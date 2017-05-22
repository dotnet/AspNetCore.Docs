using ContactManager.Authorization;
using ContactManager.Data;
using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContactManager
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnv;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            _hostingEnv = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        #region ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            #region snippet_SSL 
            var skipSSL = Configuration.GetValue<bool>("LocalTest:skipSSL");
            // requires using Microsoft.AspNetCore.Mvc;
            services.Configure<MvcOptions>(options =>
            {
            // Set LocalTest:skipSSL to true to skip SSL requrement in 
            // debug mode. This is useful when not using Visual Studio.
            if (_hostingEnv.IsDevelopment() && !skipSSL)
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                }
            });
            #endregion

            #region snippet_defaultPolicy
            // requires: using Microsoft.AspNetCore.Authorization;
            //           using Microsoft.AspNetCore.Mvc.Authorization;
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            #endregion           

            #region AuthorizationHandlers
            // Authorization handlers.
            services.AddScoped<IAuthorizationHandler,
                                  ContactIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ContactAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ContactManagerAuthorizationHandler>();
            #endregion
        }
        #endregion

        #region Configure
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvcWithDefaultRoute();

            // Set password with the Secret Manager tool.
            // dotnet user-secrets set SeedUserPW <pw>
            var testUserPw = Configuration["SeedUserPW"];

            if (String.IsNullOrEmpty(testUserPw))
            {
                throw new System.Exception("Use secrets manager to set SeedUserPW \n" +
                                           "dotnet user-secrets set SeedUserPW <pw>");
            }

            try
            {
                SeedData.Initialize(app.ApplicationServices, testUserPw).Wait();
            }
            catch
            {
                throw new System.Exception("You need to update the DB "
                    + "\nPM > Update-Database " + "\n or \n" +
                      "> dotnet ef database update"
                      + "\nIf that doesn't work, comment out SeedData and "
                      + "register a new user");
            }
            #endregion
        }
    }
}