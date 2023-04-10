---
title: ASP.NET Core Web SDK
author: tdykstra
description: Overview of Microsoft.NET.Sdk.Web.
ms.author: riande
ms.date: 01/25/2023
uid: razor-pages/web-sdk
---

# ASP.NET Core Web SDK

 :::moniker range=">= aspnetcore-3.0"

## Overview

`Microsoft.NET.Sdk.Web` is an [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) for building ASP.NET Core apps. It's possible to build an ASP.NET Core app without this SDK, however, the Web SDK is:

* Tailored towards providing a first-class experience.
* The recommended target for most users.

Use the Web.SDK in a project:

  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Web">
    <!-- omitted for brevity -->
  </Project>
  ```

Features enabled by using the Web SDK:

* Implicitly references:

  * The [ASP.NET Core shared framework](xref:fundamentals/metapackage-app).
  * [Analyzers](/visualstudio/extensibility/getting-started-with-roslyn-analyzers) designed for building ASP.NET Core apps.
* The Web SDK imports MSBuild targets that enable the use of publish profiles and publishing using WebDeploy.

## Properties

| Property | Description |
| -------- | ----------- |
| `DisableImplicitFrameworkReferences` | Disables implicit reference to the `Microsoft.AspNetCore.App` shared framework. |
| `DisableImplicitAspNetCoreAnalyzers` | Disables implicit reference to ASP.NET Core analyzers. |
| `DisableImplicitComponentsAnalyzers` | Disables implicit reference to Razor Components analyzers when building Blazor (server) applications. |

For more information on tasks, targets, properties, implicit blobs, globs, publishing, methods, and more, see the [README file](https://github.com/dotnet/sdk/tree/main/src/WebSdk) in the [WebSdk](https://github.com/dotnet/sdk/tree/main/src/WebSdk) repository.

:::moniker-end
:::moniker range="< aspnetcore-3.0"

### Overview

`Microsoft.NET.Sdk.Web` is an [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) for building ASP.NET Core apps. It's possible to build an ASP.NET Core app without this SDK, however, the Web SDK is:

* Tailored towards providing a first-class experience.
* The recommended target for most users.

Use the Web.SDK in a project:

  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Web">
    <!-- omitted for brevity -->
  </Project>
  ```

The Web SDK imports MSBuild targets that enable the use of publish profiles and publishing using WebDeploy.

:::moniker-end
