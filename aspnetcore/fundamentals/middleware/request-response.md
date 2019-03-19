---
title: Request and Response operations in ASP.NET Core
author: jkotalik
description: Learn how to read the request body and write the response body in ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jkotalik
ms.custom: mvc
ms.date: 02/26/2019
uid: fundamentals/middleware/request-response
---
# Request and response operations in ASP.NET Core

By [Justin Kotalik](https://github.com/jkotalik)

This article explains how to read from the request body and write to the response body. You might need to write code for these operations when you're writing middleware. Otherwise, you typically don't have to write this code because the operations are handled by MVC and Razor Pages.

In ASP.NET Core 3.0, there are two abstractions for the request and response bodies: <xref:System.IO.Stream> and <xref:System.IO.Pipelines.Pipe>. For request reading, [HttpRequest.Body](xref:Microsoft.AspNetCore.Http.HttpRequest.Body) is a <xref:System.IO.Stream>, and `HttpRequest.BodyPipe` is a <xref:System.IO.Pipelines.PipeReader>. For response writing, [HttpResponse.Body](xref:Microsoft.AspNetCore.Http.HttpResponse.Body) is a `HttpResponse.BodyPipe` is a <xref:System.IO.Pipelines.PipeWriter>.

We recommend pipelines over streams. Streams can be easier to use for some simple operations, but pipelines have a performance advantage and are easier to use in most scenarios. In 3.0, ASP.NET Core is starting to use pipelines instead of streams internally. Examples include:

- `FormReader`
- `TextReader`
- `TexWriter`
- `HttpResponse.WriteAsync`

Streams aren't going away. They continue to be used throughout .NET, and many stream types don't have pipe equivalents, like `FileStreams` and `ResponseCompression`.

## Stream examples

Suppose you want to create a middleware that reads the entire request body as a list of strings, splitting on new lines. A simple stream implementation might look like the following example:

[!code-csharp[](request-response/samples/3.x/RequestResponseSample/Startup.cs?name=GetListOfStringsFromStream)]

This code works, but there are some issues:

- Before appending to the `StringBuilder`, the example creates another string (`encodedString`) that is thrown away immediately. This process occurs for all bytes in the stream, so the result is extra memory allocation the size of the entire request body.
- The example reads the entire string before splitting on new lines. It would be more efficient to check for new lines in the byte array.

Here's an example that fixes some of these issues:

[!code-csharp[](request-response/samples/3.x/RequestResponseSample/Startup.cs?name=GetListOfStringsFromStreamMoreEfficient)]

This example:

- Doesn't buffer the entire request body in a `StringBuilder` unless there aren't any newline characters.
- Doesn't call `Split` on the string.

However, there are still are a few issues:

- If newline characters are sparse, much of the request body is buffered in the string .
- It still creates strings (`remainingString`) and adds them to the string buffer, which results in an extra allocation.

These issues are fixable, but the code is becoming more and more complicated with little improvement. Pipelines provide a way to solve these problems with minimal code complexity.

## Pipelines

The following example shows how the same scenario can be handled using a `PipeReader`:

[!code-csharp[](request-response/samples/3.x/RequestResponseSample/Startup.cs?name=GetListOfStringFromPipe)]

This example fixes many issues that the streams implementations had:

- There is no need for a string buffer because the `PipeReader` handles bytes that haven't been used.
- Encoded strings are directly added to the list of returned strings.
- String creation is allocation-free besides the memory used by the string (except the `ToArray()` call).

## Adapters

Now that both `Body` and `BodyPipe` properties are available for `HttpRequest` and `HttpResponse`, what happens when you set `Body` to a different stream? In 3.0, a new set of adapters automatically adapt each type to the other. For example, if you set `HttpRequest.Body` to a new stream, `HttpRequest.BodyPipe` is automatically set to a new `PipeReader` that wraps `HttpRequest.Body`. The same behavior applies to setting the `BodyPipe` property. If `HttpResponse.BodyPipe` is set to a new `PipeWriter`, the `HttpResponse.Body` is automatically set to a new stream that wraps `HttpResponse.BodyPipe`.

## StartAsync

`HttpResponse.StartAsync` is new in 3.0. It is used to indicate that headers are unmodifiable and to run `OnStarting` callbacks. In 3.0-preview3, you have to call `StartAsync` before using `HttpRequest.BodyPipe`, and in future releases, it will be a recommendation. When using Kestrel as a server, calling StartAsync before using the `PipeReader` guarantees that memory returned by `GetMemory` will belong to Kestrel's internal <xref:System.IO.Pipelines.Pipe> rather than an external buffer.

## Additional resources

- [Introducing System.IO.Pipelines](https://devblogs.microsoft.com/dotnet/system-io-pipelines-high-performance-io-in-net/)
- <xref:fundamentals/middleware/write>