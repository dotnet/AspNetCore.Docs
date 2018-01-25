using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddScoped<MiddlewareViaIMiddlewareFactoryActivation>();

            services.AddMvc();

            IntegrateSimpleInjector(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services) {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }
        #endregion

        #region snippet2
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);

            container.Register<MiddlewareViaIMiddlewareFactoryActivation>();

            container.Verify();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseMiddlewareViaConventionalActivation();
            app.UseMiddlewareViaIMiddlewareFactoryActivation();

            app.UseStaticFiles();
            app.UseMvc();
        }

        private void InitializeContainer(IApplicationBuilder app) {
            // Add application services.
            container.Register<AppDbContext>(() => {
                var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                return new AppDbContext(optionsBuilder.Options);
            }, Lifestyle.Scoped);
        }
        #endregion
    }
}
