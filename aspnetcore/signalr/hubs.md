---
title: Use hubs in ASP.NET Core SignalR
author: rachelappel
description: Learn how to use hubs in ASP.NET Core SignalR.
manager: wpickett
ms.author: rachelap
ms.custom: mvc
ms.date: 03/30/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/hubs
---

# Use hubs in SignalR for ASP.NET Core

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

## What is a SignalR hub

The SignalR Hubs API enables you to call methods on connected clients from the server. In the server code, you define methods that are called by client. In the client code, you define methods that are called from the server. SignalR takes care of everything behind the scenes that makes real-time client-to-server and server-to-client communications possible.

## Configure SignalR hubs

The SignalR middleware requires some services to be able to run. To configure those call `services.AddSignalR`.

[!code-javascript[Configure service](hubs/sample/startup.cs?range=35)]

When adding SignalR functionality to an ASP.NET Core app, setup SignalR routes by calling `app.UseSignalR` in the `Startup.Configure` method.

[!code-javascript[Configure routes to hubs](hubs/sample/startup.cs?range=55-58)]

## Create and use hubs

Create a hub by declaring a class that inherits from `Hub`, and add public methods to it. Clients can call methods that are defined as `public`.

[!code-csharp[Create and use hubs](hubs/sample/hubs/chathub.cs?range=10-14)]

You can specify a return type and parameters, including complex types and arrays, as you would in any C# method. SignalR handles the serialization and deserialization of complex objects and arrays in your parameters and return values.

## The Clients object

Each instance of the `Hub` class has a property named `Clients` that contains the following members for communication between server and client:

| Property | Description |
| ------ | ----------- |
| `All` | Calls a method on all connected clients |
| `Caller` | Calls a method on the currently connected client |
| `Others` | Calls a method on all connected clients except the client that invoked the method |

Additionally, the `Hub` class contains the following methods:

| Method | Description |
| ------ | ----------- |
| `AllExcept` | Calls a method on all connected clients except for the provided connections |
| `Client` | Calls a method on a specific connected client |
| `Clients` | Calls a method on specific connected clients |
| `Group` | Sends a message to all connections in the specified group  |
| `GroupExcept` | Sends a message to all connections in the specified group, except the specified connections |
| `Groups` | Sends a message to multiple groups of connections  |
| `OthersInGroup` | Sends a message to others in a group of connections  |
| `User` | Sends a message to all connections associated with a specific user |
| `Users` | Sends a message to all connections associated with the specified users |

Each property or method in the preceding tables returns an object with a `SendAsync` method. The `SendAsync` method allows you to supply the name and parameters of the client method to call.

## Send messages to clients

To make calls to specific clients, use the members of `Clients.Client` or `Clients.Clients`. In the following example, the `SendMessageToSingleConnection` method demonstrates sending a message to one specific connection. The `SendMessageToMultipleConnections` method sends a message to the clients stored in an array named `ids`.

[!code-csharp[Send messages](hubs/sample/hubs/chathub.cs?range=15-24)]

## Handle events for a connection

The SignalR Hubs API provides the `OnConnectedAsync` and `OnDisconnectedAsync` virtual methods to manage and track connections. Override the `OnConnectedAsync` virtual method to perform actions when a client connects to the Hub, such as adding it to a group.

[!code-csharp[Handle events](hubs/sample/hubs/chathub.cs?range=32-37)]

## Handle errors

Exceptions thrown in your hub methods are sent to the client that invoked the method. On the client, the `invoke` method returns a [JavaScript Promise](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Using_promises). When the client receives an error with a handler attached to the promise using `catch`, it's invoked and passed as a JavaScript `Error` object.

[!code-csharp[Error](hubs/sample/wwwroot/js/chat.js?range=19)]
[!code-csharp[Error](hubs/sample/wwwroot/js/chat.js?range=24-29)]

## Related resources

[Intro to ASP.NET Core SignalR](xref:signalr/introduction)