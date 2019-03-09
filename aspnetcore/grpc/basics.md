---
title: gRPC services with C#
author: juntaoluo
description: Learn the basic concepts when writing gRPC serices with C#.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 03/08/2019
uid: grpc/basics
---
# gRPC services with C#

This document outlines the basic concepts needed to write gRPC apps in C#. The topics covered here apply to both C Core based and ASP.NET Core based apps.

## `.proto` file

gRPC uses a design-first approach to API development. Protocol buffers (protobuf) are used as the Interface Design Language (IDL) by default. As a result, `.proto` file serve as the definition of the gRPC service and messages sent between clients and servers. For more information on the syntax of protobuf files, visit the [official documentation (protobuf)](https://developers.google.com/protocol-buffers/docs/proto3)).

For example, the `greet.proto` file defines a `Greeter` service which defines a `SayHello` call that sends a `HelloRequest` message and receives a `HelloResponse` message:

[!code-proto[](~/tutorials/grpc/samples/GrpcStart/Protos/greet.proto)]

## Adding a `.proto` files to your C# app

The `.proto` file is included in your project by adding it to the `<ProtoBuf>` item group:

[!code-xml[](~/tutorials/grpc/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=8)]

## C# Tooling support for `.proto` files

The tooling package [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/) is required to generate the C# assets from `.proto` files. The assets are generated on a as-needed basis every time the project is built. This dependency is required by both the server and client projects and can be added by using the Package Manager in Visual Studio or adding a `<PackageReference>` to your project file:

[!code-xml[](~/tutorials/grpc/~/tutorials/grpc/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=16)]

Since the tooling package is not required at runtime, the dependency should be marked with `PrivateAssets="All"`.

## Generated C# assets

The tooling package will generate the C# types representing the messages defined in the included `.proto` files.

For server side assets, an abstract service base type is generated. The base type contains the definitions of all the gRPC calls contained in the `.proto` file. A concrete service implementation derives from this base type and implements the logic for the gRPC calls. For the `greet.proto` example described above, an abstract `GreeterBase` type that contains a virtual `SayHello` method is generated. A concrete implementation `GreeterService` then overrides the method and implements the logic handling the gRPC call.

[!code-cs[](~/tutorials/grpc/samples/GrpcStart/GrpcGreeter.Server/Services/GreeterService.cs?highlight=10,12-18)]

For client side assets, a concrete client type is generated. The gRPC calls in the `.proto` file are translated to methods on the concrete type which can be called. For the `greet.proto` example described above, a concrete `GreeterClient` type is generated that contains a `SayHello` method that can be called to initiate a gRPC to the server.

[!code-cs[](~/tutorials/grpc/samples/GrpcStart/GrpcGreeter.Client/Program.cs?highlight=19,21)]

By default, both server and client assets are generated for each `.proto` file included in the `<ProtoBuf>` item group. To ensure only the server assets are generated in a server project, the `GrpcServices` attribute is set to `Server`.

[!code-xml[](~/tutorials/grpc/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=8)]

Similarly the attribute is set to `Client` in client projects:

[!code-xml[](~/tutorials/grpc/samples/GrpcStart/GrpcGreeter.Client/GrpcGreeter.Client.csproj?highlight=10)]

## Additional resources

* <xref:index>
* <xref:grpc/index>
* <xref:grpc/aspnetcore>
* <xref:grpc/migration>