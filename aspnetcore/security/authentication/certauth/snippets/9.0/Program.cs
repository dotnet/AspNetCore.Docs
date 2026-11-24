#!/usr/bin/env -S dotnet --
#:sdk Microsoft.NET.Sdk.Web
#:property PublishAot=false
#:property TargetFramework=net9.0
#:package Microsoft.AspNetCore.Authentication.Certificate@9.0.23

using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication.Certificate;

var builder = WebApplication.CreateBuilder(args);

    // <snippet_AddCertificateUseAuthentication>
    builder.Services.AddAuthentication(
            CertificateAuthenticationDefaults.AuthenticationScheme)
        .AddCertificate();
    // </snippet_AddCertificateUseAuthentication>

    // <snippet_AddCertificateOnCertificateValidated>
    builder.Services.AddAuthentication(
            CertificateAuthenticationDefaults.AuthenticationScheme)
        .AddCertificate(options =>
        {
            options.Events = new CertificateAuthenticationEvents
            {
                OnCertificateValidated = context =>
                {
                    var claims = new[]
                    {
                        new Claim(
                            ClaimTypes.NameIdentifier,
                            context.ClientCertificate.Subject,
                            ClaimValueTypes.String, context.Options.ClaimsIssuer),
                        new Claim(
                            ClaimTypes.Name,
                            context.ClientCertificate.Subject,
                            ClaimValueTypes.String, context.Options.ClaimsIssuer)
                    };

                    context.Principal = new ClaimsPrincipal(
                        new ClaimsIdentity(claims, context.Scheme.Name));
                    context.Success();

                    return Task.CompletedTask;
                }
            };
        });
        // </snippet_AddCertificateOnCertificateValidated>

    // <snippet_AddCertificateOnCertificateValidatedService>
    builder.Services.AddAuthentication(
            CertificateAuthenticationDefaults.AuthenticationScheme)
        .AddCertificate(options =>
        {
            options.Events = new CertificateAuthenticationEvents
            {
                OnCertificateValidated = context =>
                {
                    var validationService = context.HttpContext.RequestServices
                        .GetRequiredService<ICertificateValidationService>();

                    if (validationService.ValidateCertificate(context.ClientCertificate))
                    {
                        var claims = new[]
                        {
                            new Claim(
                                ClaimTypes.NameIdentifier,
                                context.ClientCertificate.Subject,
                                ClaimValueTypes.String, context.Options.ClaimsIssuer),
                            new Claim(
                                ClaimTypes.Name,
                                context.ClientCertificate.Subject,
                                ClaimValueTypes.String, context.Options.ClaimsIssuer)
                        };

                        context.Principal = new ClaimsPrincipal(
                            new ClaimsIdentity(claims, context.Scheme.Name));
                        context.Success();
                    }

                    return Task.CompletedTask;
                }
            };
        });
        // </snippet_AddCertificateOnCertificateValidatedService>

    // <snippet_AddCertificateForwarding>
    builder.Services.AddCertificateForwarding(options =>
    {
        options.CertificateHeader = "X-SSL-CERT";

        options.HeaderConverter = headerValue =>
        {
            X509Certificate2? clientCertificate = null;

            if (!string.IsNullOrWhiteSpace(headerValue))
            {
                clientCertificate = X509CertificateLoader.LoadCertificate(
                    StringToByteArray(headerValue));
            }

            return clientCertificate!;

            static byte[] StringToByteArray(string hex)
            {
                var numberChars = hex.Length;
                var bytes = new byte[numberChars / 2];

                for (int i = 0; i < numberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }

                return bytes;
            }
        };
    });
    // </snippet_AddCertificateForwarding>

    // <snippet_AddCertificateForwardingUrlEncoded>
    builder.Services.AddCertificateForwarding(options =>
    {
        options.CertificateHeader = "ssl-client-cert";

        options.HeaderConverter = (headerValue) =>
        {
            X509Certificate2? clientCertificate = null;

            if (!string.IsNullOrWhiteSpace(headerValue))
            {
                clientCertificate = X509Certificate2.CreateFromPem(
                    WebUtility.UrlDecode(headerValue));
            }

            return clientCertificate!;
        };
    });
    // </snippet_AddCertificateForwardingUrlEncoded>

    // <snippet_AddHttpClient>
    var clientCertificate =
        X509CertificateLoader.LoadPkcs12FromFile(
            Path.Combine(builder.Environment.ContentRootPath, "sts_dev_cert.pfx"), password: null);

    builder.Services.AddHttpClient("namedClient", c =>
    {
    }).ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(clientCertificate);
        return handler;
    });
    // </snippet_AddHttpClient>

    // <snippet_AddCertificateCaching>
    builder.Services.AddAuthentication(
            CertificateAuthenticationDefaults.AuthenticationScheme)
        .AddCertificate()
        .AddCertificateCache(options =>
        {
            options.CacheSize = 1024;
            options.CacheEntryExpiration = TimeSpan.FromMinutes(2);
        });
    // </snippet_AddCertificateCaching>

var app = builder.Build();

// <snippet_UseCertificateForwarding>
app.UseCertificateForwarding();
// </snippet_UseCertificateForwarding>

app.UseAuthentication();
app.UseAuthorization();

app.Run();

public interface ICertificateValidationService
{
    bool ValidateCertificate(X509Certificate2 clientCertificate);
}
