using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;

// <snippet_ConfigureKestrelServerOptions>
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.ConfigureHttpsDefaults(options =>
        options.ClientCertificateMode = ClientCertificateMode.RequireCertificate);
});
// </snippet_ConfigureKestrelServerOptions>

builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate()
    .AddCertificateCache();

var app = builder.Build();

app.UseAuthentication();

app.MapGet("/", (ClaimsPrincipal claimsPrincipal) =>
    string.Join(
        Environment.NewLine,
        claimsPrincipal.Claims.Select(x => $"{x.Type}: {x.Value}")));

app.Run();
