kernel.Bind<IHubConnectionContext>().ToMethod(context =>
	resolver.Resolve<IConnectionManager>().GetHubContext<StockTickerHub>().Clients
).WhenInjectedInto<IStockTicker>();