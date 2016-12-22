public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

        var kernel = new StandardKernel();
        var resolver = new NinjectSignalRDependencyResolver(kernel);

        kernel.Bind<IStockTicker>()
            .To<Microsoft.AspNet.SignalR.StockTicker.StockTicker>()  // Bind to StockTicker.
            .InSingletonScope();  // Make it a singleton object.

        kernel.Bind(typeof(IHubConnectionContext<dynamic>)).ToMethod(context =>
                resolver.Resolve<IConnectionManager>().GetHubContext<StockTickerHub>().Clients
                    ).WhenInjectedInto<IStockTicker>();

        var config = new HubConfiguration();
        config.Resolver = resolver;
        Microsoft.AspNet.SignalR.StockTicker.Startup.ConfigureSignalR(app, config);
    }
}