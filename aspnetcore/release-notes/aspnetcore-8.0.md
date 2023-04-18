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
<!-- The next update of this needs to add this topic to the TOC -->
This article highlights the most significant changes in ASP.NET Core 8.0 with links to relevant documentation.

This article is under development and not complete. More information may be found in the ASP.NET Core 8.0 preview blogs and GitHub issue:

* [ASP.NET Core roadmap for .NET 8 on GitHub](https://github.com/dotnet/aspnetcore/issues/44984) 
* [What’s new in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
* [What’s new in .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-2/)

## Blazor

## Miscellaneous

### Support for native AOT

Support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/) has been added. For more information, see [ASP.NET Core support for native AOT](xref:fundamentals/native-aot).

### Code analysis in ASP.NET Core apps

The following new analyzers are available in ASP.NET Core 8.0:

| Diagnostic ID    | Breaking or non-breaking | Description |
|-------|-------|----------------------------|
| [ASP0020](xref:diagnostics/asp0020) | Non-breaking             | Complex types referenced by route parameters must be parsable |
| [ASP0021](xref:diagnostics/asp0021) | Non-breaking             | The return type of the BindAsync method must be `ValueTask<T>` |
| [ASP0022](xref:diagnostics/asp0022) | Non-breaking             | Route conflict detected between route handlers |
| [ASP0023](xref:diagnostics/asp0023) | Non-breaking             | MVC: Route conflict detected between route handlers |
| [ASP0024](xref:diagnostics/asp0024) | Non-breaking             | Route handler has multiple parameters with the `[FromBody]` attribute |
<!--
## API controllers

## Minimal APIs

## gRPC
-->