using GrcpServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();

var app = builder.Build();

// <snippet_MapGrpcService>
app.MapGrpcService<GreeterService>();
// </snippet_MapGrpcService>

app.Run();
