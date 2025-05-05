---
title: Host and deploy ASP.NET Core Blazor
author: guardrex
description: Discover how to host and deploy Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
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

# [.NET CLI](#tab/net-cli)

Use the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command to publish the app with a Release configuration:

```dotnetcli
dotnet publish -c Release
```

---

Publishing the app triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times.

## Default publish locations

:::moniker range=">= aspnetcore-8.0"

* Blazor Web App: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder, where the `{TARGET FRAMEWORK}` placeholder is the target framework. Deploy the contents of the `publish` folder to the host.
* Standalone Blazor WebAssembly: The app is published into the `bin/Release/{TARGET FRAMEWORK}/publish` or `bin/Release/{TARGET FRAMEWORK}/browser-wasm/publish` folder. To deploy the app as a static site, copy the contents of the `wwwroot` folder to the static site host.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* Blazor Server: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder, where the `{TARGET FRAMEWORK}` placeholder is the target framework.. Deploy the contents of the `publish` folder to the host.
* Blazor WebAssembly
  * Standalone: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` or `bin/Release/{TARGET FRAMEWORK}/browser-wasm/publish` folder. To deploy the app as a static site, copy the contents of the `wwwroot` folder to the static site host.
  * Hosted: The server ASP.NET Core app and client Blazor WebAssembly app are published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder of the server app, along with any static web assets of the client app. Deploy the contents of the `publish` folder to the host.

:::moniker-end

## IIS

To host a Blazor app in IIS, see the following resources:

* IIS hosting
  * <xref:tutorials/publish-to-iis>
  * <xref:host-and-deploy/iis/index>
* <xref:blazor/host-and-deploy/server/index>: Server apps running on IIS, including IIS with Azure Virtual Machines (VMs) running Windows OS and Azure App Service.
* <xref:blazor/host-and-deploy/webassembly/iis>: Provides guidance for standalone Blazor WebAssembly apps hosted on IIS (and for hosted Blazor WebAssembly apps in .NET 7 or earlier).
* IIS sub-application hosting
  * Follow the [app base path guidance](xref:blazor/host-and-deploy/app-base-path) prior to publishing the app. The examples use an app base path of `/CoolApp` and show how to [obtain the base path from app settings or other configuration providers](xref:blazor/host-and-deploy/app-base-path#obtain-the-app-base-path-from-configuration).
  * Follow the sub-application configuration guidance in <xref:host-and-deploy/iis/advanced#sub-applications>. The sub-app's folder path under the root site becomes the virtual path of the sub-app. For an app base path of `/CoolApp`, the Blazor app is placed in a folder named `CoolApp` under the root site and the sub-app takes on a virtual path of `/CoolApp`.

Sharing an app pool among ASP.NET Core apps isn't supported, including for Blazor apps. Use one app pool per app when hosting with IIS, and avoid the use of IIS's [virtual directories](/iis/get-started/planning-your-iis-architecture/understanding-sites-applications-and-virtual-directories-on-iis#virtual-directories) for hosting multiple apps.

:::moniker range="< aspnetcore-8.0"

One or more Blazor WebAssembly apps hosted by an ASP.NET Core app, known as a [hosted Blazor WebAssembly solution](xref:blazor/hosting-models#blazor-webassembly), are supported for ***one*** app pool. However, we don't recommend or support assigning a single app pool to multiple hosted Blazor WebAssembly solutions or in sub-app hosting scenarios.

For more information on *solutions*, see <xref:blazor/tooling#visual-studio-solution-file-sln>.

:::moniker-end

## Blazor Server `MapFallbackToPage` configuration

*This section only applies to Blazor Server apps. <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> isn't supported in Blazor Web Apps and Blazor WebAssembly apps.*

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
