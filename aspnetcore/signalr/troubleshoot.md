---
title: ASP.NET Core SignalR connection troubleshooting
author: bradygaster
description: ASP.NET Core SignalR connection troubleshooting.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 04/08/2020
uid: signalr/troubleshoot
---
# Troubleshoot connection errors

This section provides help with errors that can occur when trying to establish a connection to an ASP.NET Core SignalR hub.

### Response code 404

When using WebSockets and `skipNegotiation = true`
```log
WebSocket connection to 'wss://xxx/HubName' failed: Error during WebSocket handshake: Unexpected response code: 404
```

* When using multiple servers without sticky sessions, the connection can start on one server and then switch to another server. The other server is not aware of the previous connection.
* Verify the client is connecting to the correct endpoint. For example, the server is hosted at `http://127.0.0.1:5000/hub/myHub` and client is trying to connect to `http://127.0.0.1:5000/myHub`.
* If the connection uses the ID and takes too long to send a request to the server after the negotiate, the server:

  * Deletes the ID.
  * Returns a 404.

### Response code 400 or 503

For the following error:

```log
WebSocket connection to 'wss://xxx/HubName' failed: Error during WebSocket handshake: Unexpected response code: 400

Error: Failed to start the connection: Error: There was an error with the transport.
```

This error is usually caused by a client using only the WebSockets transport but the WebSocket protocol isn't enabled on the server.

### Response code 307

When using WebSockets and `skipNegotiation = true`
```log
WebSocket connection to 'ws://xxx/HubName' failed: Error during WebSocket handshake: Unexpected response code: 307
```

This error can also happen during the negotiate request.

Common cause:
* App is configured to enforce HTTPS by calling `UseHttpsRedirection` in `Startup`, or enforces HTTPS via URL rewrite rule.

Possible solution:
* Change the URL on the client side from "http" to "https". `.withUrl("https://xxx/HubName")`

### Response code 405

Http status code 405 - Method Not Allowed

* The app doesn't have [CORS](xref:signalr/security#cross-origin-resource-sharing) enabled

### Response code 0

Http status code 0 - Usually a [CORS](xref:signalr/security#cross-origin-resource-sharing) issue, no status code is given

```log
Cross-Origin Request Blocked: The Same Origin Policy disallows reading the remote resource at http://localhost:5000/default/negotiate?negotiateVersion=1. (Reason: CORS header 'Access-Control-Allow-Origin' missing).
```

* Add the expected origins to `.WithOrigins(...)`

```log
Cross-Origin Request Blocked: The Same Origin Policy disallows reading the remote resource at http://localhost:5000/default/negotiate?negotiateVersion=1. (Reason: expected 'true' in CORS header 'Access-Control-Allow-Credentials').
```

* Add `.AllowCredentials()` to your CORS policy. Cannot use `.AllowAnyOrigin()` or `.WithOrigins("*")` with this option

### Response code 413

Http status code 413 - Payload Too Large

This is often caused by having an access token that is over 4k.

* If using the Azure SignalR Service, reduce the token size by customizing the claims being sent through the Service with:
```csharp
.AddAzureSignalR(options =>
{
    options.ClaimsProvider = context => context.User.Claims;
});
```

### Transient network failures

Transient network failures may close the SignalR connection. The server may interpret the closed connection as a graceful client disconnect. To get more info on why a client disconnected in those cases [gather logs from the client and server](xref:signalr/diagnostics).

## Additional resources

* [SignalR Hub Protocol](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/HubProtocol.md)
