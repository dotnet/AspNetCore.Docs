stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock => 
    // Context is a reference to SynchronizationContext.Current
    Context.Post(delegate
    {
        textBox.Text += string.Format("Stock update for {0} new price {1}\n", stock.Symbol, stock.Price);
    }, null)
);