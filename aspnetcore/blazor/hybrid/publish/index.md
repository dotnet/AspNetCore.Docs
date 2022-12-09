---
title: Publish ASP.NET Core Blazor Hybrid apps
author: guardrex
description: Learn about publishing ASP.NET Core Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 12/07/2022
uid: blazor/hybrid/publish/index
---
# Publish ASP.NET Core Blazor Hybrid apps

This article explains how to publish Blazor Hybrid apps.

## Publish for a specific framework

Blazor Hybrid supports .NET MAUI, WPF, and Windows Forms. The publishing steps for apps using Blazor Hybrid are nearly identical to the publishing steps for the target platform.

* WPF and Windows Forms
  * [.NET application publishing overview](/dotnet/core/deploying/)
* .NET MAUI
  * [Windows](/dotnet/maui/windows/deployment/overview)
  * [Android](/dotnet/maui/android/deployment/overview)
  * [iOS](/dotnet/maui/ios/deployment/overview)
  * [macOS](/dotnet/maui/macos/deployment/overview)

## Blazor-specific considerations

Blazor Hybrid apps require a :::no-loc text="Web View"::: on the host platform. For more information, see [Keep the :::no-loc text="Web View"::: current in deployed Blazor Hybrid apps](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/hybrid/security/security-considerations.md#keep-the-web-view-current-in-deployed-apps).
