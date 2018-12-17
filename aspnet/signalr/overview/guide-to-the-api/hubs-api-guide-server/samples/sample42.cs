public async Task NewContosoChatMessage(string name, string message)
{
    string methodToCall = "addContosoChatMessageToPage";
    IClientProxy proxy = Clients.All;
    await proxy.Invoke(methodToCall, name, message);
}