protected void Application_Start()
{
    GlobalHost.DependencyResolver.UseRedis("server", port, "password", "AppName");

    RouteTable.Routes.MapHubs();
}