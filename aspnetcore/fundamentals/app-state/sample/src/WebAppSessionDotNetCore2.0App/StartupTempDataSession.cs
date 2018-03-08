using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class StartupTempDataSession
{
    public StartupTempDataSession(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    #region snippet_TempDataSession
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .AddSessionStateTempDataProvider();

        services.AddSession();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseSession();
        app.UseMvcWithDefaultRoute();
    }
    #endregion
}