#define PrimarySample
#if PrimarySample
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Chain
{
    #region snippet1
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Handling request. <p>");
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 2nd delegate. <p>");
            });
        }
    }
    #endregion
}
#endif