using System.Web.Mvc;
using System.Web.Routing;

namespace Asp.Net4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ignore requests for .report urls
            routes.IgnoreRoute("{*allreports}", new { allreports = @".*\.report(\?.*)?" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
