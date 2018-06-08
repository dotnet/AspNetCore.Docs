---
title: Use streaming in ASP.NET Core SignalR
author: rachelappel
description: 
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 06/07/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/streaming
---

# Use streaming in ASP.NET Core SignalR

By [Brennan Conroy](https://github.com/BrennanConroy)

Streaming is useful for scenarios when you don't have all the data to send to the client yet, but will get it over time and want to update the client whenever new data is available.

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/streaming/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Set up the hub

A hub method automatically becomes a streaming hub method when it returns a variant of `ChannelReader`. For example, return values of `ChannelReader<int>` and `Task<ChannelReader<string>>` are streaming methods. Below is a sample that shows the basics of streaming data to the client. Everytime data is written to the `ChannelReader` the client is notified of the new data. At the end, the `ChannelReader` is completed to tell the client the stream is closed.

[!code-javascript[Streaming hub method](streaming/sample/hubs/streamhub.cs?range=10-29)]

## .NET client

`StreamAsChannelAsync` on the `HubConnection` calls streaming methods on the hub. Pass the hub method name, and arguments defined in the hub method to `StreamAsChannelAsync`. Set the generic in `StreamAsChannelAsync` based on the type returned from the streaming method. A `ChannelReader<T>` is returned from the stream invocation, and represents the stream on the client. To read data, a common pattern is to loop over `WaitToReadAsync` and call `TryRead` when data is available. The loop will end when the stream has been closed by the server, or the cancellation token passed to `StreamAsChannelAsync` is canceled.

```csharp
var channel = await hubConnection.StreamAsChannelAsync<int>("Counter", 10, 500, CancellationToken.None);
while (await channel.WaitToReadAsync())
{
    while (channel.TryRead(out var count))
    {
        Console.WriteLine($"{count}");
    }
}

Console.WriteLine("Streaming completed");
```

## JavaScript client

JavaScript clients call streaming methods on hubs by using `connection.stream`. The `stream` method accepts two arguments:

* The name of the hub method. In the following example, the hub method name is `Counter`.
* Arguments defined in the hub method. In the following example, the arguments are: a count for the number of stream items to receive, and the delay between stream items.

`connection.stream` returns an `IStreamResult` which contains a `subscribe` method. Pass an `IStreamSubscriber` to `subscribe` and set the `next`, `error`, and `complete` callbacks to get notifications from the `stream` invocation.

[!code-javascript[Streaming javascript](streaming/sample/wwwroot/js/stream.js?range=16-32)]

To end the stream from the client call the `dispose` method on the `ISubscription` that is returned from the `subscribe` method.

## Related resources

* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [JavaScript client](xref:signalr/javascript-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)