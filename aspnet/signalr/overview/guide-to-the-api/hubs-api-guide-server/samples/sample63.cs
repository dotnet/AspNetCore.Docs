public class MyHub : Hub
{
    public async Task Send(string message)
    {
        if(message.Contains("<script>"))
        {
            throw new HubException("This message will flow to the client", new { user = Context.User.Identity.Name, message = message });
        }

        await Clients.All.send(message);
    }
}