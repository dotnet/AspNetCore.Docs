using DependencyInjectionSample.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Middleware
{
    #region snippet
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger,
            IOperationTransient transientOperation,
            IOperationSingleton singletonOperation)
        {
            _logger = logger;
            _transientOperation = transientOperation;
            _singletonOperation = singletonOperation;
            _next = next;
        }

        #region snippet2
        public async Task InvokeAsync(HttpContext context,
            IOperationScoped scopedOperation)
        {
            _logger.LogInformation("Transient: " + _transientOperation.OperationId);
            _logger.LogInformation("Scoped: "    + scopedOperation.OperationId);
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
