#define TypeSpecific // TypeSpecific or Factory

// HCMinimal is the main sample app.
// This one, HCMinimal2, demonstrates how to use a custom serializer.

// This sample app uses a Google.Protobuf type alongside
// an unrelated POCO type, to illustrate that the POCO
// type is unaffected by the Google.Protobuf serialization
// configuration. Multiple serialization setups
// are possible in tandem, including multiple serializer factories.
// Adding a factory is interpreted as an override, so
// in the case of multiple factories claiming a type, the last-added
// factory wins. In other words, the factories are processed in last-to-first
// order and the first to claim a type in that reverse order wins.

namespace HCMinimal;
using HCMinimal;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
#if TypeSpecific
        // <snippet_withserializer>
        // Add services to the container.

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddHybridCache(options =>
            {
                options.DefaultEntryOptions = new HybridCacheEntryOptions
                {
                    Expiration = TimeSpan.FromSeconds(10),
                    LocalCacheExpiration = TimeSpan.FromSeconds(5)
                };
            }).AddSerializer<SomeProtobufMessage, 
                GoogleProtobufSerializer<SomeProtobufMessage>>();
        //</snippet_withserializer>
#endif
#if Factory
        // <snippet_withserializerfactory>
        // Add services to the container.

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddHybridCache(options =>
        {
            options.DefaultEntryOptions = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromSeconds(10),
                LocalCacheExpiration = TimeSpan.FromSeconds(5)
            };
        }).WithSerializerFactory<GoogleProtobufSerializerFactory>();
        // </snippet_withserializerfactory>
#endif
        // <snippet_redis>
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = 
                builder.Configuration.GetConnectionString("RedisConnectionString");
        });
        // </snippet_redis>

        builder.Services.AddSingleton<SomeService>();

        var app = builder.Build();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/{ID}", async (HttpContext context, Int32 ID) =>
        {
            var someService = context.RequestServices.GetRequiredService<SomeService>();
            var someProtobufMessage = await someService.GetSomeProtobufMessageFromCacheAsync(ID);
            var someMessage = await someService.GetSomeMessageFromCacheAsync(ID);

            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/html";
            string html = "";

            // Display the cached data and the serialized version of that data.
            // The data in the out-of-process secondary cache is serialized, so get
            // the cache entry directly from the secondary cache to see how it was serialized.

            html += "<h1>SomeMessage</h1>";
            html += $"<p>{someMessage.Name} {someMessage.Id} {someMessage.Time}</p>";
            html += $"<p>{await someService.GetL2CacheEntryAsync(ID)}</p>";

            // We expect to see Protobuf serialization for the Protobuf type.
            html += "<h1>SomeProtobufMessage</h1>";
            html += $"<p>{someProtobufMessage.Name} {someProtobufMessage.Id} {someProtobufMessage.Time}</p>";
            html += $"<p>{await someService.GetL2ProtobufCacheEntryAsync(ID)}</p>";

            await context.Response.WriteAsync(html);

            // Sample output - response to an HTTP request to https://localhost:{port}/42
            // We expect to see JSON from the non-protobuf type because HybridCache does that
            // by default when no serializer is specified.

            // SomeMessage
            // Tom 42 5/28/2024 12:13:18 PM
            //Encoding.UTF8: { "Id":42,"Name":"Tom","Time":"5/28/2024 12:13:18 PM"}

            // SomeProtobufMessage
            // Tom 42 5/28/2024 12:13:18 PM
            //Encoding.UTF8: *Tom 5/28/2024 12:13:18 PM

            // When the data comes from cache, the Time field stays the same;
            // when the data comes from the source, the Time field is updated.
        });

        app.Run();
    }
}

public class SomeService(HybridCache cache, IDistributedCache l2)
{
    private readonly HybridCache _cache = cache;
    private readonly IDistributedCache _l2 = l2;

    // The following Get...FromCache methods call GetOrCreate on HybridCache.
    // If the data is not in the cache, the factory method is called
    // to get the data from the source, and the data is stored in the cache.

    public async Task<SomeMessage>
        GetSomeMessageFromCacheAsync(int id, CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(
            $"SomeMessage_{id}", // Unique key to the cache entry
            async cancel => await GetSomeMessageFromSourceAsync(id, token),
            cancellationToken: token
        );
    }

    public async Task<SomeProtobufMessage>
        GetSomeProtobufMessageFromCacheAsync(int id, CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(
            $"Protobuf_{id}", // Unique key to the cache entry
            async cancel => await GetSomeProtobufMessageFromSourceAsync(id, token),
            cancellationToken: token
        );
    }

    // The following GetL2...CacheEntry methods get the cache entry directly from
    // the secondary cache.
    // The data in the secondary cache is serialized, so the output is a string
    // representation of the serialized data.

    public async Task<string> GetL2CacheEntryAsync(int id)
    {
        var bytes = await _l2.GetAsync($"SomeMessage_{id}") ?? [];
        return "Encoding.UTF8:  " + Encoding.UTF8.GetString(bytes);
    }

    public async Task<string> GetL2ProtobufCacheEntryAsync(int id)
    {
        var bytes = await _l2.GetAsync($"Protobuf_{id}") ?? [];
        return "Encoding.UTF8:  " + Encoding.UTF8.GetString(bytes);
    }

    // Get...FromSource methods simulate getting data from the real source (not cache).
    // When the data in the HTTP response comes from cache, the Time field in the output stays
    // the same; when the data comes from the source, the Time field in the output is updated.

    private ValueTask<SomeMessage> 
        GetSomeMessageFromSourceAsync(int id, CancellationToken token)
    {
        return new(new SomeMessage { Id = id, Name = "Tom", Time = DateTime.Now.ToString() });
    }

    private ValueTask<SomeProtobufMessage> 
        GetSomeProtobufMessageFromSourceAsync(int id, CancellationToken token)
    {
        return new(new SomeProtobufMessage 
            { Id = id, Name = "Tom", Time = DateTime.Now.ToString() });
    }
}

// This is a simple POCO to contrast with SomeProtobufMessage,
// which is generated from sample.proto.
public class SomeMessage
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Time { get; set; }
}
