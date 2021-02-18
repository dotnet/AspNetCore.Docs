using ContosoUniversity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ContosoUniversity
{
    public class StartupMaxMBsize
    {
        public StartupMaxMBsize(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            int MyMaxModelBindingCollectionSize = 100;
            Int32.TryParse(Configuration["MyMaxModelBindingCollectionSize"],
                                       out MyMaxModelBindingCollectionSize);
            
            services.Configure<MvcOptions>(options => 
                   options.MaxModelBindingCollectionSize = MyMaxModelBindingCollectionSize);

            services.AddRazorPages();

            services.AddDbContext<SchoolContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));

            services.AddDatabaseDeveloperPageExceptionFilter();
        }
        #endregion

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
