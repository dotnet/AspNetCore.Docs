public void Configuration(IAppBuilder app)
{
    // Any connection or hub wire up and configuration should go here
    string connectionString = "";
    GlobalHost.DependencyResolver.UseServiceBus(connectionString, "Chat");  

    app.MapSignalR();
}