---
title: Overview of caching in ASP.NET Core
author: tdykstra
description: Overview of caching in ASP.NET Core
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.date: 11/07/2022
uid: performance/caching/overview
---
# Overview of caching in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Kirk Larkin](https://twitter.com/serpent5)

:::moniker range=">= aspnetcore-7.0"

## In-memory caching

In-memory caching uses server memory to store cached data. This type of caching is suitable for a single server or multiple servers using session affinity. Session affinity is also known as *sticky sessions*. Session affinity means that the requests from a client are always routed to the same server for processing.

For more information, see <xref:performance/caching/memory> and [Troubleshoot Azure Application Gateway session affinity issues](/azure/application-gateway/how-to-troubleshoot-application-gateway-session-affinity-issues).

## Distributed Cache

Use a distributed cache to store data in memory when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client can submit a request that's handled by any server in the group if cached data for the client is available. ASP.NET Core works with SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), and [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) distributed caches.

For more information, see <xref:performance/caching/distributed>.

## Cache Tag Helper

Cache the content from an MVC view or Razor Page with the Cache Tag Helper. The Cache Tag Helper uses in-memory caching to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>.

## Distributed Cache Tag Helper

Cache the content from an MVC view or Razor Page in distributed cloud or web farm scenarios with the Distributed Cache Tag Helper. The Distributed Cache Tag Helper uses SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), or [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>.

## Response caching

[!INCLUDE[](~/includes/response-caching-mid.md)]

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

:::moniker-end

:::moniker range="< aspnetcore-7.0"

## In-memory caching

In-memory caching uses server memory to store cached data. This type of caching is suitable for a single server or multiple servers using session affinity. Session affinity is also known as *sticky sessions*. Session affinity means that the requests from a client are always routed to the same server for processing.

For more information, see <xref:performance/caching/memory> and [Troubleshoot Azure Application Gateway session affinity issues](/azure/application-gateway/how-to-troubleshoot-application-gateway-session-affinity-issues).

## Distributed Cache

Use a distributed cache to store data in memory when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client can submit a request that's handled by any server in the group if cached data for the client is available. ASP.NET Core works with SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), and [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) distributed caches.

For more information, see <xref:performance/caching/distributed>.

## Cache Tag Helper

Cache the content from an MVC view or Razor Page with the Cache Tag Helper. The Cache Tag Helper uses in-memory caching to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>.

## Distributed Cache Tag Helper

Cache the content from an MVC view or Razor Page in distributed cloud or web farm scenarios with the Distributed Cache Tag Helper. The Distributed Cache Tag Helper uses SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), or [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>.

## Response caching

[!INCLUDE[](~/includes/response-caching-mid.md)]

## Output caching

[Output caching](xref:performance/caching/overview?view=aspnetcore-7.0#oc7) is available in .NET 7 and later.

:::moniker-end
