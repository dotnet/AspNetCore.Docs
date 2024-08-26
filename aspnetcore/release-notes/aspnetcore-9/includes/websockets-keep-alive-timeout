### Keep-Alive Timeout for WebSockets

The [WebSockets middleware](https://learn.microsoft.com/aspnet/core/fundamentals/websockets#configure-the-middleware) can now be configured for keep alive timeouts.

The keep alive timeout will abort the WebSocket and throw from `WebSocket.ReceiveAsync` if a ping frame from the websocket protocol is sent by the server and the client doesn't reply with a pong frame within the specified timeout. The ping frame is automatically sent by the server and configured with `KeepAliveInterval`. This option is useful when wanting to detect connections that might be slow or ungracefully disconnected.

The keep alive timeout can be configured globally for the WebSocket middleware:
```csharp
app.UseWebSockets(new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(15) });
```

Or configured per accepted WebSocket:
```csharp
app.Run(async (context) =>
{
    using var webSocket = await context.WebSockets.AcceptWebSocketAsync(
        new WebSocketAcceptContext { KeepAliveTimeout = TimeSpan.FromSeconds(15) });

    // ...
}
```
