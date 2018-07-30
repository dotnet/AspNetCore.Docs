using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPatternSample.Interfaces;
using RepositoryPatternSample.Models;

namespace RepositoryPatternSample
{
    public class Startup
    {
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            // Add database services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase()
            );

            // Add framework services.
            services.AddMvc();

            // Register application services.
            services.AddScoped<ICharacterRepository, CharacterRepository>();
        }
        #endregion

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
