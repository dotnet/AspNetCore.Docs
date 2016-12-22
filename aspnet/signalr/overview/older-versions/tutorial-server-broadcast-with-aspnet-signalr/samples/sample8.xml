_timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);

private void UpdateStockPrices(object state)
{
    lock (_updateStockPricesLock)
    {
        if (!_updatingStockPrices)
        {
            _updatingStockPrices = true;

            foreach (var stock in _stocks.Values)
            {
                if (TryUpdateStockPrice(stock))
                {
                    BroadcastStockPrice(stock);
                }
            }

            _updatingStockPrices = false;
        }
    }
}

private bool TryUpdateStockPrice(Stock stock)
{
    // Randomly choose whether to update this stock or not
    var r = _updateOrNotRandom.NextDouble();
    if (r > .1)
    {
        return false;
    }

    // Update the stock price by a random factor of the range percent
    var random = new Random((int)Math.Floor(stock.Price));
    var percentChange = random.NextDouble() * _rangePercent;
    var pos = random.NextDouble() > .51;
    var change = Math.Round(stock.Price * (decimal)percentChange, 2);
    change = pos ? change : -change;

    stock.Price += change;
    return true;
}