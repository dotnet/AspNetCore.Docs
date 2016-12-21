public class ContosoChatHub : Hub
{
    [HubMethodName("NewContosoChatMessage")]
    public void NewContosoChatMessage(string name, string message)
    {
        Clients.All.addContosoChatMessageToPage(name, message);
    }
}