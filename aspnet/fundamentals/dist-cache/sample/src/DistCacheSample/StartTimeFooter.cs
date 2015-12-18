using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Microsoft.Extensions.Caching.SqlServer;

namespace DistCacheSample
{
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class StartTimeFooter
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _cache;

        public StartTimeFooter(RequestDelegate next,
            IDistributedCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next.Invoke(httpContext);

            string startTimeString = "Not found.";
            var value = await _cache.GetAsync("serverStartTime");
            if(value != null)
            {
                startTimeString = Encoding.UTF8.GetString(value);
            }

            await httpContext.Response.WriteAsync("<hr />Server Started At: " + startTimeString);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class StartTimeFooterExtensions
    {
        public static IApplicationBuilder UseStartTimeFooter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StartTimeFooter>();
        }
    }
}
