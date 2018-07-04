using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ResponseCacheSample
{
    public class Startup
    {
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        #endregion

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

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
