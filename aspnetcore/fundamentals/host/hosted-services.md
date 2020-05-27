---
title: Background tasks with hosted services in ASP.NET Core
author: rick-anderson
description: Learn how to implement background tasks with hosted services in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/10/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/host/hosted-services
---
# Background tasks with hosted services in ASP.NET Core

By [Jeow Li Huan](https://github.com/huan086)

::: moniker range=">= aspnetcore-3.0"

In ASP.NET Core, background tasks can be implemented as *hosted services*. A hosted service is a class with background task logic that implements the <xref:Microsoft.Extensions.Hosting.IHostedService> interface. This topic provides three hosted service examples:

* Background task that runs on a timer.
* Hosted service that activates a [scoped service](xref:fundamentals/dependency-injection#service-lifetimes). The scoped service can use [dependency injection (DI)](xref:fundamentals/dependency-injection).
* Queued background tasks that run sequentially.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/host/hosted-services/samples/) ([how to download](xref:index#how-to-download-a-sample))

## Worker Service template

The ASP.NET Core Worker Service template provides a starting point for writing long running service apps. An app created from the Worker Service template specifies the Worker SDK in its project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Worker">
```

To use the template as a basis for a hosted services app:

[!INCLUDE[](~/includes/worker-template-instructions.md)]

## Package

An app based on the Worker Service template uses the `Microsoft.NET.Sdk.Worker` SDK and has an explicit package reference to the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) package. For example, see the sample app's project file (*BackgroundTasksSample.csproj*).

For web apps that use the `Microsoft.NET.Sdk.Web` SDK, the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) package is referenced implicitly from the shared framework. An explicit package reference in the app's project file isn't required.

## IHostedService interface

The <xref:Microsoft.Extensions.Hosting.IHostedService> interface defines two methods for objects that are managed by the host:

* [StartAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync*): `StartAsync` contains the logic to start the background task. `StartAsync` is called *before*:

  * The app's request processing pipeline is configured (`Startup.Configure`).
  * The server is started and [IApplicationLifetime.ApplicationStarted](xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStarted*) is triggered.

  The default behavior can be changed so that the hosted service's `StartAsync` runs after the app's pipeline has been configured and `ApplicationStarted` is called. To change the default behavior, add the hosted service (`VideosWatcher` in the following example) after calling `ConfigureWebHostDefaults`:

  ```csharp
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;

  public class Program
  {
      public static void Main(string[] args)
      {
          CreateHostBuilder(args).Build().Run();
      }

      public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              })
              .ConfigureServices(services =>
              {
                  services.AddHostedService<VideosWatcher>();
              });
  }
  ```

* [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync*): Triggered when the host is performing a graceful shutdown. `StopAsync` contains the logic to end the background task. Implement <xref:System.IDisposable> and [finalizers (destructors)](/dotnet/csharp/programming-guide/classes-and-structs/destructors) to dispose of any unmanaged resources.

  The cancellation token has a default five second timeout to indicate that the shutdown process should no longer be graceful. When cancellation is requested on the token:

  * Any remaining background operations that the app is performing should be aborted.
  * Any methods called in `StopAsync` should return promptly.

  However, tasks aren't abandoned after cancellation is requested&mdash;the caller awaits all tasks to complete.

  If the app shuts down unexpectedly (for example, the app's process fails), `StopAsync` might not be called. Therefore, any methods called or operations conducted in `StopAsync` might not occur.

  To extend the default five second shutdown timeout, set:

  * <xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout*> when using Generic Host. For more information, see <xref:fundamentals/host/generic-host#shutdown-timeout>.
  * Shutdown timeout host configuration setting when using Web Host. For more information, see <xref:fundamentals/host/web-host#shutdown-timeout>.

The hosted service is activated once at app startup and gracefully shut down at app shutdown. If an error is thrown during background task execution, `Dispose` should be called even if `StopAsync` isn't called.

## BackgroundService base class

<xref:Microsoft.Extensions.Hosting.BackgroundService> is a base class for implementing a long running <xref:Microsoft.Extensions.Hosting.IHostedService>.

[ExecuteAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync*) is called to run the background service. The implementation returns a <xref:System.Threading.Tasks.Task> that represents the entire lifetime of the background service. No further services are started until [ExecuteAsync becomes asynchronous](https://github.com/dotnet/extensions/issues/2149), such as by calling `await`. Avoid performing long, blocking initialization work in `ExecuteAsync`. The host blocks in [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync*) waiting for `ExecuteAsync` to complete.

The cancellation token is triggered when [IHostedService.StopAsync](xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync*) is called. Your implementation of `ExecuteAsync` should finish promptly when the cancellation token is fired in order to gracefully shut down the service. Otherwise, the service ungracefully shuts down at the shutdown timeout. For more information, see the [IHostedService interface](#ihostedservice-interface) section.

## Timed background tasks

A timed background task makes use of the [System.Threading.Timer](xref:System.Threading.Timer) class. The timer triggers the task's `DoWork` method. The timer is disabled on `StopAsync` and disposed when the service container is disposed on `Dispose`:

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Services/TimedHostedService.cs?name=snippet1&highlight=16-17,34,41)]

The <xref:System.Threading.Timer> doesn't wait for previous executions of `DoWork` to finish, so the approach shown might not be suitable for every scenario. [Interlocked.Increment](xref:System.Threading.Interlocked.Increment*) is used to increment the execution counter as an atomic operation, which ensures that multiple threads don't update `executionCount` concurrently.

The service is registered in `IHostBuilder.ConfigureServices` (*Program.cs*) with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Program.cs?name=snippet1)]

## Consuming a scoped service in a background task

To use [scoped services](xref:fundamentals/dependency-injection#service-lifetimes) within a [BackgroundService](#backgroundservice-base-class), create a scope. No scope is created for a hosted service by default.

The scoped background task service contains the background task's logic. In the following example:

* The service is asynchronous. The `DoWork` method returns a `Task`. For demonstration purposes, a delay of ten seconds is awaited in the `DoWork` method.
* An <xref:Microsoft.Extensions.Logging.ILogger> is injected into the service.

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Services/ScopedProcessingService.cs?name=snippet1)]

The hosted service creates a scope to resolve the scoped background task service to call its `DoWork` method. `DoWork` returns a `Task`, which is awaited in `ExecuteAsync`:

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Services/ConsumeScopedServiceHostedService.cs?name=snippet1&highlight=19,22-35)]

The services are registered in `IHostBuilder.ConfigureServices` (*Program.cs*). The hosted service is registered with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Program.cs?name=snippet2)]

## Queued background tasks

A background task queue is based on the .NET 4.x <xref:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem*> ([tentatively scheduled to be built-in for ASP.NET Core](https://github.com/aspnet/Hosting/issues/1280)):

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Services/BackgroundTaskQueue.cs?name=snippet1)]

In the following `QueueHostedService` example:

* The `BackgroundProcessing` method returns a `Task`, which is awaited in `ExecuteAsync`.
* Background tasks in the queue are dequeued and executed in `BackgroundProcessing`.
* Work items are awaited before the service stops in `StopAsync`.

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Services/QueuedHostedService.cs?name=snippet1&highlight=28-29,33)]

A `MonitorLoop` service handles enqueuing tasks for the hosted service whenever the `w` key is selected on an input device:

* The `IBackgroundTaskQueue` is injected into the `MonitorLoop` service.
* `IBackgroundTaskQueue.QueueBackgroundWorkItem` is called to enqueue a work item.
* The work item simulates a long-running background task:
  * Three 5-second delays are executed (`Task.Delay`).
  * A `try-catch` statement traps <xref:System.OperationCanceledException> if the task is cancelled.

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Services/MonitorLoop.cs?name=snippet_Monitor&highlight=7,33)]

The services are registered in `IHostBuilder.ConfigureServices` (*Program.cs*). The hosted service is registered with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Program.cs?name=snippet3)]

`MonitorLoop` is started in `Program.Main`:

[!code-csharp[](hosted-services/samples/3.x/BackgroundTasksSample/Program.cs?name=snippet4)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

In ASP.NET Core, background tasks can be implemented as *hosted services*. A hosted service is a class with background task logic that implements the <xref:Microsoft.Extensions.Hosting.IHostedService> interface. This topic provides three hosted service examples:

* Background task that runs on a timer.
* Hosted service that activates a [scoped service](xref:fundamentals/dependency-injection#service-lifetimes). The scoped service can use [dependency injection (DI)](xref:fundamentals/dependency-injection)
* Queued background tasks that run sequentially.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/host/hosted-services/samples/) ([how to download](xref:index#how-to-download-a-sample))

## Package

Reference the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) or add a package reference to the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) package.

## IHostedService interface

Hosted services implement the <xref:Microsoft.Extensions.Hosting.IHostedService> interface. The interface defines two methods for objects that are managed by the host:

* [StartAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync*): `StartAsync` contains the logic to start the background task. When using the [Web Host](xref:fundamentals/host/web-host), `StartAsync` is called after the server has started and [IApplicationLifetime.ApplicationStarted](xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStarted*) is triggered. When using the [Generic Host](xref:fundamentals/host/generic-host), `StartAsync` is called before `ApplicationStarted` is triggered.

* [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync*): Triggered when the host is performing a graceful shutdown. `StopAsync` contains the logic to end the background task. Implement <xref:System.IDisposable> and [finalizers (destructors)](/dotnet/csharp/programming-guide/classes-and-structs/destructors) to dispose of any unmanaged resources.

  The cancellation token has a default five second timeout to indicate that the shutdown process should no longer be graceful. When cancellation is requested on the token:

  * Any remaining background operations that the app is performing should be aborted.
  * Any methods called in `StopAsync` should return promptly.

  However, tasks aren't abandoned after cancellation is requested&mdash;the caller awaits all tasks to complete.

  If the app shuts down unexpectedly (for example, the app's process fails), `StopAsync` might not be called. Therefore, any methods called or operations conducted in `StopAsync` might not occur.

  To extend the default five second shutdown timeout, set:

  * <xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout*> when using Generic Host. For more information, see <xref:fundamentals/host/generic-host#shutdown-timeout>.
  * Shutdown timeout host configuration setting when using Web Host. For more information, see <xref:fundamentals/host/web-host#shutdown-timeout>.

The hosted service is activated once at app startup and gracefully shut down at app shutdown. If an error is thrown during background task execution, `Dispose` should be called even if `StopAsync` isn't called.

## Timed background tasks

A timed background task makes use of the [System.Threading.Timer](xref:System.Threading.Timer) class. The timer triggers the task's `DoWork` method. The timer is disabled on `StopAsync` and disposed when the service container is disposed on `Dispose`:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Services/TimedHostedService.cs?name=snippet1&highlight=15-16,30,37)]

The <xref:System.Threading.Timer> doesn't wait for previous executions of `DoWork` to finish, so the approach shown might not be suitable for every scenario.

The service is registered in `Startup.ConfigureServices` with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Startup.cs?name=snippet1)]

## Consuming a scoped service in a background task

To use [scoped services](xref:fundamentals/dependency-injection#service-lifetimes) within an `IHostedService`, create a scope. No scope is created for a hosted service by default.

The scoped background task service contains the background task's logic. In the following example, an <xref:Microsoft.Extensions.Logging.ILogger> is injected into the service:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Services/ScopedProcessingService.cs?name=snippet1)]

The hosted service creates a scope to resolve the scoped background task service to call its `DoWork` method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Services/ConsumeScopedServiceHostedService.cs?name=snippet1&highlight=29-36)]

The services are registered in `Startup.ConfigureServices`. The `IHostedService` implementation is registered with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Startup.cs?name=snippet2)]

## Queued background tasks

A background task queue is based on the .NET Framework 4.x <xref:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem*> ([tentatively scheduled to be built-in for ASP.NET Core](https://github.com/aspnet/Hosting/issues/1280)):

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Services/BackgroundTaskQueue.cs?name=snippet1)]

In `QueueHostedService`, background tasks in the queue are dequeued and executed as a [BackgroundService](#backgroundservice-base-class), which is a base class for implementing a long running `IHostedService`:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Services/QueuedHostedService.cs?name=snippet1&highlight=21,25)]

The services are registered in `Startup.ConfigureServices`. The `IHostedService` implementation is registered with the `AddHostedService` extension method:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Startup.cs?name=snippet3)]

In the Index page model class:

* The `IBackgroundTaskQueue` is injected into the constructor and assigned to `Queue`.
* An <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory> is injected and assigned to `_serviceScopeFactory`. The factory is used to create instances of <xref:Microsoft.Extensions.DependencyInjection.IServiceScope>, which is used to create services within a scope. A scope is created in order to use the app's `AppDbContext` (a [scoped service](xref:fundamentals/dependency-injection#service-lifetimes)) to write database records in the `IBackgroundTaskQueue` (a singleton service).

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Pages/Index.cshtml.cs?name=snippet1)]

When the **Add Task** button is selected on the Index page, the `OnPostAddTask` method is executed. `QueueBackgroundWorkItem` is called to enqueue a work item:

[!code-csharp[](hosted-services/samples/2.x/BackgroundTasksSample/Pages/Index.cshtml.cs?name=snippet2)]

::: moniker-end

## Additional resources

* [Implement background tasks in microservices with IHostedService and the BackgroundService class](/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/background-tasks-with-ihostedservice)
* [Run background tasks with WebJobs in Azure App Service](/azure/app-service/webjobs-create)
* <xref:System.Threading.Timer>
