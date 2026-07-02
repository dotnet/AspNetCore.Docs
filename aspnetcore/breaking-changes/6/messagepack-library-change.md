---
title: "Breaking change: Changed MessagePack library in signalr-protocol-msgpack package"
description: "Learn about the breaking change in ASP.NET Core 6.0 where the MessagePack library was changed and two options were removed in the @microsoft/signalr-protocol-msgpack package."
ms.date: 04/07/2021
ms.custom: https://github.com/aspnet/Announcements/issues/454
---
# Changed MessagePack library in @microsoft/signalr-protocol-msgpack

The [@microsoft/signalr-protocol-msgpack](https://www.npmjs.com/package/@microsoft/signalr-protocol-msgpack) npm package now references `@msgpack/msgpack` instead of `msgpack5`. Additionally, the available options that can optionally be passed into the `MessagePackHubProtocol` have changed. The `MessagePackOptions.disableTimestampEncoding` and `MessagePackOptions.forceFloat64` properties were removed, and some new options were added.

For discussion, see <https://github.com/dotnet/aspnetcore/issues/30471>.

## Version introduced

ASP.NET Core 6.0

## Old behavior

In previous versions, you must include three script references to use the [MessagePack Hub Protocol](/aspnet/core/signalr/messagepackhubprotocol) in the browser:

```html
<script src="~/lib/signalr/signalr.js"></script>
<script src="~/lib/msgpack5/msgpack5.js"></script>
<script src="~/lib/signalr/signalr-protocol-msgpack.js"></script>
```

## New behavior

Starting in ASP.NET Core 6, you only need two script references to use the [MessagePack Hub Protocol](/aspnet/core/signalr/messagepackhubprotocol) in the browser:

```html
<script src="~/lib/signalr/signalr.js"></script>
<script src="~/lib/signalr/signalr-protocol-msgpack.js"></script>
```

Instead of the `msgpack5` package, the `@msgpack/msgpack` package is downloaded to your *node_modules* directory if you want to use it directly in your app.

Finally, `MessagePackOptions` has new, additional properties, and the `disableTimestampEncoding` and `forceFloat64` properties are removed.

## Reason for change

This change was made to reduce asset size, make it simpler to consume the package, and add more customizability.

## Recommended action

If you were previously using `msgpack5` in your app, you'll need to add a direct reference to the library in your *package.json* file.

## Affected APIs

The following APIs were removed:

- `MessagePackOptions.disableTimestampEncoding`
- `MessagePackOptions.forceFloat64`

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectable via API analysis.

-->
