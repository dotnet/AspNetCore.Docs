---
title: Razor file compilation in ASP.NET Core
author: rick-anderson
description: Learn how compilation of Razor files occurs in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/20/2023
uid: mvc/views/view-compilation
---
# Razor file compilation in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

Razor files with a `.cshtml` extension are compiled at both build and publish time using the [Razor SDK](xref:razor-pages/sdk). Runtime compilation may be optionally enabled by configuring the project.

> [!NOTE]
> Runtime compilation:
> * Isn't supported for Razor components of Blazor apps.
> * Doesn't support [global using directives](/dotnet/csharp/whats-new/csharp-10#global-using-directives).
> * Doesn't support [implicit using directives](/dotnet/core/tutorials/top-level-templates#implicit-using-directives).
> * Disables [.NET Hot Reload](xref:test/hot-reload).
> * Is recommended for development, not for production.

## Razor compilation

Build-time and publish-time compilation of Razor files is enabled by default by the Razor SDK. When enabled, runtime compilation complements build-time compilation, allowing Razor files to be updated if they're edited while the app is running.

Updating Razor views and Razor Pages during development while the app is running is also supported using [.NET Hot Reload](xref:test/hot-reload).

> [!NOTE]
> When enabled, runtime compilation disables [.NET Hot Reload](xref:test/hot-reload). We recommend using Hot Reload instead of Razor runtime compilation during development.

## Enable runtime compilation for all environments

To enable runtime compilation for all environments:

1. Install the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) NuGet package.
1. Call <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A> in `Program.cs`:

   :::code language="csharp" source="view-compilation/samples/6.x/ViewCompilationSample/Snippets/Program.cs" id="snippet_AddRazorRuntimeCompilation" highlight="4":::

## Enable runtime compilation conditionally

Runtime compilation can be enabled conditionally, which ensures that the published output:

* Uses compiled views.
* Doesn't enable file watchers in production.

To enable runtime compilation only for the Development environment:

1. Install the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) NuGet package.
1. Call <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A> in `Program.cs` when the current environment is set to Development:

   :::code language="csharp" source="view-compilation/samples/6.x/ViewCompilationSample/Snippets/Program.cs" id="snippet_AddRazorRuntimeCompilationDevelopment" highlight="5-8":::

Runtime compilation can also be enabled with a [hosting startup assembly](xref:fundamentals/configuration/platform-specific-configuration). To enable runtime compilation in the Development environment for specific launch profiles:

1. Install the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) NuGet package.
1. Modify the launch profile's `environmentVariables` section in `launchSettings.json`:
   * Verify that `ASPNETCORE_ENVIRONMENT` is set to `"Development"`.
   * Set `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` to `"Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation"`. For example, the following `launchSettings.json` enables runtime compilation for the `ViewCompilationSample` and `IIS Express` launch profiles:

      :::code language="json" source="view-compilation/samples/6.x/ViewCompilationSample/Snippets/launchSettings.json" highlight="17-18,25-26":::

With this approach, no code changes are needed in `Program.cs`. At runtime, ASP.NET Core searches for an [assembly-level HostingStartup attribute](xref:fundamentals/configuration/platform-specific-configuration#hostingstartup-attribute) in `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation`. The `HostingStartup` attribute specifies the app startup code to execute and that startup code enables runtime compilation.

## Enable runtime compilation for a Razor Class Library

Consider a scenario in which a Razor Pages project references a [Razor Class Library (RCL)](xref:razor-pages/ui-class) named *MyClassLib*. The RCL contains a `_Layout.cshtml` file consumed by MVC and Razor Pages projects. To enable runtime compilation for the `_Layout.cshtml` file in that RCL, make the following changes in the Razor Pages project:

1. Enable runtime compilation with the instructions at [Enable runtime compilation conditionally](#enable-runtime-compilation-conditionally).
1. Configure <xref:Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.MvcRazorRuntimeCompilationOptions> in `Program.cs`:

    :::code language="csharp" source="view-compilation/samples/6.x/ViewCompilationSample/Snippets/Program.cs" id="snippet_ConfigureMvcRazorRuntimeCompilationOptions" highlight="5-11":::

    The preceding code builds an absolute path to the *MyClassLib* RCL. The [PhysicalFileProvider API](xref:fundamentals/file-providers#physicalfileprovider) is used to locate directories and files at that absolute path. Finally, the `PhysicalFileProvider` instance is added to a file providers collection, which allows access to the RCL's `.cshtml` files.

## Additional resources

* [RazorCompileOnBuild and RazorCompileOnPublish](xref:razor-pages/sdk#properties) properties
* <xref:razor-pages/index>
* <xref:mvc/views/overview>
* <xref:razor-pages/sdk>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Razor files with a `.cshtml` extension are compiled at both build and publish time using the [Razor SDK](xref:razor-pages/sdk). Runtime compilation may be optionally enabled by configuring your project.

## Razor compilation

Build-time and publish-time compilation of Razor files is enabled by default by the Razor SDK. When enabled, runtime compilation complements build-time compilation, allowing Razor files to be updated if they're edited.

## Enable runtime compilation at project creation

The Razor Pages and MVC project templates include an option to enable runtime compilation when the project is created. This option is supported in ASP.NET Core 3.1 and later.

# [Visual Studio](#tab/visual-studio)

In the **Create a new ASP.NET Core web application** dialog:

1. Select either the **Web Application** or the **Web Application (Model-View-Controller)** project template.
1. Select the **Enable Razor runtime compilation** checkbox.

# [.NET Core CLI](#tab/netcore-cli)

Use the `-rrc` or `--razor-runtime-compilation` template option. For example, the following command creates a new Razor Pages project with runtime compilation enabled:

```dotnetcli
dotnet new webapp --razor-runtime-compilation
```

---

## Enable runtime compilation in an existing project

To enable runtime compilation for all environments in an existing project:

1. Install the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) NuGet package.
1. Update the project's `Startup.ConfigureServices` method to include a call to <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A>. For example:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages()
            .AddRazorRuntimeCompilation();

        // code omitted for brevity
    }
    ```

## Conditionally enable runtime compilation in an existing project

Runtime compilation can be enabled such that it's only available for local development. Conditionally enabling in this manner ensures that the published output:

* Uses compiled views.
* Doesn't enable file watchers in production.

To enable runtime compilation only in the Development environment:

1. Install the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) NuGet package.
1. Modify the launch profile `environmentVariables` section in `launchSettings.json`:
    * Verify `ASPNETCORE_ENVIRONMENT` is set to `"Development"`.
    * Set `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` to `"Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation"`.

In the following example, runtime compilation is enabled in the Development environment for the `IIS Express` and `RazorPagesApp` launch profiles:

:::code language="json" source="view-compilation/samples_snapshot/3.x/launchSettings.json" highlight="15-16,24-25":::

No code changes are needed in the project's `Startup` class. At runtime, ASP.NET Core searches for an [assembly-level HostingStartup attribute](xref:fundamentals/configuration/platform-specific-configuration#hostingstartup-attribute) in `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation`. The `HostingStartup` attribute specifies the app startup code to execute. That startup code enables runtime compilation.

## Enable runtime compilation for a Razor Class Library

Consider a scenario in which a Razor Pages project references a [Razor Class Library (RCL)](xref:razor-pages/ui-class) named *MyClassLib*. The RCL contains a `_Layout.cshtml` file that all of your team's MVC and Razor Pages projects consume. You want to enable runtime compilation for the `_Layout.cshtml` file in that RCL. Make the following changes in the Razor Pages project:

1. Enable runtime compilation with the instructions at [Conditionally enable runtime compilation in an existing project](#conditionally-enable-runtime-compilation-in-an-existing-project).
1. Configure the runtime compilation options in `Startup.ConfigureServices`:

    :::code language="csharp" source="view-compilation/samples_snapshot/3.x/Startup.cs" id="snippet_ConfigureServices" highlight="5-10":::

    In the preceding code, an absolute path to the *MyClassLib* RCL is constructed. The [PhysicalFileProvider API](xref:fundamentals/file-providers#physicalfileprovider) is used to locate directories and files at that absolute path. Finally, the `PhysicalFileProvider` instance is added to a file providers collection, which allows access to the RCL's `.cshtml` files.

## Additional resources

* [RazorCompileOnBuild and RazorCompileOnPublish](xref:razor-pages/sdk#properties) properties
* <xref:razor-pages/index>
* <xref:mvc/views/overview>
* <xref:razor-pages/sdk>

:::moniker-end
