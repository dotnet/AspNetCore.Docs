---
title: ASP.NET Core SignalR clients
author: bradygaster
description: Learn which features are supported by the various ASP.NET Core SignalR clients.
ms.author: bradyg
ms.custom: mvc
ms.date: 11/12/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/client-features
---
# ASP.NET Core SignalR clients

## Versioning, support, and compatibility

The SignalR clients ship alongside the server components and are versioned to match. Any supported client can safely connect to any supported server, and any compatibility issues would be considered bugs to be fixed. SignalR clients are supported in the same support lifecycle as the rest of .NET Core. See [the .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) for details.

Many features require a compatible client **and** server. See below for a table showing the minimum versions for various features.

The 1.x versions of SignalR map to the 2.1 and 2.2 .NET Core releases and have the same lifetime. For version 3.x and above, the SignalR version exactly matches the rest of .NET and has the same support lifecycle.

| SignalR version | .NET Core version | Support level | End of support |
| - | - | - | - |
| 1.0.x | 2.1.x | Long Term Support | August 21, 2021 |
| 1.1.x | 2.2.x | End Of Life | December 23, 2019 |
| 3.x or higher | *same as SignalR version* | See the [the .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) |

**NOTE:** In ASP.NET Core 3.0, the JavaScript client *moved* to the `@microsoft/signalr` npm package.

## Feature distribution

The table below shows the features and support for the clients that offer real-time support. For each feature, the *minimum* version supporting this feature is listed. If no version is listed, the feature isn't supported.

| Feature | Server | .NET client | JavaScript client | Java client |
| ---- | :-: | :-: | :-: | :-: |
| Azure SignalR Service Support |2.1.0|1.0.0|1.0.0|1.0.0|
| [Server-to-client Streaming](xref:signalr/streaming)          |2.1.0|1.0.0|1.0.0|1.0.0|
| [Client-to-server Streaming](xref:signalr/streaming)          |3.0.0|3.0.0|3.0.0|3.0.0|
| Automatic Reconnection ([.NET](./dotnet-client.md?tabs=visual-studio&view=aspnetcore-3.0#handle-lost-connection), [JavaScript](./javascript-client.md?view=aspnetcore-3.0#reconnect-clients))          |3.0.0|3.0.0|3.0.0|❌|
| WebSockets Transport |2.1.0|1.0.0|1.0.0|1.0.0|
| Server-Sent Events Transport |2.1.0|1.0.0|1.0.0|❌|
| Long Polling Transport |2.1.0|1.0.0|1.0.0|3.0.0|
| JSON Hub Protocol |2.1.0|1.0.0|1.0.0|1.0.0|
| MessagePack Hub Protocol |2.1.0|1.0.0|1.0.0|5.0.0|

Support for enabling additional client features is tracked in [our issue tracker](https://github.com/dotnet/AspNetCore/issues).

## Additional resources

* [Get started with SignalR for ASP.NET Core](xref:tutorials/signalr)
* [Supported platforms](xref:signalr/supported-platforms)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)