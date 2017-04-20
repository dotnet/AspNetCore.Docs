SET SignalR_LogDir=%~dp0Log\
MKDIR "%SignalR_LogDir%"
cd %~dp0
signalr.exe ipc >> "%SignalR_LogDir%SignalR_Log.txt" 2>&1
net localgroup "Performance Monitor Users" "Network Service" /ADD >> "%SignalR_LogDir%NetworkAdd.txt" 2>&1
