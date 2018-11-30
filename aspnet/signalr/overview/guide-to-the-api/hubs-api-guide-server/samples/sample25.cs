public async Task SendMessage(string name, string message)
{
    await Clients.All.addContosoChatMessageToPage(new ContosoChatMessage() { UserName = name, Message = message });
}