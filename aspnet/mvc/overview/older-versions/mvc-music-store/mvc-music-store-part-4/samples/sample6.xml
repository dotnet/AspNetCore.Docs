protected void Application_Start()
{
    System.Data.Entity.Database.SetInitializer(
	new MvcMusicStore.Models.SampleData());
    AreaRegistration.RegisterAllAreas();
    RegisterGlobalFilters(GlobalFilters.Filters);
    RegisterRoutes(RouteTable.Routes);
 }