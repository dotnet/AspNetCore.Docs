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

        // ...
        // </snippet_KeepAliveTimeout_Per_Accepted_WebSocket>
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
});

app.MapControllers();

app.Run();
