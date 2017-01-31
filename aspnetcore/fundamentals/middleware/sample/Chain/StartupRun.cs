// TODO remove, no longer used. Sample to obvious, no value and Use approach is bad code.
//#define Run
#if Run
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

#region snippet1
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hello from first delegate");
        });
    }
}
#endregion
#endif