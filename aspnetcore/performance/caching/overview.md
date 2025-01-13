---
title: Overview of caching in ASP.NET Core
author: tdykstra
description: Overview of caching in ASP.NET Core
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.date: 11/07/2022
uid: performance/caching/overview
---
# Overview of caching in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Tom Dykstra](https://twitter.com/tdykstra)

:::moniker range=">= aspnetcore-9.0"

Caching can improve the performance and scalability of an app by reducing the work required to generate content. Caching works best with data that changes infrequently **and** is expensive to generate. Caching makes a copy of data that can be returned much faster than from the source.

ASP.NET Core supports several different caching APIs:

* In-memory cache
* Distributed cache
* Hybrid cache
* Response caching
* Output caching

## In-memory cache

In-memory caching uses server memory to store cached data. The <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> interface provides the API for storing and retrieving data in memory. 

This type of caching is suitable for a single server or multiple servers using session affinity, also known as *sticky sessions*. A web farm configured for sticky sessions routes all requests for a given session to the same server for processing.

Non-sticky sessions in a web farm require a [#distributed-cache](xref:performance/caching/distributed) to avoid cache consistency problems. Using a distributed cache offloads the cache memory from each server to an external process. For some apps, a distributed cache can support higher scale-out than an in-memory cache.

The in-memory cache API can store any object. The distributed cache interface is limited to byte arrays (`byte[]`). The in-memory and distributed cache store cache items as key-value pairs.

For more information, see <xref:performance/caching/memory>.

## Distributed Cache

Use a distributed cache to store data when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client's request for cached data can be handled by any server in the server farm if cached data for the client is available.

ASP.NET Core works with SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), and [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) distributed caches.

For more information, see <xref:performance/caching/distributed>.

## HybridCache

The `Hybrid cache`API bridges some gaps in the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> and <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> APIs. <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache> is an abstract class with a default implementation that handles most aspects of saving to cache and retrieving from cache:

`HybridCache has the following features that the other APIs don't have:

* A unified API for both in-process and out-of-process caching.

  `Hybrid cache` is designed to be a drop-in replacement for existing `IDistributedCache` and `IMemoryCache` usage, and it provides a 
simple API for adding new caching code. If the app has an `IDistributedCache` implementation, the `HybridCache` service uses it for secondary caching. This two-level caching strategy allows `HybridCache` to provide the speed of an in-memory cache and the durability of a distributed or persistent cache.

* Stampede protection.

  *Cache stampede* happens when a frequently used cache entry is revoked, and too many requests try to repopulate the same cache entry at the same time. The `HybridCache` implementation combines concurrent operations, ensuring that all requests for a given response wait for the first request to populate the cache.

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

The equivalent code using the `HybridCache` class is simpler although it also provides features such as stampede protection:

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

The `HybridCache` library supports older .NET runtimes, including .NET Framework 4.7.2 and .NET Standard 2.0.

For more information, see <xref:performance/caching/hybrid>.

## Response caching

Response caching decreases the workload on the server in two ways:

* By storing and reusing entire HTTP responses. This behavior differs from memory cache, distributed cache, and hybrid cache, which store any data objects specified by the application code. 
* By reducing the number of requests clients and intermediate proxies make to the web server. This effect is achieved by setting HTTP headers such as Cache-Control, Expires, and ETag, which instruct clients and proxies on how to cache the responses. None of the other available types of caching have this capability.

Response caching has limited benefits for UI apps such as Blazor web apps because browsers generally set request headers that prevent caching. In contrast, [output caching](xref:performance/caching/output) benefits UI apps by allowing server-side configuration to decide what should be cached independently of HTTP headers.

Response caching on the server relies on middleware to handle the storage and retrieval of cache entries. This middleware must be configured in the application to function correctly. The Response caching middleware:

* Enables caching server responses based on [HTTP cache headers](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) like proxies do.
* May be beneficial for public GET or HEAD API requests from clients where the [Conditions for caching](xref:performance/caching/middleware#cfc) are met.

For more information, see <xref:performance/caching/response> and <xref:performance/caching/middleware>

<a name="oc7"></a>

## Output caching

The output caching middleware enables caching of HTTP responses. Output caching differs from [response caching](#response-caching) in the following ways:

* The caching behavior is configurable on the server.

  Response caching behavior is defined by HTTP headers. For example, when you visit a website with Chrome or Edge, the browser automatically sends a `Cache-control: max-age=0` header. This header effectively disables response caching, since the server follows the directions provided by the client. A new response is returned for every request, even if the server has a fresh cached response. With output caching the client doesn't override the caching behavior that you configure on the server.

* The cache storage medium is extensible.

  Memory is used by default. Response caching is limited to memory.

* You can programmatically invalidate selected cache entries.

  Response caching's dependence on HTTP headers leaves you with few options for invalidating cache entries.

* Resource locking mitigates the risk of cache stampede and thundering herd.

  *Cache stampede* happens when a frequently used cache entry is revoked, and too many requests try to repopulate the same cache entry at the same time. *Thundering herd* is similar: a burst of requests for the same response that isn't already in a cache entry. Resource locking ensures that all requests for a given response wait for the first request to populate the cache. Response caching doesn't have a resource locking feature.

* Cache revalidation minimizes bandwidth usage.

  *Cache revalidation* means the server can return a `304 Not Modified` HTTP status code instead of a cached response body. This status code informs the client that the response to the request is unchanged from what was previously received. Response caching doesn't do cache revalidation.

For more information, see <xref:performance/caching/output>.

## Cache Tag Helper

Cache the content from an MVC view or Razor Page with the Cache Tag Helper. The Cache Tag Helper uses in-memory caching to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>.

## Distributed Cache Tag Helper

Cache the content from an MVC view or Razor Page in distributed cloud or web farm scenarios with the Distributed Cache Tag Helper. The Distributed Cache Tag Helper uses SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), or [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>.

Additional resources

* <https://learn.microsoft.com/azure/architecture/best-practices/caching>

:::moniker-end

[!INCLUDE[](~/performance/caching/overview/includes/overview7-8.md)]
[!INCLUDE[](~/performance/caching/overview/includes/overview6.md)]
