using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Middleware
{
    #region snippet
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly IOperationSingleton _singletonOperation;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger,
            IOperationSingleton singletonOperation)
        {
            _logger = logger;
            _singletonOperation = singletonOperation;
            _next = next;
        }

        #region snippet2
        public async Task InvokeAsync(HttpContext context,
            IOperationTransient transientOperation, IOperationScoped scopedOperation)
        {
            _logger.LogInformation("Transient: " + transientOperation.OperationId);
            _logger.LogInformation("Scoped: " + scopedOperation.OperationId);
            _logger.LogInformation("Singleton: " + _singletonOperation.OperationId);

            await _next(context);
        }
        #endregion
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
    #endregion
}
