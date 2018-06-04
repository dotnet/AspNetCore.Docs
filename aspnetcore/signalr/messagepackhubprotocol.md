---
title: Use MessagePack Hub Protocol in SignalR for ASP.NET Core
author: 
description: Learn how to add MessagePack Hub Protocol to ASP.NET Core SignalR.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: 
ms.custom: mvc
ms.date: 06/04/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/messagepack
---

# Use MessagePack Hub Protocol in SignalR for ASP.NET Core

This article assumes the reader is familiar with the topics covered in [Get Started](xref:signalr/get-started).

## What is MessagePack

MessagePack is a binary serialization format that is fast and compact. It is useful when performance and bandwidth are a concern because it creates smaller packets compared to JSON. Because it is a binary format, it will be unreadable when looking at network traces and logs unless you pass the bytes through a MessagePack parser. You can see more information about the format at https://msgpack.org/index.html. SignalR has added built-in support for the MessagePack format and added APIs for the client and server to use.

## Configure MessagePack on the Server

To enable the MessagePack Hub Protocol on the server you will first need to install the `Microsoft.AspNetCore.SignalR.Protocols.MessagePack` package in your app. Next add `.AddMessagePackProtocol()` to the  `AddSignalR()` call and now the server will support MessagePack.

> [!NOTE]
> Json is supported by default, adding MessagePack is addative so both will be supported at the same time.

```csharp
services.AddSignalR()
    .AddMessagePackProtocol();
```

If you want to customize how MessagePack will format your data `.AddMessagePackProtocol()` takes a func for configuring options. A property named `FormatterResolvers` is exposed in the options and this is a list of resolvers that are used by MessagePack to determine the format your messages will be in. For more information on how the resolvers work visit the MessagePack library we use at [MessagePack-CSharp](https://github.com/neuecc/MessagePack-CSharp). Or you can use attributes on the objects you want to serialize to define how they should be handled.

```csharp
services.AddSignalR()
    .AddMessagePackProtocol(options =>
    {
        options.FormatterResolvers = new List<MessagePack.IFormatterResolver>()
        {
            MessagePack.Resolvers.StandardResolver.Instance
        };
    });
```

## Configure MessagePack on the Client

### C# Client

The C# Client will also need to install the `Microsoft.AspNetCore.SignalR.Protocols.MessagePack` package to get support for MessagePack. On the `HubConnectionBuilder` add the `.AddMessagePackProtocol()` call.

```csharp
var hubConnection = new HubConnectionBuilder()
                        .WithUrl("/chatHub")
                        .AddMessagePackProtocol()
                        .Build();
```

### JavaScript Client

The MessagePack javascript support is in a separate npm package from the base `@aspnet/signalr` package.

```console
npm install @aspnet/signalr-protocol-msgpack
```

Npm installs the package contents in the *node_modules\\@aspnet\signalr-protocol-msgpack\dist\browser* folder. It also has a dependency on the `msgpack5` npm package which will be installed at *node_modules\msgpack5\dist*. Copy the *signalr-protocol-msgpack.js* file to the *wwwroot\lib\signalr* folder and the *msgpack5.js* file to the *wwwroot\lib\msgpack5* folder.

Reference the javascript files with the `<script>` element. Order is important here, if *signalr-protocol-msgpack.js* is referenced before *msgpack5.js* then you will get an error when trying to connect with MessagePack.

```html
<script src="~/lib/signalr/signalr.js"></script>
<script src="~/lib/msgpack5/msgpack5.js"></script>
<script src="~/lib/signalr/signalr-protocol-msgpack.js"></script>
```

Adding `.withHubProtocol(new signalR.protocols.msgpack.MessagePackHubProtocol())` to the `HubConnectionBuilder` will tell the client that it should use MessagePack when connecting to a server.

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .withHubProtocol(new signalR.protocols.msgpack.MessagePackHubProtocol())
    .build();
```

## Related resources

* [Get Started](xref:signalr/get-started)
* [.NET client](xref:signalr/dotnet-client)
* [JavaScript client](xref:signalr/javascript-client)
