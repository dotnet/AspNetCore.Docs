---
title: Host and deploy ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to host and deploy Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc, linux-related-content
ms.date: 11/12/2024
uid: blazor/host-and-deploy/webassembly/index
---
# Host and deploy ASP.NET Core Blazor WebAssembly

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy Blazor WebAssembly apps.

With the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser in parallel.
* The app is executed directly on the browser UI thread.

:::moniker range=">= aspnetcore-8.0"

This article pertains to the deployment scenario where the Blazor app is placed on a static hosting web server or service, .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section and other articles in this node for IIS, Azure services, Apache, Nginx, and GitHub Pages.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The following deployment strategies are supported:

* The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
* The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.
* An ASP.NET Core app hosts multiple Blazor WebAssembly apps. For more information, see <xref:blazor/host-and-deploy/webassembly/multiple-hosted-webassembly>.

:::moniker-end

## Subdomain and IIS sub-application hosting

Subdomain hosting doesn't require special configuration of the app. You ***don't*** need to configure the app base path (the `<base>` tag in `wwwroot/index.html`) to host the app at a subdomain.

IIS sub-application hosting ***does*** require you to set the app base path. For more information and cross-links to further guidance on IIS sub-application hosting, see <xref:blazor/host-and-deploy/index#iis>.

## Decrease maximum heap size for some mobile device browsers

:::moniker range=">= aspnetcore-8.0"

When building a Blazor app that runs on the client (`.Client` project of a Blazor Web App or standalone Blazor WebAssembly app) and targets mobile device browsers, especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required. The default value is 2,147,483,648 bytes, which may be too large and result in the app crashing if the app attempts to allocate more memory with the browser failing to grant it. The following example sets the value to 268,435,456 bytes in the `Program` file:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

When building a Blazor WebAssembly app that targets mobile device browsers, especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required. The default value is 2,147,483,648 bytes, which may be too large and result in the app crashing if the app attempts to allocate more memory with the browser failing to grant it. The following example sets the value to 268,435,456 bytes in the `Program` file:

:::moniker-end

```xml
<EmccMaximumHeapSize>268435456</EmccMaximumHeapSize>
```

For more information on [Mono](https://github.com/mono/mono)/WebAssembly MSBuild properties and targets, see [`WasmApp.Common.targets` (`dotnet/runtime` GitHub repository)](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/build/WasmApp.Common.targets).

:::moniker range=">= aspnetcore-8.0"

## Webcil packaging format for .NET assemblies

[Webcil](https://github.com/dotnet/runtime/blob/main/docs/design/mono/webcil.md) is a web-friendly packaging format for .NET assemblies designed to enable using Blazor WebAssembly in restrictive network environments. Webcil files use a standard WebAssembly wrapper, where the assemblies are deployed as WebAssembly files that use the standard `.wasm` file extension.

Webcil is the default packaging format when you publish a Blazor WebAssembly app. To disable the use of Webcil, set the following MSBuild property in the app's project file:

```xml
<PropertyGroup>
  <WasmEnableWebcil>false</WasmEnableWebcil>
</PropertyGroup>
```

:::moniker-end

## Customize how boot resources are loaded

Customize how boot resources are loaded using the `loadBootResource` API. For more information, see <xref:blazor/fundamentals/startup#load-client-side-boot-resources>.

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

* For IIS `web.config` compression configuration, see the [IIS: Brotli and Gzip compression](xref:blazor/host-and-deploy/webassembly/iis#brotli-and-gzip-compression) section. 
* When hosting on static hosting solutions that don't support statically-compressed file content negotiation, consider configuring the app to fetch and decode Brotli compressed files:

Obtain the JavaScript Brotli decoder from the [`google/brotli` GitHub repository](https://github.com/google/brotli). The minified decoder file is named `decode.min.js` and found in the repository's [`js` folder](https://github.com/google/brotli/tree/master/js).
  
> [!NOTE]
> If the minified version of the `decode.js` script (`decode.min.js`) fails, try using the unminified version (`decode.js`) instead.

Update the app to use the decoder.
    
In the `wwwroot/index.html` file, set `autostart` to `false` on Blazor's `<script>` tag:
    
```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
```
    
After Blazor's `<script>` tag and before the closing `</body>` tag, add the following JavaScript code `<script>` block. The following function calls `fetch` with [`cache: 'no-cache'`](https://developer.mozilla.org/docs/Web/API/Request/cache#value) to keep the browser's cache updated.

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
1. <xref:Microsoft.AspNetCore.Components.Routing.Router> component loads, and the Razor `Main` component is rendered.

In the Main page, selecting the link to the `About` component works on the client because the Blazor router stops the browser from making a request on the Internet to `www.contoso.com` for `About` and serves the rendered `About` component itself. All of the requests for internal endpoints *within the Blazor WebAssembly app* work the same way: Requests don't trigger browser-based requests to server-hosted resources on the Internet. The router handles the requests internally.

If a request is made using the browser's address bar for `www.contoso.com/About`, the request fails. No such resource exists on the app's Internet host, so a *404 - Not Found* response is returned.

Because browsers make requests to Internet-based hosts for client-side pages, web servers and hosting services must rewrite all requests for resources not physically on the server to the `index.html` page. When `index.html` is returned, the app's Blazor router takes over and responds with the correct resource.

When deploying to an IIS server, you can use the URL Rewrite Module with the app's published `web.config` file. For more information, see <xref:blazor/host-and-deploy/webassembly/iis>.

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

A [self-contained](/dotnet/core/deploying/#publish-self-contained) deployment is configured for a generated publish profile (`.pubxml`). Confirm that the **:::no-loc text="Server":::** project's publish profile contains the `<SelfContained>` MSBuild property set to `false`.

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
> It's possible to publish an app with publish profile settings using the .NET CLI by passing `/p:PublishProfile={PROFILE}` to the [`dotnet publish` command](/dotnet/core/tools/dotnet-publish), where the `{PROFILE}` placeholder is the profile. For more information, see the *Publish profiles* and *Folder publish example* sections in the <xref:host-and-deploy/visual-studio-publish-profiles#publish-profiles> article. If you pass the RID in the [`dotnet publish` command](/dotnet/core/tools/dotnet-publish) and not in the publish profile, use the MSBuild property (`/p:RuntimeIdentifier`) with the command, not with the `-r|--runtime` option.

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

* Option 2: Pass the RID in the [`dotnet publish` command](/dotnet/core/tools/dotnet-publish) as the MSBuild property (`/p:RuntimeIdentifier`), not with the `-r|--runtime` option:
  
  ```dotnetcli
  dotnet publish -c Release /p:RuntimeIdentifier={RID}
  ```
    
  In the preceding command, the `{RID}` placeholder is the [Runtime Identifier (RID)](/dotnet/core/rid-catalog).

For more information, see the following articles:

* [.NET application publishing overview](/dotnet/core/deploying/)
* <xref:host-and-deploy/index>

:::moniker-end

## Standalone deployment

A *standalone deployment* serves the Blazor WebAssembly app as a set of static files that are requested directly by clients. Any static file server is able to serve the Blazor app.

Standalone deployment assets are published into either the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` or `bin/Release/{TARGET FRAMEWORK}/browser-wasm/publish` folder, where the `{TARGET FRAMEWORK}` placeholder is the target framework.

## Azure App Service

Blazor WebAssembly apps can be deployed to Azure App Services on Windows, which hosts the app on IIS.

Deploying a standalone Blazor WebAssembly app to Azure App Service for Linux isn't currently supported. We recommend hosting a standalone Blazor WebAssembly app using [Azure Static Web Apps](xref:blazor/host-and-deploy/webassembly/azure-static-web-apps), which supports this scenario.

## Standalone with Docker

A standalone Blazor WebAssembly app is published as a set of static files for hosting by a static file server.

To host the app in Docker:

* Choose a Docker container with web server support, such as Nginx or Apache.
* Copy the `publish` folder assets to a location folder defined in the web server for serving static files.
* Apply additional configuration as needed to serve the Blazor WebAssembly app.

For configuration guidance, see the following resources:

* [Nginx](xref:blazor/host-and-deploy/webassembly/nginx) or [Apache](xref:blazor/host-and-deploy/webassembly/apache) articles
* [Docker Documentation](https://docs.docker.com/)

## Host configuration values

[Blazor WebAssembly apps](xref:blazor/hosting-models#blazor-webassembly) can accept the following host configuration values as command-line arguments at runtime in the development environment.

### Content root

The `--contentroot` argument sets the absolute path to the directory that contains the app's content files ([content root](xref:fundamentals/index#content-root)). In the following examples, `/content-root-path` is the app's content root path.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet watch --contentroot=/content-root-path
  ```

* Add an entry to the app's `launchSettings.json` file in the **IIS Express** profile. This setting is used when the app is run with the Visual Studio Debugger and from a command prompt with `dotnet watch` (or `dotnet run`).

  ```json
  "commandLineArgs": "--contentroot=/content-root-path"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the `launchSettings.json` file.

  ```console
  --contentroot=/content-root-path
  ```

### Path base

The `--pathbase` argument sets the app base path for an app run locally with a non-root relative URL path (the `<base>` tag `href` is set to a path other than `/` for staging and production). In the following examples, `/relative-URL-path` is the app's path base. For more information, see <xref:blazor/host-and-deploy/app-base-path>.

> [!IMPORTANT]
> Unlike the path provided to `href` of the `<base>` tag, don't include a trailing slash (`/`) when passing the `--pathbase` argument value. If the app base path is provided in the `<base>` tag as `<base href="/CoolApp/">` (includes a trailing slash), pass the command-line argument value as `--pathbase=/CoolApp` (no trailing slash).

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet watch --pathbase=/relative-URL-path
  ```

* Add an entry to the app's `launchSettings.json` file in the **IIS Express** profile. This setting is used when running the app with the Visual Studio Debugger and from a command prompt with `dotnet watch` (or `dotnet run`).

  ```json
  "commandLineArgs": "--pathbase=/relative-URL-path"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the `launchSettings.json` file.

  ```console
  --pathbase=/relative-URL-path
  ```

For more information, see <xref:blazor/host-and-deploy/app-base-path>.

### URLs

The `--urls` argument sets the IP addresses or host addresses with ports and protocols to listen on for requests.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet watch --urls=http://127.0.0.1:0
  ```

* Add an entry to the app's `launchSettings.json` file in the **IIS Express** profile. This setting is used when running the app with the Visual Studio Debugger and from a command prompt with `dotnet watch` (or `dotnet run`).

  ```json
  "commandLineArgs": "--urls=http://127.0.0.1:0"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the `launchSettings.json` file.

  ```console
  --urls=http://127.0.0.1:0
  ```

:::moniker range=">= aspnetcore-5.0"

## Configure the Trimmer

Blazor performs Intermediate Language (IL) trimming on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-trimmer>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Configure the Linker

Blazor performs Intermediate Language (IL) linking on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-linker>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

## Change the file name extension of DLL files

*This section applies to .NET 5 through .NET 7. In .NET 8 or later, .NET assemblies are deployed as WebAssembly files (`.wasm`) using the Webcil file format.*

If a firewall, anti-virus program, or network security appliance is blocking the transmission of the app's dynamic-link library (DLL) files (`.dll`), you can follow the guidance in this section to change the file name extensions of the app's published DLL files.

Changing the file name extensions of the app's DLL files might not resolve the problem because many security systems scan the content of the app's files, not merely check file extensions.

For a more robust approach in environments that block the download and execution of DLL files, take ***either*** of the following approaches:

* Use .NET 8 or later, which packages .NET assemblies as WebAssembly files (`.wasm`) using the [Webcil](https://github.com/dotnet/runtime/blob/main/docs/design/mono/webcil.md) file format. For more information, see the *Webcil packaging format for .NET assemblies* section in an 8.0 or later version of this article.
* In .NET 6 or later, use a [custom deployment layout](xref:blazor/host-and-deploy/webassembly/deployment-layout).

Third-party approaches exist for dealing with this problem. For more information, see the resources at [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor).

After publishing the app, use a shell script or DevOps build pipeline to rename `.dll` files to use a different file extension in the directory of the app's published output.

In the following examples:

* PowerShell (PS) is used to update the file extensions.
* `.dll` files are renamed to use the `.bin` file extension from the command line.
* Files listed in the published Blazor boot manifest with a `.dll` file extension are updated to the `.bin` file extension.
* If service worker assets are also in use, a PowerShell command updates the `.dll` files listed in the `service-worker-assets.js` file to the `.bin` file extension.

To use a different file extension than `.bin`, replace `.bin` in the following commands with the desired file extension.

# [Windows](#tab/windows)

In the following commands, the `{PATH}` placeholder is the path to the published `_framework` folder in the [`publish` folder](xref:blazor/host-and-deploy/index#default-publish-locations).

Rename file extensions in the folder:

```powershell
dir {PATH} | rename-item -NewName { $_.name -replace ".dll\b",".bin" }
```

Rename file extensions in the `blazor.boot.json` file:

```powershell
((Get-Content {PATH}\blazor.boot.json -Raw) -replace '.dll"','.bin"') | Set-Content {PATH}\blazor.boot.json
```

If service worker assets are also in use because the app is a [Progressive Web App (PWA)](xref:blazor/progressive-web-app):

```powershell
((Get-Content {PATH}\service-worker-assets.js -Raw) -replace '.dll"','.bin"') | Set-Content {PATH}\service-worker-assets.js
```

In the preceding command, the `{PATH}` placeholder is the path to the published `service-worker-assets.js` file.

# [Linux / macOS](#tab/linux-macos)

In the following commands, the `{PATH}` placeholder is the path to the published `_framework` folder in the [`publish` folder](xref:blazor/host-and-deploy/index#default-publish-locations).

Rename file extensions in the folder:

```console
for f in {PATH}/*; do mv "$f" "`echo $f | sed -e 's/\.dll/.bin/g'`"; done
```

Rename file extensions in the `blazor.boot.json` file:

```console
sed -i 's/\.dll"/.bin"/g' {PATH}/blazor.boot.json
```

If service worker assets are also in use because the app is a [Progressive Web App (PWA)](xref:blazor/progressive-web-app):

```console
sed -i 's/\.dll"/.bin"/g' {PATH}/service-worker-assets.js
```

In the preceding command, the `{PATH}` placeholder is the path to the published `service-worker-assets.js` file.

---

To address the compressed `blazor.boot.json` file, adopt either of the following approaches:

* Recompress the updated `blazor.boot.json` file, producing new `blazor.boot.json.gz` and `blazor.boot.json.br` files. (*Recommended*)
* Remove the compressed `blazor.boot.json.gz` and `blazor.boot.json.br` files. (*Compression is disabled with this approach.*)

For a [Progressive Web App (PWA)](xref:blazor/progressive-web-app)'s compressed `service-worker-assets.js` file, adopt either of the following approaches:

* Recompress the updated `service-worker-assets.js` file, producing new `service-worker-assets.js.br` and `service-worker-assets.js.gz` files. (*Recommended*)
* Remove the compressed `service-worker-assets.js.gz` and `service-worker-assets.js.br` files. (*Compression is disabled with this approach.*)

To automate the extension change on Windows in .NET 6/7, the following approach uses a PowerShell script placed at the root of the project. The following script, which disables compression, is the basis for further modification if you wish to recompress the `blazor.boot.json` file and `service-worker-assets.js` file if the app is a [Progressive Web App (PWA)](xref:blazor/progressive-web-app). The path to the [`publish` folder](xref:blazor/host-and-deploy/index#default-publish-locations) is passed to the script when it's executed.

`ChangeDLLExtensions.ps1:`:

```powershell
param([string]$filepath)
dir $filepath\wwwroot\_framework | rename-item -NewName { $_.name -replace ".dll\b",".bin" }
((Get-Content $filepath\wwwroot\_framework\blazor.boot.json -Raw) -replace '.dll"','.bin"') | Set-Content $filepath\wwwroot\_framework\blazor.boot.json
Remove-Item $filepath\wwwroot\_framework\blazor.boot.json.gz
Remove-Item $filepath\wwwroot\_framework\blazor.boot.json.br
```

If service worker assets are also in use because the app is a [Progressive Web App (PWA)](xref:blazor/progressive-web-app), add the following commands:

```powershell
((Get-Content $filepath\wwwroot\service-worker-assets.js -Raw) -replace '.dll"','.bin"') | Set-Content $filepath\wwwroot\service-worker-assets.js
Remove-Item $filepath\wwwroot\service-worker-assets.js.gz
Remove-Item $filepath\wwwroot\service-worker-assets.js.br
```

In the project file, the script is executed after publishing the app for the `Release` configuration:

```xml
<Target Name="ChangeDLLFileExtensions" AfterTargets="AfterPublish" Condition="'$(Configuration)'=='Release'">
  <Exec Command="powershell.exe -command &quot;&amp; {.\ChangeDLLExtensions.ps1 '$(SolutionDir)'}&quot;" />
</Target>
```

After publishing the app, manually recompress `blazor.boot.json`, and `service-worker-assets.js` if used, to re-enable compression.

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

For more information on custom `web.config` files, see the [Use of a custom `web.config`](xref:blazor/host-and-deploy/webassembly/iis#use-of-a-custom-webconfig) section.

:::moniker-end

## Prior deployment corruption

Typically on deployment:

* Only the files that have changed are replaced, which usually results in a faster deployment.
* Existing files that aren't part of the new deployment are left in place for use by the new deployment.

In rare cases, lingering files from a prior deployment can corrupt a new deployment. Completely deleting the existing deployment (or locally-published app prior to deployment) may resolve the issue with a corrupted deployment. Often, deleting the existing deployment ***once*** is sufficient to resolve the problem, including for a DevOps build and deploy pipeline.

If you determine that clearing a prior deployment is always required when a DevOps build and deploy pipeline is in use, you can temporarily add a step to the build pipeline to delete the prior deployment for each new deployment until you troubleshoot the exact cause of the corruption.
