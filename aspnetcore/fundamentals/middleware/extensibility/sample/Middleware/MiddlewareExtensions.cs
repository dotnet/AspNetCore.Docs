using Microsoft.AspNetCore.Builder;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareViaConventionalActivation(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareViaConventionalActivation>();
        }

        public static IApplicationBuilder UseMiddlewareViaIMiddlewareFactoryActivation(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareViaIMiddlewareFactoryActivation>();
        }
    }
    #endregion
}
