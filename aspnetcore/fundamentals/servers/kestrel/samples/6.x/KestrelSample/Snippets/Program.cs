using System.Net;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
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
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
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

    public static void ConfigureKestrel(string[] args)
    {
        // <snippet_ConfigureKestrel>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            // ...
        });
        // </snippet_ConfigureKestrel>
    }

    public static void ConfigureKestrelLimitsKeepAliveTimeout(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelLimitsKeepAliveTimeout>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
        });
        // </snippet_ConfigureKestrelLimitsKeepAliveTimeout>
    }

    public static void ConfigureKestrelLimitsMaxConcurrentConnections(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelLimitsMaxConcurrentConnections>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.MaxConcurrentConnections = 100;
        });
        // </snippet_ConfigureKestrelLimitsMaxConcurrentConnections>
    }

    public static void ConfigureKestrelLimitsMaxConcurrentUpgradedConnections(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelLimitsMaxConcurrentUpgradedConnections>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
        });
        // </snippet_ConfigureKestrelLimitsMaxConcurrentUpgradedConnections>
    }

    public static void ConfigureKestrelLimitsMaxRequestBodySize(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelLimitsMaxRequestBodySize>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.MaxRequestBodySize = 100_000_000;
        });
        // </snippet_ConfigureKestrelLimitsMaxRequestBodySize>
    }

    public static void IHttpMaxRequestBodySizeFeatureMiddleware(WebApplication app)
    {
        // <snippet_IHttpMaxRequestBodySizeFeatureMiddleware>
        app.Use(async (context, next) =>
        {
            var httpMaxRequestBodySizeFeature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();

            if (httpMaxRequestBodySizeFeature is not null)
                httpMaxRequestBodySizeFeature.MaxRequestBodySize = 10 * 1024;

            // ...

            await next(context);
        });
        // </snippet_IHttpMaxRequestBodySizeFeatureMiddleware>
    }

    public static void ConfigureKestrelLimitsMinDataRates(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelLimitsMinDataRates>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.MinRequestBodyDataRate = new MinDataRate(
                bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
            serverOptions.Limits.MinResponseDataRate = new MinDataRate(
                bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
        });
        // </snippet_ConfigureKestrelLimitsMinDataRates>
    }

    public static void DataRateFeaturesMiddleware(WebApplication app)
    {
        // <snippet_DataRateFeaturesMiddleware>
        app.Use(async (context, next) =>
        {
            var httpMinRequestBodyDataRateFeature = context.Features
                .Get<IHttpMinRequestBodyDataRateFeature>();

            if (httpMinRequestBodyDataRateFeature is not null)
            {
                httpMinRequestBodyDataRateFeature.MinDataRate = new MinDataRate(
                    bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
            }

            var httpMinResponseDataRateFeature = context.Features
                .Get<IHttpMinResponseDataRateFeature>();

            if (httpMinResponseDataRateFeature is not null)
            {
                httpMinResponseDataRateFeature.MinDataRate = new MinDataRate(
                    bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
            }

            // ...

            await next(context);
        });
        // </snippet_DataRateFeaturesMiddleware>
    }

    public static void ConfigureKestrelLimitsRequestHeadersTimeout(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelLimitsRequestHeadersTimeout>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
        });
        // </snippet_ConfigureKestrelLimitsRequestHeadersTimeout>
    }

    public static void ConfigureKestrelHttp2LimitsMaxStreamsPerConnection(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelHttp2LimitsMaxStreamsPerConnection>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.Http2.MaxStreamsPerConnection = 100;
        });
        // </snippet_ConfigureKestrelHttp2LimitsMaxStreamsPerConnection>
    }

    public static void ConfigureKestrelHttp2LimitsHeaderTableSize(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelHttp2LimitsHeaderTableSize>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.Http2.HeaderTableSize = 4096;
        });
        // </snippet_ConfigureKestrelHttp2LimitsHeaderTableSize>
    }

    public static void ConfigureKestrelHttp2LimitsMaxFrameSize(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelHttp2LimitsMaxFrameSize>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.Http2.MaxFrameSize = 16_384;
        });
        // </snippet_ConfigureKestrelHttp2LimitsMaxFrameSize>
    }

    public static void ConfigureKestrelHttp2LimitsMaxRequestHeaderFieldSize(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelHttp2LimitsMaxRequestHeaderFieldSize>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.Http2.MaxRequestHeaderFieldSize = 8192;
        });
        // </snippet_ConfigureKestrelHttp2LimitsMaxRequestHeaderFieldSize>
    }

    public static void ConfigureKestrelHttp2LimitsInitialConnectionWindowSize(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelHttp2LimitsInitialConnectionWindowSize>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.Http2.InitialConnectionWindowSize = 131_072;
        });
        // </snippet_ConfigureKestrelHttp2LimitsInitialConnectionWindowSize>
    }

    public static void ConfigureKestrelHttp2LimitsInitialStreamWindowSize(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelHttp2LimitsInitialStreamWindowSize>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.Http2.InitialStreamWindowSize = 98_304;
        });
        // </snippet_ConfigureKestrelHttp2LimitsInitialStreamWindowSize>
    }

    public static void ConfigureKestrelHttp2LimitsKeepAlivePings(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelHttp2LimitsKeepAlivePings>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.Http2.KeepAlivePingDelay = TimeSpan.FromSeconds(30);
            serverOptions.Limits.Http2.KeepAlivePingTimeout = TimeSpan.FromMinutes(1);
        });
        // </snippet_ConfigureKestrelHttp2LimitsKeepAlivePings>
    }

    public static void ConfigureKestrelAllowSynchronousIO(WebApplicationBuilder builder)
    {
        // <snippet_ConfigureKestrelAllowSynchronousIO>
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.AllowSynchronousIO = true;
        });
        // </snippet_ConfigureKestrelAllowSynchronousIO>
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
