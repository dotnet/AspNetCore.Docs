---
title: Differences between SignalR and ASP.NET Core SignalR
author: tdykstra
description: Differences between SignalR and ASP.NET Core SignalR 
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.date: 06/30/2018
uid: signalr/version-differences
---

# Differences between SignalR and ASP.NET Core SignalR

ASP.NET Core SignalR is not compatible with clients or servers for ASP.NET SignalR. This article details the features which have been removed or changed in the ASP.NET Core SignalR.

## Feature differences

### Automatic reconnects

Automatic reconnects are no longer supported. Previously, SignalR tried to reconnect to the server if the connection was dropped. Now, if the client is disconnected the user must explicitly start a new connection if they want to reconnect.

### Protocol support

ASP.NET Core SignalR supports JSON, as well as a new binary protocol based on [MessagePack](xref:signalr/messagepackhubprotocol). Additionally, custom protocols can be created.

## Differences on the server

The SignalR server-side libraries are included in the `Microsoft.AspNetCore.App` package that is part of the **ASP.NET Core Web Application** template for both Razor and MVC projects.

SignalR is an ASP.NET Core middleware, so it must be configured by calling `AddSignalR` in `Startup.ConfigureServices`.

```csharp
services.AddSignalR();
```

To configure routing, map routes to hubs inside the `UseSignalR` method call in the `Startup.Configure` method.

```csharp
app.UseSignalR(routes =>
{
    routes.MapHub<ChatHub>("/hub");
});
```

### Sticky sessions now required

Because of how scale-out worked in the previous versions of SignalR, clients could reconnect and send messages to any server in the farm. Due to changes to the scale-out model, as well as not supporting reconnects, this is no longer supported. Now, once the client connects to the server it needs to interact with the same server for the duration of the connection.

### Single hub per connection

In ASP.NET Core SignalR, the connection model has been simplified. Connections are made directly to a single hub, rather than a single connection being used to share access to multiple hubs.

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

### Hub proxies

Hub proxies are no longer automatically generated. Instead, the method name is passed into the `invoke` API as a string.

### .NET and other clients

The `Microsoft.AspNetCore.SignalR.Client` NuGet package contains the .NET client libraries for ASP.NET Core SignalR.

Use the `HubConnectionBuilder` to create and build an instance of a connection to a hub.

```csharp
connection = new HubConnectionBuilder()
    .WithUrl("url")
    .Build();
```

## Additional resources

* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)
