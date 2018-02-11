---
title: Background tasks with IHostedService in ASP.NET Core
author: guardrex
description: Learn how to implement background tasks with IHostedService in ASP.NET Core.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 02/12/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/ihostedservice
---
# Background tasks with IHostedService in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

In ASP.NET Core, background tasks are implemented as *hosted services*. A hosted service is a class with background task logic that implements the [IHostedService](/dotnet/api/microsoft.extensions.hosting.ihostedservice) interface. This topic provides three hosted service examples:

* Background task that runs on a timer.
* Hosted service that activates a scoped service. The scoped service can use dependency injection.
* Queued background tasks that run sequentially.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/ihostedservice/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## IHostedService interface

Hosted services implement the [IHostedService](/dotnet/api/microsoft.extensions.hosting.ihostedservice) interface. The interface defines two methods for objects that are managed by the host:

* [StartAsync(CancellationToken)](/dotnet/api/microsoft.extensions.hosting.ihostedservice.startasync) - Called after the server has started and [IApplicationLifetime.ApplicationStarted](/dotnet/api/microsoft.aspnetcore.hosting.iapplicationlifetime.applicationstarted) is triggered. `StartAsync` contains the logic to start the background task.

* [StopAsync(CancellationToken)](/dotnet/api/microsoft.extensions.hosting.ihostedservice.stopasync) - Triggered when the host is performing a graceful shutdown. `StopAsync` contains the logic to end the background task and dispose of any unmanaged resources.

The hosted service is activated once at app startup and gracefully shutdown at app shutdown.

## Timed background tasks

A timed background task makes use of the [System.Threading.Timer](/dotnet/api/system.threading.timer) class. The timer triggers the task's work and is disposed when the service stops:

[!code-csharp[](ihostedservice/sample/Services/TimedHostedService.cs?name=snippet1&highlight=9,23)]

The service is registered in `Startup.ConfigureServices`:

[!code-csharp[](ihostedservice/sample/Startup.cs?name=snippet1)]

## Consuming a scoped service in a background task

Since an `IHostedService` is started when the app starts, the service is activated only *once*. To use dependency injection with a hosted service, a scope must be created during execution. The scope is used resolve an independently registered service where dependency injection can be used.

The scoped background task service contains the background task's logic. In the following example, [IHostingEnvironment](/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment) is injected into the service:

[!code-csharp[](ihostedservice/sample/Services/ScopedProcessingService.cs?name=snippet1&highlight=8,12,18)]

The hosted service creates a scope to resolve the scoped background task service to call its `DoWork` method:

[!code-csharp[](ihostedservice/sample/Services/ScopedHostedService.cs?name=snippet1&highlight=14-20)]

The services are registered in `Startup.ConfigureServices`:

[!code-csharp[](ihostedservice/sample/Startup.cs?name=snippet2)]

## Queued background tasks

A background task queue is built based on .NET 4.x [QueueBackgroundWorkItem](/dotnet/api/system.web.hosting.hostingenvironment.queuebackgroundworkitem) ([tentatively scheduled to be built-in for ASP.NET Core 2.2](https://github.com/aspnet/Hosting/issues/1280)):

[!code-csharp[](ihostedservice/sample/Services/BackgroundTaskQueue.cs?name=snippet1)]

In `QueueHostedService`, background tasks (`workItem`) in the queue are dequeued and executed:

[!code-csharp[](ihostedservice/sample/Services/QueuedHostedService.cs?name=snippet1&highlight=28-29,33)]

The services are registered in `Startup.ConfigureServices`:

[!code-csharp[](ihostedservice/sample/Startup.cs?name=snippet3)]

## Additional resources

* [Implement background tasks in microservices with IHostedService and the BackgroundService class](/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/background-tasks-with-ihostedservice)
