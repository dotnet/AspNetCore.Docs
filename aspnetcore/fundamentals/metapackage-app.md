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

The [Microsoft.AspNetCore.App](https://www.nuget.org/packages/Microsoft.AspNetCore.App) metapackage for ASP.NET Core includes:

* All supported packages by the ASP.NET Core team except those that contain third party dependencies.
* All supported packages by the Entity Framework Core. 
* Internal dependencies used by ASP.NET Core and Entity Framework Core.
* 3rd-party dependencies used by ASP.NET Core and Entity Framework Core deemed necessary to ensure the major frameworks features function.

All the features of ASP.NET Core 2.1 and later and Entity Framework Core 2.1 and later are included in the `Microsoft.AspNetCore.App` package. The default project templates targeting ASP.NET Core 2.1 and later use this package. We recommend applications targeting ASP.NET Core 2.1+ and Entity Framework Core 2.1+ use the `Microsoft.AspNetCore.App` package.

The version number of the `Microsoft.AspNetCore.App` metapackage represents the ASP.NET Core version and Entity Framework Core version. The ASP.NET Core version is currently aligned with the .NET Core version, and we hope to continue version alignment in the future.

Using the the `Microsoft.AspNetCore.App` metapackage provides version restrictions that protect your app:

* Other packages added to your app cannot change the version of packages included in `Microsoft.AspNetCore.App`.
* Version consistency ensures a reliable experience. `Microsoft.AspNetCore.App` was designed to prevent untested version combinations of related bits being used together in the same app.

Applications that use the `Microsoft.AspNetCore.App` metapackage automatically take advantage of the ASP.NET Core shared framework. When you use the `Microsoft.AspNetCore.App` metapackage, **no** assets from the referenced ASP.NET Core NuGet packages are deployed with the application &mdash; the ASP.NET Core shared framework contains these assets. The assets in the shared framework are precompiled to improve application startup time. For more information, see "shared framework" in [.NET Core distribution packaging](/dotnet/core/build/distribution-packaging).

Packages in the .NET Core shared framework are excluded in published application output.

The following *.csproj* file references the `Microsoft.AspNetCore.App` metapackage for ASP.NET Core:

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

The preceding markup doesn't specify a version number for the `Microsoft.AspNetCore.App` NuGet package. The ASP.NET Core 2.1+ templates generate this markup without a version number. When the version is not specified, the version used depends on the package source. On servers and in Azure, the package source is generally the ASP.NET Core shared framework. On development machines, it's generally `https://api.nuget.org/v3/index.json`.

We recommend not specifying the version number. By not specifying the version, the shared framework roll forward mechanism will run the app on the latest version of the installed shared framework. To guarantee the same version is used in development, test, and production, ensure the same version of the shared framework is installed in all environments.

Developers can choose to specify a version number to guarantee the same version is used in development, test, and production. With a fixed version number, updates to the hosts shared framework will not cause the app to use a newer version of the `Microsoft.AspNetCore.App` package.

If your application previously used `Migrating from Microsoft.AspNetCore.All`, see [Migrating from Microsoft.AspNetCore.All to Microsoft.AspNetCore.App](xref:fundamentals/metapackage#migrate).