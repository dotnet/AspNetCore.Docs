using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SessionSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        #region snippet1
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                logger.LogInformation($"Before setting: Verified: {context.Items["isVerified"]}");
                context.Items["isVerified"] = true;
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation($"Next: Verified: {context.Items["isVerified"]}");
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Verified: {context.Items["isVerified"]}");
                });
            });
        }
        #endregion
    }
}
