---
title: "Breaking change: ClientCertificate property no longer triggers renegotiation for HttpSys"
description: "Learn about the breaking change in ASP.NET Core 6.0 where the ClientCertificate property no longer triggers renegotiation for HttpSys."
ms.date: 07/20/2021
ms.custom: https://github.com/aspnet/Announcements/issues/466
no-loc: [ Kestrel ]
---
# ClientCertificate property no longer triggers renegotiation for HttpSys

The [`HttpContext.Connection.ClientCertificate`](xref:Microsoft.AspNetCore.Http.ConnectionInfo.ClientCertificate?displayProperty=nameWithType) property no longer triggers TLS renegotiations for HttpSys.

## Version introduced

ASP.NET Core 6.0

### Old behavior

Setting `HttpSysOptions.ClientCertificateMethod = ClientCertificateMethod.AllowRenegotiation` allowed renegotiation to be triggered by both `HttpContext.Connection.ClientCertificate` and `HttpContext.Connection.GetClientCertificateAsync`.

### New behavior

Setting `HttpSysOptions.ClientCertificateMethod = ClientCertificateMethod.AllowRenegotiation` allows renegotiation to be triggered only by `HttpContext.Connection.GetClientCertificateAsync`. `HttpContext.Connection.ClientCertificate` returns the current certificate if available, but does not renegotiate with the client to request the certificate.

## Reason for change

When implementing the same features for Kestrel, it became clear that applications need to be able to check the state of the client certificate before triggering a renegotiation. For issues like the request body conflicting with the renegotiation, checking the state enables the following usage pattern to deal with the issue:

```csharp
if (connection.ClientCertificate == null)
{
  await BufferRequestBodyAsync();
  await connection.GetClientCertificateAsync();
}
```

## Recommended action

Apps that use delayed client-certificate negotiation should call <xref:Microsoft.AspNetCore.Http.ConnectionInfo.GetClientCertificateAsync(System.Threading.CancellationToken)> to trigger renegotiation.

## Affected APIs

- <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions.ClientCertificateMethod?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.ConnectionInfo.ClientCertificate?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.ConnectionInfo.GetClientCertificateAsync(System.Threading.CancellationToken)?displayProperty=fullName>

## See also

- [dotnet/aspnetcore issue number 34124](https://github.com/dotnet/aspnetcore/issues/34124)

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectable via API analysis

-->
