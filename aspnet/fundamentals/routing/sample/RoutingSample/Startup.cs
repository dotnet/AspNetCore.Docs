using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RoutingSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Trace);

            var defaultHandler = new RouteHandler((c) => 
                c.Response.WriteAsync($"Hello world! Route values: " +
                $"{string.Join(", ", c.GetRouteData().Values)}")
                );

            var routeBuilder = new RouteBuilder(app, defaultHandler);

            routeBuilder.AddHelloRoute(app);

            routeBuilder.MapRoute(
                "Track Package Route",
                "package/{operation:regex(track|create|detonate)}/{id:int}");

            app.UseRouter(routeBuilder.Build());

            // demonstrate link generation
            var trackingRouteCollection = new RouteCollection();
            trackingRouteCollection.Add(routeBuilder.Routes[1]); // "Track Package Route"

            app.Run(async (context) =>
            {
                var dictionary = new RouteValueDictionary
                {
                    {"operation","create" },
                    {"id",123}
                };

                var vpc = new VirtualPathContext(context,
                    null, dictionary, "Track Package Route");

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Menu<hr/>");
                await context.Response.WriteAsync(@"<a href='" +
                    trackingRouteCollection.GetVirtualPath(vpc).VirtualPath +
                    "'>Create Package 123</a><br/>");
            });
        }
    }
}
