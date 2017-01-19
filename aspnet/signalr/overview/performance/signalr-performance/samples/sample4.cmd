cd %windir%\System32\inetsrv\
appcmd.exe set config /section:system.webserver/serverRuntime 
        /appConcurrentRequestLimit:10000