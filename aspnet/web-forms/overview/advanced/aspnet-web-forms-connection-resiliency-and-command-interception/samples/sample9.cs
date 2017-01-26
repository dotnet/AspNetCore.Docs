void Application_Start(object sender, EventArgs e)
{
	// Code that runs on application startup
	RouteConfig.RegisterRoutes(RouteTable.Routes);
	BundleConfig.RegisterBundles(BundleTable.Bundles);

	// Initialize the product database.
	Database.SetInitializer(new ProductDatabaseInitializer());

	// Create administrator role and user.
	RoleActions roleActions = new RoleActions();
	roleActions.createAdmin();

	// Add Routes.
	RegisterRoutes(RouteTable.Routes);

	// Logging.
	DbInterception.Add(new InterceptorTransientErrors());
	DbInterception.Add(new InterceptorLogging());
  
}