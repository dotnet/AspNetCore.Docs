using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace WebAPI
{
    public class Startup7
    {
        public Startup7(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
               
                options.AddPolicy("AllowHeaders",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com",
                                            "http://www.contoso.com",
                                            "https://localhost:44398",
                                            "https://localhost:5001")
                               .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                               .WithMethods("PUT","DELETE")
                               ;
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

            app.UseRouting();

            app.UseCors("AllowHeaders");

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
