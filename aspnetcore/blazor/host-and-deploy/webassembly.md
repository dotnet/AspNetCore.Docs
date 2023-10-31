---
title: Host and deploy ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to host and deploy Blazor WebAssembly using ASP.NET Core, Content Delivery Networks (CDN), file servers, and GitHub Pages.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/host-and-deploy/webassembly
---
# Host and deploy ASP.NET Core Blazor WebAssembly

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy Blazor WebAssembly using ASP.NET Core, Content Delivery Networks (CDN), file servers, and GitHub Pages.

With the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser in parallel.
* The app is executed directly on the browser UI thread.

:::moniker range=">= aspnetcore-8.0"

This article pertains to the deployment scenario where the Blazor app is placed on a static hosting web server or service, .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The following deployment strategies are supported:

* The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
* The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.
* An ASP.NET Core app hosts multiple Blazor WebAssembly apps. For more information, see <xref:blazor/host-and-deploy/multiple-hosted-webassembly>.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Webcil packaging format for .NET assemblies

[Webcil](https://github.com/dotnet/runtime/blob/main/docs/design/mono/webcil.md) is a web-friendly packaging format for .NET assemblies designed to enable using Blazor WebAssembly in restrictive network environments. Webcil files use a standard WebAssembly wrapper, where the assemblies are deployed as WebAssembly files that use the standard `.wasm` file extension.

Webcil is the default packaging format when you publish a Blazor WebAssembly app. To disable the use of Webcil, set the following MS Build property in the app's project file:

```xml
<PropertyGroup>
  <WasmEnableWebcil>false</WasmEnableWebcil>
</PropertyGroup>
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Ahead-of-time (AOT) compilation

Blazor WebAssembly supports ahead-of-time (AOT) compilation, where you can compile your .NET code directly into WebAssembly. AOT compilation results in runtime performance improvements at the expense of a larger app size.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Without enabling AOT compilation, Blazor WebAssembly apps run on the browser using a .NET [Intermediate Language (IL)](/dotnet/standard/glossary#il) interpreter implemented in WebAssembly with partial [just-in-time (JIT)](/dotnet/standard/glossary#jit) runtime support, informally referred to as the *Jiterpreter*. Because the .NET IL code is interpreted, apps typically run slower than they would on a server-side .NET JIT runtime without any IL interpretation. AOT compilation addresses this performance issue by compiling an app's .NET code directly into WebAssembly for native WebAssembly execution by the browser. The AOT performance improvement can yield dramatic improvements for apps that execute CPU-intensive tasks. The drawback to using AOT compilation is that AOT-compiled apps are generally larger than their IL-interpreted counterparts, so they usually take longer to download to the client when first requested.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Without enabling AOT compilation, Blazor WebAssembly apps run on the browser using a .NET [Intermediate Language (IL)](/dotnet/standard/glossary#il) interpreter implemented in WebAssembly. Because the .NET code is interpreted, apps typically run slower than they would on a server-side .NET [just-in-time (JIT)](/dotnet/standard/glossary#jit) runtime. AOT compilation addresses this performance issue by compiling an app's .NET code directly into WebAssembly for native WebAssembly execution by the browser. The AOT performance improvement can yield dramatic improvements for apps that execute CPU-intensive tasks. The drawback to using AOT compilation is that AOT-compiled apps are generally larger than their IL-interpreted counterparts, so they usually take longer to download to the client when first requested.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

For guidance on installing the .NET WebAssembly build tools, see <xref:blazor/tooling#net-webassembly-build-tools>.

To enable WebAssembly AOT compilation, add the `<RunAOTCompilation>` property set to `true` to the Blazor WebAssembly app's project file:

```xml
<PropertyGroup>
  <RunAOTCompilation>true</RunAOTCompilation>
</PropertyGroup>
```

To compile the app to WebAssembly, publish the app. Publishing the `Release` configuration ensures the .NET Intermediate Language (IL) linking is also run to reduce the size of the published app:

```dotnetcli
dotnet publish -c Release
```

WebAssembly AOT compilation is only performed when the project is published. AOT compilation isn't used when the project is run during development (`Development` environment) because AOT compilation usually takes several minutes on small projects and potentially much longer for larger projects. Reducing the build time for AOT compilation is under development for future releases of ASP.NET Core.

The size of an AOT-compiled Blazor WebAssembly app is generally larger than the size of the app if compiled into .NET IL:

* Although the size difference depends on the app, most AOT-compiled apps are about twice the size of their IL-compiled versions. This means that using AOT compilation trades off load-time performance for runtime performance. Whether this tradeoff is worth using AOT compilation depends on your app. Blazor WebAssembly apps that are CPU intensive generally benefit the most from AOT compilation.

* The larger size of an AOT-compiled app is due to two conditions:

  * More code is required to represent high-level .NET IL instructions in native WebAssembly.
  * AOT does ***not*** trim out managed DLLs when the app is published. Blazor requires the DLLs for [reflection metadata](/dotnet/csharp/advanced-topics/reflection-and-attributes/) and to support certain .NET runtime features. Requiring the DLLs on the client increases the download size but provides a more compatible .NET experience.

> [!NOTE]
> For [Mono](https://github.com/mono/mono)/WebAssembly MSBuild properties and targets, see [`WasmApp.targets` (dotnet/runtime GitHub repository)](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/build/WasmApp.targets). Official documentation for common MSBuild properties is planned per [Document blazor msbuild configuration options (dotnet/docs #27395)](https://github.com/dotnet/docs/issues/27395).

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Trim .NET IL after ahead-of-time (AOT) compilation

The `WasmStripILAfterAOT` MSBuild option enables removing the .NET Intermediate Language (IL) for compiled methods after performing AOT compilation to WebAssembly, which reduces the size of the `_framework` folder.

In the app's project file:

```xml
<PropertyGroup>
  <RunAOTCompilation>true</RunAOTCompilation>
  <WasmStripILAfterAOT>true</WasmStripILAfterAOT>
</PropertyGroup>
```

This setting trims away the IL code for most compiled methods, including methods from libraries and methods in the app. Not all compiled methods can be trimmed, as some are still required by the .NET interpreter at runtime.

To report a problem with the trimming option, [open an issue on the `dotnet/runtime` GitHub repository](https://github.com/dotnet/runtime/issues).

Disable the trimming property if it prevents your app from running normally:

```xml
<WasmStripILAfterAOT>false</WasmStripILAfterAOT>
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Runtime relinking

One of the largest parts of a Blazor WebAssembly app is the WebAssembly-based .NET runtime (`dotnet.wasm`) that the browser must download when the app is first accessed by a user's browser. Relinking the .NET WebAssembly runtime trims unused runtime code and thus improves download speed.

Runtime relinking requires installation of the .NET WebAssembly build tools. For more information, see <xref:blazor/tooling#net-webassembly-build-tools>.

With the .NET WebAssembly build tools installed, runtime relinking is performed automatically when an app is **published** in the `Release` configuration. The size reduction is particularly dramatic when disabling globalization. For more information, see <xref:blazor/globalization-localization#invariant-globalization>.

> [!IMPORTANT]
> Runtime relinking trims class instance JavaScript-invokable .NET methods unless they're protected. For more information, see <xref:blazor/js-interop/call-dotnet-from-javascript#avoid-trimming-javascript-invokable-net-methods>.

:::moniker-end

## Customize how boot resources are loaded

Customize how boot resources are loaded using the `loadBootResource` API. For more information, see <xref:blazor/fundamentals/startup#load-boot-resources>.

## Compression

When a Blazor WebAssembly app is published, the output is statically compressed during publish to reduce the app's size and remove the overhead for runtime compression. The following compression algorithms are used:

* [Brotli](https://tools.ietf.org/html/rfc7932) (highest level)
* [Gzip](https://tools.ietf.org/html/rfc1952)

:::moniker range=">= aspnetcore-8.0"

Blazor relies on the host to serve the appropriate compressed files. When hosting a Blazor WebAssembly standalone app, additional work might be required to ensure that statically-compressed files are served:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Blazor relies on the host to serve the appropriate compressed files. When using an **ASP.NET Core Hosted** Blazor WebAssembly project, the host project is capable of performing content negotiation and serving the statically-compressed files. When hosting a Blazor WebAssembly standalone app, additional work might be required to ensure that statically-compressed files are served:

:::moniker-end

* For IIS `web.config` compression configuration, see the [IIS: Brotli and Gzip compression](#brotli-and-gzip-compression) section. 
* When hosting on static hosting solutions that don't support statically-compressed file content negotiation, consider configuring the app to fetch and decode Brotli compressed files:

Obtain the JavaScript Brotli decoder from the [google/brotli GitHub repository](https://github.com/google/brotli). The minified decoder file is named `decode.min.js` and found in the repository's [`js` folder](https://github.com/google/brotli/tree/master/js).
  
> [!NOTE]
> If the minified version of the `decode.js` script (`decode.min.js`) fails, try using the unminified version (`decode.js`) instead.

Update the app to use the decoder.
    
In the `wwwroot/index.html` file, set `autostart` to `false` on Blazor's `<script>` tag:
    
```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
```
    
After Blazor's `<script>` tag and before the closing `</body>` tag, add the following JavaScript code `<script>` block.

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script type="module">
  import { BrotliDecode } from './decode.min.js';
  Blazor.start({
    webAssembly: {
      loadBootResource: function (type, name, defaultUri, integrity) {
        if (type !== 'dotnetjs' && location.hostname !== 'localhost' && type !== 'configuration' && type !== 'manifest') {
          return (async function () {
            const response = await fetch(defaultUri + '.br', { cache: 'no-cache' });
            if (!response.ok) {
              throw new Error(response.statusText);
            }
            const originalResponseBuffer = await response.arrayBuffer();
            const originalResponseArray = new Int8Array(originalResponseBuffer);
            const decompressedResponseArray = BrotliDecode(originalResponseArray);
            const contentType = type === 
              'dotnetwasm' ? 'application/wasm' : 'application/octet-stream';
            return new Response(decompressedResponseArray, 
              { headers: { 'content-type': contentType } });
          })();
        }
      }
    }
  });
</script>
```

Standalone Blazor WebAssembly:

:::moniker-end

```html
<script type="module">
  import { BrotliDecode } from './decode.min.js';
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      if (type !== 'dotnetjs' && location.hostname !== 'localhost' && type !== 'configuration') {
        return (async function () {
          const response = await fetch(defaultUri + '.br', { cache: 'no-cache' });
          if (!response.ok) {
            throw new Error(response.statusText);
          }
          const originalResponseBuffer = await response.arrayBuffer();
          const originalResponseArray = new Int8Array(originalResponseBuffer);
          const decompressedResponseArray = BrotliDecode(originalResponseArray);
          const contentType = type === 
            'dotnetwasm' ? 'application/wasm' : 'application/octet-stream';
          return new Response(decompressedResponseArray, 
            { headers: { 'content-type': contentType } });
        })();
      }
    }
  });
</script>
```

For more information on loading boot resources, see <xref:blazor/fundamentals/startup#load-boot-resources>.

:::moniker range=">= aspnetcore-8.0"

To disable compression, add the `CompressionEnabled` MSBuild property to the app's project file and set the value to `false`:

```xml
<PropertyGroup>
  <CompressionEnabled>false</CompressionEnabled>
</PropertyGroup>
```

The `CompressionEnabled` property can be passed to the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command with the following syntax in a command shell:

```dotnetcli
dotnet publish -p:CompressionEnabled=false
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To disable compression, add the `BlazorEnableCompression` MSBuild property to the app's project file and set the value to `false`:

```xml
<PropertyGroup>
  <BlazorEnableCompression>false</BlazorEnableCompression>
</PropertyGroup>
```

The `BlazorEnableCompression` property can be passed to the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command with the following syntax in a command shell:

```dotnetcli
dotnet publish -p:BlazorEnableCompression=false
```

:::moniker-end

## Rewrite URLs for correct routing

Routing requests for page components in a Blazor WebAssembly app isn't as straightforward as routing requests in a Blazor Server app. Consider a Blazor WebAssembly app with two components:

* `Main.razor`: Loads at the root of the app and contains a link to the `About` component (`href="About"`).
* `About.razor`: `About` component.

When the app's default document is requested using the browser's address bar (for example, `https://www.contoso.com/`):

1. The browser makes a request.
1. The default page is returned, which is usually `index.html`.
1. `index.html` bootstraps the app.
1. Blazor's router loads, and the Razor `Main` component is rendered.

In the Main page, selecting the link to the `About` component works on the client because the Blazor router stops the browser from making a request on the Internet to `www.contoso.com` for `About` and serves the rendered `About` component itself. All of the requests for internal endpoints *within the Blazor WebAssembly app* work the same way: Requests don't trigger browser-based requests to server-hosted resources on the Internet. The router handles the requests internally.

If a request is made using the browser's address bar for `www.contoso.com/About`, the request fails. No such resource exists on the app's Internet host, so a *404 - Not Found* response is returned.

Because browsers make requests to Internet-based hosts for client-side pages, web servers and hosting services must rewrite all requests for resources not physically on the server to the `index.html` page. When `index.html` is returned, the app's Blazor router takes over and responds with the correct resource.

When deploying to an IIS server, you can use the URL Rewrite Module with the app's published `web.config` file. For more information, see the [IIS](#iis) section.

:::moniker range="< aspnetcore-8.0"

## Hosted deployment with ASP.NET Core

A *hosted deployment* serves the Blazor WebAssembly app to browsers from an [ASP.NET Core app](xref:index) that runs on a web server.

The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the server app. The two apps are deployed together. A web server that is capable of hosting an ASP.NET Core app is required. For a hosted deployment, Visual Studio includes the **Blazor WebAssembly App** project template (`blazorwasm` template when using the [`dotnet new`](/dotnet/core/tools/dotnet-new) command) with the **`Hosted`** option selected (`-ho|--hosted` when using the `dotnet new` command).

For more information, see the following articles:

* ASP.NET Core app hosting and deployment: <xref:host-and-deploy/index>
* Deployment to Azure App Service: <xref:tutorials/publish-to-azure-webapp-using-vs>
* Blazor project templates: <xref:blazor/project-structure>

## Hosted deployment of a framework-dependent executable for a specific platform

To deploy a hosted Blazor WebAssembly app as a [framework-dependent executable for a specific platform](/dotnet/core/deploying/#publish-framework-dependent) (not self-contained) use the following guidance based on the tooling in use.

### Visual Studio

By default, a [self-contained](/dotnet/core/deploying/#publish-self-contained) deployment is configured for a generated publish profile (`.pubxml`). Confirm that the **:::no-loc text="Server":::** project's publish profile contains the `<SelfContained>` MSBuild property set to `false`.

In the `.pubxml` publish profile file in the **:::no-loc text="Server":::** project's `Properties` folder:

```xml
<SelfContained>false</SelfContained>
```

Set the [Runtime Identifier (RID)](/dotnet/core/rid-catalog) using the **Target Runtime** setting in the **Settings** area of the **Publish** UI, which generates the `<RuntimeIdentifier>` MSBuild property in the publish profile:
  
```xml
<RuntimeIdentifier>{RID}</RuntimeIdentifier>
```

In the preceding configuration, the `{RID}` placeholder is the [Runtime Identifier (RID)](/dotnet/core/rid-catalog).

Publish the **:::no-loc text="Server":::** project in the **Release** configuration.

> [!NOTE]
> It's possible to publish an app with publish profile settings using the .NET CLI by passing `/p:PublishProfile={PROFILE}` to the [`dotnet publish` command](/dotnet/core/tools/dotnet-publish), where the `{PROFILE}` placeholder is the profile. For more information, see the *Publish profiles* and *Folder publish example* sections in the <xref:host-and-deploy/visual-studio-publish-profiles#publish-profiles> article. If you pass the RID in the [`dotnet publish` command](/dotnet/core/tools/dotnet-publish) and not in the publish profile, use the MSBuild property (`/p:RuntimeIdentifier`) with the command, ***not*** with the `-r|--runtime` option.

### .NET CLI

Configure a [self-contained](/dotnet/core/deploying/#publish-self-contained) deployment by placing the `<SelfContained>` MSBuild property in a `<PropertyGroup>` in the **:::no-loc text="Server":::** project's project file set to `false`:

```xml
<SelfContained>false</SelfContained>
```

> [!IMPORTANT]
> The `SelfContained` property must be placed in the **:::no-loc text="Server":::** project's project file. The property can't be set correctly with the [`dotnet publish` command](/dotnet/core/tools/dotnet-publish) using the `--no-self-contained` option or the MSBuild property `/p:SelfContained=false`.
  
Set the [Runtime Identifier (RID)](/dotnet/core/rid-catalog) using ***either*** of the following approaches:

* Option 1: Set the RID in a `<PropertyGroup>` in the **:::no-loc text="Server":::** project's project file:
  
  ```xml
  <RuntimeIdentifier>{RID}</RuntimeIdentifier>
  ```
    
  In the preceding configuration, the `{RID}` placeholder is the [Runtime Identifier (RID)](/dotnet/core/rid-catalog).
  
  Publish the app in the Release configuration from the **:::no-loc text="Server":::** project:
    
  ```dotnetcli
   dotnet publish -c Release
  ```

* Option 2: Pass the RID in the [`dotnet publish` command](/dotnet/core/tools/dotnet-publish) as the MSBuild property (`/p:RuntimeIdentifier`), ***not*** with the `-r|--runtime` option:
  
  ```dotnetcli
  dotnet publish -c Release /p:RuntimeIdentifier={RID}
  ```
    
  In the preceding command, the `{RID}` placeholder is the [Runtime Identifier (RID)](/dotnet/core/rid-catalog).

For more information, see the following articles:

* [.NET application publishing overview](/dotnet/core/deploying/)
* <xref:host-and-deploy/index>

:::moniker-end

:::moniker range="< aspnetcore-8.0"

## Hosted deployment with multiple Blazor WebAssembly apps

For more information, see <xref:blazor/host-and-deploy/multiple-hosted-webassembly>.

:::moniker-end

## Standalone deployment

A *standalone deployment* serves the Blazor WebAssembly app as a set of static files that are requested directly by clients. Any static file server is able to serve the Blazor app.

Standalone deployment assets are published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder.

### Azure App Service

Blazor WebAssembly apps can be deployed to Azure App Services on Windows, which hosts the app on [IIS](#iis).

Deploying a standalone Blazor WebAssembly app to Azure App Service for Linux isn't currently supported. We recommend hosting a standalone Blazor WebAssembly app using [Azure Static Web Apps](#azure-static-web-apps), which supports this scenario.

### Azure Static Web Apps

Deploy a Blazor WebAssembly app to Azure Static Web Apps using either of the following approaches:

* [Deploy from Visual Studio](#deploy-from-visual-studio)
* [Deploy from GitHub](#deploy-from-github)

#### Deploy from Visual Studio

To deploy from Visual Studio, create a publish profile for Azure Static Web Apps:

1. Save any unsaved work in the project, as a Visual Studio restart might be required during the process.

1. In Visual Studio's **Publish** UI, select **Target** > **Azure** > **Specific Target** > **Azure Static Web Apps** to create a [publish profile](xref:host-and-deploy/visual-studio-publish-profiles).

1. If the **Azure WebJobs Tools** component for Visual Studio isn't installed, a prompt appears to install the **ASP.NET and web development** component. Follow the prompts to install the tools using the Visual Studio Installer. Visual Studio closes and reopens automatically while installing the tools. After the tools are installed, start over at the first step to create the publish profile.

1. In the publish profile configuration, provide the **Subscription name**. Select an existing instance, or select **Create a new instance**. When creating a new instance in the Azure portal's **Create Static Web App** UI, set the **Deployment details** > **Source** to **Other**. Wait for the deployment to complete in the Azure portal before proceeding.

1. In the publish profile configuration, select the Azure Static Web Apps instance from the instance's resource group. Select **Finish** to create the publish profile. If Visual Studio prompts to install the Static Web Apps (SWA) CLI, install the CLI by following the prompts. The SWA CLI requires [NPM/Node.js (Visual Studio documentation)](/visualstudio/javascript/npm-package-management).

After the publish profile is created, deploy the app to the Azure Static Web Apps instance using the publish profile by selecting the **Publish** button.

#### Deploy from GitHub

To deploy from a GitHub repository, see [Tutorial: Building a static web app with Blazor in Azure Static Web Apps](/azure/static-web-apps/deploy-blazor).

### IIS

IIS is a capable static file server for Blazor apps. To configure IIS to host Blazor, see [Build a Static Website on IIS](/iis/manage/creating-websites/scenario-build-a-static-website-on-iis).

Published assets are created in the `/bin/Release/{TARGET FRAMEWORK}/publish` or `bin\Release\{TARGET FRAMEWORK}\browser-wasm\publish` folder, depending on which version of the SDK is used and where the `{TARGET FRAMEWORK}` placeholder is the target framework. Host the contents of the `publish` folder on the web server or hosting service.

#### web.config

When a Blazor project is published, a `web.config` file is created with the following IIS configuration:

* MIME types
* HTTP compression is enabled for the following MIME types:
  * `application/octet-stream`
  * `application/wasm`
* URL Rewrite Module rules are established:
  * Serve the sub-directory where the app's static assets reside (`wwwroot/{PATH REQUESTED}`).
  * Create SPA fallback routing so that requests for non-file assets are redirected to the app's default document in its static assets folder (`wwwroot/index.html`).
  
#### Use a custom `web.config`

To use a custom `web.config` file:

:::moniker range=">= aspnetcore-8.0"

1. Place the custom `web.config` file in the project's root folder.
1. Publish the project. For more information, see <xref:blazor/host-and-deploy/index>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

1. Place the custom `web.config` file in the project's root folder. For a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln), place the file in the **:::no-loc text="Server":::** project's folder.
1. Publish the project. For a hosted Blazor WebAssembly solution, publish the solution from the **:::no-loc text="Server":::** project. For more information, see <xref:blazor/host-and-deploy/index>.

:::moniker-end

If the SDK's `web.config` generation or transformation during publish either doesn't move the file to published assets in the `publish` folder or modifies the custom configuration in your custom `web.config` file, use any of the following approaches as needed to take full control of the process:

* If the SDK doesn't generate the file, for example, in a standalone Blazor WebAssembly app at `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` or `bin\Release\{TARGET FRAMEWORK}\browser-wasm\publish`, depending on which version of the SDK is used and where the `{TARGET FRAMEWORK}` placeholder is the target framework, set the `<PublishIISAssets>` property to `true` in the project file (`.csproj`). Usually for standalone WebAssembly apps, this is the only required setting to move a custom `web.config` file and prevent transformation of the file by the SDK.

  ```xml
  <PropertyGroup>
    <PublishIISAssets>true</PublishIISAssets>
  </PropertyGroup>
  ```

* Disable the SDK's `web.config` transformation in the project file (`.csproj`):

  ```xml
  <PropertyGroup>
    <IsTransformWebConfigDisabled>true</IsTransformWebConfigDisabled>
  </PropertyGroup>
  ```

* Add a custom target to the project file (`.csproj`) to move a custom `web.config` file. In the following example, the custom `web.config` file is placed by the developer at the root of the project. If the `web.config` file resides elsewhere, specify the path to the file in `SourceFiles`. The following example specifies the `publish` folder with `$(PublishDir)`, but provide a path to `DestinationFolder` for a custom output location.

  ```xml
  <Target Name="CopyWebConfig" AfterTargets="Publish">
    <Copy SourceFiles="web.config" DestinationFolder="$(PublishDir)" />
  </Target>
  ```

#### Install the URL Rewrite Module

The [URL Rewrite Module](https://www.iis.net/downloads/microsoft/url-rewrite) is required to rewrite URLs. The module isn't installed by default, and it isn't available for install as a Web Server (IIS) role service feature. The module must be downloaded from the IIS website. Use the Web Platform Installer to install the module:

1. Locally, navigate to the [URL Rewrite Module downloads page](https://www.iis.net/downloads/microsoft/url-rewrite#additionalDownloads). For the English version, select **WebPI** to download the WebPI installer. For other languages, select the appropriate architecture for the server (x86/x64) to download the installer.
1. Copy the installer to the server. Run the installer. Select the **Install** button and accept the license terms. A server restart isn't required after the install completes.

#### Configure the website

Set the website's **Physical path** to the app's folder. The folder contains:

* The `web.config` file that IIS uses to configure the website, including the required redirect rules and file content types.
* The app's static asset folder.

#### Host as an IIS sub-app

If a standalone app is hosted as an IIS sub-app, perform either of the following:

* Disable the inherited ASP.NET Core Module handler.

  Remove the handler in the Blazor app's published `web.config` file by adding a `<handlers>` section to the `<system.webServer>` section of the file:

  ```xml
  <handlers>
    <remove name="aspNetCore" />
  </handlers>
  ```

* Disable inheritance of the root (parent) app's `<system.webServer>` section using a `<location>` element with `inheritInChildApplications` set to `false`:

  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <configuration>
    <location path="." inheritInChildApplications="false">
      <system.webServer>
        <handlers>
          <add name="aspNetCore" ... />
        </handlers>
        <aspNetCore ... />
      </system.webServer>
    </location>
  </configuration>
  ```
  
  > [!NOTE]
  > Disabling inheritance of the root (parent) app's `<system.webServer>` section is the default configuration for published apps using the .NET SDK.

Removing the handler or disabling inheritance is performed in addition to [configuring the app's base path](xref:blazor/host-and-deploy/index#app-base-path). Set the app base path in the app's `index.html` file to the IIS alias used when configuring the sub-app in IIS.

#### Brotli and Gzip compression

:::moniker range=">= aspnetcore-8.0"

*This section only applies to standalone Blazor WebAssembly apps.*

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section only applies to standalone Blazor WebAssembly apps. Hosted Blazor apps use a default ASP.NET Core app `web.config` file, not the file linked in this section.*

:::moniker-end

IIS can be configured via `web.config` to serve Brotli or Gzip compressed Blazor assets for standalone Blazor WebAssembly apps. For an example configuration file, see [`web.config`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/host-and-deploy/webassembly/_samples/web.config?raw=true).

Additional configuration of the example `web.config` file might be required in the following scenarios:

* The app's specification calls for either of the following:
  * Serving compressed files that aren't configured by the example `web.config` file.
  * Serving compressed files configured by the example `web.config` file in an uncompressed format.
* The server's IIS configuration (for example, `applicationHost.config`) provides server-level IIS defaults. Depending on the server-level configuration, the app might require a different IIS configuration than what the example `web.config` file contains.

For more information on custom `web.config` files, see the [Use a custom `web.config`](#use-a-custom-webconfig) section.

#### Troubleshooting

If a *500 - Internal Server Error* is received and IIS Manager throws errors when attempting to access the website's configuration, confirm that the URL Rewrite Module is installed. When the module isn't installed, the `web.config` file can't be parsed by IIS. This prevents the IIS Manager from loading the website's configuration and the website from serving Blazor's static files.

For more information on troubleshooting deployments to IIS, see <xref:test/troubleshoot-azure-iis>.

### Azure Storage

[Azure Storage](/azure/storage/) static file hosting allows serverless Blazor app hosting. Custom domain names, the Azure Content Delivery Network (CDN), and HTTPS are supported.

When the blob service is enabled for static website hosting on a storage account:

* Set the **Index document name** to `index.html`.
* Set the **Error document path** to `index.html`. Razor components and other non-file endpoints don't reside at physical paths in the static content stored by the blob service. When a request for one of these resources is received that the Blazor router should handle, the *404 - Not Found* error generated by the blob service routes the request to the **Error document path**. The `index.html` blob is returned, and the Blazor router loads and processes the path.

If files aren't loaded at runtime due to inappropriate MIME types in the files' `Content-Type` headers, take either of the following actions:

* Configure your tooling to set the correct MIME types (`Content-Type` headers) when the files are deployed.
* Change the MIME types (`Content-Type` headers) for the files after the app is deployed.

  In Storage Explorer (Azure portal) for each file:
  
  1. Right-click the file and select **Properties**.
  1. Set the **ContentType** and select the **Save** button.

For more information, see [Static website hosting in Azure Storage](/azure/storage/blobs/storage-blob-static-website).

### Nginx

The following `nginx.conf` file is simplified to show how to configure Nginx to send the `index.html` file whenever it can't find a corresponding file on disk.

```
events { }
http {
    server {
        listen 80;

        location / {
            root      /usr/share/nginx/html;
            try_files $uri $uri/ /index.html =404;
        }
    }
}
```

When setting the [NGINX burst rate limit](https://www.nginx.com/blog/rate-limiting-nginx/#bursts) with [`limit_req`](https://nginx.org/docs/http/ngx_http_limit_req_module.html#limit_req), Blazor WebAssembly apps may require a large `burst` parameter value to accommodate the relatively large number of requests made by an app. Initially, set the value to at least 60:

```
http {
    server {
        ...

        location / {
            ...

            limit_req zone=one burst=60 nodelay;
        }
    }
}
```

Increase the value if browser developer tools or a network traffic tool indicates that requests are receiving a *503 - Service Unavailable* status code.

For more information on production Nginx web server configuration, see [Creating NGINX Plus and NGINX Configuration Files](https://docs.nginx.com/nginx/admin-guide/basic-functionality/managing-configuration-files/).

### Apache

To deploy a Blazor WebAssembly app to CentOS 7 or later:

1. Create the Apache configuration file. The following example is a simplified configuration file (`blazorapp.config`):

:::moniker range=">= aspnetcore-8.0"

   ```
   <VirtualHost *:80>
       ServerName www.example.com
       ServerAlias *.example.com

       DocumentRoot "/var/www/blazorapp"
       ErrorDocument 404 /index.html

       AddType application/wasm .wasm
   
       <Directory "/var/www/blazorapp">
           Options -Indexes
           AllowOverride None
       </Directory>

       <IfModule mod_deflate.c>
           AddOutputFilterByType DEFLATE text/css
           AddOutputFilterByType DEFLATE application/javascript
           AddOutputFilterByType DEFLATE text/html
           AddOutputFilterByType DEFLATE application/octet-stream
           AddOutputFilterByType DEFLATE application/wasm
           <IfModule mod_setenvif.c>
         BrowserMatch ^Mozilla/4 gzip-only-text/html
         BrowserMatch ^Mozilla/4.0[678] no-gzip
         BrowserMatch bMSIE !no-gzip !gzip-only-text/html
     </IfModule>
       </IfModule>

       ErrorLog /var/log/httpd/blazorapp-error.log
       CustomLog /var/log/httpd/blazorapp-access.log common
   </VirtualHost>
   ```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

   ```
   <VirtualHost *:80>
       ServerName www.example.com
       ServerAlias *.example.com

       DocumentRoot "/var/www/blazorapp"
       ErrorDocument 404 /index.html

       AddType application/wasm .wasm
       AddType application/octet-stream .dll
   
       <Directory "/var/www/blazorapp">
           Options -Indexes
           AllowOverride None
       </Directory>

       <IfModule mod_deflate.c>
           AddOutputFilterByType DEFLATE text/css
           AddOutputFilterByType DEFLATE application/javascript
           AddOutputFilterByType DEFLATE text/html
           AddOutputFilterByType DEFLATE application/octet-stream
           AddOutputFilterByType DEFLATE application/wasm
           <IfModule mod_setenvif.c>
         BrowserMatch ^Mozilla/4 gzip-only-text/html
         BrowserMatch ^Mozilla/4.0[678] no-gzip
         BrowserMatch bMSIE !no-gzip !gzip-only-text/html
     </IfModule>
       </IfModule>

       ErrorLog /var/log/httpd/blazorapp-error.log
       CustomLog /var/log/httpd/blazorapp-access.log common
   </VirtualHost>
   ```

:::moniker-end

1. Place the Apache configuration file into the `/etc/httpd/conf.d/` directory, which is the default Apache configuration directory in CentOS 7.

1. Place the app's files into the `/var/www/blazorapp` directory (the location specified to `DocumentRoot` in the configuration file).

1. Restart the Apache service.

For more information, see [`mod_mime`](https://httpd.apache.org/docs/2.4/mod/mod_mime.html) and [`mod_deflate`](https://httpd.apache.org/docs/current/mod/mod_deflate.html).

### GitHub Pages

The default GitHub Action, which deploys pages, skips deployment of folders starting with underscore, for example, the `_framework` folder. To deploy folders starting with underscore, add an empty `.nojekyll` file to the Git branch.

Git treats JavaScript (JS) files, such as `blazor.webassembly.js`, as text and converts line endings from CRLF (carriage return-line feed) to LF (line feed) in the deployment pipeline. These changes to JS files produce different file hashes than Blazor sends to the client in the `blazor.boot.json` file. The mismatches result in integrity check failures on the client. One approach to solving this problem is to add a `.gitattributes` file with `*.js binary` line before adding the app's assets to the Git branch. The `*.js binary` line configures Git to treat JS files as binary files, which avoids processing the files in the deployment pipeline. The file hashes of the unprocessed files match the entries in the `blazor.boot.json` file, and client-side integrity checks pass. For more information, see the [Resolve integrity check failures](#resolve-integrity-check-failures) section.

To handle URL rewrites, add a `wwwroot/404.html` file with a script that handles redirecting the request to the `index.html` page. For an example, see the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages):

* [`wwwroot/404.html`](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/wwwroot/404.html)
* [Live site](https://stevesandersonms.github.io/BlazorOnGitHubPages/)

When using a project site instead of an organization site, update the `<base>` tag in `wwwroot/index.html`. Set the `href` attribute value to the GitHub repository name with a trailing slash (for example, `/my-repository/`). In the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages), the base `href` is updated at publish by the [`.github/workflows/main.yml` configuration file](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/.github/workflows/main.yml).

> [!NOTE]
> The [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages) isn't owned, maintained, or supported by the .NET Foundation or Microsoft.

### Standalone with Docker

A standalone Blazor WebAssembly app is published as a set of static files for hosting by a static file server.

To host the app in Docker:

* Choose a Docker container with web server support, such as Ngnix or Apache.
* Copy the `publish` folder assets to a location folder defined in the web server for serving static files.
* Apply additional configuration as needed to serve the Blazor WebAssembly app.

For configuration guidance, see the following resources:

* [Nginx](#nginx) section or [Apache](#apache) section of this article
* [Docker Documentation](https://docs.docker.com/)

## Host configuration values

[Blazor WebAssembly apps](xref:blazor/hosting-models#blazor-webassembly) can accept the following host configuration values as command-line arguments at runtime in the development environment.

### Content root

The `--contentroot` argument sets the absolute path to the directory that contains the app's content files ([content root](xref:fundamentals/index#content-root)). In the following examples, `/content-root-path` is the app's content root path.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet run --contentroot=/content-root-path
  ```

* Add an entry to the app's `launchSettings.json` file in the **IIS Express** profile. This setting is used when the app is run with the Visual Studio Debugger and from a command prompt with `dotnet run`.

  ```json
  "commandLineArgs": "--contentroot=/content-root-path"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the `launchSettings.json` file.

  ```console
  --contentroot=/content-root-path
  ```

### Path base

The `--pathbase` argument sets the app base path for an app run locally with a non-root relative URL path (the `<base>` tag `href` is set to a path other than `/` for staging and production). In the following examples, `/relative-URL-path` is the app's path base. For more information, see [App base path](xref:blazor/host-and-deploy/index#app-base-path).

> [!IMPORTANT]
> Unlike the path provided to `href` of the `<base>` tag, don't include a trailing slash (`/`) when passing the `--pathbase` argument value. If the app base path is provided in the `<base>` tag as `<base href="/CoolApp/">` (includes a trailing slash), pass the command-line argument value as `--pathbase=/CoolApp` (no trailing slash).

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet run --pathbase=/relative-URL-path
  ```

* Add an entry to the app's `launchSettings.json` file in the **IIS Express** profile. This setting is used when running the app with the Visual Studio Debugger and from a command prompt with `dotnet run`.

  ```json
  "commandLineArgs": "--pathbase=/relative-URL-path"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the `launchSettings.json` file.

  ```console
  --pathbase=/relative-URL-path
  ```

### URLs

The `--urls` argument sets the IP addresses or host addresses with ports and protocols to listen on for requests.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet run --urls=http://127.0.0.1:0
  ```

* Add an entry to the app's `launchSettings.json` file in the **IIS Express** profile. This setting is used when running the app with the Visual Studio Debugger and from a command prompt with `dotnet run`.

  ```json
  "commandLineArgs": "--urls=http://127.0.0.1:0"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the `launchSettings.json` file.

  ```console
  --urls=http://127.0.0.1:0
  ```

:::moniker range="< aspnetcore-8.0"

## Hosted deployment on Linux (Nginx)

Configure the app with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers by following the guidance in <xref:host-and-deploy/proxy-load-balancer>.

For more information on setting the app's base path, including sub-app path configuration, see <xref:blazor/host-and-deploy/index#app-base-path>.

Follow the guidance for an [ASP.NET Core SignalR app](xref:signalr/scale#linux-with-nginx) with the following changes:

* Remove the configuration for proxy buffering (`proxy_buffering off;`) because the setting only applies to [Server-Sent Events (SSE)](https://developer.mozilla.org/docs/Web/API/Server-sent_events), which aren't relevant to Blazor app client-server interactions.
* Change the `location` path from `/hubroute` (`location /hubroute { ... }`) to the sub-app path `/{PATH}` (`location /{PATH} { ... }`), where the `{PATH}` placeholder is the sub-app path.

  The following example configures the server for an app that responds to requests at the root path `/`:

  ```
  http {
      server {
          ...
          location / {
              ...
          }
      }
  }
  ```

  The following example configures the sub-app path of `/blazor`:

  ```
  http {
      server {
          ...
          location /blazor {
              ...
          }
      }
  }
  ```

For more information and configuration guidance, consult the following resources:

* <xref:host-and-deploy/linux-nginx>
* Nginx documentation:
  * [NGINX as a WebSocket Proxy](https://www.nginx.com/blog/websocket-nginx/)
  * [WebSocket proxying](http://nginx.org/docs/http/websocket.html)
* Developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

<!-- HOLD FOR FUTURE WORK

## Hosted deployment on Linux (Apache)

Configure the app with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers by following the guidance in <xref:host-and-deploy/proxy-load-balancer>.

For more information on setting the app's base path, including sub-app path configuration, see <xref:blazor/host-and-deploy/index#app-base-path>.

The following example hosts the app at a root URL (no sub-app path):

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass         / http://localhost:5000/
    ProxyPassReverse  / http://localhost:5000/
    ProxyPassMatch    ^/_blazor/(.*) http://localhost:5000/_blazor/$1
    ProxyPass         /_blazor ws://localhost:5000/_blazor
    ServerName        www.example.com
    ServerAlias       *.example.com
    ErrorLog          ${APACHE_LOG_DIR}helloapp-error.log
    CustomLog         ${APACHE_LOG_DIR}helloapp-access.log common
</VirtualHost>
```

To configure the server to host the app at a sub-app path, the `{PATH}` placeholder in the following entires is the sub-app path:

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass         / http://localhost:5000/{PATH}
    ProxyPassReverse  / http://localhost:5000/{PATH}
    ProxyPassMatch    ^/_blazor/(.*) http://localhost:5000/{PATH}/_blazor/$1
    ProxyPass         /_blazor ws://localhost:5000/{PATH}/_blazor
    ServerName        www.example.com
    ServerAlias       *.example.com
    ErrorLog          ${APACHE_LOG_DIR}helloapp-error.log
    CustomLog         ${APACHE_LOG_DIR}helloapp-access.log common
</VirtualHost>
```

For an app that responds to requests at `/blazor`:

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass         / http://localhost:5000/blazor
    ProxyPassReverse  / http://localhost:5000/blazor
    ProxyPassMatch    ^/_blazor/(.*) http://localhost:5000/blazor/_blazor/$1
    ProxyPass         /_blazor ws://localhost:5000/blazor/_blazor
    ServerName        www.example.com
    ServerAlias       *.example.com
    ErrorLog          ${APACHE_LOG_DIR}helloapp-error.log
    CustomLog         ${APACHE_LOG_DIR}helloapp-access.log common
</VirtualHost>
```

For more information and configuration guidance, consult the following resources:

* <xref:host-and-deploy/linux-apache>
* [Apache documentation](https://httpd.apache.org/docs/current/mod/mod_proxy.html)
* Developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

-->

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## Configure the Trimmer

Blazor performs Intermediate Language (IL) trimming on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-trimmer>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Configure the Linker

Blazor performs Intermediate Language (IL) linking on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-linker>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## Change the file name extension of DLL files

*This section applies to ASP.NET Core 6.x and 7.x. In ASP.NET Core 8.0 or later, .NET assemblies are deployed as WebAssembly files (`.wasm`) using the Webcil file format. In ASP.NET Core 8.0 or later, this section only applies if the Webcil file format has been disabled in the app's project file.*

If a firewall, anti-virus program, or network security appliance is blocking the transmission of the app's dynamic-link library (DLL) files (`.dll`), you can follow the guidance in this section to change the file name extensions of the app's published DLL files.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

> [!NOTE]
> Changing the file name extensions of the app's DLL files might not resolve the problem because many security systems scan the content of the app's files, not merely check file extensions.
>
> For a more robust approach in environments that block the download and execution of DLL files, use ASP.NET Core 8.0 or later, which by default packages .NET assemblies as WebAssembly files (`.wasm`) using the [Webcil](https://github.com/dotnet/runtime/blob/main/docs/design/mono/webcil.md) file format. For more information, see the *Webcil packaging format for .NET assemblies* section in an 8.0 or later version of this article.
>
> Third-party approaches exist for dealing with this problem. For more information, see the resources at [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor).

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

> [!NOTE]
> Changing the file name extensions of the app's DLL files might not resolve the problem because many security systems scan the content of the app's files, not merely check file extensions.
>
> For a more robust approach in environments that block the download and execution of DLL files, take ***either*** of the following approaches:
>
> * Use ASP.NET Core 8.0 or later, which by default packages .NET assemblies as WebAssembly files (`.wasm`) using the [Webcil](https://github.com/dotnet/runtime/blob/main/docs/design/mono/webcil.md) file format. For more information, see the *Webcil packaging format for .NET assemblies* section in an 8.0 or later version of this article.
> * In ASP.NET Core 6.0 or later, use a [custom deployment layout](xref:blazor/host-and-deploy/webassembly-deployment-layout).
>
> Third-party approaches exist for dealing with this problem. For more information, see the resources at [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor).

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

After publishing the app, use a shell script or DevOps build pipeline to rename `.dll` files to use a different file extension in the directory of the app's published output.

In the following examples:

* PowerShell (PS) is used to update the file extensions.
* `.dll` files are renamed to use the `.bin` file extension from the command line.
* Files listed in the published `blazor.boot.json` file with a `.dll` file extension are updated to the `.bin` file extension.
* If service worker assets are also in use, a PowerShell command updates the `.dll` files listed in the `service-worker-assets.js` file to the `.bin` file extension.

To use a different file extension than `.bin`, replace `.bin` in the following commands with the desired file extension.

On Windows:

```powershell
dir {PATH} | rename-item -NewName { $_.name -replace ".dll\b",".bin" }
((Get-Content {PATH}\blazor.boot.json -Raw) -replace '.dll"','.bin"') | Set-Content {PATH}\blazor.boot.json
```

In the preceding command, the `{PATH}` placeholder is the path to the published `_framework` folder (for example, `.\bin\Release\net6.0\browser-wasm\publish\wwwroot\_framework` from the project's root folder).

If service worker assets are also in use:

```powershell
((Get-Content {PATH}\service-worker-assets.js -Raw) -replace '.dll"','.bin"') | Set-Content {PATH}\service-worker-assets.js
```

In the preceding command, the `{PATH}` placeholder is the path to the published `service-worker-assets.js` file.

On Linux or macOS:

```console
for f in {PATH}/*; do mv "$f" "`echo $f | sed -e 's/\.dll/.bin/g'`"; done
sed -i 's/\.dll"/.bin"/g' {PATH}/blazor.boot.json
```

In the preceding command, the `{PATH}` placeholder is the path to the published `_framework` folder (for example, `.\bin\Release\net6.0\browser-wasm\publish\wwwroot\_framework` from the project's root folder).

If service worker assets are also in use:

```console
sed -i 's/\.dll"/.bin"/g' {PATH}/service-worker-assets.js
```

In the preceding command, the `{PATH}` placeholder is the path to the published `service-worker-assets.js` file.

To address the compressed `blazor.boot.json.gz` and `blazor.boot.json.br` files, adopt either of the following approaches:

* Remove the compressed `blazor.boot.json.gz` and `blazor.boot.json.br` files. **Compression is disabled with this approach.**
* Recompress the updated `blazor.boot.json` file.

The preceding guidance for the compressed `blazor.boot.json` file also applies when service worker assets are in use. Remove or recompress `service-worker-assets.js.br` and `service-worker-assets.js.gz`. Otherwise, file integrity checks fail in the browser.

The following Windows example for .NET 6.0 uses a PowerShell script placed at the root of the project. The following script, which disables compression, is the basis for further modification if you wish to recompress the `blazor.boot.json` file.

`ChangeDLLExtensions.ps1:`:

```powershell
param([string]$filepath,[string]$tfm)
dir $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework | rename-item -NewName { $_.name -replace ".dll\b",".bin" }
((Get-Content $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework\blazor.boot.json -Raw) -replace '.dll"','.bin"') | Set-Content $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework\blazor.boot.json
Remove-Item $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework\blazor.boot.json.gz
Remove-Item $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework\blazor.boot.json.br
```

If service worker assets are also in use, add the following commands:

```powershell
((Get-Content $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\service-worker-assets.js -Raw) -replace '.dll"','.bin"') | Set-Content $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework\wwwroot\service-worker-assets.js
Remove-Item $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework\wwwroot\service-worker-assets.js.gz
Remove-Item $filepath\bin\Release\$tfm\browser-wasm\publish\wwwroot\_framework\wwwroot\service-worker-assets.js.br
```

In the project file, the script is executed after publishing the app for the `Release` configuration:

```xml
<Target Name="ChangeDLLFileExtensions" AfterTargets="AfterPublish" Condition="'$(Configuration)'=='Release'">
  <Exec Command="powershell.exe -command &quot;&amp; { .\ChangeDLLExtensions.ps1 '$(SolutionDir)' '$(TargetFramework)'}&quot;" />
</Target>
```

> [!NOTE]
> When renaming and lazy loading the same assemblies, see the guidance in <xref:blazor/webassembly-lazy-load-assemblies#onnavigateasync-events-and-renamed-assembly-files>.

Usually, the app's server requires static asset configuration to serve the files with the updated extension. For an app hosted by IIS, add a MIME map entry (`<mimeMap>`) for the new file extension in the static content section (`<staticContent>`) in a custom `web.config` file. The following example assumes that the file extension is changed from `.dll` to `.bin`:

```xml
<staticContent>
  ...
  <mimeMap fileExtension=".bin" mimeType="application/octet-stream" />
  ...
</staticContent>
```

Include an update for compressed files if [compression](#compression) is in use:

```
<mimeMap fileExtension=".bin.br" mimeType="application/octet-stream" />
<mimeMap fileExtension=".bin.gz" mimeType="application/octet-stream" />
```

Remove the entry for the `.dll` file extension:

```diff
- <mimeMap fileExtension=".dll" mimeType="application/octet-stream" />
```

Remove entries for compressed `.dll` files if [compression](#compression) is in use:

```diff
- <mimeMap fileExtension=".dll.br" mimeType="application/octet-stream" />
- <mimeMap fileExtension=".dll.gz" mimeType="application/octet-stream" />
```

For more information on custom `web.config` files, see the [Use a custom `web.config`](#use-a-custom-webconfig) section.

:::moniker-end

## Prior deployment corruption

Typically on deployment:

* Only the files that have changed are replaced, which usually results in a faster deployment.
* Existing files that aren't part of the new deployment are left in place for use by the new deployment.

In rare cases, lingering files from a prior deployment can corrupt a new deployment. Completely deleting the existing deployment (or locally-published app prior to deployment) may resolve the issue with a corrupted deployment. Often, deleting the existing deployment ***once*** is sufficient to resolve the problem, including for a DevOps build and deploy pipeline.

If you determine that clearing a prior deployment is always required when a DevOps build and deploy pipeline is in use, you can temporarily add a step to the build pipeline to delete the prior deployment for each new deployment until you troubleshoot the exact cause of the corruption.

## Resolve integrity check failures

When Blazor WebAssembly downloads an app's startup files, it instructs the browser to perform integrity checks on the responses. Blazor sends SHA-256 hash values for DLL (`.dll`), WebAssembly (`.wasm`), and other files in the `blazor.boot.json` file, which isn't cached on clients. The file hashes of cached files are compared to the hashes in the `blazor.boot.json` file. For cached files with a matching hash, Blazor uses the cached files. Otherwise, files are requested from the server. After a file is downloaded, its hash is checked again for integrity validation. An error is generated by the browser if any downloaded file's integrity check fails.

Blazor's algorithm for managing file integrity:

* Ensures that the app doesn't risk loading an inconsistent set of files, for example if a new deployment is applied to your web server while the user is in the process of downloading the application files. Inconsistent files can result in a malfunctioning app.
* Ensures the user's browser never caches inconsistent or invalid responses, which can prevent the app from starting even if the user manually refreshes the page.
* Makes it safe to cache the responses and not check for server-side changes until the expected SHA-256 hashes themselves change, so subsequent page loads involve fewer requests and complete faster.

If the web server returns responses that don't match the expected SHA-256 hashes, an error similar to the following example appears in the browser's developer console:

> Failed to find a valid digest in the 'integrity' attribute for resource 'https://myapp.example.com/\_framework/MyBlazorApp.dll' with computed SHA-256 integrity 'IIa70iwvmEg5WiDV17OpQ5eCztNYqL186J56852RpJY='. The resource has been blocked.

In most cases, the warning doesn't indicate a problem with integrity checking. Instead, the warning usually means that some other problem exists.

For Blazor WebAssembly's boot reference source, see [the `Boot.WebAssembly.ts` file in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web.JS/src/Boot.WebAssembly.ts).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### Diagnosing integrity problems

When an app is built, the generated `blazor.boot.json` manifest describes the SHA-256 hashes of boot resources at the time that the build output is produced. The integrity check passes as long as the SHA-256 hashes in `blazor.boot.json` match the files delivered to the browser.

Common reasons why this fails include:

* The web server's response is an error (for example, a *404 - Not Found* or a *500 - Internal Server Error*) instead of the file the browser requested. This is reported by the browser as an integrity check failure and not as a response failure.
* Something has changed the contents of the files between the build and delivery of the files to the browser. This might happen:
  * If you or build tools manually modify the build output.
  * If some aspect of the deployment process modified the files. For example if you use a Git-based deployment mechanism, bear in mind that Git transparently converts Windows-style line endings to Unix-style line endings if you commit files on Windows and check them out on Linux. Changing file line endings change the SHA-256 hashes. To avoid this problem, consider [using `.gitattributes` to treat build artifacts as `binary` files](https://git-scm.com/book/en/v2/Customizing-Git-Git-Attributes).
  * The web server modifies the file contents as part of serving them. For example, some content distribution networks (CDNs) automatically attempt to [minify](xref:client-side/bundling-and-minification#minification) HTML, thereby modifying it. You may need to disable such features.
* The `blazor.boot.json` file fails to load properly or is improperly cached on the client. Common causes include either of the following: 
  * Misconfigured or malfunctioning custom developer code.
  * One or more misconfigured intermediate caching layers.

To diagnose which of these applies in your case:

 1. Note which file is triggering the error by reading the error message.
 1. Open your browser's developer tools and look in the *Network* tab. If necessary, reload the page to see the list of requests and responses. Find the file that is triggering the error in that list.
 1. Check the HTTP status code in the response. If the server returns anything other than *200 - OK* (or another 2xx status code), then you have a server-side problem to diagnose. For example, status code 403 means there's an authorization problem, whereas status code 500 means the server is failing in an unspecified manner. Consult server-side logs to diagnose and fix the app.
 1. If the status code is *200 - OK* for the resource, look at the response content in browser's developer tools and check that the content matches up with the data expected. For example, a common problem is to misconfigure routing so that requests return your `index.html` data even for other files. Make sure that responses to `.wasm` requests are WebAssembly binaries and that responses to `.dll` requests are .NET assembly binaries. If not, you have a server-side routing problem to diagnose.
 1. Seek to validate the app's published and deployed output with the [Troubleshoot integrity PowerShell script](#troubleshoot-integrity-powershell-script).

If you confirm that the server is returning plausibly correct data, there must be something else modifying the contents in between build and delivery of the file. To investigate this:

* Examine the build toolchain and deployment mechanism in case they're modifying files after the files are built. An example of this is when Git transforms file line endings, as described earlier.
* Examine the web server or CDN configuration in case they're set up to modify responses dynamically (for example, trying to minify HTML). It's fine for the web server to implement HTTP compression (for example, returning `content-encoding: br` or `content-encoding: gzip`), since this doesn't affect the result after decompression. However, it's *not* fine for the web server to modify the uncompressed data.

### Troubleshoot integrity PowerShell script

Use the [`integrity.ps1`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/host-and-deploy/webassembly/_samples/integrity.ps1?raw=true) PowerShell script to validate a published and deployed Blazor app. The script is provided for PowerShell Core 7 or later as a starting point when the app has integrity issues that the Blazor framework can't identify. Customization of the script might be required for your apps, including if running on version of PowerShell later than version 7.2.0.

The script checks the files in the `publish` folder and downloaded from the deployed app to detect issues in the different manifests that contain integrity hashes. These checks should detect the most common problems:

* You modified a file in the published output without realizing it.
* The app wasn't correctly deployed to the deployment target, or something changed within the deployment target's environment.
* There are differences between the deployed app and the output from publishing the app.

Invoke the script with the following command in a PowerShell command shell:

```powershell
.\integrity.ps1 {BASE URL} {PUBLISH OUTPUT FOLDER}
```

In the following example, the script is executed on a locally-running app at `https://localhost:5001/`:

```powershell
.\integrity.ps1 https://localhost:5001/ C:\TestApps\BlazorSample\bin\Release\net6.0\publish\
```

Placeholders:

* `{BASE URL}`: The URL of the deployed app. A trailing slash (`/`) is required.
* `{PUBLISH OUTPUT FOLDER}`: The path to the app's `publish` folder or location where the app is published for deployment.

> [!NOTE]
> When cloning the `dotnet/AspNetCore.Docs` GitHub repository, the `integrity.ps1` script might be quarantined by [Bitdefender](https://www.bitdefender.com) or another virus scanner present on the system. Usually, the file is trapped by a virus scanner's *heuristic scanning* technology, which merely looks for patterns in files that might indicate the presence of malware. To prevent the virus scanner from quarantining the file, add an exception to the virus scanner prior to cloning the repo. The following example is a typical path to the script on a Windows system. Adjust the path as needed for other systems. The placeholder `{USER}` is the user's path segment.
>
> ```
> C:\Users\{USER}\Documents\GitHub\AspNetCore.Docs\aspnetcore\blazor\host-and-deploy\webassembly\_samples\integrity.ps1
> ```
>
> **Warning**: *Creating virus scanner exceptions is dangerous and should only be performed when you're certain that the file is safe.*
>
> Comparing the checksum of a file to a valid checksum value doesn't guarantee file safety, but modifying a file in a way that maintains a checksum value isn't trivial for malicious users. Therefore, checksums are useful as a general security approach. Compare the checksum of the local `integrity.ps1` file to one of the following values:
>
> * SHA256: `32c24cb667d79a701135cb72f6bae490d81703323f61b8af2c7e5e5dc0f0c2bb`
> * MD5: `9cee7d7ec86ee809a329b5406fbf21a8`
>
> Obtain the file's checksum on Windows OS with the following command. Provide the path and file name for the `{PATH AND FILE NAME}` placeholder and indicate the type of checksum to produce for the `{SHA512|MD5}` placeholder, either `SHA256` or `MD5`:
>
> ```console
> CertUtil -hashfile {PATH AND FILE NAME} {SHA256|MD5}
> ```
> 
> If you have any cause for concern that checksum validation isn't secure enough in your environment, consult your organization's security leadership for guidance.
>
> For more information, see [Understanding malware & other threats](/windows/security/threat-protection/intelligence/understanding-malware).

### Disable integrity checking for non-PWA apps

In most cases, don't disable integrity checking. Disabling integrity checking doesn't solve the underlying problem that has caused the unexpected responses and results in losing the benefits listed earlier.

There may be cases where the web server can't be relied upon to return consistent responses, and you have no choice but to temporarily disable integrity checks until the underlying problem is resolved.

To disable integrity checks, add the following to a property group in the Blazor WebAssembly app's project file (`.csproj`):

```xml
<BlazorCacheBootResources>false</BlazorCacheBootResources>
```

`BlazorCacheBootResources` also disables Blazor's default behavior of caching the `.dll`, `.wasm`, and other files based on their SHA-256 hashes because the property indicates that the SHA-256 hashes can't be relied upon for correctness. Even with this setting, the browser's normal HTTP cache may still cache those files, but whether or not this happens depends on your web server configuration and the `cache-control` headers that it serves.

> [!NOTE]
> The `BlazorCacheBootResources` property doesn't disable integrity checks for [Progressive Web Applications (PWAs)](xref:blazor/progressive-web-app). For guidance pertaining to PWAs, see the [Disable integrity checking for PWAs](#disable-integrity-checking-for-pwas) section.

We can't provide an exhaustive list of scenarios where disabling integrity checking is required. Servers can answer a request in arbitrary ways outside of the scope of the Blazor framework. The framework provides the `BlazorCacheBootResources` setting to make the app runnable at the cost of *losing a guarantee of integrity that the app can provide*. Again, we don't recommend disabling integrity checking, especially for production deployments. Developers should seek to solve the underlying integrity problem that's causing integrity checking to fail.

A few general cases that can cause integrity issues are:

* Running on HTTP where integrity can't be checked.
* If your deployment process modifies the files after publish in any way.
* If your host modifies the files in any way.

### Disable integrity checking for PWAs

Blazor's Progressive Web Application (PWA) template contains a suggested `service-worker.published.js` file that's responsible for fetching and storing application files for offline use. This is a separate process from the normal app startup mechanism and has its own separate integrity checking logic.

Inside the `service-worker.published.js` file, following line is present:

```javascript
.map(asset => new Request(asset.url, { integrity: asset.hash }));
```

To disable integrity checking, remove the `integrity` parameter by changing the line to the following:

```javascript
.map(asset => new Request(asset.url));
```

Again, disabling integrity checking means that you lose the safety guarantees offered by integrity checking. For example, there is a risk that if the user's browser is caching the app at the exact moment that you deploy a new version, it could cache some files from the old deployment and some from the new deployment. If that happens, the app becomes stuck in a broken state until you deploy a further update.

:::moniker range=">= aspnetcore-6.0"

## SignalR configuration

[SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor apps that use SignalR.

### Transports

Blazor works best when using [WebSockets](xref:fundamentals/websockets) as the SignalR transport due to lower latency, better reliability, and improved [security](xref:signalr/security). [Long Polling](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md#long-polling-server-to-client-only) is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

A console warning appears if Long Polling is utilized:

> :::no-loc text="Failed to connect via WebSockets, using the Long Polling fallback transport. This may be due to a VPN or proxy blocking the connection.":::

### Global deployment and connection failures

Recommendations for global deployments to geographical data centers:

* Deploy the app to the regions where most of the users reside.
* Take into consideration the increased latency for traffic across continents.
* For Azure hosting, use the [Azure SignalR Service](/azure/azure-signalr/signalr-overview).

If a deployed app frequently displays the reconnection UI due to ping timeouts caused by Internet latency, lengthen the server and client timeouts:

* **Server**

  At least double the maximum roundtrip time expected between the client and the server. Test, monitor, and revise the timeouts as needed. For the SignalR hub, set the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> (default: 15 seconds). The following example assumes that <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> uses the default value of 15 seconds.

  > [!IMPORTANT]
  > The <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> isn't directly related to the reconnection UI appearing. The Keep-Alive interval doesn't necessarily need to be changed. If the reconnection UI appearance issue is due to timeouts, the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> and <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> can be increased and the Keep-Alive interval can remain the same. The important consideration is that if you change the Keep-Alive interval, make sure that the client timeout value is at least double the value of the Keep-Alive interval and that the Keep-Alive interval on the client matches the server setting.
  >
  > In the following example, the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> is increased to 60 seconds, and the <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> is increased to 30 seconds.

  In the `Program` file of the server app:

   ```csharp
   builder.Services.AddSignalR(options =>
   {
       options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
       options.HandshakeTimeout = TimeSpan.FromSeconds(30);
   });
   ```

  For more information, see <xref:blazor/fundamentals/signalr#server-side-circuit-handler-options>.

* **Client**

  Typically, double the value used for the server's <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> to set the timeout for the client's server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>, default: 30 seconds).

  > [!IMPORTANT]
  > The Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>) isn't directly related to the reconnection UI appearing. The Keep-Alive interval doesn't necessarily need to be changed. If the reconnection UI appearance issue is due to timeouts, the server timeout can be increased and the Keep-Alive interval can remain the same. The important consideration is that if you change the Keep-Alive interval, make sure that the timeout value is at least double the value of the Keep-Alive interval and that the Keep-Alive interval on the server matches the client setting.
  >
  > In the following example, a custom value of 60 seconds is used for the server timeout.

  When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds).
  
  <!-- UPDATE 8.0 This needs to be cross-checked against the latest
       tutorial guidance after the tutorial receives its final
       round of updates. -->

  The following example is based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor). The server timeout is increased to 60 seconds, and the handshake timeout is increased to 30 seconds:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

  ```csharp
  protected override async Task OnInitializedAsync()
  {
      hubConnection = new HubConnectionBuilder()
          .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
          .WithServerTimeout(TimeSpan.FromSeconds(60))
          .Build();

      hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(30);

      hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

      await hubConnection.StartAsync();
  }
  ```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

  ```csharp
  protected override async Task OnInitializedAsync()
  {
      hubConnection = new HubConnectionBuilder()
          .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
          .Build();

      hubConnection.ServerTimeout = TimeSpan.FromSeconds(60);
      hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(30);

      hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

      await hubConnection.StartAsync();
  }
  ```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

  When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>:

  * The server timeout should be at least double the value assigned to the Keep-Alive interval.
  * The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout.

For more information, see <xref:blazor/fundamentals/signalr#configure-signalr-timeouts-and-keep-alive-on-the-client>.

:::moniker-end
