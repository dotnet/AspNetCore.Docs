---
title: Configure endpoints for the ASP.NET Core Kestrel web server
author: rick-anderson
description: Learn about configuring endpoints with Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/20/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/servers/kestrel/endpoints
---

# Configure endpoints for the ASP.NET Core Kestrel web server

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core projects are configured to bind to a random HTTP port between 5000-5300 and a random HTTPS port between 7000-7300. This default configuration is specified in the generated `Properties/launchSettings.json` file and can be overridden. If no ports are specified, Kestrel binds to:

* `http://localhost:5000`
* `https://localhost:5001` (when a local development certificate is present)

Specify URLs using the:

* `ASPNETCORE_URLS` environment variable.
* `--urls` command-line argument.
* `urls` host configuration key.
* <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls%2A> extension method.

The value provided using these approaches can be one or more HTTP and HTTPS endpoints (HTTPS if a default cert is available). Configure the value as a semicolon-separated list (for example, `"Urls": "http://localhost:8000;http://localhost:8001"`).

For more information on these approaches, see [Server URLs](xref:fundamentals/host/web-host#server-urls) and [Override configuration](xref:fundamentals/host/web-host#override-configuration).

A development certificate is created:

* When the [.NET SDK](/dotnet/core/sdk) is installed.
* The [dev-certs tool](xref:security/enforcing-ssl#trust) is used to create a certificate.

The development certificate is available only for the user that generates the certificate. Some browsers require granting explicit permission to trust the local development certificate.

Project templates configure apps to run on HTTPS by default and include [HTTPS redirection and HSTS support](xref:security/enforcing-ssl).

Call <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> or <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> methods on <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> to configure URL prefixes and ports for Kestrel.

`UseUrls`, the `--urls` command-line argument, `urls` host configuration key, and the `ASPNETCORE_URLS` environment variable also work but have the limitations noted later in this section (a default certificate must be available for HTTPS endpoint configuration).

`KestrelServerOptions` configuration:

## ConfigureEndpointDefaults(Action\<ListenOptions>)

Specifies a configuration `Action` to run for each specified endpoint. Calling `ConfigureEndpointDefaults` multiple times replaces prior `Action`s with the last `Action` specified:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureEndpointDefaults":::

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureEndpointDefaults%2A> won't have the defaults applied.

## Configure(IConfiguration)

Enables Kestrel to load endpoints from an <xref:Microsoft.Extensions.Configuration.IConfiguration>. The configuration must be scoped to the configuration section for Kestrel. The `Configure(IConfiguration, bool)` overload can be used to enable reloading endpoints when the configuration source changes.

By default, Kestrel configuration is loaded from the `Kestrel` section and reloading changes is enabled:

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      },
      "Https": {
        "Url": "https://localhost:5001"
      }
    }
  }
}
```

If reloading configuration is enabled and a change is signaled then the following steps are taken:

* The new configuration is compared to the old one, any endpoint without configuration changes are not modified.
* Removed or modified endpoints are given 5 seconds to complete processing requests and shut down.
* New or modified endpoints are started.

Clients connecting to a modified endpoint may be disconnected or refused while the endpoint is restarted.

## ConfigureHttpsDefaults(Action\<HttpsConnectionAdapterOptions>)

Specifies a configuration `Action` to run for each HTTPS endpoint. Calling `ConfigureHttpsDefaults` multiple times replaces prior `Action`s with the last `Action` specified.

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaults":::

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureHttpsDefaults%2A> won't have the defaults applied.

## ListenOptions.UseHttps

Configure Kestrel to use HTTPS.

`ListenOptions.UseHttps` extensions:

* `UseHttps`: Configure Kestrel to use HTTPS with the default certificate. Throws an exception if no default certificate is configured.
* `UseHttps(string fileName)`
* `UseHttps(string fileName, string password)`
* `UseHttps(string fileName, string password, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(StoreName storeName, string subject)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid, StoreLocation location)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid, StoreLocation location, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(X509Certificate2 serverCertificate)`
* `UseHttps(X509Certificate2 serverCertificate, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(Action<HttpsConnectionAdapterOptions> configureOptions)`

`ListenOptions.UseHttps` parameters:

* `filename` is the path and file name of a certificate file, relative to the directory that contains the app's content files.
* `password` is the password required to access the X.509 certificate data.
* `configureOptions` is an `Action` to configure the `HttpsConnectionAdapterOptions`. Returns the `ListenOptions`.
* `storeName` is the certificate store from which to load the certificate.
* `subject` is the subject name for the certificate.
* `allowInvalid` indicates if invalid certificates should be considered, such as self-signed certificates.
* `location` is the store location to load the certificate from.
* `serverCertificate` is the X.509 certificate.

In production, HTTPS must be explicitly configured. At a minimum, a default certificate must be provided.

Supported configurations described next:

* No configuration
* Replace the default certificate from configuration
* Change the defaults in code

### No configuration

Kestrel listens on `http://localhost:5000` and `https://localhost:5001` (if a default cert is available).

<a name="configuration"></a>

### Replace the default certificate from configuration

A default HTTPS app settings configuration schema is available for Kestrel. Configure multiple endpoints, including the URLs and the certificates to use, either from a file on disk or from a certificate store.

In the following `appsettings.json` example:

* Set `AllowInvalid` to `true` to permit the use of invalid certificates (for example, self-signed certificates).
* Any HTTPS endpoint that doesn't specify a certificate (`HttpsDefaultCert` in the example that follows) falls back to the cert defined under `Certificates:Default` or the development certificate.

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      },
      "HttpsInlineCertFile": {
        "Url": "https://localhost:5001",
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      },
      "HttpsInlineCertAndKeyFile": {
        "Url": "https://localhost:5002",
        "Certificate": {
          "Path": "<path to .pem/.crt file>",
          "KeyPath": "<path to .key file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      },
      "HttpsInlineCertStore": {
        "Url": "https://localhost:5003",
        "Certificate": {
          "Subject": "<subject; required>",
          "Store": "<certificate store; required>",
          "Location": "<location; defaults to CurrentUser>",
          "AllowInvalid": "<true or false; defaults to false>"
        }
      },
      "HttpsDefaultCert": {
        "Url": "https://localhost:5004"
      }
    },
    "Certificates": {
      "Default": {
        "Path": "<path to .pfx file>",
        "Password": "$CREDENTIAL_PLACEHOLDER$"
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, certificate passwords are stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for each certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration). Development secrets shouldn't be used for production or test.

Schema notes:

* Endpoints names are [case-insensitive](xref:fundamentals/configuration/index#configuration-keys-and-values). For example, `HTTPS` and `Https` are equivalent.
* The `Url` parameter is required for each endpoint. The format for this parameter is the same as the top-level `Urls` configuration parameter except that it's limited to a single value.
* These endpoints replace those defined in the top-level `Urls` configuration rather than adding to them. Endpoints defined in code via `Listen` are cumulative with the endpoints defined in the configuration section.
* The `Certificate` section is optional. If the `Certificate` section isn't specified, the defaults defined in `Certificates:Default` are used. If no defaults are available, the development certificate is used. If there are no defaults and the development certificate isn't present, the server throws an exception and fails to start.
* The `Certificate` section supports multiple [certificate sources](#certificate-sources).
* Any number of endpoints may be defined in [Configuration](xref:fundamentals/configuration/index) as long as they don't cause port conflicts.

#### Certificate sources

Certificate nodes can be configured to load certificates from a number of sources:

* `Path` and `Password` to load *.pfx* files.
* `Path`, `KeyPath` and `Password` to load *.pem*/*.crt* and *.key* files.
* `Subject` and `Store` to load from the certificate store.

For example, the `Certificates:Default` certificate can be specified as:

```json
"Default": {
  "Subject": "<subject; required>",
  "Store": "<cert store; required>",
  "Location": "<location; defaults to CurrentUser>",
  "AllowInvalid": "<true or false; defaults to false>"
}
```

#### ConfigurationLoader

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure(Microsoft.Extensions.Configuration.IConfiguration)> returns a <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader> with an <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader.Endpoint(System.String,System.Action{Microsoft.AspNetCore.Server.Kestrel.EndpointConfiguration})> method that can be used to supplement a configured endpoint's settings:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigurationLoader":::

`KestrelServerOptions.ConfigurationLoader` can be directly accessed to continue iterating on the existing loader, such as the one provided by <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.WebHost%2A?displayProperty=nameWithType>.

* The configuration section for each endpoint is available on the options in the `Endpoint` method so that custom settings may be read.
* Multiple configurations may be loaded by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure(Microsoft.Extensions.Configuration.IConfiguration)> again with another section. Only the last configuration is used, unless `Load` is explicitly called on prior instances. The metapackage doesn't call `Load` so that its default configuration section may be replaced.
* `KestrelConfigurationLoader` mirrors the `Listen` family of APIs from `KestrelServerOptions` as `Endpoint` overloads, so code and config endpoints may be configured in the same place. These overloads don't use names and only consume default settings from configuration.

### Change the defaults in code

`ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` can be used to change default settings for `ListenOptions` and `HttpsConnectionAdapterOptions`, including overriding the default certificate specified in the prior scenario. `ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` should be called before any endpoints are configured.

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureEndpointDefaultsConfigureHttpsDefaults":::

## Configure endpoints using Server Name Indication

[Server Name Indication (SNI)](https://tools.ietf.org/html/rfc6066#section-3) can be used to host multiple domains on the same IP address and port. For SNI to function, the client sends the host name for the secure session to the server during the TLS handshake so that the server can provide the correct certificate. The client uses the furnished certificate for encrypted communication with the server during the secure session that follows the TLS handshake.

SNI can be configured in two ways:

* Create an endpoint in code and select a certificate using the host name with the <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.ServerCertificateSelector%2A> callback.
* Configure a mapping between host names and HTTPS options in [Configuration](xref:fundamentals/configuration/index). For example, JSON in  the `appsettings.json` file.

### SNI with `ServerCertificateSelector`

Kestrel supports SNI via the `ServerCertificateSelector` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ServerCertificateSelector":::

### SNI with `ServerOptionsSelectionCallback`

Kestrel supports additional dynamic TLS configuration via the `ServerOptionsSelectionCallback` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate and TLS configuration. Default certificates and `ConfigureHttpsDefaults` are not used with this callback.

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ServerOptionsSelectionCallback":::

### SNI with `TlsHandshakeCallbackOptions`

Kestrel supports additional dynamic TLS configuration via the `TlsHandshakeCallbackOptions.OnConnection` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate, TLS configuration, and other server options. Default certificates and `ConfigureHttpsDefaults` are not used with this callback.

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_TlsHandshakeCallbackOptions":::

### SNI in configuration

Kestrel supports SNI defined in configuration. An endpoint can be configured with an `Sni` object that contains a mapping between host names and HTTPS options. The connection host name is matched to the options and they are used for that connection.

The following configuration adds an endpoint named `MySniEndpoint` that uses SNI to select HTTPS options based on the host name:

```json
{
  "Kestrel": {
    "Endpoints": {
      "MySniEndpoint": {
        "Url": "https://*",
        "SslProtocols": ["Tls11", "Tls12"],
        "Sni": {
          "a.example.org": {
            "Protocols": "Http1AndHttp2",
            "SslProtocols": ["Tls11", "Tls12", "Tls13"],
            "Certificate": {
              "Subject": "<subject; required>",
              "Store": "<certificate store; required>",
            },
            "ClientCertificateMode" : "NoCertificate"
          },
          "*.example.org": {
            "Certificate": {
              "Path": "<path to .pfx file>",
              "Password": "$CREDENTIAL_PLACEHOLDER$"
            }
          },
          "*": {
            // At least one subproperty needs to exist per SNI section or it
            // cannot be discovered via IConfiguration
            "Protocols": "Http1",
          }
        }
      }
    },
    "Certificates": {
      "Default": {
        "Path": "<path to .pfx file>",
        "Password": "$CREDENTIAL_PLACEHOLDER$"
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, certificate passwords are stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for each certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration). Development secrets shouldn't be used for production or test.

HTTPS options that can be overridden by SNI:

* `Certificate` configures the [certificate source](#certificate-sources).
* `Protocols` configures the allowed [HTTP protocols](xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols).
* `SslProtocols` configures the allowed [SSL protocols](xref:System.Security.Authentication.SslProtocols).
* `ClientCertificateMode` configures the [client certificate requirements](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode).

The host name supports wildcard matching:

* Exact match. For example, `a.example.org` matches `a.example.org`.
* Wildcard prefix. If there are multiple wildcard matches then the longest pattern is chosen. For example, `*.example.org` matches `b.example.org` and `c.example.org`.
* Full wildcard. `*` matches everything else, including clients that aren't using SNI and don't send a host name.

The matched SNI configuration is applied to the endpoint for the connection, overriding values on the endpoint. If a connection doesn't match a configured SNI host name then the connection is refused.

### SNI requirements

All websites must run on the same Kestrel instance. Kestrel doesn't support sharing an IP address and port across multiple instances without a reverse proxy.

## SSL/TLS Protocols

SSL Protocols are protocols used for encrypting and decrypting traffic between two peers, traditionally a client and a server.

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsSslProtocols":::

```json
{
  "Kestrel": {
    "Endpoints": {
      "MyHttpsEndpoint": {
        "Url": "https://localhost:5001",
        "SslProtocols": ["Tls12", "Tls13"],
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, the certificate password is stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for the certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration). Development secrets shouldn't be used for production or test.

The default value, `SslProtocols.None`, causes Kestrel to use the operating system defaults to choose the best protocol. Unless you have a specific reason to select a protocol, use the default.

## Client Certificates

`ClientCertificateMode` configures the [client certificate requirements](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode).

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsClientCertificateMode":::

```json
{
  "Kestrel": {
    "Endpoints": {
      "MyHttpsEndpoint": {
        "Url": "https://localhost:5001",
        "ClientCertificateMode": "AllowCertificate",
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, the certificate password is stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for the certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration).

The default value is `ClientCertificateMode.NoCertificate` where Kestrel will not request or require a certificate from the client.

For more information, see <xref:security/authentication/certauth>.

## Connection logging

Call <xref:Microsoft.AspNetCore.Hosting.ListenOptionsConnectionLoggingExtensions.UseConnectionLogging%2A> to emit Debug level logs for byte-level communication on a connection. Connection logging is helpful for troubleshooting problems in low-level communication, such as during TLS encryption and behind proxies. If `UseConnectionLogging` is placed before `UseHttps`, encrypted traffic is logged. If `UseConnectionLogging` is placed after `UseHttps`, decrypted traffic is logged. This is built-in [Connection Middleware](#connection-middleware).

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelUseConnectionLogging":::

## Bind to a TCP socket

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> method binds to a TCP socket, and an options lambda permits X.509 certificate configuration:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_Listen":::

The example configures HTTPS for an endpoint with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions>. Use the same API to configure other Kestrel settings for specific endpoints.

[!INCLUDE [How to make an X.509 cert](~/includes/make-x509-cert.md)]

## Bind to a Unix socket

Listen on a Unix socket with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> for improved performance with Nginx, as shown in this example:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ListenUnixSocket":::

* In the Nginx configuration file, set the `server` > `location` > `proxy_pass` entry to `http://unix:/tmp/{KESTREL SOCKET}:/;`. `{KESTREL SOCKET}` is the name of the socket provided to <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> (for example, `kestrel-test.sock` in the preceding example).
* Ensure that the socket is writeable by Nginx (for example, `chmod go+w /tmp/kestrel-test.sock`).

## Port 0

When the port number `0` is specified, Kestrel dynamically binds to an available port. The following example shows how to determine which port Kestrel bound at runtime:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_IServerAddressesFeature":::

## Limitations

Configure endpoints with the following approaches:

* <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls%2A>
* `--urls` command-line argument
* `urls` host configuration key
* `ASPNETCORE_URLS` environment variable

These methods are useful for making code work with servers other than Kestrel. However, be aware of the following limitations:

* HTTPS can't be used with these approaches unless a default certificate is provided in the HTTPS endpoint configuration (for example, using `KestrelServerOptions` configuration or a configuration file as shown earlier in this article).
* When both the `Listen` and `UseUrls` approaches are used simultaneously, the `Listen` endpoints override the `UseUrls` endpoints.

## IIS endpoint configuration

When using IIS, the URL bindings for IIS override bindings are set by either `Listen` or `UseUrls`. For more information, see [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module).

## ListenOptions.Protocols

The `Protocols` property establishes the HTTP protocols (`HttpProtocols`) enabled on a connection endpoint or for the server. Assign a value to the `Protocols` property from the `HttpProtocols` enum.

| `HttpProtocols` enum value | Connection protocol permitted |
|--|--|
| `Http1` | HTTP/1.1 only. Can be used with or without TLS. |
| `Http2` | HTTP/2 only. May be used without TLS only if the client supports a [Prior Knowledge mode](https://tools.ietf.org/html/rfc7540#section-3.4). |
| `Http1AndHttp2` | HTTP/1.1 and HTTP/2. HTTP/2 requires the client to select HTTP/2 in the TLS [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) handshake; otherwise, the connection defaults to HTTP/1.1. |

The default `ListenOptions.Protocols` value for any endpoint is `HttpProtocols.Http1AndHttp2`.

TLS restrictions for HTTP/2:

* TLS version 1.2 or later
* Renegotiation disabled
* Compression disabled
* Minimum ephemeral key exchange sizes:
  * Elliptic curve Diffie-Hellman (ECDHE) &lbrack;[RFC4492](https://www.ietf.org/rfc/rfc4492.txt)&rbrack;: 224 bits minimum
  * Finite field Diffie-Hellman (DHE) &lbrack;`TLS12`&rbrack;: 2048 bits minimum
* Cipher suite not prohibited. 

`TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256` &lbrack;`TLS-ECDHE`&rbrack; with the P-256 elliptic curve &lbrack;`FIPS186`&rbrack; is supported by default.

The following example permits HTTP/1.1 and HTTP/2 connections on port 8000. Connections are secured by TLS with a supplied certificate:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelProtocols":::

On Linux, <xref:System.Net.Security.CipherSuitesPolicy> can be used to filter TLS handshakes on a per-connection basis:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsCipherSuitesPolicy":::

## Connection Middleware

Custom connection middleware can filter TLS handshakes on a per-connection basis for specific ciphers if necessary.

The following example throws <xref:System.NotSupportedException> for any cipher algorithm that the app doesn't support. Alternatively, define and compare <xref:Microsoft.AspNetCore.Connections.Features.ITlsHandshakeFeature.CipherAlgorithm%2A?displayProperty=nameWithType> to a list of acceptable cipher suites.

No encryption is used with a <xref:System.Security.Authentication.CipherAlgorithmType.Null?displayProperty=nameWithType> cipher algorithm.

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelMiddleware":::

## Set the HTTP protocol from configuration

By default, Kestrel configuration is loaded from the `Kestrel` section. The following `appsettings.json` example establishes HTTP/1.1 as the default connection protocol for all endpoints:

```json
{
  "Kestrel": {
    "EndpointDefaults": {
      "Protocols": "Http1"
    }
  }
}
```

The following `appsettings.json` example establishes the HTTP/1.1 connection protocol for a specific endpoint:

```json
{
  "Kestrel": {
    "Endpoints": {
      "HttpsDefaultCert": {
        "Url": "https://localhost:5001",
        "Protocols": "Http1"
      }
    }
  }
}
```

Protocols specified in code override values set by configuration.

## URL prefixes

When using `UseUrls`, `--urls` command-line argument, `urls` host configuration key, or `ASPNETCORE_URLS` environment variable, the URL prefixes can be in any of the following formats.

Only HTTP URL prefixes are valid. Kestrel doesn't support HTTPS when configuring URL bindings using `UseUrls`.

* IPv4 address with port number

  ```
  http://65.55.39.10:80/
  ```

  `0.0.0.0` is a special case that binds to all IPv4 addresses.

* IPv6 address with port number

  ```
  http://[0:0:0:0:0:ffff:4137:270a]:80/
  ```

  `[::]` is the IPv6 equivalent of IPv4 `0.0.0.0`.

* Host name with port number

  ```
  http://contoso.com:80/
  http://*:80/
  ```

  Host names, `*`, and `+`, aren't special. Anything not recognized as a valid IP address or `localhost` binds to all IPv4 and IPv6 IPs. To bind different host names to different ASP.NET Core apps on the same port, use [HTTP.sys](xref:fundamentals/servers/httpsys) or a reverse proxy server. Reverse proxy server examples include IIS, Nginx, or Apache.

  > [!WARNING]
  > Hosting in a reverse proxy configuration requires [host filtering](xref:fundamentals/servers/kestrel/host-filtering).

* Host `localhost` name with port number or loopback IP with port number

  ```
  http://localhost:5000/
  http://127.0.0.1:5000/
  http://[::1]:5000/
  ```

  When `localhost` is specified, Kestrel attempts to bind to both IPv4 and IPv6 loopback interfaces. If the requested port is in use by another service on either loopback interface, Kestrel fails to start. If either loopback interface is unavailable for any other reason (most commonly because IPv6 isn't supported), Kestrel logs a warning.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

By default, ASP.NET Core binds to:

* `http://localhost:5000`
* `https://localhost:5001` (when a local development certificate is present)

Specify URLs using the:

* `ASPNETCORE_URLS` environment variable.
* `--urls` command-line argument.
* `urls` host configuration key.
* <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls%2A> extension method.

The value provided using these approaches can be one or more HTTP and HTTPS endpoints (HTTPS if a default cert is available). Configure the value as a semicolon-separated list (for example, `"Urls": "http://localhost:8000;http://localhost:8001"`).

For more information on these approaches, see [Server URLs](xref:fundamentals/host/web-host#server-urls) and [Override configuration](xref:fundamentals/host/web-host#override-configuration).

A development certificate is created:

* When the [.NET SDK](/dotnet/core/sdk) is installed.
* The [dev-certs tool](xref:security/enforcing-ssl#trust) is used to create a certificate.

Some browsers require granting explicit permission to trust the local development certificate.

Project templates configure apps to run on HTTPS by default and include [HTTPS redirection and HSTS support](xref:security/enforcing-ssl).

Call <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> or <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> methods on <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> to configure URL prefixes and ports for Kestrel.

`UseUrls`, the `--urls` command-line argument, `urls` host configuration key, and the `ASPNETCORE_URLS` environment variable also work but have the limitations noted later in this section (a default certificate must be available for HTTPS endpoint configuration).

`KestrelServerOptions` configuration:

## ConfigureEndpointDefaults(Action\<ListenOptions>)

Specifies a configuration `Action` to run for each specified endpoint. Calling `ConfigureEndpointDefaults` multiple times replaces prior `Action`s with the last `Action` specified.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        // Configure endpoint defaults
    });
});
```

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureEndpointDefaults%2A> won't have the defaults applied.

## Configure(IConfiguration)

Enables Kestrel to load endpoints from an <xref:Microsoft.Extensions.Configuration.IConfiguration>. The configuration must be scoped to the configuration section for Kestrel.

The `Configure(IConfiguration, bool)` overload can be used to enable reloading endpoints when the configuration source changes.

`IHostBuilder.ConfigureWebHostDefaults` calls `Configure(context.Configuration.GetSection("Kestrel"), reloadOnChange: true)` by default to load Kestrel configuration and enable reloading.

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      },
      "Https": {
        "Url": "https://localhost:5001"
      }
    }
  }
}
```

If reloading configuration is enabled and a change is signaled then the following steps are taken:

* The new configuration is compared to the old one, any endpoint without configuration changes are not modified.
* Removed or modified endpoints are given 5 seconds to complete processing requests and shut down.
* New or modified endpoints are started.

Clients connecting to a modified endpoint may be disconnected or refused while the endpoint is restarted.

## ConfigureHttpsDefaults(Action\<HttpsConnectionAdapterOptions>)

Specifies a configuration `Action` to run for each HTTPS endpoint. Calling `ConfigureHttpsDefaults` multiple times replaces prior `Action`s with the last `Action` specified.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        // certificate is an X509Certificate2
        listenOptions.ServerCertificate = certificate;
    });
});
```

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureHttpsDefaults%2A> won't have the defaults applied.

## ListenOptions.UseHttps

Configure Kestrel to use HTTPS.

`ListenOptions.UseHttps` extensions:

* `UseHttps`: Configure Kestrel to use HTTPS with the default certificate. Throws an exception if no default certificate is configured.
* `UseHttps(string fileName)`
* `UseHttps(string fileName, string password)`
* `UseHttps(string fileName, string password, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(StoreName storeName, string subject)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid, StoreLocation location)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid, StoreLocation location, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(X509Certificate2 serverCertificate)`
* `UseHttps(X509Certificate2 serverCertificate, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(Action<HttpsConnectionAdapterOptions> configureOptions)`

`ListenOptions.UseHttps` parameters:

* `filename` is the path and file name of a certificate file, relative to the directory that contains the app's content files.
* `password` is the password required to access the X.509 certificate data.
* `configureOptions` is an `Action` to configure the `HttpsConnectionAdapterOptions`. Returns the `ListenOptions`.
* `storeName` is the certificate store from which to load the certificate.
* `subject` is the subject name for the certificate.
* `allowInvalid` indicates if invalid certificates should be considered, such as self-signed certificates.
* `location` is the store location to load the certificate from.
* `serverCertificate` is the X.509 certificate.

In production, HTTPS must be explicitly configured. At a minimum, a default certificate must be provided.

Supported configurations described next:

* No configuration
* Replace the default certificate from configuration
* Change the defaults in code

### No configuration

Kestrel listens on `http://localhost:5000` and `https://localhost:5001` (if a default cert is available).

<a name="configuration"></a>

### Replace the default certificate from configuration

A default HTTPS app settings configuration schema is available for Kestrel. Configure multiple endpoints, including the URLs and the certificates to use, either from a file on disk or from a certificate store.

In the following `appsettings.json` example:

* Set `AllowInvalid` to `true` to permit the use of invalid certificates (for example, self-signed certificates).
* Any HTTPS endpoint that doesn't specify a certificate (`HttpsDefaultCert` in the example that follows) falls back to the cert defined under `Certificates:Default` or the development certificate.

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      },
      "HttpsInlineCertFile": {
        "Url": "https://localhost:5001",
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      },
      "HttpsInlineCertAndKeyFile": {
        "Url": "https://localhost:5002",
        "Certificate": {
          "Path": "<path to .pem/.crt file>",
          "KeyPath": "<path to .key file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      },
      "HttpsInlineCertStore": {
        "Url": "https://localhost:5003",
        "Certificate": {
          "Subject": "<subject; required>",
          "Store": "<certificate store; required>",
          "Location": "<location; defaults to CurrentUser>",
          "AllowInvalid": "<true or false; defaults to false>"
        }
      },
      "HttpsDefaultCert": {
        "Url": "https://localhost:5004"
      }
    },
    "Certificates": {
      "Default": {
        "Path": "<path to .pfx file>",
        "Password": "$CREDENTIAL_PLACEHOLDER$"
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, certificate passwords are stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for each certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration). Development secrets shouldn't be used for production or test.

Schema notes:

* Endpoints names are [case-insensitive](xref:fundamentals/configuration/index#configuration-keys-and-values). For example, `HTTPS` and `Https` are equivalent.
* The `Url` parameter is required for each endpoint. The format for this parameter is the same as the top-level `Urls` configuration parameter except that it's limited to a single value.
* These endpoints replace those defined in the top-level `Urls` configuration rather than adding to them. Endpoints defined in code via `Listen` are cumulative with the endpoints defined in the configuration section.
* The `Certificate` section is optional. If the `Certificate` section isn't specified, the defaults defined in `Certificates:Default` are used. If no defaults are available, the development certificate is used. If there are no defaults and the development certificate isn't present, the server throws an exception and fails to start.
* The `Certificate` section supports multiple [certificate sources](#certificate-sources).
* Any number of endpoints may be defined in [Configuration](xref:fundamentals/configuration/index) as long as they don't cause port conflicts.

#### Certificate sources

Certificate nodes can be configured to load certificates from a number of sources:

* `Path` and `Password` to load *.pfx* files.
* `Path`, `KeyPath` and `Password` to load *.pem*/*.crt* and *.key* files.
* `Subject` and `Store` to load from the certificate store.

For example, the `Certificates:Default` certificate can be specified as:

```json
"Default": {
  "Subject": "<subject; required>",
  "Store": "<cert store; required>",
  "Location": "<location; defaults to CurrentUser>",
  "AllowInvalid": "<true or false; defaults to false>"
}
```

#### ConfigurationLoader

`options.Configure(context.Configuration.GetSection("{SECTION}"))` returns a <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader> with an `.Endpoint(string name, listenOptions => { })` method that can be used to supplement a configured endpoint's settings:

```csharp
webBuilder.UseKestrel((context, serverOptions) =>
{
    serverOptions.Configure(context.Configuration.GetSection("Kestrel"))
        .Endpoint("HTTPS", listenOptions =>
        {
            listenOptions.HttpsOptions.SslProtocols = SslProtocols.Tls12;
        });
});
```

`KestrelServerOptions.ConfigurationLoader` can be directly accessed to continue iterating on the existing loader, such as the one provided by <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A>.

* The configuration section for each endpoint is available on the options in the `Endpoint` method so that custom settings may be read.
* Multiple configurations may be loaded by calling `options.Configure(context.Configuration.GetSection("{SECTION}"))` again with another section. Only the last configuration is used, unless `Load` is explicitly called on prior instances. The metapackage doesn't call `Load` so that its default configuration section may be replaced.
* `KestrelConfigurationLoader` mirrors the `Listen` family of APIs from `KestrelServerOptions` as `Endpoint` overloads, so code and config endpoints may be configured in the same place. These overloads don't use names and only consume default settings from configuration.

### Change the defaults in code

`ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` can be used to change default settings for `ListenOptions` and `HttpsConnectionAdapterOptions`, including overriding the default certificate specified in the prior scenario. `ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` should be called before any endpoints are configured.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        // Configure endpoint defaults
    });

    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        listenOptions.SslProtocols = SslProtocols.Tls12;
    });
});
```

## Configure endpoints using Server Name Indication

[Server Name Indication (SNI)](https://tools.ietf.org/html/rfc6066#section-3) can be used to host multiple domains on the same IP address and port. For SNI to function, the client sends the host name for the secure session to the server during the TLS handshake so that the server can provide the correct certificate. The client uses the furnished certificate for encrypted communication with the server during the secure session that follows the TLS handshake.

SNI can be configured in two ways:

* Create an endpoint in code and select a certificate using the host name with the <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.ServerCertificateSelector%2A> callback.
* Configure a mapping between host names and HTTPS options in [Configuration](xref:fundamentals/configuration/index). For example, JSON in  the `appsettings.json` file.

### SNI with `ServerCertificateSelector`

Kestrel supports SNI via the `ServerCertificateSelector` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate. The following callback code can be used in the `ConfigureWebHostDefaults` method call of a project's `Program.cs` file:

```csharp
// using System.Security.Cryptography.X509Certificates;
// using Microsoft.AspNetCore.Server.Kestrel.Https;

webBuilder.ConfigureKestrel(serverOptions =>
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
            var certs = new Dictionary<string, X509Certificate2>(StringComparer.OrdinalIgnoreCase)
            {
                { "localhost", localhostCert },
                { "example.com", exampleCert },
                { "sub.example.com", subExampleCert },
            };            

            httpsOptions.ServerCertificateSelector = (connectionContext, name) =>
            {
                if (name != null && certs.TryGetValue(name, out var cert))
                {
                    return cert;
                }

                return exampleCert;
            };
        });
    });
});
```

### SNI with `ServerOptionsSelectionCallback`

Kestrel supports additional dynamic TLS configuration via the `ServerOptionsSelectionCallback` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate and TLS configuration. Default certificates and `ConfigureHttpsDefaults` are not used with this callback.

```csharp
// using System.Security.Cryptography.X509Certificates;
// using Microsoft.AspNetCore.Server.Kestrel.Https;

webBuilder.ConfigureKestrel(serverOptions =>
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
                if (string.Equals(clientHelloInfo.ServerName, "localhost", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValueTask<SslServerAuthenticationOptions>(new SslServerAuthenticationOptions
                    {
                        ServerCertificate = localhostCert,
                        // Different TLS requirements for this host
                        ClientCertificateRequired = true,
                    });
                }

                return new ValueTask<SslServerAuthenticationOptions>(new SslServerAuthenticationOptions
                {
                    ServerCertificate = exampleCert,
                });
            }, state: null);
        });
    });
});
```

### SNI in configuration

Kestrel supports SNI defined in configuration. An endpoint can be configured with an `Sni` object that contains a mapping between host names and HTTPS options. The connection host name is matched to the options and they are used for that connection.

The following configuration adds an endpoint named `MySniEndpoint` that uses SNI to select HTTPS options based on the host name:

```json
{
  "Kestrel": {
    "Endpoints": {
      "MySniEndpoint": {
        "Url": "https://*",
        "SslProtocols": ["Tls11", "Tls12"],
        "Sni": {
          "a.example.org": {
            "Protocols": "Http1AndHttp2",
            "SslProtocols": ["Tls11", "Tls12", "Tls13"],
            "Certificate": {
              "Subject": "<subject; required>",
              "Store": "<certificate store; required>",
            },
            "ClientCertificateMode" : "NoCertificate"
          },
          "*.example.org": {
            "Certificate": {
              "Path": "<path to .pfx file>",
              "Password": "$CREDENTIAL_PLACEHOLDER$"
            }
          },
          "*": {
            // At least one subproperty needs to exist per SNI section or it
            // cannot be discovered via IConfiguration
            "Protocols": "Http1",
          }
        }
      }
    },
    "Certificates": {
      "Default": {
        "Path": "<path to .pfx file>",
        "Password": "$CREDENTIAL_PLACEHOLDER$"
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, certificate passwords are stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for each certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration). Development secrets shouldn't be used for production or test.

HTTPS options that can be overridden by SNI:

* `Certificate` configures the [certificate source](#certificate-sources).
* `Protocols` configures the allowed [HTTP protocols](xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols).
* `SslProtocols` configures the allowed [SSL protocols](xref:System.Security.Authentication.SslProtocols).
* `ClientCertificateMode` configures the [client certificate requirements](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode).

The host name supports wildcard matching:

* Exact match. For example, `a.example.org` matches `a.example.org`.
* Wildcard prefix. If there are multiple wildcard matches then the longest pattern is chosen. For example, `*.example.org` matches `b.example.org` and `c.example.org`.
* Full wildcard. `*` matches everything else, including clients that aren't using SNI and don't send a host name.

The matched SNI configuration is applied to the endpoint for the connection, overriding values on the endpoint. If a connection doesn't match a configured SNI host name then the connection is refused.

### SNI requirements

* Running on target framework `netcoreapp2.1` or later. On `net461` or later, the callback is invoked but the `name` is always `null`. The `name` is also `null` if the client doesn't provide the host name parameter in the TLS handshake.
* All websites run on the same Kestrel instance. Kestrel doesn't support sharing an IP address and port across multiple instances without a reverse proxy.

## SSL/TLS Protocols

SSL Protocols are protocols used for encrypting and decrypting traffic between two peers, traditionally a client and a server.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        listenOptions.SslProtocols = SslProtocols.Tls13;
    });
});
```

```json
{
  "Kestrel": {
    "Endpoints": {
      "MyHttpsEndpoint": {
        "Url": "https://localhost:5001",
        "SslProtocols": ["Tls12", "Tls13"],
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, the certificate password is stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for the certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration). Development secrets shouldn't be used for production or test.

The default value, `SslProtocols.None`, causes Kestrel to use the operating system defaults to choose the best protocol. Unless you have a specific reason to select a protocol, use the default.

## Client Certificates

`ClientCertificateMode` configures the [client certificate requirements](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        listenOptions.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
    });
});
```

```json
{
  "Kestrel": {
    "Endpoints": {
      "MyHttpsEndpoint": {
        "Url": "https://localhost:5001",
        "ClientCertificateMode": "AllowCertificate",
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "$CREDENTIAL_PLACEHOLDER$"
        }
      }
    }
  }
}
```

> [!WARNING]
> In the preceding example, the certificate password is stored in plain-text in `appsettings.json`. The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for the certificate's password. To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets). To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration). Development secrets shouldn't be used for production or test.

The default value is `ClientCertificateMode.NoCertificate` where Kestrel will not request or require a certificate from the client.

For more information, see <xref:security/authentication/certauth>.

## Connection logging

Call <xref:Microsoft.AspNetCore.Hosting.ListenOptionsConnectionLoggingExtensions.UseConnectionLogging%2A> to emit Debug level logs for byte-level communication on a connection. Connection logging is helpful for troubleshooting problems in low-level communication, such as during TLS encryption and behind proxies. If `UseConnectionLogging` is placed before `UseHttps`, encrypted traffic is logged. If `UseConnectionLogging` is placed after `UseHttps`, decrypted traffic is logged. This is built-in [Connection Middleware](#connection-middleware).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseConnectionLogging();
    });
});
```

## Bind to a TCP socket

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> method binds to a TCP socket, and an options lambda permits X.509 certificate configuration:

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_TCPSocket" highlight="12-18":::

The example configures HTTPS for an endpoint with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions>. Use the same API to configure other Kestrel settings for specific endpoints.

[!INCLUDE [How to make an X.509 cert](~/includes/make-x509-cert.md)]

## Bind to a Unix socket

Listen on a Unix socket with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> for improved performance with Nginx, as shown in this example:

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_UnixSocket":::

* In the Nginx configuration file, set the `server` > `location` > `proxy_pass` entry to `http://unix:/tmp/{KESTREL SOCKET}:/;`. `{KESTREL SOCKET}` is the name of the socket provided to <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> (for example, `kestrel-test.sock` in the preceding example).
* Ensure that the socket is writeable by Nginx (for example, `chmod go+w /tmp/kestrel-test.sock`).

## Port 0

When the port number `0` is specified, Kestrel dynamically binds to an available port. The following example shows how to determine which port Kestrel bound at runtime:

:::code language="csharp" source="samples/5.x/KestrelSample/Startup.cs" id="snippet_Configure" highlight="3-4,15-21":::

When the app is run, the console window output indicates the dynamic port where the app can be reached:

```console
Listening on the following addresses: http://127.0.0.1:48508
```

## Limitations

Configure endpoints with the following approaches:

* <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls%2A>
* `--urls` command-line argument
* `urls` host configuration key
* `ASPNETCORE_URLS` environment variable

These methods are useful for making code work with servers other than Kestrel. However, be aware of the following limitations:

* HTTPS can't be used with these approaches unless a default certificate is provided in the HTTPS endpoint configuration (for example, using `KestrelServerOptions` configuration or a configuration file as shown earlier in this article).
* When both the `Listen` and `UseUrls` approaches are used simultaneously, the `Listen` endpoints override the `UseUrls` endpoints.

## IIS endpoint configuration

When using IIS, the URL bindings for IIS override bindings are set by either `Listen` or `UseUrls`. For more information, see [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module).

## ListenOptions.Protocols

The `Protocols` property establishes the HTTP protocols (`HttpProtocols`) enabled on a connection endpoint or for the server. Assign a value to the `Protocols` property from the `HttpProtocols` enum.

| `HttpProtocols` enum value | Connection protocol permitted |
| -------------------------- | ----------------------------- |
| `Http1`                    | HTTP/1.1 only. Can be used with or without TLS. |
| `Http2`                    | HTTP/2 only. May be used without TLS only if the client supports a [Prior Knowledge mode](https://tools.ietf.org/html/rfc7540#section-3.4). |
| `Http1AndHttp2`            | HTTP/1.1 and HTTP/2. HTTP/2 requires the client to select HTTP/2 in the TLS [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) handshake; otherwise, the connection defaults to HTTP/1.1. |

The default `ListenOptions.Protocols` value for any endpoint is `HttpProtocols.Http1AndHttp2`.

TLS restrictions for HTTP/2:

* TLS version 1.2 or later
* Renegotiation disabled
* Compression disabled
* Minimum ephemeral key exchange sizes:
  * Elliptic curve Diffie-Hellman (ECDHE) &lbrack;[RFC4492](https://www.ietf.org/rfc/rfc4492.txt)&rbrack;: 224 bits minimum
  * Finite field Diffie-Hellman (DHE) &lbrack;`TLS12`&rbrack;: 2048 bits minimum
* Cipher suite not prohibited. 

`TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256` &lbrack;`TLS-ECDHE`&rbrack; with the P-256 elliptic curve &lbrack;`FIPS186`&rbrack; is supported by default.

The following example permits HTTP/1.1 and HTTP/2 connections on port 8000. Connections are secured by TLS with a supplied certificate:

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseHttps("testCert.pfx", "testPassword");
    });
});
```

On Linux, <xref:System.Net.Security.CipherSuitesPolicy> can be used to filter TLS handshakes on a per-connection basis:

```csharp
// using System.Net.Security;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Server.Kestrel.Core;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

webBuilder.ConfigureKestrel(serverOptions =>
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
```

## Connection Middleware

Custom connection middleware can filter TLS handshakes on a per-connection basis for specific ciphers if necessary.

The following example throws <xref:System.NotSupportedException> for any cipher algorithm that the app doesn't support. Alternatively, define and compare [ITlsHandshakeFeature.CipherAlgorithm](xref:Microsoft.AspNetCore.Connections.Features.ITlsHandshakeFeature.CipherAlgorithm) to a list of acceptable cipher suites.

No encryption is used with a [CipherAlgorithmType.Null](xref:System.Security.Authentication.CipherAlgorithmType) cipher algorithm.

```csharp
// using System.Net;
// using Microsoft.AspNetCore.Connections;

webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseHttps("testCert.pfx", "testPassword");
        listenOptions.UseTlsFilter();
    });
});
```

```csharp
using System;
using System.Security.Authentication;
using Microsoft.AspNetCore.Connections.Features;

namespace Microsoft.AspNetCore.Connections
{
    public static class TlsFilterConnectionMiddlewareExtensions
    {
        public static IConnectionBuilder UseTlsFilter(
            this IConnectionBuilder builder)
        {
            return builder.Use((connection, next) =>
            {
                var tlsFeature = connection.Features.Get<ITlsHandshakeFeature>();

                if (tlsFeature.CipherAlgorithm == CipherAlgorithmType.Null)
                {
                    throw new NotSupportedException("Prohibited cipher: " +
                        tlsFeature.CipherAlgorithm);
                }

                return next();
            });
        }
    }
}
```

Connection filtering can also be configured via an <xref:Microsoft.AspNetCore.Connections.IConnectionBuilder> lambda:

```csharp
// using System;
// using System.Net;
// using System.Security.Authentication;
// using Microsoft.AspNetCore.Connections;
// using Microsoft.AspNetCore.Connections.Features;

webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseHttps("testCert.pfx", "testPassword");
        listenOptions.Use((context, next) =>
        {
            var tlsFeature = context.Features.Get<ITlsHandshakeFeature>();

            if (tlsFeature.CipherAlgorithm == CipherAlgorithmType.Null)
            {
                throw new NotSupportedException(
                    $"Prohibited cipher: {tlsFeature.CipherAlgorithm}");
            }

            return next();
        });
    });
});
```

## Set the HTTP protocol from configuration

`CreateDefaultBuilder` calls `serverOptions.Configure(context.Configuration.GetSection("Kestrel"))` by default to load Kestrel configuration.

The following `appsettings.json` example establishes HTTP/1.1 as the default connection protocol for all endpoints:

```json
{
  "Kestrel": {
    "EndpointDefaults": {
      "Protocols": "Http1"
    }
  }
}
```

The following `appsettings.json` example establishes the HTTP/1.1 connection protocol for a specific endpoint:

```json
{
  "Kestrel": {
    "Endpoints": {
      "HttpsDefaultCert": {
        "Url": "https://localhost:5001",
        "Protocols": "Http1"
      }
    }
  }
}
```

Protocols specified in code override values set by configuration.

## URL prefixes

When using `UseUrls`, `--urls` command-line argument, `urls` host configuration key, or `ASPNETCORE_URLS` environment variable, the URL prefixes can be in any of the following formats.

Only HTTP URL prefixes are valid. Kestrel doesn't support HTTPS when configuring URL bindings using `UseUrls`.

* IPv4 address with port number

  ```
  http://65.55.39.10:80/
  ```

  `0.0.0.0` is a special case that binds to all IPv4 addresses.

* IPv6 address with port number

  ```
  http://[0:0:0:0:0:ffff:4137:270a]:80/
  ```

  `[::]` is the IPv6 equivalent of IPv4 `0.0.0.0`.

* Host name with port number

  ```
  http://contoso.com:80/
  http://*:80/
  ```

  Host names, `*`, and `+`, aren't special. Anything not recognized as a valid IP address or `localhost` binds to all IPv4 and IPv6 IPs. To bind different host names to different ASP.NET Core apps on the same port, use [HTTP.sys](xref:fundamentals/servers/httpsys) or a reverse proxy server. Reverse proxy server examples include IIS, Nginx, or Apache.

  > [!WARNING]
  > Hosting in a reverse proxy configuration requires [host filtering](xref:fundamentals/servers/kestrel/host-filtering).

* Host `localhost` name with port number or loopback IP with port number

  ```
  http://localhost:5000/
  http://127.0.0.1:5000/
  http://[::1]:5000/
  ```

  When `localhost` is specified, Kestrel attempts to bind to both IPv4 and IPv6 loopback interfaces. If the requested port is in use by another service on either loopback interface, Kestrel fails to start. If either loopback interface is unavailable for any other reason (most commonly because IPv6 isn't supported), Kestrel logs a warning.
    
:::moniker-end
