---
title: In Memory Caching | Microsoft Docs
author: ardalis
description: Shows how to cache data in-memory.
keywords: ASP.NET Core, cache, in-memory, performance
ms.author: riande
manager: wpickett
ms.date: 12/14/2016
ms.topic: article
ms.assetid: 819511cf-d33e-410a-b5a9-bef7fa64d2f3
ms.technology: aspnet
ms.prod: aspnet-core
uid: performance/caching/memory
---
# In Memory Caching


By [Steve Smith](http://ardalis.com), [Rick Anderson](https://twitter.com/RickAndMSFT)

In-memory cached data can be accessed much faster than a database.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/memory/sample)

<a name=caching-basics></a>

## Caching Basics

Caching can significantly improve the performance and scalability of an app, by replacing requests to a persistent datastore with in memory data. Caching works best with data that changes infrequently. For example, data-driven navigation menus, which rarely change but are frequently requested. Caching can greatly improve performance by reducing round trips to the datastore.

Caching makes a copy of data that can be returned much faster than from the original source. You should write and test your app such that it can use cached data if it's available, but will fallback to the correctly using the underlying data source.

ASP.NET Core supports several different caches. The simplest cache is based on the [IMemoryCache](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.caching.memory.imemorycache), which represents a cache stored in the memory of the local web server.

An in-memory cache is stored in the memory of the server hosting an ASP.NET app. Apps that utilize scale out in the cloud (run on multiple servers, that is a server farm), should ensure that sessons are sticky. Sticky sessions ensure that subsequent requests from a client all go to the same server. For example, Azure Web apps use  (Application Request Routing)[http://www.iis.net/learn/extensions/planning-for-arr] (ARR) to route all subsequent requests to the same server.

If an app is hosted by multiple servers in a web farm or cloud hosting environment, and you cannot guarantee sticky sessions (that is subsequent requests to to the same server), you will not be able to use the in-memory cache. Non-sticky sessions require using  a [distributed cache](distributed.md) to avoid cache consistency problems.

## Configuring In Memory Caching

To use an in memory cache in your ASP.NET application, add the following dependencies to your *project.json* file:

[!code-json[Main](memory/sample/src/CachingSample/project.json?range=7-13&highlight=4)]

Caching in ASP.NET Core is a *service* that should be referenced from your application by [Dependency Injection](../../fundamentals/dependency-injection.md). To register the caching service and make it available within your app, add the following line to your `ConfigureServices` method in `Startup`:

[!code-csharp[Main](memory/sample/src/CachingSample/Startup.cs?range=12-15&highlight=3)]

You utilize caching in your app by requesting an instance of `IMemoryCache` in your controller or middleware constructor. In the sample for this article, we are using a simple middleware component to handle requests by returning customized greeting. The constructor is shown here:

[!code-csharp[Main](memory/sample/src/CachingSample/Middleware/GreetingMiddleware.cs?range=19-28&highlight=2,7)] 

## Reading and Writing to a Memory Cache

The middleware's `Invoke` method returns the cached data when it's available.

There are two methods for accessing cache entries:

**`Get`**

`Get` will return the value if it exists, but otherwise returns `null`.

**`TryGet`**

`TryGet` will assign the cached value to an `out` parameter and return true if the entry exists. Otherwise it returns false.

Use the `Set` method to write to the cache. `Set` accepts the key to use to look up the value, the value to be cached, and a set of `MemoryCacheEntryOptions`. The `MemoryCacheEntryOptions` allow you to specify absolute or sliding time-based cache expiration, caching priority, callbacks, and dependencies. These options are detailed below.

The sample code (shown below) uses the `SetAbsoluteExpiration` method on `MemoryCacheEntryOptions` to cache greetings for one minute.

[!code-csharp[Main](memory/sample/src/CachingSample/Middleware/GreetingMiddleware.cs?highlight=7,10,16-18&range=30-58)]

In addition to setting an absolute expiration, a sliding expiration can be used to keep frequently requested items in the cache:

```csharp
// keep item in cache as long as it is requested at least
// once every 5 minutes
new MemoryCacheEntryOptions()
  .SetSlidingExpiration(TimeSpan.FromMinutes(5))
```

To avoid having frequently-accessed cache entries growing too stale (because their sliding expiration is constantly reset), you can combine absolute and sliding expirations:

```csharp
// keep item in cache as long as it is requested at least
// once every 5 minutes...
// but in any case make sure to refresh it every hour
new MemoryCacheEntryOptions()
  .SetSlidingExpiration(TimeSpan.FromMinutes(5))
  .SetAbsoluteExpiration(TimeSpan.FromHours(1))
```

By default, an instance of `MemoryCache` will automatically manage the items stored, removing entries when necessary in response to memory pressure in the app. You can influence the way cache entries are managed by setting their `CacheItemPriority` when adding the item to the cache. For instance, if you have an item you want to keep in the cache unless you explicitly remove it, you would use the `NeverRemove` priority option:

```csharp
// keep item in cache indefinitely unless explicitly removed
new MemoryCacheEntryOptions()
  .SetPriority(CacheItemPriority.NeverRemove))
```

When you do want to explicitly remove an item from the cache, you can do so easily using the `Remove` method:

```csharp
cache.Remove(cacheKey);
```

## Cache Dependencies and Callbacks

You can configure cache entries to depend on other cache entries, the file system, or programmatic tokens, evicting the entry in response to changes. You can register a callback, which will run when a cache item is evicted.

[!code-csharp[Main](memory/sample/test/CachingSample.Tests/MemoryCacheTests.cs?highlight=6-11,18&range=22-41)]

The callback is run on a different thread from the code that removes the item from the cache.

>[!WARNING]
> If the callback is used to repopulate the cache it is possible other requests for the cache will take place (and find it empty) before the callback completes, possibly resulting in several threads repopulating the cached value.

Possible `eviction reasons` are:

**None**

No reason known.

**Removed**

The item was manually removed by a call to `Remove()`

**Replaced**

The item was overwritten.

**Expired**

The item timed out.

**TokenExpired**

The token the item depended upon fired an event.

**Capacity**

The item was removed as part of the cache's memory management process.

You can specify that one or more cache entries depend on a `CancellationTokenSource` by adding the expiration token to the `MemoryCacheEntryOptions` object. When a cached item is invalidated, call `Cancel` on the token, which will expire all of the associated cache entries (with a reason of `TokenExpired`). The following unit test demonstrates this:

[!code-csharp[Main](memory/sample/test/CachingSample.Tests/MemoryCacheTests.cs?highlight=7,16,21&range=43-64)]

Using a `CancellationTokenSource` allows multiple cache entries to all be expired without the need to create a dependency between cache entries themselves (in which case, you must ensure that the source cache entry exists before it is used as a dependency for other entries).

Cache entries will inherit triggers and timeouts from other entries accessed while creating the new entry. This approach ensures that subordinate cache entries expire at the same time as related entries.

[!code-csharp[Main](memory/sample/test/CachingSample.Tests/MemoryCacheTests.cs?highlight=7,11,13,23,24&range=66-94)]

> [!NOTE]
> When one cache entry is used to create another, the new one copies the existing entry's expiration tokens and time-based expiration settings, if any. It is not expired in response to manual removal or updating of the existing entry.

## Other Resources

* [Working with a Distributed Cache](distributed.md)
