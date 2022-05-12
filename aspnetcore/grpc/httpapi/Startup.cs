#region snippet_1
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc().AddJsonTranscoding();
}

public void Configure(IApplicationBuilder app)
{
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<GreeterService>();
    });
}
#endregion
