using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ConfigurationSample.Extensions;

namespace ConfigurationSample
{
    #region snippet_Startup
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var arrayDict = new Dictionary<string, string>
            {
                {"array:entries:0", "value0"},
                {"array:entries:1", "value1"},
                {"array:entries:2", "value2"},
                {"array:entries:4", "value4"},
                {"array:entries:5", "value5"}
            };

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddInMemoryCollection(arrayDict)
                .AddJsonFile("json_array.json", optional: false, reloadOnChange: false)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, 
                    reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddJsonFile("starship.json", optional: false, reloadOnChange: false)
                .AddXmlFile("tvshow.xml", optional: false, reloadOnChange: false)
                .AddEFConfiguration(options => options.UseInMemoryDatabase("InMemoryDb"))
                .AddCommandLine(Program.Args);

            Configuration = builder.Build();
        }
    #endregion

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole()
                .AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
