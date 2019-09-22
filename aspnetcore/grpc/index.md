---
title: Introduction to gRPC on .NET Core
author: juntaoluo
description: Learn about gRPC services with Kestrel server and the ASP.NET Core stack.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 09/20/2019
uid: grpc/index
---
# Introduction to gRPC on .NET Core

By [John Luo](https://github.com/juntaoluo), [James Newton-King](https://twitter.com/jamesnk)

[gRPC](https://grpc.io/docs/guides/) is a language agnostic, high-performance Remote Procedure Call (RPC) framework.

The main benefits of gRPC are:
* Modern high-performance lightweight RPC framework.
* Contract-first API development, using Protocol Buffers by default, allowing for language agnostic implementations.
* Tooling available for many languages to generate strongly-typed servers and clients.
* Supports client, server, and bi-directional streaming calls.
* Reduced network usage with Protobuf binary serialization.

These benefits make gRPC ideal for:
* Lightweight microservices where efficiency is critical.
* Polyglot systems where multiple languages are required for development.
* Point-to-point real-time services that need to handle streaming requests or responses.

## C# Tooling support for .proto files

gRPC uses a contract-first approach to API development. Services and messages are defined in *\*.proto* files:

```protobuf
syntax = "proto3";

service Greeter {
  rpc SayHello (HelloRequest) returns (HelloReply);
}

message HelloRequest {
  string name = 1;
}

message HelloReply {
  string message = 1;
}
```

Automatically generate services, clients and messages by referencing the [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/) package and *\*.proto* files in a project:

```xml
<ItemGroup>
  <Protobuf Include="Protos\greet.proto" />
</ItemGroup>
```

For more information on gRPC tooling support, see <xref:grpc/basics>.

## gRPC services on ASP.NET Core

gRPC services can be hosted on ASP.NET Core. Services have full integration with popular ASP.NET Core features such as logging, dependency injection (DI), authentication and authorization.

```csharp
public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request,
        ServerCallContext context)
    {
        _logger.LogInformation("Saying hello to " + request.Name);
        return Task.FromResult(new HelloReply 
        {
            Message = "Hello " + request.Name
        });
    }
}
```

To learn about creating gRPC services on ASP.NET Core, see <xref:grpc/aspnetcore>.

## Call gRPC services with a .NET client

gRPC clients are concrete client types that are [generated from *\*.proto* files](xref:grpc/basics#generated-c-assets). The concrete gRPC client has methods that translate to the gRPC service in the *\*.proto* file.

```csharp
var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Greeter.GreeterClient(channel);

var response = await client.SayHello(
    new HelloRequest { Name = "World" });

Console.WriteLine(response.Message);
```

For more information, see <xref:grpc/client>.

## Additional resources

* <xref:grpc/basics>
* <xref:grpc/aspnetcore>
* <xref:grpc/client>
* <xref:grpc/clientfactory>
* <xref:tutorials/grpc/grpc-start>
