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

On the server, add `AddJsonHubProtocol` to your `AddSignalR` call in `ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ... other services ...
    services.AddSignalR()
        .AddJsonHubProtocol(options => {
            // Configure the PayloadSerializerSettings here. 
            // For example, use PascalCase property names instead of 
            // the default camelCase names:
            options.PayloadSerializerSettings.ContractResolver = 
            new DefaultContractResolver();
            // See the JSON.NET Documentation for more details:
            // https://www.newtonsoft.com/json/help/html/Introduction.htm
        });
}
```

On the client, the same `AddJsonHubProtocol` extension method exists on `HubConnectionBuilder`. The `Microsoft.Extensions.DependencyInjection` namespace must be imported to see the method:

```csharp
// At the top of the file:
using Microsoft.Extensions.DependencyInjection;

// When constructing your connection:
var connection = new HubConnectionBuilder();
    .AddJsonHubProtocol(options => {
        // Configure the PayloadSerializerSettings here.
        // For example, use PascalCase property names instead of
        // the default camelCase names:
        options.PayloadSerializerSettings.ContractResolver = 
            new DefaultContractResolver();
        // See the JSON.NET Documentation for more details:
        // https://www.newtonsoft.com/json/help/html/Introduction.htm
    });
```

### MessagePack Serialization Options

MessagePack serialization can be configured by providing a delegate to the `AddMessagePackProtocol` call. See [MessagePack in SignalR](xref:signalr/messagepack) for more details.

> [!NOTE]
> It's not possible to configure JSON or MessagePack serialization on the JavaScript client at this time.

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

Strongly-typed [HubOptions<T>](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.huboptions-1) can be configured as follows:

```csharp
  services.AddSignalR().AddHubOptions<HubName>(options =>
  {
      options.EnableDetailedErrors = true;
  }
```

### HttpConnectionDispatcherOptions

Options related to the transport layer. Use these to restrict the transports that can be used by SignalR clients, as well as to configure advanced settings related to memory buffer management.

These options are configured by passing a delegate to `MapHub<T>`.

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

The following code samples demonstrate setting connection options with the `HubConnectionBuilder`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("...", HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents)
    .Build();

var connection = new HubConnectionBuilder()
    .WithUrl("...", options => {
        options.AccessTokenProvider = async () => {
            // Get access token and return it.
        };
    });
    .Build();

var connection = new HubConnectionBuilder()
    .WithUrl("...", options => {
        options.Headers["Foo"] = "Bar";
        options.Cookies.Add(new Cookie(...));
        options.ClientCertificates.Add(...);
    });
    .Build();
```

Headers, cookies and client certificates cannot be configured in the JavaScript client due to limitations on browser APIs.

## Additional Resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)