---
title: Introduction to gRPC on ASP.NET Core
author: juntaoluo
description: Learn about gRPC services with Kestrel server and the ASP.NET Core stack.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 02/26/2019
uid: grpc/index
---
# Introduction to gRPC on ASP.NET Core

By [John Luo](https://github.com/juntaoluo)

gRPC is a language agnostic, high-performance Remote Procedure Call (RPC) framework incubated by the Cloud Native Computing Foundation (CNCF). For more on gRPC fundamentals please see the [gRPC documentation page](https://grpc.io/docs/).

The main benefits of gRPC are:
* Modern high-performance lightweight RPC framework.
* Design-first API development, using Protocol Buffers by default, allowing for language agnostic implementations.
* Tooling available for many languages to generate strongly-typed servers and clients.
* Supports client, server, and bi-directional streaming calls.

These benefits make gRPC ideal for:
* Lightweight microservices where efficiency is critical.
* Polyglot systems where multiple languages are required for development.
* Point-to-point real-time services that need to handle streaming requests or responses.

While a C# implementation is currently available on the official [gRPC page](https://grpc.io/docs/quickstart/csharp.html), the current implementation relies on the native library written in C (gRPC C Core). Work is currently in progress to provide a new implementation based on the Kestrel HTTP server and the ASP.NET Core stack that is fully managed. The following documents provide an introduction to building gRPC services with this new implementation.

## Additional resources

* <xref:index>
* <xref:grpc/basics>
* <xref:grpc/aspnetcore>
* <xref:grpc/migration>