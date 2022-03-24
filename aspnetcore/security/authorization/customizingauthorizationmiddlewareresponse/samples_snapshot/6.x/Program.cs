using Microsoft.AspNetCore.Authorization;

// <snippet_Register>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<
    IAuthorizationMiddlewareResultHandler, SampleAuthorizationMiddlewareResultHandler>();

var app = builder.Build();
// </snippet_Register>

app.MapGet("/", () => "Hello World!");

app.Run();
