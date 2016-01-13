using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using Microsoft.AspNet.Localization;
using System.Globalization;

namespace WebLoc
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddLocalization(options => options.ResourcesPath = "My/Resources");

    // Register the IStringLocalizerFactory
    // services.AddTransient<IStringLocalizer<Startup>, StringLocalizerFactory >();
}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
    ILoggerFactory loggerFactory, IStringLocalizer<Startup> SR)
{
    loggerFactory.AddConsole(Configuration.GetSection("Logging"));
    loggerFactory.AddDebug();

    if (env.IsDevelopment())
    {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
    }

    app.UseStaticFiles();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });

    var CultureInfoList = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("en-AU"),
            new CultureInfo("en-GB"),
            new CultureInfo("es-ES"),
            new CultureInfo("ja-JP"),
            new CultureInfo("fr-FR"),
            new CultureInfo("zh"),
            new CultureInfo("zh-CN"),
            new CultureInfo("zh-CHT")
        };

    var options = new RequestLocalizationOptions
    {
        // Set options here to change middleware behavior
        SupportedCultures = CultureInfoList,
        SupportedUICultures = CultureInfoList
    };

    app.UseRequestLocalization(options, defaultRequestCulture: new RequestCulture("en-US"));
}

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
    
}
