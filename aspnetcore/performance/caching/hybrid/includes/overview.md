The <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache> API bridges gaps in the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> and <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> APIs. `HybridCache` is an abstract class with a default implementation that handles most aspects of saving to cache and retrieving from cache.

### Features of HybridCache

`HybridCache` provides the following features that aren't available with other APIs:

* A unified API for both in-process and out-of-process caching.

  `HybridCache` is designed to be a drop-in replacement for existing `IDistributedCache` and `IMemoryCache` usage, and it provides a 
simple API for adding new caching code. If the app has an `IDistributedCache` implementation, the `HybridCache` service uses it for secondary caching. This two-level caching strategy allows `HybridCache` to provide the speed of an in-memory cache and the durability of a distributed or persistent cache.

* Stampede protection.

  *Cache stampede* happens when a frequently used cache entry is revoked, and too many requests try to repopulate the same cache entry at the same time. `HybridCache` combines concurrent operations, which ensures that all requests for a given response wait for the first request to populate the cache.

* Configurable serialization.

  Serialization is configured as part of registering the service, with support for type-specific and generalized serializers via the `WithSerializer` and `WithSerializerFactory` methods, chained from the `AddHybridCache` call. By default, the service handles `string` and `byte[]` types internally, and uses the `System.Text.Json` namespace for everything else. `HybridCache` can be configured for other types of serializers, such as protobuf or XML.

To see the relative simplicity of the `HybridCache` API, compare code that uses it to code that uses the `IDistributedCache` interface. Here's an example of a configuration with the `IDistributedCache` interface:

```csharp
public class SomeService(IDistributedCache cache)
{
    public async Task<SomeInformation> GetSomeInformationAsync
        (string name, int id, CancellationToken token = default)
    {
        var key = $"someinfo:{name}:{id}"; // Unique key for this combination.
        var bytes = await cache.GetAsync(key, token); // Try to get from cache.
        SomeInformation info;
        if (bytes is null)
        {
            // Cache miss; get the data from the real source.
            info = await SomeExpensiveOperationAsync(name, id, token);

            // Serialize and cache it.
            bytes = SomeSerializer.Serialize(info);
            await cache.SetAsync(key, bytes, token);
        }
        else
        {
            // Cache hit; deserialize it.
            info = SomeSerializer.Deserialize<SomeInformation>(bytes);
        }
        return info;
    }

    // This is the work we're trying to cache.
    private async Task<SomeInformation> SomeExpensiveOperationAsync(string name, int id,
        CancellationToken token = default)
    { /* ... */ }
}
```

The code demonstrates a significant amount of work to get right each time, including things like serialization. Also in the "cache miss" scenario, you might end up with multiple concurrent threads. These threads might all receive a cache miss, all fetch the underlying data, all serialize it, and all send the data to the cache.

Here's equivalent code that uses the `HybridCache` API:

```csharp
public class SomeService(HybridCache cache)
{
    public async Task<SomeInformation> GetSomeInformationAsync
        (string name, int id, CancellationToken token = default)
    {
        return await cache.GetOrCreateAsync(
            $"someinfo:{name}:{id}", // Unique key for this entry.
            async cancel => await SomeExpensiveOperationAsync(name, id, cancel),
            token: token
        );
    }
}
```

The code is simpler, and the library provides stampede protection and other features not available with the `IDistributedCache` interface.

### Compatibility

The `HybridCache` library supports older .NET runtimes, including .NET Framework 4.7.2 and .NET Standard 2.0.

### More information

For more information, see the following resources:

* [HybridCache library in ASP.NET Core](xref:performance/caching/hybrid)
* [Hybrid Cache API proposal (GitHub dotnet/aspnetcore issue #54647)](https://github.com/dotnet/aspnetcore/issues/54647)
* [HybridCache source code](https://source.dot.net/#Microsoft.Extensions.Caching.Abstractions/Hybrid/HybridCache.cs,8c0fe94693d1ac8d) <!--keep-->
