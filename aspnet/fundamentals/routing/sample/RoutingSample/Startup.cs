using System.Collections.Generic;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Routing.Template;
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
            loggerFactory.AddConsole(minLevel: LogLevel.Verbose);
            app.UseIISPlatformHandler();

            var routeBuilder = new RouteBuilder();
            routeBuilder.ServiceProvider = app.ApplicationServices;

            routeBuilder.Routes.Add(new TemplateRoute(
                new HelloRouter(),
                "hello/{name:alpha}",
                app.ApplicationServices.GetService<IInlineConstraintResolver>()));

            var endpoint1 = new DelegateRouter(async (context) =>
                            await context
                                .HttpContext
                                .Response
                                .WriteAsync("Hello world! Route Values: " +
                                    string.Join("", context.RouteData.Values)));

            routeBuilder.DefaultHandler = endpoint1;

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

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
