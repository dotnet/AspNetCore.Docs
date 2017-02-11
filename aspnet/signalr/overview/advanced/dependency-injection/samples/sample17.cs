kernel.Bind<IStockTicker>()
    .To<Microsoft.AspNet.SignalR.StockTicker.StockTicker>()  // Bind to StockTicker.
    .InSingletonScope();  // Make it a singleton object.