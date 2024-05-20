---
title: HybridCache library in ASP.NET Core
author: tdykstra
description: Learn how to use HybridCache library in ASP.NET Core.
monikerRange: '>= aspnetcore-9.0'
ms.author: tdykstra
ms.date: 05/17/2024
uid: performance/caching/hybrid
---
# HybridCache library in ASP.NET Core

[!INCLUDE[](~/includes/not-ga-yet.md)] 

<!--
[!INCLUDE[](~/includes/not-latest-version.md)] 
Uncomment this when 9.0 is the default value in the version selector.
-->

This article explains how to configure and use the `HybridCache` library in an ASP.NET Core app. For an introduction to the library, see [the `HybridCache` section of the Caching overview](xref:performance/caching/overview#hybridcache).

## Get the library

Install the `Microsoft.Extensions.Caching.Hybrid` package.

```dotnetcli
dotnet add package Microsoft.Extensions.Caching.Hybrid --prerelease
```

## Register the service

Add the `HybridCache` service to the [dependency injection (DI)](xref:fundamentals/dependency-injection) container by calling [`AddHybridCache`](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/HybridCacheServiceExtensions.cs,2c4a0de52ec7387c):

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_noconfig" highlight="7":::

The preceding code registers the `HybridCache` service with default options. The registration API can also configure [options](#options) and [serialization](#serialization).

## Get and store cache entries

The `HybridCache` service provides a [`GetOrCreateAsync`](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Runtime/HybridCache.cs,990ceb8b6f2999f7) method with two overloads, taking a key and:

* A factory method.
* State, and a factory method.

The method uses the key to try to retrieve the object from the primary cache. If the item is not found in the primary cache (a cache miss), it then checks the secondary cache if one is configured. If it doesn't find the data there (another cache miss), it calls the factory method to get the object from the data source. It then stores the object in both primary and secondary caches. The factory method is never called if the object is found in the primary or secondary cache (a cache hit).

The `HybridCache` service ensures that only one concurrent caller for a given key executes the factory method, and all other callers wait for the result of that execution.The `CancellationToken` passed to `GetOrCreateAsync` represents the combined cancellation of all concurrent callers.

### The main `GetOrCreateAsync` overload

The stateless overload of `GetOrCreateAsync` is recommended for most scenarios. The code to call it is relatively simple. Here's an example:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreate" highlight="5-12":::

### The alternative `GetOrCreateAsync` overload

The alternative overload might reduce some overhead from [captured variables](/dotnet/csharp/language-reference/operators/lambda-expressions#capture-of-outer-variables-and-variable-scope-in-lambda-expressions) and per-instance callbacks, but at the expense of more complex code. For most scenarios the performance increase doesn't outweigh the code complexity. Here's an example that uses the alternative overload:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreatestate" highlight="5-14":::

### The `SetAsync` method

In many scenarios, `GetOrCreateAsync` is the only API needed. But `HybridCache` also has [`SetAsync`](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Internal/DefaultHybridCache.cs,ed5c0ddff676c5f2) to store an object in cache without trying to retrieve it first.
<!--
Add GetAsync when it's implemented.
-->

## Remove unexpired cache entries

When the underlying data for cache entries changes before they expire, you can explicitly remove the entries. The entries to remove can be specified by key. When an entry is removed, it's removed from both the primary and secondary caches.

### Remove by key

The following methods support removal of cache entries by key:

* `RemoveKeyAsync`
* `RemoveKeysAsync`

**Note:** These will change to `RemoveByKeyAsync` and `RemoveByKeysAsync` in the future.
 
<!--
## Tags

Tags can be used to group cache entries and invalidate them together. You can set tags when calling `GetOrCreateAsync`, as shown in the following example:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreateoptions" highlight="7,17":::

For example, if the key is composed of first name and last name, set a tag with the value of last name when calling `GetOrCreateAsync`. Then, when the last name changes, call one of the following methods to remove all cache entries with that tag:

* `RemoveTagAsync`
* `RemoveTagsAsync`

These methods remove all cache entries that have one or more of the specified tags.

**Note:** These will change to `RemoveByTagAsync` and `RemoveByTagsAsync` in the future.
<!--
Uncomment when tags are implemented.
-->

## Options

The `AddHybridCache` method can be used to configure global defaults. The following example shows how to configure some of the available options:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_globaloptions" highlight = "6-15":::

The `GetOrCreateAsync` method can also take a `HybridCacheEntryOptions` object to override the global defaults for a specific cache entry. Here's an example:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreateoptions" highlight = "8-12,16":::

For more information about the options, see the source code:

* [HybridCacheOptions](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/HybridCacheOptions.cs,8736f7c41cee28f4) class.
* [HybridCacheEntryOptions](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Runtime/HybridCacheEntryOptions.cs,fe35dea42677e2f8) class.

## Limits

The following properties of `HybridCacheOptions` let you configure limits that apply to all cache entries:

* MaximumPayloadBytes - Maximum size of a cache entry. Default value is 1 MB. Attempts to store values over this size are logged, and the value is not stored in cache.
* MaximumKeyLength - Maximum length of a cache key. Default value is 1024 characters. Attempts to store values over this size are logged, and the value is not stored in cache.
 
## Serialization

Serialization is configured as part of registering the service, with support for type-specific and generalized serializers via the
`WithSerializer` and `.WithSerializerFactory` methods, chained from the `AddHybridCache` call. By default, the library
handles `string` and `byte[]` internally, and uses `System.Text.Json` for everything else, but you can configure `HybridCache` to use protobuf, xml, or anything else.

An example that configures the service to use a protobuf serializer is [here](https://github.com/dotnet/aspnetcore/commit/ac0dbd8c96caa704e39a080b8db59183b6dd3e13).

## Cache storage

By default `HybridCache` uses <xref:System.Runtime.Caching.MemoryCache> for its primary cache storage. Cache entries are stored in-process, so each server has a separate cache that is lost whenever the server process is restarted. For secondary out-of-process storage, such as Redis or SQL Server, `HybridCache` uses [the configured `IDistributedCache` implementation](xref:performance/caching/distributed), if any. But even without an `IDistributedCache`implementation, the `HybridCache` service still provides in-process caching and stampede protection.

## Optimize performance

To optimize performance, configure `HybridCache` to reuse objects and avoid `byte[]` allocations.

### Reuse objects

In typical existing code that uses `IDistributedCache`, every retrieval of an object from the cache results in deserialization. This behavior means that each concurrent caller gets a separate instance of the object, which cannot interact with other instances. The result is thread safety, as there's no risk of concurrent modifications to the same object instance.

Because a lot of `HybridCache` usage will be adapted from existing `IDistributedCache` code, `HybridCache` preserves this behavior by default to avoid introducing concurrency bugs. However, objects are inherently thread-safe if:

* They are immutable types.
* The code doesn't modify them.

In such cases, inform `HybridCache` that it's safe to reuse instances by:

* Marking the type as `sealed`. The `sealed` keyword in C# means that the class cannot be inherited.
* Applying the `[ImmutableObject(true)]` attribute to the type. The `[ImmutableObject(true)]` attribute indicates that the object's state cannot be changed after it's created.

By reusing instances, `HybridCache` can reduce the overhead of CPU and object allocations associated with per-call deserialization. This can lead to performance improvements in scenarios where the cached objects are large or accessed frequently.

### Avoid `byte[]` allocations

`HybridCache` also provides optional APIs for `IDistributedCache` implementations, to avoid `byte[]` allocations. This feature is implemented by the preview versions of the `Microsoft.Extensions.Caching.StackExchangeRedis` and `Microsoft.Extensions.Caching.SqlServer` packages. For more information, see [IBufferDistributedCache](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Runtime/IBufferDistributedCache.cs,df9fb366340929b1)
Here are the .NET CLI commands to install the packages:

```dotnetcli
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis --prerelease
```

```dotnetcli
dotnet add package Microsoft.Extensions.Caching.SqlServer --prerelease
```

## Custom HybridCache implementations

A concrete implementation of the `HybridCache` abstract class is included in the shared framework and is provided via dependency injection. But developers are welcome to provide custom implementations of the API.

## Compatibility

The library supports older .NET runtimes, down to .NET Framework 4.7.2 and .NET Standard 2.0.

## Additional resources

For more information about `HybridCache`, see the following resources:

* GitHub issue [dotnet/aspnetcore #54647](https://github.com/dotnet/aspnetcore/issues/54647).
* [`HybridCache` source code](https://source.dot.net/#Microsoft.Extensions.Caching.Hybrid/Runtime/HybridCache.cs,8c0fe94693d1ac8d)
