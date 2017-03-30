---
uid: signalr/overview/guide-to-the-api/hubs-api-guide-server
title: "ASP.NET SignalR Hubs API Guide - Server (C#) | Microsoft Docs"
author: pfletcher
description: "This document provides an introduction to programming the server side of the ASP.NET SignalR Hubs API for SignalR version 2, with code samples demonstrating..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/10/2014
ms.topic: article
ms.assetid: b19913e5-cd8a-4e4b-a872-5ac7a858a934
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/guide-to-the-api/hubs-api-guide-server
msc.type: authoredcontent
---
ASP.NET SignalR Hubs API Guide - Server (C#)
====================
by [Patrick Fletcher](https://github.com/pfletcher), [Tom Dykstra](https://github.com/tdykstra)

> This document provides an introduction to programming the server side of the ASP.NET SignalR Hubs API for SignalR version 2, with code samples demonstrating common options.
> 
> The SignalR Hubs API enables you to make remote procedure calls (RPCs) from a server to connected clients and from clients to the server. In server code, you define methods that can be called by clients, and you call methods that run on the client. In client code, you define methods that can be called from the server, and you call methods that run on the server. SignalR takes care of all of the client-to-server plumbing for you.
> 
> SignalR also offers a lower-level API called Persistent Connections. For an introduction to SignalR, Hubs, and Persistent Connections, see [Introduction to SignalR 2](../getting-started/introduction-to-signalr.md).
> 
> ## Software versions used in this topic
> 
> 
> - [Visual Studio 2013](https://www.microsoft.com/visualstudio/eng/2013-downloads)
> - .NET 4.5
> - SignalR version 2
>   
> 
> 
> ## Topic versions
> 
> For information about earlier versions of SignalR, see [SignalR Older Versions](../older-versions/index.md).
> 
> ## Questions and comments
> 
> Please leave feedback on how you liked this tutorial and what we could improve in the comments at the bottom of the page. If you have questions that are not directly related to the tutorial, you can post them to the [ASP.NET SignalR forum](https://forums.asp.net/1254.aspx/1?ASP+NET+SignalR) or [StackOverflow.com](http://stackoverflow.com/).


## Overview

This document contains the following sections:

- [How to register SignalR middleware](#route)

    - [The /signalr URL](#signalrurl)
    - [Configuring SignalR options](#options)
- [How to create and use Hub classes](#hubclass)

    - [Hub object lifetime](#transience)
    - [Camel-casing of Hub names in JavaScript clients](#hubnames)
    - [Multiple Hubs](#multiplehubs)
    - [Strongly-Typed Hubs](#stronglytypedhubs)
- [How to define methods in the Hub class that clients can call](#hubmethods)

    - [Camel-casing of method names in JavaScript clients](#methodnames)
    - [When to execute asynchronously](#asyncmethods)
    - [Defining overloads](#overloads)
    - [Reporting progress from hub method invocations](#progress)
- [How to call client methods from the Hub class](#callfromhub)

    - [Selecting which clients will receive the RPC](#selectingclients)
    - [No compile-time validation for method names](#dynamicmethodnames)
    - [Case-insensitive method name matching](#caseinsensitive)
    - [Asynchronous execution](#asyncclient)
- [How to manage group membership from the Hub class](#groupsfromhub)

    - [Asynchronous execution of Add and Remove methods](#asyncgroupmethods)
    - [Group membership persistence](#grouppersistence)
    - [Single-user groups](#singleusergroups)
- [How to handle connection lifetime events in the Hub class](#connectionlifetime)

    - [When OnConnected, OnDisconnected, and OnReconnected are called](#onreconnected)
    - [Caller state not populated](#nocallerstate)
- [How to get information about the client from the Context property](#contextproperty)
- [How to pass state between clients and the Hub class](#passstate)
- [How to handle errors in the Hub class](#handleErrors)
- [How to call client methods and manage groups from outside the Hub class](#callfromoutsidehub)

    - [Calling client methods](#callingclientsoutsidehub)
    - [Managing group membership](#managinggroupsoutsidehub)
- [How to enable tracing](#tracing)
- [How to customize the Hubs pipeline](#hubpipeline)

For documentation on how to program clients, see the following resources:

- [SignalR Hubs API Guide - JavaScript Client](hubs-api-guide-javascript-client.md)
- [SignalR Hubs API Guide - .NET Client](hubs-api-guide-net-client.md)

The server components for SignalR 2 are only available in .NET 4.5. Servers running .NET 4.0 must use SignalR v1.x.

<a id="route"></a>

## How to register SignalR middleware

To define the route that clients will use to connect to your Hub, call the `MapSignalR` method when the application starts. `MapSignalR` is an [extension method](https://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx) for the `OwinExtensions` class. The following example shows how to define the SignalR Hubs route using an OWIN startup class.

[!code-csharp[Main](hubs-api-guide-server/samples/sample1.cs)]

If you are adding SignalR functionality to an ASP.NET MVC application, make sure that the SignalR route is added before the other routes. For more information, see [Tutorial: Getting Started with SignalR 2 and MVC 5](../getting-started/tutorial-getting-started-with-signalr-and-mvc.md).

<a id="signalrurl"></a>

### The /signalr URL

By default, the route URL which clients will use to connect to your Hub is "/signalr". (Don't confuse this URL with the "/signalr/hubs" URL, which is for the automatically generated JavaScript file. For more information about the generated proxy, see [SignalR Hubs API Guide - JavaScript Client - The generated proxy and what it does for you](hubs-api-guide-javascript-client.md#genproxy).)

There might be extraordinary circumstances that make this base URL not usable for SignalR; for example, you have a folder in your project named *signalr* and you don't want to change the name. In that case, you can change the base URL, as shown in the following examples (replace "/signalr" in the sample code with your desired URL).

**Server code that specifies the URL**

[!code-csharp[Main](hubs-api-guide-server/samples/sample2.cs?highlight=1)]

**JavaScript client code that specifies the URL (with the generated proxy)**

[!code-javascript[Main](hubs-api-guide-server/samples/sample3.js?highlight=1)]

**JavaScript client code that specifies the URL (without the generated proxy)**

[!code-javascript[Main](hubs-api-guide-server/samples/sample4.js?highlight=1)]

**.NET client code that specifies the URL**

[!code-csharp[Main](hubs-api-guide-server/samples/sample5.cs?highlight=1)]

<a id="options"></a>

### Configuring SignalR Options

Overloads of the `MapSignalR` method enable you to specify a custom URL, a custom dependency resolver, and the following options:

- Enable cross-domain calls using CORS or JSONP from browser clients.

    Typically if the browser loads a page from `http://contoso.com`, the SignalR connection is in the same domain, at `http://contoso.com/signalr`. If the page from `http://contoso.com` makes a connection to `http://fabrikam.com/signalr`, that is a cross-domain connection. For security reasons, cross-domain connections are disabled by default. For more information, see [ASP.NET SignalR Hubs API Guide - JavaScript Client - How to establish a cross-domain connection](hubs-api-guide-javascript-client.md#crossdomain).
- Enable detailed error messages.

    When errors occur, the default behavior of SignalR is to send to clients a notification message without details about what happened. Sending detailed error information to clients is not recommended in production, because malicious users might be able to use the information in attacks against your application. For troubleshooting, you can use this option to temporarily enable more informative error reporting.
- Disable automatically generated JavaScript proxy files.

    By default, a JavaScript file with proxies for your Hub classes is generated in response to the URL "/signalr/hubs". If you don't want to use the JavaScript proxies, or if you want to generate this file manually and refer to a physical file in your clients, you can use this option to disable proxy generation. For more information, see [SignalR Hubs API Guide - JavaScript Client - How to create a physical file for the SignalR generated proxy](hubs-api-guide-javascript-client.md#manualproxy).

The following example shows how to specify the SignalR connection URL and these options in a call to the `MapSignalR` method. To specify a custom URL, replace "/signalr" in the example with the URL that you want to use.

[!code-csharp[Main](hubs-api-guide-server/samples/sample6.cs)]

<a id="hubclass"></a>

## How to create and use Hub classes

To create a Hub, create a class that derives from [Microsoft.Aspnet.Signalr.Hub](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.hub(v=vs.111).aspx). The following example shows a simple Hub class for a chat application.

[!code-csharp[Main](hubs-api-guide-server/samples/sample7.cs)]

In this example, a connected client can call the `NewContosoChatMessage` method, and when it does, the data received is broadcasted to all connected clients.

<a id="transience"></a>

### Hub object lifetime

You don't instantiate the Hub class or call its methods from your own code on the server; all that is done for you by the SignalR Hubs pipeline. SignalR creates a new instance of your Hub class each time it needs to handle a Hub operation such as when a client connects, disconnects, or makes a method call to the server.

Because instances of the Hub class are transient, you can't use them to maintain state from one method call to the next. Each time the server receives a method call from a client, a new instance of your Hub class processes the message. To maintain state through multiple connections and method calls, use some other method such as a database, or a static variable on the Hub class, or a different class that does not derive from `Hub`. If you persist data in memory, using a method such as a static variable on the Hub class, the data will be lost when the app domain recycles.

If you want to send messages to clients from your own code that runs outside the Hub class, you can't do it by instantiating a Hub class instance, but you can do it by getting a reference to the SignalR context object for your Hub class. For more information, see [How to call client methods and manage groups from outside the Hub class](#callfromoutsidehub) later in this topic.

<a id="hubnames"></a>

### Camel-casing of Hub names in JavaScript clients

By default, JavaScript clients refer to Hubs by using a camel-cased version of the class name. SignalR automatically makes this change so that JavaScript code can conform to JavaScript conventions. The previous example would be referred to as `contosoChatHub` in JavaScript code.

**Server**

[!code-csharp[Main](hubs-api-guide-server/samples/sample8.cs?highlight=1)]

**JavaScript client using generated proxy**

[!code-javascript[Main](hubs-api-guide-server/samples/sample9.js?highlight=1)]

If you want to specify a different name for clients to use, add the `HubName` attribute. When you use a `HubName` attribute, there is no name change to camel case on JavaScript clients.

**Server**

[!code-csharp[Main](hubs-api-guide-server/samples/sample10.cs?highlight=1)]

**JavaScript client using generated proxy**

[!code-javascript[Main](hubs-api-guide-server/samples/sample11.js?highlight=1)]

<a id="multiplehubs"></a>

### Multiple Hubs

You can define multiple Hub classes in an application. When you do that, the connection is shared but groups are separate:

- All clients will use the same URL to establish a SignalR connection with your service ("/signalr" or your custom URL if you specified one), and that connection is used for all Hubs defined by the service.

    There is no performance difference for multiple Hubs compared to defining all Hub functionality in a single class.
- All Hubs get the same HTTP request information.

    Since all Hubs share the same connection, the only HTTP request information that the server gets is what comes in the original HTTP request that establishes the SignalR connection. If you use the connection request to pass information from the client to the server by specifying a query string, you can't provide different query strings to different Hubs. All Hubs will receive the same information.
- The generated JavaScript proxies file will contain proxies for all Hubs in one file.

    For information about JavaScript proxies, see [SignalR Hubs API Guide - JavaScript Client - The generated proxy and what it does for you](hubs-api-guide-javascript-client.md#genproxy).
- Groups are defined within Hubs.

    In SignalR you can define named groups to broadcast to subsets of connected clients. Groups are maintained separately for each Hub. For example, a group named "Administrators" would include one set of clients for your `ContosoChatHub` class, and the same group name would refer to a different set of clients for your `StockTickerHub` class.

<a id="stronglytypedhubs"></a>
### Strongly-Typed Hubs

To define an interface for your hub methods that your client can reference (and enable Intellisense on your hub methods), derive your hub from `Hub<T>` (introduced in SignalR 2.1) rather than `Hub`:

[!code-csharp[Main](hubs-api-guide-server/samples/sample12.cs)]

<a id="hubmethods"></a>

## How to define methods in the Hub class that clients can call

To expose a method on the Hub that you want to be callable from the client, declare a public method, as shown in the following examples.

[!code-csharp[Main](hubs-api-guide-server/samples/sample13.cs?highlight=3)]

[!code-csharp[Main](hubs-api-guide-server/samples/sample14.cs?highlight=3)]

You can specify a return type and parameters, including complex types and arrays, as you would in any C# method. Any data that you receive in parameters or return to the caller is communicated between the client and the server by using JSON, and SignalR handles the binding of complex objects and arrays of objects automatically.

<a id="methodnames"></a>

### Camel-casing of method names in JavaScript clients

By default, JavaScript clients refer to Hub methods by using a camel-cased version of the method name. SignalR automatically makes this change so that JavaScript code can conform to JavaScript conventions.

**Server**

[!code-csharp[Main](hubs-api-guide-server/samples/sample15.cs?highlight=1)]

**JavaScript client using generated proxy**

[!code-javascript[Main](hubs-api-guide-server/samples/sample16.js?highlight=1)]

If you want to specify a different name for clients to use, add the `HubMethodName` attribute.

**Server**

[!code-csharp[Main](hubs-api-guide-server/samples/sample17.cs?highlight=1)]

**JavaScript client using generated proxy**

[!code-javascript[Main](hubs-api-guide-server/samples/sample18.js?highlight=1)]

<a id="asyncmethods"></a>

### When to execute asynchronously

If the method will be long-running or has to do work that would involve waiting, such as a database lookup or a web service call, make the Hub method asynchronous by returning a [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx) (in place of `void` return) or [Task&lt;T&gt;](https://msdn.microsoft.com/en-us/library/dd321424.aspx) object (in place of `T` return type). When you return a `Task` object from the method, SignalR waits for the `Task` to complete, and then it sends the unwrapped result back to the client, so there is no difference in how you code the method call in the client.

Making a Hub method asynchronous avoids blocking the connection when it uses the WebSocket transport. When a Hub method executes synchronously and the transport is WebSocket, subsequent invocations of methods on the Hub from the same client are blocked until the Hub method completes.

The following example shows the same method coded to run synchronously or asynchronously, followed by JavaScript client code that works for calling either version.

**Synchronous**

[!code-csharp[Main](hubs-api-guide-server/samples/sample19.cs)]

**Asynchronous**

[!code-csharp[Main](hubs-api-guide-server/samples/sample20.cs?highlight=1,7-8)]

**JavaScript client using generated proxy**

[!code-javascript[Main](hubs-api-guide-server/samples/sample21.js)]

For more information about how to use asynchronous methods in ASP.NET 4.5, see [Using Asynchronous Methods in ASP.NET MVC 4](../../../mvc/overview/performance/using-asynchronous-methods-in-aspnet-mvc-4.md).

<a id="overloads"></a>

### Defining Overloads

If you want to define overloads for a method, the number of parameters in each overload must be different. If you differentiate an overload just by specifying different parameter types, your Hub class will compile but the SignalR service will throw an exception at run time when clients try to call one of the overloads.

<a id="progress"></a>
### Reporting progress from hub method invocations

SignalR 2.1 adds support for the [progress reporting pattern](https://blogs.msdn.com/b/dotnet/archive/2012/06/06/async-in-4-5-enabling-progress-and-cancellation-in-async-apis.aspx) introduced in .NET 4.5. To implement progress reporting, define an `IProgress<T>` parameter for your hub method that your client can access:

[!code-csharp[Main](hubs-api-guide-server/samples/sample22.cs)]

When writing a long-running server method, it is important to use an asynchronous programming pattern like Async/ Await rather than blocking the hub thread.

<a id="callfromhub"></a>

## How to call client methods from the Hub class

To call client methods from the server, use the `Clients` property in a method in your Hub class. The following example shows server code that calls `addNewMessageToPage` on all connected clients, and client code that defines the method in a JavaScript client.

**Server**

[!code-csharp[Main](hubs-api-guide-server/samples/sample23.cs?highlight=5)]

**JavaScript client using generated proxy**

[!code-html[Main](hubs-api-guide-server/samples/sample24.html?highlight=1)]

You can't get a return value from a client method; syntax such as `int x = Clients.All.add(1,1)` does not work.

You can specify complex types and arrays for the parameters. The following example passes a complex type to the client in a method parameter.

**Server code that calls a client method using a complex object**

[!code-csharp[Main](hubs-api-guide-server/samples/sample25.cs?highlight=3)]

**Server code that defines the complex object**

[!code-csharp[Main](hubs-api-guide-server/samples/sample26.cs?highlight=1)]

**JavaScript client using generated proxy**

[!code-javascript[Main](hubs-api-guide-server/samples/sample27.js?highlight=2-3)]

<a id="selectingclients"></a>

### Selecting which clients will receive the RPC

The Clients property returns a [HubConnectionContext](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.hubs.hubconnectioncontext(v=vs.111).aspx) object that provides several options for specifying which clients will receive the RPC:

- All connected clients.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample28.cs)]
- Only the calling client.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample29.cs)]
- All clients except the calling client.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample30.cs)]
- A specific client identified by connection ID.

    [!code-css[Main](hubs-api-guide-server/samples/sample31.css)]

    This example calls `addContosoChatMessageToPage` on the calling client and has the same effect as using `Clients.Caller`.
- All connected clients except the specified clients, identified by connection ID.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample32.cs)]
- All connected clients in a specified group.

    [!code-css[Main](hubs-api-guide-server/samples/sample33.css)]
- All connected clients in a specified group except the specified clients, identified by connection ID.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample34.cs)]
- All connected clients in a specified group except the calling client.

    [!code-css[Main](hubs-api-guide-server/samples/sample35.css)]
- A specific user, identified by userId.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample36.cs)]

    By default, this is `IPrincipal.Identity.Name`, but this can be changed by [registering an implementation of IUserIdProvider with the global host](mapping-users-to-connections.md#IUserIdProvider).
- All clients and groups in a list of connection IDs.

    [!code-css[Main](hubs-api-guide-server/samples/sample37.css)]
- A list of groups.

    [!code-css[Main](hubs-api-guide-server/samples/sample38.css)]
- A user by name.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample39.cs)]
- A list of user names (introduced in SignalR 2.1).

    [!code-csharp[Main](hubs-api-guide-server/samples/sample40.cs)]

<a id="dynamicmethodnames"></a>

### No compile-time validation for method names

The method name that you specify is interpreted as a dynamic object, which means there is no IntelliSense or compile-time validation for it. The expression is evaluated at run time. When the method call executes, SignalR sends the method name and the parameter values to the client, and if the client has a method that matches the name, that method is called and the parameter values are passed to it. If no matching method is found on the client, no error is raised. For information about the format of the data that SignalR transmits to the client behind the scenes when you call a client method, see [Introduction to SignalR](../getting-started/introduction-to-signalr.md).

<a id="caseinsensitive"></a>

### Case-insensitive method name matching

Method name matching is case-insensitive. For example, `Clients.All.addContosoChatMessageToPage` on the server will execute `AddContosoChatMessageToPage`, `addcontosochatmessagetopage`, or `addContosoChatMessageToPage` on the client.

<a id="asyncclient"></a>

### Asynchronous execution

The method that you call executes asynchronously. Any code that comes after a method call to a client will execute immediately without waiting for SignalR to finish transmitting data to clients unless you specify that the subsequent lines of code should wait for method completion. The following code example shows how to execute two client methods sequentially.

**Using Await (.NET 4.5)**

[!code-csharp[Main](hubs-api-guide-server/samples/sample41.cs?highlight=1,3)]

If you use `await` to wait until a client method finishes before the next line of code executes, that does not mean that clients will actually receive the message before the next line of code executes. "Completion" of a client method call only means that SignalR has done everything necessary to send the message. If you need verification that clients received the message, you have to program that mechanism yourself. For example, you could code a `MessageReceived` method on the Hub, and in the `addContosoChatMessageToPage` method on the client you could call `MessageReceived` after you do whatever work you need to do on the client. In `MessageReceived` in the Hub you can do whatever work depends on actual client reception and processing of the original method call.

### How to use a string variable as the method name

If you want to invoke a client method by using a string variable as the method name, cast `Clients.All` (or `Clients.Others`, `Clients.Caller`, etc.) to `IClientProxy` and then call [Invoke(methodName, args...)](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.hubs.iclientproxy.invoke(v=vs.111).aspx).

[!code-csharp[Main](hubs-api-guide-server/samples/sample42.cs)]

<a id="groupsfromhub"></a>

## How to manage group membership from the Hub class

Groups in SignalR provide a method for broadcasting messages to specified subsets of connected clients. A group can have any number of clients, and a client can be a member of any number of groups.

To manage group membership, use the [Add](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.igroupmanager.add(v=vs.111).aspx) and [Remove](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.igroupmanager.remove(v=vs.111).aspx) methods provided by the `Groups` property of the Hub class. The following example shows the `Groups.Add` and `Groups.Remove` methods used in Hub methods that are called by client code, followed by JavaScript client code that calls them.

**Server**

[!code-csharp[Main](hubs-api-guide-server/samples/sample43.cs?highlight=5,10)]

**JavaScript client using generated proxy**

[!code-javascript[Main](hubs-api-guide-server/samples/sample44.js)]

[!code-javascript[Main](hubs-api-guide-server/samples/sample45.js)]

You don't have to explicitly create groups. In effect a group is automatically created the first time you specify its name in a call to `Groups.Add`, and it is deleted when you remove the last connection from membership in it.

There is no API for getting a group membership list or a list of groups. SignalR sends messages to clients and groups based on a [pub/sub model](http://en.wikipedia.org/wiki/Publish/subscribe), and the server does not maintain lists of groups or group memberships. This helps maximize scalability, because whenever you add a node to a web farm, any state that SignalR maintains has to be propagated to the new node.

<a id="asyncgroupmethods"></a>

### Asynchronous execution of Add and Remove methods

The `Groups.Add` and `Groups.Remove` methods execute asynchronously. If you want to add a client to a group and immediately send a message to the client by using the group, you have to make sure that the `Groups.Add` method finishes first. The following code example shows how to do that.

**Adding a client to a group and then messaging that client**

[!code-csharp[Main](hubs-api-guide-server/samples/sample46.cs?highlight=1,3)]

<a id="grouppersistence"></a>

### Group membership persistence

SignalR tracks connections, not users, so if you want a user to be in the same group every time the user establishes a connection, you have to call `Groups.Add` every time the user establishes a new connection.

After a temporary loss of connectivity, sometimes SignalR can restore the connection automatically. In that case, SignalR is restoring the same connection, not establishing a new connection, and so the client's group membership is automatically restored. This is possible even when the temporary break is the result of a server reboot or failure, because connection state for each client, including group memberships, is round-tripped to the client. If a server goes down and is replaced by a new server before the connection times out, a client can reconnect automatically to the new server and re-enroll in groups it is a member of.

When a connection can't be restored automatically after a loss of connectivity, or when the connection times out, or when the client disconnects (for example, when a browser navigates to a new page), group memberships are lost. The next time the user connects will be a new connection. To maintain group memberships when the same user establishes a new connection, your application has to track the associations between users and groups, and restore group memberships each time a user establishes a new connection.

For more information about connections and reconnections, see [How to handle connection lifetime events in the Hub class](#connectionlifetime) later in this topic.

<a id="singleusergroups"></a>

### Single-user groups

Applications that use SignalR typically have to keep track of the associations between users and connections in order to know which user has sent a message and which user(s) should be receiving a message. Groups are used in one of the two commonly used patterns for doing that.

- Single-user groups.

    You can specify the user name as the group name, and add the current connection ID to the group every time the user connects or reconnects. To send messages to the user you send to the group. A disadvantage of this method is that the group doesn't provide you with a way to find out if the user is online or offline.
- Track associations between user names and connection IDs.

    You can store an association between each user name and one or more connection IDs in a dictionary or database, and update the stored data each time the user connects or disconnects. To send messages to the user you specify the connection IDs. A disadvantage of this method is that it takes more memory.

<a id="connectionlifetime"></a>

## How to handle connection lifetime events in the Hub class

Typical reasons for handling connection lifetime events are to keep track of whether a user is connected or not, and to keep track of the association between user names and connection IDs. To run your own code when clients connect or disconnect, override the `OnConnected`, `OnDisconnected`, and `OnReconnected` virtual methods of the Hub class, as shown in the following example.

[!code-csharp[Main](hubs-api-guide-server/samples/sample47.cs?highlight=3,14,22)]

<a id="onreconnected"></a>

### When OnConnected, OnDisconnected, and OnReconnected are called

Each time a browser navigates to a new page, a new connection has to be established, which means SignalR will execute the `OnDisconnected` method followed by the `OnConnected` method. SignalR always creates a new connection ID when a new connection is established.

The `OnReconnected` method is called when there has been a temporary break in connectivity that SignalR can automatically recover from, such as when a cable is temporarily disconnected and reconnected before the connection times out. The `OnDisconnected` method is called when the client is disconnected and SignalR can't automatically reconnect, such as when a browser navigates to a new page. Therefore, a possible sequence of events for a given client is `OnConnected`, `OnReconnected`, `OnDisconnected`; or `OnConnected`, `OnDisconnected`. You won't see the sequence `OnConnected`, `OnDisconnected`, `OnReconnected` for a given connection.

The `OnDisconnected` method doesn't get called in some scenarios, such as when a server goes down or the App Domain gets recycled. When another server comes on line or the App Domain completes its recycle, some clients may be able to reconnect and fire the `OnReconnected` event.

For more information, see [Understanding and Handling Connection Lifetime Events in SignalR](handling-connection-lifetime-events.md).

<a id="nocallerstate"></a>

### Caller state not populated

The connection lifetime event handler methods are called from the server, which means that any state that you put in the `state` object on the client will not be populated in the `Caller` property on the server. For information about the `state` object and the `Caller` property, see [How to pass state between clients and the Hub class](#passstate) later in this topic.

<a id="contextproperty"></a>

## How to get information about the client from the Context property

To get information about the client, use the `Context` property of the Hub class. The `Context` property returns a [HubCallerContext](https://msdn.microsoft.com/en-us/library/jj890883(v=vs.111).aspx) object which provides access to the following information:

- The connection ID of the calling client.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample48.cs?highlight=1)]

    The connection ID is a GUID that is assigned by SignalR (you can't specify the value in your own code). There is one connection ID for each connection, and the same connection ID is used by all Hubs if you have multiple Hubs in your application.
- HTTP header data.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample49.cs?highlight=1)]

    You can also get HTTP headers from `Context.Headers`. The reason for multiple references to the same thing is that `Context.Headers` was created first, the `Context.Request` property was added later, and `Context.Headers` was retained for backward compatibility.
- Query string data.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample50.cs?highlight=1)]

    You can also get query string data from `Context.QueryString`.

    The query string that you get in this property is the one that was used with the HTTP request that established the SignalR connection. You can add query string parameters in the client by configuring the connection, which is a convenient way to pass data about the client from the client to the server. The following example shows one way to add a query string in a JavaScript client when you use the generated proxy.

    [!code-javascript[Main](hubs-api-guide-server/samples/sample51.js?highlight=1)]

    For more information about setting query string parameters, see the API guides for the [JavaScript](hubs-api-guide-javascript-client.md) and [.NET](hubs-api-guide-net-client.md) clients.

    You can find the transport method used for the connection in the query string data, along with some other values used internally by SignalR:

    [!code-csharp[Main](hubs-api-guide-server/samples/sample52.cs)]

    The value of `transportMethod` will be "webSockets", "serverSentEvents", "foreverFrame" or "longPolling". Note that if you check this value in the `OnConnected` event handler method, in some scenarios you might initially get a transport value that is not the final negotiated transport method for the connection. In that case the method will throw an exception and will be called again later when the final transport method is established.
- Cookies.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample53.cs?highlight=1)]

    You can also get cookies from `Context.RequestCookies`.
- User information.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample54.cs?highlight=1)]
- The HttpContext object for the request :

    [!code-csharp[Main](hubs-api-guide-server/samples/sample55.cs?highlight=1)]

    Use this method instead of getting `HttpContext.Current` to get the `HttpContext` object for the SignalR connection.

<a id="passstate"></a>

## How to pass state between clients and the Hub class

The client proxy provides a `state` object in which you can store data that you want to be transmitted to the server with each method call. On the server you can access this data in the `Clients.Caller` property in Hub methods that are called by clients. The `Clients.Caller` property is not populated for the connection lifetime event handler methods `OnConnected`, `OnDisconnected`, and `OnReconnected`.

Creating or updating data in the `state` object and the `Clients.Caller` property works in both directions. You can update values in the server and they are passed back to the client.

The following example shows JavaScript client code that stores state for transmission to the server with every method call.

[!code-javascript[Main](hubs-api-guide-server/samples/sample56.js?highlight=1-2)]

The following example shows the equivalent code in a .NET client.

[!code-csharp[Main](hubs-api-guide-server/samples/sample57.cs?highlight=1-2)]

In your Hub class, you can access this data in the `Clients.Caller` property. The following example shows code that retrieves the state referred to in the previous example.

[!code-csharp[Main](hubs-api-guide-server/samples/sample58.cs?highlight=3-4)]

> [!NOTE]
> This mechanism for persisting state is not intended for large amounts of data, since everything you put in the `state` or `Clients.Caller` property is round-tripped with every method invocation. It's useful for smaller items such as user names or counters.


In VB.NET or in a strongly-typed hub, the caller state object can't be accessed through `Clients.Caller`; instead, use `Clients.CallerState` (introduced in SignalR 2.1):

**Using CallerState in C#**

[!code-csharp[Main](hubs-api-guide-server/samples/sample59.cs?highlight=3-4)]

**Using CallerState in Visual Basic**

[!code-vb[Main](hubs-api-guide-server/samples/sample60.vb)]

<a id="handleErrors"></a>

## How to handle errors in the Hub class

To handle errors that occur in your Hub class methods, use one or more of the following methods:

- Wrap your method code in try-catch blocks and log the exception object. For debugging purposes you can send the exception to the client, but for security reasons sending detailed information to clients in production is not recommended.
- Create a Hubs pipeline module that handles the [OnIncomingError](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.hubs.hubpipelinemodule.onincomingerror(v=vs.111).aspx) method. The following example shows a pipeline module that logs errors, followed by code in Startup.cs that injects the module into the Hubs pipeline.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample61.cs)]

    [!code-csharp[Main](hubs-api-guide-server/samples/sample62.cs?highlight=4)]
- Use the `HubException` class (introduced in SignalR 2). This error can be thrown from any hub invocation. The `HubError` constructor takes a string message, and an object for storing extra error data. SignalR will auto-serialize the exception and send it to the client, where it will be used to reject or fail the hub method invocation.

    The following code samples demonstrate how to throw a `HubException` during a Hub invocation, and how to handle the exception on JavaScript and .NET clients.

    **Server code demonstrating the HubException class**

    [!code-csharp[Main](hubs-api-guide-server/samples/sample63.cs)]

    **JavaScript client code demonstrating response to throwing a HubException in a hub**

    [!code-html[Main](hubs-api-guide-server/samples/sample64.html)]

    **.NET client code demonstrating response to throwing a HubException in a hub**

    [!code-csharp[Main](hubs-api-guide-server/samples/sample65.cs)]

For more information about Hub pipeline modules, see [How to customize the Hubs pipeline](#hubpipeline) later in this topic.

<a id="tracing"></a>

## How to enable tracing

To enable server-side tracing, add a system.diagnostics element to your Web.config file, as shown in this example:

[!code-html[Main](hubs-api-guide-server/samples/sample66.html?highlight=17-72)]

When you run the application in Visual Studio, you can view the logs in the **Output** window.

<a id="callfromoutsidehub"></a>

## How to call client methods and manage groups from outside the Hub class

To call client methods from a different class than your Hub class, get a reference to the SignalR context object for the Hub and use that to call methods on the client or manage groups.

The following sample `StockTicker` class gets the context object, stores it in an instance of the class, stores the class instance in a static property, and uses the context from the singleton class instance to call the `updateStockPrice` method on clients that are connected to a Hub named `StockTickerHub`.

[!code-csharp[Main](hubs-api-guide-server/samples/sample67.cs?highlight=8,24)]

If you need to use the context multiple-times in a long-lived object, get the reference once and save it rather than getting it again each time. Getting the context once ensures that SignalR sends messages to clients in the same sequence in which your Hub methods make client method invocations. For a tutorial that shows how to use the SignalR context for a Hub, see [Server Broadcast with ASP.NET SignalR](../getting-started/tutorial-server-broadcast-with-signalr.md).

<a id="callingclientsoutsidehub"></a>

### Calling client methods

You can specify which clients will receive the RPC, but you have fewer options than when you call from a Hub class. The reason for this is that the context is not associated with a particular call from a client, so any methods that require knowledge of the current connection ID, such as `Clients.Others`, or `Clients.Caller`, or `Clients.OthersInGroup`, are not available. The following options are available:

- All connected clients.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample68.cs)]
- A specific client identified by connection ID.

    [!code-css[Main](hubs-api-guide-server/samples/sample69.css)]
- All connected clients except the specified clients, identified by connection ID.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample70.cs)]
- All connected clients in a specified group.

    [!code-css[Main](hubs-api-guide-server/samples/sample71.css)]
- All connected clients in a specified group except specified clients, identified by connection ID.

    [!code-csharp[Main](hubs-api-guide-server/samples/sample72.cs)]

If you are calling into your non-Hub class from methods in your Hub class, you can pass in the current connection ID and use that with `Clients.Client`, `Clients.AllExcept`, or `Clients.Group` to simulate `Clients.Caller`, `Clients.Others`, or `Clients.OthersInGroup`. In the following example, the `MoveShapeHub` class passes the connection ID to the `Broadcaster` class so that the `Broadcaster` class can simulate `Clients.Others`.

[!code-csharp[Main](hubs-api-guide-server/samples/sample73.cs?highlight=12,36)]

<a id="managinggroupsoutsidehub"></a>

### Managing group membership

For managing groups you have the same options as you do in a Hub class.

- Add a client to a group

    [!code-csharp[Main](hubs-api-guide-server/samples/sample74.cs)]
- Remove a client from a group

    [!code-css[Main](hubs-api-guide-server/samples/sample75.css)]

<a id="hubpipeline"></a>

## How to customize the Hubs pipeline

SignalR enables you to inject your own code into the Hub pipeline. The following example shows a custom Hub pipeline module that logs each incoming method call received from the client and outgoing method call invoked on the client:

[!code-csharp[Main](hubs-api-guide-server/samples/sample76.cs)]

The following code in the *Startup.cs* file registers the module to run in the Hub pipeline:

[!code-csharp[Main](hubs-api-guide-server/samples/sample77.cs?highlight=3)]

There are many different methods that you can override. For a complete list, see [HubPipelineModule Methods](https://msdn.microsoft.com/en-us/library/jj918633(v=vs.111).aspx).