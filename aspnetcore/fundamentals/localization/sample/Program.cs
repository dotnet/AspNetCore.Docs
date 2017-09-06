using System.Globalization;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Localization.StarterWeb.Models;
using Localization.StarterWeb.Services;

namespace Localization.StarterWeb
{
    public class Program
    {
        private const string enUSCulture = "en-US";

        public static IConfiguration Configuration { get; set; }
        public static IHostingEnvironment Environment { get; set; }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    Configuration = config.Build();
                    Environment = hostingContext.HostingEnvironment;
                })
                .ConfigureServices(services =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
                    });

                    services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();
                    #region snippet1
                    services.AddLocalization(options => options.ResourcesPath = "Resources");

                    services.AddMvc()
                        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                        .AddDataAnnotationsLocalization();
                    #endregion
                    services.AddTransient<IEmailSender, AuthMessageSender>();
                    services.AddTransient<ISmsSender, AuthMessageSender>();

                    // Configure supported cultures and localization options
                    services.Configure<RequestLocalizationOptions>(options =>
                    {
                        var supportedCultures = new[]
                        {
                            new CultureInfo(enUSCulture),
                            new CultureInfo("fr")
                        };

                        // State what the default culture for your application is. This is used if no specific culture
                        // can be determined for a given request.
                        options.DefaultRequestCulture = new RequestCulture(culture: enUSCulture, uiCulture: enUSCulture);

                        // You must explicitly state which cultures your application supports.
                        // These are the cultures the app supports for formatting numbers, dates, etc.
                        options.SupportedCultures = supportedCultures;

                        // These are the cultures the app supports for UI strings (that we have localized resources for).
                        options.SupportedUICultures = supportedCultures;

                        // You can change which providers are configured to determine the culture for requests, or even add a custom
                        // provider with your own logic. The providers will be asked in order to provide a culture for each request,
                        // and the first to provide a non-null result that is in the configured supported cultures list will be used.
                        // By default, the following built-in providers are configured:
                        // - QueryStringRequestCultureProvider, sets culture via "culture" and "ui-culture" query string values, useful for testing
                        // - CookieRequestCultureProvider, sets culture via "ASPNET_CULTURE" cookie
                        // - AcceptLanguageHeaderRequestCultureProvider, sets culture via the "Accept-Language" request header
                        //
                        //options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
                        //{
                        //  // My custom request culture logic
                        //  return new ProviderCultureResult("en");
                        //}));
                    });
                })
                .Configure(app =>
                {
                    if (Environment.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                        app.UseDatabaseErrorPage();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Home/Error");

                        // For more details on creating database during deployment,
                        // see: http://go.microsoft.com/fwlink/?LinkID=615859
                        try
                        {
                            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                .CreateScope())
                            {
                                serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                                    .Database.Migrate();
                            }
                        }
                        catch { }
                    }
                    #region snippet2
                    var supportedCultures = new[]
                    {
                        new CultureInfo(enUSCulture),
                        new CultureInfo("en-AU"),
                        new CultureInfo("en-GB"),
                        new CultureInfo("en"),
                        new CultureInfo("es-ES"),
                        new CultureInfo("es-MX"),
                        new CultureInfo("es"),
                        new CultureInfo("fr-FR"),
                        new CultureInfo("fr"),
                    };

                    app.UseRequestLocalization(new RequestLocalizationOptions
                    {
                        DefaultRequestCulture = new RequestCulture(enUSCulture),
                        // Formatting numbers, dates, etc.
                        SupportedCultures = supportedCultures,
                        // UI strings that we have localized.
                        SupportedUICultures = supportedCultures
                    });

                    app.UseStaticFiles();
                    // To configure external authentication, 
                    // see: http://go.microsoft.com/fwlink/?LinkID=532715
                    app.UseAuthentication();
                    app.UseMvcWithDefaultRoute();
                    #endregion
                })
                .Build();
    }
}
