[HubName("stockTicker")]
public class StockTickerHub : Hub
{
    private readonly IStockTicker _stockTicker;

    public StockTickerHub(IStockTicker stockTicker)
    {
        if (stockTicker == null)
        {
            throw new ArgumentNullException("stockTicker");
        }
        _stockTicker = stockTicker;
    }