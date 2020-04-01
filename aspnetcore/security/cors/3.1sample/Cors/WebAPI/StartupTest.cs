using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    #region snippet2
    public class StartupTest
    {
        public StartupTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        #region snippet
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://example.com",
                            "http://www.contoso.com",
                            "https://cors1.azurewebsites.net",
                            "https://cors3.azurewebsites.net",
                            "https://localhost:44398",
                            "https://localhost:5001")
                                .WithMethods("PUT", "DELETE", "GET");
                    });
            });

            services.AddControllers();
            services.AddRazorPages();
        }
        #endregion

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
    #endregion
}
