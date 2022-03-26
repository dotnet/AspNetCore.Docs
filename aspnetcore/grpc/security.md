---
title: Security considerations in gRPC for ASP.NET Core
author: jamesnk
description: Learn about security considerations for gRPC for ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 07/07/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/security
---
# Security considerations in gRPC for ASP.NET Core

By [James Newton-King](https://twitter.com/jamesnk)

This article provides information on securing gRPC with .NET Core.

## Transport security

gRPC messages are sent and received using HTTP/2. We recommend:

* [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246) be used to secure messages in production gRPC apps.
* gRPC services should only listen and respond over secured ports.

:::moniker range=">= aspnetcore-5.0"
TLS is configured in Kestrel. For more information on configuring Kestrel endpoints, see [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel/endpoints).
:::moniker-end

:::moniker range="< aspnetcore-5.0"
TLS is configured in Kestrel. For more information on configuring Kestrel endpoints, see [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration).
:::moniker-end

A [TLS termination proxy](https://wikipedia.org/wiki/TLS_termination_proxy) can be combined with TLS. The benefits of using TLS termination should be considered against the security risks of sending unsecured HTTP requests between apps in the private network.

## Exceptions

Exception messages are generally considered sensitive data that shouldn't be revealed to a client. By default, gRPC doesn't send the details of an exception thrown by a gRPC service to the client. Instead, the client receives a generic message indicating an error occurred. Exception message delivery to the client can be overridden (for example, in development or test) with [EnableDetailedErrors](xref:grpc/configuration#configure-services-options). Exception messages shouldn't be exposed to the client in production apps.

## Message size limits

Incoming messages to gRPC clients and services are loaded into memory. Message size limits are a mechanism to help prevent gRPC from consuming excessive resources.

gRPC uses per-message size limits to manage incoming and outgoing messages. By default, gRPC limits incoming messages to 4 MB. There is no limit on outgoing messages.

On the server, gRPC message limits can be configured for all services in an app with `AddGrpc`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc(options =>
    {
        options.MaxReceiveMessageSize = 1 * 1024 * 1024; // 1 MB
        options.MaxSendMessageSize = 1 * 1024 * 1024; // 1 MB
    });
}
```

Limits can also be configured for an individual service using `AddServiceOptions<TService>`. For more information on configuring message size limits, see [gRPC configuration](xref:grpc/configuration).

## Client certificate validation

[Client certificates](https://tools.ietf.org/html/rfc5246#section-7.4.4) are initially validated when the connection is established. By default, Kestrel doesn't perform additional validation of a connection's client certificate.

We recommend that gRPC services secured by client certificates use the [Microsoft.AspNetCore.Authentication.Certificate](xref:security/authentication/certauth) package. ASP.NET Core certification authentication will perform additional validation on a client certificate, including:

* Certificate has a valid extended key use (EKU)
* Is within its validity period
* Check certificate revocation
