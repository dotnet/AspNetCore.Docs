public class MyMvcApplication : HttpApplication {

    void App_Start() {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
    }

    public static void RegisterRoutes(RouteCollection routes) {
        routes.MapRoute("default", "{controller}/{action}/{id}", ...);
    }
}