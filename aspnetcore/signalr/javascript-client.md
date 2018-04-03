---
title: ASP.NET Core SignalR JavaScript client
author: rachelappel
description: Create a JavaScript client for an ASP.NET Core SignalR hub.
manager: wpickett
ms.author: rachelap
ms.custom: mvc
ms.date: 04/06/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/javascript-client
---

# ASP.NET Core SignalR JavaScript client

By [Rachel Appel](http://twitter.com/rachelappel)

The ASP.NET Core SignalR JavaScript client library enables developers to call server-side hub code.

## Install the SignalR client package

The SignalR JavaScript client library is delivered as an [npm](https://www.npmjs.com/) package. If you're using Visual Studio, call `npm install` from the command line in any folder. For Visual Studio Code, call the command from the **Integrated Terminal**.

  ```console
   npm install @aspnet/signalr
  ```

Npm installs the package contents in the *node_modules\\@aspnet\signalr\dist\browser* folder. Copy the *signalr.js* or its minified version to a folder in your project.

## Use the SignalR JavaScript client

To use the SignalR JavaScript client, a script reference is required. Since the reference is an HTML `<script>` element, it can go in any kind of client-side page, such as a [Razor Page](xref:mvc/razor-pages/index?tabs=visual-studio), [MVC view](xref:mvc/views/overview), or HTML page.

```html
<script src="~/scripts/signalr.js"></script>
```

## Connect to a hub

To connect to a SignalR hub, create a new instance of a connection with the route as its argument. The route maps to a hub with the same name. However, the hub's name can be mixed case, such as `ChatHub`.

```javascript
const connection = new signalR.HubConnection('/chathub');
```

While the preceding code sample creates a connection to a hub named `ChatHub`, it doesn't start it. To start the connection, call the `connection.start` method.

```javascript
connection.start().catch(err => logError(err));
```

### Specify the connection's transport type

Transports define how servers and clients communicate. To set the transport type when you create the connection by setting the `signalR.TransportType` to *WebSockets*, *LongPolling*, or *ServerSentEvents*. The default, recommended transport is *WebSockets*.

[!code-javascript[Specify transport](javascript-client/sample/chat.js?range=1-3)]

### Cross-origin connections

Typically, browsers load connections from the same domain as the requested page. However, there are occasions when a connection to another domain is required.

For better security, [cross-origin connections](xref:security/cors) are disabled by default. If you need to create a cross-origin request, configure and enable it in the `Startup` class.

[!code-csharp[Cross-origin connections](javascript-client/sample/startup.cs?highlight=22-29,39-40)]

## Call hub methods from client

JavaScript clients can call public methods on hubs by issuing `connection.invoke`. The `invoke` method accepts two arguments:

* The name of the hub's method. In the following example, the hub name is `SendMessage`.
* Any arguments defined in the hub's method. In the following example, the argument name is `message`.

[!code-javascript[Call hub methods](javascript-client/sample/chat.js?range=13-16)]

## Call client methods from hub

To receive messages from the hub, define a method in the client's `connection.on` method. The `connection.on` method requires the following information:

* The name of the JavaScript client's method. In the following example, the method name is `ReceiveMessage`.
* Arguments the hub passes to the method. In the following example, the argument value is `message`.
* The method's code.

[!code-javascript[Receive calls from hub](javascript-client/sample/chat.js?range=6-9)]

The preceding code in `connection.on` runs when  server-side code calls it using the `SendAsync` method.

[!code-javascript[Call client-side](javascript-client/sample/chathub.cs?range=8-11)]

SignalR determines which client method to call by matching the method name and arguments defined in `SendAsync` and `connection.on`.

> [!NOTE]
> As a best practice, call `connection.start` after `connection.on` so the code is properly loaded.

## Error handling and logging

Chain a `catch` method to the end of the `connection.start` method to handle client-side errors. Use `console.log` to output custom messages or errors to the browser's console.

[!code-javascript[Error handling](javascript-client/sample/chat.js?range=11,18-20)]

Setup client-side log tracing by passing a logger and type of event to log when the connection is made. Available log levels are: `signalR.LogLevel.Information`, `signalR.LogLevel.Warning`, and `signalR.LogLevel.Error`.

[!code-javascript[Logging levels](javascript-client/sample/chat.js?range=2-4)]

## Related resources

* [ASP.NET Core SignalR Hubs](xref:signalr/hubs)
* [Enable Cross-Origin Requests (CORS) in ASP.NET Core](xref:security/cors)