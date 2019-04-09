---
title: gRPC for ASP.NET Core configuration
author: jamesnk
description: Learn how to configure gRPC for ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 04/09/2019
uid: grpc/configuration
---
# gRPC for ASP.NET Core configuration

## Configure services options

The following table describes options for configuring gRPC services:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `SendMaxMessageSize` | `null` | The maximum message size in bytes that can be sent from the server. Attempting to send a message that exceeds the configured maximum message size will result in an exception. |
| `ReceiveMaxMessageSize` | 4 MB | The maximum message size in bytes that can be recived by the server. If the server receives a message that exceeds this limit then it will throw an exception. Increasing this value allows the server to receive larger messages, but can negatively impact memory consumption. |
| `EnableDetailedErrors` | `false` | If `true`, detailed exception messages are returned to clients when an exception is thrown in a service method. The default is `false`, as these exception messages can contain sensitive information. |
| `CompressionProviders` | gzip | A collection of compression providers used to compress and decompress messages. Custom compression providers can be created and added to the collection. The default configured provider supports **gzip** compression. |
| `ResponseCompressionAlgorithm` | `null` | The compression algorithm used to compress messages sent from the server. The algorithm must match a compression provider in `CompressionProviders`. For the algorthm to compress a response the client must indicate it supports the algorithm by sending it in the **grpc-accept-encoding** header. |
| `ResponseCompressionLevel` | `null` | The compress level used to compress messages sent from the server. |

Options can be configured for all services by providing an options delegate to the `AddGrpc` call in `Startup.ConfigureServices`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc(options =>
    {
        options.EnableDetailedErrors = true;
    });
}
```

Options for a single service override the global options provided in `AddGrpc` and can be configured using `AddServiceOptions<TService>`:

```csharp
services.AddGrpc().AddServiceOptions<MyService>(options =>
{
    options.ReceiveMaxMessageSize = 10 * 1024 * 1024; // 10 megabytes
});
```

## Additional resources

* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>
