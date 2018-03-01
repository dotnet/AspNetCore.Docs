---
title: Introduction to SignalR on ASP.NET Core
author: rachelappel
description: Learn how the ASP.NET Core SignalR library simplifies adding real-time web functionality to apps.
manager: wpickett
ms.author: rachelap
ms.custom: mvc
ms.date: 2/19/2018
ms.prod: aspnet-core
ms.technology: dotnet-signalr
ms.topic: article
uid: signalr/introduction-signalr-core
---
# Introduction to SignalR

By [Rachel Appel](https://twitter.com/rachelappel)

## What is SignalR?

ASP.NET Core SignalR is a library that simplifies adding real-time web functionality to apps. Real-time web functionality is the ability to have server code push content to connected clients instantly as it becomes available, rather than having the server wait for a client to request new data.

Good candidates for adding real-time updates include:

* Apps that require high frequency updates from the server. Real-time gaming, social networks, maps and GPS apps, require high frequency updates.
* Dashboards and monitoring apps. Some examples of these include voting and auction software.
* Collaborative apps. Whiteboard apps and team meeting software are examples of collaborative apps.
* Apps that require notifications. Social networks, email, chat, games, and many more types of apps use notifications.

SignalR provides an API for creating server-to-client remote procedure calls (RPC). The RPCs call JavaScript functions on browsers or other client platforms from server-side .NET Core code. The SignalR API includes features such as connection management, groups,  messaging, and security.

SignalR for ASP.NET Core:

* Handles connection management automatically.
* Enables broadcasting messages to all connected clients simultaneously. For example, a chat room.
* Enables sending messages to specific clients or groups of clients.
* Is open-sourced at [GitHub](https://github.com/aspnet/SignalR).
* Scales nicely.

The connection between the client and server is persistent, unlike an HTTP connection. 

## Transports and fallbacks

 SignalR is an abstraction over some of the transports that are required to do real-time work between client and server. A SignalR connection starts as HTTP. SignalR uses the [WebSocket transport](https://tools.ietf.org/html/rfc7118) when available, and falls back to other transports when it's not available. WebSocket is the ideal transport for SignalR. This is because it makes the most efficient use of server memory, has the lowest latency, and has the most underlying features, such as full duplex communication between client and server. SignalR automatically assigns a transport per connection for you automatically, though you can override this functionality.

## Hubs and Endpoints

The SignalR API contains two models for communicating between clients and servers: Hubs and Persistent Connections. The Hubs API covers the vast majority of scenarios the average ASP.NET developer needs.

An Endpoint receives a raw socket-like API to read and write from the client. It's up to the user to handle grouping, broadcasting, etc. The Hubs API is built on top of the Endpoints layer.

A Hub is a high-level pipeline built upon the Endpoint API that allows your client and server to call methods on each other. SignalR handles the dispatching across machine boundaries as if by magic, allowing clients to call methods on the server as easily as local methods, and vice versa. Using a Hub allows you to pass strongly typed parameters to methods, enabling model binding. SignalR provides two built-in hub protocols: a text protocol based on JSON and a binary protocol based on [MessagePack](http://msgpack.org/). Using  MessagePack generally creates smaller messages than when using JSON. Note that older browsers that do not support [XHR level 2](https://caniuse.com/#feat=xhr2) cannot support the MessagePack protocol.

When server-side code calls a method on the client, a message is sent across the active transport that contains the name and parameters of the method to be called. Objects sent as method parameters are serialized using JSON. The client then matches the method name to methods defined in client-side code. If there is a match, the client method will be executed using the deserialized parameter data.

The following diagram shows the relationship between hubs, endpoints, and clients.

![SignalR architecture diagram](introduction-signalr-core/_static/signalr-core-architecture.png)

## Related Resources

[Get Started with SignalR for ASP.NET Core](get-started-signalr-core)