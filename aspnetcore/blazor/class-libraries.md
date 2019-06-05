---
title: Razor components class libraries
author: guardrex
description: Discover how components can be included in Blazor apps from an external component library.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/06/2019
uid: blazor/class-libraries
---
# Razor components class libraries

By [Simon Timms](https://github.com/stimms)

Components can be shared in Razor class libraries across projects. Components can be included from:

* Another project in the solution.
* A NuGet package.
* A referenced .NET library.

Just as components are regular .NET types, components provided by Razor class libraries are normal .NET assemblies.

## Create a Razor class library

Follow the guidance in the <xref:blazor/get-started> article to configure your environment for Blazor.

# [Visual Studio](#tab/visual-studio)

1. Create a new project.
1. Select **ASP.NET Core Web Application**. Select **Next**.
1. Provide a project name in the **Project name** field or accept the default project name. The examples in this topic use the project name `MyComponentLib1`. Select **Create**.
1. In the **Create a new ASP.NET Core Web Application** dialog, confirm that **.NET Core** and **ASP.NET Core 3.0** are selected.
1. Select the **Razor Class Library** template. Select **Create**.
1. Add the Razor class library to a solution:
   1. Right-click the solution. Select **Add** > **Existing Project**.
   1. Navigate to the Razor class library's project file.
   1. Select the Razor class library's project file (*.csproj*).
1. Add a reference the Razor class library from the app:
   1. Right-click the app project. Select **Add** > **Reference**.
   1. Select the Razor class library project. Select **OK**.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

1. Use the Razor class library (`razorclasslib`) template with the [dotnet new](/dotnet/core/tools/dotnet-new) command from a command shell. In the following example, a Razor class library is created named `MyComponentLib1`. The folder that holds `MyComponentLib1` is created automatically when the command is executed.

   ```console
   dotnet new razorclasslib -o MyComponentLib1
   ```

1. To add the library to an existing project, use the [dotnet add reference](/dotnet/core/tools/dotnet-add-reference) command from a command shell. In the following example, the Razor class library is added to the app. Execute the following command from the app's project folder with the path to the library:

   ```console
   dotnet add reference {PATH TO LIBRARY}
   ```

---

Add Razor component files (*.razor*) to the Razor class library.

## Razor class libraries not supported for client-side apps

In ASP.NET Core 3.0 Preview, Razor class libraries aren't compatible with Blazor client-side apps.

For Blazor client-side apps, use a Blazor component library created by the `blazorlib` template from a command shell:

```console
dotnet new blazorlib -o MyComponentLib1
```

Component libraries using the `blazorlib` template can include static files, such as images, JavaScript, and stylesheets. At build time, static files are embedded into the built assembly file (*.dll*), which allows consumption of the components without having to worry about how to include their resources. Any files included in the `content` directory are marked as an embedded resource.

## Static assets not supported for server-side apps

In ASP.NET Core 3.0 Preview, Blazor server-side apps can't consume static assets from either a Razor class library (`razorclasslib`) or a Blazor library (`blazorlib`).

As a temporary workaround, you can try [BlazorEmbedLibrary](https://www.nuget.org/packages/BlazorEmbedLibrary/).

> [!NOTE]
> [BlazorEmbedLibrary](https://www.nuget.org/packages/BlazorEmbedLibrary/) isn't maintained or supported by Microsoft.

## Consume a library component

In order to consume components defined in a library in another project, use either of the following approaches:

* Use the full type name with the namespace.
* Use Razor's [\@using](xref:mvc/views/razor#using) directive. Individual components can be added by name.

In the following examples, `MyComponentLib1` is a component library containing a Sales Report (`SalesReport`) component.

The Sales Report component can be referenced using its full type name with namespace:

```cshtml
<h1>Hello, world!</h1>

Welcome to your new app.

<MyComponentLib1.SalesReport />
```

The component can also be referenced if the library is brought into scope with an `@using` directive:

```cshtml
@using MyComponentLib1

<h1>Hello, world!</h1>

Welcome to your new app.

<SalesReport />
```

Include the `@using MyComponentLib1` directive in the top-level *_Import.razor* file to make the library's components available to an entire project. Add the directive to an *_Import.razor* file at any level to apply the namespace to a single page or set of pages within a folder.

## Build, pack, and ship to NuGet

Because component libraries are standard .NET libraries, packaging and shipping them to NuGet is no different from packaging and shipping any library to NuGet. Packaging is performed using the [dotnet pack](/dotnet/core/tools/dotnet-pack) command from a command shell:

```console
dotnet pack
```

Upload the package to NuGet using the [dotnet nuget publish](/dotnet/core/tools/dotnet-nuget-push) command from a command shell:

```console
dotnet nuget publish
```

When using the `blazorlib` template, static resources are included in the NuGet package. Library consumers automatically receive scripts and stylesheets, so consumers aren't required to manually install the resources. Note that [static assets aren't supported for server-side apps](#static-assets-not-supported-for-server-side-apps), including when a Blazor library (`blazorlib`) is referenced by a server-side app.

## Create a razor class library with static assets

Razor class libraries (RCL) frequently require companion static assets that can be referenced by the consuming app of the RCL. ASP.NET Core allows creating RCLs that include static assets that are available to a consuming app.

To include companion assets as part of a razor class library, create a *wwwroot* folder in the class library and include any required files in that folder.

When packing a Razor class library, all companion assets in the *wwwroot* folder are included in the package automatically and are made available to apps referencing the package.

### Consume content from a referenced razor class library

The files included under the *wwwroot* folder of the razor class library are exposed on the consuming app under the prefix `_content/<<libraryname>>/`. The consuming app can reference these assets within script, style, img, etc. tags.

### Multi-project development flow

When the app runs:

* The assets stay in their original folders.
* Any change within the class library *wwwroot* folder is reflected on the app without rebuilding.

At build time, a manifest is produced with all the static web asset locations. The manifest is read at runtime and allows the app to consume the assets from referenced projects and packages.

### Publish

When the app is published, the companion assets from all referenced projects and packages get copied into the *wwwroot* folder of the published app under `_content/<<libraryname>>/`.
