using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MissingDIExtensions
{
    public static class AspNetCoreExtensions
    {
        public static void AddRequestScopingMiddleware(this IServiceCollection services,
            Func<IDisposable> requestScopeProvider)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (requestScopeProvider == null)
            {
                throw new ArgumentNullException(nameof(requestScopeProvider));
            }

            services.AddSingleton<IStartupFilter>(new RequestScopingStartupFilter(requestScopeProvider));
        }
        
        public static T GetRequestService<T>(this IApplicationBuilder builder) where T : class
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            return GetRequestServiceProvider(builder).GetService<T>();
        }

        public static T GetRequiredRequestService<T>(this IApplicationBuilder builder) where T : class
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            return GetRequestServiceProvider(builder).GetRequiredService<T>();
        }

        private static IServiceProvider GetRequestServiceProvider(IApplicationBuilder builder)
        {
            var accessor = builder.ApplicationServices.GetService<IHttpContextAccessor>();

            if (accessor == null)
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture,
                        "Type '{0}' is not available in the IApplicationBuilder.ApplicationServices collection. " +
                        "Please make sure it is registered by adding it to the ConfigureServices method " +
                        "as follows: services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();",
                        typeof(IHttpContextAccessor).FullName));
            }

            var context = accessor.HttpContext;

            if (context == null)
            {
                throw new InvalidOperationException(
                    "No HttpContext. Please make sure this method is called in the context of an active HTTP request.");
            }

            return context.RequestServices;
        }

        private sealed class RequestScopingStartupFilter : IStartupFilter
        {
            private readonly Func<IDisposable> requestScopeProvider;

            public RequestScopingStartupFilter(Func<IDisposable> requestScopeProvider)
            {
                if (requestScopeProvider == null) throw new ArgumentNullException(nameof(requestScopeProvider));

                this.requestScopeProvider = requestScopeProvider;
            }

            public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> nextFilter)
            {
                return builder =>
                {
                    ConfigureRequestScoping(builder);

                    nextFilter(builder);
                };
            }

            private void ConfigureRequestScoping(IApplicationBuilder builder)
            {
                builder.Use(async (context, next) =>
                {
                    using (var scope = this.requestScopeProvider())
                    {
                        await next();
                    }
                });
            }
        }
    }
}
