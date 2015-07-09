using Kestrel;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Hosting.Server;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;
using Microsoft.Net.Http.Server;
using System;

namespace ServersDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, 
            IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var configBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddEnvironmentVariables();
            Configuration = configBuilder.Build();
        }
        public IConfiguration Configuration { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            var webListenerInfo = app.Server as Microsoft.AspNet.Server.WebListener.ServerInformation;
            if (webListenerInfo != null)
            {
                webListenerInfo.Listener.AuthenticationManager.AuthenticationSchemes =
                    AuthenticationSchemes.AllowAnonymous;
            }

            app.Run(async (context) =>
            {
                var message = String.Format("Hello World from {0}",
                                        ((IServerInformation)app.Server).Name);
                await context.Response.WriteAsync(message);
            });
        }
    }
}
