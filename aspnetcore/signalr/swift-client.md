---
title: ASP.NET Core SignalR Swift client
author: zackliu
description: Overview of the ASP.NET Core SignalR Swift client library.
ms.author: chenyl
ms.custom: mvc, devx-track-swift
ms.date: 03/20/2025
uid: signalr/swift-client
---

# ASP.NET Core SignalR Swift client

SignalR Swift is a client library for connecting to SignalR servers from Swift applications. This document provides an overview of how to install the client, establish a connection, handle server-to-client calls, invoke server methods, work with streaming responses, and configure automatic reconnection and other options.

## Install the SignalR client package

The SignalR Swift client library is delivered as a Swift package. You can add it to your project using the [Swift Package Manager](https://swift.org/package-manager/).

### Requirements

* Swift **>= 5.10**
* macOS **>= 11.0**
* iOS >= 14

### Install with Swift Package Manager

Add the SignalR Swift package as a dependency in your `Package.swift` file:

```swift
// swift-tools-version: 5.10
import PackageDescription

let package = Package(
    name: "signalr-client-app",
    dependencies: [
        .package(url: "https://github.com/dotnet/signalr-client-swift", branch: "main")
    ],
    targets: [
        .executableTarget(name: "YourTargetName", dependencies: [.product(name: "SignalRClient", package: "signalr-client-swift")])
    ]
)
```

After adding the dependency, import the library in your Swift code:

```swift
import SignalRClient
```

## Connect to a hub

To establish a connection, create a `HubConnectionBuilder` and configure it with the URL of your SignalR server using the `withUrl()` method. Once the connection is built, call `start()` to connect to the server:

```swift
import SignalRClient

let connection = HubConnectionBuilder()
    .withUrl(url: "https://your-signalr-server")
    .build()

try await connection.start()
```

## Call client methods from the hub

To receive messages from the server, register a handler using the `on` method. The `on` method takes the name of the hub method and a closure that will be executed when the server calls that method.

In the following the method name is `ReceiveMessage`. The argument names are `user` and `message`:

```swift
await connection.on("ReceiveMessage") { (user: String, message: String) in
    print("\(user) says: \(message)")
}
```

The preceding code in `connection.on` runs when server-side code calls it using the <xref:Microsoft.AspNetCore.SignalR.ClientProxyExtensions.SendAsync%2A> method:

[!code-csharp[Call client-side](javascript-client/samples/6.x/SignalRChat/Hubs/ChatHub.cs)]

SignalR determines which client method to call by matching the method name and arguments defined in `SendAsync` and `connection.on`.

A **best practice** is to call the `try await connection.start()` method on the `HubConnection` after `on`. Doing so ensures the handlers are registered before any messages are received.


## Call hub methods from the client

Swift clients can invoke hub methods on the server using either the `invoke` or `send` methods of the HubConnection. The `invoke` method waits for the server's response and throws an error if the call fails, whereas the `send` method does not wait for a response.

In the following code, the method name on the hub is `SendMessage`. The second and third arguments passed to `invoke` map to the hub method's `user` and `message` arguments:

```swift
// Using invoke, which waits for a response
try await connection.invoke(method: "SendMessage", arguments: "myUser", "Hello")

// Using send, which does not wait for a response
try await connection.send(method: "SendMessage", arguments: "myUser", "Hello")
```

The `invoke` method returns with the return value (if any) when the method on the server returns. If the method on the server throws an error, the function throws an error.

## Logging

Swift client library includes a lightweight logging system designed for Swift applications. It provides a structured way to log messages at different levels of severity, using a customizable log handler. On Apple platforms, it leverages `os.Logger` for efficient system logging, while on other platforms, it falls back to standard console output.

### Log level

Use `HubConnectionBuilder().withLogLevel(LogLevel:)` to set the log level. Messages are logged with the specified log level and higher:

* `LogLevel.debug`: Detailed information useful for debugging.
* `LogLevel.information`: General application messages.
* `LogLevel.warning`: Warnings about potential issues.
* `LogLevel.error`: Errors that need immediate attention.

## Client results

In addition to invoking server methods, the server can call methods on the client and await a response. To support this, define a client handler that returns a result from its closure:

```swift
await connection.on("ClientResult") { (message: String) in
    return "client response"
}
```

For example, the server can invoke the `ClientResult` method on the client and wait for the returned value:

```csharp
public class ChatHub : Hub
{
    public async Task TriggerClientResult()
    {
        var message = await Clients.Client(connectionId).InvokeAsync<string>("ClientResult");
    }
}
```

## Working with streaming responses

To receive a stream of data from the server, use the `stream` method. The method returns a stream that you can iterate over asynchronously:

```swift
let streamResult: any StreamResult<String> = try await connection.stream(method: "StreamMethod")
for try await item in streamResult.stream {
    print("Received item: \(item)")
}
```

## Handle lost connection

### Automatic reconnect

The SignalR Swift client supports automatic reconnect. To enable it, call withAutomaticReconnect() while building the connection. Automatic reconnect is disabled by default.

```swift
let connection = HubConnectionBuilder()
    .withUrl(url: "https://your-signalr-server")
    .withAutomaticReconnect()
    .build()
```

Without parameters, withAutomaticReconnect() configures the client to wait 0, 2, 10, and 30 seconds respectively before each reconnect attempt. After four failed attempts, the client stops trying to reconnect.

Before starting any reconnect attempts, the `HubConnection` transitions to the `Reconnecting` state and fires its `onReconnecting` callbacks.

After the reconnection succeeds, the `HubConnection` transitions to the `connected` state and fires its `onReconnected` callbacks.

A general way to use `onReconnecting` and `onReconnected` is to mark the connection state changes:

```swift
connection.onReconnecting { error in
    // connection is disconnected because of error
}

connection.onReconnected {
    // connection is connected back
}
```

### Configure strategy in automatic reconnect

To customize the reconnect behavior, you can pass an array of numbers representing the delay in seconds before each reconnect attempt. For more granular control, pass an object that conforms to the RetryPolicy protocol.

#### Using an array of delay values

```swift
let connection = HubConnectionBuilder()
    .withUrl(url: "https://your-signalr-server")
    .withAutomaticReconnect([0, 0, 1]) // Wait 0, 0, and 1 second before each reconnect attempt; stop after 3 attempts.
    .build()
```

#### Using a custom retry policy

Implement the RetryPolicy protocol to control the reconnect timing:

```swift
// Define a custom retry policy
struct CustomRetryPolicy: RetryPolicy {
    func nextRetryInterval(retryContext: RetryContext) -> TimeInterval? {
        // For example, retry every 1 second indefinitely.
        return 1
    }
}

let connection = HubConnectionBuilder()
    .withUrl(url: "https://your-signalr-server")
    .withAutomaticReconnect(CustomRetryPolicy())
    .build()
```

## Configure timeout and keep-alive options

You can customize the client's timeout and keep-alive settings via the HubConnectionBuilder:

| Options | Default Value | Description |
|---------|---------------|-------------|
|withKeepAliveInterval| 15 (seconds)|Determines the interval at which the client sends ping messages and is set directly on HubConnectionBuilder. This setting allows the server to detect hard disconnects, such as when a client unplugs their computer from the network. Sending any message from the client resets the timer to the start of the interval. If the client hasn't sent a message in the ClientTimeoutInterval set on the server, the server considers the client disconnected.|
|withServerTimeout| 30 (seconds)|Determines the interval at which the client waits for a response from the server before it considers the server disconnected. This setting is set directly on HubConnectionBuilder.|

## Configure transport

The SignalR Swift client supports three transports: LongPolling, ServerSentEvents, and WebSockets. By default, the client will use WebSockets if the server supports it, and fall back to ServerSentEvents and LongPolling if it doesn't. You can configure the client to use a specific transport by calling `withUrl(url:transport:)` while building the connection.

```swift
let connection = HubConnectionBuilder()
    .withUrl(url: "https://your-signalr-server", transport: .webSockets) // use websocket only
    .build()
```

```swift
let connection = HubConnectionBuilder()
    .withUrl(url: "https://your-signalr-server", transport: [.webSockets, .serverSentEvents]) // use websockets and server sent events
    .build()
```

## Additional resources

* [WebPack and TypeScript tutorial](xref:tutorials/signalr-typescript-webpack)
* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [JavaScript client](xref:signalr/javascript-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
* [Cross-Origin Requests (CORS)](xref:security/cors)
* [Azure SignalR Service serverless documentation](/azure/azure-signalr/signalr-concept-serverless-development-config)
* [Troubleshoot connection errors](xref:signalr/troubleshoot)
