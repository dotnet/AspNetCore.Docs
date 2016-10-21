//#define UseMe
#if UseMe
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UsingOptions
{
    #region snippet1
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Register the ConfigurationBuilder instance which MyOptions binds against.
            services.AddSingleton<MyOptions>();

            // Add framework services.
            services.AddMvc();
        }
        #endregion
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
#endif