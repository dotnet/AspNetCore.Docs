---
title: ASP.NET Core SignalR configuration
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

# ASP.NET Core SignalR configuration

## JSON/MessagePack serialization options

ASP.NET Core SignalR supports two protocols for encoding messages, [JSON](https://www.json.org/) and [MessagePack](https://msgpack.org/index.html). Each protocol has serialization configuration options.

JSON serialization can be configured on the server using the `AddJsonProtocol` extension method. The `AddJsonProtocol` method takes a delegate that receives an `options` object. The `PayloadSerializerSettings` property on that object is a JSON.NET `JsonSerializerSettings` object that can be used to configure serialization of arguments and return values. See the [JSON.NET Documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm) for more details.

As an example, you can configure the serializer to use PascalCase names instead of the default camelCase names using the following code:

[!code-csharp[Startup config](configuration/sample/config-startup.cs?range=1-5)]

In the .NET client, the same `AddJsonHubProtocol` extension method exists on [HubConnectionBuilder](/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnectionbuilder). The `Microsoft.Extensions.DependencyInjection` namespace must be imported to resolve the extension method:

[!code-csharp[HubConnectionBuilder](configuration/sample/addhubjsonprotocol.cs)]

### MessagePack Serialization Options

MessagePack serialization can be configured by providing a delegate to the [AddMessagePackProtocol](/dotnet/api/microsoft.extensions.dependencyinjection.msgpackprotocoldependencyinjectionextensions.addmessagepackprotocol) call. See [MessagePack in SignalR](xref:signalr/messagepack) for more details.

> [!NOTE]
> It's not possible to configure JSON or MessagePack serialization in the JavaScript client at this time.

### Configure [HubOptions](/dotnet/api/microsoft.aspnetcore.signalr.huboptions) for SignalR

The following table describes the `HubOptions` options for configuring a hub:

| Option | Description |
| ------ | ----------- |
| `HandshakeTimeout` | If the client doesn't send an initial handshake message within this time interval, the connection will be closed. |
| `KeepAliveInterval` | If the server hasn't sent a message within this interval, a ping message is sent automatically to keep the connection open. |
| `SupportedProtocols` | Protocols supported by this hub. By default, all protocols registered on the server are allowed, but protocols can be removed from this list to disable specific protocols for individual hubs. |
| `EnableDetailedErrors` | If true, sends detailed error messages to the client when exceptions occur. The detailed error messages may contain sensitive data, and are `false` by default. |

Options can be configured for all hubs by providing an options delegate to the `AddSignalR` call in `ConfigureServices`.

[!code-csharp[Startup](configuration/sample/config-startup.cs?range=7-14)]

Options for a single hub override the global options provided in `AddSignalR`, and can be configured using `AddHubOptions<T>`:

[!code-csharp[HubOptions](configuration/sample/config-startup.cs?range=16-19)]

### HttpConnectionDispatcherOptions - Options related to the transport layer.

Options related to the transport layer. Use these to restrict the transports that can be used by SignalR clients, as well as to configure advanced settings related to memory buffer management. The transport options are configured by passing a delegate to `MapHub<T>`.

| Option | Description |
| ------ | ----------- |
| `ApplicationMaxBufferSize`  | The maximum number of bytes the connection (transport) can buffer. It buffers when invoking methods from the client, before blocking and waiting for the application to allow writing again. |
| `AuthorizationData` | A pre-populated list of `IAuthorizeData` gathered from the `Authorize` attributes used on the `Hub<T>`. |
| `LongPolling`  | Gets the LongPolling options object that has a settable `PollTimeout` property. Setting the `PollTimeOut` sets the wait time before ending a poll request. |
| `TransportMaxBufferSize`  | The maximum number of bytes the application. For example, `Clients.All.SendAsync` can buffer when writing to a single connection before blocking and waiting for the connection to consume enough bytes to allow writing again. |
| `Transports`  | A bitmask that sets a transport. The available `options.Transports` options are as follows: `HttpTransportType.WebSockets`, `HttpTransportType.LongPolling`, and `HttpTransportType.ServerSentEvents` |
| `WebSockets`*  |  Gets the WebSockets options object.  |
| `CloseTimeout`*  | TimeSpan to set how long to wait for a clean WebSocket close when connection is being terminated.  |
| `SubProtocolSelector`* | A delegate the hub calls and passes a list of `Sec-WebSocket-Protocol` values from the request header. A delegate returns the chosen `Sec-WebSocket-Protocol`. |
| `AccessTokenProvider`* | A delegate that is called to get an access token. The token is applied as an HTTP Bearer Authentication header. |

 Items in the table marked with an asterisk (*) are specific to WebSockets.

### HubConnectionBuilder

The [HubConnectionBuilder](/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnectionbuilder) API is available for both C# and TypeScript clients.

| Option | Description |
| ------ | ----------- |
| Headers | HTTP headers to be applied to all HTTP requests. |
| Cookies | Cookies to be sent with each HTTP request. |
| ClientCertificates | TLS client certificates to send when connecting over HTTPS (not supported in Xamarin). |

The following code samples demonstrate the C# setting connection options with `HubConnectionBuilder`:

[!code-csharp[HubConnectionBuilder](configuration/sample/hubconnectionbuilder.cs?)]

The following code samples demonstrate setting connection options with the `HubConnectionBuilder` in JavaScript:

[!code-javascript[HubConnectionBuilder in JavaScript](configuration/sample/hubconnectionbuilder.js?range=1-16)]

> [!NOTE]
> Headers, cookies and client certificates cannot be configured in the JavaScript client due to limitations on browser APIs.

The following table and code sample demonstrate the available `HttpConnectionOptions`.

| Option | Description |
| ------ | ----------- |
| `httpClient` | Class that handles all the GET, POST, and DELETE requests sent by the client. Can override with custom settings. |
| `transport` | Specific transport the client should use, or an `ITransport` implementation for a custom transport. |
| `accessTokenFactory` | Called for each HTTP request to set the authorization header or for WebSockets to set the `access_token` query string value. |
| `logMessageContent` | Log the message content when sending and receiving. Disabled by default. |
| `skipNegotiation` | Only use this when `HttpTransportType.WebSockets` is specified. It skips the negotiation step when it isn't necessary. |

[!code-javascript[HttpConnectionOptions in JavaScript](configuration/sample/hubconnectionbuilder.js?range=19-21)]

> [!NOTE]
> All `HttpConnectionOptions` are optional.

Once you have a [HubConnection](dotnet/api/microsoft.aspnetcore.signalr.client.hubconnection) there are two settings you can change:

| Option | Description |
| ------ | ----------- |
| `serverTimeoutInMilliseconds` | Closes the connection if time since last message received is greater than this value. |
| `keepAliveIntervalInMilliseconds` | SignalR 1.1: The interval at which the client sends pings to the server to keep the server from closing the connection. |

[!code-javascript[JS settings](configuration/sample/hubconnectionbuilder.js?range=24-25)]

## Additional Resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)