using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
// <snippet_HubsNamespace>
using SignalRWebPack.Hubs;
// </snippet_HubsNamespace>

namespace SignalRWebPack
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // <snippet_AddSignalR>
            services.AddSignalR();
            // </snippet_AddSignalR>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // <snippet_UseStaticDefaultFiles>
            app.UseDefaultFiles();
            app.UseStaticFiles();
            // </snippet_UseStaticDefaultFiles>

            // <snippet_UseSignalR>
            app.UseSignalR(options =>
            {
                options.MapHub<ChatHub>("/hub");
            });
            // </snippet_UseSignalR>
        }
    }
}
