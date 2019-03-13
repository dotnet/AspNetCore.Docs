---
title: Razor Components Class Libraries
author: guardrex
description: Discover how components can be included in Razor Components apps from an external component library.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 03/13/2019
uid: razor-components/class-libraries
---
# Razor Components Class Libraries

By [Simon Timms](https://github.com/stimms)

Components can be shared in Razor class libraries across projects. Components can be included from:

* Another project in the solution.
* A NuGet package.
* A referenced .NET library.

Just as components are regular .NET types, components provided by Razor class libraries are normal .NET assemblies.

Use the `razorclasslib` (Razor class library) template with the [dotnet new](/dotnet/core/tools/dotnet-new) command:

```console
dotnet new razorclasslib -o MyComponentLib1
```

Add Razor Component files (*.razor*) to the Razor class library.

To add the library to an existing project, use the [dotnet sln](/dotnet/core/tools/dotnet-sln) command:

# [Visual Studio](#tab/visual-studio)

```console
dotnet sln add .\MyComponentLib1
```

# [.NET Core CLI](#tab/netcore-cli)

```console
dotnet add WebApplication1 reference MyComponentLib1
```

---

> [!NOTE]
> Razor class libraries aren't compatible with Blazor apps in ASP.NET Core Preview 3.
>
> To create components in a library that can be shared with Blazor and Razor Components apps, use a Blazor class library created by the `blazorlib` template.
>
> Razor class libraries don't support static assets in ASP.NET Core Preview 3. Component libraries using the `blazorlib` template can include static files, such as images, JavaScript, and stylesheets. At build time, static files are embedded into the built assembly file (*.dll*), which allows consumption of the components without having to worry about how to include their resources. Any files included in the `content` directory are marked as an embedded resource.

## Consume a library component

In order to consume components defined in a library in another project, the [@addTagHelper](/aspnet/core/mvc/views/tag-helpers/intro#add-helper-label) directive must be used. Individual components may be added by name. For example, the following directive adds `Component1` of `MyComponentLib1`:

```cshtml
@addTagHelper MyComponentLib1.Component1, MyComponentLib1

<h1>Hello, world!</h1>

Welcome to your new app.

<Component1 />
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

When using the `blazorlib` template, any included static resources are included in the NuGet package. Library consumers automatically receive scripts and stylesheets, so consumers aren't required to manually install the resources.
