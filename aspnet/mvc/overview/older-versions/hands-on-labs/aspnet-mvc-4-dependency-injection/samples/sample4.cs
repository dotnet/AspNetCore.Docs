protected void Application_Start()
{
	AreaRegistration.RegisterAllAreas();

	WebApiConfig.Register(GlobalConfiguration.Configuration);
	FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
	RouteConfig.RegisterRoutes(RouteTable.Routes);
	BundleConfig.RegisterBundles(BundleTable.Bundles);

	Bootstrapper.Initialise();

	AppConfig.Configure();
}