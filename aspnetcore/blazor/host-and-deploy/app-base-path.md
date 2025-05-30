---
title: ASP.NET Core Blazor app base path
author: guardrex
description: Learn about the app base path in ASP.NET Core Blazor apps, including configuration guidance.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 03/31/2025
uid: blazor/host-and-deploy/app-base-path
---
# ASP.NET Core Blazor app base path

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains the *app base path* in ASP.NET Core Blazor apps, including configuration guidance.

The *app base path* is the app's root URL path. Successful routing in Blazor apps requires framework configuration for any root URL path that isn't at the default app base path `/`.

Consider the following ASP.NET Core app and Blazor sub-app:

* The ASP.NET Core app is named `MyApp`:
  * The app physically resides at `d:/MyApp`.
  * Requests are received at `https://www.contoso.com/{MYAPP RESOURCE}`.
* A Blazor app named `CoolApp` is a sub-app of `MyApp`:
  * The sub-app physically resides at `d:/MyApp/CoolApp`.
  * Requests are received at `https://www.contoso.com/CoolApp/{COOLAPP RESOURCE}`.

Without specifying additional configuration for `CoolApp`, the sub-app in this scenario has no knowledge of where it resides on the server. For example, the app can't construct correct relative URLs to its resources without knowing that it resides at the relative URL path `/CoolApp/`. This scenario also applies in various hosting and reverse proxy scenarios when an app isn't hosted at a root URL path.

## Background

An anchor tag's destination ([`href`](https://developer.mozilla.org/docs/Web/HTML/Element/a)) can be composed with either of two endpoints:

* Absolute locations that include a scheme (defaults to the page's scheme if omitted), host, port, and path or just a forward slash (`/`) followed by the path.

  Examples: `https://example.com/a/b/c` or `/a/b/c`

* Relative locations that contain just a path and do not start with a forward slash (`/`). These are resolved relative to the current document URL or the `<base>` tag's value, if specified.

  Example: `a/b/c`
  
The presence of a trailing slash (`/`) in a configured app base path is significant to compute the base path for URLs of the app. For example, `https://example.com/a` has a base path of `https://example.com/`, while `https://example.com/a/` with a trailing slash has a base path of `https://example.com/a`.

For the sources of links that pertain to Blazor in ASP.NET Core apps:

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

## Server-side Blazor

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

## Hosted Blazor WebAssembly

If the app is a hosted Blazor WebAssembly app:

* In the in the **:::no-loc text="Server":::** project (`Program.cs`):
  * Adjust the path of <xref:Microsoft.AspNetCore.Builder.ComponentsWebAssemblyApplicationBuilderExtensions.UseBlazorFrameworkFiles%2A> (for example, `app.UseBlazorFrameworkFiles("/base/path");`).
  * Configure calls to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (for example, `app.UseStaticFiles("/base/path");`).
* In the **:::no-loc text="Client":::** project:
  * Configure [`<StaticWebAssetBasePath>`](xref:blazor/fundamentals/static-files#static-web-asset-base-path) in the project file to match the path for serving static web assets (for example, `<StaticWebAssetBasePath>base/path</StaticWebAssetBasePath>
`).
  * Configure the `<base>` tag, per the guidance in the [Configure the app base path](#configure-the-app-base-path) section.

For an example of hosting multiple Blazor WebAssembly apps in a hosted Blazor WebAssembly solution, see <xref:blazor/host-and-deploy/webassembly/multiple-hosted-webassembly>, where approaches are explained for domain/port hosting and subpath hosting of multiple Blazor WebAssembly client apps.

:::moniker-end

## Standalone Blazor WebAssembly

In a standalone Blazor WebAssembly app, only the `<base>` tag is configured, per the guidance in the [Configure the app base path](#configure-the-app-base-path) section.

## Configure the app base path

To provide configuration for the Blazor app's base path of `https://www.contoso.com/CoolApp/`, set the [app base path (`<base>`)](https://developer.mozilla.org/docs/Web/HTML/Element/base), which is also called the relative root path.

By configuring the app base path, a component that isn't in the root directory can construct URLs relative to the app's root path. Components at different levels of the directory structure can build links to other resources at locations throughout the app. The app base path is also used to intercept selected hyperlinks where the `href` target of the link is within the app base path URI space. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component handles the internal navigation.

Place the `<base>` tag in `<head>` markup ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)) before any elements with attribute values that are URLs, such as the `href` attributes of `<link>` elements.

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
> When using <xref:Microsoft.AspNetCore.Builder.WebApplication> (see <xref:migration/50-to-60#new-hosting-model>), [`app.UseRouting`](xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A) must be called after <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> so that the Routing Middleware can observe the modified path before matching routes. Otherwise, routes are matched before the path is rewritten by <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> as described in the [Middleware Ordering](xref:fundamentals/middleware/index#order) and [Routing](xref:fundamentals/routing) articles.

Don't prefix links throughout the app with a forward slash. Either avoid the use of a path segment separator or use dot-slash (`./`) relative path notation:

* <span aria-hidden="true">❌</span> Incorrect: `<a href="/account">`
* <span aria-hidden="true">✔️</span> Correct: `<a href="account">`
* <span aria-hidden="true">✔️</span> Correct: `<a href="./account">`

In [Blazor WebAssembly web API requests with the `HttpClient` service](xref:blazor/call-web-api?pivots=webassembly), confirm that JSON helpers (<xref:System.Net.Http.Json.HttpClientJsonExtensions>) don't prefix URLs with a forward slash (`/`):

* <span aria-hidden="true">❌</span> Incorrect: `var rsp = await client.GetFromJsonAsync("/api/Account");`
* <span aria-hidden="true">✔️</span> Correct: `var rsp = await client.GetFromJsonAsync("api/Account");`

Don't prefix [Navigation Manager](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers) relative links with a forward slash. Either avoid the use of a path segment separator or use dot-slash (`./`) relative path notation (`Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>):

* <span aria-hidden="true">❌</span> Incorrect: `Navigation.NavigateTo("/other");`
* <span aria-hidden="true">✔️</span> Correct: `Navigation.NavigateTo("other");`
* <span aria-hidden="true">✔️</span> Correct: `Navigation.NavigateTo("./other");`

In typical configurations for Azure/IIS hosting, additional configuration usually isn't required. In some non-IIS hosting and reverse proxy hosting scenarios, additional Static File Middleware configuration might be required:

* To serve static files correctly (for example, `app.UseStaticFiles("/CoolApp");`).
* To serve the Blazor script (`_framework/blazor.*.js`). For more information, see <xref:blazor/fundamentals/static-files>.

For a Blazor WebAssembly app with a non-root relative URL path (for example, `<base href="/CoolApp/">`), the app fails to find its resources *when run locally*. To overcome this problem during local development and testing, you can supply a *path base* argument that matches the `href` value of the `<base>` tag at runtime. **Don't include a trailing slash.** To pass the path base argument when running the app locally, execute the `dotnet watch` (or `dotnet run`) command from the app's directory with the `--pathbase` option:

```dotnetcli
dotnet watch --pathbase=/{RELATIVE URL PATH (no trailing slash)}
```

For a Blazor WebAssembly app with a relative URL path of `/CoolApp/` (`<base href="/CoolApp/">`), the command is:

```dotnetcli
dotnet watch --pathbase=/CoolApp
```

If you prefer to configure the app's launch profile to specify the `pathbase` automatically instead of manually with `dotnet watch` (or `dotnet run`), set the `commandLineArgs` property in `Properties/launchSettings.json`. The following also configures the launch URL (`launchUrl`):

```json
"commandLineArgs": "--pathbase=/{RELATIVE URL PATH (no trailing slash)}",
"launchUrl": "{RELATIVE URL PATH (no trailing slash)}",
```

Using `CoolApp` as the example:

```json
"commandLineArgs": "--pathbase=/CoolApp",
"launchUrl": "CoolApp",
```

Using either `dotnet watch` (or `dotnet run`) with the `--pathbase` option or a launch profile configuration that sets the base path, the Blazor WebAssembly app responds locally at `http://localhost:port/CoolApp`.

For more information on the `launchSettings.json` file, see <xref:fundamentals/environments#development-and-launchsettingsjson>. For additional information on Blazor app base paths and hosting, see [`<base href="/" />` or base-tag alternative for Blazor MVC integration (dotnet/aspnetcore #43191)](https://github.com/dotnet/aspnetcore/issues/43191#issuecomment-1212156106).

## Obtain the app base path from configuration

The following guidance explains how to obtain the path for the `<base>` tag from an app settings file for different [environments](xref:blazor/fundamentals/environments).

Add the app settings file to the app. The following example is for the `Staging` environment (`appsettings.Staging.json`):

```json
{
  "AppBasePath": "staging/"
}
```

In a server-side Blazor app, load the base path from configuration in [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content):

```razor
@inject IConfiguration Config

...

<head>
    ...
    <base href="/@(Config.GetValue<string>("AppBasePath"))" />
    ...
</head>
```

:::moniker range=">= aspnetcore-6.0"

Alternatively, a server-side app can obtain the value from configuration for <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A>. Place the following code ***first*** in the app's request processing pipeline (`Program.cs`) immediately after the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> is built (`builder.Build()`). The following example uses the configuration key `AppBasePath`:

```csharp
app.UsePathBase($"/{app.Configuration.GetValue<string>("AppBasePath")}");
```

In a client-side Blazor WebAssembly app:

* Remove the `<base>` tag from `wwwroot/index.html`:

  ```diff
  - <base href="..." />
  ```

* Supply the app base path via a [`HeadContent` component](xref:blazor/components/control-head-content#control-head-content-in-a-razor-component) in the `App` component (`App.razor`):

  ```razor
  @inject IConfiguration Config

  ...

  <HeadContent>
      <base href="/@(Config.GetValue<string>("AppBasePath"))" />
  </HeadContent>
  ```

:::moniker-end

If there's no configuration value to load, for example in non-staging environments, the preceding `href` resolves to the root path `/`.

The examples in this section focus on supplying the app base path from app settings, but the approach of reading the path from <xref:Microsoft.Extensions.Configuration.IConfiguration> is valid for any configuration provider. For more information, see the following resources:

* <xref:blazor/fundamentals/configuration>
* <xref:fundamentals/configuration/index>
