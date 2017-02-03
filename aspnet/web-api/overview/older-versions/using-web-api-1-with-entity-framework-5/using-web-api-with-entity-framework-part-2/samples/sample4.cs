public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

        // New code:
        var json = config.Formatters.JsonFormatter;
        json.SerializerSettings.PreserveReferencesHandling =
            Newtonsoft.Json.PreserveReferencesHandling.Objects;

        config.Formatters.Remove(config.Formatters.XmlFormatter);
    }
}