using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebApiSample.DataAccess;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api
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
            services.AddScoped<ProductsRepository>();
            services.AddScoped<PetsRepository>();

            services.AddDbContext<ProductContext>(opt =>
                opt.UseInMemoryDatabase("ProductInventory"));
            services.AddDbContext<PetContext>(opt =>
                opt.UseInMemoryDatabase("PetInventory"));

            #region snippet_SetCompatibilityVersion
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressConsumesConstraintForFormFileParameters = true;
                        options.SuppressInferBindingSourcesForParameters = true;
                        options.SuppressModelStateInvalidFilter = true;
                        options.SuppressMapClientErrors = true;

                        options.ClientErrorMapping[404] = "https://httpstatuses.com/404";
                    });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ASP.NET Core 2.1+ Web API",
                    Version = "v1"
                });
            });
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
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
