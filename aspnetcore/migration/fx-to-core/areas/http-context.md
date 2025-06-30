---
title: Migrate ASP.NET Framework HttpContext to ASP.NET Core
description: Learn how to migrate from System.Web.HttpContext to Microsoft.AspNetCore.Http.HttpContext
author: twsouthwick
ms.author: tasou
ms.date: 6/20/2025
uid: migration/fx-to-core/areas/http-context
---
# Migrate ASP.NET Framework HttpContext to ASP.NET Core

HttpContext is a fundamental component of web applications, providing access to HTTP request and response information. When migrating from ASP.NET Framework to ASP.NET Core, HttpContext presents unique challenges because the two frameworks have different APIs and approaches.

## Why HttpContext migration is complex

ASP.NET Framework and ASP.NET Core have fundamentally different HttpContext implementations:

* **ASP.NET Framework** uses <xref:System.Web.HttpContext?displayProperty=fullName> with built-in properties and methods
* **ASP.NET Core** uses <xref:Microsoft.AspNetCore.Http.HttpContext?displayProperty=fullName> with a more modular, extensible design

These differences mean you can't simply move your HttpContext code from Framework to Core without changes.

## Migration strategies overview

You have two main approaches for handling HttpContext during migration:

1. **Complete rewrite** - Rewrite all HttpContext code to use ASP.NET Core's native HttpContext implementation
2. **System.Web adapters** - Use adapters to minimize code changes while migrating incrementally

For most applications, migrating to ASP.NET Core's native HttpContext provides the best performance and maintainability. However, larger applications or those with extensive HttpContext usage may benefit from using System.Web adapters during incremental migration.

## Choose your migration approach

You have two main options for migrating HttpContext from ASP.NET Framework to ASP.NET Core. Your choice depends on your migration timeline, whether you need to run both applications simultaneously, and how much code you're willing to rewrite.

### Quick decision guide

**Answer these questions to choose your approach:**

1. **Are you doing a complete rewrite or incremental migration?**
   * Complete rewrite → [Complete rewrite to ASP.NET Core HttpContext](#complete-rewrite-to-aspnet-core-httpcontext)
   * Incremental migration → Continue to question 2

2. **Do you have extensive HttpContext usage across shared libraries?** 
   * Yes, lots of shared code → [System.Web adapters](#systemweb-adapters)
   * No, isolated HttpContext usage → [Complete rewrite to ASP.NET Core HttpContext](#complete-rewrite-to-aspnet-core-httpcontext)

### Migration approaches comparison

| Approach | Code Changes | Performance | Shared Libraries | When to Use |
|----------|-------------|-------------|------------------|-------------|
| **[Complete rewrite](#complete-rewrite-to-aspnet-core-httpcontext)** | High - Rewrite all HttpContext code | Best | Requires updates | Complete rewrites, performance-critical apps |
| **[System.Web adapters](#systemweb-adapters)** | Low - Keep existing patterns | Good | Works with existing code | Incremental migrations, extensive HttpContext usage |

## Complete rewrite to ASP.NET Core HttpContext

Choose this approach when you're performing a complete migration and can rewrite HttpContext-related code to use ASP.NET Core's native implementation.

ASP.NET Core's HttpContext provides a more modular and extensible design compared to ASP.NET Framework. This approach offers the best performance but requires more code changes during migration.

### Overview

`HttpContext` has significantly changed in ASP.NET Core. When migrating HTTP modules or handlers to middleware, you'll need to update your code to work with the new `HttpContext` API.

In ASP.NET Core middleware, the `Invoke` method takes a parameter of type `HttpContext`:

```csharp
public async Task Invoke(HttpContext context)
```

This `HttpContext` is different from the ASP.NET Framework version and requires different approaches to access request and response information.

### Property translations

This section shows how to translate the most commonly used properties of <xref:System.Web.HttpContext?displayProperty=fullName> to the equivalent <xref:Microsoft.AspNetCore.Http.HttpContext?displayProperty=fullName> in ASP.NET Core.

#### HttpContext properties

| ASP.NET Framework | ASP.NET Core | Code Sample | Notes |
|-------------------|--------------|-------------|-------|
| <xref:System.Web.HttpContext.Items> | <xref:Microsoft.AspNetCore.Http.HttpContext.Items> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Items)] | Works the same way |
| *No equivalent* | <xref:Microsoft.AspNetCore.Http.HttpContext.TraceIdentifier> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Trace)] | Unique request ID for logging |

#### HttpRequest properties

| ASP.NET Framework | ASP.NET Core | Code Sample | Notes |
|-------------------|--------------|-------------|-------|
| <xref:System.Web.HttpRequest.HttpMethod> | <xref:Microsoft.AspNetCore.Http.HttpRequest.Method> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Method)] | |
| <xref:System.Web.HttpRequest.QueryString> | <xref:Microsoft.AspNetCore.Http.HttpRequest.QueryString> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Query)] | |
| <xref:System.Web.HttpRequest.Url><br/><xref:System.Web.HttpRequest.RawUrl> | Multiple properties | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Url)] | Use Request.Scheme, Host, PathBase, Path, QueryString |
| <xref:System.Web.HttpRequest.IsSecureConnection> | <xref:Microsoft.AspNetCore.Http.HttpRequest.IsHttps> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Secure)] | |
| <xref:System.Web.HttpRequest.UserHostAddress> | <xref:Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Host)] | |
| <xref:System.Web.HttpRequest.Cookies> | <xref:Microsoft.AspNetCore.Http.HttpRequest.Cookies> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Cookies)] | |
| <xref:System.Web.HttpRequest.RequestContext> | <xref:Microsoft.AspNetCore.Http.HttpContextExtensions.GetRouteData*> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Route)] | |
| <xref:System.Web.HttpRequest.Headers> | <xref:Microsoft.AspNetCore.Http.HttpRequest.Headers> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Headers)] | |
| <xref:System.Web.HttpRequest.UserAgent> | <xref:Microsoft.AspNetCore.Http.HttpRequest.Headers> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Agent)] | Access via Headers["User-Agent"] |
| <xref:System.Web.HttpRequest.UrlReferrer> | <xref:Microsoft.AspNetCore.Http.HttpRequest.Headers> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Referrer)] | Access via Headers["Referer"] |
| <xref:System.Web.HttpRequest.ContentType> | <xref:Microsoft.AspNetCore.Http.HttpRequest.ContentType> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Type)] | |
| <xref:System.Web.HttpRequest.Form> | <xref:Microsoft.AspNetCore.Http.HttpRequest.Form> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Form)] | **Warning**: Read form values only if content type is *x-www-form-urlencoded* or *form-data* |
| <xref:System.Web.HttpRequest.InputStream> | <xref:Microsoft.AspNetCore.Http.HttpRequest.Body> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Input)] | **Warning**: Use only in handler middleware at end of pipeline. Body can only be read once per request |

#### HttpResponse properties

| ASP.NET Framework | ASP.NET Core | Code Sample | Notes |
|-------------------|--------------|-------------|-------|
| <xref:System.Web.HttpResponse.Status><br/><xref:System.Web.HttpResponse.StatusDescription> | <xref:Microsoft.AspNetCore.Http.HttpResponse.StatusCode> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Status)] | |
| <xref:System.Web.HttpResponse.ContentEncoding><br/><xref:System.Web.HttpResponse.ContentType> | <xref:Microsoft.AspNetCore.Http.HttpResponse.ContentType> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_RespType)] | |
| <xref:System.Web.HttpResponse.ContentType> | <xref:Microsoft.AspNetCore.Http.HttpResponse.ContentType> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_RespTypeOnly)] | |
| <xref:System.Web.HttpResponse.Output> | <xref:Microsoft.AspNetCore.Http.HttpResponse.WriteAsync*> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_Output)] | |
| <xref:System.Web.HttpResponse.TransmitFile*> | See request features | | Serving files is discussed in <xref:fundamentals/request-features> |
| <xref:System.Web.HttpResponse.Headers> | <xref:Microsoft.AspNetCore.Http.HttpResponse.OnStarting*> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_SetHeaders)] | Must use callback pattern to set headers before response starts |
| <xref:System.Web.HttpResponse.Cookies> | <xref:Microsoft.AspNetCore.Http.HttpResponse.OnStarting*> | [!code-csharp[](sample/Asp.Net.Core/Middleware/HttpContextDemoMiddleware.cs?name=snippet_SetCookies)] | Must use callback pattern to set cookies before response starts |

#### Response headers and cookies patterns

Since response headers and cookies require special handling in ASP.NET Core, here are the patterns:

**Setting response headers:**

```csharp
public async Task Invoke(HttpContext httpContext)
{
    // Set callback to execute before response starts
    httpContext.Response.OnStarting(SetHeaders, state: httpContext);
    // ... rest of middleware logic
}
```

**Setting response cookies:**

```csharp
public async Task Invoke(HttpContext httpContext)
{
    // Set callbacks to execute before response starts
    httpContext.Response.OnStarting(SetCookies, state: httpContext);
    httpContext.Response.OnStarting(SetHeaders, state: httpContext);
    // ... rest of middleware logic
}
```

## System.Web adapters

[!INCLUDE[](~/migration/fx-to-core/includes/uses-systemweb-adapters.md)]

Choose this approach when you have extensive HttpContext usage across shared libraries or when performing an incremental migration where you want to minimize code changes.

The [System.Web adapters](~/migration/fx-to-core/inc/systemweb-adapters.md) provide a compatibility layer that allows you to use familiar <xref:System.Web.HttpContext> APIs in ASP.NET Core applications. This approach is particularly useful when:

* You have shared libraries that use <xref:System.Web.HttpContext>
* You're performing an incremental migration
* You want to minimize code changes during the migration process

### Benefits of using System.Web adapters

* **Minimal code changes**: Keep your existing `System.Web.HttpContext` usage patterns
* **Shared libraries**: Libraries can work with both ASP.NET Framework and ASP.NET Core
* **Incremental migration**: Migrate applications piece by piece without breaking shared dependencies
* **Faster migration**: Reduce the time needed to migrate complex applications

### Considerations

* **Performance**: While good, adapters introduce some overhead compared to native ASP.NET Core APIs
* **Feature parity**: Not all <xref:System.Web.HttpContext> features are available through adapters
* **Long-term strategy**: Consider eventually migrating to native ASP.NET Core APIs for best performance

For more information about System.Web adapters, see the [System.Web adapters documentation](~/migration/fx-to-core/inc/systemweb-adapters.md).

## Additional resources

* [HTTP Handlers and HTTP Modules Overview](/iis/configuration/system.webserver/)
* [HttpContext in ASP.NET Core](xref:fundamentals/httpcontext)
* [Middleware](xref:fundamentals/middleware/index)
* [Configuration](xref:fundamentals/configuration/index)
* [System.Web adapters](~/migration/fx-to-core/inc/systemweb-adapters.md)
