---
title: ASP.NET Core SignalR .NET Client
author: tdykstra
description: Information about the ASP.NET Core SignalR .NET Client
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 08/07/2018
uid: signalr/dotnet-client
---

# ASP.NET Core SignalR .NET Client

By [Rachel Appel](http://twitter.com/rachelappel)

The ASP.NET Core SignalR .NET client can be used by Xamarin, WPF, Windows Forms, Console, and .NET Core apps. Like the [JavaScript client](xref:signalr/javascript-client), the .NET client enables you to receive and send and receive messages to a hub in real time.

> [!NOTE]
> Xamarin has special requirements for Visual Studio version. For more information, see [SignalR Client 2.1.1 in Xamarin](https://github.com/aspnet/Announcements/issues/305).

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/dotnet-client/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The code sample in this article is a WPF app that uses the ASP.NET Core SignalR .NET client.

## Install the SignalR .NET client package

The `Microsoft.AspNetCore.SignalR.Client` package is needed for .NET clients to connect to SignalR hubs. To install the client library, run the following command in the **Package Manager Console** window:

```powershell
Install-Package Microsoft.AspNetCore.SignalR.Client
```

## Connect to a hub

To establish a connection, create a `HubConnectionBuilder` and call `Build`. The hub URL, protocol, transport type, log level, headers, and other options can be configured while building a connection. Configure any required options by inserting any of the `HubConnectionBuilder` methods into `Build`. Start the connection with `StartAsync`.

[!code-csharp[Build hub connection](dotnet-client/sample/signalrchatclient/MainWindow.xaml.cs?highlight=15-17,33)]

## Call hub methods from client

`InvokeAsync` calls methods on the hub. Pass the hub method name and any arguments defined in the hub method to `InvokeAsync`. SignalR is asynchronous, so use `async` and `await` when making the calls.

[!code-csharp[InvokeAsync method](dotnet-client/sample/signalrchatclient/MainWindow.xaml.cs?range=48-49)]

## Call client methods from hub

Define methods the hub calls using `connection.On` after building, but before starting the connection.

[!code-csharp[Define client methods](dotnet-client/sample/signalrchatclient/MainWindow.xaml.cs?range=22-29)]

The preceding code in `connection.On` runs when server-side code calls it using the `SendAsync` method.

[!code-csharp[Call client method](dotnet-client/sample/signalrchat/hubs/chathub.cs?range=8-11)]

## Error handling and logging

Handle errors with a try-catch statement. Inspect the `Exception` object to determine the proper action to take after an error occurs.

[!code-csharp[Logging](dotnet-client/sample/signalrchatclient/MainWindow.xaml.cs?range=46-54)]

## Additional resources

* [Hubs](xref:signalr/hubs)
* [JavaScript client](xref:signalr/javascript-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
