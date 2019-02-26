---
title: Request and Response operations in ASP.NET Core
author: jkotalik
description: Learn how to get started with WebSockets in ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: tdykstra
ms.custom: mvc
ms.date: 02/26/2019
uid: fundamentals/request-response
---
# Request and response operations in ASP.NET Core

By [Justin Kotalik](https://github.com/jkotalik)

This article explains how to read from the HttpRequest Body and write to the HttpResponse Body.

In ASP.NET Core 3.0, there are two abstractions for the HttpRequest and Response bodies: <xref:System.IO.Stream> and <xref:System.IO.Pipelines.Pipe>. For Request reading, the <xref:Microsoft.AspNetCore.Http.HttpRequest.Body> is a <xref:System.IO.Stream> and <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyPipe> is <xref:System.IO.Pipelines.PipeReader>. For Response writing, the <xref:Microsoft.AspNetCore.Http.HttpResponse.Body> is a <xref:System.IO.Stream> and <xref:Microsoft.AspNetCore.Http.HttpResponse.BodyPipe> is <xref:System.IO.Pipelines.PipeWriter>.

## How to Read and Write to the Request and Response bodies

Below are examples of common usage patterns for reading and writing.
### Streams

```csharp
public class MyTerminalMiddleware
{
    public async Task InvokeAsync(HttpContext context)
    {
        Memory<byte> buffer = new Memory<byte>(new byte[4096]);
        var length = await context.Request.Body.ReadAsync(buffer);

        await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello World"));
    }
}
```

Benefits:
- Still used by a majority of .NET APIs.
Downsides:
- Reading forces the middleware to allocate memory for the stream to read into. 

### Pipelines

```csharp
public class MyTerminalMiddleware
{
    public async Task InvokeAsync(HttpContext context)
    {
        ReadResult readResult = await context.Request.BodyPipe.ReadAsync();
        ReadOnlySequence<byte> buffer = readResult.Buffer;
        context.Request.BodyPipe.AdvanceTo(buffer.End);

        await context.Response.StartAsync();

        var helloWorldResponse = Encoding.UTF8.GetBytes("Hello World");

        var memory = context.Response.BodyPipe.GetMemory();
        helloWorldResponse.CopyTo(memory);
        context.Response.BodyPipe.Advance(helloWorldResponse.Length);
        await context.Response.BodyPipe.FlushAsync();
    }
}
```

```csharp
public class MyTerminalMiddleware
{
    public async Task InvokeAsync(HttpContext context)
    {
        var helloWorldResponse = Encoding.UTF8.GetBytes("Hello World");

        await context.Response.BodyPipe.WriteAsync(Encoding.UTF8.GetBytes("Hello World"));
    }
}
```

Benefits
- Better performance (don't need to allocate a buffer for each read call)

## StartAsync
<xref:Microsoft.AspNetCore.Http.HttpResponse.StartAsync> is a new API on the HttpResponse. It is used to indicate that headers are unmodifiable and to run OnStarting callbacks. In 3.0-preview3, it is required to call StartAsync before using the <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyPipe>, and in future releases, it will be a recommendation. When using Kestrel as a server, by calling StartAsync before using the PipeReader, it guarantees the memory returned by GetMemory will belong to Kestrel's internal <xref:System.IO.Pipelines.Pipe> rather than an external buffer.

## Additional resources
* [Introducing System.IO.Pipelines](https://devblogs.microsoft.com/dotnet/system-io-pipelines-high-performance-io-in-net/)