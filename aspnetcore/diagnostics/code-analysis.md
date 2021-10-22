---
title: Code analysis in ASP.NET Core apps
author: rick-anderson
description: Learn about source code analysis in ASP.NET Core 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.date: 10/15/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: diagnostics/code-analysis
---
# Code analysis in ASP.NET Core apps

.NET compiler platform analyzers inspect application code for code quality and style issues. This document lists only diagnostics for ASP.NET Core. For information on .NET diagnostics, see [Overview of .NET source code analysis](/dotnet/fundamentals/code-analysis/overview).

| Diagnostic ID | Breaking or non-breaking | Description |
| - | - | - |
| [ASP0004](xref:diagnostics/asp0004) | Non-breaking | Do not use action results with route handlers |
| [ASP0005](xref:diagnostics/asp0005) | Non-breaking | Do not place attribute on method called by route handler lambda |
| [ASP0007](xref:diagnostics/asp0007) | Non-breaking |Route parameter and argument optionality is mismatched |
| [MVC1000](xref:diagnostics/mvc1000) | Non-breaking | Use of IHtmlHelper.Partial should be avoided |
| [MVC1001](xref:diagnostics/mvc1001) | Non-breaking | Filters cannot be applied to page handler methods |
