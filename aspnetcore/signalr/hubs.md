---
title: Use hubs in ASP.NET Core SignalR
author: tdykstra
description: Learn how to use hubs in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 09/12/2018
uid: signalr/hubs
---

# Use hubs in SignalR for ASP.NET Core

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/hubs/sample/ ) [(how to download)](xref:index#how-to-download-a-sample)

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

## The Context object

The `Hub` class has a `Context` property that contains the following properties with information about the connection:

| Property | Description |
| ------ | ----------- |
| `ConnectionId` | Gets the unique ID for the connection, assigned by SignalR. There is one connection ID for each connection.|
| `UserIdentifier` | Gets the [user identifier](xref:signalr/groups). By default, SignalR uses the `ClaimTypes.NameIdentifier` from the `ClaimsPrincipal` associated with the connection as the user identifier. |
| `User` | Gets the `ClaimsPrincipal` associated with the current user. |
| `Items` | Gets a key/value collection that can be used to share data within the scope of this connection. Data can be stored in this collection and it will persist for the connection across different hub method invocations. |
| `Features` | Gets the collection of features available on the connection. For now, this collection isn't needed in most scenarios, so it isn't documented in detail yet. |
| `ConnectionAborted` | Gets a `CancellationToken` that notifies when the connection is aborted. |

`Hub.Context` also contains the following methods:

| Method | Description |
| ------ | ----------- |
| `GetHttpContext` | Returns the `HttpContext` for the connection, or `null` if the connection is not associated with an HTTP request. For HTTP connections, you can use this method to get information such as HTTP headers and query strings. |
| `Abort` | Aborts the connection. |

## The Clients object

The `Hub` class has a `Clients` property that contains the following properties for communication between server and client:

| Property | Description |
| ------ | ----------- |
| `All` | Calls a method on all connected clients |
| `Caller` | Calls a method on the client that invoked the hub method |
| `Others` | Calls a method on all connected clients except the client that invoked the method |


`Hub.Clients` also contains the following methods:

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

## Strongly typed hubs

A drawback of using `SendAsync` is that it relies on a magic string to specify the client method to be called. This leaves code open to runtime errors if the method name is misspelled or missing from the client.

An alternative to using `SendAsync` is to strongly type the `Hub` with <xref:Microsoft.AspNetCore.SignalR.Hub`1>. In the following example, the `ChatHub` client methods have been extracted out into an interface called `IChatClient`.  

[!code-csharp[Interface for IChatClient](hubs/sample/hubs/ichatclient.cs?name=snippet_IChatClient)]

This interface can be used to refactor the preceding `ChatHub` example.

[!code-csharp[Strongly typed ChatHub](hubs/sample/hubs/StronglyTypedChatHub.cs?range=8-18,36)]

Using `Hub<IChatClient>` enables compile-time checking of the client methods. This prevents issues caused by using magic strings, since `Hub<T>` can only provide access to the methods defined in the interface.

Using a strongly typed `Hub<T>` disables the ability to use `SendAsync`.

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
