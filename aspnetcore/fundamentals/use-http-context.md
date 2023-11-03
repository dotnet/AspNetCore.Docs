---
title: Use HttpContext in ASP.NET Core
author: jamesnk
description: How to use HttpContext in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: jamesnk
ms.date: 01/31/2022
uid: fundamentals/use-httpcontext
---
# Use HttpContext in ASP.NET Core

<xref:Microsoft.AspNetCore.Http.HttpContext> encapsulates all information about an individual HTTP request and response. An `HttpContext` instance is initialized when an HTTP request is received. The `HttpContext` instance is accessible by middleware and app frameworks such as Web API controllers, Razor Pages, SignalR, gRPC, and more.

For more information about accessing the `HttpContext`, see <xref:fundamentals/httpcontext>.

## `HttpRequest`

<xref:Microsoft.AspNetCore.Http.HttpContext.Request?displayProperty=nameWithType> provides access to <xref:Microsoft.AspNetCore.Http.HttpRequest>. `HttpRequest` has information about the incoming HTTP request, and it's initialized when an HTTP request is received by the server. `HttpRequest` isn't read-only, and middleware can change request values in the middleware pipeline.

Commonly used members on `HttpRequest` include:

|Property|Description|Example|
|--|--|--|--|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Path?displayProperty=nameWithType>|The request path.|`/en/article/getstarted`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Method?displayProperty=nameWithType>|The request method.|`GET`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Headers?displayProperty=nameWithType>|A collection of request headers.|`user-agent=Edge`<br />`x-custom-header=MyValue`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.RouteValues?displayProperty=nameWithType>|A collection of route values. The collection is set when the request is matched to a route.|`language=en`<br />`article=getstarted`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Query?displayProperty=nameWithType>|A collection of query values parsed from <xref:Microsoft.AspNetCore.Http.HttpRequest.QueryString>.|`filter=hello`<br />`page=1`|
|[HttpRequest.ReadFormAsync()](xref:Microsoft.AspNetCore.Http.HttpRequest.ReadFormAsync(System.Threading.CancellationToken))|A method that reads the request body as a form and returns a form values collection. For information about why `ReadFormAsync` should be used to access form data, see [Prefer ReadFormAsync over Request.Form](xref:fundamentals/best-practices#prefer-readformasync-over-requestform).|`email=user@contoso.com`<br />`password=TNkt4taM`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Body?displayProperty=nameWithType>|A <xref:System.IO.Stream> for reading the request body.|UTF-8 JSON payload|

### Get request headers

<xref:Microsoft.AspNetCore.Http.HttpRequest.Headers?displayProperty=nameWithType> provides access to the request headers sent with the HTTP request. There are two ways to access headers using this collection:

* Provide the header name to the indexer on the header collection. The header name isn't case-sensitive. The indexer can access any header value.
* The header collection also has properties for getting and setting commonly used HTTP headers. The properties provide a fast, IntelliSense driven way to access headers.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestHeaders&highlight=6-7)]

### Read request body

An HTTP request can include a request body. The request body is data associated with the request, such as the content of an HTML form, UTF-8 JSON payload, or a file.

<xref:Microsoft.AspNetCore.Http.HttpRequest.Body?displayProperty=nameWithType> allows the request body to be read with <xref:System.IO.Stream>:

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestBody&highlight=9)]

`HttpRequest.Body` can be read directly or used with other APIs that accept stream.

> [!NOTE]
> [Minimal APIs](xref:fundamentals/minimal-apis) supports binding <xref:Microsoft.AspNetCore.Http.HttpRequest.Body?displayProperty=nameWithType> directly to a <xref:System.IO.Stream> parameter.

#### Enable request body buffering

The request body can only be read once, from beginning to end. Forward-only reading of the request body avoids the overhead of buffering the entire request body and reduces memory usage. However, in some scenarios, there's a need to read the request body multiple times. For example, middleware might need to read the request body and then rewind it so it's available for the endpoint.

The <xref:Microsoft.AspNetCore.Http.HttpRequestRewindExtensions.EnableBuffering%2A> extension method enables buffering of the HTTP request body and is the recommended way to enable multiple reads. Because a request can be any size, `EnableBuffering` supports options for buffering large request bodies to disk, or rejecting them entirely.

The middleware in the following example:

* Enables multiple reads with `EnableBuffering`. It must be called before reading the request body.
* Reads the request body.
* Rewinds the request body to the start so other middleware or the endpoint can read it.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestBuffering&highlight=6)]

#### BodyReader

An alternative way to read the request body is to use the <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyReader?displayProperty=nameWithType> property. The `BodyReader` property exposes the request body as a <xref:System.IO.Pipelines.PipeReader>. This API is from [I/O pipelines](/dotnet/standard/io/pipelines), an advanced, high-performance way to read the request body.

The reader directly accesses the request body and manages memory on the caller's behalf. Unlike `HttpRequest.Body`, the reader doesn't copy request data into a buffer. However, a reader is more complicated to use than a stream and should be used with caution.

For information on how to read content from `BodyReader`, see [I/O pipelines PipeReader](/dotnet/standard/io/pipelines#pipereader).

## `HttpResponse`

<xref:Microsoft.AspNetCore.Http.HttpContext.Response?displayProperty=nameWithType> provides access to <xref:Microsoft.AspNetCore.Http.HttpResponse>. `HttpResponse` is used to set information on the HTTP response sent back to the client.

Commonly used members on `HttpResponse` include:

|Property|Description|Example|
|--|--|--|--|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.StatusCode?displayProperty=nameWithType>|The response code. Must be set before writing to the response body.|`200`|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.ContentType?displayProperty=nameWithType>|The response `content-type` header. Must be set before writing to the response body.|`application/json`|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.Headers?displayProperty=nameWithType>|A collection of response headers. Must be set before writing to the response body.|`server=Kestrel`<br />`x-custom-header=MyValue`|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.Body?displayProperty=nameWithType>|A <xref:System.IO.Stream> for writing the response body.|Generated web page|

### Set response headers

<xref:Microsoft.AspNetCore.Http.HttpResponse.Headers?displayProperty=nameWithType> provides access to the response headers sent with the HTTP response. There are two ways to access headers using this collection:

* Provide the header name to the indexer on the header collection. The header name isn't case-sensitive. The indexer can access any header value.
* The header collection also has properties for getting and setting commonly used HTTP headers. The properties provide a fast, IntelliSense driven way to access headers.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_ResponseHeaders&highlight=6-7)]

An app can't modify headers after the response has started. Once the response starts, the headers are sent to the client. A response is started by flushing the response body or calling <xref:Microsoft.AspNetCore.Http.HttpResponse.StartAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>. The <xref:Microsoft.AspNetCore.Http.HttpResponse.HasStarted?displayProperty=nameWithType> property indicates whether the response has started. An error is thrown when attempting to modify headers after the response has started:

> System.InvalidOperationException: Headers are read-only, response has already started.

> [!NOTE]
> Unless response buffering is enabled, all write operations (for example, <xref:Microsoft.AspNetCore.Http.HttpResponseWritingExtensions.WriteAsync%2A>) flush the response body internally and mark the response as started. Response buffering is disabled by default.

### Write response body

An HTTP response can include a response body. The response body is data associated with the response, such as generated web page content, UTF-8 JSON payload, or a file.

<xref:Microsoft.AspNetCore.Http.HttpResponse.Body?displayProperty=nameWithType> allows the response body to be written with <xref:System.IO.Stream>:

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_ResponseBody&highlight=9)]

`HttpResponse.Body` can be written directly or used with other APIs that write to a stream.

#### BodyWriter

An alternative way to write the response body is to use the <xref:Microsoft.AspNetCore.Http.HttpResponse.BodyWriter?displayProperty=nameWithType> property. The `BodyWriter` property exposes the response body as a <xref:System.IO.Pipelines.PipeWriter>. This API is from [I/O pipelines](/dotnet/standard/io/pipelines), and it's an advanced, high-performance way to write the response.

The writer provides direct access to the response body and manages memory on the caller's behalf. Unlike `HttpResponse.Body`, the write doesn't copy request data into a buffer. However, a writer is more complicated to use than a stream and writer code should be thoroughly tested.

For information on how to write content to `BodyWriter`, see [I/O pipelines PipeWriter](/dotnet/standard/io/pipelines#pipewriter).

### Set response trailers

HTTP/2 and HTTP/3 support response trailers. Trailers are headers sent with the response after the response body is complete. Because trailers are sent after the response body, trailers can be added to the response at any time.

The following code sets trailers using <xref:Microsoft.AspNetCore.Http.ResponseTrailerExtensions.AppendTrailer%2A>:

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_ResponseTrailers&highlight=11)]

## `RequestAborted`

The <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> cancellation token can be used to notify that the HTTP request has been aborted by the client or server. The cancellation token should be passed to long-running tasks so they can be canceled if the request is aborted. For example, aborting a database query or HTTP request to get data to return in the response.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestAborted&highlight=7-8)]

The `RequestAborted` cancellation token doesn't need to be used for request body read operations because reads always throw immediately when the request is aborted. The `RequestAborted` token is also usually unnecessary when writing response bodies, because writes immediately no-op when the request is aborted.

In some cases, passing the `RequestAborted` token to write operations can be a convenient way to force a write loop to exit early with an <xref:System.OperationCanceledException>. However, it's typically better to pass the `RequestAborted` token into any asynchronous operations responsible for retrieving the response body content instead.

> [!NOTE]
> [Minimal APIs](xref:fundamentals/minimal-apis) supports binding <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> directly to a <xref:System.Threading.CancellationToken> parameter.

## `Abort()`

The <xref:Microsoft.AspNetCore.Http.HttpContext.Abort?displayProperty=nameWithType> method can be used to abort an HTTP request from the server. Aborting the HTTP request immediately triggers the <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> cancellation token and sends a notification to the client that the server has aborted the request.

The middleware in the following example:

* Adds a custom check for malicious requests.
* Aborts the HTTP request if the request is malicious.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_Abort&highlight=9)]

## `User`

The <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType> property is used to get or set the user, represented by <xref:System.Security.Claims.ClaimsPrincipal>, for the request. The <xref:System.Security.Claims.ClaimsPrincipal> is typically set by [ASP.NET Core authentication](xref:security/authentication/index).

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_User&highlight=6)]

> [!NOTE]
> [Minimal APIs](xref:fundamentals/minimal-apis) supports binding <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType> directly to a <xref:System.Security.Claims.ClaimsPrincipal> parameter.

## `Features`

The <xref:Microsoft.AspNetCore.Http.HttpContext.Features?displayProperty=nameWithType> property provides access to the collection of feature interfaces for the current request. Since the feature collection is mutable even within the context of a request, middleware can be used to modify the collection and add support for additional features. Some advanced features are only available by accessing the associated interface through the feature collection.

The following example:

* Gets <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinRequestBodyDataRateFeature> from the features collection.
* Sets <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinResponseDataRateFeature.MinDataRate> to null. This removes the minimum data rate that the request body must be sent by the client for this HTTP request.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_Features&highlight=6)]

For more information about using request features and `HttpContext`, see <xref:fundamentals/request-features>.

## HttpContext isn't thread safe

This article primarily discusses using `HttpContext` in request and response flow from Razor Pages, controllers, middleware, etc. Consider the following when using `HttpContext` outside the request and response flow:

* The `HttpContext` is **NOT** thread safe, accessing it from multiple threads can result in exceptions, data corruption and generally unpredictable results.
* The <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> interface should be used with caution. As always, the `HttpContext` must ***not*** be captured outside of the request flow.  `IHttpContextAccessor`:
  * Relies on  <xref:System.Threading.AsyncLocal%601> which can have a negative performance impact on asynchronous calls.
  * Creates a dependency on "ambient state" which can make testing more difficult.
* <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor.HttpContext%2A?displayProperty=nameWithType> may be `null` if accessed outside of the request flow.
* To access information from `HttpContext` outside the request flow, copy the information inside the request flow. Be careful to copy the actual data and not just references. For example, rather than copying a reference to an `IHeaderDictionary`, copy the relevant header values or copy the entire dictionary key by key before leaving the request flow.
* Don't capture `IHttpContextAccessor.HttpContext` in a constructor.

The following sample logs GitHub branches when requested from the `/branch` endpoint:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/Program.cs?highlight=26-46)]

The GitHub API requires two headers. The `User-Agent` header is added dynamically by the `UserAgentHeaderHandler`:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/Program.cs?highlight=10-20)]

The `UserAgentHeaderHandler`:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/UserAgentHeaderHandler.cs?highlight=21-29)]

In the preceding code, when the `HttpContext` is `null`, the `userAgent` string is set to `"Unknown"`. If possible, `HttpContext` should be explicitly passed to the service. Explicitly passing in `HttpContext` data:

* Makes the service API more useable outside the request flow.
* Is better for performance.
* Makes the code easier to understand and reason about than relying on ambient state.

When the service must access `HttpContext`, it should account for the possibility of `HttpContext` being `null` when not called from a request thread.

The application also includes `PeriodicBranchesLoggerService`, which logs the open GitHub branches of the specified repository every 30 seconds:

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/PeriodicBranchesLoggerService.cs)]

`PeriodicBranchesLoggerService` is a [hosted service](xref:fundamentals/host/hosted-services), which runs outside the request and response flow. Logging from the `PeriodicBranchesLoggerService` has a null `HttpContext`. The `PeriodicBranchesLoggerService` was written to not depend on the `HttpContext`.

[!code-csharp[](~/fundamentals/http-context/samples/6.x/HttpContextInBackgroundThread/Program.cs?highlight=8&range=1-11)]
