using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using PrimeWeb.Services;

namespace PrimeWeb
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                if (context.Request.Path.Value.Contains("checkprime"))
                {
                    int numberToCheck;
                    try
                    {
                        numberToCheck = int.Parse(context.Request.QueryString.Value.Replace("?",""));
                        var primeService = new PrimeService();
                        if (primeService.IsPrime(numberToCheck))
                        {
                            await context.Response.WriteAsync(numberToCheck + " is prime!");
                        }
                        else
                        {
                            await context.Response.WriteAsync(numberToCheck + " is NOT prime!");
                        }
                    }
                    catch
                    {
                        await context.Response.WriteAsync("Pass in a number to check in the form /checkprime?5");
                    }
                }
                else
                {
                    await context.Response.WriteAsync("Hello World!");
                }
            });
        }
    }
}
