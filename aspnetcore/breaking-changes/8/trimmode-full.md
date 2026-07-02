---
title: "Breaking change: TrimMode defaults to full for Web SDK projects"
description: Learn about the breaking change in ASP.NET Core 8.0 where 'TrimMode' defaults to 'full' for Web SDK projects.
ms.date: 07/31/2023
ms.custom: https://github.com/aspnet/Announcements/issues/507
---
# TrimMode defaults to full for Web SDK projects

Trimming now trims all assemblies in applications that target the [Web SDK](/aspnet/core/razor-pages/web-sdk), by default. This change only affects apps that are published with `PublishTrimmed=true`, and it only breaks apps that had existing trim warnings.

## Version introduced

ASP.NET Core 8.0 Preview 7

## Previous behavior

Previously, `TrimMode=partial` was set by default for all projects that targeted the Web SDK.

## New behavior

Starting in .NET 8, all the assemblies in the app are trimmed, by default. Apps that previously worked with `PublishTrimmed=true` and `TrimMode=partial` might not work in .NET 8 and later versions. However, only apps with trim warnings are affected. If your app has no trim warnings, the change in behavior shouldn't cause any adverse effects.

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

This change helps to decrease app size without users having to explicitly opt in. It also aligns with user expectations that the entire app is trimmed unless noted otherwise.

## Recommended action

The best resolution is to resolve all the trim warnings in your application. For information about resolving the warnings in your own libraries, see [Introduction to trim warnings](/dotnet/core/deploying/trimming/fixing-warnings).

To revert to the previous behavior, set the `TrimMode` property to `partial`.

```xml
<TrimMode>partial</TrimMode>
```

## Affected APIs

None.
