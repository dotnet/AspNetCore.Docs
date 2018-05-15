---
title: Microsoft.AspNetCore.App metapackage for ASP.NET Core 2.1 and later
author: Rick-Anderson
description: The Microsoft.AspNetCore.App metapackage includes all supported ASP.NET Core and Entity Framework Core packages.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 09/20/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/metapackage-app
---

# Microsoft.AspNetCore.App metapackage for ASP.NET Core 2.1

This feature requires ASP.NET Core 2.1 and later targeting .NET Core 2.1 and later.

<!--
This doc needs to be independent from the M.A.All doc. New developers to 2.1 who haven't used 2.0 will not be required to understand M.A.App when contrasted to M.A.All. So I can't describe what M.A.App is by saying how it has changed from M.A.All.
-->

The [Microsoft.AspNetCore.App](https://www.nuget.org/packages/Microsoft.AspNetCore.App) metapackage for ASP.NET Core:

* Does not include third-party dependencies except for [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/), [Remotion.Linq, and [IX-Async](https://www.nuget.org/packages/System.Interactive.Async/). These 3rd-party dependencies are deemed necessary to ensure the major frameworks features function.
* Includes all supported packages by the ASP.NET Core team except those that contain third-party dependencies (other than those previously mentioned).
* All supported packages by the Entity Framework Core team except those that contain third-party dependencies (other than those previously mentioned).
<!--
Copy/paste from https://github.com/aspnet/Announcements/issues/287
* Internal dependencies used by ASP.NET Core and Entity Framework Core.
-->
All the features of ASP.NET Core 2.1 and later and Entity Framework Core 2.1 and later are included in the `Microsoft.AspNetCore.App` package. The default project templates targeting ASP.NET Core 2.1 and later use this package. We recommend applications targeting ASP.NET Core 2.1 and later and Entity Framework Core 2.1 and later use the `Microsoft.AspNetCore.App` package.

The version number of the `Microsoft.AspNetCore.App` metapackage represents the ASP.NET Core version and Entity Framework Core version.

Using the `Microsoft.AspNetCore.App` metapackage provides version restrictions that protect your app:

* If a package is included that has a transitive (not direct) dependency on a package in `Microsoft.AspNetCore.App`, and those version numbers differ, NuGet will generate an error.
* Other packages added to your app cannot change the version of packages included in `Microsoft.AspNetCore.App`.
* Version consistency ensures a reliable experience. `Microsoft.AspNetCore.App` was designed to prevent untested version combinations of related bits being used together in the same app.

Applications that use the `Microsoft.AspNetCore.App` metapackage automatically take advantage of the ASP.NET Core shared framework. When you use the `Microsoft.AspNetCore.App` metapackage, **no** assets from the referenced ASP.NET Core NuGet packages are deployed with the application &mdash; the ASP.NET Core shared framework contains these assets. The assets in the shared framework are precompiled to improve application startup time. For more information, see "shared framework" in [.NET Core distribution packaging](/dotnet/core/build/distribution-packaging).

The following *.csproj* project file references the `Microsoft.AspNetCore.App` metapackage for ASP.NET Core:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.App" />
  </ItemGroup>

</Project>

```

The preceding markup doesn't specify a version number for the `Microsoft.AspNetCore.App` NuGet package. The ASP.NET Core 2.1 and later templates generate this markup without a version number. When the version is not specified, the implicit version is used:

* On development machines, the version of the .NET Core SDK installed. 
* On servers and in Azure, the version of the ASP.NET Core shared framework. 

The implicit version number is set to the latest bundled `major.minor.patch` of the shared framework for standalone apps.

We recommend not specifying the version number. The shared framework roll-forward mechanism will run the app on the latest version of the installed shared framework. To guarantee the same version is used in development, test, and production, ensure the same version of the shared framework is installed in all environments.

The version is implicitly specified by the SDK, that is, `Microsoft.NET.Sdk.Web`. However the implicit version is usually set to `major.minor.0` for portable apps. The framework roll-forward mechanism of the dotnet host chooses the most appropriate shared framework installed to run the app with. In most cases that means the latest installed `major.minor.patch` where the `major.minor` matches the implicit version number set by the SDK.

Using a version number with `Microsoft.AspNetCore.App` does **not** force that version to be used. For example, suppose version "2.1.1" is specified, but "2.1.3" is installed. In that case, the app will use "2.1.3". Although not recommended, you can disable roll forward (patch and/or minor). To disable roll forward, specify the options on the dotnet host. For more information, see [Settings to control behavior](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/roll-forward-on-no-candidate-fx.md#settings-to-control-behavior).

If your application previously used `Microsoft.AspNetCore.All`, see [Migrating from Microsoft.AspNetCore.All to Microsoft.AspNetCore.App](xref:fundamentals/metapackage#migrate).