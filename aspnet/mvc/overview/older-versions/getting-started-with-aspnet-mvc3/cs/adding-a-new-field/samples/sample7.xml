protected void Application_Start()
{
    Database.SetInitializer<MovieDBContext>(new MovieInitializer());

    AreaRegistration.RegisterAllAreas();
    RegisterGlobalFilters(GlobalFilters.Filters);
    RegisterRoutes(RouteTable.Routes);
}