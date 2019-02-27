---
title: Request and Response operations in ASP.NET Core
author: jkotalik
description: Learn how to get started with WebSockets in ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jkotalik
ms.custom: mvc
ms.date: 02/26/2019
uid: fundamentals/request-response
---
# Request and response operations in ASP.NET Core

By [Justin Kotalik](https://github.com/jkotalik)

This article explains how to read from the HttpRequest Body and write to the HttpResponse Body.

In ASP.NET Core 3.0, there are two abstractions for the HttpRequest and Response bodies: <xref:System.IO.Stream> and <xref:System.IO.Pipelines.Pipe>. For Request reading, the <xref:Microsoft.AspNetCore.Http.HttpRequest.Body> is a <xref:System.IO.Stream> and <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyPipe> is <xref:System.IO.Pipelines.PipeReader>. For Response writing, the <xref:Microsoft.AspNetCore.Http.HttpResponse.Body> is a <xref:System.IO.Stream> and <xref:Microsoft.AspNetCore.Http.HttpResponse.BodyPipe> is <xref:System.IO.Pipelines.PipeWriter>.

## Choosing between Streams and Pipes

### Stream examples
The following sample demonstrates how to read the request body. Let's say we wanted to create a middleware which read the entire request body as a list of strings, splitting on new lines. A simple stream implementation may look like the following:

[!code-csharp[](request-response/samples/3.x/RequestResponseSample/Startup.cs?name=GetListOfStringsFromStream)]

This example may work, but there are a lot of issues:
- Before appending to the StringBuilder, we create another string `encodedString` that will be thrown away immediately. As this occurs for all bytes in the stream, in total we allocate an extra string as long as the request body.
- Splitting on new lines after obtaining the entire string can be optimized to check for new lines in the byte array.

Let's take another shot at implementing this with streams. Here is another example that fixes a few issues the previous implementation had.

[!code-csharp[](request-response/samples/3.x/RequestResponseSample/Startup.cs?name=GetListOfStringsFromStreamMoreEfficient)]

This sample fixes a few issues, including not buffering the entire request body in a StringBuilder unless there aren't any new line characters. It also doesn't call Split on the string.

However, there are still are a few issues:
- If there are a very sparse number of new line characters in the string, we will be buffering a good portion of the string in the string buffer.
- It still creates string and then adds them to the StringBuffer, which still does an extra allocation.

Despite some of these optimizations being feasible things to fix, the examples are becoming more and more complicated without much improvement. Let's take a different approach by using Pipelines.

### Pipelines

Instead of reading from a Stream, we will now be reading from a PipeReader. Let's look at this approach using a PipeReader. 

[!code-csharp[](request-response/samples/3.x/RequestResponseSample/Startup.cs?name=GetListOfStringsFromStreamMoreEfficient)]

This improves many issues that the previous implementation had:
- Buffering bytes that haven't been used is now handled by the PipeReader, removing the need to have a StringBuffer.
- Encoded strings are directly added to the list of returned strings.
- String creation is allocation free besides the memory used by the string (except the ToArray()) call.

### Why would you still use Streams?

Streams are still a fundamental construct used in all of .NET. They aren't going away. For simple operations, Streams can be easier to use than Pipelines. Also, many Stream types don't have Pipe equivalents, like FileStreams and ResponseCompression.

### For middleware authors. 

If you are writing a middleware that requires reading or writing the request/response body, we recommend using Pipes. There will be a significant performance gain and it should be easier to have correctness. 

### For normal users

Most users will not need to directly read/write the request/response body; it will be abstracted by MVC/Razor Pages in ASP.NET Core. Do note that many of our internal classes, like FormReader and TextReader/Writers will transition to start using Pipelines internally.

Also, HttpResponse.WriteAsync will use Pipelines internally.

### Adapters

Now that a user can use both the Body and BodyPipe to read/write, what happens when you set the Body to a different Stream? In 3.0, we are introducing a set of adapters which will automatically adapt each type to the other. For example, if we set the HttpRequest.Body to a new Stream, HttpRequest.BodyPipe will automatically be set to a new PipeReader which wraps the HttpRequest.Body. The same behavior applies to setting the BodyPipe, if the HttpResponse.BodyPipe is set to a new PipeWriter, the HttpResponse.Body will automatically be set to a new Stream which wrapps HttpResponse.BodyPipe.

### StartAsync
<xref:Microsoft.AspNetCore.Http.HttpResponse.StartAsync> is a new API on the HttpResponse. It is used to indicate that headers are unmodifiable and to run OnStarting callbacks. In 3.0-preview3, it is required to call StartAsync before using the <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyPipe>, and in future releases, it will be a recommendation. When using Kestrel as a server, by calling StartAsync before using the PipeReader, it guarantees the memory returned by GetMemory will belong to Kestrel's internal <xref:System.IO.Pipelines.Pipe> rather than an external buffer.

## Additional resources
* [Introducing System.IO.Pipelines](https://devblogs.microsoft.com/dotnet/system-io-pipelines-high-performance-io-in-net/)