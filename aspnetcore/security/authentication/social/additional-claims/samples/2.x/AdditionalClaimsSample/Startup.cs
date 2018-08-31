using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data;
using WebApp.Services;

namespace WebApp
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
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext>(options => 
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            #region snippet_AddGoogle
            services.AddAuthentication().AddGoogle(options =>
            {
                // Provide the Google Client ID
                options.ClientId = "XXXXXXXXXXX.apps.googleusercontent.com";
                // Provide the Google Secret
                options.ClientSecret = "g4GZ2#...GD5Gg1x";
                options.Scope.Add("https://www.googleapis.com/auth/plus.login");
                options.ClaimActions.MapJsonKey(ClaimTypes.Gender, "gender");
                options.SaveTokens = true;
                options.Events.OnCreatingTicket = ctx =>
                {
                    List<AuthenticationToken> tokens = ctx.Properties.GetTokens() 
                        as List<AuthenticationToken>;
                    tokens.Add(new AuthenticationToken()
                    {
                        Name = "TicketCreated", 
                        Value = DateTime.UtcNow.ToString()
                    });
                    ctx.Properties.StoreTokens(tokens);
                    return Task.CompletedTask;
                };
            });
            #endregion

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                    options.Conventions.AuthorizePage("/MyClaims");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            services.AddSingleton<IEmailSender, EmailSender>();
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
    }
}
