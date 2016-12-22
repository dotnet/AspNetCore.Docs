[HubName("stockTicker")]
public class StockTickerHub : Hub
{
    private readonly StockTicker _stockTicker;

    //public StockTickerHub() : this(StockTicker.Instance) { }

    public StockTickerHub(StockTicker stockTicker)
    {
        if (stockTicker == null)
        {
            throw new ArgumentNullException("stockTicker");
        }
        _stockTicker = stockTicker;
    }

    // ...