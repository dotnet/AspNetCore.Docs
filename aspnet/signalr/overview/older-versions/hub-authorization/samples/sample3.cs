public class Global : HttpApplication
{
    void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes.MapHubs();
        GlobalHost.HubPipeline.RequireAuthentication();
    }
}