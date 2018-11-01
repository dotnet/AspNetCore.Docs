public async Task NewContosoChatMessage(string data)
{
    string userName = Clients.Caller.userName;
    string computerName = Clients.Caller.computerName;
    await Clients.Others.addContosoChatMessageToPage(message, userName, computerName);
}