---
title: What's new in ASP.NET Core 8.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 8.0.
ms.author: riande
ms.custom: mvc
ms.date: 06/30/2023
uid: aspnetcore-8
---
# What's new in ASP.NET Core 8.0

This article highlights the most significant changes in ASP.NET Core 8.0 with links to relevant documentation.

This article is under development and not complete. More information may be found in the ASP.NET Core 8.0 preview blogs and GitHub issue:

* [ASP.NET Core roadmap for .NET 8 on GitHub](https://github.com/dotnet/aspnetcore/issues/44984) 
* [What's new in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
* [What's new in .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-2/)
* [What's new in .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-3/)
* [What's new in .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/)
* [What's new in .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-5/)
<!--
* [What's new in .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-6/)
* [What's new in .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-7/)
-->

<!--
## Blazor
-->

## SignalR

### New approach to set the server timeout and Keep-Alive interval

<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) can be set directly on <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>.

#### Prior approach for JavaScript clients

The following example shows the assignment of values that are double the default values in ASP.NET Core 7.0 or earlier:

```javascript
var connection = new signalR.HubConnectionBuilder()
  .withUrl("/chatHub")
  .build();

connection.serverTimeoutInMilliseconds = 60000;
connection.keepAliveIntervalInMilliseconds = 30000;
```

#### New approach for JavaScript clients

The following example shows the ***new approach*** for assigning values that are double the default values in ASP.NET Core 8.0 or later:

```javascript
var connection = new signalR.HubConnectionBuilder()
  .withUrl("/chatHub")
  .withServerTimeoutInMilliseconds(60000)
  .withKeepAliveIntervalInMilliseconds(30000)
  .build();
```

#### Prior approach for the JavaScript client of a Blazor Server app

The following example shows the assignment of values that are double the default values in ASP.NET Core 7.0 or earlier:

```javascript
Blazor.start({
  configureSignalR: function (builder) {
    let c = builder.build();
    c.serverTimeoutInMilliseconds = 60000;
    c.keepAliveIntervalInMilliseconds = 30000;
    builder.build = () => {
      return c;
    };
  }
});
```

#### New approach for the JavaScript client of a Blazor Server app

The following example shows the ***new approach*** for assigning values that are double the default values in ASP.NET Core 8.0 or later:

```javascript
Blazor.start({
  configureSignalR: function (builder) {
    builder.withServerTimeout(60000).withKeepAliveInterval(30000);
  }
});
```

#### Prior approach for .NET clients

The following example shows the assignment of values that are double the default values in ASP.NET Core 7.0 or earlier:

```csharp
var builder = new HubConnectionBuilder()
    .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
    .Build();

builder.ServerTimeout = TimeSpan.FromSeconds(60);
builder.KeepAliveInterval = TimeSpan.FromSeconds(30);

builder.On<string, string>("ReceiveMessage", (user, message) => ...

await builder.StartAsync();
```

#### New approach for .NET clients

The following example shows the ***new approach*** for assigning values that are double the default values in ASP.NET Core 8.0 or later:

```csharp
var builder = new HubConnectionBuilder()
    .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
    .WithServerTimeout(TimeSpan.FromSeconds(60))
    .WithKeepAliveInterval(TimeSpan.FromSeconds(30))
    .Build();

builder.On<string, string>("ReceiveMessage", (user, message) => ...

await builder.StartAsync();
```

## Minimal APIs

This section describes new features for minimal APIs. See also [the section on native AOT](#native-aot) for more information relevant to minimal APIs.

### Binding to forms

Explicit binding to form values using the [[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) attribute is now supported. Inferred binding to forms using the <xref:Microsoft.AspNetCore.Http.IFormCollection>, <xref:Microsoft.AspNetCore.Http.IFormFile>, and <xref:Microsoft.AspNetCore.Http.IFormFileCollection> types is also supported. [OpenAPI](xref:fundamentals/minimal-apis/openapi) metadata is inferred for form parameters to support integration with [Swagger UI](xref:tutorials/web-api-help-pages-using-swagger).

For more information, see:

* [Explicit binding from form values](xref:fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0&preserve-view=true#explicit-binding-from-form-values).
* [Binding to forms with IFormCollection, IFormFile, and IFormFileCollection](xref:fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0&preserve-view=true#binding-to-forms-with-iformcollection-iformfile-and-iformfilecollection).

### Support for AsParameters and automatic metadata generation

Minimal APIs generated at compile-time include support for parameters decorated with the [`[AsParameters]`](xref:Microsoft.AspNetCore.Http.AsParametersAttribute) attribute and support automatic metadata inference for request and response types. Consider the following code:

:::code language="csharp" source="~/release-notes/sample/ProgramAsParameters.cs" highlight="22":::

The preceding generated code:

* Binds a `projectId` parameter from the query.
* Binds a `Todo` parameter from the JSON body.
* Annotates the endpoint metadata to indicate that it accepts a JSON payload.
* Annotate the endpoint metadata to indicate that it returns a Todo as a JSON payload.

## Native AOT

Support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/) has been added. Apps that are published using AOT can have substantially better performance: smaller app size, less memory usage, and faster startup time. Native AOT is currently supported by gRPC, minimal API, and worker service apps. For more information, see <xref:fundamentals/native-aot> and <xref:fundamentals/native-aot-tutorial>. For information about known issues with ASP.NET Core and native AOT compatibility, see GitHub issue [dotnet/core #8288](https://github.com/dotnet/core/issues/8288).

### New project template

The new **ASP.NET Core API** template in Visual Studio 2022 has an **Enable native AOT publish** option. The equivalent template and option in the CLI is the `dotnet new api` command and the `--aot` option. This template is intended to produce a project focused on cloud-native, API-first scenarios. For more information, see [The API template](xref:fundamentals/native-aot#the-api-template).

### New CreateSlimBuilder method

The <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> method used in the API template initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimum ASP.NET Core features necessary to run an app. It's used by the API template whether or not the AOT option is used. For more information, see [The `CreateSlimBuilder` method](xref:fundamentals/native-aot#the-createslimbuilder-method).

### Reduced app size with configurable HTTPS support

We've further reduced native AOT binary size for apps that don't need HTTPS or HTTP/3 support. Not using HTTPS or HTTP/3 is common for apps that run behind a TLS termination proxy (for example, hosted on Azure). The new `WebApplication.CreateSlimBuilder` method omits this functionality by default. It can be added by calling `builder.WebHost.UseKestrelHttpsConfiguration()` for HTTPS or `builder.WebHost.UseQuic()` for HTTP/3. For more information, see [The `CreateSlimBuilder` method](xref:fundamentals/native-aot#the-createslimbuilder-method).

### JSON serialization of compiler-generated `IAsyncEnumerable<T>` types

New features were added to <xref:System.Text.Json> to better support native AOT. These new features add capabilities for the source generation mode of `System.Text.Json`, because reflection isn't supported by AOT.

One of the new features is support for JSON serialization of <xref:System.Collections.Generic.IAsyncEnumerable%601> implementations implemented by the C# compiler. This support opens up their use in ASP.NET Core projects configured to publish native AOT.

This API is useful in scenarios where a route handler uses `yield return` to asynchronously return an enumeration. For example, to materialize rows from a database query. For more information, see [Unspeakable type support](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/#unspeakable-type-support) in the .NET 8 Preview 4 announcement.

For information abut other improvements in `System.Text.Json` source generation, see [Serialization improvements in .NET 8](/dotnet/core/whats-new/dotnet-8#serialization).

### Top-level APIs annotated for trim warnings

The main entry points to subsystems that don't work reliably with native AOT are now annotated. When these methods are called from an application with native AOT enabled, a warning is provided. For example, the following code produces a warning at the invocation of `AddControllers` because this API isn't trim-safe and isn't supported by native AOT.

:::image type="content" source="../fundamentals/aot/_static/top-level-annnotations.png" alt-text="Visual Studio window showing IL2026 warning message on the AddControllers method that says MVC doesn't currently support native AOT.":::

### Request delegate generator

In order to make Minimal APIs compatible with native AOT, we're introducing the Request Delegate Generator (RDG). The RDG is a source generator that does what the <xref:Microsoft.AspNetCore.Http.RequestDelegateFactory> (RDF) does. That is, it turns the various `MapGet()`, `MapPost()`, and calls like them into <xref:Microsoft.AspNetCore.Http.RequestDelegate> instances associated with the specified routes. But rather than doing it in-memory in an application when it starts, the RDG does it at compile time and generates C# code directly into the project. The RDG:

* Removes the runtime generation of this code.
* Ensures that the types used in APIs are statically analyzable by the native AOT tool-chain.
* Ensures that required code is not trimmed away.

We're working to ensure that as many as possible of the Minimal API features are supported by the RDG and thus compatible with native AOT.

The RDG is enabled automatically in a project when publishing with native AOT is enabled. RDG can be manually enabled even when not using native AOT by setting `<EnableRequestDelegateGenerator>true</EnableRequestDelegateGenerator>` in the project file. This can be useful when initially evaluating a project's readiness for native AOT, or to reduce the startup time of an app.

### Logging and exception handling in compile-time generated minimal APIs

Minimal APIs generated at run time support automatically logging (or throwing exceptions in Development environments) when parameter binding fails. .NET 8 introduces the same support for APIs generated at compile time via the [Request Delegate Generator](#request-delegate-generator) (RDG). For more information, see [Logging and exception handling in compile-time generated minimal APIs](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/#logging-and-exception-handling-in-compile-time-generated-minimal-apis).

### AOT and System.Text.Json

Minimal APIs are optimized for receiving and returning JSON payloads using `System.Text.Json`, so the compatibility requirements for JSON and native AOT apply too. Native AOT compatibility requires the use of the `System.Text.Json` source generator. All types accepted as parameters to or returned from request delegates in Minimal APIs must be configured on a `JsonSerializerContext` that is registered via ASP.NET Core's dependency injection, for example:

```csharp
// Register the JSON serializer context with DI
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

...

// Add types used in the minimal API app to source generated JSON serializer content
[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
```

For more information about the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> API, see the following resources:

* [JsonSerializerOptions.TypeInfoResolverChain](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/#jsonserializeroptions-typeinforesolverchain)
* [Chain source generators](/dotnet/core/whats-new/dotnet-8#chain-source-generators)
* [Changes to support source generation](xref:fundamentals/native-aot#changes-to-support-source-generation)

### Libraries and native AOT

Many of the common libraries available for ASP.NET Core projects today have some compatibility issues if used in a project targeting native AOT. Popular libraries often rely on the dynamic capabilities of .NET reflection to inspect and discover types, conditionally load libraries at runtime, and generate code on the fly to implement their functionality. These libraries need to be updated in order to work with native AOT by using tools like [Roslyn source generators](/dotnet/csharp/roslyn-sdk/source-generators-overview).

Library authors wishing to learn more about preparing their libraries for native AOT are encouraged to start by [preparing their library for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming) and learning more about the [native AOT compatibility requirements](/dotnet/core/deploying/native-aot/).

## Kestrel and HTTP.sys servers

There are several new features for Kestrel and HTTP.sys.

### Support for named pipes in Kestrel

Named pipes is a popular technology for building inter-process communication (IPC) between Windows apps. You can now build an IPC server using .NET, Kestrel, and named pipes.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenNamedPipe("MyPipeName");
});
```

For more information about this feature and how to use .NET and gRPC to create an IPC server and client, see <xref:grpc/interprocess>.

### HTTP/3 enabled by default in Kestrel

HTTP/3 is a new internet technology that was standardized in June 2022. HTTP/3 offers several advantages over older HTTP protocols, including:

* Faster connection setup.
* No head-of-line blocking.
* Better transitions between networks.

.NET 7 added support for HTTP/3 to ASP.NET Core and Kestrel. ASP.NET Core apps could choose to turn it on. In .NET 8, HTTP/3 is enabled by default for Kestrel, alongside HTTP/1.1 and HTTP/2. For more information about HTTP/3 and its requirements, see <xref:fundamentals/servers/kestrel/http3>.

### HTTP/2 over TLS (HTTPS) support on macOS in Kestrel

.NET 8 adds support for Application-Layer Protocol Negotiation (ALPN) to macOS. ALPN is a TLS feature used to negotiate which HTTP protocol a connection will use. For example, ALPN allows browsers and other HTTP clients to request an HTTP/2 connection. This feature is especially useful for gRPC apps, which require HTTP/2. For more information, see <xref:fundamentals/servers/kestrel/http2>.

### Warning when specified HTTP protocols won't be used

If TLS is disabled and HTTP/1.x is available, HTTP/2 and HTTP/3 will be disabled, even if they've been specified. This can cause some nasty surprises, so we've added warning output to let you know when it happens.

### `HTTP_PORTS` and `HTTPS_PORTS` config keys

Applications and containers are often only given a port to listen on, like 80, without additional constraints like host or path. `HTTP_PORTS` and `HTTPS_PORTS` are new config keys that allow specifying the listening ports for the Kestrel and HTTP.sys servers. These may be defined with the `DOTNET_` or `ASPNETCORE_` environment variable prefixes, or specified directly through any other config input like appsettings.json. Each is a semicolon delimited list of port values. For example:

```cli
ASPNETCORE_HTTP_PORTS=80;8080
ASPNETCORE_HTTPS_PORTS=443;8081
```

This is shorthand for the following, which specifies the scheme (HTTP or HTTPS) and any host or IP:

```cli
ASPNETCORE_URLS=http://*:80/;http://*:8080/;https://*:443/;https://*:8081/
```

For more information, see <xref:fundamentals/servers/kestrel/endpoints> and <xref:fundamentals/servers/httpsys>.

### SNI hostname in `ITlsHandshakeFeature`

The Server Name Indication (SNI) host name is now exposed in the [HostName](https://source.dot.net/#Microsoft.AspNetCore.Connections.Abstractions/Features/ITlsHandshakeFeature.cs,29) property of the <xref:Microsoft.AspNetCore.Connections.Features.ITlsHandshakeFeature> interface.

SNI is part of the TLS handshake process. It enables clients to specify the host name they want to connect to when the server hosts multiple virtual hosts or domains. The server can then select the correct security certificate to present to the client during the handshake process. Normally, SNI is only handled within the TLS stack and is used to select the matching certificate. But by exposing it, other components in the application can use that information for diagnostics, rate limiting, routing, billing, and so on.

Exposing the host name is particularly useful for large-scale services managing thousands of SNI bindings. This feature provides information about the chosen SNI during the TLS handshake, thereby improving debugging capabilities during customer escalations. This increased transparency allows for faster problem resolution and enhanced service reliability.

### IHttpSysRequestTimingFeature

[IHttpSysRequestTimingFeature](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/IHttpSysRequestTimingFeature.cs,3c5dc86dc837b1f4) provides detailed timing information for requests when using the [HTTP.sys server](xref:fundamentals/servers/httpsys) and [In-process hosting with IIS](xref:host-and-deploy/iis/in-process-hosting?view=aspnetcore-8.0&preserve-view=true#ihsrtf8):

* Timestamps are obtained using [QueryPerformanceCounter](/windows/win32/api/profileapi/nf-profileapi-queryperformancecounter).
* The timestamp frequency can be obtained via [QueryPerformanceFrequency](/windows/win32/api/profileapi/nf-profileapi-queryperformancefrequency).
* The index of the timing can be cast to [HttpSysRequestTimingType](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/HttpSysRequestTimingType.cs,e62e7bcd02f8589e) to know what the timing represents.
* The value may be 0 if the timing isn't available for the current request.

[IHttpSysRequestTimingFeature.TryGetTimestamp](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/IHttpSysRequestTimingFeature.cs,3c5dc86dc837b1f4) retrieves the timestamp for the provided timing type:

:::code language="csharp" source="~/fundamentals/request-features/samples/8.x/IHttpSysRequestTimingFeature/Program.cs" id="snippet_WithTryGetTimestamp":::

For more information, see [Get detailed timing information with IHttpSysRequestTimingFeature](xref:fundamentals/servers/httpsys?view=aspnetcore-8.0&preserve-view=true#ihsrtf8) and [Timing information and In-process hosting with IIS](xref:host-and-deploy/iis/in-process-hosting?view=aspnetcore-8.0&preserve-view=true#ihsrtf8).

### HTTP.sys: opt-in support for kernel-mode response buffering

In some scenarios, high volumes of small writes with high latency can cause significant performance impact to `HTTP.sys`. This impact is due to the lack of a <xref:System.IO.Pipelines.Pipe> buffer in the `HTTP.sys` implementation. To improve performance in these scenarios, support for response buffering has been added to `HTTP.sys`. Enable buffering by setting [HttpSysOptions.EnableKernelResponseBuffering](https://github.com/dotnet/aspnetcore/blob/main/src/Servers/HttpSys/src/HttpSysOptions.cs#L120) to `true`.

Response buffering should be enabled by an app that does synchronous I/O, or asynchronous I/O with no more than one outstanding write at a time. In these scenarios, response buffering can significantly improve throughput over high-latency connections.

Apps that use asynchronous I/O and that may have more than one write outstanding at a time should **_not_** use this flag. Enabling this flag can result in higher CPU and memory usage by HTTP.Sys.

## Authentication and authorization

ASP.NET Core 8 adds new features to authentication and authorization. 

### Authentication updates in ASP.NET Core SPA templates

The ASP.NET Core React and Angular project templates no longer have a dependency on the Duende IdentityServer. Instead, these templates now handle authentication for individual user accounts using the default [ASP.NET Core Identity](xref:security/authentication/identity) UI and cookie authentication. This makes it possible to create secure single page app (SPA) projects without the complexity of configuring and managing a full-featured OpenID Connect (OIDC) server. For projects that still require full OIDC support, use the [Duende project templates for setting up Duende IdentityServer with ASP.NET Core Identity](https://docs.duendesoftware.com/identityserver/v5/quickstarts/5_aspnetid/).

### Identity API endpoints

[MapIdentityApi\<TUser>()](https://source.dot.net/#Microsoft.AspNetCore.Identity/IdentityApiEndpointRouteBuilderExtensions.cs,32) is a new extension method that adds two API endpoints (`/register` and `/login`). The main goal of the `MapIdentityApi` is to make it easy for developers to use ASP.NET Core Identity for authentication in JavaScript-based single page apps (SPA) or Blazor apps. Instead of using the default UI provided by ASP.NET Core Identity, which is based on Razor Pages, MapIdentityApi adds JSON API endpoints that are more suitable for SPA apps and non-browser apps. For more information, see [Identity API endpoints](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/#identity-api-endpoints).

### IAuthorizationRequirementData

Prior to ASP.NET Core 8, adding a parameterized authorization policy to an endpoint required implementing an:

* `AuthorizeAttribute` for each policy.
* `AuthorizationPolicyProvider` to process a custom policy from a string-based contract.
* `AuthorizationRequirement` for the policy.
* `AuthorizationHandler` for each requirement.

For example, consider the following sample written for ASP.NET Core 7.0:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Program.cs" highlight="9":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Controllers/GreetingsController.cs" :::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="7,19":::

The complete sample is [here](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/OldStyleAuthRequirements) in the [AspNetCore.Docs.Samples](https://github.com/dotnet/AspNetCore.Docs.Samples) repository.

ASP.NET Core 8 introduces the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> interface. The `IAuthorizationRequirementData` interface allows the attribute definition to specify the requirements associated with the authorization policy. Using `IAuthorizationRequirementData`, the preceding custom authorization policy code can be written with fewer lines of code. The updated `Program.cs` file:

```diff
  using AuthRequirementsData.Authorization;
  using Microsoft.AspNetCore.Authorization;
  
  var builder = WebApplication.CreateBuilder();
  
  builder.Services.AddAuthentication().AddJwtBearer();
  builder.Services.AddAuthorization();
  builder.Services.AddControllers();
- builder.Services.AddSingleton<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();
  builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeAuthorizationHandler>();
  
  var app = builder.Build();
  
  app.MapControllers();
  
  app.Run();
```

The updated `MinimumAgeAuthorizationHandler`:

```diff
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.Security.Claims;

namespace AuthRequirementsData.Authorization;

- class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequirement>
+ class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeAuthorizeAttribute>
{
    private readonly ILogger<MinimumAgeAuthorizationHandler> _logger;

    public MinimumAgeAuthorizationHandler(ILogger<MinimumAgeAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    // Check whether a given MinimumAgeRequirement is satisfied or not for a particular
    // context
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
-                                              MinimumAgeRequirement requirement)
+                                              MinimumAgeAuthorizeAttribute requirement)
    {
        // Remaining code omitted for brevity.
```

The complete updated sample can be found [here](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData).

See <xref:security/authorization/iard> for a detailed examination of the new sample.

## Miscellaneous

The following sections describe miscellaneous new features in ASP.NET Core 8.

### Support for generic attributes

Attributes that previously required a <xref:System.Type> parameter are now available in cleaner generic variants. This is made possible by support for [generic attributes](/dotnet/csharp/whats-new/csharp-11) in C# 11. For example, the syntax for annotating the response type of an action can be modified as follows:

```diff
[ApiController]
[Route("api/[controller]")]
public class TodosController : Controller
{
  [HttpGet("/")]
- [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
+ [ProducesResponseType<Todo>(StatusCodes.Status200OK)]
  public Todo Get() => new Todo(1, "Write a sample", DateTime.Now, false);
}
```

Generic variants are supported for the following attributes:

<!--TODO update these API links -->

* `[ProducesResponseType<T>]`
* `[Produces<T>]`
* `[MiddlewareFilter<T>]`
* `[ModelBinder<T>]`
* `[ModelMetadataType<T>]`
* `[ServiceFilter<T>]`
* `[TypeFilter<T>]`

<!--Note: All the topics that use the preceding attributes have been updated to use the generic -->

### Code analysis in ASP.NET Core apps

The new analyzers shown in the following table are available in ASP.NET Core 8.0.

| Diagnostic ID | Breaking or non-breaking | Description |
| --- | --- | --- |
| [ASP0016](xref:diagnostics/asp0016) | Non-breaking | Do not return a value from RequestDelegate |
| [ASP0019](xref:diagnostics/asp0019) | Non-breaking | Suggest using IHeaderDictionary.Append or the indexer |
| [ASP0020](xref:diagnostics/asp0020) | Non-breaking | Complex types referenced by route parameters must be parsable |
| [ASP0021](xref:diagnostics/asp0021) | Non-breaking | The return type of the BindAsync method must be `ValueTask<T>` |
| [ASP0022](xref:diagnostics/asp0022) | Non-breaking | Route conflict detected between route handlers |
| [ASP0023](xref:diagnostics/asp0023) | Non-breaking | MVC: Route conflict detected between route handlers |
| [ASP0024](xref:diagnostics/asp0024) | Non-breaking | Route handler has multiple parameters with the `[FromBody]` attribute |
| [ASP0025](xref:diagnostics/asp0025) | Non-breaking | Use AddAuthorizationBuilder |

### Route tooling

ASP.NET Core is built on routing. Minimal APIs, Web APIs, Razor Pages, and Blazor all use routes to customize how HTTP requests map to code.

In .NET 8 we've invested in a suite of new features to make routing easier to learn and use. These new features include:

* [Route syntax highlighting](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#route-syntax-highlighting)
* [Autocomplete of parameter and route names](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#autocomplete-of-parameter-and-route-names)
* [Autocomplete of route constraints](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#autocomplete-of-route-constraints)
* [Route analyzers and fixers](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#route-analyzers-and-fixers)
  * [Route syntax analyzer](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#route-syntax-analyzer)
  * [Mismatched parameter optionality analyzer and fixer](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#mismatched-parameter-optionality-analyzer-and-fixer)
  * [Ambiguous Minimal API and Web API route analyzer](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#ambiguous-minimal-api-and-web-api-route-analyzer)
* [Support for Minimal APIs, Web APIs, and Blazor](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#supports-minimal-apis-web-apis-and-blazor)

For more information, see [Route tooling in .NET 8](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/).

### ASP.NET Core metrics

Metrics are measurements reported over time and are most often used to monitor the health of an app and to generate alerts. For example, a counter that reports failed HTTP requests could be displayed in dashboards or generate alerts when failures pass a threshold.

This preview adds new metrics throughout ASP.NET Core using <xref:System.Diagnostics.Metrics>. `Metrics` is a modern API for reporting and collecting information about apps.

Metrics offers a number of improvements compared to existing event counters:

* New kinds of measurements with counters, gauges and histograms.
* Powerful reporting with multi-dimensional values.
* Integration into the wider cloud native ecosystem by aligning with OpenTelemetry standards.

Metrics have been added for ASP.NET Core hosting, Kestrel, and SignalR. For more information, see [System.Diagnostics.Metrics](/dotnet/core/diagnostics/compare-metric-apis#systemdiagnosticsmetrics).

### IExceptionHandler

[IExceptionHandler](https://source.dot.net/#Microsoft.AspNetCore.Diagnostics/ExceptionHandler/IExceptionHandler.cs,adae2915ad0c6dc5) is a new interface that gives the developer a callback for handling known exceptions in a central location.

`IExceptionHandler` implementations are registered by calling [`IServiceCollection.AddExceptionHandler<T>`](https://source.dot.net/#Microsoft.AspNetCore.Diagnostics/ExceptionHandler/ExceptionHandlerServiceCollectionExtensions.cs,e74aac24e3e2cbc9). Multiple implementations can be added, and they're called in the order registered. If an exception handler handles a request, it can return `true` to stop processing. If an exception isn't handled by any exception handler, then control falls back to the default behavior and options from the middleware.

For more information, see [IExceptionHandler](xref:fundamentals/error-handling#iexceptionhandler).

<!--
## API controllers

## gRPC
-->
