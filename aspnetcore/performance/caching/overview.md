---
title: Overview of caching in ASP.NET Core
author: tdykstra
description: Explore caching in ASP.NET Core, including in-memory, distributed, hybrid, response, and output caching.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.date: 05/01/2026
uid: performance/caching/overview

# customer intent: As an ASP.NET developer, I want to explore caching options in ASP.NET Core, so I can use various types of caching in my apps.
---
# Overview of caching in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Tom Dykstra](https://twitter.com/tdykstra)

This article provides an overview of caching in ASP.NET Core with an introduction to in-memory, distributed, hybrid, response, and output caching.

:::moniker range=">= aspnetcore-9.0"

## In-memory caching

In-memory caching uses server memory to store cached data. This type of caching is suitable for a single server or multiple servers that use session affinity. Session affinity is also known as *sticky sessions*. Session affinity means that the requests from a client are always routed to the same server for processing.

For more information, see [Cache in-memory in ASP.NET Core](xref:performance/caching/memory) and [Troubleshoot Azure Application Gateway session affinity issues](/azure/application-gateway/how-to-troubleshoot-application-gateway-session-affinity-issues).

## Distributed cache

Use a distributed cache to store data when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client can submit a request that gets handled by any server in the group when cached data for the client is available. ASP.NET Core works with SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), [Postgres](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Postgres), and [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) distributed caches.

For more information, see [Distributed caching in ASP.NET Core](xref:performance/caching/distributed).

## HybridCache

[!INCLUDE[](~/performance/caching/hybrid/includes/overview.md)]

## Response caching

[!INCLUDE[](~/includes/response-caching-mid.md)]

For more information, see [Response caching in ASP.NET Core](xref:performance/caching/response).

## Output caching

The output caching middleware enables caching of HTTP responses. Output caching differs from [response caching](#response-caching) in the following ways:

* Caching behavior is configurable on the server.

  Response caching behavior is defined with HTTP headers. For example, when you browse a website with Chrome or Microsoft Edge, the browser automatically sends a `Cache-control: max-age=0` header. This header effectively disables response caching because the server follows the directions provided by the client. A new response is returned for every request, even if the server has a fresh cached response. With output caching, the client doesn't override the caching behavior that you configure on the server.

* The cache storage medium is extensible.

  Memory is used by default. Response caching is limited to memory.

* You can programmatically invalidate selected cache entries.

  Response caching is dependent on HTTP headers, which leaves you with few options for invalidating cache entries.

* Resource locking mitigates the risk of cache stampede and thundering herd.

  *Cache stampede* happens when a frequently used cache entry is revoked, and too many requests try to repopulate the same cache entry at the same time. *Thundering herd* is similar: a burst of requests for the same response that isn't already in a cache entry. Resource locking ensures that all requests for a given response wait for the first request to populate the cache. Response caching doesn't have a resource locking feature.

* Cache revalidation minimizes bandwidth usage.

  *Cache revalidation* means the server can return a _304 Not Modified_ HTTP status code instead of a cached response body. This status code informs the client that the response to the request is unchanged from what was previously received. Response caching doesn't do cache revalidation.

For more information, see [Output caching middleware in ASP.NET Core](xref:performance/caching/output).

## Cache Tag Helper

Cache the content from an MVC view or Razor Page with the Cache Tag Helper. The Cache Tag Helper uses in-memory caching to store data.

For more information, see [Cache Tag Helper in ASP.NET Core MVC](xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper).

## Distributed Cache Tag Helper

Cache the content from an MVC view or Razor Page in distributed cloud or web farm scenarios with the Distributed Cache Tag Helper. The Distributed Cache Tag Helper uses SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), or [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) to store data.

For more information, see [Distributed Cache Tag Helper in ASP.NET Core](xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper).

:::moniker-end

[!INCLUDE[](~/performance/caching/overview/includes/overview7-8.md)]
[!INCLUDE[](~/performance/caching/overview/includes/overview6.md)]

## Related content

* [Cache in-memory in ASP.NET Core](xref:performance/caching/memory)
* [Distributed caching in ASP.NET Core](xref:performance/caching/distributed)
* [HybridCache library in ASP.NET Core](xref:performance/caching/hybrid)
* [Response caching middleware in ASP.NET Core](xref:performance/caching/middleware)
* [Output caching middleware in ASP.NET Core](xref:performance/caching/output)