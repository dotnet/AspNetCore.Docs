---
title: SignalR HubContext
author: rachelappel
description: Overview of the use of SignalR's HubContext
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/HubContext
---

# Sending Messages Outside of you Hub Class

By [Mikael Mengistu](https://github.com/mikaelm12)

The SignalR Hub is the core abstraction for sending messages to connected clients. From within a SignalR Hub you can decide which clients to s

**Add Sample Code!**
[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/groups/sample/) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## Using the HubContext

In ASP.NET Core SignalR you can get access to an instance of HubContext via dependency injection. You can get an instance of HubContext<YourHubType> in ana MVC Controller or middleware this way. In previous versions of SignalR you would do this by explicitly asking for an instance of HubContext via a connection manager but that has been replaced in favor of our dependency injection approach.

Getting an instance of HubContext in a Controller

```csharp
    public class SimpleController : Controller
    {
        private IHubContext<YourHubType> _hubContext;

        public SimpleController(IHubContext<YourHubType> hubContext)
        {
            _hubContext = hubContext;
        }
	...
```

Now with access to an instance of HubContext, we can call our hub methods as if we were in the hub itself. 

```csharp
        [HttpGet]
        public string Get()
        {
            _hubContext.Clients.All.InvokeAsync("notify", "notification");   
        }

```

Getting an instance of HubContext in Middleware

```csharp
           app.Use(next => (context) =>
            {
                var hubContext = (IHubContext<YourHubType>)context.RequestServices.GetServices<IHubContext<YourHubType>>();
		...
	    }
```

One thing to note about calling Hub methods from outside of your Hub is that since there is no caller associated with the invocation you don't have access to a ConnectionId and therefore don't have access to the Caller others properties.

## Related resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)