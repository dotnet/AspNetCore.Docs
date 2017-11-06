using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorizationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            #region snippet1
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/Contact");
                    options.Conventions.AuthorizeFolder("/Private");
                    options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
                    options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
                });
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
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
