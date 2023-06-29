using Microsoft.AspNetCore.Diagnostics;

namespace ErrorHandlingSample
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CustomExceptionHandler> logger;
        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
            this.logger = logger;
        }
        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            logger.LogError("Error Message: {exceptionMessage}", exceptionMessage);
            logger.LogError("Time of occurrence {time}", DateTime.Now);
            // Return false to continue with the default behavior
            return ValueTask.FromResult(false);
        }
    }
}
