using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    // Use the `--scenario db` switch to run this version of the sample.
    //
    // Register Health Check Middleware at the URL: /health
    //
    // By default, health checks return a 200-Ok with 'Healthy' when the database is responsive.
    // - A BeatPulse SQL Server health check is used in the example for a SQL database. For more information on BeatPulse, see https://github.com/Xabaril/BeatPulse.
    // - The default response writer writes the HealthStatus as text/plain content.
    //
    // This approach is suitable for systems that check for 'liveness' of an app with a database.

    public class DbHealthStartup
    {
        public DbHealthStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // <snippet_ConfigureServices>
            services.AddHealthChecks()
                .AddSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            // </snippet_ConfigureServices>
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");

                endpoints.MapGet("/{**path}", async context =>
                {
                    await context.Response.WriteAsync(
                        "Navigate to /health to see the health status.");
                });
            });
        }
    }
}
