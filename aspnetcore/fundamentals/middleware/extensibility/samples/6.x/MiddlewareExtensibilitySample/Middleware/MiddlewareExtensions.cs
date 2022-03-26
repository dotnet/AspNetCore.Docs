using MiddlewareExtensibilitySample.Middleware;

namespace Microsoft.AspNetCore.Builder;

// <snippet_Class>
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseConventionalMiddleware(
        this IApplicationBuilder app)
        => app.UseMiddleware<ConventionalMiddleware>();

    public static IApplicationBuilder UseFactoryActivatedMiddleware(
        this IApplicationBuilder app)
        => app.UseMiddleware<FactoryActivatedMiddleware>();
}
// </snippet_Class>
