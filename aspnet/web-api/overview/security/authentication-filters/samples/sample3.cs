public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        config.Filters.Add(new IdentityBasicAuthentication());

        // Other configuration code not shown...
    }
}
