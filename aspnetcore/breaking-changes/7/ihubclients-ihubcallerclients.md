---
title: "Breaking change: IHubClients and IHubCallerClients hide members"
description: Learn about the breaking change in ASP.NET Core 7.0 where IHubClients and IHubCallerClients hide two interface members.
ms.date: 06/22/2022
ms.custom: https://github.com/aspnet/Announcements/issues/487
---
# IHubClients and IHubCallerClients hide members

To add support for client results, <xref:Microsoft.AspNetCore.SignalR.IHubClients> and <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients> now hide interface members `IClientProxy Client(string connectionId);` and `IClientProxy Caller { get; }` with `ISingleClientProxy Client(string connectionId);` and `ISingleClientProxy Caller { get; }`.

This is not a breaking change to production code unless you use reflection to call the affected `Client` or `Caller` methods. You may need to update unit testing SignalR Hubs.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

When using a testing library like Moq to unit test a SignalR Hub, you could write code similar to the following:

```csharp
var hub = new MyHub();
var mockCaller = new Mock<IHubCallerClients>();
var mockClientProxy = new Mock<IClientProxy>();
mockCaller.Setup(x => x.Caller).Returns(mockClientProxy.Object);
hub.Clients = mockCaller.Object;

class MyHub : Hub { }
```

## New behavior

```csharp
var hub = new MyHub();
var mockCaller = new Mock<IHubCallerClients>();
var mockClientProxy = new Mock<ISingleClientProxy>(); // <-- updated code
mockCaller.Setup(x => x.Caller).Returns(mockClientProxy.Object);
hub.Clients = mockCaller.Object;

class MyHub : Hub { }
```

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The change was made to add new functionality to SignalR. It is non-breaking in normal use cases, however, it may break test code, which is easily updated.

## Recommended action

Update test code to use the `ISingleClientProxy` interface when using reflection or reflection-based code.

## Affected APIs

- <xref:Microsoft.AspNetCore.SignalR.IHubClients?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients?displayProperty=fullName>
