---
title: Overview of ASP.NET Core SignalR
ai-usage: ai-assisted
author: wadepickett
description: Explore ASP.NET Core SignalR, where you can add real-time capabilities to your apps with automatic connection management and scalable messaging solutions.
monikerRange: '>= aspnetcore-2.1'
ms.author: wpickett
ms.reviewer: wpickett
ms.date: 05/20/2026
uid: signalr/introduction

# customer intent: As an ASP.NET developer, I want to use SignalR with ASP.NET Core, so I can add real-time capabilities to my apps.
---
# Overview of ASP.NET Core SignalR

:::moniker range=">= aspnetcore-10.0"

ASP.NET Core SignalR is an open-source library that simplifies adding real-time web functionality to apps. Real-time web functionality enables server-side code to push content to clients instantly. There are many scenarios where an ASP.NET Core application can benefit from SignalR:

| Scenario | Examples |
|---|---|
| Applications that require high frequency updates from the server | Gaming, Social networks, Voting sites, Auctions, Maps, GPS |
| Dashboards and apps for monitoring | Company dashboards, Instant sales updates, Travel alerts |
| Apps that support collaboration | Whiteboard apps, Team meeting software |
| Apps that require notifications | Social networks, Email, Chat, Games, Travel alerts |

This article provides an introduction to working with SignalR in your ASP.NET Core apps.

## Features and source code

SignalR provides an API for creating server-to-client [remote procedure calls (RPC)](https://wikipedia.org/wiki/Remote_procedure_call). The RPCs invoke functions on clients from server-side .NET code. There are several [supported platforms](xref:signalr/supported-platforms), each with their respective client SDK. The programming language invoked by the RPC call varies based on the platform.

SignalR for ASP.NET Core provides developers with many features:

* Handle connection management automatically
* Send messages to all connected clients simultaneously (for example, a chat room)
* Send messages to specific clients or groups of clients
* Scale to handle increasing traffic with options like the [Azure SignalR Service](xref:signalr/scale) and [Redis backplane](xref:signalr/redis-backplane)
* Support trimming and native ahead-of-time (AOT) compilation for supported scenarios
* Support polymorphic type handling in hub methods
* Support distributed tracing with `ActivitySource` for SignalR hub server and .NET client
* Work with the [SignalR Hub Protocol](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/HubProtocol.md)

The source is hosted in the [ASP.NET Core SignalR repository on GitHub](https://github.com/dotnet/AspNetCore/tree/main/src/SignalR).

## Transports

SignalR supports the following techniques for handling real-time communication (in order of graceful fallback):

* [WebSockets](xref:fundamentals/websockets)
* Server-sent events
* Long polling

SignalR automatically chooses the best transport method within the capabilities of the server and client. WebSockets is the preferred transport because it generally provides the best performance.

## Hubs

SignalR uses *hubs* to communicate between clients and servers.

A hub is a high-level pipeline that a client and server use to call methods on each other. SignalR automatically handles the dispatching across machine boundaries, so clients can call methods on the server and vice versa. You can pass strongly typed parameters to methods and enable model binding.

SignalR supports two built-in hub protocols:

- A text protocol based on JSON (default)
- A binary protocol based on MessagePack. MessagePack generally creates smaller messages compared to JSON. For more information, see <xref:signalr/messagepackhubprotocol>.

Hubs call client-side code by sending messages that contain the name and parameters of the client-side method. The configured protocol deserializes objects sent as method parameters. The client tries to match the name to a method in the client-side code. When the client finds a match, it calls the method and passes the deserialized parameter data.

## Related content

* <xref:tutorials/signalr>
* <xref:signalr/supported-platforms>
* <xref:signalr/hubs>
* <xref:signalr/diagnostics>
* <xref:signalr/scale>
* <xref:signalr/javascript-client>
* <xref:blazor/fundamentals/signalr>

:::moniker-end

[!INCLUDE[](~/signalr/introduction/includes/introduction-9.md)]

[!INCLUDE[](~/signalr/introduction/includes/introduction-2-8.md)]
