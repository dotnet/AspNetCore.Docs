---
title: Configure endpoints for the ASP.NET Core Kestrel web server
author: tdykstra
description: Learn about configuring endpoints with Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/15/2023
uid: fundamentals/servers/kestrel/endpoints
---

# Configure endpoints for the ASP.NET Core Kestrel web server

:::moniker range="< aspnetcore-7.0"
[!INCLUDE [](~/includes/not-latest-version.md)]
:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Endpoints in ASP.NET Core Kestrel provide the infrastructure for listening to incoming requests and routing them to the appropriate middleware. An endpoint in Kestrel is defined by a combination of an address and a protocol.

* The address specifies the network interface and port on which the server listens for incoming requests. This can be a specific IP address, such as localhost or a public IP, along with a port number.
* The protocol defines the communication standard that is used between the client and server, such as HTTP or HTTPS, or the HTTP version. Endpoints can be configured to support HTTP or HTTPS, depending on the environment (development or production) and the requirements of the application.

## Default bindings

ASP.NET Core projects are configured to bind to a random HTTP port between 5000-5300 and a random HTTPS port between 7000-7300. This default configuration is specified in the generated `Properties/launchSettings.json` file and can be overridden. If no ports are specified, Kestrel binds to `http://localhost:5000`.

## Configure endpoints with URLs

The following sections explain how to configure endpoints using the:

* `ASPNETCORE_URLS` environment variable.
* `--urls` command-line argument.
* `urls` host configuration key.
* <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls%2A> extension method.
* <xref:Microsoft.AspNetCore.Builder.WebApplication.Urls?displayProperty=nameWithType> property.

### URL formats

The URLs indicate the IP addresses or host addresses with ports and protocols that the server should listen on. URLs can be in any of the following formats.

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

* Wildcard host with port number

  ```
  http://contoso.com:80/
  http://*:80/
  ```

  Host names, `*`, and `+`, aren't special. Anything not recognized as a valid IP address or `localhost` binds to all IPv4 and IPv6 IP addresses. To bind different host names to different ASP.NET Core apps on the same port, use [HTTP.sys](xref:fundamentals/servers/httpsys) or a reverse proxy server.

  Reverse proxy server examples include IIS, Nginx, and Apache. Hosting in a reverse proxy configuration requires [host filtering](xref:fundamentals/servers/kestrel/host-filtering).

* Host name `localhost` with port number or loopback IP with port number

  ```
  http://localhost:5000/
  http://127.0.0.1:5000/
  http://[::1]:5000/
  ```

  When `localhost` is specified, Kestrel attempts to bind to both IPv4 and IPv6 loopback interfaces. If the requested port is in use by another service on either loopback interface, Kestrel fails to start. If either loopback interface is unavailable for any other reason (most commonly because IPv6 isn't supported), Kestrel logs a warning.

Multiple URL prefixes can be specified by using a semicolon (`;`) delimiter:

```
http://*:5000;http://localhost:5001;https://hostname:5002
```

For more information, see [Override configuration](xref:fundamentals/host/web-host#override-configuration).

### Port 0

When the port number `0` is specified, Kestrel dynamically binds to an available port. The following example shows how to determine which port Kestrel bound at runtime:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_IServerAddressesFeature":::

Dynamically binding a port isn't available in some situations:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenLocalhost%2A?displayProperty=nameWithType>
* Binding TCP-based HTTP/1.1 or HTTP/2, and QUIC-based HTTP/3 together.

### Specify ports only

[!INCLUDE [http-ports](~/includes/http-ports.md)]

### HTTPS URL prefixes

HTTPS URL prefixes can be used to define endpoints only if a default certificate is provided in the HTTPS endpoint configuration. For example, use <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions> configuration or a configuration file, as shown [later in this article](#configure-certificates-in-appsettingsjson).

For more information, see [Configure HTTPS](#configure-https) later in this article.

## Configure endpoints in appsettings.json 

Kestrel can load endpoints from an <xref:Microsoft.Extensions.Configuration.IConfiguration> instance. The following sections provide configuration examples in `appsettings.json`. However, any configuration source can be used.  
The configuration must be scoped to the `Kestrel` configuration section. for example:

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

The `Configure(IConfiguration, bool)` overload can be used to enable reloading endpoints when the configuration source changes. Reloading endpoint configuration is enabled by default. If a change is signaled, the following steps are taken:

* The new configuration is compared to the old one, and any endpoint without configuration changes isn't modified.
* Removed or modified endpoints are given 5 seconds to complete processing requests and shut down.
* New or modified endpoints are started.

Clients connecting to a modified endpoint may be disconnected or refused while the endpoint is restarted.

The following sections provide configuration examples in `appsettings.json`. However, any configuration source can be used.

### Configure certificates in appsettings.json

A default HTTPS app settings configuration schema is available for Kestrel. Configure multiple endpoints, including the URLs and the certificates to use, either from a file on disk or from a certificate store.

As noted earlier, the following example is for `appsettings.json`, but any configuration source can be used:

* Set `AllowInvalid` to `true` to permit the use of invalid certificates (for example, self-signed certificates).
* Any HTTPS endpoint that doesn't specify a certificate (`HttpsDefaultCert` in the example that follows) falls back to the certificate defined under `Certificates:Default` or the development certificate.

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

[!INCLUDE [](../../../includes/credentials-warning.md)]

#### Schema notes

* Endpoint names are [case-insensitive](xref:fundamentals/configuration/index#configuration-keys-and-values). For example, `HTTPS` and `Https` are equivalent.
* The `Url` parameter is required for each endpoint. The format for this parameter is the same as the top-level `Urls` configuration parameter except that it's limited to a single value. See [URL formats](#url-formats) earlier in this article.
* These endpoints replace the ones defined in the top-level `Urls` configuration rather than adding to them. Endpoints defined in code via `Listen` are cumulative with the endpoints defined in the configuration section.
* The `Certificate` section is optional. If the `Certificate` section isn't specified, the defaults defined in `Certificates:Default` are used. If no defaults are available, the development certificate is used. If there are no defaults and the development certificate isn't present, the server throws an exception and fails to start.
* The `Certificate` section supports multiple certificate sources.
* Any number of endpoints may be defined in `Configuration`, as long as they don't cause port conflicts.

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

### Configure client certificates in appsettings.json

[ClientCertificateMode](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode) is used to configure client certificate behavior.

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

<!-- [!INCLUDE [](../../../includes/credentials-warning.md)] -->

The default value is `ClientCertificateMode.NoCertificate`, where Kestrel won't request or require a certificate from the client.

For more information, see <xref:security/authentication/certauth>.

### ConfigurationLoader

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure(Microsoft.Extensions.Configuration.IConfiguration)?displayProperty=nameWithType> returns a <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader> with an <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader.Endpoint(System.String,System.Action{Microsoft.AspNetCore.Server.Kestrel.EndpointConfiguration})> method that can be used to supplement a configured endpoint's settings:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigurationLoader":::

`KestrelServerOptions.ConfigurationLoader` can be directly accessed to continue iterating on the existing loader, such as the one provided by <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.WebHost%2A?displayProperty=nameWithType>.

* The configuration section for each endpoint is available on the options in the <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader.Endpoint%2A> method so that custom settings may be read.
* Multiple configurations can be loaded by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure(Microsoft.Extensions.Configuration.IConfiguration)?displayProperty=nameWithType> again with another section. Only the last configuration is used, unless `Load` is explicitly called on prior instances. The metapackage doesn't call `Load` so that its default configuration section may be replaced.
* `KestrelConfigurationLoader` mirrors the `Listen` family of APIs from `KestrelServerOptions` as `Endpoint` overloads, so code and config endpoints can be configured in the same place. These overloads don't use names and only consume default settings from configuration.

## Configure endpoints in code

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> provides methods for configuring endpoints:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A>

When both the `Listen` and [UseUrls](#configure-endpoints-with-urls) APIs are used simultaneously, the `Listen` endpoints override the `UseUrls` endpoints.

### Change defaults in code

`ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` can be used to change default settings for `ListenOptions` and `HttpsConnectionAdapterOptions`, including overriding the default certificate specified in the prior scenario. `ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` should be called before any endpoints are configured.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureEndpointDefaultsConfigureHttpsDefaults":::

#### Configure endpoint defaults in code

[`ConfigureEndpointDefaults(Action<ListenOptions>)`](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureEndpointDefaults(System.Action{Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions}) Specifies a configuration `Action` to run for each specified endpoint. Calling `ConfigureEndpointDefaults` multiple times replaces prior `Action` instances with the last `Action` specified.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureEndpointDefaults":::

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureEndpointDefaults%2A> won't have the defaults applied.

#### Configure HTTPS defaults in code

[ConfigureHttpsDefaults(Action\<HttpsConnectionAdapterOptions>](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureHttpsDefaults(System.Action{Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions}) specifies a configuration `Action` to run for each HTTPS endpoint. Calling `ConfigureHttpsDefaults` multiple times replaces prior `Action` instances with the last `Action` specified.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaults":::

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureHttpsDefaults%2A> won't have the defaults applied.

### Configure certificates in code

In production, HTTPS must be explicitly configured. At a minimum, a default certificate must be provided.

`UseUrls`, the `--urls` command-line argument, `urls` host configuration key, and the `ASPNETCORE_URLS` environment variable have the limitation that a default certificate must be available for HTTPS endpoint configuration. When using the `Listen` API, the <xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps%2A> extension method on <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions> is available to configure HTTPS. Here are some of the overloads of that method:

* `UseHttps()`: Configure Kestrel to use HTTPS with the default certificate. Throws an exception if no default certificate is configured.
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

For a complete list of `UseHttps` overloads, see <xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps%2A>.

### Configure client certificates in code

<xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode> configures the client certificate requirements.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsClientCertificateMode":::

The default value is <xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.NoCertificate>, where Kestrel won't request or require a certificate from the client.

For more information, see <xref:security/authentication/certauth>.

### Bind to a TCP socket

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> method binds to a TCP socket, and an options lambda permits X.509 certificate configuration:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_Listen":::

The example configures HTTPS for an endpoint with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions>. Use the same API to configure other Kestrel settings for specific endpoints.

[!INCLUDE [How to make an X.509 cert](~/includes/make-x509-cert.md)]

### Bind to a Unix socket

Listen on a Unix socket with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> for improved performance with Nginx, as shown in this example:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ListenUnixSocket":::

* In the Nginx configuration file, set the `server` > `location` > `proxy_pass` entry to `http://unix:/tmp/{KESTREL SOCKET}:/;`. `{KESTREL SOCKET}` is the name of the socket provided to <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> (for example, `kestrel-test.sock` in the preceding example).
* Ensure that the socket is writeable by Nginx (for example, `chmod go+w /tmp/kestrel-test.sock`).

### Dynamic port binding

For information about dynamic port binding, see [Port 0](#port-0) earlier in this article.

## Configure HTTPS

Kestrel supports securing endpoints with HTTPS. The way you configure HTTPS depends on how endpoints are defined.

If [URL prefixes](#configure-endpoints-with-urls) are used to define endpoints, HTTPS can be used only if a default certificate is provided in HTTPS endpoint configuration. For example, use <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> configuration or a configuration file as shown [earlier in this article](#configure-certificates-in-appsettingsjson).

For more information about configuring HTTPS, such as using configuration or code to specify SSL certificates and SSL/TLS protocols, see the following sections of this article:

* [Configure certificates in appsettings.json](#configure-certificates-in-appsettingsjson)
* [Configure client certificates in appsettings.json](#configure-client-certificates-in-appsettingsjson)
* [Certificate sources](#certificate-sources)
* [Configure HTTPS defaults in code](#configure-https-defaults-in-code)
* [Configure certificates in code](#configure-certificates-in-code)
* [Configure client certificates in code](#configure-client-certificates-in-code)
* [Configure endpoints using Server Name Indication (SNI)](#configure-endpoints-using-server-name-indication)
* [Connection middleware](#connection-middleware)
* [Configure endpoint protocols](#configure-endpoint-protocols)

To create a development certificate, use the [dev-certs tool](/dotnet/core/tools/dotnet-dev-certs). The tool is automatically installed when the [.NET SDK](/dotnet/core/sdk) is installed.

The development certificate is available only for the user that generates the certificate. Some browsers require granting explicit permission to trust the local development certificate.

Many ASP.NET Core project templates configure apps to run on HTTPS by default and include [HTTPS redirection and HSTS support](xref:security/enforcing-ssl).

## Configure endpoints using Server Name Indication

[Server Name Indication (SNI)](https://tools.ietf.org/html/rfc6066#section-3) can be used to host multiple domains on the same IP address and port. For SNI to function, the client sends the host name for the secure session to the server during the TLS handshake so that the server can provide the correct certificate. The client uses the furnished certificate for encrypted communication with the server during the secure session that follows the TLS handshake.

All websites must run on the same Kestrel instance. Kestrel doesn't support sharing an IP address and port across multiple instances without a reverse proxy.

SNI can be configured in two ways:

* Configure a mapping between host names and HTTPS options in [Configuration](xref:fundamentals/configuration/index). For example, JSON in  the `appsettings.json` file.
* Create an endpoint in code and select a certificate using the host name with the <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.ServerCertificateSelector%2A> callback.

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

[!INCLUDE [](../../../includes/credentials-warning.md)]

HTTPS options that can be overridden by SNI:

* `Certificate` configures the [certificate source](#certificate-sources).
* `Protocols` configures the allowed [HTTP protocols](xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols).
* `SslProtocols` configures the allowed [SSL protocols](xref:System.Security.Authentication.SslProtocols).
* `ClientCertificateMode` configures the [client certificate requirements](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode).

The host name supports wildcard matching:

* Exact match. For example, `a.example.org` matches `a.example.org`.
* Wildcard prefix. If there are multiple wildcard matches, then the longest pattern is chosen. For example, `*.example.org` matches `b.example.org` and `c.example.org`.
* Full wildcard. `*` matches everything else, including clients that aren't using SNI and don't send a host name.

The matched SNI configuration is applied to the endpoint for the connection, overriding values on the endpoint. If a connection doesn't match a configured SNI host name, then the connection is refused.

### Configure SNI with code

Kestrel supports SNI with several callback APIs:

* `ServerCertificateSelector`
* `ServerOptionsSelectionCallback`
* `TlsHandshakeCallbackOptions`

#### SNI with `ServerCertificateSelector`

Kestrel supports SNI via the `ServerCertificateSelector` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ServerCertificateSelector":::

#### SNI with `ServerOptionsSelectionCallback`

Kestrel supports additional dynamic TLS configuration via the `ServerOptionsSelectionCallback` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate and TLS configuration. Default certificates and `ConfigureHttpsDefaults` aren't used with this callback.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ServerOptionsSelectionCallback":::

#### SNI with `TlsHandshakeCallbackOptions`

Kestrel supports additional dynamic TLS configuration via the `TlsHandshakeCallbackOptions.OnConnection` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate, TLS configuration, and other server options. Default certificates and `ConfigureHttpsDefaults` aren't used with this callback.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_TlsHandshakeCallbackOptions":::

## IIS endpoint configuration

When using IIS, the URL bindings for IIS override bindings are set by either `Listen` or `UseUrls`. For more information, see [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module).

## Connection middleware

Kestrel endpoints support connection middleware. Connection middleware is software that is assembled into a connection pipeline and runs when Kestrel receives a new connection. Each component:

* Chooses whether to pass the request to the next component in the pipeline.
* Can perform work before and after the next component in the pipeline.

Connection delegates are used to build the connection pipeline. Connection delegates are configured with the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions.Use%2A?displayProperty=nameWithType> method.

Connection middleware is similar to <xref:fundamentals/middleware/index>. The difference is the connection middleware runs per-connection instead of per-request.

### Create custom connection middleware

The following example shows a custom connection middleware that can filter TLS handshakes on a per-connection basis for specific ciphers if necessary. The middleware throws <xref:System.NotSupportedException> for any cipher algorithm that the app doesn't support. Alternatively, define and compare <xref:Microsoft.AspNetCore.Connections.Features.ITlsHandshakeFeature.CipherAlgorithm%2A?displayProperty=nameWithType> to a list of acceptable cipher suites.

No encryption is used with a <xref:System.Security.Authentication.CipherAlgorithmType.Null?displayProperty=nameWithType> cipher algorithm.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelMiddleware":::

### Connection logging

Call <xref:Microsoft.AspNetCore.Hosting.ListenOptionsConnectionLoggingExtensions.UseConnectionLogging%2A> to emit Debug level logs for byte-level communication on a connection. Connection logging is helpful for troubleshooting problems in low-level communication, such as during TLS encryption and behind proxies. If `UseConnectionLogging` is placed before `UseHttps`, encrypted traffic is logged. If `UseConnectionLogging` is placed after `UseHttps`, decrypted traffic is logged. This is built-in [Connection middleware](#connection-middleware).

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelUseConnectionLogging":::

## Configure endpoint protocols

The following configuration examples show `appsettings.json`. However, any configuration source can be used.

### Configure HTTP protocols in appsettings.json

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

### Configure SSL/TLS protocols in appsettings.json

SSL Protocols are protocols used for encrypting and decrypting traffic between two peers, traditionally a client and a server.

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

[!INCLUDE [](../../../includes/credentials-warning.md)]

The default value, `SslProtocols.None`, causes Kestrel to use the operating system defaults to choose the best protocol. Unless you have a specific reason to select a protocol, use the default.

### Configure HTTP protocols in code

The `Protocols` property of `ListenOptions` establishes the HTTP protocols (`HttpProtocols`) enabled on a connection endpoint or for the server. Assign a value to the `Protocols` property from the `HttpProtocols` enum.

| `HttpProtocols` enum value | Connection protocol permitted |
|--|--|
| `Http1` | HTTP/1.1 only. Can be used with or without TLS. |
| `Http2` | HTTP/2 only. May be used without TLS only if the client supports a [Prior Knowledge mode](https://tools.ietf.org/html/rfc7540#section-3.4). |
| `Http3` | HTTP/3 only. Requires TLS. The client may need to be configured to use HTTP/3 only. |
| `Http1AndHttp2` | HTTP/1.1 and HTTP/2. HTTP/2 requires the client to select HTTP/2 in the TLS [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) handshake; otherwise, the connection defaults to HTTP/1.1. |
| `Http1AndHttp2AndHttp3` | HTTP/1.1, HTTP/2 and HTTP/3. The first client request normally uses HTTP/1.1 or HTTP/2, and the [`alt-svc` response header](xref:fundamentals/servers/kestrel/http3#alt-svc) prompts the client to upgrade to HTTP/3. HTTP/2 and HTTP/3 requires TLS; otherwise, the connection defaults to HTTP/1.1. |

The default `ListenOptions.Protocols` value for any endpoint is `HttpProtocols.Http1AndHttp2AndHttp3`.

TLS restrictions for HTTP/2:

* TLS version 1.2 or later
* Renegotiation disabled
* Compression disabled
* Minimum ephemeral key exchange sizes:
  * Elliptic curve Diffie-Hellman (ECDHE) &lbrack;[RFC4492](https://www.ietf.org/rfc/rfc4492.txt)&rbrack;: 224 bits minimum
  * Finite field Diffie-Hellman (DHE) &lbrack;`TLS12`&rbrack;: 2048 bits minimum
* Cipher suite not prohibited. 

`TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256` &lbrack;`TLS-ECDHE`&rbrack; with the P-256 elliptic curve &lbrack;`FIPS186`&rbrack; is supported by default.

The following example permits HTTP/1.1, HTTP/2, and HTTP/3 connections on port 8000. Connections are secured by TLS with a supplied certificate:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelProtocols":::

On Linux, <xref:System.Net.Security.CipherSuitesPolicy> can be used to filter TLS handshakes on a per-connection basis:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsCipherSuitesPolicy":::

### Configure SSL/TLS protocols in code

SSL protocols are protocols used for encrypting and decrypting traffic between two peers, traditionally a client and a server.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureHttpsDefaultsSslProtocols":::

## See also

<xref:fundamentals/servers/kestrel>
<xref:fundamentals/servers/kestrel/options>

:::moniker-end

[!INCLUDE [endpoints5-7](~/fundamentals/servers/kestrel/endpoints/includes/endpoints5-7.md)]
