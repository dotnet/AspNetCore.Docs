using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using PrimeWeb.Services;

namespace PrimeWeb.Middleware
{
    public static class PrimeCheckerExtensions
    {
        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder,
            PrimeCheckerOptions options)
        {
            if(builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            var primeService = builder.ApplicationServices.GetService(typeof (PrimeService)) as PrimeService;
            return builder.Use(next => new PrimeCheckerMiddleware(next, options, primeService).Invoke);
        }

        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder,
            PathString path)
        {
            return UsePrimeChecker(builder, new PrimeCheckerOptions { Path = path });
        }
        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder,
            string path)
        {
            return UsePrimeChecker(builder, new PrimeCheckerOptions { Path = new PathString(path) });
        }

        public static IApplicationBuilder UsePrimeChecker(this IApplicationBuilder builder)
        {
            return UsePrimeChecker(builder, 
                new PrimeCheckerOptions()
                {
                    Path = new PathString("/checkprime")
                });
        }
    }
}
