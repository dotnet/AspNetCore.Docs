using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

public class StartupCopy
{
    #region snippet1
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.CookieName = ".AdventureWorks.Session";
            options.IdleTimeout = TimeSpan.FromSeconds(10);
        });

        services.AddMvc();
    }
    #endregion

    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
        app.UseMvcWithDefaultRoute();
    }
}
