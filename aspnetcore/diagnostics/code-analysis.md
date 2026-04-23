---
title: Diagnostic Code Analysis in ASP.NET Core Apps
author: tdykstra
description: Review the list of diagnostic codes for ASP.NET Core and get details for specific diagnostic identifiers (IDs), such as ASP0007, BL0001, and MVC1006.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.date: 04/22/2026
uid: diagnostics/code-analysis

# customer intent: As an ASP.NET developer, I want to get details for specific diagnostic codes in ASP.NET Core, so I can understand the diagnostic messages in my apps.
---

# Diagnostic code analysis in ASP.NET Core apps

.NET compiler platform analyzers inspect application code for code quality and style issues.

This article provides links to specific diagnostic messages for ASP.NET Core. For more information on .NET diagnostics, see [Overview of .NET source code analysis](/dotnet/fundamentals/code-analysis/overview).

## Diagnostic codes

The following table lists the diagnostics available for ASP.NET Core applications.

> [!NOTE]
> Not all diagnostics are available in older versions of ASP.NET Core.

| Diagnostic ID | Message |
| --- | --- |
| **[ASP0000](xref:diagnostics/asp0000)** | Don't call `IServiceCollection.BuildServiceProvider` in `ConfigureServices` |
| **[ASP0001](xref:diagnostics/asp0001)** | Authorization middleware is incorrectly configured |
| **[ASP0003](xref:diagnostics/asp0003)** | Don't use model binding attributes with route handlers |
| **[ASP0004](xref:diagnostics/asp0004)** | Don't use action results with route handlers |
| **[ASP0005](xref:diagnostics/asp0005)** | Don't place attribute on method called by route handler lambda |
| **[ASP0006](xref:diagnostics/asp0006)** | Don't use nonliteral sequence numbers |
| **[ASP0007](xref:diagnostics/asp0007)** | Route parameter and argument optionality is mismatched |
| **[ASP0008](xref:diagnostics/asp0008)** | Don't use `ConfigureWebHost` with `WebApplicationBuilder.Host` |
| **[ASP0009](xref:diagnostics/asp0009)** | Don't use `Configure` with `WebApplicationBuilder.WebHost` |
| **[ASP0010](xref:diagnostics/asp0010)** | Don't use `UseStartup` with `WebApplicationBuilder.WebHost` |
| **[ASP0011](xref:diagnostics/asp0011)** | Suggest using `builder.Logging` over `Host.ConfigureLogging` or `WebHost.ConfigureLogging` |
| **[ASP0012](xref:diagnostics/asp0012)** | Suggest using `builder.Services` over `Host.ConfigureServices` or `WebHost.ConfigureServices` |
| **[ASP0013](xref:diagnostics/asp0013)** | Suggest switching from using `Configure` methods to `WebApplicationBuilder.Configuration` |
| **[ASP0014](xref:diagnostics/asp0014)** | Suggest using top level route registrations |
| **[ASP0015](xref:diagnostics/asp0015)** | Suggest using `IHeaderDictionary` properties |
| **[ASP0016](xref:diagnostics/asp0016)** | Don't return a value from `RequestDelegate` |
| **[ASP0017](xref:diagnostics/asp0017)** | Invalid route pattern |
| **[ASP0018](xref:diagnostics/asp0018)** | Unused route parameter |
| **[ASP0019](xref:diagnostics/asp0019)** | Suggest using `IHeaderDictionary.Append` or the indexer |
| **[ASP0020](xref:diagnostics/asp0020)** | Complex types referenced by route parameters must be parsable |
| **[ASP0021](xref:diagnostics/asp0021)** | Return type of the `BindAsync` method must be `ValueTask<T>` |
| **[ASP0022](xref:diagnostics/asp0022)** | Route conflict detected between route handlers ([Minimal API apps](/aspnet/core/fundamentals/apis)) |
| **[ASP0023](xref:diagnostics/asp0023)** | Route conflict detected between route handlers |
| **[ASP0024](xref:diagnostics/asp0024)** | Route handler has multiple parameters with the `[FromBody]` attribute |
| **[ASP0025](xref:diagnostics/asp0025)** | Use `AddAuthorizationBuilder` to register authorization services and construct policies |
| **[ASP0026](xref:diagnostics/asp0026)** | `[Authorize]` is overridden by `[AllowAnonymous]` from "farther away" |
| **[ASP0027](xref:diagnostics/asp0027)** | Unnecessary `public Program` class declaration |
| **[ASP0028](xref:diagnostics/asp0028)** | Consider using `IPAddress.IPv6Any` instead of `IPAddress.Any` |
| **[BL0001](xref:diagnostics/bl0001)**   | Component parameter should have public setters |
| **[BL0002](xref:diagnostics/bl0002)**   | Component has multiple `CaptureUnmatchedValues` parameters |
| **[BL0003](xref:diagnostics/bl0003)**   | Component parameter with `CaptureUnmatchedValues` has the wrong type |
| **[BL0004](xref:diagnostics/bl0004)**   | Component parameter should be public |
| **[BL0005](xref:diagnostics/bl0005)**   | Component parameter shouldn't be set outside of its component |
| **[BL0006](xref:diagnostics/bl0006)**   | Don't use RenderTree types |
| **[BL0007](xref:diagnostics/bl0007)**   | Component parameter `{0}` should be auto property |
| **[BL0008](xref:diagnostics/bl0008)**   | Component parameters should be auto properties |
| **[MVC1000](xref:diagnostics/mvc1000)** | Use of `IHtmlHelper.Partial` should be avoided |
| **[MVC1001](xref:diagnostics/mvc1001)** | Filters can't be applied to page handler methods |
| **[MVC1002](xref:diagnostics/mvc1002)** | Route attribute can't be applied to page handler methods |
| **[MVC1003](xref:diagnostics/mvc1003)** | Route attributes can't be applied to page models |
| **[MVC1004](xref:diagnostics/mvc1004)** | Rename model bound parameter |
| **[MVC1005](xref:diagnostics/mvc1005)** | Can't use `UseMvc` with Endpoint Routing |
| **[MVC1006](xref:diagnostics/mvc1006)** | Methods containing Tag Helpers (`TagHelpers`) must be async and return `Task` |

## Related content

- [Overview of .NET source code analysis](/dotnet/fundamentals/code-analysis/overview)