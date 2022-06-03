---
title: ASP.NET Core Blazor supported platforms
author: guardrex
description: Learn about the supported platforms for ASP.NET Core Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/24/2022
uid: blazor/supported-platforms
---
# ASP.NET Core Blazor supported platforms

:::moniker range=">= aspnetcore-6.0"

Blazor WebAssembly and Blazor Server are supported in the browsers shown in the following table on both mobile and desktop platforms.

| Browser         | Version         |
| --------------- | --------------- |
| Apple Safari    | Current&dagger; |
| Google Chrome   | Current&dagger; |
| Microsoft Edge  | Current&dagger; |
| Mozilla Firefox | Current&dagger; |

&dagger;*Current* refers to the latest version of the browser.

For [Blazor Hybrid apps](xref:blazor/hybrid/index), we test on and support the latest platform Web View control versions:

* [Microsoft Edge `WebView2` on Windows](/microsoft-edge/webview2/)
* [Chrome on Android](https://play.google.com/store/apps/details?id=com.android.chrome)
* [Safari on iOS and macOS](https://www.apple.com/safari/)

## Additional resources

* <xref:blazor/hosting-models>
* <xref:signalr/supported-platforms>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Blazor WebAssembly and Blazor Server are supported in the browsers shown in the following table on both mobile and desktop platforms.

| Browser         | Version         |
| --------------- | --------------- |
| Apple Safari    | Current&dagger; |
| Google Chrome   | Current&dagger; |
| Microsoft Edge  | Current&dagger; |
| Mozilla Firefox | Current&dagger; |

&dagger;*Current* refers to the latest version of the browser.

## Additional resources

* <xref:blazor/hosting-models>
* <xref:signalr/supported-platforms>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Blazor WebAssembly

| Browser                     | Version               |
| --------------------------- | --------------------- |
| Apple Safari                | Current&dagger;       |
| Google Chrome               | Current&dagger;       |
| Microsoft Edge              | Current&dagger;       |
| Microsoft Internet Explorer | Not Supported&Dagger; |
| Mozilla Firefox             | Current&dagger;       |

&dagger;*Current* refers to the latest version of the browser.  
&Dagger;Microsoft Internet Explorer doesn't support [WebAssembly](https://webassembly.org).

## Blazor Server

| Browser                     | Version         |
| --------------------------- | --------------- |
| Apple Safari                | Current&dagger; |
| Google Chrome               | Current&dagger; |
| Microsoft Edge              | Current&dagger; |
| Microsoft Internet Explorer | 11&Dagger;      |
| Mozilla Firefox             | Current&dagger; |

&dagger;*Current* refers to the latest version of the browser.  
&Dagger;Additional polyfills are required. For example, promises can be added via a [`Polyfill.io`](https://polyfill.io/v3/) bundle.

## Additional resources

* <xref:blazor/hosting-models>
* <xref:signalr/supported-platforms>

:::moniker-end
