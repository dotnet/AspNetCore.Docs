using Microsoft.AspNetCore.Builder;

namespace MiddlewareExtensibilitySample.Middleware
{
    // <snippet1>
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConventionalMiddleware>();
        }

        public static IApplicationBuilder UseFactoryActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FactoryActivatedMiddleware>();
        }
    }
    // </snippet1>
}
