private void BroadcastMarketStateChange(MarketState marketState)
{
    switch (marketState)
    {
        case MarketState.Open:
            Clients.All.marketOpened();
            break;
        case MarketState.Closed:
            Clients.All.marketClosed();
            break;
        default:
            break;
    }
}

private void BroadcastMarketReset()
{
    Clients.All.marketReset();
}