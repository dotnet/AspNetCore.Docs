---
title: ASP.NET Core Blazor static files
author: guardrex
description: Learn how to configure and manage static files for Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/fundamentals/static-files
---
# ASP.NET Core Blazor static files

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes Blazor app configuration for serving static files.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

:::moniker range=">= aspnetcore-8.0"

## Static Web Asset Project Mode

*This section applies to the `.Client` project of a Blazor Web App.*

The required `<StaticWebAssetProjectMode>Default</StaticWebAssetProjectMode>` setting in the `.Client` project of a Blazor Web App reverts Blazor WebAssembly static asset behaviors back to the defaults, so that the project behaves as part of the hosted project. The Blazor WebAssembly SDK (`Microsoft.NET.Sdk.BlazorWebAssembly`) configures static web assets in a specific way to work in "standalone" mode with a server simply consuming the outputs from the library. This isn't appropriate for a Blazor Web App, where the WebAssembly portion of the app is a logical part of the host and must behave more like a library. For example, the project doesn't expose the styles bundle (for example, `BlazorSample.Client.styles.css`) and instead only provides the host with the project bundle, so that the host can include it in its own styles bundle.

:::moniker-end

## Static File Middleware

*This section applies to server-side Blazor apps.*

Configure Static File Middleware to serve static assets to clients by calling <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in the app's request processing pipeline. For more information, see <xref:fundamentals/static-files>.

## Static files in non-`Development` environments

*This section applies to server-side static files.*

When running an app locally, static web assets are only enabled by default in the <xref:Microsoft.Extensions.Hosting.Environments.Development> environment. To enable static files for environments other than <xref:Microsoft.Extensions.Hosting.Environments.Development> during local development and testing (for example, <xref:Microsoft.Extensions.Hosting.Environments.Staging>), call <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStaticWebAssets%2A> on the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> in the `Program` file.

> [!WARNING]
> Call <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStaticWebAssets%2A> for the ***exact environment*** to prevent activating the feature in production, as it serves files from separate locations on disk *other than from the project* if called in a production environment. The example in this section checks for the <xref:Microsoft.Extensions.Hosting.Environments.Staging> environment by calling <xref:Microsoft.Extensions.Hosting.HostEnvironmentEnvExtensions.IsStaging%2A>.

```csharp
if (builder.Environment.IsStaging())
{
    builder.WebHost.UseStaticWebAssets();
}
```

:::moniker range=">= aspnetcore-8.0"

## Prefix for Blazor WebAssembly assets

*This section applies to Blazor Web Apps.*

Use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Server.WebAssemblyComponentsEndpointOptions.PathPrefix?displayProperty=nameWithType> endpoint option to set the path string that indicates the prefix for Blazor WebAssembly assets. The path must correspond to a referenced Blazor WebAssembly application project.

```csharp
endpoints.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode(options => 
        options.PathPrefix = "{PATH PREFIX}");
```

In the preceding example, the `{PATH PREFIX}` placeholder is the path prefix and must start with a forward slash (`/`).

In the following example, the path prefix is set to `/path-prefix`:

```csharp
endpoints.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode(options => 
        options.PathPrefix = "/path-prefix");
```

:::moniker-end

## Static web asset base path

:::moniker range=">= aspnetcore-8.0"

*This section applies to standalone Blazor WebAssembly apps.*

By default, publishing the app places the app's static assets, including Blazor framework files (`_framework` folder assets), at the root path (`/`) in published output. The `<StaticWebAssetBasePath>` property specified in the project file (`.csproj`) sets the base path to a non-root path:

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>{PATH}</StaticWebAssetBasePath>
</PropertyGroup>
```

In the preceding example, the `{PATH}` placeholder is the path.

Without setting the `<StaticWebAssetBasePath>` property, a standalone app is published at `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/`.

In the preceding example, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

If the `<StaticWebAssetBasePath>` property in a standalone Blazor WebAssembly app sets the published static asset path to `app1`, the root path to the app in published output is `/app1`.

In the standalone Blazor WebAssembly app's project file (`.csproj`):

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>app1</StaticWebAssetBasePath>
</PropertyGroup>
```

In published output, the path to the standalone Blazor WebAssembly app is `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/app1/`.

In the preceding example, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to standalone Blazor WebAssembly apps and hosted Blazor WebAssembly solutions.*

By default, publishing the app places the app's static assets, including Blazor framework files (`_framework` folder assets), at the root path (`/`) in published output. The `<StaticWebAssetBasePath>` property specified in the project file (`.csproj`) sets the base path to a non-root path:

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>{PATH}</StaticWebAssetBasePath>
</PropertyGroup>
```

In the preceding example, the `{PATH}` placeholder is the path.

Without setting the `<StaticWebAssetBasePath>` property, the client app of a hosted solution or a standalone app is published at the following paths:

* In the **:::no-loc text="Server":::** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/`
* In a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/`

If the `<StaticWebAssetBasePath>` property in the **:::no-loc text="Client":::** project of a hosted Blazor WebAssembly app or in a standalone Blazor WebAssembly app sets the published static asset path to `app1`, the root path to the app in published output is `/app1`.

In the **:::no-loc text="Client":::** app's project file (`.csproj`) or the standalone Blazor WebAssembly app's project file (`.csproj`):

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>app1</StaticWebAssetBasePath>
</PropertyGroup>
```

In published output:

* Path to the client app in the **:::no-loc text="Server":::** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/app1/`
* Path to a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/app1/`

The `<StaticWebAssetBasePath>` property is most commonly used to control the paths to published static assets of multiple Blazor WebAssembly apps in a single hosted deployment. For more information, see <xref:blazor/host-and-deploy/multiple-hosted-webassembly>. The property is also effective in standalone Blazor WebAssembly apps.

In the preceding examples, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

:::moniker-end

## File mappings and static file options

*This section applies to server-side static files.*

To create additional file mappings with a <xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider> or configure other <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>, use **one** of the following approaches. In the following examples, the `{EXTENSION}` placeholder is the file extension, and the `{CONTENT TYPE}` placeholder is the content type.

* Configure options through [dependency injection (DI)](xref:blazor/fundamentals/dependency-injection) in the `Program` file using <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>:

  ```csharp
  using Microsoft.AspNetCore.StaticFiles;

  ...

  var provider = new FileExtensionContentTypeProvider();
  provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

  builder.Services.Configure<StaticFileOptions>(options =>
  {
      options.ContentTypeProvider = provider;
  });
  ```

  This approach configures the same file provider used to serve the Blazor script. Make sure that your custom configuration doesn't interfere with serving the Blazor script. For example, don't remove the mapping for JavaScript files by configuring the provider with `provider.Mappings.Remove(".js")`.

* Use two calls to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in the `Program` file:
  * Configure the custom file provider in the first call with <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>.
  * The second middleware serves the Blazor script, which uses the default static files configuration provided by the Blazor framework.

  ```csharp
  using Microsoft.AspNetCore.StaticFiles;

  ...

  var provider = new FileExtensionContentTypeProvider();
  provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

  app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
  app.UseStaticFiles();
  ```

:::moniker range=">= aspnetcore-8.0"

* You can avoid interfering with serving `_framework/blazor.web.js` by using <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> to execute a custom Static File Middleware:

  ```csharp
  app.MapWhen(ctx => !ctx.Request.Path
      .StartsWithSegments("/_framework/blazor.web.js"),
          subApp => subApp.UseStaticFiles(new StaticFileOptions() { ... }));
  ```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* You can avoid interfering with serving `_framework/blazor.server.js` by using <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> to execute a custom Static File Middleware:

  ```csharp
  app.MapWhen(ctx => !ctx.Request.Path
      .StartsWithSegments("/_framework/blazor.server.js"),
          subApp => subApp.UseStaticFiles(new StaticFileOptions() { ... }));
  ```

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-8.0"

[App base path](xref:blazor/host-and-deploy/index#app-base-path)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* [App base path](xref:blazor/host-and-deploy/index#app-base-path)
* <xref:blazor/host-and-deploy/multiple-hosted-webassembly>

:::moniker-end
