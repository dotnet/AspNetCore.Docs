public void RegisterRoutes(RouteCollection routes) {

   routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    routes.MapRoute(                                        
        "UpcomingDinners",                               // Route name
        "Dinners/Page/{page}",                           // URL with params
        new { controller = "Dinners", action = "Index" } // Param defaults
    );

    routes.MapRoute(
        "Default",                                       // Route name
        "{controller}/{action}/{id}",                    // URL with params
        new { controller="Home", action="Index",id="" }  // Param defaults
    );
}

void Application_Start() {
    RegisterRoutes(RouteTable.Routes);
}