hubConnection = new hubConnection("http://www.contoso.com/");
connection.Headers.Add("headername", "headervalue");
IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("StockTickerHub");
stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock => Console.WriteLine("Stock update for {0} new price {1}", stock.Symbol, stock.Price));
await connection.Start();