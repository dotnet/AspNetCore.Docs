protected void Application_Start()
{
    string connectionString = "";
    GlobalHost.DependencyResolver.UseServiceBus(connectionString, "Chat");  

    RouteTable.Routes.MapHubs();
}