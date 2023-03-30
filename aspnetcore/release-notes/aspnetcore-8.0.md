---
title: What's new in ASP.NET Core 8.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 8.0.
ms.author: riande
ms.custom: mvc
ms.date: 4/1/2023
uid: aspnetcore-8
---
# What's new in ASP.NET Core 8.0

This article highlights the most significant changes in ASP.NET Core 8.0 with links to relevant documentation.

This article is under development and not complete. More information may be found in the ASP.NET Core 8.0 preview blogs and GitHub issue:

* [ASP.NET Core roadmap for .NET 8 on GitHub](https://github.com/dotnet/aspnetcore/issues/44984) 
* [What’s new in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
* [What’s new in .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-2/)

## Miscellaneous

### Code analysis in ASP.NET Core apps

The following new analyzers are available in ASP.NET Core 8.0

| Diagnostic ID                       | Breaking or non-breaking | Description                                                                  |
|-------------------------------------|--------------------------|------------------------------------------------------------------------------|
| [ASP0000](xref:diagnostics/asp0000) | Non-breaking             | Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices' |
| [ASP0001](xref:diagnostics/asp0001) | Non-breaking             | Authorization middleware is incorrectly configured                           |
| [ASP0003](xref:diagnostics/asp0003) | Non-breaking             | Do not use model binding attributes with route handlers                      |
| [ASP0004](xref:diagnostics/asp0004) | Non-breaking             | Do not use action results with route handlers                                |
| [ASP0005](xref:diagnostics/asp0005) | Non-breaking             | Do not place attribute on method called by route handler lambda              |
| [ASP0006](xref:diagnostics/asp0006) | Non-breaking             | Do not use non-literal sequence numbers                                      |
| [ASP0007](xref:diagnostics/asp0007) | Non-breaking             | Route parameter and argument optionality is mismatched                       |
| [ASP0008](xref:diagnostics/asp0008) | Non-breaking             | Do not use ConfigureWebHost with WebApplicationBuilder.Host                  |
| [ASP0009](xref:diagnostics/asp0009) | Non-breaking             | Do not use Configure with WebApplicationBuilder.WebHost                      |
| [ASP0010](xref:diagnostics/asp0010) | Non-breaking             | Do not use UseStartup with WebApplicationBuilder.WebHost                     |
| [ASP0011](xref:diagnostics/asp0011) | Non-breaking             | Suggest using builder.Logging over Host.ConfigureLogging or WebHost.ConfigureLogging                     |
| [ASP0012](xref:diagnostics/asp0012) | Non-breaking             | Suggest using builder.Services over Host.ConfigureServices or WebHost.ConfigureServices                    |
| [ASP0013](xref:diagnostics/asp0013) | Non-breaking             | Suggest switching from using Configure methods to WebApplicationBuilder.Configuration                     |
| [ASP0014](xref:diagnostics/asp0014) | Non-breaking             | Suggest using top level route registrations                                  |
| [ASP0015](xref:diagnostics/asp0015) | Non-breaking             | Suggest using IHeaderDictionary properties |
| [ASP0016](xref:diagnostics/asp0016) | Non-breaking             | Do not return a value from RequestDelegate |
| [ASP0017](xref:diagnostics/asp0017) | Non-breaking             | Invalid route pattern |
| [ASP0018](xref:diagnostics/asp0018) | Non-breaking             | Unused route parameter |
| [ASP0019](xref:diagnostics/asp0019) | Non-breaking             | Suggest using IHeaderDictionary.Append or the indexer |
| [BL0001](xref:diagnostics/bl0001)   | Breaking                 | Component parameter should have public setters                               |
| [BL0002](xref:diagnostics/bl0002)   | Non-breaking             | Component has multiple CaptureUnmatchedValues parameters                     |
| [BL0003](xref:diagnostics/bl0003)   | Breaking                 | Component parameter with CaptureUnmatchedValues has the wrong type           |
| [BL0004](xref:diagnostics/bl0004)   | Breaking                 | Component parameter should be public                                         |
| [BL0005](xref:diagnostics/bl0005)   | Non-breaking             | Component parameter should not be set outside of its component               |
| [BL0006](xref:diagnostics/bl0006)   | Non-breaking             | Do not use RenderTree types                                                  |
| [MVC1000](xref:diagnostics/mvc1000) | Non-breaking             | Use of IHtmlHelper.Partial should be avoided                                 |
| [MVC1001](xref:diagnostics/mvc1001) | Non-breaking             | Filters cannot be applied to page handler methods                            |
| [MVC1002](xref:diagnostics/mvc1002) | Non-breaking             | Route attributes cannot be applied to page handler methods                   |
| [MVC1003](xref:diagnostics/mvc1003) | Non-breaking             | Route attributes cannot be applied to page models                            |
| [MVC1004](xref:diagnostics/mvc1004) | Breaking                 | Rename model bound parameter                                                 |
| [MVC1005](xref:diagnostics/mvc1005) | Non-breaking             | Cannot use UseMvc with Endpoint Routing                                      |
| [MVC1006](xref:diagnostics/mvc1006) | Breaking                 | Methods containing TagHelpers must be async and return Task                  |

## Blazor

## API controllers

## Minimal APIs

## gRPC


