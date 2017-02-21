public MarketState MarketState
{
    get { return _marketState; }
    private set { _marketState = value; }
}

public enum MarketState
{
    Closed,
    Open
}