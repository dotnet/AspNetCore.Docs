---
title: Use Hubs in SignalR for ASP.NET Core
author: rachelappel
description: Learn how to use hubs in SignalR Core.
manager: wpickett
ms.author: rachelap
ms.custom: mvc
ms.date: 03/08/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/use-hubs-signalr-core
---

# Use Hubs in SignalR for ASP.NET Core

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](http://twitter.com/1kevgriff)


## What is a SignalR Hub

The SignalR Hubs API enables you to call methods on connected clients from the server. In server code, you define methods that can be called by clients, and you call methods that run on the client. In client code, you define methods that can be called from the server, and you call methods that run on the server. SignalR takes care of the client-to-server plumbing for you.

## Configure connections 
### Connection Ids
Each connection to a SignalR hub will be given its own connection id.  This connection id can be used by other parts of your application to send messages directly to a particular connection.

In the context of your Hub, you can determine the connection id for the current connection by referencing the `Context.ConnectionId` object.

```csharp
public class MyHub : Hub
{
    public Task HubMethod()
    {
        var connectionId = Context.ConnectionId; // this connection id is UNIQUE to the current connection
    }
}
```

Unique connection Id
OnConnected OnDisconnected events
Reconnecting

## Send message to clients

### Sending to a Connection Id
If you know the connection id of the connection(s) you'd like to send an event to, you can use `Clients.Client` or `Clients.Clients` to invoke the request.

```csharp
public class MyHub : Hub
{
    public async Task SendToOneConnectionId()
    {
        var connectionIdToSendTo = "fb83d9c6-e026-4ce3-a815-d2916ebcf448";
        await Clients.Client(connectionIdToSendTo).SendAsync("methodToInvoke");
    }

    public async Task SendToManyConnectionIds()
    {
        var ids = new string[]
        {
            "fb83d9c6-e026-4ce3-a815-d2916ebcf448",
            "07bcd5d5-5b1d-4428-87f2-6ecef45d4968"
        };
        await Clients.Clients(ids).SendAsync("methodToInvoke");
    }
}
```

Clients object

## Related Resources