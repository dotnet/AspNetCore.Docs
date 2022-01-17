#region snippet_1
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
    services.AddGrpcHealthChecks();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseRouting();
    
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<GreeterService>();
        endpoints.MapGrpcHealthChecksService();
    });
}
#endregion
