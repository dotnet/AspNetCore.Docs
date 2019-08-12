---
title: Troubleshoot gRPC clients and services
author: jamesnk
description: Troubleshoot errors when using gRPC clients and services.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 08/12/2019
uid: grpc/troubleshoot
---
# Troubleshoot gRPC clients and services

By [James Newton-King](https://twitter.com/jamesnk)

## Mismatch between client and service SSL/TLS configuration

The gRPC template and samples use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246) by default. gRPC clients need to use a secure connection to call secured gRPC services successfully.

You can verify the ASP.NET Core gRPC service is using TLS in logs from app start. The service will be listening on `https`:

```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

The .NET Core client must use `https` in the server address to make calls on a secured connection:

```csharp
static async Task Main(string[] args)
{
    var httpClient = new HttpClient();
    // The port number(5001) must match the port of the gRPC server.
    httpClient.BaseAddress = new Uri("https://localhost:5001");
    var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
}
```

All gRPC client implementations support TLS. gRPC clients from other languages typically require the channel configured with `SslCredentials`. `SslCredentials` specifies the certificate that the client will use, and it must be used instead of insecure credentials. See [gRPC Authentication](https://www.grpc.io/docs/guides/auth/) for samples of configuring the different gRPC client implementations to use TLS.

## Call insecure gRPC services with .NET Core client

Additional configuration is required to call insecure gRPC services with the .NET Core client. The gRPC client must set the `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch to `true` and use `http` in the server address:

```csharp
// This switch must be set before creating the HttpClient.
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

var httpClient = new HttpClient();
// The port number(5000) must match the port of the gRPC server.
httpClient.BaseAddress = new Uri("http://localhost:5000");
var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
```

## Unable to start ASP.NET Core gRPC app on macOS

Kestrel doesn't support HTTP/2 with TLS on macOS. The ASP.NET Core gRPC template and samples use TLS by default. You'll see the following error message when you attempt to start the gRPC server:

> Unable to bind to https://localhost:5001 on the IPv4 loopback interface: 'HTTP/2 over TLS is not supported on macOS due to missing ALPN support.'.

To work around this issue, configure Kestrel and the gRPC client to use HTTP/2 **without** TLS. You should only do this during development. Not using TLS will result in gRPC messages being sent without encryption.

Kestrel must configure a HTTP/2 endpoint without TLS in `Program.cs`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                // Setup a HTTP/2 endpoint without TLS.
                options.ListenLocalhost(5000, o => o.Protocols = HttpProtocols.Http2);
            });
            webBuilder.UseStartup<Startup>();
        });
```

The gRPC client must also be configured to not use TLS. See [Call insecure gRPC services with .NET Core client](#call-insecure-grpc-services-with-net-core-client) for more information.

> [!WARNING]
> HTTP/2 without TLS should only be used during app development. Production applications should always use transport security. For more information, see [Security considerations in gRPC for ASP.NET Core](xref:grpc/security#transport-security).
