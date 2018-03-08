using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApp1
{
    #region snippet_all
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        #region snippet
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
        #endregion

        public void ConfigureStaging(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsStaging())
            {
                throw new Exception("Not staging.");
            }

            app.UseExceptionHandler("/Error");
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
    #endregion
}