using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Middleware;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace MiddlewareExtensibilitySample
{
    public class Startup
    {
        private Container container = new Container();

        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddTransient<IMiddlewareMiddleware>();
            services.AddTransient<IMiddlewareFactory, SimpleInjectorMiddlewareFactory>();

            services.AddMvc();

            IntegrateSimpleInjector(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services) {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }
        #endregion

        #region snippet3
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);

            container.Verify();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseIMiddlewareMiddleware();

            app.UseStaticFiles();
            app.UseMvc();
        }
        #endregion

        #region snippet2
        private void InitializeContainer(IApplicationBuilder app) {
            container.Register<AppDbContext>(() => {
                var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                return new AppDbContext(optionsBuilder.Options);
            }, Lifestyle.Scoped);

            container.Register<IMiddlewareMiddleware>();
            
            container.Register<SimpleInjectorMiddlewareFactory>();
        }
        #endregion
    }
}
