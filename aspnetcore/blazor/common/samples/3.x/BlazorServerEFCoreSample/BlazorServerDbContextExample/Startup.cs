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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // register factory and configure the options
            #region snippet1
            services.AddDbContextFactory<ContactContext>(opt =>
                opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db"));
            #endregion

            // pager
            services.AddScoped<IPageHelper, PageHelper>();

            // filters
            services.AddScoped<IContactFilters, GridControls>();

            // query adapter (applies filter to contact request).
            services.AddScoped<GridQueryAdapter>();

            // service to communicate success on edit between pages
            services.AddScoped<EditSuccess>();
        }

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
