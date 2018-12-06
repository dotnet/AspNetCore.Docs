---
title: Background tasks with hosted services in ASP.NET Core
author: guardrex
description: Learn how to implement background tasks with hosted services in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/28/2018
uid: fundamentals/host/hosted-services
---
# Background tasks with hosted services in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

In ASP.NET Core, background tasks can be implemented as *hosted services*. A hosted service is a class with background task logic that implements the <xref:Microsoft.Extensions.Hosting.IHostedService> interface. This topic provides three hosted service examples:

* Background task that runs on a timer.
* Hosted service that activates a scoped service. The scoped service can use dependency injection.
* Queued background tasks that run sequentially.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/hosted-services/samples/) ([how to download](xref:index#how-to-download-a-sample))

The sample app is provided in two versions:

* Web Host &ndash; The Web Host is useful for hosting web apps. The example code shown in this topic is from the Web Host version of the sample. For more information, see the [Web Host](xref:fundamentals/host/web-host) topic.
* Generic Host &ndash; The Generic Host is new in ASP.NET Core 2.1. For more information, see the [Generic Host](xref:fundamentals/host/generic-host) topic.

## Package

Reference the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) or add a package reference to the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) package.

## IHostedService interface

Hosted services implement the <xref:Microsoft.Extensions.Hosting.IHostedService> interface. The interface defines two methods for objects that are managed by the host:

* [StartAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync*) &ndash; `StartAsync` contains the logic to start the background task. When using the [Web Host](xref:fundamentals/host/web-host), `StartAsync` is called after the server has started and [IApplicationLifetime.ApplicationStarted](xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStarted*) is triggered. When using the [Generic Host](xref:fundamentals/host/generic-host), `StartAsync` is called before `ApplicationStarted` is triggered.

* [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync*) &ndash; Triggered when the host is performing a graceful shutdown. `StopAsync` contains the logic to end the background task. Implement <xref:System.IDisposable> and [finalizers (destructors)](/dotnet/csharp/programming-guide/classes-and-structs/destructors) to dispose of any unmanaged resources.

  The cancellation token has a default five second timeout to indicate that the shutdown process should no longer be graceful. When cancellation is requested on the token:

  * Any remaining background operations that the app is performing should be aborted.
  * Any methods called in `StopAsync` should return promptly.

  However, tasks aren't abandoned after cancellation is requested&mdash;the caller awaits all tasks to complete.

  If the app shuts down unexpectedly (for example, the app's process fails), `StopAsync` might not be called. Therefore, any methods called or operations conducted in `StopAsync` might not occur.

  To extend the default five second shutdown timeout, set:

  * <xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout*> when using the Generic Host. For more information, see <xref:fundamentals/host/generic-host#shutdown-timeout>.
  * Shutdown timeout host configuration setting when using the Web Host. For more information, see <xref:fundamentals/host/web-host#shutdown-timeout>.

The hosted service is activated once at app startup and gracefully shut down at app shutdown. If an error is thrown during background task execution, `Dispose` should be called even if `StopAsync` isn't called.

## Timed background tasks

A timed background task makes use of the [System.Threading.Timer](xref:System.Threading.Timer) class. The timer triggers the task's `DoWork` method. The timer is disabled on `StopAsync` and disposed when the service container is disposed on `Dispose`:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Services/TimedHostedService.cs?name=snippet1&highlight=15-16,30,37)]

The service is registered in `Startup.ConfigureServices` with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Startup.cs?name=snippet1)]

## Consuming a scoped service in a background task

To use scoped services within an `IHostedService`, create a scope. No scope is created for a hosted service by default.

The scoped background task service contains the background task's logic. In the following example, an <xref:Microsoft.Extensions.Logging.ILogger> is injected into the service:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Services/ScopedProcessingService.cs?name=snippet1)]

The hosted service creates a scope to resolve the scoped background task service to call its `DoWork` method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Services/ConsumeScopedServiceHostedService.cs?name=snippet1&highlight=29-36)]

The services are registered in `Startup.ConfigureServices`. The `IHostedService` implementation is registered with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Startup.cs?name=snippet2)]

## Queued background tasks

A background task queue is based on the .NET 4.x <xref:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem*> ([tentatively scheduled to be built-in for ASP.NET Core 3.0](https://github.com/aspnet/Hosting/issues/1280)):

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Services/BackgroundTaskQueue.cs?name=snippet1)]

In `QueueHostedService`, background tasks in the queue are dequeued and executed as a <xref:Microsoft.Extensions.Hosting.BackgroundService>, which is a base class for implementing a long running `IHostedService`:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Services/QueuedHostedService.cs?name=snippet1&highlight=21,25)]

The services are registered in `Startup.ConfigureServices`. The `IHostedService` implementation is registered with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Startup.cs?name=snippet3)]

In the Index page model class, the `IBackgroundTaskQueue` is injected into the constructor and assigned to `Queue`:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Pages/Index.cshtml.cs?name=snippet1)]

When the **Add Task** button is selected on the Index page, the `OnPostAddTask` method is executed. `QueueBackgroundWorkItem` is called to enqueue the work item:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample-WebHost/Pages/Index.cshtml.cs?name=snippet2)]

## Additional resources

* [Implement background tasks in microservices with IHostedService and the BackgroundService class](/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/background-tasks-with-ihostedservice)
* [System.Threading.Timer](xref:System.Threading.Timer)
