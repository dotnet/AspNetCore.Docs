#region snippet_1
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();

    services.AddCors(o => o.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
    }));
}

public void Configure(IApplicationBuilder app)
{
    app.UseRouting();

    app.UseGrpcWeb();
    app.UseCors();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<GreeterService>().EnableGrpcWeb()
                                                  .RequireCors("AllowAll");
    });
}
#endregion
