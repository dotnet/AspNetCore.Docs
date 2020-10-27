---
title: ASP.NET Core Blazor supported platforms
author: guardrex
description: Learn about the supported platforms for ASP.NET Core Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 10/01/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/supported-platforms
---
# ASP.NET Core Blazor supported platforms

By [Luke Latham](https://github.com/guardrex)

::: moniker range=">= aspnetcore-5.0"

Blazor WebAssembly and Blazor Server are supported in the browsers shown in the following table.

| Browser                          | Version         |
| -------------------------------- | --------------- |
| Apple Safari, including iOS      | Current&dagger; |
| Google Chrome, including Android | Current&dagger; |
| Microsoft Edge                   | Current&dagger; |
| Mozilla Firefox                  | Current&dagger; |  

&dagger;*Current* refers to the latest version of the browser.  

::: moniker-end

::: moniker range="< aspnetcore-5.0"

## Blazor WebAssembly

| Browser                          | Version               |
| -------------------------------- | --------------------- |
| Apple Safari, including iOS      | Current&dagger;       |
| Google Chrome, including Android | Current&dagger;       |
| Microsoft Edge                   | Current&dagger;       |
| Microsoft Internet Explorer      | Not Supported&Dagger; |
| Mozilla Firefox                  | Current&dagger;       |  

&dagger;*Current* refers to the latest version of the browser.  
&Dagger;Microsoft Internet Explorer doesn't support [WebAssembly](https://webassembly.org).

## Blazor Server

| Browser                          | Version         |
| -------------------------------- | --------------- |
| Apple Safari, including iOS      | Current&dagger; |
| Google Chrome, including Android | Current&dagger; |
| Microsoft Edge                   | Current&dagger; |
| Microsoft Internet Explorer      | 11&Dagger;      |
| Mozilla Firefox                  | Current&dagger; |

&dagger;*Current* refers to the latest version of the browser.  
&Dagger;Additional polyfills are required. For example, promises can be added via a [`Polyfill.io`](https://polyfill.io/v3/) bundle.

::: moniker-end

## Additional resources

* <xref:blazor/hosting-models>
* <xref:signalr/supported-platforms>
