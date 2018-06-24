using Microsoft.AspNetCore.Builder;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseBuildActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BuildActivatedMiddleware>();
        }
    }

    #endregion snippet1
}