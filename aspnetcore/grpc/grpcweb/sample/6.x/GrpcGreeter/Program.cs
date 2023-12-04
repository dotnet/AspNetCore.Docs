#define GRPC_WEB_ENABLE_DEFAULT   // Options:  GRPC_WEB_ENABLE_DEFAULT | GRPC_WEB_ALL_SERVICES | GRPC_WEB_ENABLE_CORS

#if GRPC_WEB_ENABLE_DEFAULT 

// <snippet_WebEnable>
using GrpcGreeter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.UseGrpcWeb();

app.MapGrpcService<GreeterService>().EnableGrpcWeb();
app.MapGet("/", () => "This gRPC service is gRPC-Web enabled and is callable from browser apps uisng the gRPC-Web protocal");

app.Run();
// </snippet_WebEnable>
#endif

#if GRPC_WEB_ALL_SERVICES

// <snippet_WebEnableAllServices>
using GrpcGreeter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.MapGrpcService<GreeterService>().EnableGrpcWeb();
app.MapGet("/", () => "All gRPC service are supported by default in this example, and are callable from browser apps uisng the gRPC-Web protocal");

app.Run();
// </snippet_WebEnableAllServices>
#endif

#if GRPC_WEB_ENABLE_CORS
// <snippet_WebEnableCORS>
using GrpcGreeter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

var app = builder.Build();

app.UseGrpcWeb();
app.UseCors();

app.MapGrpcService<GreeterService>().EnableGrpcWeb()
                                    .RequireCors("AllowAll");

app.MapGet("/", () => "This gRPC service is gRPC-Web enabled, CORS enabled, and is callable from browser apps uisng the gRPC-Web protocal");

app.Run();
// </snippet_WebEnableCORS>
#endif
