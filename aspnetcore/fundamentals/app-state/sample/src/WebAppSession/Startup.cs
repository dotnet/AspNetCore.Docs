using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        // Adds a default in-memory implementation of IDistributedCache.
        services.AddDistributedMemoryCache();

        services.AddSession(o =>
        {
            // Set a short timeout for easy testing.
            o.IdleTimeout = TimeSpan.FromSeconds(10);
            o.CookieHttpOnly = true;
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
        app.UseMvcWithDefaultRoute();
    }
}
