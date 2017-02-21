public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
        config.EnableCors();

        // ...
    }
}