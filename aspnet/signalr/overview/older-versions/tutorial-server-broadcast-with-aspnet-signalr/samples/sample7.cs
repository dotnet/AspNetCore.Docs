private StockTicker(IHubConnectionContext clients)
{
    Clients = clients;

    _stocks.Clear();
    var stocks = new List<Stock>
    {
        new Stock { Symbol = "MSFT", Price = 30.31m },
        new Stock { Symbol = "APPL", Price = 578.18m },
        new Stock { Symbol = "GOOG", Price = 570.30m }
    };
    stocks.ForEach(stock => _stocks.TryAdd(stock.Symbol, stock));

    _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
}

public IEnumerable<Stock> GetAllStocks()
{
    return _stocks.Values;
}