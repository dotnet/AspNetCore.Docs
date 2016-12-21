public class ContosoChatHub : Hub
{
    public void NewContosoChatMessage(string name, string message)
    {
        Clients.All.addNewMessageToPage(name, message);
    }
}