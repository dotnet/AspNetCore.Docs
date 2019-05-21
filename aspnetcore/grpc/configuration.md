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
| `SendMaxMessageSize` | `null` | The maximum message size in bytes that can be sent from the server. Attempting to send a message that exceeds the configured maximum message size results in an exception. |
| `ReceiveMaxMessageSize` | 4 MB | The maximum message size in bytes that can be received by the server. If the server receives a message that exceeds this limit, it throws an exception. Increasing this value allows the server to receive larger messages, but can negatively impact memory consumption. |
| `EnableDetailedErrors` | `false` | If `true`, detailed exception messages are returned to clients when an exception is thrown in a service method. The default is `false`. Setting this to `true` can leak sensitive information. |
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

## Configure Kestrel options

Kestrel server has configuration options that affect the behavior of gRPC for ASP.NET.

### Request body data rate limit

By default, the Kestrel server imposes a [minimum request body data rate](
<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinRequestBodyDataRate>). For client streaming and duplex streaming calls, this rate may not be satisfied and the connection may be timed out. The minimum request body data rate limit must be disabled when the gRPC service includes client streaming and duplex streaming calls:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
        webBuilder.ConfigureKestrel((context, options) =>
        {
            options.Limits.MinRequestBodyDataRate = null;
        });
    });
}
```

## Configure client options

If before we saw **Server or Service Options**, now we need configure same respective parameters on **Client Options**.

Grpc.Core.ChannelOptions class have some constants for most important client configurations related of server configuration, like:

|ChannelOptions (Client) |  GrpcServiceOptions (Server) |
| ------ | ------------- |
| `MaxSendMessageLength` | `ReceiveMaxMessageSize` | 
| `MaxReceiveMessageLength` | `SendMaxMessageSize` |

And some client specific configurations like User Agent 

### How to Use:

#### Server
```csharp
services.AddGrpc(options => {
    options.ReceiveMaxMessageSize = 2 * 1024 * 1024;    // 2 megabytes
    options.SendMaxMessageSize = 5 * 1024 * 1024;       // 5 megabytes 
});
```

#### Client
```csharp
var channel = new Channel("localhost:5001", ChannelCredentials.Insecure, new[] {
    new ChannelOption(ChannelOptions.MaxSendMessageLength , 2 * 1024 * 1024),      // 2 megabytes
    new ChannelOption(ChannelOptions.MaxReceiveMessageLength , 5 * 1024 * 1024)    // 5 megabytes    
});
```

With this example: 
* Client is able to send 2 megabytes, and server accepts up to 2 megabytes. 
* Server response can reached 5 megabytes, and client accepts receive up to 5 megabytes.



## Additional resources

* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>
