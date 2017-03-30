---
uid: signalr/overview/older-versions/troubleshooting
title: "SignalR Troubleshooting (SignalR 1.x) | Microsoft Docs"
author: pfletcher
description: "This article describes common issues with developing SignalR applications."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/05/2013
ms.topic: article
ms.assetid: 347210ba-c452-4feb-886f-b51d89f58971
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/older-versions/troubleshooting
msc.type: authoredcontent
---
SignalR Troubleshooting (SignalR 1.x)
====================
by [Patrick Fletcher](https://github.com/pfletcher)

> This document describes common troubleshooting issues with SignalR.


This document contains the following sections.

- [Calling methods between the client and server silently fails](#connection)
- [Other connection issues](#other)
- [Compilation and server-side errors](#server)
- [Visual Studio issues](#vs)
- [Internet Information Services issues](#iis)
- [Azure issues](#azure)

<a id="connection"></a>

## Calling methods between the client and server silently fails

This section describes possible causes for a method call between client and server to fail without a meaningful error message. In a SignalR application, the server has no information about the methods that the client implements; when the server invokes a client method, the method name and parameter data are sent to the client, and the method is executed only if it exists in the format that the server specified. If no matching method is found on the client, nothing happens, and no error message is raised on the server.

To further investigate client methods not getting called, you can turn on logging before the calling the start method on the hub to see what calls are coming from the server. To enable logging in a JavaScript application, see [How to enable client-side logging (JavaScript client version)](../guide-to-the-api/hubs-api-guide-javascript-client.md#logging). To enable logging in a .NET client application, see [How to enable client-side logging (.NET Client version)](../guide-to-the-api/hubs-api-guide-net-client.md#logging).

### Misspelled method, incorrect method signature, or incorrect hub name

If the name or signature of a called method does not exactly match an appropriate method on the client, the call will fail. Verify that the method name called by the server matches the name of the method on the client. Also, SignalR creates the hub proxy using camel-cased methods, as is appropriate in JavaScript, so a method called `SendMessage` on the server would be called `sendMessage` in the client proxy. If you use the `HubName` attribute in your server-side code, verify that the name used matches the name used to create the hub on the client. If you do not use the `HubName` attribute, verify that the name of the hub in a JavaScript client is camel-cased, such as chatHub instead of ChatHub.

### Duplicate method name on client

Verify that you do not have a duplicate method on the client that differs only by case. If your client application has a method called `sendMessage`, verify that there isn't also a method called `SendMessage` as well.

### Missing JSON parser on the client

SignalR requires a JSON parser to be present to serialize calls between the server and the client. If your client doesn't have a built-in JSON parser (such as Internet Explorer 7), you'll need to include one in your application. You can download the JSON parser [here](http://nuget.org/packages/json2).

### Mixing Hub and PersistentConnection syntax

SignalR uses two communication models: Hubs and PersistentConnections. The syntax for calling these two communication models is different in the client code. If you have added a hub in your server code, verify that all of your client code uses the proper hub syntax.

**JavaScript client code that creates a PersistentConnection in a JavaScript client**

[!code-javascript[Main](troubleshooting/samples/sample1.js)]

**JavaScript client code that creates a Hub Proxy in a Javascript client**

[!code-javascript[Main](troubleshooting/samples/sample2.js)]

**C# server code that maps a route to a PersistentConnection**

[!code-csharp[Main](troubleshooting/samples/sample3.cs)]

**C# server code that maps a route to a Hub, or to mulitple hubs if you have multiple applications**

[!code-csharp[Main](troubleshooting/samples/sample4.cs)]

### Connection started before subscriptions are added

If the Hub's connection is started before methods that can be called from the server are added to the proxy, messages will not be received. The following JavaScript code will not start the hub properly:

**Incorrect JavaScript client code that will not allow Hubs messages to be received**

[!code-javascript[Main](troubleshooting/samples/sample5.js)]

Instead, add the method subscriptions before calling Start:

**JavaScript client code that correctly adds subscriptions to a hub**

[!code-javascript[Main](troubleshooting/samples/sample6.js)]

### Missing method name on the hub proxy

Verify that the method defined on the server is subscribed to on the client. Even though the server defines the method, it must still be added to the client proxy. Methods can be added to the client proxy in the following ways (Note that the method is added to the `client` member of the hub, not the hub directly):

**JavaScript client code that adds methods to a hub proxy**

[!code-javascript[Main](troubleshooting/samples/sample7.js)]

### Hub or hub methods not declared as Public

To be visible on the client, the hub implementation and methods must be declared as `public`.

### Accessing hub from a different application

SignalR Hubs can only be accessed through applications that implement SignalR clients. SignalR cannot interoperate with other communication libraries (like SOAP or WCF web services.) If there is no SignalR client available for your target platform, you cannot access the server's endpoint directly.

### Manually serializing data

SignalR will automatically use JSON to serialize your method parameters- there's no need to do it yourself.

### Remote Hub method not executed on client in OnDisconnected function

This behavior is by design. When `OnDisconnected` is called, the hub has already entered the `Disconnected` state, which does not allow further hub methods to be called.

**C# server code that correctly executes code in the OnDisconnected event**

[!code-csharp[Main](troubleshooting/samples/sample8.cs)]

### Connection limit reached

When using the full version of IIS on a client operating system like Windows 7, a 10-connection limit is imposed. When using a client OS, use IIS Express instead to avoid this limit.

### Cross-domain connection not set up properly

If a cross-domain connection (a connection for which the SignalR URL is not in the same domain as the hosting page) is not set up correctly, the connection may fail without an error message. For information on how to enable cross-domain communication, see [How to establish a cross-domain connection](../guide-to-the-api/hubs-api-guide-javascript-client.md#crossdomain).

### Connection using NTLM (Active Directory) not working in .NET client

A connection in a .NET client application that uses Domain security may fail if the connection is not configured properly. To use SignalR in a domain environment, set the requisite connection property as follows:

**C# client code that implements connection credentials**

[!code-csharp[Main](troubleshooting/samples/sample9.cs)]

<a id="other"></a>

## Other connection issues

This section describes the causes and solutions for specific symptoms or error messages that occur during a connection.

### "Start must be called before data can be sent" error

This error is commonly seen if code references SignalR objects before the connection is started. The wireup for handlers and the like that will call methods defined on the server must be added after the connection completes. Note that the call to `Start` is asynchronous, so code after the call may be executed before it completes. The best way to add handlers after a connection starts completely is to put them into a callback function that is passed as a parameter to the start method:

**JavaScript client code that correctly adds event handlers that reference SignalR objects**

[!code-javascript[Main](troubleshooting/samples/sample10.js?highlight=1)]

This error will also be seen if a connection stops while SignalR objects are still being referenced.

### "301 Moved Permanently" or "302 Moved Temporarily" error

This error may be seen if the project contains a folder called SignalR, which will interfere with the automatically-created proxy. To avoid this error, do not use a folder called `SignalR` in your application, or turn automatic proxy generation off. See [The Generated Proxy and what it does for you](../guide-to-the-api/hubs-api-guide-javascript-client.md#genproxy) for more details.

### "403 Forbidden" error in .NET or Silverlight client

This error may occur in cross-domain environments where cross-domain communication is not properly enabled. For information on how to enable cross-domain communication, see [How to establish a cross-domain connection](../guide-to-the-api/hubs-api-guide-javascript-client.md#crossdomain). To establish a cross-domain connection in a Silverlight client, see [Cross-domain connections from Silverlight clients](../guide-to-the-api/hubs-api-guide-net-client.md#slcrossdomain).

### "404 Not Found" error

There are several causes for this issue. Verify all of the following:

- **Hub proxy address reference not formatted correctly:** This error is commonly seen if the reference to the generated hub proxy address is not formatted correctly. Verify that the reference to the hub address is made properly. See [How to reference the dynamically generated proxy](../guide-to-the-api/hubs-api-guide-javascript-client.md#dynamicproxy) for details.
- **Adding routes to application before adding the hub route:** If your application uses other routes, verify that the first route added is the call to `MapHubs`.

### "500 Internal Server Error"

This is a very generic error that could have a wide variety of causes. The details of the error should appear in the server's event log, or can be found through debugging the server. More detailed error information may be obtained by turning on detailed errors on the server. For more information, see [How to handle errors in the Hub class](../guide-to-the-api/hubs-api-guide-server.md#handleErrors).

### "TypeError: &lt;hubType&gt; is undefined" error

This error will result if the call to `MapHubs` is not made properly. See [How to register the SignalR route and configure SignalR options](../guide-to-the-api/hubs-api-guide-server.md#route) for more information.

### JsonSerializationException was unhandled by user code

Verify that the parameters you send to your methods do not include non-serializable types (like file handles or database connections). If you need to use members on a server-side object that you don't want to be sent to the client (either for security or for reasons of serialization), use the `JSONIgnore` attribute.

### "Protocol error: Unknown transport" error

This error may occur if the client does not support the transports that SignalR uses. See [Transports and Fallbacks](../getting-started/introduction-to-signalr.md#transports) for information on which browsers can be used with SignalR.

### "JavaScript Hub proxy generation has been disabled."

This error will occur if `DisableJavaScriptProxies` is set while also including a reference to the dynamically generated proxy at `signalr/hubs`. For more information on creating the proxy manually, see [The generated proxy and what it does for you](../guide-to-the-api/hubs-api-guide-javascript-client.md#genproxy).

### "The connection ID is in the incorrect format" or "The user identity cannot change during an active SignalR connection" error

This error may be seen if authentication is being used, and the client is logged out before the connection is stopped. The solution is to stop the SignalR connection before logging the client out.

### "Uncaught Error: SignalR: jQuery not found. Please ensure jQuery is referenced before the SignalR.js file" error

The SignalR JavaScript client requires jQuery to run. Verify that your reference to jQuery is correct, that the path used is valid, and that the reference to jQuery is before the reference to SignalR.

### "Uncaught TypeError: Cannot read property '&lt;property&gt;' of undefined" error

This error results from not having jQuery or the hubs proxy referenced properly. Verify that your reference to jQuery and the hubs proxy is correct, that the path used is valid, and that the reference to jQuery is before the reference to the hubs proxy. The default reference to the hubs proxy should look like the following:

**HTML client-side code that correctly references the Hubs proxy**

[!code-html[Main](troubleshooting/samples/sample11.html)]

### "RuntimeBinderException was unhandled by user code" error

This error may occur when the incorrect overload of `Hub.On` is used. If the method has a return value, the return type must be specified as a generic type parameter:

**Method defined on the client (without generated proxy)**

[!code-html[Main](troubleshooting/samples/sample12.html?highlight=1)]

### Connection ID is inconsistent or connection breaks between page loads

This behavior is by design. Since the hub object is hosted in the page object, the hub is destroyed when the page refreshes. A multi-page application needs to maintain the association between users and connection IDs so that they will be consistent between page loads. The connection IDs can be stored on the server in either a `ConcurrentDictionary` object or a database.

### "Value cannot be null" error

Server-side methods with optional parameters are not currently supported; if the optional parameter is omitted, the method will fail. For more information, see [Optional Parameters](https://github.com/SignalR/SignalR/issues/324).

### "Firefox can't establish a connection to the server at &lt;address&gt;" error in Firebug

This error message can be seen in Firebug if negotiation of the WebSocket transport fails and another transport is used instead. This behavior is by design.

### "The remote certificate is invalid according to the validation procedure" error in .NET client application

If your server requires custom client certificates, then you can add an x509certificate to the connection before the request is made. Add the certificate to the connection using `Connection.AddClientCertificate`.

### Connection drops after authentication times out

This behavior is by design. Authentication credentials cannot be modified while a connection is active; to refresh credentials, the connection must be stopped and restarted.

### OnConnected gets called twice when using jQuery Mobile

jQuery Mobile's `initializePage` function forces the scripts in each page to be re-executed, thus creating a second connection. Solutions for this issue include:

- Include the reference to jQuery Mobile before your JavaScript file.
- Disable the `initializePage` function by setting `$.mobile.autoInitializePage = false`.
- Wait for the page to finish initializing before starting the connection.

### Messages are delayed in Silverlight applications using Server Sent Events

Messages are delayed when using server sent events on Silverlight. To force long polling to be used instead, use the following when starting the connection:

[!code-css[Main](troubleshooting/samples/sample13.css)]

### "Permission Denied" using Forever Frame protocol

This is a known issue, described [here](https://github.com/SignalR/SignalR/issues/1963). This symptom may be seen using the latest JQuery library; the workaround is to downgrade your application to JQuery 1.8.2.

<a id="server"></a>

## Compilation and server-side errors

 The following section contains possible solutions to compiler and server-side runtime errors. 

### Reference to Hub instance is null

Since a hub instance is created for each connection, you can't create an instance of a hub in your code yourself. To call methods on a hub from outside the hub itself, see [How to call client methods and manage groups from outside the Hub class](../guide-to-the-api/hubs-api-guide-server.md#callfromoutsidehub) for how to obtain a reference to the hub context.

### HTTPContext.Current.Session is null

This behavior is by design. SignalR does not support the ASP.NET session state, since enabling the session state would break duplex messaging.

### No suitable method to override

You may see this error if you are using code from older documentation or blogs. Verify that you are not referencing names of methods that have been changed or deprecated (like `OnConnectedAsync`).

### HostContextExtensions.WebSocketServerUrl is null

This behavior is by design. This member is deprecated and should not be used.

### "A route named 'signalr.hubs' is already in the route collection" error

This error will be seen if `MapHubs` is called twice by your application. Some example applications call `MapHubs` directly in the global application file; others make the call in a wrapper class. Ensure that your application does not do both.

<a id="vs"></a>

## Visual Studio issues

This section describes issues encountered in Visual Studio.

### Script Documents node does not appear in Solution Explorer

Some of our tutorials direct you to the "Script Documents" node in Solution Explorer while debugging. This node is produced by the JavaScript debugger, and will only appear while debugging browser clients in Internet Explorer; the node will not appear if Chrome or Firefox are used. The JavaScript debugger will also not run if another client debugger is running, such as the Silverlight debugger.

### SignalR does not work on Visual Studio 2008 or earlier

This behavior is by design. SignalR requires .NET Framework 4 or later; this requires that SignalR applications be developed in Visual Studio 2010 or later.

<a id="iis"></a>

## IIS issues

This section contains issues with Internet Information Services.

### Web site crashes after MapHubs call

This issue has been fixed in the latest version of SignalR. Verify that you are using the latest released version of SignalR by updating your installation using NuGet.

<a id="azure"></a>

## Azure issues

This section contains issues with Microsoft Azure.

### Messages are not received through the Azure backplane after altering topic names

The topics used by the Azure backplane are not intended to be user-configurable.