---
uid: signalr/introduction-to-signalr
title: Introduction to SignalR on ASP.NET Core
author: rachelappel
ms.author: rachelap
description: An overview of SignalR on ASP.NET Core
manager: wpickett
ms.date: 2/19/2018
ms.topic: article
ms.technology: dotnet-signalr
ms.prod: aspnet-core
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
* Scales nicely using [Azure Service Bus](https://azure.microsoft.com/en-us/services/service-bus/), SQL Server, or [Redis](http://redis.io).

The connection between the client and server is persistent, unlike an HTTP connection. 

## Transports and fallbacks

 SignalR is an abstraction over some of the transports that are required to do real-time work between client and server. A SignalR connection starts as HTTP. SignalR uses the [WebSocket transport](https://tools.ietf.org/html/rfc7118) when available, and falls back to other transports when it's not available. WebSocket is the ideal transport for SignalR. This is because it makes the most efficient use of server memory, has the lowest latency, and has the most underlying features, such as full duplex communication between client and server. However, it also has the most stringent requirements: WebSocket requires the server to be using Windows Server 2012 or Windows 8, and .NET Framework 4.5, or later versions of these. If these requirements are not met, SignalR will attempt to use other transports to make its connections. The important thing to note is that SignalR automatically assigns a transport per connection for you automatically, though you can override this functionality.

## Hubs and Connections

The SignalR API contains two models for communicating between clients and servers: Hubs and Persistent Connections. The Hubs API covers the vast majority of scenarios the average ASP.NET developer needs.

a layer that provides a raw socket-like API on top of Long Polling/Server-Sent Events/WebSockets, and as the layer on which SignalR is built

A Connection represents a simple endpoint for sending single-recipient, grouped, or broadcast messages. The Persistent Connection API gives the developer direct access to the low-level communication protocol for SignalR. 

A Hub is a high-level pipeline built upon the Connection API that allows your client and server to call methods on each other directly. SignalR handles the dispatching across machine boundaries as if by magic, allowing clients to call methods on the server as easily as local methods, and vice versa. Using a Hub allows you to pass strongly typed parameters to methods, enabling model binding. SignalR provides two built-in hub protocols: a text protocol based on JSON and a binary protocol based on MessagePack. Using  MessagePack generally creates smaller messages than when using JSON.

When server-side code calls a method on the client, a packet is sent across the active transport that contains the name and parameters of the method to be called. Objects sent as method parameters are serialized using JSON. The client then matches the method name to methods defined in client-side code. If there is a match, the client method will be executed using the deserialized parameter data.

## SignalR for ASP.NET Core Architecture

The following diagram shows the relationship between Hubs, endpoints, and the underlying technologies used for transports.

![SignalR Architecture Diagram showing APIs, transports, and clients](introduction-to-signalr/_static/signalr-core-architecture.png)