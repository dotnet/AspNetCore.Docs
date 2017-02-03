routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{category}/{id}",
    defaults: new { category = "all", id = RouteParameter.Optional }
);