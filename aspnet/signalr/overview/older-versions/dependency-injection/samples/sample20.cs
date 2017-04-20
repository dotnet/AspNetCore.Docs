public static class RegisterHubs
{
    public static void Start()
    {
        var kernel = new StandardKernel();
        var resolver = new NinjectSignalRDependencyResolver(kernel);

        kernel.Bind<IStockTicker>()
            .To<Microsoft.AspNet.SignalR.StockTicker.StockTicker>()
            .InSingletonScope();

        kernel.Bind<IHubConnectionContext>().ToMethod(context =>
                resolver.Resolve<IConnectionManager>().
                    GetHubContext<StockTickerHub>().Clients
            ).WhenInjectedInto<IStockTicker>();

        var config = new HubConfiguration()
        {
            Resolver = resolver
        };

        // Register the default hubs route: ~/signalr/hubs
        RouteTable.Routes.MapHubs(config);
    }
}