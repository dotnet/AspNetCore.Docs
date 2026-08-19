#define KEEP_ALIVE_GLOBAL   //KEEP_ALIVE_PER_WEBSOCKET

#if KEEP_ALIVE_GLOBAL

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// <snippet_WebSocket_KeepAliveTimeout_Global>
app.UseWebSockets(new WebSocketOptions { KeepAliveTimeout = TimeSpan.FromSeconds(15) });
// </snippet_WebSocket_KeepAliveTimeout_Global>

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();

#elif KEEP_ALIVE_PER_WEBSOCKET

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// Configured per accepted WebSocket:
// <snippet_KeepAliveTimeout_Per_Accepted_WebSocket>
app.Run(async (context) =>
{
    using var webSocket = await context.WebSockets.AcceptWebSocketAsync(
        new WebSocketAcceptContext { KeepAliveTimeout = TimeSpan.FromSeconds(15) });

    // ...
});
// </snippet_KeepAliveTimeout_Per_Accepted_WebSocket>

#endif
