---
title: SignalR HubContext
author: rachelappel
description: Learn how to use the ASP.NET Core SignalR HubContext service for sending notifications to clients from outside a hub.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 06/13/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/HubContext
---
# Send messages from outside a hub

By [Mikael Mengistu](https://github.com/mikaelm12)


The SignalR hub is the core abstraction for sending messages to clients connected to the SignalR server. It's also possible to send messages from other places in your app using the `IHubContext<T>` service. This article explains how to access a SignalR `IHubContext<T>` to send notification to clients from outside a hub.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/hubcontext/sample/) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## Get an instance of `HubContext`

In ASP.NET Core SignalR, you can access an instance of `IHubContext<T>` via dependency injection. You can inject an instance of `IHubContext<your_hub_type>` into a controller, middleware, or other DI service. Use the instance to send messages to clients.

> [!NOTE]
> This differs from ASP.NET SignalR which used `GlobalHost` to provide access to the `IHubContext`. There was no built-in dependency injection system in ASP.NET.

### Inject an instance of `HubContext` in a controller

You can inject an instance of `IHubContext` into a controller by adding it to your constructor:

[!code-csharp[HubContext](hubcontext/sample/Controllers/HomeController.cs?range=12-19)]

Now with access to an instance of `HubContext`, you can call hub methods as if you were in the hub itself.

[!code-csharp[HubContext](hubcontext/sample/Controllers/HomeController.cs?range=21-25)]

### Get an instance of `HubContext` in middleware

Access the `IHubContext<T>` within the middleware pipeline like so:

```csharp
app.Use(next => (context) =>
{
    var hubContext = (IHubContext<your_hub_type>)context
                        .RequestServices
                        .GetServices<IHubContext<your_hub_type>>();
    ...
}
```

> [!NOTE]
> When hub methods are called from outside of the `Hub` class, there's no caller associated with the invocation. Therefore, there's no access to the `ConnectionId`, `Caller`, and `Others` properties.

## Related resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)