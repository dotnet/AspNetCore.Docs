public static void ConfigureSignalR(IAppBuilder app, HubConfiguration config)
{
    app.MapSignalR(config);
}