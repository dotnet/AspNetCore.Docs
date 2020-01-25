#region snippet_1
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
}

public void Configure(IApplicationBuilder app)
{
    app.UseRouting();

    app.UseGrpcWeb();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<GreeterService>().EnableGrpcWeb();
    });
}
#endregion
