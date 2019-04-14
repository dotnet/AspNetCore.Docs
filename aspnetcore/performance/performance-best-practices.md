---
title: ASP.NET Core Performance Best Practices
author: mjrousos
description: Tips for increasing performance in ASP.NET Core apps and avoiding common performance problems.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 04/13/2019
uid: performance/performance-best-practices
---
# ASP.NET Core Performance Best Practices

By [Mike Rousos](https://github.com/mjrousos)

This topic provides guidelines for performance best practices with ASP.NET Core.

<a name="hot"></a>

In this document, a *hot code path* is defined as a code path that is frequently called and where much of the execution time occurs. Hot code paths typically limit app scale-out and performance.

## Cache aggressively

Caching is discussed in several parts of this document. For more information, see <xref:performance/caching/response>.

## Avoid blocking calls

ASP.NET Core apps should be designed to process many requests simultaneously. Asynchronous APIs allow a small pool of threads to handle thousands of concurrent requests by not waiting on blocking calls. Rather than waiting on a long-running synchronous task to complete, the thread can work on another request.

A common performance problem in ASP.NET Core apps is blocking calls that could be asynchronous. Many synchronous blocking calls lead to [Thread Pool starvation](https://blogs.msdn.microsoft.com/vancem/2018/10/16/diagnosing-net-core-threadpool-starvation-with-perfview-why-my-service-is-not-saturating-all-cores-or-seems-to-stall/) and degraded response times.

**Do not**:

* Block asynchronous execution by calling [Task.Wait](/dotnet/api/system.threading.tasks.task.wait) or [Task.Result](/dotnet/api/system.threading.tasks.task-1.result).
* Acquire locks in common code paths. ASP.NET Core apps are most performant when architected to run code in parallel.

**Do**:

* Make [hot code paths](#hot) asynchronous.
* Call data access and long-running operations APIs asynchronously.
* Make controller/Razor Page actions asynchronous. The entire call stack is asynchronous in order to benefit from [async/await](/dotnet/csharp/programming-guide/concepts/async/) patterns.

A profiler, such as [PerfView](https://github.com/Microsoft/perfview), can be used to find threads frequently added to the [Thread Pool](/windows/desktop/procthread/thread-pool). The `Microsoft-Windows-DotNETRuntime/ThreadPoolWorkerThread/Start` event indicates a thread added to the thread pool. <!--  For more information, see [async guidance docs](TBD-Link_To_Davifowl_Doc  -->

## Minimize large object allocations

<!-- TODO review Bill - replaced original .NET language below with .NET Core since this targets .NET Core -->
The [.NET Core garbage collector](/dotnet/standard/garbage-collection/) manages allocation and release of memory automatically in ASP.NET Core apps. Automatic garbage collection generally means that developers don't need to worry about how or when memory is freed. However, cleaning up unreferenced objects takes CPU time, so developers should minimize allocating objects in [hot code paths](#hot). Garbage collection is especially expensive on large objects (> 85 K bytes). Large objects are stored on the [large object heap](/dotnet/standard/garbage-collection/large-object-heap) and require a full (generation 2) garbage collection to clean up. Unlike generation 0 and generation 1 collections, a generation 2 collection requires a temporary suspension of app execution. Frequent allocation and de-allocation of large objects can cause inconsistent performance.

Recommendations:

* **Do** consider caching large objects that are frequently used. Caching large objects prevents expensive allocations.
* **Do** pool buffers by using an [`ArrayPool<T>`](/dotnet/api/system.buffers.arraypool-1) to store large arrays.
* **Do not** allocate many, short-lived large objects on [hot code paths](#hot).

Memory issues, such as the preceding, can be diagnosed by reviewing garbage collection (GC) stats in [PerfView](https://github.com/Microsoft/perfview) and examining:

* Garbage collection pause time.
* What percentage of the processor time is spent in garbage collection.
* How many garbage collections are generation 0, 1, and 2.

For more information, see [Garbage Collection and Performance](/dotnet/standard/garbage-collection/performance).

## Optimize Data Access

Interactions with a data store and other remote services are often the slowest parts of an ASP.NET Core app. Reading and writing data efficiently is critical for good performance.

Recommendations:

* **Do** call all data access APIs asynchronously.
* **Do not** retrieve more data than is necessary. Write queries to return just the data that's necessary for the current HTTP request.
* **Do** consider caching frequently accessed data retrieved from a database or remote service if slightly out-of-date data is acceptable. Depending on the scenario, use a [MemoryCache](xref:performance/caching/memory) or a [DistributedCache](xref:performance/caching/distributed). For more information, see <xref:performance/caching/response>.
* **Do** minimize network round trips. The goal is to retrieve the required data in a single call rather than several calls.
* **Do** use [no-tracking queries](/ef/core/querying/tracking#no-tracking-queries) in Entity Framework Core when accessing data for read-only purposes. EF Core can return the results of no-tracking queries more efficiently.
* **Do** filter and aggregate LINQ queries (with `.Where`, `.Select`, or `.Sum` statements, for example) so that the filtering is performed by the database.
* **Do** consider that EF Core resolves some query operators on the client, which may lead to inefficient query execution. For more information, see [Client evaluation performance issues](/ef/core/querying/client-eval#client-evaluation-performance-issues).
* **Do not** use projection queries on collections, which can result in executing "N + 1" SQL queries. For more information, see [Optimization of correlated subqueries](/ef/core/what-is-new/ef-core-2.1#optimization-of-correlated-subqueries).

See [EF High Performance](/ef/core/what-is-new/ef-core-2.0#explicitly-compiled-queries) for approaches that may improve performance in high-scale apps:

* [DbContext pooling](/ef/core/what-is-new/ef-core-2.0#dbcontext-pooling)
* [Explicitly compiled queries](/ef/core/what-is-new/ef-core-2.0#explicitly-compiled-queries)

We recommend measuring the impact of the preceding high-performance approaches before committing the code base. The additional complexity of compiled queries may not justify the performance improvement.

Query issues can be detected by reviewing the time spent accessing data with [Application Insights](/azure/application-insights/app-insights-overview) or with profiling tools. Most databases also make statistics available concerning frequently executed queries.

## Pool HTTP connections with HttpClientFactory

Although [HttpClient](/dotnet/api/system.net.http.httpclient) implements the `IDisposable` interface, it's designed for reuse. Closed `HttpClient` instances leave sockets open in the `TIME_WAIT` state for a short period of time. If a code path that creates and disposes of `HttpClient` objects is frequently used, the app may exhaust available sockets. [HttpClientFactory](/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests) was introduced in ASP.NET Core 2.1 as a solution to this problem. It handles pooling HTTP connections to optimize performance and reliability.

Recommendations:

* **Do not** create and dispose of `HttpClient` instances directly.
* **Do** use [HttpClientFactory](/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests) to retrieve `HttpClient` instances. For more information, see [Use HttpClientFactory to implement resilient HTTP requests](/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests).

## Keep common code paths fast

You want all of your code to be fast, frequently called code paths are the most critical to optimize:

* Middleware components in the app's request processing pipeline, especially middleware run early in the pipeline. These components have a large impact on performance.
* Code that's executed for every request or multiple times per request. For example, custom logging, authorization handlers, or initialization of transient services.

Recommendations:

* **Do not** use custom middleware components with long-running tasks.
* **Do** use performance profiling tools, such as [Visual Studio Diagnostic Tools](/visualstudio/profiling/profiling-feature-tour) or [PerfView](https://github.com/Microsoft/perfview)), to identify [hot code paths](#hot).

## Complete long-running Tasks outside of HTTP requests

Most requests to an ASP.NET Core app can be handled by a controller or page model calling necessary services and returning an HTTP response. For some requests that involve long-running tasks, it's better to make the entire request-response process asynchronous.

Recommendations:

* **Do not** wait for long-running tasks to complete as part of ordinary HTTP request processing.
* **Do** consider handling long-running requests with [background services](xref:fundamentals/host/hosted-services) or out of process with an [Azure Function](/azure/azure-functions/). Completing work out-of-process is especially beneficial for CPU-intensive tasks.
* **Do** use real-time communication options, such as [SignalR](xref:signalr/introduction), to communicate with clients asynchronously.

## Minify client assets

ASP.NET Core apps with complex front-ends frequently serve many JavaScript, CSS, or image files. Performance of initial load requests can be improved by:

* Bundling, which combines multiple files into one.
* Minifying, which reduces the size of files by removing whitespace and comments.

Recommendations:

* **Do** use ASP.NET Core's [built-in support](xref:client-side/bundling-and-minification) for bundling and minifying client assets.
* **Do** consider other third-party tools, such as [Gulp](xref:client-side/using-gulp) or [Webpack](https://webpack.js.org/) for complex client asset management.

## Compress responses

 Reducing the size of the response usually increases the responsiveness of an app, often dramatically. One way to reduce payload sizes is to compress an app's responses. For more information, see [Response compression](xref:performance/response-compression).

## Use the latest ASP.NET Core release

Each new release of ASP.NET Core includes performance improvements. Optimizations in .NET Core and ASP.NET Core mean that newer versions generally outperform older versions. For example, .NET Core 2.1 added support for compiled regular expressions and benefitted from [`Span<T>`](https://msdn.microsoft.com/magazine/mt814808.aspx). ASP.NET Core 2.2 added support for HTTP/2. If performance is a priority, consider upgrading to the current version of ASP.NET Core.

<!-- TODO review link and taking advantage of new [performance features](#TBD)
Maybe skip this TBD link as each version will have perf improvements -->

## Minimize exceptions

Exceptions should be rare. Throwing and catching exceptions is slow relative to other code flow patterns. Because of this, exceptions shouldn't be used to control normal program flow.

Recommendations:

* **Do not** use throwing or catching exceptions as a means of normal program flow, especially in [hot code paths](#hot).
* **Do** include logic in the app to detect and handle conditions that would cause an exception.
* **Do** throw or catch exceptions for unusual or unexpected conditions.

App diagnostic tools, such as Application Insights, can help to identify common exceptions in an app that may affect performance.
