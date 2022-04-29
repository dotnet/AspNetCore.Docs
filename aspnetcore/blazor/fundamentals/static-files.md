---
title: ASP.NET Core Blazor static files
author: guardrex
description: Learn how to configure and manage static files for Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/static-files
---
# ASP.NET Core Blazor static files

This article describes the configuration for serving static files in Blazor apps.

For more information on *solutions* in sections that apply to hosted Blazor WebAssembly apps, see <xref:blazor/tooling#visual-studio-solution-file-sln>.

:::moniker range=">= aspnetcore-6.0"

## Static File Middleware

*This section applies to Blazor Server apps and the `**Server**` app of a hosted Blazor WebAssembly solution.*

Configure Static File Middleware to serve static assets to clients by calling <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in the app's request processing pipeline. For more information, see <xref:fundamentals/static-files>.

## Static web asset base path

*This section applies to standalone Blazor WebAssembly apps and hosted Blazor WebAssembly solutions.*

By default, publishing a Blazor WebAssembly app places the app's static assets, including Blazor framework files (`_framework` folder assets), at the root path (`/`) in published output. The `<StaticWebAssetBasePath>` property specified in the project file (`.csproj`) sets the base path to a non-root path:

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>{PATH}</StaticWebAssetBasePath>
</PropertyGroup>
```

In the preceding example, the `{PATH}` placeholder is the path.

The `<StaticWebAssetBasePath>` property is most commonly used to control the paths to published static assets of multiple Blazor WebAssembly apps in a single hosted deployment. For more information, see <xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps>. The property is also effective in standalone Blazor WebAssembly apps.

Without setting the `<StaticWebAssetBasePath>` property, the client app of a hosted solution or a standalone app is published at the following paths:

* In the **`Server`** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/`
* In a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/`

In the preceding examples, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

If the `<StaticWebAssetBasePath>` property in the **`Client`** project of a hosted Blazor WebAssembly app or in a standalone Blazor WebAssembly app sets the published static asset path to `app1`, the root path to the app in published output is `/app1`.

In the **`Client`** app's project file (`.csproj`) or the standalone Blazor WebAssembly app's project file (`.csproj`):

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>app1</StaticWebAssetBasePath>
</PropertyGroup>
```

In published output:

* Path to the client app in the **`Server`** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/app1/`
* Path to a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/app1/`

In the preceding examples, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

## Blazor Server file mappings and static file options

To create additional file mappings with a <xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider> or configure other <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>, use **one** of the following approaches. In the following examples, the `{EXTENSION}` placeholder is the file extension, and the `{CONTENT TYPE}` placeholder is the content type.

* Configure options through [dependency injection (DI)](xref:blazor/fundamentals/dependency-injection) in `Program.cs` using <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>:

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

  Because this approach configures the same file provider used to serve `blazor.server.js`, make sure that your custom configuration doesn't interfere with serving `blazor.server.js`. For example, don't remove the mapping for JavaScript files by configuring the provider with `provider.Mappings.Remove(".js")`.

* Use two calls to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in `Program.cs`:
  * Configure the custom file provider in the first call with <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>.
  * The second middleware serves `blazor.server.js`, which uses the default static files configuration provided by the Blazor framework.

  ```csharp
  using Microsoft.AspNetCore.StaticFiles;

  ...

  var provider = new FileExtensionContentTypeProvider();
  provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

  app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
  app.UseStaticFiles();
  ```

* You can avoid interfering with serving `_framework/blazor.server.js` by using <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> to execute a custom Static File Middleware:

  ```csharp
  app.MapWhen(ctx => !ctx.Request.Path
      .StartsWithSegments("/_framework/blazor.server.js"),
          subApp => subApp.UseStaticFiles(new StaticFileOptions() { ... }));
  ```

## Additional resources

* [App base path](xref:blazor/host-and-deploy/index#app-base-path)
* [Hosted deployment with multiple Blazor WebAssembly apps](xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Static File Middleware

*This section applies to Blazor Server apps and the `**Server**` app of a hosted Blazor WebAssembly solution.*

Configure Static File Middleware to serve static assets to clients by calling <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in the app's request processing pipeline. For more information, see <xref:fundamentals/static-files>.

## Static web asset base path

*This section applies to standalone Blazor WebAssembly apps and hosted Blazor WebAssembly solutions.*

By default, publishing a Blazor WebAssembly app places the app's static assets, including Blazor framework files (`_framework` folder assets), at the root path (`/`) in published output. The `<StaticWebAssetBasePath>` property specified in the project file (`.csproj`) sets the base path to a non-root path:

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>{PATH}</StaticWebAssetBasePath>
</PropertyGroup>
```

In the preceding example, the `{PATH}` placeholder is the path.

The `<StaticWebAssetBasePath>` property is most commonly used to control the paths to published static assets of multiple Blazor WebAssembly apps in a single hosted deployment. For more information, see <xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps>. The property is also effective in standalone Blazor WebAssembly apps.

Without setting the `<StaticWebAssetBasePath>` property, the client app of a hosted solution or a standalone app is published at the following paths:

* In the **`Server`** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/`
* In a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/`

In the preceding examples, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

If the `<StaticWebAssetBasePath>` property in the **`Client`** project of a hosted Blazor WebAssembly app or in a standalone Blazor WebAssembly app sets the published static asset path to `app1`, the root path to the app in published output is `/app1`.

In the **`Client`** app's project file (`.csproj`) or the standalone Blazor WebAssembly app's project file (`.csproj`):

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>app1</StaticWebAssetBasePath>
</PropertyGroup>
```

In published output:

* Path to the client app in the **`Server`** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/app1/`
* Path to a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/app1/`

In the preceding examples, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

## Blazor Server file mappings and static file options

To create additional file mappings with a <xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider> or configure other <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>, use **one** of the following approaches. In the following examples, the `{EXTENSION}` placeholder is the file extension, and the `{CONTENT TYPE}` placeholder is the content type.

* Configure options through [dependency injection (DI)](xref:blazor/fundamentals/dependency-injection) in `Startup.ConfigureServices` (`Startup.cs`) using <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>:

  ```csharp
  using Microsoft.AspNetCore.StaticFiles;

  ...

  var provider = new FileExtensionContentTypeProvider();
  provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

  services.Configure<StaticFileOptions>(options =>
  {
      options.ContentTypeProvider = provider;
  });
  ```

  Because this approach configures the same file provider used to serve `blazor.server.js`, make sure that your custom configuration doesn't interfere with serving `blazor.server.js`. For example, don't remove the mapping for JavaScript files by configuring the provider with `provider.Mappings.Remove(".js")`.

* Use two calls to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in `Startup.Configure` (`Startup.cs`):
  * Configure the custom file provider in the first call with <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>.
  * The second middleware serves `blazor.server.js`, which uses the default static files configuration provided by the Blazor framework.

  ```csharp
  using Microsoft.AspNetCore.StaticFiles;

  ...

  var provider = new FileExtensionContentTypeProvider();
  provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

  app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
  app.UseStaticFiles();
  ```

* You can avoid interfering with serving `_framework/blazor.server.js` by using <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> to execute a custom Static File Middleware:

  ```csharp
  app.MapWhen(ctx => !ctx.Request.Path
      .StartsWithSegments("/_framework/blazor.server.js"),
          subApp => subApp.UseStaticFiles(new StaticFileOptions() { ... }));
  ```

## Additional resources

* [App base path](xref:blazor/host-and-deploy/index#app-base-path)
* [Hosted deployment with multiple Blazor WebAssembly apps](xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Static File Middleware

Configure Static File Middleware to serve static assets to clients by calling <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in the app's request processing pipeline. Multiple calls to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> is supported when static files exist at multiple locations:

```csharp
app.UseStaticFiles();
app.UseStaticFiles("/static");
```

For more information, see <xref:fundamentals/static-files>.

## Static web asset base path

*This section applies to standalone Blazor WebAssembly apps and hosted Blazor WebAssembly solutions.*

By default, publishing a Blazor WebAssembly app places the app's static assets, including Blazor framework files (`_framework` folder assets), at the root path (`/`) in published output. The `<StaticWebAssetBasePath>` property specified in the project file (`.csproj`) sets the base path to a non-root path:

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>{PATH}</StaticWebAssetBasePath>
</PropertyGroup>
```

In the preceding example, the `{PATH}` placeholder is the path.

The `<StaticWebAssetBasePath>` property is most commonly used to control the paths to published static assets of multiple Blazor WebAssembly apps in a single hosted deployment. For more information, see <xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps>. The property is also effective in standalone Blazor WebAssembly apps.

Without setting the `<StaticWebAssetBasePath>` property, the client app of a hosted solution or a standalone app is published at the following paths:

* In the **`Server`** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/`
* In a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/`

In the preceding examples, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

If the `<StaticWebAssetBasePath>` property in the **`Client`** project of a hosted Blazor WebAssembly app or in a standalone Blazor WebAssembly app sets the published static asset path to `app1`, the root path to the app in published output is `/app1`.

In the **`Client`** app's project file (`.csproj`) or the standalone Blazor WebAssembly app's project file (`.csproj`):

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>app1</StaticWebAssetBasePath>
</PropertyGroup>
```

In published output:

* Path to the client app in the **`Server`** project of a hosted Blazor WebAssembly solution: `/BlazorHostedSample/Server/bin/Release/{TFM}/publish/wwwroot/app1/`
* Path to a standalone Blazor WebAssembly app: `/BlazorStandaloneSample/bin/Release/{TFM}/publish/wwwroot/app1/`

In the preceding examples, the `{TFM}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) (for example, `net6.0`).

## Blazor Server file mappings and static file options

To create additional file mappings with a <xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider> or configure other <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>, use **one** of the following approaches. In the following examples, the `{EXTENSION}` placeholder is the file extension, and the `{CONTENT TYPE}` placeholder is the content type.

* Configure options through [dependency injection (DI)](xref:blazor/fundamentals/dependency-injection) in `Startup.ConfigureServices` (`Startup.cs`) using <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>:

  ```csharp
  using Microsoft.AspNetCore.StaticFiles;

  ...

  var provider = new FileExtensionContentTypeProvider();
  provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

  services.Configure<StaticFileOptions>(options =>
  {
      options.ContentTypeProvider = provider;
  });
  ```

  Because this approach configures the same file provider used to serve `blazor.server.js`, make sure that your custom configuration doesn't interfere with serving `blazor.server.js`. For example, don't remove the mapping for JavaScript files by configuring the provider with `provider.Mappings.Remove(".js")`.

* Use two calls to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in `Startup.Configure` (`Startup.cs`):
  * Configure the custom file provider in the first call with <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>.
  * The second middleware serves `blazor.server.js`, which uses the default static files configuration provided by the Blazor framework.

  ```csharp
  using Microsoft.AspNetCore.StaticFiles;

  ...

  var provider = new FileExtensionContentTypeProvider();
  provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

  app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
  app.UseStaticFiles();
  ```

* You can avoid interfering with serving `_framework/blazor.server.js` by using <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> to execute a custom Static File Middleware:

  ```csharp
  app.MapWhen(ctx => !ctx.Request.Path
      .StartsWithSegments("/_framework/blazor.server.js"),
          subApp => subApp.UseStaticFiles(new StaticFileOptions() { ... }));
  ```

## Additional resources

* [App base path](xref:blazor/host-and-deploy/index#app-base-path)
* [Hosted deployment with multiple Blazor WebAssembly apps](xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps)

:::moniker-end
