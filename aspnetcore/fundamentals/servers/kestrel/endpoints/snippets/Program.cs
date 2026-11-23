#!/usr/bin/env -S dotnet --
#:sdk Microsoft.NET.Sdk.Web
#:property PublishAot=false

using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

// Dynamically bind to an available port on loopback:
builder.WebHost.UseUrls("http://127.0.0.1:0");

var app = builder.Build();

// <snippet_IServerAddressesFeature>
var serverAddressesFeature = app.Services.GetRequiredService<IServer>()
                                .Features.GetRequiredFeature<IServerAddressesFeature>();

app.MapGet("/", () =>
    $"Server listening on: {string.Join(", ", serverAddressesFeature.Addresses)}");
// </snippet_IServerAddressesFeature>

app.Run();
