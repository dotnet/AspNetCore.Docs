---
title: Use gRPC in browser apps
author: jamesnk
description: Learn the options available to make ASP.NET Core gRPC services callable from browser apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 06/30/2020
uid: grpc/browser
---
# Use gRPC in browser apps

By [James Newton-King](https://twitter.com/jamesnk)

It's not possible to directly call a gRPC service from a browser. gRPC uses HTTP/2 features, and no browser provides the level of control required over web requests to support a gRPC client.

gRPC on ASP.NET Core offers two browser-compatible solutions:

* **gRPC-Web** allows browser apps to call gRPC services with the gRPC-Web client and Protobuf. gRPC-Web requires the browser app to generate a gRPC client. gRPC-Web allows browser apps to benefit from the high-performance and low network usage of gRPC.

  .NET has built-in support for gRPC-Web. For more information, see <xref:grpc/grpcweb>.

* **gRPC JSON transcoding** allows browser apps to call gRPC services as if they were RESTful APIs with JSON. The browser app doesn't need to generate a gRPC client or know anything about gRPC. RESTful APIs can be automatically created from gRPC services by annotating the `.proto` file with HTTP metadata. Transcoding allows an app to support both gRPC and JSON web APIs without duplicating the effort of building separate services for both.

  .NET has built-in support for creating JSON web APIs from gRPC services. For more information, see <xref:grpc/httpapi>.

> [!NOTE]
> gRPC JSON transcoding requires .NET 7 or later.

## Additional resources

* <xref:grpc/grpcweb>
* <xref:grpc/httpapi>
