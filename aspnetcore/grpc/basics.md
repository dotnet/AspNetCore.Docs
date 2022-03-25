---
title: gRPC services with C#
author: jamesnk
description: Learn the basic concepts when writing gRPC services with C#.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 09/29/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/basics
---
# gRPC services with C\#

:::moniker range=">= aspnetcore-6.0"
This document outlines the concepts needed to write [gRPC](https://grpc.io/docs/guides/) apps in C#. The topics covered here apply to both [C-core](https://grpc.io/blog/grpc-stacks)-based and ASP.NET Core-based gRPC apps.

[!INCLUDE[](~/includes/gRPCazure.md)]

## proto file

gRPC uses a contract-first approach to API development. Protocol buffers (protobuf) are used as the Interface Definition Language (IDL) by default. The `.proto` file contains:

* The definition of the gRPC service.
* The messages sent between clients and servers.

For more information on the syntax of protobuf files, see <xref:grpc/protobuf>.

For example, consider the *greet.proto* file used in [Get started with gRPC service](xref:tutorials/grpc/grpc-start):

* Defines a `Greeter` service.
* The `Greeter` service defines a `SayHello` call.
* `SayHello` sends a `HelloRequest` message and receives a `HelloReply` message:

[!code-protobuf[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeter/Protos/greet.proto)]
[!INCLUDE[about the series](~/includes/code-comments-loc.md)]

## Add a `.proto` file to a C\# app

The `.proto` file is included in a project by adding it to the `<Protobuf>` item group:

[!code-xml[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeter/GrpcGreeter.csproj?highlight=2&range=10-12)]

By default, a `<Protobuf>` reference generates a concrete client and a service base class. The reference element's `GrpcServices` attribute can be used to limit C# asset generation. Valid `GrpcServices` options are:

* `Both` (default when not present)
* `Server`
* `Client`
* `None`

## C# Tooling support for `.proto` files

The tooling package [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/) is required to generate the C# assets from `.proto` files. The generated assets (files):

* Are generated on an as-needed basis each time the project is built.
* Aren't added to the project or checked into source control.
* Are a build artifact contained in the *obj* directory.

This package is required by both the server and client projects. The `Grpc.AspNetCore` metapackage includes a reference to `Grpc.Tools`. Server projects can add `Grpc.AspNetCore` using the Package Manager in Visual Studio or by adding a `<PackageReference>` to the project file:

[!code-xml[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeter/GrpcGreeter.csproj?highlight=1&range=15)]

Client projects should directly reference `Grpc.Tools` alongside the other packages required to use the gRPC client. The tooling package isn't required at runtime, so the dependency is marked with `PrivateAssets="All"`:

[!code-xml[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeterClient/GrpcGreeterClient.csproj?highlight=3&range=11-16)]

## Generated C# assets

The tooling package generates the C# types representing the messages defined in the included `.proto` files.

For server-side assets, an abstract service base type is generated. The base type contains the definitions of all the gRPC calls contained in the `.proto` file. Create a concrete service implementation that derives from this base type and implements the logic for the gRPC calls. For the `greet.proto`, the example described previously, an abstract `GreeterBase` type that contains a virtual `SayHello` method is generated. A concrete implementation `GreeterService` overrides the method and implements the logic handling the gRPC call.

[!code-csharp[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeter/Services/GreeterService.cs?name=snippet)]

For client-side assets, a concrete client type is generated. The gRPC calls in the `.proto` file are translated into methods on the concrete type, which can be called. For the `greet.proto`, the example described previously, a concrete `GreeterClient` type is generated. Call `GreeterClient.SayHelloAsync` to initiate a gRPC call to the server.

[!code-csharp[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeterClient/Program.cs?name=snippet)]

By default, server and client assets are generated for each `.proto` file included in the `<Protobuf>` item group. To ensure only the server assets are generated in a server project, the `GrpcServices` attribute is set to `Server`.

[!code-xml[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeter/GrpcGreeter.csproj?highlight=2&range=10-12)]

Similarly, the attribute is set to `Client` in client projects.

## Additional resources

* <xref:grpc/index>
* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/aspnetcore>
* <xref:grpc/client>
:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"
This document outlines the concepts needed to write [gRPC](https://grpc.io/docs/guides/) apps in C#. The topics covered here apply to both [C-core](https://grpc.io/blog/grpc-stacks)-based and ASP.NET Core-based gRPC apps.

[!INCLUDE[](~/includes/gRPCazure.md)]

## proto file

gRPC uses a contract-first approach to API development. Protocol buffers (protobuf) are used as the Interface Definition Language (IDL) by default. The `.proto` file contains:

* The definition of the gRPC service.
* The messages sent between clients and servers.

For more information on the syntax of protobuf files, see <xref:grpc/protobuf>.

For example, consider the *greet.proto* file used in [Get started with gRPC service](xref:tutorials/grpc/grpc-start):

* Defines a `Greeter` service.
* The `Greeter` service defines a `SayHello` call.
* `SayHello` sends a `HelloRequest` message and receives a `HelloReply` message:

[!code-protobuf[](~/tutorials/grpc/grpc-start/sample/GrpcGreeter/Protos/greet.proto)]
[!INCLUDE[about the series](~/includes/code-comments-loc.md)]

## Add a `.proto` file to a C\# app

The `.proto` file is included in a project by adding it to the `<Protobuf>` item group:

[!code-xml[](~/tutorials/grpc/grpc-start/sample/GrpcGreeter/GrpcGreeter.csproj?highlight=2&range=7-9)]

By default, a `<Protobuf>` reference generates a concrete client and a service base class. The reference element's `GrpcServices` attribute can be used to limit C# asset generation. Valid `GrpcServices` options are:

* `Both` (default when not present)
* `Server`
* `Client`
* `None`

## C# Tooling support for `.proto` files

The tooling package [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/) is required to generate the C# assets from `.proto` files. The generated assets (files):

* Are generated on an as-needed basis each time the project is built.
* Aren't added to the project or checked into source control.
* Are a build artifact contained in the *obj* directory.

This package is required by both the server and client projects. The `Grpc.AspNetCore` metapackage includes a reference to `Grpc.Tools`. Server projects can add `Grpc.AspNetCore` using the Package Manager in Visual Studio or by adding a `<PackageReference>` to the project file:

[!code-xml[](~/tutorials/grpc/grpc-start/sample/GrpcGreeter/GrpcGreeter.csproj?highlight=1&range=12)]

Client projects should directly reference `Grpc.Tools` alongside the other packages required to use the gRPC client. The tooling package isn't required at runtime, so the dependency is marked with `PrivateAssets="All"`:

[!code-xml[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/GrpcGreeterClient.csproj?highlight=3&range=9-14)]

## Generated C# assets

The tooling package generates the C# types representing the messages defined in the included `.proto` files.

For server-side assets, an abstract service base type is generated. The base type contains the definitions of all the gRPC calls contained in the `.proto` file. Create a concrete service implementation that derives from this base type and implements the logic for the gRPC calls. For the `greet.proto`, the example described previously, an abstract `GreeterBase` type that contains a virtual `SayHello` method is generated. A concrete implementation `GreeterService` overrides the method and implements the logic handling the gRPC call.

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeter/Services/GreeterService.cs?name=snippet)]

For client-side assets, a concrete client type is generated. The gRPC calls in the `.proto` file are translated into methods on the concrete type, which can be called. For the `greet.proto`, the example described previously, a concrete `GreeterClient` type is generated. Call `GreeterClient.SayHelloAsync` to initiate a gRPC call to the server.

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/Program.cs?name=snippet)]

By default, server and client assets are generated for each `.proto` file included in the `<Protobuf>` item group. To ensure only the server assets are generated in a server project, the `GrpcServices` attribute is set to `Server`.

[!code-xml[](~/tutorials/grpc/grpc-start/sample/GrpcGreeter/GrpcGreeter.csproj?highlight=2&range=7-9)]

Similarly, the attribute is set to `Client` in client projects.

## Additional resources

* <xref:grpc/index>
* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/aspnetcore>
* <xref:grpc/client>
:::moniker-end
