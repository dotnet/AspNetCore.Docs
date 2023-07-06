
:::moniker range="= aspnetcore-3.1"

## JSON/MessagePack serialization options

ASP.NET Core SignalR supports two protocols for encoding messages: [JSON](https://www.json.org/) and [MessagePack](https://msgpack.org/index.html). Each protocol has serialization configuration options.

JSON serialization can be configured on the server using the <xref:Microsoft.Extensions.DependencyInjection.JsonProtocolDependencyInjectionExtensions.AddJsonProtocol%2A> extension method. `AddJsonProtocol` can be added after <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A> in `Startup.ConfigureServices`. The `AddJsonProtocol` method takes a delegate that receives an `options` object. The <xref:Microsoft.AspNetCore.SignalR.JsonHubProtocolOptions.PayloadSerializerOptions%2A> property on that object is a `System.Text.Json` <xref:System.Text.Json.JsonSerializerOptions> object that can be used to configure serialization of arguments and return values. For more information, see the [System.Text.Json documentation](xref:System.Text.Json).

For example, to configure the serializer to not change the casing of property names, rather than the default [camel case](https://wikipedia.org/wiki/Camel_case) names, use the following code in `Startup.ConfigureServices`:

```csharp
services.AddSignalR()
    .AddJsonProtocol(options => {
        options.PayloadSerializerOptions.PropertyNamingPolicy = null
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

### Switch to Newtonsoft.Json

If you need features of `Newtonsoft.Json` that aren't supported in `System.Text.Json`, see [Switch to `Newtonsoft.Json`](xref:migration/22-to-30#switch-to-newtonsoftjson).

### MessagePack serialization options

MessagePack serialization can be configured by providing a delegate to the <xref:Microsoft.Extensions.DependencyInjection.MsgPackProtocolDependencyInjectionExtensions.AddMessagePackProtocol%2A> call. See [MessagePack in SignalR](xref:signalr/messagepackhubprotocol) for more details.

> [!NOTE]
> It's not possible to configure MessagePack serialization in the JavaScript client at this time.

## Configure server options

The following table describes options for configuring SignalR hubs:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `ClientTimeoutInterval` | 30 seconds | The server considers the client disconnected if it hasn't received a message (including keep-alive) in this interval. It could take longer than this timeout interval for the client to be marked disconnected due to how this is implemented. The recommended value is double the `KeepAliveInterval` value.|
| `HandshakeTimeout` | 15 seconds | If the client doesn't send an initial handshake message within this time interval, the connection is closed. This is an advanced setting that should only be modified if handshake timeout errors are occurring due to severe network latency. For more detail on the handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |
| `KeepAliveInterval` | 15 seconds | If the server hasn't sent a message within this interval, a ping message is sent automatically to keep the connection open. When changing `KeepAliveInterval`, change the `ServerTimeout` or `serverTimeoutInMilliseconds` setting on the client. The recommended `ServerTimeout` or `serverTimeoutInMilliseconds` value is double the `KeepAliveInterval` value.  |
| `SupportedProtocols` | All installed protocols | Protocols supported by this hub. By default, all protocols registered on the server are allowed. Protocols can be removed from this list to disable specific protocols for individual hubs. |
| `EnableDetailedErrors` | `false` | If `true`, detailed exception messages are returned to clients when an exception is thrown in a Hub method. The default is `false` because these exception messages can contain sensitive information. |
| `StreamBufferCapacity` | `10` | The maximum number of items that can be buffered for client upload streams. If this limit is reached, the processing of invocations is blocked until the server processes stream items.|
| `MaximumReceiveMessageSize` | 32 KB | Maximum size of a single incoming hub message. Increasing the value may increase the risk of [Denial of service (DoS) attacks](https://developer.mozilla.org/docs/Glossary/DOS_attack). |

Options can be configured for all hubs by providing an options delegate to the `AddSignalR` call in `Startup.ConfigureServices`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSignalR(hubOptions =>
    {
        hubOptions.EnableDetailedErrors = true;
        hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
    });
}
```

Options for a single hub override the global options provided in `AddSignalR` and can be configured using <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddHubOptions%2A>:

```csharp
services.AddSignalR().AddHubOptions<ChatHub>(options =>
{
    options.EnableDetailedErrors = true;
});
```

### Advanced HTTP configuration options

Use `HttpConnectionDispatcherOptions` to configure advanced settings related to transports and memory buffer management. These options are configured by passing a delegate to <xref:Microsoft.AspNetCore.Builder.HubEndpointRouteBuilderExtensions.MapHub%2A> in `Startup.Configure`.

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHub<ChatHub>("/chathub", options =>
        {
            options.Transports =
                HttpTransportType.WebSockets |
                HttpTransportType.LongPolling;
        });
    });
}
```

The following table describes options for configuring ASP.NET Core SignalR's advanced HTTP options:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `ApplicationMaxBufferSize` | 32 KB | The maximum number of bytes received from the client that the server buffers before applying backpressure. Increasing this value allows the server to receive larger messages more quickly without applying backpressure, but can increase memory consumption. |
| `AuthorizationData` | Data automatically gathered from the `Authorize` attributes applied to the Hub class. | A list of <xref:Microsoft.AspNetCore.Authorization.IAuthorizeData> objects used to determine if a client is authorized to connect to the hub. |
| `TransportMaxBufferSize` | 32 KB | The maximum number of bytes sent by the app that the server buffers before observing backpressure. Increasing this value allows the server to buffer larger messages more quickly without awaiting backpressure, but can increase memory consumption. |
| `Transports` | All Transports are enabled. | A bit flags enum of `HttpTransportType` values that can restrict the transports a client can use to connect. |
| `LongPolling` | See below. | Additional options specific to the Long Polling transport. |
| `WebSockets` | See below. | Additional options specific to the WebSockets transport. |
| `MinimumProtocolVersion` | 0 | Specify the minimum version of the negotiate protocol. This is used to limit clients to newer versions. |

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

Client options can be configured on the `HubConnectionBuilder` type (available in the .NET and JavaScript clients). It's also available in the Java client, but the `HttpHubConnectionBuilder` subclass is what contains the builder configuration options, as well as on the `HubConnection` itself.

### Configure logging

Logging is configured in the .NET Client using the `ConfigureLogging` method. Logging providers and filters can be registered in the same way as they are on the server. See the [Logging in ASP.NET Core](xref:fundamentals/logging/index) documentation for more information.

> [!NOTE]
> In order to register Logging providers, you must install the necessary packages. See the [Built-in logging providers](xref:fundamentals/logging/index#built-in-logging-providers) section of the docs for a full list.

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

In the JavaScript client, a similar `configureLogging` method exists. Provide a `LogLevel` value indicating the minimum level of log messages to produce. Logs are written to the browser console window.

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .configureLogging(signalR.LogLevel.Information)
    .build();
```

Instead of a `LogLevel` value, you can also provide a `string` value representing a log level name. This is useful when configuring SignalR logging in environments where you don't have access to the `LogLevel` constants.

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .configureLogging("warn")
    .build();
```

The following table lists the available log levels. The value you provide to `configureLogging` sets the **minimum** log level that will be logged. Messages logged at this level, **or the levels listed after it in the table**, will be logged.

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

For more information on logging, see the [SignalR Diagnostics documentation](xref:signalr/diagnostics).

The SignalR Java client uses the [SLF4J](https://www.slf4j.org/) library for logging. It's a high-level logging API that allows users of the library to choose their own specific logging implementation by bringing in a specific logging dependency. The following code snippet shows how to use `java.util.logging` with the SignalR Java client.

```gradle
implementation 'org.slf4j:slf4j-jdk14:1.7.25'
```

If you don't configure logging in your dependencies, SLF4J loads a default no-operation logger with the following warning message:

```
SLF4J: Failed to load class "org.slf4j.impl.StaticLoggerBinder".
SLF4J: Defaulting to no-operation (NOP) logger implementation
SLF4J: See http://www.slf4j.org/codes.html#StaticLoggerBinder for further details.
```

This can safely be ignored.

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

In this version of the Java client websockets is the only available transport.

In the Java client, the transport is selected with the `withTransport` method on the `HttpHubConnectionBuilder`. The Java client defaults to using the WebSockets transport.

```java
HubConnection hubConnection = HubConnectionBuilder.create("https://example.com/chathub")
    .withTransport(TransportEnum.WEBSOCKETS)
    .build();
```

> [!NOTE]
> The SignalR Java client doesn't support transport fallback yet.

### Configure bearer authentication

To provide authentication data along with SignalR requests, use the `AccessTokenProvider` option (`accessTokenFactory` in JavaScript) to specify a function that returns the desired access token. In the .NET Client, this access token is passed in as an HTTP "Bearer Authentication" token (Using the `Authorization` header with a type of `Bearer`). In the JavaScript client, the access token is used as a Bearer token, **except** in a few cases where browser APIs restrict the ability to apply headers (specifically, in Server-Sent Events and WebSockets requests). In these cases, the access token is provided as a query string value `access_token`.

In the .NET client, the `AccessTokenProvider` option can be specified using the options delegate in `WithUrl`:

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

In the SignalR Java client, you can configure a bearer token to use for authentication by providing an access token factory to the [HttpHubConnectionBuilder](/java/api/com.microsoft.signalr.httphubconnectionbuilder?view=aspnet-signalr-java&preserve-view=true). Use [withAccessTokenFactory](/java/api/com.microsoft.signalr.httphubconnectionbuilder.withaccesstokenprovider?view=aspnet-signalr-java&preserve-view=true) to provide an [RxJava](https://github.com/ReactiveX/RxJava) [Single\<String>](https://reactivex.io/documentation/single.html). With a call to [Single.defer](https://reactivex.io/RxJava/javadoc/io/reactivex/Single.html#defer-java.util.concurrent.Callable-), you can write logic to produce access tokens for your client.

```java
HubConnection hubConnection = HubConnectionBuilder.create("https://example.com/chathub")
    .withAccessTokenProvider(Single.defer(() -> {
        // Your logic here.
        return Single.just("An Access Token");
    })).build();
```

### Configure timeout and keep-alive options

Additional options for configuring timeout and keep-alive behavior are available on the `HubConnection` object itself:

# [.NET](#tab/dotnet)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `ServerTimeout` | 30 seconds (30,000 milliseconds) | Timeout for server activity. If the server hasn't sent a message in this interval, the client considers the server disconnected and triggers the `Closed` event (`onclose` in JavaScript). This value must be large enough for a ping message to be sent from the server **and** received by the client within the timeout interval. The recommended value is a number at least double the server's `KeepAliveInterval` value to allow time for pings to arrive. |
| `HandshakeTimeout` | 15 seconds | Timeout for initial server handshake. If the server doesn't send a handshake response in this interval, the client cancels the handshake and triggers the `Closed` event (`onclose` in JavaScript). This is an advanced setting that should only be modified if handshake timeout errors are occurring due to severe network latency. For more detail on the handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |
| `KeepAliveInterval` | 15 seconds | Determines the interval at which the client sends ping messages. Sending any message from the client resets the timer to the start of the interval. If the client hasn't sent a message in the `ClientTimeoutInterval` set on the server, the server considers the client disconnected. |

In the .NET Client, timeout values are specified as `TimeSpan` values.

# [JavaScript](#tab/javascript)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `serverTimeoutInMilliseconds` | 30 seconds (30,000 milliseconds) | Timeout for server activity. If the server hasn't sent a message in this interval, the client considers the server disconnected and triggers the `onclose` event. This value must be large enough for a ping message to be sent from the server **and** received by the client within the timeout interval. The recommended value is a number at least double the server's `KeepAliveInterval` value to allow time for pings to arrive. |
| `keepAliveIntervalInMilliseconds` | 15 seconds (15,000 milliseconds) | Determines the interval at which the client sends ping messages. Sending any message from the client resets the timer to the start of the interval. If the client hasn't sent a message in the `ClientTimeoutInterval` set on the server, the server considers the client disconnected. |

# [Java](#tab/java)

| Option | Default value | Description |
| ------ | ------------- | ----------- |
| `getServerTimeout` / `setServerTimeout` | 30 seconds (30,000 milliseconds) | Timeout for server activity. If the server hasn't sent a message in this interval, the client considers the server disconnected and triggers the `onClose` event. This value must be large enough for a ping message to be sent from the server **and** received by the client within the timeout interval. The recommended value is a number at least double the server's `KeepAliveInterval` value to allow time for pings to arrive. |
| `withHandshakeResponseTimeout` | 15 seconds | Timeout for initial server handshake. If the server doesn't send a handshake response in this interval, the client cancels the handshake and triggers the `onClose` event. This is an advanced setting that should only be modified if handshake timeout errors are occurring due to severe network latency. For more detail on the Handshake process, see the [SignalR Hub Protocol Specification](https://github.com/aspnet/SignalR/blob/master/specs/HubProtocol.md). |
| `getKeepAliveInterval` / `setKeepAliveInterval` | 15 seconds (15,000 milliseconds) | Determines the interval at which the client sends ping messages. Sending any message from the client resets the timer to the start of the interval. If the client hasn't sent a message in the `ClientTimeoutInterval` set on the server, the server considers the client disconnected. |

---

### Configure additional options

Additional options can be configured in the `WithUrl` (`withUrl` in JavaScript) method on `HubConnectionBuilder` or on the various configuration APIs on the `HttpHubConnectionBuilder` in the Java client:

# [.NET](#tab/dotnet)

| .NET Option |  Default value | Description |
| ----------- | -------------- | ----------- |
| `AccessTokenProvider` | `null` | A function returning a string that is provided as a Bearer authentication token in HTTP requests. |
| `SkipNegotiation` | `false` | Set this to `true` to skip the negotiation step. **Only supported when the WebSockets transport is the only enabled transport**. This setting can't be enabled when using the Azure SignalR Service. |
| `ClientCertificates` | Empty | A collection of TLS certificates to send to authenticate requests. |
| `Cookies` | Empty | A collection of HTTP cookies to send with every HTTP request. |
| `Credentials` | Empty | Credentials to send with every HTTP request. |
| `CloseTimeout` | 5 seconds | WebSockets only. The maximum amount of time the client waits after closing for the server to acknowledge the close request. If the server doesn't acknowledge the close within this time, the client disconnects. |
| `Headers` | Empty | A Map of additional HTTP headers to send with every HTTP request. |
| `HttpMessageHandlerFactory` | `null` | A delegate that can be used to configure or replace the `HttpMessageHandler` used to send HTTP requests. Not used for WebSocket connections. This delegate must return a non-null value, and it receives the default value as a parameter. Either modify settings on that default value and return it, or return a new `HttpMessageHandler` instance. **When replacing the handler make sure to copy the settings you want to keep from the provided handler, otherwise, the configured options (such as Cookies and Headers) won't apply to the new handler.** |
| `Proxy` | `null` | An HTTP proxy to use when sending HTTP requests. |
| `UseDefaultCredentials` | `false` | Set this boolean to send the default credentials for HTTP and WebSockets requests. This enables the use of Windows authentication. |
| `WebSocketConfiguration` | `null` | A delegate that can be used to configure additional WebSocket options. Receives an instance of <xref:System.Net.WebSockets.ClientWebSocketOptions> that can be used to configure the options. |

# [JavaScript](#tab/javascript)

| JavaScript Option | Default Value | Description |
| ----------------- | ------------- | ----------- |
| `accessTokenFactory` | `null` | A function returning a string that is provided as a Bearer authentication token in HTTP requests. |
| `transport` | `null` | An <xref:Microsoft.AspNetCore.Http.Connections.HttpTransportType> value specifying the transport to use for the connection. |
| `logMessageContent` | `null` | Set to `true` to log the bytes/chars of messages sent and received by the client. |
| `skipNegotiation` | `false` | Set this to `true` to skip the negotiation step. **Only supported when the WebSockets transport is the only enabled transport**. This setting can't be enabled when using the Azure SignalR Service. |

# [Java](#tab/java)

| Java Option | Default Value | Description |
| ----------- | ------------- | ----------- |
| `withAccessTokenProvider` | `null` | A function returning a string that is provided as a Bearer authentication token in HTTP requests. |
| `shouldSkipNegotiate` | `false` | Set this to `true` to skip the negotiation step. **Only supported when the WebSockets transport is the only enabled transport**. This setting can't be enabled when using the Azure SignalR Service. |
| `withHeader` `withHeaders` | Empty | A Map of additional HTTP headers to send with every HTTP request. |

---

In the .NET Client, these options can be modified by the options delegate provided to `WithUrl`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options => {
        options.Headers["Foo"] = "Bar";
        options.Cookies.Add(new Cookie(/* ... */);
        options.ClientCertificates.Add(/* ... */);
    })
    .Build();
```

In the JavaScript Client, these options can be provided in a JavaScript object provided to `withUrl`:

```javascript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .build();
```

In the Java client, these options can be configured with the methods on the `HttpHubConnectionBuilder` returned from the `HubConnectionBuilder.create("HUB URL")`

```java
HubConnection hubConnection = HubConnectionBuilder.create("https://example.com/chathub")
        .withHeader("Foo", "Bar")
        .shouldSkipNegotiate(true)
        .withHandshakeResponseTimeout(30*1000)
        .build();
```

## Additional resources

* <xref:tutorials/signalr>
* <xref:signalr/hubs>
* <xref:signalr/javascript-client>
* <xref:signalr/dotnet-client>
* <xref:signalr/messagepackhubprotocol>
* <xref:signalr/supported-platforms>

:::moniker-end
