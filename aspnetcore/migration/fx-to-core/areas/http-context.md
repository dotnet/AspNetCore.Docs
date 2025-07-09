---
title: Migrate from System.Web.HttpContext to Micrsoft.AspNetCore.Http.HttpContext
description: Learn how to migrate from System.Web.HttpContext to Micrsoft.AspNetCore.Http.HttpContext
author: twsouthwick
ms.author: tasou
ms.date: 6/20/2025
uid: migration/fx-to-core/areas/http-context
---
# Migrate from System.Web.HttpContext to Micrsoft.AspNetCore.Http.HttpContext

This article shows how to translate the most commonly used properties of <xref:System.Web.HttpContext?displayProperty=fullName> to the equivalent <xref:Microsoft.AspNetCore.Http.HttpContext?displayProperty=fullName> in ASP.NET Core.

## Overview

`HttpContext` has significantly changed in ASP.NET Core. When migrating HTTP modules or handlers to middleware, you'll need to update your code to work with the new `HttpContext` API.

In ASP.NET Core middleware, the `Invoke` method takes a parameter of type `HttpContext`:

```csharp
public async Task Invoke(HttpContext context)
```

This `HttpContext` is different from the ASP.NET Framework version and requires different approaches to access request and response information.

## HttpContext

**HttpContext.Items** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Items)]

**Unique request ID (no System.Web.HttpContext counterpart)**

Gives you a unique id for each request. Very useful to include in your logs.

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Trace)]

## HttpContext.Request

**HttpContext.Request.HttpMethod** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Method)]

**HttpContext.Request.QueryString** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Query)]

**HttpContext.Request.Url** and **HttpContext.Request.RawUrl** translate to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Url)]

**HttpContext.Request.IsSecureConnection** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Secure)]

**HttpContext.Request.UserHostAddress** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Host)]

**HttpContext.Request.Cookies** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Cookies)]

**HttpContext.Request.RequestContext.RouteData** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Route)]

**HttpContext.Request.Headers** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Headers)]

**HttpContext.Request.UserAgent** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Agent)]

**HttpContext.Request.UrlReferrer** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Referrer)]

**HttpContext.Request.ContentType** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Type)]

**HttpContext.Request.Form** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Form)]

> [!WARNING]
> Read form values only if the content sub type is *x-www-form-urlencoded* or *form-data*.

**HttpContext.Request.InputStream** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Input)]

> [!WARNING]
> Use this code only in a handler type middleware, at the end of a pipeline.
>
>You can read the raw body as shown above only once per request. Middleware trying to read the body after the first read will read an empty body.
>
>This doesn't apply to reading a form as shown earlier, because that's done from a buffer.

## HttpContext.Response

**HttpContext.Response.Status** and **HttpContext.Response.StatusDescription** translate to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Status)]

**HttpContext.Response.ContentEncoding** and **HttpContext.Response.ContentType** translate to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_RespType)]

**HttpContext.Response.ContentType** on its own also translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_RespTypeOnly)]

**HttpContext.Response.Output** translates to:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Output)]

**HttpContext.Response.TransmitFile**

Serving up a file is discussed in <xref:fundamentals/request-features>.

**HttpContext.Response.Headers**

Sending response headers is complicated by the fact that if you set them after anything has been written to the response body, they will not be sent.

The solution is to set a callback method that will be called right before writing to the response starts. This is best done at the start of the `Invoke` method in your middleware. It's this callback method that sets your response headers.

The following code sets a callback method called `SetHeaders`:

```csharp
public async Task Invoke(HttpContext httpContext)
{
    // ...
    httpContext.Response.OnStarting(SetHeaders, state: httpContext);
```

The `SetHeaders` callback method would look like this:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_SetHeaders)]

**HttpContext.Response.Cookies**

Cookies travel to the browser in a *Set-Cookie* response header. As a result, sending cookies requires the same callback as used for sending response headers:

```csharp
public async Task Invoke(HttpContext httpContext)
{
    // ...
    httpContext.Response.OnStarting(SetCookies, state: httpContext);
    httpContext.Response.OnStarting(SetHeaders, state: httpContext);
```

The `SetCookies` callback method would look like the following:

[!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_SetCookies)]

## Additional resources

* [HTTP Handlers and HTTP Modules Overview](/iis/configuration/system.webserver/)
* [HttpContext in ASP.NET Core](xref:fundamentals/httpcontext)
* [Middleware](xref:fundamentals/middleware/index)
* [Configuration](xref:fundamentals/configuration/index)
