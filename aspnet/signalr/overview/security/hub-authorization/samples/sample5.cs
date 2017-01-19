public Task SendChatMessage(string message)
{
    string name;
    var user = Context.User;

    if (user.Identity.IsAuthenticated)
    {
        name = user.Identity.Name;
    }
    else
    {
        name = "anonymous";
    }
    return Clients.All.addMessageToPage(name, message);
}