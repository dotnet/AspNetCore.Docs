protected void Application_Start()
{
	string sqlConnectionString = "<add your SQL connection string here>";
	GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);

	RouteTable.Routes.MapHubs();
}