public void NewContosoChatMessage(string name, string message)
{
    string methodToCall = "addContosoChatMessageToPage";
    IClientProxy proxy = Clients.All;
    proxy.Invoke(methodToCall, name, message);
}