---
title: Troubleshoot gRPC on .NET Core
author: jamesnk
description: Troubleshoot errors when using gRPC on .NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 05/04/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/troubleshoot
---

# Troubleshoot gRPC on .NET Core

By [James Newton-King](https://twitter.com/jamesnk)

:::moniker range=">= aspnetcore-6.0"

This document discusses commonly encountered problems when developing gRPC apps on .NET.

## Mismatch between client and service SSL/TLS configuration

The gRPC template and samples use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246) to secure gRPC services by default. gRPC clients need to use a secure connection to call secured gRPC services successfully.

You can verify the ASP.NET Core gRPC service is using TLS in the logs written on app start. The service will be listening on an HTTPS endpoint:

```text
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

The .NET Core client must use `https` in the server address to make calls with a secured connection:

```csharp
static async Task Main(string[] args)
{
    // The port number(5001) must match the port of the gRPC server.
    var channel = GrpcChannel.ForAddress("https://localhost:5001");
    var client = new Greet.GreeterClient(channel);
}
```

All gRPC client implementations support TLS. gRPC clients from other languages typically require the channel configured with `SslCredentials`. `SslCredentials` specifies the certificate that the client will use, and it must be used instead of insecure credentials. For examples of configuring the different gRPC client implementations to use TLS, see [gRPC Authentication](https://www.grpc.io/docs/guides/auth/).

## Call a gRPC service with an untrusted/invalid certificate

The .NET gRPC client requires the service to have a trusted certificate. The following error message is returned when calling a gRPC service without a trusted certificate:

> Unhandled exception. System.Net.Http.HttpRequestException: The SSL connection could not be established, see inner exception.
> ---> System.Security.Authentication.AuthenticationException: The remote certificate is invalid according to the validation procedure.

You may see this error if you are testing your app locally and the ASP.NET Core HTTPS development certificate is not trusted. For instructions to fix this issue, see [Trust the ASP.NET Core HTTPS development certificate on Windows and macOS](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos).

If you are calling a gRPC service on another machine and are unable to trust the certificate then the gRPC client can be configured to ignore the invalid certificate. The following code uses <xref:System.Net.Http.HttpClientHandler.ServerCertificateCustomValidationCallback%2A?displayProperty=nameWithType> to allow calls without a trusted certificate:

```csharp
var httpHandler = new HttpClientHandler();
// Return `true` to allow certificates that are untrusted/invalid
httpHandler.ServerCertificateCustomValidationCallback = 
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

var channel = GrpcChannel.ForAddress("https://localhost:5001",
    new GrpcChannelOptions { HttpHandler = httpHandler });
var client = new Greet.GreeterClient(channel);
```

> [!WARNING]
> Untrusted certificates should only be used during app development. Production apps should always use valid certificates.

## Call insecure gRPC services with .NET Core client

The .NET gRPC client can call insecure gRPC services by specifing `http` in the server address. For example, `GrpcChannel.ForAddress("http://localhost:5000")`.

There are some additional requirements to call insecure gRPC services depending on the .NET version an app is using:

* .NET 5 or later requires [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) version 2.32.0 or later.
* .NET Core 3.x requires additional configuration. The app must set the `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch to `true`:

    ```csharp
    // This switch must be set before creating the GrpcChannel/HttpClient.
    AppContext.SetSwitch(
        "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
    
    // The port number(5000) must match the port of the gRPC server.
    var channel = GrpcChannel.ForAddress("http://localhost:5000");
    var client = new Greet.GreeterClient(channel);
    ```

The `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch is only required for .NET Core 3.x. It does nothing in .NET 5 and isn't required.

> [!IMPORTANT]
> Insecure gRPC services must be hosted on a HTTP/2-only port. For more information, see [ASP.NET Core protocol negotiation](xref:grpc/aspnetcore#protocol-negotiation).

## Unable to start ASP.NET Core gRPC app on macOS

Kestrel doesn't support HTTP/2 with TLS on macOS and older Windows versions such as Windows 7. The ASP.NET Core gRPC template and samples use TLS by default. You'll see the following error message when you attempt to start the gRPC server:

> Unable to bind to https://localhost:5001 on the IPv4 loopback interface: 'HTTP/2 over TLS is not supported on macOS due to missing ALPN support.'.

To work around this issue, configure Kestrel and the gRPC client to use HTTP/2 *without* TLS. You should only do this during development. Not using TLS will result in gRPC messages being sent without encryption.

Kestrel must configure an HTTP/2 endpoint without TLS in `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // Setup a HTTP/2 endpoint without TLS.
    options.ListenLocalhost(<5287>, o => o.Protocols =
        HttpProtocols.Http2);
});
```

* In the preceding code, replace the localhost port number `5287` with the `HTTP` (not `HTTPS`) port number specified in `Properties/launchSettings.json` within the gRPC service project.

When an HTTP/2 endpoint is configured without TLS, the endpoint's [ListenOptions.Protocols](xref:fundamentals/servers/kestrel/endpoints#listenoptionsprotocols) must be set to `HttpProtocols.Http2`. `HttpProtocols.Http1AndHttp2` can't be used because TLS is required to negotiate HTTP/2. Without TLS, all connections to the endpoint default to HTTP/1.1, and gRPC calls fail.

The gRPC client must also be configured to not use TLS. For more information, see [Call insecure gRPC services with .NET Core client](#call-insecure-grpc-services-with-net-core-client).

> [!WARNING]
> HTTP/2 without TLS should only be used during app development. Production apps should always use transport security. For more information, see [Security considerations in gRPC for ASP.NET Core](xref:grpc/security#transport-security).

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

The path component of a gRPC channel's address is ignored when making gRPC calls. For example, `GrpcChannel.ForAddress("https://localhost:5001/ignored_path")` won't use `ignored_path` when routing gRPC calls for the service.

The address path is ignored because gRPC has a standardized, prescriptive address structure. A gRPC address combines the package, service and method names: `https://localhost:5001/PackageName.ServiceName/MethodName`.

There are some scenarios when an app needs to include a path with gRPC calls. For example, when an ASP.NET Core gRPC app is hosted in an IIS directory and the directory needs to be included in the request. When a path is required, it can be added to the gRPC call using the custom `SubdirectoryHandler` specified below:

```csharp
/// <summary>
/// A delegating handler that adds a subdirectory to the URI of gRPC requests.
/// </summary>
public class SubdirectoryHandler : DelegatingHandler
{
    private readonly string _subdirectory;

    public SubdirectoryHandler(HttpMessageHandler innerHandler, string subdirectory)
        : base(innerHandler)
    {
        _subdirectory = subdirectory;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var old = request.RequestUri;

        var url = $"{old.Scheme}://{old.Host}:{old.Port}";
        url += $"{_subdirectory}{request.RequestUri.AbsolutePath}";
        request.RequestUri = new Uri(url, UriKind.Absolute);

        return base.SendAsync(request, cancellationToken);
    }
}
```

`SubdirectoryHandler` is used when the gRPC channel is created.

```csharp
var handler = new SubdirectoryHandler(new HttpClientHandler(), "/MyApp");

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = handler });
var client = new Greet.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
```

The preceding code:

* Creates a `SubdirectoryHandler` with the path `/MyApp`.
* Configures a channel to use `SubdirectoryHandler`.
* Calls the gRPC service with `SayHelloAsync`. The gRPC call is sent to `https://localhost:5001/MyApp/greet.Greeter/SayHello`.

Alternatively, a client factory can be configured with `SubdirectoryHandler` by using <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.

## Configure gRPC client to use HTTP/3

The .NET gRPC client supports HTTP/3 with .NET 6 or later. If the server sends an `alt-svc` response header to the client that indicates the server supports HTTP/3, the client will automatically upgrade its connection to HTTP/3. For information about how to enable HTTP/3 on the server, see <xref:fundamentals/servers/kestrel/http3>.

HTTP/3 support is in preview in .NET 6, and needs to be enabled via a configuration flag in the project file:

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Net.SocketsHttpHandler.Http3Support" Value="true" />
</ItemGroup>
```

`System.Net.SocketsHttpHandler.Http3Support` can also be set using [AppContext.SetSwitch](xref:System.AppContext.SetSwitch%2A).

A <xref:System.Net.Http.DelegatingHandler> can bee used to force a gRPC client to use HTTP/3. Forcing HTTP/3 avoids the overhead of upgrading the request. Force HTTP/3 with code similar to the following:

```csharp
/// <summary>
/// A delegating handler that changes the request HTTP version to HTTP/3.
/// </summary>
public class Http3Handler : DelegatingHandler
{
    public Http3Handler() { }
    public Http3Handler(HttpMessageHandler innerHandler) : base(innerHandler) { }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Version = HttpVersion.Version30;
        request.VersionPolicy = HttpVersionPolicy.RequestVersionExact;

        return base.SendAsync(request, cancellationToken);
    }
}
```

`Http3Handler` is used when the gRPC channel is created. The following code creates a channel configured to use `Http3Handler`.

```csharp
var handler = new Http3Handler(new HttpClientHandler());

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = handler });
var client = new Greet.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
```

Alternatively, a client factory can be configured with `Http3Handler` by using <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.


[!INCLUDE[](~/includes/gRPCazure.md)]

:::moniker-end
:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

This document discusses commonly encountered problems when developing gRPC apps on .NET.

## Mismatch between client and service SSL/TLS configuration

The gRPC template and samples use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246) to secure gRPC services by default. gRPC clients need to use a secure connection to call secured gRPC services successfully.

You can verify the ASP.NET Core gRPC service is using TLS in the logs written on app start. The service will be listening on an HTTPS endpoint:

```text
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

The .NET Core client must use `https` in the server address to make calls with a secured connection:

```csharp
static async Task Main(string[] args)
{
    // The port number(5001) must match the port of the gRPC server.
    var channel = GrpcChannel.ForAddress("https://localhost:5001");
    var client = new Greet.GreeterClient(channel);
}
```

All gRPC client implementations support TLS. gRPC clients from other languages typically require the channel configured with `SslCredentials`. `SslCredentials` specifies the certificate that the client will use, and it must be used instead of insecure credentials. For examples of configuring the different gRPC client implementations to use TLS, see [gRPC Authentication](https://www.grpc.io/docs/guides/auth/).

## Call a gRPC service with an untrusted/invalid certificate

The .NET gRPC client requires the service to have a trusted certificate. The following error message is returned when calling a gRPC service without a trusted certificate:

> Unhandled exception. System.Net.Http.HttpRequestException: The SSL connection could not be established, see inner exception.
> ---> System.Security.Authentication.AuthenticationException: The remote certificate is invalid according to the validation procedure.

You may see this error if you are testing your app locally and the ASP.NET Core HTTPS development certificate is not trusted. For instructions to fix this issue, see [Trust the ASP.NET Core HTTPS development certificate on Windows and macOS](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos).

If you are calling a gRPC service on another machine and are unable to trust the certificate then the gRPC client can be configured to ignore the invalid certificate. The following code uses <xref:System.Net.Http.HttpClientHandler.ServerCertificateCustomValidationCallback%2A?displayProperty=nameWithType> to allow calls without a trusted certificate:

```csharp
var httpHandler = new HttpClientHandler();
// Return `true` to allow certificates that are untrusted/invalid
httpHandler.ServerCertificateCustomValidationCallback = 
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

var channel = GrpcChannel.ForAddress("https://localhost:5001",
    new GrpcChannelOptions { HttpHandler = httpHandler });
var client = new Greet.GreeterClient(channel);
```

> [!WARNING]
> Untrusted certificates should only be used during app development. Production apps should always use valid certificates.

## Call insecure gRPC services with .NET Core client

The .NET gRPC client can call insecure gRPC services by specifing `http` in the server address. For example, `GrpcChannel.ForAddress("http://localhost:5000")`.

There are some additional requirements to call insecure gRPC services depending on the .NET version an app is using:

* .NET 5 or later requires [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) version 2.32.0 or later.
* .NET Core 3.x requires additional configuration. The app must set the `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch to `true`:

    ```csharp
    // This switch must be set before creating the GrpcChannel/HttpClient.
    AppContext.SetSwitch(
        "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
    
    // The port number(5000) must match the port of the gRPC server.
    var channel = GrpcChannel.ForAddress("http://localhost:5000");
    var client = new Greet.GreeterClient(channel);
    ```

The `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch is only required for .NET Core 3.x. It does nothing in .NET 5 and isn't required.

> [!IMPORTANT]
> Insecure gRPC services must be hosted on a HTTP/2-only port. For more information, see [ASP.NET Core protocol negotiation](xref:grpc/aspnetcore#protocol-negotiation).

## Unable to start ASP.NET Core gRPC app on macOS

Kestrel doesn't support HTTP/2 with TLS on macOS and older Windows versions such as Windows 7. The ASP.NET Core gRPC template and samples use TLS by default. You'll see the following error message when you attempt to start the gRPC server:

> Unable to bind to https://localhost:5001 on the IPv4 loopback interface: 'HTTP/2 over TLS is not supported on macOS due to missing ALPN support.'.

To work around this issue, configure Kestrel and the gRPC client to use HTTP/2 *without* TLS. You should only do this during development. Not using TLS will result in gRPC messages being sent without encryption.

Kestrel must configure an HTTP/2 endpoint without TLS in `Program.cs`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                // Setup a HTTP/2 endpoint without TLS.
                options.ListenLocalhost(5000, o => o.Protocols = 
                    HttpProtocols.Http2);
            });
            webBuilder.UseStartup<Startup>();
        });
```

When an HTTP/2 endpoint is configured without TLS, the endpoint's [ListenOptions.Protocols](xref:fundamentals/servers/kestrel/endpoints#listenoptionsprotocols) must be set to `HttpProtocols.Http2`. `HttpProtocols.Http1AndHttp2` can't be used because TLS is required to negotiate HTTP/2. Without TLS, all connections to the endpoint default to HTTP/1.1, and gRPC calls fail.

The gRPC client must also be configured to not use TLS. For more information, see [Call insecure gRPC services with .NET Core client](#call-insecure-grpc-services-with-net-core-client).

> [!WARNING]
> HTTP/2 without TLS should only be used during app development. Production apps should always use transport security. For more information, see [Security considerations in gRPC for ASP.NET Core](xref:grpc/security#transport-security).

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

The path component of a gRPC channel's address is ignored when making gRPC calls. For example, `GrpcChannel.ForAddress("https://localhost:5001/ignored_path")` won't use `ignored_path` when routing gRPC calls for the service.

The address path is ignored because gRPC has a standardized, prescriptive address structure. A gRPC address combines the package, service and method names: `https://localhost:5001/PackageName.ServiceName/MethodName`.

There are some scenarios when an app needs to include a path with gRPC calls. For example, when an ASP.NET Core gRPC app is hosted in an IIS directory and the directory needs to be included in the request. When a path is required, it can be added to the gRPC call using the custom `SubdirectoryHandler` specified below:

```csharp
/// <summary>
/// A delegating handler that adds a subdirectory to the URI of gRPC requests.
/// </summary>
public class SubdirectoryHandler : DelegatingHandler
{
    private readonly string _subdirectory;

    public SubdirectoryHandler(HttpMessageHandler innerHandler, string subdirectory)
        : base(innerHandler)
    {
        _subdirectory = subdirectory;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var old = request.RequestUri;

        var url = $"{old.Scheme}://{old.Host}:{old.Port}";
        url += $"{_subdirectory}{request.RequestUri.AbsolutePath}";
        request.RequestUri = new Uri(url, UriKind.Absolute);

        return base.SendAsync(request, cancellationToken);
    }
}
```

`SubdirectoryHandler` is used when the gRPC channel is created.

```csharp
var handler = new SubdirectoryHandler(new HttpClientHandler(), "/MyApp");

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = handler });
var client = new Greet.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
```

The preceding code:

* Creates a `SubdirectoryHandler` with the path `/MyApp`.
* Configures a channel to use `SubdirectoryHandler`.
* Calls the gRPC service with `SayHelloAsync`. The gRPC call is sent to `https://localhost:5001/MyApp/greet.Greeter/SayHello`.

Alternatively, a client factory can be configured with `SubdirectoryHandler` by using <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.

[!INCLUDE[](~/includes/gRPCazure.md)]

:::moniker-end
:::moniker range=">= aspnetcore-3.0 < aspnetcore-5.0"

This document discusses commonly encountered problems when developing gRPC apps on .NET.

## Mismatch between client and service SSL/TLS configuration

The gRPC template and samples use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246) to secure gRPC services by default. gRPC clients need to use a secure connection to call secured gRPC services successfully.

You can verify the ASP.NET Core gRPC service is using TLS in the logs written on app start. The service will be listening on an HTTPS endpoint:

```text
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

The .NET Core client must use `https` in the server address to make calls with a secured connection:

```csharp
static async Task Main(string[] args)
{
    // The port number(5001) must match the port of the gRPC server.
    var channel = GrpcChannel.ForAddress("https://localhost:5001");
    var client = new Greet.GreeterClient(channel);
}
```

All gRPC client implementations support TLS. gRPC clients from other languages typically require the channel configured with `SslCredentials`. `SslCredentials` specifies the certificate that the client will use, and it must be used instead of insecure credentials. For examples of configuring the different gRPC client implementations to use TLS, see [gRPC Authentication](https://www.grpc.io/docs/guides/auth/).

## Call a gRPC service with an untrusted/invalid certificate

The .NET gRPC client requires the service to have a trusted certificate. The following error message is returned when calling a gRPC service without a trusted certificate:

> Unhandled exception. System.Net.Http.HttpRequestException: The SSL connection could not be established, see inner exception.
> ---> System.Security.Authentication.AuthenticationException: The remote certificate is invalid according to the validation procedure.

You may see this error if you are testing your app locally and the ASP.NET Core HTTPS development certificate is not trusted. For instructions to fix this issue, see [Trust the ASP.NET Core HTTPS development certificate on Windows and macOS](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos).

If you are calling a gRPC service on another machine and are unable to trust the certificate then the gRPC client can be configured to ignore the invalid certificate. The following code uses <xref:System.Net.Http.HttpClientHandler.ServerCertificateCustomValidationCallback%2A?displayProperty=nameWithType> to allow calls without a trusted certificate:

```csharp
var httpHandler = new HttpClientHandler();
// Return `true` to allow certificates that are untrusted/invalid
httpHandler.ServerCertificateCustomValidationCallback = 
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

var channel = GrpcChannel.ForAddress("https://localhost:5001",
    new GrpcChannelOptions { HttpHandler = httpHandler });
var client = new Greet.GreeterClient(channel);
```

> [!WARNING]
> Untrusted certificates should only be used during app development. Production apps should always use valid certificates.

## Call insecure gRPC services with .NET Core client

The .NET gRPC client can call insecure gRPC services by specifing `http` in the server address. For example, `GrpcChannel.ForAddress("http://localhost:5000")`.

There are some additional requirements to call insecure gRPC services depending on the .NET version an app is using:

* .NET 5 or later requires [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) version 2.32.0 or later.
* .NET Core 3.x requires additional configuration. The app must set the `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch to `true`:

    ```csharp
    // This switch must be set before creating the GrpcChannel/HttpClient.
    AppContext.SetSwitch(
        "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
    
    // The port number(5000) must match the port of the gRPC server.
    var channel = GrpcChannel.ForAddress("http://localhost:5000");
    var client = new Greet.GreeterClient(channel);
    ```

The `System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport` switch is only required for .NET Core 3.x. It does nothing in .NET 5 and isn't required.

> [!IMPORTANT]
> Insecure gRPC services must be hosted on a HTTP/2-only port. For more information, see [ASP.NET Core protocol negotiation](xref:grpc/aspnetcore#protocol-negotiation).

## Unable to start ASP.NET Core gRPC app on macOS

Kestrel doesn't support HTTP/2 with TLS on macOS and older Windows versions such as Windows 7. The ASP.NET Core gRPC template and samples use TLS by default. You'll see the following error message when you attempt to start the gRPC server:

> Unable to bind to https://localhost:5001 on the IPv4 loopback interface: 'HTTP/2 over TLS is not supported on macOS due to missing ALPN support.'.

To work around this issue, configure Kestrel and the gRPC client to use HTTP/2 *without* TLS. You should only do this during development. Not using TLS will result in gRPC messages being sent without encryption.

Kestrel must configure an HTTP/2 endpoint without TLS in `Program.cs`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                // Setup a HTTP/2 endpoint without TLS.
                options.ListenLocalhost(5000, o => o.Protocols = 
                    HttpProtocols.Http2);
            });
            webBuilder.UseStartup<Startup>();
        });
```

When an HTTP/2 endpoint is configured without TLS, the endpoint's [ListenOptions.Protocols](xref:fundamentals/servers/kestrel#listenoptionsprotocols) must be set to `HttpProtocols.Http2`. `HttpProtocols.Http1AndHttp2` can't be used because TLS is required to negotiate HTTP/2. Without TLS, all connections to the endpoint default to HTTP/1.1, and gRPC calls fail.

The gRPC client must also be configured to not use TLS. For more information, see [Call insecure gRPC services with .NET Core client](#call-insecure-grpc-services-with-net-core-client).

> [!WARNING]
> HTTP/2 without TLS should only be used during app development. Production apps should always use transport security. For more information, see [Security considerations in gRPC for ASP.NET Core](xref:grpc/security#transport-security).

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

The path component of a gRPC channel's address is ignored when making gRPC calls. For example, `GrpcChannel.ForAddress("https://localhost:5001/ignored_path")` won't use `ignored_path` when routing gRPC calls for the service.

The address path is ignored because gRPC has a standardized, prescriptive address structure. A gRPC address combines the package, service and method names: `https://localhost:5001/PackageName.ServiceName/MethodName`.

There are some scenarios when an app needs to include a path with gRPC calls. For example, when an ASP.NET Core gRPC app is hosted in an IIS directory and the directory needs to be included in the request. When a path is required, it can be added to the gRPC call using the custom `SubdirectoryHandler` specified below:

```csharp
/// <summary>
/// A delegating handler that adds a subdirectory to the URI of gRPC requests.
/// </summary>
public class SubdirectoryHandler : DelegatingHandler
{
    private readonly string _subdirectory;

    public SubdirectoryHandler(HttpMessageHandler innerHandler, string subdirectory)
        : base(innerHandler)
    {
        _subdirectory = subdirectory;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var old = request.RequestUri;

        var url = $"{old.Scheme}://{old.Host}:{old.Port}";
        url += $"{_subdirectory}{request.RequestUri.AbsolutePath}";
        request.RequestUri = new Uri(url, UriKind.Absolute);

        return base.SendAsync(request, cancellationToken);
    }
}
```

`SubdirectoryHandler` is used when the gRPC channel is created.

```csharp
var handler = new SubdirectoryHandler(new HttpClientHandler(), "/MyApp");

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = handler });
var client = new Greet.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
```

The preceding code:

* Creates a `SubdirectoryHandler` with the path `/MyApp`.
* Configures a channel to use `SubdirectoryHandler`.
* Calls the gRPC service with `SayHelloAsync`. The gRPC call is sent to `https://localhost:5001/MyApp/greet.Greeter/SayHello`.

Alternatively, a client factory can be configured with `SubdirectoryHandler` by using <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.

[!INCLUDE[](~/includes/gRPCazure.md)]

:::moniker-end
