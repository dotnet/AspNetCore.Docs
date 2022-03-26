---
title: What's new in ASP.NET Core 5.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 5.0.
ms.author: riande
ms.custom: mvc
ms.date: 10/29/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, Kestrel]
uid: aspnetcore-5.0
---
# What's new in ASP.NET Core 5.0

This article highlights the most significant changes in ASP.NET Core 5.0 with links to relevant documentation.

## ASP.NET Core MVC and Razor improvements

### Model binding DateTime as UTC

Model binding now supports binding UTC time strings to `DateTime`. If the request contains a UTC time string, model binding binds it to a UTC `DateTime`. For example, the following time string is bound the UTC `DateTime`: `https://example.com/mycontroller/myaction?time=2019-06-14T02%3A30%3A04.0576719Z`

### Model binding and validation with C# 9 record types

[C# 9 record types](/dotnet/csharp/whats-new/csharp-9#record-types) can be used with model binding in an MVC controller or a Razor Page. Record types are a good way to model data being transmitted over the network.

For example, the following `PersonController` uses the `Person` record type with model binding and form validation:

```csharp
public record Person([Required] string Name, [Range(0, 150)] int Age);

public class PersonController
{
   public IActionResult Index() => View();

   [HttpPost]
   public IActionResult Index(Person person)
   {
          // ...
   }
}
```

The `Person/Index.cshtml` file:

```cshtml
@model Person

Name: <input asp-for="Model.Name" />
<span asp-validation-for="Model.Name" />

Age: <input asp-for="Model.Age" />
<span asp-validation-for="Model.Age" />
```

### Improvements to DynamicRouteValueTransformer

ASP.NET Core 3.1 introduced <xref:Microsoft.AspNetCore.Mvc.Routing.DynamicRouteValueTransformer> as a way to use custom endpoint to dynamically select an MVC controller action or a Razor page. ASP.NET Core 5.0 apps can pass state to a `DynamicRouteValueTransformer` and filter the set of endpoints chosen.

### Miscellaneous

* The [[Compare]](xref:System.ComponentModel.DataAnnotations.CompareAttribute) attribute can be applied to properties on a Razor Page model.
* Parameters and properties bound from the body are considered required by default. <!-- Review: How is this different from 3.1
The validation system in .NET Core 3.0 and later treats non-nullable parameters or bound properties as if they had a [Required] attribute.
see https://docs.microsoft.com/aspnet/core/mvc/models/validation?view=aspnetcore-3.1   
-->

## Web API

### OpenAPI Specification on by default

[OpenAPI Specification](http://spec.openapis.org/oas/v3.0.3) is an industry standard for describing HTTP APIs and integrating them into complex business processes or with third parties. OpenAPI is widely supported by all cloud providers and many API registries. Apps that emit OpenAPI documents from web APIs have a variety of new opportunities in which those APIs can be used. In partnership with the maintainers of the open-source project [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/), the ASP.NET Core API template contains a NuGet dependency on [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore). Swashbuckle is a popular open-source NuGet package that emits OpenAPI documents dynamically. Swashbuckle does this by introspecting over the API controllers and generating the OpenAPI document at run-time, or at build time using the Swashbuckle CLI.

In ASP.NET Core 5.0, the web API templates enable the OpenAPI support by default. To disable OpenAPI:

* From the command line:

	```dotnetcli
	dotnet new webapi --no-openapi true
	```
* From Visual Studio: Uncheck **Enable OpenAPI support**.

All `.csproj` files created for web API projects contain the [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) NuGet package reference.

```xml
<ItemGroup>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="5.5.1" />
</ItemGroup>
```

The template generated code contains code in `Startup.ConfigureServices` that activates OpenAPI document generation:

[!code-csharp[](~/release-notes/sample/StartupSwagger.cs?name=snippet)]

The `Startup.Configure` method adds the Swashbuckle middleware, which enables the:

* Document generation process.
* Swagger UI page by default in development mode.

The template generated code won't accidentally expose the API's description when publishing to production.

[!code-csharp[](~/release-notes/sample/StartupSwagger.cs?name=snippet2)]

#### Azure API Management Import

When ASP.NET Core API projects enable OpenAPI, the Visual Studio 2019 version 16.8 and later publishing automatically offer an additional step in the publishing flow. Developers who use [Azure API Management](xref:tutorials/publish-to-azure-api-management-using-vs) have an opportunity to automatically import the APIs into Azure API Management during the publish flow:

![Azure API Management Import VS publishing](~/release-notes/static/publish-to-apim.png)

### Better launch experience for web API projects

With OpenAPI enabled by default, the app launching experience (F5) for web API developers significantly improves. With ASP.NET Core 5.0, the web API template comes pre-configured to load up the Swagger UI page. The Swagger UI page provides both the documentation added for the published API, and enables testing the APIs with a single click.

![swagger/index.html view](~/release-notes/static/swagger-ui-page-rc1.png)

## Blazor

### Performance improvements

For .NET 5, we made significant improvements to Blazor WebAssembly runtime performance with a specific focus on complex UI rendering and JSON serialization. In our performance tests, Blazor WebAssembly in .NET 5 is two to three times faster for most scenarios. For more information, see [ASP.NET Blog: ASP.NET Core updates in .NET 5 Release Candidate 1](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-5-release-candidate-1/#blazor-webassembly-performance-improvements).

### CSS isolation

Blazor now supports defining CSS styles that are scoped to a given component. Component-specific CSS styles make it easier to reason about the styles in an app and to avoid unintentional side effects of global styles. For more information, see <xref:blazor/components/css-isolation>.

### New `InputFile` component

The `InputFile` component allows reading one or more files selected by a user for upload. For more information, see <xref:blazor/file-uploads>.

### New `InputRadio` and `InputRadioGroup` components

Blazor has built-in `InputRadio` and `InputRadioGroup` components that simplify data binding to radio button groups with integrated validation. For more information, see <xref:blazor/forms-validation>.

### Component virtualization

Improve the perceived performance of component rendering using the Blazor framework's built-in virtualization support. For more information, see <xref:blazor/components/virtualization>.

### `ontoggle` event support

Blazor events now support the `ontoggle` DOM event. For more information, see <xref:blazor/components/event-handling#event-arguments>.

### Set UI focus in Blazor apps

Use the `FocusAsync` convenience method on element references to set the UI focus to that element. For more information, see <xref:blazor/components/event-handling#focus-an-element>.

### Custom validation CSS class attributes

Custom validation CSS class attributes are useful when integrating with CSS frameworks, such as Bootstrap. For more information, see <xref:blazor/forms-validation#custom-validation-css-class-attributes>.

### IAsyncDisposable support

Razor components now support the <xref:System.IAsyncDisposable> interface for the asynchronous release of allocated resources.

### JavaScript isolation and object references

Blazor enables JavaScript isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules). For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

### Form components support display name

The following built-in components support display names with the `DisplayName` parameter:

* `InputDate`
* `InputNumber`
* `InputSelect`

For more information, see <xref:blazor/forms-validation#display-name-support>.

### Catch-all route parameters

Catch-all route parameters, which capture paths across multiple folder boundaries, are supported in components. For more information, see <xref:blazor/fundamentals/routing#catch-all-route-parameters>.

### Debugging improvements

Debugging Blazor WebAssembly apps is improved in ASP.NET Core 5.0. Additionally, debugging is now supported on Visual Studio for Mac. For more information, see <xref:blazor/debug>.

### Microsoft Identity v2.0 and MSAL v2.0

Blazor security now uses Microsoft Identity v2.0 ([`Microsoft.Identity.Web`](https://www.nuget.org/packages/Microsoft.Identity.Web) and [`Microsoft.Identity.Web.UI`](https://www.nuget.org/packages/Microsoft.Identity.Web.UI)) and MSAL v2.0. For more information, see the topics in the [Blazor Security and Identity node](xref:blazor/security/index).

### Protected Browser Storage for Blazor Server

Blazor Server apps can now use built-in support for storing app state in the browser that has been protected from tampering using ASP.NET Core data protection. Data can be stored in either local browser storage or session storage. For more information, see <xref:blazor/state-management>.

### Blazor WebAssembly prerendering

Component integration is improved across hosting models, and Blazor WebAssembly apps can now prerender output on the server. <!-- UNCOMMENT AFTER https://github.com/dotnet/AspNetCore.Docs/pull/19887 MERGES: For more information, see <xref:blazor/components/integrate-components-into-razor-pages-and-mvc-apps> and <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>. -->

### Trimming/linking improvements

Blazor WebAssembly performs Intermediate Language (IL) trimming/linking during a build to trim unnecessary IL from the app's output assemblies. With the release of ASP.NET Core 5.0, Blazor WebAssembly performs improved trimming with additional configuration options. For more information, see <xref:blazor/host-and-deploy/configure-trimmer> and [Trimming options](/dotnet/core/deploying/trimming-options).

### Browser compatibility analyzer

Blazor WebAssembly apps target the full .NET API surface area, but not all .NET APIs are supported on WebAssembly due to browser sandbox constraints. Unsupported APIs throw <xref:System.PlatformNotSupportedException> when running on WebAssembly. A platform compatibility analyzer warns the developer when the app uses APIs that aren't supported by the app's target platforms. For more information, see <xref:blazor/components/class-libraries#browser-compatibility-analyzer-for-blazor-webassembly>.

### Lazy load assemblies

Blazor WebAssembly app startup performance can be improved by deferring the loading of some application assemblies until they're required. For more information, see <xref:blazor/webassembly-lazy-load-assemblies>.

### Updated globalization support

Globalization support is available for Blazor WebAssembly based on International Components for Unicode (ICU). For more information, see <xref:blazor/globalization-localization>.

## gRPC

Many preformance improvements have been made in [gRPC](https://grpc.io/). For more information, see [gRPC performance improvements in .NET 5](https://devblogs.microsoft.com/aspnet/grpc-performance-improvements-in-net-5/).

For more gRPC information, see <xref:grpc/index>.

## SignalR

### SignalR Hub filters

SignalR Hub filters, called Hub pipelines in ASP.NET SignalR, is a feature that allows code to run before and after Hub methods are called. Running code before and after Hub methods are called is similar to how middleware has the ability to run code before and after an HTTP request. Common uses include logging, error handling, and argument validation.

For more information, see [Use hub filters in ASP.NET Core SignalR](xref:signalr/hub-filters).

### SignalR parallel hub invocations

ASP.NET Core SignalR is now capable of handling parallel hub invocations. The default behavior can be changed to allow clients to invoke more than one hub method at a time:

[!code-csharp[](~/release-notes/sample/StartupSignalRhubs.cs?name=snippet)]

### Added Messagepack support in SignalR Java client

A new package, [com.microsoft.signalr.messagepack](https://mvnrepository.com/artifact/com.microsoft.signalr.messagepack), adds MessagePack support to the SignalR Java client. To use the MessagePack hub protocol, add `.withHubProtocol(new MessagePackHubProtocol())` to the connection builder:

```java
HubConnection hubConnection = HubConnectionBuilder.create(
                           "http://localhost:53353/MyHub")
               .withHubProtocol(new MessagePackHubProtocol())
               .build();
```

<!--
See [Update SignalR code](xref:migration/31-to-50#signalr) for migration instructions.
-->

## Kestrel

* Reloadable endpoints via configuration: Kestrel can detect changes to configuration passed to [KestrelServerOptions.Configure](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure%2A) and unbind from existing endpoints and bind to new endpoints without requiring an application restart when the `reloadOnChange` parameter is `true`. By default when using <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> or <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A>, Kestrel binds to the ["Kestrel"](https://github.com/dotnet/aspnetcore/blob/7e9e03b70124784b1de5564c573bd65cdaccbfcc/src/DefaultBuilder/src/WebHost.cs#L226) configuration subsection with `reloadOnChange` enabled. Apps must pass `reloadOnChange: true` when calling `KestrelServerOptions.Configure` manually to get reloadable endpoints.
* HTTP/2 response headers improvements. For more information, see [Performance improvements](#performance-improvements) in the next section.
* Support for additional endpoints types in the sockets transport: Adding to the new API introduced in <xref:System.Net.Sockets?displayProperty=nameWithType>, the sockets default transport in [Kestrel](xref:fundamentals/servers/kestrel) allows binding to both existing file handles and Unix domain sockets. Support for binding to existing file handles enables using the existing `Systemd` integration without requiring the `libuv` transport.
* Custom header decoding in Kestrel: Apps can specify which <xref:System.Text.Encoding> to use to interpret incoming headers based on the header name instead of defaulting to UTF-8. Set the <!--<xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.RequestHeaderEncodingSelector> --> `Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.RequestHeaderEncodingSelector` property to specify which encoding to use:
 
  ```csharp
  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                options.RequestHeaderEncodingSelector = encoding =>
                {
                      return encoding switch
                      {
                          "Host" => System.Text.Encoding.Latin1,
                          _ => System.Text.Encoding.UTF8,
                      };
                };
            });
            webBuilder.UseStartup<Startup>();
        });
  ```

### Kestrel endpoint-specific options via configuration

Support has been added for configuring Kestrel’s endpoint-specific options via [configuration](xref:fundamentals/configuration/index). The endpoint-specific configurations includes the:

* HTTP protocols used
* TLS protocols used
* Certificate selected
* Client certificate mode

Configuration allows specifying which certificate is selected based on the specified server name. The server name is part of the Server Name Indication (SNI) extension to the TLS protocol as indicated by the client. Kestrel's configuration also supports a wildcard prefix in the host name.

The following example shows how to specify endpoint-specific using a configuration file:

```json
{
  "Kestrel": {
    "Endpoints": {
      "EndpointName": {
        "Url": "https://*",
        "Sni": {
          "a.example.org": {
            "Protocols": "Http1AndHttp2",
            "SslProtocols": [ "Tls11", "Tls12"],
            "Certificate": {
              "Path": "testCert.pfx",
              "Password": "testPassword"
            },
            "ClientCertificateMode" : "NoCertificate"
          },
          "*.example.org": {
            "Certificate": {
              "Path": "testCert2.pfx",
              "Password": "testPassword"
            }
          },
          "*": {
            // At least one sub-property needs to exist per
            // SNI section or it cannot be discovered via
            // IConfiguration
            "Protocols": "Http1",
          }
        }
      }
    }
  }
}
```

Server Name Indication (SNI) is a TLS extension to include a virtual domain as a part of SSL negotiation. What this effectively means is that the virtual domain name, or a hostname, can be used to identify the network end point.

## Performance improvements

### HTTP/2

* Significant reductions in allocations in the HTTP/2 code path.
* Support for [HPack dynamic compression](https://tools.ietf.org/html/rfc7541) of HTTP/2 response headers in [Kestrel](xref:fundamentals/servers/kestrel). For more information, see [Header table size](xref:fundamentals/servers/kestrel/options#header-table-size) and [HPACK: the silent killer (feature) of HTTP/2](https://blog.cloudflare.com/hpack-the-silent-killer-feature-of-http-2/).
* Sending HTTP/2 PING frames: HTTP/2 has a mechanism for sending PING frames to ensure an idle connection is still functional. Ensuring a viable connection is especially useful when working with long-lived streams that are often idle but only intermittently see activity, for example, gRPC streams. Apps can send periodic PING frames in [Kestrel](xref:fundamentals/servers/kestrel) by setting limits on 
<xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions>:

   ```csharp
   public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                options.Limits.Http2.KeepAlivePingInterval =
                                               TimeSpan.FromSeconds(10);
                options.Limits.Http2.KeepAlivePingTimeout =
                                               TimeSpan.FromSeconds(1);
            });
            webBuilder.UseStartup<Startup>();
        });
   ```
   <!-- review: KeepAlivePingInterval not found in RC1. Try testing with RC1. See https://github.com/dotnet/aspnetcore/pull/22565/files see C:/Users/riande/source/repos/WebApplication128/WebApplication128 -->

### Containers

Prior to .NET 5.0, building and publishing a *Dockerfile* for an ASP.NET Core app required pulling the entire .NET Core SDK and the ASP.NET Core image. With this release, pulling the SDK images bytes is reduced and the bytes pulled for the ASP.NET Core image is largely eliminated. For more information, see [this GitHub issue comment](https://github.com/dotnet/dotnet-docker/issues/1814#issuecomment-625294750).

## Authentication and authorization

### Azure Active Directory authentication with Microsoft.Identity.Web

The ASP.NET Core project templates now integrate with <xref:Microsoft.Identity.Web?displayProperty=fullName> to handle authentication with [Azure Active Directory](/azure/active-directory/fundamentals/active-directory-whatis) (Azure AD). The [Microsoft.Identity.Web package](https://www.nuget.org/packages/Microsoft.Identity.Web/) provides:

* A better experience for authentication through Azure AD.
* An easier way to access Azure resources on behalf of your users, including [Microsoft Graph](/graph/overview). See the [Microsoft.Identity.Web sample](https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2), which starts with a basic login and advances through multi-tenancy, using Azure APIs, using Microsoft Graph, and protecting your own APIs. `Microsoft.Identity.Web` is available alongside .NET 5.

### Allow anonymous access to an endpoint

The `AllowAnonymous` extension method allows anonymous access to an endpoint:

[!code-csharp[](~/release-notes/sample/StartupAnonEndpoint.cs?name=snippet)]

### Custom handling of authorization failures

Custom handling of authorization failures is now easier with the new [IAuthorizationMiddlewareResultHandler](https://github.com/dotnet/aspnetcore/blob/v5.0.0-rc.1.20451.17/src/Security/Authorization/Policy/src/IAuthorizationMiddlewareResultHandler.cs) interface that is invoked by the [authorization](xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A) [Middleware](xref:fundamentals/middleware/index). The default implementation remains the same, but a custom handler can be registered in [Dependency injection, which allows custom HTTP responses based on why authorization failed. See [this sample](https://github.com/dotnet/aspnetcore/blob/main/src/Security/samples/CustomAuthorizationFailureResponse/Authorization/SampleAuthorizationMiddlewareResultHandler.cs) that demonstrates usage of the `IAuthorizationMiddlewareResultHandler`.

### Authorization when using endpoint routing

Authorization when using endpoint routing now receives the `HttpContext` rather than the endpoint instance. This allows the authorization middleware to access the `RouteData` and other properties of the `HttpContext` that were not accessible though the <xref:Microsoft.AspNetCore.Http.Endpoint> class. The endpoint can be fetched from the context using [context.GetEndpoint](xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A).

### Role-based access control with Kerberos authentication and LDAP on Linux

See [Kerberos authentication and role-based access control (RBAC)](xref:security/authentication/windowsauth#rbac)

## API improvements

### JSON extension methods for HttpRequest and HttpResponse

JSON data can be read and written to from an `HttpRequest` and `HttpResponse` using the new <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> and `WriteAsJsonAsync` extension methods. These extension methods use the [System.Text.Json](xref:System.Text.Json) serializer to handle the JSON data. The new `HasJsonContentType` extension method can also check if a request has a JSON content type.

The JSON extension methods can be combined with [endpoint routing](xref:fundamentals/routing) to create JSON APIs in a style of programming we call ***route to code***. It is a new option for developers who want to create basic JSON APIs in a lightweight way. For example, a web app that has only a handful of endpoints might choose to use route to code rather than the full functionality of ASP.NET Core MVC:

```csharp
endpoints.MapGet("/weather/{city:alpha}", async context =>
{
    var city = (string)context.Request.RouteValues["city"];
    var weather = GetFromDatabase(city);

    await context.Response.WriteAsJsonAsync(weather);
});
```

### System.Diagnostics.Activity

The default format for <xref:System.Diagnostics.Activity?displayProperty=fullName> now defaults to the W3C format. This makes distributed tracing support in ASP.NET Core interoperable with more frameworks by default.

### FromBodyAttribute

<xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute> now supports configuring an option that allows these parameters or properties to be considered optional:

```csharp
public IActionResult Post([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)]
                          MyModel model)
{
    ...
}
```

## Miscellaneous improvements

We’ve started applying [nullable annotations](/dotnet/csharp/nullable-references#attributes-describe-apis) to ASP.NET Core assemblies. We plan to annotate most of the common public API surface of the .NET 5 framework. <!-- Review: what's the impact of this? How does it work? Need more info.  Check the link I added -->

### Control Startup class activation

An additional <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseStartup%2A> overload has been added that lets an app provide a factory method for controlling `Startup` class activation. Controlling `Startup` class activation is useful to pass additional parameters to `Startup` that are initialized along with the host:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var logger = CreateLogger();
        var host = Host.CreateDefaultBuilder()
            .ConfigureWebHost(builder =>
            {
                builder.UseStartup(context => new Startup(logger));
            })
            .Build();

        await host.RunAsync();
    }
}
```

### Auto refresh with dotnet watch

In .NET 5, running [dotnet watch](xref:tutorials/dotnet-watch) on an ASP.NET Core project both launches the default browser and auto refreshes the browser as changes are made to the code. This means you can:

* Open an ASP.NET Core project in a text editor.
* Run `dotnet watch`.
* Focus on the code changes while the tooling handles rebuilding, restarting, and reloading the app.

### Console Logger Formatter

Improvements have been made to the console log provider in the `Microsoft.Extensions.Logging` library. Developers can now implement a custom `ConsoleFormatter` to exercise complete control over formatting and colorization of the console output. The formatter APIs allow for rich formatting by implementing a subset of the VT-100 escape sequences. VT-100 is supported by most modern terminals. The console logger can parse out escape sequences on unsupported terminals allowing developers to author a single formatter for all terminals.

### JSON Console Logger

In addition to support for custom formatters, we’ve also added a built-in JSON formatter that emits structured JSON logs to the console. The following code shows how to switch from the default logger to JSON:

[!code-csharp[](~/release-notes/sample/ProgramJsonLog.cs?name=snippet)]

Log messages emitted to the console are JSON formatted:

```json
{
  "EventId": 0,
  "LogLevel": "Information",
  "Category": "Microsoft.Hosting.Lifetime",
  "Message": "Now listening on: https://localhost:5001",
  "State": {
    "Message": "Now listening on: https://localhost:5001",
    "address": "https://localhost:5001",
    "{OriginalFormat}": "Now listening on: {address}"
  }
}
```
