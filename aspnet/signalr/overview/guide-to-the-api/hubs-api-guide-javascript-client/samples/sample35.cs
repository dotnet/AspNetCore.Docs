public class ContosoChatHub : Hub
{
    public void NewContosoChatMessage(ChatMessage message)
    {
        Clients.All.addContosoChatMessageToPage(message);
    }
}