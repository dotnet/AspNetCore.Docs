protected void Application_Start()
{
    string sqlConnectionString = "Connecton string to your SQL DB";
    GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);

    RouteTable.Routes.MapHubs();
    // ...
}