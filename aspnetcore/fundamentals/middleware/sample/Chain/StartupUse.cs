// TODO remove, no longer used. This is bad code.
//#define Use
#if Use
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
                await context.Response.WriteAsync("Hello from first delegate");
                //  next.Invoke() Not called, so app.Run never called.
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