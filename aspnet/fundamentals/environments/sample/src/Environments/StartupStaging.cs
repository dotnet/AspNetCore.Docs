using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace Environments
{
    public class StartupStaging
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Staging environment.");
            });
        }
    }
}
