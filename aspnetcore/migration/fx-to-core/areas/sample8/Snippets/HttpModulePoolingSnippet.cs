using System.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;

class HttpModulePoolingSnippet
{
    void Snippet(WebApplicationBuilder builder)
    {
// <snippet_ObjectPool>
        builder.Services.TryAddSingleton<ObjectPool<HttpApplication>>(sp =>
        {
            // Recommended to use the in-built policy as that will ensure everything is initialized correctly and is not intended to be replaced
            var policy = sp.GetRequiredService<IPooledObjectPolicy<HttpApplication>>();

            // Can use any provider needed
            var provider = new DefaultObjectPoolProvider();

            // Use the provider to create a custom pool that will then be used for the application.
            return provider.Create(policy);
        });
// </snippet_ObjectPool>
    }
}
