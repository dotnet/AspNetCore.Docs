---
title: Use hubs in ASP.NET Core SignalR
author: tdykstra
description: Learn how to use hubs in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 05/01/2018
uid: signalr/hubs
---

# Use hubs in SignalR for ASP.NET Core

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/hubs/sample/ ) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## What is a SignalR hub

The SignalR Hubs API enables you to call methods on connected clients from the server. In the server code, you define methods that are called by client. In the client code, you define methods that are called from the server. SignalR takes care of everything behind the scenes that makes real-time client-to-server and server-to-client communications possible.

## Configure SignalR hubs

The SignalR middleware requires some services, which are configured by calling `services.AddSignalR`.

[!code-csharp[Configure service](hubs/sample/startup.cs?range=38)]

When adding SignalR functionality to an ASP.NET Core app, setup SignalR routes by calling `app.UseSignalR` in the `Startup.Configure` method.

[!code-csharp[Configure routes to hubs](hubs/sample/startup.cs?range=57-60)]

## Create and use hubs

Create a hub by declaring a class that inherits from `Hub`, and add public methods to it. Clients can call methods that are defined as `public`.

[!code-csharp[Create and use hubs](hubs/sample/hubs/chathub.cs?range=8-37)]

You can specify a return type and parameters, including complex types and arrays, as you would in any C# method. SignalR handles the serialization and deserialization of complex objects and arrays in your parameters and return values.

## The Clients object

Each instance of the `Hub` class has a property named `Clients` that contains the following members for communication between server and client:

| Property | Description |
| ------ | ----------- |
| `All` | Calls a method on all connected clients |
| `Caller` | Calls a method on the client that invoked the hub method |
| `Others` | Calls a method on all connected clients except the client that invoked the method |


Additionally, `Hub.Clients` contains the following methods:

| Method | Description |
| ------ | ----------- |
| `AllExcept` | Calls a method on all connected clients except for the specified connections |
| `Client` | Calls a method on a specific connected client |
| `Clients` | Calls a method on specific connected clients |
| `Group` | Calls a method to all connections in the specified group  |
| `GroupExcept` | Calls a method to all connections in the specified group, except the specified connections |
| `Groups` | Calls a method to multiple groups of connections  |
| `OthersInGroup` | Calls a method to a group of connections, excluding the client that invoked the hub method  |
| `User` | Calls a method to all connections associated with a specific user |
| `Users` | Calls a method to all connections associated with the specified users |

Each property or method in the preceding tables returns an object with a `SendAsync` method. The `SendAsync` method allows you to supply the name and parameters of the client method to call.

## Send messages to clients

To make calls to specific clients, use the properties of the `Clients` object. In the following example, the `SendMessageToCaller` method demonstrates sending a message to the connection that invoked the hub method. The `SendMessageToGroups` method sends a message to the groups stored in a `List` named `groups`.

[!code-csharp[Send messages](hubs/sample/hubs/chathub.cs?range=15-24)]

## Handle events for a connection

The SignalR Hubs API provides the `OnConnectedAsync` and `OnDisconnectedAsync` virtual methods to manage and track connections. Override the `OnConnectedAsync` virtual method to perform actions when a client connects to the Hub, such as adding it to a group.

[!code-csharp[Handle events](hubs/sample/hubs/chathub.cs?range=26-36)]

## Handle errors

Exceptions thrown in your hub methods are sent to the client that invoked the method. On the JavaScript client, the `invoke` method returns a [JavaScript Promise](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Using_promises). When the client receives an error with a handler attached to the promise using `catch`, it's invoked and passed as a JavaScript `Error` object.

[!code-javascript[Error](hubs/sample/wwwroot/js/chat.js?range=23)]

## Related resources

* [Intro to ASP.NET Core SignalR](xref:signalr/introduction)
* [JavaScript client](xref:signalr/javascript-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
