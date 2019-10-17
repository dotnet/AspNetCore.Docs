using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RoutingSample
{
    public class Startup
    {
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        #endregion

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            #region snippet_RouteHandler
            var trackPackageRouteHandler = new RouteHandler(context =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync(
                    $"Hello! Route values: {string.Join(", ", routeValues)}");
            });

            var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            routeBuilder.MapRoute(
                "Track Package Route",
                "package/{operation:regex(^track|create$)}/{id:int}");

            routeBuilder.MapGet("hello/{name}", context =>
            {
                var name = context.GetRouteValue("name");
                // The route handler when HTTP GET "hello/<anything>" matches
                // To match HTTP GET "hello/<anything>/<anything>, 
                // use routeBuilder.MapGet("hello/{*name}"
                return context.Response.WriteAsync($"Hi, {name}!");
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);
            #endregion

            #region snippet_Dictionary
            app.Run(async (context) =>
            {
                var dictionary = new RouteValueDictionary
                {
                    { "operation", "create" },
                    { "id", 123}
                };

                var vpc = new VirtualPathContext(context, null, dictionary, 
                    "Track Package Route");
                var path = routes.GetVirtualPath(vpc).VirtualPath;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Menu<hr/>");
                await context.Response.WriteAsync(
                    $"<a href='{path}'>Create Package 123</a><br/>");
            });
            #endregion
        }
    }
}
