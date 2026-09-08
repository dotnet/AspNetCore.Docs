### Experimental DirectTls transport

> [!WARNING]
> DirectTls is experimental in .NET 11 and produces diagnostic `ASPNETCORE_DIRECTTLS_001`.

**DirectTls** is an opt-in Kestrel transport for Linux that terminates TLS directly on the connection's socket by using the runtime's low-level TLS APIs. It binds OpenSSL to the socket file descriptor instead of using <xref:System.Net.Security.SslStream>, avoiding an intermediate managed copy on the TLS data path. The transport is being explored for connection-dense and handshake-heavy workloads where those copies and allocations can be significant.

DirectTls ships as the standalone `Microsoft.AspNetCore.Server.Kestrel.Transport.DirectTls` package and requires OpenSSL on the host. After adding a reference to the package, call `UseDirectTls()` to register the transport and select it for a specific endpoint. The following example assumes that `certificate` is an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> loaded from the app's secure certificate configuration:

```csharp
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Transport.DirectTls;

#pragma warning disable ASPNETCORE_DIRECTTLS_001 // DirectTls is experimental.

builder.WebHost.UseKestrel();
builder.WebHost.UseDirectTls();
builder.WebHost.ConfigureKestrel(options =>
{
    var endpoint = new DirectTlsEndpoint(IPAddress.Any, 5001);
    endpoint.Options.ServerCertificate = certificate;
    options.Listen(endpoint);
});
```

Only endpoints configured with `DirectTlsEndpoint` use DirectTls. Other endpoints continue to use the default sockets transport and the standard Kestrel TLS implementation.
