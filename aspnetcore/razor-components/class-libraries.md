---
title: Razor Components Class Libraries
author: guardrex
description: Discover how components can be included in Razor Components apps from an external component library.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/29/2019
uid: razor-components/class-libraries
---
# Razor Components Class Libraries

By [Simon Timms](https://github.com/stimms)

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

> [!NOTE]
> The .NET Core 3.0 Preview 2 SDK doesn't include a project template for Razor Component Class Libraries, but we expect to add a template in a future preview. In meantime, you can use the Blazor Component Class Library template explained in this topic.

Components can be shared in component libraries across projects. Components can be included from:

* Another project in the solution.
* A NuGet package.
* A referenced .NET library.

Just as components are regular .NET types, component libraries are normal .NET assemblies.

To create a new component library, use the `blazorlib` template with the [dotnet new](/dotnet/core/tools/dotnet-new) command. The template is part of the templates installed when [setting up Razor Components](/aspnet/core/razor-components/get-started.html#setup).

```console
dotnet new blazorlib -o MyComponentLib1
```

To add the library to an existing project, use the [dotnet sln](/dotnet/core/tools/dotnet-sln) command:

```console
dotnet sln add .\MyComponentLib1
```

Component libraries may contain static files, such as images, JavaScript, and stylesheets. At build time, static files are embedded into the built assembly file (*.dll*), which allows consumption of the components without having to worry about how to include their resources. Any files included in the `content` directory are marked as an embedded resource. 

## Consume a library component

In order to consume components defined in a library in another project, the [@addTagHelper](/aspnet/core/mvc/views/tag-helpers/intro#add-helper-label) directive must be used. Individual components may be added by name. For example, the following directive adds `Component1` of `MyComponentLib1`:

```cshtml
@addTagHelper MyComponentLib1.Component1, MyComponentLib1
```

The general format of the directive is:

```cshtml
@addTagHelper <namespaced component name>, <assembly name>
```

However, it's common to include all of the components from an assembly using a wildcard:

```cshtml
@addTagHelper *, MyComponentLib1
```

The `@addTagHelper` directive can be included in *_ViewImport.cshtml* to make the components available for an entire project or applied to a single page or set of pages within a folder. With the `@addTagHelper` directive in place, the components of the component library can be consumed as if they were in the same assembly as the app. 

## Build, pack, and ship to NuGet

Because component libraries are standard .NET libraries, packaging and shipping them to NuGet is no different from packaging and shipping any library to NuGet. Packaging is performed using the [dotnet pack](/dotnet/core/tools/dotnet-pack) command:

```console
dotnet pack
```

Upload the package to NuGet using the [dotnet nuget publish](/dotnet/core/tools/dotnet-nuget-push) command:

```console
dotnet nuget publish
```

Any included static resources are included in the NuGet package. Library consumers automatically receive scripts and stylesheets, so consumers aren't required to manually install the resources.
