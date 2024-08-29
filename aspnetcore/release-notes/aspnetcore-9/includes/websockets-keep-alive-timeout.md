### Keep-Alive Timeout for WebSockets

The [WebSockets middleware](https://learn.microsoft.com/aspnet/core/fundamentals/websockets#configure-the-middleware) can now be configured for keep-alive timeouts.

The keep-alive timeout aborts the WebSocket connection and throws an exception from `WebSocket.ReceiveAsync` if both of the following conditions are met:

* The server sends a ping frame using the websocket protocol.
* The client doesn't reply with a pong frame within the specified timeout.

The server automatically sends the ping frame and configures it with `KeepAliveInterval`. 

The keep-alive timeout setting is useful for detecting connections that might be slow or ungracefully disconnected.

The keep-alive timeout can be configured globally for the WebSocket middleware:

[!code-csharp[](~/release-notes/aspnetcore-9/samples/WebSocketsKeepAliveTimeoutExample/Program.cs?name=snippet_WebSocket_KeepAliveTimeout_Global)]

Or configured per accepted WebSocket:

[!code-csharp[](~/release-notes/aspnetcore-9/samples/WebSocketsKeepAliveTimeoutExample/Program.cs?name=snippet_KeepAliveTimeout_Per_Accepted_WebSocket)]
