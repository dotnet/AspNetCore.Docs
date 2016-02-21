using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.Threading.Tasks;

using System.Text;

namespace Asp.Net5.Middleware
{
    public class AddLinesMiddleware
    {
        private readonly RequestDelegate _next;

        public AddLinesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // If you do not add this, the response sent to the browser will have no ContentType at all,
            // resulting in the browser showing the response as text instead of html.
            context.Response.ContentType = "text/html";

            await context.Response.WriteAsync("Added by AddLinesMiddleware before _next.Invoke<hr>");

            await _next.Invoke(context);

            await context.Response.WriteAsync("<hr>Added by AddLinesMiddleware after _next.Invoke");
        }
    }

    public static class AddLinesMiddlewareExtensions
    {
        public static IApplicationBuilder UseAddLines(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddLinesMiddleware>();
        }
    }
}
