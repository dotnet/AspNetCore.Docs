public void RegisterRoutes(RouteCollection routes) {

    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    routes.MapRoute(
        "Default",                                       // Route name
        "{controller}/{action}/{id}",                    // URL w/ params
        new { controller="Home", action="Index",id="" }  // Param defaults
    );
}