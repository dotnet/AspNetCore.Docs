---
title: ASP.NET Core SignalR JavaScript client
author: bradygaster
description: Overview of ASP.NET Core SignalR JavaScript client.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 04/08/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/javascript-client
---
# ASP.NET Core SignalR JavaScript client

::: moniker range="< aspnetcore-3.0"

By [Rachel Appel](https://twitter.com/rachelappel)

The ASP.NET Core SignalR JavaScript client library enables developers to call server-side hub code.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/signalr/javascript-client/samples) ([how to download](xref:index#how-to-download-a-sample))

## Install the SignalR client package

The SignalR JavaScript client library is delivered as an [npm](https://www.npmjs.com/) package. The following sections outline different ways to install the client library.

### Install with npm

If using Visual Studio, run the following commands from **Package Manager Console** while in the root folder. For Visual Studio Code, run the following commands from the **Integrated Terminal**.

```bash
npm init -y
npm install @aspnet/signalr
```

npm installs the package contents in the *node_modules\\@aspnet\signalr\dist\browser* folder. Create a new folder named *signalr* under the *wwwroot\\lib* folder. Copy the *signalr.js* file to the *wwwroot\lib\signalr* folder.

Reference the SignalR JavaScript client in the `<script>` element. For example:

```html
<script src="~/lib/signalr/signalr.js"></script>
```

### Use a Content Delivery Network (CDN)

To use the client library without the npm prerequisite, reference a CDN-hosted copy of the client library. For example:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/3.1.3/signalr.min.js"></script>
```

The client library is available on the following CDNs:

* [cdnjs](https://cdnjs.com/libraries/aspnet-signalr)
* [jsDelivr](https://www.jsdelivr.com/package/npm/@aspnet/signalr)
* [unpkg](https://unpkg.com/@aspnet/signalr@next/dist/browser/signalr.min.js)

### Install with LibMan

[LibMan](xref:client-side/libman/index) can be used to install specific client library files from the CDN-hosted client library. For example, only add the minified JavaScript file to the project. For details on that approach, see [Add the SignalR client library](xref:tutorials/signalr#add-the-signalr-client-library).

## Connect to a hub

The following code creates and starts a connection. The hub's name is case insensitive.

[!code-javascript[Call hub methods](javascript-client/samples/2.x/SignalRChat/wwwroot/js/chat.js?range=9-13,28-51)]

### Cross-origin connections

Typically, browsers load connections from the same domain as the requested page. However, there are occasions when a connection to another domain is required.

To prevent a malicious site from reading sensitive data from another site, [cross-origin connections](xref:security/cors) are disabled by default. To allow a cross-origin request, enable it in the `Startup` class.

[!code-csharp[Cross-origin connections](javascript-client/samples/2.x/SignalRChat/Startup.cs?highlight=29-35,56)]

## Call hub methods from client

JavaScript clients call public methods on hubs via the [invoke](/javascript/api/%40aspnet/signalr/hubconnection#invoke) method of the [HubConnection](/javascript/api/%40aspnet/signalr/hubconnection). The `invoke` method accepts two arguments:

* The name of the hub method. In the following example, the method name on the hub is `SendMessage`.
* Any arguments defined in the hub method. In the following example, the argument name is `message`. The example code uses arrow function syntax that is supported in current versions of all major browsers except Internet Explorer.

  [!code-javascript[Call hub methods](javascript-client/samples/2.x/SignalRChat/wwwroot/js/chat.js?range=24)]

> [!NOTE]
> Calling hub methods from a client is only supported when using the Azure SignalR Service in *Default* mode. For more information, see [Frequently Asked Questions (azure-signalr GitHub repository)](https://github.com/Azure/azure-signalr/blob/dev/docs/faq.md#what-is-the-meaning-of-service-mode-defaultserverlessclassic-how-can-i-choose).

The `invoke` method returns a JavaScript [Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise). The `Promise` is resolved with the return value (if any) when the method on the server returns. If the method on the server throws an error, the `Promise` is rejected with the error message. Use the `then` and `catch` methods on the `Promise` itself to handle these cases (or `await` syntax).

The `send` method returns a JavaScript `Promise`. The `Promise` is resolved when the message has been sent to the server. If there is an error sending the message, the `Promise` is rejected with the error message. Use the `then` and `catch` methods on the `Promise` itself to handle these cases (or `await` syntax).

> [!NOTE]
> Using `send` doesn't wait until the server has received the message. Consequently, it's not possible to return data or errors from the server.

## Call client methods from hub

To receive messages from the hub, define a method using the [on](/javascript/api/%40aspnet/signalr/hubconnection#on) method of the `HubConnection`.

* The name of the JavaScript client method. In the following example, the method name is `ReceiveMessage`.
* Arguments the hub passes to the method. In the following example, the argument value is `message`.

[!code-javascript[Receive calls from hub](javascript-client/samples/2.x/SignalRChat/wwwroot/js/chat.js?range=14-19)]

The preceding code in `connection.on` runs when server-side code calls it using the [SendAsync](/dotnet/api/microsoft.aspnetcore.signalr.clientproxyextensions.sendasync) method.

[!code-csharp[Call client-side](javascript-client/samples/2.x/SignalRChat/hubs/chathub.cs?range=8-11)]

SignalR determines which client method to call by matching the method name and arguments defined in `SendAsync` and `connection.on`.

> [!NOTE]
> As a best practice, call the [start](/javascript/api/%40aspnet/signalr/hubconnection#start) method on the `HubConnection` after `on`. Doing so ensures your handlers are registered before any messages are received.

## Error handling and logging

Chain a `catch` method to the end of the `start` method to handle client-side errors. Use `console.error` to output errors to the browser's console.

[!code-javascript[Error handling](javascript-client/samples/2.x/SignalRChat/wwwroot/js/chat.js?range=50)]

Set up client-side log tracing by passing a logger and type of event to log when the connection is made. Messages are logged with the specified log level and higher. Available log levels are as follows:

* `signalR.LogLevel.Error`: Error messages. Logs `Error` messages only.
* `signalR.LogLevel.Warning`: Warning messages about potential errors. Logs `Warning`, and `Error` messages.
* `signalR.LogLevel.Information`: Status messages without errors. Logs `Information`, `Warning`, and `Error` messages.
* `signalR.LogLevel.Trace`: Trace messages. Logs everything, including data transported between hub and client.

Use the [configureLogging](/javascript/api/%40aspnet/signalr/hubconnectionbuilder#configurelogging) method on [HubConnectionBuilder](/javascript/api/%40aspnet/signalr/hubconnectionbuilder) to configure the log level. Messages are logged to the browser console.

[!code-javascript[Logging levels](javascript-client/samples/2.x/SignalRChat/wwwroot/js/chat.js?range=9-12)]

## Reconnect clients

### Manually reconnect

> [!WARNING]
> Prior to 3.0, the JavaScript client for SignalR doesn't automatically reconnect. You must write code that will reconnect your client manually.

The following code demonstrates a typical manual reconnection approach:

1. A function (in this case, the `start` function) is created to start the connection.
1. Call the `start` function in the connection's `onclose` event handler.

[!code-javascript[Reconnect the JavaScript client](javascript-client/samples/2.x/SignalRChat/wwwroot/js/chat.js?range=28-40)]

A real-world implementation would use an exponential back-off or retry a specified number of times before giving up.

## Additional resources

* [JavaScript API reference](/javascript/api/?view=signalr-js-latest)
* [JavaScript tutorial](xref:tutorials/signalr)
* [WebPack and TypeScript tutorial](xref:tutorials/signalr-typescript-webpack)
* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
* [Cross-Origin Requests (CORS)](xref:security/cors)
* [Azure SignalR Service serverless documentation](/azure/azure-signalr/signalr-concept-serverless-development-config)

::: moniker-end
