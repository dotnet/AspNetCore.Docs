---
title: SignalR HubContext
author: tdykstra
description: Learn how to use the ASP.NET Core SignalR HubContext service for sending notifications to clients from outside a hub.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 06/13/2018
uid: signalr/hubcontext
---
# Send messages from outside a hub

By [Mikael Mengistu](https://twitter.com/MikaelM_12)

The SignalR hub is the core abstraction for sending messages to clients connected to the SignalR server. It's also possible to send messages from other places in your app using the `IHubContext` service. This article explains how to access a SignalR `IHubContext` to send notifications to clients from outside a hub.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/hubcontext/sample/) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## Get an instance of `IHubContext`

In ASP.NET Core SignalR, you can access an instance of `IHubContext` via dependency injection. You can inject an instance of `IHubContext` into a controller, middleware, or other DI service. Use the instance to send messages to clients.

> [!NOTE]
> This differs from ASP.NET SignalR which used GlobalHost to provide access to the `IHubContext`. ASP.NET Core has a dependency injection framework that removes the need for this global singleton.

### Inject an instance of `IHubContext` in a controller

You can inject an instance of `IHubContext` into a controller by adding it to your constructor:

[!code-csharp[IHubContext](hubcontext/sample/Controllers/HomeController.cs?range=12-19,57)]

Now, with access to an instance of `IHubContext`, you can call hub methods as if you were in the hub itself.

[!code-csharp[IHubContext](hubcontext/sample/Controllers/HomeController.cs?range=21-25)]

### Get an instance of `IHubContext` in middleware

Access the `IHubContext` within the middleware pipeline like so:

```csharp
app.Use(next => (context) =>
{
    var hubContext = (IHubContext<MyHub>)context
                        .RequestServices
                        .GetServices<IHubContext<MyHub>>();
    //...
});
```

> [!NOTE]
> When hub methods are called from outside of the `Hub` class, there's no caller associated with the invocation. Therefore, there's no access to the `ConnectionId`, `Caller`, and `Others` properties.

## Related resources

* [Get started](xref:tutorials/signalr)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
