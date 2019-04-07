---
title: Host and deploy Blazor
author: guardrex
description: Learn how to host and deploy a Blazor app using ASP.NET Core, Content Delivery Networks (CDN), file servers, and GitHub Pages.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 03/28/2019
uid: host-and-deploy/razor-components-blazor/blazor
---
# Host and deploy Blazor

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), and [Daniel Roth](https://github.com/danroth27)

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

## Host configuration values

Blazor apps that use the [client-side hosting model](xref:razor-components/hosting-models#client-side-hosting-model) can accept the following host configuration values as command-line arguments at runtime in the development environment.

### Content Root

The `--contentroot` argument sets the absolute path to the directory that contains the app's content files. In the following examples, `/content-root-path` is the app's content root path.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```console
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

The `--pathbase` argument sets the app base path for an app run locally with a non-root virtual path (the `<base>` tag `href` is set to a path other than `/` for staging and production). In the following examples, `/virtual-path` is the app's path base. For more information, see the [App base path](#app-base-path) section.

> [!IMPORTANT]
> Unlike the path provided to `href` of the `<base>` tag, don't include a trailing slash (`/`) when passing the `--pathbase` argument value. If the app base path is provided in the `<base>` tag as `<base href="/CoolApp/" />` (includes a trailing slash), pass the command-line argument value as `--pathbase=/CoolApp` (no trailing slash).

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```console
  dotnet run --pathbase=/virtual-path
  ```

* Add an entry to the app's *launchSettings.json* file in the **IIS Express** profile. This setting is used when running the app with the Visual Studio Debugger and from a command prompt with `dotnet run`.

  ```json
  "commandLineArgs": "--pathbase=/virtual-path"
  ```

* In Visual Studio, specify the argument in **Properties** > **Debug** > **Application arguments**. Setting the argument in the Visual Studio property page adds the argument to the *launchSettings.json* file.

  ```console
  --pathbase=/virtual-path
  ```

### URLs

The `--urls` argument sets the IP addresses or host addresses with ports and protocols to listen on for requests.

* Pass the argument when running the app locally at a command prompt. From the app's directory, execute:

  ```console
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

## Deployment

With the [client-side hosting model](xref:razor-components/hosting-models#client-side-hosting-model):

* The Blazor app, its dependencies, and the .NET runtime are downloaded to the browser.
* The app is executed directly on the browser UI thread. Either of the following strategies is supported:
  * The Blazor app is served by an ASP.NET Core app. This strategy is covered in the [Hosted deployment with ASP.NET Core](#hosted-deployment-with-aspnet-core) section.
  * The Blazor app is placed on a static hosting web server or service, where .NET isn't used to serve the Blazor app. This strategy is covered in the [Standalone deployment](#standalone-deployment) section.

## Configure the Linker

Blazor performs Intermediate Language (IL) linking on each build to remove unnecessary IL from the output assemblies. Assembly linking can be controlled on build. For more information, see <xref:host-and-deploy/razor-components-blazor/configure-linker>.

## Rewrite URLs for correct routing

Routing requests for page components in a client-side app isn't as simple as routing requests to a server-side, hosted app. Consider a client-side app with two pages:

* **_Main.cshtml_** &ndash; Loads at the root of the app and contains a link to the About page (`href="About"`).
* **_About.cshtml_** &ndash; About page.

When the app's default document is requested using the browser's address bar (for example, `https://www.contoso.com/`):

1. The browser makes a request.
1. The default page is returned, which is usually *index.html*.
1. *index.html* bootstraps the app.
1. Blazor's router loads, and the Razor Main page (*Main.cshtml*) is displayed.

On the Main page, selecting the link to the About page loads the About page. Selecting the link to the About page works on the client because the Blazor router stops the browser from making a request on the Internet to `www.contoso.com` for `About` and serves the About page itself. All of the requests for internal pages *within the client-side app* work the same way: Requests don't trigger browser-based requests to server-hosted resources on the Internet. The router handles the requests internally.

If a request is made using the browser's address bar for `www.contoso.com/About`, the request fails. No such resource exists on the app's Internet host, so a *404 - Not Found* response is returned.

Because browsers make requests to Internet-based hosts for client-side pages, web servers and hosting services must rewrite all requests for resources not physically on the server to the *index.html* page. When *index.html* is returned, the app's client-side router takes over and responds with the correct resource.

## App base path

The *app base path* is the virtual app root path on the server. For example, an app that resides on the Contoso server in a virtual folder at `/CoolApp/` is reached at `https://www.contoso.com/CoolApp` and has a virtual base path of `/CoolApp/`. By setting the app base path to `CoolApp/`, the app is made aware of where it virtually resides on the server. The app can use the app base path to construct URLs relative to the app root from a component that isn't in the root directory. This allows components that exist at different levels of the directory structure to build links to other resources at locations throughout the app. The app base path is also used to intercept hyperlink clicks where the `href` target of the link is within the app base path URI space&mdash;the Blazor router handles the internal navigation.

In many hosting scenarios, the server's virtual path to the app is the root of the app. In these cases, the app base path is a forward slash (`<base href="/" />`), which is the default configuration for an app. In other hosting scenarios, such as GitHub Pages and IIS virtual directories or sub-applications, the app base path must be set to the server's virtual path to the app. To set the app's base path, add or update the `<base>` tag in *index.html* found within the `<head>` tag elements. Set the `href` attribute value to `virtual-path/` (the trailing slash is required), where `virtual-path/` is the full virtual app root path on the server for the app. In the preceding example, the virtual path is set to `CoolApp/`: `<base href="CoolApp/" />`.

For an app with a non-root virtual path configured (for example, `<base href="CoolApp/" />`), the app fails to find its resources *when run locally*. To overcome this problem during local development and testing, you can supply a *path base* argument that matches the `href` value of the `<base>` tag at runtime.

To pass the path base argument with the root path (`/`) when running the app locally, execute the following command from the app's directory:

```console
dotnet run --pathbase=/CoolApp
```

The app responds locally at `http://localhost:port/CoolApp`.

For more information, see the section on the [path base host configuration value](#path-base).

If an app uses the [client-side hosting model](xref:razor-components/hosting-models#client-side-hosting-model) (based on the **Blazor** project template) and is hosted as an IIS sub-application in an ASP.NET Core app, it's important to disable the inherited ASP.NET Core Module handler or make sure the root (parent) app's `<handlers>` section in the *web.config* file isn't inherited by the sub-app.

Remove the handler in the app's published *web.config* file by adding a `<handlers>` section to the file:

```xml
<handlers>
  <remove name="aspNetCore" />
</handlers>
```

Alternatively, disable inheritance of the root (parent) app's `<system.webServer>` section using a `<location>` element with `inheritInChildApplications` set to `false`:

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

Removing the handler or disabling inheritance is performed in addition to configuring the app's base path as described in this section. Set the app base path in the app's *index.html* file to the IIS alias used when configuring the sub-app in IIS.

## Hosted deployment with ASP.NET Core

A *hosted deployment* serves the client-side Blazor app to browsers from an [ASP.NET Core app](xref:index) that runs on a server.

The Blazor app is included with the ASP.NET Core app in the published output so that the two apps are deployed together. A web server that is capable of hosting an ASP.NET Core app is required. For a hosted deployment, Visual Studio includes the **Blazor (ASP.NET Core hosted)** project template (`blazorhosted` template when using the [dotnet new](/dotnet/core/tools/dotnet-new) command).

For more information on ASP.NET Core app hosting and deployment, see <xref:host-and-deploy/index>.

For information on deploying to Azure App Service, see <xref:tutorials/publish-to-azure-webapp-using-vs>.

## Standalone deployment

A *standalone deployment* serves the client-side Blazor app as a set of static files that are requested directly by clients. A web server isn't used to serve the Blazor app.

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

#### Troubleshooting

If a *500 - Internal Server Error* is received and IIS Manager throws errors when attempting to access the website's configuration, confirm that the URL Rewrite Module is installed. When the module isn't installed, the *web.config* file can't be parsed by IIS. This prevents the IIS Manager from loading the website's configuration and the website from serving Blazor's static files.

For more information on troubleshooting deployments to IIS, see <xref:host-and-deploy/iis/troubleshoot>.

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

### GitHub Pages

To handle URL rewrites, add a *404.html* file with a script that handles redirecting the request to the *index.html* page. For an example implementation provided by the community, see [Single Page Apps for GitHub Pages](http://spa-github-pages.rafrex.com/) ([rafrex/spa-github-pages on GitHub](https://github.com/rafrex/spa-github-pages#readme)). An example using the community approach can be seen at [blazor-demo/blazor-demo.github.io on GitHub](https://github.com/blazor-demo/blazor-demo.github.io) ([live site](https://blazor-demo.github.io/)).

When using a project site instead of an organization site, add or update the `<base>` tag in *index.html*. Set the `href` attribute value to the GitHub repository name with a trailing slash (for example, `my-repository/`.
