using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI
{
    #region snippet
    public class StartupTestMultiPolicy
    {
        public StartupTestMultiPolicy(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                       
                        policy.WithOrigins("http://example.com",
                                            "https://localhost:5001",
                                            "https://localhost:44375",
                                            "http://www.contoso.com");
                    });

                options.AddPolicy("AnotherPolicy",
                    policy =>
                    {
                        policy.WithOrigins("http://www.contoso.com",
                                            "https://localhost:44375",
                                            "https://localhost:5001")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
    #endregion
}
