using ClientIpSafelistComponents.Filters;
using ClientIpSafelistComponents.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientIpAspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region snippet_ConfigureServicesActionFilter
            services.AddScoped<ClientIpCheckActionFilter>(container =>
            {
                var loggerFactory = container.GetRequiredService<ILoggerFactory>();
                return new ClientIpCheckActionFilter(Configuration)
                {
                    Logger = loggerFactory.CreateLogger<ClientIpCheckActionFilter>()
                };
            });
            #endregion snippet_ConfigureServicesActionFilter

            services.AddControllers();

            #region snippet_ConfigureServicesPageFilter
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    var clientIpCheckPageFilter = new ClientIpCheckPageFilter(Configuration)
                    {
                        Logger = LoggerFactory.Create(builder => builder.AddConsole())
                                    .CreateLogger<ClientIpCheckPageFilter>()
                    };
                    options.Filters.Add(clientIpCheckPageFilter);
                });
            #endregion snippet_ConfigureServicesPageFilter
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            #region snippet_ConfigureAddMiddleware
            app.UseMiddleware<AdminSafeListMiddleware>(Configuration["AdminSafeList"]);
            #endregion snippet_ConfigureAddMiddleware

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
