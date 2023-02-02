---
title: Use gRPC in browser apps
author: jamesnk
description: Learn the options available to make ASP.NET Core gRPC services callable from browser apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 08/04/2022
uid: grpc/browser
---
# Use gRPC in browser apps

By [James Newton-King](https://twitter.com/jamesnk)

It's not possible to directly call a gRPC service from a browser. gRPC uses HTTP/2 features, and no browser provides the level of control required over web requests to support a gRPC client.

gRPC on ASP.NET Core offers two browser-compatible solutions, gRPC-Web and gRPC JSON transcoding.

## gRPC-Web

gRPC-Web allows browser apps to call gRPC services with the gRPC-Web client and Protobuf.

* Similar to normal gRPC, but it has a slightly different wire-protocol, which makes it compatible with HTTP/1.1 and browsers.
* Requires the browser app to generate a gRPC client from a `.proto` file.
* Allows browser apps to benefit from the high-performance and low network usage of binary messages.

.NET has built-in support for gRPC-Web. For more information, see <xref:grpc/grpcweb>.

## gRPC JSON transcoding

gRPC JSON transcoding allows browser apps to call gRPC services as if they were RESTful APIs with JSON.

* The browser app doesn't need to generate a gRPC client or know anything about gRPC.
* RESTful APIs are automatically created from gRPC services by annotating the `.proto` file with HTTP metadata.
* Allows an app to support both gRPC and JSON web APIs without duplicating the effort of building separate services for both.

.NET has built-in support for creating JSON web APIs from gRPC services. For more information, see <xref:grpc/json-transcoding>.

> [!NOTE]
> gRPC JSON transcoding requires .NET 7 or later.

## Additional resources

* <xref:grpc/grpcweb>
* <xref:grpc/json-transcoding>
