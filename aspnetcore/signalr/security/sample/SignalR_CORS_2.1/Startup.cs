#define snippet2 // snippet1
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SignalR_CORS
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

#if snippet1
        #region snippet1
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // ... other middleware ...

            // Make sure the CORS middleware is ahead of SignalR.
            app.UseCors(builder =>
            {
                builder.WithOrigins("https://example.com")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST")
                    .AllowCredentials();
            });

            // ... other middleware ...

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chathub");
            });

            // ... other middleware ...
        }

        #endregion
#endif
#if snippet2
        #region snippet2

        // In Startup, add a static field listing the allowed Origin values:
        private static readonly HashSet<string> _allowedOrigins = new HashSet<string>()
        {
            // Add allowed origins here. For example:
            "https://www.mysite.com",
            "https://mysite.com",
        };

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // ... other middleware ...

            // Validate Origin header on WebSocket requests to prevent unexpected cross-site 
            // WebSocket requests.
            app.Use((context, next) =>
            {
                // Check for a WebSocket request.
                if (string.Equals(context.Request.Headers["Upgrade"], "websocket"))
                {
                    var origin = context.Request.Headers["Origin"];

                    // If there is an origin header, and the origin header doesn't match 
                    // an allowed value:
                    if (!string.IsNullOrEmpty(origin) && !_allowedOrigins.Contains(origin))
                    {
                        // The origin is not allowed, reject the request
                        context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                        return Task.CompletedTask;
                    }
                }

                // The request is a valid Origin or not a WebSocket request, so continue.
                return next();
            });

            // ... other middleware ...

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chathub");
            });

            // ... other middleware ...
        }

        #endregion
#endif
    }

    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}


