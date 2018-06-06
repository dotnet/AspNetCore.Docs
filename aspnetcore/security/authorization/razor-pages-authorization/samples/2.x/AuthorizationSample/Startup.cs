using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorizationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region snippet1
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/Contact");
                    options.Conventions.AuthorizeFolder("/Private");
                    options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
                    options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
        }

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
    }
}
