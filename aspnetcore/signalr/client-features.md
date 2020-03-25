---
title: SignalR client features
author: bradygaster
description: Learn which features are supported by the various ASP.NET Core SignalR clients.
ms.author: bradyg
ms.custom: mvc
ms.date: 11/12/2019
no-loc: [SignalR]
uid: signalr/client-features
---
# ASP.NET Core SignalR client features

## Feature distribution

The table below shows the features and support for the clients that offer real-time support. For each feature, the *minimum* version supporting this feature is listed. If no version is listed, the feature isn't supported.

| Feature | .NET | JavaScript | Java |
| ---- | :-: | :-: | :-: |
| Azure SignalR Service Support |1.0.0|1.0.0|1.0.0|
| [Server-to-client Streaming](xref:signalr/streaming)          |1.0.0|1.0.0|1.0.0|
| [Client-to-server Streaming](xref:signalr/streaming)          |3.0.0|3.0.0|3.0.0|
| Automatic Reconnection ([.NET](/aspnet/core/signalr/dotnet-client?view=aspnetcore-3.0&tabs=visual-studio#handle-lost-connection), [JavaScript](/aspnet/core/signalr/javascript-client?view=aspnetcore-3.0#reconnect-clients))          |3.0.0|3.0.0|❌|
| WebSockets Transport |1.0.0|1.0.0|1.0.0|
| Server-Sent Events Transport |1.0.0|1.0.0|❌|
| Long Polling Transport |1.0.0|1.0.0|3.0.0|
| JSON Hub Protocol |1.0.0|1.0.0|1.0.0|
| MessagePack Hub Protocol |1.0.0|1.0.0|❌|

Support for automatic reconnect in the Java client is tracked in [our issue tracker](https://github.com/dotnet/AspNetCore/issues/8711).

## Additional resources

* [Get started with SignalR for ASP.NET Core](xref:tutorials/signalr)
* [Supported platforms](xref:signalr/supported-platforms)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
