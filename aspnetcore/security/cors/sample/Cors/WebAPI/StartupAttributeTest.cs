using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// All the xxxTest.cs are used only for testing and not in the cors.md file.

namespace WebAPI
{
    public class StartupAttributeTest
    {
        public StartupAttributeTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://example.com",
                                        "http://www.contoso.com",
                                         // Never use localhost in a production app.
                                         // localhost is used for testing only.
                                         "https://localhost:5001");
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

}
