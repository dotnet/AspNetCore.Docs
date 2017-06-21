private readonly static Lazy<StockTicker> _instance =
    new Lazy<StockTicker>(() => new StockTicker(GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients));

private StockTicker(IHubConnectionContext<dynamic> clients)
{
    Clients = clients;

    // Remainder of constructor ...
}

private IHubConnectionContext<dynamic> Clients
{
    get;
    set;
}

private void BroadcastStockPrice(Stock stock)
{
    Clients.All.updateStockPrice(stock);
}