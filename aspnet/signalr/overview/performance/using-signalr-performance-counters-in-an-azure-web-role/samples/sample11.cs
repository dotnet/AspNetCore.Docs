using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebRole1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SignalRHelper.SignalRDiagnosticHelper.RegisterSignalRPerfCounters();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}