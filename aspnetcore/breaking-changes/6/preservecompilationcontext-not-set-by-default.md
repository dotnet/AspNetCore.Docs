---
title: "Breaking change: PreserveCompilationContext not configured by default"
description: "Learn about the breaking change in ASP.NET Core 6.0 where the PreserveCompilationContext property is no longer configured by default."
no-loc: [ Razor ]
ms.date: 04/22/2021
ms.custom: https://github.com/aspnet/Announcements/issues/460
---
# PreserveCompilationContext not configured by default

[`PreserveCompilationContext`](../../../project-sdk/msbuild-props.md#preservecompilationcontext) is an MSBuild property that causes .NET Core projects to emit additional content to the application's dependency (.deps) file about how the app was compiled. This is primarily used to support runtime compilation scenarios.

Prior to .NET 6, `PreserveCompilationContext` was set to `true` for all apps that target the Razor (Microsoft.NET.Sdk.Razor) and Web (Microsoft.NET.Sdk.Web) SDKs. Starting in .NET 6, this property is no longer configured by default. However, packages such as Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation configure this property as required.

## Version introduced

ASP.NET Core 6.0

## Old behavior

The dependency file contains compilation context.

## New behavior

The dependency file no longer contains compilation context.

## Reason for change

This change improves build performance and startup time, and reduces the size of ASP.NET Core's build output.

## Recommended action

If your app requires this feature and does not reference a package that configures the property, add the `PreserveCompilationContext` property to your project file.

```xml
<PropertyGroup>
   <PreserveCompilationContext>true</PreserveCompilationContext>
</PropertyGroup>
```

## Affected APIs

None.

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectable via API analysis.

-->
