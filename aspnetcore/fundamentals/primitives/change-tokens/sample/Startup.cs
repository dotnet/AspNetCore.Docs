using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ChangeTokenSample.Data;
using static ChangeTokenSample.ChangeTokens.ChangeTokens;

namespace ChangeTokenSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IConfiguration config, IHostingEnvironment env)
        {
            SetupChangeTokens(config, env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
