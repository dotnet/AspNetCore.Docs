using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace RoutingSample
{
    public static class HelloExtensions
    {
        public static IRouteBuilder AddHelloRoute(this IRouteBuilder routeBuilder,
            IApplicationBuilder app)
        {
            routeBuilder.Routes.Add(new Route(new HelloRouter(),
                "hello/{name:alpha}", 
                app.ApplicationServices.GetService<IInlineConstraintResolver>()));

            return routeBuilder;
        }
    }
}