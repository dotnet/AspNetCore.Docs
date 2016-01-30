using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace DistCacheSample
{
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class StartTimeHeader
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _cache;

        public StartTimeHeader(RequestDelegate next,
            IDistributedCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string startTimeString = "Not found.";
            var value = await _cache.GetAsync("lastServerStartTime");
            if (value != null)
            {
                startTimeString = Encoding.UTF8.GetString(value);
            }

            httpContext.Response.Headers.Append("Last-Server-Start-Time", startTimeString);

            await _next.Invoke(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class StartTimeHeaderExtensions
    {
        public static IApplicationBuilder UseStartTimeHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StartTimeHeader>();
        }
    }
}
