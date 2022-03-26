---
title: Use ASP.NET Core APIs in a class library
author: rick-anderson
description: Learn how to use ASP.NET Core APIs in a class library.
ms.author: scaddie
ms.custom: mvc
ms.date: 12/16/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/target-aspnetcore
---
# Use ASP.NET Core APIs in a class library

By [Scott Addie](https://github.com/scottaddie)

This document provides guidance for using ASP.NET Core APIs in a class library. For all other library guidance, see [Open-source library guidance](/dotnet/standard/library-guidance/).

## Determine which ASP.NET Core versions to support

ASP.NET Core adheres to the [.NET Core support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core). Consult the support policy when determining which ASP.NET Core versions to support in a library. A library should:

* Make an effort to support all ASP.NET Core versions classified as *Long-Term Support* (LTS).
* Not feel obligated to support ASP.NET Core versions classified as *End of Life* (EOL).

As preview releases of ASP.NET Core are made available, breaking changes are posted in the [aspnet/Announcements](https://github.com/aspnet/Announcements/issues) GitHub repository. Compatibility testing of libraries can be conducted as framework features are being developed.

## Use the ASP.NET Core shared framework

With the release of .NET Core 3.0, many ASP.NET Core assemblies are no longer published to NuGet as packages. Instead, the assemblies are included in the `Microsoft.AspNetCore.App` shared framework, which is installed with the .NET Core SDK and runtime installers. For a list of packages no longer being published, see [Remove obsolete package references](xref:migration/22-to-30#remove-obsolete-package-references).

As of .NET Core 3.0, projects using the `Microsoft.NET.Sdk.Web` MSBuild SDK implicitly reference the shared framework. Projects using the `Microsoft.NET.Sdk` or `Microsoft.NET.Sdk.Razor` SDK must reference ASP.NET Core to use ASP.NET Core APIs in the shared framework.

To reference ASP.NET Core, add the following `<FrameworkReference>` element to your project file:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.1-basic-library.csproj?highlight=8)]

## Include Blazor extensibility

Blazor supports WebAssembly (WASM) and server-based [hosting models](xref:blazor/hosting-models). Unless there's a specific reason not to support both hosting models, a [Razor components](xref:blazor/components/index) library should support both hosting models. A Razor components library must use the [Microsoft.NET.Sdk.Razor SDK](xref:razor-pages/sdk).

### Support both hosting models

To support Razor component consumption by [Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) and [Blazor Server](xref:blazor/hosting-models#blazor-server) projects, use the following instructions for your editor.

# [Visual Studio](#tab/visual-studio)

Use the **Razor Class Library** project template.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following command in the integrated terminal:

```dotnetcli
dotnet new razorclasslib
```

# [Visual Studio for Mac](#tab/visual-studio-mac)

Use the **Razor Class Library** project template.

---

:::moniker range=">= aspnetcore-5.0"

The library generated from the project template:

* Targets the current .NET framework based on the installed SDK.
* Enables browser compatibility checks for platform dependencies by including `browser` as a supported platform with the `SupportedPlatform` MSBuild item.
* Adds a NuGet package reference for [Microsoft.AspNetCore.Components.Web](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web).

Example:

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

  <PropertyGroup>
    <TargetFramework>{TARGET FRAMEWORK}</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <SupportedPlatform Include="browser" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Components.Web" Version="{VERSION}" />
  </ItemGroup>

</Project>
```

In the preceding example:

* The `{TARGET FRAMEWORK}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks).
* The `{VERSION}` placeholder is the version of the [`Microsoft.AspNetCore.Components.Web`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web) package.

### Only support the Blazor Server hosting model

Class libraries rarely only support [Blazor Server](xref:blazor/hosting-models#blazor-server) apps. If the class library requires [Blazor Server](xref:blazor/hosting-models#blazor-server)-specific features, such as access to <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler>s or <xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage>, or uses ASP.NET Core-specific features, such as middleware, MVC controllers, or Razor Pages, use **one** of the following approaches:

* Specify that the library supports pages and views when the project is created with the **Support pages and views** checkbox (Visual Studio) or the `-s|--support-pages-and-views` option with the `dotnet new` command:

  ```dotnetcli
  dotnet new razorclasslib -s true
  ```

* Only provide a framework reference to ASP.NET Core in the library's project file:

  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Razor">

    <ItemGroup>
      <FrameworkReference Include="Microsoft.AspNetCore.App" />
    </ItemGroup>

  </Project>
  ```

### Support multiple framework versions

If the library must support features added to Blazor in the current release while also supporting one or more earlier releases, multi-target the library. Provide a semicolon-separated list of [Target Framework Monikers (TFMs)](/dotnet/standard/frameworks) in the `TargetFrameworks` MSBuild property:

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

  <PropertyGroup>
    <TargetFrameworks>{TARGET FRAMEWORKS}</TargetFrameworks>
  </PropertyGroup>

  <ItemGroup>
    <SupportedPlatform Include="browser" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Components.Web" Version="{VERSION}" />
  </ItemGroup>

</Project>
```

In the preceding example:

* The `{TARGET FRAMEWORKS}` placeholder represents the semicolon-separated TFMs list. For example, `netcoreapp3.1;net5.0`.
* The `{VERSION}` placeholder is the version of the [`Microsoft.AspNetCore.Components.Web`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web) package.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

The project generated from the template:

* Targets .NET Standard 2.0.
* Sets the `RazorLangVersion` property to `3.0`. `3.0` is the default value for .NET Core 3.x.
* Adds the following package references:
  * [Microsoft.AspNetCore.Components](https://www.nuget.org/packages/Microsoft.AspNetCore.Components)
  * [Microsoft.AspNetCore.Components.Web](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web)

For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netstandard2.0-razor-components-library.csproj)]

### Support a specific hosting model

It's far less common to support a single Blazor hosting model. As an example, to support Razor component consumption from [Blazor Server](xref:blazor/hosting-models#blazor-server) projects only:

* Target .NET Core 3.x.
* Add a `<FrameworkReference>` element for the shared framework.

For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.1-razor-components-library.csproj)]

:::moniker-end

For more information on libraries containing Razor components, see <xref:blazor/components/class-libraries>.

## Include MVC extensibility

This section outlines recommendations for libraries that include:

* [Razor views or Razor Pages](#razor-views-or-razor-pages)
* [Tag Helpers](#tag-helpers)
* [View components](#view-components)

This section doesn't discuss multi-targeting to support multiple versions of MVC. For guidance on supporting multiple ASP.NET Core versions, see [Support multiple ASP.NET Core versions](#support-multiple-aspnet-core-versions).

### Razor views or Razor Pages

A project that includes [Razor views](xref:mvc/views/overview) or [Razor Pages](xref:razor-pages/index) must use the [Microsoft.NET.Sdk.Razor SDK](xref:razor-pages/sdk).

If the project targets .NET Core 3.x, it requires:

* An `AddRazorSupportForMvc` MSBuild property set to `true`.
* A `<FrameworkReference>` element for the shared framework.

The **Razor Class Library** project template satisfies the preceding requirements for projects targeting .NET Core 3.x. Use the following instructions for your editor.

# [Visual Studio](#tab/visual-studio)

Use the **Razor Class Library** project template. The template's **Support pages and views** checkbox should be selected.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following command in the integrated terminal:

```dotnetcli
dotnet new razorclasslib -s
```

# [Visual Studio for Mac](#tab/visual-studio-mac)

No project template support at this time.

---

For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.1-razor-views-pages-library.csproj)]

If the project targets .NET Standard instead, a [Microsoft.AspNetCore.Mvc](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc) package reference is required. The `Microsoft.AspNetCore.Mvc` package moved into the shared framework in ASP.NET Core 3.0 and is therefore no longer published. For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netstandard2.0-razor-views-pages-library.csproj?highlight=8)]

### Tag Helpers

A project that includes [Tag Helpers](xref:mvc/views/tag-helpers/intro) should use the `Microsoft.NET.Sdk` SDK. If targeting .NET Core 3.x, add a `<FrameworkReference>` element for the shared framework. For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.1-basic-library.csproj)]

If targeting .NET Standard (to support versions earlier than ASP.NET Core 3.x), add a package reference to [Microsoft.AspNetCore.Mvc.Razor](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor). The `Microsoft.AspNetCore.Mvc.Razor` package moved into the shared framework and is therefore no longer published. For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netstandard2.0-tag-helpers-library.csproj)]

### View components

A project that includes [View components](xref:mvc/views/view-components) should use the `Microsoft.NET.Sdk` SDK. If targeting .NET Core 3.x, add a `<FrameworkReference>` element for the shared framework. For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.1-basic-library.csproj)]

If targeting .NET Standard (to support versions earlier than ASP.NET Core 3.x), add a package reference to [Microsoft.AspNetCore.Mvc.ViewFeatures](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.ViewFeatures). The `Microsoft.AspNetCore.Mvc.ViewFeatures` package moved into the shared framework and is therefore no longer published. For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netstandard2.0-view-components-library.csproj)]

## Support multiple ASP.NET Core versions

Multi-targeting is required to author a library that supports multiple variants of ASP.NET Core. Consider a scenario in which a Tag Helpers library must support the following ASP.NET Core variants:

* ASP.NET Core 2.1 targeting .NET Framework 4.6.1
* ASP.NET Core 2.x targeting .NET Core 2.x
* ASP.NET Core 3.x targeting .NET Core 3.x

The following project file supports these variants via the `TargetFrameworks` property:

[!code-xml[](target-aspnetcore/samples/multi-tfm/recommended-tag-helpers-library.csproj)]

With the preceding project file:

* The `Markdig` package is added for all consumers.
* A reference to [Microsoft.AspNetCore.Mvc.Razor](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor) is added for consumers targeting .NET Framework 4.6.1 or later or .NET Core 2.x. Version 2.1.0 of the package works with ASP.NET Core 2.2 because of backwards compatibility.
* The shared framework is referenced for consumers targeting .NET Core 3.x. The `Microsoft.AspNetCore.Mvc.Razor` package is included in the shared framework.

Alternatively, .NET Standard 2.0 could be targeted instead of targeting both .NET Core 2.1 and .NET Framework 4.6.1:

[!code-xml[](target-aspnetcore/samples/multi-tfm/alternative-tag-helpers-library.csproj?highlight=4)]

With the preceding project file, the following caveats exist:

* Since the library only contains Tag Helpers, it's more straightforward to target the specific platforms on which ASP.NET Core runs: .NET Core and .NET Framework. Tag Helpers can't be used by other .NET Standard 2.0-compliant target frameworks such as Unity, UWP, and Xamarin.
* Using .NET Standard 2.0 from .NET Framework has some issues that were addressed in .NET Framework 4.7.2. You can improve the experience for consumers using .NET Framework 4.6.1 through 4.7.1 by targeting .NET Framework 4.6.1.

If your library needs to call platform-specific APIs, target specific .NET implementations instead of .NET Standard. For more information, see [Multi-targeting](/dotnet/standard/library-guidance/cross-platform-targeting#multi-targeting).

## Use an API that hasn't changed

Imagine a scenario in which you're upgrading a middleware library from .NET Core 2.2 to 3.1. The ASP.NET Core middleware APIs being used in the library haven't changed between ASP.NET Core 2.2 and 3.1. To continue supporting the middleware library in .NET Core 3.1, take the following steps:

* Follow the [standard library guidance](/dotnet/standard/library-guidance/).
* Add a package reference for each API's NuGet package if the corresponding assembly doesn't exist in the shared framework.

## Use an API that changed

Imagine a scenario in which you're upgrading a library from .NET Core 2.2 to .NET Core 3.1. An ASP.NET Core API being used in the library has a [breaking change](/dotnet/core/compatibility/breaking-changes) in ASP.NET Core 3.1. Consider whether the library can be rewritten to not use the broken API in all versions.

If you can rewrite the library, do so and continue to target an earlier target framework (for example, .NET Standard 2.0 or .NET Framework 4.6.1) with package references.

If you can't rewrite the library, take the following steps:

* Add a target for .NET Core 3.1.
* Add a `<FrameworkReference>` element for the shared framework.
* Use the [#if preprocessor directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) with the appropriate target framework symbol to conditionally compile code.

For example, synchronous reads and writes on HTTP request and response streams are disabled by default as of ASP.NET Core 3.1. ASP.NET Core 2.2 supports the synchronous behavior by default. Consider a middleware library in which synchronous reads and writes should be enabled where I/O is occurring. The library should enclose the code to enable synchronous features in the appropriate preprocessor directive. For example:

[!code-csharp[](target-aspnetcore/samples/middleware.cs?highlight=9-24)]

## Use an API introduced in 3.1

Imagine that you want to use an ASP.NET Core API that was introduced in ASP.NET Core 3.1. Consider the following questions:

1. Does the library functionally require the new API?
1. Can the library implement this feature in a different way?

If the library functionally requires the API and there's no way to implement it down-level:

* Target .NET Core 3.x only.
* Add a `<FrameworkReference>` element for the shared framework.

If the library can implement the feature in a different way:

* Add .NET Core 3.x as a target framework.
* Add a `<FrameworkReference>` element for the shared framework.
* Use the [#if preprocessor directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) with the appropriate target framework symbol to conditionally compile code.

For example, the following Tag Helper uses the <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> interface introduced in ASP.NET Core 3.1. Consumers targeting .NET Core 3.1 execute the code path defined by the `NETCOREAPP3_1` target framework symbol. The Tag Helper's constructor parameter type changes to <xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment> for .NET Core 2.1 and .NET Framework 4.6.1 consumers. This change was necessary because ASP.NET Core 3.1 marked `IHostingEnvironment` as obsolete and recommended `IWebHostEnvironment` as the replacement.

```csharp
[HtmlTargetElement("script", Attributes = "asp-inline")]
public class ScriptInliningTagHelper : TagHelper
{
    private readonly IFileProvider _wwwroot;

#if NETCOREAPP3_1
    public ScriptInliningTagHelper(IWebHostEnvironment env)
#else
    public ScriptInliningTagHelper(IHostingEnvironment env)
#endif
    {
        _wwwroot = env.WebRootFileProvider;
    }

    // code omitted for brevity
}
```

The following multi-targeted project file supports this Tag Helper scenario:

[!code-xml[](target-aspnetcore/samples/multi-tfm/recommended-tag-helpers-library.csproj)]

## Use an API removed from the shared framework

To use an ASP.NET Core assembly that was removed from the shared framework, add the appropriate package reference. For a list of packages removed from the shared framework in ASP.NET Core 3.1, see [Remove obsolete package references](xref:migration/22-to-30#remove-obsolete-package-references).

For example, to add the web API client:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <FrameworkReference Include="Microsoft.AspNetCore.App" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNet.WebApi.Client" Version="5.2.7" />
  </ItemGroup>

</Project>
```

## Additional resources

* <xref:razor-pages/ui-class>
* <xref:blazor/components/class-libraries>
* [.NET implementation support](/dotnet/standard/net-standard#net-implementation-support)
* [.NET support policies](https://dotnet.microsoft.com/platform/support/policy)
