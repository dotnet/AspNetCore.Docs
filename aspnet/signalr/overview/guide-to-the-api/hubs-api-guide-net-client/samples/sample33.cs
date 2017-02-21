try
{
    IEnumerable<Stock> stocks = await stockTickerHub.Invoke<IEnumerable<Stock>>("GetAllStocks");
    foreach (Stock stock in stocks)
    {
        Console.WriteLine("Symbol: {0} price: {1}", stock.Symbol, stock.Price);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error invoking GetAllStocks: {0}", ex.Message);
}