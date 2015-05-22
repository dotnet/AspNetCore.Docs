using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace CorsExamples
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }

        // Shows UseCos with CorsPolicyBuilder
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.WithOrigins("http://example.com"));

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
