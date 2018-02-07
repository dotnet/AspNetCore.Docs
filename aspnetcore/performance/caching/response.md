---
title: Response caching in ASP.NET Core
author: rick-anderson
description: Learn how to use response caching to lower bandwidth requirements and increase performance of ASP.NET Core apps.
manager: wpickett
ms.author: riande
ms.date: 09/20/2017
ms.prod: asp.net-core
ms.topic: article
uid: performance/caching/response
---
# Response caching in ASP.NET Core

By [John Luo](https://github.com/JunTaoLuo), [Rick Anderson](https://twitter.com/RickAndMSFT), [Steve Smith](https://ardalis.com/), and [Luke Latham](https://github.com/guardrex)

> [!NOTE]
> Response caching [isn't supported in Razor Pages with ASP.NET Core 2.0](https://github.com/aspnet/Mvc/issues/6437). This feature will be supported in the [ASP.NET Core 2.1 release](https://github.com/aspnet/Home/wiki/Roadmap).
  
[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/response/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

Response caching reduces the number of requests a client or proxy makes to a web server. Response caching also reduces the amount of work the web server performs to generate a response. Response caching is controlled by headers that specify how you want client, proxy, and middleware to cache responses.

The web server can cache responses when you add [Response Caching Middleware](xref:performance/caching/middleware).

## HTTP-based response caching

The [HTTP 1.1 Caching specification](https://tools.ietf.org/html/rfc7234) describes how Internet caches should behave. The primary HTTP header used for caching is [Cache-Control](https://tools.ietf.org/html/rfc7234#section-5.2), which is used to specify cache *directives*. The directives control caching behavior as requests make their way from clients to servers and as reponses make their way from servers back to clients. Requests and responses move through proxy servers, and proxy servers must also conform to the HTTP 1.1 Caching specification.

Common `Cache-Control` directives are shown in the following table.

| Directive                                                       | Action |
| --------------------------------------------------------------- | ------ |
| [public](https://tools.ietf.org/html/rfc7234#section-5.2.2.5)   | A cache may store the response. |
| [private](https://tools.ietf.org/html/rfc7234#section-5.2.2.6)  | The response must not be stored by a shared cache. A private cache may store and reuse the response. |
| [max-age](https://tools.ietf.org/html/rfc7234#section-5.2.1.1)  | The client won't accept a response whose age is greater than the specified number of seconds. Examples: `max-age=60` (60 seconds), `max-age=2592000` (1 month) |
| [no-cache](https://tools.ietf.org/html/rfc7234#section-5.2.1.4) | **On requests**: A cache must not use a stored response to satisfy the request. Note: The origin server re-generates the response for the client, and the middleware updates the stored response in its cache.<br><br>**On responses**: The response must not be used for a subsequent request without validation on the origin server. |
| [no-store](https://tools.ietf.org/html/rfc7234#section-5.2.1.5) | **On requests**: A cache must not store the request.<br><br>**On responses**: A cache must not store any part of the response. |

Other cache headers that play a role in caching are shown in the following table.

| Header                                                     | Function |
| ---------------------------------------------------------- | -------- |
| [Age](https://tools.ietf.org/html/rfc7234#section-5.1)     | An estimate of the amount of time in seconds since the response was generated or successfully validated at the origin server. |
| [Expires](https://tools.ietf.org/html/rfc7234#section-5.3) | The date/time after which the response is considered stale. |
| [Pragma](https://tools.ietf.org/html/rfc7234#section-5.4)  | Exists for backwards compatibility with HTTP/1.0 caches for setting `no-cache` behavior. If the `Cache-Control` header is present, the `Pragma` header is ignored. |
| [Vary](https://tools.ietf.org/html/rfc7231#section-7.1.4)  | Specifies that a cached response must not be sent unless all of the `Vary` header fields match in both the cached response's original request and the new request. |

## HTTP-based caching respects request Cache-Control directives

The [HTTP 1.1 Caching specification for the Cache-Control header](https://tools.ietf.org/html/rfc7234#section-5.2) requires a cache to honor a valid `Cache-Control` header sent by the client. A client can make requests with a `no-cache` header value and force the server to generate a new response for every request.

Always honoring client `Cache-Control` request headers makes sense if you consider the goal of HTTP caching. Under the official specification, caching is meant to reduce the latency and network overhead of satisfying requests across a network of clients, proxies, and servers. It isn't necessarily a way to control the load on an origin server.

There's no current developer control over this caching behavior when using the [Response Caching Middleware](xref:performance/caching/middleware) because the middleware adheres to the official caching specification. [Future enhancements to the middleware](https://github.com/aspnet/ResponseCaching/issues/96) will permit configuring the middleware to ignore a request's `Cache-Control` header when deciding to serve a cached response. This will offer you an opportunity to better control the load on your server when you use the middleware.

## Other caching technology in ASP.NET Core

### In-memory caching

In-memory caching uses server memory to store cached data. This type of caching is suitable for a single server or multiple servers using *sticky sessions*. Sticky sessions means that the requests from a client are always routed to the same server for processing.

For more information, see [Introduction to in-memory caching in ASP.NET Core](xref:performance/caching/memory).

### Distributed Cache

Use a distributed cache to store data in memory when the app is hosted in a cloud or server farm. The cache is shared across the servers that process requests. A client can submit a request that's handled by any server in the group and cached data for the client if available. ASP.NET Core offers SQL Server and Redis distributed caches.

For more information, see [Working with a distributed cache](xref:performance/caching/distributed).

### Cache Tag Helper

You can cache the content from an MVC view or Razor Page with the Cache Tag Helper. The Cache Tag Helper uses in-memory caching to store data.

For more information, see [Cache Tag Helper in ASP.NET Core MVC](xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper).

### Distributed Cache Tag Helper

You can cache the content from an MVC view or Razor Page in distributed cloud or web farm scenarios with the Distributed Cache Tag Helper. The Distributed Cache Tag Helper uses SQL Server or Redis to store data.

For more information, see [Distributed Cache Tag Helper](xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper).

## ResponseCache attribute

The `ResponseCacheAttribute` specifies the parameters necessary for setting appropriate headers in response caching. See [ResponseCacheAttribute](/aspnet/core/api/microsoft.aspnetcore.mvc.responsecacheattribute) for a description of the parameters.

> [!WARNING]
> Disable caching for content that contains information for authenticated clients. Caching should only be enabled for content that doesn't change based on a user's identity or whether a user is logged in.

`VaryByQueryKeys string[]` (requires ASP.NET Core 1.1 and higher): When set, the Response Caching Middleware varies the stored response by the values of the given list of query keys. The Response Caching Middleware must be enabled to set the `VaryByQueryKeys` property; otherwise, a runtime exception is thrown. There's no corresponding HTTP header for the `VaryByQueryKeys` property. This property is an HTTP feature handled by the Response Caching Middleware. For the middleware to serve a cached response, the query string and query string value must match a previous request. For example, consider the sequence of requests and results shown in the following table.

| Request                          | Result                   |
| -------------------------------- | ------------------------ |
| `http://example.com?key1=value1` | Returned from server     |
| `http://example.com?key1=value1` | Returned from middleware |
| `http://example.com?key1=value2` | Returned from server     |

The first request is returned by the server and cached in middleware. The second request is returned by middleware because the query string matches the previous request. The third request isn't in the middleware cache because the query string value doesn't match a previous request. 

The `ResponseCacheAttribute` is used to configure and create (via `IFilterFactory`) a `ResponseCacheFilter`. The `ResponseCacheFilter` performs the work of updating the appropriate HTTP headers and features of the response. The filter:

* Removes any existing headers for `Vary`, `Cache-Control`, and `Pragma`. 
* Writes out the appropriate headers based on the properties set in the `ResponseCacheAttribute`. 
* Updates the response caching HTTP feature if `VaryByQueryKeys` is set.

### Vary

This header is only written when the `VaryByHeader` property is set. It's set to the `Vary` property's value. The following sample uses the `VaryByHeader` property:

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet_VaryByHeader&highlight=1)]

You can view the response headers with your browser's network tools. The following image shows the Edge F12 output on the **Network** tab when the `About2` action method is refreshed:

![Edge F12 output on the Network tab when the About2 action method is called](response/_static/vary.png)

### NoStore and Location.None

`NoStore` overrides most of the other properties. When this property is set to `true`, the `Cache-Control` header is set to `no-store`. If `Location` is set to `None`:

* `Cache-Control` is set to `no-store,no-cache`.
* `Pragma` is set to `no-cache`.

If `NoStore` is `false` and `Location` is `None`, `Cache-Control` and `Pragma` are set to `no-cache`.

You typically set `NoStore` to `true` on error pages. For example:

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet1&highlight=1)]

This results in the following headers:

```
Cache-Control: no-store,no-cache
Pragma: no-cache
```

### Location and Duration

To enable caching, `Duration` must be set to a positive value and `Location` must be either `Any` (the default) or `Client`. In this case, the `Cache-Control` header is set to the location value followed by the `max-age` of the response.

> [!NOTE]
> `Location`'s options of `Any` and `Client` translate into `Cache-Control` header values of `public` and `private`, respectively. As noted previously, setting `Location` to `None` sets both `Cache-Control` and `Pragma` headers to `no-cache`.

Below is an example showing the headers produced by setting `Duration` and leaving the default `Location` value:

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet_duration&highlight=1)]

This produces the following header:

```
Cache-Control: public,max-age=60
```

### Cache profiles

Instead of duplicating `ResponseCache` settings on many controller action attributes, cache profiles can be configured as options when setting up MVC in the `ConfigureServices` method in `Startup`. Values found in a referenced cache profile are used as the defaults by the `ResponseCache` attribute and are overridden by any properties specified on the attribute.

Setting up a cache profile:

[!code-csharp[Main](response/sample/Startup.cs?name=snippet1)] 

Referencing a cache profile:

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet_controller&highlight=1,4)]

The `ResponseCache` attribute can be applied both to actions (methods) and controllers (classes). Method-level attributes override the settings specified in class-level attributes.

In the above example, a class-level attribute specifies a duration of 30 seconds, while a method-level attribute references a cache profile with a duration set to 60 seconds.

The resulting header:

```
Cache-Control: public,max-age=60
```

## Additional resources

* [Caching in HTTP from the specification](https://tools.ietf.org/html/rfc7234#section-3)
* [Cache-Control](https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9)
* [In-memory caching](xref:performance/caching/memory)
* [Working with a distributed cache](xref:performance/caching/distributed)
* [Detect changes with change tokens](xref:fundamentals/primitives/change-tokens)
* [Response Caching Middleware](xref:performance/caching/middleware)
* [Cache Tag Helper](xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper)
* [Distributed Cache Tag Helper](xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper)
