using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

public class AppApplication : HttpApplication
{
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        // <snippet_SystemWebAdapterConfiguration>
        HttpApplicationHost.RegisterHost(builder =>
        {
            builder.Services.AddSystemWebAdapters()
                .AddProxySupport(options => options.UseForwardedHeaders = true)
                .AddRemoteAppServer(options =>
                {
                    options.ApiKey = ConfigurationManager.AppSettings["RemoteAppApiKey"];
                })
                .AddAuthenticationServer();
        });
        // </snippet_SystemWebAdapterConfiguration>
    }
}