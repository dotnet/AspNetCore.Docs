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

Streaming is a way for clients to subscribe to a stream of data from the server on demand.

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/streaming/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Set up the hub

A hub method automatically becomes a streaming hub method when it returns a variant of `ChannelReader`. For example, return values of `ChannelReader<int>` and `Task<ChannelReader<string>>` are streaming methods. Streaming is useful for scenarios when you don't have all the data to send to the client yet, but will be getting it over time and would like to update the client whenever new data is available. Below is a sample that shows the basics of streaming data to the client. Everytime data is written to the `ChannelReader` the client will be notified of the new data and at the end the `ChannelReader` is completed to tell the client that the stream is closed.

[!code-javascript[Streaming hub method](streaming/sample/hubs/streamhub.cs?range=10-29)]

## .NET client

`StreamAsChannelAsync` on the `HubConnection` calls streaming methods on the hub. Pass the hub method name and any arguments defined in the hub method to `StreamAsChannelAsync`. Set the generic in `StreamAsChannelAsync` based on the type returned from the streaming method. A `ChannelReader<T>` is returned from the stream invocation and represents the stream on the client. To read data, a common pattern is to loop over `WaitToReadAsync` and call `TryRead` when data is available. The loop will end when the stream has been closed by the server or the cancellation token passed to `StreamAsChannelAsync` is canceled.

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

* The name of the hub method. In the following example, the hub name is `Counter`.
* Any arguments defined in the hub method. In the following example, the arguments are, a count for the number of stream items to receive and the delay between stream items.

`connection.stream` returns an `IStreamResult` which has a method `subscribe` on it. Pass an `IStreamSubscriber` to `subscribe` and set the `next`, `error`, and `complete` callbacks to get notifications from the `stream` invocation.

[!code-javascript[Streaming javascript](streaming/sample/wwwroot/js/stream.js?range=16-32)]

## Related resources

* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [JavaScript client](xref:signalr/javascript-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)