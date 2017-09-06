//#define UseMe
#if UseMe
// Use with HomeController2.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UsingOptions.Models;

namespace UsingOptions
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method is called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds services required for using options.
            services.AddOptions();

            // Configure with Microsoft.Extensions.Options.ConfigurationExtensions
            // Binding the whole configuration should be rare, subsections are more typical.
            services.Configure<MyOptions>(Configuration);

            // Configure MyOptions using code.
            services.Configure<MyOptions>(myOptions =>
            {
                myOptions.Option1 = "value1_from_action";
            });

            // Configure using a sub-section of the appsettings.json file.
            services.Configure<MySubOptions>(Configuration.GetSection("subsection"));

            // Add framework services.
            services.AddMvc();
        }
        #endregion
        // This method is called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
#endif
