---
title: Cache in-memory in ASP.NET Core
ai-usage: ai-assisted
content_well_notification: AI-contribution
description: Learn how to cache data in memory in ASP.NET Core.
monikerRange: '>= aspnetcore-10.0'
ms.date: 10/28/2026

# customer intent: As an ASP.NET developer, I want to use in-memory caching in ASP.NET Core, so I can improve the performance and scalability of my app.
---
# Cache in-memory in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [John Luo](https://github.com/JunTaoLuo), and [Steve Smith](https://ardalis.com/)

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

:::moniker range=">= aspnetcore-10.0"

Caching can significantly improve the performance and scalability of an app by reducing the work required to generate content. Caching works best with data that changes infrequently **and** is expensive to generate. Caching makes a copy of data that can be returned much faster than from the source. Apps should be written and tested to **never** depend on cached data.

ASP.NET Core supports several different caches. The simplest cache is based on the <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> interface. `IMemoryCache` represents a cache stored in the memory of the web server. Apps running on a server farm (multiple servers) should ensure sessions are sticky when using the in-memory cache. Sticky sessions ensure that requests from a client all go to the same server. For example, an Azure web app uses [Microsoft Application Request Routing (ARR)](/iis/extensions/planning-for-arr/application-request-routing-version-2-overview) to route all requests to the same server.

Nonsticky sessions in a web farm require a [distributed cache](distributed.md) to avoid cache consistency problems. For some apps, a distributed cache can support higher scale-out than an in-memory cache. Using a distributed cache offloads the cache memory to an external process.

The in-memory cache can store any object. The distributed cache interface is limited to `byte[]`. The in-memory and distributed cache store cache items as key-value pairs.

## Use System.Runtime.Caching/MemoryCache

<xref:System.Runtime.Caching>/<xref:System.Runtime.Caching.MemoryCache> ([NuGet package](https://www.nuget.org/packages/System.Runtime.Caching/)) can be used with:

* .NET Standard 2.0 or later
* Any [.NET implementation](/dotnet/standard/net-standard#net-implementation-support) that targets .NET Standard 2.0 or later (such as ASP.NET Core 3.1 or later)
* .NET Framework 4.5 or later

[Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory/)/`IMemoryCache` (described in this article) is recommended over `System.Runtime.Caching`/`MemoryCache` because it offers better integration with ASP.NET Core. For example, `IMemoryCache` works natively with ASP.NET Core [dependency injection](../../fundamentals/dependency-injection.md).

Use `System.Runtime.Caching`/`MemoryCache` as a compatibility bridge when porting code from ASP.NET 4.x to ASP.NET Core.

## Review guidelines for in-memory caching

The following guidelines apply to in-memory caching:

* Code should always have a fallback option to fetch data and **not** depend on the availability of a cached value.

* The cache uses memory, which is a scarce resource. Limit cache growth:

  * **Don't** insert external input into the cache. As an example, using arbitrary user-provided input as a cache key isn't recommended because the input might consume an unpredictable amount of memory.

  * Use expirations to limit cache growth.

  * [Limit cache size with SetSize, Size, and SizeLimit](#limit-cache-size-with-setsize-size-and-sizelimit). The ASP.NET Core runtime **doesn't** limit cache size based on memory pressure. The developer is responsible for limiting the cache size.

## Create an instance of IMemoryCache

In-memory caching is a *service* that an app references by using [dependency injection](../../fundamentals/dependency-injection.md).

> [!WARNING]
> If the same cache is used by multiple frameworks or libraries, it's a _shared_ cache. If you use a shared memory cache from [dependency injection](../../fundamentals/dependency-injection.md) and also use `SetSize`, `Size`, and `SizeLimit` to limit the cache size, the app can fail.
>
> When a size limit is set on a cache, all entries must specify a size when they're added. This approach can lead to issues because developers might not have full control over what uses the shared cache.
>
> To limit the cache size with the `SetSize` method, the `Size` property, or the `SizeLimit` property, create a cache singleton for caching. For more information and an example, see [Limit cache size with SetSize, Size, and SizeLimit](#limit-cache-size-with-setsize-size-and-sizelimit).

Request the `IMemoryCache` instance in the constructor:

:::code language="csharp" source="memory/samples/CachingMemorySample/Pages/Index.cshtml.cs" id="snippet_ClassConstructor" highlight="5":::

The following code uses the <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache.TryGetValue*> method to check if a time is in the cache. If a time isn't cached, a new entry is created and added to the cache with the <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Set*> method:

:::code language="csharp" source="memory/samples/CachingMemorySample/Pages/Index.cshtml.cs" id="snippet_OnGet" highlight="5,9-12":::

In the preceding code, the cache entry is configured with a sliding expiration of 3 seconds. If the cache entry isn't accessed for more than 3 seconds, the entry is evicted from the cache. Each time the cache entry is accessed, it remains in the cache for a further 3 seconds. The `CacheKeys` class is part of the download sample.

The current time and the cached time are displayed:

:::code language="cshtml" source="memory/samples/CachingMemorySample/Pages/Index.cshtml" id="snippet_CacheCurrentDateTime":::

The following code uses the `Set` extension method to cache data for a relative time without <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions>:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheRelative":::

In the preceding code, the cache entry is configured with a relative expiration of one day. The cache entry is evicted from the cache after one day, even if the entry is accessed during the timeout period.

The following code uses the <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate*> and <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync*> methods to cache data.

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGetOrCreate":::

The following code calls the <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Get*> method to fetch the cached time:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGet":::

The following code gets or creates a cached item with absolute expiration:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGetOrCreateAbsolute" highlight="5":::

A cached item set with only a sliding expiration is at risk of never expiring. If the cached item is repeatedly accessed within the sliding expiration interval, the item never expires. Combining a sliding expiration with an absolute expiration guarantees the item expires. The absolute expiration sets an upper bound on how long the item can be cached. It still allows the item to expire earlier, if the item isn't requested within the sliding expiration interval. If either the sliding expiration interval *or* the absolute expiration time passes, the item is evicted from the cache.

The following code gets or creates a cached item with both sliding *and* absolute expiration:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGetOrCreateSlidingAbsolute" highlight="5-6":::

The preceding code guarantees the data isn't cached longer than the absolute time.

<xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate*>, <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync*>, and <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Get*> are extension methods in the <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions> class. These methods extend the capability of <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>.

## Create MemoryCacheEntryOptions for an entry

The following example demonstrates how to create <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions> for an entry. The code completes the following tasks:

* Sets the cache priority to <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove?displayProperty=nameWithType>.

* Sets a <xref:Microsoft.Extensions.Caching.Memory.PostEvictionDelegate> to call after the entry is evicted from the cache. The callback runs on a different thread from the code that removes the item from the cache.

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_MemoryCacheEntryOptions" highlight="4-5":::

## Limit cache size with SetSize, Size, and SizeLimit

A `MemoryCache` instance can optionally specify and enforce a size limit. The cache size limit doesn't have a defined unit of measure because the cache has no mechanism to measure the size of entries. If the cache size limit is set, all entries must specify size. The ASP.NET Core runtime doesn't limit cache size based on memory pressure. It's up to the developer to limit cache size. The size specified is in units the developer chooses.

For example:

* If the web app primarily caches strings, each cache entry size might be the string length.
* The app can specify the size of all entries as 1, and the size limit is the count of entries.

If the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.SizeLimit> property isn't set, the cache grows without bound. The ASP.NET Core runtime doesn't trim the cache when system memory is low. Apps must be architected to:

* Limit cache growth.
* Call the <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.Compact*> or <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.Remove*> method when available memory is limited.

The following code creates a unitless fixed-size <xref:Microsoft.Extensions.Caching.Memory.MemoryCache> instance that's accessible by [dependency injection](../../fundamentals/dependency-injection.md):

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/MyMemoryCache.cs" id="snippet_Class":::

The `SizeLimit` property doesn't have units. Cached entries must specify size in whatever units they consider most appropriate when the cache size limit is set. All users of a cache instance should use the same unit system. An entry isn't cached if the sum of the cached entry sizes exceeds the value specified by `SizeLimit`. If no cache size limit is set, the cache size set on the entry is ignored.

The following code registers the `MyMemoryCache` instance with the [dependency injection](../../fundamentals/dependency-injection.md) container:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Program.cs" id="snippet_AddSingletonMyMemoryCache" highlight="4":::

`MyMemoryCache` is created as an independent memory cache for components that are aware of this size-limited cache and know how to set cache entry size appropriately.

The size of the cache entry can be set by using the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetSize*> extension method or the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.Size> property:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/MyMemoryCache.cshtml.cs" id="snippet_OnGetCacheSizeSetSize" highlight="4,6":::

In the preceding code, the two highlighted lines achieve the same result of setting the size of the cache entry. The `SetSize` method is provided for convenience when chaining calls onto `new MemoryCacheOptions()`.

### Remove cache items with MemoryCache.Compact

The `MemoryCache.Compact` method attempts to remove the specified percentage of the cache in the following order:

* All expired items
* Items by priority, where lowest priority items are removed first
* Least recently used objects
* Items with the earliest absolute expiration
* Items with the earliest sliding expiration

Pinned items with priority <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove> are [never removed](https://github.com/dotnet/runtime/blob/release/6.0/src/libraries/Microsoft.Extensions.Caching.Memory/src/MemoryCache.cs#L415-L430). The following code removes a cache item and calls the `Compact` method to remove 25% of cached entries:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/MyMemoryCache.cshtml.cs" id="snippet_OnGetCacheCompact":::

For more information, see the [Compact source on GitHub](https://github.com/dotnet/runtime/blob/release/6.0/src/libraries/Microsoft.Extensions.Caching.Memory/src/MemoryCache.cs#L382-L393).

## Evict a cache entry with expired dependencies

To enable inheritance of expiration tokens and time-based expiration settings between linked cache entries, set <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.TrackLinkedCacheEntries> to `true` when registering the cache in `Program.cs`. This option is `false` by default starting in .NET 7:

:::code language="csharp" source="memory/samples/CachingMemorySample/Program.cs" id="snippet_TrackLinkedCacheEntries":::

The following sample shows how to expire a cache entry if a dependent entry expires. A <xref:Microsoft.Extensions.Primitives.CancellationChangeToken> is added to the cached item. When the `Cancel` method is called on the `CancellationTokenSource` object, both cache entries are evicted:

:::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_CacheDependencies" highlight="16,24":::

When you use a <xref:System.Threading.CancellationTokenSource> object, you can evict multiple cache entries as a group. With linked-entry tracking enabled, the parent entry inherits the expiration token from the child entry created within its `using` scope.

## Review notes about in-memory caching

The following notes apply to in-memory caching:

* Expiration doesn't happen in the background.

  There's no timer that actively scans the cache for expired items. Any activity on the cache (via `Get`, `TryGetValue`, `Set`, or `Remove`) can trigger a background scan for expired items. A timer set on the `CancellationTokenSource` object (by using the <xref:System.Threading.CancellationTokenSource.CancelAfter*> method) also removes the entry and triggers a scan for expired items.

  The following example uses the <xref:System.Threading.CancellationTokenSource.%23ctor(System.TimeSpan)> overloaded constructor for the registered token. When this token fires, it removes the entry immediately and fires the eviction callbacks:

  :::code language="csharp" source="memory/samples/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGeCacheExpirationToken":::

* When you use a callback to repopulate a cache item:

  * Multiple requests might discover the cached key value is empty because the callback isn't finished.
  * This approach can result in several threads repopulating the cached item.

* When linked-entry tracking is enabled and one cache entry (the parent) creates another entry (the child), the parent inherits the child's expiration tokens and time-based expiration settings. Manually removing or updating the child doesn't expire the parent.

* Use the <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.PostEvictionCallbacks> property to specify which callbacks should fire after a cache entry is evicted from the cache.

* For most apps, `IMemoryCache` is enabled. For example, calling `AddMvc`, `AddControllersWithViews`, `AddRazorPages`, `AddMvcCore().AddRazorViewEngine`, and many other `Add{Service}` methods in the _Program.cs_ file enables `IMemoryCache`.

  For apps that don't call one of the mentioned `Add{Service}` methods, you might need to call the <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache*> method in the _Program.cs_ file.

* <xref:Microsoft.Extensions.Caching.Memory.MemoryCache> is thread-safe and can be used concurrently across multiple threads.

* Accessing the <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.Count> property is computationally expensive under high concurrency because it requires aggregating items across internal partitions. Avoid accessing `Count` frequently in performance-sensitive request paths.

* <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate*> and <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync*> aren't atomic. When several requests miss the same key at the same time, each request runs the factory, and the last value written is the one that stays in the cache. For an expensive data source, this can cause a burst of duplicate calls. To run the factory only once per key, use [`HybridCache`](hybrid.md), which provides stampede protection.

* The cache stores references to objects, not copies. If code changes an object after reading it from the cache, every caller that reads that entry sees the change. Cache immutable objects, or copy an object before changing it.

## Use a background cache update

Use a [background service](../../fundamentals/host/hosted-services.md) such as the <xref:Microsoft.Extensions.Hosting.IHostedService> interface to update the cache. The background service can recompute the entries and assign them to the cache only after they're ready.

## Related content

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/memory/samples/) ([how to download](../../fundamentals/index.md#how-to-download-a-sample))
* [Detect changes with change tokens in ASP.NET Core](../../fundamentals/change-tokens.md)
* [Response caching in ASP.NET Core](response.md)

:::moniker-end
