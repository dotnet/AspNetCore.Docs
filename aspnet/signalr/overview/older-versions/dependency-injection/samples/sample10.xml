public class StockTicker
{
    //private readonly static Lazy<StockTicker> _instance = new Lazy<StockTicker>(
    //    () => new StockTicker(GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients));

    // Important! Make this constructor public.
    public StockTicker(IHubConnectionContext clients)
    {
        if (clients == null)
        {
            throw new ArgumentNullException("clients");
        }

        Clients = clients;
        LoadDefaultStocks();
    }

    //public static StockTicker Instance
    //{
    //    get
    //    {
    //        return _instance.Value;
    //    }
    //}