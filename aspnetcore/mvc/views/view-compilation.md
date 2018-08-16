---
title: Razor file compilation and precompilation in ASP.NET Core
author: rick-anderson
description: Learn about the benefits of precompiling Razor files and how to accomplish Razor file precompilation in an ASP.NET Core app.
monikerRange: '>= aspnetcore-1.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/17/2018
uid: mvc/views/view-compilation
---
# Razor file compilation in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

::: moniker range="= aspnetcore-1.1"
A Razor file is compiled at runtime, when the associated MVC view is invoked. Build-time Razor file publishing is unsupported. Razor files can optionally be compiled at publish time and deployed with the app&mdash;using the precompilation tool.
::: moniker-end
::: moniker range="= aspnetcore-2.0"
A Razor file is compiled at runtime, when the associated Razor Page or MVC view is invoked. Build-time Razor file publishing is unsupported. Razor files can optionally be compiled at publish time and deployed with the app&mdash;using the precompilation tool.
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
A Razor file is compiled at runtime, when the associated Razor Page or MVC view is invoked. Razor files are compiled at both build and publish time using the [Razor SDK](xref:razor-pages/sdk).
::: moniker-end

## Precompilation considerations

The following are side effects of precompiling Razor files:

* A smaller published bundle
* A faster startup time
* You can't edit Razor files&mdash;the associated content is absent from the published bundle.

## Deploy precompiled files

::: moniker range=">= aspnetcore-2.1"
Build- and publish-time compilation of Razor files is enabled by default by the Razor SDK. Editing Razor files after they're updated is supported at build time. By default, only the compiled *Views.dll* and no *.cshtml* files are deployed with your app.

> [!IMPORTANT]
> The Razor SDK is effective only when no precompilation-specific properties are set in the project file. For instance, setting the *.csproj* file's `MvcRazorCompileOnPublish` property to `true` disables the Razor SDK.
::: moniker-end

::: moniker range="= aspnetcore-2.0"
If your project targets .NET Framework, install the [Microsoft.AspNetCore.Mvc.Razor.ViewCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.ViewCompilation/) NuGet package:

[!code-xml[](view-compilation/sample/DotNetFrameworkProject.csproj?name=snippet_ViewCompilationPackage)]

If your project targets .NET Core, no changes are necessary.

The ASP.NET Core 2.x project templates implicitly set the `MvcRazorCompileOnPublish` property to `true` by default. Consequently, this element can be safely removed from the *.csproj* file.

> [!IMPORTANT]
> Razor file precompilation is unavailable when performing a [self-contained deployment (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd) in ASP.NET Core 2.0.
::: moniker-end

::: moniker range="= aspnetcore-1.1"
Set the `MvcRazorCompileOnPublish` property to `true`, and install the [Microsoft.AspNetCore.Mvc.Razor.ViewCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.ViewCompilation/) NuGet package. The following *.csproj* sample highlights these settings:

[!code-xml[](view-compilation/sample/MvcRazorCompileOnPublish.csproj?highlight=4,10)]
::: moniker-end

::: moniker range="<= aspnetcore-2.0"
Prepare the app for a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd) with the [.NET Core CLI publish command](/dotnet/core/tools/dotnet-publish). For example, execute the following command at the project root:

```console
dotnet publish -c Release
```

A *<project_name>.PrecompiledViews.dll* file, containing the compiled Razor files, is produced when precompilation succeeds. For example, the screenshot below depicts the contents of *Index.cshtml* within *WebApplication1.PrecompiledViews.dll*:

![Razor views inside DLL](view-compilation/_static/razor-views-in-dll.png)
::: moniker-end

## Additional resources

::: moniker range="= aspnetcore-1.1"
* <xref:mvc/views/overview>
::: moniker-end

::: moniker range="= aspnetcore-2.0"
* <xref:razor-pages/index>
* <xref:mvc/views/overview>
::: moniker-end

::: moniker range=">= aspnetcore-2.1"
* <xref:razor-pages/index>
* <xref:mvc/views/overview>
* <xref:razor-pages/sdk>
::: moniker-end
