---
title: Performance Diagnostics Tools
author: mjrousos
description: Useful tools for diagnosing performance issues in ASP.NET Core apps.
monikerRange: '>= aspnetcore-1.1'
ms.author: riande
ms.date: 04/11/2019
uid: performance/diagnostic-tools
---
# Performance Diagnostic Tools

By [Mike Rousos](https://github.com/mjrousos)

This article lists tools for diagnosing performance issues in ASP.NET Core.

## Visual Studio Diagnostic Tools

The [profiling and diagnostic tools](/visualstudio/profiling) built into Visual Studio are a good place to start investigating performance issues. These tools are powerful and convenient to use from the Visual Studio development environment. The tooling allows analysis of CPU usage, memory usage, and performance events in ASP.NET Core apps. Being built-in makes profiling easy at development time.

More information is available in [Visual Studio documentation](/visualstudio/profiling/profiling-overview).

## Application Insights

[Application Insights](/azure/application-insights/app-insights-overview) provides in-depth performance data for your app. Application Insights automatically collects data on response rates, failure rates, dependency response times, and more. Application Insights supports logging custom events and metrics specific to your app.

Azure Application Insights provides multiple ways to give insights on monitored apps:

- [Application Map](/azure/application-insights/app-insights-app-map) – helps spot performance bottlenecks or failure hot-spots across all components of distributed apps.
- [Azure Metrics Explorer](/azure/azure-monitor/platform/metrics-getting-started) is a component of the Microsoft Azure portal that allows plotting charts, visually correlating trends, and investigating spikes and dips in metrics' values.
- [Performance blade in Application Insights portal](/azure/application-insights/app-insights-tutorial-performance):

  - Shows performance details for different operations in the monitored app.
  - Allows drilling into a single operation to check all parts/dependencies that contribute to a long duration.
  - Profiler can be invoked from here to collect performance traces on-demand.

- [Azure Application Insights Profiler](/azure/azure-monitor/app/profiler) allows regular and on-demand profiling of .NET apps.  Azure portal shows captured performance traces with call stacks and hot paths. The trace files can also be downloaded for deeper analysis using PerfView.

Application Insights can be used in a variety of environments:

- Optimized to work in Azure.
- Works in production, development, and staging.
- Works locally from [Visual Studio](/azure/application-insights/app-insights-visual-studio) or in other hosting environments.

For more information on code-based monitoring, see [Application Insights for ASP.NET Core](/azure/application-insights/app-insights-asp-net-core). For more information on codeless monitoring, see [Monitor Azure App Service performance](/azure/azure-monitor/app/azure-web-apps?tabs=netcore).

## PerfView

[PerfView](https://github.com/Microsoft/perfview) is a performance analysis tool created by the .NET team specifically for diagnosing .NET performance issues. PerfView allows analysis of CPU usage, memory and GC behavior, performance events, and wall clock time.

For more about PerfView, see the user's guide available in the tool or [on GitHub](https://github.com/Microsoft/perfview).

## Windows Performance Toolkit

[Windows Performance Toolkit](/windows-hardware/test/wpt/) (WPT) consists of two components: Windows Performance Recorder (WPR) and Windows Performance Analyzer (WPA). The tools produce in-depth performance profiles of Windows operating systems and apps. WPT has richer ways of visualizing data, but its data collecting is less powerful than PerfView's.

## PerfCollect

While PerfView is a useful performance analysis tool for .NET scenarios, it only runs on Windows, so you can't use it to collect traces from ASP.NET Core apps running in Linux environments.

[PerfCollect](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/linux-performance-tracing.md) is a bash script that uses native Linux profiling tools ([Perf](https://perf.wiki.kernel.org/index.php/Main_Page) and [LTTng](https://lttng.org/)) to collect traces on Linux that can be analyzed by PerfView. PerfCollect is useful when performance problems show up in Linux environments where PerfView can't be used directly. Instead, PerfCollect can collect traces from .NET Core apps that are then analyzed on a Windows computer using PerfView.

More information about how to install and get started with PerfCollect is available [on GitHub](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/linux-performance-tracing.md).

## Other Third-party Performance Tools

The following lists some third-party performance tools that are useful in performance investigation of .NET Core applications.

- [MiniProfiler](https://miniprofiler.com/)
- [dotTrace](https://www.jetbrains.com/profiler/) and [dotMemory](https://www.jetbrains.com/dotmemory/) from [JetBrains](https://www.jetbrains.com/)
- [VTune](https://software.intel.com/content/www/us/en/develop/tools/vtune-profiler.html) from Intel
