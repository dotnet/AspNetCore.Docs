---
uid: signalr/overview/older-versions/signalr-1x-hubs-api-guide-net-client
title: "ASP.NET SignalR Hubs API Guide - .NET Client (SignalR 1.x) | Microsoft Docs"
author: pfletcher
description: "This document provides an introduction to using the Hubs API for SignalR version 2 in .NET clients, such as Windows Store (WinRT), WPF, Silverlight, and cons..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 04/17/2013
ms.topic: article
ms.assetid: c334adc3-d6dc-44f3-9f06-f7634475aad3
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/older-versions/signalr-1x-hubs-api-guide-net-client
msc.type: authoredcontent
---
ASP.NET SignalR Hubs API Guide - .NET Client (SignalR 1.x)
====================
by [Patrick Fletcher](https://github.com/pfletcher), [Tom Dykstra](https://github.com/tdykstra)

> This document provides an introduction to using the Hubs API for SignalR version 2 in .NET clients, such as Windows Store (WinRT), WPF, Silverlight, and console applications.
> 
> The SignalR Hubs API enables you to make remote procedure calls (RPCs) from a server to connected clients and from clients to the server. In server code, you define methods that can be called by clients, and you call methods that run on the client. In client code, you define methods that can be called from the server, and you call methods that run on the server. SignalR takes care of all of the client-to-server plumbing for you.
> 
> SignalR also offers a lower-level API called Persistent Connections. For an introduction to SignalR, Hubs, and Persistent Connections, or for a tutorial that shows how to build a complete SignalR application, see [SignalR - Getting Started](../getting-started/index.md).


## Overview

This document contains the following sections:

- [Client Setup](#clientsetup)
- [How to establish a connection](#establishconnection)

    - [Cross-domain connections from Silverlight clients](#slcrossdomain)
- [How to configure the connection](#configureconnection)

    - [How to set the maximum number of concurrent connections in WPF clients](#maxconnections)
    - [How to specify query string parameters](#querystring)
    - [How to specify the transport method](#transport)
    - [How to specify HTTP headers](#httpheaders)
    - [How to specify client certificates](#clientcertificate)
- [How to create the Hub proxy](#proxy)
- [How to define methods on the client that the server can call](#callclient)

    - [Methods without parameters](#clientmethodswithoutparms)
    - [Methods with parameters, specifying parameter types](#clientmethodswithparmtypes)
    - [Methods with parameters, specifying dynamic objects for the parameters](#clientmethodswithdynamparms)
    - [How to remove a handler](#removehandler)
- [How to call server methods from the client](#callserver)
- [How to handle connection lifetime events](#connectionlifetime)
- [How to handle errors](#handleerrors)
- [How to enable client-side logging](#logging)
- [WPF, Silverlight, and console application code samples for client methods that the server can call](#wpfsl)

For a sample .NET client projects, see the following resources:

- [gustavo-armenta / SignalR-Samples](https://github.com/gustavo-armenta/SignalR-Samples) on GitHub.com (WinRT, Silverlight, console app examples).
- [DamianEdwards / SignalR-MoveShapeDemo / MoveShape.Desktop](https://github.com/DamianEdwards/SignalR-MoveShapeDemo/tree/master/MoveShape/MoveShape.Desktop) on GitHub.com (WPF example).
- [SignalR / Microsoft.AspNet.SignalR.Client.Samples](https://github.com/SignalR/SignalR/tree/master/samples/Microsoft.AspNet.SignalR.Client.Samples) on GitHub.com (Console app example).

For documentation on how to program the server or JavaScript clients, see the following resources:

- [SignalR Hubs API Guide - Server](../guide-to-the-api/hubs-api-guide-server.md)
- [SignalR Hubs API Guide - JavaScript Client](../guide-to-the-api/hubs-api-guide-javascript-client.md)

Links to API Reference topics are to the .NET 4.5 version of the API. If you're using .NET 4, see [the .NET 4 version of the API topics](https://msdn.microsoft.com/en-us/library/jj891075(v=vs.100).aspx).

<a id="clientsetup"></a>

## Client setup

Install the [Microsoft.AspNet.SignalR.Client](http://nuget.org/packages/Microsoft.AspNet.SignalR.Client) NuGet package (not the [Microsoft.AspNet.SignalR](http://nuget.org/packages/microsoft.aspnet.signalr) package). This package supports WinRT, Silverlight, WPF, console application, and Windows Phone clients, for both .NET 4 and .NET 4.5.

If the version of SignalR that you have on the client is different from the version that you have on the server, SignalR is often able to adapt to the difference. For example, when SignalR version 2.0 is released and you install that on the server, the server will support clients that have 1.1.x installed as well as clients that have 2.0 installed. If the difference between the version on the server and the version on the client is too great, SignalR throws an `InvalidOperationException` exception when the client tries to establish a connection. The error message is "`You are using a version of the client that isn't compatible with the server. Client version X.X, server version X.X`".

<a id="establishconnection"></a>

## How to establish a connection

Before you can establish a connection, you have to create a `HubConnection` object and create a proxy. To establish the connection, call the `Start` method on the `HubConnection` object.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample1.cs?highlight=1,4)]

> [!NOTE]
> For JavaScript clients you have to register at least one event handler before calling the `Start` method to establish the connection. This is not necessary for .NET clients. For JavaScript clients, the generated proxy code automatically creates proxies for all Hubs that exist on the server, and registering a handler is how you indicate which Hubs your client intends to use. But for a .NET client you create Hub proxies manually, so SignalR assumes that you will be using any Hub that you create a proxy for.


The sample code uses the default "/signalr" URL to connect to your SignalR service. For information about how to specify a different base URL, see [ASP.NET SignalR Hubs API Guide - Server - The /signalr URL](../guide-to-the-api/hubs-api-guide-server.md#signalrurl).

The `Start` method executes asynchronously. To make sure that subsequent lines of code don't execute until after the connection is established, use `await` in an ASP.NET 4.5 asynchronous method or `.Wait()` in a synchronous method. Don't use `.Wait()` in a WinRT client.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample2.cs?highlight=1)]

[!code-css[Main](signalr-1x-hubs-api-guide-net-client/samples/sample3.css?highlight=1)]

The `HubConnection` class is thread-safe.

<a id="slcrossdomain"></a>

### Cross-domain connections from Silverlight clients

For information about how to enable cross-domain connections from Silverlight clients, see [Making a Service Available Across Domain Boundaries](https://msdn.microsoft.com/en-us/library/cc197955(v=vs.95).aspx).

<a id="configureconnection"></a>

## How to configure the connection

Before you establish a connection, you can specify any of the following options:

- Concurrent connections limit.
- Query string parameters.
- The transport method.
- HTTP headers.
- Client certificates.

<a id="maxconnections"></a>

### How to set the maximum number of concurrent connections in WPF clients

In WPF clients, you might have to increase the maximum number of concurrent connections from its default value of 2. The recommended value is 10.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample4.cs?highlight=4)]

For more information, see [ServicePointManager.DefaultConnectionLimit](https://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit.aspx).

<a id="querystring"></a>

### How to specify query string parameters

If you want to send data to the server when the client connects, you can add query string parameters to the connection object. The following example shows how to set a query string parameter in client code.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample5.cs)]

The following example shows how to read a query string parameter in server code.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample6.cs?highlight=5)]

<a id="transport"></a>

### How to specify the transport method

As part of the process of connecting, a SignalR client normally negotiates with the server to determine the best transport that is supported by both server and client. If you already know which transport you want to use, you can bypass this negotiation process. To specify the transport method, pass in a transport object to the Start method. The following example shows how to specify the transport method in client code.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample7.cs?highlight=4)]

The [Microsoft.AspNet.SignalR.Client.Transports](https://msdn.microsoft.com/en-us/library/jj918090(v=vs.111).aspx) namespace includes the following classes that you can use to specify the transport.

- [LongPollingTransport](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.transports.longpollingtransport(v=vs.111).aspx)
- [ServerSentEventsTransport](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.transports.serversenteventstransport(v=vs.111).aspx)
- [WebSocketTransport](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.transports.websockettransport(v=vs.111).aspx) (Available only when both server and client use .NET 4.5.)
- [AutoTransport](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.transports.autotransport(v=vs.111).aspx) (Automatically chooses the best transport that is supported by both the client and the server. This is the default transport. Passing this in to the `Start` method has the same effect as not passing in anything.)

The ForeverFrame transport is not included in this list because it is used only by browsers.

For information about how to check the transport method in server code, see [ASP.NET SignalR Hubs API Guide - Server - How to get information about the client from the Context property](../guide-to-the-api/hubs-api-guide-server.md#contextproperty). For more information about transports and fallbacks, see [Introduction to SignalR - Transports and Fallbacks](../getting-started/introduction-to-signalr.md#transports).

<a id="httpheaders"></a>

### How to specify HTTP headers

To set HTTP headers, use the `Headers` property on the connection object. The following example shows how to add an HTTP header.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample8.cs?highlight=2)]

<a id="clientcertificate"></a>

### How to specify client certificates

To add client certificates, use the `AddClientCertificate` method on the connection object.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample9.cs?highlight=2)]

<a id="proxy"></a>

## How to create the Hub proxy

In order to define methods on the client that a Hub can call from the server, and to invoke methods on a Hub at the server, create a proxy for the Hub by calling `CreateHubProxy` on the connection object. The string you pass in to `CreateHubProxy` is the name of your Hub class, or the name specified by the `HubName` attribute if one was used on the server. Name matching is case-insensitive.

**Hub class on server**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample10.cs?highlight=1)]

**Create client proxy for the Hub class**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample11.cs?highlight=2)]

If you decorate your Hub class with a `HubName` attribute, use that name.

**Hub class on server**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample12.cs)]

**Create client proxy for the Hub class**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample13.cs?highlight=2)]

The proxy object is thread-safe. In fact, if you call `HubConnection.CreateHubProxy` multiple times with the same `hubName`, you get the same cached `IHubProxy` object.

<a id="callclient"></a>

## How to define methods on the client that the server can call

To define a method that the server can call, use the proxy's `On` method to register an event handler.

Method name matching is case-insensitive. For example, `Clients.All.UpdateStockPrice` on the server will execute `updateStockPrice`, `updatestockprice`, or `UpdateStockPrice` on the client.

Different client platforms have different requirements for how you write method code to update the UI. The examples shown are for WinRT (Windows Store .NET) clients. WPF, Silverlight, and console application examples are provided in [a separate section later in this topic](#wpfsl).

<a id="clientmethodswithoutparms"></a>

### Methods without parameters

If the method you're handling does not have parameters, use the non-generic overload of the `On` method:

**Server code calling client method without parameters**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample14.cs?highlight=5)]

**WinRT Client code for method called from server without parameters ([see WPF and Silverlight examples later in this topic](#wpfsl))**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample15.cs)]

<a id="clientmethodswithparmtypes"></a>

### Methods with parameters, specifying the parameter types

If the method you're handling has parameters, specify the types of the parameters as the generic types of the `On` method. There are generic overloads of the `On` method to enable you to specify up to 8 parameters (4 on Windows Phone 7). In the following example, one parameter is sent to the `UpdateStockPrice` method.

**Server code calling client method with a parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample16.cs?highlight=3)]

**The Stock class used for the parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample17.cs)]

**WinRT Client code for a method called from server with a parameter ([see WPF and Silverlight examples later in this topic](#wpfsl))**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample18.cs?highlight=1,5)]

<a id="clientmethodswithdynamparms"></a>

### Methods with parameters, specifying dynamic objects for the parameters

As an alternative to specifying parameters as generic types of the `On` method, you can specify parameters as dynamic objects:

**Server code calling client method with a parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample19.cs?highlight=3)]

**The Stock class used for the parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample20.cs)]

**WinRT Client code for a method called from server with a parameter, using a dynamic object for the parameter ([see WPF and Silverlight examples later in this topic](#wpfsl))**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample21.cs?highlight=1,5)]

<a id="removehandler"></a>

### How to remove a handler

To remove a handler, call its `Dispose` method.

**Client code for a method called from server**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample22.cs?highlight=1)]

**Client code to remove the handler**

[!code-css[Main](signalr-1x-hubs-api-guide-net-client/samples/sample23.css?highlight=1)]

<a id="callserver"></a>

## How to call server methods from the client

To call a method on the server, use the `Invoke` method on the Hub proxy.

If the server method has no return value, use the non-generic overload of the `Invoke` method.

**Server code for a method that has no return value**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample24.cs?highlight=3)]

**Client code calling a method that has no return value**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample25.cs?highlight=1)]

If the server method has a return value, specify the return type as the generic type of the `Invoke` method.

**Server code for a method that has a return value and takes a complex type parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample26.cs?highlight=1)]

**The Stock class used for the parameter and return value**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample27.cs)]

**Client code calling a method that has a return value and takes a complex type parameter, in an ASP.NET 4.5 async method**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample28.cs?highlight=1-2)]

**Client code calling a method that has a return value and takes a complex type parameter, in a synchronous method**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample29.cs?highlight=1-2)]

The `Invoke` method executes asynchronously and returns a `Task` object. If you don't specify `await` or `.Wait()`, the next line of code will execute before the method that you invoke has finished executing.

<a id="connectionlifetime"></a>

## How to handle connection lifetime events

SignalR provides the following connection lifetime events that you can handle:

- `Received`: Raised when any data is received on the connection. Provides the received data.
- `ConnectionSlow`: Raised when the client detects a slow or frequently dropping connection.
- `Reconnecting`: Raised when the underlying transport begins reconnecting.
- `Reconnected`: Raised when the underlying transport has reconnected.
- `StateChanged`: Raised when the connection state changes. Provides the old state and the new state. For information about connection state values see [ConnectionState Enumeration](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.connectionstate(v=vs.111).aspx).
- `Closed`: Raised when the connection has disconnected.

For example, if you want to display warning messages for errors that are not fatal but cause intermittent connection problems, such as slowness or frequent dropping of the connection, handle the `ConnectionSlow` event.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample30.cs)]

For more information, see [Understanding and Handling Connection Lifetime Events in SignalR](../guide-to-the-api/handling-connection-lifetime-events.md).

<a id="handleerrors"></a>

## How to handle errors

If you don't explicitly enable detailed error messages on the server, the exception object that SignalR returns after an error contains minimal information about the error. For example, if a call to `newContosoChatMessage` fails, the error message in the error object contains "`There was an error invoking Hub method 'contosoChatHub.newContosoChatMessage'.`" Sending detailed error messages to clients in production is not recommended for security reasons, but if you want to enable detailed error messages for troubleshooting purposes, use the following code on the server.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample31.cs?highlight=2)]

<a id="handleerrors"></a>

To handle errors that SignalR raises, you can add a handler for the `Error` event on the connection object.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample32.cs)]

To handle errors from method invocations, wrap the code in a try-catch block.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample33.cs)]

<a id="logging"></a>

## How to enable client-side logging

To enable client-side logging, set the `TraceLevel` and `TraceWriter` properties on the connection object.

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample34.cs?highlight=2-3)]

<a id="wpfsl"></a>

## WPF, Silverlight, and console application code samples for client methods that the server can call

The code samples shown earlier for defining client methods that the server can call apply to WinRT clients. The following samples show the equivalent code for WPF, Silverlight, and console application clients.

### Methods without parameters

**WPF client code for method called from server without parameters**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample35.cs?highlight=1)]

**Silverlight client code for method called from server without parameters**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample36.cs?highlight=1)]

**Console application client code for method called from server without parameters**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample37.cs?highlight=1)]

### Methods with parameters, specifying the parameter types

**WPF client code for a method called from server with a parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample38.cs?highlight=1,4)]

**Silverlight client code for a method called from server with a parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample39.cs?highlight=1,5)]

**Console application client code for a method called from server with a parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample40.cs?highlight=1-2)]

### Methods with parameters, specifying dynamic objects for the parameters

**WPF client code for a method called from server with a parameter, using a dynamic object for the parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample41.cs?highlight=1,4)]

**Silverlight client code for a method called from server with a parameter, using a dynamic object for the parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample42.cs?highlight=1,5)]

**Console application client code for a method called from server with a parameter, using a dynamic object for the parameter**

[!code-csharp[Main](signalr-1x-hubs-api-guide-net-client/samples/sample43.cs?highlight=1-2)]