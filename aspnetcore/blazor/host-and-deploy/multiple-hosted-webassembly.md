---
title: Multiple hosted ASP.NET Core Blazor WebAssembly apps
author: guardrex
description: Learn how to configure a hosted Blazor WebAssembly app to host multiple Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-3.1 < aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/host-and-deploy/multiple-hosted-webassembly
zone_pivot_groups: blazor-multiple-hosted-wasm-apps
---
# Multiple hosted ASP.NET Core Blazor WebAssembly apps

:::moniker range="< aspnetcore-7.0"

> [!NOTE]
> This isn't the latest version of this article. For the latest version of this article, see the [.NET 7 version](?view=aspnetcore-7.0&preserve-view=true).

:::moniker-end

This article explains how to configure a hosted Blazor WebAssembly app to host multiple Blazor WebAssembly apps.

## Configuration

Select the version of this article that matches your hosting requirements, either port/domain hosting (for example, `:5001`/`:5002` or `firstapp.com`/`secondapp.com`) or route subpath hosting (for example, `/FirstApp` and `/SecondApp`).

:::zone pivot="port-domain"

With the current hosting selection, this article covers port/domain hosting (for example, `:5001`/`:5002` or `firstapp.com`/`secondapp.com`).

In the following examples:

* The project name of the hosted Blazor WebAssembly app is `MultipleBlazorApps` in a folder named `MultipleBlazorApps`.
* The three projects in the solution before a second client app is added are `MultipleBlazorApps.Client` in the `Client` folder, `MultipleBlazorApps.Server` in the `Server` folder, and `MultipleBlazorApps.Shared` in the `Shared` folder.
* The initial (first) client app is the default client project of the solution created from the Blazor WebAssembly project template.
* A second client app is added to the solution, `MultipleBlazorApps.SecondClient` in a folder named `SecondClient`.
* Optionally, the server project (`MultipleBlazorApps.Server`) can serve pages or views as a Razor Pages or MVC app.
* The first client app is accessible in a browser at port 5001 or with a host of `firstapp.com`. The second client app is accessible in a browser at port 5002 or with a host of `secondapp.com`.

:::zone-end

:::zone pivot="route-subpath"

With the current selection, this article covers route subpath hosting (for example, `/FirstApp` and `/SecondApp`).

In the following examples:

* The project name of the hosted Blazor WebAssembly app is `MultipleBlazorApps` in a folder named `MultipleBlazorApps`.
* The three projects in the solution before a second client app is added are `MultipleBlazorApps.Client` in the `Client` folder, `MultipleBlazorApps.Server` in the `Server` folder, and `MultipleBlazorApps.Shared` in the `Shared` folder.
* The initial (first) client app is the default client project of the solution created from the Blazor WebAssembly project template.
* A second client app is added to the solution, `MultipleBlazorApps.SecondClient` in a folder named `SecondClient`.
* Optionally, the server project (`MultipleBlazorApps.Server`) can serve pages or views as a formal Razor Pages or MVC app.
* Both client apps use the default port defined by the `MultipleBlazorApps.Server` project's `Properties/launchSettings.json` file in its `applicationUrl` value. The first client app is accessible in a browser at the `/FirstApp` subpath. The second client app is accessible in a browser at the `/SecondApp` subpath. 

:::zone-end

The examples shown in this article require additional configuration for:

* Accessing the apps directly at the example host domains, `firstapp.com` and `secondapp.com`.
* Certificates for the client apps to enable TLS/HTTPS security.
* Configuring the server app as a Razor Pages app for the following features:
  * Integration of Razor components into pages or views.
  * Prerendering Razor components.

The preceding configurations are beyond the scope of this article. For more information, see the following resources:

* [Host and deploy articles](xref:host-and-deploy/index)
* <xref:security/enforcing-ssl>
* <xref:blazor/components/prerendering-and-integration?pivots=webassembly>

Use an existing hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) or create a [new hosted Blazor WebAssembly solution](xref:blazor/tooling) from the Blazor WebAssembly project template by passing the `-ho|--hosted` option if using the .NET CLI or selecting the **ASP.NET Core Hosted** checkbox in Visual Studio when the project is created in the IDE.

Use a folder for the solution named `MultipleBlazorApps` and name the project `MultipleBlazorApps`.

Create a new folder in the solution named `SecondClient`. In the new folder, add a second Blazor WebAssembly client app named `MultipleBlazorApps.SecondClient`. Add the project as a standalone Blazor WebAssembly app. To create a standalone Blazor WebAssembly app, don't pass the `-ho|--hosted` option if using the .NET CLI or don't use the **ASP.NET Core Hosted** checkbox if using Visual Studio.

Make the following changes to the `MultipleBlazorApps.SecondClient` project:

* Copy the `FetchData` component (`Pages/FetchData.razor`) from the `Client/Pages` folder to the `SecondClient/Pages` folder. This step is required because a standalone Blazor WebAssembly app doesn't call a **:::no-loc text="Server":::** project's controller for weather data, it uses a static data file. By copying the `FetchData` component to the added project, the second client app also makes a web API call to the server API for weather data.
* Delete the `SecondClient/wwwroot/sample-data` folder, as the `weather.json` file in the folder isn't used.

The following table describes the solution's folders and project names after the `SecondClient` folder and `MultipleBlazorApps.SecondClient` project are added.

Physical folder | Project name | Description
--- | --- | ---
`Client` | `MultipleBlazorApps.Client` | Blazor WebAssembly client app
`SecondClient` | `MultipleBlazorApps.SecondClient` | Blazor WebAssembly client app
`Server` | `MultipleBlazorApps.Server` | ASP.NET Core server app
`Shared` | `MultipleBlazorApps.Shared` | Shared resources project

The `MultipleBlazorApps.Server` project serves the two Blazor WebAssembly client apps and provides weather data to the client apps' `FetchData` components via an MVC controller. Optionally, the `MultipleBlazorApps.Server` project can also serve pages or views, as a traditional Razor Pages or MVC app. Steps to enable serving pages or views are covered later in this article.

:::zone pivot="port-domain"

> [!NOTE]
> The demonstration in this article uses static web asset path names of `FirstApp` for the `MultipleBlazorApps.Client` project and `SecondApp` for the `MultipleBlazorApps.SecondClient` project. The names "`FirstApp`" and "`SecondApp`" are merely for demonstration purposes. Other names are acceptable to distinguish the client apps, such as `App1`/`App2`, `Client1`/`Client2`, `1`/`2`, or any similar naming scheme. 
>
> When routing requests to the client apps by a port or a domain, "`FirstApp`" and "`SecondApp`" are used ***internally*** to route requests and serve responses for static assets and aren't seen in the browser's address bar.

:::zone-end

:::zone pivot="route-subpath"

> [!NOTE]
> The demonstration in this article uses static web asset path names of `FirstApp` for the `MultipleBlazorApps.Client` project and `SecondApp` for the `MultipleBlazorApps.SecondClient` project. The names "`FirstApp`" and "`SecondApp`" are merely for demonstration purposes. Other names are acceptable to distinguish the client apps, such as `App1`/`App2`, `Client1`/`Client2`, `1`/`2`, or any similar naming scheme. 
>
> "`FirstApp`" and "`SecondApp`" also appear in the browser's address bar because requests are routed to the two client apps using these names. Other valid URL route segments are supported, and the route segments don't strictly need to match the names used to route static web assets internally. Using "`FirstApp`" and "`SecondApp`" for both the internal static asset routing and app request routing is merely for convenance in this article's examples.

:::zone-end

In the first client app's project file (`MultipleBlazorApps.Client.csproj`), add a [`<StaticWebAssetBasePath>` property](xref:blazor/fundamentals/static-files#static-web-asset-base-path) to a `<PropertyGroup>` with a value of `FirstApp` to set the base path for the project's static assets:

```xml
<StaticWebAssetBasePath>FirstApp</StaticWebAssetBasePath>
```

In the `MultipleBlazorApps.SecondClient` app's project file (`MultipleBlazorApps.SecondClient.csproj`):

* Add a `<StaticWebAssetBasePath>` property to a `<PropertyGroup>` with a value of `SecondApp`:

  ```xml
  <StaticWebAssetBasePath>SecondApp</StaticWebAssetBasePath>
  ```

* Add a project reference for the `MultipleBlazorApps.Shared` project to an `<ItemGroup>`:

  ```xml
  <ItemGroup>
    <ProjectReference Include="..\Shared\MultipleBlazorApps.Shared.csproj" />
  </ItemGroup>
  ```

In the server app's project file (`Server/MultipleBlazorApps.Server.csproj`), create a project reference for the added `MultipleBlazorApps.SecondClient` client app in an `<ItemGroup>`:

```xml
<ProjectReference Include="..\SecondClient\MultipleBlazorApps.SecondClient.csproj" />
```

:::zone pivot="port-domain"

In the server app's `Properties/launchSettings.json` file, configure the `applicationUrl` of the Kestrel profile (`MultipleBlazorApps.Server`) to access the client apps at ports 5001 and 5002. If you configure your local environment to use the example domains, URLs for `applicationUrl` can use `firstapp.com` and `secondapp.com` and not use the ports.

> [!NOTE]
> The use of ports in this demonstration allows access to the client projects in a local browser without the need to configure a local hosting environment so that web browsers can access the client apps via the host configurations, `firstapp.com` and `secondapp.com`. In production scenarios, a typical configuration is to use subdomains to distinguish the client apps.
>
> For example:
>
> * The ports are dropped from the configuration of this demonstration.
> * The hosts are changed to use subdomains, such as `www.contoso.com` for site visitors and `admin.contoso.com` for administrators.
> * Additional hosts can be included for additional client apps, and at least one more host is required if the server app is also a Razor Pages or MVC app that serves pages or views.

If you plan to serve pages or views from the server app, use the following `applicationUrl` setting in the `Properties/launchSettings.json` file, which permits the following access:

* Optionally, the Razor Pages or MVC app (`MultipleBlazorApps.Server` project) responds to requests at port 5000.
* Responses to requests for the first client (`MultipleBlazorApps.Client` project) are at port 5001.
* Responses to requests for the second client (`MultipleBlazorApps.SecondClient` project) are at port 5002.

```json
"applicationUrl": "https://localhost:5000;https://localhost:5001;https://localhost:5002",
```

If you don't plan for the server app to serve pages or views and only serve the Blazor WebAssembly client apps, use the following setting, which permits the following access:

* The first client app responds on port 5001.
* The second client app responds on port 5002.

```json
"applicationUrl": "https://localhost:5001;https://localhost:5002",
```

:::zone-end

In the server app's `Program.cs` file, remove the following code, which appears after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>:

* If you plan to serve pages or views from the server app, delete the following lines of code:

  ```diff
  - app.UseBlazorFrameworkFiles();
  ```

  ```diff
  - app.MapFallbackToFile("index.html");
  ```

* If you plan for the server app to only serve the Blazor WebAssembly client apps, delete the following code:

  ```diff
  - app.UseBlazorFrameworkFiles();
  
  ...

  - app.UseRouting();

  - app.MapRazorPages();
  - app.MapControllers();
  - app.MapFallbackToFile("index.html");
  ```

  Leave Static File Middleware in place:

  ```csharp
  app.UseStaticFiles();
  ```

:::zone pivot="port-domain"

* Add middleware that maps requests to the client apps. The following example configures the middleware to run when the request port is either 5001 for the first client app or 5002 for the second client app, or the request host is either `firstapp.com` for the first client app or `secondapp.com` for the second client app.

  > [!NOTE]
  > Use of the hosts (`firstapp.com`/`secondapp.com`) on a local system with a local browser requires additional configuration that's beyond the scope of this article. For local testing of this scenario, we recommend using ports. Typical production apps are configured to use subdomains, such as `www.contoso.com` for site visitors and `admin.contoso.com` for administrators. With the proper DNS and server configuration, which is beyond the scope of this article and depends on the technologies used, the app responds to requests at whatever hosts are named in the following code.

  Where you removed the `app.UseBlazorFrameworkFiles();` line from `Program.cs`, place the following code:

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

  [!INCLUDE[](~/includes/spoof.md)]

:::zone-end

:::zone pivot="route-subpath"

* Add middleware that maps requests to the client apps. The following example configures the middleware to run when the request subpath is `/FirstApp` for the first client app or `/SecondApp` for the second client app.

  Where you removed the `app.UseBlazorFrameworkFiles();` line from `Program.cs`, place the following code:

  ```csharp
  app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/FirstApp", 
      StringComparison.OrdinalIgnoreCase), first =>
  {
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

  app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/SecondApp", 
      StringComparison.OrdinalIgnoreCase), second =>
  {
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

* Set the base path in each client app:

  In the first client app's `index.html` file (`Client/wwwroot/index.html`), update the `<base>` tag value to reflect the subpath. The trailing slash is required:

  ```html
  <base href="/FirstApp/" />
  ```

  In the second client app's `index.html` file (`SecondClient/wwwroot/index.html`), update the `<base>` tag value to reflect the subpath. The trailing slash is required:

  ```html
  <base href="/SecondApp/" />
  ```

:::zone-end

For more information on <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, see <xref:blazor/fundamentals/static-files#static-file-middleware>.

For more information on `UseBlazorFrameworkFiles` and `MapFallbackToFile`, see the following resources:

* <xref:Microsoft.AspNetCore.Builder.ComponentsWebAssemblyApplicationBuilderExtensions.UseBlazorFrameworkFiles%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/Server/src/ComponentsWebAssemblyApplicationBuilderExtensions.cs))
* <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A?displayProperty=fullName> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/StaticFiles/src/StaticFilesEndpointRouteBuilderExtensions.cs))

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Requests from the client apps to `/WeatherForecast` in the server API are either to `/FirstApp/WeatherForecast` or `/SecondApp/WeatherForecast` depending on which client app makes the request. Therefore, the controller routes that return weather data from the server API require a modification to include the path segments.

In the server app's weather forecast controller (`Controllers/WeatherForecastController.cs`), replace the existing route (`[Route("[controller]")]`) to `WeatherForecastController` with the following routes, which take into account the client request paths:

```csharp
[Route("FirstApp/[controller]")]
[Route("SecondApp/[controller]")]
```

If you plan to serve pages from the server app, add an `Index` Razor page to the `Pages` folder of the server app:

`Pages/Index.cshtml`:

```cshtml
@page
@model MultipleBlazorApps.Server.Pages.IndexModel
@{
    ViewData["Title"] = "Home";
}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Home</title>
</head>
<body>
    <div class="main">
        <div class="content px-4">

            <div>
                <h1>Welcome</h1>
                <p>Hello from Razor Pages!</p>
            </div>
        </div>
    </div>
</body>
</html>
```

`Pages/Index.cshtml.cs`:

:::moniker range=">= aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleBlazorApps.Server.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleBlazorApps.Server.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
```

:::moniker-end

> [!NOTE]
> The preceding `Index` page is a minimal example purely for demonstration purposes. If the app requires additional Razor Pages assets, such as a layout, styles, scripts, and imports, obtain them from an app created from the Razor Pages project template. For more information, see <xref:razor-pages/index>.

If you plan to serve MVC views from the server app, add an `Index` view and a `Home` controller:

`Views/Home/Index.cshtml`:

```cshtml
@{
    ViewData["Title"] = "Home";
}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Home</title>
</head>
<body>
    <div class="main">
        <div class="content px-4">

            <div>
                <h1>Welcome</h1>
                <p>Hello from MVC!</p>
            </div>
        </div>
    </div>
</body>
</html>
```

`Controllers/HomeController.cs`:

:::moniker range=">= aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.Mvc;

namespace MultipleBlazorApps.Server.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.Mvc;

namespace MultipleBlazorApps.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
```

:::moniker-end

> [!NOTE]
> The preceding `Index` view is a minimal example purely for demonstration purposes. If the app requires additional MVC assets, such as a layout, styles, scripts, and imports, obtain them from an app created from the MVC project template. For more information, see <xref:tutorials/first-mvc-app/start-mvc>.

For more information on using the Razor components from either of the client apps in pages or views of the server app, see <xref:blazor/components/prerendering-and-integration?pivots=webassembly>.

## Run the app

Run the `MultipleBlazorApps.Server` project:

:::zone pivot="port-domain"

* Access the initial client app at `https://localhost:5001`.
* Access the added client app at `https://localhost:5002`.
* If the server app is configured to serve pages or views, access the `Index` page or view at `https://localhost:5000`.

:::zone-end

:::zone pivot="route-subpath"

* Access the initial client app at `https://localhost:{DEFAULT PORT}/FirstApp`.
* Access the added client app at `https://localhost:{DEFAULT PORT}/SecondApp`.
* If the server app is configured to serve pages or views, access the `Index` page or view at `https://localhost:{DEFAULT PORT}`.

In the preceding example URLs, the `{DEFAULT PORT}` placeholder is the default port defined by the `MultipleBlazorApps.Server` project's `Properties/launchSettings.json` file in its `applicationUrl` value.

:::zone-end

> [!IMPORTANT]
> When running the app with the `dotnet run` command (.NET CLI), confirm that the command shell is open in the `Server` folder of the solution.
>
> When using Visual Studio's start button to run the app, confirm that the `MultipleBlazorApps.Server` project is set as the startup project (highlighted in Solution Explorer). 

## Static assets

When an asset is in a client app's `wwwroot` folder, provide the static asset request path in components:

```razor
<img alt="..." src="{PATH AND FILE NAME}" />
```

The `{PATH AND FILE NAME}` placeholder is the path and file name under `wwwroot`.

For example, the source for a Jeep image (`jeep-yj.png`) in the `vehicle` folder of `wwwroot`:

```razor
<img alt="Jeep Wrangler YJ" src="vehicle/jeep-yj.png" />
```

## Razor class library (RCL) support

Add the [Razor class library (RCL)](xref:blazor/components/class-libraries) to the solution as a new project:

* Right-click the solution in **Solution Explorer** and select **Add** > **New Project**.
* Use the **Razor Class Library** project template to create the project. The examples in this section use the project name `ComponentLibrary`, which is also the RCL's assembly name. Do ***not*** select the **Support pages and views** checkbox.

For each hosted Blazor WebAssembly client app, create a project reference for the RCL project by right-clicking each client project in **Solution Explorer** and selecting **Add** > **Project Reference**.

Use components from the RCL in the client apps with either of the following approaches:

* Place an [`@using`](xref:mvc/views/razor#using) directive at the top of the component for the RCL's namespace and add Razor syntax for the component. The following example is for an RCL with the assembly name `ComponentLibrary`:

  ```razor
  @using ComponentLibrary

  ...

  <Component1 />
  ```

* Provide the RCL's namespace along with the Razor syntax for the component. This approach doesn't require an [`@using`](xref:mvc/views/razor#using) directive at the top of the component file. The following example is for an RCL with the assembly name `ComponentLibrary`:

  ```razor
  <ComponentLibrary.Component1 />
  ```

> [!NOTE]
> An [`@using`](xref:mvc/views/razor#using) directive can also be placed into each client app's `_Import.razor` file, which makes the RCL's namespace globally available to components in that project.

When any other static asset is in the `wwwroot` folder of an RCL, reference the static asset in a client app per the guidance in <xref:razor-pages/ui-class#consume-content-from-a-referenced-rcl>:

```razor
<img alt="..." src="_content/{PACKAGE ID}/{PATH AND FILE NAME}" />
```

The `{PACKAGE ID}` placeholder is the RCL's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. The `{PATH AND FILE NAME}` placeholder is path and file name under `wwwroot`.

The following example shows the markup for a Jeep image (`jeep-yj.png`) in the `vehicle` folder of the RCL's `wwwroot` folder. The following example is for an RCL with the assembly name `ComponentLibrary`:

```razor
<img alt="Jeep Wrangler YJ" src="_content/ComponentLibrary/vehicle/jeep-yj.png" />
```

## Additional resources

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>
* <xref:blazor/components/css-isolation>
