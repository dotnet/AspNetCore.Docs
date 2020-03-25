using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppPartsSample
{
    public class StartupRemove
    {
        public StartupRemove(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet
        public void ConfigureServices(IServiceCollection services)
        {
            var pluginAssembly = Assembly.Load(new AssemblyName("Plugin"));
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddApplicationPart(pluginAssembly)
                .ConfigureApplicationPartManager(p =>
                {
                    var dependentLibrary = p.ApplicationParts
                                .FirstOrDefault(part => part.Name == "DependentLibrary");
                    if (dependentLibrary != null)
                    {
                        p.ApplicationParts.Remove(dependentLibrary);
                    }
                })
                .ConfigureApplicationPartManager(p => 
                   p.FeatureProviders.Add(new GenericControllerFeatureProvider())); 
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
