---
title: ASP.NET Core SignalR Configuration
author: rachelappel
description: Configure ASP.NET Core SignalR Apps
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.date: 06/30/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: signalr/configuration
---

# ASP.NET Core SignalR Configuration

## [JSON]( https://github.com/aspnet/SignalR/blob/dev/src/Microsoft.AspNetCore.SignalR.Protocols.Json/JsonHubProtocolOptions.cs)/[MessagePack](https://github.com/aspnet/SignalR/blob/dev/src/Microsoft.AspNetCore.SignalR.Protocols.MessagePack/MessagePackHubProtocolOptions.cs) serialization options

MessagePack is a binary serialization format that provides serialization options for server and client.

### [HubConnection](https://github.com/aspnet/SignalR/blob/dev/src/Microsoft.AspNetCore.SignalR.Client.Core/HubConnection.cs#L66) options

The following table describes the `HubConnection` options for configuring the client:

| Option | Description |
| ------ | ----------- |
| `ServerTimeout` | If the server doesn't respond within this time interval, the connection closes |
| `HandshakeTimeout`  | If the server doesn't respond to the initial handshake message within this time interval, the connection closes |
| `PingInterval` (added in 2.2) | If the client hasn't sent a message within this interval, a ping message is sent automatically to keep the connection open |

### [HubOptions](https://github.com/aspnet/SignalR/blob/dev/src/Microsoft.AspNetCore.SignalR.Core/HubOptions.cs)

The following table describes the `HubOptions` options for configuring the hub:

| Option | Description |
| ------ | ----------- |
| `HandshakeTimeout` | If the client doesn't send an initial handshake message within this time interval, the connection will be closed |
| `KeepAliveInterval` | If the server hasn't sent a message within this interval, a ping message will is sent automatically to keep the connection open |
| `SupportedProtocols` | Protocols supported by this hub. For example, disabling JSON or MessagePack for certain hubs |
| `EnableDetailedErrors` | If true, sends detailed error messages to the client when exceptions occur. This may contain sensitive data and is `false` by default |

## Additional Resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)