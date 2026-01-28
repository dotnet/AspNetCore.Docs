---
title: "Breaking change: Event IDs for some Microsoft.AspNetCore.Mvc.Core log messages changed"
description: Learn about the breaking change in ASP.NET Core 7.0 where event IDs for some Microsoft.AspNetCore.Mvc.Core log messages changed.
ms.date: 03/23/2022
ms.custom: https://github.com/aspnet/Announcements/issues/483
---

# Event IDs for some Microsoft.AspNetCore.Mvc.Core log messages changed

As part of updating the `Microsoft.AspNetcore.Mvc.Core` assembly to use <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute>, the ASP.NET Core team discovered logger event IDs that were reused within a single log category. Event IDs and names should be unique so that different message types can be identified. These IDs have been updated to ensure that they're unique within a single log category.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

Some logger event IDs within the `Microsoft.AspNetCore.Mvc.Core` assembly were reused within a single log category.

## New behavior

Duplicate logger event IDs within a single log category within the `Microsoft.AspNetCore.Mvc.Core` assembly have been updated.

## Type of breaking change

This change affects [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility).

## Reason for change

Logger event IDs and names should be unique so that different message types can be identified.

## Recommended action

If you have code or configuration that references the old logger event IDs, update those references to use the new IDs.

## Affected APIs

Not detectable via API analysis.
