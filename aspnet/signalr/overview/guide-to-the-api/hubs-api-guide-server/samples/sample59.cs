public void NewContosoChatMessage(string data)
{
    string userName = Clients.CallerState.userName;
    string computerName = Clients.CallerState.computerName;
    Clients.Others.addContosoChatMessageToPage(data, userName, computerName);
}