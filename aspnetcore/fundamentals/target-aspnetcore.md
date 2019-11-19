---
title: Use ASP.NET Core APIs in a class library
author: scottaddie
description: Learn how to use ASP.NET Core APIs in a class library.
monikerRange: '>= aspnetcore-3.0'
ms.author: scaddie
ms.custom: mvc
ms.date: 11/18/2019
no-loc: [Blazor]
uid: fundamentals/target-aspnetcore
---
# Use ASP.NET Core APIs in a class library

By [Scott Addie](https://github.com/scottaddie)

This document provides guidance for using ASP.NET Core APIs in a class library. For all other library guidance, see [Open-source library guidance](/dotnet/standard/library-guidance/).

## Use the ASP.NET Core shared framework

With the release of .NET Core 3.0, many ASP.NET Core packages are no longer published to NuGet. Instead, the packages are included in the `Microsoft.AspNetCore.App` shared framework, which is installed with the .NET Core SDK. The shared framework was previously distributed as a NuGet package. For a list of packages no longer being published, see [Remove obsolete package references](xref:migration/22-to-30#remove-obsolete-package-references).

As of .NET Core 3.0, projects:

* Using the `Microsoft.NET.Sdk.Web` MSBuild SDK implicitly reference the shared framework.
* With dependencies on ASP.NET Core APIs in the shared framework need to target ASP.NET Core.

To target ASP.NET Core, add the following `<FrameworkReference>` element to your project file:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.0-basic-library.csproj?highlight=8)]

Targeting ASP.NET Core in this manner is only supported for projects targeting .NET Core 3.0.

## Include UI components

The following sections outline recommendations for libraries that include UI components. This guidance assumes the library won't multi-target. For guidance on supporting multiple ASP.NET Core versions, see [Support multiple versions](#support-multiple-versions).

### Razor views or Razor Pages

A project that includes [Razor views](xref:mvc/views/overview) or [Razor Pages](xref:razor-pages/index) must use the [Microsoft.NET.Sdk.Razor SDK](xref:razor-pages/sdk).

If the project targets .NET Core 3.0, it requires:

* An `AddRazorSupportForMvc` MSBuild property set to `true`.
* A `<FrameworkReference>` element for the shared framework.

For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.0-razor-views-pages-library.csproj)]

If the project targets .NET Standard 2.0 instead, it requires a [Microsoft.AspNetCore.Mvc](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc) package reference. For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netstandard2.0-razor-views-pages-library.csproj?highlight=8)]

### Razor components

A project that includes [Razor components](xref:blazor/components) must use the [Microsoft.NET.Sdk.Razor SDK](xref:razor-pages/sdk).

To support Razor component consumption from [Blazor Server](xref:blazor/hosting-models#blazor-server) only:

* Target .NET Core 3.0.
* Add a `<FrameworkReference>` element for the shared framework.

For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.0-razor-components-library.csproj)]

To support Razor component consumption from both Blazor Server and [Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly):

* Target .NET Standard 2.0.
* Add the following package references:
  * [Microsoft.AspNetCore.Components](https://www.nuget.org/packages/Microsoft.AspNetCore.Components)
  * [Microsoft.AspNetCore.Components.Web](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web)
* Set the `RazorLangVersion` property to `3.0`. `3.0` is the default value for .NET Core 3.0.

For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netstandard2.0-razor-components-library.csproj)]

For more information on libraries containing Razor components, see [ASP.NET Core Razor components class libraries](xref:blazor/class-libraries).

### Tag Helpers or view components

A project that includes [Tag Helpers](xref:mvc/views/tag-helpers/intro) or [View components](xref:mvc/views/view-components) should:

* Target .NET Core 3.0.
* Add a `<FrameworkReference>` element for the shared framework.

For example:

[!code-xml[](target-aspnetcore/samples/single-tfm/netcoreapp3.0-basic-library.csproj)]

## Support multiple versions

Multi-targeting is required to author a library that supports multiple variants of ASP.NET Core. Consider a scenario in which a Tag Helpers library must support the following ASP.NET Core variants:

* ASP.NET Core 2.1 targeting .NET Framework 4.6.1
* ASP.NET Core 2.x targeting .NET Core 2.x
* ASP.NET Core 3.0 targeting .NET Core 3.0

The following project file supports these variants via the `TargetFrameworks` property:

[!code-xml[](target-aspnetcore/samples/multi-tfm/recommended-tag-helpers-library.csproj)]

With the preceding project file:

* The `Markdig` package is added for all consumers.
* A reference to [Microsoft.AspNetCore.Mvc.Razor](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor) is added for consumers targeting .NET Framework 4.6.1 or .NET Core 2.x. Version 2.1.0 of the package works with ASP.NET Core 2.2 because of backwards compatibility.
* The shared framework is referenced for consumers targeting .NET Core 3.0. The `Microsoft.AspNetCore.Mvc.Razor` package is included in the shared framework.

Alternatively, .NET Standard 2.0 could be targeted instead of targeting both .NET Core 2.1 and .NET Framework 4.6.1:

[!code-xml[](target-aspnetcore/samples/multi-tfm/alternative-tag-helpers-library.csproj?highlight=4)]

With the preceding project file, .NET Core 2.x and .NET Framework 4.6.1 projects are supported because both target frameworks implement .NET Standard 2.0. Since this library only contains Tag Helpers, it's more efficient to target the specific platforms on which ASP.NET Core runs: .NET Core and .NET Framework. Tag Helpers can't be used by other .NET Standard 2.0-compliant target frameworks such as Unity, UWP, and Xamarin. If your library needs to call platform-specific APIs, target specific .NET implementations instead of .NET Standard. For more information, see [Multi-targeting](/dotnet/standard/library-guidance/cross-platform-targeting#multi-targeting).

## Use an API that hasn't changed

Imagine a scenario in which you're upgrading a middleware library from .NET Core 2.2 to 3.0. The ASP.NET Core middleware APIs being used in the library haven't changed between ASP.NET Core 2.2 and 3.0. To continue supporting a middleware library in .NET Core 3.0, take the following steps:

* Follow the [standard library guidance](/dotnet/standard/library-guidance/).
* Add a `<PackageReference>` element for the API's NuGet package.

## Use an API that changed

Imagine a scenario in which you're upgrading a library from .NET Core 2.2 to .NET Core 3.0. An ASP.NET Core API being used in the library has a [breaking change](/dotnet/core/compatibility/breaking-changes) in ASP.NET Core 3.0. Consider whether the library can be rewritten to not use the broken API in all versions.

If you can rewrite the library, do so and continue to target an earlier target framework (for example, .NET Standard 2.0 or .NET Framework 4.6.1) with package references.

If you can't rewrite the library, take the following steps:

* Add a target for .NET Core 3.0.
* Add a `<FrameworkReference>` element for the shared framework.
* Use the [#if preprocessor directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) with the appropriate target framework symbol to conditionally compile code.

For example, synchronous reads and writes on HTTP request and response streams are disabled by default in ASP.NET Core 3.0. ASP.NET Core 2.2 supports the synchronous behavior by default. Consider a library in which synchronous reads and writes should be enabled in Kestrel. The library should enclose the code to enable synchronous features in the appropriate preprocessor directive. For example:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // code omitted for brevity

#if NETCOREAPP3_0
    services.Configure<KestrelServerOptions>(options =>
        options.AllowSynchronousIO = true);
#endif
}
```

## Use an API introduced in 3.0

Imagine that you want to use an ASP.NET Core API that was introduced in ASP.NET Core 3.0. Consider the following questions:

1. Does the library functionally require the new API?
1. Can the library implement this feature in a different way?

If the library functionally requires the API and there's no way to implement it down-level:

* Target .NET Core 3.0 only.
* Add a `<FrameworkReference>` element for the shared framework.

If the library can implement the feature in a different way:

* Add .NET Core 3.0 as a target framework.
* Add a `<FrameworkReference>` element for the shared framework.
* Use the [#if preprocessor directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) with the appropriate target framework symbol to conditionally compile code.

For example, the following Tag Helper uses the <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> interface introduced in ASP.NET Core 3.0. Consumers targeting .NET Core 3.0 execute the code path defined by the `NETCOREAPP3_0` target framework symbol. The Tag Helper's constructor parameter type changes to <xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment> for .NET Core 2.1 and .NET Framework 4.6.1 consumers. This change was necessary because `IHostingEnvironment` was marked as obsolete in ASP.NET Core 3.0 in favor of `IWebHostEnvironment`.

```csharp
[HtmlTargetElement("script", Attributes = "asp-inline")]
public class ScriptInliningTagHelper : TagHelper
{
    private readonly IFileProvider _wwwroot;

#if NETCOREAPP3_0
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

## Use an API removed from shared framework

TODO
<!--To use an ASP.NET Core assembly that was removed from the shared framework:

TODO: e.g. Tag Helpers, WebApiClient, JsonPatch, EF Core, Identity, JSON.NET
* Some of these libraries will continue to function in 3.0 apps
* Should be multi-targeted to `netcoreapp3.0` for best consumption experience
  * e.g. avoid unused dependencies appearing in application *bin*
  * Ensure new versions of package-only dependencies are deployed with app-->

## Additional resources

* <xref:razor-pages/ui-class>
* <xref:blazor/class-libraries>
* [.NET implementation support](/dotnet/standard/net-standard#net-implementation-support)
