public void NewContosoChatMessage(string data)
{
    string userName = Clients.Caller.userName;
    string computerName = Clients.Caller.computerName;
    Clients.Others.addContosoChatMessageToPage(message, userName, computerName);
}