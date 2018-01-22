using System;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CookieAuthWithIdentityCore.Data;
using CookieAuthWithIdentityCore.Models;
using CookieAuthWithIdentityCore.Services;

namespace CookieAuthWithIdentityCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDB"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #region snippet1
            services.ConfigureApplicationCookie(options => {
                var protectionProvider = DataProtectionProvider.Create(
                    new DirectoryInfo(GetKeyRingFolderPath()));

                options.Cookie.Name = ".AspNet.SharedCookie";
                options.DataProtectionProvider = protectionProvider;
                options.TicketDataFormat = 
                    new TicketDataFormat(
                        protectionProvider.CreateProtector(
                            "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", 
                            "Cookies", 
                            "v2"));
            });
            #endregion

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

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

        // For demonstration purposes only.
        // This method searches up the directory tree until it
        // finds the KeyRing folder in the sample. Using this
        // approach allows the sample to run from a Debug
        // or Release location within the bin folder.
        private string GetKeyRingFolderPath()
        {
            var startupAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var applicationBasePath = System.AppContext.BaseDirectory;
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                directoryInfo = directoryInfo.Parent;

                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, "KeyRing"));
                if (projectDirectoryInfo.Exists)
                {
                    return projectDirectoryInfo.FullName;
                }
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"KeyRing folder could not be located using the application root {applicationBasePath}.");
        }
    }
}
