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

# Sending Messages Outside of you Hub Class

By [Mikael Mengistu](https://github.com/mikaelm12)

The SignalR Hub is the core abstraction for sending messages to clients connectied to our SignalR server. You aren't limited to sending messages to clients from within a Hub though. Here we'll look at how to access a SignalR HubContext to send notification to clients from outside of a hub.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/hubcontext/sample/) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## Using the HubContext

In ASP.NET Core SignalR you can get access to an instance of HubContext via dependency injection. You can get an instance of HubContext<YourHubType> in ana MVC Controller or middleware this way. In previous versions of SignalR you would do this by explicitly asking for an instance of HubContext via a connection manager but that has been replaced in favor of our dependency injection approach.

Getting an instance of HubContext in a Controller

[!code-csharp[HubContext](hubcontext/sample/Controllers/HomeController.cs?range=12-19)]


Now with access to an instance of HubContext, we can call our hub methods as if we were in the hub itself. 

[!code-csharp[HubContext](hubcontext/sample/Controllers/HomeController.cs?range=21-25)]


#Getting an instance of HubContext in Middleware

We can also get access to our HubContext within the Middleware pipeline like so.

```csharp
           app.Use(next => (context) =>
            {
                var hubContext = (IHubContext<YourHubType>)context.RequestServices.GetServices<IHubContext<YourHubType>>();
		...
	    }
```

One thing to note about calling Hub methods from outside of your Hub is that since there is no caller associated with the invocation you don't have access to a ConnectionId and therefore don't have access to the `Caller` and `Others` properties.

## Related resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)