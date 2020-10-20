---
title: What's new in ASP.NET Core 5.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 5.0.
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: aspnetcore-5.0
---
# What's new in ASP.NET Core 5.0

https://docs.microsoft.com/en-us

This article highlights the most significant changes in ASP.NET Core 5.0 with links to relevant documentation.

## Blazor

### CSS isolation for Blazor components

Blazor now supports defining CSS styles that are scoped to a given component. Component specific CSS styles make it easier to reason about the styles in an app and to avoid unintentional side effects from global styles. Component specific styles are defined in a *.razor.css* file that matches the name of the *.razor* file for the component.

For example, consider the following component *MyComponent.razor* file:

```html
<h1>My Component</h1>

<ul class="cool-list">
    <li>Item1</li>
    <li>Item2</li>
</ul>
```

A *MyComponent.razor.css* can be defined with the styles for `MyComponent`:

```html
h1 {
    font-family: 'Comic Sans MS'
}

.cool-list li {
    color: red;
}
```

The styles in *MyComponent.razor.css* are only get applied to the rendered output of `MyComponent`. The `h1` elements rendered by other components, for example, aren't affected.

To write a selector in component specific styles that affects child components, use the `::deep` combinator:

```
.parent ::deep .child {
    color: red;
}
```

By using the `::deep` combinator, only the *.parent* class selector is scoped to the component. The *.child* class selector isn't scoped, and matches content from child components.

Blazor achieves CSS isolation by rewriting the CSS selectors as part of the build so that they only match markup rendered by the component. Blazor then bundles together the rewritten CSS files and makes the bundle available to the app as a static web asset at the path *_framework/scoped.styles.css*.

While Blazor doesn’t natively support CSS preprocessors like Sass or Less, CSS preprocessors can be used to generate component specific styles before they are rewritten as part of the building the project.

### New InputRadio Blazor component

Blazor in .NET 5 now includes built-in `InputRadio` and `InputRadioGroup` components. These components simplify data binding to radio button groups with integrated validation alongside the other Blazor form input components.

Opinion about blazor:

```
<InputRadioGroup @bind-Value="survey.OpinionAboutBlazor">
    @foreach (var opinion in opinions)
    {
        <div class="form-check">
            <InputRadio class="form-check-input" id="@opinion.id" Value="@opinion.id" />
            <label class="form-check-label" for="@opinion.id">@opinion.label</label>
        </div>
    }
</InputRadioGroup>
```

### Set UI focus in Blazor apps

Blazor now has a `FocusAsync` convenience method on Elem`entReference for setting the UI focus on that element.

```html
<button @onclick="() => textInput.FocusAsync()">Set focus</button>
<input @ref="textInput"/>
```

### IAsyncDisposable support for Blazor components

Blazor components now support the <xref:System.IAsyncDisposable> interface for the asynchronous release of allocated resources.

### Control Blazor component instantiation

You can control how Blazor components are instantiated by providing an `IComponentActivator` service implementation.

### Influencing the HTML head in Blazor apps

Use the new `Title`, `Link`, and `Meta` components to programmatically set the title of a page and dynamically add links and meta tags to the HTML head in a Blazor app.

To use the new `Title`, `Link`, and `Meta` components:

1. Add a package reference to the [Microsoft.AspNetCore.Components.Web.Extensions NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web.Extensions/).
1. Include a script reference to *_content/Microsoft.AspNetCore.Components.Web.Extensions/headManager.js*.
1. Add a `@using` directive for `Microsoft.AspNetCore.Components.Web.Extensions.Head`.

The following example programmatically sets the page title to show the number of unread user notifications and updates the page icon:

```
@if (unreadNotificationsCount > 0)
{
    var title = $"Notifications ({unreadNotificationsCount})";
    <Title Value="title"></Title>
    <Link rel="icon" href="icon-unread.ico" />
}
```

### Blazor Server

#### Protected browser storage

In Blazor Server apps, you may want to persist app state in local or session storage so that the app can rehydrate it later if needed. When storing app state in the user’s browser, you also need to ensure that it hasn’t been tampered with.

Blazor in .NET 5 helps solve this problem by providing two new services: `ProtectedLocalStorage` and `ProtectedSessionStorage`. These services help you store state in local and session storage respectively, and they take care of protecting the stored data using the ASP.NET Core data protection APIs.

To use the new protected browser storage services:

1. Add a package reference to Microsoft.AspNetCore.Components.Web.Extensions.
1. Configure the services by calling services.AddProtectedBrowserStorage() from Startup.ConfigureServcies.
1. Inject either ProtectedLocalStorage and ProtectedSessionStorage into your component implementation:
  ```
    @inject ProtectedLocalStorage ProtectedLocalStorage
    @inject ProtectedSessionStorage ProtectedSessionStorage
  ```
1. Use the desired service to get, set, and delete state asynchronously:
  ```
    private async Task IncrementCount()
    {
        await ProtectedLocalStorage.SetAsync("count", ++currentCount);
    }
  ```

### Blazor WebAssembly

#### Blazor can run client-side C# code directly in the browser

Blazor can run client-side C# code directly in the browser, using [WebAssembly](xref:blazor/hosting-models#blazor-webassembly).

The Blazor WebAssembly template and the Blazor Server template are included in the .NET 5 SDK. along with the Blazor Server template.

To create a Blazor WebAssembly project, run the following command in a console window:

```dotnetcli
dotnet new blazorwasm
```

#### Lazy loading in Blazor WebAssembly

Lazy loading enables improve  load time of the Blazor WebAssembly app by deferring the download of specific app dependencies until they are required. Lazy loading may be helpful when a Blazor WebAssembly app has large dependencies that are only used for specific parts of the app.

To delay the loading of an assembly, add it to the `BlazorWebAssemblyLazyLoad` item group in the project file:

Assemblies marked for lazy loading must be explicitly loaded by the app before they are used. To lazy load assemblies at runtime, use the `LazyAssemblyLoader` service:

```
@inject LazyAssemblyLoader LazyAssemblyLoader

@code {
    var assemblies = await LazyAssemblyLoader.LoadAssembliesAsync(new string[] { "Lib1.dll" });
}
```

To lazy load assemblies for a specific page, use the `OnNavigateAsync` event on the `Router` component. The `OnNavigateAsync` event is fired on every page navigation and can be used to lazy load assemblies for a particular route. The entire page can be lazily loaded for a route by passing any lazy loaded assemblies as additional assemblies to the Router.

The following examples demonstrates using the `LazyAssemblyLoader` service to lazy load a specific dependency (Lib1.dll) when the user navigates to `/page1`. The lazy loaded assembly is then added to the additional assemblies list passed to the `Router` component, so that it can discover any routable components in that assembly.

```
@using System.Reflection
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.WebAssembly.Services
@inject LazyAssemblyLoader LazyAssemblyLoader

<Router AppAssembly="typeof(Program).Assembly" AdditionalAssemblies="lazyLoadedAssemblies" OnNavigateAsync="@OnNavigateAsync">
    <Navigating>
        <div>
            <p>Loading the requested page...</p>
        </div>
    </Navigating>
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="typeof(MainLayout)">
            <p>Sorry, there is nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>

@code {
    private List<Assembly> lazyLoadedAssemblies = 
        new List<Assembly>();

    private async Task OnNavigateAsync(NavigationContext args)
    {
        if (args.Path.EndsWith("/page1"))
        {
            var assemblies = await LazyAssemblyLoader.LoadAssembliesAsync(new string[] { "Lib1.dll"  });
            lazyLoadedAssemblies.AddRange(assemblies);
        }
    }
}
```

#### Updated Blazor WebAssembly globalization support

.NET 5 Preview 8 reintroduces globalization support for Blazor WebAssembly based on International Components for Unicode (ICU). Part of introducing the ICU data and logic is optimizing these payloads for download size. This work is not fully completed yet. We expect to reduce the size of the ICU data in future .NET 5 updates.
<!-- Review: is this completed? -->

## gRPC

[gRPC](https://grpc.io/):

For more information, see <xref:grpc/index>.

## SignalR

SignalR Hub filters, called Hub pipelines in ASP.NET SignalR, is a feature that allows code to run before and after Hub methods are called. Running code before and after Hub methods are called is similar to how middleware has the ability to run code before and after an HTTP request. Common uses include logging, error handling, and argument validation.

For more information, see [Use hub filters in ASP.NET Core SignalR](xref:signalr/hub-filters).

You can read more about this Hub filters on the docs page.
<!--
See [Update SignalR code](xref:migration/31-to-50#signalr) for migration instructions.
-->

## Kestrel

* Reloadable endpoints via configuration: Kestrel can detect changes to configuration passed to [KestrelServerOptions.Configure](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure%2A) and unbind from existing endpoints and bind to new endpoints without requiring an application restart.
* HTTP/2 response headers improvements. For more information, see [Performance improvements](#performance-improvements) in the next section.
* Support for additional endpoints types in the sockets transport: Adding to the new API introduced in <xref:System.Net.Sockets?displayProperty=nameWithType>, the sockets default transport in [Kestrel](xref:fundamentals/servers/kestrel) allows binding to both existing file handles and unix domain sockets. Support for binding to existing file handles enables using the existing `Systemd` integration without requiring the `libuv` transport.
* Custom header decoding in Kestrel: Apps can specify which <xref:System.Text.Encoding> to use to interpret incoming headers based on the header name instead of defaulting to `UTF-8`. Set the <xref:System.Net.Http.SocketsHttpHandler.RequestHeaderEncodingSelector> property on <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions> to specify which encoding to use:
 
  ```csharp
  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                options.RequestHeaderEncodingSelector = encoding =>
                {
                    switch (encoding)
                    {
                        case "Host":
                            return System.Text.Encoding.Latin1;
                        default:
                            return System.Text.Encoding.UTF8;
                    }
                };
            });
            webBuilder.UseStartup<Startup>();
        });
  ```

## Performance improvements

### HTTP/2

* Significant reductions in allocations in the HTTP/2 code path.
* Support for [HPack dynamic compression](https://tools.ietf.org/html/rfc7541) of HTTP/2 response headers in [Kestrel](xref:fundamentals/servers/kestrel). For more information, see [Header table size](xref:fundamentals/servers/kestrel#header-table-size) and [HPACK: the silent killer (feature) of HTTP/2](https://blog.cloudflare.com/hpack-the-silent-killer-feature-of-http-2/).
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

Prior to .NET 5, building and publishing a Dockerfile for an ASP.NET app required pulling the entire .NET Core SDK and the ASP.NET image. With this release, pulling the SDK images bytes is reduced and the bytes pulled for the ASP.NET image is largely eliminated. For more information, See [this GitHub issue comment](https://github.com/dotnet/dotnet-docker/issues/1814#issuecomment-625294750)

## Security API improvements

### Azure Active Directory authentication with Microsoft.Identity.Web

The ASP.NET Core project templates now integrate with <xref:Microsoft.Identity.Web?displayProperty=fullName> to handle authentication with [Azure Activity Directory](https://docs.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-whatis) (Azure AD). The [Microsoft.Identity.Web package](https://www.nuget.org/packages/Microsoft.Identity.Web/) provides:

* A better experience for authentication through Azure AD.
* An easier way to access Azure resources on behalf of your users, including [Microsoft Graph](https://docs.microsoft.com/en-us/graph/overview). See the [Microsoft.Identity.Web sample](https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2) starts with a basic login and advances through multi-tenancy, using Azure APIs, using Microsoft Graph, and protecting your own APIs. `Microsoft.Identity.Web` is available alongside .NET 5.

### Allow anonymous access to an endpoint

The `AllowAnonymous` extension method allows anonymous access to an endpoint:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Hello World!");
        })
        .AllowAnonymous();
    });
}
```

### Custom handling of authorization failures

Custom handling of authorization failures is now easier with the new [IAuthorizationMiddlewareResultHandler](https://github.com/dotnet/aspnetcore/blob/v5.0.0-rc.1.20451.17/src/Security/Authorization/Policy/src/IAuthorizationMiddlewareResultHandler.cs) interface that is invoked by the [authorization](xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A) [Middleware](fundamentals/middleware). The default implementation remains the same, but a custom handler can be registered in [Dependency injection, which allows custom HTTP responses based on why authorization failed. See [this sample](https://github.com/dotnet/aspnetcore/blob/master/src/Security/samples/CustomAuthorizationFailureResponse/Authorization/SampleAuthorizationMiddlewareResultHandler.cs) that demonstrates usage of the `IAuthorizationMiddlewareResultHandler`.

### Authorization when using endpoint routing

Authorization when using endpoint routing now receives the `HttpContext` rather than the endpoint instance. This allows the authorization middleware to access the `RouteData` and other properties of the `HttpContext` that were not accessible though the <xref:Microsoft.AspNetCore.Http.Endpoint> class. The endpoint can be fetched from the context using [context.GetEndpoint(xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A).

## ASP.NET Core improvements

### Model binding improvements

#### Model binding DateTime as UTC

Model binding now supports binding UTC time strings to `DateTime`. If the request contains a UTC time string, model binding binds it to a UTC `DateTime`. For example, the following time string is bound the UTC `DateTime`:  `https://example.com/mycontroller/myaction?time=2019-06-14T02%3A30%3A04.0576719Z`

#### Model binding and validation with C# 9 record types

[C# 9 record types](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types) can be used with model binding in an MVC controller or a Razor Page. Record types are a great way to model data being transmitted over the network.

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

### OpenAPI Specification on by default

[OpenAPI Specification](http://spec.openapis.org/oas/v3.0.3) is a industry adopted convention for describing HTTP APIs and integrating them into complex business processes or with 3rd parties. Open API is widely supported by all cloud providers and many API registries. Apps that emit Open API documents from Web APIs have a variety of new opportunities in which those APIs can be used. In partnership with the maintainers of the open-source project [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/), we’re excited to announce that the ASP.NET Core API template contains a NuGet dependency on [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore), a popular open-source NuGet package that emits Open API documents dynamically. Swashbuckle does this by introspecting over the API Controllers and generating the Open API document at run-time, or at build time using the Swashbuckle CLI.

In .NET 5, the Web API templates enable the Open API output being enabled by default. To disable OpenAPI:

* From the command line: `dotnet new webapi --no-openapi true`
* From Visual Studio: Uncheck **Enable OpenAPI support**.

All *.csproj* files created for Web API projects contain the [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) NuGet package reference.

```xml
<ItemGroup>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="5.5.1" />
</ItemGroup>
```

The template generated code contains code in `Startup.ConfigureServices`that activates Open API document generation:

[!code-csharp[](~/release-notes/sample/StartupSwagger.cs?name=snippet)]

The `Configure` method adds the Swashbuckle middleware, which enables the:

* Document generation process.
* Swagger UI page by default in development mode.

The template generated code won't accidentally expose the API’s description when publishing to production.

[!code-csharp[](~/release-notes/sample/StartupSwagger.cs?name=snippet2)]

#### Azure API Management Import

When ASP.NET Core API projects enable OpenAPI, the Visual Studio 2019 version 16.8 Preview 3.2 and later publishing automatically offer an additional step in the publishing flow. Developers who use [Azure API Management](xref:tutorials/publish-to-azure-api-management-using-vs) have an opportunity to automatically import the APIs into Azure API Management during the publish flow:

![Azure API Management Import VS publishing](~/release-notes/static/publish-to-apim.png)

#### Console Logger Formatter

Improvements have been made to the console log provider in the `Microsoft.Extensions.Logging` library. Developers can now implement a custom `ConsoleFormatter` to exercise complete control over formatting and colorization of the console output. The formatter APIs allow for rich formatting by implementing a subset of the VT-100 escape sequences. VT-100 is supported by most modern terminals. The console logger can parse out escape sequences on unsupported terminals allowing developers to author a single formatter for all terminals.

#### JSON Console Logger

In addition to support for custom formatters, we’ve also added a built-in JSON formatter that emits structured JSON logs to the console. You can switch from the default simple logger to JSON, add to following snippet to your Program.cs:

```csharp
 public static IHostBuilder CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
   .ConfigureLogging(logging =>
   {
       logging.AddJsonConsole(options =>
       {
           options.JsonWriterOptions = new JsonWriterOptions()
           { Indented = true };
       });
   })
  .ConfigureWebHostDefaults(webBuilder =>
  {
      webBuilder.UseStartup<Startup>();
  });
```

Log messages emitted to the console are  JSON formatted:

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

## API improvements

### Improvements to DynamicRouteValueTransformer

ASP.NET Core 3.1 introduced <xref:Microsoft.AspNetCore.Mvc.Routing.DynamicRouteValueTransformer> as a way to use use a custom endpoint to dynamically select an MVC controller action or a razor page.  ASP.NET Core 5.0 apps can pass state to a `DynamicRouteValueTransformer` and filter the set of endpoints chosen.

### JSON extension methods for HttpRequest and HttpResponse

JSON data can be read and written to from an `HttpRequest` and `HttpResponse` using the new <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> and `WriteAsJsonAsync` extension methods. These extension methods use the [System.Text.Json](xref:System.Text.Json) serializer to handle the JSON data. You can also check if a request has a JSON content type using the new `HasJsonContentType` extension method.

The JSON extension methods can be combined with [endpoint routing](xref:fundamentals/routing) to create JSON APIs in a style of programming we call ***route to code***. It is a new option for developers who want to create basic JSON APIs in a lightweight way. For example, a web app that has only a handful of endpoints might choose to use route to code rather than the full functionality of ASP.NET Core MVC:

```csharp
endpoints.MapGet("/weather/{city:alpha}", async context =>
{
    var city = (string)context.Request.RouteValues["city"];
    var weather = GetFromDatabase(city);

    await context.Response.WriteAsJsonAsync(weather);
});
```

For more information on the new JSON extension methods and route to code, see [this .NET show](WriteAsJsonAsync).

### System.Diagnostics.Activity

The default format for <xref:System.Diagnostics.Activity?displayProperty=fullName> now defaults to the W3C format. This makes distributed tracing support in ASP.NET Core interoperable with more frameworks by default.

### FromBodyAttribute

<xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute> ow supports configuring an option that allows these parameters or properties to be considered optional:

```csharp
public IActionResult Post([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)]
                           MyModel model) {
     ...
     }
```

### Miscellaneous API changes

* The <xref:System.ComponentModel.DataAnnotations.CompareAttribute> can be applied to properties on Razor Page model.
* Parameters and properties bound from the body are considered required by default. <!-- Review: How is this different from 3.1
The validation system in .NET Core 3.0 and later treats non-nullable parameters or bound properties as if they had a [Required] attribute.
see https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1   
-->
* We’ve started applying [nullable annotations](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#attributes-describe-apis) to ASP.NET Core assemblies. We plan to annotate most of the common public API surface of the .NET 5 framework. <!-- Review: what's the impact of this? How does it work? Need more info.  Check the link I added -->

## Miscellaneous improvements

### Auto refresh with dotnet watch

In .NET 5, running [dotnet watch](xref:tutorials/dotnet-watch) on an ASP.NET Core project both launches the default browser and auto refreshes the browser as changes are made to the code. This means you can:

* Open an ASP.NET Core project in a text editor.
* Run `dotnet watch`
* Focus on the code changes while the tooling handles rebuilding, restarting, and reloading the app.

We hope to bring the auto refresh functionality to Visual Studio in the future.
