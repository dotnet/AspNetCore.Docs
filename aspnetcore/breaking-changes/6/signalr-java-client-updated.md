---
title: "Breaking change: SignalR Java Client updated to RxJava3"
description: "Learn about the breaking change in ASP.NET Core 6.0 where the SignalR Java Client was updated to RxJava3."
ms.date: 04/21/2021
ms.custom: https://github.com/aspnet/Announcements/issues/457
---
# SignalR: Java Client updated to RxJava3

The SignalR Java Client is now RxJava3.

## Version introduced

ASP.NET Core 6.0

## Old behavior

The RxJava package reference in the library was RxJava2.

## New behavior

The RxJava package reference in the library is now RxJava3. For information about what changed in RxJava, see [What's different in 3.0](https://github.com/ReactiveX/RxJava/wiki/What's-different-in-3.0).

## Reason for change

The previous dependency (RxJava2) is no longer maintained. Support for RxJava2 ended in February 2021.

## Recommended action

If you were using RxJava2 in your app or library, you might need to update to RxJava3. For more information, see [What's different in 3.0](https://github.com/ReactiveX/RxJava/wiki/What's-different-in-3.0).

## Affected APIs

None.

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectable via API analysis.

-->
