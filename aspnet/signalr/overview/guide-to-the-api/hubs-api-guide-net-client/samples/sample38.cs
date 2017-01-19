stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock => 
    Dispatcher.InvokeAsync(() =>
        {
            textBox.Text += string.Format("Stock update for {0} new price {1}\n", stock.Symbol, stock.Price);
        })
);