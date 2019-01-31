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

This article provides guidance for hosting SignalR Hubs using background worker process hosted with ASP.NET Core, and how to send messages to connected clients from within a .NET Core [`BackgroundService`](/dotnet/api/microsoft.extensions.hosting.backgroundservice).

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/background-services/sample/) [(how to download)](xref:index#how-to-download-a-sample)

> Note: more text will be added, this is mostly placeholder for now.

## Wiring up SignalR during Startup

Wiring up SignalR:

[!code-csharp[Startup](background-service/sample/Server/Startup.cs?name=Startup)]

The `ClockHub` class, which shows off a strong-typed Hub. For more information on strongly-typed Hubs, see the article [Use hubs in SignalR for ASP.NET Core](/aspnet/core/signalr/hubs?view=aspnetcore-2.2#strongly-typed-hubs).

[!code-csharp[Startup](background-service/sample/Server/ClockHub.cs?name=ClockHub)]

The interface used by the strongly-typed `ClockHub` is the `IClock` interface.

[!code-csharp[Startup](background-service/sample/HubServiceInterfaces/IClock.cs?name=IClock)]

## Calling a SignalR Hub from a background service

During startup a `BackgroundService` is wired up using `AddHostedService`.

```csharp
services.AddHostedService<Worker>();
```

An instance of the `IHubContext<ClockHub>` is passed into the constructor of the `Worker` when it is created.

[!code-csharp[Startup](background-service/sample/Server/Worker.cs?name=Worker)]

As the `ExecuteAsync` method is called iteratively in the background service, the server's current date & time are sent to the connected clients using the `ClockHub`.

## Related resources

* [Get started](xref:tutorials/signalr)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
* [Strongly-typed Hubs](/aspnet/core/signalr/hubs?view=aspnetcore-2.2#strongly-typed-hubs)