public class MvcApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        System.Data.Entity.Database.SetInitializer(new TriviaDatabaseInitializer()); 

        AreaRegistration.RegisterAllAreas();
        GlobalConfiguration.Configure(WebApiConfig.Register);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
}