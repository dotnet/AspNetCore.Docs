---
title: Create responses in Minimal API applications
author: brunolins16
description: Learn how to create responses for Minimal APIs in ASP.NET Core.
ms.author: wpickett
ms.reviewer: brolivei
monikerRange: '>= aspnetcore-7.0'
ms.date: 08/22/2025
uid: fundamentals/minimal-apis/responses
ai-usage: ai-assisted
---

# How to create responses in Minimal API apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to create responses for Minimal API endpoints in ASP.NET Core. Minimal APIs provide several ways to return data and HTTP status codes.

:::moniker range=">= aspnetcore-10.0"

Minimal endpoints support the following types of return values:

1. `string` - This includes `Task<string>` and `ValueTask<string>`.
1. `T` (Any other type) - This includes `Task<T>` and `ValueTask<T>`.
1. `IResult` based - This includes `Task<IResult>` and `ValueTask<IResult>`.

[!INCLUDE[](~/includes/api-endpoint-auth.md)]

## `string` return values

|Behavior|Content-Type|
|--|--|
| The framework writes the string directly to the response. | `text/plain`

Consider the following route handler, which returns a `Hello world` text. 

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_01":::

The `200` status code is returned with `text/plain` Content-Type header and the following content.

```text
Hello World
```

## `T` (Any other type) return values

|Behavior|Content-Type|
|--|--|
| The framework JSON-serializes the response.| `application/json`

Consider the following route handler, which returns an anonymous type containing a `Message` string property.

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_02":::

The `200` status code is returned with `application/json` Content-Type header and the following content.

```json
{"message":"Hello World"}
```

## `IResult` return values

|Behavior|Content-Type|
|--|--|
| The framework calls [IResult.ExecuteAsync](xref:Microsoft.AspNetCore.Http.IResult.ExecuteAsync%2A).| Decided by the `IResult` implementation.

The `IResult` interface defines a contract that represents the result of an HTTP endpoint. The static [Results](<xref:Microsoft.AspNetCore.Http.Results>) class and the static [TypedResults](<xref:Microsoft.AspNetCore.Http.TypedResults>) are used to create various `IResult` objects that represent different types of responses.

### TypedResults vs Results

The <xref:Microsoft.AspNetCore.Http.Results> and <xref:Microsoft.AspNetCore.Http.TypedResults> static classes provide similar sets of results helpers. The `TypedResults` class is the *typed* equivalent of the `Results` class. However, the `Results` helpers' return type is <xref:Microsoft.AspNetCore.Http.IResult>, while each `TypedResults` helper's return type is one of the `IResult` implementation types. The difference means that for `Results` helpers a conversion is needed when the concrete type is needed, for example, for unit testing. The implementation types are defined in the <xref:Microsoft.AspNetCore.Http.HttpResults> namespace.

Returning `TypedResults` rather than `Results` has the following advantages:

* `TypedResults` helpers return strongly typed objects, which can improve code readability, unit testing, and reduce the chance of runtime errors.
* The implementation type [automatically provides the response type metadata for OpenAPI](/aspnet/core/fundamentals/openapi/aspnetcore-openapi#describe-response-types) to describe the endpoint.

Consider the following endpoint, for which a `200 OK` status code with the expected JSON response is produced.

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todo/Program.cs" id="snippet_11b":::

In order to document this endpoint correctly the extensions method `Produces` is called. However, it's not necessary to call `Produces` if `TypedResults` is used instead of `Results`, as shown in the following code. `TypedResults` automatically provides the metadata for the endpoint.

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todo/Program.cs" id="snippet_112b":::

For more information about describing a response type, see [OpenAPI support in Minimal APIs](/aspnet/core/fundamentals/openapi/aspnetcore-openapi#describe-response-types-1).

For examples on testing result types, see the [Test documentation](/aspnet/core/fundamentals/minimal-apis/test-min-api#unit-test-iresult-implementation-types).

Because all methods on `Results` return `IResult` in their signature, the compiler automatically infers that as the request delegate return type when returning different results from a single endpoint. `TypedResults` requires the use of `Results<T1, TN>` from such delegates.

The following method compiles because both [`Results.Ok`](xref:Microsoft.AspNetCore.Http.Results.Ok%2A) and [`Results.NotFound`](xref:Microsoft.AspNetCore.Http.Results.NotFound%2A) are declared as returning `IResult`, even though the actual concrete types of the objects returned are different:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todo/Program.cs" id="snippet_1a":::

The following method does not compile, because `TypedResults.Ok` and `TypedResults.NotFound` are declared as returning different types and the compiler won't attempt to infer the best matching type:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todo/Program.cs" id="snippet_111":::

To use `TypedResults`, the return type must be fully declared; when the method is asynchronous, the declaration requires wrapping the return type in a `Task<>`. Using `TypedResults` is more verbose, but that's the trade-off for having the type information be statically available and thus capable of self-describing to OpenAPI:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todo/Program.cs" id="snippet_1b":::

### Results<TResult1, TResultN>

Use [`Results<TResult1, TResultN>`](/dotnet/api/microsoft.aspnetcore.http.httpresults.results-2) as the endpoint handler return type instead of `IResult` when:

* Multiple `IResult` implementation types are returned from the endpoint handler. 
* The static `TypedResult` class is used to create the `IResult` objects.

This alternative is better than returning `IResult` because the generic union types automatically retain the endpoint metadata. And since the `Results<TResult1, TResultN>` union types implement implicit cast operators, the compiler can automatically convert the types specified in the generic arguments to an instance of the union type. 

This has the added benefit of providing compile-time checking that a route handler actually only returns the results that it declares it does. Attempting to return a type that isn't declared as one of the generic arguments to `Results<>` results in a compilation error.

Consider the following endpoint, for which a `400 BadRequest` status code is returned when the `orderId` is greater than `999`. Otherwise, it produces a `200 OK` with the expected content.

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_03":::

In order to document this endpoint correctly the extension method `Produces` is called. However, since the `TypedResults` helper automatically includes the metadata for the endpoint, you can return the `Results<T1, Tn>` union type instead, as shown in the following code.

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_04":::

<a name="binr10"></a>

### Built-in results

[!INCLUDE [results-helpers](~/fundamentals/minimal-apis/includes/results-helpers.md)]

The following sections demonstrate the usage of the common result helpers.

#### JSON

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_05":::

<xref:Microsoft.AspNetCore.Http.HttpResponseJsonExtensions.WriteAsJsonAsync%2A> is an alternative way to return JSON:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinJson/Program.cs" id="snippet_writeasjsonasync":::

#### Custom Status Code

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_06":::

#### Internal Server Error

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_07":::

The preceding example returns a 500 status code.

#### Problem and ValidationProblem

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_12":::

#### Customize validation error responses using IProblemDetailsService

Customize error responses from Minimal API validation logic with an <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> implementation. Register this service in your application's service collection to enable more consistent and user-specific error responses. Support for Minimal API validation was introduced in ASP.NET Core in .NET 10.

To implement custom validation error responses:

* Implement <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> or use the default implementation
* Register the service in the DI container
* The validation system automatically uses the registered service to format validation error responses

The following example shows how to register and configure the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> to customize validation error responses:

:::code language="csharp" source="~/fundamentals/minimal-apis/10.0-samples/MinApiIproblemDetailsService/Program.cs" id="snippet_register_IProblemDetailsService_implementation" :::

When a validation error occurs, the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> will be used to generate the error response, including any customizations added in the `CustomizeProblemDetails` callback.

For a complete app example, see the [Minimal API sample app](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/fundamentals/minimal-apis/10.0-samples/MinApiIproblemDetailsService/Program.cs) demonstrating how to customize validation error responses using the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> in ASP.NET Core Minimal APIs.

#### Text

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_08":::

<a name="stream7"></a>

#### Stream

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_stream)]

[`Results.Stream`](/dotnet/api/microsoft.aspnetcore.http.results.stream?view=aspnetcore-7.0&preserve-view=true) overloads allow access to the underlying HTTP response stream without buffering. The following example uses [ImageSharp](https://sixlabors.com/products/imagesharp) to return a reduced size of the specified image:

[!code-csharp[](~/fundamentals/minimal-apis/resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet)]

The following example streams an image from [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction):

[!code-csharp[](~/fundamentals/minimal-apis/resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet_abs)]

The following example streams a video from an Azure Blob:

[!code-csharp[](~/fundamentals/minimal-apis/resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet_video)]

#### Server-Sent Events (SSE)

The [TypedResults.ServerSentEvents](https://source.dot.net/#Microsoft.AspNetCore.Http.Results/TypedResults.cs,051e6796e1492f84) API supports returning a [ServerSentEvents](xref:System.Net.ServerSentEvents) result.

[Server-Sent Events](https://developer.mozilla.org/docs/Web/API/Server-sent_events) is a server push technology that allows a server to send a stream of event messages to a client over a single HTTP connection. In .NET, the event messages are represented as [`SseItem<T>`](/dotnet/api/system.net.serversentevents.sseitem-1) objects, which may contain an event type, an ID, and a data payload of type `T`.

The [TypedResults](xref:Microsoft.AspNetCore.Http.TypedResults) class has a static method called [ServerSentEvents](https://source.dot.net/#Microsoft.AspNetCore.Http.Results/TypedResults.cs,ceb980606eb9e295) that can be used to return a `ServerSentEvents` result. The first parameter to this method is an `IAsyncEnumerable<SseItem<T>>` that represents the stream of event messages to be sent to the client.

The following example illustrates how to use the `TypedResults.ServerSentEvents` API to return a stream of heart rate events as JSON objects to the client:

:::code language="csharp" source="~/fundamentals/minimal-apis/10.0-samples/MinimalServerSentEvents/Program.cs" id="snippet_item" :::

For more information, see the [Minimal API sample app](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/fundamentals/minimal-apis/10.0-samples/MinimalServerSentEvents/Program.cs) using the `TypedResults.ServerSentEvents` API to return a stream of heart rate events as string, `ServerSentEvents`, and JSON objects to the client.

#### Redirect

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_09":::

#### File

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_10":::

<a name="httpresultinterfaces7"></a>

### HttpResult interfaces

The following interfaces in the <xref:Microsoft.AspNetCore.Http> namespace provide a way to detect the `IResult` type at runtime, which is a common pattern in filter implementations:

* <xref:Microsoft.AspNetCore.Http.IContentTypeHttpResult>
* <xref:Microsoft.AspNetCore.Http.IFileHttpResult>
* <xref:Microsoft.AspNetCore.Http.INestedHttpResult>
* <xref:Microsoft.AspNetCore.Http.IStatusCodeHttpResult>
* <xref:Microsoft.AspNetCore.Http.IValueHttpResult>
* <xref:Microsoft.AspNetCore.Http.IValueHttpResult%601>

Here's an example of a filter that uses one of these interfaces:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/HttpResultInterfaces/Program.cs" id="snippet_filter":::

For more information, see [Filters in Minimal API apps](xref:fundamentals/minimal-apis/min-api-filters) and [IResult implementation types](xref:fundamentals/minimal-apis/test-min-api#iresult-implementation-types).

## File result return values

When an API endpoint returns content other than JSON, or supports HTTP protocol features like conditional or range requests,
ASP.NET Core provides result types that handle the necessary HTTP protocol details for you.
These result types are referred to as "file results", but provide functionality that can be useful more broadly than just files on disk.
There are file result types for both Minimal APIs and controller-based APIs, and they share a common underlying implementation and behavior.

To access this functionality, the API endpoint creates and returns a file result object - an instance of one of these file result types.
The file result object encapsulates the content to be sent, the content type, and any additional parameters like a download file name.
The result object implements a method -- `ExecuteAsync(HttpContext)` for Minimal APIs or `ExecuteResultAsync(ActionContext)` for controllers -- that the framework calls to write the response.
This method sets the `Content-Type` header and, when a file name is provided, the `Content-Disposition` header.
It also handles conditional request headers and range request headers when the appropriate parameters are set on the result object.

### File result types

In Minimal APIs, the most common and recommended way to create a file result is [`TypedResults.File`](xref:Microsoft.AspNetCore.Http.TypedResults.File%2A), which accepts a `byte[]` or `Stream` and returns a [`FileContentHttpResult`](xref:Microsoft.AspNetCore.Http.HttpResults.FileContentHttpResult) or [`FileStreamHttpResult`](xref:Microsoft.AspNetCore.Http.HttpResults.FileStreamHttpResult).

Alternatives include [`TypedResults.Bytes`](xref:Microsoft.AspNetCore.Http.TypedResults.Bytes%2A) for an explicit byte-array helper,
[`TypedResults.PhysicalFile`](xref:Microsoft.AspNetCore.Http.TypedResults.PhysicalFile%2A) for serving files by absolute path, or
[`Results.File`](xref:Microsoft.AspNetCore.Http.Results.File%2A) / [`Results.Bytes`](xref:Microsoft.AspNetCore.Http.Results.Bytes%2A) when you only need the `IResult` interface.

Also note that ASP.NET Core provides [static files middleware](xref:fundamentals/static-files) that serves files relative to the web root (`wwwroot`) without requiring an explicit endpoint.

```csharp
app.MapGet("/report", () =>
{
    // TypedResults.File with a byte[] returns a FileContentHttpResult
    byte[] pdf = GenerateReport();
    return TypedResults.File(pdf, "application/pdf", "report.pdf");
});

app.MapGet("/download", () =>
{
    // TypedResults.File with a Stream returns a FileStreamHttpResult
    Stream stream = new MemoryStream("Hello, World!"u8.ToArray());
    return TypedResults.File(stream, "application/octet-stream");
});
```

In controller-based APIs, the [`ControllerBase.File()`](xref:Microsoft.AspNetCore.Mvc.ControllerBase.File%2A) helper method accepts either a `byte[]` or `Stream` and returns the appropriate concrete result type ([`FileContentResult`](xref:Microsoft.AspNetCore.Mvc.FileContentResult), [`FileStreamResult`](xref:Microsoft.AspNetCore.Mvc.FileStreamResult)).

Alternatives include returning a [`VirtualFileResult`](xref:Microsoft.AspNetCore.Mvc.VirtualFileResult) for files relative to the web root, or a [`PhysicalFileResult`](xref:Microsoft.AspNetCore.Mvc.PhysicalFileResult) for files by absolute path, but these are less common as the static files middleware usually handles those scenarios.

```csharp
[HttpGet("report")]
public FileContentResult Report()
{
    // File() with a byte[] returns a FileContentResult
    byte[] pdf = GenerateReport();
    return File(pdf, "application/pdf", "report.pdf");
}

[HttpGet("download")]
public FileStreamResult Download()
{
    // File() with a Stream returns a FileStreamResult
    Stream stream = new MemoryStream("Hello, World!"u8.ToArray());
    return File(stream, "application/octet-stream");
}
```

### OpenAPI support for file results

File result types don't automatically contribute response metadata to the generated OpenAPI document.
To get a proper response description in the OpenAPI document, you must specify this metadata explicitly.

In Minimal APIs, use the [`Produces<TResponse>()`](xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces)
extension method to provide the OpenAPI metadata for the response. This metadata determines the status code, content type, and schema for the response in the OpenAPI document.
For a file result, it's important to specify the content type (e.g. `application/pdf`) and to use an appropriate `TResponse` to get the desired schema.
You can also specify the status code in the `Produces` extension method if it differs from the default of `200 OK`.
Common status codes are defined in the [`StatusCodes`](xref:Microsoft.AspNetCore.Http.StatusCodes) class, and common content types are defined in the [`MediaTypeNames`](xref:System.Net.Mime.MediaTypeNames) class.
For example:

```csharp
app.MapGet("/image", () =>
{
    // A 1x1 red pixel BMP (bitmap header + single pixel)
    byte[] data = [0x42, 0x4D, 0x1E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x1A, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x00,
                    0x01, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00, 0xFF, 0x00];
    return TypedResults.File(data, MediaTypeNames.Image.Bmp, "pixel.bmp");
})
// Use Stream to produce the correct schema in OpenAPI (format: binary)
.Produces<Stream>(contentType: MediaTypeNames.Image.Bmp);
```

Conceptually, `TResponse` represents the type of the response body, but the appropriate schema for a file result depends
more on the body content than the CLR type. Therefore, it may be necessary to specify a `TResponse` that doesn't match
the CLR type of the content in the file result in order to get the desired OpenAPI schema.

In particular, there are three common schemas for file results:

- **binary content**, such as PDFs, images, or videos, where the schema should be `type: string, format: binary`.
<!-- Hope we can change this to IBinaryContent if #67145 is approved and implemented-->
The recommended `TResponse` for this case is `Stream`. The framework has special logic to map
this type to the `binary` format in the OpenAPI schema.

- **text content**, such as CSV or plain text. Here the schema should be simply `type: string` with no `format`. Use `string` as the `TResponse` for this case.

- **base64-encoded content**, where the schema should be `type: string, format: byte`. It is uncommon to base64-encode file content in an API response, but for legacy reasons this is the schema produced when the `TResponse` is `byte[]`.

In a controller-based app, use the [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute) or the [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) attribute:

```csharp
[HttpGet("image")]
// Use FileContentResult to produce the correct schema in OpenAPI (format: binary)
[ProducesResponseType<FileContentResult>(StatusCodes.Status200OK, MediaTypeNames.Image.Bmp)]
public FileContentResult Image()
{
    // A 1x1 red pixel BMP (bitmap header + single pixel)
    byte[] data = [0x42, 0x4D, 0x1E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x1A, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x00,
                    0x01, 0x00, 0x18, 0x00, 0x00, 0x00, 0xFF, 0x00];
    return File(data, "image/bmp", "pixel.bmp");
}
```

As with Minimal APIs, you should choose the `Type` parameter of the `[Produces]` and `[ProducesResponseType]` attributes
that corresponds to the desired OpenAPI schema for your file result responses:
- **binary content** -- Use `FileContentResult` or `FileStreamResult` to get the `binary` format in the OpenAPI schema.
- **text content** -- Use `string` to get a simple `type: string` schema.
- **base64-encoded content** -- Use `byte[]` to get the `byte` format in the OpenAPI schema, though this is uncommon for file results.

### File result support for conditional requests

File results support [conditional requests](https://www.rfc-editor.org/rfc/rfc9110#section-13) for cache validation. Set the `lastModified` and/or `entityTag` parameters when creating the result object, and the framework automatically inspects incoming `If-None-Match` and `If-Modified-Since` headers. If the resource hasn't changed, the framework returns `304 Not Modified` with no body — no additional code is needed.

| Parameter | Purpose |
|-----------|---------|
| `lastModified` | Sets the `Last-Modified` response header. If the client sends `If-Modified-Since` and the file hasn't changed, the framework returns `304 Not Modified` with no body. |
| `entityTag` | Sets the `ETag` response header. If the client sends `If-None-Match` with a matching ETag, the framework returns `304 Not Modified` with no body. |

> [!NOTE]
> Precondition checks (`If-Match`, `If-Unmodified-Since`) typically require custom logic in the endpoint to verify preconditions *before* performing their function.

The following example demonstrates how to use file results to enable cache validation for a configuration endpoint.

```csharp
app.MapGet("/config", (
    [FromHeader(Name = "If-None-Match")] string? ifNoneMatch,
    [FromHeader(Name = "If-Modified-Since")] string? ifModifiedSince) =>
{
    byte[] data = File.ReadAllBytes("Data/config.json");
    var lastModified = File.GetLastWriteTimeUtc("Data/config.json");
    var etag = new EntityTagHeaderValue($"\"{Convert.ToHexString(SHA256.HashData(data))}\"");

    return TypedResults.File(
        data,
        contentType: MediaTypeNames.Application.Json,
        lastModified: lastModified,
        entityTag: etag);
})
.Produces<object>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status304NotModified);
```

This example also illustrates how to document the `304 Not Modified` response in the OpenAPI document using the `Produces` extension method, and including the `if-none-match` and `if-modified-since` headers as parameters so they're included in the OpenAPI schema for the endpoint.

A controller-based API can achieve the same behavior using the `File` helper method and the `[ProducesResponseType]` attribute:

```csharp
[HttpGet("config")]
[ProducesResponseType<object>(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status304NotModified)]
public FileContentResult Config(
    [FromHeader(Name = "If-None-Match")] string? ifNoneMatch,
    [FromHeader(Name = "If-Modified-Since")] string? ifModifiedSince)
{
    byte[] data = System.IO.File.ReadAllBytes("Data/config.json");
    var lastModified = System.IO.File.GetLastWriteTimeUtc("Data/config.json");
    var etag = new EntityTagHeaderValue($"\"{Convert.ToHexString(SHA256.HashData(data))}\"");

    return File(
        data,
        MediaTypeNames.Application.Json,
        lastModified: lastModified,
        entityTag: etag);
}
```

### File result support for range requests

**Range requests** allow clients to request only a portion of a file rather than the entire content. A client sends a `Range` header specifying byte offsets, and the server responds with `206 Partial Content` containing just those bytes. This enables resumable downloads, parallel chunked downloads, and efficient seeking in media players.

Range requests can also be conditional: the client sends an `If-Range` header containing an ETag or date alongside the `Range` header, and the server returns the partial content only if the resource hasn't changed since then. If it has changed, the server ignores the range and returns the full resource instead. Note that `If-Range` is only evaluated when `entityTag` or `lastModified` is also set on the file result.

Set `enableRangeProcessing` to `true` to enable range processing. The following examples enable range processing for a video streaming endpoint, and document the additional response types in the OpenAPI metadata.

**Minimal API:**

```csharp
app.MapGet("/video/{id}", (string id,
    [FromHeader(Name = "Range")] string? range) =>
{
    var bytes = GetVideo(id);

    return TypedResults.File(
        bytes,
        contentType: "video/mp4",
        fileDownloadName: "video.mp4",
        enableRangeProcessing: true);
})
.Produces<Stream>(StatusCodes.Status200OK, "video/mp4")
.Produces<Stream>(StatusCodes.Status206PartialContent, "video/mp4")
.Produces(StatusCodes.Status416RangeNotSatisfiable);
```

**Controller:**

```csharp
[HttpGet("video/{id}")]
[ProducesResponseType<FileContentResult>(StatusCodes.Status200OK, "video/mp4")]
[ProducesResponseType<FileContentResult>(StatusCodes.Status206PartialContent, "video/mp4")]
[ProducesResponseType(StatusCodes.Status416RangeNotSatisfiable)]
public FileContentResult Video(string id,
    [FromHeader(Name = "Range")] string? range)
{
    var bytes = GetVideo(id);

    return File(
        bytes,
        contentType: "video/mp4",
        fileDownloadName: "video.mp4",
        enableRangeProcessing: true);
}
```

With this configuration, the framework automatically handles the following HTTP interactions:

* **Full request** &mdash; Returns `200 OK` with the complete file.
* **Range request** (`Range: bytes=0-1023`) &mdash; Returns `206 Partial Content` with the `Content-Range` header and only the requested bytes.
* **Invalid range** &mdash; Returns `416 Range Not Satisfiable`.

## Modifying Headers

Use the `HttpResponse` object to modify response headers:

```csharp
app.MapGet("/", (HttpContext context) => {
    // Set a custom header
    context.Response.Headers["X-Custom-Header"] = "CustomValue";

    // Set a known header
    context.Response.Headers.CacheControl = $"public,max-age=3600";

    return "Hello World";
});
```

## Customizing responses

Applications can control responses by implementing a custom <xref:Microsoft.AspNetCore.Http.IResult> type. The following code is an example of an HTML result type:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/ResultsExtensions.cs)]

We recommend adding an extension method to <xref:Microsoft.AspNetCore.Http.IResultExtensions?displayProperty=fullName> to make these custom results more discoverable.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_xtn)]

Also, a custom `IResult` type can provide its own annotation by implementing the <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> interface. For example, the following code adds an annotation to the preceding `HtmlResult` type that describes the response produced by the endpoint.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Snippets/ResultsExtensions.cs?name=snippet_IEndpointMetadataProvider&highlight=1,17-20)]

The `ProducesHtmlMetadata` is an implementation of <xref:Microsoft.AspNetCore.Http.Metadata.IProducesResponseTypeMetadata> that defines the produced response content type `text/html` and the status code `200 OK`.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Snippets/ResultsExtensions.cs?name=snippet_ProducesHtmlMetadata&highlight=5,7)]

An alternative approach is using the <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute?displayProperty=fullName> to describe the produced response. The following code changes the `PopulateMetadata` method to use `ProducesAttribute`.

:::code language="csharp" source="~/fundamentals/minimal-apis/9.0-samples/Snippets/Program.cs" id="snippet_11":::

## Configure JSON serialization options

By default, Minimal API apps use [`Web defaults`](/dotnet/standard/serialization/system-text-json-configure-options#web-defaults-for-jsonserializeroptions) options during JSON serialization and deserialization.

### Configure JSON serialization options globally

Options can be configured globally for an app by invoking <xref:Microsoft.Extensions.DependencyInjection.HttpJsonServiceExtensions.ConfigureHttpJsonOptions%2A>. The following example includes public fields and formats JSON output.

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinJson/Program.cs" id="snippet_confighttpjsonoptions" highlight="3-6":::

Since fields are included, the preceding code reads `NameField` and includes it in the output JSON.

### Configure JSON serialization options for an endpoint

To configure serialization options for an endpoint, invoke <xref:Microsoft.AspNetCore.Http.Results.Json%2A?displayProperty=nameWithType> and pass to it a <xref:System.Text.Json.JsonSerializerOptions> object, as shown in the following example:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinJson/Program.cs" id="snippet_resultsjsonwithoptions" highlight="5-6,9":::

As an alternative, use an overload of <xref:Microsoft.AspNetCore.Http.HttpResponseJsonExtensions.WriteAsJsonAsync%2A> that accepts a <xref:System.Text.Json.JsonSerializerOptions> object. The following example uses this overload to format the output JSON:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinJson/Program.cs" id="snippet_writeasjsonasyncwithoptions" highlight="5-6,10":::

## Additional Resources

* <xref:fundamentals/minimal-apis/security>

:::moniker-end

[!INCLUDE[](~/fundamentals/minimal-apis/includes/responses9.md)]

[!INCLUDE[](~/fundamentals/minimal-apis/includes/responses7-8.md)]
