---
title: Response Caching Middleware | Microsoft Docs
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 12/05/2016
ms.topic: article
ms.assetid: f9267eab-2762-42ac-1638-4a25d2c9d67c
ms.prod: aspnet-core
uid: performance/caching/middleware
---
# Response Caching Middleware

By [Luke Latham](https://github.com/GuardRex) and [John Luo](https://github.com/JunTaoLuo)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/response/sample)

This document provides details on how to configure the Response Caching Middleware for ASP.NET Core applications. For an introduction to to HTTP caching and the `ResponseCacheAttribute`, see [Response Caching](response.md).

## Package
To include the middleware in your project, add a reference to the  [`Microsoft.AspNetCore.ResponseCaching`](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCaching/) package. The middleware is available for projects that target `.NETFramework 4.5.1` or `.NETStandard 1.3` or higher.

## Extensions
In `ConfgureServices`, add the middleware to your service collection.
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddResponseCaching();
}
```
Configure the application to use the middleware when processing requests.
```c#
public void Configure(IApplicationBuilder app)
{
    ...
    app.UseResponseCaching();
    ...
}
```
The position of `app.UseResponseCaching()` relative to other middleware in the pipeline is important. Any terminal middleware placed before the Response Caching Middleware will prevent the Response Caching Middleware from caching or serving the response. For example, if you place [Static File Middleware](xref:fundamentals/static-files) before `app.UseResponseCaching()`, your static files will not be cached by the middleware. If you place Static File Middleware after `app.UseResponseCaching()`, your static files will be cached.

If you place Static File Middleware before Response Caching Middleware, you can provide a prefix to the middleware that will force it to ignore requests with a path that doesn't match your prefix. For example, you can prefix your application's static file links with **assets** (**http://www.myapp.com/assets/staticfile.txt**) and configure the middleware to ignore any requests that do not include the **assets** prefix, `app.UseStaticFiles("/assets")`. Note that "**assets**" is only part of the path in your links to the static files. Your application will not have an **assets** folder, and your static files should remain in the **wwwroot** folder of your deployed application (**wwwroot\staticfile.txt**).

There is no need for you to be concerned about the position of `app.UseDeveloperExceptionPage()` and the accidential caching of the developer exception page. The Response Caching Middleware only caches 200 (OK) server responses. The developer exception page is only produced on non-200 responses, so it will never be cached by the middleware.

## Options
The middleware offers two options for controlling response caching.

Option | Default Value
--- | ---
UseCaseSensitivePaths | <p>Determines if responses will be cached on case-sensitive paths.</p><p>The default value is `false`.</p>
MaximumBodySize | <p>The largest cacheable size for the response body in bytes.</p>The default value is `64 * 1024 * 1024` [64 MB (67,108,864 bytes)].</p>

The following example configures these options so that the middleware will independently cache responses on case-sensitive paths and on body response size. Configured as shown below, the middleware would independently cache the responses for `/page1` and `/PaGe1`. The middleware would also only cache responses that have a body size less than 1 MB (1,024 bytes).
```c#
services.AddResponseCaching(options =>
{
    options.UseCaseSensitivePaths = true;
    options.MaximumBodySize = 1024;
});
```

## ResponseCache attribute
The `ResponseCache` attribute specifies the parameters necessary for setting appropriate headers for response caching. The only parameter of the `ResponseCache` attribute that strictly requires the middleware is `VaryByQueryKeys`, which does not correspond to an actual HTTP header. See the [ResponseCache Attribute document](response.md#responsecache-attribute) and the [ResponseCacheAttribute Class API Reference](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.responsecacheattribute) for usage and a description of the parameters.

## Caching conditions
* The request must result in a 200 (OK) response from the server.
* The request method must be GET or HEAD.
* Terminal middlewares, such as Static File Middleware, must not process the response prior to the Response Caching Middleware.
* The Authorization header must not be present.
* `Cache-Control` header parameters must be valid and the response must be marked `public`.
* The `Pragma: no-cache` header/value must not be present.
* The `Set-Cookie` header must not be present.
* `Vary` header parameters must be valid and not equal to `*`.

>[!NOTE]
> The Antiforgery system for generating secure tokens to prevent Cross-Site Request Forgery (CSRF) attacks will set the `Cache-Control` and `Pragma` headers to `no-cache` so that responses will not be cached.

## HTTP response caching headers
Response caching by the middleware is configured via your HTTP response headers. The relevant headers are listed below with notes on how they affect caching.

Header | Details
--- | --- |
Authorization | <p>The response is not cached if the header exists.</p>
Cache-Control | <p>The header must be present and its value must explicitly be marked `public`.</p><p>You can control caching with the following parameters:</p><ul><li>max-age</li><li>max-stale</li><li>min-fresh</li><li>must-revalidate</li><li>no-cache</li><li>no-store</li><li>only-if-cached</li><li>private</li><li>public</li><li>s-maxage</li><li>proxy-revalidate</li></ul>
Pragma | <p>The value must not be `no-cache`.</p><p>Considered for backward compatibility with HTTP/1.0.</p>
Set-Cookie | <p>The response is not cached if the header exists.</p>
Vary | <p>You can vary the cached response by another header. For example, you can cache responses by encoding by including the `Vary: Accept-Encoding` header, which would cache `gzip` and `text/plain` responses separately.</p>
Expires | <p>The response must not be stale given the value provided.</p>
If-None-Match | <p>The response will be served from cache if the value is not `*` and the `ETag` of the response doesn't match any of the values provided. Otherwise, a 304 (Not Modified) response will be served.</p>
If-Modified-Since | <p>If the `If-None-Match` header is not present, a cached response will be served if the cached response date value is less than the value provided.</p>

The middleware sets the following headers when appropriate:
* Date
* Age
* Content-Length

## Additional Resources

* [Application Startup](xref:fundamentals/startup)
* [Middleware](xref:fundamentals/middleware)

