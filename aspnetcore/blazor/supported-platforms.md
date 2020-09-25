---
title: ASP.NET Core Blazor supported platforms
author: guardrex
description: Learn about the supported platforms for ASP.NET Core Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 09/25/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/supported-platforms
---
# ASP.NET Core Blazor supported platforms

By [Luke Latham](https://github.com/guardrex)

## Blazor WebAssembly

| Browser                          | Version&dagger;       |
| -------------------------------- | :-------------------: |
| Apple Safari, including iOS      | Current               |
| Google Chrome, including Android | Current               |
| Microsoft Internet Explorer      | Not Supported&Dagger; |
| Microsoft Edge                   | Current               |
| Mozilla Firefox                  | Current               |

&dagger;Resource limitations prevent testing the Blazor framework APIs with all versions of the most popular browsers. Therefore, Blazor WebAssembly is generally supported for the latest versions of browsers. If a browser incompatibility is discovered for a current Blazor framework feature, open an issue at the [ASP.NET Core GitHub repository](https://github.com/dotnet/aspnetcore/issues) with complete details of the incompatibility.

&Dagger;Microsoft Internet Explorer doesn't support [WebAssembly](https://webassembly.org).

## Blazor Server

| Browser                          | Version&dagger; |
| -------------------------------- | :-------------: |
| Apple Safari, including iOS      | Current         |
| Google Chrome, including Android | Current         |
| Microsoft Edge                   | Current         |
| Microsoft Internet Explorer      | 11&Dagger;      |
| Mozilla Firefox                  | Current         |

&dagger;Resource limitations prevent testing the Blazor framework APIs with all versions of the most popular browsers. Therefore, Blazor Server is generally supported for the latest versions of browsers. Additionally, Blazor Server relies on [SignalR](xref:signalr/introduction), which is [generally supported for the latest versions of popular browsers](xref:signalr/supported-platforms). If a browser incompatibility is discovered for a current Blazor framework feature, open an issue at the [ASP.NET Core GitHub repository](https://github.com/dotnet/aspnetcore/issues) with complete details of the incompatibility.

&Dagger;Additional polyfills are required. For example, promises can be added via a [`Polyfill.io`](https://polyfill.io/v3/) bundle.

## Additional resources

* <xref:blazor/hosting-models>
* <xref:signalr/supported-platforms>
