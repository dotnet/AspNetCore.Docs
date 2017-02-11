async public Task NewContosoChatMessage(string name, string message)
{
    await Clients.Others.addContosoChatMessageToPage(data);
    Clients.Caller.notifyMessageSent();
}