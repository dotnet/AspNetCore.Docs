---
title: "Breaking change: Razor: Logging ID changes"
description: "Learn about the breaking change in ASP.NET Core 6.0 where some Razor pages logging IDs were changed."
no-loc: [ Razor ]
ms.date: 09/01/2021
ms.custom: https://github.com/aspnet/Announcements/issues/471
---
# Razor: Logging ID changes

Razor Pages log messages have associated IDs and names. These are used to uniquely identify different kinds of log messages. Some of those IDs were incorrectly duplicated. This .NET 6 change corrects the duplication.

## Version introduced

ASP.NET Core 6.0 RC1

## Old and new behavior

| Event name | Previous event ID | New event ID |
| - | - |
| `ExecutedHandlerMethod` | 102 | 108 |
| `ExecutingImplicitHandlerMethod` | 103 | 107 |
| `ExecutedImplicitHandlerMethod` | 104 | 109 |
| `NotMostEffectiveFilter` | 1 | 4 |

## Change category

This change affects [*binary compatibility*](../../categories.md#binary-compatibility).

## Reason for change

Log IDs should be unique so different message types can be identified.

## Recommended action

If you have code or configuration that references the old IDs, update those references to use the new IDs.

## Affected APIs

N/A.
