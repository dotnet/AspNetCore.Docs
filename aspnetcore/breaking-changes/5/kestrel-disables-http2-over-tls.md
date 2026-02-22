---
title: "Breaking change: Kestrel: HTTP/2 disabled over TLS on incompatible Windows versions"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Kestrel: HTTP/2 disabled over TLS on incompatible Windows versions"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/421
---
# Kestrel: HTTP/2 disabled over TLS on incompatible Windows versions

To enable HTTP/2 over Transport Layer Security (TLS) on Windows, two requirements need to be met:

- Application-Layer Protocol Negotiation (ALPN) support, which is available starting with Windows 8.1 and Windows Server 2012 R2.
- A set of ciphers compatible with HTTP/2, which is available starting with Windows 10 and Windows Server 2016.

As such, Kestrel's behavior when HTTP/2 over TLS is configured has changed to:

- Downgrade to `Http1` and log a message at the `Information` level when [ListenOptions.HttpProtocols](/dotnet/api/microsoft.aspnetcore.server.kestrel.core.httpprotocols) is set to `Http1AndHttp2`. `Http1AndHttp2` is the default value for `ListenOptions.HttpProtocols`.
- Throw a `NotSupportedException` when `ListenOptions.HttpProtocols` is set to `Http2`.

For discussion, see issue [dotnet/aspnetcore#23068](https://github.com/dotnet/aspnetcore/issues/23068).

## Version introduced

ASP.NET Core 5.0

## Old behavior

The following table outlines the behavior when HTTP/2 over TLS is configured.

| Protocols | Windows 7,<br />Windows Server 2008 R2,<br />or earlier | Windows 8,<br />Windows Server 2012 | Windows 8.1,<br />Windows Server 2012 R2 | Windows 10,<br />Windows Server 2016,<br />or newer |
|---------------|-----------------------------------------------|--------------------------------|-------------------------------------|------------------------------------------|
| `Http2`         | Throw `NotSupportedException`                   | Error during TLS handshake     | Error during TLS handshake &ast;     | No error |
| `Http1AndHttp2` | Downgrade to `Http1`                    | Downgrade to `Http1`     | Error during TLS handshake &ast;     | No error |

&ast; Configure compatible cipher suites to enable these scenarios.

## New behavior

The following table outlines the behavior when HTTP/2 over TLS is configured.

| Protocols | Windows 7,<br />Windows Server 2008 R2,<br />or earlier | Windows 8,<br />Windows Server 2012 | Windows 8.1,<br />Windows Server 2012 R2 | Windows 10,<br />Windows Server 2016,<br />or newer |
|---------------|-----------------------------------------------|--------------------------------|-------------------------------------|------------------------------------------|
| `Http2`         | Throw `NotSupportedException`                   | Throw `NotSupportedException`     | Throw `NotSupportedException` &ast;&ast;     | No error |
| `Http1AndHttp2` | Downgrade to `Http1`                    | Downgrade to `Http1`     | Downgrade to `Http1` &ast;&ast;     | No error |

&ast;&ast; Configure compatible cipher suites and set the app context switch `Microsoft.AspNetCore.Server.Kestrel.EnableWindows81Http2` to `true` to enable these scenarios.

## Reason for change

This change ensures compatibility errors for HTTP/2 over TLS on older Windows versions are surfaced as early and as clearly as possible.

## Recommended action

Ensure HTTP/2 over TLS is disabled on incompatible Windows versions. Windows 8.1 and Windows Server 2012 R2 are incompatible since they lack the necessary ciphers by default. However, it's possible to update the Computer Configuration settings to use HTTP/2 compatible ciphers. For more information, see [TLS cipher suites in Windows 8.1](/windows/win32/secauthn/tls-cipher-suites-in-windows-8-1). Once configured, HTTP/2 over TLS on Kestrel must be enabled by setting the app context switch `Microsoft.AspNetCore.Server.Kestrel.EnableWindows81Http2`. For example:

```csharp
AppContext.SetSwitch("Microsoft.AspNetCore.Server.Kestrel.EnableWindows81Http2", true);
```

No underlying support has changed. For example, HTTP/2 over TLS has never worked on Windows 8 or Windows Server 2012. This change modifies how errors in these unsupported scenarios are presented.

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
