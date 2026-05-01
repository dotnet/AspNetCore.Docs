---
title: Output caching middleware in ASP.NET Core
author: tdykstra
description: Learn how to configure and use output caching middleware in ASP.NET Core.
monikerRange: '>= aspnetcore-7.0'
ms.author: tdykstra
ms.custom: mvc
ms.date: 05/01/2026
uid: performance/caching/output

# customer intent: As an ASP.NET developer, I want to configure output caching middleware in ASP.NET Core, so I can use output caching in my apps.
---
# Output caching middleware in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra)

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

This article explains how to configure output caching middleware in an ASP.NET Core app. For an introduction to output caching, see [Output caching](xref:performance/caching/overview#output-caching).

The output caching middleware can be used in all types of ASP.NET Core apps: [Minimal APIs](xref:fundamentals/minimal-apis), [Web API with controllers](xref:web-api/index), [MVC](xref:mvc/overview), and [Razor Pages](xref:razor-pages/index). Code examples are provided for Minimal APIs and controller-based APIs. The controller-based API examples show how to use attributes to configure caching. These attributes can also be used in MVC and Razor Pages apps.

The code examples refer to a [Gravatar class](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/performance/caching/output/samples/7.x/Gravatar.cs) that generates an image and provides a "generated at" date and time. The class is defined and used only in [the sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/output/samples/7.x). Its purpose is to make it easy to see when cached output is being used. For more information, see [How to download a sample](xref:fundamentals/index#how-to-download-a-sample) and [Preprocessor directives](/dotnet/csharp/fundamentals/program-structure/preprocessor-directives).

## Add the middleware to the app

Add the output caching middleware to the service collection by calling the <xref:Microsoft.Extensions.DependencyInjection.OutputCacheServiceCollectionExtensions.AddOutputCache%2A> method.

Add the middleware to the request processing pipeline by calling the <xref:Microsoft.AspNetCore.Builder.OutputCacheApplicationBuilderExtensions.UseOutputCache%2A> method.

For example:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies4" highlight="1":::
:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="snippet_use" highlight="5":::

Calling the `AddOutputCache`and `UseOutputCache` methods doesn't start caching behavior, it makes caching available. To make the app cache responses, caching must be configured as described in the following sections.

> [!NOTE]
> * In apps that use [Cross-Origin Requests (CORS) middleware](xref:security/cors), the `UseOutputCache` method must be called after the <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> method.
> * In Razor Pages apps and apps with controllers, the `UseOutputCache` method must be called after the `UseRouting` method.

## Configure one endpoint or page

For Minimal API apps, configure an endpoint to do caching by calling the [CacheOutput](xref:Microsoft.Extensions.DependencyInjection.OutputCacheConventionBuilderExtensions.CacheOutput%2A) method, or by applying the [[OutputCache](xref:Microsoft.AspNetCore.OutputCaching.OutputCacheAttribute)] attribute, as shown in the following examples:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="oneendpoint":::

For apps with controllers, apply the `[OutputCache]` attribute to the action method as shown in the following code:

:::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Controllers/CachedController.cs" id="snippet_oneendpoint":::

For Razor Pages apps, apply the attribute to the Razor page class.

## Configure multiple endpoints or pages

Create *policies* when calling the `AddOutputCache` method to specify caching configuration that applies to multiple endpoints. A policy can be selected for specific endpoints, while a base policy provides default caching configuration for a collection of endpoints.

The following highlighted code configures caching for all of the app's endpoints, with an expiration time of 10 seconds. If an expiration time isn't specified, it defaults to one minute.

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies1" highlight="3-4":::

The following highlighted code creates two policies, each specifying a different expiration time. Selected endpoints can use the 20-second expiration, and others can use the 30-second expiration.

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies1" highlight="5-8":::

You can select a policy for an endpoint when calling the `CacheOutput` method or by using the `[OutputCache]` attribute.

In a Minimal API app, the following code configures one endpoint with a 20-second expiration and one with a 30-second expiration:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="selectpolicy":::

For apps with controllers, apply the `[OutputCache]` attribute to the action method to select a policy:

:::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Controllers/Expire20Controller.cs" id="snippet_selectpolicy":::

For Razor Pages apps, apply the attribute to the Razor page class.

## Work with the default output caching policy

By default, output caching follows these rules:

* Only HTTP 200 responses are cached.
* Only HTTP GET or HEAD requests are cached.
* Responses that set cookies aren't cached.
* Responses to authenticated requests aren't cached.

The following code applies all of the default caching rules to all of an app's endpoints:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies3":::

### Override the default policy

The following code shows how to override the default policy rules. The highlighted lines in the following custom policy code enable caching for HTTP POST methods and HTTP 301 responses:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/MyCustomPolicy.cs" highlight="50,68":::

To use this custom policy, create a named policy:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies3b":::

And, select the named policy for an endpoint. The following code selects the custom policy for an endpoint in a Minimal API app:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="post":::

The following code does the same for a controller action:

:::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Controllers/PostController.cs" id="snippet_post":::

### Use an alternative default policy override 

Alternatively, use Dependency Injection (DI) to initialize an instance with the following changes to the custom policy class:

* Use a public constructor instead of a private constructor.
* Eliminate the `Instance` property in the custom policy class.

For example:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/MyCustomPolicy2.cs" id="fordi":::

The remainder of the class is the same as shown previously. Add the custom policy as shown in the following example:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies3c":::

The preceding code uses DI to create the instance of the custom policy class. Any public arguments in the constructor are resolved.

When using a custom policy as a base policy, don't call the `OutputCache()` method (with no arguments) or use the `[OutputCache]` attribute on any endpoint that the base policy should apply to. Calling the `OutputCache()` method or using the attribute adds the default policy to the endpoint.

## Specify the cache key

By default, every part of the URL is included as the key to a cache entry, that is, the scheme, host, port, path, and query string. However, you might want to explicitly control the cache key. For example, suppose you have an endpoint that returns a unique response only for each unique value of the `culture` query string. Variation in other parts of the URL, such as other query strings, shouldn't result in different cache entries. You can specify such rules in a policy, as shown in the following highlighted code:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies2" highlight="7":::

You can then select the `VaryByQuery` policy for an endpoint. In a Minimal API app, the following code selects the `VaryByQuery` policy for an endpoint that returns a unique response only for each unique value of the `culture` query string:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="selectquery":::

The following code does the same for a controller action:

:::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Controllers/QueryController.cs" id="snippet_selectquery":::

Here are some of the options for controlling the cache key:

* The <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetVaryByQuery%2A> method specifies one or more query string names to add to the cache key.
* The <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetVaryByHeader%2A> method specifies one or more HTTP headers to add to the cache key.
* The <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByValue%2A> method provides a value to add to the cache key. The following example uses a value that indicates whether the current server time in seconds is odd or even. A new response is generated only when the number of seconds changes from an odd to even value, or vice versa.

  :::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Program.cs" id="policies2" highlight="10-14":::

Use the <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions.UseCaseSensitivePaths?displayProperty=nameWithType> property to specify that the path part of the key is case sensitive. The default is case insensitive.

For more options, see the <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder> class.

## Enable cache revalidation

Cache revalidation means the server can return a _304 Not Modified_ HTTP status code instead of the full response body. This status code informs the client that the response to the request is unchanged from what the client previously received.

The following code illustrates the use of an [ETag](https://developer.mozilla.org/docs/Web/HTTP/Headers/ETag) header to enable cache revalidation. If the client sends an [If-None-Match](https://developer.mozilla.org/docs/Web/HTTP/Headers/If-None-Match) header with the value for the `ETag` from an earlier response, and the cache entry is fresh, the server returns the [304 Not Modified](https://developer.mozilla.org/docs/Web/HTTP/Status/304) code instead of the full response.

The following code sets the `ETag` value in a policy in a Minimal API app:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="etag":::

The following code does the same for a controller-based API:

:::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Controllers/EtagController.cs" id="snippet_etag":::

Another way to do cache revalidation is to check the date of the cache entry creation compared to the date requested by the client. When the request header `If-Modified-Since` is provided, output caching returns the 304 code if the cached entry is older and isn't expired.

Cache revalidation is automatic in response to these headers sent from the client. No special configuration is required on the server to enable this behavior, aside from enabling output caching.

## Use tags to evict cache entries

You can use tags to identify a group of endpoints and evict all cache entries for the group. For example, the following Minimal API code creates a pair of endpoints whose URLs begin with the text `blog` and applies the `tag-blog` tag:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="tagendpoint":::

The following code shows how to assign tags to an endpoint in a controller-based API:

:::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Controllers/TagEndpointController.cs" id="snippet_tagendpoint":::

An alternative way to assign tags for endpoints with routes that begin with `blog` is to define a base policy that applies to all endpoints with that route. The following code demonstrates this approach:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies2" highlight="3-5":::

Another alternative for Minimal API apps is to call the [MapGroup(/dotnet/api/microsoft.aspnetcore.builder.endpointroutebuilderextensions.mapgroup) method:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="taggroup":::

In the preceding tag assignment examples, both endpoints are identified by the `tag-blog` tag. You can then evict the cache entries for those endpoints with a single statement that references that tag:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="evictbytag":::

With this code, an HTTP POST request sent to the `https://localhost:<port>/purge/tag-blog` URL evicts cache entries for these endpoints.

You might want a way to evict all cache entries for all endpoints. You can create a base policy for all endpoints as demonstrated in the following code:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies2" highlight="6":::

This base policy enables you to use the `tag-all` tag to evict everything in cache.

## Disable resource locking

By default, resource locking is enabled to mitigate the risk of [cache stampede and thundering herd](https://wikipedia.org/wiki/Thundering_herd_problem). For more information, see [Output Caching](xref:performance/caching/overview#output-caching).

To disable resource locking, call the [SetLocking(false)](xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetLocking%2A) method while creating a policy, as shown in the following example:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="policies2" highlight="9":::

The next example selects the no-locking policy for an endpoint in a Minimal API app:

:::code language="csharp" source="~/performance/caching/output/samples/7.x/Program.cs" id="selectnolock":::

In a controller-based API, use the attribute to select the policy:

:::code language="csharp" source="~/performance/caching/output/samples/9.x/OCControllers/Controllers/NoLockController.cs" id="snippet_selectnolock":::

## Configure limits

The following properties of the <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions> class let you configure limits that apply to all endpoints:

* The <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions.SizeLimit> property sets the maximum size for the cache storage. When the limit is reached, no new responses are cached until older entries are evicted. The default value is 100 MB.
* The <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions.MaximumBodySize> property sets the maximum size for the response body. If the response body exceeds the limit, it isn't cached. The default value is 64 MB.
* The <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions.DefaultExpirationTimeSpan> property sets the maximum duration a response is cached, when a time isn't specified in a policy. The default value is 60 seconds.

## Explore cache storage options

The <xref:Microsoft.AspNetCore.OutputCaching.IOutputCacheStore> interface is used for storage. By default, it's used with the <xref:System.Runtime.Caching.MemoryCache> class. Cached responses are stored in-process, so each server has a separate cache that is lost whenever the server process restarts.

### Alternative: Redis cache

An alternative is to use [Redis](https://redis.io/) cache. Redis cache provides consistency between server nodes via a shared cache that outlives individual server processes. To use Redis for output caching:

* Install the [Microsoft.AspNetCore.OutputCaching.StackExchangeRedis](https://www.nuget.org/packages/Microsoft.AspNetCore.OutputCaching.StackExchangeRedis) NuGet package.

* Call the `builder.Services.AddStackExchangeRedisOutputCache` method (not the `AddStackExchangeRedisCache` method), and provide a connection string that points to a Redis server.

  For example:

  :::code language="csharp" source="~/performance/caching/output/samples/8.x/Program.cs" id="redis" highlight="1-6":::

  * The [options.Configuration](xref:Microsoft.Extensions.Caching.StackExchangeRedis.RedisCacheOptions.Configuration) property is a connection string to an on-premises Redis server or to a hosted offering such as [Azure Cache for Redis](/azure/azure-cache-for-redis/). For example, `<instance_name>.redis.cache.windows.net:6380,password=,pw,ssl=True,abortConnect=False` for Azure Cache for Redis.

  * (Optional) The [options.InstanceName](xref:Microsoft.Extensions.Caching.StackExchangeRedis.RedisCacheOptions.InstanceName) property specifies a logical partition for the cache.
 
  The configuration options are identical to the [Redis-based distributed caching options](xref:performance/caching/distributed#distributed-redis-cache).

### Not recommended: IDistributedCache

The <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> interface isn't recommended for use with output caching. This interface doesn't provide atomic features, which are required for tagging.

The recommended approach is to use the built-in support for Redis or create a custom <xref:Microsoft.AspNetCore.OutputCaching.IOutputCacheStore> implementation by using direct dependencies on the underlying storage mechanism.

## Related content

* [Overview of caching in ASP.NET Core](xref:performance/caching/overview)
* [ASP.NET Core Middleware](xref:fundamentals/middleware/index)
* <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions>
* <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder>

:::moniker-end

[!INCLUDE[](~/performance/caching/output/includes/output7.md)]
