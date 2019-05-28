---
title: gRPC for ASP.NET Core configuration
author: jamesnk
description: Learn how to configure gRPC for ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 5/30/2019
uid: grpc/configuration
---
# gRPC for ASP.NET Core configuration

## Configure services options

The following table describes options for configuring gRPC services:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `SendMaxMessageSize` | `null` | The maximum message size in bytes that can be sent from the server. Attempting to send a message that exceeds the configured maximum message size results in an exception. |
| `ReceiveMaxMessageSize` | 4 MB | The maximum message size in bytes that can be received by the server. If the server receives a message that exceeds this limit, it throws an exception. Increasing this value allows the server to receive larger messages, but can negatively impact memory consumption. |
| `EnableDetailedErrors` | `false` | If `true`, detailed exception messages are returned to clients when an exception is thrown in a service method. The default is `false`. Setting `EnableDetailedErrors` to `true` can leak sensitive information. |
| `CompressionProviders` | gzip | A collection of compression providers used to compress and decompress messages. Custom compression providers can be created and added to the collection. The default configured provider supports **gzip** compression. |
| `ResponseCompressionAlgorithm` | `null` | The compression algorithm used to compress messages sent from the server. The algorithm must match a compression provider in `CompressionProviders`. For the algorithm to compress a response, the client must indicate it supports the algorithm by sending it in the **grpc-accept-encoding** header. |
| `ResponseCompressionLevel` | `null` | The compress level used to compress messages sent from the server. |

Options can be configured for all services by providing an options delegate to the `AddGrpc` call in `Startup.ConfigureServices`:

[!code-csharp[](~/grpc/configuration/sample/GrcpService/Startup.cs?name=snippet)]

Options for a single service override the global options provided in `AddGrpc` and can be configured using `AddServiceOptions<TService>`:

[!code-csharp[](~/grpc/configuration/sample/GrcpService/Startup2.cs?name=snippet)]

The following code sets the client maximum send and receive message size:

[!code-csharp[](~/grpc/configuration/sample/Program.cs?name=snippet&highlight=3-6)]

## Additional resources

* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>
