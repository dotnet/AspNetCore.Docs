using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Middleware;

namespace MiddlewareExtensibilitySample
{
    public class Startup
    {
        private Container _container = new Container();

        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Replace the default middleware factory with the 
            // SimpleInjectorMiddlewareFactory. Pass in the 
            // Simple Injector container when the factory is
            // instantiated.
            services.AddTransient<IMiddlewareFactory>(_ =>
            {
                return new SimpleInjectorMiddlewareFactory(_container);
            });

            // Wraps ASP.NET requests in an 
            // SimpleInjector.Lifestyles.AsyncScopedLifestyle.
            services.UseSimpleInjectorAspNetRequestScoping(_container);

            // Provide the AppDbContext from the Simple Injector
            // container whenever it's requested from the default
            // service container.
            services.AddScoped<AppDbContext>(provider => 
                _container.GetInstance<AppDbContext>());

            // Sets the default scoped lifestyle that the 
            // container should use when a registration is made 
            // using SimpleInjector.Lifestyle.Scoped.
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register the AppDbContext in the Simple Injector
            // container. Use an options builder to specify the
            // use of an in-memory database.
            _container.Register<AppDbContext>(() => 
            {
                var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                return new AppDbContext(optionsBuilder.Options);
            }, Lifestyle.Scoped);

            // Register the middleware with the Simple Injector 
            // container.
            _container.Register<SimpleInjectorActivatedMiddleware>();

            // Verifies and diagnoses the container instance.
            _container.Verify();
        }
        #endregion

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
            }

            app.UseSimpleInjectorActivatedMiddleware();

            app.UseStaticFiles();
            app.UseMvc();
        }
        #endregion
    }
}
