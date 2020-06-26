using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorServerDbContextExample.Data;
using Microsoft.EntityFrameworkCore;
using BlazorServerDbContextExample.Grid;

namespace BlazorServerDbContextExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // register factory and configure the options
            services.AddDbContextFactory<ContactContext>(opt =>
                opt.UseSqlServer(
                    Configuration.GetConnectionString(ContactContext.ContactsDb))
                .EnableSensitiveDataLogging());

            // pager
            services.AddScoped<IPageHelper, PageHelper>();

            // filters
            services.AddScoped<IContactFilters, GridControls>();

            // query adapter (applies filter to contact request).
            services.AddScoped<GridQueryAdapter>();

            // service to communicate success on edit between pages
            services.AddScoped<EditSuccess>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
