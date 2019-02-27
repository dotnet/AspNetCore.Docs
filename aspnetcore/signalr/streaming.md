---
title: Use streaming in ASP.NET Core SignalR
author: bradygaster
description: Learn how to return streams of values from server hub methods and consume the streams using the .NET and JavaScript clients.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 11/14/2018
uid: signalr/streaming
---

# Use streaming in ASP.NET Core SignalR

By [Brennan Conroy](https://github.com/BrennanConroy)

::: moniker range="< aspnetcore-3.0"

ASP.NET Core SignalR supports streaming return values of server methods. This is useful for scenarios where fragments of data will come in over time. When a return value is streamed to the client, each fragment is sent to the client as soon as it becomes available, rather than waiting for all the data to become available.

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

ASP.NET Core SignalR supports streaming from client to server and from server to client. This is useful for scenarios where fragments of data will come in over time. When streaming, each fragment is sent to the client or server as soon as it becomes available, rather than waiting for all the data to become available.

::: moniker-end

::: moniker range="= aspnetcore-2.1"

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/streaming/sample.netcoreapp2.1) ([how to download](xref:index#how-to-download-a-sample))

::: moniker-end

::: moniker range="= aspnetcore-2.2"

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/streaming/sample.netcoreapp2.2) ([how to download](xref:index#how-to-download-a-sample))

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/streaming/sample.netcoreapp3.0) ([how to download](xref:index#how-to-download-a-sample))

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

A hub method automatically becomes a streaming hub method when it returns a `ChannelReader<T>`, `IAsyncEnumerable<T>`, `Task<ChannelReader<T>>`, or `Task<IAsyncEnumerable<T>>`.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

A hub method automatically becomes a streaming hub method when it returns a `ChannelReader<T>` or a `Task<ChannelReader<T>>`.

::: moniker-end

## Set up the hub for streaming

### Server to client streaming

The following sample shows the basics of streaming data to the client using Channels. Whenever an object is written to the `ChannelWriter` that object is immediately sent to the client. At the end, the `ChannelWriter` is completed to tell the client the stream is closed.

> [!NOTE]
> * Write to the `ChannelWriter` on a background thread and return the `ChannelReader` as soon as possible. Other hub invocations will be blocked until a `ChannelReader` is returned.
> * Wrap your logic in a `try ... catch` and complete the `Channel` in the catch and outside the catch to make sure the hub method invocation is completed properly.

::: moniker range="= aspnetcore-2.1"

[!code-csharp[Streaming hub method](streaming/sample.netcoreapp2.1/Hubs/StreamHub.cs?name=snippet1)]

::: moniker-end

::: moniker range="= aspnetcore-2.2"

[!code-csharp[Streaming hub method](streaming/sample.netcoreapp2.2/Hubs/StreamHub.cs?name=snippet1)]

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[Streaming hub method](streaming/sample.netcoreapp3.0/Hubs/StreamHub.cs?name=snippet1)]

::: moniker-end

::: moniker range=">= aspnetcore-2.2"

In ASP.NET Core 2.2 or later, server to client streaming hub methods can accept a `CancellationToken` parameter that will be triggered when the client unsubscribes from the stream. Use this token to stop the server operation and release any resources if the client disconnects before the end of the stream.

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

In ASP.NET Core 3.0 or later, streaming hub methods can return `IAsyncEnumerable<T>` in addition to `ChannelReader<T>`. The simplest way to return `IAsyncEnumerable<T>` is by making the hub method an async iterator method as the following sample demonstrates. Hub async iterator methods can accept a `CancellationToken` parameter that will be triggered when the client unsubscribes from the stream. Async iterator methods easily avoid problems common with Channels such as not returning the `ChannelReader` early enough or exiting the method without completing the `ChannelWriter`.

[!INCLUDE[](~/includes/csharp-8-required.md)]

[!code-csharp[Streaming hub async iterator method](streaming/sample.netcoreapp3.0/Hubs/AsyncEnumerableHub.cs?name=snippet_AsyncIterator)]

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

### Client to server streaming

A hub method automatically becomes a client to server streaming hub method when it accepts a <xref:System.Threading.Channels.ChannelReader`1>. Below is a sample that shows the basics of reading streaming data from the client. Whenever the client writes to the stream the data is written into the `ChannelReader` on the server which the hub method should be reading from.

[!code-csharp[Streaming upload hub method](streaming/sample.netcoreapp3.0/Hubs/StreamHub.cs?name=snippet2)]

::: moniker-end

## .NET client

### Server to client streaming

The `StreamAsChannelAsync` method on `HubConnection` is used to invoke a server to client streaming method. Pass the hub method name, and arguments defined in the hub method to `StreamAsChannelAsync`. The generic parameter on `StreamAsChannelAsync<T>` specifies the type of objects returned by the streaming method. A `ChannelReader<T>` is returned from the stream invocation, and represents the stream on the client. To read data, a common pattern is to loop over `WaitToReadAsync` and call `TryRead` when data is available. The loop will end when the stream has been closed by the server, or the cancellation token passed to `StreamAsChannelAsync` is canceled.

::: moniker range=">= aspnetcore-2.2"

```csharp
// Call "Cancel" on this CancellationTokenSource to send a cancellation message to
// the server, which will trigger the corresponding token in the hub method.
var cancellationTokenSource = new CancellationTokenSource();
var channel = await hubConnection.StreamAsChannelAsync<int>(
    "Counter", 10, 500, cancellationTokenSource.Token);

// Wait asynchronously for data to become available
while (await channel.WaitToReadAsync())
{
    // Read all currently available data synchronously, before waiting for more data
    while (channel.TryRead(out var count))
    {
        Console.WriteLine($"{count}");
    }
}

Console.WriteLine("Streaming completed");
```

::: moniker-end

::: moniker range="= aspnetcore-2.1"

```csharp
var channel = await hubConnection
    .StreamAsChannelAsync<int>("Counter", 10, 500, CancellationToken.None);

// Wait asynchronously for data to become available
while (await channel.WaitToReadAsync())
{
    // Read all currently available data synchronously, before waiting for more data
    while (channel.TryRead(out var count))
    {
        Console.WriteLine($"{count}");
    }
}

Console.WriteLine("Streaming completed");
```

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

### Client to server streaming

To invoke a client to server streaming hub method from the .NET Client create a `Channel` and pass the `ChannelReader` as an argument to `SendAsync`, `InvokeAsync`, or `StreamAsChannelAsync`, depending on the hub method being invoked.

Whenever data is written to the `ChannelWriter` the hub method on the server will receive a new item with the data from the client.

To end the stream, complete the channel with `channel.Writer.TryComplete()`.

```csharp
var channel = Channel.CreateBounded<string>(10);
await connection.SendAsync("UploadStream", channel.Reader);
await channel.Writer.WriteAsync("some data");
await channel.Writer.WriteAsync("some more data");
await channel.Writer.TryComplete();
```

::: moniker-end

## JavaScript client

### Server to client streaming

JavaScript clients call server to client streaming methods on hubs by using `connection.stream`. The `stream` method accepts two arguments:

* The name of the hub method. In the following example, the hub method name is `Counter`.
* Arguments defined in the hub method. In the following example, the arguments are: a count for the number of stream items to receive, and the delay between stream items.

`connection.stream` returns an `IStreamResult` which contains a `subscribe` method. Pass an `IStreamSubscriber` to `subscribe` and set the `next`, `error`, and `complete` callbacks to get notifications from the `stream` invocation.

::: moniker range="= aspnetcore-2.1"

[!code-javascript[Streaming javascript](streaming/sample.netcoreapp2.1/wwwroot/js/stream.js?range=19-36)]

To end the stream from the client, call the `dispose` method on the `ISubscription` that is returned from the `subscribe` method.

::: moniker-end

::: moniker range=">= aspnetcore-2.2"

[!code-javascript[Streaming javascript](streaming/sample.netcoreapp2.2/wwwroot/js/stream.js?range=19-36)]

To end the stream from the client, call the `dispose` method on the `ISubscription` that is returned from the `subscribe` method. Calling this method will cause the `CancellationToken` parameter of the Hub method (if you provided one) to be canceled.

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

### Client to server streaming

JavaScript clients call client to server streaming methods on hubs by passing in a `Subject` as one of the arguments in `send`, `invoke`, or `stream`, depending on the hub method being invoked. The `Subject` needs to be a class that looks like a `Subject`. For example, if you use RxJS then you can use the `Subject` class from that library.

[!code-javascript[Upload javascript](streaming/sample.netcoreapp3.0/wwwroot/js/stream.js?range=74-84)]

Calling `subject.next(item)` with an item will write the item to the stream and the hub method will get the item on the server.

 To end the stream, call `subject.complete()`.

::: moniker-end

::: moniker range=">= aspnetcore-3.0"
## Java client

### Server to client streaming

The SignalR Java client uses the `stream` method to invoke streaming methods. It accepts three or more arguments:

* The expected type of the stream items
* The name of the hub method.
* Arguments defined in the hub method.

```java
hubConnection.stream(String.class, "ExampleStreamingHubMethod", "Arg1")
    .subscribe(
        (item) -> {/* Define your onNext handler here. */ },
        (error) -> {/* Define your onError handler here. */},
        () -> {/* Define your onCompleted handler here. */});
```

The `stream` method on `HubConnection` returns an Observable of the stream item type. The Observable type's `subscribe` method is where you define your `onNext`,  `onError` and  `onCompleted` handlers.

::: moniker-end

## Related resources

* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [JavaScript client](xref:signalr/javascript-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
