---
title: Cache in-memory in ASP.NET Core
author: tdykstra
description: Learn how to cache data in memory in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/07/2023
content_well_notification: AI-contribution
uid: performance/caching/memory
---
# Cache in-memory in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [John Luo](https://github.com/JunTaoLuo), and [Steve Smith](https://ardalis.com/)

:::moniker range=">= aspnetcore-6.0"

Caching can significantly improve the performance and scalability of an app by reducing the work required to generate content. Caching works best with data that changes infrequently **and** is expensive to generate. Caching makes a copy of data that can be returned much faster than from the source. Apps should be written and tested to **never** depend on cached data.

ASP.NET Core supports several different caches. The simplest cache is based on the <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>. `IMemoryCache` represents a cache stored in the memory of the web server. Apps running on a server farm (multiple servers) should ensure sessions are sticky when using the in-memory cache. Sticky sessions ensure that requests from a client all go to the same server. For example, Azure Web apps use [Application Request Routing](https://www.iis.net/learn/extensions/planning-for-arr) (ARR) to route all requests to the same server.

Non-sticky sessions in a web farm require a [distributed cache](xref:performance/caching/distributed) to avoid cache consistency problems. For some apps, a distributed cache can support higher scale-out than an in-memory cache. Using a distributed cache offloads the cache memory to an external process.

The in-memory cache can store any object. The distributed cache interface is limited to `byte[]`. The in-memory and distributed cache store cache items as key-value pairs.

## System.Runtime.Caching/MemoryCache

<xref:System.Runtime.Caching>/<xref:System.Runtime.Caching.MemoryCache> ([NuGet package](https://www.nuget.org/packages/System.Runtime.Caching/)) can be used with:

* .NET Standard 2.0 or later.
* Any [.NET implementation](/dotnet/standard/net-standard#net-implementation-support) that targets .NET Standard 2.0 or later. For example, ASP.NET Core 3.1 or later.
* .NET Framework 4.5 or later.

[Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory/)/`IMemoryCache` (described in this article) is recommended over `System.Runtime.Caching`/`MemoryCache` because it's better integrated into ASP.NET Core. For example, `IMemoryCache` works natively with ASP.NET Core [dependency injection](xref:fundamentals/dependency-injection).

Use `System.Runtime.Caching`/`MemoryCache` as a compatibility bridge when porting code from ASP.NET 4.x to ASP.NET Core.

## Cache guidelines

* Code should always have a fallback option to fetch data and **not** depend on a cached value being available.
* The cache uses a scarce resource, memory. Limit cache growth:
  * Do **not** insert external input into the cache. As an example, using arbitrary user-provided input as a cache key is not recommended since the input might consume an unpredictable amount of memory.
  * Use expirations to limit cache growth.
  * [Use SetSize, Size, and SizeLimit to limit cache size](#use-setsize-size-and-sizelimit-to-limit-cache-size). The ASP.NET Core runtime does **not** limit cache size based on memory pressure. It's up to the developer to limit cache size.

## Use IMemoryCache

> [!WARNING]
> Using a *shared* memory cache from [Dependency Injection](xref:fundamentals/dependency-injection) and calling `SetSize`, `Size`, or `SizeLimit` to limit cache size can cause the app to fail. When a size limit is set on a cache, all entries must specify a size when being added. This can lead to issues since developers may not have full control on what uses the shared cache.
> When using `SetSize`, `Size`, or `SizeLimit` to limit cache, create a cache singleton for caching. For more information and an example, see [Use SetSize, Size, and SizeLimit to limit cache size](#use-setsize-size-and-sizelimit-to-limit-cache-size).
> A shared cache is one shared by other frameworks or libraries.

In-memory caching is a *service* that's referenced from an app using [Dependency Injection](xref:fundamentals/dependency-injection). Request the `IMemoryCache` instance in the constructor:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Pages/Index.cshtml.cs" id="snippet_ClassConstructor" highlight="5":::

The following code uses <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache.TryGetValue%2A> to check if a time is in the cache. If a time isn't cached, a new entry is created and added to the cache with <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Set%2A>: 

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Pages/Index.cshtml.cs" id="snippet_OnGet" highlight="5,9-12":::

In the preceding code, the cache entry is configured with a sliding expiration of three seconds. If the cache entry isn't accessed for more than three seconds, it gets evicted from the cache. Each time the cache entry is accessed, it remains in the cache for a further 3 seconds. The `CacheKeys` class is part of the download sample.

The current time and the cached time are displayed:

:::code language="cshtml" source="memory/samples/6.x/CachingMemorySample/Pages/Index.cshtml" id="snippet_CacheCurrentDateTime":::

The following code uses the `Set` extension method to cache data for a relative time without `MemoryCacheEntryOptions`:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheRelative":::

In the preceding code, the cache entry is configured with a relative expiration of one day. The cache entry gets evicted from the cache after one day, even if it's accessed within this timeout period.

The following code uses <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate%2A> and <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync%2A> to cache data.

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGetOrCreate":::

The following code calls <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Get%2A> to fetch the cached time:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGet":::

The following code gets or creates a cached item with absolute expiration:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGetOrCreateAbsolute" highlight="5":::

A cached item set with only a sliding expiration is at risk of never expiring. If the cached item is repeatedly accessed within the sliding expiration interval, the item never expires. Combine a sliding expiration with an absolute expiration to guarantee the item expires. The absolute expiration sets an upper bound on how long the item can be cached while still allowing the item to expire earlier if it isn't requested within the sliding expiration interval. If either the sliding expiration interval *or* the absolute expiration time pass, the item is evicted from the cache.

The following code gets or creates a cached item with both sliding *and* absolute expiration:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGetCacheGetOrCreateSlidingAbsolute" highlight="5-6":::

The preceding code guarantees the data won't be cached longer than the absolute time.

<xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate%2A>, <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync%2A>, and <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Get%2A> are extension methods in the <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions> class. These methods extend the capability of <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>.

## `MemoryCacheEntryOptions`

The following example:

* Sets the cache priority to <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove?displayProperty=nameWithType>.
* Sets a <xref:Microsoft.Extensions.Caching.Memory.PostEvictionDelegate> that gets called after the entry is evicted from the cache. The callback is run on a different thread from the code that removes the item from the cache.

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_MemoryCacheEntryOptions" highlight="4-5":::

## Use SetSize, Size, and SizeLimit to limit cache size

A `MemoryCache` instance may optionally specify and enforce a size limit. The cache size limit doesn't have a defined unit of measure because the cache has no mechanism to measure the size of entries. If the cache size limit is set, all entries must specify size. The ASP.NET Core runtime doesn't limit cache size based on memory pressure. It's up to the developer to limit cache size. The size specified is in units the developer chooses.

For example:

* If the web app was primarily caching strings, each cache entry size could be the string length.
* The app could specify the size of all entries as 1, and the size limit is the count of entries.

If <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.SizeLimit> isn't set, the cache grows without bound. The ASP.NET Core runtime doesn't trim the cache when system memory is low. Apps must be architected to:

* Limit cache growth.
* Call <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.Compact%2A> or <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.Remove%2A> when available memory is limited.

The following code creates a unitless fixed size <xref:Microsoft.Extensions.Caching.Memory.MemoryCache> accessible by [dependency injection](xref:fundamentals/dependency-injection):

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/MyMemoryCache.cs" id="snippet_Class":::

`SizeLimit` doesn't have units. Cached entries must specify size in whatever units they consider most appropriate if the cache size limit has been set. All users of a cache instance should use the same unit system. An entry won't be cached if the sum of the cached entry sizes exceeds the value specified by `SizeLimit`. If no cache size limit is set, the cache size set on the entry is ignored.

The following code registers `MyMemoryCache` with the [dependency injection](xref:fundamentals/dependency-injection) container:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Program.cs" id="snippet_AddSingletonMyMemoryCache" highlight="4":::

`MyMemoryCache` is created as an independent memory cache for components that are aware of this size limited cache and know how to set cache entry size appropriately.

The size of the cache entry can be set using the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetSize%2A> extension method or the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.Size> property:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/MyMemoryCache.cshtml.cs" id="snippet_OnGetCacheSizeSetSize" highlight="4,6":::

In the preceding code, the two highlighted lines achieve the same result of setting the size of the cache entry. `SetSize` is provided for convenience when chaining calls onto `new MemoryCacheOptions()`.

### MemoryCache.Compact

`MemoryCache.Compact` attempts to remove the specified percentage of the cache in the following order:

* All expired items.
* Items by priority. Lowest priority items are removed first.
* Least recently used objects.
* Items with the earliest absolute expiration.
* Items with the earliest sliding expiration.

Pinned items with priority <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove> are [never removed](https://github.com/dotnet/runtime/blob/release/6.0/src/libraries/Microsoft.Extensions.Caching.Memory/src/MemoryCache.cs#L415-L430). The following code removes a cache item and calls `Compact` to remove 25% of cached entries:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/MyMemoryCache.cshtml.cs" id="snippet_OnGetCacheCompact":::

For more information, see the [Compact source on GitHub](https://github.com/dotnet/runtime/blob/release/6.0/src/libraries/Microsoft.Extensions.Caching.Memory/src/MemoryCache.cs#L382-L393).

## Cache dependencies

The following sample shows how to expire a cache entry if a dependent entry expires. A <xref:Microsoft.Extensions.Primitives.CancellationChangeToken> is added to the cached item. When `Cancel` is called on the `CancellationTokenSource`, both cache entries are evicted:

:::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_CacheDependencies" highlight="16,24":::

Using a <xref:System.Threading.CancellationTokenSource> allows multiple cache entries to be evicted as a group. With the `using` pattern in the code above, cache entries created inside the `using` scope inherit triggers and expiration settings.

## Additional notes

* Expiration doesn't happen in the background. There's no timer that actively scans the cache for expired items. Any activity on the cache (`Get`, `Set`, `Remove`) can trigger a background scan for expired items. A timer on the `CancellationTokenSource` (<xref:System.Threading.CancellationTokenSource.CancelAfter%2A>) also removes the entry and triggers a scan for expired items. The following example uses <xref:System.Threading.CancellationTokenSource.%23ctor(System.TimeSpan)> for the registered token. When this token fires, it removes the entry immediately and fires the eviction callbacks:

  :::code language="csharp" source="memory/samples/6.x/CachingMemorySample/Snippets/Pages/Index.cshtml.cs" id="snippet_OnGeCacheExpirationToken":::

* When using a callback to repopulate a cache item:
  * Multiple requests can find the cached key value empty because the callback hasn't completed.
  * This can result in several threads repopulating the cached item.
* When one cache entry is used to create another, the child copies the parent entry's expiration tokens and time-based expiration settings. The child isn't expired by manual removal or updating of the parent entry.
* Use <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.PostEvictionCallbacks> to set the callbacks that will be fired after the cache entry is evicted from the cache.
* For most apps, `IMemoryCache` is enabled. For example, calling `AddMvc`, `AddControllersWithViews`, `AddRazorPages`, `AddMvcCore().AddRazorViewEngine`, and many other `Add{Service}` methods in `Program.cs`, enables `IMemoryCache`. For apps that don't call one of the preceding `Add{Service}` methods, it may be necessary to call <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache%2A> in `Program.cs`.

## Background cache update

Use a [background service](xref:fundamentals/host/hosted-services) such as <xref:Microsoft.Extensions.Hosting.IHostedService> to update the cache. The background service can recompute the entries and then assign them to the cache only when they’re ready.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/memory/samples/) ([how to download](xref:index#how-to-download-a-sample))
* <xref:performance/caching/distributed>
* <xref:fundamentals/change-tokens>
* <xref:performance/caching/response>
* <xref:performance/caching/middleware>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>
    
:::moniker-end

:::moniker range="< aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/memory/samples/) ([how to download](xref:index#how-to-download-a-sample))

## Caching basics

Caching can significantly improve the performance and scalability of an app by reducing the work required to generate content. Caching works best with data that changes infrequently **and** is expensive to generate. Caching makes a copy of data that can be returned much faster than from the source. Apps should be written and tested to **never** depend on cached data.

ASP.NET Core supports several different caches. The simplest cache is based on the <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>. `IMemoryCache` represents a cache stored in the memory of the web server. Apps running on a server farm (multiple servers) should ensure sessions are sticky when using the in-memory cache. Sticky sessions ensure that subsequent requests from a client all go to the same server. For example, Azure Web apps use [Application Request Routing](https://www.iis.net/learn/extensions/planning-for-arr) (ARR) to route all subsequent requests to the same server.

Non-sticky sessions in a web farm require a [distributed cache](xref:performance/caching/distributed) to avoid cache consistency problems. For some apps, a distributed cache can support higher scale-out than an in-memory cache. Using a distributed cache offloads the cache memory to an external process.

The in-memory cache can store any object. The distributed cache interface is limited to `byte[]`. The in-memory and distributed cache store cache items as key-value pairs.

## System.Runtime.Caching/MemoryCache

<xref:System.Runtime.Caching>/<xref:System.Runtime.Caching.MemoryCache> ([NuGet package](https://www.nuget.org/packages/System.Runtime.Caching/)) can be used with:

* .NET Standard 2.0 or later.
* Any [.NET implementation](/dotnet/standard/net-standard#net-implementation-support) that targets .NET Standard 2.0 or later. For example, ASP.NET Core 3.1 or later.
* .NET Framework 4.5 or later.

[Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory/)/`IMemoryCache` (described in this article) is recommended over `System.Runtime.Caching`/`MemoryCache` because it's better integrated into ASP.NET Core. For example, `IMemoryCache` works natively with ASP.NET Core [dependency injection](xref:fundamentals/dependency-injection).

Use `System.Runtime.Caching`/`MemoryCache` as a compatibility bridge when porting code from ASP.NET 4.x to ASP.NET Core.

## Cache guidelines

* Code should always have a fallback option to fetch data and **not** depend on a cached value being available.
* The cache uses a scarce resource, memory. Limit cache growth:
  * Do **not** use external input as cache keys.
  * Use expirations to limit cache growth.
  * [Use SetSize, Size, and SizeLimit to limit cache size](#use-setsize-size-and-sizelimit-to-limit-cache-size). The ASP.NET Core runtime does **not** limit cache size based on memory pressure. It's up to the developer to limit cache size.

## Use IMemoryCache

> [!WARNING]
> Using a *shared* memory cache from [Dependency Injection](xref:fundamentals/dependency-injection) and calling `SetSize`, `Size`, or `SizeLimit` to limit cache size can cause the app to fail. When a size limit is set on a cache, all entries must specify a size when being added. This can lead to issues since developers may not have full control on what uses the shared cache.
> When using `SetSize`, `Size`, or `SizeLimit` to limit cache, create a cache singleton for caching. For more information and an example, see [Use SetSize, Size, and SizeLimit to limit cache size](#use-setsize-size-and-sizelimit-to-limit-cache-size).
> A shared cache is one shared by other frameworks or libraries.

In-memory caching is a *service* that's referenced from an app using [Dependency Injection](xref:fundamentals/dependency-injection). Request the `IMemoryCache` instance in the constructor:

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet_ctor":::

The following code uses <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache.TryGetValue%2A> to check if a time is in the cache. If a time isn't cached, a new entry is created and added to the cache with <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Set%2A>. The `CacheKeys` class is part of the download sample.

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/CacheKeys.cs":::

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet1":::

The current time and the cached time are displayed:

:::code language="cshtml" source="memory/samples/3.x/WebCacheSample/Views/Home/Cache.cshtml":::

The following code uses the `Set` extension method to cache data for a relative time without creating the `MemoryCacheEntryOptions` object:

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet_set":::

The cached `DateTime` value remains in the cache while there are requests within the timeout period.

The following code uses <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate%2A> and <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync%2A> to cache data.

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet2" highlight="3-7,14-19":::

The following code calls <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Get%2A> to fetch the cached time:

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet_gct":::

The following code gets or creates a cached item with absolute expiration:

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet99":::

A cached item set with only a sliding expiration is at risk of never expiring. If the cached item is repeatedly accessed within the sliding expiration interval, the item never expires. Combine a sliding expiration with an absolute expiration to guarantee the item expires. The absolute expiration sets an upper bound on how long the item can be cached while still allowing the item to expire earlier if it isn't requested within the sliding expiration interval. If either the sliding expiration interval *or* the absolute expiration time pass, the item is evicted from the cache.

The following code gets or creates a cached item with both sliding *and* absolute expiration:

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet9":::

The preceding code guarantees the data will not be cached longer than the absolute time.

<xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate%2A>, <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync%2A>, and <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Get%2A> are extension methods in the <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions> class. These methods extend the capability of <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>.

## `MemoryCacheEntryOptions`

The following sample:

* Sets a sliding expiration time. Requests that access this cached item will reset the sliding expiration clock.
* Sets the cache priority to <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove?displayProperty=nameWithType>.
* Sets a <xref:Microsoft.Extensions.Caching.Memory.PostEvictionDelegate> that will be called after the entry is evicted from the cache. The callback is run on a different thread from the code that removes the item from the cache.

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet_et" highlight="14-21":::

## Use SetSize, Size, and SizeLimit to limit cache size

A `MemoryCache` instance may optionally specify and enforce a size limit. The cache size limit does not have a defined unit of measure because the cache has no mechanism to measure the size of entries. If the cache size limit is set, all entries must specify size. The ASP.NET Core runtime does not limit cache size based on memory pressure. It's up to the developer to limit cache size. The size specified is in units the developer chooses.

For example:

* If the web app was primarily caching strings, each cache entry size could be the string length.
* The app could specify the size of all entries as 1, and the size limit is the count of entries.

If <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.SizeLimit> isn't set, the cache grows without bound. The ASP.NET Core runtime doesn't trim the cache when system memory is low. Apps must be architected to:

* Limit cache growth.
* Call <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.Compact%2A> or <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.Remove%2A> when available memory is limited:

The following code creates a unitless fixed size <xref:Microsoft.Extensions.Caching.Memory.MemoryCache> accessible by [dependency injection](xref:fundamentals/dependency-injection):

:::code language="csharp" source="memory/samples/3.x/RPcache/Services/MyMemoryCache.cs" id="snippet":::

`SizeLimit` does not have units. Cached entries must specify size in whatever units they deem most appropriate if the cache size limit has been set. All users of a cache instance should use the same unit system. An entry will not be cached if the sum of the cached entry sizes exceeds the value specified by `SizeLimit`. If no cache size limit is set, the cache size set on the entry will be ignored.

The following code registers `MyMemoryCache` with the [dependency injection](xref:fundamentals/dependency-injection) container.

:::code language="csharp" source="memory/samples/3.x/RPcache/Startup.cs" id="snippet":::

`MyMemoryCache` is created as an independent memory cache for components that are aware of this size limited cache and know how to set cache entry size appropriately.

The following code uses `MyMemoryCache`:

:::code language="csharp" source="memory/samples/3.x/RPcache/Pages/SetSize.cshtml.cs" id="snippet":::

The size of the cache entry can be set by <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.Size> or the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetSize%2A> extension methods:

:::code language="csharp" source="memory/samples/3.x/RPcache/Pages/SetSize.cshtml.cs" id="snippet2" highlight="9,10,14,15":::

### MemoryCache.Compact

`MemoryCache.Compact` attempts to remove the specified percentage of the cache in the following order:

* All expired items.
* Items by priority. Lowest priority items are removed first.
* Least recently used objects.
* Items with the earliest absolute expiration.
* Items with the earliest sliding expiration.

Pinned items with priority <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove> are never removed. The following code removes a cache item and calls `Compact`:

:::code language="csharp" source="memory/samples/3.x/RPcache/Pages/TestCache.cshtml.cs" id="snippet3":::

For more information, see the [Compact source on GitHub](https://github.com/dotnet/extensions/blob/v3.0.0-preview8.19405.4/src/Caching/Memory/src/MemoryCache.cs#L382-L393).

## Cache dependencies

The following sample shows how to expire a cache entry if a dependent entry expires. A <xref:Microsoft.Extensions.Primitives.CancellationChangeToken> is added to the cached item. When `Cancel` is called on the `CancellationTokenSource`, both cache entries are evicted.

:::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet_ed":::

Using a <xref:System.Threading.CancellationTokenSource> allows multiple cache entries to be evicted as a group. With the `using` pattern in the code above, cache entries created inside the `using` block will inherit triggers and expiration settings.

## Additional notes

* Expiration doesn't happen in the background. There is no timer that actively scans the cache for expired items. Any activity on the cache (`Get`, `Set`, `Remove`) can trigger a background scan for expired items. A timer on the `CancellationTokenSource` (<xref:System.Threading.CancellationTokenSource.CancelAfter%2A>) also removes the entry and triggers a scan for expired items. The following example uses <xref:System.Threading.CancellationTokenSource.%23ctor(System.TimeSpan)> for the registered token. When this token fires it removes the entry immediately and fires the eviction callbacks:

  :::code language="csharp" source="memory/samples/3.x/WebCacheSample/Controllers/HomeController.cs" id="snippet_ae":::

* When using a callback to repopulate a cache item:
  * Multiple requests can find the cached key value empty because the callback hasn't completed.
  * This can result in several threads repopulating the cached item.
* When one cache entry is used to create another, the child copies the parent entry's expiration tokens and time-based expiration settings. The child isn't expired by manual removal or updating of the parent entry.
* Use <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.PostEvictionCallbacks> to set the callbacks that will be fired after the cache entry is evicted from the cache. In the example code, <xref:System.Threading.CancellationTokenSource.Dispose?displayProperty=nameWithType> is called to release the unmanaged resources used by the `CancellationTokenSource`. However, the `CancellationTokenSource` is not disposed immediately because it is still being used by the cache entry. The `CancellationToken` is passed to `MemoryCacheEntryOptions` to create a cache entry that expires after a certain time. So `Dispose` should not be called until the cache entry is removed or expired. The example code calls the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.RegisterPostEvictionCallback%2A> method to register a callback that will be invoked when the cache entry is evicted, and it disposes the `CancellationTokenSource` in that callback.
* For most apps, `IMemoryCache` is enabled. For example, calling `AddMvc`, `AddControllersWithViews`, `AddRazorPages`, `AddMvcCore().AddRazorViewEngine`, and many other `Add{Service}` methods in `ConfigureServices`, enables `IMemoryCache`. For apps that are not calling one of the preceding `Add{Service}` methods, it may be necessary to call <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache%2A> in `ConfigureServices`.

## Background cache update

Use a [background service](xref:fundamentals/host/hosted-services) such as <xref:Microsoft.Extensions.Hosting.IHostedService> to update the cache. The background service can recompute the entries and then assign them to the cache only when they’re ready.

## Additional resources

* <xref:performance/caching/distributed>
* <xref:fundamentals/change-tokens>
* <xref:performance/caching/response>
* <xref:performance/caching/middleware>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>
    
:::moniker-end
