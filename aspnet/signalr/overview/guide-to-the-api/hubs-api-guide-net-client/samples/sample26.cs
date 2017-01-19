public IEnumerable<Stock> AddStock(Stock stock)
{
    _stockTicker.AddStock(stock);
    return _stockTicker.GetAllStocks();
}