---
title: Response Caching Middleware in ASP.NET Core
author: guardrex
description: Configuration and use of Response Caching Middleware in ASP.NET Core applications.
keywords: ASP.NET Core,response caching,caching,ResponseCache,ResponseCaching,Cache-Control,VaryByQueryKeys,middleware
ms.author: riande
manager: wpickett
ms.date: 08/22/2017
ms.topic: article
ms.assetid: f9267eab-2762-42ac-1638-4a25d2c9d67c
ms.prod: asp.net-core
uid: performance/caching/middleware
---
# Response Caching Middleware in ASP.NET Core

By [Luke Latham](https://github.com/GuardRex) and [John Luo](https://github.com/JunTaoLuo)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/middleware/samples)

This document provides details on how to configure the Response Caching Middleware in ASP.NET Core apps. The middleware determines when responses are cacheable, stores responses, and serves responses from cache. For an introduction to HTTP caching and the `ResponseCache` attribute, see [Response Caching](response.md).

## Package
To include the middleware in a project, add a reference to the [`Microsoft.AspNetCore.ResponseCaching`](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCaching/) package or use the [`Microsoft.AspNetCore.All`](https://www.nuget.org/packages/Microsoft.AspNetCore.All/) package.

## Configuration
In `ConfigureServices`, add the middleware to the service collection.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](middleware/samples/2.x/Program.cs?name=snippet1&highlight=4)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](middleware/samples/1.x/Startup.cs?name=snippet1&highlight=3)]

---

Configure the app to use the middleware with the `UseResponseCaching` extension method, which adds the middleware to the request processing pipeline. The sample app adds a [`Cache-Control`](https://tools.ietf.org/html/rfc7234#section-5.2) header to the response that caches cacheable responses for up to 10 seconds. The sample sends a [`Vary`](https://tools.ietf.org/html/rfc7231#section-7.1.4) header to configure the middleware to serve a cached response only if the [`Accept-Encoding`](https://tools.ietf.org/html/rfc7231#section-5.3.4) header of subsequent requests matches that of the original request.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](middleware/samples/2.x/Program.cs?name=snippet1&highlight=8)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](middleware/samples/1.x/Startup.cs?name=snippet2&highlight=3)]

---

The Response Caching Middleware only caches 200 (OK) server responses. Any other responses, including [error pages](xref:fundamentals/error-handling), are ignored by the middleware.

> [!WARNING]
> Responses containing content for authenticated clients must be marked as not cacheable to prevent the middleware from storing and serving those responses. See [Conditions for caching](#conditions-for-caching) for details on how the middleware determines if a response is cacheable.

## Options
The middleware offers three options for controlling response caching.

| Option                | Default Value |
| --------------------- | ------------- |
| UseCaseSensitivePaths | Determines if responses are cached on case-sensitive paths.</p><p>The default value is `false`. |
| MaximumBodySize       | The largest cacheable size for the response body in bytes.</p>The default value is `64 * 1024 * 1024` (64 MB). |
| SizeLimit             | The size limit for the response cache middleware in bytes. The default value is `100 * 1024 * 1024` (100 MB). |

The following example configures the middleware to cache responses smaller than or equal to 1,024 bytes using case-sensitive paths, storing the responses to `/page1` and `/Page1` separately.

```csharp
services.AddResponseCaching(options =>
{
    options.UseCaseSensitivePaths = true;
    options.MaximumBodySize = 1024;
});
```

## VaryByQueryKeys
When using MVC, the `ResponseCache` attribute specifies the parameters necessary for setting appropriate headers for response caching. The only parameter of the `ResponseCache` attribute that strictly requires the middleware is `VaryByQueryKeys`, which doesn't correspond to an actual HTTP header. For more information, see [ResponseCache Attribute](response.md#responsecache-attribute).

When not using MVC, you can vary response caching with the `VaryByQueryKeys` feature. Use the `ResponseCachingFeature` directly from the `IFeatureCollection` of the `HttpContext`:

```csharp
var responseCachingFeature = context.HttpContext.Features.Get<IResponseCachingFeature>();
if (responseCachingFeature != null)
{
    responseCachingFeature.VaryByQueryKeys = new[] { "MyKey" };
}
```

## HTTP headers used by Response Caching Middleware
Response caching by the middleware is configured via HTTP headers. The relevant headers are listed below with notes on how they affect caching.

| Header | Details |
| ------ | ------- |
| Authorization | The response isn't cached if the header exists. |
| Cache-Control | The middleware only considers caching responses marked with the `public` cache directive. You can control caching with the following parameters:<ul><li>max-age</li><li>max-stale&#8224;</li><li>min-fresh</li><li>must-revalidate</li><li>no-cache</li><li>no-store</li><li>only-if-cached</li><li>private</li><li>public</li><li>s-maxage</li><li>proxy-revalidate&#8225;</li></ul>&#8224;If no limit is specified to `max-stale`, the middleware takes no action.<br>&#8225;`proxy-revalidate` has the same effect as `must-revalidate`.<br><br>For more information, see [RFC 7231: Request Cache-Control Directives](https://tools.ietf.org/html/rfc7234#section-5.2.1). |
| Pragma | A `Pragma: no-cache` header in the request produces the same effect as `Cache-Control: no-cache`. This header is overridden by the relevant directives in the `Cache-Control` header, if present. Considered for backward compatibility with HTTP/1.0. |
| Set-Cookie | The response isn't cached if the header exists. |
| Vary | The `Vary` header is used to vary the cached response by another header. For example, you can cache responses by encoding by including the `Vary: Accept-Encoding` header, which caches responses for requests with headers `Accept-Encoding: gzip` and `Accept-Encoding: text/plain` separately. A response with a header value of `*` is never stored. |
| Expires | A response deemed stale by this header isn't stored or retrieved unless overridden by other `Cache-Control` headers. |
| If-None-Match | The full response is served from cache if the value isn't `*` and the `ETag` of the response doesn't match any of the values provided. Otherwise, a 304 (Not Modified) response is served. |
| If-Modified-Since | If the `If-None-Match` header isn't present, a full response is served from cache if the cached response date is newer than the value provided. Otherwise, a 304 (Not Modified) response is served. |
| Date | When serving from cache, the `Date` header is set by the middleware if it wasn't provided on the original response. |
| Content-Length | When serving from cache, the `Content-Length` header is set by the middleware if it wasn't provided on the original response. |
| Age | The `Age` header sent in the original response is ignored. The middleware computes a new value when serving a cached response. |

## Troubleshooting
If caching behavior isn't as you expect, confirm that responses are cacheable and capable of being served from the cache by examining the request's incoming headers and the response's outgoing headers. Enabling [logging](xref:fundamentals/logging) can help when debugging. The middleware logs caching behavior and when a response is retrieved from cache.

When testing and troubleshooting caching behavior, a browser may set request headers that affect caching in undesirable ways. For example, a browser may set the `Cache-Control` header to `no-cache` when you refresh the page. The following tools can explicitly set request headers, and are preferred for testing caching:

* [Fiddler](http://www.telerik.com/fiddler)
* [Firebug](http://getfirebug.com/)
* [Postman](https://www.getpostman.com/)

### Conditions for caching
* The request must result in a 200 (OK) response from the server.
* The request method must be GET or HEAD.
* Terminal middleware, such as Static File Middleware, must not process the response prior to the Response Caching Middleware.
* The `Authorization` header must not be present.
* `Cache-Control` header parameters must be valid, and the response must be marked `public` and not marked `private`.
* The `Pragma: no-cache` header/value must not be present if the `Cache-Control` header isn't present, as the `Cache-Control` header overrides the `Pragma` header when present.
* The `Set-Cookie` header must not be present.
* `Vary` header parameters must be valid and not equal to `*`.
* The `Content-Length` header value (if set) must match the size of the response body.
* The `HttpSendFileFeature` isn't used.
* The response must not be stale as specified by the `Expires` header and the `max-age` and `s-maxage` cache directives.
* Response buffering is successful, and the size of the response is smaller than the configured or default `SizeLimit`.
* The response must be cacheable according to the [RFC 7234](https://tools.ietf.org/html/rfc7234) specifications. For example, the `no-store` directive must not exist in request or response header fields. See *Section 3: Storing Responses in Caches* of [RFC 7234](https://tools.ietf.org/html/rfc7234) for details.

> [!NOTE]
> The Antiforgery system for generating secure tokens to prevent Cross-Site Request Forgery (CSRF) attacks sets the `Cache-Control` and `Pragma` headers to `no-cache` so that responses aren't cached.

## Additional resources

* [Application Startup](xref:fundamentals/startup)
* [Middleware](xref:fundamentals/middleware)
