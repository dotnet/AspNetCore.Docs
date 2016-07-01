using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RoutingSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Trace);

            var defaultHandler = new RouteHandler((c) =>
            {
                var routeValues = c.GetRouteData().Values;
                return c.Response.WriteAsync(
                    $"Hello world! Route values: {string.Join(", ", routeValues)}");
            });

            var routeBuilder = new RouteBuilder(app, defaultHandler);

            routeBuilder.MapGet("hello/{name}", c =>
            {
                var name = c.GetRouteValue("name");
                return c.Response.WriteAsync($"Hi, {name}!");
            });

            routeBuilder.MapRoute(
                "Track Package Route",
                "package/{operation:regex(track|create|detonate)}/{id:int}");

            var routes = routeBuilder.Build();
            app.UseRouter(routes);

            // demonstrate link generation
            app.Run(async (context) =>
            {
                var dictionary = new RouteValueDictionary
                {
                    { "operation", "create" },
                    { "id", 123}
                };

                var vpc = new VirtualPathContext(context, null, dictionary, "Track Package Route");
                var path = routes.GetVirtualPath(vpc).VirtualPath;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Menu<hr/>");
                await context.Response.WriteAsync($"<a href='{path}'>Create Package 123</a><br/>");
            });
        }
    }
}
