#define THIRD // FIRST SECOND THIRD
#if NEVER
#elif FIRST
#region snippet
using GrpcServiceHC.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcHealthChecks()
                .AddCheck("Sample", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGrpcHealthChecksService();

// Code removed for brevity.
#endregion

app.MapGet("/", () => "Communication with gRPC endpoints must be made through"
          + "a gRPC client. To learn how to create a client, visit:"
          +"https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
#elif SECOND
#region snippet2
using GrpcServiceHC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcHealthChecks(o =>
{
    o.Services.MapService("", r => r.Tags.Contains("public"));
});

var app = builder.Build();

// Code removed for brevity.
#endregion
app.MapGrpcService<GreeterService>();
app.MapGrpcHealthChecksService();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through"
          + "a gRPC client. To learn how to create a client, visit:"
          +"https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
#elif THIRD
#region snippet3
using GrpcServiceHC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
// No overload for method 'AddGrpcHealthChecks' takes 1 arguments	
  builder.Services.AddGrpcHealthChecks(o =>
  {
      o.Services.MapService("greet.Greeter", r => r.Tags.Contains("greeter"));
      o.Services.MapService("count.Counter", r => r.Tags.Contains("counter"));
  });

var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGrpcHealthChecksService();

// Code removed for brevity.
#endregion

app.MapGet("/", () => "Communication with gRPC endpoints must be made through"
          + "a gRPC client. To learn how to create a client, visit:"
          +"https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
#endif
