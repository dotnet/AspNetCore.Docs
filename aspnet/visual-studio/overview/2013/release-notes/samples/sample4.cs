public static class WebApiConfig 
{ 
    public static void Register(HttpConfiguration config) 
    { 
        config.Routes.MapHttpBatchRoute( 
            routeName: "WebApiBatch", 
            routeTemplate: "api/batch", 
            batchHandler: new DefaultHttpBatchHandler(GlobalConfiguration.DefaultServer)); 
    } 
}