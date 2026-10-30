---
title: Diagnostic Code Analysis in ASP.NET Core Apps
description: Review the list of diagnostic codes for ASP.NET Core and get details for specific diagnostic identifiers (IDs), such as ASP0007, BL0001, and MVC1006.
monikerRange: '>= aspnetcore-3.1'
ms.date: 08/25/2026

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
| **[ASP0000](asp0000.md)** | Don't call `IServiceCollection.BuildServiceProvider` in `ConfigureServices` |
| **[ASP0001](asp0001.md)** | Authorization middleware is incorrectly configured |
| **[ASP0003](asp0003.md)** | Don't use model binding attributes with route handlers |
| **[ASP0004](asp0004.md)** | Don't use action results with route handlers |
| **[ASP0005](asp0005.md)** | Don't place attribute on method called by route handler lambda |
| **[ASP0006](asp0006.md)** | Don't use nonliteral sequence numbers |
| **[ASP0007](asp0007.md)** | Route parameter and argument optionality is mismatched |
| **[ASP0008](asp0008.md)** | Don't use `ConfigureWebHost` with `WebApplicationBuilder.Host` |
| **[ASP0009](asp0009.md)** | Don't use `Configure` with `WebApplicationBuilder.WebHost` |
| **[ASP0010](asp0010.md)** | Don't use `UseStartup` with `WebApplicationBuilder.WebHost` |
| **[ASP0011](asp0011.md)** | Suggest using `builder.Logging` over `Host.ConfigureLogging` or `WebHost.ConfigureLogging` |
| **[ASP0012](asp0012.md)** | Suggest using `builder.Services` over `Host.ConfigureServices` or `WebHost.ConfigureServices` |
| **[ASP0013](asp0013.md)** | Suggest switching from using `Configure` methods to `WebApplicationBuilder.Configuration` |
| **[ASP0014](asp0014.md)** | Suggest using top level route registrations |
| **[ASP0015](asp0015.md)** | Suggest using `IHeaderDictionary` properties |
| **[ASP0016](asp0016.md)** | Don't return a value from `RequestDelegate` |
| **[ASP0017](asp0017.md)** | Invalid route pattern |
| **[ASP0018](asp0018.md)** | Unused route parameter |
| **[ASP0019](asp0019.md)** | Suggest using `IHeaderDictionary.Append` or the indexer |
| **[ASP0020](asp0020.md)** | Complex types referenced by route parameters must be parsable |
| **[ASP0021](asp0021.md)** | Return type of the `BindAsync` method must be `ValueTask<T>` |
| **[ASP0022](asp0022.md)** | Route conflict detected between route handlers ([Minimal API apps](/aspnet/core/fundamentals/apis)) |
| **[ASP0023](asp0023.md)** | Route conflict detected between route handlers |
| **[ASP0024](asp0024.md)** | Route handler has multiple parameters with the `[FromBody]` attribute |
| **[ASP0025](asp0025.md)** | Use `AddAuthorizationBuilder` to register authorization services and construct policies |
| **[ASP0026](asp0026.md)** | `[Authorize]` is overridden by `[AllowAnonymous]` from "farther away" |
| **[ASP0027](asp0027.md)** | Unnecessary `public Program` class declaration |
| **[ASP0028](asp0028.md)** | Consider using `IPAddress.IPv6Any` instead of `IPAddress.Any` |
| **[ASP0033](asp0033.md)** | `[ValidatableType]` is applied to an inaccessible type |
| **[ASP0034](asp0034.md)** | Endpoint parameter type is inaccessible from generated code |
| **[ASP0035](asp0035.md)** | Validatable property or its type on a `[ValidatableType]` is not accessible |
| **[ASP0036](asp0036.md)** | Validatable property or its type on an endpoint parameter type is not accessible |
| **[ASP0037](asp0037.md)** | `[ValidatableType]` cannot be used in generated code |
| **[ASP0038](asp0038.md)** | `[ValidatableType]` should not be used without a call to `AddValidation` |
| **[BL0001](bl0001.md)**   | Component parameter should have public setters |
| **[BL0002](bl0002.md)**   | Component has multiple `CaptureUnmatchedValues` parameters |
| **[BL0003](bl0003.md)**   | Component parameter with `CaptureUnmatchedValues` has the wrong type |
| **[BL0004](bl0004.md)**   | Component parameter should be public |
| **[BL0005](bl0005.md)**   | Component parameter shouldn't be set outside of its component |
| **[BL0006](bl0006.md)**   | Don't use RenderTree types |
| **[BL0007](bl0007.md)**   | Component parameter `{0}` should be auto property |
| **[BL0008](bl0008.md)**   | Component parameters should be auto properties |
| **[MVC1000](mvc1000.md)** | Use of `IHtmlHelper.Partial` should be avoided |
| **[MVC1001](mvc1001.md)** | Filters can't be applied to page handler methods |
| **[MVC1002](mvc1002.md)** | Route attribute can't be applied to page handler methods |
| **[MVC1003](mvc1003.md)** | Route attributes can't be applied to page models |
| **[MVC1004](mvc1004.md)** | Rename model bound parameter |
| **[MVC1005](mvc1005.md)** | Can't use `UseMvc` with Endpoint Routing |
| **[MVC1006](mvc1006.md)** | Methods containing Tag Helpers (`TagHelpers`) must be async and return `Task` |

## Related content

- [Overview of .NET source code analysis](/dotnet/fundamentals/code-analysis/overview)