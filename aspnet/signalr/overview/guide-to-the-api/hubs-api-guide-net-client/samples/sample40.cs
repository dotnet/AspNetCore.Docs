stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock => 
    Console.WriteLine("Symbol {0} Price {1}", stock.Symbol, stock.Price));