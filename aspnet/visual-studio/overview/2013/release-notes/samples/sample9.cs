protected void Application_Start(object sender, EventArgs e) 
{
    var hubConfiguration = new HubConfiguration();
    hubConfiguration.EnableCrossDomain = true;
    RouteTable.Routes.MapHubs(hubConfiguration);
}