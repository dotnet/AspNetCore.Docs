protected void Application_Start()
{
    string connectionString = "Service Bus connection string";
    GlobalHost.DependencyResolver.UseServiceBus(connectionString, "YourAppName");

    RouteTable.Routes.MapHubs();
    // ...
}