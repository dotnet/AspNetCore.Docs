---
title: Manage users and groups in SignalR
author: tdykstra
description: Overview of ASP.NET Core SignalR User and Group management.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 06/04/2018
uid: signalr/groups
---

# Manage users and groups in SignalR

By [Brennan Conroy](https://github.com/BrennanConroy)

SignalR allows messages to be sent to all connections associated with a specific user, as well as to named groups of connections.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/groups/sample/) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## Users in SignalR

SignalR allows you to send messages to all connections associated with a specific user. By default, SignalR uses the `ClaimTypes.NameIdentifier` from the `ClaimsPrincipal` associated with the connection as the user identifier. A single user can have multiple connections to a SignalR app. For example, a user could be connected on their desktop as well as their phone. Each device has a separate SignalR connection, but they're all associated with the same user. If a message is sent to the user, all of the connections associated with that user receive the message. The user identifier for a connection can be accessed by the `Context.UserIdentifier` property in your hub.

Send a message to a specific user by passing the user identifier to the `User` function in your hub method as shown in the following example:

> [!NOTE]
> The user identifier is case-sensitive.

```csharp
public Task SendPrivateMessage(string user, string message)
{
    return Clients.User(user).SendAsync("ReceiveMessage", message);
}
```

The user identifier can be customized by creating an `IUserIdProvider`, and registering it in `ConfigureServices`.

[!code-csharp[UserIdProvider](groups/sample/customuseridprovider.cs?range=4-10)]

[!code-csharp[Configure service](groups/sample/startup.cs?range=21-22,39-42)]

> [!NOTE]
> AddSignalR must be called before registering your custom SignalR services.

## Groups in SignalR

A group is a collection of connections associated with a name. Messages can be sent to all connections in a group. Groups are the recommended way to send to a connection or multiple connections because the groups are managed by the application. A connection can be a member of multiple groups. This makes groups ideal for something like a chat application, where each room can be represented as a group. Connections can be added to or removed from groups via the `AddToGroupAsync` and `RemoveFromGroupAsync` methods.

[!code-csharp[Hub methods](groups/sample/hubs/chathub.cs?range=15-27)]

Group membership isn't preserved when a connection reconnects. The connection needs to rejoin the group when it's re-established. It's not possible to count the members of a group, since this information is not available if the application is scaled to multiple servers.

> [!NOTE]
> Group names are case-sensitive.

## Related resources

* [Get started](xref:tutorials/signalr)
* [Hubs](xref:signalr/hubs)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
