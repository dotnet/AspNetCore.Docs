---
title: Manage users and groups in SignalR
author: 
description: 
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: 
ms.custom: mvc
ms.date: 06/04/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: signalr/groups
---

# Manage users and groups in SignalR

## Users?

A user is one or more connections associated with an identifier. By default SignalR will use the `ClaimTypes.NameIdentifier` from the `ClaimsPrincipal` associated with the connection. There can be multiple connections for a single user. For example you can be connected on your desktop, your phone, and your laptop. If you send to the user all three connections will receive the message.

You can send a message to a specific user by passing the user identifier to the `User(...)` function in your hub method as shown in the following example. One important aspect to note is that the user identifier is case-sensitive.

```csharp
public Task SendPrivateMessage(string user, string message)
{
    return Clients.User(user).SendAsync("ReceiveMessage", message);
}
```

The user identifier can be customized by creating your own `IUserIdProvider`.

```csharp
public class CustomUserIdProvider : IUserIdProvider
{
    public virtual string GetUserId(HubConnectionContext connection)
    {
        // Be careful when using ClaimTypes.Name.
        // If your app allows non-unique names then the identifier will apply to everyone that uses that name.
        return connection.User?.FindFirst(ClaimTypes.Name)?.Value;
    }
}
```

And injecting it into the Apps DI container.

```csharp
services.AddSingleton(typeof(IUserIdProvider), typeof(CustomUserIdProvider));
```

## Groups?

A group is a collection of connections that can be broadcast to. Groups are the recommended way to send to a connection or multiple connections because the groups are managed by the application. A connection can be subscribed to multiple groups, one example would be for a chat app to have a group per chat room so only connections interested in certain rooms would be a part of those groups. Group management can be done in the hub via the `AddToGroupAsync` and `RemoveFromGroupAsync` methods.

```csharp
public async Task AddToGroup(string groupName)
{
    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
}

public async Task RemoveFromGroup(string groupName)
{
    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
}
```

Group membership is not preserved when a connection reconnects, the connection will need to resubscribe or the aplication will need to keep track of each connections subscriptions. It is also not possible to count the number of members per group as the app can be scaled out and wont know about the other servers subscription information. Just like user identifiers, group names are case-sensitive.

## Related resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
