---
title: HybridCache library in ASP.NET Core
author: tdykstra
description: Learn how to use HybridCache library in ASP.NET Core.
monikerRange: '>= aspnetcore-9.0'
ms.author: tdykstra
ms.custom: sfi-ropc-nochange
ms.date: 05/22/2025
uid: performance/caching/hybrid
ms.ai: assisted
---
# HybridCache library in ASP.NET Core

This article explains how to configure and use the `HybridCache` library in an ASP.NET Core app. For an introduction to the library, see [the `HybridCache` section of the Caching overview](xref:performance/caching/overview#hybridcache).

## Get the library

Install the `Microsoft.Extensions.Caching.Hybrid` package.

```dotnetcli
dotnet add package Microsoft.Extensions.Caching.Hybrid
```

## Register the service

Add the `HybridCache` service to the [dependency injection (DI)](xref:fundamentals/dependency-injection) container by calling <xref:Microsoft.Extensions.DependencyInjection.HybridCacheServiceExtensions.AddHybridCache%2A>:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_noconfig" highlight="7":::

The preceding code registers the `HybridCache` service with default options. The registration API can also configure [options](#options) and [serialization](#serialization).

## Get and store cache entries

The `HybridCache` service provides a <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache.GetOrCreateAsync%2A> method with two overloads, taking a key and:

* A factory method.
* State, and a factory method.

The method uses the key to try to retrieve the object from the primary cache. If the item isn't found in the primary cache (a cache miss), it then checks the secondary cache if one is configured. If it doesn't find the data there (another cache miss), it calls the factory method to get the object from the data source. It then stores the object in both primary and secondary caches. The factory method is never called if the object is found in the primary or secondary cache (a cache hit).

The `HybridCache` service ensures that only one concurrent caller for a given key calls the factory method, and all other callers wait for the result of that call. The `CancellationToken` passed to `GetOrCreateAsync` represents the combined cancellation of all concurrent callers.

### The main `GetOrCreateAsync` overload

The stateless overload of `GetOrCreateAsync` is recommended for most scenarios. The code to call it is relatively simple. Here's an example:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreate" highlight="5-12":::

## Cache key guidance

The `key` passed to `GetOrCreateAsync` must uniquely identify the data being cached:

* In terms of the identifier values used to retrieve that data from its source.
* In terms of other data cached in the application.

Both types of uniqueness are usually ensured by using string concatenation to make a single key string composed of different parts concatenated into one string. For example:

```csharp
cache.GetOrCreateAsync($"/orders/{region}/{orderId}", ...);
```

Or

```csharp
cache.GetOrCreateAsync($"user_prefs_{userId}", ...);
```

It's the caller's responsibility to ensure that a key scheme is valid and can't cause data to become confused.

Avoid using external user input directly in cache keys. For example, don't use raw strings from user interfaces as cache keys. Doing so can expose your app to security risks, such as unauthorized access or denial-of-service attacks caused by flooding the cache with random or meaningless keys. In the preceding valid examples, the *order* and *user preference* data are clearly separated and use trusted identifiers:

* `orderid` and `userId` are internally generated identifiers.
* `region` might be an enum or string from a predefined list of known regions.

No significance is placed on tokens such as `/` or `_`. The entire key value is treated as an opaque identifying string. In this case, you could omit the `/` and `_` with no
change to the way the cache functions, but a delimiter is usually used to avoid ambiguity - for example `$"order{customerId}{orderId}"` could cause confusion between:

* `customerId` 42 with `orderId` 123
* `customerId` 421 with `orderId` 23

Both of the preceding examples would generate the cache key `order42123`.

This guidance applies equally to any `string`-based cache API, such as `HybridCache`, `IDistributedCache`, and `IMemoryCache`.

Notice that the inline interpolated string syntax (`$"..."` in the preceding examples of valid keys) is directly inside the `GetOrCreateAsync` call. This syntax is recommended when using `HybridCache`, as it allows for planned future improvements that bypass the need to allocate a `string` for the key in many scenarios.

### Additional key considerations

* Keys can be restricted to valid maximum lengths. For example, the default `HybridCache` implementation (via `AddHybridCache(...)`) restricts keys to 1024 characters by default. That number is configurable via `HybridCacheOptions.MaximumKeyLength`, with longer keys bypassing the cache mechanisms to prevent saturation.
* Keys must be valid Unicode sequences. If invalid Unicode sequences are passed, the behavior is undefined.
* When using an out-of-process secondary cache such as `IDistributedCache`, the backend implementation may impose additional restrictions. As a hypothetical example, a particular backend might use case-insensitive key logic. The default `HybridCache` (via `AddHybridCache(...)`) detects this scenario to prevent confusion attacks or alias attacks (using bitwise string equality). However, this scenario might still result in conflicting keys becoming overwritten or evicted sooner than expected.

### The alternative `GetOrCreateAsync` overload

The alternative overload might reduce some overhead from [captured variables](/dotnet/csharp/language-reference/operators/lambda-expressions#capture-of-outer-variables-and-variable-scope-in-lambda-expressions) and per-instance callbacks, but at the expense of more complex code. For most scenarios, the performance increase doesn't outweigh the code complexity. Here's an example that uses the alternative overload:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreatestate" highlight="5-14":::

### The `SetAsync` method

In many scenarios, `GetOrCreateAsync` is the only API needed. But `HybridCache` also has <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache.SetAsync%2A> to store an object in cache without trying to retrieve it first.
<!--
Add GetAsync when it's implemented.
-->

## Remove cache entries by key

When the underlying data for a cache entry changes before it expires, remove the entry explicitly by calling <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache.RemoveAsync%2A> with the key to the entry. An overload lets you specify a collection of key values.

When an entry is removed, it is removed from both the primary and secondary caches.

## Remove cache entries by tag

Tags can be used to group cache entries and invalidate them together.

Set tags when calling `GetOrCreateAsync`, as shown in the following example:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreateoptions" highlight="7,17":::

Remove all entries for a specified tag by calling <xref:Microsoft.Extensions.Caching.Hybrid.HybridCache.RemoveByTagAsync%2A> with the tag value. An overload lets you specify a collection of tag values.

Neither `IMemoryCache` nor `IDistributedCache` has direct support for the concept of tags, so tag-based invalidation is a *logical* operation only. It doesn't actively remove values from either local or distributed cache. Instead, it ensures that when receiving data with such tags, the data is treated as a cache-miss from both the local and remote cache. The values expire from `IMemoryCache` and `IDistributedCache` in the usual way based on the configured lifetime.

## Removing all cache entries

The asterisk tag (`*`) is reserved as a wildcard and is disallowed against individual values. Calling `RemoveByTagAsync("*")` has the effect of invalidating *all* `HybridCache` data, even data that doesn't have any tags. As with individual tags, this is a *logical* operation, and individual values continue to exist until they expire naturally. Glob-style matches aren't supported. For example, you can't use `RemoveByTagAsync("foo*")` to remove everything starting with `foo`.

### Additional tag considerations

* The system doesn't limit the number of tags you can use, but large sets of tags might negatively impact performance.
* Tags can't be empty, just whitespace, or the reserved value `*`.

## Options

The `AddHybridCache` method can be used to configure global defaults. The following example shows how to configure some of the available options:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_globaloptions" highlight = "6-15":::

The `GetOrCreateAsync` method can also take a `HybridCacheEntryOptions` object to override the global defaults for a specific cache entry. Here's an example:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal/Program.cs" id="snippet_getorcreateoptions" highlight = "8-12,16":::

For more information about the options, see the source code:

* <xref:Microsoft.Extensions.Caching.Hybrid.HybridCacheOptions> class.
* <xref:Microsoft.Extensions.Caching.Hybrid.HybridCacheEntryOptions> class.

## Limits

The following properties of `HybridCacheOptions` let you configure limits that apply to all cache entries:

* MaximumPayloadBytes - Maximum size of a cache entry. Default value is 1 MB. Attempts to store values over this size are logged, and the value isn't stored in cache.
* MaximumKeyLength - Maximum length of a cache key. Default value is 1024 characters. Attempts to store values over this size are logged, and the value isn't stored in cache.
 
## Serialization

Use of a secondary, out-of-process cache requires serialization. Serialization is configured as part of registering the `HybridCache` service. Type-specific and general-purpose serializers can be configured via the <xref:Microsoft.Extensions.DependencyInjection.HybridCacheBuilderExtensions.AddSerializer%2A> and <xref:Microsoft.Extensions.DependencyInjection.HybridCacheBuilderExtensions.AddSerializerFactory%2A> methods, chained from the `AddHybridCache` call. By default, the library
handles `string` and `byte[]` internally, and uses `System.Text.Json` for everything else. `HybridCache` can also use other serializers, such as protobuf or XML.

The following example configures the service to use a type-specific protobuf serializer:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal2/Program.cs" id="snippet_withserializer" highlight="14-15":::

The following example configures the service to use a general-purpose protobuf serializer that can handle many protobuf types:

:::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal2/Program.cs" id="snippet_withserializerfactory" highlight="14":::

The secondary cache requires a data store, such as Redis, SQL Server, or Postgres. To use [Azure Cache for Redis](https://azure.microsoft.com/products/cache), for example:

* Install the `Microsoft.Extensions.Caching.StackExchangeRedis` package.
* Create an instance of Azure Cache for Redis.
* Get a connection string that connects to the Redis instance. Find the connection string by selecting **Show access keys** on the **Overview** page in the Azure portal.
* Store the connection string in the app's configuration. For example, use a [user secrets file](xref:security/app-secrets) that looks like the following JSON, with the connection string in the `ConnectionStrings` section. Replace `<the connection string>` with the actual connection string:

  ```json
  {
    "ConnectionStrings": {
      "RedisConnectionString": "<the connection string>"
    }
  }
  ```

* Register in DI the `IDistributedCache` implementation that the Redis package provides. To do that, call `AddStackExchangeRedisCache`, and pass in the connection string. For example:

  :::code language="csharp" source="~/performance/caching/hybrid/samples/9.x/HCMinimal2/Program.cs" id="snippet_redis":::

* The Redis `IDistributedCache` implementation is now available from the app's DI container. `HybridCache` uses it as the secondary cache and uses the serializer configured for it.

For more information, see the [HybridCache serialization sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/hybrid/samples/9.x/HCMinimal2).

## Cache storage

By default `HybridCache` uses <xref:System.Runtime.Caching.MemoryCache> for its primary cache storage. Cache entries are stored in-process, so each server has a separate cache that is lost whenever the server process is restarted. For secondary out-of-process storage, such as Redis, SQL Server, or Postgres, `HybridCache` uses [the configured `IDistributedCache` implementation](xref:performance/caching/distributed), if any. But even without an `IDistributedCache`implementation, the `HybridCache` service still provides in-process caching and [stampede protection](https://en.wikipedia.org/wiki/Cache_stampede).

> [!NOTE]
> When invalidating cache entries by key or by tags, they're invalidated in the current server and in the secondary out-of-process storage. However, the in-memory cache in other servers isn't affected.

## Optimize performance

To optimize performance, configure `HybridCache` to reuse objects and avoid `byte[]` allocations.

### Reuse objects

By reusing instances, `HybridCache` can reduce the overhead of CPU and object allocations associated with per-call deserialization. This can lead to performance improvements in scenarios where the cached objects are large or accessed frequently.

In typical existing code that uses `IDistributedCache`, every retrieval of an object from the cache results in deserialization. This behavior means that each concurrent caller gets a separate instance of the object, which can't interact with other instances. The result is thread safety, as there's no risk of concurrent modifications to the same object instance.

Because much `HybridCache` usage will be adapted from existing `IDistributedCache` code, `HybridCache` preserves this behavior by default to avoid introducing concurrency bugs. However, objects are inherently thread-safe if:

* They're immutable types.
* The code doesn't modify them.

In such cases, inform `HybridCache` that it's safe to reuse instances by making both of the following changes:

* Marking the type as `sealed`. The `sealed` keyword in C# means that the class can't be inherited.
* Applying the `[ImmutableObject(true)]` attribute to the type. The `[ImmutableObject(true)]` attribute indicates that the object's state can't be changed after it's created.

### Avoid `byte[]` allocations

`HybridCache` also provides optional APIs for `IDistributedCache` implementations, to avoid `byte[]` allocations. This feature is implemented by the preview versions of the `Microsoft.Extensions.Caching.StackExchangeRedis`,  `Microsoft.Extensions.Caching.SqlServer`, and `Microsoft.Extensions.Caching.Postgres` packages. For more information, see <xref:Microsoft.Extensions.Caching.Distributed.IBufferDistributedCache>.
Here are the .NET CLI commands to install the packages:

```dotnetcli
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis
```

```dotnetcli
dotnet add package Microsoft.Extensions.Caching.SqlServer
```

```dotnetcli
dotnet add package Microsoft.Extensions.Caching.Postgres
```

## Custom HybridCache implementations

A concrete implementation of the `HybridCache` abstract class is included in the shared framework and is provided via dependency injection. But developers are welcome to provide or consume custom implementations of the API, for example [FusionCache](https://github.com/ZiggyCreatures/FusionCache/blob/main/docs/MicrosoftHybridCache.md).

## Use Hybrid Cache with Native AOT

 The following Native AOT-specific considerations apply to `HybridCache`:

* **Serialization**  

  Native AOT doesn't support runtime reflection-based serialization. If you cache custom types, you must use source generators or explicitly configure serializers that are compatible with AOT, like `System.Text.Json` source generation. `HybridCache` is still under development, and simplifying the way to use it with AOT is a high priority for that development. For more information, see pull request [dotnet/extensions#6475](https://github.com/dotnet/extensions/pull/6475)

* **Trimming**

  Make sure all types you cache are referenced in a way that prevents them from being trimmed by the AOT compiler. Using source generators for serialization helps with this requirement. For more information, see <xref:fundamentals/native-aot>.

If you set up serialization and trimming correctly, `HybridCache` behaves the same way in Native AOT as in regular ASP.NET Core apps.

## Compatibility

The `HybridCache` library supports older .NET runtimes, down to .NET Framework 4.7.2 and .NET Standard 2.0.

## Additional resources

For more information, see [the `HybridCache` source code](https://source.dot.net/#Microsoft.Extensions.Caching.Abstractions/Hybrid/HybridCache.cs)
