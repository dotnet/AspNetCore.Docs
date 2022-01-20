using System.Net;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;

namespace KestrelSample.Snippets;

public static class Program
{
    public static void ConfigureEndpointDefaults(string[] args)
    {
        // <snippet_ConfigureEndpointDefaults>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ConfigureEndpointDefaults(listenOptions =>
            {
                // ...
            });
        });
        // </snippet_ConfigureEndpointDefaults>
    }

    public static void ConfigureHttpsDefaults(string[] args)
    {
        // <snippet_ConfigureHttpsDefaults>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ConfigureHttpsDefaults(listenOptions =>
            {
                // ...
            });
        });
        // </snippet_ConfigureHttpsDefaults>
    }

    public static void ConfigurationLoader(string[] args)
    {
        // <snippet_ConfigurationLoader>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            var kestrelSection = context.Configuration.GetSection("Kestrel");

            serverOptions.Configure(kestrelSection)
                .Endpoint("HTTPS", listenOptions =>
                {
                    // ...
                });
        });
        // </snippet_ConfigurationLoader>
    }

    public static void ConfigureEndpointDefaultsConfigureHttpsDefaults(string[] args)
    {
        // <snippet_ConfigureEndpointDefaultsConfigureHttpsDefaults>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.ConfigureEndpointDefaults(listenOptions =>
            {
                // ...
            });

            serverOptions.ConfigureHttpsDefaults(listenOptions =>
            {
                // ...
            });
        });
        // </snippet_ConfigureEndpointDefaultsConfigureHttpsDefaults>
    }

    public static void ServerCertificateSelector(string[] args)
    {
        // <snippet_ServerCertificateSelector>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenAnyIP(5005, listenOptions =>
            {
                listenOptions.UseHttps(httpsOptions =>
                {
                    var localhostCert = CertificateLoader.LoadFromStoreCert(
                        "localhost", "My", StoreLocation.CurrentUser,
                        allowInvalid: true);
                    var exampleCert = CertificateLoader.LoadFromStoreCert(
                        "example.com", "My", StoreLocation.CurrentUser,
                        allowInvalid: true);
                    var subExampleCert = CertificateLoader.LoadFromStoreCert(
                        "sub.example.com", "My", StoreLocation.CurrentUser,
                        allowInvalid: true);
                    var certs = new Dictionary<string, X509Certificate2>(
                        StringComparer.OrdinalIgnoreCase)
                    {
                        ["localhost"] = localhostCert,
                        ["example.com"] = exampleCert,
                        ["sub.example.com"] = subExampleCert
                    };

                    httpsOptions.ServerCertificateSelector = (connectionContext, name) =>
                    {
                        if (name is not null && certs.TryGetValue(name, out var cert))
                        {
                            return cert;
                        }

                        return exampleCert;
                    };
                });
            });
        });
        // </snippet_ServerCertificateSelector>
    }

    public static void ServerOptionsSelectionCallback(string[] args)
    {
        // <snippet_ServerOptionsSelectionCallback>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenAnyIP(5005, listenOptions =>
            {
                listenOptions.UseHttps(httpsOptions =>
                {
                    var localhostCert = CertificateLoader.LoadFromStoreCert(
                        "localhost", "My", StoreLocation.CurrentUser,
                        allowInvalid: true);
                    var exampleCert = CertificateLoader.LoadFromStoreCert(
                        "example.com", "My", StoreLocation.CurrentUser,
                        allowInvalid: true);

                    listenOptions.UseHttps((stream, clientHelloInfo, state, cancellationToken) =>
                    {
                        if (string.Equals(clientHelloInfo.ServerName, "localhost",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            return new ValueTask<SslServerAuthenticationOptions>(
                                new SslServerAuthenticationOptions
                                {
                                    ServerCertificate = localhostCert,
                                    // Different TLS requirements for this host
                                    ClientCertificateRequired = true
                                });
                        }

                        return new ValueTask<SslServerAuthenticationOptions>(
                            new SslServerAuthenticationOptions
                            {
                                ServerCertificate = exampleCert
                            });
                    }, state: null!);
                });
            });
        });
        // </snippet_ServerOptionsSelectionCallback>
    }

    public static void TlsHandshakeCallbackOptions(string[] args)
    {
        // <snippet_TlsHandshakeCallbackOptions>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenAnyIP(5005, listenOptions =>
            {
                listenOptions.UseHttps(httpsOptions =>
                {
                    var localhostCert = CertificateLoader.LoadFromStoreCert(
                        "localhost", "My", StoreLocation.CurrentUser,
                        allowInvalid: true);
                    var exampleCert = CertificateLoader.LoadFromStoreCert(
                        "example.com", "My", StoreLocation.CurrentUser,
                        allowInvalid: true);

                    listenOptions.UseHttps(new TlsHandshakeCallbackOptions
                    {
                        OnConnection = context =>
                        {
                            if (string.Equals(context.ClientHelloInfo.ServerName, "localhost",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                // Different TLS requirements for this host
                                context.AllowDelayedClientCertificateNegotation = true;

                                return new ValueTask<SslServerAuthenticationOptions>(
                                    new SslServerAuthenticationOptions
                                    {
                                        ServerCertificate = localhostCert
                                    });
                            }

                            return new ValueTask<SslServerAuthenticationOptions>(
                                new SslServerAuthenticationOptions
                                {
                                    ServerCertificate = exampleCert
                                });
                        }
                    });
                });
            });
        });
        // </snippet_TlsHandshakeCallbackOptions>
    }

    public static void ConfigureHttpsDefaultsSslProtocols(string[] args)
    {
        // <snippet_ConfigureHttpsDefaultsSslProtocols>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ConfigureHttpsDefaults(listenOptions =>
            {
                listenOptions.SslProtocols = SslProtocols.Tls13;
            });
        });
        // </snippet_ConfigureHttpsDefaultsSslProtocols>
    }

    public static void ConfigureHttpsDefaultsClientCertificateMode(string[] args)
    {
        // <snippet_ConfigureHttpsDefaultsClientCertificateMode>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ConfigureHttpsDefaults(listenOptions =>
            {
                listenOptions.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
            });
        });
        // </snippet_ConfigureHttpsDefaultsClientCertificateMode>
    }

    public static void ConfigureKestrelUseConnectionLogging(string[] args)
    {
        // <snippet_ConfigureKestrelUseConnectionLogging>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
            {
                listenOptions.UseConnectionLogging();
            });
        });
        // </snippet_ConfigureKestrelUseConnectionLogging>
    }

    public static void Listen(string[] args)
    {
        // <snippet_Listen>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.Listen(IPAddress.Loopback, 5000);
            serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
            {
                listenOptions.UseHttps("testCert.pfx", "testPassword");
            });
        });
        // </snippet_Listen>
    }

    public static void ListenUnixSocket(string[] args)
    {
        // <snippet_ListenUnixSocket>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock");
            serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock", listenOptions =>
            {
                listenOptions.UseHttps("testCert.pfx", "testpassword");
            });
        });
        // </snippet_ListenUnixSocket>
    }

    public static void IServerAddressesFeature(WebApplication app)
    {
#pragma warning disable CS1998
        // <snippet_IServerAddressesFeature>
        app.Run(async (context) =>
        {
            var serverAddressFeature = context.Features.Get<IServerAddressesFeature>();

            if (serverAddressFeature is not null)
            {
                var listenAddresses = string.Join(", ", serverAddressFeature.Addresses);

                // ...
            }
        });
        // </snippet_IServerAddressesFeature>
#pragma warning restore CS1998
    }

    public static void ConfigureKestrelProtocols(string[] args)
    {
        // <snippet_ConfigureKestrelProtocols>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
            {
                listenOptions.UseHttps("testCert.pfx", "testPassword");
            });
        });
        // </snippet_ConfigureKestrelProtocols>
    }

    public static void ConfigureHttpsDefaultsCipherSuitesPolicy(string[] args)
    {
        // <snippet_ConfigureHttpsDefaultsCipherSuitesPolicy>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.ConfigureHttpsDefaults(listenOptions =>
            {
                listenOptions.OnAuthenticate = (context, sslOptions) =>
                {
                    sslOptions.CipherSuitesPolicy = new CipherSuitesPolicy(
                        new[]
                        {
                            TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256,
                            TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384,
                            // ...
                        });
                };
            });
        });
        // </snippet_ConfigureHttpsDefaultsCipherSuitesPolicy>
    }

    public static void ConfigureKestrelMiddleware(string[] args)
    {
        // <snippet_ConfigureKestrelMiddleware>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
            {
                listenOptions.UseHttps("testCert.pfx", "testPassword");

                listenOptions.Use((context, next) =>
                {
                    var tlsFeature = context.Features.Get<ITlsHandshakeFeature>()!;

                    if (tlsFeature.CipherAlgorithm == CipherAlgorithmType.Null)
                    {
                        throw new NotSupportedException(
                            $"Prohibited cipher: {tlsFeature.CipherAlgorithm}");
                    }

                    return next();
                });
            });
        });
        // </snippet_ConfigureKestrelMiddleware>
    }

    public static void Http3(string[] args)
    {
        // <snippet_Http3>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, options) =>
        {
            options.ListenAnyIP(5001, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                listenOptions.UseHttps();
            });
        });
        // </snippet_Http3>
    }
}
