---
title: Use gRPC client with .NET Standard 2.0
author: jamesnk
description: Learn how to use the .NET gRPC client in apps and libraries that support .NET Standard 2.0.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 3/11/2021
uid: grpc/netstandard
---
# Use gRPC client with .NET Standard 2.0

By [James Newton-King](https://twitter.com/jamesnk)

This article discusses how to use the .NET gRPC client with .NET implementations that support [.NET Standard 2.0](/dotnet/standard/net-standard).

## .NET implementations

The following .NET implementations (or later) support [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client/) but don't have full support for HTTP/2:

* .NET Core 2.1
* .NET Framework 4.6.1
* Mono 5.4
* Xamarin.iOS 10.14
* Xamarin.Android 8.0
* Universal Windows Platform 10.0.16299
* Unity 2018.1

The .NET gRPC client can call services from these .NET implementations with some additional configuration.

## HttpHandler configuration

An HTTP provider must be configured using `GrpcChannelOptions.HttpHandler`. If a handler isn't configured, an error is thrown:

> `System.PlatformNotSupportedException`: gRPC requires extra configuration to successfully make RPC calls on .NET implementations that don't have support for gRPC over HTTP/2. An HTTP provider must be specified using `GrpcChannelOptions.HttpHandler`. The configured HTTP provider must either support HTTP/2 or be configured to use gRPC-Web.

.NET implementations that don't support HTTP/2, such as UWP, Xamarin, and Unity, can use gRPC-Web as an alternative.

```csharp
var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
    {
        HttpHandler = new GrpcWebHandler(new HttpClientHandler())
    });

var client = new Greeter.GreeterClient(channel);
var response = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
```

Clients can also be created using the [gRPC client factory](xref:grpc/clientfactory). An HTTP provider is configured using the <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method.

```csharp
builder.Services
    .AddGrpcClient<Greet.GreeterClient>(options =>
    {
        options.Address = new Uri("https://localhost:5001");
    })
    .ConfigurePrimaryHttpMessageHandler(
        () => new GrpcWebHandler(new HttpClientHandler()));
```

For more information, see [Configure gRPC-Web with the .NET gRPC client](xref:grpc/grpcweb#configure-grpc-web-with-the-net-grpc-client).

> [!IMPORTANT]
> gRPC-Web requires the client ***and*** server to support it. gRPC-Web can be [quickly configured by an ASP.NET Core gRPC server](xref:grpc/grpcweb#configure-grpc-web-in-aspnet-core). Other gRPC server implementations require a proxy to support gRPC-Web.

## .NET Framework

.NET Framework has limited support for gRPC over HTTP/2. To enable gRPC over HTTP/2 on .NET Framework, configure the channel to use <xref:System.Net.Http.WinHttpHandler>.

Requirements and restrictions to using `WinHttpHandler`:

* Windows 11 or later, Windows Server 2022 or later.
  * gRPC client is fully supported on Windows 11 or later.
  * gRPC client is partially supported on Windows Server 2022. Unary and server streaming methods are supported. Client and bidirectional streaming methods are **_not_** supported.
* A reference to [`System.Net.Http.WinHttpHandler`](https://www.nuget.org/packages/System.Net.Http.WinHttpHandler/) version 6.0.1 or later.
* Configure `WinHttpHandler` on the channel using `GrpcChannelOptions.HttpHandler`.
* .NET Framework 4.6.1 or later.
* Only gRPC calls over TLS are supported.

```csharp
var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
    {
        HttpHandler = new WinHttpHandler()
    });

var client = new Greeter.GreeterClient(channel);
var response = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
```

## gRPC C# core-library

An alternative option for .NET Framework and Xamarin has been to use [gRPC C# core-library](https://grpc.io/docs/languages/csharp/quickstart/) to make gRPC calls. gRPC C# core-library is:

* A third party library that supports making gRPC calls over HTTP/2 on .NET Framework and Xamarin. 
* Not supported by Microsoft.
* In maintenance mode and will be [deprecated in favour of gRPC for .NET](https://grpc.io/blog/grpc-csharp-future/).
* Not recommended for new apps.

## Additional resources

* <xref:grpc/client>
* <xref:grpc/browser>
* [gRPC C# core-library](https://grpc.io/docs/languages/csharp/quickstart/)
