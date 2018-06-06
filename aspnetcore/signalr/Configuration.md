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

```csharp
using Microsoft.Extensions.DependencyInjection

var connection = new HubConnectionBuilder()
    .WithUrl("...")
    .AddJsonHubProtocol(options => {
        // options.PayloadSerializerSettings is a JSON.NET JsonSerializerSettings used to 
        // configure how the payload is serialized
        // Example: PascalCase JSON (we are camelCase by default)
        options.PayloadSerializerSettings.ContractResolver = new DefaultContractResolver();
    })
    .Build();
```

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

The `HubOptions` are configured in the `ConfigureServices` method of the `Startup` class, as shown in the following code sample:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSignalR(hubOptions =>
    {
        hubOptions.EnableDetailedErrors = true;
        hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
    })
}
```

### [HubOptions<T>](https://github.com/aspnet/SignalR/blob/dev/src/Microsoft.AspNetCore.SignalR.Core/HubOptions.cs)

```csharp
  services.AddSignalR().AddHubOptions<ChatHub>(options =>
  {
      options.EnableDetailedErrors = true;
  }
```

### HttpConnectionDispatcherOptions

The following table describes the `HttpConnectionDispatcherOptions` options:

| Option | Description |
| ------ | ----------- |
| `ApplicationMaxBufferSize`  | The maximum number of bytes the connection (transport) can buffer when invoking methods from the client, before blocking and waiting for the application to consume enough bytes to allow writing again.  |
| `AuthorizationData` | A pre-populated list of `IAuthorizeData` gathered from the `Authorize` attributes used on the `Hub<T>`. |
| `LongPolling`  | Gets the LongPolling options object that has a settable `PollTimeout` property. Setting the `PollTimeOut` sets the wait time before ending a poll request. |
| `TransportMaxBufferSize`  | The maximum number of bytes the application. For example, `Clients.All.SendAsync` can buffer when writing to a single connection before blocking and waiting for the connection to consume enough bytes to allow writing again. |
| `Transports`  | A bitmask that sets a transport. The available `options.Transports` options are as follows: `HttpTransportType.WebSockets`, `HttpTransportType.LongPolling`, and `HttpTransportType.ServerSentEvents`
    WebSockets - Gets the WebSockets options object.  |
| `WebSockets`  |  Gets the WebSockets options object.  |
| `CloseTimeout`  | TimeSpan to set how long to wait for a clean WebSocket close when connection is being terminated  |
| `SubProtocolSelector` | A delegate the hub calls and passes a list of `Sec-WebSocket-Protocol` values from the request header. A delegate returns the chosen `Sec-WebSocket-Protocol`. |

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("/url", HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents)
    .Build();
```

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("/url", options => {
        options.AccessTokenProvider = async () => {
            // Get access token and return it.
        };
    });
    .Build();
```

## Additional Resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)