using System.Net.WebSockets;

namespace WebSocketsSample.Snippets;

public static class Program
{
    public static void UseWebSockets(WebApplication app)
    {
        // <snippet_UseWebSockets>
        app.UseWebSockets();
        // </snippet_UseWebSockets>
    }

    public static void AcceptWebSocketAsync(WebApplication app)
    {
        // <snippet_AcceptWebSocketAsync>
        app.Use(async (context, next) =>
        {
            if (context.Request.Path == "/ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await Echo(webSocket);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
            }
            else
            {
                await next(context);
            }

        });
        // </snippet_AcceptWebSocketAsync>
    }

    public static void AcceptWebSocketAsyncBackgroundSocketProcessor(WebApplication app)
    {
        // <snippet_AcceptWebSocketAsyncBackgroundSocketProcessor>
        app.Run(async (context) =>
        {
            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            var socketFinishedTcs = new TaskCompletionSource<object>();

            BackgroundSocketProcessor.AddSocket(webSocket, socketFinishedTcs);

            await socketFinishedTcs.Task;
        });
        // </snippet_AcceptWebSocketAsyncBackgroundSocketProcessor>
    }

    public static void UseWebSocketsOptionsAllowedOrigins(WebApplication app)
    {
        // <snippet_UseWebSocketsOptionsAllowedOrigins>
        var webSocketOptions = new WebSocketOptions
        {
            KeepAliveInterval = TimeSpan.FromMinutes(2)
        };

        webSocketOptions.AllowedOrigins.Add("https://client.com");
        webSocketOptions.AllowedOrigins.Add("https://www.client.com");

        app.UseWebSockets(webSocketOptions);
        // </snippet_UseWebSocketsOptionsAllowedOrigins>
    }

    // <snippet_Echo>
    private static async Task Echo(WebSocket webSocket)
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
    // </snippet_Echo>
}
