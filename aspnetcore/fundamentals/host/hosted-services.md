---
title: Background tasks with hosted services in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Learn how to implement background tasks with hosted services in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.date: 10/05/2026
uid: fundamentals/host/hosted-services
---
# Background tasks with hosted services in ASP.NET Core

By [Jeow Li Huan](https://github.com/huan086)

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

In ASP.NET Core, background tasks can be implemented as *hosted services*. A hosted service is a class with background task logic that implements the <xref:Microsoft.Extensions.Hosting.IHostedService> interface. Hosted services can be used in Worker Service apps and in web apps. This article provides three hosted service examples:

* Background task that runs on a timer.
* Hosted service that activates a [scoped service](xref:fundamentals/dependency-injection#service-lifetimes). The scoped service can use [dependency injection (DI)](xref:fundamentals/dependency-injection).
* Queued background tasks that run sequentially.

## Worker Service template

The ASP.NET Core Worker Service template provides a starting point for writing long running service apps. An app created from the Worker Service template specifies the Worker SDK in its project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Worker">
```

To use the template as a basis for a hosted services app:

[!INCLUDE[](~/includes/worker-template-instructions-net6.md)]

## Package

An app based on the Worker Service template uses the `Microsoft.NET.Sdk.Worker` SDK and has an explicit package reference to the [`Microsoft.Extensions.Hosting` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Hosting). For example, see the Worker Service sample app's project file (`BackgroundTasksSample.csproj`).

For web apps that use the `Microsoft.NET.Sdk.Web` SDK, the [`Microsoft.Extensions.Hosting` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) is referenced implicitly from the shared framework. An explicit package reference in the app's project file isn't required.

## Hosted services in a web app

Hosted services aren't limited to Worker Service apps. A web app that uses the `Microsoft.NET.Sdk.Web` SDK registers hosted services in the `Program` file by calling the same <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension method on <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services?displayProperty=nameWithType>. The host automatically starts and stops registered hosted services, as described in the [`IHostedService` interface](#ihostedservice-interface) section.

The following `Program` file is from the web sample app (`BackgroundTasksWebSample`). It registers the three hosted services that are described in the rest of this article, maps a root endpoint that returns a status message, and adds an endpoint that queues a work item for one of them:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksWebSample/Program.cs" highlight="5,7,10":::

In the preceding code:

* `TimedHostedService`, `ConsumeScopedServiceHostedService`, and `QueuedHostedService` are registered with the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension method.
* A hosted service is registered as a singleton, so it can't receive [scoped services](xref:fundamentals/dependency-injection#service-lifetimes), such as an Entity Framework Core `DbContext`, by constructor injection. `IScopedProcessingService` is registered as a scoped service, and `ConsumeScopedServiceHostedService` creates a scope to resolve it. For more information, see the [Consuming a scoped service in a background task](#consuming-a-scoped-service-in-a-background-task) section.
* The `IBackgroundTaskQueue` singleton is consumed by the `/queue` endpoint and `QueuedHostedService`. A `POST` request to `/queue` returns a `202 Accepted` response once the work item is enqueued without waiting for it to execute. If the bounded queue is full, the request waits until space is available to enqueue the work item. `QueuedHostedService` runs the queued work items in the background. For more information, see the [Queued background tasks](#queued-background-tasks) section.

The following service registration snippets are from the Worker Service sample app (`BackgroundTasksSample`), where `services` is the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> parameter passed to `ConfigureServices`. In a web app, use `builder.Services` instead of `services`.

## IHostedService interface

The <xref:Microsoft.Extensions.Hosting.IHostedService> interface defines two methods for objects that are managed by the host:

* [StartAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A)
* [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync%2A)

### `StartAsync`

[StartAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A) contains the logic to start the background task. `StartAsync` is called *before*:

* The app's request processing pipeline is configured.
* The server is started and [IApplicationLifetime.ApplicationStarted](xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStarted%2A) is triggered.

`StartAsync` should be limited to short running tasks because hosted services are run sequentially, and no further services are started until `StartAsync` runs to completion.

Hosted service instances start in the order that they're registered in the dependency injection container unless the app opts into concurrent startup by setting <xref:Microsoft.Extensions.Hosting.HostOptions.ServicesStartConcurrently> to `true`:

```csharp
builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStartConcurrently = true;
});
```

### `StopAsync`

* [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync%2A) is triggered when the host is performing a graceful shutdown. `StopAsync` contains the logic to end the background task. Implement <xref:System.IDisposable> and [finalizers (destructors)](/dotnet/csharp/programming-guide/classes-and-structs/destructors) to dispose of any unmanaged resources.

The cancellation token has a default 30 second timeout to indicate that the shutdown process should no longer be graceful. When cancellation is requested on the token:

* Any remaining background operations that the app is performing should be aborted.
* Any methods called in `StopAsync` should return promptly.

However, tasks aren't abandoned after cancellation is requested&mdash;the caller awaits all tasks to complete.

If the app shuts down unexpectedly (for example, the app's process fails), `StopAsync` might not be called. Therefore, any methods called or operations conducted in `StopAsync` might not occur.

To extend the default 30 second shutdown timeout, set:

* <xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout%2A> when using Generic Host. For more information, see <xref:fundamentals/host/generic-host#shutdowntimeout>.
* Shutdown timeout host configuration setting when using Web Host. For more information, see <xref:fundamentals/host/web-host#shutdown-timeout>.

The hosted service is activated once at app startup and gracefully shut down at app shutdown. If an error is thrown during background task execution, `Dispose` should be called even if `StopAsync` isn't called.

Hosted service instances stop in the reverse order that they're registered in the dependency injection container unless the app opts into concurrent shutdown behavior by setting <xref:Microsoft.Extensions.Hosting.HostOptions.ServicesStopConcurrently> to `true`:

```csharp
builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStopConcurrently = true;
});
```

## BackgroundService base class

<xref:Microsoft.Extensions.Hosting.BackgroundService> is a base class for implementing a long running <xref:Microsoft.Extensions.Hosting.IHostedService>.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

[ExecuteAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A) is called on the thread pool to run the background service. The implementation returns a <xref:System.Threading.Tasks.Task> that represents the entire lifetime of the background service. The host blocks in [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync%2A) waiting for `ExecuteAsync` to complete.

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-10.0"

[ExecuteAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A) is called to run the background service. The implementation returns a <xref:System.Threading.Tasks.Task> that represents the entire lifetime of the background service. No further services are started until [ExecuteAsync becomes asynchronous](https://github.com/dotnet/extensions/issues/2149), such as by calling `await`. Avoid performing long, blocking initialization work in `ExecuteAsync`. The host blocks in [StopAsync(CancellationToken)](xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync%2A) waiting for `ExecuteAsync` to complete.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

The cancellation token is triggered when [IHostedService.StopAsync](xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync%2A) is called. Your implementation of `ExecuteAsync` should finish promptly when the cancellation token is fired in order to gracefully shut down the service. Otherwise, the service ungracefully shuts down at the shutdown timeout. For more information, see the [IHostedService interface](#ihostedservice-interface) section.

For more information, see the [BackgroundService](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Hosting.Abstractions/src/BackgroundService.cs) source code.

## Timed background tasks

A timed background task makes use of the [System.Threading.Timer](xref:System.Threading.Timer) class. The timer triggers the task's `DoWork` method. The timer is disabled on `StopAsync` and disposed when the service container is disposed on `Dispose`:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Services/TimedHostedService.cs" id="snippet1" highlight="10-11,28,35":::

The <xref:System.Threading.Timer> doesn't wait for previous executions of `DoWork` to finish, so the approach shown might not be suitable for every scenario. [Interlocked.Increment](xref:System.Threading.Interlocked.Increment%2A) is used to increment the execution counter as an atomic operation, which ensures that multiple threads don't update `executionCount` concurrently.

The service is registered in the `Program` file with the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension method:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Program.cs" id="snippet1":::

## Consuming a scoped service in a background task

To use [scoped services](xref:fundamentals/dependency-injection#service-lifetimes) within a [BackgroundService](#backgroundservice-base-class), create a scope. No scope is created for a hosted service by default.

The scoped background task service contains the background task's logic. In the following example:

* The service is asynchronous. The `DoWork` method returns a `Task`. For demonstration purposes, a delay of ten seconds is awaited in the `DoWork` method.
* An <xref:Microsoft.Extensions.Logging.ILogger> is injected into the service.

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Services/ScopedProcessingService.cs" id="snippet1":::

The hosted service creates a scope to resolve the scoped background task service to call its `DoWork` method. `DoWork` returns a `Task`, which is awaited in `ExecuteAsync`:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Services/ConsumeScopedServiceHostedService.cs" id="snippet1" highlight="12,15-28":::

The services are registered in the `Program` file. The hosted service is registered with the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension method:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Program.cs" id="snippet2":::

## Queued background tasks

A background task queue is based on the .NET Framework 4.x <xref:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem%2A>:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Services/BackgroundTaskQueue.cs" id="snippet1":::

In the following `QueueHostedService` example:

* The `BackgroundProcessing` method returns a `Task`, which is awaited in `ExecuteAsync`.
* Background tasks in the queue are dequeued and executed in `BackgroundProcessing`.
* Work items are awaited before the service stops in `StopAsync`.

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Services/QueuedHostedService.cs" id="snippet1" highlight="21-22,26":::

A `MonitorLoop` service handles enqueuing tasks for the hosted service whenever the `w` key is selected on an input device:

* The `IBackgroundTaskQueue` is injected into the `MonitorLoop` service.
* `IBackgroundTaskQueue.QueueBackgroundWorkItem` is called to enqueue a work item.
* The work item simulates a long-running background task:
  * Three 5-second delays are executed (`Task.Delay`).
  * A `try-catch` statement traps <xref:System.OperationCanceledException> if the task is cancelled.

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Services/MonitorLoop.cs" id="snippet_Monitor" highlight="2,25":::

The services are registered in the `Program` file. The hosted service is registered with the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension method:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Program.cs" id="snippet3":::

`MonitorLoop` is started in the `Program` file:

:::code language="csharp" source="~/fundamentals/host/hosted-services/samples/8.0/BackgroundTasksSample/Program.cs" id="snippet4":::

In a web app, an endpoint can queue work items instead of a console input loop. For an example, see the [Hosted services in a web app](#hosted-services-in-a-web-app) section.

## Asynchronous timed background task

The following code creates an asynchronous timed background task:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/host/TimedBackgroundTasks/TimedHostedService.cs":::

## Native AOT

The Worker Service templates support [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/) with the `--aot` flag:

# [Visual Studio](#tab/visual-studio)

1. Create a new project.
1. Select **Worker Service**. Select **Next**.
1. Provide a project name in the **Project name** field or accept the default project name.  Select **Next**.
1. In the **Additional information** dialog:
  1. Choose a **Framework**.
  1. Check the **Enable Native AOT publish** checkbox.
  1. Select **Create**.

# [.NET CLI](#tab/net-cli)

Use the Worker Service (`worker`) template with the [dotnet new](/dotnet/core/tools/dotnet-new) command from a command shell with the AOT option:

```dotnetcli
dotnet new worker -o WorkerWithAot --aot
```

---

The AOT option adds `<PublishAot>true</PublishAot>` to the project file:

```diff

<Project Sdk="Microsoft.NET.Sdk.Worker">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <InvariantGlobalization>true</InvariantGlobalization>
+   <PublishAot>true</PublishAot>
    <UserSecretsId>dotnet-WorkerWithAot-e94b2</UserSecretsId>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0-preview.4.23259.5" />
  </ItemGroup>
</Project>
```

## Additional resources

* [Background services unit tests on GitHub](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Hosting/tests/UnitTests/BackgroundServiceTests.cs).
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/hosted-services/samples/) ([how to download](xref:fundamentals/index#how-to-download-a-sample))
* [Implement background tasks in microservices with IHostedService and the BackgroundService class](/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/background-tasks-with-ihostedservice)
* [Run background tasks with WebJobs in Azure App Service](/azure/app-service/webjobs-create)
* <xref:System.Threading.Timer>

:::moniker-end

[!INCLUDE[](~/fundamentals/host/hosted-services/includes/hosted-services67.md)]
[!INCLUDE[](~/fundamentals/host/hosted-services/includes/hosted-services5.md)]
