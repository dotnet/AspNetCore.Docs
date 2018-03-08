using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HttpSysSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        #region snippet1
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILogger<Startup> logger)
        {
            app.Use(async (context, next) =>
            {
                context.Features.Get<IHttpMaxRequestBodySizeFeature>()
                    .MaxRequestBodySize = 10 * 1024;

                var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();
                var addresses = string.Join(", ", serverAddressesFeature?.Addresses);

                logger.LogInformation($"Addresses: {addresses}");

                await next.Invoke();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
        #endregion
    }
}
