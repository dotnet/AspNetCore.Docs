using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

/// <summary>
/// This sample demonstrates an IOptionsSnapshot being created on the first request
/// after config.json changes. TimeOptions is bound to config.json, but TimeOptions
/// won't be recreated unless the config file changes.  Hit the server and verify 
/// the creation time is unchanged between requests.  Modify config.json and the 
/// time will be updated on the next request.
/// </summary>
namespace Config.Options.Snapshot.Web
{
    #region snippet1
    public class TimeOptions
    {
        // Records the time when the options are created.
        public DateTime CreationTime { get; set; } = DateTime.Now;

        // Bound to config. Changes to the value of "Message"
        // in config.json will be reflected in this property.
        public string Message { get; set; }
    }

    public class Controller
    {
        public readonly TimeOptions _options;

        public Controller(IOptionsSnapshot<TimeOptions> options)
        {
            _options = options.Value;
        }

        public Task DisplayTimeAsync(HttpContext context)
        {
            return context.Response.WriteAsync(_options.Message + _options.CreationTime);
        }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // reloadOnChange: true is required for config changes to be detected.
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            // Simple mockup of a simple per request controller that writes
            // the creation time and message of TimeOptions.
            app.Run(DisplayTimeAsync);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Simple mockup of a simple per request controller.
            services.AddScoped<Controller>();

            // Binds config.json to the options and setups the change tracking.
            services.Configure<TimeOptions>(Configuration.GetSection("Time"));
        }

        public Task DisplayTimeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            return context.RequestServices.GetRequiredService<Controller>().DisplayTimeAsync(context);
        }

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
    #endregion
}