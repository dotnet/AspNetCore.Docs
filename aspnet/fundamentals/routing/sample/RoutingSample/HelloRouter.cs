using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;

namespace RoutingSample
{
    public class HelloRouter : IRouter
    {
        public async Task RouteAsync(RouteContext context)
        {
            var name = context.RouteData.Values["name"] as string;
            if (String.IsNullOrEmpty(name))
            {
                return;
            }
            await context.HttpContext.Response.WriteAsync($"Hi {name}!");
            context.IsHandled = true;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}