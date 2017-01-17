---
title: Response Caching Middleware | Microsoft Docs
author: guardrex
description: Configuration and use of Response Caching Middleware in ASP.NET Core applications.
keywords: ASP.NET Core, response caching, caching, ResponseCache, ResponseCaching, Cache-Control, VaryByQueryKeys, middleware
ms.author: riande
manager: wpickett
ms.date: 1/7/2017
ms.topic: article
ms.assetid: f9267eab-2762-42ac-1638-4a25d2c9d67c
ms.prod: aspnet-core
uid: performance/caching/middleware
---
# Response Caching Middleware

By [Luke Latham](https://github.com/GuardRex) and [John Luo](https://github.com/JunTaoLuo)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/middleware/sample)

This document provides details on how to configure the Response Caching Middleware in ASP.NET Core applications. The middleware determines when responses are cacheable, stores responses, and serves responses from cache. For an introduction to HTTP caching and the `ResponseCache` attribute, see [Response Caching](response.md).

## Package
To include the middleware in your project, add a reference to the  [`Microsoft.AspNetCore.ResponseCaching`](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCaching/) package. The middleware is available for projects that target `.NETFramework 4.5.1` or `.NETStandard 1.3` or higher.

## Configuration
In `ConfgureServices`, add the middleware to your service collection.

[!code-csharp[Main](middleware/sample/Startup.cs?name=snippet1)]

Configure the application to use the middleware when processing requests. The sample application adds a [`Cache-Control`](https://tools.ietf.org/html/rfc7234#section-5.2) header to the response that will cache cacheable responses for up to 10 seconds. The sample also sends a [`Vary`](https://tools.ietf.org/html/rfc7231#section-7.1.4) header to configure the cache to serve the response only if the [`Accept-Encoding`](https://tools.ietf.org/html/rfc7231#section-5.3.4) header of subsequent requests matches that from the original request.

[!code-csharp[Main](middleware/sample/Startup.cs?name=snippet2)]

The Response Caching Middleware only caches 200 (OK) server responses. Any other responses, including [error pages](xref:fundamentals/error-handling), will be ignored by the middleware.

## Options
The middleware offers two options for controlling response caching.

Option | Default Value
--- | ---
UseCaseSensitivePaths | <p>Determines if responses will be cached on case-sensitive paths.</p><p>The default value is `false`.</p>
MaximumBodySize | <p>The largest cacheable size for the response body in bytes.</p>The default value is `64 * 1024 * 1024` [64 MB (67,108,864 bytes)].</p>

The following example configures the middleware to cache responses smaller than or equal to 1,024 bytes using case-sensitive paths, storing the responses to `/page1` and `/Page1` separately.

```csharp
services.AddResponseCaching(options =>
{
    options.UseCaseSensitivePaths = true;
    options.MaximumBodySize = 1024;
});
```

## VaryByQueryKeys feature
When using MVC, the `ResponseCache` attribute specifies the parameters necessary for setting appropriate headers for response caching. The only parameter of the `ResponseCache` attribute that strictly requires the middleware is `VaryByQueryKeys`, which does not correspond to an actual HTTP header. For more information, see [ResponseCache Attribute](response.md#responsecache-attribute).

When not using MVC, you can vary response caching with the `VaryByQueryKeys` feature by using the `ResponseCachingFeature` directly from the `IFeatureCollection` of the `HttpContext`.

```csharp
var responseCachingFeature = context.HttpContext.Features.Get<IResponseCachingFeature>();
if (responseCachingFeature != null)
{
    responseCachingFeature.VaryByQueryKeys = new[] { "MyKey" };
}
```

## HTTP headers used by Response Caching Middleware
Response caching by the middleware is configured via your HTTP response headers. The relevant headers are listed below with notes on how they affect caching.

Header | Details
--- | --- |
Authorization | <p>The response is not cached if the header exists.</p>
Cache-Control | <p>The middleware will only consider caching responses explicitly marked with the `public` cache directive.</p><p>You can control caching with the following parameters:</p><ul><li>max-age</li><li>max-stale</li><li>min-fresh</li><li>must-revalidate</li><li>no-cache</li><li>no-store</li><li>only-if-cached</li><li>private</li><li>public</li><li>s-maxage</li><li>proxy-revalidate</li></ul><p>For more information, see [RFC 7231: Request Cache-Control Directives](https://tools.ietf.org/html/rfc7234#section-5.2.1).</p>
Pragma | <p>A `Pragma: no-cache` header in the request produces the same effect as `Cache-Control: no-cache`. This header is overridden by the relevant directives in the `Cache-Control` header if present.</p><p>Considered for backward compatibility with HTTP/1.0.</p>
Set-Cookie | <p>The response is not cached if the header exists.</p>
Vary | <p>You can vary the cached response by another header. For example, you can cache responses by encoding by including the `Vary: Accept-Encoding` header, which would cache responses to requests with headers `Accept-Encoding: gzip` and `Accept-Encoding: text/plain` separately. A response with a header value of `*` is never stored.</p>
Expires | <p>A response deemed stale by this header will not be stored or retrieved unless overridden by other `Cache-Control` headers.</p>
If-None-Match | <p>The full response will be served from cache if the value is not `*` and the `ETag` of the response doesn't match any of the values provided. Otherwise, a 304 (Not Modified) response will be served.</p>
If-Modified-Since | <p>If the `If-None-Match` header is not present, a full response will be served from cache if the cached response date is newer than the value provided. Otherwise, a 304 (Not Modified) response will be served.</p>
Date | <p>When serving from cache, the `Date` header is set by the middleware if it wasn't provided on the original response.</p>
Content-Length | <p>When serving from cache, the `Content-Length` header is set by the middleware if it wasn't provided on the original response.</p>
Age | <p>The `Age` header sent in the original response will be ignored. The middleware will compute a new value when serving a cached response.</p>

## Troubleshooting
If caching behavior is not as you expect, confirm that responses are cacheable and capable of being served from the cache by examining the request's incoming headers and the response's outgoing headers. The conditions by which a response will be cached are listed below.

Enabling logging can help when debugging. For example, the middleware logs why a response is or is not cached and whether it was retrieved from cache. See [Logging in ASP.NET Core](xref:fundamentals/logging) for more information on enabling logging in your application.

When testing and troubleshooting caching behavior, a browser may set request headers that affect caching in undesirable ways. For example, a browser may set the `Cache-Control` header to `no-cache` when you refresh the page. Instead of using a browser, use a tool like [Fiddler](http://www.telerik.com/fiddler), [Firebug](http://getfirebug.com/), or [Postman](https://www.getpostman.com/), all of which allow you to explicitly set request headers.

### Conditions for caching
* The request must result in a 200 (OK) response from the server.
* The request method must be GET or HEAD.
* Terminal middleware, such as Static File Middleware, must not process the response prior to the Response Caching Middleware.
* The Authorization header must not be present.
* `Cache-Control` header parameters must be valid, and the response must be marked `public` and not marked `private`.
* The `Pragma: no-cache` header/value must not be present if the `Cache-Control` header is not present, as the `Cache-Control` header overrides the `Pragma` header when present.
* The `Set-Cookie` header must not be present.
* `Vary` header parameters must be valid and not equal to `*`.
* The `Content-Length` header value (if set) must match the size of the response body.
* The `HttpSendFileFeature` is not used.
* The response must not be stale as specified by the `Expires` header and the `max-age` and `s-maxage` cache directives.
* Response buffering is successful, and the total length of the response is smaller than the configured limit.
* The response must be cacheable according to the [RFC 7234](https://tools.ietf.org/html/rfc7234) specifications. For example, the `no-store` directive must not exist in request or response header fields. See *Section 3: Storing Responses in Caches* of the RFC document for details.

>[!NOTE]
> The Antiforgery system for generating secure tokens to prevent Cross-Site Request Forgery (CSRF) attacks will set the `Cache-Control` and `Pragma` headers to `no-cache` so that responses will not be cached.

## Additional Resources

* [Application Startup](xref:fundamentals/startup)
* [Middleware](xref:fundamentals/middleware)
