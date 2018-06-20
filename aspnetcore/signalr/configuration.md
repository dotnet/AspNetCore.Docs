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

JSON serialization can be configured on the server using the [`AddJsonProtocol`](/dotnet/api/microsoft.extensions.dependencyinjection.jsonprotocoldependencyinjectionextensions.addjsonprotocol) extension method, which can be added after `AddSignalR` in your `ConfigureServices` method. The `AddJsonProtocol` method takes a delegate that receives an `options` object. The [`PayloadSerializerSettings`](/dotnet/api/microsoft.aspnetcore.signalr.jsonhubprotocoloptions.payloadserializersettings) property on that object is a JSON.NET `JsonSerializerSettings` object that can be used to configure serialization of arguments and return values. See the [JSON.NET Documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm) for more details.

As an example, you can configure the serializer to use "PascalCase" property names instead of the default "camelCase" names using the following code:

[!code-csharp[Startup config](configuration/sample/config-startup.cs?range=1-5)]

In the .NET client, the same `AddJsonHubProtocol` extension method exists on [HubConnectionBuilder](/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnectionbuilder). The `Microsoft.Extensions.DependencyInjection` namespace must be imported to resolve the extension method:

[!code-csharp[HubConnectionBuilder](configuration/sample/addhubjsonprotocol.cs)]

> [!NOTE]
> It's not possible to configure JSON serialization in the JavaScript client at this time.

### MessagePack Serialization Options

MessagePack serialization can be configured by providing a delegate to the [AddMessagePackProtocol](/dotnet/api/microsoft.extensions.dependencyinjection.msgpackprotocoldependencyinjectionextensions.addmessagepackprotocol) call. See [MessagePack in SignalR](xref:signalr/messagepackhubprotocol) for more details.

> [!NOTE]
> It's not possible to configure MessagePack serialization in the JavaScript client at this time.

## Configure server options

The following table describes options for configuring SignalR hubs:

| Option | Description |
| ------ | ----------- |
| `HandshakeTimeout` | If the client doesn't send an initial handshake message within this time interval, the connection will be closed. |
| `KeepAliveInterval` | If the server hasn't sent a message within this interval, a ping message is sent automatically to keep the connection open. |
| `SupportedProtocols` | Protocols supported by this hub. By default, all protocols registered on the server are allowed, but protocols can be removed from this list to disable specific protocols for individual hubs. |
| `EnableDetailedErrors` | If `true`, detailed exception messages will be returned to clients when an exception is thrown in a Hub method. The default is `false`, as these exception messages can contain sensitive information. |

Options can be configured for all hubs by providing an options delegate to the `AddSignalR` call in `ConfigureServices`.

[!code-csharp[Startup](configuration/sample/config-startup.cs?range=7-14)]

Options for a single hub override the global options provided in `AddSignalR`, and can be configured using [`AddHubOptions<T>`](/dotnet/api/microsoft.extensions.dependencyinjection.huboptionsdependencyinjectionextensions.addhuboptions):

[!code-csharp[HubOptions](configuration/sample/config-startup.cs?range=16-19)]

Use `HttpConnectionDispatcherOptions` to configure advanced settings related to transports and memory buffer management. These options are configured by passing a delegate to [`MapHub<T>`](/dotnet/api/microsoft.aspnetcore.signalr.hubroutebuilder.maphub).

| Option | Description |
| ------ | ----------- |
| `ApplicationMaxBufferSize`  | The maximum number of bytes received from the client that the server will buffer. Increasing this value allows the server to receive larger messages, but can negatively impact memory consumption. The default value is 32KB. |
| `AuthorizationData` | A list of [`IAuthorizeData`](/dotnet/api/microsoft.aspnetcore.authorization.iauthorizedata) objects used to determine if a client is authorized to connect to the hub. By default, this is populated with values from the `Authorize` attributes applied to the Hub class. |
| `TransportMaxBufferSize`  | The maximum number of bytes sent by the application that the server will buffer. Increasing this value allows the server to send larger messages, but can negatively impact memory consumption. The default value is 32KB. |
| `Transports`  | A bitmask of [`HttpTransportType`](LINK TBD, API DOCS BEING UPDATED) values that can restrict the transports a client can use to connect. By default, all transports are enabled. |
| `LongPolling`  | Additional options specific to the Long Polling transport |
| `WebSockets`  | Additional options specific to the WebSockets transport |

The Long Polling transport has additional options that can be configured using the `LongPolling` property:

| Option | Description |
| ------ | ----------- |
| `PollTimeout` | The maximum amount of time the server will wait for a message to send to the client before terminating a single poll request. Decreasing this value will cause the client to issue new poll requests more frequently. The default value is 90 seconds. |


The WebSocket transport has additional options that can be configured using the `WebSockets` property:

| Option | Description |
| ------ | ----------- |
| `CloseTimeout`  | After the server closes, if the client fails to close within this time interval, the connection will be terminated. |
| `SubProtocolSelector` | A delegate that can be used to set the `Sec-WebSocket-Protocol` header to a custom value. The delegate receives the values requested by the client as input and is expected to return the desired value. |

## Configure client options

Client options can be configured on the `HubConnectionBuilder` type (available in both .NET and JavaScript clients), as well as on the `HubConnection` itself.

### Configure logging

Logging is configured in the .NET Client using the `ConfigureLogging` method. Logging providers and filters can be registered in the same way as they are on the server. See the [Logging in ASP.NET Core](xref:fundamentals/logging/index#how-to-add-providers) documentation for more information.

> [!NOTE]
> In order to register Logging providers, you must install the necessary packages. See the [Built-in logging providers](xref:fundamentals/logging/index#built-in-logging-providers) section of the docs for a full list.

For example, to configure the console logger (after installing the `Microsoft.Extensions.Logging.Console` NuGet package):

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/myhub")
    .ConfigureLogging(logging => {
        logging.SetMinimumLevel(LogLevel.Information);
        logging.AddConsole();
    })
    .Build();
```

In the JavaScript client, a similar `configureLogging` method exists. Provide a `LogLevel` value indicating the minimum level of log messages to produce. Logs will be written to the browser console window.

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/myhub")
    .configureLogging(signalR.LogLevel.Information)
```

> [!NOTE]
> To disable logging entirely, specify `signalR.LogLevel.None` in the `configureLogging` method

Log levels available to the JavaScript client are listed below. Setting the log level to one of these values will enable logging of messages at **or above** that level.

| Level | Description |
| ----- | ----------- |
| `None` | No messages will be logged |
| `Critical` | Messages that indicate a failure in the entire application |
| `Error` | Messages that indicate a failure in the current operation |
| `Warning` | Messages that indicate a non-fatal problem |
| `Information` | Informational messages |
| `Debug` | Diagnostic messages useful for debugging |
| `Trace` | Very detailed diagnostic messages designed for diagnosing specific issues |

### Configure allowed transports

The transports used by SignalR can be configured in the `WithUrl` call (`withUrl` in JavaScript). A bitwise-OR of the values of `HttpTransportType` can be used to restrict the client to only use the specified transports. By default, all transports are enabled.

For example, to disable the Server-Sent Events transport, but allow WebSockets and Long Polling connections:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/myhub", HttpTransportType.WebSockets | HttpTransportType.LongPolling)
    .Build();
```

In the JavaScript client, transports are configured by setting the `transport` field on the options object provided to `withUrl`:

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/myhub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
    .build();
```

### Configure bearer authentication

To provide authentication data along with SignalR requests, use the `AccessTokenProvider` option (`accessTokenFactory` in JavaScript) to specify a function that will return the desired access token. In the .NET Client, this access token is passed in as an HTTP "Bearer Authentication" token (Using the `Authorization` header with a type of `Bearer`). In the JavaScript client, the access token is used as a Bearer token, **except** in a few cases where browser APIs restrict the ability to apply headers (specifically, in Server-Sent Events and WebSockets requests). In these cases, the access token is provided as a query string value `access_token`.


In the .NET client, the `AccessTokenProvider` option can be specified using the options delegate in `WithUrl`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/myhub", options => {
        options.AccessTokenProvider = async () => {
            // Get and return the access token.
        }
    })
    .Build();
```

In the JavaScript client, the acess token is configured by setting the `accessTokenFactory` field on the options object in `withUrl`:

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/myhub", {
        accessTokenFactory: () => {
            // Get and return the access token.
            // This function can return a JavaScript Promise if asynchronous
            // logic is required to retrieve the access token.
        }
    })
    .build();
```

### Configure timeout and keep-alive options

Additional options for configuring timeout and keep-alive behavior are available on the `HubConnection` object itself:

| .NET Option | JavaScript Option | Description |
| ----------- | ----------------- | ----------- |
| `ServerTimeout` | `serverTimeoutInMilliseconds` | Timeout for server activity. If the server has not sent any message in this interval, the client will consider the server disconnected and trigger the `Closed` event (`onclose` in JavaScript). |
| `HandshakeTimeout` | Not Configurable | Timeout for initial server handshake. If the server does not send a handshake response in this interval, the client will cancel the handshake and trigger the `Closed` event (`onclose` in JavaScript). |

In the .NET Client, timeout values are specified as `TimeSpan` values. In the JavaScript client, timeout values are specified as numbers which represent a time value in milliseconds.

### Configure additional options

Additional options can be configured in the `WithUrl` (`withUrl` in JavaScript) method on `HubConnectionBuilder`:


| .NET Option | JavaScript Option | Description |
| ----------- | ----------------- | ----------- |
| `AccessTokenProvider` | `accessTokenFactory` | A function that returns a string that will be provided as a Bearer authentication token in HTTP requests. |
| `SkipNegotiation` | `skipNegotaiation` | Set this to `true` to skip the negotiation step. **Only supported when the WebSockets transport is the only enabled transport**. This setting cannot be enabled when using the Azure SignalR Service. |
| `Headers` | Not Configurable * | A dictionary of additional HTTP headers to send with every HTTP request. |
| `Cookies` | Not Configurable * | A collection of HTTP cookies to send with every HTTP request. |
| `Credentials` | Not Configurable * | Credentials to send with every HTTP request. |
| `Proxy` | Not Configurable * | An HTTP proxy to use when sending HTTP requests. |
| `WebSocketConfiguration` | Not Configurable * | A delegate that can be used to configure additional WebSocket options. Receives an instance of [ClientWebSocketOptions](/dotnet/api/system.net.websockets.clientwebsocketoptions?view=netstandard-2.0) that can be used to configure the options. |

Options marked with an asterisk (*) are not configurable in the JavaScript client due to limitations in Browser APIs.

In the .NET Client, these options can be modified by the options delegate provided to `WithUrl`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/myhub", options => {
        options.Headers["Foo"] = "Bar";
        options.Cookies.Add(new Cookie(/* ... */);
        options.ClientCertificates.Add(/* ... */);
    })
    .Build();
```

In the JavaScript Client, these options can be provided in a JavaScript object provided to `withUrl`:

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/myhub", {
        skipNegotiation: true
    });
    .build();
```

## Additional Resources

* [Get started with SignalR for ASP.NET Core](xref:tutorials/signalr)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [MessagePack Hub Protocol](xref:signalr/messagepackhubprotocol)
* [Supported platforms](xref:signalr/supported-platforms)