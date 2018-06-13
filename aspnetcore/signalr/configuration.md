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

## JSON/MessagePack Serialization Options

ASP.NET Core SignalR supports two protocols for encoding messages, JSON and MessagePack. Each protocol has configuration options that can be used to configure serialization.
JSON Serialization Options

JSON serialization can be configured on both the Server and .NET Client by providing a delegate to the AddJsonHubProtocol method. The options object received by that delegate has a PayloadSerializedSettings which is a JSON.NET JsonSerializerSettings object that can be used to configure serialization of arguments and return values

On the server, add `AddJsonHubProtocol` to the `AddSignalR` call in `ConfigureServices`. Use PascalCase property names instead of the default camelCase names. See the [JSON.NET Documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm) for more details.

```csharp
    services.AddSignalR()
        .AddJsonHubProtocol(options => {
            options.PayloadSerializerSettings.ContractResolver = 
            new DefaultContractResolver();
        });
}
```

On a .NET client, the same `AddJsonHubProtocol` extension method exists on `HubConnectionBuilder`. The `Microsoft.Extensions.DependencyInjection` namespace must be imported to see the method:

```csharp
// At the top of the file:
using Microsoft.Extensions.DependencyInjection;

// When constructing your connection:
var connection = new HubConnectionBuilder();
    .AddJsonHubProtocol(options => {
        options.PayloadSerializerSettings.ContractResolver = 
            new DefaultContractResolver();
    });
```

### MessagePack Serialization Options

MessagePack serialization can be configured by providing a delegate to the `AddMessagePackProtocol` call. See [MessagePack in SignalR](xref:signalr/messagepack) for more details.

> [!NOTE]
> It's not possible to configure JSON or MessagePack serialization in the JavaScript client at this time.

### Configure [HubOptions](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.huboptions) for SignalR

The following table describes the `HubOptions` options for configuring the hub:

| Option | Description |
| ------ | ----------- |
| `HandshakeTimeout` | If the client doesn't send an initial handshake message within this time interval, the connection will be closed |
| `KeepAliveInterval` | If the server hasn't sent a message within this interval, a ping message will is sent automatically to keep the connection open |
| `SupportedProtocols` | Protocols supported by this hub. By default, all protocols registered on the server are allowed, but protocols can be removed from this list to disable specific protocols for individual hubs. |
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

Strongly-typed [HubOptions<T>](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.huboptions-1) can be configured as follows, for example, setting the `EnableDetailedErrors` property:

```csharp
  services.AddSignalR().AddHubOptions<HubName>(options =>
  {
      options.EnableDetailedErrors = true;
  }
```

### HttpConnectionDispatcherOptions

Options related to the transport layer. Use these to restrict the transports that can be used by SignalR clients, as well as to configure advanced settings related to memory buffer management. These options are configured by passing a delegate to `MapHub<T>`.

| Option | Description |
| ------ | ----------- |
| `ApplicationMaxBufferSize`  | The maximum number of bytes the connection (transport) can buffer when invoking methods from the client, before blocking and waiting for the application to consume enough bytes to allow writing again.  |
| `AuthorizationData` | A pre-populated list of `IAuthorizeData` gathered from the `Authorize` attributes used on the `Hub<T>`. |
| `LongPolling`  | Gets the LongPolling options object that has a settable `PollTimeout` property. Setting the `PollTimeOut` sets the wait time before ending a poll request. |
| `TransportMaxBufferSize`  | The maximum number of bytes the application. For example, `Clients.All.SendAsync` can buffer when writing to a single connection before blocking and waiting for the connection to consume enough bytes to allow writing again. |
| `Transports`  | A bitmask that sets a transport. The available `options.Transports` options are as follows: `HttpTransportType.WebSockets`, `HttpTransportType.LongPolling`, and `HttpTransportType.ServerSentEvents` |
| `WebSockets`  |  Gets the WebSockets options object.  |
| `CloseTimeout`  | TimeSpan to set how long to wait for a clean WebSocket close when connection is being terminated  |
| `SubProtocolSelector` | A delegate the hub calls and passes a list of `Sec-WebSocket-Protocol` values from the request header. A delegate returns the chosen `Sec-WebSocket-Protocol`. |
| AccessTokenProvider | A delegate that is called to get an access token. The token is applied as an HTTP Bearer Authentication header. |

### [HubConnectionBuilder](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnectionbuilder?view=aspnetcore-2.1)

The `HubConnectionBuilder` API is available for both C# and TypeScript clients.

| Option | Description |
| ------ | ----------- |
| Headers | HTTP headers to be applied to all HTTP requests. |
| Cookies | Cookies to be sent with each HTTP request. |
| ClientCertificates | TLS client certificates to send when connecting over HTTP (not supported in Xamarin) |

The following code samples demonstrate the C# setting connection options with the `HubConnectionBuilder`:

```csharp
// Creates a connection and restricts transports to WebSockets and Server Sent Events.
var connection = new HubConnectionBuilder()
    .WithUrl("url", HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents)
    .Build();

// Creates a connection with a JSON Web Token.
var connection = new HubConnectionBuilder()
    .WithUrl("url", options => {
        options.AccessTokenProvider = async () => {
            // Get access token and return it.
        };
    });
    .Build();

// Creates a connection, and sets headers, cookies, and client certificates.
var connection = new HubConnectionBuilder()
    .WithUrl("url", options => {
        options.Headers["Foo"] = "Bar";
        options.Cookies.Add(new Cookie(...));
        options.ClientCertificates.Add(...);
    });
    .Build();
```

The following code samples demonstrate setting connection options with the `HubConnectionBuilder` in JavaScript:

```javascript
// Creates a basic connection
const connection = new signalR.HubConnectionBuilder()
    .withUrl("url")
    .build();

// Sets the transport type. Transport types are defined in preceding table
const connection = new signalR.HubConnectionBuilder()
    .withUrl("url", HttpTransportType.WebSockets)
    .build();

// Sets the protocol such as Messagepack
const connection = new signalR.HubConnectionBuilder()
    .withUrl("url")
    .withHubProtocol(IHubProtocol)
    .build();
```

> ![NOTE]
> Headers, cookies and client certificates cannot be configured in the JavaScript client due to limitations on browser APIs.

The following table and code sample demonstrate the available `HttpConnectionOptions`.

| Option | Description |
| ------ | ----------- |
| `httpClient`  | Class that handles all the GET, POST, and DELETE requests sent by the client. Can override with custom settings. |
| `transport`  | Specific transport the client should use, or an `ITransport` implementation for a custom transport. |
| `accessTokenFactory`  | Called for each HTTP request to set the authorization header or for WebSockets to set the `access_token` query string value. |
| `logMessageContent`  | Log the message content when sending and receiving. Disabled by default. |
| `skipNegotiation`  | Only use this when `HttpTransportType.WebSockets` is specified. It skips the negotiation step when it not necessary. |

> [!NOTE]
> All `HttpConnectionOptions` are optional.

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("url", IHttpConnectionOptions)
    .build();
```

Once you have a `HubConnection` there are two settings you can change:

| Option | Description |
| ------ | ----------- |
| `serverTimeoutInMilliseconds` | Closes the connection if time since last message received is greater than this value. |
| `keepAliveIntervalInMilliseconds` | SignalR 1.1: The interval at which the client sends pings to the server to keep the server from closing the connection. |

```javascript
hubConnection.serverTimeoutInMilliseconds = 5 * 1000; // 5 seconds
hubConnection.keepAliveIntervalInMilliseconds = 10 * 1000; // 10 seconds
```

## Additional Resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)