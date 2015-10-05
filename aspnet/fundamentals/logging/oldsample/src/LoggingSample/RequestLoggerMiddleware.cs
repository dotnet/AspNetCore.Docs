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
        private const int BEGINREQUEST_EVENTID = 10001;
        private const int ENDREQUEST_EVENTID = 10002;
        private const int REQUESTEXCEPTION_EVENTID = 11001;

        public RequestLoggerMiddleware(RequestDelegate next, 
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(BEGINREQUEST_EVENTID, 
                "{eventId}: Handling request: {path}",
                BEGINREQUEST_EVENTID, context.Request.Path);
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Critical))
                {
                    // perform expensive operation related to logging

                    var message =
                        $"{REQUESTEXCEPTION_EVENTID}: Unexpected error handling request {context.Request.Path}:";
                    _logger.LogCritical(REQUESTEXCEPTION_EVENTID, message, ex);
                }
            }
            _logger.LogInformation(ENDREQUEST_EVENTID, 
                "{eventId}: Finished handling request.", ENDREQUEST_EVENTID);
        }
    }
}