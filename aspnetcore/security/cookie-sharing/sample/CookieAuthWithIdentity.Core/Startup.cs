using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookieAuthWithIdentity.Core.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookieAuthWithIdentity.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            #region snippet1
            services.AddDataProtection()
                .PersistKeysToFileSystem(GetKeyRingDirInfo())
                .SetApplicationName("SharedCookieApp");

            services.ConfigureApplicationCookie(options => {
                options.Cookie.Name = ".AspNet.SharedCookie";
            });
            #endregion

            services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
                    options.Conventions.AuthorizePage("/Contact");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();
        }

        // For demonstration purposes only.
        // This method searches up the directory tree until it
        // finds the KeyRing folder in the sample. Using this
        // approach allows the sample to run from a Debug
        // or Release location within the bin folder.
        private DirectoryInfo GetKeyRingDirInfo()
        {
            var startupAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var applicationBasePath = System.AppContext.BaseDirectory;
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                directoryInfo = directoryInfo.Parent;

                var keyRingDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, "KeyRing"));
                if (keyRingDirectoryInfo.Exists)
                {
                    return keyRingDirectoryInfo;
                }
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"KeyRing folder could not be located using the application root {applicationBasePath}.");
        }
    }
}
