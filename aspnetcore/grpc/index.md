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

[gRPC](https://grpc.io/docs/guides/) is a language agnostic, high-performance Remote Procedure Call (RPC) framework. For more on gRPC fundamentals, see the [gRPC documentation page](https://grpc.io/docs/).

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

The following documents introduce [gRPC for .NET](https://github.com/grpc/grpc-dotnet), a new, fully managed implementation of gRPC that runs on .NET Core 3.0.

> [!TIP]
> An alternative C# implementation is available on the [gRPC for C# page](https://grpc.io/docs/quickstart/csharp.html). This implementation relies on the native library written in C (gRPC [C-core](https://grpc.io/blog/grpc-stacks)).

## Additional resources

* <xref:grpc/basics>
* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/aspnetcore>
* <xref:grpc/migration>
