using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.Threading.Tasks;

namespace MyApp.Middleware
{
    public class MyTerminatingMiddleware
    {
        private readonly RequestDelegate _next;

        public MyTerminatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // ASP.NET 5 middleware that may terminate the request

        public async Task Invoke(HttpContext context)
        {
            // Do something with context near the beginning of request processing.

            if (!TerminateRequest())
                await _next.Invoke(context);

            // Clean up.
        }

        private bool TerminateRequest()
        {
            return false;
        }
    }

    public static class MyTerminatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyTerminatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyTerminatingMiddleware>();
        }
    }
}
