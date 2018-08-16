---
title: ASP.NET Core SignalR configuration
author: tdykstra
description: Learn how to configure ASP.NET Core SignalR apps.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/31/2018
uid: signalr/configuration
---
# ASP.NET Core SignalR configuration

## JSON/MessagePack serialization options

ASP.NET Core SignalR supports two protocols for encoding messages: [JSON](https://www.json.org/) and [MessagePack](https://msgpack.org/index.html). Each protocol has serialization configuration options.

JSON serialization can be configured on the server using the [AddJsonProtocol](/dotnet/api/microsoft.extensions.dependencyinjection.jsonprotocoldependencyinjectionextensions.addjsonprotocol) extension method, which can be added after [AddSignalR](/dotnet/api/microsoft.extensions.dependencyinjection.signalrdependencyinjectionextensions.addsignalr) in your `Startup.ConfigureServices` method. The `AddJsonProtocol` method takes a delegate that receives an `options` object. The [PayloadSerializerSettings](/dotnet/api/microsoft.aspnetcore.signalr.jsonhubprotocoloptions.payloadserializersettings) property on that object is a JSON.NET `JsonSerializerSettings` object that can be used to configure serialization of arguments and return values. See the [JSON.NET Documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm) for more details.

As an example, to configure the serializer to use "PascalCase" property names, instead of the default "camelCase" names, use the following code:

```csharp
services.AddSignalR()
    .AddJsonHubProtocol(options => {
        options.PayloadSerializerSettings.ContractResolver = 
        new DefaultContractResolver();
    });
```

In the .NET client, the same `AddJsonHubProtocol` extension method exists on [HubConnectionBuilder](/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnectionbuilder). The `Microsoft.Extensions.DependencyInjection` namespace must be imported to resolve the extension method:

```csharp
// At the top of the file:
using Microsoft.Extensions.DependencyInjection;

// When constructing your connection:
var connection = new HubConnectionBuilder()
.AddJsonHubProtocol(options => {
    options.PayloadSerializerSettings.ContractResolver = 
        new DefaultContractResolver();
});
```

> [!NOTE]
> It's not possible to configure JSON serialization in the JavaScript client at this time.

### MessagePack serialization options

MessagePack serialization can be configured by providing a delegate to the [AddMessagePackProtocol](/dotnet/api/microsoft.extensions.dependencyinjection.msgpackprotocoldependencyinjectionextensions.addmessagepackprotocol) call. See [MessagePack in SignalR](xref:signalr/messagepackhubprotocol) for more details.

> [!NOTE]
> It's not possible to configure MessagePack serialization in the JavaScript client at this time.

## Configure server options

The following table describes options for configuring SignalR hubs:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `HandshakeTimeout` | 15 seconds | If the client doesn't send an initial handshake message within this time interval, the connection is closed. This is an advanced setting that should only be modified if handshake timeout errors are occurring due to severe network latency. For more detail on the handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |
| `KeepAliveInterval` | 15 seconds | If the server hasn't sent a message within this interval, a ping message is sent automatically to keep the connection open. |
| `SupportedProtocols` | All installed protocols | Protocols supported by this hub. By default, all protocols registered on the server are allowed, but protocols can be removed from this list to disable specific protocols for individual hubs. |
| `EnableDetailedErrors` | `false` | If `true`, detailed exception messages are returned to clients when an exception is thrown in a Hub method. The default is `false`, as these exception messages can contain sensitive information. |

Options can be configured for all hubs by providing an options delegate to the `AddSignalR` call in `Startup.ConfigureServices`.

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

Options for a single hub override the global options provided in `AddSignalR` and can be configured using [AddHubOptions\<T>](/dotnet/api/microsoft.extensions.dependencyinjection.huboptionsdependencyinjectionextensions.addhuboptions):

```csharp
services.AddSignalR().AddHubOptions<MyHub>(options =>
{
    options.EnableDetailedErrors = true;
}
```

Use `HttpConnectionDispatcherOptions` to configure advanced settings related to transports and memory buffer management. These options are configured by passing a delegate to [MapHub\<T>](/dotnet/api/microsoft.aspnetcore.signalr.hubroutebuilder.maphub).

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `ApplicationMaxBufferSize` | 32 KB | The maximum number of bytes received from the client that the server buffers. Increasing this value allows the server to receive larger messages, but can negatively impact memory consumption. |
| `AuthorizationData` | Data automatically gathered from the `Authorize` attributes applied to the Hub class. | A list of [IAuthorizeData](/dotnet/api/microsoft.aspnetcore.authorization.iauthorizedata) objects used to determine if a client is authorized to connect to the hub. |
| `TransportMaxBufferSize` | 32 KB | The maximum number of bytes sent by the app that the server buffers. Increasing this value allows the server to send larger messages, but can negatively impact memory consumption. |
| `Transports` | All Transports are enabled. | A bitmask of `HttpTransportType` values that can restrict the transports a client can use to connect. |
| `LongPolling` | See below. | Additional options specific to the Long Polling transport. |
| `WebSockets` | See below. | Additional options specific to the WebSockets transport. |

The Long Polling transport has additional options that can be configured using the `LongPolling` property:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `PollTimeout` | 90 seconds | The maximum amount of time the server waits for a message to send to the client before terminating a single poll request. Decreasing this value causes the client to issue new poll requests more frequently. |

The WebSocket transport has additional options that can be configured using the `WebSockets` property:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `CloseTimeout` | 5 seconds | After the server closes, if the client fails to close within this time interval, the connection is terminated. |
| `SubProtocolSelector` | `null` | A delegate that can be used to set the `Sec-WebSocket-Protocol` header to a custom value. The delegate receives the values requested by the client as input and is expected to return the desired value. |

## Configure client options

Client options can be configured on the `HubConnectionBuilder` type (available in both .NET and JavaScript clients), as well as on the `HubConnection` itself.

### Configure logging

Logging is configured in the .NET Client using the `ConfigureLogging` method. Logging providers and filters can be registered in the same way as they are on the server. See the [Logging in ASP.NET Core](xref:fundamentals/logging/index#how-to-add-providers) documentation for more information.

> [!NOTE]
> In order to register Logging providers, you must install the necessary packages. See the [Built-in logging providers](xref:fundamentals/logging/index#built-in-logging-providers) section of the docs for a full list.

For example, to enable Console logging, install the `Microsoft.Extensions.Logging.Console` NuGet package. Call the `AddConsole` extension method:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/myhub")
    .ConfigureLogging(logging => {
        logging.SetMinimumLevel(LogLevel.Information);
        logging.AddConsole();
    })
    .Build();
```

In the JavaScript client, a similar `configureLogging` method exists. Provide a `LogLevel` value indicating the minimum level of log messages to produce. Logs are written to the browser console window.

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/myhub")
    .configureLogging(signalR.LogLevel.Information)
    .build();
```

> [!NOTE]
> To disable logging entirely, specify `signalR.LogLevel.None` in the `configureLogging` method.

Log levels available to the JavaScript client are listed below. Setting the log level to one of these values enables logging of messages at **or above** that level.

| Level | Description |
| ----- | ----------- |
| `None` | No messages are logged. |
| `Critical` | Messages that indicate a failure in the entire app. |
| `Error` | Messages that indicate a failure in the current operation. |
| `Warning` | Messages that indicate a non-fatal problem. |
| `Information` | Informational messages. |
| `Debug` | Diagnostic messages useful for debugging. |
| `Trace` | Very detailed diagnostic messages designed for diagnosing specific issues. |

### Configure allowed transports

The transports used by SignalR can be configured in the `WithUrl` call (`withUrl` in JavaScript). A bitwise-OR of the values of `HttpTransportType` can be used to restrict the client to only use the specified transports. All transports are enabled by default.

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

To provide authentication data along with SignalR requests, use the `AccessTokenProvider` option (`accessTokenFactory` in JavaScript) to specify a function that returns the desired access token. In the .NET Client, this access token is passed in as an HTTP "Bearer Authentication" token (Using the `Authorization` header with a type of `Bearer`). In the JavaScript client, the access token is used as a Bearer token, **except** in a few cases where browser APIs restrict the ability to apply headers (specifically, in Server-Sent Events and WebSockets requests). In these cases, the access token is provided as a query string value `access_token`.

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

In the JavaScript client, the access token is configured by setting the `accessTokenFactory` field on the options object in `withUrl`:

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

| .NET Option | JavaScript Option | Default Value | Description |
| ----------- | ----------------- | ------------- | ----------- |
| `ServerTimeout` | `serverTimeoutInMilliseconds` | 30 seconds (30,000 milliseconds) | Timeout for server activity. If the server hasn't sent a message in this interval, the client considers the server disconnected and triggers the `Closed` event (`onclose` in JavaScript). |
| `HandshakeTimeout` | Not configurable | 15 seconds | Timeout for initial server handshake. If the server doesn't send a handshake response in this interval, the client cancels the handshake and triggers the `Closed` event (`onclose` in JavaScript). This is an advanced setting that should only be modified if handshake timeout errors are occurring due to severe network latency. For more detail on the Handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |

In the .NET Client, timeout values are specified as `TimeSpan` values. In the JavaScript client, timeout values are specified as a number indicating the duration in milliseconds.

### Configure additional options

Additional options can be configured in the `WithUrl` (`withUrl` in JavaScript) method on `HubConnectionBuilder`:

| .NET Option | JavaScript Option | Default Value | Description |
| ----------- | ----------------- | ------------- | ----------- |
| `AccessTokenProvider` | `accessTokenFactory` | `null` | A function returning a string that is provided as a Bearer authentication token in HTTP requests. |
| `SkipNegotiation` | `skipNegotiation` | `false` | Set this to `true` to skip the negotiation step. **Only supported when the WebSockets transport is the only enabled transport**. This setting can't be enabled when using the Azure SignalR Service. |
| `ClientCertificates` | Not configurable * | Empty | A collection of TLS certificates to send to authenticate requests. |
| `Cookies` | Not configurable * | Empty | A collection of HTTP cookies to send with every HTTP request. |
| `Credentials` | Not configurable * | Empty | Credentials to send with every HTTP request. |
| `CloseTimeout` | Not configurable * | 5 seconds | WebSockets only. The maximum amount of time the client waits after closing for the server to acknowledge the close request. If the server doesn't acknowledge the close within this time, the client disconnects. |
| `Headers` | Not configurable * | Empty | A dictionary of additional HTTP headers to send with every HTTP request. |
| `HttpMessageHandlerFactory` | Not configurable * | `null` | A delegate that can be used to configure or replace the `HttpMessageHandler` used to send HTTP requests. Not used for WebSocket connections. This delegate must return a non-null value, and it receives the default value as a parameter. Either modify settings on that default value and return it, or return a new `HttpMessageHandler` instance. **When replacing the handler make sure to copy the settings you want to keep from the provided handler, otherwise, the configured options (such as Cookies and Headers) won't apply to the new handler.** |
| `Proxy` | Not configurable * | `null` | An HTTP proxy to use when sending HTTP requests. |
| `UseDefaultCredentials` | Not configurable * | `false` | Set this boolean to send the default credentials for HTTP and WebSockets requests. This enables the use of Windows authentication. |
| `WebSocketConfiguration` | Not configurable * | `null` | A delegate that can be used to configure additional WebSocket options. Receives an instance of [ClientWebSocketOptions](/dotnet/api/system.net.websockets.clientwebsocketoptions) that can be used to configure the options. |

Options marked with an asterisk (*) aren't configurable in the JavaScript client, due to limitations in browser APIs.

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
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    });
    .build();
```

## Additional resources

* <xref:tutorials/signalr>
* <xref:signalr/hubs>
* <xref:signalr/javascript-client>
* <xref:signalr/dotnet-client>
* <xref:signalr/messagepackhubprotocol>
* <xref:signalr/supported-platforms>
