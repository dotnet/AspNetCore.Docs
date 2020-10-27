---
title: gRPC for .NET configuration
author: jamesnk
description: Learn how to configure gRPC for .NET apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 05/26/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/configuration
---
# gRPC for .NET configuration

## Configure services options

gRPC services are configured with `AddGrpc` in *Startup.cs*. The following table describes options for configuring gRPC services:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| MaxSendMessageSize | `null` | The maximum message size in bytes that can be sent from the server. Attempting to send a message that exceeds the configured maximum message size results in an exception. When set to `null`, the message size is unlimited. |
| MaxReceiveMessageSize | 4 MB | The maximum message size in bytes that can be received by the server. If the server receives a message that exceeds this limit, it throws an exception. Increasing this value allows the server to receive larger messages, but can negatively impact memory consumption. When set to `null`, the message size is unlimited. |
| EnableDetailedErrors | `false` | If `true`, detailed exception messages are returned to clients when an exception is thrown in a service method. The default is `false`. Setting `EnableDetailedErrors` to `true` can leak sensitive information. |
| CompressionProviders | gzip | A collection of compression providers used to compress and decompress messages. Custom compression providers can be created and added to the collection. The default configured providers support **gzip** compression. |
| <span style="word-break:normal;word-wrap:normal">ResponseCompressionAlgorithm</span> | `null` | The compression algorithm used to compress messages sent from the server. The algorithm must match a compression provider in `CompressionProviders`. For the algorithm to compress a response, the client must indicate it supports the algorithm by sending it in the **grpc-accept-encoding** header. |
| ResponseCompressionLevel | `null` | The compress level used to compress messages sent from the server. |
| Interceptors | None | A collection of interceptors that are run with each gRPC call. Interceptors are run in the order they are registered. Globally configured interceptors are run before interceptors configured for a single service. For more information about gRPC interceptors, see [gRPC Interceptors vs. Middleware](xref:grpc/migration#grpc-interceptors-vs-middleware). |
| IgnoreUnknownServices | `false` | If `true`, calls to unknown services and methods don't return an **UNIMPLEMENTED** status, and the request passes to the next registered middleware in ASP.NET Core. |

Options can be configured for all services by providing an options delegate to the `AddGrpc` call in `Startup.ConfigureServices`:

[!code-csharp[](~/grpc/configuration/sample/GrcpService/Startup.cs?name=snippet)]

Options for a single service override the global options provided in `AddGrpc` and can be configured using `AddServiceOptions<TService>`:

[!code-csharp[](~/grpc/configuration/sample/GrcpService/Startup2.cs?name=snippet)]

## Configure client options

gRPC client configuration is set on `GrpcChannelOptions`. The following table describes options for configuring gRPC channels:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| HttpHandler | New instance | The `HttpMessageHandler` used to make gRPC calls. A client can be set to configure a custom `HttpClientHandler` or add additional handlers to the HTTP pipeline for gRPC calls. If no `HttpMessageHandler` is specified, a new `HttpClientHandler` instance is created for the channel with automatic disposal. |
| HttpClient | `null` | The `HttpClient` used to make gRPC calls. This setting is an alternative to `HttpHandler`. |
| DisposeHttpClient | `false` | If set to `true` and an `HttpMessageHandler` or `HttpClient` is specified, then either the `HttpHandler` or `HttpClient`, respectively, is disposed when the `GrpcChannel` is disposed. |
| LoggerFactory | `null` | The `LoggerFactory` used by the client to log information about gRPC calls. A `LoggerFactory` instance can be resolved from dependency injection or created using `LoggerFactory.Create`. For examples of configuring logging, see <xref:grpc/diagnostics#grpc-client-logging>. |
| MaxSendMessageSize | `null` | The maximum message size in bytes that can be sent from the client. Attempting to send a message that exceeds the configured maximum message size results in an exception. When set to `null`, the message size is unlimited. |
| <span style="word-break:normal;word-wrap:normal">MaxReceiveMessageSize</span> | 4 MB | The maximum message size in bytes that can be received by the client. If the client receives a message that exceeds this limit, it throws an exception. Increasing this value allows the client to receive larger messages, but can negatively impact memory consumption. When set to `null`, the message size is unlimited. |
| Credentials | `null` | A `ChannelCredentials` instance. Credentials are used to add authentication metadata to gRPC calls. |
| CompressionProviders | gzip | A collection of compression providers used to compress and decompress messages. Custom compression providers can be created and added to the collection. The default configured providers support **gzip** compression. |

The following code:

* Sets the maximum send and receive message size on the channel.
* Creates a client.

[!code-csharp[](~/grpc/configuration/sample/Program.cs?name=snippet&highlight=3-8)]

[!INCLUDE[](~/includes/gRPCazure.md)]

## Additional resources

* <xref:grpc/aspnetcore>
* <xref:grpc/client>
* <xref:grpc/diagnostics>
* <xref:tutorials/grpc/grpc-start>
