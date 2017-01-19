public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<Book>("Books");
        builder.EntitySet<Customer>("Customers");
        var model = builder.GetEdmModel();

        config.MapODataServiceRoute(
            routeName: "ODataRoute",
            routePrefix: null,
            model: model);

    }
}