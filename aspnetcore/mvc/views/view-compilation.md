---
title: Razor file compilation in ASP.NET Core
author: rick-anderson
description: Learn how compilation of Razor files occurs in an ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 4/8/2020
uid: mvc/views/view-compilation
---
# Razor file compilation in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

::: moniker range=">= aspnetcore-3.0"

Razor files with a *.cshtml* extension are compiled at both build and publish time using the [Razor SDK](xref:razor-pages/sdk). Runtime compilation may be optionally enabled by configuring your application.

## Razor compilation

Build- and publish-time compilation of Razor files is enabled by default by the Razor SDK. When enabled, runtime compilation complements build-time compilation, allowing Razor files to be updated if they are edited.

## Runtime compilation

To enable runtime compilation for all environments and configuration modes:

* Install the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) NuGet package.

* Update the project's `Startup.ConfigureServices` method to include a call to <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation*>. For example:

[!code-csharp[](~/mvc/views/view-compilation/sample/Startup.cs
?name=snippet]

### Conditionally enable runtime compilation

Runtime compilation can be enabled such that it's only available for local development. Conditionally enabling in this manner ensures that the published output:

* Uses compiled views.
* Is smaller in size.
* Doesn't enable file watchers in production.

To enable runtime compilation based on the environment and configuration mode:

1. Conditionally reference the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) package based on the active `Configuration` value:

    ```xml
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="3.1.0" Condition="'$(Configuration)' == 'Debug'" />
    ```

1. Update the project's `Startup.ConfigureServices` method to include a call to `AddRazorRuntimeCompilation`. Conditionally execute `AddRazorRuntimeCompilation` such that it only runs in Debug mode when the `ASPNETCORE_ENVIRONMENT` variable is set to `Development`:

    ```csharp
    public IWebHostEnvironment Env { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        IMvcBuilder builder = services.AddRazorPages();

    #if DEBUG
        if (Env.IsDevelopment())
        {
            builder.AddRazorRuntimeCompilation();
        }
    #endif

        // code omitted for brevity
    }
    ```

## Additional resources

* [RazorCompileOnBuild and RazorCompileOnPublish](xref:razor-pages/sdk#properties) properties.
* <xref:razor-pages/index>
* <xref:mvc/views/overview>
* <xref:razor-pages/sdk>
* See the [runtimecompilation sample on GitHub](https://github.com/aspnet/samples/tree/master/samples/aspnetcore/mvc/runtimecompilation) for a sample that shows making `RuntimeCompilation` work across projects.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

A Razor file is compiled at runtime, when the associated Razor Page or MVC view is invoked. Razor files are compiled at both build and publish time using the [Razor SDK](xref:razor-pages/sdk).

## Razor compilation

Build- and publish-time compilation of Razor files is enabled by default by the Razor SDK. Editing Razor files after they're updated is supported at build time. By default, only the compiled *Views.dll* and no *.cshtml* files or references assemblies required to compile Razor files are deployed with your app.

> [!IMPORTANT]
> The precompilation tool has been deprecated, and will be removed in ASP.NET Core 3.0. We recommend migrating to [Razor Sdk](xref:razor-pages/sdk).
>
> The Razor SDK is effective only when no precompilation-specific properties are set in the project file. For instance, setting the *.csproj* file's `MvcRazorCompileOnPublish` property to `true` disables the Razor SDK.

## Runtime compilation

Build-time compilation is supplemented by runtime compilation of Razor files. ASP.NET Core MVC will recompile Razor files when the contents of a *.cshtml* file change.

## Additional resources

* <xref:razor-pages/index>
* <xref:mvc/views/overview>
* <xref:razor-pages/sdk>

::: moniker-end