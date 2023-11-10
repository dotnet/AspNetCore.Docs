---
title: Host and deploy ASP.NET Core Blazor
author: guardrex
description: Discover how to host and deploy Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/host-and-deploy/index
---
# Host and deploy ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy Blazor apps.

## Publish the app

Apps are published for deployment in Release configuration.

:::moniker range="< aspnetcore-8.0"

> [!NOTE]
> Publish a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) from the **:::no-loc text="Server":::** project.

:::moniker-end

# [Visual Studio](#tab/visual-studio)

1. Select the **Publish {APPLICATION}** command from the **Build** menu, where the `{APPLICATION}` placeholder the app's name.
1. Select the *publish target*. To publish locally, select **Folder**.
1. Accept the default location in the **Choose a folder** field or specify a different location. Select the **`Publish`** button.

# [.NET Core CLI](#tab/netcore-cli)

Use the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command to publish the app with a Release configuration:

```dotnetcli
dotnet publish -c Release
```

---

Publishing the app triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times.

Publish locations:

:::moniker range=">= aspnetcore-8.0"

* Blazor Web App: By default, the app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Deploy the contents of the `publish` folder to the host.
* Blazor WebAssembly: By default, the app is published into the `bin\Release\net8.0\browser-wasm\publish\` folder. To deploy the app as a static site, copy the contents of the `wwwroot` folder to the static site host.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* Blazor Server: By default, the app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Deploy the contents of the `publish` folder to the host.
* Blazor WebAssembly
  * Standalone: By default, the app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` or `bin\Release\{TARGET FRAMEWORK}\browser-wasm\publish` folder, depending on the version of the SDK used to publish the app. To deploy the app as a static site, copy the contents of the `wwwroot` folder to the static site host.
  * Hosted: The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the client app. Deploy the contents of the `publish` folder to the host.

:::moniker-end

The `{TARGET FRAMEWORK}` in the preceding paths is the target framework (for example, `net8.0`).

## IIS

To host a Blazor app in IIS, see the following resources:

* IIS hosting
  * <xref:tutorials/publish-to-iis>
  * <xref:host-and-deploy/iis/index>
* <xref:blazor/host-and-deploy/server>: Server apps running on IIS, including IIS with Azure Virtual Machines (VMs) running Windows OS and Azure App Service.
* <xref:blazor/host-and-deploy/webassembly>: Includes additional guidance for Blazor WebAssembly apps hosted on IIS, including static site hosting, custom `web.config` files, URL rewriting, sub-apps, compression, and Azure Storage static file hosting.
* IIS sub-application hosting
  * Follow the guidance in the [App base path](#app-base-path) section for the Blazor app prior to publishing the app. The examples use an app base path of `/CoolApp`.
  * Follow the sub-application configuration guidance in <xref:host-and-deploy/iis/advanced#sub-applications>. The sub-app's folder path under the root site becomes the virtual path of the sub-app. For an app base path of `/CoolApp`, the Blazor app is placed in a folder named `CoolApp` under the root site and the sub-app takes on a virtual path of `/CoolApp`.

Sharing an app pool among ASP.NET Core apps isn't supported, including for Blazor apps. Use one app pool per app when hosting with IIS, and avoid the use of IIS's [virtual directories](/iis/get-started/planning-your-iis-architecture/understanding-sites-applications-and-virtual-directories-on-iis#virtual-directories) for hosting multiple apps.

:::moniker range="< aspnetcore-8.0"

One or more Blazor WebAssembly apps hosted by an ASP.NET Core app, known as a [hosted Blazor WebAssembly solution](xref:blazor/hosting-models#blazor-webassembly), are supported for ***one*** app pool. However, we don't recommend or support assigning a single app pool to multiple hosted Blazor WebAssembly solutions or in sub-app hosting scenarios.

For more information on *solutions*, see <xref:blazor/tooling#visual-studio-solution-file-sln>.

:::moniker-end

## App base path

The *app base path* is the app's root URL path. Successful routing in Blazor apps requires framework configuration for any root URL path that isn't at the default app base path `/`.

Consider the following ASP.NET Core app and Blazor sub-app:

* The ASP.NET Core app is named `MyApp`:
  * The app physically resides at `d:/MyApp`.
  * Requests are received at `https://www.contoso.com/{MYAPP RESOURCE}`.
* A Blazor app named `CoolApp` is a sub-app of `MyApp`:
  * The sub-app physically resides at `d:/MyApp/CoolApp`.
  * Requests are received at `https://www.contoso.com/CoolApp/{COOLAPP RESOURCE}`.

Without specifying additional configuration for `CoolApp`, the sub-app in this scenario has no knowledge of where it resides on the server. For example, the app can't construct correct relative URLs to its resources without knowing that it resides at the relative URL path `/CoolApp/`. This scenario also applies in various hosting and reverse proxy scenarios when an app isn't hosted at a root URL path.

### Background

An anchor tag's destination ([`href`](https://developer.mozilla.org/docs/Web/HTML/Element/a)) can be composed with either of two endpoints:

* Absolute locations that include a scheme (defaults to the page's scheme if omitted), host, port, and path or just a forward slash (`/`) followed by the path.

  Examples: `https://example.com/a/b/c` or `/a/b/c`

* Relative locations that contain just a path and do not start with a forward slash (`/`). These are resolved relative to the current document URL or the `<base>` tag's value, if specified.

  Example: `a/b/c`
  
The presence of a trailing slash (`/`) in a configured app base path is significant to compute the base path for URLs of the app. For example, `https://example.com/a` has a base path of `https://example.com/`, while `https://example.com/a/` with a trailing slash has a base path of `https://example.com/a`.

There are three sources of links that pertain to Blazor in ASP.NET Core apps:

:::moniker range=">= aspnetcore-8.0"

* URLs in Razor components (`.razor`) are typically relative.
* URLs in scripts, such as the Blazor scripts (`blazor.*.js`), are relative to the document.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* URLs manually written in the `_Host.cshtml` file (Blazor Server), which if you are rendering inside different documents should always be absolute.
* URLs in Razor components (`.razor`) are typically relative.
* URLs in scripts, such as the Blazor scripts (`blazor.*.js`), are relative to the document.

:::moniker-end

If you're rendering a Blazor app from different documents (for example, `/Admin/B/C/` and `/Admin/D/E/`), you must take the app base path into account, or the base path is different when the app renders in each document and the resources are fetched from the wrong URLs.

There are two approaches to deal with the challenge of resolving relative links correctly:

* Map the resources dynamically using the document they were rendered on as the root.
* Set a consistent base path for the document and map the resources under that base path.

The first option is more complicated and isn't the most typical approach, as it makes navigation different for each document. Consider the following example for rendering a page `/Something/Else`:

* Rendered under `/Admin/B/C/`, the page is rendered with a path of `/Admin/B/C/Something/Else`.
* Rendered under `/Admin/D/E/`, the page is rendered ***at the same path*** of `/Admin/B/C/Something/Else`.

Under the first approach, routing offers <xref:Microsoft.AspNetCore.Routing.IDynamicEndpointMetadata> and <xref:Microsoft.AspNetCore.Routing.MatcherPolicy>, which in combination can be the basis for implementing a completely dynamic solution that determines at runtime about how requests are routed.

For the second option, which is the usual approach taken, the app sets the base path in the document and maps the server endpoints to paths under the base. The following guidance adopts this approach.

### Server-side Blazor

Map the SignalR hub of a server-side Blazor app by passing the path to <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in the `Program` file:

```csharp
app.MapBlazorHub("base/path");
```

The benefit of using <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> is that you can map patterns, such as `"{tenant}"` and not just concrete paths.

You can also map the SignalR hub when the app is in a virtual folder with a [branched middleware pipeline](xref:fundamentals/middleware/index#branch-the-middleware-pipeline). In the following example, requests to `/base/path/` are handled by Blazor's SignalR hub:

```csharp
app.Map("/base/path/", subapp => {
    subapp.UsePathBase("/base/path/");
    subapp.UseRouting();
    subapp.UseEndpoints(endpoints => endpoints.MapBlazorHub());
});
```

Configure the `<base>` tag, per the guidance in the [Configure the app base path](#configure-the-app-base-path) section.

:::moniker range="< aspnetcore-8.0"

### Hosted Blazor WebAssembly

If the app is a hosted Blazor WebAssembly app:

* In the in the **:::no-loc text="Server":::** project (`Program.cs`):
  * Adjust the path of <xref:Microsoft.AspNetCore.Builder.ComponentsWebAssemblyApplicationBuilderExtensions.UseBlazorFrameworkFiles%2A> (for example, `app.UseBlazorFrameworkFiles("/base/path");`).
  * Configure calls to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (for example, `app.UseStaticFiles("/base/path");`).
* In the **:::no-loc text="Client":::** project:
  * Configure [`<StaticWebAssetBasePath>`](xref:blazor/fundamentals/static-files#static-web-asset-base-path) in the project file to match the path for serving static web assets (for example, `<StaticWebAssetBasePath>base/path</StaticWebAssetBasePath>
`).
  * Configure the `<base>` tag, per the guidance in the [Configure the app base path](#configure-the-app-base-path) section.

For an example of hosting multiple Blazor WebAssembly apps in a hosted Blazor WebAssembly solution, see <xref:blazor/host-and-deploy/multiple-hosted-webassembly>, where approaches are explained for domain/port hosting and subpath hosting of multiple Blazor WebAssembly client apps.

:::moniker-end

### Standalone Blazor WebAssembly

In a standalone Blazor WebAssembly app, only the `<base>` tag is configured, per the guidance in the [Configure the app base path](#configure-the-app-base-path) section.

### Configure the app base path

To provide configuration for the Blazor app's base path of `https://www.contoso.com/CoolApp/`, set the app base path, which is also called the relative root path.

By configuring the app base path, a component that isn't in the root directory can construct URLs relative to the app's root path. Components at different levels of the directory structure can build links to other resources at locations throughout the app. The app base path is also used to intercept selected hyperlinks where the `href` target of the link is within the app base path URI space. The Blazor router handles the internal navigation.

:::moniker range=">= aspnetcore-8.0"

In many hosting scenarios, the relative URL path to the app is the root of the app. In these default cases, the app's relative URL base path is `/` configured as `<base href="/" />` in [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

In many hosting scenarios, the relative URL path to the app is the root of the app. In these default cases, the app's relative URL base path is the following in [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content):

* Blazor Server: `~/` configured as `<base href="~/" />`.
* Blazor WebAssembly: `/` configured as `<base href="/" />`.

:::moniker-end

> [!NOTE]
> In some hosting scenarios, such as GitHub Pages and IIS sub-apps, the app base path must be set to the server's relative URL path of the app.

* In a server-side Blazor app, use ***either*** of the following approaches:

  * Option 1: Use the `<base>` tag to set the app's base path ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)):

    ```html
    <base href="/CoolApp/">
    ```

    **The trailing slash is required.**

  * Option 2: Call <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> ***first*** in the app's request processing pipeline (`Program.cs`) immediately after the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> is built (`builder.Build()`) to configure the base path for any following middleware that interacts with the request path:

    ```csharp
    app.UsePathBase("/CoolApp");
    ```

    Calling <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> is recommended when you also wish to run the Blazor Server app locally. For example, supply the launch URL in `Properties/launchSettings.json`:
  
    ```xml
    "launchUrl": "https://localhost:{PORT}/CoolApp",
    ```

    The `{PORT}` placeholder in the preceding example is the port that matches the secure port in the `applicationUrl` configuration path. The following example shows the full launch profile for an app at port 7279:
  
    ```xml
    "BlazorSample": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7279;http://localhost:5279",
      "launchUrl": "https://localhost:7279/CoolApp",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
    }
    ```
    
    For more information on the `launchSettings.json` file, see <xref:fundamentals/environments#development-and-launchsettingsjson>. For additional information on Blazor app base paths and hosting, see [`<base href="/" />` or base-tag alternative for Blazor MVC integration (dotnet/aspnetcore #43191)](https://github.com/dotnet/aspnetcore/issues/43191#issuecomment-1212156106).

* Standalone Blazor WebAssembly (`wwwroot/index.html`):

  ```html
  <base href="/CoolApp/">
  ```

  **The trailing slash is required.**

:::moniker range="< aspnetcore-8.0"

* Hosted Blazor WebAssembly (**:::no-loc text="Client":::** project, `wwwroot/index.html`):

  ```html
  <base href="/CoolApp/">
  ```

  **The trailing slash is required.**

  In the **:::no-loc text="Server":::** project, call <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> ***first*** in the app's request processing pipeline (`Program.cs`) immediately after the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> is built (`builder.Build()`) to configure the base path for any following middleware that interacts with the request path:

  ```csharp
  app.UsePathBase("/CoolApp");
  ```

:::moniker-end

> [!NOTE]
> When using <xref:Microsoft.AspNetCore.Builder.WebApplication> (see <xref:migration/50-to-60#new-hosting-model>), [`app.UseRouting`](xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A) must be called after `UsePathBase` so that the Routing Middleware can observe the modified path before matching routes. Otherwise, routes are matched before the path is rewritten by `UsePathBase` as described in the [Middleware Ordering](xref:fundamentals/middleware/index#order) and [Routing](xref:fundamentals/routing) articles.

Do ***not*** prefix links throughout the app with a forward slash. Either avoid the use of a path segment separator or use dot-slash (`./`) relative path notation:

* <span aria-hidden="true">❌</span> Incorrect: `<a href="/account">`
* <span aria-hidden="true">✔️</span> Correct: `<a href="account">`
* <span aria-hidden="true">✔️</span> Correct: `<a href="./account">`

In [Blazor WebAssembly web API requests with the `HttpClient` service](xref:blazor/call-web-api?pivots=webassembly), confirm that JSON helpers (<xref:System.Net.Http.Json.HttpClientJsonExtensions>) do ***not*** prefix URLs with a forward slash (`/`):

* <span aria-hidden="true">❌</span> Incorrect: `var rsp = await client.GetFromJsonAsync("/api/Account");`
* <span aria-hidden="true">✔️</span> Correct: `var rsp = await client.GetFromJsonAsync("api/Account");`

Do ***not*** prefix [Navigation Manager](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers) relative links with a forward slash. Either avoid the use of a path segment separator or use dot-slash (`./`) relative path notation (`Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>):

* <span aria-hidden="true">❌</span> Incorrect: `Navigation.NavigateTo("/other");`
* <span aria-hidden="true">✔️</span> Correct: `Navigation.NavigateTo("other");`
* <span aria-hidden="true">✔️</span> Correct: `Navigation.NavigateTo("./other");`

In typical configurations for Azure/IIS hosting, additional configuration usually isn't required. In some non-IIS hosting and reverse proxy hosting scenarios, additional Static File Middleware configuration might be required:

* To serve static files correctly (for example, `app.UseStaticFiles("/CoolApp");`).
* To serve the Blazor script (`_framework/blazor.*.js`). For more information, see <xref:blazor/fundamentals/static-files>.

For a Blazor WebAssembly app with a non-root relative URL path (for example, `<base href="/CoolApp/">`), the app fails to find its resources *when run locally*. To overcome this problem during local development and testing, you can supply a *path base* argument that matches the `href` value of the `<base>` tag at runtime. **Don't include a trailing slash.** To pass the path base argument when running the app locally, execute the `dotnet run` command from the app's directory with the `--pathbase` option:

```dotnetcli
dotnet run --pathbase=/{RELATIVE URL PATH (no trailing slash)}
```

For a Blazor WebAssembly app with a relative URL path of `/CoolApp/` (`<base href="/CoolApp/">`), the command is:

```dotnetcli
dotnet run --pathbase=/CoolApp
```

If you prefer to configure the app's launch profile to specify the `pathbase` automatically instead of manually with `dotnet run`, set the `commandLineArgs` property in `Properties/launchSettings.json`. The following also configures the launch URL (`launchUrl`):

```json
"commandLineArgs": "--pathbase=/{RELATIVE URL PATH (no trailing slash)}",
"launchUrl": "{RELATIVE URL PATH (no trailing slash)}",
```

Using `CoolApp` as the example:

```json
"commandLineArgs": "--pathbase=/CoolApp",
"launchUrl": "CoolApp",
```

Using either `dotnet run` with the `--pathbase` option or a launch profile configuration that sets the base path, the Blazor WebAssembly app responds locally at `http://localhost:port/CoolApp`.

For more information on the `launchSettings.json` file, see <xref:fundamentals/environments#development-and-launchsettingsjson>. For additional information on Blazor app base paths and hosting, see [`<base href="/" />` or base-tag alternative for Blazor MVC integration (dotnet/aspnetcore #43191)](https://github.com/dotnet/aspnetcore/issues/43191#issuecomment-1212156106).

:::moniker range="< aspnetcore-8.0"

## Blazor Server `MapFallbackToPage` configuration

<!-- UPDATE 8.0 Update for BWAs -->

In scenarios where an app requires a separate area with custom resources and Razor components:

* Create a folder within the app's `Pages` folder to hold the resources. For example, an administrator section of an app is created in a new folder named `Admin` (`Pages/Admin`).
* Create a root page (`_Host.cshtml`) for the area. For example, create a `Pages/Admin/_Host.cshtml` file from the app's main root page (`Pages/_Host.cshtml`). Don't provide an `@page` directive in the Admin `_Host` page.
* Add a layout to the area's folder (for example, `Pages/Admin/_Layout.razor`). In the layout for the separate area, set the `<base>` tag `href` to match the area's folder (for example, `<base href="/Admin/" />`). For demonstration purposes, add `~/` to the static resources in the page. For example:
  * `~/css/bootstrap/bootstrap.min.css`
  * `~/css/site.css`
  * `~/BlazorSample.styles.css` (the example app's namespace is `BlazorSample`)
  * `~/_framework/blazor.server.js` (Blazor script)
* If the area should have its own static asset folder, add the folder and specify its location to Static File Middleware in `Program.cs` (for example, `app.UseStaticFiles("/Admin/wwwroot")`).
* Razor components are added to the area's folder. At a minimum, add an `Index` component to the area folder with the correct `@page` directive for the area. For example, add a `Pages/Admin/Index.razor` file based on the app's default `Pages/Index.razor` file. Indicate the Admin area as the route template at the top of the file (`@page "/admin"`). Add additional components as needed. For example, `Pages/Admin/Component1.razor` with an `@page` directive and route template of `@page "/admin/component1`.
* In `Program.cs`, call <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for the area's request path immediately before the fallback root page path to the `_Host` page:

  ```csharp
  ...
  app.UseRouting();

  app.MapBlazorHub();
  app.MapFallbackToPage("~/Admin/{*clientroutes:nonfile}", "/Admin/_Host");
  app.MapFallbackToPage("/_Host");

  app.Run();
  ```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

## Host multiple Blazor WebAssembly apps

For more information on hosting multiple Blazor WebAssembly apps in a hosted Blazor [solution](xref:blazor/tooling#visual-studio-solution-file-sln), see <xref:blazor/host-and-deploy/multiple-hosted-webassembly>.

:::moniker-end

## Deployment

For deployment guidance, see the following topics:

* <xref:blazor/host-and-deploy/webassembly>
* <xref:blazor/host-and-deploy/server>
