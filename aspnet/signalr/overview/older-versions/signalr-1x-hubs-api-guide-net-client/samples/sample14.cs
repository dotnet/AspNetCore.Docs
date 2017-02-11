public class StockTickerHub : Hub
{
    public void NotifyAllClients()
    {
         Clients.All.Notify();
    }
}