:::moniker range="< aspnetcore-7.0"

## In-memory caching

In-memory caching uses server memory to store cached data. This type of caching is suitable for a single server or multiple servers using session affinity. Session affinity is also known as *sticky sessions*. Session affinity means that the requests from a client are always routed to the same server for processing.

For more information, see <xref:performance/caching/memory> and [Troubleshoot Azure Application Gateway session affinity issues](/azure/application-gateway/how-to-troubleshoot-application-gateway-session-affinity-issues).

## Distributed Cache

Use a distributed cache to store data when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client can submit a request that's handled by any server in the group if cached data for the client is available. ASP.NET Core works with SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), and [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) distributed caches.

For more information, see <xref:performance/caching/distributed>.

## HybridCache

[!INCLUDE[](~/performance/caching/hybrid/includes/overview.md)]

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
