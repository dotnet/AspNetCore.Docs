//#define S1
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace policyschemes
{
    public class Startup
    {
#if S1
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => options.ForwardChallenge = "Google")
               .AddGoogle(options => { });
        }
        #endregion
#else
        #region snippet2
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    // For example, can foward any requests that start with /api 
                    // to the api scheme.
                    options.ForwardDefaultSelector = ctx => 
                       ctx.Request.Path.StartsWithSegments("/api") ? "Api" : null;
                })
                .AddYourApiAuth("Api");
        }
        #endregion
#endif

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
