---
title: ASP.NET Core Blazor app download size performance best practices
author: guardrex
description: Tips for reducing app download size in ASP.NET Core Blazor apps and avoiding common performance problems.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 05/02/2025
uid: blazor/performance/app-download-size
---
# ASP.NET Core Blazor app download size performance best practices

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-6.0"

## Runtime relinking

For information on how runtime relinking minimizes an app's download size, see <xref:blazor/tooling/webassembly#runtime-relinking>.

:::moniker-end

## Use `System.Text.Json`

Blazor's JS interop implementation relies on <xref:System.Text.Json>, which is a high-performance JSON serialization library with low memory allocation. Using <xref:System.Text.Json> shouldn't result in additional app payload size over adding one or more alternate JSON libraries.

For migration guidance, see [How to migrate from `Newtonsoft.Json` to `System.Text.Json`](/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to).

## Intermediate Language (IL) trimming

*This section only applies to client-side Blazor scenarios.*

:::moniker range=">= aspnetcore-5.0"

Trimming unused assemblies from a Blazor WebAssembly app reduces the app's size by removing unused code in the app's binaries. For more information, see <xref:blazor/host-and-deploy/configure-trimmer>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

[Linking a Blazor WebAssembly app](xref:blazor/host-and-deploy/configure-linker) reduces the app's size by trimming unused code in the app's binaries. The Intermediate Language (IL) Linker is only enabled when building in `Release` configuration. To benefit from this, publish the app for deployment using the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command with the [-c|--configuration](/dotnet/core/tools/dotnet-publish#options) option set to `Release`:

```dotnetcli
dotnet publish -c Release
```

:::moniker-end

## Lazy load assemblies

*This section only applies to client-side Blazor scenarios.*

Load assemblies at runtime when the assemblies are required by a route. For more information, see <xref:blazor/webassembly-lazy-load-assemblies>.

## Compression

*This section only applies to Blazor WebAssembly apps.*

When a Blazor WebAssembly app is published, the output is statically compressed during publish to reduce the app's size and remove the overhead for runtime compression. Blazor relies on the server to perform content negotiation and serve statically-compressed files.

After an app is deployed, verify that the app serves compressed files. Inspect the **Network** tab in a browser's [developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) and verify that the files are served with `Content-Encoding: br` (Brotli compression) or `Content-Encoding: gz` (Gzip compression). If the host isn't serving compressed files, follow the instructions in <xref:blazor/host-and-deploy/webassembly/index#compression>.

## Disable unused features

*This section only applies to client-side Blazor scenarios.*

Blazor WebAssembly's runtime includes the following .NET features that can be disabled for a smaller payload size.

Blazor WebAssembly carries globalization resources required to display values, such as dates and currency, in the user's culture. If the app doesn't require localization, you may configure the app to [support the invariant culture](xref:blazor/globalization-localization#invariant-globalization), which is based on the `en-US` culture. Apply the `<InvariantGlobalization>` MSBuild property with a value of `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

:::moniker range=">= aspnetcore-8.0"

Adopting [invariant globalization](xref:blazor/globalization-localization#invariant-globalization) only results in using non-localized timezone names. To trim timezone code and data from the app, apply the `<InvariantTimezone>` MSBuild property with a value of `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <InvariantTimezone>true</InvariantTimezone>
</PropertyGroup>
```

> [!NOTE]
> [`<BlazorEnableTimeZoneSupport>`](xref:blazor/performance/app-download-size#disable-unused-features) overrides an earlier `<InvariantTimezone>` setting. We recommend removing the `<BlazorEnableTimeZoneSupport>` setting.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

A data file is included to make timezone information correct. If the app doesn't require this feature, consider disabling it by setting the `<BlazorEnableTimeZoneSupport>` MSBuild property to `false` in the app's project file:

```xml
<PropertyGroup>
  <BlazorEnableTimeZoneSupport>false</BlazorEnableTimeZoneSupport>
</PropertyGroup>
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Collation information is included to make APIs such as <xref:System.StringComparison.InvariantCultureIgnoreCase?displayProperty=nameWithType> work correctly. If you're certain that the app doesn't require the collation data, consider disabling it by setting the `BlazorWebAssemblyPreserveCollationData` MSBuild property in the app's project file to `false`:

```xml
<PropertyGroup>
  <BlazorWebAssemblyPreserveCollationData>false</BlazorWebAssemblyPreserveCollationData>
</PropertyGroup>
```

:::moniker-end

## Additional resources

[Configuring and hosting .NET WebAssembly applications](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/features.md)
