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

<xref:Microsoft.AspNetCore.Http.HttpContext> encapsulates all HTTP-specific information about an individual HTTP request. An `HttpContext` instance is initialized when ASP.NET Core receives an HTTP request and is accessible by middleware and app frameworks such as Web API controllers, Razor Pages, SignalR, gRPC, and more.

For more information about accessing the `HttpContext`, see <xref:fundamentals/httpcontext>.

## `HttpRequest`

<xref:Microsoft.AspNetCore.Http.HttpContext.Request?displayProperty=nameWithType> provides access to <xref:Microsoft.AspNetCore.Http.HttpRequest>. `HttpRequest` has information about the incoming HTTP request, and it's initialized when an HTTP request is received by the server. `HttpRequest` isn't read-only, and middleware can change request values in the middleware pipeline.

Commonly used properties on `HttpRequest` include:

|Property|Description|Example|
|--|--|--|--|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Path?displayProperty=nameWithType>|The request path.|`/en-us/article/get-started`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Method?displayProperty=nameWithType>|The request method.|`GET`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Headers?displayProperty=nameWithType>|A collection of request headers.|`user-agent=Edge`<br />`x-custom-header=MyValue`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.RouteValues?displayProperty=nameWithType>|A collection of route values. The collection is set when the request is matched to a route.|`language=en-us`<br />`article=get-started`|
|<xref:Microsoft.AspNetCore.Http.HttpRequest.Body?displayProperty=nameWithType>|A <xref:System.IO.Stream> for reading the request body.|UTF-8 JSON payload|

### Get request headers

<xref:Microsoft.AspNetCore.Http.HttpRequest.Headers?displayProperty=nameWithType> provides access to the request headers sent with the HTTP request. There are two ways to access headers using this collection:

* Provide the header name to the indexer on the header collection. The header name isn't case-sensitive. The indexer can access any header value.
* The header collection also has properties for getting and setting commonly used HTTP headers. The properties provide a fast, strongly typed way to access headers.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestHeaders&highlight=6-7)]

### Read request body

An HTTP request can include a request body. The request body is data associated with the request, such as the content of an HTML form, UTF-8 JSON payload, or a file.

<xref:Microsoft.AspNetCore.Http.HttpRequest.Body?displayProperty=nameWithType> allows the request body to be read with <xref:System.IO.Stream>:

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestBody&highlight=9)]

`HttpRequest.Body` can be read directly or used with other APIs that accept stream.

#### Enabling request body buffering

The request body can only be read once, from beginning to end. Forward-only reading of the request body is designed to avoid the overhead of buffering the entire request body and reduce memory usage. However, in some scenarios, there's a need to read the request body multiple times. For example, middleware might need to read the request body and then rewind it so it's available for the endpoint.

The <xref:Microsoft.AspNetCore.Http.HttpRequestRewindExtensions.EnableBuffering%2A> extension method enables buffering of the HTTP request body and is the recommended way to enable multiple reads. Because a request can be any size, `EnableBuffering` supports options for buffering large request bodies to disk, or rejecting them entirely.

The middleware in the following example:

* Enables multiple reads with `EnableBuffering`. Must be called before reading the request body.
* Reads the request body.
* Rewinds the request body to the start so other middleware or the endpoint can read it.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestBuffering&highlight=6-8)]

#### BodyReader

An alternative way to read the request body is to use the <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyReader?displayProperty=nameWithType> property. The `BodyReader` property exposes the request body as a <xref:System.IO.Pipelines.PipeReader>. This API is from [I/O pipelines](/dotnet/standard/io/pipelines), an advanced, high-performance way to read the request body.

The reader directly accesses the request body and manages memory on the caller's behalf. Unlike `HttpRequest.Body`, the reader doesn't copy request data into a buffer. However, a reader is more complicated to use than a stream and should be used with caution.

For information on how to read content from `BodyReader`, see [I/O pipelines PipeReader](/dotnet/standard/io/pipelines#pipereader).

## `HttpResponse`

<xref:Microsoft.AspNetCore.Http.HttpContext.Response?displayProperty=nameWithType> provides access to <xref:Microsoft.AspNetCore.Http.HttpResponse>. `HttpResponse` is used to set information on the HTTP response sent back to the client.

Commonly used properties on `HttpResponse` include:

|Property|Description|Example|
|--|--|--|--|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.StatusCode?displayProperty=nameWithType>|The response code. Must be set before writing to the response body.|`200`|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.ContentType?displayProperty=nameWithType>|The response `content-type` header. Must be set before writing to the response body.|`application/json`|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.Headers?displayProperty=nameWithType>|A collection of response headers. Must be set before writing to the response body.|`server=Kestrel`<br />`x-custom-header=MyValue`|
|<xref:Microsoft.AspNetCore.Http.HttpResponse.Body?displayProperty=nameWithType>|A <xref:System.IO.Stream> for writing the response body.|Generated web page|

### Set response headers

<xref:Microsoft.AspNetCore.Http.HttpResponse.Headers?displayProperty=nameWithType> provides access to the response headers sent with the HTTP response. There are two ways to access headers using this collection:

* Provide the header name to the indexer on the header collection. The header name isn't case-sensitive. The indexer can access any header value.
* The header collection also has properties for getting and setting commonly used HTTP headers. The properties provide a fast, strongly typed way to access headers.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_ResponseHeaders&highlight=6-7)]

An app can't modify headers after the response has started, which sends the headers to the client. A response is started by flushing the response body or calling <xref:Microsoft.AspNetCore.Http.HttpResponse.StartAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>. An error is thrown when attempting to modify headers after the response has started.

### Set response trailers

HTTP/2 and HTTP/3 support response trailers. Trailers are headers sent with the response after the response body is complete. Because trailers are sent after the response body, trailers can be added to the response at any time.

Set trailers using <xref:Microsoft.AspNetCore.Http.ResponseTrailerExtensions.AppendTrailer%2A>:

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_ResponseTrailers&highlight=8)]

### Write response body

An HTTP response can include a response body. The response body is data associated with the response, such as generated web page content, UTF-8 JSON payload, or a file.

<xref:Microsoft.AspNetCore.Http.HttpResponse.Body?displayProperty=nameWithType> allows the response body to be written with <xref:System.IO.Stream>:

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_ResponseBody&highlight=9)]

`HttpResponse.Body` can be written directly or used with other APIs that write to a stream.

#### BodyWriter

An alternative way to read the request body is to use the <xref:Microsoft.AspNetCore.Http.HttpResponse.BodyWriter?displayProperty=nameWithType> property. The `BodyWriter` property exposes the response body as a <xref:System.IO.Pipelines.PipeWriter>. This API is from [I/O pipelines](/dotnet/standard/io/pipelines), and it's an advanced, high-performance way to write the response.

The writer provides direct access to the response body and manages memory on the caller's behalf. Unlike `HttpResponse.Body`, the write doesn't copy request data into a buffer. However, a reader is more complicated to use than a stream and should be used with caution.

For information on how to read content from `BodyWriter`, see [I/O pipelines PipeWriter](/dotnet/standard/io/pipelines#pipewriter).

## `RequestAborted`

The <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> cancellation token can be used to notify that the HTTP request has been aborted. The cancellation token should be passed to long-running tasks so they can be canceled if the request is aborted. For example, aborting a database query or HTTP request to get data to return in the response.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_RequestAborted&highlight=7-8)]

The `RequestAborted` cancellation token doesn't need to be used with asynchronous operations when reading the request body or writing to the response body. They immediately exit if the HTTP request is aborted.

> [!NOTE]
> [Minimal APIs](xref:fundamentals/minimal-apis) supports binding <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> directly to a <xref:System.Threading.CancellationToken> parameter.

## `Abort()`

The <xref:Microsoft.AspNetCore.Http.HttpContext.Abort?displayProperty=nameWithType> method can be used to abort an HTTP request from the server. Aborting the HTTP request immediately triggers the <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> cancellation token and sends a notification to the client that the server has aborted the request.

The following example:

* Adds a 10-second timeout to reading the incoming request message.
* Aborts the HTTP request if the timeout is exceeded.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_Abort&highlight=23)]

## `User`

The <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType> property is used to get or set the user, represented by <xref:System.Security.Claims.ClaimsPrincipal>, for the request. The <xref:System.Security.Claims.ClaimsPrincipal> is typically set by [ASP.NET Core authentication](xref:security/authentication/index).

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_User&highlight=6)]

> [!NOTE]
> [Minimal APIs](xref:fundamentals/minimal-apis) supports binding <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType> directly to a <xref:System.Security.Claims.ClaimsPrincipal> parameter.

## `Features`

The <xref:Microsoft.AspNetCore.Http.HttpContext.Features?displayProperty=nameWithType> property provides access to the collection of feature interfaces for the current request. Since the feature collection is mutable even within the context of a request, middleware can be used to modify the collection and add support for additional features. Some advanced features are only available by accessing the associated interface through the feature collection.

The following example:

* Gets <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinRequestBodyDataRateFeature> from the features collection.
* Sets `MinDataRate` to null. This removes the minimum data rate that the request body must be sent by the client for this HTTP request.

[!code-csharp[](use-http-context/samples/Program.cs?name=snippet_Features&highlight=6)]

For more information about using request features and `HttpContext`, see <xref:fundamentals/request-features>.
