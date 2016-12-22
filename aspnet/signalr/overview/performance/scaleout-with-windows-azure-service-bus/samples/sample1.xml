public void Configuration(IAppBuilder app)
{
    string connectionString = "Service Bus connection string";
    GlobalHost.DependencyResolver.UseServiceBus(connectionString, "YourAppName");

    app.MapSignalR();
    // ...
}