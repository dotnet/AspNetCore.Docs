---
title: ASP.NET Core Blazor performance best practices
author: guardrex
description: Tips for increasing the performance of ASP.NET Core Blazor apps and avoiding common performance problems.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/16/2025
uid: blazor/performance/index
---
# ASP.NET Core Blazor performance best practices

[!INCLUDE[](~/includes/not-latest-version.md)]

Blazor is optimized for high performance in most realistic application UI scenarios. However, the best performance depends on developers adopting the correct patterns and features.

> [!NOTE]
> The code examples in this node of articles adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core in .NET 6 or later.

:::moniker range=">= aspnetcore-6.0"

## Ahead-of-time (AOT) compilation

Ahead-of-time (AOT) compilation compiles a Blazor app's .NET code directly into native WebAssembly for direct execution by the browser. AOT-compiled apps result in larger apps that take longer to download, but AOT-compiled apps usually provide better runtime performance, especially for apps that execute CPU-intensive tasks. For more information, see <xref:blazor/tooling/webassembly#ahead-of-time-aot-compilation>.

:::moniker-end
