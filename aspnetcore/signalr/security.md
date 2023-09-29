---
title: Security considerations in ASP.NET Core SignalR
author: bradygaster
description: Learn about security in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 09/28/2023
uid: signalr/security
---
# Security considerations in ASP.NET Core SignalR

By [Andrew Stanton-Nurse](https://twitter.com/anurse)

:::moniker range=">= aspnetcore-8.0"
This article provides information on securing SignalR.

## Cross-Origin Resource Sharing

[Cross-Origin Resource Sharing (CORS)](https://www.w3.org/TR/cors/) can be used to allow cross-origin SignalR connections in the browser. If JavaScript code is hosted on a different domain from the SignalR app, [CORS middleware](xref:security/cors) must be enabled to allow the JavaScript to connect to the SignalR app. Allow cross-origin requests only from domains you trust or control. For example:

* Your site is hosted on `http://www.example.com`
* Your SignalR app is hosted on `http://signalr.example.com`

CORS should be configured in the SignalR app to only allow the origin `www.example.com`.

For more information on configuring CORS, see [Enable Cross-Origin Requests (CORS)](xref:security/cors). SignalR **requires** the following CORS policies:

* Allow the specific expected origins. Allowing any origin is possible but is **not** secure or recommended.
* HTTP methods `GET` and `POST` must be allowed.
* Credentials must be allowed in order for cookie-based sticky sessions to work correctly. They must be enabled even when authentication isn't used.

However, in 5.0 we have provided an option in the TypeScript client to not use credentials.
The option to not use credentials should only be used when you know 100% that credentials like Cookies are not needed in your app (cookies are used by azure app service when using multiple servers for sticky sessions).

For example, the following highlighted CORS policy allows a SignalR browser client hosted on `https://example.com` to access the SignalR app hosted on `https://signalr.example.com`:

[!code-csharp[Main](~/signalr/security/sample/SignalR_CORS6-8/Program.cs?name=snippet_AddCors&highlight=7-16)]

## WebSocket Origin Restriction

The protections provided by CORS don't apply to WebSockets. For origin restriction on WebSockets, read [WebSockets origin restriction](xref:fundamentals/websockets#websocket-origin-restriction).

## ConnectionId

Exposing `ConnectionId` can lead to malicious impersonation if the SignalR server or client version is ASP.NET Core 2.2 or earlier. If the SignalR server and client version are ASP.NET Core 3.0 or later, the `ConnectionToken` rather than the `ConnectionId` must be kept secret. The `ConnectionToken` is purposely not exposed in any API.  It can be difficult to ensure that older SignalR clients aren't connecting to the server, so even if your SignalR server version is ASP.NET Core 3.0 or later, the `ConnectionId` shouldn't be exposed.

## Access token logging

When using WebSockets or Server-Sent Events, the browser client sends the access token in the query string. Receiving the access token via query string is generally as secure as using the standard `Authorization` header. Always use HTTPS to ensure a secure end-to-end connection between the client and the server. Many web servers log the URL for each request, including the query string. Logging the URLs may log the access token. ASP.NET Core logs the URL for each request by default, which includes the query string. For example:

```output
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[1]
      Request starting HTTP/1.1 GET http://localhost:5000/chathub?access_token=1234
```

If you have concerns about logging this data with your server logs, you can disable this logging entirely by configuring the `Microsoft.AspNetCore.Hosting` logger to the `Warning` level or above (these messages are written at `Info` level). For more information, see [Apply log filter rules in code](xref:fundamentals/logging/index#apply-log-filter-rules-in-code) for more information. If you still want to log certain request information, you can [write middleware](xref:fundamentals/middleware/write) to log the data that you require and filter out the `access_token` query string value (if present).

## Exceptions

Exception messages are generally considered sensitive data that shouldn't be revealed to a client. By default, SignalR doesn't send the details of an exception thrown by a hub method to the client. Instead, the client receives a generic message indicating an error occurred. Exception message delivery to the client can be overridden (for example in development or test) with [EnableDetailedErrors](xref:signalr/configuration#configure-server-options). Exception messages should not be exposed to the client in production apps.

## Buffer management

SignalR uses per-connection buffers to manage incoming and outgoing messages. By default, SignalR limits these buffers to 32 KB. The largest message a client or server can send is 32 KB. The maximum memory consumed by a connection for messages is 32 KB. If your messages are always smaller than 32 KB, you can reduce the limit, which:

* Prevents a client from being able to send a larger message.
* The server will never need to allocate large buffers to accept messages.

If your messages are larger than 32 KB, you can increase the limit. Increasing this limit means:

* The client can cause the server to allocate large memory buffers.
* Server allocation of large buffers may reduce the number of concurrent connections.

There are limits for incoming and outgoing messages, both can be configured on the [HttpConnectionDispatcherOptions](xref:signalr/configuration#configure-server-options) object configured in `MapHub`:

* `ApplicationMaxBufferSize` represents the maximum number of bytes from the client that the server buffers. If the client attempts to send a message larger than this limit, the connection may be closed.
* `TransportMaxBufferSize` represents the maximum number of bytes the server can send. If the server attempts to send a message (including return values from hub methods) larger than this limit, an exception will be thrown.

Setting the limit to `0` disables the limit. Removing the limit allows a client to send a message of any size. Malicious clients sending large messages can cause excess memory to be allocated. Excess memory usage can significantly reduce the number of concurrent connections.

:::moniker-end

[!INCLUDE[](~/signalr/security/includes/security7.md)]

[!INCLUDE[](~/signalr/security/includes/security6.md)]

[!INCLUDE[](~/signalr/security/includes/security2.1-5.md)]
