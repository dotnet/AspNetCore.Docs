---
title: Response Caching Middleware in ASP.NET Core
author: rick-anderson
description: Learn how to configure and use Response Caching Middleware in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 1/1/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: performance/caching/middleware
---
# Response Caching Middleware in ASP.NET Core

By [John Luo](https://github.com/JunTaoLuo) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

This article explains how to configure [Response Caching Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/ResponseCaching/src/ResponseCachingMiddleware.cs) in an ASP.NET Core app. The middleware determines when responses are cacheable, stores responses, and serves responses from cache. For an introduction to HTTP caching and the [`[ResponseCache]`](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) attribute, see [Response Caching](xref:performance/caching/response).

[!INCLUDE[](~/includes/response-caching-mid.md)]

<!--Postman:  GET: Headers > Postman > go to settings > uncheck Send no-cache header -->
## Configuration

In `Program.cs`, add the Response Caching Middleware services <xref:Microsoft.Extensions.DependencyInjection.ResponseCachingServicesExtensions.AddResponseCaching%2A> to the service collection and configure the app to use the middleware with the <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A> extension method. `UseResponseCaching` adds the middleware to the request processing pipeline:

[!code-csharp[](middleware/samples/6.x/ResponseCachingMiddleware/Program.cs?name=snippet2&highlight=3,12)]

> [!WARNING]
> <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must be called before <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A> when using [CORS middleware](xref:security/cors).

The sample app adds headers to control caching on subsequent requests:

* [Cache-Control](https://tools.ietf.org/html/rfc7234#section-5.2): Caches cacheable responses for up to 10 seconds.
* [Vary](https://tools.ietf.org/html/rfc7231#section-7.1.4): Configures the middleware to serve a cached response only if the [Accept-Encoding](https://tools.ietf.org/html/rfc7231#section-5.3.4) header of subsequent requests matches that of the original request.

[!code-csharp[](middleware/samples/6.x/ResponseCachingMiddleware/Program.cs?name=snippet1&highlight=14-26)]

The preceding headers are not written to the response and are overridden when a controller, action, or Razor Page:

* Has a [[ResponseCache]](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) attribute. This applies even if a property isn't set. For example, omitting the [VaryByHeader](./response.md#vary) property will cause the corresponding header to be removed from the response.

Response Caching Middleware only caches server responses that result in a 200 (OK) status code. Any other responses, including [error pages](xref:fundamentals/error-handling), are ignored by the middleware.

> [!WARNING]
> Responses containing content for authenticated clients must be marked as not cacheable to prevent the middleware from storing and serving those responses. See [Conditions for caching](#conditions-for-caching) for details on how the middleware determines if a response is cacheable.

The preceding code typically doesn't return a cached value to a browser. Use [Fiddler](https://www.telerik.com/fiddler), [Postman](https://www.getpostman.com/), or another tool that can explicitly set request headers and is preferred for testing caching. For more information, see [Troubleshooting](#troubleshooting) in this article.

## Options

Response caching options are shown in the following table.

| Option | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.MaximumBodySize> | The largest cacheable size for the response body in bytes. The default value is `64 * 1024 * 1024` (64 MB). |
| <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.SizeLimit> | The size limit for the response cache middleware in bytes. The default value is `100 * 1024 * 1024` (100 MB). |
| <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.UseCaseSensitivePaths> | Determines if responses are cached on case-sensitive paths. The default value is `false`. |

The following example configures the middleware to:

* Cache responses with a body size smaller than or equal to 1,024 bytes.
* Store the responses by case-sensitive paths. For example, `/page1` and `/Page1` are stored separately.

[!code-csharp[](middleware/samples/6.x/ResponseCachingMiddleware/Program.cs?name=snippet4&highlight=3-7)]

## VaryByQueryKeys

When using MVC, web API controllers, or Razor Pages page models, the [`[ResponseCache]`](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) attribute specifies the parameters necessary for setting the appropriate headers for response caching. The only parameter of the `[ResponseCache]` attribute that strictly requires the middleware is <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.VaryByQueryKeys>, which doesn't correspond to an actual HTTP header. For more information, see <xref:performance/caching/response#responsecache-attribute>.

When not using the `[ResponseCache]` attribute, response caching can be varied with `VaryByQueryKeys`. Use the <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingFeature> directly from the [HttpContext.Features](xref:Microsoft.AspNetCore.Http.HttpContext.Features):

```csharp
var responseCachingFeature = context.HttpContext.Features.Get<IResponseCachingFeature>();

if (responseCachingFeature != null)
{
    responseCachingFeature.VaryByQueryKeys = new[] { "MyKey" };
}
```

Using a single value equal to `*` in `VaryByQueryKeys` varies the cache by all request query parameters.

## HTTP headers used by Response Caching Middleware

The following table provides information on HTTP headers that affect response caching.

| Header | Details |
| ------ | ------- |
| `Authorization` | The response isn't cached if the header exists. |
| `Cache-Control` | The middleware only considers caching responses marked with the `public` cache directive. Control caching with the following parameters:<ul><li>max-age</li><li>max-stale&#8224;</li><li>min-fresh</li><li>must-revalidate</li><li>no-cache</li><li>no-store</li><li>only-if-cached</li><li>private</li><li>public</li><li>s-maxage</li><li>proxy-revalidate&#8225;</li></ul>&#8224;If no limit is specified to `max-stale`, the middleware takes no action.<br>&#8225;`proxy-revalidate` has the same effect as `must-revalidate`.<br><br>For more information, see [RFC 7231: Request Cache-Control Directives](https://tools.ietf.org/html/rfc7234#section-5.2.1). |
| `Pragma` | A `Pragma: no-cache` header in the request produces the same effect as `Cache-Control: no-cache`. This header is overridden by the relevant directives in the `Cache-Control` header, if present. Considered for backward compatibility with HTTP/1.0. |
| `Set-Cookie` | The response isn't cached if the header exists. Any middleware in the request processing pipeline that sets one or more cookies prevents the Response Caching Middleware from caching the response (for example, the [cookie-based TempData provider](xref:fundamentals/app-state#tempdata)).  |
| `Vary` | The `Vary` header is used to vary the cached response by another header. For example, cache responses by encoding by including the `Vary: Accept-Encoding` header, which caches responses for requests with headers `Accept-Encoding: gzip` and `Accept-Encoding: text/plain` separately. A response with a header value of `*` is never stored. |
| `Expires` | A response deemed stale by this header isn't stored or retrieved unless overridden by other `Cache-Control` headers. |
| `If-None-Match` | The full response is served from cache if the value isn't `*` and the `ETag` of the response doesn't match any of the values provided. Otherwise, a 304 (Not Modified) response is served. |
| `If-Modified-Since` | If the `If-None-Match` header isn't present, a full response is served from cache if the cached response date is newer than the value provided. Otherwise, a *304 - Not Modified* response is served. |
| `Date` | When serving from cache, the `Date` header is set by the middleware if it wasn't provided on the original response. |
| `Content-Length` | When serving from cache, the `Content-Length` header is set by the middleware if it wasn't provided on the original response. |
| `Age` | The `Age` header sent in the original response is ignored. The middleware computes a new value when serving a cached response. |

## Caching respects request Cache-Control directives

The middleware respects the rules of the [HTTP 1.1 Caching specification](https://tools.ietf.org/html/rfc7234#section-5.2). The rules require a cache to honor a valid `Cache-Control` header sent by the client. Under the specification, a client can make requests with a `no-cache` header value and force the server to generate a new response for every request. Currently, there's no developer control over this caching behavior when using the middleware because the middleware adheres to the official caching specification.

For more control over caching behavior, explore other caching features of ASP.NET Core. See the following topics:

* <xref:performance/caching/memory>
* <xref:performance/caching/distributed>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>

## Troubleshooting

The [Response Caching Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/ResponseCaching/src/ResponseCachingMiddleware.cs) uses <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>, which has a limited capacity. When the capacity is exceeded, the [memory cache is compacted](https://github.com/dotnet/runtime/blob/v6.0.1/src/libraries/Microsoft.Extensions.Caching.Memory/src/MemoryCache.cs#L359-L365). <!-- and the debug level log `Overcapacity compaction triggered` is written. -->

If caching behavior isn't as expected, confirm that responses are cacheable and capable of being served from the cache. Examine the request's incoming headers and the response's outgoing headers. Enable [logging](xref:fundamentals/logging/index) to help with debugging.

When testing and troubleshooting caching behavior, a browser typically sets request headers that prevent caching. For example, a browser may set the `Cache-Control` header to `no-cache` or `max-age=0` when refreshing a page. [Fiddler](https://www.telerik.com/fiddler), [Postman](https://www.getpostman.com/), and other tools can explicitly set request headers and are preferred for testing caching.

<a name="cfc"></a>

### Conditions for caching

* The request must result in a server response with a 200 (OK) status code.
* The request method must be GET or HEAD.
* Response Caching Middleware must be placed before middleware that require caching. For more information, see <xref:fundamentals/middleware/index>.
* The `Authorization` header must not be present.
* `Cache-Control` header parameters must be valid, and the response must be marked `public` and not marked `private`.
* The `Pragma: no-cache` header must not be present if the `Cache-Control` header isn't present, as the `Cache-Control` header overrides the `Pragma` header when present.
* The `Set-Cookie` header must not be present.
* `Vary` header parameters must be valid and not equal to `*`.
* The `Content-Length` header value (if set) must match the size of the response body.
* The <xref:Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature> isn't used.
* The response must not be stale as specified by the `Expires` header and the `max-age` and `s-maxage` cache directives.
* Response buffering must be successful. The size of the response must be smaller than the configured or default <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.SizeLimit>. The body size of the response must be smaller than the configured or default <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.MaximumBodySize>.
* The response must be cacheable according to the [RFC 7234](https://tools.ietf.org/html/rfc7234) specifications. For example, the `no-store` directive must not exist in request or response header fields. See *Section 3: Storing Responses in Caches* of [RFC 7234](https://tools.ietf.org/html/rfc7234) for details.

> [!NOTE]
> The Antiforgery system for generating secure tokens to prevent Cross-Site Request Forgery (CSRF) attacks sets the `Cache-Control` and `Pragma` headers to `no-cache` so that responses aren't cached. For information on how to disable antiforgery tokens for HTML form elements, see <xref:security/anti-request-forgery#aspnet-core-antiforgery-configuration>.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/middleware/samples) ([how to download](xref:index#how-to-download-a-sample))
* [GitHub source for `IResponseCachingPolicyProvider`](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/ResponseCaching/src/Interfaces/IResponseCachingPolicyProvider.cs)
* [GitHub source for `IResponseCachingPolicyProvider`](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/ResponseCaching/src/Interfaces/IResponseCachingPolicyProvider.cs)
* <xref:fundamentals/startup>
* <xref:fundamentals/middleware/index>
* <xref:performance/caching/memory>
* <xref:performance/caching/distributed>
* <xref:fundamentals/change-tokens>
* <xref:performance/caching/response>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This article explains how to configure Response Caching Middleware in an ASP.NET Core app. The middleware determines when responses are cacheable, stores responses, and serves responses from cache. For an introduction to HTTP caching and the [`[ResponseCache]`](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) attribute, see [Response Caching](xref:performance/caching/response).

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/caching/middleware/samples) ([how to download](xref:index#how-to-download-a-sample))

## Configuration

Response Caching Middleware is implicitly available for ASP.NET Core apps via the shared framework.

In `Startup.ConfigureServices`, add the Response Caching Middleware to the service collection:

[!code-csharp[](middleware/samples/3.x/ResponseCachingMiddleware/Startup.cs?name=snippet1&highlight=3)]

Configure the app to use the middleware with the <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching*> extension method, which adds the middleware to the request processing pipeline in `Startup.Configure`:

[!code-csharp[](middleware/samples/3.x/ResponseCachingMiddleware/Startup.cs?name=snippet2&highlight=17)]

> [!WARNING]
> <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must be called before <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A> when using [CORS middleware](xref:security/cors).

The sample app adds headers to control caching on subsequent requests:

* [Cache-Control](https://tools.ietf.org/html/rfc7234#section-5.2): Caches cacheable responses for up to 10 seconds.
* [Vary](https://tools.ietf.org/html/rfc7231#section-7.1.4): Configures the middleware to serve a cached response only if the [Accept-Encoding](https://tools.ietf.org/html/rfc7231#section-5.3.4) header of subsequent requests matches that of the original request.

[!code-csharp[](middleware/samples_snippets/3.x/AddHeaders.cs)]

The preceding headers are not written to the response and are overridden when a controller, action, or Razor Page:

* Has a [[ResponseCache]](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) attribute. This applies even if a property isn't set. For example, omitting the [VaryByHeader](./response.md#vary) property will cause the corresponding header to be removed from the response.

Response Caching Middleware only caches server responses that result in a 200 (OK) status code. Any other responses, including [error pages](xref:fundamentals/error-handling), are ignored by the middleware.

> [!WARNING]
> Responses containing content for authenticated clients must be marked as not cacheable to prevent the middleware from storing and serving those responses. See [Conditions for caching](#conditions-for-caching) for details on how the middleware determines if a response is cacheable.

## Options

Response caching options are shown in the following table.

| Option | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.MaximumBodySize> | The largest cacheable size for the response body in bytes. The default value is `64 * 1024 * 1024` (64 MB). |
| <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.SizeLimit> | The size limit for the response cache middleware in bytes. The default value is `100 * 1024 * 1024` (100 MB). |
| <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.UseCaseSensitivePaths> | Determines if responses are cached on case-sensitive paths. The default value is `false`. |

The following example configures the middleware to:

* Cache responses with a body size smaller than or equal to 1,024 bytes.
* Store the responses by case-sensitive paths. For example, `/page1` and `/Page1` are stored separately.

```csharp
services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 1024;
    options.UseCaseSensitivePaths = true;
});
```

## VaryByQueryKeys

When using MVC / web API controllers or Razor Pages page models, the [`[ResponseCache]`](xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute) attribute specifies the parameters necessary for setting the appropriate headers for response caching. The only parameter of the `[ResponseCache]` attribute that strictly requires the middleware is <xref:Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.VaryByQueryKeys>, which doesn't correspond to an actual HTTP header. For more information, see <xref:performance/caching/response#responsecache-attribute>.

When not using the `[ResponseCache]` attribute, response caching can be varied with `VaryByQueryKeys`. Use the <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingFeature> directly from the [HttpContext.Features](xref:Microsoft.AspNetCore.Http.HttpContext.Features):

```csharp
var responseCachingFeature = context.HttpContext.Features.Get<IResponseCachingFeature>();

if (responseCachingFeature != null)
{
    responseCachingFeature.VaryByQueryKeys = new[] { "MyKey" };
}
```

Using a single value equal to `*` in `VaryByQueryKeys` varies the cache by all request query parameters.

## HTTP headers used by Response Caching Middleware

The following table provides information on HTTP headers that affect response caching.

| Header | Details |
| ------ | ------- |
| `Authorization` | The response isn't cached if the header exists. |
| `Cache-Control` | The middleware only considers caching responses marked with the `public` cache directive. Control caching with the following parameters:<ul><li>max-age</li><li>max-stale&#8224;</li><li>min-fresh</li><li>must-revalidate</li><li>no-cache</li><li>no-store</li><li>only-if-cached</li><li>private</li><li>public</li><li>s-maxage</li><li>proxy-revalidate&#8225;</li></ul>&#8224;If no limit is specified to `max-stale`, the middleware takes no action.<br>&#8225;`proxy-revalidate` has the same effect as `must-revalidate`.<br><br>For more information, see [RFC 7231: Request Cache-Control Directives](https://tools.ietf.org/html/rfc7234#section-5.2.1). |
| `Pragma` | A `Pragma: no-cache` header in the request produces the same effect as `Cache-Control: no-cache`. This header is overridden by the relevant directives in the `Cache-Control` header, if present. Considered for backward compatibility with HTTP/1.0. |
| `Set-Cookie` | The response isn't cached if the header exists. Any middleware in the request processing pipeline that sets one or more cookies prevents the Response Caching Middleware from caching the response (for example, the [cookie-based TempData provider](xref:fundamentals/app-state#tempdata)).  |
| `Vary` | The `Vary` header is used to vary the cached response by another header. For example, cache responses by encoding by including the `Vary: Accept-Encoding` header, which caches responses for requests with headers `Accept-Encoding: gzip` and `Accept-Encoding: text/plain` separately. A response with a header value of `*` is never stored. |
| `Expires` | A response deemed stale by this header isn't stored or retrieved unless overridden by other `Cache-Control` headers. |
| `If-None-Match` | The full response is served from cache if the value isn't `*` and the `ETag` of the response doesn't match any of the values provided. Otherwise, a 304 (Not Modified) response is served. |
| `If-Modified-Since` | If the `If-None-Match` header isn't present, a full response is served from cache if the cached response date is newer than the value provided. Otherwise, a *304 - Not Modified* response is served. |
| `Date` | When serving from cache, the `Date` header is set by the middleware if it wasn't provided on the original response. |
| `Content-Length` | When serving from cache, the `Content-Length` header is set by the middleware if it wasn't provided on the original response. |
| `Age` | The `Age` header sent in the original response is ignored. The middleware computes a new value when serving a cached response. |

## Caching respects request Cache-Control directives

The middleware respects the rules of the [HTTP 1.1 Caching specification](https://tools.ietf.org/html/rfc7234#section-5.2). The rules require a cache to honor a valid `Cache-Control` header sent by the client. Under the specification, a client can make requests with a `no-cache` header value and force the server to generate a new response for every request. Currently, there's no developer control over this caching behavior when using the middleware because the middleware adheres to the official caching specification.

For more control over caching behavior, explore other caching features of ASP.NET Core. See the following topics:

* <xref:performance/caching/memory>
* <xref:performance/caching/distributed>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>

## Troubleshooting

If caching behavior isn't as expected, confirm that responses are cacheable and capable of being served from the cache. Examine the request's incoming headers and the response's outgoing headers. Enable [logging](xref:fundamentals/logging/index) to help with debugging.

When testing and troubleshooting caching behavior, a browser may set request headers that affect caching in undesirable ways. For example, a browser may set the `Cache-Control` header to `no-cache` or `max-age=0` when refreshing a page. The following tools can explicitly set request headers and are preferred for testing caching:

* [Fiddler](https://www.telerik.com/fiddler)
* [Postman](https://www.getpostman.com/)

### Conditions for caching

* The request must result in a server response with a 200 (OK) status code.
* The request method must be GET or HEAD.
* In `Startup.Configure`, Response Caching Middleware must be placed before middleware that require caching. For more information, see <xref:fundamentals/middleware/index>.
* The `Authorization` header must not be present.
* `Cache-Control` header parameters must be valid, and the response must be marked `public` and not marked `private`.
* The `Pragma: no-cache` header must not be present if the `Cache-Control` header isn't present, as the `Cache-Control` header overrides the `Pragma` header when present.
* The `Set-Cookie` header must not be present.
* `Vary` header parameters must be valid and not equal to `*`.
* The `Content-Length` header value (if set) must match the size of the response body.
* The <xref:Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature> isn't used.
* The response must not be stale as specified by the `Expires` header and the `max-age` and `s-maxage` cache directives.
* Response buffering must be successful. The size of the response must be smaller than the configured or default <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.SizeLimit>. The body size of the response must be smaller than the configured or default <xref:Microsoft.AspNetCore.ResponseCaching.ResponseCachingOptions.MaximumBodySize>.
* The response must be cacheable according to the [RFC 7234](https://tools.ietf.org/html/rfc7234) specifications. For example, the `no-store` directive must not exist in request or response header fields. See *Section 3: Storing Responses in Caches* of [RFC 7234](https://tools.ietf.org/html/rfc7234) for details.

> [!NOTE]
> The Antiforgery system for generating secure tokens to prevent Cross-Site Request Forgery (CSRF) attacks sets the `Cache-Control` and `Pragma` headers to `no-cache` so that responses aren't cached. For information on how to disable antiforgery tokens for HTML form elements, see <xref:security/anti-request-forgery#aspnet-core-antiforgery-configuration>.

## Additional resources

* <xref:fundamentals/startup>
* <xref:fundamentals/middleware/index>
* <xref:performance/caching/memory>
* <xref:performance/caching/distributed>
* <xref:fundamentals/change-tokens>
* <xref:performance/caching/response>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>

:::moniker-end
