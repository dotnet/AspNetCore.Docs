:::moniker range="= aspnetcore-7.0"

[HTTP/3](https://datatracker.ietf.org/doc/rfc9114/) is a proposed standard and the third major version of HTTP. This article discusses requirements for HTTP/3. HTTP/3 is fully supported in ASP.NET Core 7.0 and later.

> [!IMPORTANT]
> Apps configured to take advantage of HTTP/3 should be designed to also support HTTP/1.1 and HTTP/2.

## HTTP/3 requirements

HTTP/3 has different requirements depending on the operating system. If the platform that Kestrel is running on doesn't have all the requirements for HTTP/3 then it's disabled, and Kestrel will fallback to other HTTP protocols.

### Windows

* Windows 11 Build 22000 or later OR Windows Server 2022.
* TLS 1.3 or later connection.

### Linux

* `libmsquic` package installed.

`libmsquic` is published via Microsoft's official Linux package repository at `packages.microsoft.com`. To install this package:

1. Add the `packages.microsoft.com` repository. See [Linux Software Repository for Microsoft Products](/windows-server/administration/linux-package-repository-for-microsoft-software) for instructions.
2. Install the `libmsquic` package using the distro's package manager. For example, `apt install libmsquic=1.9*` on Ubuntu.

**Note:** .NET 6 is only compatible with the 1.9.x versions of libmsquic. Libmsquic 2.x is not compatible due to breaking changes. Libmsquic receives updates to 1.9.x when needed to incorporate security fixes.  

### macOS

HTTP/3 isn't currently supported on macOS and may be available in a future release.

## Getting started

HTTP/3 is not enabled by default. Add configuration to `Program.cs` to enable HTTP/3.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_Http3" highlight="7-8":::

The preceding code configures port 5001 to:

* Use HTTP/3 alongside HTTP/1.1 and HTTP/2 by specifying `HttpProtocols.Http1AndHttp2AndHttp3`.
* Enable HTTPS with `UseHttps`. HTTP/3 requires HTTPS.

Because not all routers, firewalls, and proxies properly support HTTP/3, HTTP/3 should be configured together with HTTP/1.1 and HTTP/2. This can be done by specifying [`HttpProtocols.Http1AndHttp2AndHttp3`](xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2AndHttp3) as an endpoint's supported protocols.

For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

## Alt-svc

HTTP/3 is discovered as an upgrade from HTTP/1.1 or HTTP/2 via the [`alt-svc`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Alt-Svc) header. That means the first request will normally use HTTP/1.1 or HTTP/2 before switching to HTTP/3. Kestrel automatically adds the `alt-svc` header if HTTP/3 is enabled.

## Localhost testing

* Browsers don't allow self-signed certificates on HTTP/3 such as the Kestrel development certificate.
* `HttpClient` can be used for localhost/loopback testing in .NET 6 or later. Extra configuration is required when using `HttpClient` to make an HTTP/3 request:

  * Set [`HttpRequestMessage.Version`](xref:System.Net.Http.HttpRequestMessage.Version) to 3.0, or
  * Set [`HttpRequestMessage.VersionPolicy`](xref:System.Net.Http.HttpRequestMessage.VersionPolicy) to [`HttpVersionPolicy.RequestVersionOrHigher`](xref:System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher).

## HTTP/3 benefits

HTTP/3 uses the same semantics as HTTP/1.1 and HTTP/2: the same request methods, status codes, and message fields apply to all versions. The differences are in the underlying transport. Both HTTP/1.1 and HTTP/2 use TCP as their transport. HTTP/3 uses a new transport technology developed alongside HTTP/3 called [QUIC](https://datatracker.ietf.org/doc/html/draft-ietf-quic-transport-34).

HTTP/3 and QUIC have a number of benefits compared to HTTP/1.1 and HTTP/2:

* Faster response time of the first request. QUIC and HTTP/3 negotiates the connection in fewer round-trips between the client and the server. The first request reaches the server faster.
* Improved experience when there is connection packet loss. HTTP/2 multiplexes multiple requests via one TCP connection. Packet loss on the connection affects all requests. This problem is called "head-of-line blocking". Because QUIC provides native multiplexing, lost packets only impact the requests where data has been lost.
* Supports transitioning between networks. This feature is useful for mobile devices where it is common to switch between WIFI and cellular networks as a mobile device changes location. Currently HTTP/1.1 and HTTP/2 connections fail with an error when switching networks. An app or web browsers must retry any failed HTTP requests. HTTP/3 allows the app or web browser to seamlessly continue when a network changes. Kestrel doesn't support network transitions in .NET 6. It may be available in a future release.

:::moniker-end

:::moniker range="= aspnetcore-6.0"

[HTTP/3](https://datatracker.ietf.org/doc/rfc9114/) is the third and upcoming major version of HTTP. This article discusses requirements for HTTP/3 and how to configure Kestrel to use it.

> [!IMPORTANT]
> HTTP/3 is available in .NET 6 as a *preview feature*. The HTTP/3 specification isn't finalized and behavioral or performance issues may exist in HTTP/3 with .NET 6.
> 
> For more information on preview feature support, see [the preview features supported section](https://github.com/dotnet/designs/blob/main/accepted/2021/preview-features/preview-features.md#are-preview-features-supported).
>
> Apps configured to take advantage of HTTP/3 should be designed to also support HTTP/1.1 and HTTP/2. If issues are identified in HTTP/3, we recommend disabling HTTP/3 until the issues are resolved in a future release of ASP.NET Core. Significant issues are reported at the [Announcements GitHub repository](https://github.com/aspnet/Announcements/issues).

## HTTP/3 requirements

HTTP/3 has different requirements depending on the operating system. If the platform that Kestrel is running on doesn't have all the requirements for HTTP/3 then it's disabled, and Kestrel will fallback to other HTTP protocols.

### Windows

* Windows 11 Build 22000 or later OR Windows Server 2022.
* TLS 1.3 or later connection.

### Linux

* `libmsquic` package installed.

`libmsquic` is published via Microsoft's official Linux package repository at `packages.microsoft.com`. To install this package:

1. Add the `packages.microsoft.com` repository. See [Linux Software Repository for Microsoft Products](/windows-server/administration/linux-package-repository-for-microsoft-software) for instructions.
2. Install the `libmsquic` package using the distro's package manager. For example, `apt install libmsquic=1.9*` on Ubuntu.

**Note:** .NET 6 is only compatible with the 1.9.x versions of libmsquic. Libmsquic 2.x is not compatible due to breaking changes. Libmsquic receives updates to 1.9.x when needed to incorporate security fixes.  

### macOS

HTTP/3 isn't currently supported on macOS and may be available in a future release.

## Getting started

HTTP/3 is not enabled by default. Add configuration to `Program.cs` to enable HTTP/3.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_Http3" highlight="7-8":::

The preceding code configures port 5001 to:

* Use HTTP/3 alongside HTTP/1.1 and HTTP/2 by specifying `HttpProtocols.Http1AndHttp2AndHttp3`.
* Enable HTTPS with `UseHttps`. HTTP/3 requires HTTPS.

Because not all routers, firewalls, and proxies properly support HTTP/3, HTTP/3 should be configured together with HTTP/1.1 and HTTP/2. This can be done by specifying `HttpProtocols.Http1AndHttp2AndHttp3` as an endpoint's supported protocols.

For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

## Alt-svc

HTTP/3 is discovered as an upgrade from HTTP/1.1 or HTTP/2 via the `alt-svc` header. That means the first request will normally use HTTP/1.1 or HTTP/2 before switching to HTTP/3. Kestrel automatically adds the `alt-svc` header if HTTP/3 is enabled.

## Localhost testing

* Browsers don't allow self-signed certificates on HTTP/3 such as the Kestrel development certificate.
* `HttpClient` can be used for localhost/loopback testing in .NET 6 or later. Extra configuration is required when using `HttpClient` to make an HTTP/3 request:

  * Set `HttpRequestMessage.Version` to 3.0, or
  * Set `HttpRequestMessage.VersionPolicy` to `HttpVersionPolicy.RequestVersionOrHigher`.

## Limitations

Some HTTPS scenarios are not yet supported for HTTP/3 in Kestrel. When calling `Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps` with <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions> while using HTTP/3, setting the following options on the <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions> is a no-op (it does nothing):
* <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.HandshakeTimeout>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.OnAuthenticate>

Calling the following implementations of `Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps` throw an error when using HTTP/3:

* [UseHttps(this ListenOptions listenOptions, ServerOptionsSelectionCallback serverOptionsSelectionCallback, object state, TimeSpan handshakeTimeout)](xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps(Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions,System.Net.Security.ServerOptionsSelectionCallback,System.Object,System.TimeSpan))
* [UseHttps(this ListenOptions listenOptions, TlsHandshakeCallbackOptions callbackOptions)](xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps(Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions,Microsoft.AspNetCore.Server.Kestrel.Https.TlsHandshakeCallbackOptions))

## HTTP/3 benefits

HTTP/3 uses the same semantics as HTTP/1.1 and HTTP/2: the same request methods, status codes, and message fields apply to all versions. The differences are in the underlying transport. Both HTTP/1.1 and HTTP/2 use TCP as their transport. HTTP/3 uses a new transport technology developed alongside HTTP/3 called [QUIC](https://datatracker.ietf.org/doc/html/draft-ietf-quic-transport-34).

HTTP/3 and QUIC have a number of benefits compared to HTTP/1.1 and HTTP/2:

* Faster response time of the first request. QUIC and HTTP/3 negotiates the connection in fewer round-trips between the client and the server. The first request reaches the server faster.
* Improved experience when there is connection packet loss. HTTP/2 multiplexes multiple requests via one TCP connection. Packet loss on the connection affects all requests. This problem is called "head-of-line blocking". Because QUIC provides native multiplexing, lost packets only impact the requests where data has been lost.
* Supports transitioning between networks. This feature is useful for mobile devices where it is common to switch between WIFI and cellular networks as a mobile device changes location. Currently HTTP/1.1 and HTTP/2 connections fail with an error when switching networks. An app or web browsers must retry any failed HTTP requests. HTTP/3 allows the app or web browser to seamlessly continue when a network changes. Kestrel doesn't support network transitions in .NET 6. It may be available in a future release.

:::moniker-end
