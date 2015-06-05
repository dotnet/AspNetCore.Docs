using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace aaa
{
    // This Startup class is not used because the other one is in the project namespace
    // Change the namespace of the other Startup class to "bbb" and this one will be used.
    // Alternately, change this class's namespace to "StartupDemo" (and the other to anything else)
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World from Startup - Copy.cs!");
            });
        }
    }
}
