---
title: Host and deploy ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to host and deploy Blazor WebAssembly using ASP.NET Core, Content Delivery Networks (CDN), file servers, and GitHub Pages.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/host-and-deploy/webassembly
---
# Host and deploy ASP.NET Core Blazor WebAssembly

This article explains how to host and deploy Blazor WebAssembly using ASP.NET Core, Content Delivery Networks (CDN), file servers, and GitHub Pages.

:::moniker range=">= aspnetcore-6.0"

With the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser in parallel.
* The app is executed directly on the browser UI thread.

The following deployment strategies are supported:

* The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
* The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.

## Ahead-of-time (AOT) compilation

Blazor WebAssembly supports ahead-of-time (AOT) compilation, where you can compile your .NET code directly into WebAssembly. AOT compilation results in runtime performance improvements at the expense of a larger app size.

Without enabling AOT compilation, Blazor WebAssembly apps run on the browser using a .NET Intermediate Language (IL) interpreter implemented in WebAssembly. Because the .NET code is interpreted, apps typically run slower than they would on a server-side [.NET just-in-time (JIT) runtime](/dotnet/standard/glossary#jit). AOT compilation addresses this performance issue by compiling an app's .NET code directly into WebAssembly for native WebAssembly execution by the browser. The AOT performance improvement can yield dramatic improvements for apps that execute CPU-intensive tasks. The drawback to using AOT compilation is that AOT-compiled apps are generally larger than their IL-interpreted counterparts, so they usually take longer to download to the client when first requested.

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
  * AOT does ***not*** trim out managed DLLs when the app is published. Blazor requires the DLLs for reflection metadata and to support certain .NET runtime features. Requiring the DLLs on the client increases the download size but provides a more compatible .NET experience.

> [!NOTE]
> For [Mono](https://github.com/mono/mono)/WebAssembly MSBuild properties and targets, see [`WasmApp.targets` (dotnet/runtime GitHub repository)](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/build/WasmApp.targets). Official documentation for common MSBuild properties is planned per [Document blazor msbuild configuration options (dotnet/docs #27395)](https://github.com/dotnet/docs/issues/27395).

## Runtime relinking

One of the largest parts of a Blazor WebAssembly app is the WebAssembly-based .NET runtime (`dotnet.wasm`) that the browser must download when the app is first accessed by a user's browser. Relinking the .NET WebAssembly runtime trims unused runtime code and thus improves download speed.

Runtime relinking requires installation of the .NET WebAssembly build tools. For more information, see <xref:blazor/tooling#net-webassembly-build-tools>.

With the .NET WebAssembly build tools installed, runtime relinking is performed automatically when an app is **published** in the `Release` configuration. The size reduction is particularly dramatic when disabling globalization. For more information, see <xref:blazor/globalization-localization#invariant-globalization>.

## Customize how boot resources are loaded

Customize how boot resources are loaded using the `loadBootResource` API. For more information, see <xref:blazor/fundamentals/startup#load-boot-resources>.

## Compression

When a Blazor WebAssembly app is published, the output is statically compressed during publish to reduce the app's size and remove the overhead for runtime compression. The following compression algorithms are used:

* [Brotli](https://tools.ietf.org/html/rfc7932) (highest level)
* [Gzip](https://tools.ietf.org/html/rfc1952)

Blazor relies on the host to the serve the appropriate compressed files. When using an ASP.NET Core hosted project, the host project is capable of performing content negotiation and serving the statically-compressed files. When hosting a Blazor WebAssembly standalone app, additional work might be required to ensure that statically-compressed files are served:

* For IIS `web.config` compression configuration, see the [IIS: Brotli and Gzip compression](#brotli-and-gzip-compression) section. 
* When hosting on static hosting solutions that don't support statically-compressed file content negotiation, such as GitHub Pages, consider configuring the app to fetch and decode Brotli compressed files:

  * Obtain the JavaScript Brotli decoder from the [google/brotli GitHub repository](https://github.com/google/brotli). The minified decoder file is named `decode.min.js` and found in the repository's [`js` folder](https://github.com/google/brotli/tree/master/js).
  
    > [!NOTE]
    > If the minified version of the `decode.js` script (`decode.min.js`) fails, try using the unminified version (`decode.js`) instead.

  * Update the app to use the decoder.
    
    In the `wwwroot/index.html` file, set `autostart` to `false` on Blazor's `<script>` tag:
    
    ```html
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    ```
    
    After Blazor's `<script>` tag and before the closing `</body>` tag, add the following JavaScript code `<script>` block:
  
    ```html
    <script type="module">
      import { BrotliDecode } from './decode.min.js';
      Blazor.start({
        loadBootResource: function (type, name, defaultUri, integrity) {
          if (type !== 'dotnetjs' && location.hostname !== 'localhost') {
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

## Rewrite URLs for correct routing

Routing requests for page components in a Blazor WebAssembly app isn't as straightforward as routing requests in a Blazor Server, hosted app. Consider a Blazor WebAssembly app with two components:

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

## Hosted deployment with ASP.NET Core

A *hosted deployment* serves the Blazor WebAssembly app to browsers from an [ASP.NET Core app](xref:index) that runs on a web server.

The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the server app. The two apps are deployed together. A web server that is capable of hosting an ASP.NET Core app is required. For a hosted deployment, Visual Studio includes the **Blazor WebAssembly App** project template (`blazorwasm` template when using the [`dotnet new`](/dotnet/core/tools/dotnet-new) command) with the **`Hosted`** option selected (`-ho|--hosted` when using the `dotnet new` command).

For more information, see the following articles:

* ASP.NET Core app hosting and deployment: <xref:host-and-deploy/index>
* Deployment to Azure App Service: <xref:tutorials/publish-to-azure-webapp-using-vs>
* Blazor project templates: <xref:blazor/project-structure>

## Hosted deployment with multiple Blazor WebAssembly apps

### App configuration

Hosted Blazor solutions can serve multiple Blazor WebAssembly apps.

> [!NOTE]
> The example in this section references the use of a Visual Studio *solution*, but the use of Visual Studio and a Visual Studio solution isn't required for multiple client apps to work in a hosted Blazor WebAssembly apps scenario. If you aren't using Visual Studio, ignore the `{SOLUTION NAME}.sln` file and any other files created for Visual Studio.

In the following example:

* The initial (first) client app is the default client project of a solution created from the Blazor WebAssembly project template. The first client app is accessible in a browser from the URL `/FirstApp` on either port 5001 or with a host of `firstapp.com`.
* A second client app is added to the solution, `SecondBlazorApp.Client`. The second client app is accessible in a browser from the URL `/SecondApp` on either port 5002 or with a host of `secondapp.com`.

> [!NOTE]
> The example shown in this section requires additional configuration for:
>
> * Accessing the apps directly at the example host domains, `firstapp.com` and `secondapp.com`.
> * Certificates for the client apps to enable TLS security (HTTPS).
> * Configuring the server app as a Razor Pages app for the following features:
>   * Integration of Razor components into Razor pages.
>   * Prerendering Razor components.
>
> The preceding configurations are beyond the scope of this article. For more information, see the following resources:
> 
> * [Host and deploy articles](xref:host-and-deploy/index)
> * <xref:blazor/components/prerendering-and-integration?pivots=webassembly>
> * <xref:security/enforcing-ssl>

Use an existing hosted Blazor solution or create a new solution from the Blazor Hosted project template:

* In the client app's project file, add a [`<StaticWebAssetBasePath>` property](xref:blazor/fundamentals/static-files#static-web-asset-base-path) to the `<PropertyGroup>` with a value of `FirstApp` to set the base path for the project's static assets:

  ```xml
  <PropertyGroup>
    ...
    <StaticWebAssetBasePath>FirstApp</StaticWebAssetBasePath>
  </PropertyGroup>
  ```

* Add a second client app to the solution:

  * Add a folder named `SecondClient` to the solution's folder. The solution folder created from the project template contains the following solution file and folders after the `SecondClient` folder is added:
  
    * `Client` (folder)
    * `SecondClient` (folder)
    * `Server` (folder)
    * `Shared` (folder)
    * `{SOLUTION NAME}.sln` (file)

    The placeholder `{SOLUTION NAME}` is the solution's name.

  * Create a Blazor WebAssembly app named `SecondBlazorApp.Client` in the `SecondClient` folder from the Blazor WebAssembly project template.

  * In the `SecondBlazorApp.Client` app's project file:

    * Add a `<StaticWebAssetBasePath>` property to the `<PropertyGroup>` with a value of `SecondApp`:

      ```xml
      <PropertyGroup>
        ...
        <StaticWebAssetBasePath>SecondApp</StaticWebAssetBasePath>
      </PropertyGroup>
      ```

    * Add a project reference to the `Shared` project:

      ```xml
      <ItemGroup>
        <ProjectReference Include="..\Shared\{SOLUTION NAME}.Shared.csproj" />
      </ItemGroup>
      ```

      The placeholder `{SOLUTION NAME}` is the solution's name.

* In the server app's project file, create a project reference for the added `SecondBlazorApp.Client` client app:

  ```xml
  <ItemGroup>
    <ProjectReference Include="..\Client\{SOLUTION NAME}.Client.csproj" />
    <ProjectReference Include="..\SecondClient\SecondBlazorApp.Client.csproj" />
    <ProjectReference Include="..\Shared\{SOLUTION NAME}.Shared.csproj" />
  </ItemGroup>
  ```
  
  The placeholder `{SOLUTION NAME}` is the solution's name.

* In the server app's `Properties/launchSettings.json` file, configure the `applicationUrl` of the Kestrel profile (`{SOLUTION NAME}.Server`) to access the client apps at ports 5001 and 5002:

  ```json
  "applicationUrl": "https://localhost:5001;https://localhost:5002",
  ```

* In the server app's `Program.cs` file, remove the following lines, which appear after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>:

  ```diff
  -app.UseBlazorFrameworkFiles();
  -app.UseStaticFiles();

  -app.UseRouting();

  -app.MapRazorPages();
  -app.MapControllers();
  -app.MapFallbackToFile("index.html");
  ```

  Add middleware that maps requests to the client apps. The following example configures the middleware to run when:

  * The request port is either 5001 for the original client app or 5002 for the added client app.
  * The request host is either `firstapp.com` for the original client app or `secondapp.com` for the added client app.

  Place the following code where the lines were removed earlier:

  ```csharp
  app.MapWhen(ctx => ctx.Request.Host.Port == 5001 || 
      ctx.Request.Host.Equals("firstapp.com"), first =>
  {
      first.Use((ctx, nxt) =>
      {
          ctx.Request.Path = "/FirstApp" + ctx.Request.Path;
          return nxt();
      });

      first.UseBlazorFrameworkFiles("/FirstApp");
      first.UseStaticFiles();
      first.UseStaticFiles("/FirstApp");
      first.UseRouting();

      first.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
          endpoints.MapFallbackToFile("/FirstApp/{*path:nonfile}", 
              "FirstApp/index.html");
      });
  });
  
  app.MapWhen(ctx => ctx.Request.Host.Port == 5002 || 
      ctx.Request.Host.Equals("secondapp.com"), second =>
  {
      second.Use((ctx, nxt) =>
      {
          ctx.Request.Path = "/SecondApp" + ctx.Request.Path;
          return nxt();
      });

      second.UseBlazorFrameworkFiles("/SecondApp");
      second.UseStaticFiles();
      second.UseStaticFiles("/SecondApp");
      second.UseRouting();

      second.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
          endpoints.MapFallbackToFile("/SecondApp/{*path:nonfile}", 
              "SecondApp/index.html");
      });
  });
  ```

  For more information on <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, see <xref:blazor/fundamentals/static-files#static-file-middleware>.

  For more information on `UseBlazorFrameworkFiles` and `MapFallbackToFile`, see the following resources:

  * <xref:Microsoft.AspNetCore.Builder.ComponentsWebAssemblyApplicationBuilderExtensions.UseBlazorFrameworkFiles%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/Server/src/ComponentsWebAssemblyApplicationBuilderExtensions.cs))
  * <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/StaticFiles/src/StaticFilesEndpointRouteBuilderExtensions.cs))

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

* In the server app's weather forecast controller (`Controllers/WeatherForecastController.cs`), replace the existing route (`[Route("[controller]")]`) to `WeatherForecastController` with the following routes:

  ```csharp
  [Route("FirstApp/[controller]")]
  [Route("SecondApp/[controller]")]
  ```

  The middleware added to the server app's request processing pipeline earlier modifies incoming requests to `/WeatherForecast` to either `/FirstApp/WeatherForecast` or `/SecondApp/WeatherForecast` depending on the port (5001/5002) or domain (`firstapp.com`/`secondapp.com`). The preceding controller routes are required in order to return weather data from the server app to the client apps.

### Static assets and class libraries for multiple Blazor WebAssembly apps

Use the following approaches to reference static assets:

* When the asset is in the client app's `wwwroot` folder, provide the path normally:

  ```razor
  <img alt="..." src="/{PATH AND FILE NAME}" />
  ```

  The `{PATH AND FILE NAME}` placeholder is the path and file name under `wwwroot`.

* When the asset is in the `wwwroot` folder of a [Razor Class Library (RCL)](xref:blazor/components/class-libraries), reference the static asset in the client app per the guidance in <xref:razor-pages/ui-class#consume-content-from-a-referenced-rcl>:

  ```razor
  <img alt="..." src="_content/{PACKAGE ID}/{PATH AND FILE NAME}" />
  ```

  The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. The `{PATH AND FILE NAME}` placeholder is path and file name under `wwwroot`.

For more information on RCLs, see:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

## Standalone deployment

A *standalone deployment* serves the Blazor WebAssembly app as a set of static files that are requested directly by clients. Any static file server is able to serve the Blazor app.

Standalone deployment assets are published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder.

### Azure App Service

Blazor WebAssembly apps can be deployed to Azure App Services on Windows, which hosts the app on [IIS](#iis).

Deploying a standalone Blazor WebAssembly app to Azure App Service for Linux isn't currently supported. We recommend hosting a standalone Blazor WebAssembly app using [Azure Static Web Apps](#azure-static-web-apps), which supports this scenario.

### Azure Static Web Apps

For more information, see [Tutorial: Building a static web app with Blazor in Azure Static Web Apps](/azure/static-web-apps/deploy-blazor).

### IIS

IIS is a capable static file server for Blazor apps. To configure IIS to host Blazor, see [Build a Static Website on IIS](/iis/manage/creating-websites/scenario-build-a-static-website-on-iis).

Published assets are created in the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Host the contents of the `publish` folder on the web server or hosting service.

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

1. Place the custom `web.config` file in the project's root folder. For a hosted Blazor WebAssembly solution, place the file in the **`Server`** project's folder.
1. Publish the project. For a hosted Blazor WebAssembly solution, publish the solution from the **`Server`** project. For more information, see <xref:blazor/host-and-deploy/index>.

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

*This section only applies to standalone Blazor WebAssembly apps. Hosted Blazor apps use a default ASP.NET Core app `web.config` file, not the file linked in this section.*

IIS can be configured via `web.config` to serve Brotli or Gzip compressed Blazor assets for standalone Blazor WebAssembly apps. For an example configuration file, see [`web.config`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/host-and-deploy/webassembly/_samples/web.config?raw=true).

Additional configuration of the example `web.config` file might be required in the following scenarios:

* The app's specification calls for either of the following:
  * Serving compressed files that aren't configured by the example `web.config` file.
  * Serving compressed files configured by the example `web.config` file in an uncompressed format.
* The server's IIS configuration (for example, `applicationHost.config`) provides server-level IIS defaults. Depending on the server-level configuration, the app might require a different IIS configuration than what the example `web.config` file contains.

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

1. Place the Apache configuration file into the `/etc/httpd/conf.d/` directory, which is the default Apache configuration directory in CentOS 7.

1. Place the app's files into the `/var/www/blazorapp` directory (the location specified to `DocumentRoot` in the configuration file).

1. Restart the Apache service.

For more information, see [`mod_mime`](https://httpd.apache.org/docs/2.4/mod/mod_mime.html) and [`mod_deflate`](https://httpd.apache.org/docs/current/mod/mod_deflate.html).

### GitHub Pages

To handle URL rewrites, add a `wwwroot/404.html` file with a script that handles redirecting the request to the `index.html` page. For an example, see the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages):

* [`wwwroot/404.html`](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/wwwroot/404.html)
* [Live site](https://stevesandersonms.github.io/BlazorOnGitHubPages/))

When using a project site instead of an organization site, update the `<base>` tag in `wwwroot/index.html`. Set the `href` attribute value to the GitHub repository name with a trailing slash (for example, `/my-repository/`). In the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages), the base `href` is updated at publish by the [`.github/workflows/main.yml` configuration file](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/.github/workflows/main.yml).

> [!NOTE]
> The [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages) isn't owned, maintained, or supported by the .NET Foundation or Microsoft.

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
  * [ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
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
    ProxyRequests     On
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
    ProxyRequests     On
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
    ProxyRequests     On
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
  * [ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

-->

## Configure the Trimmer

Blazor performs Intermediate Language (IL) trimming on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-trimmer>.

## Change the filename extension of DLL files

In case you have a need to change the filename extensions of the app's published `.dll` files, follow the guidance in this section.

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

Common reasons why this fails are:

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

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

With the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser in parallel.
* The app is executed directly on the browser UI thread.

The following deployment strategies are supported:

* The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
* The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.

## Customize how boot resources are loaded

Customize how boot resources are loaded using the `loadBootResource` API. For more information, see <xref:blazor/fundamentals/startup#load-boot-resources>.

## Compression

When a Blazor WebAssembly app is published, the output is statically compressed during publish to reduce the app's size and remove the overhead for runtime compression. The following compression algorithms are used:

* [Brotli](https://tools.ietf.org/html/rfc7932) (highest level)
* [Gzip](https://tools.ietf.org/html/rfc1952)

Blazor relies on the host to the serve the appropriate compressed files. When using an ASP.NET Core hosted project, the host project is capable of performing content negotiation and serving the statically-compressed files. When hosting a Blazor WebAssembly standalone app, additional work might be required to ensure that statically-compressed files are served:

* For IIS `web.config` compression configuration, see the [IIS: Brotli and Gzip compression](#brotli-and-gzip-compression) section. 
* When hosting on static hosting solutions that don't support statically-compressed file content negotiation, such as GitHub Pages, consider configuring the app to fetch and decode Brotli compressed files:

  * Obtain the JavaScript Brotli decoder from the [google/brotli GitHub repository](https://github.com/google/brotli). The minified decoder file is named `decode.min.js` and found in the repository's [`js` folder](https://github.com/google/brotli/tree/master/js).
  
    > [!NOTE]
    > If the minified version of the `decode.js` script (`decode.min.js`) fails, try using the unminified version (`decode.js`) instead.

  * Update the app to use the decoder.
    
    In the `wwwroot/index.html` file, set `autostart` to `false` on Blazor's `<script>` tag:
    
    ```html
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    ```
    
    After Blazor's `<script>` tag and before the closing `</body>` tag, add the following JavaScript code `<script>` block:
  
    ```html
    <script type="module">
      import { BrotliDecode } from './decode.min.js';
      Blazor.start({
        loadBootResource: function (type, name, defaultUri, integrity) {
          if (type !== 'dotnetjs' && location.hostname !== 'localhost') {
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

## Rewrite URLs for correct routing

Routing requests for page components in a Blazor WebAssembly app isn't as straightforward as routing requests in a Blazor Server, hosted app. Consider a Blazor WebAssembly app with two components:

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

## Hosted deployment with ASP.NET Core

A *hosted deployment* serves the Blazor WebAssembly app to browsers from an [ASP.NET Core app](xref:index) that runs on a web server.

The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the server app. The two apps are deployed together. A web server that is capable of hosting an ASP.NET Core app is required. For a hosted deployment, Visual Studio includes the **Blazor WebAssembly App** project template (`blazorwasm` template when using the [`dotnet new`](/dotnet/core/tools/dotnet-new) command) with the **`Hosted`** option selected (`-ho|--hosted` when using the `dotnet new` command).

For more information, see the following articles:

* ASP.NET Core app hosting and deployment: <xref:host-and-deploy/index>
* Deployment to Azure App Service: <xref:tutorials/publish-to-azure-webapp-using-vs>
* Blazor project templates: <xref:blazor/project-structure>

## Hosted deployment with multiple Blazor WebAssembly apps

### App configuration

Hosted Blazor solutions can serve multiple Blazor WebAssembly apps.

> [!NOTE]
> The example in this section references the use of a Visual Studio *solution*, but the use of Visual Studio and a Visual Studio solution isn't required for multiple client apps to work in a hosted Blazor WebAssembly apps scenario. If you aren't using Visual Studio, ignore the `{SOLUTION NAME}.sln` file and any other files created for Visual Studio.

In the following example:

* The initial (first) client app is the default client project of a solution created from the Blazor WebAssembly project template. The first client app is accessible in a browser from the URL `/FirstApp` on either port 5001 or with a host of `firstapp.com`.
* A second client app is added to the solution, `SecondBlazorApp.Client`. The second client app is accessible in a browser from the URL `/SecondApp` on either port 5002 or with a host of `secondapp.com`.

Use an existing hosted Blazor solution or create a new solution from the Blazor Hosted project template:

* In the client app's project file, add a [`<StaticWebAssetBasePath>` property](xref:blazor/fundamentals/static-files#static-web-asset-base-path) to the `<PropertyGroup>` with a value of `FirstApp` to set the base path for the project's static assets:

  ```xml
  <PropertyGroup>
    ...
    <StaticWebAssetBasePath>FirstApp</StaticWebAssetBasePath>
  </PropertyGroup>
  ```

* Add a second client app to the solution:

  * Add a folder named `SecondClient` to the solution's folder. The solution folder created from the project template contains the following solution file and folders after the `SecondClient` folder is added:
  
    * `Client` (folder)
    * `SecondClient` (folder)
    * `Server` (folder)
    * `Shared` (folder)
    * `{SOLUTION NAME}.sln` (file)

    The placeholder `{SOLUTION NAME}` is the solution's name.

  * Create a Blazor WebAssembly app named `SecondBlazorApp.Client` in the `SecondClient` folder from the Blazor WebAssembly project template.

  * In the `SecondBlazorApp.Client` app's project file:

    * Add a `<StaticWebAssetBasePath>` property to the `<PropertyGroup>` with a value of `SecondApp`:

      ```xml
      <PropertyGroup>
        ...
        <StaticWebAssetBasePath>SecondApp</StaticWebAssetBasePath>
      </PropertyGroup>
      ```

    * Add a project reference to the `Shared` project:

      ```xml
      <ItemGroup>
        <ProjectReference Include="..\Shared\{SOLUTION NAME}.Shared.csproj" />
      </ItemGroup>
      ```

      The placeholder `{SOLUTION NAME}` is the solution's name.

* In the server app's project file, create a project reference for the added `SecondBlazorApp.Client` client app:

  ```xml
  <ItemGroup>
    <ProjectReference Include="..\Client\{SOLUTION NAME}.Client.csproj" />
    <ProjectReference Include="..\SecondClient\SecondBlazorApp.Client.csproj" />
    <ProjectReference Include="..\Shared\{SOLUTION NAME}.Shared.csproj" />
  </ItemGroup>
  ```
  
  The placeholder `{SOLUTION NAME}` is the solution's name.

* In the server app's `Properties/launchSettings.json` file, configure the `applicationUrl` of the Kestrel profile (`{SOLUTION NAME}.Server`) to access the client apps at ports 5001 and 5002:

  ```json
  "applicationUrl": "https://localhost:5001;https://localhost:5002",
  ```

* In the server app's `Startup.Configure` method (`Startup.cs`), remove the following lines, which appear after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>:

  ```diff
  -app.UseBlazorFrameworkFiles();
  -app.UseStaticFiles();

  -app.UseRouting();

  -app.UseEndpoints(endpoints =>
  -{
  -    endpoints.MapRazorPages();
  -    endpoints.MapControllers();
  -    endpoints.MapFallbackToFile("index.html");
  -});
  ```

  Add middleware that maps requests to the client apps. The following example configures the middleware to run when:

  * The request port is either 5001 for the original client app or 5002 for the added client app.
  * The request host is either `firstapp.com` for the original client app or `secondapp.com` for the added client app.

    > [!NOTE]
    > The example shown in this section requires additional configuration for:
    >
    > * Accessing the apps at the example host domains, `firstapp.com` and `secondapp.com`.
    > * Certificates for the client apps to enable TLS security (HTTPS).
    >
    > The required configuration is beyond the scope of this article and depends on how the solution is hosted. For more information see the [Host and deploy articles](xref:host-and-deploy/index).

  Place the following code where the lines were removed earlier:

  ```csharp
  app.MapWhen(ctx => ctx.Request.Host.Port == 5001 || 
      ctx.Request.Host.Equals("firstapp.com"), first =>
  {
      first.Use((ctx, nxt) =>
      {
          ctx.Request.Path = "/FirstApp" + ctx.Request.Path;
          return nxt();
      });

      first.UseBlazorFrameworkFiles("/FirstApp");
      first.UseStaticFiles();
      first.UseStaticFiles("/FirstApp");
      first.UseRouting();

      first.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
          endpoints.MapFallbackToFile("/FirstApp/{*path:nonfile}", 
              "FirstApp/index.html");
      });
  });
  
  app.MapWhen(ctx => ctx.Request.Host.Port == 5002 || 
      ctx.Request.Host.Equals("secondapp.com"), second =>
  {
      second.Use((ctx, nxt) =>
      {
          ctx.Request.Path = "/SecondApp" + ctx.Request.Path;
          return nxt();
      });

      second.UseBlazorFrameworkFiles("/SecondApp");
      second.UseStaticFiles();
      second.UseStaticFiles("/SecondApp");
      second.UseRouting();

      second.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
          endpoints.MapFallbackToFile("/SecondApp/{*path:nonfile}", 
              "SecondApp/index.html");
      });
  });
  ```

  For more information on <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, see <xref:blazor/fundamentals/static-files#static-file-middleware>.

  For more information on `UseBlazorFrameworkFiles` and `MapFallbackToFile`, see the following resources:

  * <xref:Microsoft.AspNetCore.Builder.ComponentsWebAssemblyApplicationBuilderExtensions.UseBlazorFrameworkFiles%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/Server/src/ComponentsWebAssemblyApplicationBuilderExtensions.cs))
  * <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/StaticFiles/src/StaticFilesEndpointRouteBuilderExtensions.cs))

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

* In the server app's weather forecast controller (`Controllers/WeatherForecastController.cs`), replace the existing route (`[Route("[controller]")]`) to `WeatherForecastController` with the following routes:

  ```csharp
  [Route("FirstApp/[controller]")]
  [Route("SecondApp/[controller]")]
  ```

  The middleware added to the server app's `Startup.Configure` method earlier modifies incoming requests to `/WeatherForecast` to either `/FirstApp/WeatherForecast` or `/SecondApp/WeatherForecast` depending on the port (5001/5002) or domain (`firstapp.com`/`secondapp.com`). The preceding controller routes are required in order to return weather data from the server app to the client apps.

### Static assets and class libraries for multiple Blazor WebAssembly apps

Use the following approaches to reference static assets:

* When the asset is in the client app's `wwwroot` folder, provide the path normally:

  ```razor
  <img alt="..." src="/{PATH AND FILE NAME}" />
  ```

  The `{PATH AND FILE NAME}` placeholder is the path and file name under `wwwroot`.

* When the asset is in the `wwwroot` folder of a [Razor Class Library (RCL)](xref:blazor/components/class-libraries), reference the static asset in the client app per the guidance in <xref:razor-pages/ui-class#consume-content-from-a-referenced-rcl>:

  ```razor
  <img alt="..." src="_content/{PACKAGE ID}/{PATH AND FILE NAME}" />
  ```

  The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. The `{PATH AND FILE NAME}` placeholder is path and file name under `wwwroot`.

For more information on RCLs, see:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

## Standalone deployment

A *standalone deployment* serves the Blazor WebAssembly app as a set of static files that are requested directly by clients. Any static file server is able to serve the Blazor app.

Standalone deployment assets are published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder.

### Azure App Service

Blazor WebAssembly apps can be deployed to Azure App Services on Windows, which hosts the app on [IIS](#iis).

Deploying a standalone Blazor WebAssembly app to Azure App Service for Linux isn't currently supported. We recommend hosting a standalone Blazor WebAssembly app using [Azure Static Web Apps](#azure-static-web-apps), which supports this scenario.

### Azure Static Web Apps

For more information, see [Tutorial: Building a static web app with Blazor in Azure Static Web Apps](/azure/static-web-apps/deploy-blazor).

### IIS

IIS is a capable static file server for Blazor apps. To configure IIS to host Blazor, see [Build a Static Website on IIS](/iis/manage/creating-websites/scenario-build-a-static-website-on-iis).

Published assets are created in the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Host the contents of the `publish` folder on the web server or hosting service.

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

1. Place the custom `web.config` file in the project's root folder. For a hosted Blazor WebAssembly solution, place the file in the **`Server`** project's folder.
1. Set the `<PublishIISAssets>` property to `true` in the project file (`.csproj`). For a hosted Blazor WebAssembly solution, set the property in the **`Server`** project's project file.

   ```xml
   <PropertyGroup>
     <PublishIISAssets>true</PublishIISAssets>
   </PropertyGroup>
   ```

1. Publish the project. For a hosted Blazor WebAssembly solution, publish the solution from the **`Server`** project. For more information, see <xref:blazor/host-and-deploy/index>.

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

*This section only applies to standalone Blazor WebAssembly apps. Hosted Blazor apps use a default ASP.NET Core app `web.config` file, not the file linked in this section.*

IIS can be configured via `web.config` to serve Brotli or Gzip compressed Blazor assets for standalone Blazor WebAssembly apps. For an example configuration file, see [`web.config`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/host-and-deploy/webassembly/_samples/web.config?raw=true).

Additional configuration of the example `web.config` file might be required in the following scenarios:

* The app's specification calls for either of the following:
  * Serving compressed files that aren't configured by the example `web.config` file.
  * Serving compressed files configured by the example `web.config` file in an uncompressed format.
* The server's IIS configuration (for example, `applicationHost.config`) provides server-level IIS defaults. Depending on the server-level configuration, the app might require a different IIS configuration than what the example `web.config` file contains.

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

1. Place the Apache configuration file into the `/etc/httpd/conf.d/` directory, which is the default Apache configuration directory in CentOS 7.

1. Place the app's files into the `/var/www/blazorapp` directory (the location specified to `DocumentRoot` in the configuration file).

1. Restart the Apache service.

For more information, see [`mod_mime`](https://httpd.apache.org/docs/2.4/mod/mod_mime.html) and [`mod_deflate`](https://httpd.apache.org/docs/current/mod/mod_deflate.html).

### GitHub Pages

To handle URL rewrites, add a `wwwroot/404.html` file with a script that handles redirecting the request to the `index.html` page. For an example, see the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages):

* [`wwwroot/404.html`](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/wwwroot/404.html)
* [Live site](https://stevesandersonms.github.io/BlazorOnGitHubPages/))

When using a project site instead of an organization site, update the `<base>` tag in `wwwroot/index.html`. Set the `href` attribute value to the GitHub repository name with a trailing slash (for example, `/my-repository/`). In the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages), the base `href` is updated at publish by the [`.github/workflows/main.yml` configuration file](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/.github/workflows/main.yml).

> [!NOTE]
> The [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages) isn't owned, maintained, or supported by the .NET Foundation or Microsoft.

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

## Configure the Trimmer

Blazor performs Intermediate Language (IL) trimming on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-trimmer>.

## Change the filename extension of DLL files

In case you have a need to change the filename extensions of the app's published `.dll` files, follow the guidance in this section.

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

In the preceding command, the `{PATH}` placeholder is the path to the published `_framework` folder (for example, `.\bin\Release\net5.0\browser-wasm\publish\wwwroot\_framework` from the project's root folder).

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

In the preceding command, the `{PATH}` placeholder is the path to the published `_framework` folder (for example, `.\bin\Release\net5.0\browser-wasm\publish\wwwroot\_framework` from the project's root folder).

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

When an app is built, the generated `blazor.boot.json` manifest describes the SHA-256 hashes of your boot resources at the time that the build output is produced. The integrity check passes as long as the SHA-256 hashes in `blazor.boot.json` match the files delivered to the browser.

Common reasons why this fails are:

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

:::moniker-end

:::moniker range="< aspnetcore-5.0"

With the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser in parallel.
* The app is executed directly on the browser UI thread.

The following deployment strategies are supported:

* The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
* The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.

## Customize how boot resources are loaded

Customize how boot resources are loaded using the `loadBootResource` API. For more information, see <xref:blazor/fundamentals/startup#load-boot-resources>.

## Compression

When a Blazor WebAssembly app is published, the output is statically compressed during publish to reduce the app's size and remove the overhead for runtime compression. The following compression algorithms are used:

* [Brotli](https://tools.ietf.org/html/rfc7932) (highest level)
* [Gzip](https://tools.ietf.org/html/rfc1952)

Blazor relies on the host to the serve the appropriate compressed files. When using an ASP.NET Core hosted project, the host project is capable of performing content negotiation and serving the statically-compressed files. When hosting a Blazor WebAssembly standalone app, additional work might be required to ensure that statically-compressed files are served:

* For IIS `web.config` compression configuration, see the [IIS: Brotli and Gzip compression](#brotli-and-gzip-compression) section. 
* When hosting on static hosting solutions that don't support statically-compressed file content negotiation, such as GitHub Pages, consider configuring the app to fetch and decode Brotli compressed files:

  * Obtain the JavaScript Brotli decoder from the [google/brotli GitHub repository](https://github.com/google/brotli). The minified decoder file is named `decode.min.js` and found in the repository's [`js` folder](https://github.com/google/brotli/tree/master/js).
  
    > [!NOTE]
    > If the minified version of the `decode.js` script (`decode.min.js`) fails, try using the unminified version (`decode.js`) instead.

  * Update the app to use the decoder.
    
    In the `wwwroot/index.html` file, set `autostart` to `false` on Blazor's `<script>` tag:
    
    ```html
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    ```
    
    After Blazor's `<script>` tag and before the closing `</body>` tag, add the following JavaScript code `<script>` block:
  
    ```html
    <script type="module">
      import { BrotliDecode } from './decode.min.js';
      Blazor.start({
        loadBootResource: function (type, name, defaultUri, integrity) {
          if (type !== 'dotnetjs' && location.hostname !== 'localhost') {
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

## Rewrite URLs for correct routing

Routing requests for page components in a Blazor WebAssembly app isn't as straightforward as routing requests in a Blazor Server, hosted app. Consider a Blazor WebAssembly app with two components:

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

## Hosted deployment with ASP.NET Core

A *hosted deployment* serves the Blazor WebAssembly app to browsers from an [ASP.NET Core app](xref:index) that runs on a web server.

The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the server app. The two apps are deployed together. A web server that is capable of hosting an ASP.NET Core app is required. For a hosted deployment, Visual Studio includes the **Blazor WebAssembly App** project template (`blazorwasm` template when using the [`dotnet new`](/dotnet/core/tools/dotnet-new) command) with the **`Hosted`** option selected (`-ho|--hosted` when using the `dotnet new` command).

For more information, see the following articles:

* ASP.NET Core app hosting and deployment: <xref:host-and-deploy/index>
* Deployment to Azure App Service: <xref:tutorials/publish-to-azure-webapp-using-vs>
* Blazor project templates: <xref:blazor/project-structure>

## Hosted deployment with multiple Blazor WebAssembly apps

### App configuration

Hosted Blazor solutions can serve multiple Blazor WebAssembly apps.

> [!NOTE]
> The example in this section references the use of a Visual Studio *solution*, but the use of Visual Studio and a Visual Studio solution isn't required for multiple client apps to work in a hosted Blazor WebAssembly apps scenario. If you aren't using Visual Studio, ignore the `{SOLUTION NAME}.sln` file and any other files created for Visual Studio.

In the following example:

* The initial (first) client app is the default client project of a solution created from the Blazor WebAssembly project template. The first client app is accessible in a browser from the URL `/FirstApp` on either port 5001 or with a host of `firstapp.com`.
* A second client app is added to the solution, `SecondBlazorApp.Client`. The second client app is accessible in a browser from the URL `/SecondApp` on either port 5002 or with a host of `secondapp.com`.

Use an existing hosted Blazor solution or create a new solution from the Blazor Hosted project template:

* In the client app's project file, add a [`<StaticWebAssetBasePath>` property](xref:blazor/fundamentals/static-files#static-web-asset-base-path) to the `<PropertyGroup>` with a value of `FirstApp` to set the base path for the project's static assets:

  ```xml
  <PropertyGroup>
    ...
    <StaticWebAssetBasePath>FirstApp</StaticWebAssetBasePath>
  </PropertyGroup>
  ```

* Add a second client app to the solution:

  * Add a folder named `SecondClient` to the solution's folder. The solution folder created from the project template contains the following solution file and folders after the `SecondClient` folder is added:
  
    * `Client` (folder)
    * `SecondClient` (folder)
    * `Server` (folder)
    * `Shared` (folder)
    * `{SOLUTION NAME}.sln` (file)

    The placeholder `{SOLUTION NAME}` is the solution's name.

  * Create a Blazor WebAssembly app named `SecondBlazorApp.Client` in the `SecondClient` folder from the Blazor WebAssembly project template.

  * In the `SecondBlazorApp.Client` app's project file:

    * Add a `<StaticWebAssetBasePath>` property to the `<PropertyGroup>` with a value of `SecondApp`:

      ```xml
      <PropertyGroup>
        ...
        <StaticWebAssetBasePath>SecondApp</StaticWebAssetBasePath>
      </PropertyGroup>
      ```

    * Add a project reference to the `Shared` project:

      ```xml
      <ItemGroup>
        <ProjectReference Include="..\Shared\{SOLUTION NAME}.Shared.csproj" />
      </ItemGroup>
      ```

      The placeholder `{SOLUTION NAME}` is the solution's name.

* In the server app's project file, create a project reference for the added `SecondBlazorApp.Client` client app:

  ```xml
  <ItemGroup>
    <ProjectReference Include="..\Client\{SOLUTION NAME}.Client.csproj" />
    <ProjectReference Include="..\SecondClient\SecondBlazorApp.Client.csproj" />
    <ProjectReference Include="..\Shared\{SOLUTION NAME}.Shared.csproj" />
  </ItemGroup>
  ```
  
  The placeholder `{SOLUTION NAME}` is the solution's name.

* In the server app's `Properties/launchSettings.json` file, configure the `applicationUrl` of the Kestrel profile (`{SOLUTION NAME}.Server`) to access the client apps at ports 5001 and 5002:

  ```json
  "applicationUrl": "https://localhost:5001;https://localhost:5002",
  ```

* In the server app's `Startup.Configure` method (`Startup.cs`), remove the following lines, which appear after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>:

  ```diff
  -app.UseBlazorFrameworkFiles();
  -app.UseStaticFiles();

  -app.UseRouting();

  -app.UseEndpoints(endpoints =>
  -{
  -    endpoints.MapRazorPages();
  -    endpoints.MapControllers();
  -    endpoints.MapFallbackToFile("index.html");
  -});
  ```

  Add middleware that maps requests to the client apps. The following example configures the middleware to run when:

  * The request port is either 5001 for the original client app or 5002 for the added client app.
  * The request host is either `firstapp.com` for the original client app or `secondapp.com` for the added client app.

    > [!NOTE]
    > The example shown in this section requires additional configuration for:
    >
    > * Accessing the apps at the example host domains, `firstapp.com` and `secondapp.com`.
    > * Certificates for the client apps to enable TLS security (HTTPS).
    >
    > The required configuration is beyond the scope of this article and depends on how the solution is hosted. For more information see the [Host and deploy articles](xref:host-and-deploy/index).

  Place the following code where the lines were removed earlier:

  ```csharp
  app.MapWhen(ctx => ctx.Request.Host.Port == 5001 || 
      ctx.Request.Host.Equals("firstapp.com"), first =>
  {
      first.Use((ctx, nxt) =>
      {
          ctx.Request.Path = "/FirstApp" + ctx.Request.Path;
          return nxt();
      });

      first.UseBlazorFrameworkFiles("/FirstApp");
      first.UseStaticFiles();
      first.UseStaticFiles("/FirstApp");
      first.UseRouting();

      first.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
          endpoints.MapFallbackToFile("/FirstApp/{*path:nonfile}", 
              "FirstApp/index.html");
      });
  });
  
  app.MapWhen(ctx => ctx.Request.Host.Port == 5002 || 
      ctx.Request.Host.Equals("secondapp.com"), second =>
  {
      second.Use((ctx, nxt) =>
      {
          ctx.Request.Path = "/SecondApp" + ctx.Request.Path;
          return nxt();
      });

      second.UseBlazorFrameworkFiles("/SecondApp");
      second.UseStaticFiles();
      second.UseStaticFiles("/SecondApp");
      second.UseRouting();

      second.UseEndpoints(endpoints =>
      {
          endpoints.MapControllers();
          endpoints.MapFallbackToFile("/SecondApp/{*path:nonfile}", 
              "SecondApp/index.html");
      });
  });
  ```

  For more information on <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, see <xref:blazor/fundamentals/static-files#static-file-middleware>.

  For more information on `UseBlazorFrameworkFiles` and `MapFallbackToFile`, see the following resources:

  * <xref:Microsoft.AspNetCore.Builder.ComponentsWebAssemblyApplicationBuilderExtensions.UseBlazorFrameworkFiles%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/Server/src/ComponentsWebAssemblyApplicationBuilderExtensions.cs))
  * <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/StaticFiles/src/StaticFilesEndpointRouteBuilderExtensions.cs))

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

* In the server app's weather forecast controller (`Controllers/WeatherForecastController.cs`), replace the existing route (`[Route("[controller]")]`) to `WeatherForecastController` with the following routes:

  ```csharp
  [Route("FirstApp/[controller]")]
  [Route("SecondApp/[controller]")]
  ```

  The middleware added to the server app's `Startup.Configure` method earlier modifies incoming requests to `/WeatherForecast` to either `/FirstApp/WeatherForecast` or `/SecondApp/WeatherForecast` depending on the port (5001/5002) or domain (`firstapp.com`/`secondapp.com`). The preceding controller routes are required in order to return weather data from the server app to the client apps.

### Static assets and class libraries for multiple Blazor WebAssembly apps

Use the following approaches to reference static assets:

* When the asset is in the client app's `wwwroot` folder, provide the path normally:

  ```razor
  <img alt="..." src="/{PATH AND FILE NAME}" />
  ```

  The `{PATH AND FILE NAME}` placeholder is the path and file name under `wwwroot`.

* When the asset is in the `wwwroot` folder of a [Razor Class Library (RCL)](xref:blazor/components/class-libraries), reference the static asset in the client app per the guidance in <xref:razor-pages/ui-class#consume-content-from-a-referenced-rcl>:

  ```razor
  <img alt="..." src="_content/{PACKAGE ID}/{PATH AND FILE NAME}" />
  ```

  The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. The `{PATH AND FILE NAME}` placeholder is path and file name under `wwwroot`.

For more information on RCLs, see:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

## Standalone deployment

A *standalone deployment* serves the Blazor WebAssembly app as a set of static files that are requested directly by clients. Any static file server is able to serve the Blazor app.

Standalone deployment assets are published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder.

### Azure App Service

Blazor WebAssembly apps can be deployed to Azure App Services on Windows, which hosts the app on [IIS](#iis).

Deploying a standalone Blazor WebAssembly app to Azure App Service for Linux isn't currently supported. We recommend hosting a standalone Blazor WebAssembly app using [Azure Static Web Apps](#azure-static-web-apps), which supports this scenario.

### Azure Static Web Apps

For more information, see [Tutorial: Building a static web app with Blazor in Azure Static Web Apps](/azure/static-web-apps/deploy-blazor).

### IIS

IIS is a capable static file server for Blazor apps. To configure IIS to host Blazor, see [Build a Static Website on IIS](/iis/manage/creating-websites/scenario-build-a-static-website-on-iis).

Published assets are created in the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Host the contents of the `publish` folder on the web server or hosting service.

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

1. Place the custom `web.config` file in the project's root folder. For a hosted Blazor WebAssembly solution, place the file in the **`Server`** project's folder.
1. Set the `<PublishIISAssets>` property to `true` in the project file (`.csproj`). For a hosted Blazor WebAssembly solution, set the property in the **`Server`** project's project file.

   ```xml
   <PropertyGroup>
     <PublishIISAssets>true</PublishIISAssets>
   </PropertyGroup>
   ```

1. Publish the project. For a hosted Blazor WebAssembly solution, publish the solution from the **`Server`** project. For more information, see <xref:blazor/host-and-deploy/index>.

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

*This section only applies to standalone Blazor WebAssembly apps. Hosted Blazor apps use a default ASP.NET Core app `web.config` file, not the file linked in this section.*

IIS can be configured via `web.config` to serve Brotli or Gzip compressed Blazor assets for standalone Blazor WebAssembly apps. For an example configuration file, see [`web.config`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/host-and-deploy/webassembly/_samples/web.config?raw=true).

Additional configuration of the example `web.config` file might be required in the following scenarios:

* The app's specification calls for either of the following:
  * Serving compressed files that aren't configured by the example `web.config` file.
  * Serving compressed files configured by the example `web.config` file in an uncompressed format.
* The server's IIS configuration (for example, `applicationHost.config`) provides server-level IIS defaults. Depending on the server-level configuration, the app might require a different IIS configuration than what the example `web.config` file contains.

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

1. Place the Apache configuration file into the `/etc/httpd/conf.d/` directory, which is the default Apache configuration directory in CentOS 7.

1. Place the app's files into the `/var/www/blazorapp` directory (the location specified to `DocumentRoot` in the configuration file).

1. Restart the Apache service.

For more information, see [`mod_mime`](https://httpd.apache.org/docs/2.4/mod/mod_mime.html) and [`mod_deflate`](https://httpd.apache.org/docs/current/mod/mod_deflate.html).

### GitHub Pages

To handle URL rewrites, add a `wwwroot/404.html` file with a script that handles redirecting the request to the `index.html` page. For an example, see the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages):

* [`wwwroot/404.html`](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/wwwroot/404.html)
* [Live site](https://stevesandersonms.github.io/BlazorOnGitHubPages/))

When using a project site instead of an organization site, update the `<base>` tag in `wwwroot/index.html`. Set the `href` attribute value to the GitHub repository name with a trailing slash (for example, `/my-repository/`). In the [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages), the base `href` is updated at publish by the [`.github/workflows/main.yml` configuration file](https://github.com/SteveSandersonMS/BlazorOnGitHubPages/blob/master/.github/workflows/main.yml).

> [!NOTE]
> The [SteveSandersonMS/BlazorOnGitHubPages GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages) isn't owned, maintained, or supported by the .NET Foundation or Microsoft.

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

## Configure the Linker

Blazor performs Intermediate Language (IL) linking on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-linker>.

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

When an app is built, the generated `blazor.boot.json` manifest describes the SHA-256 hashes of your boot resources at the time that the build output is produced. The integrity check passes as long as the SHA-256 hashes in `blazor.boot.json` match the files delivered to the browser.

Common reasons why this fails are:

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

:::moniker-end
