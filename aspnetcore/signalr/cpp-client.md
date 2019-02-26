---
title: ASP.NET Core SignalR C++ Client
author: bradygaster
description: Information about the ASP.NET Core SignalR C++ Client
monikerRange: '>= aspnetcore-3.0'
ms.author: bradyg
ms.custom: mvc
ms.date: 2/26/2019
uid: signalr/cpp-client
---

# ASP.NET Core SignalR C++ Client

The ASP.NET Core SignalR C++ client library lets you communicate with SignalR hubs from native apps.

## Build the SignalR C++ client library

TODO

## Connect to a hub

```c++
signalr::hub_connection connection("http://localhost:5000/default", signalr::trace_level::all);
connection.start().get();
```

## Call hub methods from client

```c++
connection.send("Echo").get();
auto value = connection.invoke("Echo").get();
```
`invoke` calls methods on the hub and waits for a response. Pass the hub method name and any arguments defined in the hub method to `invoke`.
`send` calls methods on the hub and does not expect a response. Pass the hub method name and any arguments defined in the hub method to `invoke`.

[!code-csharp[InvokeAsync method](dotnet-client/sample/signalrchatclient/MainWindow.xaml.cs?name=snippet_InvokeAsync)]

## Call client methods from hub

Define methods the hub calls using `connection.On` after creating the connection, but before starting it.
```c++
connection.on("Send", [](const web::json::value& m)
{
    std::cout << m.at(0).as_string() << std::endl;
});
```

The registered handler in `connection.On` runs when server-side code calls it using the `SendAsync` method.

## Additional resources

* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
