---
title: "Breaking change: Blazor: Updated browser support"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Blazor: Updated browser support"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/441
no-loc: [Blazor, "Blazor WebAssembly", "Blazor Server"]
---
# Blazor: Updated browser support

ASP.NET Core 5.0 introduces [new Blazor features](https://github.com/dotnet/aspnetcore/issues/21514), some of which are incompatible with older browsers. The list of browsers supported by Blazor in ASP.NET Core 5.0 has been updated accordingly.

For discussion, see GitHub issue [dotnet/aspnetcore#26475](https://github.com/dotnet/aspnetcore/issues/26475).

## Version introduced

5.0

## Old behavior

Blazor Server supports Microsoft Internet Explorer 11 with sufficient polyfills. Blazor Server and Blazor WebAssembly are also functional in [Microsoft Edge Legacy](https://support.microsoft.com/help/4533505/what-is-microsoft-edge-legacy).

## New behavior

Blazor Server in ASP.NET Core 5.0 isn't supported with Microsoft Internet Explorer 11. Blazor Server and Blazor WebAssembly aren't fully functional in Microsoft Edge Legacy.

## Reason for change

New Blazor features in ASP.NET Core 5.0 are incompatible with these older browsers, and use of these older browsers is diminishing. For more information, see the following resources:

* [Windows support for Microsoft Edge Legacy is also ending on March 9, 2021](https://support.microsoft.com/help/4533505/what-is-microsoft-edge-legacy)
* [Microsoft 365 apps and services will end support for Microsoft Internet Explorer 11 by August 17, 2021](/lifecycle/announcements/m365-ie11-microsoft-edge-legacy)

## Recommended action

Upgrade from these older browsers to the [new, Chromium-based Microsoft Edge](https://www.microsoft.com/edge). For Blazor apps that need to support these older browsers, use ASP.NET Core 3.1. The supported browsers list for Blazor in ASP.NET Core 3.1 hasn't changed and is documented at [Supported platforms](/aspnet/core/blazor/supported-platforms?view=aspnetcore-3.1&preserve-view=true).

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
