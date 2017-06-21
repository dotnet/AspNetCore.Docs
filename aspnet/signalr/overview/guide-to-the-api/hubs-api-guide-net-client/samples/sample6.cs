public class StockTickerHub : Hub
{
    public override Task OnConnected()
    {
        var version = Context.QueryString["contosochatversion"];
        if (version != "1.0")
        {
            Clients.Caller.notifyWrongVersion();
        }
        return base.OnConnected();
    }
}