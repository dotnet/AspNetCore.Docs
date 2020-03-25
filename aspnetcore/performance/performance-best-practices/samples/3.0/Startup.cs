using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using performance_best_practices.Controllers;
using System;
using System.Threading.Tasks;

namespace performance_best_practices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SearchService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class SearchService : IDisposable 
    {
        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task<SearchResults> Search(SearchEngine engine, string query)
        {
            throw new NotImplementedException();
        }

        public async Task<SearchResults> Empty()
        {
            throw new NotImplementedException();
        }

        internal Task<Task<SearchResults>> SearchAsync(SearchEngine engine, string query)
        {
            throw new NotImplementedException();
        }
    }
}
