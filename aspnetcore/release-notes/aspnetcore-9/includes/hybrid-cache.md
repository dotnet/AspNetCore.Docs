---
ms.topic: include
author: mgravell
ms.author: marcgravell
ms.date: 05/21/2024
---
### New `HybridCache` library

The [`HybridCache`](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Runtime/HybridCache.cs,8c0fe94693d1ac8d) API bridges some gaps in the existing <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> and <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> APIs. It also adds new capabilities, such as:

* **"Stampede" protection** to prevent parallel fetches of the same work.
* Configurable serialization.

`HybridCache` is designed to be a drop-in replacement for existing `IDistributedCache` and `IMemoryCache` usage, and it provides a simple API for adding new caching code. It provides a unified API for both in-process and out-of-process caching.

To see how the `HybridCache` API is simplified, compare it to code that uses `IDistributedCache`. Here's an example of what using `IDistributedCache` looks like:

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

That's a lot of work to get right each time, including things like serialization. And in the cache miss scenario, you could end up with multiple concurrent threads, all getting a cache miss, all fetching the underlying data, all serializing it, and all sending that data to the cache.

To simplify and improve this code with `HybridCache`, we first need to add the new library `Microsoft.Extensions.Caching.Hybrid`:

``` xml
<PackageReference Include="Microsoft.Extensions.Caching.Hybrid" Version="9.0.0" />
```

Register the `HybridCache` service, like you would register an `IDistributedCache` implementation:

```csharp
services.AddHybridCache(); // Not shown: optional configuration API.
```

Now most caching concerns can be offloaded to `HybridCache`:

```csharp
public class SomeService(HybridCache cache)
{
    public async Task<SomeInformation> GetSomeInformationAsync
        (string name, int id, CancellationToken token = default)
    {
        return await cache.GetOrCreateAsync(
            $"someinfo:{name}:{id}", // Unique key for this combination.
            async cancel => await SomeExpensiveOperationAsync(name, id, cancel),
            token: token
        );
    }
}
```

We provide a concrete implementation of the `HybridCache` abstract class via dependency injection, but it's intended that developers can provide custom implementations of the API. The `HybridCache` implementation deals with everything related to caching, including concurrent operation handling. The `cancel` token here represents the combined cancellation of *all* concurrent callers&mdash;not just the cancellation of the caller we can see (that is, `token`).

High throughput scenarios can be further optimized by using the `TState` pattern, to avoid some overhead from captured variables and per-instance callbacks:

```csharp
public class SomeService(HybridCache cache)
{
    public async Task<SomeInformation> GetSomeInformationAsync(string name, int id, CancellationToken token = default)
    {
        return await cache.GetOrCreateAsync(
            $"someinfo:{name}:{id}", // unique key for this combination
            (name, id), // all of the state we need for the final call, if needed
            static async (state, token) =>
                await SomeExpensiveOperationAsync(state.name, state.id, token),
            token: token
        );
    }
}
```

`HybridCache` uses the configured `IDistributedCache` implementation, if any, for secondary out-of-process caching, for example, using
Redis. But even without an `IDistributedCache`, the `HybridCache` service will still provide in-process caching and "stampede" protection.

#### A note on object reuse

In typical existing code that uses `IDistributedCache`, every retrieval of an object from the cache results in deserialization. This behavior means that each concurrent caller gets a separate instance of the object, which cannot interact with other instances. The result is thread safety, as there's no risk of concurrent modifications to the same object instance.

Because a lot of `HybridCache` usage will be adapted from existing `IDistributedCache` code, `HybridCache` preserves this behavior by default to avoid introducing concurrency bugs. However, a given use case is inherently thread-safe:

* If the types being cached are immutable.
* If the code doesn't modify them.

In such cases, inform `HybridCache` that it's safe to reuse instances by:

* Marking the type as `sealed`. The `sealed` keyword in C# means that the class can't be inherited.
* Applying the `[ImmutableObject(true)]` attribute to it. The `[ImmutableObject(true)]` attribute indicates that the object's state can't be changed after it's created.

By reusing instances, `HybridCache` can reduce the overhead of CPU and object allocations associated with per-call deserialization. This can lead to performance improvements in scenarios where the cached objects are large or accessed frequently.

#### Other `HybridCache` features

Like `IDistributedCache`, `HybridCache` supports removal by key with a `RemoveKeyAsync` method.

`HybridCache` also provides optional APIs for `IDistributedCache` implementations, to avoid `byte[]` allocations. This feature is implemented
by the preview versions of the `Microsoft.Extensions.Caching.StackExchangeRedis` and `Microsoft.Extensions.Caching.SqlServer` packages.

Serialization is configured as part of registering the service, with support for type-specific and generalized serializers via the
`WithSerializer` and `.WithSerializerFactory` methods, chained from the `AddHybridCache` call. By default, the library
handles `string` and `byte[]` internally, and uses `System.Text.Json` for everything else, but you can use protobuf, xml, or anything
else.

`HybridCache` supports older .NET runtimes, down to .NET Framework 4.7.2 and .NET Standard 2.0.

For more information about `HybridCache`, see <xref:performance/caching/hybrid>
