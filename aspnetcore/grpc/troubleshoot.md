---
title: Troubleshoot gRPC on .NET
author: jamesnk
description: Troubleshoot errors when using gRPC on .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 08/08/2023
uid: grpc/troubleshoot
---

# Troubleshoot gRPC on .NET

By [James Newton-King](https://twitter.com/jamesnk)

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range="= aspnetcore-8.0"

This document discusses commonly encountered problems when developing gRPC apps on .NET.

## Mismatch between client and service SSL/TLS configuration

The gRPC template and samples use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246) to secure gRPC services by default. gRPC clients need to use a secure connection to call secured gRPC services successfully.

You can verify the ASP.NET Core gRPC service is using TLS in the logs written on app start. The service will be listening on an HTTPS endpoint:

```output
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

The .NET Core client must use `https` in the server address to make calls with a secured connection:

[!code-csharp[](~/grpc/troubleshoot/sample/8.0/GrpcGreeterClient/Program.cs?name=snippet_StandardHTTPS)]

All gRPC client implementations support TLS. gRPC clients from other languages typically require the channel configured with `SslCredentials`. `SslCredentials` specifies the certificate that the client will use, and it must be used instead of insecure credentials. For examples of configuring the different gRPC client implementations to use TLS, see [gRPC Authentication](https://www.grpc.io/docs/guides/auth/).

## Call a gRPC service with an untrusted/invalid certificate

The .NET gRPC client requires the service to have a trusted certificate. The following error message is returned when calling a gRPC service without a trusted certificate:

> Unhandled exception. System.Net.Http.HttpRequestException: The SSL connection could not be established, see inner exception.
> ---> System.Security.Authentication.AuthenticationException: The remote certificate is invalid according to the validation procedure.

You may see this error if you are testing your app locally and the ASP.NET Core HTTPS development certificate is not trusted. For instructions to fix this issue, see [Trust the ASP.NET Core HTTPS development certificate on Windows and macOS](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos).

If you are calling a gRPC service on another machine and are unable to trust the certificate then the gRPC client can be configured to ignore the invalid certificate. The following code uses <xref:System.Net.Http.HttpClientHandler.ServerCertificateCustomValidationCallback%2A?displayProperty=nameWithType> to allow calls without a trusted certificate:

[!code-csharp[](~/grpc/troubleshoot/sample/8.0/GrpcGreeterClient/Program.cs?name=snippet_IgnoreInvalidCertificate)]

The [gRPC client factory](xref:grpc/clientfactory) allows calls without a trusted certificate. Use the <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method to configure the handler on the client:

[!code-csharp[](~/grpc/troubleshoot/sample/8.0/GrpcGreeterClient/Program.cs?name=snippet_IgnoreInvalidCertificateClientFactory)]

> [!WARNING]
> Untrusted certificates should only be used during app development. Production apps should always use valid certificates.

## Call insecure gRPC services with .NET Core client

The .NET gRPC client can call insecure gRPC services by specifing `http` in the server address. For example, `GrpcChannel.ForAddress("http://localhost:5000")`.

There are some additional requirements to call insecure gRPC services depending on the .NET version an app is using:

* .NET 5 or later requires [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) version 2.32.0 or later.
* .NET Core 3.x requires additional configuration. The app must set the `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch to `true`. For more information see [Asp.Net Core 3.x: Call insecure gRPC services with the .NET client](xref:grpc/troubleshoot?view=aspnetcore-3.1#call-insecure-grpc-services-with-net-core-client-2):

> [!IMPORTANT]
> Insecure gRPC services must be hosted on a HTTP/2-only port. For more information, see [ASP.NET Core protocol negotiation](xref:grpc/aspnetcore#protocol-negotiation).

## Unable to start ASP.NET Core gRPC app on macOS

Kestrel doesn't support HTTP/2 with TLS on macOS before .NET 8. The ASP.NET Core gRPC template and samples use TLS by default. You'll see the following error message when you attempt to start the gRPC server:

> Unable to bind to https://localhost:5001 on the IPv4 loopback interface: 'HTTP/2 over TLS is not supported on macOS due to missing ALPN support.'.

To work around this issue in .NET 7 and earlier, configure Kestrel and the gRPC client to use HTTP/2 *without* TLS. You should only do this during development. Not using TLS will result in gRPC messages being sent without encryption. For more information see [Asp.Net Core 7.0: Unable to start ASP.NET Core gRPC app on macOS](xref:grpc/troubleshoot?view=aspnetcore-7.0#unable-to-start-aspnet-core-grpc-app-on-macos).

## gRPC C# assets are not code generated from `.proto` files

gRPC code generation of concrete clients and service base classes requires protobuf files and tooling to be referenced from a project. You must include:

* `.proto` files you want to use in the `<Protobuf>` item group. [Imported `.proto` files](https://developers.google.com/protocol-buffers/docs/proto3#importing-definitions) must be referenced by the project.
* Package reference to the gRPC tooling package [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/).

For more information on generating gRPC C# assets, see <xref:grpc/basics>.

An ASP.NET Core web app hosting gRPC services only needs the service base class generated:

```xml
<ItemGroup>
  <Protobuf Include="Protos\greet.proto" GrpcServices="Server" />
</ItemGroup>
```

A gRPC client app making gRPC calls only needs the concrete client generated:

```xml
<ItemGroup>
  <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
</ItemGroup>
```

## WPF projects unable to generate gRPC C# assets from `.proto` files

WPF projects have a [known issue](https://github.com/dotnet/wpf/issues/810) that prevents gRPC code generation from working correctly. Any gRPC types generated in a WPF project by referencing `Grpc.Tools` and `.proto` files will create compilation errors when used:

> error CS0246: The type or namespace name 'MyGrpcServices' could not be found (are you missing a using directive or an assembly reference?)

You can workaround this issue by:

1. Create a new .NET Core class library project.
2. In the new project, add references to enable [C# code generation from `.proto` files](xref:grpc/basics#generated-c-assets):
    * Add the following package references:
        * [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/)
        * [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client/)
        * [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/)
    * Add `.proto` files to the `<Protobuf>` item group.
3. In the WPF application, add a reference to the new project.

The WPF application can use the gRPC generated types from the new class library project.

## Calling gRPC services hosted in a sub-directory

> [!WARNING]
> Many third-party gRPC tools don't support services hosted in subdirectories. Consider finding a way to host gRPC as the root directory.

The path component of a gRPC channel's address is ignored when making gRPC calls. For example, `GrpcChannel.ForAddress("https://localhost:5001/ignored_path")` won't use `ignored_path` when routing gRPC calls for the service.

The address path is ignored because gRPC has a standardized, prescriptive address structure. A gRPC address combines the package, service and method names: `https://localhost:5001/PackageName.ServiceName/MethodName`.

There are some scenarios when an app needs to include a path with gRPC calls. For example, when an ASP.NET Core gRPC app is hosted in an IIS directory and the directory needs to be included in the request. When a path is required, it can be added to the gRPC call using the custom `SubdirectoryHandler` specified below:

[!code-csharp[](~/grpc/troubleshoot/sample/8.0/GrpcGreeterClient/Program.cs?name=snippet_SubdirectoryHandler)]

`SubdirectoryHandler` is used when the gRPC channel is created.

[!code-csharp[](~/grpc/troubleshoot/sample/8.0/GrpcGreeterClient/Program.cs?name=snippet_CallSubdirectoryHandler)]

The preceding code:

* Creates a `SubdirectoryHandler` with the path `/MyApp`.
* Configures a channel to use `SubdirectoryHandler`.
* Calls the gRPC service with `SayHelloAsync`. The gRPC call is sent to `https://localhost:5001/MyApp/greet.Greeter/SayHello`.

Alternatively, a client factory can be configured with `SubdirectoryHandler` by using <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.

## Configure gRPC client to use HTTP/3

The .NET gRPC client supports HTTP/3 with .NET 6 or later. If the server sends an `alt-svc` response header to the client that indicates the server supports HTTP/3, the client will automatically upgrade its connection to HTTP/3. For more information, see <xref:fundamentals/servers/kestrel/http3>.

A <xref:System.Net.Http.DelegatingHandler> can be used to force a gRPC client to use HTTP/3. Forcing HTTP/3 avoids the overhead of upgrading the request. Force HTTP/3 with code similar to the following:

[!code-csharp[](~/grpc/troubleshoot/sample/8.0/GrpcGreeterClient/Program.cs?name=snippet_Http3Handler)]

`Http3Handler` is used when the gRPC channel is created. The following code creates a channel configured to use `Http3Handler`.

[!code-csharp[](~/grpc/troubleshoot/sample/8.0/GrpcGreeterClient/Program.cs?name=snippet_CallHttp3Handler)]

Alternatively, a client factory can be configured with `Http3Handler` by using <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.

## Building gRPC on Alpine Linux

The `Grpc.Tools` package [generates .NET types from `.proto` files](xref:grpc/basics#generated-c-assets) using a bundled native binary called `protoc`. Additional steps are required to build gRPC apps on platforms that aren't supported by the native binaries in `Grpc.Tools`, such as Alpine Linux.

### Generate code ahead of time

One solution is to generate code ahead of time.

1. Move `.proto` files and the `Grpc.Tools` package reference to a new project.
1. Publish the project as a NuGet package and upload it to a NuGet feed.
1. Update the app to reference the NuGet package.

With the preceding steps, the app no longer requires `Grpc.Tools` to build because code is generated ahead of time.

### Customize `Grpc.Tools` native binaries

`Grpc.Tools` supports using custom native binaries. This feature allows gRPC tooling to run in environments its bundled native binaries don't support.

Build or acquire `protoc` and `grpc_csharp_plugin` native binaries and configure `Grpc.Tools` to use them. Configure native binaries by setting the following environment variables:

* `PROTOBUF_PROTOC` - Full path to the protocol buffers compiler
* `GRPC_PROTOC_PLUGIN` - Full path to the grpc_csharp_plugin

For Alpine Linux, there are community-provided packages for the protocol buffers compiler and gRPC plugins at [https://pkgs.alpinelinux.org/](https://pkgs.alpinelinux.org/packages?name=grpc-plugins).

```sh
# Build or install the binaries for your architecture.

# e.g. for Alpine Linux the grpc-plugins package can be used
#  See https://pkgs.alpinelinux.org/package/edge/community/x86_64/grpc-plugins
apk add grpc-plugins  # Alpine Linux specific package installer

# Set environment variables for the built/installed protoc
# and grpc_csharp_plugin binaries
export PROTOBUF_PROTOC=/usr/bin/protoc
export GRPC_PROTOC_PLUGIN=/usr/bin/grpc_csharp_plugin

# When dotnet build runs, the Grpc.Tools NuGet package
# uses the binaries pointed to by the environment variables.
dotnet build
```

For more information about using `Grpc.Tools` with unsupported architectures, see the [gRPC build integration documentation](https://github.com/grpc/grpc/blob/master/src/csharp/BUILD-INTEGRATION.md#using-grpctools-with-unsupported-architectures).

:::moniker-end

[!INCLUDE[](~/grpc/troubleshoot/includes/troubleshoot3-7.md)]

