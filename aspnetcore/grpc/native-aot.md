---
title: gRPC and native AOT
author: jamesnk
description: Learn about support for gRPC with .NET native ahead-of-time (AOT).
monikerRange: '>= aspnetcore-8.0'
ms.author: jamesnk
ms.date: 04/06/2023
uid: grpc/native-aot
---
# gRPC and native AOT

By [James Newton-King](https://twitter.com/jamesnk)

gRPC supports [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/) in .NET 8. Native AOT enables publishing gRPC client and server apps as small, fast native executables.

> [!WARNING]
> In .NET 8, not all ASP.NET Core features are compatible with native AOT. For more information, see [ASP.NET Core and native AOT compatibility](xref:fundamentals/native-aot#aspnet-core-and-native-aot-compatibility).

## Get started

AOT compilation happens when the app is published. Native AOT is enabled with the `PublishAot` option.

1. Add `<PublishAot>true</PublishAot>` to the gRPC client or server app's project file. This will enable native AOT compilation during publish and enable dynamic code usage analysis during build and editing.

    [!code-xml[](~/grpc/native-aot/Server.csproj?highlight=5)]

    Native AOT can also be enabled by specifying the `-aot` option with the ASP.NET Core gRPC template:

    ```dotnetcli
    dotnet new grpc -aot
    ```

2. Publish the app for a specific [runtime identifier (RID)](/dotnet/core/rid-catalog) using `dotnet publish -r <RID>`.

The app is available in the publish directory and contains all the code needed to run in it.

Native AOT analysis includes all of the app's code and the libraries the app depends on. Review native AOT warnings and take corrective steps. It's a good idea to test publishing apps frequently to discover issues early in the development lifecycle.

## Optimize publish size

A native AOT executable contains just the code from external dependencies required to support the app. Unused code is automatically trimmed away.

The publish size of an ASP.NET Core gRPC service can be optimized by creating the host builder with `WebApplication.CreateSlimBuilder()`. This builder provides a minimal list of features required to run an ASP.NET Core app.

[!code-csharp[](~/grpc/native-aot/Program.cs?highlight=1)]

## Benefits of using native AOT

Apps published with native AOT have:

* Minimized disk footprint
* Reduced startup time
* Reduce memory demand

For more information and examples of the benefits that native AOT provides, see [Benefits of using native AOT with ASP.NET Core](xref:fundamentals/native-aot#benefits-of-using-native-aot-with-aspnet-core).

## Additional resources

* <xref:fundamentals/native-aot>
* [Native AOT deployment](/dotnet/core/deploying/native-aot/)
