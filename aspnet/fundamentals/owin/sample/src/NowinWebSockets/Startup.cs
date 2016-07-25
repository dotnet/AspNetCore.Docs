using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace NowinWebSockets
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await EchoWebSocket(webSocket);
                }
                else
                {
                    await next();
                }
            });

            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello World");
            });
        }

        private async Task EchoWebSocket(WebSocket webSocket)
        {
            byte[] buffer = new byte[1024];
            WebSocketReceiveResult received = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!webSocket.CloseStatus.HasValue)
            {
                // Echo anything we receive
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, received.Count), 
                    received.MessageType, received.EndOfMessage, CancellationToken.None);

                received = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), 
                    CancellationToken.None);
            }

            await webSocket.CloseAsync(webSocket.CloseStatus.Value, 
                webSocket.CloseStatusDescription, CancellationToken.None);
        }
    }
}