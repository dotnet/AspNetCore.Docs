---
title: Response caching in ASP.NET Core
author: tdykstra
description: Learn how to use response caching to lower bandwidth requirements and increase performance of ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.date: 1/11/2022
uid: performance/caching/response
---
# Response caching in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Kirk Larkin](https://twitter.com/serpent5)

:::moniker range=">= aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/response/samples) ([how to download](xref:index#how-to-download-a-sample))

Response caching reduces the number of requests a client or proxy makes to a web server. Response caching also reduces the amount of work the web server performs to generate a response. Response caching is set in headers.

The [ResponseCache attribute](#responsecache-attribute) sets response caching headers. Clients and intermediate proxies should honor the headers for caching responses under [RFC 9111: HTTP Caching](https://www.rfc-editor.org/rfc/rfc9111).

For server-side caching that follows the HTTP 1.1 Caching specification, use [Response Caching Middleware](xref:performance/caching/middleware). The middleware can use the <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> properties to influence server-side caching behavior.

[!INCLUDE[](~/includes/response-caching-mid.md)]
<!--Postman:  GET: Headers > Postman > go to settings > uncheck Send no-cache header -->

## HTTP-based response caching

[RFC 9111: HTTP Caching](https://www.rfc-editor.org/rfc/rfc9111) describes how Internet caches should behave. The primary HTTP header used for caching is [Cache-Control](https://www.rfc-editor.org/rfc/rfc9111#field.cache-control), which is used to specify cache directives. The directives control caching behavior as requests make their way from clients to servers and as responses make their way from servers back to clients. Requests and responses move through proxy servers, and proxy servers must also conform to the HTTP 1.1 Caching specification.

Common `Cache-Control` directives are shown in the following table.

| Directive                                                                            | Action |
| ------------------------------------------------------------------------------------ | ------ |
| [public](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.public)     | A cache may store the response. |
| [private](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.private)   | The response must not be stored by a shared cache. A private cache may store and reuse the response. |
| [max-age](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.max-age)   | The client doesn't accept a response whose age is greater than the specified number of seconds. Examples: `max-age=60` (60 seconds), `max-age=2592000` (1 month) |
| [no-cache](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.no-cache) | **On requests**: A cache must not use a stored response to satisfy the request. The origin server regenerates the response for the client, and the middleware updates the stored response in its cache.<br><br>**On responses**: The response must not be used for a subsequent request without validation on the origin server. |
| [no-store](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.no-store) | **On requests**: A cache must not store the request.<br><br>**On responses**: A cache must not store any part of the response. |

Other cache headers that play a role in caching are shown in the following table.

| Header                                                          | Function |
| --------------------------------------------------------------- | -------- |
| [Age](https://www.rfc-editor.org/rfc/rfc9111#field.age)         | An estimate of the amount of time in seconds since the response was generated or successfully validated at the origin server. |
| [Expires](https://www.rfc-editor.org/rfc/rfc9111#field.expires) | The time after which the response is considered stale. |
| [Pragma](https://www.rfc-editor.org/rfc/rfc9111#field.pragma)   | Exists for backwards compatibility with HTTP/1.0 caches for setting `no-cache` behavior. If the `Cache-Control` header is present, the `Pragma` header is ignored. |
| [Vary](https://www.rfc-editor.org/rfc/rfc9110#field.vary)       | Specifies that a cached response must not be sent unless all of the `Vary` header fields match in both the cached response's original request and the new request. |

## HTTP-based caching respects request Cache-Control directives

[RFC 9111: HTTP Caching (Section 5.2. Cache-Control)](https://www.rfc-editor.org/rfc/rfc9111#field.cache-control) requires a cache to honor a valid `Cache-Control` header sent by the client. A client can make requests with a `no-cache` header value and force the server to generate a new response for every request.

Always honoring client `Cache-Control` request headers makes sense if you consider the goal of HTTP caching. Under the official specification, caching is meant to reduce the latency and network overhead of satisfying requests across a network of clients, proxies, and servers. It isn't necessarily a way to control the load on an origin server.

There's no developer control over this caching behavior when using the [Response Caching Middleware](xref:performance/caching/middleware) because the middleware adheres to the official caching specification. Support for *output caching* to better control server load was added in .NET 7. For more information, see [Output caching](xref:performance/caching/overview#output-caching).

## ResponseCache attribute

The <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> specifies the parameters necessary for setting appropriate headers in response caching.

> [!WARNING]
> Disable caching for content that contains information for authenticated clients. Caching should only be enabled for content that doesn't change based on a user's identity or whether a user is signed in.

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> varies the stored response by the values of the given list of query keys. When a single value of `*` is provided, the middleware varies responses by all request query string parameters.

[Response Caching Middleware](xref:performance/caching/middleware) must be enabled to set the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> property. Otherwise, a runtime exception is thrown. There isn't a corresponding HTTP header for the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> property. The property is an HTTP feature handled by Response Caching Middleware. For the middleware to serve a cached response, the query string and query string value must match a previous request. For example, consider the sequence of requests and results shown in the following table:

| Request                          | Returned from                    |
| -------------------------------- | ------------------------- |
| `http://example.com?key1=value1` | Server |
| `http://example.com?key1=value1` | Middleware |
| `http://example.com?key1=NewValue` | Server |

The first request is returned by the server and cached in middleware. The second request is returned by middleware because the query string matches the previous request. The third request isn't in the middleware cache because the query string value doesn't match a previous request.

The <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> is used to configure and create (via <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory>) a `Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter`. The `ResponseCacheFilter` performs the work of updating the appropriate HTTP headers and features of the response. The filter:

* Removes any existing headers for `Vary`, `Cache-Control`, and `Pragma`.
* Writes out the appropriate headers based on the properties set in the <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute>.
* Updates the response caching HTTP feature if <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> is set.

### Vary

This header is only written when the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByHeader> property is set. The property set to the `Vary` property's value. The following sample uses the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByHeader> property:

[!code-csharp[](response/samples/6.x/WebRC/Controllers/TimeController.cs?name=snippet)]

View the response headers with Fiddler or another tool. The response headers include:

```text
Cache-Control: public,max-age=30
Vary: User-Agent
```

The preceding code requires adding the Response Caching Middleware services <xref:Microsoft.Extensions.DependencyInjection.ResponseCachingServicesExtensions.AddResponseCaching%2A> to the service collection and configures the app to use the middleware with the <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A> extension method. 

[!code-csharp[](response/samples/6.x/WebRC/Program.cs?name=snippet&highlight=4,13)]

### `NoStore` and `Location.None`

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.NoStore> overrides most of the other properties. When this property is set to `true`, the `Cache-Control` header is set to `no-store`. If <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> is set to `None`:

* `Cache-Control` is set to `no-store,no-cache`.
* `Pragma` is set to `no-cache`.

If <xref:Microsoft.AspNetCore.Mvc.CacheProfile.NoStore> is `false` and <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> is `None`, `Cache-Control`, and `Pragma` are set to `no-cache`.

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.NoStore> is typically set to `true` for error pages. The following produces response headers that instruct the client not to store the response.

[!code-csharp[](response/samples/6.x/WebRC/Controllers/TimeController.cs?name=snippet2)]

The preceding code includes the following headers in the response:

```
Cache-Control: no-store,no-cache
Pragma: no-cache
```

To apply the <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> to all of the app's MVC controller or Razor Pages page responses, add it with an [MVC filter](xref:mvc/controllers/filters) or [Razor Pages filter](xref:razor-pages/filter).

In an MVC app:

```csharp
builder.Services.AddControllersWithViews().AddMvcOptions(options => 
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true, 
            Location = ResponseCacheLocation.None
        }));
```

For an approach that applies to Razor Pages apps, see [Adding `ResponseCacheAttribute` to MVC global filter list does not apply to Razor Pages (dotnet/aspnetcore #18890)](https://github.com/dotnet/aspnetcore/issues/18890#issuecomment-584290537). The example provided in the issue comment was written for apps targeting ASP.NET Core prior to the release of [Minimal APIs](xref:fundamentals/minimal-apis) at 6.0. For 6.0 or later apps, change the service registration in the example to `builder.Services.AddSingleton...` for `Program.cs`.

### Location and Duration

To enable caching, <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Duration> must be set to a positive value and <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> must be either `Any` (the default) or `Client`. The framework sets the `Cache-Control` header to the location value followed by the `max-age` of the response.

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location>'s options of `Any` and `Client` translate into `Cache-Control` header values of `public` and `private`, respectively. As noted in the [NoStore and Location.None](#nostore-and-locationnone) section, setting <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> to `None` sets both `Cache-Control` and `Pragma` headers to `no-cache`.

`Location.Any` (`Cache-Control` set to `public`) indicates that the *client or any intermediate proxy* may cache the value, including [Response Caching Middleware](xref:performance/caching/middleware).

`Location.Client` (`Cache-Control` set to `private`) indicates that *only the client* may cache the value. No intermediate cache should cache the value, including [Response Caching Middleware](xref:performance/caching/middleware).

Cache control headers provide guidance to clients and intermediary proxies when and how to cache responses. There's no guarantee that clients and proxies will honor [RFC 9111: HTTP Caching](https://www.rfc-editor.org/rfc/rfc9111). [Response Caching Middleware](xref:performance/caching/middleware) always follows the caching rules laid out by the specification.

The following example shows the headers produced by setting <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Duration> and leaving the default <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> value:

[!code-csharp[](response/samples/6.x/WebRC/Controllers/TimeController.cs?name=snippet3)]

The preceding code includes the following headers in the response:

```
Cache-Control: public,max-age=10
```

### Cache profiles

Instead of duplicating response cache settings on many controller action attributes, cache profiles can be configured as options when setting up MVC/Razor Pages. Values found in a referenced cache profile are used as the defaults by the <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> and are overridden by any properties specified on the attribute.

The following example shows a 30 second cache profile:

[!code-csharp[](response/samples/6.x/WebRC/Program.cs?name=snippet2&highlight=5-13,22)]

The following code references the `Default30` cache profile:

[!code-csharp[](response/samples/6.x/WebRC/Controllers/Time2Controller.cs?name=snippet&highlight=2)]

The resulting header response by the `Default30` cache profile includes:

```
Cache-Control: public,max-age=30
```

The  [`[ResponseCache]`](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) attribute can be applied to:

* Razor Pages: Attributes can't be applied to handler methods. Browsers used with UI apps prevent response caching.
* MVC controllers.
* MVC action methods: Method-level attributes override the settings specified in class-level attributes.

The following code applies the `[ResponseCache]` attribute at the controller level and method level:

[!code-csharp[](response/samples/6.x/WebRC/Controllers/TimeController.cs?name=snippet4&highlight=2,17)]

## Additional resources

* [Storing Responses in Caches](https://www.rfc-editor.org/rfc/rfc9111.html#name-storing-responses-in-caches)
* [Cache-Control](https://www.rfc-editor.org/rfc/rfc9111.html#field.cache-control)
* <xref:performance/caching/memory>
* <xref:performance/caching/distributed>
* <xref:fundamentals/change-tokens>
* <xref:performance/caching/middleware>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>
:::moniker-end

:::moniker range="< aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/response/samples) ([how to download](xref:index#how-to-download-a-sample))

Response caching reduces the number of requests a client or proxy makes to a web server. Response caching also reduces the amount of work the web server performs to generate a response. Response caching is controlled by headers that specify how you want client, proxy, and middleware to cache responses.

The [`[ResponseCache]`](#responsecache-attribute) participates in setting response caching headers. Clients and intermediate proxies should honor the headers for caching responses under [RFC 9111: HTTP Caching](https://www.rfc-editor.org/rfc/rfc9111).

For server-side caching that follows the HTTP 1.1 Caching specification, use [Response Caching Middleware](xref:performance/caching/middleware). The middleware can use the [`[ResponseCache]`](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) properties to set server-side caching headers.

## HTTP-based response caching

[RFC 9111: HTTP Caching](https://www.rfc-editor.org/rfc/rfc9111) describes how Internet caches should behave. The primary HTTP header used for caching is [Cache-Control](https://www.rfc-editor.org/rfc/rfc9111#field.cache-control), which is used to specify cache *directives*. The directives control caching behavior as requests make their way from clients to servers and as responses make their way from servers back to clients. Requests and responses move through proxy servers, and proxy servers must also conform to the HTTP 1.1 Caching specification.

Common `Cache-Control` directives are shown in the following table.

| Directive                                                                            | Action |
| ------------------------------------------------------------------------------------ | ------ |
| [public](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.public)     | A cache may store the response. |
| [private](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.private)   | The response must not be stored by a shared cache. A private cache may store and reuse the response. |
| [max-age](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.max-age)   | The client doesn't accept a response whose age is greater than the specified number of seconds. Examples: `max-age=60` (60 seconds), `max-age=2592000` (1 month) |
| [no-cache](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.no-cache) | **On requests**: A cache must not use a stored response to satisfy the request. The origin server regenerates the response for the client, and the middleware updates the stored response in its cache.<br><br>**On responses**: The response must not be used for a subsequent request without validation on the origin server. |
| [no-store](https://www.rfc-editor.org/rfc/rfc9111#cache-response-directive.no-store) | **On requests**: A cache must not store the request.<br><br>**On responses**: A cache must not store any part of the response. |

Other cache headers that play a role in caching are shown in the following table.

| Header                                                          | Function |
| --------------------------------------------------------------- | -------- |
| [Age](https://www.rfc-editor.org/rfc/rfc9111#field.age)         | An estimate of the amount of time in seconds since the response was generated or successfully validated at the origin server. |
| [Expires](https://www.rfc-editor.org/rfc/rfc9111#field.expires) | The time after which the response is considered stale. |
| [Pragma](https://www.rfc-editor.org/rfc/rfc9111#field.pragma)   | Exists for backwards compatibility with HTTP/1.0 caches for setting `no-cache` behavior. If the `Cache-Control` header is present, the `Pragma` header is ignored. |
| [Vary](https://www.rfc-editor.org/rfc/rfc9110#field.vary)       | Specifies that a cached response must not be sent unless all of the `Vary` header fields match in both the cached response's original request and the new request. |

## HTTP-based caching respects request Cache-Control directives

[RFC 9111: HTTP Caching (Section 5.2. Cache-Control)](https://www.rfc-editor.org/rfc/rfc9111#field.cache-control) requires a cache to honor a valid `Cache-Control` header sent by the client. A client can make requests with a `no-cache` header value and force the server to generate a new response for every request.

Always honoring client `Cache-Control` request headers makes sense if you consider the goal of HTTP caching. Under the official specification, caching is meant to reduce the latency and network overhead of satisfying requests across a network of clients, proxies, and servers. It isn't necessarily a way to control the load on an origin server.

There's no developer control over this caching behavior when using the [Response Caching Middleware](xref:performance/caching/middleware) because the middleware adheres to the official caching specification. Support for *output caching* to better control server load is a design proposal for a future release of ASP.NET Core. For more information, see [Add support for Output Caching (dotnet/aspnetcore #27387)](https://github.com/dotnet/aspnetcore/issues/27387).

## Other caching technology in ASP.NET Core

### In-memory caching

In-memory caching uses server memory to store cached data. This type of caching is suitable for a single server or multiple servers using session affinity. Session affinity is also known as *sticky sessions*. Session affinity means that the requests from a client are always routed to the same server for processing.

For more information, see <xref:performance/caching/memory> and [Troubleshoot Azure Application Gateway session affinity issues](/azure/application-gateway/how-to-troubleshoot-application-gateway-session-affinity-issues).

### Distributed Cache

Use a distributed cache to store data in memory when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client can submit a request that's handled by any server in the group if cached data for the client is available. ASP.NET Core works with SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), and [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) distributed caches.

For more information, see <xref:performance/caching/distributed>.

### Cache Tag Helper

Cache the content from an MVC view or Razor Page with the Cache Tag Helper. The Cache Tag Helper uses in-memory caching to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>.

### Distributed Cache Tag Helper

Cache the content from an MVC view or Razor Page in distributed cloud or web farm scenarios with the Distributed Cache Tag Helper. The Distributed Cache Tag Helper uses SQL Server, [Redis](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis), or [NCache](https://www.nuget.org/packages/Alachisoft.NCache.OpenSource.SDK/) to store data.

For more information, see <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>.

## ResponseCache attribute

The <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> specifies the parameters necessary for setting appropriate headers in response caching.

> [!WARNING]
> Disable caching for content that contains information for authenticated clients. Caching should only be enabled for content that doesn't change based on a user's identity or whether a user is signed in.

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> varies the stored response by the values of the given list of query keys. When a single value of `*` is provided, the middleware varies responses by all request query string parameters.

[Response Caching Middleware](xref:performance/caching/middleware) must be enabled to set the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> property. Otherwise, a runtime exception is thrown. There isn't a corresponding HTTP header for the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> property. The property is an HTTP feature handled by Response Caching Middleware. For the middleware to serve a cached response, the query string and query string value must match a previous request. For example, consider the sequence of requests and results shown in the following table.

| Request                          | Result                    |
| -------------------------------- | ------------------------- |
| `http://example.com?key1=value1` | Returned from the server. |
| `http://example.com?key1=value1` | Returned from middleware. |
| `http://example.com?key1=value2` | Returned from the server. |

The first request is returned by the server and cached in middleware. The second request is returned by middleware because the query string matches the previous request. The third request isn't in the middleware cache because the query string value doesn't match a previous request.

The <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> is used to configure and create (via <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory>) a `Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter`. The `ResponseCacheFilter` performs the work of updating the appropriate HTTP headers and features of the response. The filter:

* Removes any existing headers for `Vary`, `Cache-Control`, and `Pragma`.
* Writes out the appropriate headers based on the properties set in the <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute>.
* Updates the response caching HTTP feature if <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByQueryKeys> is set.

### Vary

This header is only written when the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByHeader> property is set. The property set to the `Vary` property's value. The following sample uses the <xref:Microsoft.AspNetCore.Mvc.CacheProfile.VaryByHeader> property:

[!code-csharp[](response/samples/2.x/ResponseCacheSample/Pages/Cache1.cshtml.cs?name=snippet)]

Using the sample app, view the response headers with the browser's network tools. The following response headers are sent with the Cache1 page response:

```
Cache-Control: public,max-age=30
Vary: User-Agent
```

### `NoStore` and `Location.None`

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.NoStore> overrides most of the other properties. When this property is set to `true`, the `Cache-Control` header is set to `no-store`. If <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> is set to `None`:

* `Cache-Control` is set to `no-store,no-cache`.
* `Pragma` is set to `no-cache`.

If <xref:Microsoft.AspNetCore.Mvc.CacheProfile.NoStore> is `false` and <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> is `None`, `Cache-Control`, and `Pragma` are set to `no-cache`.

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.NoStore> is typically set to `true` for error pages. The Cache2 page in the sample app produces response headers that instruct the client not to store the response.

[!code-csharp[](response/samples/2.x/ResponseCacheSample/Pages/Cache2.cshtml.cs?name=snippet)]

The sample app returns the Cache2 page with the following headers:

```
Cache-Control: no-store,no-cache
Pragma: no-cache
```

To apply the <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> to all of the app's MVC controller or Razor Pages page responses, add it with an [MVC filter](xref:mvc/controllers/filters) or [Razor Pages filter](xref:razor-pages/filter).

In an MVC app:

```csharp
services.AddMvc().AddMvcOptions(options => 
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true, 
            Location = ResponseCacheLocation.None
        }));
```

For an approach that applies to Razor Pages apps, see [Adding `ResponseCacheAttribute` to MVC global filter list does not apply to Razor Pages (dotnet/aspnetcore #18890)](https://github.com/dotnet/aspnetcore/issues/18890#issuecomment-584290537).

### Location and Duration

To enable caching, <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Duration> must be set to a positive value and <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> must be either `Any` (the default) or `Client`. The framework sets the `Cache-Control` header to the location value followed by the `max-age` of the response.

<xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location>'s options of `Any` and `Client` translate into `Cache-Control` header values of `public` and `private`, respectively. As noted in the [NoStore and Location.None](#nostore-and-locationnone) section, setting <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> to `None` sets both `Cache-Control` and `Pragma` headers to `no-cache`.

`Location.Any` (`Cache-Control` set to `public`) indicates that the *client or any intermediate proxy* may cache the value, including [Response Caching Middleware](xref:performance/caching/middleware).

`Location.Client` (`Cache-Control` set to `private`) indicates that *only the client* may cache the value. No intermediate cache should cache the value, including [Response Caching Middleware](xref:performance/caching/middleware).

Cache control headers merely provide guidance to clients and intermediary proxies when and how to cache responses. There's no guarantee that clients and proxies will honor [RFC 9111: HTTP Caching](https://www.rfc-editor.org/rfc/rfc9111). [Response Caching Middleware](xref:performance/caching/middleware) always follows the caching rules laid out by the specification.

The following example shows the Cache3 page model from the sample app and the headers produced by setting <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Duration> and leaving the default <xref:Microsoft.AspNetCore.Mvc.CacheProfile.Location> value:

[!code-csharp[](response/samples/2.x/ResponseCacheSample/Pages/Cache3.cshtml.cs?name=snippet)]

The sample app returns the Cache3 page with the following header:

```
Cache-Control: public,max-age=10
```

### Cache profiles

Instead of duplicating response cache settings on many controller action attributes, cache profiles can be configured as options when setting up MVC/Razor Pages in `Startup.ConfigureServices`. Values found in a referenced cache profile are used as the defaults by the <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> and are overridden by any properties specified on the attribute.

Set up a cache profile. The following example shows a 30 second cache profile in the sample app's `Startup.ConfigureServices`:

[!code-csharp[](response/samples/3.x/Startup.cs?name=snippet1)]

The sample app's Cache4 page model references the `Default30` cache profile:

[!code-csharp[](response/samples/2.x/ResponseCacheSample/Pages/Cache4.cshtml.cs?name=snippet)]

The <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute> can be applied to:

* Razor Pages: Attributes can't be applied to handler methods.
* MVC controllers.
* MVC action methods: Method-level attributes override the settings specified in class-level attributes.

The resulting header applied to the Cache4 page response by the `Default30` cache profile:

```
Cache-Control: public,max-age=30
```

## Additional resources

* [Storing Responses in Caches](https://www.rfc-editor.org/rfc/rfc9111#name-storing-responses-in-caches)
* [RFC 9111: HTTP Caching (Section 5.2. Cache-Control)](https://www.rfc-editor.org/rfc/rfc9111#field.cache-control)
* <xref:performance/caching/memory>
* <xref:performance/caching/distributed>
* <xref:fundamentals/change-tokens>
* <xref:performance/caching/middleware>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>
:::moniker-end
