---
title: ASP.NET Core SignalR Java Client
author: mimengis
description: Information about the ASP.NET Core SignalR .NET Client
monikerRange: '>= aspnetcore-2.1'
ms.author: mimengis
ms.custom: mvc
ms.date: 08/28/2018
uid: signalr/dotnet-client
---

# ASP.NET Core SignalR Java Client

By [Mikael Mengistu](http://twitter.com/MikaelM_12)

In ASP.NET Core 2.2 we are introducing a Java Client for SignalR. Like the [JavaScript client](xref:signalr/javascript-client),  and the  [.NET client](xref:signalr/javascript-client), the Java client enables you to receive and send and receive messages to a hub in real time.


[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/java-client/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The code sample in this article is a Java console app that uses the ASP.NET Core Java client.

## Install the SignalR .NET client package

The `signalr-0.1.0-preview1-35029` jar is needed for  clients to connect to SignalR hubs. If you’re using Gradle you can add the following line to your `build.gradle` file:

```gradle
implementation 'com.microsoft.aspnet:signalr:0.1.0-preview1-35029'
```

If you’re using Maven you can add the following lines to the dependencies section of your `pom.xml` file:

```xml
<dependency>
  <groupId>com.microsoft.aspnet</groupId>
  <artifactId>signalr</artifactId>
  <version>0.1.0-preview1-35029</version>
</dependency>
```


## Connect to a hub

To establish a connection, create a `HubConnectionBuilder` and call `build`. The hub URL, and log level can be configured while building a connection. Configure any required options by inserting any of the `HubConnectionBuilder` methods into `build`. Start the connection with `start`.

[!code-csharp[Build hub connection](java-client/sample/src/main/java/Chat.java?range=17-20)]

## Call hub methods from client

`send` calls sends invocations to the the hub. Pass the hub method name and any arguments defined in the hub method to `send`.

[!code-csharp[send method](java-client/sample/src/main/java/Chat.java?range=31)]

## Call client methods from hub

Define methods on the client that the hub can call using `hubConnection.On`. Be sure to define them after building, but before starting the connection.

[!code-csharp[Define client methods](java-client/sample/src/main/java/Chat.java?range=22-24)]

This is an early preview release of the Java client so there are many features that are not yet supported. We plan to close all these gaps before the RTM release:
- Only primitive types can be accepted as parameters and return types.
- The APIs are synchronous.
- Only the "Send" call type is supported at this time, "Invoke" and streaming return values are not supported.
- The client does not currently support the Azure SignalR Service.
- Only the JSON protocol is supported.
- Only the WebSockets transport is supported.

## Additional resources

* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)