---
title: Use Hubs in ASP.NET Core SignalR
author: rachelappel
description: Learn how to use hubs in ASP.NET Core SignalR.
manager: wpickett
ms.author: rachelap
ms.custom: mvc
ms.date: 03/23/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/hubs
---

# Use Hubs in SignalR for ASP.NET Core

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](http://twitter.com/1kevgriff)

## What is a SignalR Hub

The SignalR Hubs API enables you to call methods on connected clients from the server. In server code, you define methods that are called by client. In client code, you define methods that are called from the server. SignalR takes care of everything behind the scenes that makes real-time client-to-server and server-to-client communications possible.

## Configure SignalR hubs

Since SignalR is middleware, a call to `services.AddSignalR` is required in the `ConfigureServices` method of the `Startup` class to register the service.

[!code-javascript[Configure service](hubs/sample/startup.cs?range=35)]

When adding SignalR functionality to an ASP.NET MVC application, setup SignalR routes by calling `app.UseSignalR` in the `Configure` method before the other routes.

[!code-javascript[Configure routes to hubs](hubs/sample/startup.cs?range=55-58)]

## Create and use hubs

To create a hub, inherit from the `Hub` class, and add public methods to it. Clients can call methods that are defined as `public`. Methods that use access modifiers such as `private` or `protected` can't accept calls from clients.

[!code-csharp[Create and use hubs](hubs/sample/hubs/chathub.cs?range=10-14)]

You can specify a return type and parameters, including complex types and arrays, as you would in any C# method. Data that you receive in parameters or return to the caller is communicated between the server and the client by using JSON. SignalR handles the binding of complex objects and arrays of objects automatically.

## Connection IDs

Each connection to a SignalR hub has a unique connection ID. This ID can be used by other parts of your application to send messages directly to a particular connection.

In the context of your hub, you can determine current by referencing its `Context.ConnectionId` object.

[!code-csharp[Connection Ids](hubs/sample/hubs/chathub.cs?range=20-24)]

## The Clients object

Each instance of the `Hub` class has a property named `Clients` that contains the following members for communication between server and client:

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

Each property or method in the preceding tables contains a `SendAsync` method. The `SendAsync` method allows you to supply the name and parameters of the client method to call.

## Send messages to clients

Yo make calls to specific clients, use the members of `Clients.Client` or `Clients.Clients`. In the following example, the `SendMessageToSingleConnection` method demonstrates sending a message to one specific connection, while the `SendMessageToMultipleConnections` method sends a message to the clients  stored in an array named `ids`.

[!code-csharp[Send messages](hubs/sample/hubs/chathub.cs?range=15-24)]

## Handle events for a connection

The SignalR Hubs API provides the `OnConnectedAsync` and `OnDisconnectedAsync` events to manage and track connections. Use the `OnConnectedAsync` event to capture the connection ID of the incoming connection.

[!code-csharp[Handle events](hubs/sample/hubs/chathub.cs?range=32-37)]

## Handle errors

Use the same method you normally would for handling errors. In hubs, wrap your method code in try-catch blocks to handle and log the exception object.

On the client, chain a `catch` method to the call to `invoke` to designate the error handling routine.

[!code-csharp[Connection Ids](hubs/sample/wwwroot/js/chat.js?range=19)]
[!code-csharp[Connection Ids](hubs/sample/wwwroot/js/chat.js?range=24-29)]

## Related Resources

[Intro to ASP.NET Core SignalR](introduction.md)