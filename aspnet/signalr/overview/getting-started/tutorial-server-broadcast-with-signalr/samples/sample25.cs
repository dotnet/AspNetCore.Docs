public void OpenMarket()
{
    lock (_marketStateLock)
    {
        if (MarketState != MarketState.Open)
        {
            _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
            MarketState = MarketState.Open;
            BroadcastMarketStateChange(MarketState.Open);
        }
    }
}

public void CloseMarket()
{
    lock (_marketStateLock)
    {
        if (MarketState == MarketState.Open)
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
            MarketState = MarketState.Closed;
            BroadcastMarketStateChange(MarketState.Closed);
        }
    }
}

public void Reset()
{
    lock (_marketStateLock)
    {
        if (MarketState != MarketState.Closed)
        {
            throw new InvalidOperationException("Market must be closed before it can be reset.");
        }
        LoadDefaultStocks();
        BroadcastMarketReset();
    }
}