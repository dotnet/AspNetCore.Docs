using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.Threading.Tasks;

namespace Asp.Net5.Middleware
{
    public class SimpleAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query["iamevil"] == "true")
            {
                context.Response.StatusCode = 403;
                return;
            }

            await _next.Invoke(context);
        }
    }

    public static class SimpleAuthorizeExtensions
    {
        public static IApplicationBuilder UseSimpleAuthorize(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleAuthorizeMiddleware>();
        }
    }
}
