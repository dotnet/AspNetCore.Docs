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

SignalR allows you to send messages to all connections associated with a specific user. By default SignalR will use the `ClaimTypes.NameIdentifier` from the `ClaimsPrincipal` associated with the connection as the user identifier. Multiple connections can be associated with the same user. For example, you can be connected on your desktop, your phone, and your laptop. If you send to the user all three connections will receive the message.

You can send a message to a specific user by passing the user identifier to the `User(...)` function in your hub method as shown in the following example.

> [!NOTE]
> The user identifier is case-sensitive.

```csharp
public Task SendPrivateMessage(string user, string message)
{
    return Clients.User(user).SendAsync("ReceiveMessage", message);
}
```

The user identifier can be customized by creating your own `IUserIdProvider`, and registering it in `ConfigureServices`.

```csharp
public class CustomUserIdProvider : IUserIdProvider
{
    public virtual string GetUserId(HubConnectionContext connection)
    {
        return connection.User?.FindFirst(ClaimTypes.Email)?.Value;
    }
}
```

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ... other services ...
    services.AddSingleton<IUserIdProvider, CustomUserIdProvider>());
}
```

## Groups?

A group is a collection of connections associated with a name. Messages can be sent to all connections in a group. Groups are the recommended way to send to a connection or multiple connections because the groups are managed by the application. A connection can be a member of multiple groups. This makes groups ideal for something like a chat application, where each room can be represented as a group. Connections can be added to or removed from groups via the `AddToGroupAsync` and `RemoveFromGroupAsync` methods.

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

Group membership is not preserved when a connection reconnects, the connection will need to rejoin then group when it is re-established. It is not possible to count the members of a group, since this information is not available if the application is scaled to multiple servers.

> [!NOTE]
> Group names are case-sensitive.

## Related resources

* [Get started](xref:signalr/get-started)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
