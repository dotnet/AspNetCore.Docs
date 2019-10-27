---
title: Host and deploy ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to host and deploy a Blazor app using ASP.NET Core, Content Delivery Networks (CDN), file servers, and GitHub Pages.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/15/2019
uid: host-and-deploy/blazor/webassembly
---
# Host and deploy ASP.NET Core Blazor WebAssembly

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), and [Daniel Roth](https://github.com/danroth27)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

With the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser.
* The app is executed directly on the browser UI thread.

The following deployment strategies are supported:

* The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
* The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section, which includes information on hosting a Blazor WebAssembly app as an IIS sub-app.

## Rewrite URLs for correct routing

Routing requests for page components in a Blazor WebAssembly app isn't as straightforward as routing requests in a Blazor Server, hosted app. Consider a Blazor WebAssembly app with two components:

* *Main.razor* &ndash; Loads at the root of the app and contains a link to the `About` component (`href="About"`).
* *About.razor* &ndash; `About` component.

When the app's default document is requested using the browser's address bar (for example, `https://www.contoso.com/`):

1. The browser makes a request.
1. The default page is returned, which is usually *index.html*.
1. *index.html* bootstraps the app.
1. Blazor's router loads, and the Razor `Main` component is rendered.

In the Main page, selecting the link to the `About` component works on the client because the Blazor router stops the browser from making a request on the Internet to `www.contoso.com` for `About` and serves the rendered `About` component itself. All of the requests for internal endpoints *within the Blazor WebAssembly app* work the same way: Requests don't trigger browser-based requests to server-hosted resources on the Internet. The router handles the requests internally.

If a request is made using the browser's address bar for `www.contoso.com/About`, the request fails. No such resource exists on the app's Internet host, so a *404 - Not Found* response is returned.

Because browsers make requests to Internet-based hosts for client-side pages, web servers and hosting services must rewrite all requests for resources not physically on the server to the *index.html* page. When *index.html* is returned, the app's Blazor router takes over and responds with the correct resource.

When deploying to an IIS server, you can use the URL Rewrite Module with the app's published *web.config* file. For more information, see the [IIS](#iis) section.

## Hosted deployment with ASP.NET Core

A *hosted deployment* serves the Blazor WebAssembly app to browsers from an [ASP.NET Core app](xref:index) that runs on a web server.

The Blazor app is included with the ASP.NET Core app in the published output so that the two apps are deployed together. A web server that is capable of hosting an ASP.NET Core app is required. For a hosted deployment, Visual Studio includes the **Blazor WebAssembly App** project template (`blazorwasm` template when using the [dotnet new](/dotnet/core/tools/dotnet-new) command) with the **Hosted** option selected.

For more information on ASP.NET Core app hosting and deployment, see <xref:host-and-deploy/index>.

For information on deploying to Azure App Service, see <xref:tutorials/publish-to-azure-webapp-using-vs>.

## Standalone deployment

A *standalone deployment* serves the Blazor WebAssembly app as a set of static files that are requested directly by clients. Any static file server is able to serve the Blazor app.

Standalone deployment assets are published to the *bin/Release/{TARGET FRAMEWORK}/publish/{ASSEMBLY NAME}/dist* folder.

### IIS

IIS is a capable static file server for Blazor apps. To configure IIS to host Blazor, see [Build a Static Website on IIS](/iis/manage/creating-websites/scenario-build-a-static-website-on-iis).

Published assets are created in the */bin/Release/{TARGET FRAMEWORK}/publish* folder. Host the contents of the *publish* folder on the web server or hosting service.

#### web.config

When a Blazor project is published, a *web.config* file is created with the following IIS configuration:

* MIME types are set for the following file extensions:
  * *.dll* &ndash; `application/octet-stream`
  * *.json* &ndash; `application/json`
  * *.wasm* &ndash; `application/wasm`
  * *.woff* &ndash; `application/font-woff`
  * *.woff2* &ndash; `application/font-woff`
* HTTP compression is enabled for the following MIME types:
  * `application/octet-stream`
  * `application/wasm`
* URL Rewrite Module rules are established:
  * Serve the sub-directory where the app's static assets reside (*{ASSEMBLY NAME}/dist/{PATH REQUESTED}*).
  * Create SPA fallback routing so that requests for non-file assets are redirected to the app's default document in its static assets folder (*{ASSEMBLY NAME}/dist/index.html*).

#### Install the URL Rewrite Module

The [URL Rewrite Module](https://www.iis.net/downloads/microsoft/url-rewrite) is required to rewrite URLs. The module isn't installed by default, and it isn't available for install as a Web Server (IIS) role service feature. The module must be downloaded from the IIS website. Use the Web Platform Installer to install the module:

1. Locally, navigate to the [URL Rewrite Module downloads page](https://www.iis.net/downloads/microsoft/url-rewrite#additionalDownloads). For the English version, select **WebPI** to download the WebPI installer. For other languages, select the appropriate architecture for the server (x86/x64) to download the installer.
1. Copy the installer to the server. Run the installer. Select the **Install** button and accept the license terms. A server restart isn't required after the install completes.

#### Configure the website

Set the website's **Physical path** to the app's folder. The folder contains:

* The *web.config* file that IIS uses to configure the website, including the required redirect rules and file content types.
* The app's static asset folder.

#### Host as an IIS sub-app

If a standalone app is hosted as an IIS sub-app, perform either of the following:

* Disable the inherited ASP.NET Core Module handler.

  Remove the handler in the Blazor app's published *web.config* file by adding a `<handlers>` section to the file:

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

Removing the handler or disabling inheritance is performed in addition to [configuring the app's base path](xref:host-and-deploy/blazor/index#app-base-path). Set the app base path in the app's *index.html* file to the IIS alias used when configuring the sub-app in IIS.

#### Troubleshooting

If a *500 - Internal Server Error* is received and IIS Manager throws errors when attempting to access the website's configuration, confirm that the URL Rewrite Module is installed. When the module isn't installed, the *web.config* file can't be parsed by IIS. This prevents the IIS Manager from loading the website's configuration and the website from serving Blazor's static files.

For more information on troubleshooting deployments to IIS, see <xref:test/troubleshoot-azure-iis>.

### Azure Storage

[Azure Storage](/azure/storage/) static file hosting allows serverless Blazor app hosting. Custom domain names, the Azure Content Delivery Network (CDN), and HTTPS are supported.

When the blob service is enabled for static website hosting on a storage account:

* Set the **Index document name** to `index.html`.
* Set the **Error document path** to `index.html`. Razor components and other non-file endpoints don't reside at physical paths in the static content stored by the blob service. When a request for one of these resources is received that the Blazor router should handle, the *404 - Not Found* error generated by the blob service routes the request to the **Error document path**. The *index.html* blob is returned, and the Blazor router loads and processes the path.

For more information, see [Static website hosting in Azure Storage](/azure/storage/blobs/storage-blob-static-website).

### Nginx

The following *nginx.conf* file is simplified to show how to configure Nginx to send the *index.html* file whenever it can't find a corresponding file on disk.

```
events { }
http {
    server {
        listen 80;

        location / {
            root /usr/share/nginx/html;
            try_files $uri $uri/ /index.html =404;
        }
    }
}
```

For more information on production Nginx web server configuration, see [Creating NGINX Plus and NGINX Configuration Files](https://docs.nginx.com/nginx/admin-guide/basic-functionality/managing-configuration-files/).

### Nginx in Docker

To host Blazor in Docker using Nginx, setup the Dockerfile to use the Alpine-based Nginx image. Update the Dockerfile to copy the *nginx.config* file into the container.

Add one line to the Dockerfile, as shown in the following example:

```Dockerfile
FROM nginx:alpine
COPY ./bin/Release/netstandard2.0/publish /usr/share/nginx/html/
COPY nginx.conf /etc/nginx/nginx.conf
```

### Apache

To deploy a Blazor WebAssembly app to CentOS 7 or later:

1. Create the Apache configuration file. The following example is a simplified configuration file (*blazorapp.config*):

   ```
   <VirtualHost *:80>
       ServerName www.example.com
       ServerAlias *.example.com

       DocumentRoot "/var/www/blazorapp"
       ErrorDocument 404 /index.html

       AddType aplication/wasm .wasm
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

For more information, see [mod_mime](https://httpd.apache.org/docs/2.4/mod/mod_mime.html) and [mod_deflate](https://httpd.apache.org/docs/current/mod/mod_deflate.html).

### GitHub Pages

To handle URL rewrites, add a *404.html* file with a script that handles redirecting the request to the *index.html* page. For an example implementation provided by the community, see [Single Page Apps for GitHub Pages](https://spa-github-pages.rafrex.com/) ([rafrex/spa-github-pages on GitHub](https://github.com/rafrex/spa-github-pages#readme)). An example using the community approach can be seen at [blazor-demo/blazor-demo.github.io on GitHub](https://github.com/blazor-demo/blazor-demo.github.io) ([live site](https://blazor-demo.github.io/)).

When using a project site instead of an organization site, add or update the `<base>` tag in *index.html*. Set the `href` attribute value to the GitHub repository name with a trailing slash (for example, `my-repository/`.

## Host configuration values

[Blazor WebAssembly apps](xref:blazor/hosting-models#blazor-webassembly) can accept the following host configuration values as command-line arguments at runtime in the development environment.

### Content root

The `--contentroot` argument sets the absolute path to the directory that contains the app's content files ([content root](xref:fundamentals/index#content-root)). In the following examples, `/content-root-path` is the app's content root path.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet run --contentroot=/content-root-path
  ```

* Add an entry to the app's *launchSettings.json* file in the **IIS Express** profile. This setting is used when the app is run with the Visual Studio Debugger and from a command prompt with `dotnet run`.

  ```json
  "commandLineArgs": "--contentroot=/content-root-path"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the *launchSettings.json* file.

  ```console
  --contentroot=/content-root-path
  ```

### Path base

The `--pathbase` argument sets the app base path for an app run locally with a non-root relative URL path (the `<base>` tag `href` is set to a path other than `/` for staging and production). In the following examples, `/relative-URL-path` is the app's path base. For more information, see [App base path](xref:host-and-deploy/blazor/index#app-base-path).

> [!IMPORTANT]
> Unlike the path provided to `href` of the `<base>` tag, don't include a trailing slash (`/`) when passing the `--pathbase` argument value. If the app base path is provided in the `<base>` tag as `<base href="/CoolApp/">` (includes a trailing slash), pass the command-line argument value as `--pathbase=/CoolApp` (no trailing slash).

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet run --pathbase=/relative-URL-path
  ```

* Add an entry to the app's *launchSettings.json* file in the **IIS Express** profile. This setting is used when running the app with the Visual Studio Debugger and from a command prompt with `dotnet run`.

  ```json
  "commandLineArgs": "--pathbase=/relative-URL-path"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the *launchSettings.json* file.

  ```console
  --pathbase=/relative-URL-path
  ```

### URLs

The `--urls` argument sets the IP addresses or host addresses with ports and protocols to listen on for requests.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```dotnetcli
  dotnet run --urls=http://127.0.0.1:0
  ```

* Add an entry to the app's *launchSettings.json* file in the **IIS Express** profile. This setting is used when running the app with the Visual Studio Debugger and from a command prompt with `dotnet run`.

  ```json
  "commandLineArgs": "--urls=http://127.0.0.1:0"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the *launchSettings.json* file.

  ```console
  --urls=http://127.0.0.1:0
  ```

## Configure the Linker

Blazor performs Intermediate Language (IL) linking on each build to remove unnecessary IL from the output assemblies. Assembly linking can be controlled on build. For more information, see <xref:host-and-deploy/blazor/configure-linker>.
