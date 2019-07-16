using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnvironmentsSample
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
            StartupConfigureServices(services);
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            StartupConfigureServices(services);
        }

        private void StartupConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        #region snippet
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvc();
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
            app.UseMvc();
        }
    }
    #endregion
}