using System;
using System.ComponentModel;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MissingDIExtensions;
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
        private IReadOnlyKernel Kernel { get; set; }

        private object Resolve(Type type) => Kernel.Get(type);
        private object RequestScope(IContext context) => scopeProvider.Value;

        private readonly Container container = new Container();

        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDB"));

            services.AddScoped<MiddlewareViaConventionalActivation>();
            services.AddScoped<MiddlewareViaIMiddlewareFactoryActivation>();

            services.AddMvc();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddRequestScopingMiddleware(() => scopeProvider.Value = new Scope());
            services.AddCustomControllerActivation(Resolve);
            services.AddCustomViewComponentActivation(Resolve);
        }
        #endregion

        #region snippet2
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            Kernel = RegisterApplicationComponents(app, loggerFactory);

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

        #region snippet3
        private IReadOnlyKernel RegisterApplicationComponents(IApplicationBuilder app, 
            ILoggerFactory loggerFactory)
        {
            IKernelConfiguration config = new KernelConfiguration();

            // Register application services
            foreach (var ctrlType in app.GetControllerTypes())
            {
                config.Bind(ctrlType).ToSelf().InScope(RequestScope);
            }

            config.Bind<IMiddlewareFactory>().To<BasicMiddlewareFactory>().InScope(RequestScope);

            // Cross-wire required framework services
            config.BindToMethod(app.GetRequestService<IViewBufferScope>);
            config.Bind<ILoggerFactory>().ToConstant(loggerFactory);

            return config.BuildReadonlyKernel();
        }
        #endregion

        private sealed class Scope : DisposableObject { }
    }

    public static class BindingHelpers
    {
        public static void BindToMethod<T>(this IKernelConfiguration config, Func<T> method) => config.Bind<T>().ToMethod(c => method());
    }
}
