---
title: "Breaking change: SignalR: MessagePack Hub Protocol moved to MessagePack 2.x package"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled SignalR: MessagePack Hub Protocol moved to MessagePack 2.x package"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/404
---
# SignalR: MessagePack Hub Protocol moved to MessagePack 2.x package

The ASP.NET Core SignalR [MessagePack Hub Protocol](/aspnet/core/signalr/messagepackhubprotocol) uses the [MessagePack NuGet package](https://www.nuget.org/packages/MessagePack) for MessagePack serialization. ASP.NET Core 5.0 upgrades the package from 1.x to the latest 2.x package version.

For discussion on this issue, see [dotnet/aspnetcore#18692](https://github.com/dotnet/aspnetcore/issues/18692).

## Version introduced

5.0 Preview 1

## Old behavior

ASP.NET Core SignalR used the MessagePack 1.x package to serialize and deserialize MessagePack messages.

## New behavior

ASP.NET Core SignalR uses the MessagePack 2.x package to serialize and deserialize MessagePack messages.

## Reason for change

The latest improvements in the MessagePack 2.x package add useful functionality.

## Recommended action

This breaking change applies when:

* Setting or configuring values on <xref:Microsoft.AspNetCore.SignalR.MessagePackHubProtocolOptions>.
* Using the MessagePack APIs directly and using the ASP.NET Core SignalR MessagePack Hub Protocol in the same project. The newer version will be loaded instead of the previous version.

For migration guidance from the package authors, see [Migrating from MessagePack v1.x to MessagePack v2.x](https://github.com/neuecc/MessagePack-CSharp/blob/master/doc/migration.md). Some aspects of message serialization and deserialization are affected. Specifically, there are [behavioral changes to how DateTime values are serialized](https://github.com/neuecc/MessagePack-CSharp/blob/master/doc/migration.md#behavioral-changes).

## Affected APIs

<xref:Microsoft.AspNetCore.SignalR.MessagePackHubProtocolOptions?displayProperty=nameWithType>

<!--

### Category

ASP.NET Core

### Affected APIs

`T:Microsoft.AspNetCore.SignalR.MessagePackHubProtocolOptions`

-->
