using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class StartupConstraint
    {
        public StartupConstraint(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(options =>
            {
                options.ConstraintMap.Add("customName", typeof(MyCustomConstraint));
            });
        }
        #endregion

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

    internal class MyCustomConstraint
    {
    }

    /* API Controller
        [HttpGet("{id:customName}")]
        public ActionResult<string> Get(string id)
        {
            return "OK";
        }
        */
}
