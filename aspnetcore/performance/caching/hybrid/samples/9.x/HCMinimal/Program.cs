#define Version3
// Version1: Register with options, GetOrCreateAsync stateless
// Version2: Register no options, GetOrCreateAsync stateful
// Version3: Register no options, GetOrCreateAsync stateless with options

// HCMinimal2 demonstrates how to use a custom serializer.
// This one, HCMinimal, is the main sample app.

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Hybrid;

namespace HCMinimal;

public class Program
{
    public static void Main(string[] args)
    {
#if Version2 || Version3
        //<snippet_noconfig>
        // Add services to the container.
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddHybridCache();
        //</snippet_noconfig>
#endif
#if Version1
        // <snippet_globaloptions>
        // Add services to the container.
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddHybridCache(options =>
            {
                options.MaximumPayloadBytes = 1024 * 1024;
                options.MaximumKeyLength = 1024;
                options.DefaultEntryOptions = new HybridCacheEntryOptions
                {
                    Expiration = TimeSpan.FromMinutes(5),
                    LocalCacheExpiration = TimeSpan.FromMinutes(5)
                };
            });
        //</snippet_globaloptions>
#endif
        builder.Services.AddSingleton<SomeService>();

        var app = builder.Build();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/{name}/{ID}", async (HttpContext context, string? name, Int32 ID) =>
        {
            var someService = context.RequestServices.GetRequiredService<SomeService>();
            var someInfo = await someService.GetSomeInfoAsync(name!, ID);
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(someInfo);
        });
        //</snippet_mapget>
        app.Run();
    }
}

#if Version1
//<snippet_getorcreate>
public class SomeService(HybridCache cache)
{
    private HybridCache _cache = cache;

    public async Task<string> GetSomeInfoAsync(string name, int id, CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(
            $"{name}-{id}", // Unique key to the cache entry
            async cancel => await GetDataFromTheSourceAsync(name, id, cancel),
            cancellationToken: token
        );
    }

    public async Task<string> GetDataFromTheSourceAsync(string name, int id, CancellationToken token)
    {
        string someInfo = $"someinfo-{name}-{id}";
        return someInfo;
    }
}
//</snippet_getorcreate>
#endif
#if Version3
//<snippet_getorcreateoptions>
public class SomeService(HybridCache cache)
{
    private HybridCache _cache = cache;

    public async Task<string> GetSomeInfoAsync(string name, int id, CancellationToken token = default)
    {
        var tags = new List<string> { "tag1", "tag2", "tag3" };
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(1),
            LocalCacheExpiration = TimeSpan.FromMinutes(1)
        };
        return await _cache.GetOrCreateAsync(
            $"{name}-{id}", // Unique key to the cache entry
            async cancel => await GetDataFromTheSourceAsync(name, id, cancel),
            entryOptions,
            tags,
            cancellationToken: token
        );
    }
    
    public async Task<string> GetDataFromTheSourceAsync(string name, int id, CancellationToken token)
    {
        string someInfo = $"someinfo-{name}-{id}";
        return someInfo;
    }
}
//</snippet_getorcreateoptions>
#endif
#if Version2
//<snippet_getorcreatestate>
public class SomeService(HybridCache cache)
{
    private HybridCache _cache = cache;

    public async Task<string> GetSomeInfoAsync(string name, int id, CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(
            $"{name}-{id}", // Unique key to the cache entry
            (name, id, obj: this),
            static async (state, token) =>
            await state.obj.GetDataFromTheSourceAsync(state.name, state.id, token),
            cancellationToken: token
        );
    }

    public async Task<string> GetDataFromTheSourceAsync(string name, int id, CancellationToken token)
    {
        string someInfo = $"someinfo-{name}-{id}";
        return someInfo;
    }
}
//</snippet_getorcreatestate>
#endif

