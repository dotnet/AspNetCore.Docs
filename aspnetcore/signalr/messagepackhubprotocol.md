---
title: Use MessagePack Hub Protocol in SignalR for ASP.NET Core
author: rachelappel
description: Add MessagePack Hub Protocol to ASP.NET Core SignalR.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 06/04/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/messagepackhubprotocol
---

# Use MessagePack Hub Protocol in SignalR for ASP.NET Core

By [Brennan Conroy](https://github.com/BrennanConroy)

This article assumes the reader is familiar with the topics covered in [Get Started](xref:signalr/get-started).

## What is MessagePack?

[MessagePack](https://msgpack.org/index.html) is a binary serialization format that is fast and compact. It's useful when performance and bandwidth are a concern because it creates smaller packets compared to [JSON](https://www.json.org/). Because it's a binary format, messages are unreadable when looking at network traces and logs unless the bytes are passed through a MessagePack parser. SignalR has added built-in support for the MessagePack format, and provides APIs for the client and server to use.

## Configure MessagePack on the server

To enable the MessagePack Hub Protocol on the server, install the `Microsoft.AspNetCore.SignalR.Protocols.MessagePack` package in your app. Add `AddMessagePackProtocol` to the `AddSignalR` call to enable MessagePack support on the server.

> [!NOTE]
> Json is enabled by default. Adding MessagePack enables support for both JSON and MessagePack clients.

```csharp
services.AddSignalR()
    .AddMessagePackProtocol();
```

To customize how MessagePack will format your data, `AddMessagePackProtocol` takes a Func for configuring options. A property named `FormatterResolvers` is exposed in the options. The `FormatterResolvers` is a list of resolvers that are used by MessagePack to determine the format messages will be in. For more information on how the resolvers work, visit the MessagePack library at [MessagePack-CSharp](https://github.com/neuecc/MessagePack-CSharp). Attributes can be used on the objects you want to serialize to define how they should be handled.

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

## Configure MessagePack on the client

### .NET client

To enable MessagePack in the .NET Client, install the `Microsoft.AspNetCore.SignalR.Protocols.MessagePack` package and call `AddMessagePackProtocol` on `HubConnectionBuilder`.

```csharp
var hubConnection = new HubConnectionBuilder()
                        .WithUrl("/chatHub")
                        .AddMessagePackProtocol()
                        .Build();
```

### JavaScript client

MessagePack support for the Javascript client is provided by the `@aspnet/signalr-protocol-msgpack` NPM package.

```console
npm install @aspnet/signalr-protocol-msgpack
```

After installing the npm package, the module can be used directly via a JavaScript module loader or imported into the browser by referencing the *node_modules\\@aspnet\signalr-protocol-msgpack\dist\browser\signalr-protocol-msgpack.js* file. When using the MessagePack library via a browser `<script>` tag, the msgpack5 library must be referenced directly as well, it can be found in the *node_modules\msgpack5\dist\msgpack5.js* file.

When using the `<script>` element, the order is important. If *signalr-protocol-msgpack.js* is referenced before *msgpack5.js*, an error occurs when trying to connect with MessagePack.

```html
<script src="~/lib/signalr/signalr.js"></script>
<script src="~/lib/msgpack5/msgpack5.js"></script>
<script src="~/lib/signalr/signalr-protocol-msgpack.js"></script>
```

Adding `.withHubProtocol(new signalR.protocols.msgpack.MessagePackHubProtocol())` to the `HubConnectionBuilder` will configure the client to use the MessagePack protocol when connecting to a server.

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
