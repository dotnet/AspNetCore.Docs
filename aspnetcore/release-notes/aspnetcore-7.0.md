---
title: What's new in ASP.NET Core 7.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 7.0.
ms.author: riande
ms.custom: mvc
ms.date: 08/19/2022
uid: aspnetcore-7
---
# What's new in ASP.NET Core 7.0 preview

This article highlights the most significant changes in ASP.NET Core 7.0 with links to relevant documentation.

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

### Provide endpoint descriptions and summaries

Minimal APIs now support annotating operations with descriptions and summaries for OpenAPI spec generation. You can call extension methods <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithDescription%2A> and <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithSummary%2A> or use attributes [[EndpointDescription]](xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute) and [[EndpointSummary]](xref:Microsoft.AspNetCore.Http.EndpointSummaryAttribute)).

For more information, see [Add endpoint summary or description](xref:fundamentals/minimal-apis#add-endpoint-summary-or-description).

## Bind the request body as a `Stream` or `PipeReader`

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

### OpenAPI improvements for minimal APIs

<a name="openapinuget"></a>

#### `Microsoft.AspNetCore.OpenApi` NuGet package

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/) package allows interactions with OpenAPI specifications for endpoints. The package acts as a link between the OpenAPI models that are defined in the `Microsoft.AspNetCore.OpenApi` package and the endpoints that are defined in Minimal APIs. The package provides an API that examines an endpoint's parameters, responses, and metadata to construct an OpenAPI annotation type that is used to describe an endpoint.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/todo/Program.cs?name=snippet_withopenapi&highlight=9)]

#### Call `WithOpenApi` with parameters

The [`WithOpenApi`](https://github.com/dotnet/aspnetcore/blob/8a4b4deb09c04134f22f8d39aae21d212282004f/src/OpenApi/src/OpenApiRouteHandlerBuilderExtensions.cs#L49) method accepts a function that can be used to modify the OpenAPI annotation. For example, in the following code, a description is added to the first parameter of the endpoint:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/todo/Program.cs?name=snippet_withopenapi2&highlight=9-99)]

#### Exclude Open API description

In the following sample, the `/skipme` endpoint is excluded from generating an OpenAPI description:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_swag2&highlight=20-21)]

## gRPC

### JSON transcoding

gRPC JSON transcoding is an extension for ASP.NET Core that creates RESTful JSON APIs for gRPC services. gRPC JSON transcoding allows:

* Apps to call gRPC services with familiar HTTP concepts.
* ASP.NET Core gRPC apps to support both gRPC and RESTful JSON APIs without replicating functionality.

For more information, see [gRPC JSON transcoding in ASP.NET Core gRPC apps](xref:grpc/httpapi?view=aspnetcore-7.0)

## SignalR

### Client results

The server now supports requesting a result from a client. This requires the server to use `ISingleClientProxy.InvokeAsync` and the client to return a result from its `.On` handler. Strongly-typed hubs can also return values from interface methods.

For more information, see [Client results](xref:signalr/hubs?view=aspnetcore-7.0#client-results)

### Dependency injection for SignalR hub methods

SignalR hub methods now support injecting services through dependency injection (DI).

Hub constructors can accept services from DI as parameters, which can be stored in properties on the class for use in a hub method. For more information, see [Inject services into a hub](xref:signalr/hubs?view=aspnetcore-7.0&preserve-view=true#inject-services-into-a-hub)

## Performance

### HTTP/2 Performance improvements

.NET 7 introduces a significant re-architecture of how Kestrel processes HTTP/2 requests. ASP.NET Core apps with busy HTTP/2 connections will experience reduced CPU usage and higher throughput.

Previously, the HTTP/2 multiplexing implementation relied on a [lock](/dotnet/csharp/language-reference/statements/lock) controlling which request can write to the underlying TCP connection. A [thread-safe queue](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels/) replaces the write lock. Now, rather than fighting over which thread gets to use the write lock, requests now queue up and a dedicated consumer processes them. Previously wasted CPU resources are available to the rest of the app.

One place where these improvements can be noticed is in gRPC, a popular RPC framework that uses HTTP/2. Kestrel + gRPC benchmarks show a dramatic improvement:

![Entity diagram](https://user-images.githubusercontent.com/219224/177910504-e93579b4-02e4-4079-8a8c-d9d24857aabf.png)

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

For more information, see [Shadow copying in IIS](xref:host-and-deploy/iis/advanced?view=aspnetcore-7.0#shadow-copy)

## Miscellaneous

### dotnet watch

#### Improved console output for dotnet watch

The console output from dotnet watch has been improved to better align with the logging of ASP.NET Core and to stand out with 😮emojis😍.

Here's an example of what the new output looks like:

![output for dotnet watch](~/release-notes/aspnetcore-7/static/dnwatch.png)

See [this GitHub pull request](https://github.com/dotnet/sdk/pull/23318) for more information.

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

![checkbox ](https://user-images.githubusercontent.com/3605364/180587645-90f7cce5-d9f8-49d2-88cf-2258960394e1.png)

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

For more information,see [W3CLogger options](xref:fundamentals/w3c-logger/index#w3clogger-options-1).

### Request decompression

The new [Request decompression middleware](xref:fundamentals/middleware/request-decompression?view=aspnetcore-7.0&preserve-view=true):

* Enables API endpoints to accept requests with compressed content.
* Uses the [`Content-Encoding`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Encoding) HTTP header to automatically identify and decompress requests which contain compressed content.
* Eliminates the need to write code to handle compressed requests.

For more information, see [Request decompression middleware](xref:fundamentals/middleware/request-decompression?view=aspnetcore-7.0&preserve-view=true).
