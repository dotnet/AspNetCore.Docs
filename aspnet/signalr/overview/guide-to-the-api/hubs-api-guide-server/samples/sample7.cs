public class ContosoChatHub : Hub
{
    public async Task NewContosoChatMessage(string name, string message)
    {
        await Clients.All.addNewMessageToPage(name, message);
    }
}