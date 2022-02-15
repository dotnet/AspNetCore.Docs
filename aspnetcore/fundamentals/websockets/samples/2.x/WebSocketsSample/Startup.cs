#define UseOptions // or NoOptions or UseOptionsAO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;

namespace EchoApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddConsole()
                    .AddDebug()
                    .AddFilter<ConsoleLoggerProvider>(category: null, level: LogLevel.Debug)
                    .AddFilter<DebugLoggerProvider>(category: null, level: LogLevel.Debug);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

#if NoOptions
            // <snippet_UseWebSockets>
            app.UseWebSockets();
            // </snippet_UseWebSockets>
#endif
#if UseOptions
            // <snippet_UseWebSocketsOptions>
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
            };

            app.UseWebSockets(webSocketOptions);
            // </snippet_UseWebSocketsOptions>
#endif

#if UseOptionsAO
            // <snippet_UseWebSocketsOptionsAO>
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
            };
            webSocketOptions.AllowedOrigins.Add("https://client.com");
            webSocketOptions.AllowedOrigins.Add("https://www.client.com");

            app.UseWebSockets(webSocketOptions);
            // </snippet_UseWebSocketsOptionsAO>
#endif

            // <snippet_AcceptWebSocket>
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
                        {
                            await Echo(context, webSocket);
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    await next();
                }

            });
            // </snippet_AcceptWebSocket>
            app.UseFileServer();
        }
        // <snippet_Echo>
        private async Task Echo(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        // </snippet_Echo>
    }
}
