---
title: ASP.NET Core SignalR configuration
author: wadepickett
description: Learn how to configure ASP.NET Core SignalR apps, including allowed transports, logging levels, timeout intervals, and serialization.
monikerRange: '>= aspnetcore-2.1'
ms.author: wpickett
ms.date: 05/20/2026
uid: signalr/configuration

# customer intent: As an ASP.NET developer, I want to configure ASP.NET Core SignalR, so I can specify my preferences for client and server options.
---

# ASP.NET Core SignalR configuration

This article describes how to configure client and server options for ASP.NET Core SignalR.

For Blazor SignalR guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/signalr>.

:::moniker range=">= aspnetcore-8.0"

## Configure serialization for encoding messages

ASP.NET Core SignalR supports two protocols for encoding messages: [JSON](https://www.json.org/json-en.html) and [MessagePack](https://msgpack.org/index.html). Each protocol has serialization configuration options.

### JSON serialization options

JSON serialization can be configured on the server by using the <xref:Microsoft.Extensions.DependencyInjection.JsonProtocolDependencyInjectionExtensions.AddJsonProtocol%2A> extension method. `AddJsonProtocol` can be added after the <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A> method in `Startup.ConfigureServices`. The `AddJsonProtocol` method takes a delegate that receives an `options` object. The <xref:Microsoft.AspNetCore.SignalR.JsonHubProtocolOptions.PayloadSerializerOptions%2A> property on that object is a `System.Text.Json` <xref:System.Text.Json.JsonSerializerOptions> object that can be used to configure serialization of arguments and return values. For more information, see the [System.Text.Json documentation](xref:System.Text.Json).

For example, to configure the serializer to not change the casing of property names, rather than the default [camel case](https://wikipedia.org/wiki/Camel_case) names, use the following code in the _Program.cs_ file:

```csharp
builder.Services.AddSignalR()
    .AddJsonProtocol(options => {
        options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    });
```

In the .NET client, the same `AddJsonProtocol` extension method exists on <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. The `Microsoft.Extensions.DependencyInjection` namespace must be imported to resolve the extension method:

```csharp
// At the top of the file:
using Microsoft.Extensions.DependencyInjection;

// When constructing your connection:
var connection = new HubConnectionBuilder()
    .AddJsonProtocol(options => {
        options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    })
    .Build();
```

> [!NOTE]
> It's not possible to configure JSON serialization in the JavaScript client at this time.

#### Switch to Newtonsoft.Json

If your app requires features in the [Newtonsoft.Json](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson) package that aren't supported in `System.Text.Json`, see [Switch to Newtonsoft.Json](xref:migration/22-to-30#switch-to-newtonsoftjson).

### MessagePack serialization options

MessagePack serialization can be configured by providing a delegate to the <xref:Microsoft.Extensions.DependencyInjection.MsgPackProtocolDependencyInjectionExtensions.AddMessagePackProtocol%2A> call. For more information, see [MessagePack in SignalR](xref:signalr/messagepackhubprotocol).

> [!NOTE]
> It's not possible to configure MessagePack serialization in the JavaScript client at this time.

## Configure server options

The following table describes options for configuring SignalR hubs:

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `ClientTimeoutInterval` | 30 seconds | The server considers the client disconnected if it doesn't receive a message (including keep-alive) within this interval. It can take longer than this timeout interval for the client to be marked disconnected due to how this feature is implemented. The recommended value is double the `KeepAliveInterval` value. |
| `HandshakeTimeout` | 15 seconds | If the client doesn't send an initial handshake message within this time interval, the connection is closed. This option is an advanced setting that should only be modified if handshake timeout errors are occurring due to severe network latency. For more detail on the handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |
| `KeepAliveInterval` | 15 seconds | The interval at which a ping message is automatically sent to keep the connection open. When you change the `KeepAliveInterval` value, change the `ServerTimeout` or `serverTimeoutInMilliseconds` setting on the client. The recommended `ServerTimeout` or `serverTimeoutInMilliseconds` value is double the `KeepAliveInterval` value. |
| `SupportedProtocols` | All installed protocols | Protocols supported by this hub. By default, all protocols registered on the server are allowed. Protocols can be removed from this list to disable specific protocols for individual hubs. |
| `EnableDetailedErrors` | `false` | When this option is enabled (`true`), detailed exception messages are returned to clients when an exception is thrown in a hub method. The default is `false` because these exception messages can contain sensitive information. |
| `StreamBufferCapacity` | 10 | The maximum number of items that can be buffered for client upload streams. When this limit is reached, the processing of invocations is blocked until the server processes stream items. |
| `MaximumReceiveMessageSize` | 32 KB | The maximum size of a single incoming hub message. Increasing the value might increase the risk of [Denial of service (DoS) attacks](https://developer.mozilla.org/docs/Glossary/Denial_of_Service). |
| `MaximumParallelInvocationsPerClient` | 1 | The maximum number of hub methods that each client can call in parallel before queueing. Note that this limit doesn't apply to streaming hub invocations. For more information, see <xref:signalr/hubs#limit-per-connection-streaming-invocations>.|
| `DisableImplicitFromServicesParameters` | `false` | Hub method arguments are resolved from dependency injection, if possible. |

Options can be configured for all hubs by providing an options delegate to the `AddSignalR` call in the _Program.cs_ file.

```csharp
 builder.Services.AddSignalR(hubOptions =>
 {
     hubOptions.EnableDetailedErrors = true;
     hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
 });
```

Options for a single hub override the global options provided in `AddSignalR` and can be configured by using the <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddHubOptions%2A> method:

```csharp
builder.Services.AddSignalR().AddHubOptions<ChatHub>(options =>
{
    options.EnableDetailedErrors = true;
});
```

### Configure advanced HTTP options

Use `HttpConnectionDispatcherOptions` to configure advanced settings related to transports and memory buffer management. These options are configured by passing a delegate to the <xref:Microsoft.AspNetCore.Builder.HubEndpointRouteBuilderExtensions.MapHub%2A> method in `Program.cs`.

[!code-csharp[](~/signalr/configuration/samples/6.x/Program.cs?highlight=24-30)]

The following table describes options for configuring ASP.NET Core SignalR's advanced HTTP options:

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `ApplicationMaxBufferSize` | 64 KB | The maximum number of bytes received from the client that the server buffers before applying backpressure. Increasing this value allows the server to receive larger messages faster without applying backpressure, but can increase memory consumption. |
| `TransportMaxBufferSize` | 64 KB | The maximum number of bytes sent by the app that the server buffers before observing backpressure. Increasing this value allows the server to buffer larger messages faster without awaiting backpressure, but can increase memory consumption. |
| `AuthorizationData` | Data automatically gathered from the `Authorize` attributes applied to the Hub class. | A list of <xref:Microsoft.AspNetCore.Authorization.IAuthorizeData> objects used to determine if a client is authorized to connect to the hub. |
| `Transports` | All Transports are enabled. | A bit flags enum of `HttpTransportType` values that can restrict the transports a client can use to connect. |
| `LongPolling` | See [Configure Long Polling transport](#configure-long-polling-transport) | Options specific to the Long Polling transport. |
| `WebSockets` | See [Configure WebSocket transport](#configure-websocket-transport) | Options specific to the WebSockets transport. |
| `MinimumProtocolVersion` | 0 | The minimum version of the negotiation protocol. This value is used to limit clients to newer versions of the protocol. |
| `CloseOnAuthenticationExpiration` | `false` | Controls authentication expiration tracking, which closes connections when a token expires. |

#### Configure Long Polling transport

The Long Polling transport has other options that can be configured by using the `LongPolling` property:

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `PollTimeout` | 90 seconds | The maximum amount of time the server waits for a message to send to the client before terminating a single poll request. Decreasing this value causes the client to issue new poll requests more frequently. |

#### Configure WebSocket transport

The WebSocket transport has other options that can be configured by using the `WebSockets` property:

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `CloseTimeout` | 5 seconds | After the server closes, if the client fails to close within this time interval, the connection is terminated. |
| `SubProtocolSelector` | `null` | A delegate that can be used to set the `Sec-WebSocket-Protocol` header to a custom value. The delegate receives the values requested by the client as input and is expected to return the desired value. |

## Configure client options

In the .NET client and JavaScript client, the client options are configured on the `HubConnectionBuilder` type. In the Java client, the options are configured on the `HttpHubConnectionBuilder` subclass, which contains the builder configuration options and the `HubConnection` itself.

### Configure logging

Logging is configured in the .NET client by using the `ConfigureLogging` method. Logging providers and filters can be registered in the same way as they are on the server. For more information, see the [Logging in ASP.NET Core](xref:fundamentals/logging/index) documentation.

> [!NOTE]
> To register logging providers, you must install the necessary packages. For more information, see the full list of [Built-in logging providers](xref:fundamentals/logging/index#built-in-logging-providers).

For example, to enable Console logging, install the `Microsoft.Extensions.Logging.Console` NuGet package. Call the `AddConsole` extension method:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub")
    .ConfigureLogging(logging => {
        logging.SetMinimumLevel(LogLevel.Information);
        logging.AddConsole();
    })
    .Build();
```

In the JavaScript client, a similar `configureLogging` method exists. Provide a `LogLevel` value as the minimum level of log messages to produce. Logs are written to the browser console window.

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .configureLogging(signalR.LogLevel.Information)
    .build();
```

Instead of a `LogLevel` value, you can also provide a `string` value that represents a log level name. This approach is useful when configuring SignalR logging in environments where you don't have access to the `LogLevel` constants.

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .configureLogging("warn")
    .build();
```

The following table lists the available log levels. The value you provide to `configureLogging` sets the **minimum** log level for logging. Messages logged at this level, **or the levels listed after it in the table**, are logged.

| String                      | LogLevel               |
| --------------------------- | ---------------------- |
| `trace`                     | `LogLevel.Trace`       |
| `debug`                     | `LogLevel.Debug`       |
| `info` **or** `information` | `LogLevel.Information` |
| `warn` **or** `warning`     | `LogLevel.Warning`     |
| `error`                     | `LogLevel.Error`       |
| `critical`                  | `LogLevel.Critical`    |
| `none`                      | `LogLevel.None`        |

> [!NOTE]
> To disable logging entirely, specify `signalR.LogLevel.None` in the `configureLogging` method.

For more information on logging, see <xref:signalr/diagnostics>.

The SignalR Java client uses the [Simple Logging Facade for Java (SLF4J)](https://www.slf4j.org/) library for logging. It's a high-level logging API that allows users of the library to choose their own specific logging implementation by bringing in a specific logging dependency. The following code snippet shows how to use `java.util.logging` with the SignalR Java client.

```gradle
implementation 'org.slf4j:slf4j-jdk14:1.7.25'
```

If you don't configure logging in your dependencies, SLF4J loads a default no-operation logger with the following warning message:

```output
SLF4J: Failed to load class "org.slf4j.impl.StaticLoggerBinder".
SLF4J: Defaulting to no-operation (NOP) logger implementation
SLF4J: See http://www.slf4j.org/codes.html#StaticLoggerBinder for further details.
```

You can safely ignore this message.

### Configure allowed transports

The transports used by SignalR can be configured in the `WithUrl` call (`withUrl` in JavaScript). A bitwise-OR of the values of `HttpTransportType` can be used to restrict the client to only use the specified transports. All transports are enabled by default.

For example, to disable the Server-Sent Events transport, but allow WebSockets and Long Polling connections:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", HttpTransportType.WebSockets | HttpTransportType.LongPolling)
    .Build();
```

In the JavaScript client, transports are configured by setting the `transport` field on the options object provided to `withUrl`:

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
    .build();
```

In this version of the Java client, WebSockets is the only available transport.

In the Java client, the transport is selected by using the `withTransport` method on the `HttpHubConnectionBuilder`. The Java client defaults to using the WebSockets transport.

```java
HubConnection hubConnection = HubConnectionBuilder.create("https://example.com/chathub")
    .withTransport(TransportEnum.WEBSOCKETS)
    .build();
```

> [!NOTE]
> The SignalR Java client doesn't currently support transport fallback.

### Configure bearer authentication

To provide authentication data along with SignalR requests, use the `AccessTokenProvider` option (`accessTokenFactory` in JavaScript) to specify a function that returns the desired access token. In the .NET client, this access token is passed in as an HTTP "Bearer Authentication" token (using the `Authorization` header with a type of `Bearer`). In the JavaScript client, the access token is used as a Bearer token, **except** in a few cases where browser APIs restrict the ability to apply headers (specifically, in Server-Sent Events and WebSockets requests). In these cases, the access token is provided as a query string value `access_token`.

In the .NET client, the `AccessTokenProvider` option can be specified by using the options delegate in `WithUrl`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options => {
        options.AccessTokenProvider = async () => {
            // Get and return the access token.
        };
    })
    .Build();
```

In the JavaScript client, the access token is configured by setting the `accessTokenFactory` field on the options object in `withUrl`:

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub", {
        accessTokenFactory: () => {
            // Get and return the access token.
            // This function can return a JavaScript Promise if asynchronous
            // logic is required to retrieve the access token.
        }
    })
    .build();
```

In the SignalR Java client, you can configure a bearer token to use for authentication by supplying an access token provider to the [HttpHubConnectionBuilder](/java/api/com.microsoft.signalr.httphubconnectionbuilder?view=aspnet-signalr-java&preserve-view=true). Use [withAccessTokenProvider](/java/api/com.microsoft.signalr.HttpHubConnectionBuilder?view=aspnet-signalr-java&preserve-view=true#com-microsoft-signalr-httphubconnectionbuilder-withaccesstokenprovider(io-reactivex-single(java-lang-string))) to provide an [RxJava](https://github.com/ReactiveX/RxJava) [Single\<String>](https://reactivex.io/documentation/single.html). With a call to [Single.defer](https://reactivex.io/RxJava/javadoc/io/reactivex/Single.html#defer-java.util.concurrent.Callable-), you can write logic to produce access tokens for your client.

```java
HubConnection hubConnection = HubConnectionBuilder.create("https://example.com/chathub")
    .withAccessTokenProvider(Single.defer(() -> {
        // Your logic here.
        return Single.just("An Access Token");
    })).build();
```

### Configure timeout and keep-alive options

This section describes other options for configuring timeout and keep-alive behavior.

# [.NET](#tab/dotnet)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `WithServerTimeout` | 30 seconds (30,000 milliseconds) | The timeout value for server activity, which is set directly on the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. If the server doesn't send a message within this interval, the client considers the server disconnected and triggers the `Closed` event (`onclose` in JavaScript). This value must be large enough for a ping message to be sent from the server **and** received by the client within the timeout interval. The recommended value is a number at least double the server's keep-alive interval (`WithKeepAliveInterval`) value to allow time for pings to arrive. |
| `HandshakeTimeout` | 15 seconds | The timeout value for the initial server handshake, which is available on the `HubConnection` object itself. If the server doesn't send a handshake response within this interval, the client cancels the handshake and triggers the `Closed` event (`onclose` in JavaScript). This option is an advanced setting that should be modified only if handshake timeout errors are occurring due to severe network latency. For more detail on the handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |
| `WithKeepAliveInterval` | 15 seconds | This value determines the interval at which the client sends ping messages and is set directly on the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. Sending any message from the client resets the timer to the start of the interval. If the client doesn't send a message within the `ClientTimeoutInterval` set on the server, the server considers the client disconnected. |

In the .NET client, timeout values are specified as `TimeSpan` values.

The following example shows values that are double the default values:

```csharp
var builder = new HubConnectionBuilder()
    .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
    .WithServerTimeout(TimeSpan.FromSeconds(60))
    .WithKeepAliveInterval(TimeSpan.FromSeconds(30))
    .Build();

builder.On<string, string>("ReceiveMessage", (user, message) => ...

await builder.StartAsync();
```

# [JavaScript](#tab/javascript)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `withServerTimeout` | 30 seconds (30,000 milliseconds) | The timeout value for server activity, which is set directly on the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. If the server doesn't send a message within this interval, the client considers the server disconnected and triggers the `onclose` event. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. This value must be large enough for a ping message to be sent from the server **and** received by the client within the timeout interval. The recommended value is a number at least double the server's keep-alive interval (`withKeepAliveInterval`) value to allow time for pings to arrive. |
| `withKeepAliveInterval` | 15 seconds (15,000 milliseconds) | This value determines the interval at which the client sends ping messages and is set directly on <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. Sending any message from the client resets the timer to the start of the interval. If the client doesn't send a message within the `ClientTimeoutInterval` set on the server, the server considers the client disconnected. The ping occurs at most as often as the server pings. If the server pings every five seconds, assigning a value lower than `5000` (5 seconds) pings every five seconds. The default value is 15 seconds. The keep-alive interval should be less than or equal to half the value assigned to the server timeout (`withServerTimeout`). |

The following example shows values that are double the default values:

```javascript
var connection = new signalR.HubConnectionBuilder()
  .withUrl("/chatHub")
  .withServerTimeout(60000)
  .withKeepAliveInterval(30000)
  .build();
```

# [Java](#tab/java)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `getServerTimeout` / `setServerTimeout` | 30 seconds (30,000 milliseconds) | The timeout value for server activity. If the server doesn't send a message within this interval, the client considers the server disconnected and triggers the `onClose` event. This value must be large enough for a ping message to be sent from the server **and** received by the client within the timeout interval. The recommended value is a number at least double the server's `KeepAliveInterval` value to allow time for pings to arrive. |
| `withHandshakeResponseTimeout` | 15 seconds | The timeout value for the initial server handshake. If the server doesn't send a handshake response within this interval, the client cancels the handshake and triggers the `onClose` event. This option is an advanced setting that should be modified only if handshake timeout errors are occurring due to severe network latency. For more detail on the Handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |
| `getKeepAliveInterval` / `setKeepAliveInterval` | 15 seconds (15,000 milliseconds) | This value determines the interval at which the client sends ping messages. Sending any message from the client resets the timer to the start of the interval. If the client doesn't send a message within the `ClientTimeoutInterval` set on the server, the server considers the client disconnected. |

---

### Configure stateful reconnect

SignalR _stateful reconnect_ reduces the perceived downtime of clients that have a temporary disconnect in their network connection, such as when switching network connections or a short temporary loss in access.

Stateful reconnect achieves the perceived downtime by:

* Temporarily buffering data on the server and client.
* Acknowledging messages received (ACK-ing) by both the server and client.
* Recognizing when a connection is up and replaying messages that might be sent while the connection is down.

Stateful reconnect is available in .NET 8 or later.

#### Enable stateful reconnect

You can opt in to stateful reconnect at both the server hub endpoint and the client.

* On the server hub endpoint, update the configuration to enable the `AllowStatefulReconnects` option:

   ```csharp
   app.MapHub<MyHub>("/hubName", options =>
   {
      options.AllowStatefulReconnects = true;
   });
   ```

   Optionally, the maximum buffer size in bytes allowed by the server can be set globally or for a specific hub with the `StatefulReconnectBufferSize` option.

   - Set the `StatefulReconnectBufferSize` option globally:

      ```csharp
      builder.AddSignalR(o => o.StatefulReconnectBufferSize = 1000);
      ```

   - Set the `StatefulReconnectBufferSize` option for a specific hub:

      ```csharp
      builder.AddSignalR().AddHubOptions<MyHub>(o => o.StatefulReconnectBufferSize = 1000);
      ```

   The `StatefulReconnectBufferSize` setting is optional with a default size of 100,000 bytes.

* On the client, update the JavaScript or TypeScript code to enable the `withStatefulReconnect` option:

   ```JavaScript
   const builder = new signalR.HubConnectionBuilder()
      .withUrl("/hubname")
      .withStatefulReconnect({ bufferSize: 1000 });  // Optional, defaults to 100,000
   const connection = builder.build();
   ```
  
   The `bufferSize` setting is optional with a default size of 100,000 bytes.
  
* On the .NET client, update the code to enable the `WithStatefulReconnect` option:

   ```csharp
   var builder = new HubConnectionBuilder()
      .WithUrl("<hub url>")
      .WithStatefulReconnect();
   builder.Services.Configure<HubConnectionOptions>(o => o.StatefulReconnectBufferSize = 1000);
   var hubConnection = builder.Build();
   ```

   The `StatefulReconnectBufferSize` setting is optional with a default size of 100,000 bytes.

### Configure other options

You can configure other options in the `WithUrl` (`withUrl` in JavaScript) method on `HubConnectionBuilder` or on the various configuration APIs on the `HttpHubConnectionBuilder` in the Java client.

# [.NET](#tab/dotnet)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `AccessTokenProvider` | `null` | A function that returns a string, which is provided as a Bearer authentication token in HTTP requests. |
| `SkipNegotiation` | `false` | Set this option to `true` to skip the negotiation step. <br><br>**Note**: This option is available only when the WebSockets transport is the only enabled transport. The setting can't be enabled when using the Azure SignalR Service. |
| `ClientCertificates` | Empty | A collection of Transport Layer Security (TLS) certificates to send to authenticate requests. |
| `Cookies` | Empty | A collection of HTTP cookies to send with every HTTP request. |
| `Credentials` | Empty | The credentials to send with every HTTP request. |
| `CloseTimeout` | 5 seconds | The maximum amount of time the client waits after closing for the server to acknowledge the close request. If the server doesn't acknowledge the close within this time, the client disconnects. <br><br>**Note**: This setting is available for WebSockets only. |
| `Headers` | Empty | A map of other HTTP headers to send with every HTTP request. |
| `HttpMessageHandlerFactory` | `null` | A delegate that can be used to configure or replace the `HttpMessageHandler` used to send HTTP requests. This delegate must return a non-null value, and it receives the default value as a parameter. You can either modify settings on that default value and return it, or return a new `HttpMessageHandler` instance. <br><br>**Note**: <br> - When you replace the handler, be sure to copy the settings you want to keep from the provided handler. Otherwise, the configured options (such as Cookies and Headers) don't apply to the new handler. <br> - This setting isn't used for WebSocket connections. |
| `Proxy` | `null` | An HTTP proxy to use when sending HTTP requests. |
| `UseDefaultCredentials` | `false` | Set this boolean to send the default credentials for HTTP and WebSockets requests. This option enables the use of Windows authentication. |
| `WebSocketConfiguration` | `null` | A delegate that can be used to configure more WebSocket options. Receives an instance of <xref:System.Net.WebSockets.ClientWebSocketOptions> that can be used to configure the options. |
| `ApplicationMaxBufferSize` | 1 MB | The maximum number of bytes received from the server that the client buffers before applying backpressure. Increasing this value allows the client to receive larger messages faster without applying backpressure, but can increase memory consumption. |
| `TransportMaxBufferSize` | 1 MB | The maximum number of bytes sent by the user application that the client buffers before observing backpressure. Increasing this value allows the client to buffer larger messages faster without awaiting backpressure, but can increase memory consumption. |

In the .NET client, these options can be modified in the options delegate provided to `WithUrl`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options => {
        options.Headers["Foo"] = "Bar";
        options.SkipNegotiation = true;
        options.Transports = HttpTransportType.WebSockets;
        options.Cookies.Add(new Cookie(/* ... */);
        options.ClientCertificates.Add(/* ... */);
    })
    .Build();
```

# [JavaScript](#tab/javascript)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `accessTokenFactory` | `null` | A function that returns a string, which is provided as a Bearer authentication token in HTTP requests. |
| `transport` | `null` | An <xref:Microsoft.AspNetCore.Http.Connections.HttpTransportType> value specifying the transport to use for the connection. |
| `headers` | `null` | A dictionary of headers sent with every HTTP request. <br><br>**Note**: Sending headers in the browser doesn't work for WebSockets or the <xref:Microsoft.AspNetCore.Http.Connections.HttpTransportType#microsoft-aspnetcore-http-connections-httptransporttype-serversenteventsstream> stream. |
| `logMessageContent` | `null` | Set this option to `true` to log the bytes/chars of messages sent and received by the client. |
| `skipNegotiation` | `false` | Set this option to `true` to skip the negotiation step. <br><br>**Note**: This option is available only when the WebSockets transport is the only enabled transport. The setting can't be enabled when using the Azure SignalR Service. |
| `withCredentials` | `true` | Specifies whether credentials are sent with the CORS request. Azure App Service uses cookies for sticky sessions and needs this option enabled to work correctly. For more information on CORS with SignalR, see <xref:signalr/security#cross-origin-resource-sharing>. |
| `timeout` | `100,000` | The timeout value in milliseconds to apply to HTTP requests. <br><br>**Note**: This option doesn't apply to Long Polling poll requests, EventSource, or WebSockets. |

In the JavaScript Client, these options can be provided in a JavaScript object provided to `withUrl`:

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub", {
        // "Foo: Bar" will not be sent with WebSockets or Server-Sent Events requests
        headers: { "Foo": "Bar" },
        transport: signalR.HttpTransportType.LongPolling 
    })
    .build();
```

# [Java](#tab/java)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `withAccessTokenProvider` | `null` | A function that returns a string, which is provided as a Bearer authentication token in HTTP requests. |
| `shouldSkipNegotiate` | `false` | Set this option to `true` to skip the negotiation step. <br><br>**Note**: This option is available only when the WebSockets transport is the only enabled transport. The setting can't be enabled when using the Azure SignalR Service. |
| `withHeader` `withHeaders` | Empty | A map of other HTTP headers to send with every HTTP request. |

In the Java client, these options can be configured with the methods on the `HttpHubConnectionBuilder` returned from the `HubConnectionBuilder.create("HUB URL")`:

```java
HubConnection hubConnection = HubConnectionBuilder.create("https://example.com/chathub")
        .withHeader("Foo", "Bar")
        .shouldSkipNegotiate(true)
        .withHandshakeResponseTimeout(30*1000)
        .build();
```

---

## Related content

* <xref:tutorials/signalr>
* <xref:signalr/hubs>
* <xref:signalr/javascript-client>
* <xref:signalr/dotnet-client>
* <xref:signalr/messagepackhubprotocol>
* <xref:signalr/supported-platforms>

:::moniker-end

[!INCLUDE[](~/signalr/configuration/includes/configuration2.1.md)]

[!INCLUDE[](~/signalr/configuration/includes/configuration2.2.md)]

[!INCLUDE[](~/signalr/configuration/includes/configuration3.md)]

[!INCLUDE[](~/signalr/configuration/includes/configuration3.1.md)]

[!INCLUDE[](~/signalr/configuration/includes/configuration5.md)]

[!INCLUDE[](~/signalr/configuration/includes/configuration6.md)]

[!INCLUDE[](~/signalr/configuration/includes/configuration7.md)]
