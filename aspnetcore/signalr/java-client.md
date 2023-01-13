---
title: ASP.NET Core SignalR Java client
author: mikaelm12
description: Learn how to use the ASP.NET Core SignalR Java client.
monikerRange: '>= aspnetcore-2.2'
ms.author: bradyg
ms.custom: mvc
ms.date: 11/12/2019
uid: signalr/java-client
---
# ASP.NET Core SignalR Java client

By [Mikael Mengistu](https://twitter.com/MikaelM_12)

The Java client enables connecting to an ASP.NET Core SignalR server from Java code, including Android apps. Like the [JavaScript client](xref:signalr/javascript-client) and the [.NET client](xref:signalr/dotnet-client), the Java client enables you to receive and send messages to a hub in real time. The Java client is available in ASP.NET Core 2.2 and later.

The sample Java console app referenced in this article uses the SignalR Java client.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/java-client/sample) ([how to download](xref:index#how-to-download-a-sample))

## Install the SignalR Java client package

The *signalr-7.0.0* JAR file allows clients to connect to SignalR hubs. To find the latest JAR file version number, see the [Maven search results](https://search.maven.org/search?q=g:com.microsoft.signalr%20AND%20a:signalr).

If using Gradle, add the following line to the `dependencies` section of your *build.gradle* file:

```gradle
implementation 'com.microsoft.signalr:signalr:7.0.0'
```

If using Maven, add the following lines inside the `<dependencies>` element of your `pom.xml` file:

[!code-xml[pom.xml dependency element](java-client/sample/pom.xml?name=snippet_dependencyElement)]

## Connect to a hub

To establish a `HubConnection`, the `HubConnectionBuilder` should be used. The hub URL and log level can be configured while building a connection. Configure any required options by calling any of the `HubConnectionBuilder` methods before `build`. Start the connection with `start`.

[!code-java[Build hub connection](java-client/sample/src/main/java/Chat.java?range=16-17)]

## Call hub methods from client

A call to `send` invokes a hub method. Pass the hub method name and any arguments defined in the hub method to `send`.

[!code-java[send method](java-client/sample/src/main/java/Chat.java?range=28)]

> [!NOTE]
> Calling hub methods from a client is only supported when using the Azure SignalR Service in *Default* mode. For more information, see [Frequently Asked Questions (azure-signalr GitHub repository)](https://github.com/Azure/azure-signalr/blob/dev/docs/faq.md#what-is-the-meaning-of-service-mode-defaultserverlessclassic-how-can-i-choose).

## Call client methods from hub

Use `hubConnection.on` to define methods on the client that the hub can call. Define the methods after building but before starting the connection.

[!code-java[Define client methods](java-client/sample/src/main/java/Chat.java?range=19-21)]

## Add logging

The SignalR Java client uses the [SLF4J](https://www.slf4j.org/) library for logging. It's a high-level logging API that allows users of the library to choose their own specific logging implementation by bringing in a specific logging dependency. The following code snippet shows how to use `java.util.logging` with the SignalR Java client.

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

## Android development notes

With regards to Android SDK compatibility for the SignalR client features, consider the following items when specifying your target Android SDK version:

* The SignalR Java Client will run on Android API Level 16 and later.
* Connecting through the Azure SignalR Service will require Android API Level 20 and later because the [Azure SignalR Service](/azure/azure-signalr/signalr-overview) requires TLS 1.2 and doesn't support SHA-1-based cipher suites. Android [added support for SHA-256 (and above) cipher suites](https://developer.android.com/reference/javax/net/ssl/SSLSocket) in API Level 20.

## Configure bearer token authentication

In the SignalR Java client, you can configure a bearer token to use for authentication by providing an "access token factory" to the [HttpHubConnectionBuilder](/java/api/com.microsoft.signalr.httphubconnectionbuilder?view=aspnet-signalr-java&preserve-view=true). Use [withAccessTokenFactory](/java/api/com.microsoft.signalr.httphubconnectionbuilder.withaccesstokenprovider?view=aspnet-signalr-java&preserve-view=true) to provide an [RxJava](https://github.com/ReactiveX/RxJava) [Single\<String>](https://reactivex.io/documentation/single.html). With a call to [Single.defer](https://reactivex.io/RxJava/javadoc/io/reactivex/Single.html#defer-java.util.concurrent.Callable-), you can write logic to produce access tokens for your client.

```java
HubConnection hubConnection = HubConnectionBuilder.create("YOUR HUB URL HERE")
    .withAccessTokenProvider(Single.defer(() -> {
        // Your logic here.
        return Single.just("An Access Token");
    })).build();
```

:::moniker range=">= aspnetcore-5.0"

### Passing Class information in Java

When calling the `on`, `invoke`, or `stream` methods of `HubConnection` in the Java client, users should pass a `Type` object rather than a `Class<?>` object to describe any generic `Object` passed to the method. A `Type` can be acquired using the provided `TypeReference` class. For example, using a custom generic class named `Foo<T>`, the following code gets the `Type`:

```java
Type fooType = new TypeReference<Foo<String>>() { }).getType();
```

For non-generics, such as primitives or other non-parameterized types like `String`, you can simply use the built-in `.class`.

When calling one of these methods with one or more object types, use the generics syntax when invoking the method. For example, when registering an `on` handler for a method named `func`, which takes as arguments a String and a `Foo<String>` object, use the following code to set an action to print the arguments:

```java
hubConnection.<String, Foo<String>>on("func", (param1, param2) ->{
    System.out.println(param1);
    System.out.println(param2);
}, String.class, fooType);
```

This convention is necessary because we can not retrieve complete information about complex types with the `Object.getClass` method due to type erasure in Java. For example, calling `getClass` on an `ArrayList<String>` would not return `Class<ArrayList<String>>`, but rather `Class<ArrayList>`, which does not give the deserializer enough information to correctly deserialize an incoming message. The same is true for custom objects.

:::moniker-end

## Known limitations

:::moniker range=">= aspnetcore-5.0"

* Transport fallback and the Server Sent Events transport aren't supported.

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-5.0"

* Transport fallback and the Server Sent Events transport aren't supported.
* Only the JSON protocol is supported.

:::moniker-end

:::moniker range="< aspnetcore-3.0"

* Only the JSON protocol is supported.
* Only the WebSockets transport is supported.
* Streaming isn't supported yet.

:::moniker-end

## Additional resources

* [Java API reference](/java/api/com.microsoft.signalr?view=aspnet-signalr-java&preserve-view=true)
* <xref:signalr/hubs>
* <xref:signalr/javascript-client>
* <xref:signalr/publish-to-azure-web-app>
* [Azure SignalR Service serverless documentation](/azure/azure-signalr/signalr-concept-serverless-development-config)
