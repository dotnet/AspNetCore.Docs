kernel.Bind(typeof(IHubConnectionContext<dynamic>)).ToMethod(context =>
                    resolver.Resolve<IConnectionManager>().GetHubContext<StockTickerHub>().Clients
                     ).WhenInjectedInto<IStockTicker>();