public async Task NewContosoChatMessage(string name, string message)
{
    await Clients.Others.addContosoChatMessageToPage(data);
    await Clients.Caller.notifyMessageSent();
}