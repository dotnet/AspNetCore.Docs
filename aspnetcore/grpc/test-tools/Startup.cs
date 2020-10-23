#region snippet_1
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
    services.AddGrpcReflection();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseRouting();
    
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<GreeterService>();

        if (env.IsDevelopment())
        {
            endpoints.MapGrpcReflectionService();
        }
    });
}
#endregion
