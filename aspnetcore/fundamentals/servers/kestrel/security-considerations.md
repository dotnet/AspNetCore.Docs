---
title: Security considerations for the ASP.NET Core Kestrel web server
ai-usage: ai-assisted
author: BrennanConroy
description: Learn about the security considerations, configurable limits, and behavioral decisions in Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-8.0'
ms.author: brecon
ms.custom: mvc
ms.date: 07/13/2026
uid: fundamentals/servers/kestrel/security-considerations
---
# Security considerations for the ASP.NET Core Kestrel web server

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

This article describes the security considerations, configurable limits, and behavioral decisions in Kestrel—the cross-platform HTTP server for ASP.NET Core. It's intended for both **application developers** configuring Kestrel in production and **security auditors** reviewing its threat surface.

Kestrel can be deployed as an **[edge server](#edge-server-direct-internet-exposure)** directly exposed to the internet or **[behind a reverse proxy](#behind-a-reverse-proxy)** such as YARP, IIS Application Request Routing (ARR), nginx proxy_pass, or [Azure App Service frontend](https://devblogs.microsoft.com/dotnet/bringing-kestrel-and-yarp-to-azure-app-services/). The security posture differs significantly between these topologies, and this article calls out the differences where applicable.

> [!IMPORTANT]
> Kestrel includes limits, timeouts, protocol validation, and middleware integration points that help reduce the impact of malformed traffic and some resource-exhaustion patterns. It is **not intended to be the primary defense against distributed denial-of-service (DDoS) attacks**. Applications exposed to the public internet should rely on appropriate upstream network and OSI layer 4 proxy protections for volumetric attack mitigation. YARP operates as a layer 7 proxy.

> [!NOTE]
> The snippets in this article use ASP.NET Core's minimal hosting model:
>
> ```csharp
> var builder = WebApplication.CreateBuilder(args);
>
> builder.WebHost.ConfigureKestrel(options =>
> {
>     // "options" is KestrelServerOptions
> });
>
> var app = builder.Build();
>
> // Middleware goes here
>
> app.Run();
> ```
>
> Unless otherwise noted, snippets show only the relevant portion and omit unrelated service registrations, endpoint mappings, and `app.Run()`.

## Deployment topologies

Kestrel's security posture depends on where it sits in the network architecture. The two primary deployment models have meaningfully different threat surfaces.

### Edge server (direct internet exposure)

When Kestrel is directly accessible from the internet, it is the first line of defense:

- **Kestrel handles all TLS termination.** Configure [certificates, TLS protocol versions, and client certificate requirements](#transport-security-tlshttps) directly in Kestrel.
- **[Host header filtering](#host-filtering) is critical.** Without a reverse proxy to validate the Host header, Kestrel must do it. Use Host Filtering middleware to prevent DNS rebinding and host header attacks.
- **Don't enable [Forwarded Headers](#forwarded-headers) middleware.** When there is no trusted proxy, processing `X-Forwarded-*` headers allows any client to spoof their IP address, scheme, and host. Also verify the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` environment variable isn't set—see the [environment variable warning](#behind-a-reverse-proxy) in the reverse proxy section.
- **[Rate limiting](#rate-limiting) must be handled by the application.** There is no upstream proxy to absorb floods.
- **[Connection limits](#connection-limits) should be monitored.** The defaults for `MaxConcurrentConnections` and `MaxConcurrentUpgradedConnections` are unlimited. Setting a limit can DoS legitimate requests if the limits are too low, or there is an unexpected surge in traffic. [Metrics](#monitoring-with-metrics) can be used to observe traffic patterns.
- **Don't treat Kestrel limits as DDoS protection.** These settings help bound resource usage, but they aren't a substitute for upstream volumetric-attack defenses. Those are better handled by an OSI layer 4 proxy.
- **[Monitor with metrics](#monitoring-with-metrics).** Use Kestrel's built-in metrics (`kestrel.active_connections`, `kestrel.rejected_connections`, etc.) to detect anomalous traffic patterns and capacity issues.

### Behind a reverse proxy

When Kestrel sits behind a reverse proxy (YARP, IIS Application Request Routing (ARR), nginx proxy_pass, Azure App Service frontend, etc.), the proxy handles TLS termination and some request validation, but the trust boundary between the proxy and Kestrel requires careful configuration.

> [!NOTE]
> YARP itself runs on Kestrel. Placing a YARP reverse proxy in front of your application server still provides security value—the proxy Kestrel instance handles TLS termination, Host validation, rate limiting, and connection management at the edge, while the backend Kestrel instance can focus on application logic with a more restrictive configuration.

Key considerations:

- **[Forwarded Headers](#forwarded-headers) middleware is required** to preserve the original client IP, scheme, and host. Without it, `HttpContext.Connection.RemoteIpAddress` returns the proxy's IP, not the client's. For full configuration details, see the [Forwarded Headers middleware documentation](xref:host-and-deploy/proxy-load-balancer).
- **Authentication and secure-cookie behavior often depend on the restored scheme.** If the proxy terminates TLS but Kestrel still sees the request as `http`, authentication handlers may generate incorrect redirect URIs, secure cookies may not be issued or returned as expected, and policies that require HTTPS can fail.
- **Configure `KnownProxies` or `KnownIPNetworks` explicitly.** By default, Forwarded Headers middleware only trusts the IPv6 loopback address (`::1`). If your proxy's IP isn't in the trusted list, the original client information is discarded.
- **Keep `ForwardLimit` at `1`** unless you have a chain of multiple proxies. Setting it to `null` (unlimited) means any number of `X-Forwarded-For` entries are processed, which can be exploited.
- **Host filtering can be relaxed** if the reverse proxy validates the Host header, but defense-in-depth suggests keeping it enabled.
- **HTTPS redirection may be unnecessary** if the proxy terminates TLS and communicates with Kestrel over a private network. If using forwarded headers then `UseHttpsRedirection()` will noop as it will see the `X-Forwarded-Proto` header as HTTPS, recommend keeping it in that case.

> [!NOTE]
> **Proxy-specific guidance:** The recommendations above are general guidelines. Each reverse proxy has its own configuration model and security features. Consult your proxy's documentation for specifics—for example, see the [YARP documentation](xref:fundamentals/servers/yarp/overview) if you are using YARP as your reverse proxy.

> [!WARNING]
> The Forwarded Headers middleware can be silently enabled with **no proxy restrictions** by setting the environment variable `ASPNETCORE_FORWARDEDHEADERS_ENABLED=true` (or `DOTNET_FORWARDEDHEADERS_ENABLED=true`, or the configuration key `ForwardedHeaders_Enabled`). When enabled this way, the framework **clears `KnownProxies` and `KnownIPNetworks`**, meaning every upstream IP is trusted. This is far more permissive than what is achievable through the C# API, where `KnownProxies` defaults to loopback only. **Verify this variable isn't set in edge deployments**—check your Dockerfiles, orchestrator configs, CI/CD pipelines, and hosting platform defaults.

**Edge deployment**: `CLIENT --[TLS]--> KESTREL`—Kestrel validates everything (TLS, Host, limits).

**Behind a proxy**: `CLIENT --[TLS]--> REVERSE PROXY --[HTTP]--> KESTREL`—the proxy validates Host, rate limits, and terminates TLS; Kestrel trusts the proxy and uses Forwarded Headers with `KnownProxies`.

> [!IMPORTANT]
> **Key principle:** Forwarded Headers middleware should only be enabled when there is a trusted proxy in front of Kestrel. In edge deployments, enabling it allows clients to forge their identity.

### TLS pass-through (proxy without TLS termination)

Some TLS passthrough reverse proxies and load balancers forward encrypted traffic to Kestrel without decrypting it—for example, TCP-level load balancers and SNI-based routers. In this topology, **Kestrel handles TLS termination** even though it sits behind a proxy:

**TLS pass-through**: `CLIENT --[TLS]-- (TCP load balancer) --[TLS]--> KESTREL`—the proxy routes by SNI or port but can't read headers; Kestrel terminates TLS, sees the client cert, and handles everything.

This creates a hybrid security posture:

- **Kestrel must be configured for TLS** (certificates, protocol versions, client certificates) as if it were an edge server. The proxy can't help with TLS configuration or certificate management.
- **`X-Forwarded-*` headers are unavailable.** Because the proxy can't decrypt the traffic, it can't inject HTTP headers. `HttpContext.Connection.RemoteIpAddress` will show the proxy's IP, not the client's. To obtain the original client IP, the proxy must use a transport-level mechanism such as the [PROXY protocol](https://www.haproxy.org/download/1.8/doc/proxy-protocol.txt), which Kestrel doesn't natively support.
- **Forwarded Headers middleware should not be enabled.** There are no forwarded headers to process, and enabling the middleware would allow a malicious client to inject fake `X-Forwarded-*` headers in the encrypted request.
- **Host Filtering is still relevant** since Kestrel sees the actual HTTP request after TLS termination.
- **Client certificates are visible to Kestrel** since the TLS handshake happens directly with Kestrel. mTLS works normally.

> [!IMPORTANT]
> **Key takeaway:** TLS pass-through deployments have the TLS responsibilities of an edge server but the IP-visibility limitations of a proxied deployment. Evaluate both the edge server and reverse proxy checklists when securing this topology.

### Protocol selection per endpoint

Kestrel allows configuring which HTTP protocol versions are accepted on each listen endpoint (e.g. IP/port pair, named pipe) via the `Protocols` property on `ListenOptions`:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
        listenOptions.UseHttps();
    });

    options.ListenLocalhost(5002, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1; // HTTP/1.1 only -- no HTTP/2
        listenOptions.UseHttps();
    });
});
```

| Value | Protocols Enabled |
|---|---|
| `Http1` | HTTP/1.1 only |
| `Http2` | HTTP/2 only |
| `Http3` | HTTP/3 only |
| `Http1AndHttp2` (default with HTTPS) | HTTP/1.1 and HTTP/2 |
| `Http1AndHttp2AndHttp3` | All three protocols |

## Security checklist

Quick reference for production deployments. Each row links to the detailed section.

| Feature | Default | [Edge Server](#edge-server-direct-internet-exposure) | [Behind Proxy](#behind-a-reverse-proxy) | Details |
|---|---|---|---|---|
| [**Host Filtering**](#host-filtering) | All hosts allowed | Configure `AllowedHosts` | Optional (defense-in-depth) | [Security Middleware](#security-middleware) |
| [**HTTPS Redirection**](#https-redirection) | Not enabled | Enable | Depends on proxy config | [Security Middleware](#security-middleware) |
| [**HSTS**](#http-strict-transport-security-hsts) | Not enabled | Enable | Enable | [Security Middleware](#security-middleware) |
| [**Forwarded Headers**](#forwarded-headers) | Not enabled | **Don't enable** | Enable with `KnownProxies` | [Security Middleware](#security-middleware) |
| [**Rate Limiting**](#rate-limiting) | Disabled | Enable | Enable (app-level) | [Security Middleware](#security-middleware) |
| [**CORS**](#cors) | Disabled | Configure per API (if needed) | Configure per API (if needed) | [Security Middleware](#security-middleware) |
| [**MaxRequestBodySize**](#request-limits) | 30 MB | Review and lower | Review and lower | [Configurable Limits](#configurable-limits) |
| [**TLS Protocol Versions**](#tls-protocol-versions) | OS default | Review—ensure TLS 1.0/1.1 disabled | N/A (proxy terminates) | [Transport Security](#transport-security-tlshttps) |
| [**Client Certificates**](#client-certificate-modes-mtls) | `NoCertificate` | Configure if mTLS needed | N/A (proxy handles) | [Transport Security](#transport-security-tlshttps) |
| [**Certificate Revocation**](#certificate-revocation) | `false` | Consider enabling | N/A | [Transport Security](#transport-security-tlshttps) |
| [**Server Header**](#server-header) | `Server: Kestrel` | Consider disabling | Consider disabling | [Server Identity](#server-identity-and-information-disclosure) |
| [**AllowHostHeaderOverride**](#host-header-enforcement) | `false` | Keep `false` | Keep `false` unless proxy requires | [HTTP/1.1 Parsing](#http11-request-parsing-and-validation) |
| [**AllowAlternateSchemes**](#scheme-enforcement) | `false` | Keep `false` | Enable only if proxy requires | [Server Identity](#server-identity-and-information-disclosure) |
| [**AllowSynchronousIO**](#synchronous-io-protection) | `false` | Keep `false` | Keep `false` | [Configurable Limits](#configurable-limits) |

### Minimum recommended configuration (edge server)

The following demonstrates the key settings to review when deploying Kestrel as an edge server. Appropriate values depend on your application's requirements and expected traffic patterns:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // Review request size limits -- the 30 MB default may be larger than needed
    options.Limits.MaxRequestBodySize = /* appropriate for your endpoints */;

    // Consider tightening header limits from the defaults
    options.Limits.MaxRequestHeaderCount = /* appropriate for your application */;

    // Review timeout values
    options.Limits.KeepAliveTimeout = /* balance between resource usage and client experience */;
    options.Limits.RequestHeadersTimeout = /* shorter values improve slowloris resistance */;

    // Enable HTTP/2 keep-alive pings (disabled by default)
    options.Limits.Http2.KeepAlivePingDelay = /* enable to detect zombie connections */;
    options.Limits.Http2.KeepAlivePingTimeout = TimeSpan.FromSeconds(20);
});

var app = builder.Build();

app.UseHostFiltering();
app.UseHttpsRedirection();
app.UseHsts();
app.UseRateLimiter();
```

## Transport security (TLS/HTTPS)

Kestrel supports TLS termination directly, including TLS 1.2, TLS 1.3, SNI, and mutual TLS (mTLS).

### Certificate configuration

| Configuration | Description |
|---|---|
| `ServerCertificate` | A static `X509Certificate2` for HTTPS. Must include the Server Authentication EKU (OID `1.3.6.1.5.5.7.3.1`). |
| `ServerCertificateSelector` | A callback for dynamic per-connection certificate selection, typically used for SNI (Server Name Indication) to serve different certificates for different domains. |
| `ServerCertificateChain` | The full certificate chain to present to clients for trust validation. |

Kestrel watches certificate files for changes and reloads them automatically. This can be disabled with the `Microsoft.AspNetCore.Server.Kestrel.DisableCertificateFileWatching` AppContext switch.

### TLS protocol versions

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(https =>
    {
        https.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
    });
});
```

The default value of `SslProtocols` is `SslProtocols.None`, which defers to the operating system's default. On modern systems this typically means TLS 1.2 and TLS 1.3. We recommend keeping the default as it will automatically work with the latest supported protocol on the OS. If you need to restrict versions explicitly (for example, to prohibit TLS 1.0 and 1.1 in environments with older OS defaults), set the property.

### Client certificate modes (mTLS)

The `ClientCertificateMode` enum controls mutual TLS behavior:

| Mode | Behavior |
|---|---|
| `NoCertificate` (default) | Client certificate isn't requested. |
| `AllowCertificate` | Client certificate is requested but not required. The connection succeeds without one. |
| `RequireCertificate` | Client certificate is mandatory. The TLS handshake fails without one. |
| `DelayCertificate` | Client certificate isn't requested during the initial handshake but can be requested later via renegotiation/post-handshake authentication. |

The `ClientCertificateValidation` callback allows custom validation logic beyond the default chain validation. The convenience method `AllowAnyClientCertificate()` bypasses all validation—**use only in development/testing**.

### Certificate revocation

`CheckCertificateRevocation` defaults to `false`. When set to `true`, Kestrel performs CRL/OCSP checking during the TLS handshake. Consider the performance and availability implications—if the OCSP responder is unreachable, handshakes may fail or be delayed.

### TLS handshake timeout

The `HandshakeTimeout` defaults to **10 seconds**. This limits how long a client has to complete the TLS handshake, preventing slowloris-style attacks at the TLS layer.

### Advanced TLS configuration

- **`OnAuthenticate`**: A callback providing direct access to `SslServerAuthenticationOptions` per connection for advanced scenarios (cipher suite selection, ALPN negotiation, etc.).
- **`UseTlsClientHelloListener`** (.NET 11+): A connection middleware (on `ListenOptions`) that inspects the raw TLS Client Hello bytes before the handshake begins. This enables custom logic based on the client's TLS capabilities (e.g., SNI-based routing, fingerprinting). It must be called **before** `UseHttps()` in the middleware pipeline. It has its own timeout (default 8 seconds), which is **additive** with the TLS handshake timeout—consider reducing each timeout to keep the total bounded (e.g., 5s + 5s instead of 8s + 10s).
- **`TlsClientHelloBytesCallback`** (.NET 10): A property on `HttpsConnectionAdapterOptions` and `TlsHandshakeCallbackOptions` that provides raw Client Hello inspection. In .NET 11 this property is obsolete in favor of `UseTlsClientHelloListener`.

## HTTP/1.1 request parsing and validation

Kestrel implements HTTP/1.1 parsing per [RFC 9112](https://www.rfc-editor.org/rfc/rfc9112) with several security-motivated constraints.

### Request line validation

- **Method**: Only valid HTTP token characters are accepted. Invalid token characters in the method cause rejection.
- **Request target**: Empty paths and paths starting with `?` or `%` are rejected. Null bytes (`0x00`) are rejected because they can cause issues with native servers when forwarded; non-ASCII bytes (>= `0x80`) are rejected during ASCII string conversion. Kestrel's parser scans for delimiters to find target boundaries but doesn't perform a per-byte VCHAR check (RFC 9112 §4), so bytes in `0x01–0x1F` (excluding `\0`, `\n`, `\r`, space) and `0x7F` (DEL) reach `Request.Path` unchanged. The practical risk is log injection—for example, `0x1B` (ESC) in the path can inject ANSI escape sequences into log viewers. Applications can defend against this with one or more of the following measures: deploying behind a stricter reverse proxy, using a logger provider that escapes control characters, or sanitizing logs before they're displayed.
- **HTTP version**: Only `HTTP/1.0` and `HTTP/1.1` are accepted by the `HTTP/1.1` parser. The `HTTP/2` parser is selected via ALPN or prior-knowledge. Unrecognized versions (including `HTTP/0.9`, `HTTP/2.0`) are rejected with `505 HTTP Version Not Supported`.

### Request-target form validation

Kestrel validates that the request-target form matches the HTTP method per [RFC 9110](https://www.rfc-editor.org/rfc/rfc9110):

- **Asterisk-form** (`OPTIONS * HTTP/1.1`): The single-asterisk target is only accepted for the `OPTIONS` method. Any other method using asterisk-form is rejected with `405 Method Not Allowed` (`OptionsMethodRequired`). This prevents clients from sending arbitrary methods to the server-wide `*` target.
- **Authority-form** (`CONNECT host:port HTTP/1.1`): Authority-form targets (bare `host:port`) are only accepted for the `CONNECT` method. Any other method using authority-form is rejected with `405 Method Not Allowed` (`ConnectMethodRequired`). This prevents misrouting of non-tunnel requests.
- **Absolute-form** (`GET http://example.com/path HTTP/1.1`): Accepted and decomposed into scheme, host, and path components.
- **Origin-form** (`GET /path HTTP/1.1`): The standard form for most requests.

Invalid characters in authority-form targets are also rejected to prevent injection into the host/port value.

### Header validation

Kestrel validates headers to prevent injection and encoding attacks:

- **Null bytes** (`\0`) in header names or values are rejected.
- **CR** (`\r`) in header values is rejected—a standalone CR that isn't part of a CRLF sequence causes a parse error, preventing header injection.
- **LF** (`\n`) in header values: by default, Kestrel recognizes bare LF as a line terminator, consistent with RFC 9112 Section 2.2 which says a recipient MAY treat a single LF as a line terminator. From Kestrel's perspective, the LF ends the current header line—there is no "header value containing LF." This is a robustness accommodation, not a vulnerability. However, if an upstream intermediary treats the same bytes as a single header value and forwards them verbatim, the two systems disagree about message framing. The [`DisableHttp1LineFeedTerminators`](#appcontext-compatibility-switches) AppContext switch can be set to reject bare LF as defense-in-depth against such buggy intermediaries.
- **UTF-8 encoding** is enforced with `throwOnInvalidBytes: true`, rejecting malformed UTF-8 sequences. The `RequestHeaderEncodingSelector` callback can override the encoding used for specific header names—use with caution, as non-UTF-8 encodings may bypass validation assumptions in downstream middleware.
- **Header names** must contain a colon separator and can't contain spaces or tabs.
- Trailing and leading whitespace in header values is stripped per the HTTP specification.
- The `ResponseHeaderEncodingSelector` callback allows custom encoding for response header values. By default, response headers are encoded as ASCII. Misconfigured encoding selectors can introduce response header injection vulnerabilities.

### Response header validation

Kestrel validates response header names written by application code. When application code sets a response header with a non-standard name (one that isn't a well-known header), the name is checked against the HTTP token character set (RFC 9110 Section 5.6.2). Invalid characters cause an `InvalidOperationException`, preventing the application from injecting malformed headers into the response.

This is a defense against **response header injection**: if application code constructs a header name from untrusted input (e.g., user-provided data), this validation prevents control characters or delimiter characters from escaping into the response stream. Well-known headers (e.g., `Content-Type`, `Cache-Control`) bypass this check because they are pre-validated constants.

### Host header enforcement

Per RFC 9110 Section 7.2, Kestrel enforces Host header requirements:

- **HTTP/1.1 requests without a Host header are rejected** with `400 Bad Request`.
- **Multiple Host headers are rejected.** A request with more than one Host header is considered malformed.
- **Host header format is validated.** Invalid host values (e.g., containing prohibited characters) are rejected.

When the request target is in absolute-form (e.g., `GET http://example.com/path`), the `AllowHostHeaderOverride` option (default `false`) controls whether the Host header in the request target overrides the standalone Host header. Keep this `false` unless behind a trusted proxy that requires absolute-form URIs (RFC 9112 Section 3.2.2).

### Request smuggling protection (Transfer-Encoding and Content-Length)

Kestrel implements protections against HTTP request smuggling per RFC 9112 Section 6.3 and Section 11:

1. **When both Transfer-Encoding and Content-Length are present**, Transfer-Encoding takes precedence. The Content-Length header is removed and preserved as `X-Content-Length` for diagnostic purposes. **The connection is closed after the response** to prevent pipeline-based smuggling. The `AllowKeepAliveAfterCLTE` AppContext switch can restore keep-alive behavior for backwards compatibility—see [AppContext Compatibility Switches](#appcontext-compatibility-switches).
2. **The final Transfer-Encoding must be `chunked`.** If Transfer-Encoding is present but the final coding isn't `chunked`, the request is rejected. This prevents ambiguous body-framing.
3. **HTTP/2 forbids chunked Transfer-Encoding** per RFC 9113 Section 8.1. Kestrel rejects HTTP/2 requests with chunked encoding.

```
# Rejected: Transfer-Encoding is present but final coding is not chunked
Transfer-Encoding: gzip
-> 400 Bad Request

# Accepted: Content-Length removed, body read as chunked
Transfer-Encoding: chunked
Content-Length: 42
-> Content-Length removed, X-Content-Length: 42 added

# Accepted by Kestrel's HTTP/1 parser: upgrade requests can still carry a body
# and are not rejected solely because body framing headers are present.
Connection: upgrade
Transfer-Encoding: chunked
-> Request accepted; body handling is application/protocol-specific
```

### Chunked encoding validation

Kestrel validates chunked transfer encoding per RFC 9112 Section 7.1:

- Chunk format: `chunk-size [chunk-ext] CRLF chunk-data CRLF`
- Maximum chunk prefix length: 10 bytes (supports chunk sizes up to `0x7FFFFFFF`)
- Chunk extensions are validated—unpaired `\r` or `\n` in extensions cause rejection.
- `BadChunkSuffix`, `BadChunkSizeData`, `BadChunkExtension`, and `ChunkedRequestIncomplete` errors each produce `400 Bad Request`

An [`EnableInsecureChunkedRequestParsing`](#appcontext-compatibility-switches) AppContext switch exists for backwards compatibility but is disabled by default. See [AppContext Compatibility Switches](#appcontext-compatibility-switches).

### Content-Length validation

- Negative Content-Length values are rejected.
- Multiple Content-Length headers are rejected, even when the repeated values are identical.
- Requests with `Content-Length` that don't deliver the full body before the body timeout are aborted. In practice this typically surfaces as `408 Request Timeout`, though clients may observe the connection closing.

### HTTP/1.0 behavior

Kestrel accepts HTTP/1.0 requests with these differences from HTTP/1.1:

- **Host header isn't required.** HTTP/1.0 predates the Host header requirement (RFC 9110 Section 7.2 only mandates it for HTTP/1.1).
- **POST and PUT requests require Content-Length.** Unlike HTTP/1.1 which supports chunked transfer encoding, HTTP/1.0 has no chunked encoding. If an HTTP/1.0 POST or PUT request arrives without a Content-Length header, Kestrel rejects it with `400 Bad Request` (`LengthRequiredHttp10`).
- **Connections close by default.** HTTP/1.0 doesn't have persistent connections by default. Even if the client sends `Connection: keep-alive`, Kestrel may still close the connection when the response body length isn't known in advance (since HTTP/1.0 doesn't support chunked transfer encoding, `Connection: close` is the only way to signal end-of-body for dynamic responses).

### Request body draining

On keep-alive connections, Kestrel must ensure the previous request's body is fully consumed before reading the next request. If the application doesn't read the entire request body, Kestrel automatically drains the remaining bytes. This prevents **request smuggling via unconsumed body data**—without draining, leftover bytes from one request could be interpreted as the start of the next.

Draining is subject to the [`MinRequestBodyDataRate`](#minimum-data-rates) enforcement. If the client sends the remaining body too slowly, the connection is closed rather than held open indefinitely.

### HTTP trailers

Kestrel supports HTTP trailers (headers sent after the body) in both HTTP/1.1 chunked transfer encoding and HTTP/2. Trailers are accessible via `HttpRequest.GetTrailer()`.

Security consideration: most middleware processes request headers **before** the request body is read. Trailers arrive **after** the body, so they bypass header-processing middleware (authentication, CORS, etc.). Don't rely on trailer values for security decisions, and be aware that proxies may strip or add trailers.

## HTTP/2 security

Kestrel's HTTP/2 implementation addresses numerous CVEs and denial-of-service attack patterns.

HTTP/2's binary framing eliminates the primary class of [request smuggling vulnerabilities](#request-smuggling-protection-transfer-encoding-and-content-length) that affect HTTP/1.1. Each request is carried on an explicit stream with length-prefixed frames, so there is no ambiguity about where one message ends and the next begins. There is no Transfer-Encoding/Content-Length conflict to exploit. However, HTTP/2 introduces its own denial-of-service attack surface through stream multiplexing, flow control, and [header compression](#hpack-and-qpack-header-compression-security).

### Key threats and mitigations

| Threat | CVE(s) | Mitigation |
|---|---|---|
| **Continuation Flood** | Widespread | Headers parsed per-frame (not batch-reparsed), preventing quadratic work. `MaxRequestHeaderCount` and `MaxRequestHeadersTotalSize` bound accumulation. |
| **Rapid Reset** | CVE-2023-44487 | Stream creation/cancellation rate is monitored. Excessive resets trigger ENHANCE_YOUR_CALM (HTTP/2 error code 11). Rate governed by `MaxEnhanceYourCalmCount` AppContext property. |
| **RST Stream Flood** | CVE-2019-9514 | Reset accumulation is bounded. Streams are drained with a 5-second timeout on request bodies. |
| **Slow Read Attack** | CVE-2019-9517 | `MinResponseDataRate` enforces minimum data consumption rate. Note: OS-level TCP buffering can reduce the effectiveness of this mitigation. |
| **Settings/Ping Flood** | CVE-2019-9512, CVE-2019-9515, CVE-2019-9518 | Outbound message queue capped by `MaxConnectionFlowControlQueueSize`. |
| **Priority Shuffling** | CVE-2019-9513 | Stream priority is **not implemented**—PRIORITY frames are silently ignored, eliminating this attack surface entirely. |
| **Stream Self-Dependency** |—| HEADERS frames with priority and PRIORITY frames that declare a stream as dependent on itself are rejected with `PROTOCOL_ERROR` per RFC 9113 Section 5.3.1. This prevents degenerate dependency trees that could confuse priority scheduling. |
| **HPACK Bomb** |—| Dynamic table size limited (`HeaderTableSize`, default 4 KB). Per-header and total header size limits enforced. |

### HTTP/2-specific limits

| Setting | Default | Valid Range | Purpose |
|---|---|---|---|
| `MaxStreamsPerConnection` | 100 | > 0 | Concurrent streams per connection. Maps to `SETTINGS_MAX_CONCURRENT_STREAMS`. |
| `HeaderTableSize` | 4,096 bytes | >= 0 | HPACK dynamic table size. Lower values reduce compression but limit HPACK bomb impact. |
| `MaxFrameSize` | 16,384 bytes | 16 KB - 16 MB | Maximum HTTP/2 frame payload size. Maps to `SETTINGS_MAX_FRAME_SIZE`. |
| `MaxRequestHeaderFieldSize` | 32,768 bytes | > 0 | Maximum size of a single compressed header field. |
| `InitialConnectionWindowSize` | 1 MB | 64 KB - 2 GB | HTTP/2 connection-level flow control window. |
| `InitialStreamWindowSize` | 768 KB | 64 KB - 2 GB | HTTP/2 per-stream flow control window. |
| `KeepAlivePingDelay` | `TimeSpan.MaxValue` (disabled) | >= 1 second | Interval between keep-alive PINGs. Enable to detect zombie connections. |
| `KeepAlivePingTimeout` | 20 seconds | >= 1 second | How long to wait for PING response before closing. |

HTTP/2 limits are configured via `KestrelServerOptions.Limits.Http2`:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.Http2.MaxStreamsPerConnection = 50;
});
```

### Behavioral notes

- **No PUSH_PROMISE support.** Kestrel doesn't support server push, reducing attack surface.
- **Clear-text HTTP/2 (h2c) is supported but discouraged.** It is available for scenarios where Kestrel is behind a TLS-terminating proxy.
- **SETTINGS are processed atomically** per RFC 9113 Section 6.5.3.
- **Window size can go negative** per RFC 9113 Section 6.9.2, which Kestrel handles correctly.
- **Reserved bit in frame headers is explicitly set to 0**, preventing information disclosure from pooled memory.

## HTTP/3 security

Kestrel's HTTP/3 implementation runs over QUIC via `System.Net.Quic`. QUIC mandates TLS 1.3, so there is no clear-text HTTP/3.

Like HTTP/2, HTTP/3's binary framing eliminates common [HTTP/1.1-style request smuggling](#request-smuggling-protection-transfer-encoding-and-content-length). Each request is carried on an independent QUIC stream with explicit length framing. The primary threat categories for HTTP/3 are denial-of-service through stream and connection resource exhaustion.

### Key threats and mitigations

| Threat | Mitigation |
|---|---|
| **0-RTT Replay** | `System.Net.Quic` doesn't enable TLS 1.3 0-RTT, preventing replay attacks entirely. |
| **Rapid Reset** | Stream creation and cancellation are managed by `System.Net.Quic` with back-pressure for stream creation. |
| **Large Frame (Fast Failure)** | SETTINGS and GOAWAY frames exceeding 10,000 bytes trigger immediate connection closure. |
| **Slow Request Body** | `MinRequestBodyDataRate` (240 B/s default) with 5-second grace period. |
| **Slow Response Read** | `MinResponseDataRate` with caveat—QUIC-level buffering reduces effectiveness, similar to HTTP/2 with TCP. |
| **Cancellation Flood** | Delegated to `System.Net.Quic` stream management and resource limits. |
| **Unknown Frame Types** | Silently ignored per RFC 9114 requirement. |
| **Dynamic QPACK** | Kestrel doesn't create QPACK decoder/encoder streams. References to a dynamic table cause stream closure. |
| **Push Streams** | Server push isn't supported. Push-related frames (PUSH_PROMISE, CANCEL_PUSH, MAX_PUSH_ID) are parsed but payload is ignored. |

### HTTP/3-specific limits

HTTP/3 limits are split between Kestrel's `Http3Limits` (configured via `options.Limits.Http3`) and the QUIC transport layer (`QuicTransportOptions`).

**Kestrel HTTP/3 Limits** (`KestrelServerOptions.Limits.Http3`):

| Setting | Default | Purpose |
|---|---|---|
| `MaxRequestHeaderFieldSize` | 32,768 bytes | Maximum size of a single request header field (name + value). |

**QUIC Transport Limits** (`QuicTransportOptions`):

| Setting | Default | Purpose |
|---|---|---|
| `MaxBidirectionalStreamCount` | 100 | Maximum concurrent bidirectional (request) streams per connection. Analogous to HTTP/2's `MaxStreamsPerConnection`. |
| `MaxUnidirectionalStreamCount` | 10 | Maximum concurrent unidirectional streams per connection (used for control streams, QPACK streams, etc.). |

QUIC transport options are configured separately from Kestrel limits:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // HTTP/3 header limits
    options.Limits.Http3.MaxRequestHeaderFieldSize = 16 * 1024;
});

// QUIC transport stream limits
builder.WebHost.UseQuic(quic =>
{
    quic.MaxBidirectionalStreamCount = 50;
    quic.MaxUnidirectionalStreamCount = 5;
});
```

### Behavioral notes

- **`RequestHeadersTimeout` is per-stream in HTTP/3** (vs. connection-wide in HTTP/2), since HTTP/3 streams are independent.
- **Only one inbound control stream is allowed** per connection. A second control stream triggers connection abort.
- **Streams can arrive out of order**—a request stream may arrive before the control stream.
- **Platform requirements**: HTTP/3 requires Windows 11 / Windows Server 2022 or later (for TLS 1.3 support), or Linux with the `libmsquic` package. Check `QuicListener.IsSupported` at runtime.
- **`DisableAltSvcHeader` per endpoint**: By default, when HTTP/3 is enabled, Kestrel adds an `Alt-Svc` response header to HTTP/1.1 and HTTP/2 responses advertising the HTTP/3 endpoint. Set `DisableAltSvcHeader = true` on individual `ListenOptions` to suppress this for specific endpoints. This is useful when certain endpoints should not advertise HTTP/3 (e.g., internal endpoints, endpoints behind proxies that don't support QUIC, or when you want to control the HTTP/3 rollout gradually).

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        listenOptions.UseHttps();
        listenOptions.DisableAltSvcHeader = true; // No Alt-Svc advertisement on this endpoint
    });
});
```

## HPACK and QPACK header compression security

Header compression introduces specific security concerns.

### HPACK (HTTP/2)

| Concern | Mitigation |
|---|---|
| **HPACK Bomb** (small compressed headers expand to large uncompressed data) | `MaxDynamicTableSize` (default 4 KB), `MaxRequestHeaderFieldSize` (default 32 KB), and `MaxRequestHeaderCount` (default 100) bound expansion. |
| **Variable-length integer overflow** | Integers are limited to 31 bits. Unnecessary padding in the encoding is treated as an error. |
| **Zero-length header names** (CVE-2019-9516) | Empty header names are treated as an error. Empty header values are special-cased. |
| **Quadratic parsing** (CVE-2023-33953, CVE-2022-41723) | Headers are parsed per-frame, not batch-reparsed across continuation frames. |
| **Dynamic table dangling indices** (CVE-2019-11940) | Dynamic table updates occur after full decoding of the header block, preventing out-of-bounds access from mid-decode insertions. |
| **Information disclosure via shared dynamic table** | In Kestrel, the dynamic table is per-connection. Multi-tenant proxy scenarios (where different clients share a connection) are out of scope for Kestrel itself. |

### QPACK (HTTP/3)

Kestrel **doesn't use dynamic QPACK tables**. The `HeaderTableSize` for HTTP/3 is set to `0`, meaning:

- Kestrel never creates QPACK encoder or decoder streams.
- If a client references a dynamic table entry, the stream is closed with an error.
- This eliminates the QPACK-specific attack surface at the cost of slightly reduced compression efficiency.

## Configurable limits

All limits are configured via `KestrelServerOptions.Limits` (a `KestrelServerLimits` instance).

### Request limits

| Property | Default | Valid Values | Protection |
|---|---|---|---|
| `MaxRequestBodySize` | 30,000,000 bytes (~28.6 MB) | `null` = unlimited, `0`+ | Prevents upload-based denial of service. Can be overridden per-request via `IHttpMaxRequestBodySizeFeature`. |
| `MaxRequestBufferSize` | 1,048,576 bytes (1 MB) | `null` = unlimited, `>= MaxRequestLineSize` | Bounds internal read buffer. Prevents memory exhaustion from connection-level buffering. |
| `MaxRequestLineSize` | 8,192 bytes (8 KB) | > 0 | Limits the HTTP request line (`METHOD URI VERSION`). Requests exceeding this return `414 URI Too Long`. |
| `MaxRequestHeadersTotalSize` | 32,768 bytes (32 KB) | > 0 | Total size of all headers combined. Exceeding this returns `431 Request Header Fields Too Large`. |
| `MaxRequestHeaderCount` | 100 | > 0 | Number of header fields. Prevents slowloris-style header accumulation. |

### Response limits

| Property | Default | Valid Values | Protection |
|---|---|---|---|
| `MaxResponseBufferSize` | 65,536 bytes (64 KB) | `null` = unlimited, `0`+ | Controls when write operations block waiting for the client to consume data. `0` means every write blocks until flushed. |

### Connection limits

| Property | Default | Valid Values | Protection |
|---|---|---|---|
| `MaxConcurrentConnections` | `null` (unlimited) | `null` or > 0 | Limits total concurrent HTTP connections. |
| `MaxConcurrentUpgradedConnections` | `null` (unlimited) | `null` or > 0 | Separately limits concurrent WebSocket and other upgraded connections. |

> [!NOTE]
> The `MaxRequestBodySize` default (30 MB) is chosen for compatibility with IIS defaults. For APIs that don't accept large uploads, consider lowering this significantly. See the [Security Checklist](#security-checklist) for topology-specific guidance.

### Per-request body size override

The `IHttpMaxRequestBodySizeFeature` allows overriding `MaxRequestBodySize` on a per-request basis. This can only be set **before** the request body is read. Setting it to `null` removes the limit for that request.

```csharp
var app = builder.Build();

app.Use(async (context, next) =>
{
    var bodySizeFeature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
    if (bodySizeFeature is not null && !bodySizeFeature.IsReadOnly)
    {
        bodySizeFeature.MaxRequestBodySize = 100 * 1024 * 1024; // 100 MB for this request
    }

    await next(context);
});
```

### Synchronous I/O protection

`AllowSynchronousIO` (default `false`) controls whether synchronous read/write operations are permitted on request and response streams. When `false`, calling `Read()`, `Write()`, or `Flush()` on `Request.Body` or `Response.Body` throws an `InvalidOperationException`.

This default protects against **thread starvation denial-of-service**: synchronous I/O blocks the calling thread while waiting for network I/O to complete. Under load, this can exhaust the thread pool and make the application unresponsive. Asynchronous operations (`ReadAsync()`, `WriteAsync()`, `FlushAsync()`) don't block threads.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // Default is false -- only enable if legacy code requires synchronous I/O
    options.AllowSynchronousIO = true;
});
```

Per-request override is available via `IHttpBodyControlFeature`:

```csharp
var syncIoFeature = context.Features.Get<IHttpBodyControlFeature>();
if (syncIoFeature is not null)
{
    syncIoFeature.AllowSynchronousIO = true;
}
```

> [!TIP]
> Keep the default (`false`). If legacy middleware or libraries require synchronous I/O, prefer the per-request override rather than enabling it server-wide.

## Timeouts and data rate limits

Timeouts and minimum data rates protect against slow-client denial-of-service attacks (slowloris, slow POST, slow read).

### Timeouts

| Timeout | Default | Scope | Protection |
|---|---|---|---|
| `KeepAliveTimeout` | 130 seconds | Between requests on a keep-alive connection | Closes idle connections to free resources. |
| `RequestHeadersTimeout` | 30 seconds | Time to receive complete request headers | Prevents slowloris attacks that send headers one byte at a time. In HTTP/2, this is connection-wide. In HTTP/3, it applies per-stream. |
| `HandshakeTimeout` (HTTPS) | 10 seconds | TLS handshake completion | Prevents slowloris attacks at the TLS layer. |

### Minimum data rates

| Rate | Default | Grace Period | Protection |
|---|---|---|---|
| `MinRequestBodyDataRate` | 240 bytes/second | 5 seconds | Rejects clients that send request body data too slowly (slow POST attacks). The grace period allows for initial connection setup and TCP slow-start. |
| `MinResponseDataRate` | 240 bytes/second | 5 seconds | Rejects clients that consume response data too slowly (slow read attacks). |

> [!WARNING]
> `MinResponseDataRate` may be **less effective** in [HTTP/2](#http2-security) and [HTTP/3](#http3-security). OS-level TCP buffering (HTTP/2) and QUIC-level buffering (HTTP/3) can absorb writes between Kestrel and the client, which may delay detection of slow-reading clients.

Data rates can be set to `null` to disable enforcement:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MinRequestBodyDataRate = null; // (not recommended)  Disable minimum request rate
});
```

## Request rejection and error responses

When Kestrel rejects a request due to a protocol violation or limit breach, it sends a minimal error response and closes the connection. The request **never reaches application middleware or endpoints**—there is no opportunity to customize the response body or headers for rejected requests.

### Status code mapping

| HTTP Status | Rejection Reasons |
|---|---|
| **400 Bad Request** | `InvalidRequestLine`, `InvalidRequestHeader`, `InvalidRequestHeadersNoCRLF`, `InvalidRequestTarget`, `InvalidCharactersInHeaderName`, `InvalidContentLength`, `MultipleContentLengths`, `FinalTransferCodingNotChunked`, `BadChunkSuffix`, `BadChunkSizeData`, `BadChunkExtension`, `ChunkedRequestIncomplete`, `UnexpectedEndOfRequestContent`, `MissingHostHeader`, `MultipleHostHeaders`, `InvalidHostHeader`, `LengthRequiredHttp10` |
| **405 Method Not Allowed** | `OptionsMethodRequired`, `ConnectMethodRequired` |
| **408 Request Timeout** | `RequestHeadersTimeout`, `RequestBodyTimeout` |
| **413 Content Too Large** | `RequestBodyTooLarge` |
| **414 URI Too Long** | `RequestLineTooLong` |
| **431 Request Header Fields Too Large** | `HeadersExceedMaxTotalSize`, `TooManyHeaders` |
| **505 HTTP Version Not Supported** | `UnrecognizedHTTPVersion` |

### Observing rejections

Kestrel provides two ways to observe rejected requests:

**Logging**: Bad requests are logged at `Debug` level under the `Microsoft.AspNetCore.Server.Kestrel.BadRequests` category. To capture these in production, configure logging to include this category at `Debug` level:

```json
{
  "Logging": {
    "LogLevel": {
      "Microsoft.AspNetCore.Server.Kestrel.BadRequests": "Debug"
    }
  }
}
```

**Metrics**: The `kestrel.connection.duration` histogram includes an `error.type` tag with the rejection reason (e.g., `invalid_request_line`, `request_headers_timeout`, `max_concurrent_connections_exceeded`). Use this to alert on spikes in rejected connections:

```csharp
// Example: query with dotnet-counters or OpenTelemetry
// Meter: Microsoft.AspNetCore.Server.Kestrel
// Instrument: kestrel.connection.duration (histogram, seconds)
// Tag: error.type = "invalid_request_headers" | "request_body_too_large" | ...
```

### Monitoring with metrics

Beyond rejection-specific signals, Kestrel emits a set of built-in metrics under the `Microsoft.AspNetCore.Server.Kestrel` meter that are useful for detecting anomalous traffic patterns:

| Metric | What it tells you |
|---|---|
| `kestrel.connection.duration` | Connection lifetime distribution; spikes in short-lived connections may indicate scanning or SYN floods. |
| `kestrel.active_connections` | Current connection count; useful for capacity planning and detecting connection exhaustion. |
| `kestrel.queued_connections` | Connections waiting to be accepted; non-zero values may indicate saturation. |
| `kestrel.upgraded_connections` | Active WebSocket/upgraded connections; monitors long-lived connection accumulation. |
| `kestrel.rejected_connections` | Connections rejected due to limits; alerts on whether limits are being hit. |
| `kestrel.tls_handshake.duration` | TLS handshake time; spikes may indicate computational attacks or client issues. |
| `kestrel.active_tls_handshakes` | Concurrent in-progress TLS handshakes; high values may indicate handshake flooding. |

These metrics integrate with OpenTelemetry, `dotnet-counters`, Prometheus exporters, and Azure Monitor. For full setup guidance, see:

- [ASP.NET Core metrics overview](xref:log-mon/metrics/metrics)
- [Kestrel built-in metrics reference](/aspnet/core/log-mon/metrics/built-in#microsoftaspnetcoreserverkestrel)

### TLS-over-HTTP detection

Kestrel detects when a client attempts a TLS handshake on a plain HTTP port. This is reported as `TlsOverHttpError` with a `400 Bad Request` response, helping diagnose misconfigured clients.

## Security middleware

Several ASP.NET Core middleware components are critical for securing applications hosted on Kestrel. The order in which middleware is added to the pipeline matters.

### Host filtering

**What it does**: Validates the `Host` header against an allowlist, returning `400 Bad Request` for invalid hosts.

**Why it matters**: The ASP.NET Core framework uses the `Host` header to generate absolute URLs in many places—email confirmation links, password reset URLs, redirect URIs, OpenID Connect callbacks, and any use of `LinkGenerator` or `IUrlHelper`. An attacker who can control the `Host` header can cause the application to generate links pointing to a malicious domain. Host Filtering prevents this by rejecting requests with unrecognized Host values. **This is essential when Kestrel is an edge server**, because there is no upstream proxy to validate the Host header first.

```json
// In appsettings.json
{
  "AllowedHosts": "example.com;*.example.com"
}
```

| Option | Default | Description |
|---|---|---|
| `AllowedHosts` | `*` (all hosts) | Semicolon-separated list. Supports wildcards (`*.example.com`). Port numbers are excluded from comparison. |
| `AllowEmptyHosts` | `true` | Allow requests without a Host header (HTTP/1.0 compatibility). |
| `IncludeFailureMessage` | `true` | Include an error message body in the 400 response. |

### HTTPS redirection

**What it does**: Redirects non-HTTPS requests to HTTPS.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
```

| Option | Default | Description |
|---|---|---|
| `HttpsPort` | Auto-detected | The HTTPS port to redirect to. Auto-detected from `HTTPS_PORT` environment variable or `IServerAddressesFeature`. |
| `RedirectStatusCode` | 307 (Temporary Redirect) | Use `308` (Permanent Redirect) for production APIs where clients should cache the redirect. |

> [!NOTE]
> **Edge servers:** Enable HTTPS Redirection. **Behind a proxy**: Often unnecessary if the proxy handles TLS termination and all internal traffic is over a private network.

### HTTP strict transport security (HSTS)

**What it does**: Adds the `Strict-Transport-Security` header, telling browsers to only connect via HTTPS for future requests (RFC 6797).

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHsts();
```

| Option | Default | Description |
|---|---|---|
| `MaxAge` | 30 days | How long browsers remember the HTTPS-only policy. Production deployments often increase this to 1-2 years. |
| `IncludeSubDomains` | `false` | Apply the policy to all subdomains. |
| `Preload` | `false` | Allow inclusion in browser HSTS preload lists. |
| `ExcludedHosts` | `localhost`, `127.0.0.1`, `[::1]` | Hosts that don't receive the header (for local development). |

> [!IMPORTANT]
> HSTS is a one-way commitment. Once a browser receives an HSTS header, it will refuse HTTP connections to that domain for the `MaxAge` duration. Start with a short `MaxAge` and increase once confident.

### Forwarded headers

**What it does**: Processes `X-Forwarded-For`, `X-Forwarded-Host`, `X-Forwarded-Proto`, and `X-Forwarded-Prefix` headers from reverse proxies to restore the original client information.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
    KnownProxies = { IPAddress.Parse("10.0.0.1") },
    ForwardLimit = 1
});
```

| Option | Default | Description |
|---|---|---|
| `ForwardedHeaders` | `None` | Which headers to process. Must be explicitly set. |
| `KnownProxies` | `IPAddress.IPv6Loopback` (`::1`) | IPs of trusted proxies. **Must be configured.** |
| `KnownIPNetworks` | (empty) | IP ranges of trusted proxies (e.g., `10.0.0.0/8`). |
| `ForwardLimit` | 1 | Maximum number of proxy hops to trust. `null` = unlimited (**dangerous**). |
| `AllowedHosts` | (empty) | Validate `X-Forwarded-Host` values. |
| `RequireHeaderSymmetry` | `false` | Require matching counts across the forwarded headers. |

> [!WARNING]
> Forwarded Headers middleware **must be placed before** any middleware that depends on scheme, host, or client IP (authentication, authorization, CORS, etc.). If it runs too late, those components may see the backend hop as plain `http` instead of the original `https` request and fail in subtle ways—for example, authentication handlers may reject requests because the scheme is `http` instead of `https`, and secure cookies won't be sent. Also, **never enable this middleware in edge deployments**—it allows clients to spoof their IP address.
>
> For the full set of configuration options and guidance, see the [ASP.NET Core Forwarded Headers middleware documentation](xref:host-and-deploy/proxy-load-balancer).

### Rate limiting

**What it does**: Limits request rate per endpoint or globally using `System.Threading.RateLimiting`.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRateLimiter();
```

| Option | Default | Description |
|---|---|---|
| `GlobalLimiter` | `null` | A `PartitionedRateLimiter<HttpContext>` applied to all requests. |
| `RejectionStatusCode` | 503 | HTTP status code for rate-limited requests. Consider `429 Too Many Requests` for public APIs. |
| `OnRejected` | `null` | Custom rejection handler for adding `Retry-After` headers or logging. |

Rate limiting policies can be applied per-endpoint with `[EnableRateLimiting("policyName")]` and disabled with `[DisableRateLimiting]`. Common partition keys include client IP, authenticated user ID, and API key.

### CORS

**What it does**: Handles Cross-Origin Resource Sharing preflight requests and validates cross-origin access.

For APIs consumed by browser clients on different domains, CORS policies prevent unauthorized cross-domain data access. Key considerations:

- Avoid `AllowAnyOrigin` with `AllowCredentials`—this is insecure and rejected by browsers.
- Be specific about allowed origins, methods, and headers.
- `PreflightMaxAge` controls how long browsers cache preflight responses.

### Recommended middleware order

**Edge server:**
```csharp
app.UseHostFiltering();         // Validate Host header
app.UseHttpsRedirection();      // Redirect HTTP -> HTTPS
app.UseHsts();                  // Add Strict-Transport-Security
app.UseRateLimiter();           // Rate limiting
app.UseCors();                  // CORS (if needed)
app.UseAuthentication();
app.UseAuthorization();
```

**Behind a reverse proxy:**
```csharp
app.UseForwardedHeaders();      // MUST come first -- restores client IP/scheme/host
app.UseHostFiltering();         // Optional -- defense-in-depth
app.UseHsts();                  // HSTS (may also be set by proxy)
app.UseRateLimiter();           // Rate limiting (may also be done at proxy)
app.UseCors();                  // CORS (if needed)
app.UseAuthentication();
app.UseAuthorization();
```

## WebSocket security

WebSocket connections bypass many HTTP-level protections ([rate limiting](#rate-limiting), [request size limits](#configurable-limits)) since they are long-lived upgraded connections. The WebSocket middleware provides its own security controls.

### Cross-site WebSocket hijacking (origin validation)

By default, WebSocket connections are accepted from **any origin**. This makes applications vulnerable to cross-site WebSocket hijacking, where a malicious webpage opens a WebSocket to your server using the victim's cookies.

Configure `AllowedOrigins` to restrict which origins can establish WebSocket connections:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWebSockets(new WebSocketOptions
{
    AllowedOrigins = { "https://example.com", "https://www.example.com" }
});
```

| Option | Default | Description |
|---|---|---|
| `AllowedOrigins` | Empty (all origins allowed) | Origins permitted to establish WebSocket connections. `"*"` explicitly allows all. Origins are compared case-insensitively. |

When origin validation fails, the middleware returns `403 Forbidden`. Note that origin validation only applies when the `Origin` header is present—non-browser clients may omit it entirely.

### Keep-alive and timeout

| Option | Default | Description |
|---|---|---|
| `KeepAliveInterval` | 2 minutes | Interval between WebSocket Ping frames. Detects unresponsive clients. |
| `KeepAliveTimeout` | `Timeout.InfiniteTimeSpan` (disabled) | Time to wait for a Pong response after sending a Ping. If exceeded, the WebSocket is aborted. Consider enabling this in production. |

### WebSocket connection limits

WebSocket and other upgraded connections count toward [`MaxConcurrentUpgradedConnections`](#connection-limits) (unlimited by default). Since WebSocket connections are long-lived, they can accumulate and exhaust server resources. An explicit limit can be set:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxConcurrentUpgradedConnections = /* null or >= 0 */;
});
```

### Considerations

- **Message size**: WebSocket message sizes aren't limited by `MaxRequestBodySize`. Application code should validate message sizes.
- **Authentication**: WebSocket connections can't send custom headers during the handshake from browsers. Authentication typically relies on cookies or query string tokens. Validate authentication before accepting the WebSocket.
- **Rate limiting**: Standard HTTP rate limiting middleware doesn't apply to messages sent over an established WebSocket connection. Implement application-level rate limiting if needed.
- **Per-message deflate (compression)**: WebSocket supports optional per-message deflate compression (RFC 7692), which is **disabled by default** in ASP.NET Core. If enabled, it introduces compression-oracle risks similar to CRIME/BREACH—an attacker who can inject known plaintext into a message and observe the compressed size can infer secret content byte-by-byte. Only enable per-message deflate if the messages don't mix attacker-controlled and secret data.

## Named pipes transport security

Kestrel supports named pipes as a transport for inter-process communication on Windows.

### Pipe instance security

Kestrel uses `FILE_FLAG_FIRST_PIPE_INSTANCE` when creating the named pipe. If an attacker pre-creates a pipe with the same name (name squatting), Kestrel's startup **fails** rather than inheriting the attacker's weaker ACLs. This is a deliberate security decision.

Kestrel also maintains a pending server stream at all times to preserve the security settings established at startup, preventing a window where an attacker could create a replacement pipe.

### Access control

| Option | Default | Description |
|---|---|---|
| `CurrentUserOnly` | `true` | Restricts pipe access to the same user account running Kestrel. |
| Custom `PipeSecurity` |—| Allows fine-grained ACL configuration via `PipeAccessRule` for scenarios requiring access from different users or services. |

### Limitations

- Named pipes are connection-scoped (single stream per connection). HTTP/1.1 and HTTP/2 are supported; **HTTP/3 isn't supported**.
- The concept of graceful vs. ungraceful close doesn't map cleanly to named pipes—Kestrel relies on HTTP-level protocol boundaries (Content-Length, chunked encoding, frames) for message delimitation.

## Unix domain sockets transport security

Kestrel supports Unix domain sockets (UDS) as a transport, commonly used for communication between a reverse proxy (e.g., nginx) and Kestrel on the same machine.

### File permissions

Unix domain sockets are represented as files in the filesystem. Access control is governed by file permissions (owner, group, other). **Kestrel doesn't explicitly set file permissions on the socket file**—the socket inherits permissions based on the process's `umask` at the time of creation.

For production deployments, ensure the socket file's permissions restrict access to the intended user or group (`www-data` in the example below):

```bash
# After Kestrel creates the socket, restrict permissions
chmod 660 /var/run/myapp/kestrel.sock
chown www-data:www-data /var/run/myapp/kestrel.sock
```

Alternatively, configure the process `umask` before starting Kestrel to control the default permissions.

### Configuration

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenUnixSocket("/var/run/myapp/kestrel.sock");
});
```

The socket path must be an absolute path. Kestrel validates this and rejects relative paths.

### Considerations

- **No network exposure**: Unix domain sockets are only accessible from the local machine, significantly reducing the attack surface compared to TCP. This makes them a good choice for the proxy-to-Kestrel link.
- **Socket file cleanup**: If Kestrel exits without cleaning up the socket file, the next startup may fail. Ensure the deployment process handles stale socket files.
- **Permissions are the primary access control**: Unlike named pipes on Windows, there is no built-in API in Kestrel for configuring socket permissions. This must be handled at the OS level.

## Memory safety and System.IO.Pipelines

Kestrel uses `System.IO.Pipelines` for internal I/O buffering. While this is an implementation detail for most developers, it has security implications for advanced scenarios such as custom middleware or transport implementations.

### Key concerns

- **Buffer reuse and information disclosure**: `System.IO.Pipelines` uses memory pooling. Buffers are **not** zeroed between uses. If a `PipeWriter` calls `GetMemory()` and advances by the full `Memory<byte>.Length` (which may be larger than requested), it can inadvertently include stale data from a previous use of that buffer.
- **Backpressure thresholds**: `PauseWriterThreshold` and `ResumeWriterThreshold` control when writers are back-pressured. Incorrect `AdvanceTo()` usage (setting `examined` to `buffer.End` without consuming data) releases backpressure and can lead to unbounded memory growth.
- **Holding references after completion**: Accessing `Memory<byte>` or `ReadOnlySequence<byte>` after calling `Complete()` on a `PipeWriter`/`PipeReader` accesses memory that may have been returned to the pool and reused, causing data corruption or information disclosure.

### Opting out of pooled memory (advanced)

For extremely security-sensitive deployments, Kestrel's memory-pool factory can be replaced in DI with an implementation that returns **fresh arrays** instead of pooled blocks. This reduces the chance of stale data reappearing through buffer reuse, at the cost of substantially higher allocation and GC pressure.

```csharp
using System.Buffers;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Replace(ServiceDescriptor.Singleton<IMemoryPoolFactory<byte>, FreshArrayMemoryPoolFactory>());

sealed class FreshArrayMemoryPoolFactory : IMemoryPoolFactory<byte>
{
    public MemoryPool<byte> Create(MemoryPoolOptions? options = null)
        => new FreshArrayMemoryPool();
}

sealed class FreshArrayMemoryPool : MemoryPool<byte>
{
    public override int MaxBufferSize => int.MaxValue;

    public override IMemoryOwner<byte> Rent(int minBufferSize = -1)
    {
        var size = minBufferSize <= 0 ? 4096 : minBufferSize;
        return new FreshArrayOwner(new byte[size]);
    }

    protected override void Dispose(bool disposing)
    {
    }

    private sealed class FreshArrayOwner : IMemoryOwner<byte>
    {
        private byte[]? _buffer;

        public FreshArrayOwner(byte[] buffer)
        {
            _buffer = buffer;
        }

        public Memory<byte> Memory => _buffer is null ? Memory<byte>.Empty : _buffer;

        public void Dispose()
        {
            if (_buffer is not null)
            {
                Array.Clear(_buffer);
                _buffer = null;
            }
        }
    }
}
```

This is an advanced hardening tradeoff, not a general recommendation. Most applications should keep Kestrel's default pooling behavior for performance.

### Impact on application developers

These concerns primarily affect developers writing:
- Custom transport implementations
- Custom connection middleware
- Direct `PipeReader`/`PipeWriter` usage in request/response processing

Standard ASP.NET Core request/response patterns (reading `Request.Body`, writing to `Response.Body`) are safe—Kestrel handles the pipeline management internally.

## Server identity and information disclosure

### Server header

`AddServerHeader` (default `true`) causes Kestrel to include `Server: Kestrel` in every response. Disable it to prevent server identification:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});
```

While this is "security through obscurity," it reduces information available to automated scanners and is a common hardening step.

### Header string reuse

`DisableStringReuse` (default `false`) controls whether Kestrel caches and reuses string values for common headers across requests on the same connection. In most scenarios this is safe, but it can be disabled for defense-in-depth in high-security environments.

### Scheme enforcement

`AllowAlternateSchemes` (default `false`) controls whether HTTP/2 and HTTP/3 `:scheme` pseudo-headers can differ from the transport protocol. When `false`, a request received over TLS must have `:scheme` set to `https`. Enable this only when behind a trusted proxy that uses a different scheme (e.g., a proxy that terminates TLS and forwards with `:scheme: https` over a plain-text backend connection).

### Reserved bits

In HTTP/2 frame headers, Kestrel explicitly zeroes reserved bits. Without this, pooled memory could leak a single bit of stale data from a previous frame. While the information disclosure is minimal (one bit), it is prevented as a matter of correctness.

## AppContext compatibility switches

Kestrel provides several AppContext switches that change protocol-parsing and connection behavior. Each switch has different security implications—some strengthen security, some weaken it, and others are operationally neutral. Review the effect of each switch before enabling it.

AppContext switches can be set in code (before the host is built), in a `.runtimeconfig.json` file, or via an environment variable:

```csharp
// In code -- must be called before building the host
AppContext.SetSwitch("Microsoft.AspNetCore.Server.Kestrel.DisableHttp1LineFeedTerminators", true);
```

```json
// In runtimeconfig.template.json (applied at publish time)
{
  "configProperties": {
    "Microsoft.AspNetCore.Server.Kestrel.DisableHttp1LineFeedTerminators": true
  }
}
```

| Switch | Default | Effect |
|---|---|---|
| `Microsoft.AspNetCore.Server.Kestrel.DisableHttp1LineFeedTerminators` | `false` | When `true`, bare LF (`\n`) line terminators are **rejected** in HTTP/1.1. The default (`false`) accepts bare LF as permitted by RFC 9112 Section 2.2. Setting this to `true` provides defense-in-depth against intermediaries that treat bare LF differently than Kestrel. |
| `Microsoft.AspNetCore.Server.Kestrel.AllowKeepAliveAfterCLTE` | `false` | When `true`, the connection is allowed to be kept alive after a request that contains **both** Content-Length and Transfer-Encoding headers. When `false` (default), Kestrel closes the connection after processing such a request, eliminating potential smuggling risk from pipeline reuse. **Setting this to `true` weakens request smuggling protections.** |
| `Microsoft.AspNetCore.Server.Kestrel.EnableInsecureChunkedRequestParsing` | `false` | When `true`, allows lenient parsing of chunk extensions (unpaired `\r` or `\n`). **This weakens request smuggling protections.** |
| `Microsoft.AspNetCore.Server.Kestrel.FinOnError` | `false` | Controls connection close behavior on protocol errors. When `true`, sends FIN instead of RST. FIN helps avoid response truncation but might use more resources to close abusive connections. |
| `Microsoft.AspNetCore.Server.Kestrel.DisableCertificateFileWatching` | `false` | When `true`, disables automatic certificate file reload on change. |
| `Microsoft.AspNetCore.Server.Kestrel.Experimental.WebTransportAndH3Datagrams` | `false` | When `true`, enables experimental WebTransport and HTTP/3 Datagram support. **Experimental features may have unresolved security implications and aren't recommended for production.** |

### AppContext properties (HTTP/2)

These are set via `AppContext.SetData()` rather than `AppContext.SetSwitch()`:

| Property | Default | Effect |
|---|---|---|
| `Microsoft.AspNetCore.Server.Kestrel.Http2.MaxEnhanceYourCalmCount` | (allows bursty clients) | Controls the rate of ENHANCE_YOUR_CALM (error code 11) responses sent to misbehaving HTTP/2 clients. Averaged over a 5-second window. |
| `Microsoft.AspNetCore.Server.Kestrel.Http2.MaxConnectionFlowControlQueueSize` | (internal default) | Caps the outbound message queue size per HTTP/2 connection. Prevents memory exhaustion from queued SETTINGS ACKs, PING responses, and WINDOW_UPDATE frames. |

> [!IMPORTANT]
> **Guidance:** `DisableHttp1LineFeedTerminators` provides defense-in-depth when set to `true`—the default (`false`) is RFC-compliant but can cause framing disagreements with intermediaries that handle bare LF differently. `AllowKeepAliveAfterCLTE` defaults to the secure posture (`false`)—setting it to `true` weakens it. `EnableInsecureChunkedRequestParsing` weakens security when enabled. The remaining switches (`FinOnError`, `DisableCertificateFileWatching`) are operational and don't directly affect request-parsing security.
