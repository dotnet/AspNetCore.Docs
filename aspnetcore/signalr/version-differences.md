---
title: Differences between SignalR and SignalR Core
author: rachelappel
description: Differences between SignalR and SignalR Core
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.date: 06/30/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: signalr/version-differences
---

# Differences between SignalR and ASP.NET Core SignalR

ASP.NET Core SignalR is not compatible with clients or servers for ASP.NET SignalR. This article details the features which have been removed or changed in the ASP.NET Core SignalR.

## Feature differences

### Automatic reconnects

Automatic reconnects are no longer supported. Previously, SignalR tried to reconnect to the server if the connection was dropped. Now, if the client is disconnected the user must explicitly start a new connection if they want to reconnect.

### Protocol support

ASP.NET Core SignalR supports JSON, binary, text, and custom protocols. [MessagePack](xref:signalr/messagepackhubprotocol) is a binary serialization format that is fast and compact.

### Use SignalR with Websockets

SignalR now supports using [WebSockets](xref:fundamentals/websockets) to work directly with a socket connection.

## Differences on the server

The SignalR server-side libraries are included in the `Microsoft.AspNetCore.App` package that is part of the **ASP.NET Core Web Application** template for both Razor and MVC projects.

SignalR is an ASP.NET Core middleware, so it must be configured in the `Startup` class by calling `AddSignalR`.

```csharp
services.AddSignalR();
app.UseSignalR(routes =>
{
    routes.MapHub<ChatHub>("/hub");
});
```

Method calls are async by default.

### Sticky sessions now required

Because of how scale-out worked in the previous versions of SignalR, clients could reconnect and send messages to any server in the farm. Due to changes to the scale-out model, as well as not supporting reconnects, this is no longer supported. Now, once the client connects to the server it needs to interact with this server for the duration of the connection.

### Single hub per connection

The ability to connect to multiple hubs is no longer supported.

### Streaming

SignalR now supports [streaming data](xref:signalr/streaming) from the hub to the client.

### State

The ability to pass arbitrary state between clients and the hub (often called HubState) has been removed, as well as support for progress messages. There is no counterpart of hub proxies at the moment.

## Differences on the client

### TypeScript

The ASP.NET Core version of SignalR is written in [TypeScript](https://www.typescriptlang.org/). You can write in JavaScript or TypeScript when using the [JavaScript client](xref:signalr/javascript-client).

### The JavaScript client is hosted at [npm](https://www.npmjs.com/)

In previous versions, the JavaScript client was obtained through a NuGet package in Visual Studio. For the Core versions, the [@aspnet/signalr npm package](https://www.npmjs.com/package/@aspnet/signalr) contains the JavaScript libraries. This package isn't included in the **ASP.NET Core Web Application** template. Use npm to obtain and install the `@aspnet/signalr` npm package.

```console
npm init -y
npm install @aspnet/signalr
```

### jQuery

The dependency on jQuery has been removed, however projects can still use jQuery.

### JavaScript client method syntax

The JavaScript syntax has changed from the previous version of SignalR. Rather than using the `$connection` object, create a connection using the `HubConnectionBuilder` API.

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();
```

Use `connection.on` to specify client methods that the hub can call.

```javascript
connection.on("ReceiveMessage", (user, message) => {
    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    const encodedMsg = user + " says " + msg;
    log(encodedMsg);
});
```

After creating the client method, start the hub connection. Chain a `catch` method to log or handle errors.

```javascript
connection.start().catch(err => console.error(err.toString()));
```

### .NET and other clients

The `Microsoft.AspNetCore.SignalR.Client` NuGet package contains the .NET client libraries for ASP.NET Core SignalR.

Use the `HubConnectionBuilder` to create and build an instance of a connection to a hub.

```csharp
connection = new HubConnectionBuilder()
.WithUrl("url")
.Build();
```

## Additional Resources

* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)