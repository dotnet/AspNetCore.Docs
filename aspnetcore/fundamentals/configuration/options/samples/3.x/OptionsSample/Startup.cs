using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.Models;

namespace SampleApp
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add the service required for using options.
            services.AddOptions();

            // <snippet_Example1>
            // Example #1: General configuration
            // Register the Configuration instance which MyOptions binds against.
            services.Configure<MyOptions>(Configuration);
            // </snippet_Example1>

            // <snippet_Example2>
            // Example #2: Options bound and configured by a delegate
            services.Configure<MyOptionsWithDelegateConfig>(myOptions =>
            {
                myOptions.Option1 = "value1_configured_by_delegate";
                myOptions.Option2 = 500;
            });
            // </snippet_Example2>

            // <snippet_Example3>
            // Example #3: Suboptions
            // Bind options using a sub-section of the appsettings.json file.
            services.Configure<MySubOptions>(Configuration.GetSection("subsection"));
            // </snippet_Example3>

            // <snippet_Example6>
            // Example #6: Named options (named_options_1)
            // Register the ConfigurationBuilder instance which MyOptions binds against.
            // Specify that the options loaded from configuration are named
            // "named_options_1".
            services.Configure<MyOptions>("named_options_1", Configuration);

            // Example #6: Named options (named_options_2)
            // Specify that the options loaded from the MyOptions class are named
            // "named_options_2".
            // Use a delegate to configure option values.
            services.Configure<MyOptions>("named_options_2", myOptions =>
            {
                myOptions.Option1 = "named_options_2_value1_from_action";
            });
            // </snippet_Example6>

            services.AddRazorPages();
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
