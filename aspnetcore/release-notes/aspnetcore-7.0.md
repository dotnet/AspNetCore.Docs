---
title: What's new in ASP.NET Core 7.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 7.0.
ms.author: riande
ms.custom: mvc
ms.date: 11/07/2022
uid: aspnetcore-7
---
# What's new in ASP.NET Core 7.0

This article highlights the most significant changes in ASP.NET Core 7.0 with links to relevant documentation.

## Rate limiting middleware in ASP.NET Core

The `Microsoft.AspNetCore.RateLimiting` middleware provides rate limiting middleware. Apps configure rate limiting policies and then attach the policies to endpoints. For more information, see <xref:performance/rate-limit?view=aspnetcore-7.0&preserve-view=true>.

## Authentication uses single scheme as DefaultScheme

As part of the work to simplify authentication, when there's only a single authentication scheme registered, it's automatically used as the <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultScheme> and doesn't need to be specified. For more information, see [DefaultScheme](xref:security/authentication/index#defaultscheme).

## MVC and Razor pages

### Support for nullable models in MVC views and Razor Pages

Nullable page or view models are supported to improve the experience when using null state checking with ASP.NET Core apps:

```csharp
@model Product?
```

### Bind with `IParsable<T>.TryParse` in MVC and API Controllers

The [`IParsable<TSelf>.TryParse`](/dotnet/api/system.iparsable-1.tryparse#system-iparsable-1-tryparse(system-string-system-iformatprovider-0@)) API supports binding controller action parameter values. For more information, see [Bind with `IParsable<T>.TryParse`](xref:mvc/models/model-binding#itp7).

### Customize the cookie consent value

In ASP.NET Core versions earlier than 7, the cookie consent validation uses the cookie value `yes` to indicate consent. Now you can specify the value that represents consent. For example, you could use `true` instead of `yes`:

[!code-csharp[Main](~/security/gdpr/sample/RP6.0/WebGDPR/Program.cs?name=snippet_2&highlight=8)]

For more information, see [Customize the cookie consent value](xref:security/gdpr#customize-the-cookie-consent-value).

## API controllers

### Parameter binding with DI in API controllers

Parameter binding for API controller actions binds parameters through [dependency injection](xref:fundamentals/dependency-injection) when the type is configured as a service. This means it's no longer required to explicitly apply the [`[FromServices]`](xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute) attribute to a parameter. In the following code, both actions return the time:

[!code-csharp[](~/release-notes/aspnetcore-7/samples/ApiController/Controllers/MyController.cs?name=snippet)]

In rare cases, automatic DI can break apps that have a type in DI that is also accepted in an API controllers action method. It's not common to have a type in DI and as an argument in an API controller action. To disable automatic binding of parameters, set [DisableImplicitFromServicesParameters](/dotnet/api/microsoft.aspnetcore.mvc.apibehavioroptions.disableimplicitfromservicesparameters)

[!code-csharp[](~/release-notes/aspnetcore-7/samples/ApiController/Program.cs?name=snippet_dis&highlight=8-11)]

In ASP.NET Core 7.0, types in DI are checked at app startup with <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> to determine if an argument in an API controller action comes from DI or from the other sources.

The new mechanism to infer binding source of API Controller action parameters uses the following rules:

1. A previously specified [`BindingInfo.BindingSource`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingSource) is never overwritten.
1. A complex type parameter, registered in the DI container, is assigned [`BindingSource.Services`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Services).
1. A complex type parameter, not registered in the DI container, is assigned [`BindingSource.Body`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Body).
1. A parameter with a name that appears as a route value in ***any*** route template is assigned [`BindingSource.Path`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Path).
1. All other parameters are [`BindingSource.Query`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Query).

### JSON property names in validation errors

By default, when a validation error occurs, model validation produces a <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary> with the property name as the error key. Some apps, such as single page apps, benefit from using JSON property names for validation errors generated from Web APIs. The following code configures validation to use the [`SystemTextJsonValidationMetadataProvider`](/dotnet/api/microsoft.aspnetcore.mvc.modelbinding.metadata.systemtextjsonvalidationmetadataprovider) to use JSON property names:

:::code language="csharp" source="~/mvc/models/validation/samples/7.x/ValidationJSON/Program.cs" id="snippet_1" highlight="5-8":::

The following code configures validation to use the [`NewtonsoftJsonValidationMetadataProvider`](/dotnet/api/microsoft.aspnetcore.mvc.newtonsoftjson.newtonsoftjsonvalidationmetadataprovider) to use JSON property name when using [Json.NET](https://www.newtonsoft.com/json):

:::code language="csharp" source="~/mvc/models/validation/samples/7.x/ValidationJSON/Program.cs" id="snippet" highlight="5-8":::

For more information, see [Use JSON property names in validation errors](xref:mvc/models/validation?view=aspnetcore-7.0&preserve-view=true#use-json-property-names-in-validation-errors)

## Minimal APIs

### Filters in Minimal API apps

Minimal API filters allow developers to implement business logic that supports:

* Running code before and after the route handler.
* Inspecting and modifying parameters provided during a route handler invocation.
* Intercepting the response behavior of a route handler.

Filters can be helpful in the following scenarios:

* Validating the request parameters and body that are sent to an endpoint.
* Logging information about the request and response.
* Validating that a request is targeting a supported API version.

For more information, see <xref:fundamentals/minimal-apis/min-api-filters>

### Bind arrays and string values from headers and query strings

In ASP.NET 7, binding query strings to an array of primitive types, string arrays, and [StringValues](/dotnet/api/microsoft.extensions.primitives.stringvalues) is supported:

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=snippet_bqs2pa)]

Binding query strings or header values to an array of complex types is supported when the type has `TryParse` implemented. For more information, see [Bind arrays and string values from headers and query strings](xref:fundamentals/minimal-apis?view=aspnetcore-7.0&preserve-view=true#bindar).

For more information, see [Add endpoint summary or description](xref:fundamentals/minimal-apis#add-endpoint-summary-or-description).

### Bind the request body as a `Stream` or `PipeReader`

The request body can bind as a [`Stream`](/dotnet/api/system.io.stream) or [`PipeReader`](/dotnet/api/system.io.pipelines.pipereader) to efficiently support scenarios where the user has to process data and:

* Store the data to blob storage or enqueue the data to a queue provider.
* Process the stored data with a worker process or cloud function.

For example, the data might be enqueued to [Azure Queue storage](/azure/storage/queues/storage-queues-introduction) or stored in [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction).

For more information, see [Bind the request body as a `Stream` or `PipeReader`](xref:fundamentals/minimal-apis#rbs)

### New Results.Stream overloads

We introduced new [`Results.Stream`](/dotnet/api/microsoft.aspnetcore.http.results.stream?view=aspnetcore-7.0&preserve-view=true) overloads to accommodate scenarios that need access to the underlying HTTP response stream without buffering. These overloads also improve cases where an API streams data to the HTTP response stream, like from Azure Blob Storage. The following example uses [ImageSharp](https://sixlabors.com/products/imagesharp) to return a reduced size of the specified image:

[!code-csharp[](~/fundamentals/minimal-apis/resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet)]

For more information, see [Stream examples](xref:fundamentals/minimal-apis?view=aspnetcore-7.0&preserve-view=true#stream7)

### Typed results for minimal APIs

In .NET 6, the <xref:Microsoft.AspNetCore.Http.IResult> interface was introduced to represent values returned from minimal APIs that don't utilize the implicit support for JSON serializing the returned object to the HTTP response. The static [Results](/dotnet/api/microsoft.aspnetcore.http.results) class is used to create varying `IResult` objects that represent different types of responses. For example, setting the response status code or redirecting to another URL. The `IResult` implementing framework types returned from these methods were internal however, making it difficult to verify the specific `IResult` type being returned from methods in a unit test.

In .NET 7 the types implementing `IResult` are public, allowing for type assertions when testing. For example:

[!code-csharp[](~/fundamentals/minimal-apis/misc-samples/typedResults/TypedResultsApiWithTest/Test/WeatherApiTest.cs?name=snippet_1&highlight=7-8)]

### Improved unit testability for minimal route handlers

<xref:Microsoft.AspNetCore.Http.IResult> implementation types are now publicly available in the <xref:Microsoft.AspNetCore.Http.HttpResults?displayProperty=fullName> namespace. The `IResult` implementation types can be used to unit test minimal route handlers when using named methods instead of lambdas.

The following code uses the [`Ok<TValue>`](/dotnet/api/microsoft.aspnetcore.http.httpresults.ok-1) class:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MinApiTestsSample/UnitTests/TodoInMemoryTests.cs" id="snippet_1" highlight="18":::

For more information, see [`IResult` implementation types](xref:fundamentals/minimal-apis/test-min-api#iit7).

### New HttpResult interfaces

The following interfaces in the <xref:Microsoft.AspNetCore.Http> namespace provide a way to detect the `IResult` type at runtime, which is a common pattern in filter implementations:

* <xref:Microsoft.AspNetCore.Http.IContentTypeHttpResult>
* <xref:Microsoft.AspNetCore.Http.IFileHttpResult>
* <xref:Microsoft.AspNetCore.Http.INestedHttpResult>
* <xref:Microsoft.AspNetCore.Http.IStatusCodeHttpResult>
* <xref:Microsoft.AspNetCore.Http.IValueHttpResult>
* <xref:Microsoft.AspNetCore.Http.IValueHttpResult%601>

For more information, see [IHttpResult interfaces](xref:fundamentals/minimal-apis/responses#httpresultinterfaces7).

### OpenAPI improvements for minimal APIs

<a name="openapinuget"></a>

#### `Microsoft.AspNetCore.OpenApi` NuGet package

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/) package allows interactions with OpenAPI specifications for endpoints. The package acts as a link between the OpenAPI models that are defined in the `Microsoft.AspNetCore.OpenApi` package and the endpoints that are defined in Minimal APIs. The package provides an API that examines an endpoint's parameters, responses, and metadata to construct an OpenAPI annotation type that is used to describe an endpoint.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/todo/Program.cs?name=snippet_withopenapi&highlight=9)]

#### Call `WithOpenApi` with parameters

The [`WithOpenApi`](https://github.com/dotnet/aspnetcore/blob/8a4b4deb09c04134f22f8d39aae21d212282004f/src/OpenApi/src/OpenApiRouteHandlerBuilderExtensions.cs#L49) method accepts a function that can be used to modify the OpenAPI annotation. For example, in the following code, a description is added to the first parameter of the endpoint:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/todo/Program.cs?name=snippet_withopenapi2&highlight=9-99)]

#### Provide endpoint descriptions and summaries

Minimal APIs now support annotating operations with descriptions and summaries for OpenAPI spec generation. You can call extension methods <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithDescription%2A> and <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithSummary%2A> or use attributes [[EndpointDescription]](xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute) and [[EndpointSummary]](xref:Microsoft.AspNetCore.Http.EndpointSummaryAttribute)).

For more information, see [OpenAPI in minimal API apps](xref:fundamentals/minimal-apis/openapi?view=aspnetcore-7.0)

### File uploads using IFormFile and IFormFileCollection

Minimal APIs now support file upload with `IFormFile` and `IFormFileCollection`. The following code uses <xref:Microsoft.AspNetCore.Http.IFormFile> and <xref:Microsoft.AspNetCore.Http.IFormFileCollection> to upload file:

:::code language="csharp" source="~/fundamentals/minimal-apis/iformFile/7.0-samples/MinimalApi/Program.cs" :::

Authenticated file upload requests are supported using an [Authorization header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Authorization), a [client certificate](/aspnet/core/security/authentication/certauth), or a cookie header.

There is no built-in support for [antiforgery](/aspnet/core/security/anti-request-forgery?view=aspnetcore-7.0&preserve-view=true#anti7). However, it can be implemented using the [`IAntiforgery` service](/aspnet/core/security/anti-request-forgery?view=aspnetcore-7.0&preserve-view=true#antimin7).

### `[AsParameters]` attribute enables parameter binding for argument lists

The [`[AsParameters]` attribute](xref:Microsoft.AspNetCore.Http.AsParametersAttribute) enables parameter binding for argument lists. For more information, see [Parameter binding for argument lists with `[AsParameters]`](xref:fundamentals/minimal-apis?view=aspnetcore-7.0&preserve-view=true#asparam7).

## Minimal APIs and API controllers

### New problem details service

The problem details service implements the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> interface, which supports creating [Problem Details for HTTP APIs](https://www.rfc-editor.org/rfc/rfc7807.html).

For more information, see [Problem details service](xref:web-api/handle-errors#pds7).

### Route groups

[!INCLUDE[](~/includes/route-groups.md)]

## gRPC

### JSON transcoding

gRPC JSON transcoding is an extension for ASP.NET Core that creates RESTful JSON APIs for gRPC services. gRPC JSON transcoding allows:

* Apps to call gRPC services with familiar HTTP concepts.
* ASP.NET Core gRPC apps to support both gRPC and RESTful JSON APIs without replicating functionality.
* Experimental support for generating OpenAPI from transcoded RESTful APIs by integrating with [Swashbuckle](xref:tutorials/get-started-with-swashbuckle).

For more information, see [gRPC JSON transcoding in ASP.NET Core gRPC apps](xref:grpc/json-transcoding?view=aspnetcore-7.0) and <xref:grpc/json-transcoding-openapi>.

### gRPC health checks in ASP.NET Core

The [gRPC health checking protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md) is a standard for reporting the health of gRPC server apps. An app exposes health checks as a gRPC service. They are typically used with an external monitoring service to check the status of an app.

gRPC ASP.NET Core has added built-in support for gRPC health checks with the [`Grpc.AspNetCore.HealthChecks`](https://www.nuget.org/packages/Grpc.AspNetCore.HealthChecks) package. Results from [.NET health checks](xref:host-and-deploy/health-checks) are reported to callers.

For more information, see <xref:grpc/health-checks>.

### Improved call credentials support

Call credentials are the recommended way to configure a gRPC client to send an auth token to the server. gRPC clients support two new features to make call credentials easier to use:

* Support for call credentials with plaintext connections. Previously, a gRPC call only sent call credentials if the connection was secured with TLS. A new setting on `GrpcChannelOptions`, called `UnsafeUseInsecureChannelCallCredentials`, allows this behavior to be customized. There are security implications to not securing a connection with TLS.
* A new method called `AddCallCredentials` is available with the [gRPC client factory](xref:grpc/clientfactory). `AddCallCredentials` is a quick way to configure call credentials for a gRPC client and integrates well with dependency injection (DI).

The following code configures the gRPC client factory to send `Authorization` metadata:

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
       o.Address = new Uri("https://localhost:5001");
    })
    .AddCallCredentials((context, metadata) =>
    {
       if (!string.IsNullOrEmpty(_token))
       {
          metadata.Add("Authorization", $"Bearer {_token}");
       }
       return Task.CompletedTask;
    });
```

For more information, see [Configure a bearer token with the gRPC client factory](xref:grpc/authn-and-authz#bearer-token-with-grpc-client-factory).

## SignalR

### Client results

The server now supports requesting a result from a client. This requires the server to use `ISingleClientProxy.InvokeAsync` and the client to return a result from its `.On` handler. Strongly-typed hubs can also return values from interface methods.

For more information, see [Client results](xref:signalr/hubs?view=aspnetcore-7.0#client-results)

### Dependency injection for SignalR hub methods

SignalR hub methods now support injecting services through dependency injection (DI).

Hub constructors can accept services from DI as parameters, which can be stored in properties on the class for use in a hub method. For more information, see [Inject services into a hub](xref:signalr/hubs?view=aspnetcore-7.0&preserve-view=true#inject-services-into-a-hub)

## Blazor

### Handle location changing events and navigation state

In .NET 7, Blazor supports location changing events and maintaining navigation state. This allows you to warn users about unsaved work or to perform related actions when the user performs a page navigation.

For more information, see the following sections of the *Routing and navigation* article:

* [Navigation options](xref:blazor/fundamentals/routing?view=aspnetcore-7.0#navigation-options)
* [Handle/prevent location changes](xref:blazor/fundamentals/routing?view=aspnetcore-7.0#handleprevent-location-changes)

### Empty Blazor project templates

Blazor has two new project templates for starting from a blank slate. The new **Blazor Server App Empty** and **Blazor WebAssembly App Empty** project templates are just like their non-empty counterparts but without example code. These empty templates only include a basic home page, and we've removed Bootstrap so that you can start with a different CSS framework.

For more information, see the following articles:

* <xref:blazor/tooling?view=aspnetcore-7.0>
* <xref:blazor/project-structure?view=aspnetcore-7.0>

### Blazor custom elements

The [`Microsoft.AspNetCore.Components.CustomElements`](https://www.nuget.org/packages/microsoft.aspnetcore.components.customelements) package enables building [standards based custom DOM elements](https://html.spec.whatwg.org/multipage/custom-elements.html#custom-elements) using Blazor.

For more information, see <xref:blazor/components/index?view=aspnetcore-7.0#blazor-custom-elements>.

### Bind modifiers (`@bind:after`, `@bind:get`, `@bind:set`)

> [!IMPORTANT]
> The `@bind:after`/`@bind:get`/`@bind:set` features are receiving further updates at this time. To take advantage of the latest updates, confirm that you've installed the [latest SDK](https://dotnet.microsoft.com/download/dotnet/7.0).
>
> Using an event callback parameter (`[Parameter] public EventCallback<string> ValueChanged { get; set; }`) isn't supported. Instead, pass an <xref:System.Action>-returning or <xref:System.Threading.Tasks.Task>-returning method to `@bind:set`/`@bind:after`.
>
> For more information, see the following resources:
>
> * [Blazor `@bind:after` not working on .NET 7 RTM release (dotnet/aspnetcore #44957)](https://github.com/dotnet/aspnetcore/issues/44957)
> * [`BindGetSetAfter701` sample app (javiercn/BindGetSetAfter701 GitHub repository)](https://github.com/javiercn/BindGetSetAfter701)

In .NET 7, you can run asynchronous logic after a binding event has completed using the new `@bind:after` modifier. In the following example, the `PerformSearch` asynchronous method runs automatically after any changes to the search text are detected:

```razor
<input @bind="searchText" @bind:after="PerformSearch" />

@code {
    private string searchText;

    private async Task PerformSearch()
    {
        ...
    }
}
```

In .NET 7, it's also easier to set up binding for component parameters. Components can support two-way data binding by defining a pair of parameters:

* `@bind:get`: Specifies the value to bind.
* `@bind:set`: Specifies a callback for when the value changes.

The `@bind:get` and `@bind:set` modifiers are always used together.

Examples:

```razor
@* Elements *@

<input type="text" @bind="text" @bind:after="() => { }" />

<input type="text" @bind:get="text" @bind:set="(value) => { }" />

<input type="text" @bind="text" @bind:after="AfterAsync" />

<input type="text" @bind:get="text" @bind:set="SetAsync" />

<input type="text" @bind="text" @bind:after="() => { }" />

<input type="text" @bind:get="text" @bind:set="(value) => { }" />

<input type="text" @bind="text" @bind:after="AfterAsync" />

<input type="text" @bind:get="text" @bind:set="SetAsync" />

@* Components *@

<InputText @bind-Value="text" @bind-Value:after="() => { }" />

<InputText @bind-Value:get="text" @bind-Value:set="(value) => { }" />

<InputText @bind-Value="text" @bind-Value:after="AfterAsync" />

<InputText @bind-Value:get="text" @bind-Value:set="SetAsync" />

<InputText @bind-Value="text" @bind-Value:after="() => { }" />

<InputText @bind-Value:get="text" @bind-Value:set="(value) => { }" />

<InputText @bind-Value="text" @bind-Value:after="AfterAsync" />

<InputText @bind-Value:get="text" @bind-Value:set="SetAsync" />

@code {
    private string text = "";

    private void After(){}
    private void Set() {}
    private Task AfterAsync() { return Task.CompletedTask; }
    private Task SetAsync(string value) { return Task.CompletedTask; }
}
```

For more information on the `InputText` component, see <xref:blazor/forms/input-components>.

<!--

For more information, see the following content in the *Data binding* article:

* [Introduction](xref:blazor/components/data-binding?view=aspnetcore-7.0)
* [Bind across more than two components](xref:blazor/components/data-binding?view=aspnetcore-7.0#bind-across-more-than-two-components)

-->

### Hot Reload improvements

In .NET 7, Hot Reload support includes the following:

* Components reset their parameters to their default values when a value is removed.
* Blazor WebAssembly:
  * Add new types.
  * Add nested classes.
  * Add static and instance methods to existing types.
  * Add static fields and methods to existing types.
  * Add static lambdas to existing methods.
  * Add lambdas that capture `this` to existing methods that already captured `this` previously.

### Dynamic authentication requests with MSAL in Blazor WebAssembly

New in .NET 7, Blazor WebAssembly supports creating dynamic authentication requests at runtime with custom parameters to handle advanced authentication scenarios.

For more information, see the following articles:

* <xref:blazor/security/webassembly/index?view=aspnetcore-7.0#customize-authentication>
* <xref:blazor/security/webassembly/additional-scenarios?view=aspnetcore-7.0#custom-authentication-request-scenarios>

### Blazor WebAssembly debugging improvements

Blazor WebAssembly debugging has the following improvements:

* Support for the **Just My Code** setting to show or hide type members that aren't from user code.
* Support for inspecting multidimensional arrays.
* **Call Stack** now shows the correct name for asynchronous methods.
* Improved expression evaluation.
* Correct handling of the `new` keyword on derived members.
* Support for debugger-related attributes in `System.Diagnostics`.

### `System.Security.Cryptography` support on WebAssembly

.NET 6 supported the SHA family of hashing algorithms when running on WebAssembly. .NET 7 enables more cryptographic algorithms by taking advantage of [:::no-loc text="SubtleCrypto":::](https://developer.mozilla.org/docs/Web/API/SubtleCrypto), when possible, and falling back to a .NET implementation when :::no-loc text="SubtleCrypto"::: can't be used. The following algorithms are supported on WebAssembly in .NET 7:

* SHA1
* SHA256
* SHA384
* SHA512
* HMACSHA1
* HMACSHA256
* HMACSHA384
* HMACSHA512
* AES-CBC
* PBKDF2
* HKDF

For more information, see [Developers targeting browser-wasm can use Web Crypto APIs (dotnet/runtime #40074)](https://github.com/dotnet/runtime/issues/40074).

### Inject services into custom validation attributes

You can now inject services into custom validation attributes. Blazor sets up the `ValidationContext` so that it can be used as a service provider.

For more information, see <xref:blazor/forms/validation?view=aspnetcore-7.0#custom-validation-attributes>.

### `Input*` components outside of an `EditContext`/`EditForm`

The built-in input components are now supported outside of a form in Razor component markup.

For more information, see <xref:blazor/forms/input-components?view=aspnetcore-7.0>.

### Project template changes

When .NET 6 was released last year, the HTML markup of the `_Host` page (`Pages/_Host.chstml`) was split between the `_Host` page and a new `_Layout` page (`Pages/_Layout.chstml`) in the .NET 6 Blazor Server project template.

In .NET 7, the HTML markup has been recombined with the `_Host` page in project templates.

Several additional changes were made to the Blazor project templates. It isn't feasible to list every change to the templates in the documentation. To migrate an app to .NET 7 in order to adopt all of the changes, see <xref:migration/60-to-70#blazor>.

### Experimental `QuickGrid` component

The new `QuickGrid` component provides a convenient data grid component for most common requirements and as a reference architecture and performance baseline for anyone building Blazor data grid components.

For more information, see <xref:blazor/components/quickgrid>.

Live demo: [QuickGrid for Blazor sample app](https://aspnet.github.io/quickgridsamples/)

### Virtualization enhancements

Virtualization enhancements in .NET 7:

* The `Virtualize` component supports using the document itself as the scroll root, as an alternative to having some other element with `overflow-y: scroll` applied.
* If the `Virtualize` component is placed inside an element that requires a specific child tag name, `SpacerElement` allows you to obtain or set the virtualization spacer tag name.

For more information, see the following sections of the *Virtualization* article:

* [Root-level virtualization](xref:blazor/components/virtualization?view=aspnetcore-7.0#root-level-virtualization)
* [Control the spacer element tag name](xref:blazor/components/virtualization?view=aspnetcore-7.0#control-the-spacer-element-tag-name)

### `MouseEventArgs` updates

`MovementX` and `MovementY` have been added to `MouseEventArgs`.

For more information, see <xref:blazor/components/event-handling?view=aspnetcore-7.0#built-in-event-arguments>.

### New Blazor loading page

The Blazor WebAssembly project template has a new loading UI that shows the progress of loading the app.

For more information, see <xref:blazor/fundamentals/startup?view=aspnetcore-7.0#loading-progress-indicators>.

### Improved diagnostics for authentication in Blazor WebAssembly

To help diagnose authentication issues in Blazor WebAssembly apps, detailed logging is available.

For more information, see <xref:blazor/fundamentals/logging?view=aspnetcore-7.0#blazor-webassembly-authentication-logging>.

### JavaScript interop on WebAssembly

JavaScript `[JSImport]`/`[JSExport]` interop API is a new low-level mechanism for using .NET in Blazor WebAssembly and JavaScript-based apps. With this new JavaScript interop capability, you can invoke .NET code from JavaScript using the .NET WebAssembly runtime and call into JavaScript functionality from .NET without any dependency on the Blazor UI component model.

For more information:

* <xref:blazor/js-interop/import-export-interop>: Pertains only to Blazor WebAssembly apps.
* <xref:client-side/dotnet-interop>: Pertains only to JavaScript apps that don't depend on the Blazor UI component model.

### Conditional registration of the authentication state provider

Prior to the release of .NET 7, `AuthenticationStateProvider` was registered in the service container with `AddScoped`. This made it difficult to debug apps, as it forced a specific order of service registrations when providing a custom implementation. Due to internal framework changes over time, it's no longer necessary to register `AuthenticationStateProvider` with `AddScoped`.

In developer code, make the following change to the authentication state provider service registration:

```diff
- builder.Services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
+ builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
```

In the preceding example, `ExternalAuthStateProvider` is the developer's service implementation.

### Improvements to the .NET WebAssembly build tools

New features in the `wasm-tools` workload for .NET 7 that help improve performance and handle exceptions:

* [WebAssembly Single Instruction, Multiple Data (SIMD)](https://github.com/WebAssembly/simd/blob/master/proposals/simd/SIMD.md) support (only with AOT, not supported by Apple Safari)
* WebAssembly exception handling support

For more information, see <xref:blazor/tooling?view=aspnetcore-7.0#net-webassembly-build-tools>.

## Blazor Hybrid

### External URLs

An option has been added that permits opening external webpages in the browser.

For more information, see <xref:blazor/hybrid/routing?view=aspnetcore-7.0#external-navigation>.

### Security

New guidance is available for Blazor Hybrid security scenarios. For more information, see the following articles:

* <xref:blazor/hybrid/security/index?view=aspnetcore-7.0>
* <xref:blazor/hybrid/security/security-considerations?view=aspnetcore-7.0>

## Performance

### Output caching middleware

Output caching is a new middleware that stores responses from a web app and serves them from a cache rather than computing them every time. Output caching differs from [response caching](xref:performance/caching/overview#response-caching) in the following ways:

* The caching behavior is configurable on the server.
* Cache entries can be programmatically invalidated.
* Resource locking mitigates the risk of [cache stampede](https://en.wikipedia.org/wiki/Cache_stampede) and [thundering herd](https://en.wikipedia.org/wiki/Thundering_herd_problem).
* Cache revalidation means the server can return a `304 Not Modified` HTTP status code instead of a cached response body.
* The cache storage medium is extensible.

For more information, see [Overview of caching](xref:performance/caching/overview) and [Output caching middleware](xref:performance/caching/output).

### HTTP/3 improvements

This release:

* Makes HTTP/3 fully supported by ASP.NET Core, it's no longer experimental.
* Improves Kestrel's support for HTTP/3. The two main areas of improvement are feature parity with HTTP/1.1 and HTTP/2, and performance.
* Provides full support for <xref:Microsoft.AspNetCore.Hosting.ListenOptionsHttpsExtensions.UseHttps(Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions,System.Security.Cryptography.X509Certificates.X509Certificate2)> with HTTP/3. Kestrel offers advanced options for configuring connection certificates, such as hooking into [Server Name Indication (SNI)](https://wikipedia.org/wiki/Server_Name_Indication).
* Adds support for HTTP/3 on [HTTP.sys](xref:fundamentals/servers/httpsys) and [IIS](xref:host-and-deploy/iis/modules).

The following example shows how to use an SNI callback to resolve TLS options:

:::code language="csharp" source="~/release-notes/sample/Program7.cs" id="snippet_1":::

Significant work was done in .NET 7 to reduce HTTP/3 allocations. You can see some of those improvements in the following GitHub PR's:

* [HTTP/3: Avoid per-request cancellation token allocations](https://github.com/dotnet/aspnetcore/pull/42685)
* [HTTP/3: Avoid ConnectionAbortedException allocations](https://github.com/dotnet/aspnetcore/pull/42708)
* [HTTP/3: ValueTask pooling](https://github.com/dotnet/aspnetcore/pull/42760)

### HTTP/2 Performance improvements

.NET 7 introduces a significant re-architecture of how Kestrel processes HTTP/2 requests. ASP.NET Core apps with busy HTTP/2 connections will experience reduced CPU usage and higher throughput.

Previously, the HTTP/2 multiplexing implementation relied on a [lock](/dotnet/csharp/language-reference/statements/lock) controlling which request can write to the underlying TCP connection. A [thread-safe queue](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels/) replaces the write lock. Now, rather than fighting over which thread gets to use the write lock, requests now queue up and a dedicated consumer processes them. Previously wasted CPU resources are available to the rest of the app.

One place where these improvements can be noticed is in gRPC, a popular RPC framework that uses HTTP/2. Kestrel + gRPC benchmarks show a dramatic improvement:

![gRPC server streaming performance](https://user-images.githubusercontent.com/219224/177910504-e93579b4-02e4-4079-8a8c-d9d24857aabf.png)

Changes were made in the HTTP/2 frame writing code that improves performance when there are multiple streams trying to write data on a single HTTP/2 connection. We now dispatch TLS work to the thread pool and more quickly release a write lock that other streams can acquire to write their data. The reduction in wait times can yield significant performance improvements in cases where there is contention for this write lock. A gRPC benchmark with 70 streams on a single connection (with TLS) showed a ~15% improvement in requests per second (RPS) with this change.

### Http/2 WebSockets support

.NET 7 introduces Websockets over HTTP/2 support for Kestrel, the SignalR JavaScript client, and SignalR with Blazor WebAssembly.

Using WebSockets over HTTP/2 takes advantage of new features such as:

* Header compression.
* Multiplexing, which reduces the time and resources needed when making multiple requests to the server.

These supported features are available in Kestrel on all HTTP/2 enabled platforms. The version negotiation is automatic in browsers and Kestrel, so no new APIs are needed.

For more information, see [Http/2 WebSockets support](xref:fundamentals/websockets?view=aspnetcore-7.0#http2-websockets-support).

### Kestrel performance improvements on high core machines

Kestrel uses <xref:System.Collections.Concurrent.ConcurrentQueue%601> for many purposes. One purpose is scheduling I/O operations in Kestrel's default Socket transport. Partitioning the `ConcurrentQueue` based on the associated socket reduces contention and increases throughput on machines with many CPU cores.

Profiling on high core machines on .NET 6 showed significant contention in one of Kestrel's other `ConcurrentQueue` instances, the `PinnedMemoryPool` that Kestrel uses to cache byte buffers.

In .NET 7, Kestrel's memory pool is partitioned the same way as its I/O queue, which leads to much lower contention and higher throughput on high core machines. On the 80 core ARM64 VMs, we're seeing over 500% improvement in responses per second (RPS) in the TechEmpower plaintext benchmark.  On 48 Core AMD VMs, the improvement is nearly 100% in our HTTPS JSON benchmark.

### `ServerReady` event to measure startup time

Apps using [EventSource](/dotnet/api/system.diagnostics.tracing.eventsource) can measure the startup time to understand and optimize startup performance. The new [`ServerReady`](https://source.dot.net/#Microsoft.AspNetCore.Hosting/Internal/HostingEventSource.cs,76) event in <xref:Microsoft.AspNetCore.Hosting?displayProperty=fullName> represents the point where the server is ready to respond to requests.

## Server

### New ServerReady event for measuring startup time

The [`ServerReady`](https://github.com/dotnet/aspnetcore/blob/v7.0.0-preview.5.22303.8/src/Hosting/Hosting/src/Internal/HostingEventSource.cs#L75-L79) event has been added to measure [startup time](https://github.com/dotnet/aspnetcore/blob/v7.0.0-preview.5.22303.8/src/Hosting/Hosting/src/GenericHost/GenericWebHostService.cs#L138) of ASP.NET Core apps.

## IIS

### Shadow copying in IIS

Shadow copying app assemblies to the [ASP.NET Core Module (ANCM)](xref:host-and-deploy/aspnet-core-module) for IIS can provide a better end user experience than stopping the app by deploying an [app offline file](xref:host-and-deploy/iis/app-offline).

For more information, see [Shadow copying in IIS](xref:host-and-deploy/iis/advanced?view=aspnetcore-7.0#shadow-copy).

## Miscellaneous

### Kestrel full certificate chain improvements

[HttpsConnectionAdapterOptions](/dotnet/api/microsoft.aspnetcore.server.kestrel.https.httpsconnectionadapteroptions?view=aspnetcore-7.0&preserve-view=true) has a new [ServerCertificateChain](/dotnet/api/microsoft.aspnetcore.server.kestrel.https.httpsconnectionadapteroptions.servercertificatechain?view=aspnetcore-7.0&preserve-view=true#microsoft-aspnetcore-server-kestrel-https-httpsconnectionadapteroptions-servercertificatechain) property of type [X509Certificate2Collection](/dotnet/api/system.security.cryptography.x509certificates.x509certificate2collection), which makes it easier to validate certificate chains by allowing a full chain including intermediate certificates to be specified. See [dotnet/aspnetcore#21513](https://github.com/dotnet/aspnetcore/issues/21513) for more details.

### dotnet watch

#### Improved console output for dotnet watch

The console output from dotnet watch has been improved to better align with the logging of ASP.NET Core and to stand out with 😮emojis😍.

Here's an example of what the new output looks like:

![output for dotnet watch](~/release-notes/aspnetcore-7/static/dnwatch.png)

For more information, see [this GitHub pull request](https://github.com/dotnet/sdk/pull/23318).

### Configure dotnet watch to always restart for rude edits

Rude edits are edits that  can't be hot reloaded. To configure dotnet watch to always restart without a prompt for rude edits, set the `DOTNET_WATCH_RESTART_ON_RUDE_EDIT` environment variable to `true`.

### Developer exception page dark mode

Dark mode support has been added to the developer exception page, thanks to a contribution by [Patrick Westerhoff](https://twitter.com/poke). To test dark mode in a browser, from the developer tools page, set the mode to dark. For example, in Firefox:

![F12 tools FF dark mode](https://user-images.githubusercontent.com/3605364/178082215-7bd1dfbe-3f11-421c-9918-fa11d8b99736.png)

In Chrome:

![F12 tools Chrome dark mode](https://user-images.githubusercontent.com/3605364/178082535-7719b77f-563a-4d0d-b70a-267801bb6526.png)

### Project template option to use Program.Main method instead of top-level statements

The .NET 7 templates include an option to not use [top-level statements](/dotnet/csharp/fundamentals/program-structure/top-level-statements) and generate a `namespace` and a `Main` method declared on a `Program` class.

Using the .NET CLI, use the `--use-program-main` option:

```dotnetcli
dotnet new web --use-program-main
```

With Visual Studio, select the new **Do not use top-level statements** checkbox during project creation:

![checkbox](https://user-images.githubusercontent.com/3605364/180587645-90f7cce5-d9f8-49d2-88cf-2258960394e1.png)

### Updated Angular and React templates

The Angular project template has been updated to Angular 14. The React project template has been updated to React 18.2.

### Manage JSON Web Tokens in development with dotnet user-jwts

The new `dotnet user-jwts` command line tool can create and manage app specific local [JSON Web Tokens](https://jwt.io/introduction) (JWTs). For more information, see [Manage JSON Web Tokens in development with dotnet user-jwts](xref:security/authentication/jwt?view=aspnetcore-7.0&preserve-view=true).

### Support for additional request headers in W3CLogger

You can now specify additional request headers to log when using the W3C logger by calling `AdditionalRequestHeaders()` on <xref:Microsoft.AspNetCore.HttpLogging.W3CLoggerOptions>:

```csharp
services.AddW3CLogging(logging =>
{
    logging.AdditionalRequestHeaders.Add("x-forwarded-for");
    logging.AdditionalRequestHeaders.Add("x-client-ssl-protocol");
});
```

For more information, see [W3CLogger options](xref:fundamentals/w3c-logger/index#w3clogger-options-1).

### Request decompression

The new [Request decompression middleware](xref:fundamentals/middleware/request-decompression?view=aspnetcore-7.0&preserve-view=true):

* Enables API endpoints to accept requests with compressed content.
* Uses the [`Content-Encoding`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Encoding) HTTP header to automatically identify and decompress requests which contain compressed content.
* Eliminates the need to write code to handle compressed requests.

For more information, see [Request decompression middleware](xref:fundamentals/middleware/request-decompression?view=aspnetcore-7.0&preserve-view=true).
