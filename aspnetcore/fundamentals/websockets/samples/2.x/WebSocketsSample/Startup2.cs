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
    public class Startup2
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

            // <snippet_AcceptWebSocket>
            app.Use(async (context, next) =>
            {
                using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
                {
                    var socketFinishedTcs = new TaskCompletionSource<object>();

                    BackgroundSocketProcessor.AddSocket(webSocket, socketFinishedTcs);

                    await socketFinishedTcs.Task;
                }
            });
            // </snippet_AcceptWebSocket>
            app.UseFileServer();
        }
    }

    internal class BackgroundSocketProcessor
    {
        internal static void AddSocket(WebSocket socket, TaskCompletionSource<object> socketFinishedTcs)
        {
            throw new NotImplementedException();
        }
    }
}
