---
title: "Breaking change: Blazor: Parameter name changed in RequestImageFileAsync method"
description: "Learn about the breaking change in ASP.NET Core 6.0 titled Blazor: Parameter name changed in RequestImageFileAsync method"
no-loc: [ Blazor ]
ms.author: scaddie
ms.date: 02/09/2021
ms.custom: https://github.com/aspnet/Announcements/issues/451
---
# Blazor: Parameter name changed in RequestImageFileAsync method

The `RequestImageFileAsync` method's `maxWith` parameter was renamed from `maxWith` to `maxWidth`.

## Version introduced

ASP.NET Core 6.0

## Old behavior

The parameter name is spelled `maxWith`.

## New behavior

The parameter name is spelled `maxWidth`.

## Reason for change

The original parameter name was a typographical error.

## Recommended action

If you're using named parameters in the `RequestImageFile` API, update the `maxWith` parameter name to `maxWidth`. Otherwise, no change is necessary.

## Affected APIs

<xref:Microsoft.AspNetCore.Components.Forms.BrowserFileExtensions.RequestImageFileAsync%2A?displayProperty=nameWithType>

<!--

## Category

ASP.NET Core

## Affected APIs

`Overload:Microsoft.AspNetCore.Components.Forms.BrowserFileExtensions.RequestImageFileAsync`

-->
