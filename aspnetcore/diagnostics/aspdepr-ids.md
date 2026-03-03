---
title: ASPDEPR diagnostics overview
description: Overview of ASPDEPR deprecation diagnostics in ASP.NET Core.
ai-usage: ai-assisted
author: tdykstra
monikerRange: '>= aspnetcore-10.0'
ms.author: tdykstra
ms.date: 03/03/2026
uid: diagnostics/aspdepr-ids
---
# ASPDEPR diagnostics overview

ASPDEPR diagnostics are compile-time warnings issued by the .NET compiler when your code uses ASP.NET Core APIs that have been deprecated. Deprecated APIs are still functional but are scheduled for removal in a future release. Addressing these warnings helps keep your code up to date and ensures a smoother upgrade path.

ASPDEPR diagnostics are similar to the [`SYSLIB` obsoletions](/dotnet/fundamentals/syslib-diagnostics/obsoletions-overview) in .NET, but are specific to ASP.NET Core.

## ASPDEPR diagnostics

The following table lists the ASPDEPR deprecation diagnostics for ASP.NET Core:

| Diagnostic ID | Description |
| - | - |
| [ASPDEPR002](xref:diagnostics/aspdepr002) | `WithOpenApi` is deprecated |
