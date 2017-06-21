public class Global : HttpApplication
{
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        AuthConfig.RegisterOpenAuth();
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        RouteTable.Routes.MapHubs();
        GlobalHost.HubPipeline.AddModule(new RejoingGroupPipelineModule());
    }
}