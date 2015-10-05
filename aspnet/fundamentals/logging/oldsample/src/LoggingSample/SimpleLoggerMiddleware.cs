using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System.Threading.Tasks;

namespace LoggingSample
{
    public class SimpleLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SimpleLoggerMiddleware> _logger;

        public SimpleLoggerMiddleware(RequestDelegate next, 
            ILogger<SimpleLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Handling request: {path}", 
                context.Request.Path);

            await _next.Invoke(context);

            _logger.LogInformation("Finished handling request.");
        }
    }
}