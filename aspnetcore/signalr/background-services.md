---
title: Host ASP.NET Core SignalR in background services
author: bradygaster
description: Learn how to send messages to SignalR clients from .NET Core BackgroundService classes.
monikerRange: '>= aspnetcore-2.2'
ms.author: bradyg
ms.custom: mvc
ms.date: 11/12/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/background-services
---
# Host ASP.NET Core SignalR in background services

By [Dave Pringle](https://github.com/UncleDave) and [Brady Gaster](https://twitter.com/bradygaster)

This article provides guidance for:

* Hosting SignalR Hubs using a background worker process hosted with ASP.NET Core.
* Sending messages to connected clients from within a .NET Core [BackgroundService](xref:Microsoft.Extensions.Hosting.BackgroundService).

:::moniker range=">= aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/background-service/samples/6.0) [(how to download)](xref:index#how-to-download-a-sample)

## Enable SignalR at app startup


Hosting ASP.NET Core SignalR Hubs in the context of a background worker process is identical to hosting a Hub in an ASP.NET Core web app. In `Program.cs`, calling `builder.Services.AddSignalR` adds the required services to the ASP.NET Core Dependency Injection (DI) layer to support SignalR. The `MapHub` method is called on the `WebApplication` `app` to connect the Hub endpoints in the ASP.NET Core request pipeline.

[!code-csharp[Program](background-service/samples/6.0/Server/Program.cs?name=Program)]

In the preceding example, the `ClockHub` class implements the `Hub<T>` class to create a strongly typed Hub. The `ClockHub` has been configured in `Program.cs` to respond to requests at the endpoint `/hubs/clock`.

For more information on strongly typed Hubs, see [Use hubs in SignalR for ASP.NET Core](xref:signalr/hubs#strongly-typed-hubs).

> [!NOTE]
> This functionality isn't limited to the [Hub\<T>](xref:Microsoft.AspNetCore.SignalR.Hub`1) class. Any class that inherits from [Hub](xref:Microsoft.AspNetCore.SignalR.Hub), such as [DynamicHub](xref:Microsoft.AspNetCore.SignalR.DynamicHub), works.

[!code-csharp[ClockHub](background-service/samples/6.0/Server/ClockHub.cs?name=ClockHub)]

The interface used by the strongly typed `ClockHub` is the `IClock` interface.

[!code-csharp[IClock](background-service/samples/6.0/HubServiceInterfaces/IClock.cs?name=IClock)]

## Call a SignalR Hub from a background service

During startup, the `Worker` class, a `BackgroundService`, is enabled using `AddHostedService`.

```csharp
builder.Services.AddHostedService<Worker>();
```

Since SignalR is also enabled up during the startup phase, in which each Hub is attached to an individual endpoint in ASP.NET Core's HTTP request pipeline, each Hub is represented by an `IHubContext<T>` on the server. Using ASP.NET Core's DI features, other classes instantiated by the hosting layer, like `BackgroundService` classes, MVC Controller classes, or Razor page models, can get references to server-side Hubs by accepting instances of `IHubContext<ClockHub, IClock>` during construction.

[!code-csharp[Worker](background-service/samples/6.0/Server/Worker.cs?name=Worker)]

As the `ExecuteAsync` method is called iteratively in the background service, the server's current date and time are sent to the connected clients using the `ClockHub`.

## React to SignalR events with background services

Like a Single Page App using the JavaScript client for SignalR, or a .NET desktop app using the <xref:signalr/dotnet-client>, a `BackgroundService` or `IHostedService` implementation can also be used to connect to SignalR Hubs and respond to events.

The `ClockHubClient` class implements both the `IClock` interface and the `IHostedService` interface. This way it can be enabled during startup to run continuously and respond to Hub events from the server.

```csharp
public partial class ClockHubClient : IClock, IHostedService
{
}
```

During initialization, the `ClockHubClient` creates an instance of a `HubConnection` and enables the `IClock.ShowTime` method as the handler for the Hub's `ShowTime` event.

[!code-csharp[The ClockHubClient constructor](background-service/samples/6.0/Clients.ConsoleTwo/ClockHubClient.cs?name=ClockHubClientCtor)]

In the `IHostedService.StartAsync` implementation, the `HubConnection` is started asynchronously.

[!code-csharp[StartAsync method](background-service/samples/6.0/Clients.ConsoleTwo/ClockHubClient.cs?name=StartAsync)]

During the `IHostedService.StopAsync` method, the `HubConnection` is disposed of asynchronously.

[!code-csharp[StopAsync method](background-service/samples/6.0/Clients.ConsoleTwo/ClockHubClient.cs?name=StopAsync)]

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/background-service/samples/3.x) [(how to download)](xref:index#how-to-download-a-sample)

## Enable SignalR in startup

Hosting ASP.NET Core SignalR Hubs in the context of a background worker process is identical to hosting a Hub in an ASP.NET Core web app. In the `Startup.ConfigureServices` method, calling `services.AddSignalR` adds the required services to the ASP.NET Core Dependency Injection (DI) layer to support SignalR. In `Startup.Configure`, the `MapHub` method is called in the `UseEndpoints` callback to connect the Hub endpoints in the ASP.NET Core request pipeline.

[!code-csharp[Startup](background-service/samples/3.x/Server/Startup.cs?name=Startup)]

In the preceding example, the `ClockHub` class implements the `Hub<T>` class to create a strongly typed Hub. The `ClockHub` has been configured in the `Startup` class to respond to requests at the endpoint `/hubs/clock`.

For more information on strongly typed Hubs, see [Use hubs in SignalR for ASP.NET Core](xref:signalr/hubs#strongly-typed-hubs).

> [!NOTE]
> This functionality isn't limited to the [Hub\<T>](xref:Microsoft.AspNetCore.SignalR.Hub`1) class. Any class that inherits from [Hub](xref:Microsoft.AspNetCore.SignalR.Hub), such as [DynamicHub](xref:Microsoft.AspNetCore.SignalR.DynamicHub), works.

[!code-csharp[ClockHub](background-service/samples/3.x/Server/ClockHub.cs?name=ClockHub)]

The interface used by the strongly typed `ClockHub` is the `IClock` interface.

[!code-csharp[IClock](background-service/samples/3.x/HubServiceInterfaces/IClock.cs?name=IClock)]

## Call a SignalR Hub from a background service

During startup, the `Worker` class, a `BackgroundService`, is enabled using `AddHostedService`.

```csharp
services.AddHostedService<Worker>();
```

Since SignalR is also enabled up during the `Startup` phase, in which each Hub is attached to an individual endpoint in ASP.NET Core's HTTP request pipeline, each Hub is represented by an `IHubContext<T>` on the server. Using ASP.NET Core's DI features, other classes instantiated by the hosting layer, like `BackgroundService` classes, MVC Controller classes, or Razor page models, can get references to server-side Hubs by accepting instances of `IHubContext<ClockHub, IClock>` during construction.

[!code-csharp[Worker](background-service/samples/3.x/Server/Worker.cs?name=Worker)]

As the `ExecuteAsync` method is called iteratively in the background service, the server's current date and time are sent to the connected clients using the `ClockHub`.

## React to SignalR events with background services

Like a Single Page App using the JavaScript client for SignalR, or a .NET desktop app using the <xref:signalr/dotnet-client>, a `BackgroundService` or `IHostedService` implementation can also be used to connect to SignalR Hubs and respond to events.

The `ClockHubClient` class implements both the `IClock` interface and the `IHostedService` interface. This way it can be enabled during `Startup` to run continuously and respond to Hub events from the server.

```csharp
public partial class ClockHubClient : IClock, IHostedService
{
}
```

During initialization, the `ClockHubClient` creates an instance of a `HubConnection` and enables the `IClock.ShowTime` method as the handler for the Hub's `ShowTime` event.

[!code-csharp[The ClockHubClient constructor](background-service/samples/3.x/Clients.ConsoleTwo/ClockHubClient.cs?name=ClockHubClientCtor)]

In the `IHostedService.StartAsync` implementation, the `HubConnection` is started asynchronously.

[!code-csharp[StartAsync method](background-service/samples/3.x/Clients.ConsoleTwo/ClockHubClient.cs?name=StartAsync)]

During the `IHostedService.StopAsync` method, the `HubConnection` is disposed of asynchronously.

[!code-csharp[StopAsync method](background-service/samples/3.x/Clients.ConsoleTwo/ClockHubClient.cs?name=StopAsync)]

:::moniker-end  

:::moniker range="<= aspnetcore-2.2"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/background-service/samples/2.2) [(how to download)](xref:index#how-to-download-a-sample)

## Enable SignalR in startup

Hosting ASP.NET Core SignalR Hubs in the context of a background worker process is identical to hosting a Hub in an ASP.NET Core web app. In the `Startup.ConfigureServices` method, calling `services.AddSignalR` adds the required services to the ASP.NET Core Dependency Injection (DI) layer to support SignalR. In `Startup.Configure`, the `UseSignalR` method is called to connect the Hub endpoint(s) in the ASP.NET Core request pipeline.

[!code-csharp[Startup](background-service/samples/2.2/Server/Startup.cs?name=Startup)]

In the preceding example, the `ClockHub` class implements the `Hub<T>` class to create a strongly typed Hub. The `ClockHub` has been configured in the `Startup` class to respond to requests at the endpoint `/hubs/clock`.

For more information on strongly typed Hubs, see [Use hubs in SignalR for ASP.NET Core](xref:signalr/hubs#strongly-typed-hubs).

> [!NOTE]
> This functionality isn't limited to the [Hub\<T>](xref:Microsoft.AspNetCore.SignalR.Hub`1) class. Any class that inherits from [Hub](xref:Microsoft.AspNetCore.SignalR.Hub), such as [DynamicHub](xref:Microsoft.AspNetCore.SignalR.DynamicHub), works.

[!code-csharp[ClockHub](background-service/samples/2.2/Server/ClockHub.cs?name=ClockHub)]

The interface used by the strongly typed `ClockHub` is the `IClock` interface.

[!code-csharp[IClock](background-service/samples/2.2/HubServiceInterfaces/IClock.cs?name=IClock)]

## Call a SignalR Hub from a background service

During startup, the `Worker` class, a `BackgroundService`, is enabled using `AddHostedService`.

```csharp
services.AddHostedService<Worker>();
```

Since SignalR is also enabled up during the `Startup` phase, in which each Hub is attached to an individual endpoint in ASP.NET Core's HTTP request pipeline, each Hub is represented by an `IHubContext<T>` on the server. Using ASP.NET Core's DI features, other classes instantiated by the hosting layer, like `BackgroundService` classes, MVC Controller classes, or Razor page models, can get references to server-side Hubs by accepting instances of `IHubContext<ClockHub, IClock>` during construction.

[!code-csharp[Startup](background-service/samples/2.2/Server/Worker.cs?name=Worker)]

As the `ExecuteAsync` method is called iteratively in the background service, the server's current date and time are sent to the connected clients using the `ClockHub`.

## React to SignalR events with background services

Like a Single Page App using the JavaScript client for SignalR, or a .NET desktop app using the <xref:signalr/dotnet-client>, a `BackgroundService` or `IHostedService` implementation can also be used to connect to SignalR Hubs and respond to events.

The `ClockHubClient` class implements both the `IClock` interface and the `IHostedService` interface. This way it can be enabled during `Startup` to run continuously and respond to Hub events from the server.

```csharp
public partial class ClockHubClient : IClock, IHostedService
{
}
```

During initialization, the `ClockHubClient` creates an instance of a `HubConnection` and enables the `IClock.ShowTime` method as the handler for the Hub's `ShowTime` event.

[!code-csharp[The ClockHubClient constructor](background-service/samples/2.2/Clients.ConsoleTwo/ClockHubClient.cs?name=ClockHubClientCtor)]

In the `IHostedService.StartAsync` implementation, the `HubConnection` is started asynchronously.

[!code-csharp[StartAsync method](background-service/samples/2.2/Clients.ConsoleTwo/ClockHubClient.cs?name=StartAsync)]

During the `IHostedService.StopAsync` method, the `HubConnection` is disposed of asynchronously.

[!code-csharp[StopAsync method](background-service/samples/2.2/Clients.ConsoleTwo/ClockHubClient.cs?name=StopAsync)]

:::moniker-end

## Additional resources

* [Get started](xref:tutorials/signalr)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
* [Strongly typed Hubs](xref:signalr/hubs#strongly-typed-hubs)
