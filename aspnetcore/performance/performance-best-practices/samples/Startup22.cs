using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace PBP
{
    public class Startup22
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            #region snippet1
            app.Use(async (context, next) =>
            {
                await next();

                context.Response.Headers["test"] = "test value";
            });
            #endregion

            #region snippet2
            app.Use(async (context, next) =>
            {
                await next();

                if (!context.Response.HasStarted)
                {
                    context.Response.Headers["test"] = "test value";
                }
            });
            #endregion
            #region snippet3
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers["someheader"] = "somevalue";
                    return Task.CompletedTask;
                });

                await next();
            });
            #endregion
        }
    }
}
