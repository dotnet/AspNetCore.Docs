---
title: ASP.NET Core Blazor advanced scenarios
author: guardrex
description: Learn about advanced scenarios in Blazor, including how to incorporate manual RenderTreeBuilder logic into an app.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/18/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/advanced-scenarios
---
# ASP.NET Core Blazor advanced scenarios

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

## Blazor Server circuit handler

Blazor Server allows code to define a *circuit handler*, which allows running code on changes to the state of a user's circuit. A circuit handler is implemented by deriving from `CircuitHandler` and registering the class in the app's service container. The following example of a circuit handler tracks open SignalR connections:

```csharp
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;

public class TrackingCircuitHandler : CircuitHandler
{
    private HashSet<Circuit> circuits = new HashSet<Circuit>();

    public override Task OnConnectionUpAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        circuits.Add(circuit);

        return Task.CompletedTask;
    }

    public override Task OnConnectionDownAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        circuits.Remove(circuit);

        return Task.CompletedTask;
    }

    public int ConnectedCircuits => circuits.Count;
}
```

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
}
```

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the Blazor Server circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception.

## Manual RenderTreeBuilder logic

<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> provides methods for manipulating components and elements, including building components manually in C# code.

> [!NOTE]
> Use of <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> to create components is an advanced scenario. A malformed component (for example, an unclosed markup tag) can result in undefined behavior.

Consider the following `PetDetails` component, which can be manually built into another component:

```razor
<h2>Pet Details Component</h2>

<p>@PetDetailsQuote</p>

@code
{
    [Parameter]
    public string PetDetailsQuote { get; set; }
}
```

In the following example, the loop in the `CreateComponent` method generates three `PetDetails` components. When calling <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods to create the components (`OpenComponent` and `AddAttribute`), sequence numbers are source code line numbers. The Blazor difference algorithm relies on the sequence numbers corresponding to distinct lines of code, not distinct call invocations. When creating a component with <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods, hardcode the arguments for sequence numbers. **Using a calculation or counter to generate the sequence number can lead to poor performance.** For more information, see the [Sequence numbers relate to code line numbers and not execution order](#sequence-numbers-relate-to-code-line-numbers-and-not-execution-order) section.

`BuiltContent` component:

```razor
@page "/BuiltContent"

<h1>Build a component</h1>

@CustomRender

<button type="button" @onclick="RenderComponent">
    Create three Pet Details components
</button>

@code {
    private RenderFragment CustomRender { get; set; }
    
    private RenderFragment CreateComponent() => builder =>
    {
        for (var i = 0; i < 3; i++) 
        {
            builder.OpenComponent(0, typeof(PetDetails));
            builder.AddAttribute(1, "PetDetailsQuote", "Someone's best friend!");
            builder.CloseComponent();
        }
    };    
    
    private void RenderComponent()
    {
        CustomRender = CreateComponent();
    }
}
```

> [!WARNING]
> The types in <xref:Microsoft.AspNetCore.Components.RenderTree> allow processing of the *results* of rendering operations. These are internal details of the Blazor framework implementation. These types should be considered *unstable* and subject to change in future releases.

### Sequence numbers relate to code line numbers and not execution order

Razor component files (*.razor*) are always compiled. Compilation is a potential advantage over interpreting code because the compile step can be used to inject information that improves app performance at runtime.

A key example of these improvements involves *sequence numbers*. Sequence numbers indicate to the runtime which outputs came from which distinct and ordered lines of code. The runtime uses this information to generate efficient tree diffs in linear time, which is far faster than is normally possible for a general tree diff algorithm.

Consider the following Razor component (*.razor*) file:

```razor
@if (someFlag)
{
    <text>First</text>
}

Second
```

The preceding code compiles to something like the following:

```csharp
if (someFlag)
{
    builder.AddContent(0, "First");
}

builder.AddContent(1, "Second");
```

When the code executes for the first time, if `someFlag` is `true`, the builder receives:

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

Imagine that `someFlag` becomes `false`, and the markup is rendered again. This time, the builder receives:

| Sequence | Type       | Data   |
| :------: | ---------- | :----: |
| 1        | Text node  | Second |

When the runtime performs a diff, it sees that the item at sequence `0` was removed, so it generates the following trivial *edit script*:

* Remove the first text node.

### The problem with generating sequence numbers programmatically

Imagine instead that you wrote the following render tree builder logic:

```csharp
var seq = 0;

if (someFlag)
{
    builder.AddContent(seq++, "First");
}

builder.AddContent(seq++, "Second");
```

Now, the first output is:

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

This outcome is identical to the prior case, so no negative issues exist. `someFlag` is `false` on the second rendering, and the output is:

| Sequence | Type      | Data   |
| :------: | --------- | ------ |
| 0        | Text node | Second |

This time, the diff algorithm sees that *two* changes have occurred, and the algorithm generates the following edit script:

* Change the value of the first text node to `Second`.
* Remove the second text node.

Generating the sequence numbers has lost all the useful information about where the `if/else` branches and loops were present in the original code. This results in a diff **twice as long** as before.

This is a trivial example. In more realistic cases with complex and deeply nested structures, and especially with loops, the performance cost is usually higher. Instead of immediately identifying which loop blocks or branches have been inserted or removed, the diff algorithm has to recurse deeply into the render trees. This usually results in having to build longer edit scripts because the diff algorithm is misinformed about how the old and new structures relate to each other.

### Guidance and conclusions

* App performance suffers if sequence numbers are generated dynamically.
* The framework can't create its own sequence numbers automatically at runtime because the necessary information doesn't exist unless it's captured at compile time.
* Don't write long blocks of manually-implemented <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic. Prefer *.razor* files and allow the compiler to deal with the sequence numbers. If you're unable to avoid manual <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic, split long blocks of code into smaller pieces wrapped in <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenRegion%2A>/<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseRegion%2A> calls. Each region has its own separate space of sequence numbers, so you can restart from zero (or any other arbitrary number) inside each region.
* If sequence numbers are hardcoded, the diff algorithm only requires that sequence numbers increase in value. The initial value and gaps are irrelevant. One legitimate option is to use the code line number as the sequence number, or start from zero and increase by ones or hundreds (or any preferred interval). 
* Blazor uses sequence numbers, while other tree-diffing UI frameworks don't use them. Diffing is far faster when sequence numbers are used, and Blazor has the advantage of a compile step that deals with sequence numbers automatically for developers authoring *.razor* files.

## Perform large data transfers in Blazor Server apps

In some scenarios, large amounts of data must be transferred between JavaScript and Blazor. Typically, large data transfers occur when:

* Browser file system APIs are used to upload or download a file.
* Interop with a third party library is required.

In Blazor Server, a limitation is in place to prevent passing single large messages that may result in performance issues.

Consider the following guidance when developing code that transfers data between JavaScript and Blazor:

* Slice the data into smaller pieces, and send the data segments sequentially until all of the data is received by the server.
* Don't allocate large objects in JavaScript and C# code.
* Don't block the main UI thread for long periods when sending or receiving data.
* Free any memory consumed when the process is completed or cancelled.
* Enforce the following additional requirements for security purposes:
  * Declare the maximum file or data size that can be passed.
  * Declare the minimum upload rate from the client to the server.
* After the data is received by the server, the data can be:
  * Temporarily stored in a memory buffer until all of the segments are collected.
  * Consumed immediately. For example, the data can be stored immediately in a database or written to disk as each segment is received.

The following file uploader class handles JS interop with the client. The uploader class uses JS interop to:

* Poll the client to send a data segment.
* Abort the transaction if polling times out.

```csharp
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.JSInterop;

public class FileUploader : IDisposable
{
    private readonly IJSRuntime jsRuntime;
    private readonly int segmentSize = 6144;
    private readonly int maxBase64SegmentSize = 8192;
    private readonly DotNetObjectReference<FileUploader> thisReference;
    private List<IMemoryOwner<byte>> uploadedSegments = 
        new List<IMemoryOwner<byte>>();

    public FileUploader(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    public async Task<Stream> ReceiveFile(string selector, int maxSize)
    {
        var fileSize = 
            await jsRuntime.InvokeAsync<int>("getFileSize", selector);

        if (fileSize > maxSize)
        {
            return null;
        }

        var numberOfSegments = Math.Floor(fileSize / (double)segmentSize) + 1;
        var lastSegmentBytes = 0;
        string base64EncodedSegment;

        for (var i = 0; i < numberOfSegments; i++)
        {
            try
            {
                base64EncodedSegment = 
                    await jsRuntime.InvokeAsync<string>(
                        "receiveSegment", i, selector);

                if (base64EncodedSegment.Length < maxBase64SegmentSize && 
                    i < numberOfSegments - 1)
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

          var current = MemoryPool<byte>.Shared.Rent(segmentSize);

          if (!Convert.TryFromBase64String(base64EncodedSegment, 
              current.Memory.Slice(0, segmentSize).Span, out lastSegmentBytes))
          {
              return null;
          }

          uploadedSegments.Add(current);
        }

        var segments = uploadedSegments;
        uploadedSegments = null;

        return new SegmentedStream(segments, segmentSize, lastSegmentBytes);
    }

    public void Dispose()
    {
        if (uploadedSegments != null)
        {
            foreach (var segment in uploadedSegments)
            {
                segment.Dispose();
            }
        }
    }
}
```

In the preceding example:

* The `maxBase64SegmentSize` is set to `8192`, which is calculated from `maxBase64SegmentSize = segmentSize * 4 / 3`.
* Low-level .NET Core memory management APIs are used to store the memory segments on the server in `uploadedSegments`.
* A `ReceiveFile` method is used to handle the upload through JS interop:
  * The file size is determined in bytes through JS interop with `jsRuntime.InvokeAsync<FileInfo>('getFileSize', selector)`.
  * The number of segments to receive are calculated and stored in `numberOfSegments`.
  * The segments are requested in a `for` loop through JS interop with `jsRuntime.InvokeAsync<string>('receiveSegment', i, selector)`. All segments but the last must be 8,192 bytes before decoding. The client is forced to send the data in an efficient manner.
  * For each segment received, checks are performed before decoding with <xref:System.Convert.TryFromBase64String%2A>.
  * A stream with the data is returned as a new <xref:System.IO.Stream> (`SegmentedStream`) after the upload is complete.

The segmented stream class exposes the list of segments as a readonly non-seekable <xref:System.IO.Stream>:

```csharp
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;

public class SegmentedStream : Stream
{
    private readonly ReadOnlySequence<byte> sequence;
    private long currentPosition = 0;

    public SegmentedStream(IList<IMemoryOwner<byte>> segments, int segmentSize, 
        int lastSegmentSize)
    {
        if (segments.Count == 1)
        {
            sequence = new ReadOnlySequence<byte>(
                segments[0].Memory.Slice(0, lastSegmentSize));
            return;
        }

        var sequenceSegment = new BufferSegment<byte>(
            segments[0].Memory.Slice(0, segmentSize));
        var lastSegment = sequenceSegment;

        for (int i = 1; i < segments.Count; i++)
        {
            var isLastSegment = i + 1 == segments.Count;
            lastSegment = lastSegment.Append(segments[i].Memory.Slice(
                0, isLastSegment ? lastSegmentSize : segmentSize));
        }

        sequence = new ReadOnlySequence<byte>(
            sequenceSegment, 0, lastSegment, lastSegmentSize);
    }

    public override long Position
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        var bytesToWrite = (int)(currentPosition + count < sequence.Length ? 
            count : sequence.Length - currentPosition);
        var data = sequence.Slice(currentPosition, bytesToWrite);
        data.CopyTo(buffer.AsSpan(offset, bytesToWrite));
        currentPosition += bytesToWrite;

        return bytesToWrite;
    }

    private class BufferSegment<T> : ReadOnlySequenceSegment<T>
    {
        public BufferSegment(ReadOnlyMemory<T> memory)
        {
            Memory = memory;
        }

        public BufferSegment<T> Append(ReadOnlyMemory<T> memory)
        {
            var segment = new BufferSegment<T>(memory)
            {
                RunningIndex = RunningIndex + Memory.Length
            };

            Next = segment;

            return segment;
        }
    }

    public override bool CanRead => true;

    public override bool CanSeek => false;

    public override bool CanWrite => false;

    public override long Length => throw new NotImplementedException();

    public override void Flush() => throw new NotImplementedException();

    public override long Seek(long offset, SeekOrigin origin) => 
        throw new NotImplementedException();

    public override void SetLength(long value) => 
        throw new NotImplementedException();

    public override void Write(byte[] buffer, int offset, int count) => 
        throw new NotImplementedException();
}
```

The following code implements JavaScript functions to receive the data:

```javascript
function getFileSize(selector) {
  const file = getFile(selector);
  return file.size;
}

async function receiveSegment(segmentNumber, selector) {
  const file = getFile(selector);
  var segments = getFileSegments(file);
  var index = segmentNumber * 6144;
  return await getNextChunk(file, index);
}

function getFile(selector) {
  const element = document.querySelector(selector);
  if (!element) {
    throw new Error('Invalid selector');
  }
  const files = element.files;
  if (!files || files.length === 0) {
    throw new Error(`Element ${elementId} doesn't contain any files.`);
  }
  const file = files[0];
  return file;
}

function getFileSegments(file) {
  const segments = Math.floor(size % 6144 === 0 ? size / 6144 : 1 + size / 6144);
  return segments;
}

async function getNextChunk(file, index) {
  const length = file.size - index <= 6144 ? file.size - index : 6144;
  const chunk = file.slice(index, index + length);
  index += length;
  const base64Chunk = await this.base64EncodeAsync(chunk);
  return { base64Chunk, index };
}

async function base64EncodeAsync(chunk) {
  const reader = new FileReader();
  const result = new Promise((resolve, reject) => {
    reader.addEventListener('load',
      () => {
        const base64Chunk = reader.result;
        const cleanChunk = 
          base64Chunk.replace('data:application/octet-stream;base64,', '');
        resolve(cleanChunk);
      },
      false);
    reader.addEventListener('error', reject);
  });
  reader.readAsDataURL(chunk);
  return result;
}
```
