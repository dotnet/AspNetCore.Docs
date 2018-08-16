---
title: ASP.NET Core SignalR JavaScript client
author: tdykstra
description: Overview of ASP.NET Core SignalR JavaScript client.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 08/14/2018
uid: signalr/javascript-client
---
# ASP.NET Core SignalR JavaScript client

By [Rachel Appel](http://twitter.com/rachelappel)

The ASP.NET Core SignalR JavaScript client library enables developers to call server-side hub code.

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/javascript-client/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Install the SignalR client package

The SignalR JavaScript client library is delivered as an [npm](https://www.npmjs.com/) package. If you're using Visual Studio, run `npm install` from the **Package Manager Console** while in the root folder. For Visual Studio Code, run the command from the **Integrated Terminal**.

  ```console
  npm init -y
  npm install @aspnet/signalr
  ```

npm installs the package contents in the *node_modules\\@aspnet\signalr\dist\browser* folder. Create a new folder named *signalr* under the *wwwroot\\lib* folder. Copy the *signalr.js* file to the *wwwroot\lib\signalr* folder.

## Use the SignalR JavaScript client

Reference the SignalR JavaScript client in the `<script>` element.

```html
<script src="~/lib/signalr/signalr.js"></script>
```

## Connect to a hub

The following code creates and starts a connection. The hub's name is case insensitive.

[!code-javascript[Call hub methods](javascript-client/sample/wwwroot/js/chat.js?range=9-12,28)]

### Cross-origin connections

Typically, browsers load connections from the same domain as the requested page. However, there are occasions when a connection to another domain is required.

To prevent a malicious site from reading sensitive data from another site, [cross-origin connections](xref:security/cors) are disabled by default. To allow a cross-origin request, enable it in the `Startup` class.

[!code-csharp[Cross-origin connections](javascript-client/sample/Startup.cs?highlight=29-35,56)]

## Call hub methods from client

JavaScript clients call public methods on hubs via the [invoke](/javascript/api/%40aspnet/signalr/hubconnection#invoke) method of the [HubConnection](/javascript/api/%40aspnet/signalr/hubconnection). The `invoke` method accepts two arguments:

* The name of the hub method. In the following example, the method name on the hub is `SendMessage`.
* Any arguments defined in the hub method. In the following example, the argument name is `message`.

  [!code-javascript[Call hub methods](javascript-client/sample/wwwroot/js/chat.js?range=24)]

## Call client methods from hub

To receive messages from the hub, define a method using the [on](/javascript/api/%40aspnet/signalr/hubconnection#on) method of the `HubConnection`.

* The name of the JavaScript client method. In the following example, the method name is `ReceiveMessage`.
* Arguments the hub passes to the method. In the following example, the argument value is `message`.

[!code-javascript[Receive calls from hub](javascript-client/sample/wwwroot/js/chat.js?range=14-19)]

The preceding code in `connection.on` runs when server-side code calls it using the [SendAsync](/dotnet/api/microsoft.aspnetcore.signalr.clientproxyextensions.sendasync) method.

[!code-csharp[Call client-side](javascript-client/sample/hubs/chathub.cs?range=8-11)]

SignalR determines which client method to call by matching the method name and arguments defined in `SendAsync` and `connection.on`.

> [!NOTE]
> As a best practice, call the [start](/javascript/api/%40aspnet/signalr/hubconnection#start) method on the `HubConnection` after `on`. Doing so ensures your handlers are registered before any messages are received.

## Error handling and logging

Chain a `catch` method to the end of the `start` method to handle client-side errors. Use `console.error` to output errors to the browser's console.

[!code-javascript[Error handling](javascript-client/sample/wwwroot/js/chat.js?range=28)]

Setup client-side log tracing by passing a logger and type of event to log when the connection is made. Messages are logged with the specified log level and higher. Available log levels are as follows:

* `signalR.LogLevel.Error` &ndash; Error messages. Logs `Error` messages only.
* `signalR.LogLevel.Warning` &ndash; Warning messages about potential errors. Logs `Warning`, and `Error` messages.
* `signalR.LogLevel.Information` &ndash; Status messages without errors. Logs `Information`, `Warning`, and `Error` messages.
* `signalR.LogLevel.Trace` &ndash; Trace messages. Logs everything, including data transported between hub and client.

Use the [configureLogging](/javascript/api/%40aspnet/signalr/hubconnectionbuilder#configurelogging) method on [HubConnectionBuilder](/javascript/api/%40aspnet/signalr/hubconnectionbuilder) to configure the log level. Messages are logged to the browser console.

[!code-javascript[Logging levels](javascript-client/sample/wwwroot/js/chat.js?range=9-12)]

## Related resources

* [JavaScript API reference](/javascript/api/)
* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
* [Enable Cross-Origin Requests (CORS) in ASP.NET Core](xref:security/cors)
