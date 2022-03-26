---
title: Code-first gRPC services and clients with .NET
author: jamesnk
description: Learn the basic concepts when writing code-first gRPC with .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 02/23/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/code-first
---
# Code-first gRPC services and clients with .NET

By [James Newton-King](https://twitter.com/jamesnk) and [Marc Gravell](https://twitter.com/marcgravell)

:::moniker range=">= aspnetcore-6.0"

Code-first gRPC uses .NET types to define service and message contracts.

Code-first is a good choice when an entire system uses .NET:

* .NET service and data contract types can be shared between the .NET server and clients.
* Avoids the need to define contracts in `.proto` files and code generation.

Code-first isn't recommended in polyglot systems with multiple languages. .NET service and data contract types can't be used with non-.NET platforms. To call a gRPC service written using code-first, other platforms must create a `.proto` contract that matches the service.

## protobuf-net.Grpc

> [!IMPORTANT]
> For help with protobuf-net.Grpc, visit the [protobuf-net.Grpc website](https://protobuf-net.github.io/protobuf-net.Grpc/) or create an issue on the [protobuf-net.Grpc GitHub repository](https://github.com/protobuf-net/protobuf-net.Grpc).

[protobuf-net.Grpc](https://protobuf-net.github.io/protobuf-net.Grpc/) is a community project and isn't supported by Microsoft. It adds code-first support to `Grpc.AspNetCore` and `Grpc.Net.Client`. It uses .NET types annotated with attributes to define an app's gRPC services and messages.

The first step to creating a code-first gRPC service is defining the code contract:

* Create a new project that will be shared by the server and client.
* Add a [protobuf-net.Grpc](https://www.nuget.org/packages/protobuf-net.Grpc) package reference.
* Create service and data contract types.

[!code-csharp[](code-first/samples/6.x/Shared/Contracts.cs)]

The preceding code:

* Defines `HelloRequest` and `HelloReply` messages.
* Defines the `IGreeterService` contract interface with the unary `SayHelloAsync` gRPC method.

The service contract is implemented on the server and called from the client.

Methods defined on service interfaces must match certain signatures depending on whether they're:

* Unary
* Server streaming
* Client streaming
* Bidirectional streaming

For more information on defining service contracts, see the [protobuf-net.Grpc getting started documentation](https://protobuf-net.github.io/protobuf-net.Grpc/gettingstarted).

## Create a code-first gRPC service

To add gRPC code-first service to an ASP.NET Core app:

* Add a [protobuf-net.Grpc.AspNetCore](https://www.nuget.org/packages/protobuf-net.Grpc.AspNetCore) package reference.
* Add a reference to the shared code-contract project.

  [!code-xml[](code-first/samples/6.x/GrpcGreeter/GrpcGreeter.csproj?highlight=9-11,13-15)]

* Create a new `GreeterService.cs` file and implement the `IGreeterService` service interface:

  [!code-csharp[](code-first/samples/6.x/GrpcGreeter/Services/GreeterService.cs?highlight=4)]

* Update the `Program.cs` file:

  [!code-csharp[](code-first/samples/6.x/GrpcGreeter/Program.cs?highlight=9,14)]

  The preceding highlighted code updates the following:

  * `AddCodeFirstGrpc` registers services that enable code-first.
  * `MapGrpcService<GreeterService>` adds the code-first service endpoint.

gRPC services implemented with code-first and `.proto` files can co-exist in the same app. All gRPC services use [gRPC service configuration](xref:grpc/configuration#configure-services-options).

## Create a code-first gRPC client

A code-first gRPC client uses the service contract to call gRPC services.

* In the gRPC client `.csproj` file:

  * Add a [protobuf-net.Grpc](https://www.nuget.org/packages/protobuf-net.Grpc) package reference.
  * Add a [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) package reference.
  * Add a reference to the shared code-contract project.

  [!code-csharp[](code-first/samples/6.x/GrpcGreeterClient/GrpcGreeterClient.csproj?highlight=10-13,15-17)]

[!code-xml[](code-first/samples/6.x/GrpcGreeterClient/GrpcGreeterClient.csproj?highlight=10-13,15-17)]

* Update the client `program.cs`

  [!code-csharp[](code-first/samples/6.x/GrpcGreeterClient/Program.cs?highlight=13,15-16)]

The preceding gRPC client `Program.cs` code:

* Creates a gRPC channel.
* Creates a code-first client from the channel with the `CreateGrpcService<IGreeterService>` extension method.
* Calls the gRPC service with `SayHelloAsync`.

A code-first gRPC client is created from a channel. Just like a regular client, a code-first client uses its [channel configuration](xref:grpc/configuration#configure-client-options).

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/grpc/code-first/samples/6.x) ([how to download](xref:index#how-to-download-a-sample))

## Additional resources

* [protobuf-net.Grpc website](https://protobuf-net.github.io/protobuf-net.Grpc/)
* [protobuf-net.Grpc GitHub repository](https://github.com/protobuf-net/protobuf-net.Grpc)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Code-first gRPC uses .NET types to define service and message contracts.

Code-first is a good choice when an entire system uses .NET:

* .NET service and data contract types can be shared between the .NET server and clients.
* Avoids the need to define contracts in `.proto` files and code generation.

Code-first isn't recommended in polyglot systems with multiple languages. .NET service and data contract types can't be used with non-.NET platforms. To call a gRPC service written using code-first, other platforms must create a `.proto` contract that matches the service.

## protobuf-net.Grpc

> [!IMPORTANT]
> For help with protobuf-net.Grpc, visit the [protobuf-net.Grpc website](https://protobuf-net.github.io/protobuf-net.Grpc/) or create an issue on the [protobuf-net.Grpc GitHub repository](https://github.com/protobuf-net/protobuf-net.Grpc).

[protobuf-net.Grpc](https://protobuf-net.github.io/protobuf-net.Grpc/) is a community project and isn't supported by Microsoft. It adds code-first support to `Grpc.AspNetCore` and `Grpc.Net.Client`. It uses .NET types annotated with attributes to define an app's gRPC services and messages.

The first step to creating a code-first gRPC service is defining the code contract:

* Create a new project that will be shared by the server and client.
* Add a [protobuf-net.Grpc](https://www.nuget.org/packages/protobuf-net.Grpc) package reference.
* Create service and data contract types.

[!code-csharp[](code-first/samples/5.x/Shared/Contracts.cs?name=snippet)]

The preceding code:

* Defines `HelloRequest` and `HelloReply` messages.
* Defines the `IGreeterService` contract interface with the unary `SayHelloAsync` gRPC method.

The service contract is implemented on the server and called from the client. Methods defined on service interfaces must match certain signatures depending on whether they're unary, server streaming, client streaming, or bidirectional streaming.

For more information on defining service contracts, see the [protobuf-net.Grpc getting started documentation](https://protobuf-net.github.io/protobuf-net.Grpc/gettingstarted).

## Create a code-first gRPC service

To add gRPC code-first service to an ASP.NET Core app:

* Add a [protobuf-net.Grpc.AspNetCore](https://www.nuget.org/packages/protobuf-net.Grpc.AspNetCore) package reference.
* Add a reference to the shared code-contract project.

Create a new `GreeterService.cs` file and implement the `IGreeterService` service interface:

[!code-csharp[](code-first/samples/5.x/GrpcGreeter/Services/GreeterService.cs?name=snippet&highlight=1)]

Update the `Startup.cs` file:

[!code-csharp[](code-first/samples/5.x/GrpcGreeter/Startup.cs?name=snippet&highlight=3,17)]

In the preceding code:

* `AddCodeFirstGrpc` registers services that enable code-first.
* `MapGrpcService<GreeterService>` adds the code-first service endpoint.

gRPC services implemented with code-first and `.proto` files can co-exist in the same app. All gRPC services use [gRPC service configuration](xref:grpc/configuration#configure-services-options).

## Create a code-first gRPC client

A code-first gRPC client uses the service contract to call gRPC services. To call a gRPC service using a code-first client:

* Add a [protobuf-net.Grpc](https://www.nuget.org/packages/protobuf-net.Grpc) package reference.
* Add a reference to the shared code-contract project.
* Add a [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) package reference.

[!code-csharp[](code-first/samples/5.x/GrpcGreeterClient/Program.cs?name=snippet&highlight=2,4-5)]

The preceding code:

* Creates a gRPC channel.
* Creates a code-first client from the channel with the `CreateGrpcService<IGreeterService>` extension method.
* Calls the gRPC service with `SayHelloAsync`.

A code-first gRPC client is created from a channel. Just like a regular client, a code-first client uses its [channel configuration](xref:grpc/configuration#configure-client-options).

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/grpc/code-first/samples/5.x) ([how to download](xref:index#how-to-download-a-sample))

## Additional resources

* [protobuf-net.Grpc website](https://protobuf-net.github.io/protobuf-net.Grpc/)
* [protobuf-net.Grpc GitHub repository](https://github.com/protobuf-net/protobuf-net.Grpc)

:::moniker-end
