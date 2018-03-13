---
title: Use Hubs in SignalR for ASP.NET Core
author: rachelappel
description: Learn how to use hubs in SignalR Core.
manager: wpickett
ms.author: rachelap
ms.custom: mvc
ms.date: 03/16/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/use-hubs-signalr-core
---

# Use Hubs in SignalR for ASP.NET Core

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](http://twitter.com/1kevgriff)


## What is a SignalR Hub

The SignalR Hubs API enables you to call methods on connected clients from the server. In server code, you define methods that are called by client. In client code, you define methods that are called from the server. SignalR takes care of everything behind the scenes that makes nearly instant client-to-server and server-to-client communications possible.

## Configure SignalR in an ASP.NET Core app

To define the route to your hub, call the `MapSignalR` method when the application starts.


## Create and use hubs

Hub object lifetime
Camel-casing of Hub names in JavaScript clients
strongly-typed Hubs


## Send messages to connections

Use `Clients.Client` or `Clients.Clients` to make calls to clients by their connection. The `SendToOneConnectionId` method demonstrates sending a message to one specific connection, while the `SendToManyConnectionIds` method sends a message to the clients  stored in an array named `ids`.

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

## The `Clients` object

Each instance of the `Hub` class has an object named `Clients` that contains the following properties for communication between server and client:

| Property | Description |
| ------ | ----------- |
| All | Calls a method on all connected clients |
| Caller | Calls a method on all connected clients |
| Others | Calls a method on clients other than a specific connection |

Additionally, the `Hub` class contains the following methods:

| Method | Description |
| ------ | ----------- |
| AllExcept | Calls a method on all connected clients except a specified connection |
| Client | Calls a method on a specific connected client |
| Clients | Calls a method on specific connected clients |
| Group | Sends a message to a group of connections  |
| GroupExcept | Sends a message to a group of connections, excluding  the specified group |
| Groups | Sends a message to multiple groups of connections  |
| OthersInGroup | Sends a message to others in a group of connections  |
| User | Sends a message to a specific user |
| Users | Sends a message to multiple users |


## Connection IDs

Each connection to a SignalR hub has a unique connection ID. This ID can be used by other parts of your application to send messages directly to a particular connection.

In the context of your hub, you can determine current by referencing its `Context.ConnectionId` object.

```csharp
public class MyHub : Hub
{
    public Task HubMethod()
    {
        // this connection ID is UNIQUE to the current connection
        var connectionId = Context.ConnectionId;
    }
}
```

## Handle events for a connection

The SignalR Hubs API provides the `OnConnectedAsync` and `OnDisconnectedAsync` events to manage and track connections.



## Handle errors


## Related Resources