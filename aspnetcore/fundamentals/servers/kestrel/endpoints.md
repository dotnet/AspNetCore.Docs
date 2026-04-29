---
title: Configure endpoints for Kestrel web server
author: tdykstra
description: Learn about configuring endpoints with Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-5.0'
ms.author: tdykstra
ms.custom: mvc
ms.date: 04/27/2026
uid: fundamentals/servers/kestrel/endpoints

#customer intent: As an ASP.MEt developer, I want to configure endpoints with Kestrel, so I can use a Kestrel web server with my ASP.NET Core app.
---

# Configure endpoints for the ASP.NET Core Kestrel web server

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

Kestrel endpoints provide the infrastructure for listening to incoming requests and routing them to the appropriate middleware. The combination of an address and a protocol defines an endpoint.

* The address specifies the network interface that the server listens on for incoming requests, such as a TCP port.
* The protocol specifies the communication between the client and server, such as HTTP/1.1, HTTP/2, or HTTP/3.
* An endpoint can be secured by using the `https` URL scheme or `UseHttps` method.

Endpoints can be configured with URLs, JSON in the _appsettings.json_ file, and code. This article describes how to use each option to configure endpoints, HTTPS, and HTTP protocols.

## Identify the default endpoint

The configuration for new ASP.NET Core projects binds each project to a default endpoint. The configuration selects a random HTTP port between 5000-5300 and a random HTTPS port between 7000-7300. The selected ports are stored in the generated _Properties/launchSettings.json_ file and are modifiable by the developer. The _launchSetting.json_ file is used for local development only.

If there's no endpoint configuration, Kestrel binds to the `http://localhost:5000` URL.

## Configure endpoints

Kestrel endpoints listen for incoming connections. When an endpoint is created, it must be configured with the address to use for listening. The address is usually a TCP address and port number.

You have several options for configuring endpoints. You can specify the URLs or ports directly, define the addresses in your code, or create the endpoints with JSON in the _appsettings.json_ file.

### Specify endpoints with URLs

The following sections explain how to configure endpoints by using the following resources:

* `ASPNETCORE_URLS` environment variable
* `--urls` command-line argument
* `urls` host configuration key
* [UseUrls](xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls%2A) extension method
* [WebApplication.Urls](xref:Microsoft.AspNetCore.Builder.WebApplication.Urls) property

#### URL formats

The URLs indicate the IP or host addresses with ports and protocols that the server listens on. You can omit the port if it's the default for the protocol (typically 80 and 443). URLs can be in any of the following formats.

* IPv4 address with port number:

  ```url
  http://65.55.39.10:80/
  ```

  `0.0.0.0` is a special case that binds to all IPv4 addresses.

* IPv6 address with port number:

  ```url
  http://[0:0:0:0:0:ffff:4137:270a]:80/
  ```

  `[::]` is the IPv6 equivalent of IPv4 `0.0.0.0`.

* Wildcard (`*`) host with port number:

  ```url
  http://contoso.com:80/
  http://*:80/
  ```

  Anything not recognized as a valid IP address or `localhost` is treated as a wildcard that binds to all IPv4 and IPv6 addresses. Some developers prefer to use the asterisk `*` or plus symbol `+` to be more explicit. To bind different host names to different ASP.NET Core apps on the same port, use [HTTP.sys](xref:fundamentals/servers/httpsys) or a reverse proxy server. Reverse proxy server examples include IIS, YARP, Nginx, and Apache.

* Host name `localhost` with port number or loopback IP with port number:

  ```url
  http://localhost:5000/
  http://127.0.0.1:5000/
  http://[::1]:5000/
  ```

  When `localhost` is specified, Kestrel attempts to bind to both IPv4 and IPv6 loopback interfaces. If the requested port is in use by another service on either loopback interface, Kestrel fails to start. If either loopback interface is unavailable for any other reason (most commonly because IPv6 isn't supported), Kestrel logs a warning.

* Specify multiple URL prefixes by using a semicolon (`;`) delimiter, for example:

  ```url
  http://*:5000;http://localhost:5001;https://hostname:5002
  ```

For more information, see [Override configuration](xref:fundamentals/host/web-host#override-configuration).

#### HTTPS URL prefixes

You can define endpoints by using HTTPS URL prefixes only if a default certificate is provided in the HTTPS endpoint configuration. For example, use the <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions> configuration or a configuration file. This approach is described in the [Configure HTTPS in appsettings.json](#configure-https-in-appsettingsjson) section later in this article. For more information, see the [Configure HTTPS](#configure-https) section.

### Specify ports only

[!INCLUDE [http-ports](~/includes/http-ports.md)]

### Create endpoints in appsettings.json

Kestrel can load endpoints from an <xref:Microsoft.Extensions.Configuration.IConfiguration> instance. By default, Kestrel configuration is loaded from the `Kestrel` section and endpoints are configured in `Kestrel:Endpoints`:

```json
{
  "Kestrel": {
    "Endpoints": {
      "MyHttpEndpoint": {
        "Url": "http://localhost:8080"
      }
    }
  }
}
```

The example code:

* Uses the _appsettings.json_ file as the configuration source. However, any `IConfiguration` source can be used.
* Adds an endpoint named `MyHttpEndpoint` on port 8080.

For more information about configuring endpoints with JSON, see the [Configure HTTPS in appsettings.json](#configure-https-in-appsettingsjson) and [Configure HTTP protocols in appsettings.json](#configure-http-protocols-in-appsettingsjson) sections later in this article.

#### Reload endpoints from configuration

By default, the endpoint configuration can be reloaded when the configuration source changes. It can be disabled by using the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure(Microsoft.Extensions.Configuration.IConfiguration,System.Boolean)> method.

When a change is signaled:

* The new configuration is compared to the old version. Any endpoint without configuration changes isn't modified.
* Removed or modified endpoints are allowed 5 seconds to complete processing requests and shut down.
* New or modified endpoints are started.

Clients connecting to a modified endpoint might be disconnected or refused while the endpoint is restarted.

#### ConfigurationLoader

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure%2A> returns a <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader>. The loader's <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader.Endpoint(System.String,System.Action{Microsoft.AspNetCore.Server.Kestrel.EndpointConfiguration})> method can be used to supplement a configured endpoint's settings:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigurationLoader":::

`KestrelServerOptions.ConfigurationLoader` can be directly accessed to continue iterating on the existing loader, such as the one provided by the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.WebHost%2A>.

* The configuration section for each endpoint is available on the options in the <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader.Endpoint%2A> method so custom settings can be read.
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure(Microsoft.Extensions.Configuration.IConfiguration)?displayProperty=nameWithType> can be called multiple times, but only the last configuration is used unless `Load` is explicitly called on prior instances. The default host doesn't call `Load` so its default configuration section might be replaced.
* `KestrelConfigurationLoader` mirrors the `Listen` family of APIs from `KestrelServerOptions` as `Endpoint` overloads, so code and config endpoints can be configured in the same place. These overloads don't use names and only consume default settings from configuration.

### Define endpoints in the code

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> provides methods for configuring endpoints in code:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenLocalhost%2A>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenAnyIP%2A>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenNamedPipe%2A>

When both the `Listen` and [UseUrls](#specify-endpoints-with-urls) APIs are used simultaneously, the `Listen` endpoints override the `UseUrls` endpoints.

#### Bind to a TCP socket

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A>, <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenLocalhost%2A>, and <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenAnyIP%2A> methods bind to a TCP socket:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_Listen":::

The example code:

* Configures endpoints that listen on port 5000 and 5001.
* Configures HTTPS for an endpoint with the <xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps%2A> extension method on a <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions> object. For more information, see [Configure HTTPS in code](#configure-https-in-code).

[!INCLUDE [How to make an X.509 cert](~/includes/make-x509-cert.md)]

#### Bind to a Unix socket

Listen on a Unix socket with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> for improved performance with Nginx, as shown in this example:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ListenUnixSocket":::

* In the Nginx configuration file, set the `server` > `location` > `proxy_pass` entry to `http://unix:/tmp/{KESTREL SOCKET}:/;`, where `{KESTREL SOCKET}` is the name of the socket provided to <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A>. In the code exmaple, the name is `kestrel-test.sock`.
* Ensure the socket is writeable by Nginx. (You can set the write permissions on the socket with the `chmod go+w /tmp/kestrel-test.sock` command).

#### Configure endpoint defaults

[ConfigureEndpointDefaults(Action\<ListenOptions>)](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureEndpointDefaults(System.Action{Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions})) specifies configuration that runs for each specified endpoint. Multiple calls to `ConfigureEndpointDefaults` replace the previous configuration.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureEndpointDefaults":::

> [!NOTE]
> Endpoints created by calling the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureEndpointDefaults%2A> don't have the defaults applied.

### Use dynamic port binding

When port number `0` is specified, Kestrel dynamically binds to an available port. The following example shows how to determine the port bound by Kestrel at runtime:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_IServerAddressesFeature":::

Dynamically binding a port isn't available in some scenarios:

* The code calls the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenLocalhost%2A>.
* The code binds together TCP-based HTTP/1.1 or HTTP/2 with QUIC-based HTTP/3.

## Configure HTTPS

Kestrel supports securing endpoints with HTTPS. Data sent over HTTPS is encrypted by using [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246) to increase the security of data transferred between the client and server.

HTTPS requires a TLS certificate. The TLS certificate is stored on the server, and Kestrel is configured to use it. An app can use the [ASP.NET Core HTTPS development certificate](xref:security/enforcing-ssl) in a local development environment. The development certificate isn't installed in nondevelopment environments. In production, a TLS certificate must be explicitly configured. At a minimum, a default certificate must be provided.

How HTTPS and the TLS certificate is configured depends on how endpoints are configured. If [URL prefixes](#specify-endpoints-with-urls) or [only specified ports](#specify-ports-only) are used to define endpoints, HTTPS can be used only if a default certificate is provided in HTTPS endpoint configuration. A default certificate can be configured with the following options:

* [Configure HTTPS in appsettings.json](#configure-https-in-appsettingsjson)
* [Configure HTTPS in code](#configure-https-in-code)

### Configure HTTPS in appsettings.json

A default HTTPS app settings configuration schema is available for Kestrel. Configure multiple endpoints, including the URLs and the certificates to use, either from a file on disk or from a certificate store.

Any HTTPS endpoint that doesn't specify a certificate (`HttpsDefaultCert` in the following example code) falls back to the certificate defined under `Certificates:Default` or the development certificate.

The following example is for the _appsettings.json_ file, but any configuration source can be used:

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

[!INCLUDE [](~/includes/credentials-warning.md)]

#### Schema notes

* Endpoint names are [case-insensitive](xref:fundamentals/configuration/index#configuration-keys-and-values). For example, `HTTPS` and `Https` are equivalent.
* The `Url` parameter is required for each endpoint. The format for this parameter is the same as the top-level `Urls` configuration parameter, but it can have only a single value. For more information, see the [URL formats](#url-formats) section in this article.
* These endpoints replace the values defined in the top-level `Urls` configuration rather than adding to them. Endpoints defined in code with the `Listen` API are cumulative with the endpoints defined in the configuration section.
* The `Certificate` section is optional. If the `Certificate` section isn't specified, the defaults defined in `Certificates:Default` are used. If no defaults are available, the development certificate is used. If there are no defaults and the development certificate isn't present, the server throws an exception and fails to start.
* The `Certificate` section supports multiple certificate sources.
* Any number of endpoints can be defined in `Configuration`, as long as they don't cause port conflicts.

#### Certificate sources

Certificate nodes can be configured to load certificates from various sources:

* `Path` and `Password`: Load _.pfx_ files.
* `Path`, `KeyPath`, and `Password`: Load _.pem_/_.crt_ and _.key_ files.
* `Subject` and `Store`: Load from the certificate store.

For example, the `Certificates:Default` certificate can be specified with the following JSON:

```json
"Default": {
  "Subject": "<subject; required>",
  "Store": "<cert store; required>",
  "Location": "<location; defaults to CurrentUser>",
  "AllowInvalid": "<true or false; defaults to false>"
}
```

#### Configure client certificates in appsettings.json

The [ClientCertificateMode](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode) is used to configure client certificate behavior.

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

[!INCLUDE [](~/includes/credentials-warning.md)]

The default value is `ClientCertificateMode.NoCertificate`, where Kestrel doesn't request or require a certificate from the client.

For more information, see [Configure certificate authentication in ASP.NET Core](xref:security/authentication/certauth).

#### Configure SSL/TLS protocols in appsettings.json

SSL Protocols are protocols used for encrypting and decrypting traffic between two peers, which traditionally are a client and a server.

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

[!INCLUDE [](~/includes/credentials-warning.md)]

The default value, `SslProtocols.None`, causes Kestrel to use the operating system defaults to choose the best protocol. Unless you have a specific reason to select a protocol, use the default.

### Configure HTTPS in code

When you use the `Listen` API, the <xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps%2A> extension method on <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions> is available to configure HTTPS.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_Listen":::

The `ListenOptions.UseHttps` parameters include:

* `filename`: The path and file name of a certificate file, relative to the directory that contains the app's content files.
* `password`: The password required to access the X.509 certificate data.
* `configureOptions`: An `Action` to configure the `HttpsConnectionAdapterOptions`. Returns the `ListenOptions`.
* `storeName`: The certificate store from which to load the certificate.
* `subject`: The subject name for the certificate.
* `allowInvalid`: Indicates whether to consider invalid certificates, such as self-signed certificates.
* `location`: The store location to load the certificate from.
* `serverCertificate`: The X.509 certificate.

For a complete list of `UseHttps` overloads, see <xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps%2A>.

#### Configure client certificates in code

The <xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode> configures the client certificate requirements.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsClientCertificateMode":::

The default value is <xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.NoCertificate> (0), where Kestrel doesn't request or require a certificate from the client.

For more information, see [Configure certificate authentication in ASP.NET Core](xref:security/authentication/certauth).

#### Configure HTTPS defaults in code

The [ConfigureHttpsDefaults(Action\<HttpsConnectionAdapterOptions>)](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureHttpsDefaults(System.Action{Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions})) specifies a configuration `Action` to run for each HTTPS endpoint. Multiple calls to `ConfigureHttpsDefaults` replace prior `Action` instances with the last `Action` specified.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaults":::

> [!NOTE]
> Endpoints created by calling the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureHttpsDefaults%2A> don't have the defaults applied.

#### Configure SSL/TLS protocols in code

SSL protocols are protocols used for encrypting and decrypting traffic between two peers, which traditionally are a client and a server.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsSslProtocols":::

#### Configure TLS cipher suites filter in code

On Linux, a <xref:System.Net.Security.CipherSuitesPolicy> object can be used to filter TLS handshakes on a per-connection basis:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsCipherSuitesPolicy":::

## Configure Server Name Indication

[Server Name Indication (SNI)](https://tools.ietf.org/html/rfc6066#section-3) can be used to host multiple domains on the same IP address and port. SNI can be used to conserve resources by serving multiple sites from one server.

For SNI to function, the client sends the host name for the secure session to the server during the TLS handshake so the server can provide the correct certificate. The client uses the furnished certificate for encrypted communication with the server during the secure session that follows the TLS handshake.

All websites must run on the same Kestrel instance. Kestrel doesn't support sharing an IP address and port across multiple instances without a reverse proxy.

SNI can be configured in two ways:

* Configure a mapping between host names and HTTPS options in [Configuration](xref:fundamentals/configuration/index). For example, specify JSON in the _appsettings.json_ file.
* Create an endpoint in code and select a certificate by using the host name with the <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.ServerCertificateSelector%2A> callback property.

### Configure SNI in appsettings.json

Kestrel supports SNI defined in configuration. An endpoint can be configured with an `Sni` object that contains a mapping between host names and HTTPS options. The connection host name is matched to the options and they're used for that connection.

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

[!INCLUDE [](~/includes/credentials-warning.md)]

SNI can override the following HTTPS options:

* `Certificate` configures the [certificate source](#certificate-sources).
* `Protocols` configures the allowed [HTTP protocols](xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols).
* `SslProtocols` configures the allowed [SSL protocols](xref:System.Security.Authentication.SslProtocols).
* `ClientCertificateMode` configures the [client certificate requirements](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode).

The host name supports the following wildcard matching:

- **Exact match**: For example, `a.example.org` matches `a.example.org`.
- **Wildcard prefix**: If there are multiple wildcard matches, the longest pattern is selected. For example, `*.example.org` matches `b.example.org` and `c.example.org`.
- **Full wildcard**: The wildcard `*` matches everything else, including clients that don't use SNI and don't send a host name.

The matched SNI configuration is applied to the endpoint for the connection, overriding values on the endpoint. If a connection doesn't match a configured SNI host name, the connection is refused.

### Configure SNI with code

Kestrel supports SNI with several callback APIs:

* `ServerCertificateSelector`
* `ServerOptionsSelectionCallback`
* `TlsHandshakeCallbackOptions`

#### SNI with `ServerCertificateSelector`

Kestrel supports SNI via the `ServerCertificateSelector` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ServerCertificateSelector":::

#### SNI with `ServerOptionsSelectionCallback`

Kestrel supports more dynamic TLS configuration via the `ServerOptionsSelectionCallback` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate and TLS configuration. Default certificates and `ConfigureHttpsDefaults` aren't used with this callback.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ServerOptionsSelectionCallback":::

#### SNI with `TlsHandshakeCallbackOptions`

Kestrel supports more dynamic TLS configuration via the `TlsHandshakeCallbackOptions.OnConnection` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate, TLS configuration, and other server options. Default certificates and `ConfigureHttpsDefaults` aren't used with this callback.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_TlsHandshakeCallbackOptions":::

## Configure HTTP protocols

Kestrel supports all commonly used HTTP versions. Endpoints can be configured to support different HTTP versions by using the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols> enum, which specifies available HTTP version options.

TLS is required to support more than one HTTP version. The TLS [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) handshake is used to negotiate the connection protocol between the client and the server when an endpoint supports multiple protocols. 

| HttpProtocols value | Allowed protocol | Notes |
|---|---|---|
| `Http1` | HTTP/1.1 | Can be used with or without TLS. |
| `Http2` | HTTP/2 | Can be used without TLS, only if the client supports a [Prior Knowledge mode](https://tools.ietf.org/html/rfc7540#section-3.4). |
| `Http3` | HTTP/3 | **Requires TLS**. The client might need to be configured to use HTTP/3 only. |
| `Http1AndHttp2` | HTTP/1.1 <br> HTTP/2 | HTTP/2 requires the client to select HTTP/2 in the TLS [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) handshake. Otherwise, the connection defaults to HTTP/1.1. |
| `Http1AndHttp2AndHttp3` | HTTP/1.1 <br> HTTP/2 <br> HTTP/3 | The first client request normally uses HTTP/1.1 or HTTP/2. The ['alt-svc' response header](xref:fundamentals/servers/kestrel/http3#alt-svc) prompts the client to upgrade to HTTP/3. HTTP/2 and HTTP/3 requires TLS. Otherwise, the connection defaults to HTTP/1.1. |

The default protocol value for an endpoint is `HttpProtocols.Http1AndHttp2`.

### TLS restrictions for HTTP/2

When you use the HTTP/2 protocol for the connection, the following TLS restrictions apply:

* Requires TLS version 1.2 or later
* Renegotiation is disabled
* Compression is disabled
* Minimum ephemeral key exchange sizes:
  * Elliptic curve Diffie-Hellman (ECDHE) (see [[RFC 4492](https://www.ietf.org/rfc/rfc4492.txt)]): 224 bits minimum
  * Finite field Diffie-Hellman (DHE) (see TLS12 in [[RFC 5246](https://www.rfc-editor.org/rfc/rfc5246)]): 2,048 bits minimum
* The Cipher suite isn't prohibited. 

The `TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256` format (see TLS-ECDHE in [[RFC 8422](https://www.rfc-editor.org/rfc/rfc8422)]) with the P-256 elliptic curve (see [[FIPS186](https://csrc.nist.gov/pubs/fips/186-5/final)]) is supported by default.

### Configure HTTP protocols in appsettings.json

The following the _appsettings.json_ file example establishes the HTTP/1.1 connection protocol for a specific endpoint:

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

A default protocol can be configured in the `Kestrel:EndpointDefaults` section. The following _appsettings.json_ file example establishes HTTP/1.1 as the default connection protocol for all endpoints:

```json
{
  "Kestrel": {
    "EndpointDefaults": {
      "Protocols": "Http1"
    }
  }
}
```

Protocols specified in code override values set by configuration.

### Configure HTTP protocols in code

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions.Protocols?displayProperty=nameWithType> is used to specify protocols with the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols> enum.

The following example configures an endpoint for HTTP/1.1, HTTP/2, and HTTP/3 connections on port 8000. Connections are made secure with TLS and a supplied certificate:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelProtocols":::

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

## Customize Kestrel named pipe endpoints

Kestrel's named pipe support includes advanced customization options. The [CreateNamedPipeServerStream](/dotnet/api/microsoft.aspnetcore.server.kestrel.transport.namedpipes.namedpipetransportoptions.createnamedpipeserverstream) property on the named pipe options allows pipes to be customized per-endpoint.

This approach is useful in a Kestrel app that requires two pipe endpoints with different [access security](/windows/win32/ipc/named-pipe-security-and-access-rights). The `CreateNamedPipeServerStream` option can be used to create pipes with custom security settings, depending on the pipe name.

:::code language="csharp" source="~/fundamentals/servers/kestrel/endpoints/samples/KestrelNamedEP/Program.cs" highlight="15-33" id="snippet_1":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Related content

* [Kestrel web server in ASP.NET Core](xref:fundamentals/servers/kestrel)
* [Configure options for the ASP.NET Core Kestrel web server](xref:fundamentals/servers/kestrel/options)

:::moniker-end

[!INCLUDE [endpoints5-7](~/fundamentals/servers/kestrel/endpoints/includes/endpoints5-7.md)]
