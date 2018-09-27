using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace DistCacheSample
{
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
            var startTimeUTC = "Not found";
            var cacheStartTimeUTC = await _cache.GetAsync("lastServerStartTimeUTC");

            if (cacheStartTimeUTC != null)
            {
                startTimeUTC = Encoding.UTF8.GetString(cacheStartTimeUTC);
            }

            httpContext.Response.Headers.Append(
                "Last-Server-Start-Time-UTC", startTimeUTC);

            await _next.Invoke(httpContext);
        }
    }

    // Add the middleware to the HTTP request pipeline.
    public static class StartTimeHeaderExtensions
    {
        public static IApplicationBuilder UseStartTimeHeader(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StartTimeHeader>();
        }
    }
}
