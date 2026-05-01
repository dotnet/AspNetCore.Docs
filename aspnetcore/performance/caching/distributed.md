---
title: Distributed caching in ASP.NET Core
author: tdykstra
description: Learn how to use an ASP.NET Core distributed cache to improve app performance and scalability, especially in a cloud or server farm environment.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 05/01/2026
uid: performance/caching/distributed
ms.sfi.ropc: t

# customer intent: As an ASP.NET developer, I want to use an ASP.NET Core distributed cache, so I can improve app performance and scalability.
---
# Distributed caching in ASP.NET Core

By [Mohsin Nasir](https://github.com/mohsinnasir) and [smandia](https://github.com/smandia)

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

A distributed cache is a cache shared by multiple app servers. The cache is typically maintained as an external service for the app servers that access it. A distributed cache can improve the performance and scalability of an ASP.NET Core app, especially when a cloud service or a server farm hosts the app.

A distributed cache has several advantages over other caching scenarios where cached data is stored on individual app servers.

When cached data is distributed, the data:

* Is *coherent* (consistent) across requests to multiple servers.
* Survives server restarts and app deployments.
* Doesn't use local memory.

Distributed cache configuration is implementation specific. This article describes how to configure SQL Server, Redis, or Postgres distributed caches. Non-Microsoft implementations are also available, such as [NCache](http://www.alachisoft.com/ncache/aspnet-core-idistributedcache-ncache.html) ([NCache on GitHub](https://github.com/Alachisoft/NCache)), Azure Cosmos DB, and Postgres. Regardless of which implementation is selected, the app interacts with the cache by using the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> interface.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/distributed/samples/) ([how to download](xref:fundamentals/index#how-to-download-a-sample))

[!INCLUDE [managed-identities](~/includes/managed-identities-test-non-production.md)]

## Prerequisites

Add a package reference for the distributed cache provider used:

* For a Redis distributed cache, [Microsoft.Extensions.Caching.StackExchangeRedis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis).
* For SQL Server, [Microsoft.Extensions.Caching.SqlServer](https://www.nuget.org/packages/Microsoft.Extensions.Caching.SqlServer).
* For Postgres, [Microsoft.Extensions.Caching.Postgres](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Postgres).
* For Azure Cosmos DB, [Microsoft.Extensions.Caching.Cosmos](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Cosmos).
* For the NCache distributed cache, [NCache.Microsoft.Extensions.Caching.OpenSource](https://www.nuget.org/packages/NCache.Microsoft.Extensions.Caching.OpenSource).

## Use the IDistributedCache interface

The <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> interface provides the following methods to manipulate items in the distributed cache implementation:

* <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Get*>, <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.GetAsync*>: Accepts a string key and retrieves a cached item as a `byte[]` array if found in the cache.
* <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Set*>, <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.SetAsync*>: Adds an item (as `byte[]` array) to the cache by using a string key.
* <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Refresh*>, <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.RefreshAsync*>: Refreshes an item in the cache based on its key, resetting its sliding expiration timeout (if any).
* <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Remove*>, <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.RemoveAsync*>: Removes a cache item based on its string key.

## Establish distributed caching services

Register an implementation of <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> in the _Program.cs_ file. The following framework-provided implementations are described in this article:

* [Distributed Redis cache](#distributed-redis-cache)
* [Distributed memory cache](#distributed-memory-cache)
* [Distributed SQL Server cache](#distributed-sql-server-cache)
* [Distributed Postgres cache](#distributed-postgres-cache)
* [Distributed NCache cache](#distributed-ncache-cache)
* [Distributed Azure Cosmos DB cache](#distributed-azure-cosmos-db-cache)

### Distributed Redis cache

The distributed Redis cache delivers the best performance and is recommended for production apps. [Redis](https://redis.io/) is an open source in-memory data store, which is often used as a distributed cache. You can configure an [Azure Cache for Redis](/azure/azure-cache-for-redis/cache-overview) for an Azure-hosted ASP.NET Core app, and use an Azure Cache for Redis for local development. For more information, see [Review cache recommendations](#review-cache-recommendations).

An app configures the cache implementation with a <xref:Microsoft.Extensions.Caching.StackExchangeRedis.RedisCache> instance by calling the <xref:Microsoft.Extensions.DependencyInjection.StackExchangeRedisCacheServiceCollectionExtensions.AddStackExchangeRedisCache%2A> method. For [output caching](xref:performance/caching/output#cache-storage), use the <xref:Microsoft.Extensions.DependencyInjection.StackExchangeRedisOutputCacheServiceCollectionExtensions.AddStackExchangeRedisOutputCache%2A> method.

1. Create an Azure Cache for Redis.

1. Copy the Primary connection string (StackExchange.Redis) to [Configuration](xref:fundamentals/configuration/index).

   - **For local development**: Save the connection string with [Secret Manager](xref:security/app-secrets#secret-manager).

   - **For Azure**: Save the connection string in a secure store such as [Azure Key Vault](/azure/key-vault/general/overview).

The following code enables the Azure Cache for Redis:

[!code-csharp[](~/performance/caching/distributed/samples/6.x/DistCacheSample/Program.cs?name=snippet_AddStackExchangeRedisCache)]

The preceding code assumes the Primary connection string (StackExchange.Redis) is saved in configuration with the key name `MyRedisConStr`.

For more information, see [Azure Cache for Redis](/azure/azure-cache-for-redis/cache-overview).

For a discussion on alternative approaches to a local Redis cache, see [GitHub /dotnet/aspnetcore issue #19542](https://github.com/dotnet/AspNetCore.Docs/issues/19542).

### Distributed memory cache

The distributed memory cache (<xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddDistributedMemoryCache*>) is a framework-provided implementation of <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> that stores items in memory. However, the distributed memory cache isn't an actual distributed cache. The app instance stores the cached items on the server where the app is running.

The distributed memory cache is a useful implementation for development and testing scenarios. It's also useful for a single server in a production scenario where memory consumption isn't an issue. Implementing the distributed memory cache abstracts cached data storage. It allows for implementing a true distributed caching solution in the future if multiple nodes or fault tolerance become necessary.

The sample app makes use of the distributed memory cache when the app runs in the `Development` environment in the _Program.cs_ file.

[!code-csharp[](~/performance/caching/distributed/samples/6.x/DistCacheSample/Program.cs?name=snippet_AddDistributedMemoryCache)]

### Distributed SQL Server cache

The distributed SQL Server cache implementation (<xref:Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions.AddDistributedSqlServerCache*>) allows the distributed cache to use a SQL Server database as its backing store. To create a SQL Server cached item table in a SQL Server instance, you can use the `sql-cache` tool. The tool creates a table with the name and schema that you specify.

Create a table in SQL Server by running the `sql-cache create` command. Provide the SQL Server instance (`Data Source`), database (`Initial Catalog`), schema (for example, `dbo`), and table name (for example, `TestCache`):

```dotnetcli
dotnet sql-cache create "Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=DistCache;Integrated Security=True;" dbo TestCache
```

When the tool succeeds, a message is logged:

```console
Table and index were created successfully.
```

The table created by the `sql-cache` tool has the following schema:

:::image type="content" source="~/performance/caching/distributed/_static/SqlServerCacheTable.png" alt-text="Screenshot that shows the schema of a SQL Server cache table created with the 'sql-cache create' command.":::

> [!NOTE]
> An app should manipulate cache values by using an instance of <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache>, not an instance of <xref:Microsoft.Extensions.Caching.SqlServer.SqlServerCache>.

The sample app implements the <xref:Microsoft.Extensions.Caching.SqlServer.SqlServerCache> class in a nondevelopment (`Development`) environment in the _Program.cs_ file:

[!code-csharp[](~/performance/caching/distributed/samples/6.x/DistCacheSample/Program.cs?name=snippet_AddDistributedSqlServerCache)]

> [!NOTE]
> Properties like <xref:Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.ConnectionString*> (and optionally, <xref:Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.SchemaName*> and <xref:Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.TableName*>) are typically stored outside of source control. For example, the [Secret Manager](xref:security/app-secrets) or the _appsettings.json_ or _appsettings.{Environment}.json_ file might store the properties. The connection string can contain credentials that should be kept out of source control systems.

For more information, see [SQL Database on Azure](/azure/sql-database/).

### Distributed Postgres cache

[Azure Database for PostgreSQL](/azure/postgresql) can be used as a distributed cache backing store via the `IDistributedCache` interface. Azure Database for PostgreSQL is a fully managed, AI-ready Database-as-a-Service (DBaaS) offering built on the open-source PostgreSQL engine. The design supports mission-critical workloads with predictable performance, robust security, high availability, and seamless scalability. 

After installing the [Microsoft.Extensions.Caching.Postgres](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Postgres) NuGet package, configure your distributed cache as follows:

1. Register the Service.

   ```csharp
   using Microsoft.Extensions.DependencyInjection;

   var builder = WebApplication.CreateBuilder(args);

   // Register the Postgres distributed cache.
   builder.Services.AddDistributedPostgresCache(options => {
      options.ConnectionString = builder.Configuration.GetConnectionString("PostgresCache");
      options.SchemaName = builder.Configuration.GetValue<string>("PostgresCache:SchemaName", "public");
      options.TableName = builder.Configuration.GetValue<string>("PostgresCache:TableName", "cache");
      options.CreateIfNotExists = builder.Configuration.GetValue<bool>("PostgresCache:CreateIfNotExists", true);
      options.UseWAL = builder.Configuration.GetValue<bool>("PostgresCache:UseWAL", false);
    
      // Optional: Configure expiration settings.

      var expirationInterval = builder.Configuration.GetValue<string>("PostgresCache:ExpiredItemsDeletionInterval");
      if (!string.IsNullOrEmpty(expirationInterval) && TimeSpan.TryParse(expirationInterval, out var interval)) {
          options.ExpiredItemsDeletionInterval = interval;
      }
    
      var slidingExpiration = builder.Configuration.GetValue<string>("PostgresCache:DefaultSlidingExpiration");
      if (!string.IsNullOrEmpty(slidingExpiration) && TimeSpan.TryParse(slidingExpiration, out var sliding)) {
          options.DefaultSlidingExpiration = sliding;
      }
   });

   var app = builder.Build();
   ```

1. Use the cache.

   ```csharp
   public class MyService {
       private readonly IDistributedCache _cache; 

       public MyService(IDistributedCache cache) {
           _cache = cache;
       }

       public async Task<string> GetDataAsync(string key) {
           var cachedData = await _cache.GetStringAsync(key);
        
           if (cachedData == null) {

               // Fetch the data from source.
               var data = await FetchDataFromSource();
            
               // Cache the data with options.
               var options = new DistributedCacheEntryOptions {
                  AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                  SlidingExpiration = TimeSpan.FromMinutes(5)
               };
            
               await _cache.SetStringAsync(key, data, options);
               return data;
           }
        
           return cachedData;
       }
   }
   ```

### Distributed NCache cache

[NCache](https://github.com/Alachisoft/NCache) is an open source in-memory distributed cache developed natively in .NET. NCache works both locally and configured as a distributed cache cluster for an ASP.NET Core app running in Azure or on other hosting platforms.

To install and configure NCache on your local machine, see the [Getting Started Guide](https://www.alachisoft.com/resources/docs/ncache/getting-started/).

To configure NCache:

1. Install the [NCache SDK NuGet package](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/), which supports NCache Opensource for .NET Framework and .NET Core apps.

1. Configure the cache cluster in the [client configuration](https://www.alachisoft.com/resources/docs/ncache/admin-guide/client-config.html) (the _client.ncconf_ file).

1. Add the following code to the _Program.cs_ file:

[!code-csharp[](~/performance/caching/distributed/samples/6.x/DistCacheSample/Program.cs?name=snippet_AddNCache_Cache)]

### Distributed Azure Cosmos DB cache

[Azure Cosmos DB](/azure/cosmos-db/overview) can be configured in ASP.NET Core as a session state provider by using the `IDistributedCache` interface. Azure Cosmos DB is a fully managed NoSQL and relational database for modern app development that offers high availability, scalability, and low-latency access to data for mission-critical applications.

After you install the [Microsoft.Extensions.Caching.Cosmos](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Cosmos) NuGet package, configure an Azure Cosmos DB distributed cache. You can use an existing Azure Cosmos DB client or create a new one, as described in the following sections.

For more information, see the [Microsoft Caching Extension using Azure Cosmos DB](https://github.com/Azure/Microsoft.Extensions.Caching.Cosmos/blob/master/README.md), the GitHub repository README file for the NuGet package.

#### Reuse an existing client

The easiest way to configure a distributed cache is by reusing an existing Azure Cosmos DB client. In this case, the `CosmosClient` instance isn't disposed when the provider is disposed.

```csharp
services.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
{
    cacheOptions.ContainerName = Configuration["CosmosCacheContainer"];
    cacheOptions.DatabaseName = Configuration["CosmosCacheDatabase"];
    cacheOptions.CosmosClient = existingCosmosClient;
    cacheOptions.CreateIfNotExists = true;
});
```

#### Create a new client

Alternatively, instantiate a new client. In this case, the `CosmosClient` instance is disposed when the provider is disposed.

```csharp
services.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
{
    cacheOptions.ContainerName = Configuration["CosmosCacheContainer"];
    cacheOptions.DatabaseName = Configuration["CosmosCacheDatabase"];
    cacheOptions.ClientBuilder = new CosmosClientBuilder(Configuration["CosmosConnectionString"]);
    cacheOptions.CreateIfNotExists = true;
});
```

## Use the distributed cache

To use the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> interface, request an instance of <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> in the app. The instance is provided by [dependency injection (DI)](xref:fundamentals/dependency-injection).

When the sample app starts, the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> instance is injected into the _Program.cs_ file. The current time is cached by using the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> interface. (For more information, see [.NET Generic Host: IHostApplicationLifetime](xref:fundamentals/host/generic-host#ihostapplicationlifetime).)

[!code-csharp[](~/performance/caching/distributed/samples/6.x/DistCacheSample/Program.cs?name=snippet_Configure)]

The sample app injects the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> instance into the `IndexModel` object for use by the Index page.

Each time the Index page loads, the cache is checked for the cached time by using the `OnGetAsync` method. If the cached time isn't expired, the time is displayed. If 20 seconds elapsed since the last time the cached time was accessed (the last time this page loaded), the page displays the message, _Cached Time Expired_.

Immediately update the cached time to the current time by selecting the **Reset Cached Time** option. This action triggers the `OnPostResetCachedTime` handler method.

[!code-csharp[](~/performance/caching/distributed/samples/6.x/DistCacheSample/Pages/Index.cshtml.cs?name=snippet_IndexModel&highlight=7,14-20,25-29)]

> [!NOTE]
> You don't need to use a Singleton or Scoped lifetime for <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> instances with a built-in implementation.
>
> You can also create an <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> instance wherever you might need one instead of using DI. However, creating an instance in code can make your code harder to test and violates the [Explicit Dependencies Principle](/dotnet/architecture/modern-web-apps-azure/architectural-principles#explicit-dependencies).

## Review cache recommendations

When deciding which implementation of the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> interface is best for your app, consider the following points:

* Existing infrastructure
* Performance requirements
* Cost
* Team experience

Caching solutions usually rely on in-memory storage to provide fast retrieval of cached data, but memory is a limited resource and costly to expand. Only store commonly used data in a cache.

For most apps, a Redis cache provides higher throughput and lower latency than a SQL Server cache. However, benchmarking is recommended to determine the performance characteristics of caching strategies.

If SQL Server is the distributed cache backing store, and the cache and app data storage/retrieval use the same database, performance can be reduced. The recommended approach is to use a dedicated SQL Server instance for the distributed cache backing store.

## Related content

* [Cache in-memory in ASP.NET Core](xref:performance/caching/memory)
* [Detect changes with change tokens in ASP.NET Core](xref:fundamentals/change-tokens)
* [Response caching in ASP.NET Core](xref:performance/caching/response)
* [Response caching middleware in ASP.NET Core](xref:performance/caching/middleware)
* [Host ASP.NET Core in a web farm](xref:host-and-deploy/web-farm)

:::moniker-end

[!INCLUDE[](~/performance/caching/distributed/includes/distributed6-7.md)]
[!INCLUDE[](~/performance/caching/distributed/includes/distributed5.md)]
