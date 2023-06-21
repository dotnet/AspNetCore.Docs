---
title: What's new in ASP.NET Core 8.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 8.0.
ms.author: riande
ms.custom: mvc
ms.date: 06/05/2023
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
<!--
* [What's new in .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-5/)
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

### Binding to forms

Explicit binding to form values using the [[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) attribute is now supported. Inferred binding to forms using the <xref:Microsoft.AspNetCore.Http.IFormCollection>, <xref:Microsoft.AspNetCore.Http.IFormFile>, and <xref:Microsoft.AspNetCore.Http.IFormFileCollection> types is also supported. [OpenAPI](xref:fundamentals/minimal-apis/openapi) metadata is inferred for form parameters to support integration with [Swagger UI](xref:tutorials/web-api-help-pages-using-swagger).

For more information, see:

* [Explicit binding from form values](xref:fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0&preserve-view=true#explicit-binding-from-form-values).
* [Binding to forms with IFormCollection, IFormFile, and IFormFileCollection](xref:fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0&preserve-view=true#binding-to-forms-with-iformcollection-iformfile-and-iformfilecollection).

## Support for native AOT

Support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/) has been added. Apps that are published using AOT can have substantially better performance: smaller app size, less memory usage, and faster startup time. Native AOT is currently supported by gRPC, minimal API, and worker service apps. For more information, see [ASP.NET Core support for native AOT](xref:fundamentals/native-aot).

### New project template

The new **ASP.NET Core API** template in Visual Studio 2022 has an **Enable native AOT publish** option. The equivalent template and option in the CLI is the `dotnet new api` command and the `--aot` option. This template is intended to produce a project focused on cloud-native, API-first scenarios. For more information, see [The API template](xref:fundamentals/native-aot#the-api-template).

### New CreateSlimBuilder method

The <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> method used in the API template initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimum ASP.NET Core features necessary to run an app. It's used by the API template whether or not the AOT option is used. For more information, see [The `CreateSlimBuilder` method](xref:fundamentals/native-aot#the-createslimbuilder-method).

### JSON serialization of compiler-generated `IAsyncEnumerable<T>` types

New features were added to <xref:System.Text.Json> to better support native AOT. These new features add capabilities for the source generation mode of `System.Text.Json`, because reflection isn't supported by AOT.

One of the new features is support for JSON serialization of <xref:System.Collections.Generic.IAsyncEnumerable%601> implementations implemented by the C# compiler. This support opens up their use in ASP.NET Core projects configured to publish native AOT.

This API is useful in scenarios where a route handler uses `yield return` to asynchronously return an enumeration. For example, to materialize rows from a database query. For more information, see [Unspeakable type support](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/#unspeakable-type-support) in the .NET 8 Preview 4 announcement.

For information abut other improvements in `System.Text.Json` source generation, see [Serialization improvements in .NET 8](/dotnet/core/whats-new/dotnet-8#serialization).

### Top-level APIs annotated for trim warnings

The main entry points to subsystems that don't work reliably with native AOT are now annotated. When these methods are called from an application with native AOT enabled, a warning is provided. For example, the following code produces a warning at the invocation of `AddControllers` because this API is not trim-safe and isn't supported by native AOT.

:::image type="content" source="../fundamentals/aot/_static/top-level-annnotations.png" alt-text="Visual Studio window showing IL2026 warning message on the AddControllers method that says MVC does not currently support native AOT.":::

## Miscellaneous

### HTTP/3 enabled by default

HTTP/3 is a new internet technology that was standardized in June 2022. HTTP/3 offers several advantages over older HTTP protocols, including:

* Faster connection setup.
* No head-of-line blocking.
* Better transitions between networks.

.NET 7 added support for HTTP/3 to ASP.NET Core and Kestrel. ASP.NET Core apps could choose to turn it on. In .NET 8, HTTP/3 is enabled by default for Kestrel, alongside HTTP/1.1 and HTTP/2. For more information about HTTP/3 and its requirements, see <xref:fundamentals/servers/kestrel/http3>.

### HTTP/2 over TLS (HTTPS) support on macOS

.NET 8 adds support for Application-Layer Protocol Negotiation (ALPN) to macOS. ALPN is a TLS feature used to negotiate which HTTP protocol a connection will use. For example, ALPN allows browsers and other HTTP clients to request an HTTP/2 connection. This feature is especially useful for gRPC apps, which require HTTP/2. For more information, see <xref:fundamentals/servers/kestrel/http2>.

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

<!--Note: All the topics that use the preceeding atributes have been updated to use the generic -->

### Code analysis in ASP.NET Core apps

The new analyzers shown in the following table are available in ASP.NET Core 8.0.

| Diagnostic ID | Breaking or non-breaking | Description |
| --- | --- | --- |
| [ASP0020](xref:diagnostics/asp0020) | Non-breaking | Complex types referenced by route parameters must be parsable |
| [ASP0021](xref:diagnostics/asp0021) | Non-breaking | The return type of the BindAsync method must be `ValueTask<T>` |
| [ASP0022](xref:diagnostics/asp0022) | Non-breaking | Route conflict detected between route handlers |
| [ASP0023](xref:diagnostics/asp0023) | Non-breaking | MVC: Route conflict detected between route handlers |
| [ASP0024](xref:diagnostics/asp0024) | Non-breaking | Route handler has multiple parameters with the `[FromBody]` attribute |
| [ASP0025](xref:diagnostics/asp0025) | Non-breaking | Use AddAuthorizationBuilder |

### IAuthorizationRequirementData

Prior to this preview, adding a parameterized authorization policy to an endpoint required implementing an:

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

<!--
## API controllers

## gRPC
-->
