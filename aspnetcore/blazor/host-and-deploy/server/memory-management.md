---
title: Manage memory in deployed ASP.NET Core server-side Blazor apps
author: guardrex
description: Learn how to manage memory use in deployed ASP.NET Core server-side Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 03/31/2025
uid: blazor/host-and-deploy/server/memory-management
---
# Manage memory in deployed ASP.NET Core server-side Blazor apps

This article explains how to manage memory use in deployed ASP.NET Core server-side Blazor apps.

On the server, a new circuit is created for each user session. Each user session corresponds to rendering a single document in the browser. For example, multiple tabs create multiple sessions.

Blazor maintains a constant connection to the browser, called a *circuit*, that initiated the session. Connections can be lost at any time for any of several reasons, such as when the user loses network connectivity or abruptly closes the browser. When a connection is lost, Blazor has a recovery mechanism that places a limited number of circuits in a "disconnected" pool, giving clients a limited amount of time to reconnect and re-establish the session (default: 3 minutes).

After that time, Blazor releases the circuit and discards the session. From that point on, the circuit is eligible for garbage collection (GC) and is claimed when a collection for the circuit's GC generation is triggered. One important aspect to understand is that circuits have a long lifetime, which means that most of the objects rooted by the circuit eventually reach Gen 2. As a result, you might not see those objects released until a Gen 2 collection happens.

## Measure memory usage in general

Prerequisites:

* The app must be published in **Release** configuration. **Debug** configuration measurements aren't relevant, as the generated code isn't representative of the code used for a production deployment.
* The app must run without a debugger attached, as this might also affect the behavior of the app and spoil the results. In Visual Studio, start the app without debugging by selecting **Debug** > **Start Without Debugging** from the menu bar or <kbd>Ctrl</kbd>+<kbd>F5</kbd> using the keyboard.
* Consider the different types of memory to understand how much memory is actually used by .NET. Generally, developers inspect app memory usage in Task Manager on Windows OS, which typically offers an upper bound of the actual memory in use. For more information, consult the following articles:
  * [.NET Memory Performance Analysis](https://github.com/Maoni0/mem-doc/blob/master/doc/.NETMemoryPerformanceAnalysis.md): In particular, see the section on [Memory Fundamentals](https://github.com/Maoni0/mem-doc/blob/master/doc/.NETMemoryPerformanceAnalysis.md#Memory-Fundamentals).
  * [Work flow of diagnosing memory performance issues (three-part series)](https://devblogs.microsoft.com/dotnet/work-flow-of-diagnosing-memory-performance-issues-part-0/): Links to the three articles of the series are at the top of each article in the series.

## Memory usage applied to Blazor

We compute the memory used by blazor as follows:

(**Active Circuits** × **Per-circuit Memory**) + (**Disconnected Circuits** × **Per-circuit Memory**)

The amount of memory a circuit uses and the maximum potential active circuits that an app can maintain is largely dependent on how the app is written. The maximum number of possible active circuits is roughly described by:

**Maximum Available Memory** / **Per-circuit Memory** = **Maximum Potential Active Circuits**

For a memory leak to occur in Blazor, the following must be true:

* The memory must be allocated by the framework, not the app. If you allocate a 1 GB array in the app, the app must manage the disposal of the array.
* The memory must not be actively used, which means the circuit isn't active and has been evicted from the disconnected circuits cache. If you have the maximum active circuits running, running out of memory is a scale issue, not a memory leak.
* A garbage collection (GC) for the circuit's GC generation has run, but the garbage collector hasn't been able to claim the circuit because another object in the framework is holding a strong reference to the circuit.

In other cases, there's no memory leak. If the circuit is active (connected or disconnected), the circuit is still in use.

If a collection for the circuit's GC generation doesn't run, the memory isn't released because the garbage collector doesn't need to free the memory at that time.

If a collection for a GC generation runs and frees the circuit, you must validate the memory against the GC stats, not the process, as .NET might decide to keep the virtual memory active.

If the memory isn't freed, you must find a circuit that isn't either active or disconnected and that's rooted by another object in the framework. In any other case, the inability to free memory is an app issue in developer code.

## Reduce memory usage

Adopt any of the following strategies to reduce an app's memory usage:

* Publish the app in Release configuration.
* Run a published version of the app.
* Don't attach a debugger to the running app.
* Does triggering a Gen 2 forced, compacting collection (`GC.Collect(2, GCCollectionMode.Aggressive | GCCollectionMode.Forced, blocking: true, compacting: true))` free the memory?
* Consider if your app is allocating objects on the large object heap.
* Are you testing the memory growth after the app is warmed up with requests and processing? Typically, there are caches that are populated when code executes for the first time that add a constant amount of memory to the footprint of the app.
* Limit the total amount of memory used by the .NET process. For more information, see [Runtime configuration options for garbage collection](/dotnet/core/runtime-config/garbage-collector).
* Reduce the number of disconnected circuits.
* Reduce the time a circuit is allowed to be in the disconnected state.
* Trigger a garbage collection manually to perform a collection during downtime periods.
* Configure the garbage collection in Workstation mode, which aggressively triggers garbage collection, instead of Server mode.

## Heap size for some mobile device browsers

When building a Blazor app that runs on the client and targets mobile device browsers, especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required. For more information, see <xref:blazor/host-and-deploy/webassembly/index#decrease-maximum-heap-size-for-some-mobile-device-browsers>.

##  Additional actions and considerations

* Capture a memory dump of the process when memory demands are high and identify the objects are taking the most memory and where are those objects are rooted (what holds a reference to them).
* You can examine the statistics on how memory in your app is behaving using `dotnet-counters`. For more information see [Investigate performance counters (dotnet-counters)](/dotnet/core/diagnostics/dotnet-counters).
* Even when a GC is triggered, .NET holds on to the memory instead of returning it to the OS immediately, as it's likely that it will reuse the memory the near future. This avoids committing and decommitting memory constantly, which is expensive. You'll see this reflected if you use `dotnet-counters` because you'll see the GCs happen and the amount of used memory go down to 0 (zero), but you won't see the working set counter decrease, which is the sign that .NET is holding on to the memory to reuse it. For more information on project file (`.csproj`) settings to control this behavior, see [Runtime configuration options for garbage collection](/dotnet/core/runtime-config/garbage-collector).
* Server GC doesn't trigger garbage collections until it determines it's absolutely necessary to do so to avoid freezing your app and considers that your app is the only thing running on the machine, so it can use all the memory in the system. If the system has 50 GB, the garbage collector seeks to use the full 50 GB of available memory before it triggers a Gen 2 collection.
* For information on disconnected circuit retention configuration, see <xref:blazor/fundamentals/signalr#server-side-circuit-handler-options>.
