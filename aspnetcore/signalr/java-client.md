---
title: ASP.NET Core SignalR Java client
author: mikaelm12
description: Learn how to use the ASP.NET Core SignalR Java client.
monikerRange: '>= aspnetcore-2.2'
ms.author: mimengis
ms.custom: mvc
ms.date: 10/18/2018
uid: signalr/java-client
---
# ASP.NET Core SignalR Java client

By [Mikael Mengistu](https://twitter.com/MikaelM_12)

The Java client enables connecting to an ASP.NET Core SignalR server from Java code, including Android apps. Like the [JavaScript client](xref:signalr/javascript-client) and the [.NET client](xref:signalr/dotnet-client), the Java client enables you to receive and send messages to a hub in real time. The Java client is available in ASP.NET Core 2.2 and later.

The sample Java console app referenced in this article uses the SignalR Java client.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/java-client/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Install the SignalR Java client package

The *signalr-1.0.0-preview3-35501* JAR file allows clients to connect to SignalR hubs. To find the latest JAR file version number, see the [Maven search results](https://search.maven.org/search?q=g:com.microsoft.signalr%20AND%20a:signalr).

If using Gradle, add the following line to the `dependencies` section of your *build.gradle* file:

```gradle
implementation 'com.microsoft.signalr:signalr:1.0.0-preview3-35501'
implementation 'io.reactivex.rxjava2:rxjava:2.2.2'
```

If using Maven, add the following lines inside the `<dependencies>` element of your *pom.xml* file:

[!code-xml[pom.xml dependency element](java-client/sample/pom.xml?name=snippet_dependencyElement)]

## Connect to a hub

To establish a `HubConnection`, the `HubConnectionBuilder` should be used. The hub URL and log level can be configured while building a connection. Configure any required options by calling any of the `HubConnectionBuilder` methods before `build`. Start the connection with `start`.

[!code-java[Build hub connection](java-client/sample/src/main/java/Chat.java?range=16-17)]

## Call hub methods from client

A call to `send` invokes a hub method. Pass the hub method name and any arguments defined in the hub method to `send`.

[!code-java[send method](java-client/sample/src/main/java/Chat.java?range=28)]

## Call client methods from hub

Use `hubConnection.on` to define methods on the client that the hub can call. Define the methods after building but before starting the connection.

[!code-java[Define client methods](java-client/sample/src/main/java/Chat.java?range=19-21)]

## Add logging

The SignalR Java client uses the [SLF4J](https://www.slf4j.org/) library for logging. It's a high-level logging API that allows users of the library to chose their own specific logging implementation by bringing in a specific logging dependency. The following code snippet shows how to use `java.util.logging` with the SignalR Java client.

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

## Known limitations

This is a preview release of the Java client. Some features aren't supported:

* Only the JSON protocol is supported.
* Only the WebSockets transport is supported.
* Streaming isn't supported yet.

## Additional resources

* [Java API reference](/java/api/com.microsoft.signalr?view=aspnet-signalr-java)
* <xref:signalr/hubs>
* <xref:signalr/javascript-client>
* <xref:signalr/publish-to-azure-web-app>
