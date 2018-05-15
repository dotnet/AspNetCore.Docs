---
title: Introduction to ASP.NET Core SignalR
author: rachelappel
description: Learn how the ASP.NET Core SignalR library simplifies adding real-time functionality to apps.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 04/25/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/introduction
---
# Introduction to ASP.NET Core SignalR

By [Rachel Appel](https://twitter.com/rachelappel)

## What is SignalR?

ASP.NET Core SignalR is a library that simplifies adding real-time web functionality to apps. Real-time web functionality enables server-side code to push content to clients instantly.

Good candidates for SignalR:

* Apps that require high frequency updates from the server. Examples are gaming, social networks, voting, auction, maps, and GPS apps.
* Dashboards and monitoring apps. Examples include company dashboards, instant sales updates, or travel alerts.
* Collaborative apps. Whiteboard apps and team meeting software are examples of collaborative apps.
* Apps that require notifications. Social networks, email, chat, games, travel alerts, and many other apps use notifications.

SignalR provides an API for creating server-to-client [remote procedure calls (RPC)](https://wikipedia.org/wiki/Remote_procedure_call). The RPCs call JavaScript functions on clients from server-side .NET Core code.

SignalR for ASP.NET Core:

* Handles connection management automatically.
* Enables broadcasting messages to all connected clients simultaneously. For example, a chat room.
* Enables sending messages to specific clients or groups of clients.
* Is open-sourced at [GitHub](https://github.com/aspnet/signalr).
* Scalable.

The connection between the client and server is persistent, unlike an HTTP connection.

## Transports

SignalR abstracts over a number of techniques for building real-time web applications. [WebSockets](https://tools.ietf.org/html/rfc7118) is the optimal transport, but other techniques like Server-Sent Events and Long Polling can be used when those aren't available. SignalR will automatically detect and initialize the appropriate transport based on features supported on the server and client.

## Hubs

SignalR uses hubs to communicate between clients and servers.

A hub is a high-level pipeline that allows your client and server to call methods on each other. SignalR handles the dispatching across machine boundaries automatically, allowing clients to call methods on the server as easily as local methods, and vice versa. Hubs allow passing strongly-typed parameters to methods, which enables model binding. SignalR provides two built-in hub protocols: a text protocol based on JSON and a binary protocol based on [MessagePack](https://msgpack.org/).  MessagePack generally creates smaller messages than when using JSON. Older browsers must support [XHR level 2](https://caniuse.com/#feat=xhr2) to provide MessagePack protocol support.

Hubs call client-side code by sending messages using the active transport. The messages contain the name and parameters of the client-side method. Objects sent as method parameters are deserialized using the configured protocol. The client tries to match the name to a method in the client-side code. When a match happens, the client method runs using the deserialized parameter data.

## Additional resources

* [Get started with SignalR for ASP.NET Core](xref:signalr/get-started)
* [Supported Platforms](xref:signalr/supported-platforms)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
