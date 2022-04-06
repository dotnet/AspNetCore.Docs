using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPIendPt
{
    // Not used in Testing, just for the snippet.
    // StartupEndPt.cs
    #region snippet2
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://example.com",
                                                          "http://www.contoso.com");
                                  });
            });

            services.AddControllers();
            services.AddRazorPages();
        }

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/echo",
                    context => context.Response.WriteAsync("echo"))
                    .RequireCors(MyAllowSpecificOrigins);

                endpoints.MapControllers()
                         .RequireCors(MyAllowSpecificOrigins);

                endpoints.MapGet("/echo2",
                    context => context.Response.WriteAsync("echo2"));

                endpoints.MapRazorPages();
            });
        }
    }
    #endregion
}
