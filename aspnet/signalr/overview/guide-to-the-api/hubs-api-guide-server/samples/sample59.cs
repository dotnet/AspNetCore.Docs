public async Task NewContosoChatMessage(string data)
{
    string userName = Clients.CallerState.userName;
    string computerName = Clients.CallerState.computerName;
    await Clients.Others.addContosoChatMessageToPage(data, userName, computerName);
}