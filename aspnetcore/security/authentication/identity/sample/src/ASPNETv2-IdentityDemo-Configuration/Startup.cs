using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication5.Data;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet_configureservices
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #region snippet_IdentityOptions
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = true; // Defaults to true, if this is omitted and not configured.
                    options.Password.RequiredLength = 8; // Defaults to 6, if this is omitted and not configured.
                    options.Password.RequireNonAlphanumeric = true; // Defaults to true, if this is omitted and not configured.
                    options.Password.RequireUppercase = true; // Defaults to true, if this is omitted and not configured.
                    options.Password.RequireLowercase = true; // Defaults to true, if this is omitted and not configured.
                    options.Password.RequiredUniqueChars = 2; // Defaults to 1, if this is omitted and not configured.

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Defaults to 5 minutes, if this is omitted and not configured.
                    options.Lockout.MaxFailedAccessAttempts = 5; // Defaults to 5, if this is omitted and not configured.
                    options.Lockout.AllowedForNewUsers = true; // Defaults to true, if this is omitted and not configured.

                    // Signin settings
                    options.SignIn.RequireConfirmedEmail = true; // Defaults to false, if this is omitted and not configured.
                    options.SignIn.RequireConfirmedPhoneNumber = false; // Defaults to false, if this is omitted and not configured.

                    // User settings
                    options.User.RequireUniqueEmail = true; // Defaults to false, if this is omitted and not configured.
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region snippet_ConfigureCookie
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "YourAppCookieName"; // Defaults to .AspNetCore.Cookies, if this is omitted and not configured.
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Defaults to 14 days, if this is omitted and not configured.
                options.Cookie.HttpOnly = true; // Defaults to true, if this is omitted and not configured.
                options.LoginPath = "/Account/Login"; // Defaults to /Account/Login, if this is omitted and not configured.
                options.LogoutPath = "/Account/Logout"; // Defaults to /Account/Logout, if this is omitted and not configured.
                options.AccessDeniedPath = "/Account/AccessDenied"; // Defaults to /Account/AccessDenied, if this is omitted and not configured.
                options.SlidingExpiration = true; // Defaults to true, if this is omitted and not configured.
            });
            #endregion

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }
        #endregion

        #region snippet_configure
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}
