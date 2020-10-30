---
title: Host and deploy ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to host and deploy a Blazor app using ASP.NET Core, Content Delivery Networks (CDN), file servers, and GitHub Pages.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 10/09/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/host-and-deploy/webassembly
---
# Host and deploy ASP.NET Core Blazor WebAssembly

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), [Daniel Roth](https://github.com/danroth27), [Ben Adams](https://twitter.com/ben_a_adams), and [Safia Abdalla](https://safia.rocks)

With the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser in parallel.
* The app is executed directly on the browser UI thread.

The following deployment strategies are supported:

* The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
* The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.

## Compression

When a Blazor WebAssembly app is published, the output is statically compressed during publish to reduce the app's size and remove the overhead for runtime compression. The following compression algorithms are used:

* [Brotli](https://tools.ietf.org/html/rfc7932) (highest level)
* [Gzip](https://tools.ietf.org/html/rfc1952)

Blazor relies on the host to the serve the appropriate compressed files. When using an ASP.NET Core hosted project, the host project is capable of performing content negotiation and serving the statically-compressed files. When hosting a Blazor WebAssembly standalone app, additional work might be required to ensure that statically-compressed files are served:

* For IIS `web.config` compression configuration, see the [IIS: Brotli and Gzip compression](#brotli-and-gzip-compression) section. 
* When hosting on static hosting solutions that don't support statically-compressed file content negotiation, such as GitHub Pages, consider configuring the app to fetch and decode Brotli compressed files:

  * Obtain the JavaScript Brotli decoder from the [google/brotli GitHub repository](https://github.com/google/brotli). As of September 2020, the decoder file is named `decode.js` and found in the repository's [`js` folder](https://github.com/google/brotli/tree/master/js).
  
    > [!NOTE]
    > A regression is present in the minified version of the `decode.js` script (`decode.min.js`) in the [google/brotli GitHub repository](https://github.com/google/brotli). Either minify the script on your own or use the [npm package](https://www.npmjs.com/package/brotli) until the issue [Window.BrotliDecode is not set in decode.min.js (google/brotli #844)](https://github.com/google/brotli/issues/844) is resolved. The example code in this section uses the **unminified** version of the script.

  * Update the app to use the decoder. Change the markup inside the closing `<body>` tag in `wwwroot/index.html` to the following:
  
    ```html
    <script src="decode.js"></script>
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    <script>
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

For more information on ASP.NET Core app hosting and deployment, see <xref:host-and-deploy/index>.

For information on deploying to Azure App Service, see <xref:tutorials/publish-to-azure-webapp-using-vs>.

## Hosted deployment with multiple Blazor WebAssembly apps

### App configuration

To configure a hosted Blazor solution to serve multiple Blazor WebAssembly apps:

* Use an existing hosted Blazor solution or create a new solution from the Blazor Hosted project template.

* In the client app's project file, add a `<StaticWebAssetBasePath>` property to the `<PropertyGroup>` with a value of `FirstApp` to set the base path for the project's static assets:

  ```xml
  <PropertyGroup>
    ...
    <StaticWebAssetBasePath>FirstApp</StaticWebAssetBasePath>
  </PropertyGroup>
  ```

* Add a second client app to the solution:

  * Add a folder named `SecondClient` to the solution's folder.
  * Create a Blazor WebAssembly app named `SecondBlazorApp.Client` in the `SecondClient` folder from the Blazor WebAssembly project template.
  * In the app's project file:

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

* In the server app's project file, create a project reference for the added client app:

  ```xml
  <ItemGroup>
    ...
    <ProjectReference Include="..\SecondClient\SecondBlazorApp.Client.csproj" />
  </ItemGroup>
  ```

* In the server app's `Properties/launchSettings.json` file, configure the `applicationUrl` of the Kestrel profile (`{SOLUTION NAME}.Server`) to access the client apps at ports 5001 and 5002:

  ```json
  "applicationUrl": "https://localhost:5001;https://localhost:5002",
  ```

* In the server app's `Startup.Configure` method (`Startup.cs`), remove the following lines, which appear after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>:

  ```csharp
  app.UseBlazorFrameworkFiles();
  app.UseStaticFiles();

  app.UseRouting();

  app.UseEndpoints(endpoints =>
  {
      endpoints.MapRazorPages();
      endpoints.MapControllers();
      endpoints.MapFallbackToFile("index.html");
  });
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

* In the server app's weather forecast controller (`Controllers/WeatherForecastController.cs`), replace the existing route (`[Route("[controller]")]`) to `WeatherForecastController` with the following routes:

  ```csharp
  [Route("FirstApp/[controller]")]
  [Route("SecondApp/[controller]")]
  ```

  The middleware added to the server app's `Startup.Configure` method earlier modifies incoming requests to `/WeatherForecast` to either `/FirstApp/WeatherForecast` or `/SecondApp/WeatherForecast` depending on the port (5001/5002) or domain (`firstapp.com`/`secondapp.com`). The preceding controller routes are required in order to return weather data from the server app to the client apps.

### Static assets and class libraries

Use the following approaches for static assets:

* When the asset is in the client app's `wwwroot` folder, provide their paths normally:

  ```razor
  <img alt="..." src="/{ASSET FILE NAME}" />
  ```

* When the asset is in the `wwwroot` folder of a [Razor Class Library (RCL)](xref:blazor/components/class-libraries), reference the static asset in the client app per the guidance in the [RCL article](xref:razor-pages/ui-class#consume-content-from-a-referenced-rcl):

  ```razor
  <img alt="..." src="_content/{LIBRARY NAME}/{ASSET FILE NAME}" />
  ```

<!-- HOLD for reactivation at 5.x

::: moniker range=">= aspnetcore-5.0"

Components provided to a client app by a class library are referenced normally. If any components require stylesheets or JavaScript files, use either of the following approaches to obtain the static assets:

* The client app's `wwwroot/index.html` file can link (`<link>`) to the static assets.
* The component can use the framework's [`Link` component](xref:blazor/fundamentals/additional-scenarios#influence-html-head-tag-elements) to obtain the static assets.

The preceding approaches are demonstrated in the following examples.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

-->

Components provided to a client app by a class library are referenced normally. If any components require stylesheets or JavaScript files, the client app's `wwwroot/index.html` file must include the correct static asset links. These approaches are demonstrated in the following examples.

<!-- HOLD for reactivation at 5.x

::: moniker-end

-->

Add the following `Jeep` component to one of the client apps. The `Jeep` component uses:

* An image from the client app's `wwwroot` folder (`jeep-cj.png`).
* An image from an [added Razor component library](xref:blazor/components/class-libraries) (`JeepImage`) `wwwroot` folder (`jeep-yj.png`).
* The example component (`Component1`) is created automatically by the RCL project template when the `JeepImage` library is added to the solution.

```razor
@page "/Jeep"

<h1>1979 Jeep CJ-5&trade;</h1>

<p>
    <img alt="1979 Jeep CJ-5&trade;" src="/jeep-cj.png" />
</p>

<h1>1991 Jeep YJ&trade;</h1>

<p>
    <img alt="1991 Jeep YJ&trade;" src="_content/JeepImage/jeep-yj.png" />
</p>

<p>
    <em>Jeep CJ-5</em> and <em>Jeep YJ</em> are a trademarks of 
    <a href="https://www.fcagroup.com">Fiat Chrysler Automobiles</a>.
</p>

<JeepImage.Component1 />
```

> [!WARNING]
> Do **not** publish images of vehicles publicly unless you own the images. Otherwise, you risk copyright infringement.

<!-- HOLD for reactivation at 5.x

::: moniker range=">= aspnetcore-5.0"

The library's `jeep-yj.png` image can also be added to the library's `Component1` component (`Component1.razor`). To provide the `my-component` CSS class to the client app's page, link to the library's stylesheet using the framework's [`Link` component](xref:blazor/fundamentals/additional-scenarios#influence-html-head-tag-elements):

```razor
<div class="my-component">
    <Link href="_content/JeepImage/styles.css" rel="stylesheet" />

    <h1>JeepImage.Component1</h1>

    <p>
        This Blazor component is defined in the <strong>JeepImage</strong> package.
    </p>

    <p>
        <img alt="1991 Jeep YJ&trade;" src="_content/JeepImage/jeep-yj.png" />
    </p>
</div>
```

An alternative to using the [`Link` component](xref:blazor/fundamentals/additional-scenarios#influence-html-head-tag-elements) is to load the stylesheet from the client app's `wwwroot/index.html` file. This approach makes the stylesheet available to all of the components in the client app:

```html
<head>
    ...
    <link href="_content/JeepImage/styles.css" rel="stylesheet" />
</head>
```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

-->

The library's `jeep-yj.png` image can also be added to the library's `Component1` component (`Component1.razor`):

```razor
<div class="my-component">
    <h1>JeepImage.Component1</h1>

    <p>
        This Blazor component is defined in the <strong>JeepImage</strong> package.
    </p>

    <p>
        <img alt="1991 Jeep YJ&trade;" src="_content/JeepImage/jeep-yj.png" />
    </p>
</div>
```

The client app's `wwwroot/index.html` file requests the library's stylesheet with the following added `<link>` tag:

```html
<head>
    ...
    <link href="_content/JeepImage/styles.css" rel="stylesheet" />
</head>
```

<!-- HOLD for reactivation at 5.x

::: moniker-end

-->

Add navigation to the `Jeep` component in the client app's `NavMenu` component (`Shared/NavMenu.razor`):

```razor
<li class="nav-item px-3">
    <NavLink class="nav-link" href="Jeep">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Jeep
    </NavLink>
</li>
```

For more information on RCLs, see:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

## Standalone deployment

A *standalone deployment* serves the Blazor WebAssembly app as a set of static files that are requested directly by clients. Any static file server is able to serve the Blazor app.

Standalone deployment assets are published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder.

### Azure App Service

Blazor WebAssembly apps can be deployed to Azure App Services on Windows, which hosts the app on [IIS](#iis).

Deploying a standalone Blazor WebAssembly app to Azure App Service for Linux isn't currently supported. A Linux server image to host the app isn't available at this time. Work is in progress to enable this scenario.

### IIS

IIS is a capable static file server for Blazor apps. To configure IIS to host Blazor, see [Build a Static Website on IIS](/iis/manage/creating-websites/scenario-build-a-static-website-on-iis).

Published assets are created in the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Host the contents of the `publish` folder on the web server or hosting service.

#### web.config

When a Blazor project is published, a `web.config` file is created with the following IIS configuration:

* MIME types are set for the following file extensions:
  * `.dll`: `application/octet-stream`
  * `.json`: `application/json`
  * `.wasm`: `application/wasm`
  * `.woff`: `application/font-woff`
  * `.woff2`: `application/font-woff`
* HTTP compression is enabled for the following MIME types:
  * `application/octet-stream`
  * `application/wasm`
* URL Rewrite Module rules are established:
  * Serve the sub-directory where the app's static assets reside (`wwwroot/{PATH REQUESTED}`).
  * Create SPA fallback routing so that requests for non-file assets are redirected to the app's default document in its static assets folder (`wwwroot/index.html`).
  
#### Use a custom web.config

To use a custom `web.config` file, place the custom `web.config` file at the root of the project folder. Configure the project to publish IIS-specific assets using `PublishIISAssets` in the app's project file and publish the project:

```xml
<PropertyGroup>
  <PublishIISAssets>true</PublishIISAssets>
</PropertyGroup>
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

  Remove the handler in the Blazor app's published `web.config` file by adding a `<handlers>` section to the file:

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

Removing the handler or disabling inheritance is performed in addition to [configuring the app's base path](xref:blazor/host-and-deploy/index#app-base-path). Set the app base path in the app's `index.html` file to the IIS alias used when configuring the sub-app in IIS.

#### Brotli and Gzip compression

IIS can be configured via `web.config` to serve Brotli or Gzip compressed Blazor assets. For an example configuration, see [`web.config`](https://github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/blazor/host-and-deploy/webassembly/_samples/web.config?raw=true).

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

### Nginx in Docker

To host Blazor in Docker using Nginx, setup the Dockerfile to use the Alpine-based Nginx image. Update the Dockerfile to copy the `nginx.config` file into the container.

Add one line to the Dockerfile, as shown in the following example:

```dockerfile
FROM nginx:alpine
COPY ./bin/Release/netstandard2.0/publish /usr/share/nginx/html/
COPY nginx.conf /etc/nginx/nginx.conf
```

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

::: moniker range=">= aspnetcore-5.0"

## Configure the Trimmer

Blazor performs Intermediate Language (IL) trimming on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-trimmer>.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

## Configure the Linker

Blazor performs Intermediate Language (IL) linking on each Release build to remove unnecessary IL from the output assemblies. For more information, see <xref:blazor/host-and-deploy/configure-linker>.

::: moniker-end

## Custom boot resource loading

A Blazor WebAssembly app can be initialized with the `loadBootResource` function to override the built-in boot resource loading mechanism. Use `loadBootResource` for the following scenarios:

* Allow users to load static resources, such as timezone data or `dotnet.wasm` from a CDN.
* Load compressed assemblies using an HTTP request and decompress them on the client for hosts that don't support fetching compressed contents from the server.
* Alias resources to a different name by redirecting each `fetch` request to a new name.

`loadBootResource` parameters appear in the following table.

| Parameter    | Description |
| ------------ | ----------- |
| `type`       | The type of the resource. Permissable types: `assembly`, `pdb`, `dotnetjs`, `dotnetwasm`, `timezonedata` |
| `name`       | The name of the resource. |
| `defaultUri` | The relative or absolute URI of the resource. |
| `integrity`  | The integrity string representing the expected content in the response. |

`loadBootResource` returns any of the following to override the loading process:

* URI string. In the following example (`wwwroot/index.html`), the following files are served from a CDN at `https://my-awesome-cdn.com/`:

  * `dotnet.*.js`
  * `dotnet.wasm`
  * Timezone data

  ```html
  ...

  <script src="_framework/blazor.webassembly.js" autostart="false"></script>
  <script>
    Blazor.start({
      loadBootResource: function (type, name, defaultUri, integrity) {
        console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`);
        switch (type) {
          case 'dotnetjs':
          case 'dotnetwasm':
          case 'timezonedata':
            return `https://my-awesome-cdn.com/blazorwebassembly/3.2.0/${name}`;
        }
      }
    });
  </script>
  ```

* `Promise<Response>`. Pass the `integrity` parameter in a header to retain the default integrity-checking behavior.

  The following example (`wwwroot/index.html`) adds a custom HTTP header to the outbound requests and passes the `integrity` parameter through to the `fetch` call:
  
  ```html
  <script src="_framework/blazor.webassembly.js" autostart="false"></script>
  <script>
    Blazor.start({
      loadBootResource: function (type, name, defaultUri, integrity) {
        return fetch(defaultUri, { 
          cache: 'no-cache',
          integrity: integrity,
          headers: { 'MyCustomHeader': 'My custom value' }
        });
      }
    });
  </script>
  ```

* `null`/`undefined`, which results in the default loading behavior.

External sources must return the required CORS headers for browsers to allow the cross-origin resource loading. CDNs usually provide the required headers by default.

You only need to specify types for custom behaviors. Types not specified to `loadBootResource` are loaded by the framework per their default loading behaviors.

## Change the filename extension of DLL files

In case you have a need to change the filename extensions of the app's published `.dll` files, follow the guidance in this section.

After publishing the app, use a shell script or DevOps build pipeline to rename `.dll` files to use a different file extension. Target the `.dll` files in the `wwwroot` directory of the app's published output (for example, `{CONTENT ROOT}/bin/Release/netstandard2.1/publish/wwwroot`).

In the following examples, `.dll` files are renamed to use the `.bin` file extension.

On Windows:

```powershell
dir .\_framework\_bin | rename-item -NewName { $_.name -replace ".dll\b",".bin" }
((Get-Content .\_framework\blazor.boot.json -Raw) -replace '.dll"','.bin"') | Set-Content .\_framework\blazor.boot.json
```

If service worker assets are also in use, add the following command:

```powershell
((Get-Content .\service-worker-assets.js -Raw) -replace '.dll"','.bin"') | Set-Content .\service-worker-assets.js
```

On Linux or macOS:

```console
for f in _framework/_bin/*; do mv "$f" "`echo $f | sed -e 's/\.dll\b/.bin/g'`"; done
sed -i 's/\.dll"/.bin"/g' _framework/blazor.boot.json
```

If service worker assets are also in use, add the following command:

```console
sed -i 's/\.dll"/.bin"/g' service-worker-assets.js
```
   
To use a different file extension than `.bin`, replace `.bin` in the preceding commands.

To address the compressed `blazor.boot.json.gz` and `blazor.boot.json.br` files, adopt either of the following approaches:

* Remove the compressed `blazor.boot.json.gz` and `blazor.boot.json.br` files. Compression is disabled with this approach.
* Recompress the updated `blazor.boot.json` file.

The preceding guidance also applies when service worker assets are in use. Remove or recompress `wwwroot/service-worker-assets.js.br` and `wwwroot/service-worker-assets.js.gz`. Otherwise, file integrity checks fail in the browser.

The following Windows example uses a PowerShell script placed at the root of the project.

`ChangeDLLExtensions.ps1:`:

```powershell
param([string]$filepath,[string]$tfm)
dir $filepath\bin\Release\$tfm\wwwroot\_framework\_bin | rename-item -NewName { $_.name -replace ".dll\b",".bin" }
((Get-Content $filepath\bin\Release\$tfm\wwwroot\_framework\blazor.boot.json -Raw) -replace '.dll"','.bin"') | Set-Content $filepath\bin\Release\$tfm\wwwroot\_framework\blazor.boot.json
Remove-Item $filepath\bin\Release\$tfm\wwwroot\_framework\blazor.boot.json.gz
```

If service worker assets are also in use, add the following command:

```powershell
((Get-Content $filepath\bin\Release\$tfm\wwwroot\service-worker-assets.js -Raw) -replace '.dll"','.bin"') | Set-Content $filepath\bin\Release\$tfm\wwwroot\service-worker-assets.js
```

In the project file, the script is run after publishing the app:

```xml
<Target Name="ChangeDLLFileExtensions" AfterTargets="Publish" Condition="'$(Configuration)'=='Release'">
  <Exec Command="powershell.exe -command &quot;&amp; { .\ChangeDLLExtensions.ps1 '$(SolutionDir)' '$(TargetFramework)'}&quot;" />
</Target>
```

> [!NOTE]
> When renaming and lazy loading the same assemblies, see the guidance in <xref:blazor/webassembly-lazy-load-assemblies#onnavigateasync-events-and-renamed-assembly-files>.

## Resolve integrity check failures

When Blazor WebAssembly downloads an app's startup files, it instructs the browser to perform integrity checks on the responses. It uses information in the `blazor.boot.json` file to specify the expected SHA-256 hash values for `.dll`, `.wasm`, and other files. This is beneficial for the following reasons:

* It ensures you don't risk loading an inconsistent set of files, for example if a new deployment is applied to your web server while the user is in the process of downloading the application files. Inconsistent files could lead to undefined behavior.
* It ensures the user's browser never caches inconsistent or invalid responses, which could prevent them from starting the app even if they manually refresh the page.
* It makes it safe to cache the responses and not even check for server-side changes until the expected SHA-256 hashes themselves change, so subsequent page loads involve fewer requests and complete much faster.

If your web server returns responses that don't match the expected SHA-256 hashes, you will see an error similar to the following appear in the browser's developer console:

```
Failed to find a valid digest in the 'integrity' attribute for resource 'https://myapp.example.com/_framework/MyBlazorApp.dll' with computed SHA-256 integrity 'IIa70iwvmEg5WiDV17OpQ5eCztNYqL186J56852RpJY='. The resource has been blocked.
```

In most cases, this is *not* a problem with integrity checking itself. Instead, it means there is some other problem, and the integrity check is warning you about that other problem.

### Diagnosing integrity problems

When an app is built, the generated `blazor.boot.json` manifest describes the SHA-256 hashes of your boot resources (for example, `.dll`, `.wasm`, and other files) at the time that the build output is produced. The integrity check passes as long as the SHA-256 hashes in `blazor.boot.json` match the files delivered to the browser.

Common reasons why this fails are:

 * The web server's response is an error (for example, a *404 - Not Found* or a *500 - Internal Server Error*) instead of the file the browser requested. This is reported by the browser as an integrity check failure and not as a response failure.
 * Something has changed the contents of the files between the build and delivery of the files to the browser. This might happen:
   * If you or build tools manually modify the build output.
   * If some aspect of the deployment process modified the files. For example if you use a Git-based deployment mechanism, bear in mind that Git transparently converts Windows-style line endings to Unix-style line endings if you commit files on Windows and check them out on Linux. Changing file line endings change the SHA-256 hashes. To avoid this problem, consider [using `.gitattributes` to treat build artifacts as `binary` files](https://git-scm.com/book/en/v2/Customizing-Git-Git-Attributes).
   * The web server modifies the file contents as part of serving them. For example, some content distribution networks (CDNs) automatically attempt to [minify](xref:client-side/bundling-and-minification#minification) HTML, thereby modifying it. You may need to disable such features.

To diagnose which of these applies in your case:

 1. Note which file is triggering the error by reading the error message.
 1. Open your browser's developer tools and look in the *Network* tab. If necessary, reload the page to see the list of requests and responses. Find the file that is triggering the error in that list.
 1. Check the HTTP status code in the response. If the server returns anything other than *200 - OK* (or another 2xx status code), then you have a server-side problem to diagnose. For example, status code 403 means there's an authorization problem, whereas status code 500 means the server is failing in an unspecified manner. Consult server-side logs to diagnose and fix the app.
 1. If the status code is *200 - OK* for the resource, look at the response content in browser's developer tools and check that the content matchs up with the data expected. For example, a common problem is to misconfigure routing so that requests return your `index.html` data even for other files. Make sure that responses to `.wasm` requests are WebAssembly binaries and that responses to `.dll` requests are .NET assembly binaries. If not, you have a server-side routing problem to diagnose.

If you confirm that the server is returning plausibly correct data, there must be something else modifying the contents in between build and delivery of the file. To investigate this:

 * Examine the build toolchain and deployment mechanism in case they're modifying files after the files are built. An example of this is when Git transforms file line endings, as described earlier.
 * Examine the web server or CDN configuration in case they're set up to modify responses dynamically (for example, trying to minify HTML). It's fine for the web server to implement HTTP compression (for example, returning `content-encoding: br` or `content-encoding: gzip`), since this doesn't affect the result after decompression. However, it's *not* fine for the web server to modify the uncompressed data.

### Disable integrity checking for non-PWA apps

In most cases, don't disable integrity checking. Disabling integrity checking doesn't solve the underlying problem that has caused the unexpected responses and results in losing the benefits listed earlier.

There may be cases where the web server can't be relied upon to return consistent responses, and you have no choice but to disable integrity checks. To disable integrity checks, add the following to a property group in the Blazor WebAssembly project's `.csproj` file:

```xml
<BlazorCacheBootResources>false</BlazorCacheBootResources>
```

`BlazorCacheBootResources` also disables Blazor's default behavior of caching the `.dll`, `.wasm`, and other files based on their SHA-256 hashes because the property indicates that the SHA-256 hashes can't be relied upon for correctness. Even with this setting, the browser's normal HTTP cache may still cache those files, but whether or not this happens depends on your web server configuration and the `cache-control` headers that it serves.

> [!NOTE]
> The `BlazorCacheBootResources` property doesn't disable integrity checks for [Progressive Web Applications (PWAs)](xref:blazor/progressive-web-app). For guidance pertaining to PWAs, see the [Disable integrity checking for PWAs](#disable-integrity-checking-for-pwas) section.

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
