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

Use a distributed cache to store data when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client can submit a request that's handled by any server in the group if cached data for the client is available. ASP.NET Core works with SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), and [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) distributed caches.

For more information, see <xref:performance/caching/distributed>.

## HybridCache

[!INCLUDE[](~/performance/caching/hybrid/includes/overview.md)]

## Response caching

[!INCLUDE[](~/includes/response-caching-mid.md)]

For more information, see <xref:performance/caching/response>.

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

:::moniker-end

[!INCLUDE[](~/performance/caching/overview/includes/overview7-8.md)]
[!INCLUDE[](~/performance/caching/overview/includes/overview6.md)]
