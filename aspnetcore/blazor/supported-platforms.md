---
title: ASP.NET Core Blazor supported platforms
author: guardrex
description: Learn about the supported platforms for ASP.NET Core Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 12/18/2019
no-loc: [Blazor, SignalR]
uid: blazor/supported-platforms
---
# ASP.NET Core Blazor supported platforms

By [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

## Browser requirements

### Blazor WebAssembly

| Browser                          | Version               |
| -------------------------------- | :-------------------: |
| Microsoft Edge                   | Current               |
| Mozilla Firefox                  | Current               |
| Google Chrome, including Android | Current               |
| Safari, including iOS            | Current               |
| Microsoft Internet Explorer      | Not Supported&dagger; |

&dagger;Microsoft Internet Explorer doesn't support [WebAssembly](https://webassembly.org).

### Blazor Server

| Browser                          | Version    |
| -------------------------------- | :--------: |
| Microsoft Edge                   | Current    |
| Mozilla Firefox                  | Current    |
| Google Chrome, including Android | Current    |
| Safari, including iOS            | Current    |
| Microsoft Internet Explorer      | 11&dagger; |

&dagger;Additional polyfills are required (for example, promises can be added via a [Polyfill.io](https://polyfill.io/v3/) bundle).

## Additional resources

* <xref:blazor/hosting-models>
