net stop w3svc
Remove-Item -Path "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files\root\*" -Force -Recurse
net start w3svc