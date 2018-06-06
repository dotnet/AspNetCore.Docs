using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BackgroundTasksSample.Services;
using Microsoft.Extensions.Hosting;

namespace BackgroundTasksSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

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
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
