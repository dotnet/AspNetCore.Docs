using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace WebAPI
{
    #region snippet2
    public class StartupEndPointBugTest
    {
        readonly string MyPolicy = "_myPolicy";

        // .WithHeaders(HeaderNames.ContentType, "x-custom-header")
        // forces browsers to require a preflight request with GET

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyPolicy,
                    policy =>
                    {
                        policy.WithOrigins("http://example.com",
                                            "http://www.contoso.com",
                                            "https://cors1.azurewebsites.net",
                                            "https://cors3.azurewebsites.net",
                                            "https://localhost:44398",
                                            "https://localhost:5001")
                               .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                               .WithMethods("PUT", "DELETE", "GET", "OPTIONS");
                    });
            });

            services.AddControllers();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyPolicy);
                endpoints.MapRazorPages();
            });
        }
    }
    #endregion
}
