using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BackgroundTasksSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BackgroundTasksSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region snippet1
            services.AddSingleton<IHostedService, TimedHostedService>();
            #endregion

            #region snippet2
            services.AddSingleton<IHostedService, ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
            #endregion

            #region snippet3
            services.AddSingleton<IHostedService, QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}
