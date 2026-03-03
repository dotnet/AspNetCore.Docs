---
title: ASPDEPR diagnostics overview
description: Overview of ASPDEPR deprecation diagnostics in ASP.NET Core.
ai-usage: ai-assisted
monikerRange: '>= aspnetcore-10.0'
ms.date: 03/03/2026
ms.author: tdykstra
author: tdykstra
uid: diagnostics/aspdepr-ids
---
# ASPDEPR diagnostics overview

ASPDEPR diagnostics are compile-time warnings issued by the .NET compiler when your code uses ASP.NET Core APIs that have been deprecated. Deprecated APIs are still functional but are scheduled for removal in a future release. Addressing these warnings helps keep your code up to date and ensures a smoother upgrade path.

ASPDEPR diagnostics are similar to the [`SYSLIB` obsoletions](/dotnet/fundamentals/syslib-diagnostics/obsoletions-overview) in .NET, but are specific to ASP.NET Core.

> [!NOTE]
> This article is a work-in-progress. It's not a complete list of deprecation diagnostics.

## ASPDEPR diagnostics

The following table lists the `ASPDEPR` deprecation diagnostics for ASP.NET Core:

| Diagnostic ID                             | Description                 |
|-------------------------------------------|-----------------------------|
| [ASPDEPR002](xref:diagnostics/aspdepr002) | `WithOpenApi` is deprecated |
