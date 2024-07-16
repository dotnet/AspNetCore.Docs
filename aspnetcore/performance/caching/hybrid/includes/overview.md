The [`HybridCache`](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Runtime/HybridCache.cs,8c0fe94693d1ac8d) API bridges some gaps in the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> and <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> APIs. `HybridCache` is an abstract class with a default implementation that handles most aspects of saving to cache and retrieving from cache.

### Features

`HybridCache` has the following features that the other APIs don't have:

* A unified API for both in-process and out-of-process caching.

  `HybridCache` is designed to be a drop-in replacement for existing `IDistributedCache` and `IMemoryCache` usage, and it provides a 
simple API for adding new caching code. If the app has an `IDistributedCache` implementation, the `HybridCache` service uses it for secondary caching. This two-level caching strategy allows `HybridCache` to provide the speed of an in-memory cache and the durability of a distributed or persistent cache.

* Stampede protection.

  *Cache stampede* happens when a frequently used cache entry is revoked, and too many requests try to repopulate the same cache entry at the same time. `HybridCache` combines concurrent operations, ensuring that all requests for a given response wait for the first request to populate the cache.

* Configurable serialization.

  Serialization is configured as part of registering the service, with support for type-specific and generalized serializers via the `WithSerializer` and `WithSerializerFactory` methods, chained from the `AddHybridCache` call. By default, the service handles `string` and `byte[]` internally, and uses `System.Text.Json` for everything else. It can be configured for other types of serializers, such as protobuf or XML.

To see the relative simplicity of the `HybridCache` API, compare code that uses it to code that uses `IDistributedCache`. Here's an example of what using `IDistributedCache` looks like:

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

That's a lot of work to get right each time, including things like serialization. And in the "cache miss" scenario, you could end up with multiple concurrent threads, all getting a cache miss, all fetching the underlying data, all serializing it, and all sending that data to the cache.

Here's equivalent code using `HybridCache`:

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

The code is simpler and the library provides stampede protection and other features that `IDistributedCache` doesn't.

### Compatibility

The `HybridCache` library supports older .NET runtimes, down to .NET Framework 4.7.2 and .NET Standard 2.0.

### Additional resources

For more information, see the following resources:

* <xref:performance/caching/hybrid>
* [GitHub issue dotnet/aspnetcore #54647](https://github.com/dotnet/aspnetcore/issues/54647)
* [`HybridCache` source code](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Runtime/HybridCache.cs,8c0fe94693d1ac8d)
