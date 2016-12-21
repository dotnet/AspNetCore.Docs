public class ContosoChatHub : Hub
{
    public override Task OnConnected()
    {
        var version = Context.QueryString['version'];
        if (version != '1.0')
        {
            Clients.Caller.notifyWrongVersion();
        }
        return base.OnConnected();
    }
}