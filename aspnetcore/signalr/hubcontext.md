---
title: SignalR HubContext
author: rachelappel
description: Overview of the use of SignalR's HubContext
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 6/12/18
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/HubContext
---

# Sending Messages From Outside a `Hub`

By [Mikael Mengistu](https://github.com/mikaelm12)

The SignalR Hub is the core abstraction for sending messages to clients connected to our SignalR server. However, it is also possible to send messages from other places in your application using the IHubContext service. Here we'll look at how to access a SignalR IHubContext to send notification to clients from outside of a hub.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/hubcontext/sample/) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## Get an instance of `HubContext

In ASP.NET Core SignalR you can get access to an instance of IHubContext via dependency injection. You can inject an instance of IHubContext<YourHubType> into a Controller, Middleware or other DI service and use it to send messages to clients..

> [!NOTE]
> This differs from ASP.NET SignalR which used `GlobalHost` to provide access to the `IHubContext` because there was no built-in dependency injection system.

### Inject an instance of `HubContext` in a Controller

We can inject an instance of IHubContext into a Controller by adding it to your constructor:

[!code-csharp[HubContext](hubcontext/sample/Controllers/HomeController.cs?range=12-19)]

Now with access to an instance of HubContext, we can call our hub methods as if we were in the hub itself. 

[!code-csharp[HubContext](hubcontext/sample/Controllers/HomeController.cs?range=21-25)]


### Getting an instance of `HubContext` in Middleware
Access the HubContext within the Middleware pipeline like so.

```csharp
           app.Use(next => (context) =>
            {
                var hubContext = (IHubContext<YourHubType>)context.RequestServices.GetServices<IHubContext<YourHubType>>();
		...
	    }
```


> [!NOTE] 
> When hub methods are called from outside of the `Hub` class, there is no caller associated with the invocation. Therefore, there is no access to the `ConnectionId`, `Caller`, and `Others` properties.

## Related resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)