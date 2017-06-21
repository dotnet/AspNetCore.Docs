hubConnection = new hubConnection("http://www.contoso.com/");
hubConnection.AddClientCertificate(X509Certificate.CreateFromCertFile("MyCert.cer"));
IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("StockTickerHub");
stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock => Console.WriteLine("Stock update for {0} new price {1}", stock.Symbol, stock.Price));
await connection.Start();