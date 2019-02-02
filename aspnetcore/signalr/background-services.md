---
title: SignalR with Background Services
author: bradygaster
description: Learn how to send messages to SignalR clients from .NET Core BackgroundService classes.
monikerRange: '>= aspnetcore-2.2'
ms.author: bradyg
ms.custom: mvc
ms.date: 01/31/2018
uid: signalr/background-services
---
# Hosting SignalR in Background Services

By [Brady Gaster](https://twitter.com/bradygaster)

This article provides guidance for hosting SignalR Hubs using background worker process hosted with ASP.NET Core, and how to send messages to connected clients from within a .NET Core BackgroundService(/dotnet/api/microsoft.extensions.hosting.backgroundservice).

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/background-services/sample/) [(how to download)](xref:index#how-to-download-a-sample)

## Wiring up SignalR during Startup

Hosting ASP.NET Core SignalR Hubs in the context of a background worker process is identical to that of hosting a Hub in an ASP.NET Core web app. In the `ConfigureServices` method the `AddSignalR` method of a `Startup` class adds the required services to the ASP.NET Core DI layer to support SignalR. Then, in `Configure`, the `UseSignalR` method is called to wire up the Hub endpoint(s) in the ASP.NET Core request pipeline.

[!code-csharp[Startup](background-service/sample/Server/Startup.cs?name=Startup)]

In the example code, the `ClockHub` class implements the `Hub<T>` class to create a strongly-typed Hub. The `ClockHub` has been configured in the `Startup` class to respond to requests at the endpoint `/hubs/clock`.

> For more information on strongly-typed Hubs, see the article [Use hubs in SignalR for ASP.NET Core](/aspnet/core/signalr/hubs?view=aspnetcore-2.2#strongly-typed-hubs).

[!code-csharp[Startup](background-service/sample/Server/ClockHub.cs?name=ClockHub)]

The interface used by the strongly-typed `ClockHub` is the `IClock` interface.

[!code-csharp[Startup](background-service/sample/HubServiceInterfaces/IClock.cs?name=IClock)]

## Calling a SignalR Hub from a background service

During startup, the `Worker` class, a `BackgroundService`, is wired up using `AddHostedService`.

```csharp
services.AddHostedService<Worker>();
```

Since SignalR is also wired up during the `Startup` phase in which each Hub is attached to an individual endpoint in ASP.NET Core's HTTP request pipeline, each Hub is represented by an `IHubContext<T>` on the server. Using ASP.NET Core's dependency injection features, other classes instantiated by the hosting layer - like `BackgroundService` classes or MVC Controller classes or even Razor page models - can get references to server-side Hubs by accepting instances of  `IHubContext<ClockHub, IClock>` during construction.

[!code-csharp[Startup](background-service/sample/Server/Worker.cs?name=Worker)]

As the `ExecuteAsync` method is called iteratively in the background service, the server's current date & time are sent to the connected clients using the `ClockHub`.

## Reacting to SignalR events with Background Services

Using the [.NET Client for SignalR](/aspnet/core/signalr/dotnet-client), a `BackgroundService` or `IHostedService` implementor can also be used to connect to SignalR Hubs and respond to events, much like HTML or .NET client applications do using the JavaScript and .NET Clients for SignalR.

The `ClockHubClient` class implements both the `IClock` interface and the `IHostedService` interface. This way it can be wired up during `Startup` to run continuously and respond to Hub events from the server. 

```csharp
public partial class ClockHubClient : IClock, IHostedService
{
}
```

During initialization, the `ClockHubClient` creates an instance of a `HubConnection` and wires up the `IClock.ShowTime` method as the handler for the Hub's `ShowTime` event.

[!code-csharp[The ClockHubClient constructor](background-service/sample/Clients.ConsoleTwo/ClockHubClient.cs?name=ClockHubClientCtor)]

In the `IHostedService.StartAsync` implementation, the `HubConnection` is started asynchronously.

[!code-csharp[The ClockHubClient constructor](background-service/sample/Clients.ConsoleTwo/ClockHubClient.cs?name=StartAsync)]

During the `IHostedService.StopAsync` method, the `HubConnection` is disposed of asynchronously.

[!code-csharp[The ClockHubClient constructor](background-service/sample/Clients.ConsoleTwo/ClockHubClient.cs?name=StopAsync)]

## Related resources

* [Get started](xref:tutorials/signalr)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
* [Strongly-typed Hubs](/aspnet/core/signalr/hubs?view=aspnetcore-2.2#strongly-typed-hubs)