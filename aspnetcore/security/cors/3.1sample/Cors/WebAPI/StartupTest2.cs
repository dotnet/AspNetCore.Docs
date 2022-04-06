using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI
{
    #region snippet2
    public class StartupTest2
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    policy =>
                    {
                        policy.WithOrigins("http://example.com",
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

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

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
