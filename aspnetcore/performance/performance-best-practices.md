---
title: ASP.NET Core Performance Best Practices
author: mjrousos
description: Tips for increasing performance in ASP.NET Core apps and avoiding common performance problems
monikerRange: '>= aspnetcore-1.1'
ms.author: riande
ms.date: 11/13/2018
uid: performance/performance-best-practices
---
# ASP.NET Core Performance Best Practices

https://docs.microsoft.com/en-us/windows/desktop/procthread/thread-pools
https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.wait?view=netframework-4.7.2


By [Mike Rousos](https://github.com/mjrousos)

<!-- TODO review hot code paths is jargon that won't MT (machine translate) and is not well defined for native speakers. -->

This topic provides guidelines for best practices on ASP.NET Core performance. 

<a name="hot"></a>

In this document, a hot code path is defined as:

## Cache aggressively

Caching is discussed in several parts of this document. For more information, see [Cache responses in ASP.NET Core](xref:performance/caching/index).

## Avoid Blocking Calls

ASP.NET Core app should be architected to process many requests simultaneously. Asynchronous APIs allow a small pool of threads to handle hundreds or thousands of concurrent requests by not waiting on blocking calls. Rather than waiting on a long-running synchronous task to complete, the thread can work on another request.

A common performance problem in ASP.NET Core apps is blocking calls that could be asynchronous. Many synchronous blocking calls leads to [Thread Pool](https://docs.microsoft.com/en-us/windows/desktop/procthread/thread-pools) starvation and degrading response times.

**Do not**:

*  Block asynchronous execution by calling [Task.Wait](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.wait?view=netframework-4.7.2) or [Task.Result](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.result?view=netframework-4.7.2).
* Acquire locks in common code paths. ASP.NET Core apps are most performant when architected to run highly parallelized.


**Do**:

* Make frequently [hot code paths](#hot) asynchronous.
* Call asynchronous APIs for any long-running operations (especially data access).
* Make controller/Razor Page actions asynchronous. The entire call stack needs to be asynchronous in order to benefit from [async/await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) patterns.

A profiler like [PerfView](https://github.com/Microsoft/perfview) can be used to look for threads frequently/regularly being added to the Thread Pool. The `Microsoft-Windows-DotNETRuntime/ThreadPoolWorkerThread/Start` event indicates a thread being added to the thread pool.  For more information, see [async guidance docs](TBD-Link_To_Davifowl_Doc <!-- TODO review TBD link -->).

## Be Mindful of Large Object Allocations

<!-- TODO review Bill - replaced original .NET language below with .NET Core since this targets .NET Core -->
The [.NET Core garbage collector](https://docs.microsoft.com/dotnet/standard/garbage-collection/) manages allocation and release of memory automatically in ASP.NET Core apps. Automatic garbage collection means that, generally, .NET Core developers don't need to worry about when or how memory is freed. However, cleaning up unreferenced objects takes resources (CPU time), so developers need to be careful about allocating too many objects in very [hot code paths](hot). This is especially true of large objects (> 85K bytes). Large objects are stored on the large object heap and require a full (generation 2) garbage collection to clean up. Unlike generation 0 and generation 1 collections, a generation 2 collection requires app execution to be temporarily suspended. Frequent allocation and de-allocation of large objects can cause inconsistent performance in ASP.NET Core apps.

* **Do** consider caching large objects that are frequently used so that they don't need to be re-allocated each time they're needed.
* **Do** pool buffers by using an `ArrayPool<T>` to store large arrays.
* **Do not** allocate many, short-lived large objects on [hot code paths](hot).

Memory issues like this can be diagnosed by reviewing garbage collection (GC) stats in PerfView and examining:

* How long GC pauses are.
* What percentage of the processor time is spent in garbage collection.
* How many garbage collections are gen 0, gen 1, and gen 2.

## Optimize Data Access

<!-- TODO review by EF folks -->

Interactions with a data store or other remote services are often the slowest parts of an ASP.NET Core app. Because of that, it's important to make sure that data is read and written efficiently. In addition to ensuring data access is asynchronous, some best practices include:

* **Do** consider caching frequently accessed data retrieved from a database or remote service if it is acceptable for the data to be slightly out-of-date. Depending on the scenario, you might use a [MemoryCache](https://docs.microsoft.com/aspnet/core/performance/caching/memory) or a [DistributedCache](https://docs.microsoft.com/aspnet/core/performance/caching/distributed). For more information, see [Cache responses in ASP.NET Core](xref:performance/caching/index).
* Prefer *chunky* over *chatty* database interactions. A *chatty* interaction requires many calls to the data store. A *chunky* interaction requires fewer network calls. The goal is to retrieve all the data that will be needed in a single call rather than  several calls.
* **Do** use [no-tracking queries](https://docs.microsoft.com/ef/core/querying/tracking) in Entity Framework when accessing data in a read-only scenario.
* **Do** filter and aggregate LINQ queries (with `.Where`, `.Select`, or `.Sum` statements, for example) before resolving the query so that the filtering is done by the database and the response returned to your application is smaller.
* **Do not** retrieve more data than is necessary. Limit queries to return just the columns/fields and rows that are necessary for the current HTTP request.

These issues can be detected by looking at how much time is spent accessing data using app monitoring (with [Application Insights](https://docs.microsoft.com/azure/application-insights/app-insights-overview), for example) or with profiling tools. Most databases also make statistics available concerning frequently-executed queries.

## Pool HTTP Connections with HttpClientFactory
Although `HttpClient` implements the `IDisposable` interface, it is meant to be re-used. Closed `HttpClient` instances leave sockets open in the `TIME_WAIT` state for a short period of time. Consequently, if a code path that creates and disposes of `HttpClient` objects is used very frequently, the app may exhaust available sockets. `HttpClientFactory` was introduced in ASP.NET Core 2.1 as a solution to this problem. It handles pooling HTTP connections to optimize performance and reliability.

* **Do not** create and dispose of `HttpClient` instances directly.
* **Do** use [`HttpClientFactory`](https://docs.microsoft.com/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests) to retrieve `HttpClient` instances.

## Keep Common Code Paths Fast
You want all of your code to be fast, of course, but some code paths are more critical than others to optimize. For example, middleware components in your app's request processing pipeline (especially those early in the pipeline) are sure to be run for every request, so they have a large impact on app performance. Other examples include code that is executed for every request (or multiple times per request) such as custom logging, authorization handlers, or initialization of transient services.

* **Do not** use custom middleware components with long-running tasks.
* **Do** use performance profiling tools (like [Visual Studio Diagnostic Tools](https://docs.microsoft.com/visualstudio/profiling/profiling-feature-tour) or [PerfView](https://github.com/Microsoft/perfview)) to identify [hot code paths](hot) specific to your app.

## Complete Long-Running Tasks Outside of HTTP Requests
Most requests to an ASP.NET Core app can be handled by MVC controllers calling necessary services and returning an HTTP response. For some requests which involve long-running tasks, though, it is better to make the entire request-response process asynchronous.

* **Do not** wait for long-running tasks to complete as part of ordinary HTTP request processing.
* **Do** consider handling long-running requests with [background services](https://docs.microsoft.com/aspnet/core/fundamentals/host/hosted-services) or out of process with an [Azure Function](https://docs.microsoft.com/azure/azure-functions/) (completing work out-of-process is especially valuable for CPU-intensive tasks).
* **Do** use real-time communication options like [SignalR](https://docs.microsoft.com/aspnet/core/signalr) to communicate with clients asynchronously.

## Minify Client Assets
For ASP.NET Core apps with complex front-ends, it may be necessary to serve large JavaScript, CSS, or image files. Performance of initial load requests can be improved in these scenarios by combining multiple files into one (bundling) and by reducing the size of those files by removing unnecessary characters (minifying). 

* **Do** use ASP.NET Core's [built-in support](https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification) for bundling and minifying client assets.
* **Do** consider other third-party tools like [Gulp](https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification#consume-bundleconfigjson-from-gulp) or [Webpack](https://webpack.js.org/) for more complex client asset management.

## Use the Latest ASP.NET Core Releases
With every ASP.NET Core release, performance work is done. Optimtizations in .NET Core and additional ASP.NET Core performance features mean that newer versions of ASP.NET Core will outperform older versions. For example, .NET Core 2.1 addded support for compiled regular expressions and benefitted from [`Span<T>`](https://msdn.microsoft.com/en-us/magazine/mt814808.aspx). ASP.NET Core 2.2 will bring support for HTTP/2. If performance is a priority, it may worthwhile upgrading to a recent ASP.NET Core version and taking advantage of new [performance features](TBD).