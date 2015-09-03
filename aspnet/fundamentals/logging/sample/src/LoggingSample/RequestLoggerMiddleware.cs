using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Internal;

namespace LoggingSample
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly static Random _random = new Random();

        public RequestLoggerMiddleware(RequestDelegate next, 
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var eventId = _random.Next();
            _logger.LogInformation(eventId, 
                "{eventId}: Handling request: {path}", 
                eventId, context.Request.Path);
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Critical))
                {
                    // perform expensive operation related to logging

                    var values = new FormattedLogValues("{eventId}: Unexpected error handling request {path}:",
                        eventId, context.Request.Path);
                    _logger.LogCritical(eventId, values, ex);
                }
            }
            _logger.LogInformation(eventId, 
                "{eventId}: Finished handling request.", eventId);
        }
    }
}