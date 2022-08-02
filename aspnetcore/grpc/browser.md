---
title: Use gRPC in browser apps
author: jamesnk
description: Learn how to configure gRPC services on ASP.NET Core to be callable from browser apps using gRPC-Web.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 06/30/2020
uid: grpc/browser
---
# Use gRPC in browser apps

By [James Newton-King](https://twitter.com/jamesnk)

It's not possible to call HTTP/2 gRPC services from browser-based apps. gRPC uses HTTP/2 features to enable streaming and cancellation, which makes it incompatible with browser clients.

gRPC on ASP.NET Core offers two solutions to call gRPC services from browser apps:

* **gRPC-Web** allows browser apps to call gRPC services with the gRPC-Web client and Protobuf. gRPC-Web requires the browser app to generate a gRPC client. gRPC-Web is very similar to gRPC over HTTP/2 and it has the advantage of sending small, fast Protobuf messages.

* **gRPC JSON transcoding** allows browser apps to call gRPC services as if they were RESTful APIs with JSON. The browser app doesn't need to generate a gRPC client or know anything about gRPC. Transcoding offers a fast way to provide a RESTful JSON API alongside a gRPC services.

> [!NOTE]
> gRPC JSON transcoding requires .NET 7 or later.

## Additional resources

* <xref:grpc/grpcweb>
* <xref:grpc/httpapi>
