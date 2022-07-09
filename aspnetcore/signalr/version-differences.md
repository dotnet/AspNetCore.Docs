---
title: Differences between SignalR and ASP.NET Core SignalR
author: bradygaster
description: Differences between SignalR and ASP.NET Core SignalR
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.date: 11/21/2019
uid: signalr/version-differences
---

# Differences between ASP.NET SignalR and ASP.NET Core SignalR

ASP.NET Core SignalR isn't compatible with clients or servers for ASP.NET SignalR. This article details features which have been removed or changed in ASP.NET Core SignalR.

## How to identify the SignalR version

:::moniker range=">= aspnetcore-3.0"

|                      | ASP.NET SignalR | ASP.NET Core SignalR |
| -------------------- | --------------- | -------------------- |
| **Server NuGet package** | [Microsoft.AspNet.SignalR](https://www.nuget.org/packages/Microsoft.AspNet.SignalR/) | None. Included in the [Microsoft.AspNetCore.App](xref:fundamentals/metapackage-app) shared framework. |
| **Client NuGet packages** | [Microsoft.AspNet.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNet.SignalR.Client/)<br>[Microsoft.AspNet.SignalR.JS](https://www.nuget.org/packages/Microsoft.AspNet.SignalR.JS/) | [Microsoft.AspNetCore.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client/) |
| **JavaScript client npm package** | [signalr](https://www.npmjs.com/package/signalr) | [`@microsoft/signalr`](https://www.npmjs.com/package/@microsoft/signalr) |
| **Java client** | [GitHub Repository](https://github.com/SignalR/java-client) (deprecated)  | Maven package [com.microsoft.signalr](https://search.maven.org/artifact/com.microsoft.signalr/signalr) |
| **Server app type** | ASP.NET (System.Web) or OWIN Self-Host | ASP.NET Core |
| **Supported server platforms** | .NET Framework 4.5 or later | .NET Core 3.0 or later |

:::moniker-end

:::moniker range="<= aspnetcore-2.2"

|                      | ASP.NET SignalR | ASP.NET Core SignalR |
| -------------------- | --------------- | -------------------- |
| **Server NuGet package** | [Microsoft.AspNet.SignalR](https://www.nuget.org/packages/Microsoft.AspNet.SignalR/) | [Microsoft.AspNetCore.App](https://www.nuget.org/packages/Microsoft.AspNetCore.App/) (.NET Core)<br>[Microsoft.AspNetCore.SignalR](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR/) (.NET Framework) |
| **Client NuGet packages** | [Microsoft.AspNet.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNet.SignalR.Client/)<br>[Microsoft.AspNet.SignalR.JS](https://www.nuget.org/packages/Microsoft.AspNet.SignalR.JS/) | [Microsoft.AspNetCore.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client/) |
| **JavaScript client npm package** | [signalr](https://www.npmjs.com/package/signalr) | [`@aspnet/signalr`](https://www.npmjs.com/package/@aspnet/signalr) |
| **Java client** | [GitHub Repository](https://github.com/SignalR/java-client) (deprecated)  | Maven package [com.microsoft.signalr](https://search.maven.org/artifact/com.microsoft.signalr/signalr) |
| **Server app type** | ASP.NET (System.Web) or OWIN Self-Host | ASP.NET Core |
| **Supported server platforms** | .NET Framework 4.5 or later | .NET Framework 4.6.1 or later<br>.NET Core 2.1 or later |

:::moniker-end

## Feature differences

### Automatic reconnects

:::moniker range=">= aspnetcore-3.0"

In ASP.NET SignalR:

* By default, SignalR attempts to reconnect to the server if the connection is dropped. 

In ASP.NET Core SignalR:

* Automatic reconnects are opt-in with both the [.NET client](xref:signalr/dotnet-client#automatically-reconnect) and the [JavaScript client](xref:signalr/javascript-client#automatically-reconnect):

```csharp
HubConnection connection = new HubConnectionBuilder()
    .WithUrl(new Uri("http://127.0.0.1:5000/chathub"))
    .WithAutomaticReconnect()
    .Build();
```

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .withAutomaticReconnect()
    .build();
```

:::moniker-end

:::moniker range="< aspnetcore-3.0"

Prior to ASP.NET Core 3.0, SignalR doesn't support automatic reconnects. If the client is disconnected, the user must explicitly start a new connection to reconnect. In ASP.NET SignalR, SignalR attempts to reconnect to the server if the connection is dropped.

:::moniker-end

### Protocol support

ASP.NET Core SignalR supports JSON, as well as a new binary protocol based on [MessagePack](xref:signalr/messagepackhubprotocol). Additionally, custom protocols can be created.

### Transports

The Forever Frame transport isn't supported in ASP.NET Core SignalR.

## Differences on the server

The ASP.NET Core SignalR server-side libraries are included in [Microsoft.AspNetCore.App](xref:fundamentals/metapackage-app), which is used in the **ASP.NET Core Web Application** template for both Razor and MVC projects.

ASP.NET Core SignalR is an ASP.NET Core middleware. It must be configured by calling <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A> in `Startup.ConfigureServices`.

```csharp
services.AddSignalR()
```

:::moniker range=">= aspnetcore-3.0"

To configure routing, map routes to hubs inside the <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> method call in the `Startup.Configure` method.

```csharp
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/hub");
});
```

:::moniker-end

:::moniker range="<= aspnetcore-2.2"

To configure routing, map routes to hubs inside the <xref:Microsoft.AspNetCore.Builder.SignalRAppBuilderExtensions.UseSignalR%2A> method call in the `Startup.Configure` method.

```csharp
app.UseSignalR(routes =>
{
    routes.MapHub<ChatHub>("/hub");
});
```

:::moniker-end

### Sticky sessions

The scaleout model for ASP.NET SignalR allows clients to reconnect and send messages to any server in the farm. In ASP.NET Core SignalR, the client must interact with the same server for the duration of the connection. For scaleout using Redis, that means sticky sessions are required. For scaleout using [Azure SignalR Service](/azure/azure-signalr/), sticky sessions aren't required because the service handles connections to clients.

### Single hub per connection

In ASP.NET Core SignalR, the connection model has been simplified. Connections are made directly to a single hub, rather than a single connection being used to share access to multiple hubs.

### Streaming

ASP.NET Core SignalR now supports [streaming data](xref:signalr/streaming) from the hub to the client.

### State

The ability to pass arbitrary state between clients and the hub (often called `HubState`) has been removed, as well as support for progress messages. There is no counterpart of hub proxies at the moment.

### PersistentConnection removal

In ASP.NET Core SignalR, the [PersistentConnection](/previous-versions/aspnet/jj919047(v=vs.118)) class has been removed.

### GlobalHost

ASP.NET Core has dependency injection (DI) built into the framework. Services can use DI to access the [HubContext](xref:signalr/hubcontext). The `GlobalHost` object that is used in ASP.NET SignalR to get a `HubContext` doesn't exist in ASP.NET Core SignalR.

### HubPipeline

ASP.NET Core SignalR doesn't have support for `HubPipeline` modules.

## Differences on the client

### TypeScript

The ASP.NET Core SignalR client is written in [TypeScript](https://www.typescriptlang.org/). You can write in JavaScript or TypeScript when using the [JavaScript client](xref:signalr/javascript-client).

### The JavaScript client is hosted at npm

:::moniker range=">= aspnetcore-3.0"

In ASP.NET versions, the JavaScript client was obtained through a NuGet package in Visual Studio. In the ASP.NET Core versions, the [`@microsoft/signalr`](https://www.npmjs.com/package/@microsoft/signalr) npm package contains the JavaScript libraries. This package isn't included in the **ASP.NET Core Web Application** template. Use npm to obtain and install the `@microsoft/signalr` npm package.

```console
npm init -y
npm install @microsoft/signalr
```

:::moniker-end

:::moniker range="<= aspnetcore-2.2"

In ASP.NET versions, the JavaScript client was obtained through a NuGet package in Visual Studio. In the ASP.NET Core versions, the [`@aspnet/signalr`](https://www.npmjs.com/package/@aspnet/signalr) npm package contains the JavaScript libraries. This package isn't included in the **ASP.NET Core Web Application** template. Use npm to obtain and install the `@aspnet/signalr` npm package.

```console
npm init -y
npm install @aspnet/signalr
```

:::moniker-end

### jQuery

The dependency on jQuery has been removed, however projects can still use jQuery.

### Internet Explorer support

ASP.NET Core SignalR doesn't support Microsoft Internet Explorer, whereas ASP.NET SignalR supports Microsoft Internet Explorer 8 or later.
For more information, see <xref:signalr/supported-platforms#javascript-client>.

### JavaScript client method syntax

:::moniker range=">= aspnetcore-3.0"

The JavaScript syntax has changed from the ASP.NET version of SignalR. Rather than using the `$connection` object, create a connection using the [HubConnectionBuilder](/javascript/api/@aspnet/signalr/hubconnectionbuilder) API.

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();
```

Use the [on](/javascript/api/@microsoft/signalr/HubConnection#@microsoft-signalr-hubconnection-on) method to specify client methods that the hub can call.

:::moniker-end

:::moniker range="<= aspnetcore-2.2"

The JavaScript syntax has changed from the ASP.NET version of SignalR. Rather than using the `$connection` object, create a connection using the [HubConnectionBuilder](/javascript/api/@microsoft/signalr/hubconnectionbuilder) API.

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();
```

Use the [on](/javascript/api/@aspnet/signalr/HubConnection#@microsoft-signalr-hubconnection-on) method to specify client methods that the hub can call.

:::moniker-end

```javascript
connection.on("ReceiveMessage", (user, message) => {
    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    const encodedMsg = `${user} says ${msg}`;
    console.log(encodedMsg);
});
```

After creating the client method, start the hub connection. Chain a [catch](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise/catch) method to log or handle errors.

```javascript
connection.start().catch(err => console.error(err));
```

### Hub proxies

:::moniker range=">= aspnetcore-3.0"

Hub proxies are no longer automatically generated. Instead, the method name is passed into the [invoke](/javascript/api/@microsoft/signalr/hubconnection#@microsoft-signalr-hubconnection-invoke) API as a string.

:::moniker-end

:::moniker range="<= aspnetcore-2.2"

Hub proxies are no longer automatically generated. Instead, the method name is passed into the [invoke](/javascript/api/@aspnet/signalr/hubconnection#@microsoft-signalr-hubconnection-invoke) API as a string.

:::moniker-end

### .NET and other clients

The [Microsoft.AspNetCore.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) NuGet package contains the .NET client libraries for ASP.NET Core SignalR.

Use the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder> to create and build an instance of a connection to a hub.

```csharp
connection = new HubConnectionBuilder()
    .WithUrl("url")
    .Build();
```

## Scaleout differences

ASP.NET SignalR supports SQL Server and Redis. ASP.NET Core SignalR supports Azure SignalR Service and Redis.

### ASP.NET

* [SignalR scaleout with Azure Service Bus](/aspnet/signalr/overview/performance/scaleout-with-windows-azure-service-bus)
* [SignalR scaleout with Redis](/aspnet/signalr/overview/performance/scaleout-with-redis)
* [SignalR scaleout with SQL Server](/aspnet/signalr/overview/performance/scaleout-with-sql-server)

### ASP.NET Core

* [Azure SignalR Service](/azure/azure-signalr/)
* [Redis Backplane](xref:signalr/redis-backplane)

## Additional resources

* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [.NET client](xref:signalr/dotnet-client)
* [Supported platforms](xref:signalr/supported-platforms)
