routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{category}",
    defaults: new { category = "all" }
);