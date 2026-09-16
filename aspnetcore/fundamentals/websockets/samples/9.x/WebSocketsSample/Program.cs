var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// <snippet_WebSocket_KeepAliveTimeout_Global>
app.UseWebSockets(new WebSocketOptions { KeepAliveTimeout = TimeSpan.FromSeconds(15) });
// </snippet_WebSocket_KeepAliveTimeout_Global>

app.UseDefaultFiles();
app.UseStaticFiles();

app.Map("/ws", async (HttpContext context) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        // <snippet_KeepAliveTimeout_Per_Accepted_WebSocket>
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync(
            new WebSocketAcceptContext { KeepAliveTimeout = TimeSpan.FromSeconds(15) });
        // </snippet_KeepAliveTimeout_Per_Accepted_WebSocket>

        await Echo(webSocket);
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
});

static async Task Echo(System.Net.WebSockets.WebSocket webSocket)
{
    var buffer = new byte[1024 * 4];
    var receiveResult = await webSocket.ReceiveAsync(
        new ArraySegment<byte>(buffer), CancellationToken.None);

    while (!receiveResult.CloseStatus.HasValue)
    {
        await webSocket.SendAsync(
            new ArraySegment<byte>(buffer, 0, receiveResult.Count),
            receiveResult.MessageType,
            receiveResult.EndOfMessage,
            CancellationToken.None);

        receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);
    }

    await webSocket.CloseAsync(
        receiveResult.CloseStatus.Value,
        receiveResult.CloseStatusDescription,
        CancellationToken.None);
}

app.MapControllers();

app.Run();
