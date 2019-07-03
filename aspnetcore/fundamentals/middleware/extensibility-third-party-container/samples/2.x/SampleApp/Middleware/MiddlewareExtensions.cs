using Microsoft.AspNetCore.Builder;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSimpleInjectorActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleInjectorActivatedMiddleware>();
        }
    }
    #endregion
}
