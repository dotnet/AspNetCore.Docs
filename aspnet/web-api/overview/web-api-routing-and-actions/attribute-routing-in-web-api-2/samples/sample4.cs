protected void Application_Start()
{
    // WARNING - Not compatible with attribute routing.
    WebApiConfig.Register(GlobalConfiguration.Configuration);
}