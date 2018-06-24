using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Build;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Middleware;

namespace MiddlewareExtensibilitySample
{
    public class Startup
    {
        readonly Container _container = new Container();

        #region snippet1

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Replace the default middleware factory with the
            // SimpleInjectorMiddlewareFactory.
            services.AddTransient<IMiddlewareFactory>(_ =>
            {
                return new BuildMiddlewareFactory(_container);
            });

            // Wrap ASP.NET requests in a Simple Injector execution
            // context.

            // Provide the database context from the Simple
            // Injector container whenever it's requested from
            // the default service container.
            services.AddScoped(provider => _container.CreateInstance<Lazy<AppDbContext>>().GetInstance());

            System.Func<AppDbContext> appDbContextFactoryFunction = () =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                return new AppDbContext(optionsBuilder.Options);
            };

            _container.RegisterType<Lazy<AppDbContext>>(appDbContextFactoryFunction);
            _container.RegisterType<BuildActivatedMiddleware>();
        }

        #endregion snippet1

        #region snippet2

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseBuildActivatedMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
        }

        #endregion snippet2
    }
}