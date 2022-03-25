---
title: Code analysis in ASP.NET Core apps
author: rick-anderson
description: Learn about source code analysis in ASP.NET Core
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.date: 12/17/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: diagnostics/code-analysis
---
# Code analysis in ASP.NET Core apps

.NET compiler platform analyzers inspect application code for code quality and style issues. This document lists only diagnostics for ASP.NET Core. For information on .NET diagnostics, see [Overview of .NET source code analysis](/dotnet/fundamentals/code-analysis/overview).

| Diagnostic ID                       | Breaking or non-breaking | Description                                                                  |
|-------------------------------------|--------------------------|------------------------------------------------------------------------------|
| [ASP0000](xref:diagnostics/asp0000) | Non-breaking             | Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices' |
| [ASP0001](xref:diagnostics/asp0001) | Non-breaking             | Authorization middleware is incorrectly configured                           |
| [ASP0003](xref:diagnostics/asp0003) | Non-breaking             | Do not use model binding attributes with route handlers                      |
| [ASP0004](xref:diagnostics/asp0004) | Non-breaking             | Do not use action results with route handlers                                |
| [ASP0005](xref:diagnostics/asp0005) | Non-breaking             | Do not place attribute on method called by route handler lambda              |
| [ASP0006](xref:diagnostics/asp0006) | Non-breaking             | Do not use non-literal sequence numbers                                      |
| [ASP0007](xref:diagnostics/asp0007) | Non-breaking             | Route parameter and argument optionality is mismatched                       |
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
