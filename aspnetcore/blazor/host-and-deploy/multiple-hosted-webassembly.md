---
title: Multiple hosted ASP.NET Core Blazor WebAssembly apps
author: guardrex
description: Learn how to configure a hosted Blazor WebAssembly app to host multiple Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/host-and-deploy/multiple-hosted-webassembly
---
# Multiple hosted ASP.NET Core Blazor WebAssembly apps

This article explains how to configure a hosted Blazor WebAssembly app to host multiple Blazor WebAssembly apps.

## Configuration

Hosted Blazor [solutions](xref:blazor/tooling#visual-studio-solution-file-sln) can serve multiple Blazor WebAssembly apps.

In the following example:

* The project name of the hosted Blazor WebAssembly app is `MultipleBlazorApps` in a folder named `MultipleBlazorApps`.
* The three projects in the solution before a second client app is added are `MultipleBlazorApps.Client` in the `Client` folder, `MultipleBlazorApps.Server` in the `Server` folder, and `MultipleBlazorApps.Shared` in the `Shared` folder.
* The initial (first) client app is the default client project of the solution created from the Blazor WebAssembly project template. The first client app is accessible in a browser at port 5001 or with a host of `firstapp.com`.
* A second client app is added to the solution, `MultipleBlazorApps.SecondClient` in a folder named `SecondClient`. The second client app is accessible in a browser at port 5002 or with a host of `secondapp.com`.
* Optionally, the server project (`MultipleBlazorApps.Server`) can serve pages or views as a formal Razor Pages or MVC app.

The example shown in this section requires additional configuration for:

* Accessing the apps directly at the example host domains, `firstapp.com` and `secondapp.com`.
* Certificates for the client apps to enable TLS/HTTPS security.
* Configuring the server app as a Razor Pages app for the following features:
  * Integration of Razor components into pages or views.
  * Prerendering Razor components.

The preceding configurations are beyond the scope of this demonstration. For more information, see the following resources:

* [Host and deploy articles](xref:host-and-deploy/index)
* <xref:security/enforcing-ssl>
* <xref:blazor/components/prerendering-and-integration?pivots=webassembly>

Use an existing hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) or create a [new hosted Blazor WebAssembly solution](xref:blazor/tooling) from the Blazor WebAssembly project template by passing the `-ho|--hosted` option if using the .NET CLI or selecting the **ASP.NET Core Hosted** checkbox in Visual Studio or Visual Studio for Mac when the project is created in the IDE.

Use a folder for the solution named `MultipleBlazorApps` and name the project `MultipleBlazorApps`.

Initial projects in the solution and their folders:

* `MultipleBlazorApps.Client` is a Blazor WebAssembly client app in the `Client` folder.
* `MultipleBlazorApps.Server` is an ASP.NET Core server app that serves Blazor WebAssembly apps) in the `Server` folder. Optionally, the server app can also serve pages or views, as a traditional Razor Pages or MVC app.
* `MultipleBlazorApps.Shared` is a shared resources project for the client and server projects in the `Shared` folder.

In the client app's project file (`MultipleBlazorApps.Client.csproj`), add a [`<StaticWebAssetBasePath>` property](xref:blazor/fundamentals/static-files#static-web-asset-base-path) to a `<PropertyGroup>` with a value of `FirstApp` to set the base path for the project's static assets:

```xml
<StaticWebAssetBasePath>FirstApp</StaticWebAssetBasePath>
```

> [!NOTE]
> The demonstration in this section uses web asset path names of `FirstApp` and `SecondApp`, but these specific names are merely for demonstration purposes. Any base path segments that distinguish the client apps are acceptable, such as `App1`/`App2`, `Client1`/`Client2`, `1`/`2`, or any similar naming scheme. These base path segments are used internally to route requests and serve responses and are ***not*** seen in a browser's address bar.

Add a second client app to the solution. Add the project as a standalone Blazor WebAssembly app. To create a standalone Blazor WebAssembly app, don't pass the `-ho|--hosted` option if using the .NET CLI or don't use the **ASP.NET Core Hosted** checkbox if using Visual Studio:

* Name the project `MultipleBlazorApps.SecondClient` and place the app into a folder named `SecondClient`.
* The solution folder created from the project template contains the following solution file and folders after the `SecondClient` folder is added:
  * `Client` (folder)
  * `SecondClient` (folder)
  * `Server` (folder)
  * `Shared` (folder)
  * `MultipleBlazorApps.sln` (file)

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

In the server app's `Properties/launchSettings.json` file, configure the `applicationUrl` of the Kestrel profile (`MultipleBlazorApps.Server`) to access the client apps at two ports.

> [!NOTE]
> The use of ports in this demonstration allows access to the client projects in a local browser without the need to configure a local hosting environment so that web browsers can access the client apps via the host configurations, `firstapp.com` and `secondapp.com`. In production scenarios, a typical configuration is to use subdomains to distinguish the client apps.
>
> For example:
>
> * The ports are dropped from the configuration of this demonstration.
> * The hosts are changed to use subdomains, such as `www.contoso.com` for site visitors and `admin.contoso.com` for administrators.
> * Additional hosts can be included for additional client apps, and at least one more host is required if the server app is also a Razor Pages or MVC app that serves pages or views.

If you plan to serve pages or views from the server app, use the following `applicationUrl` setting in the `Properties/launchSettings.json` file, which permits the following access:

* The Razor Pages or MVC app responds to requests at port 5000.
* Responses to requests for the first client are at port 5001.
* Responses to requests for the second client are at port 5002.

```json
"applicationUrl": "https://localhost:5000;https://localhost:5001;https://localhost:5002",
```

If you don't plan for the server app to serve pages or views and only serve the Blazor WebAssembly client apps, use the following setting, which permits the following access:

* The first client app responds on port 5001.
* The second client app responds on port 5002.

```json
"applicationUrl": "https://localhost:5001;https://localhost:5002",
```

In the server app's `Program.cs` file, remove the following code, which appears after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>:

* If you plan to serve pages or views from the server app, delete the following line of code:

  ```diff
  - app.UseBlazorFrameworkFiles();
  ```

* If you plan for the server app to only serve the Blazor WebAssembly client apps, delete the following code:

  ```diff
  - app.UseBlazorFrameworkFiles();
  - app.UseStaticFiles();

  - app.UseRouting();

  - app.MapRazorPages();
  - app.MapControllers();
  - app.MapFallbackToFile("index.html");
  ```

* Add middleware that maps requests to the client apps. The following example configures the middleware to run when:

  * The request port is either 5001 for the first client app or 5002 for the second client app.
  * The request host is either `firstapp.com` for the first client app or `secondapp.com` for the second client app.

  > [!NOTE]
  > Use of the hosts (`firstapp.com`/`secondapp.com`) on a local system with a local browser requires additional configuration that's beyond the scope of this article. For local testing of this scenario, we recommend using ports. Typical production apps are configured to use subdomains, such as `www.contoso.com` for site visitors and `admin.contoso.com` for administrators. With the proper DNS and server configuration, which is beyond the scope of this article and depends on the technologies used, the app responds to requests at whatever hosts are named in the following code.

  Place the following code where the code was removed earlier in the `Program.cs` file:

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

If you plan to serve pages from the server app, add an `Index` Razor page to the `Pages` folder of the server app:

`Pages/Index.cshtml`:

```cshtml
@page
@model MultipleBlazorApps.Server.Pages.IndexModel
@{
    ViewData["Title"] = "Home page";
}

<div>
    <h1>Welcome</h1>
    <p>Hello from Razor Pages!</p>
</div>
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
> If the app requires additional Razor Pages assets, such as a layout, styles, scripts, and imports, obtain them from an app created from the Razor Pages project template. For more information, see <xref:razor-pages/index>.

If you plan to serve MVC views from the server app, add an `Index` view and a `Home` controller:

`Views/Home/Index.cshtml`:

```cshtml
@{
    ViewData["Title"] = "Home Page";
}

<div>
    <h1>Welcome</h1>
    <p>Hello from MVC!</p>
</div>
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
> If the app requires additional MVC assets, such as a layout, styles, scripts, and imports, obtain them from an app created from the MVC project template. For more information, see <xref:tutorials/first-mvc-app/start-mvc>.

The middleware added to the server app's request processing pipeline earlier modifies incoming requests to `/WeatherForecast` to either `/FirstApp/WeatherForecast` or `/SecondApp/WeatherForecast` depending on the port (5001/5002) or domain (`firstapp.com`/`secondapp.com`). Therefore, the controller routes that return weather data from the server app to the client apps require a modification.

In the server app's weather forecast controller (`Controllers/WeatherForecastController.cs`), replace the existing route (`[Route("[controller]")]`) to `WeatherForecastController` with the following routes, which take into account the client apps' base paths added by the middleware (`FirstApp`/`SecondApp`):

```csharp
[Route("FirstApp/[controller]")]
[Route("SecondApp/[controller]")]
```

Run the `MultipleBlazorApps.Server` project:

* Access the initial client app at `https://localhost:5001`.
* Access the added client app at `https://localhost:5002`.
* If the server app is configured to serve pages or views, access the `Index` page or view at `https://localhost:5000`.

For more information on using the Razor components from either of the client apps in pages or views of the server app, see <xref:blazor/components/prerendering-and-integration?pivots=webassembly>.

## Static assets

When an asset is in a client app's `wwwroot` folder, provide the static asset request path in components:

```html
<img alt="..." src="/{PATH AND FILE NAME}" />
```

The `{PATH AND FILE NAME}` placeholder is the path and file name under `wwwroot`.

For example, the source for a Jeep image (`jeep-yj.png`) in the `vehicle` folder of `wwwroot`:

```html
<img alt="Jeep Wrangler YJ" src="/vehicle/jeep-yj.png" />
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

Manually add the RCL's bundled stylesheet to the `<head>` content of `wwwroot/index.html` of each client app that consumes the RCL. The following example is for an RCL with the assembly name `ComponentLibrary`:

```html
<link href="_content/ComponentLibrary/ComponentLibrary.bundle.scp.css" rel="stylesheet" />
```

When any other static asset is in the `wwwroot` folder of an RCL, reference the static asset in a client app per the guidance in <xref:razor-pages/ui-class#consume-content-from-a-referenced-rcl>:

```html
<img alt="..." src="_content/{PACKAGE ID}/{PATH AND FILE NAME}" />
```

The `{PACKAGE ID}` placeholder is the RCL's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. The `{PATH AND FILE NAME}` placeholder is path and file name under `wwwroot`.

The following example shows the source for a Jeep image (`jeep-yj.png`) in the `vehicle` folder of the RCL's `wwwroot`. The following example is for an RCL with the assembly name `ComponentLibrary`:

```html
<img alt="Jeep Wrangler YJ" src="_content/ComponentLibrary/vehicle/jeep-yj.png" />
```

## Additional resources

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>
* <xref:blazor/components/css-isolation>
