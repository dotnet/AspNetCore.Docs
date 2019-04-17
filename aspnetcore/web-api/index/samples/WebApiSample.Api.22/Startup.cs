using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiSample.DataAccess;
using WebApiSample.DataAccess.Repositories;

#region snippet_ApiControllerAttributeOnAssembly
[assembly: ApiController]
namespace WebApiSample.Api._22
{
    public class Startup
    {
        #endregion snippet_ApiControllerAttributeOnAssembly
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

            #region snippet_ConfigureApiBehaviorOptions
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;

                    options.ClientErrorMapping[404].Link =
                        "https://httpstatuses.com/404";
                });
            #endregion
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
}
