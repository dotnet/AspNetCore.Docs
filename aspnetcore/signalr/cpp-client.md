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

The ASP.NET Core SignalR C++ client library lets you communicate with SignalR hubs from native applications.

## Consume the SignalR C++ client library

TODO

## Connect to a hub

```c++
signalr::hub_connection connection("http://localhost:5000/default", signalr::trace_level::all);
connection.start().get();
```

## Handle lost connection

Register a handler for the disconnected event to respond to a lost connection. For example, you might want to automate reconnection.

The disconnected event can be registered by calling `set_disconnected` and passing in a function;

```c++
connection.set_disconnected([]()
{
    // Do your close logic.
});
```

## Call hub methods from client

`connection.send` calls methods on the hub and does not expect or wait for a response.
```c++
web::json::value args{};
args[0] = web::json::value::string("some text");
connection.send("Echo", args).get();
```

`connection.invoke` calls methods on the hub and waits for a response.
```c++
web::json::value args{};
args[0] = web::json::value::string("some text");
connection.invoke("Echo", args)
    .then([](const web::json::value& value)
    {
        ucout << value.serialize() << std::endl;
    }).get();
```

Pass the hub method name and any arguments defined in the hub method to `invoke` or `send`.

## Call client methods from hub

Define methods the hub calls using `connection.on` after creating the connection, but before starting it. The `web::json::value` parameter will be an array of values sent from the server.
```c++
connection.on("ReceiveMessage", [](const web::json::value& m)
{
    ucout << m.at(0).as_string() << m.at(1).as_string() std::endl;
});
```

The preceding code in `connection.on` runs when server-side code calls it using the `SendAsync` method.

[!code-csharp[Call client method](dotnet-client/sample/signalrchat/hubs/chathub.cs?name=snippet_SendMessage)]

## Custom logging

To add logging to the client create a class that inherits from `signalr::log_writer` and add a `write` method that overrides the pure virtual base class.

```c++
class custom_logger : public signalr::log_writer
{
    virtual void write(const utility::string_t& log) override
    {
        ucout << log << std::endl;
    }
}
```

Then when creating the hub_connection pass a `shared_ptr<custom_logger>` into the constructor.

```c++
signalr::hub_connection connection("http://localhost:5000/default", signalr::trace_level::all, std::make_shared<custom_logger>());
```

## Additional resources

* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
