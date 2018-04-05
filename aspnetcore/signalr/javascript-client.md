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

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/javascript-client/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Install the SignalR client package

The SignalR JavaScript client library is delivered as an [npm](https://www.npmjs.com/) package. If you're using Visual Studio, run `npm install` from the command line in any folder. For Visual Studio Code, run the command from the **Integrated Terminal**.

  ```console
   npm install @aspnet/signalr
  ```

Npm installs the package contents in the *node_modules\\@aspnet\signalr\dist\browser* folder. Create a new folder named *signalr* under the *wwwroot\\lib* folder. Copy the *signalr.js* or its minified version to the *wwwroot\lib\signalr* folder.

## Use the SignalR JavaScript client

Reference the SignalR JavaScript client in the `<script>` element.

```html
<script src="~/wwwroot/lib/signalr/signalr.js"></script>
```

## Connect to a hub

The following code creates a connection. The hub's name is case insensitive.

```javascript
const connection = new signalR.HubConnection('/chathub');
```

While the preceding code sample creates a connection to a hub named `ChatHub`, it doesn't start it. To start the connection, call the `connection.start` method.

[!code-javascript[Call hub methods](javascript-client/sample/chat.js?range=9)]

### Cross-origin connections

Typically, browsers load connections from the same domain as the requested page. However, there are occasions when a connection to another domain is required.

To prevent a malicious site from reading sensitive data from another site, [cross-origin connections](xref:security/cors) are disabled by default. To allow a cross-origin request, enable it in the `Startup` class.

[!code-csharp[Cross-origin connections](javascript-client/sample/startup.cs?highlight=22-29,39-40)]

## Call hub methods from client

JavaScript clients call public methods on hubs by issuing `connection.invoke`. The `invoke` method accepts two arguments:

* The name of the hub method. In the following example, the hub name is `SendMessage`.
* Any arguments defined in the hub method. In the following example, the argument name is `message`.

[!code-javascript[Call hub methods](javascript-client/sample/chat.js?range=12)]

## Call client methods from hub

To receive messages from the hub, define a method in the client's `connection.on` method. The `connection.on` method requires the following information:

* The name of the JavaScript client method. In the following example, the method name is `ReceiveMessage`.
* Arguments the hub passes to the method. In the following example, the argument value is `message`.

[!code-javascript[Receive calls from hub](javascript-client/sample/chat.js?range=4-7)]

The preceding code in `connection.on` runs when  server-side code calls it using the `SendAsync` method.

[!code-javascript[Call client-side](javascript-client/sample/chathub.cs?range=8-11)]

SignalR determines which client method to call by matching the method name and arguments defined in `SendAsync` and `connection.on`.

> [!NOTE]
> As a best practice, call `connection.start` after `connection.on` so your handlers are registered before any messages are received.

## Error handling and logging

Chain a `catch` method to the end of the `connection.start` method to handle client-side errors. Use `console.error` to output errors to the browser's console.

[!code-javascript[Error handling](javascript-client/sample/chat.js?range=9)]

Setup client-side log tracing by passing a logger and type of event to log when the connection is made. Available log levels are as follows:

* `signalR.LogLevel.Information` : Status messages without errors.
* `signalR.LogLevel.Warning` : Warning messages about potential errors.
* `signalR.LogLevel.Error` : Error messages.

[!code-javascript[Logging levels](javascript-client/sample/chat.js?range=1-2)]

## Related resources

* [ASP.NET Core SignalR Hubs](xref:signalr/hubs)
* [Enable Cross-Origin Requests (CORS) in ASP.NET Core](xref:security/cors)