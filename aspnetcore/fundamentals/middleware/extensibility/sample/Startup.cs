using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Middleware;

namespace MiddlewareExtensibilitySample
{
    public class Startup
    {
        private readonly AsyncLocal<Scope> scopeProvider = new AsyncLocal<Scope>();
        private object RequestScope(IContext context) => scopeProvider.Value;

        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDB"));

            services.AddScoped<MiddlewareViaConventionalActivation>();
            services.AddScoped<MiddlewareViaIMiddlewareFactoryActivation>();

            services.AddMvc();
        }
        #endregion

        #region snippet2
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            IKernelConfiguration config = new KernelConfiguration();
            config.Bind<IMiddlewareFactory>().To<BasicMiddlewareFactory>().InScope(RequestScope);

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
        #endregion

        private sealed class Scope : DisposableObject { }
    }

    public static class BindingHelpers
    {
        public static void BindToMethod<T>(this IKernelConfiguration config, Func<T> method) => config.Bind<T>().ToMethod(c => method());
    }
}
