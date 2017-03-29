7---
title: WebSockets support in ASP.NET Core | Microsoft Docs
author: tdykstra
description: What is WebSockets support in ASP.NET Core and how to use it.
keywords: ASP.NET Core, WebSockets
ms.author: tdykstra
manager: wpickett
ms.date: 03/25/2017
ms.topic: article
ms.assetid: 0e0fedcd-a7b4-4479-8ae0-36eab0229d7e
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/websockets
---

# H1: Introduction to WebSockets in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra) and [Andrew Stanton-Nurse](https://github.com/anurse)

This article explains how to get started with WebSockets in ASP.NET Core. [WebSocket](https://en.wikipedia.org/wiki/WebSocket) is a protocol that enables two-way persistent communication channels over TCP connections. It is used for applications such as chat, stock tickers, games, anywhere you want real-time functionality in a web application.

## Prerequisites

* ASP.NET Core 1.1 (does not run on 1.0)
* Any OS that ASP.NET Core runs on:
  
  * Windows 7 / Windows Server 2008 and later
  * Linux
  * macOS

  Exception: if your app runs on Windows with Kestrel and IIS, or with WebListener, the OS must be Windows 8 / Windows Server 2012 or later

 * For supported browsers, see http://caniuse.com/#feat=websockets.

## When to use it

Use WebSockets when you need to work directly with a socket connection. A typical reason is a need for best possible performance for real-time games.

[ASP.NET SignalR](https://docs.microsoft.com/aspnet/signalr/overview/getting-started/introduction-to-signalr) provides a richer application model for real-time functionality, but SignalR does not run on ASP.NET Core. A Core version of SignalR is under development; to follow its progress, see the [GitHub repository for SignalR Core](https://github.com/aspnet/SignalR).

If you don't want to wait for SignalR Core, you can use WebSockets directly now. But for many applications you might have to develop features that SignalR provides, such as these:

* Support for a broader range of browser versions by using automatic fallback to alternative transport methods.
* Automatic reconnection when a connection drops.
* Support for clients calling methods on the server or vice versa.
* Support for scaling to multiple servers.

## How to use it

### Install the package

Install [Microsoft.AspNetCore.WebSockets](https://www.nuget.org/packages/Microsoft.AspNetCore.WebSockets/).

### Configure the middleware

Add `app.UseWebSockets` in the `Configure` method of the `Startup` class.

[!code-csharp[](websockets/sample/Startup.cs?name=UseWebSockets)]

You can specify the following options:

* `KeepAliveInterval` - How frequently to send "ping" frames to the client, to ensure proxies keep the connection open.
* `ReceiveBufferSize` - The size of the buffer used to receive data. Only a very advanced user would need to change this, for performance tuning based on the size of their data.

[!code-csharp[](websockets/sample/Startup.cs?name=UseWebSocketsOptions)]

### Accept a WebSocket request

* Somewhere later in the request life cycle (in the `Configure` method or an MVC action, for example) check if it's a WebSocket request and accept the WebSocket request.

This example is from later in the `Configure` method.

[!code-csharp[](websockets/sample/Startup.cs?name=AcceptWebSocket&highlight=7)]

This code only accepts a WebSocket request if the request URL is `/ws`, but that restriction is not necessary.

### Send and receive messages

The `AcceptWebSocket` method upgrades the TCP connection to a WebSocket connection and gives you a [WebSocket](https://docs.microsoft.com/dotnet/core/api/system.net.websockets.websocket) object. Use the WebSocket object to send and Receive messages.

The preceding code passes the WebSocket to an Echo method; here's the Echo method. The code receives a message and immediately sends back the same message. It stays in a loop doing that until the client closes the connection. 

[!code-csharp[](websockets/sample/Startup.cs?name=Echo)]

When you accept the WebSocket before beginning this loop, the middleware pipeline ends.  Upon closing the the socket, the pipeline unwinds. That is, the request stops moving forward in the pipeline when you accept a WebSocket, just as it would when you hit an MVC action, for example.  But when you finish this loop and close the socket, the request proceeds back up the pipeline.

### Send and receive messages on the client




## Additional Information

- [ASP.NET Core 1.1.0 Release Notes](https://github.com/aspnet/Home/releases/tag/1.1.0)
