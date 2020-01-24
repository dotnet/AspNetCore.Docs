---
title: ASP.NET Core Web SDK
author: Rick-Anderson
description: Overview of Microsoft.NET.Sdk.Web.
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 08/23/2019
no-loc: [Blazor]
uid: razor-pages/web-sdk
---

# ASP.NET Core Web SDK

### Overview

`Microsoft.NET.Sdk.Web` is a [MSBuild project SDK](https://docs.microsoft.com/en-us/visualstudio/msbuild/how-to-use-project-sdk) for building ASP.NET Core applications. While it's possible to build an ASP.NET Core application without this, the Web SDK is tailored towards providing a first-class experience and is the recommended target for most users.

Use the Web.SDK in a project:

  ```xml
  <Project SDK="Microsoft.NET.Sdk.Web">
    <!-- omitted for brevity -->
  </Project>
  ```

Features enabled by using the Web SDK:

* Projects targeting .NET Core 3.0 or later implicitly reference the [ASP.NET Core shared framework](xref:fundamentals/metapackage-app) and [analyzers](xref:https://docs.microsoft.com/en-us/visualstudio/extensibility/getting-started-with-roslyn-analyzers) designed towards building ASP.NET Core applications.
* The WebSDK enables MSBuild targets that enables the use of publish profiles, and publishing using WebDeploy.

### Properties

| Property | Description |
| -------- | ----------- |
| `DisableImplicitFrameworkReferences` | Disables implciit reference to the `Microsoft.AspNetCore.App` shared framework. |
| `DisableImplicitAspNetCoreAnalyzers` | Disables implciit reference to ASP.NET Core analyzers. |
| `DisableImplicitComponentsAnalyzers` | Disables implciit reference to Razor Components analyzers when building Blazor (server) applications. |
