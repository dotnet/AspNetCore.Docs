---
title: Razor file compilation and precompilation in ASP.NET Core
author: rick-anderson
description: Learn about the benefits of precompiling Razor files and how to accomplish Razor file precompilation in an ASP.NET Core app.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 05/17/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: mvc/views/view-compilation
---
# Razor file compilation in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

A Razor file is compiled at runtime, when the associated Razor Page or view is invoked. ASP.NET Core 2.1 and later compile views at build and publish time using the [Razor SDK](xref:mvc/razor-pages/sdk). In ASP.NET Core 1.1 and ASP.NET Core 2.0, views can optionally be compiled at publish and deployed with the app&mdash;using the precompilation tool.

## Precompilation considerations

The following are side effects of precompiling Razor files:

* A smaller published bundle
* A faster startup time
* You can't edit Razor files&mdash;the associated Razor Pages or views are absent from the published bundle.

## Deploy precompiled views

::: moniker range="= aspnetcore-2.1"
Build- and publish-time compilation of Razor files is enabled by default by the Razor SDK. Editing Razor files after they're updated is supported at build time. By default, only the compiled *Views.dll* and no *.cshtml* files are deployed with your app.

> [!IMPORTANT]
> The Razor SDK is effective only when no precompilation-specific properties are set in the project file. For instance, setting the *.csproj* file's `MvcRazorCompileOnPublish` property to `true` disables the Razor SDK.
::: moniker-end
::: moniker range="= aspnetcore-2.0"
If your project targets .NET Framework, include a package reference to [Microsoft.AspNetCore.Mvc.Razor.ViewCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.ViewCompilation/):

```xml
<PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.ViewCompilation"
                  Version="2.0.0"
                  PrivateAssets="All" />
```

If your project targets .NET Core, no changes are necessary.

The ASP.NET Core 2.x project templates implicitly set `MvcRazorCompileOnPublish` to `true` by default, which means this node can be safely removed from the *.csproj* file.

> [!IMPORTANT]
> Razor view precompilation is unavailable when performing a [self-contained deployment (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd) in ASP.NET Core 2.0.

Prepare the app for a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd) with the [.NET Core CLI publish command](/dotnet/core/tools/dotnet-publish). For example, execute the following command at the project root:

```console
dotnet publish -c Release
```

A *<project_name>.PrecompiledViews.dll* file, containing the compiled Razor files, is produced when precompilation succeeds. For example, the screenshot below depicts the contents of *Index.cshtml* within *WebApplication1.PrecompiledViews.dll*:

![Razor views inside DLL](view-compilation/_static/razor-views-in-dll.png)
::: moniker-end
::: moniker range="<= aspnetcore-1.1"
Set `MvcRazorCompileOnPublish` to `true` and include a package reference to `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation`. The following *.csproj* sample highlights these settings:

[!code-xml[](view-compilation/sample/MvcRazorCompileOnPublish.csproj?highlight=5,12)]
::: moniker-end

## Additional resources

* <xref:mvc/razor-pages/sdk>