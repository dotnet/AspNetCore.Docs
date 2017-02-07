private readonly static Lazy<StockTicker> _instance = new Lazy<StockTicker>(() => new StockTicker(GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients));

public static StockTicker Instance
{
    get
    {
        return _instance.Value;
    }
}