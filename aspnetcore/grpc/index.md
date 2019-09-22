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

The following documents introduce [gRPC for .NET](https://github.com/grpc/grpc-dotnet), a new implementation of gRPC. gRPC for .NET integrates gRPC services with ASP.NET Core on the server, and the client uses HTTP/2 support added in .NET Core 3.0.

> [!TIP]
> An alternative C# implementation is available on the [gRPC for C# page](https://github.com/grpc/grpc/tree/master/src/csharp). This implementation relies on the native library written in C (gRPC [C-core](https://grpc.io/blog/grpc-stacks)).

## C# Tooling support for .proto files

Generate gRPC services and clients from *.proto* files at build.

```protobuf
syntax = "proto3";

service WeatherForecaster {
  rpc GetWeather (WeatherRequest) returns (WeatherResponse);
}

message WeatherRequest {
  string location = 1;
}

message WeatherResponse {
  string location = 1;
  string description = 2;
  float temperature = 3;
}
```

For more information, see <xref:grpc/basics>.

## gRPC services on ASP.NET Core

gRPC services can be hosted with ASP.NET Core. Services have full integration with popular ASP.NET Core features such as logging, dependency injection (DI), authentication and authorization.

```csharp
public class WeatherService : Weather.WeatherBase
{
    private readonly WeatherRepository _weatherRepository;
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(WeatherRepository weatherRepository,
        ILogger<WeatherService> logger)
    {
        _weatherRepository = weatherRepository;
        _logger = logger;
    }

    public override async Task<WeatherResponse> GetWeather(
        WeatherRequest request, ServerCallContext context)
    {
        return await _weatherRepository.GetWeather(request.Location);
    }
}
```

For more information, see <xref:grpc/aspnetcore>.

## Call gRPC services with a .NET client

Easily call gRPC services with automatically generated gRPC clients in .NET.

```csharp
var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Weather.WeatherClient(channel);

var response = await client.GetWeatherAsync(
    new GetWeatherRequest { Location = "Seattle" });

Console.WriteLine($"It's {response.Temperature} degrees.");
```

For more information, see <xref:grpc/client>.

## gRPC client factory integration

gRPC for .NET includes integration with the HttpClientFactory.

!!CODE HERE!!

For more information, see <xref:grpc/clientfactory>.

## Additional resources

* <xref:grpc/basics>
* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/aspnetcore>
* <xref:grpc/migration>
