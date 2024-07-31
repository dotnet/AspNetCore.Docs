---
title: Integrate ASP.NET Core Razor components into ASP.NET Core apps
author: guardrex
description: Learn about Razor component integration scenarios ASP.NET Core apps, Razor Pages and MVC.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/components/integration
---
# Integrate ASP.NET Core Razor components into ASP.NET Core apps

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains Razor component integration scenarios for ASP.NET Core apps.

## Razor component integration

Razor components can be integrated into Razor Pages, MVC, and other types of ASP.NET Core apps. Razor components can also be integrated into any web app, including apps not based on ASP.NET Core, as [custom HTML elements](xref:blazor/components/js-spa-frameworks#blazor-custom-elements).

Use the guidance in the following sections depending on the app's requirements:

* To integrate components that aren't directly routable from user requests, follow the guidance in the [Use non-routable components in pages or views](#use-non-routable-components-in-pages-or-views) section. Follow this guidance when the app should only embed components into existing pages and views with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).
* To integrate components with full Blazor support, follow the guidance in the [Add Blazor support to an ASP.NET Core app](#add-blazor-support-to-an-aspnet-core-app) section.

## Use non-routable components in pages or views

Use the following guidance to integrate Razor components into pages or views of an existing Razor Pages or MVC app with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

> [!NOTE]
> If your app requires directly-routable components (not embedded into pages or views), skip this section and use the guidance in the [Add Blazor support to an ASP.NET Core app](#add-blazor-support-to-an-aspnet-core-app) section.

When server prerendering is used and the page or view renders:

* The component is prerendered with the page or view.
* The initial component state used for prerendering is lost.
* New component state is created when the SignalR connection is established.

For more information on rendering modes, including non-interactive static component rendering, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>. To save the state of prerendered Razor components, see <xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper>.

Add a `Components` folder to the root folder of the project.

Add an imports file to the `Components` folder with the following content. Change the `{APP NAMESPACE}` placeholder to the namespace of the project.

`Components/_Imports.razor`:

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using static Microsoft.AspNetCore.Components.Web.RenderMode
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using {APP NAMESPACE}
@using {APP NAMESPACE}.Components
```

In the project's layout file (`Pages/Shared/_Layout.cshtml` in Razor Pages apps or `Views/Shared/_Layout.cshtml` in MVC apps):

* Add the following `<base>` tag and [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component to the `<head>` markup:

  ```cshtml
  <base href="~/" />
  <component type="typeof(Microsoft.AspNetCore.Components.Web.HeadOutlet)" 
      render-mode="ServerPrerendered" />
  ```

  The `href` value (the *app base path*) in the preceding example assumes that the app resides at the root URL path (`/`). If the app is a sub-application, follow the guidance in the *App base path* section of the <xref:blazor/host-and-deploy/index#app-base-path> article.

  The <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is used to render head (`<head>`) content for page titles (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component) set by Razor components. For more information, see <xref:blazor/components/control-head-content>.

* Add a `<script>` tag for the `blazor.web.js` script immediately before the `Scripts` render section (`@await RenderSectionAsync(...)`):

  ```html
  <script src="_framework/blazor.web.js"></script>
  ```

  There's no need to manually add a `blazor.web.js` script to the app because the Blazor framework adds the `blazor.web.js` script to the app.

> [!NOTE]
> Typically, the layout loads via a `_ViewStart.cshtml` file.

Add an non-operational (no-op) `App` component to the project.

`Components/App.razor`:

```razor
@* No-op App component *@
```

Where services are registered, add services for Razor components and services to support rendering Interactive Server components.

At the top of the `Program` file, add a `using` statement to the top of the file for the project's components:

```csharp
using {APP NAMESPACE}.Components;
```

In the preceding line, change the `{APP NAMESPACE}` placeholder to the app's namespace. For example:

```csharp
using BlazorSample.Components;
```

In the `Program` file before the line that builds the app (`builder.Build()`):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

For more information on adding support for Interactive Server and WebAssembly components, see <xref:blazor/components/render-modes>.

In the `Program` file immediately after the call to map Razor Pages (<xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>) in a Razor Pages app or to map the default controller route (<xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>) in an MVC app, call <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> to discover available components and specify the app's root component (the first component loaded). By default, the app's root component is the `App` component (`App.razor`). Chain a call to <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> to configure interactive server-side rendering (interactive SSR) for the app:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

> [!NOTE]
> If the app hasn't already been updated to include Antiforgery Middleware, add the following line after <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> is called:
>
> ```csharp
> app.UseAntiforgery();
> ```

Integrate components into any page or view. For example, add an `EmbeddedCounter` component to the project's `Components` folder.

`Components/EmbeddedCounter.razor`:

```razor
<h1>Embedded Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

**Razor Pages**:

In the project's `Index` page of a Razor Pages app, add the `EmbeddedCounter` component's namespace and embed the component into the page. When the `Index` page loads, the `EmbeddedCounter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

`Pages/Index.cshtml`:

```cshtml
@page
@using {APP NAMESPACE}.Components
@model IndexModel
@{
    ViewData["Title"] = "Home page";
}

<component type="typeof(EmbeddedCounter)" render-mode="ServerPrerendered" />
```

**MVC**:

In the project's `Index` view of an MVC app, add the `EmbeddedCounter` component's namespace and embed the component into the view. When the `Index` view loads, the `EmbeddedCounter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

`Views/Home/Index.cshtml`:

```cshtml
@using {APP NAMESPACE}.Components
@{
    ViewData["Title"] = "Home Page";
}

<component type="typeof(EmbeddedCounter)" render-mode="ServerPrerendered" />
```

## Add Blazor support to an ASP.NET Core app

This section covers adding Blazor support to an ASP.NET Core app:

* [Add static server-side rendering (static SSR)](#add-static-server-side-rendering-static-ssr)
* [Enable interactive server-side rendering (interactive SSR)](#enable-interactive-server-side-rendering-interactive-ssr)
* [Enable interactive automatic (Auto) or client-side rendering (CSR)](#enable-interactive-automatic-auto-or-client-side-rendering-csr)

> [!NOTE]
> For the examples in this section, the example app's name and namespace is `BlazorSample`.

### Add static server-side rendering (static SSR)

Add a `Components` folder to the app.

Add the following `_Imports` file for namespaces used by Razor components.

`Components/_Imports.razor`:

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using static Microsoft.AspNetCore.Components.Web.RenderMode
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using {APP NAMESPACE}
@using {APP NAMESPACE}.Components
```

Change the namespace placeholder (`{APP NAMESPACE}`) to the namespace of the app. For example:

```razor
@using BlazorSample
@using BlazorSample.Components
```

Add the Blazor router (`<Router>`, <xref:Microsoft.AspNetCore.Components.Routing.Router>) to the app in a `Routes` component, which is placed in the app's `Components` folder.

`Components/Routes.razor`:

```razor
<Router AppAssembly="typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="routeData" />
        <FocusOnNavigate RouteData="routeData" Selector="h1" />
    </Found>
</Router>
```

Add an `App` component to the app, which serves as the root component, which is the first component the app loads.

`Components/App.razor`:

:::moniker range=">= aspnetcore-9.0"

```razor
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="@Assets["{ASSEMBLY NAME}.styles.css"]" />
    <HeadOutlet />
</head>

<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
</body>

</html>
```

:::moniker-end

:::moniker range="< aspnetcore-9.0"

```razor
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="{ASSEMBLY NAME}.styles.css" />
    <HeadOutlet />
</head>

<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
</body>

</html>
```

:::moniker-end

The `{ASSEMBLY NAME}` placeholder is the app's assembly name. For example, a project with an assembly name of `ContosoApp` uses the `ContosoApp.styles.css` stylesheet file name.

Add a `Pages` folder to the `Components` folder to hold routable Razor components.

Add the following `Welcome` component to demonstrate static SSR.

`Components/Pages/Welcome.razor`:

```razor
@page "/welcome"

<PageTitle>Welcome!</PageTitle>

<h1>Welcome to Blazor!</h1>

<p>@message</p>

@code {
    private string message = 
        "Hello from a Razor component and welcome to Blazor!";
}
```

In the ASP.NET Core project's `Program` file:

* Add a `using` statement to the top of the file for the project's components:

  ```csharp
  using {APP NAMESPACE}.Components;
  ```

  In the preceding line, change the `{APP NAMESPACE}` placeholder to the app's namespace. For example:

  ```csharp
  using BlazorSample.Components;
  ```

* Add Razor component services (<xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>), which also automatically adds  antiforgery services (<xref:Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions.AddAntiforgery%2A>). Add the following line before the line that calls `builder.Build()`):

  ```csharp
  builder.Services.AddRazorComponents();
  ```

* Add [Antiforgery Middleware](xref:blazor/security/index#antiforgery-support) to the request processing pipeline with <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A>. <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> is called after the call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>. If there are calls to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>, the call to <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> must go between them. A call to <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> must be placed after calls to <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>.

  ```csharp
  app.UseAntiforgery();
  ```

* Add <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> to the app's request processing pipeline with the `App` component (`App.razor`) specified as the default root component (the first component loaded). Place the following code before the line that calls `app.Run`:

  ```csharp
  app.MapRazorComponents<App>();
  ```

When the app is run, the `Welcome` component is accessed at the `/welcome` endpoint.

### Enable interactive server-side rendering (interactive SSR)

Follow the guidance in the [Add static server-side rendering (static SSR)](#add-static-server-side-rendering-static-ssr) section.

In the app's `Program` file, add a call to <xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A> where Razor component services are added with <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

Add a call to <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> where Razor components are mapped with <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A>:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

Add the following `Counter` component to the app that adopts interactive server-side rendering (interactive SSR).

`Components/Pages/Counter.razor`:

```razor
@page "/counter"
@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

When the app is run, the `Counter` component is accessed at `/counter`.

### Enable interactive automatic (Auto) or client-side rendering (CSR)

Follow the guidance in the [Add static server-side rendering (static SSR)](#add-static-server-side-rendering-static-ssr) section.

Components using the Interactive Auto render mode initially use interactive SSR. The .NET runtime and app bundle are downloaded to the client in the background and cached so that they can be used on future visits. Components using the Interactive WebAssembly render mode only render interactively on the client after the Blazor bundle is downloaded and the Blazor runtime activates. Keep in mind that when using the Interactive Auto or Interactive WebAssembly render modes, component code downloaded to the client is ***not*** private. For more information, see <xref:blazor/components/render-modes>.

After deciding which render mode to adopt:

* If you plan to adopt the Interactive Auto render mode, follow the guidance in the [Enable interactive server-side rendering (interactive SSR)](#enable-interactive-server-side-rendering-interactive-ssr) section. 
* If you plan to only adopt Interactive WebAssembly rendering, continue without adding interactive SSR.

Add a package reference for the [`Microsoft.AspNetCore.Components.WebAssembly.Server`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server) NuGet package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

Create a donor Blazor Web App to provide assets to the app. Follow the guidance in the <xref:blazor/tooling> article, selecting support for the following template features when generating the Blazor Web App.

For the app's name, use the same name as the ASP.NET Core app, which results in matching app name markup in components and matching namespaces in code. Using the same name/namespace isn't strictly required, as namespaces can be adjusted after assets are moved from the donor app to the ASP.NET Core app. However, time is saved by matching the namespaces at the outset.

Visual Studio:

* For **Interactive render mode**, select **Auto (Server and WebAssembly)**.
* Set the **Interactivity location** to **Per page/component**.
* Deselect the checkbox for **Include sample pages**.

.NET CLI:

* Use the `-int Auto` option.
* Do ***not*** use the `-ai|--all-interactive` option.
* Pass the `-e|--empty` option.

From the donor Blazor Web App, copy the entire `.Client` project into the solution folder of the ASP.NET Core app.

> [!IMPORTANT]
> **Don't copy the `.Client` folder into the ASP.NET Core project's folder.** The best approach for organizing .NET solutions is to place each project of the solution into its own folder inside of a top-level solution folder. If a solution folder above the ASP.NET Core project's folder doesn't exist, create one. Next, copy the `.Client` project's folder from the donor Blazor Web App into the solution folder. The final project folder structure should have the following layout:
>
> * `BlazorSampleSolution` (top-level solution folder)
>   * `BlazorSample` (original ASP.NET Core project)
>   * `BlazorSample.Client` (`.Client` project folder from the donor Blazor Web App)
>
> For the ASP.NET Core solution file, you can leave it in the ASP.NET Core project's folder. Alternatively, you can move the solution file or create a new one in the top-level solution folder as long as the project references correctly point to the project files (`.csproj`) of the two projects in the solution folder.

If you named the donor Blazor Web App when you created the donor project the same as the ASP.NET Core app, the namespaces used by the donated assets match those in the ASP.NET Core app. You shouldn't need to take further steps to match namespaces. If you used a different namespace when creating the donor Blazor Web App project, you must adjust the namespaces across the donated assets to match if you intend to use the rest of this guidance exactly as presented. If the namespaces don't match, ***either*** adjust the namespaces before proceeding ***or*** adjust the namespaces as you follow the remaining guidance in this section.

Delete the donor Blazor Web App, as it has no further use in this process.

Add the `.Client` project to the solution:

* Visual Studio: Right-click the solution in **Solution Explorer** and select **Add** > **Existing Project**. Navigate to the `.Client` folder and select the project file (`.csproj`).

* .NET CLI: Use the [`dotnet sln add` command](/dotnet/core/tools/dotnet-sln#add) to add the `.Client` project to the solution.

Add a project reference from the ASP.NET Core project to the client project:

* Visual Studio: Right-click the ASP.NET Core project and select **Add** > **Project Reference**. Select the `.Client` project and select **OK**.

* .NET CLI: From the ASP.NET Core project's folder, use the following command:

  ```dotnetcli
  dotnet add reference ../BlazorSample.Client/BlazorSample.Client.csproj
  ```

  The preceding command assumes the following:
  
  * The project file name is `BlazorSample.Client.csproj`.
  * The `.Client` project is in a `BlazorSample.Client` folder inside the solution folder. The `.Client` folder is side-by-side with the ASP.NET Core project's folder.
  
  For more information on the `dotnet add reference` command, see [`dotnet add reference` (.NET documentation)](/dotnet/core/tools/dotnet-add-reference).

Make the following changes to the ASP.NET Core app's `Program` file:

* Add Interactive WebAssembly component services with <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddInteractiveWebAssemblyComponents%2A> where Razor component services are added with <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>.

  For interactive Auto rendering:

  ```csharp
  builder.Services.AddRazorComponents()
      .AddInteractiveServerComponents()
      .AddInteractiveWebAssemblyComponents();
  ```

  For only Interactive WebAssembly rendering:

  ```csharp
  builder.Services.AddRazorComponents()
      .AddInteractiveWebAssemblyComponents();
  ```

* Add the Interactive WebAssembly render mode (<xref:Microsoft.AspNetCore.Builder.WebAssemblyRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveWebAssemblyRenderMode%2A>) and additional assemblies for the `.Client` project where Razor components are mapped with <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A>.

  For interactive automatic (Auto) rendering:

  ```csharp
  app.MapRazorComponents<App>()
      .AddInteractiveServerRenderMode()
      .AddInteractiveWebAssemblyRenderMode()
      .AddAdditionalAssemblies(typeof(BlazorSample.Client._Imports).Assembly);
  ```

  For only Interactive WebAssembly rendering:

  ```csharp
  app.MapRazorComponents<App>()
      .AddInteractiveWebAssemblyRenderMode()
      .AddAdditionalAssemblies(typeof(BlazorSample.Client._Imports).Assembly);
  ```

  In the preceding examples, change `BlazorSample.Client` to match the `.Client` project's namespace.

Add a `Pages` folder to the `.Client` project.

If the ASP.NET Core project has an existing `Counter` component:

* Move the component to the `Pages` folder of the `.Client` project.
* Remove the `@rendermode` directive at the top of the component file.

If the ASP.NET Core app doesn't have a `Counter` component, add the following `Counter` component (`Pages/Counter.razor`) to the `.Client` project:

```razor
@page "/counter"
@rendermode InteractiveAuto

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

If the app is only adopting Interactive WebAssembly rendering, remove the `@rendermode` directive and value:

```diff
- @rendermode InteractiveAuto
```

Run the solution from the ***ASP.NET Core app*** project:

* Visual Studio: Confirm that the ASP.NET Core project is selected in **Solution Explorer** when running the app.

* .NET CLI: Run the project from the ASP.NET Core project's folder.

To load the `Counter` component, navigate to `/counter`.

### Implement Blazor's layout and styles

Optionally, assign a default layout component using the <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout?displayProperty=nameWithType> parameter of the `RouteView` component.

In `Routes.razor`, the following example uses a `MainLayout` component as the default layout:

```razor
<RouteView RouteData="routeData" DefaultLayout="typeof(MainLayout)" />
```

For more information, see <xref:blazor/components/layouts#apply-a-default-layout-to-an-app>.

Blazor project template layout and stylesheets are available from the [`dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Layout):

* `MainLayout.razor`
* `MainLayout.razor.css`
* `NavMenu.razor`
* `NavMenu.razor.css`

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Depending on how you organize your layout files in the app, you might need to add an `@using` statement for the layout files' folder in the app's `_Imports.razor` file in order to surface them for use in the app's components.

There's no need to explicitly reference stylesheets when using [CSS isolation](xref:blazor/components/css-isolation). The Blazor framework automatically bundles individual component stylesheets. The app's bundled stylesheet is already referenced in the app's `App` component (`{ASSEMBLY NAME}.styles.css`, where the `{ASSEMBLY NAME}` placeholder is the app's assembly name).

## Return a `RazorComponentResult` from an MVC controller action

An MVC controller action can return a component with <xref:Microsoft.AspNetCore.Http.HttpResults.RazorComponentResult%601>.

`Components/Welcome.razor`:

```razor
<PageTitle>Welcome!</PageTitle>

<h1>Welcome!</h1>

<p>@Message</p>

@code {
    [Parameter]
    public string? Message { get; set; }
}
```

In a controller:

```csharp
public IResult GetWelcomeComponent()
{
    return new RazorComponentResult<Welcome>(new { Message = "Hello, world!" });
}
```

Only HTML markup for the rendered component is returned. Layouts and HTML page markup aren't automatically rendered with the component. To produce a complete HTML page, the app can maintain a [Blazor layout](xref:blazor/components/layouts) that provides HTML markup for `<html>`, `<head>`, `<body>`, and other tags. The component includes the layout with the [`@layout`](xref:mvc/views/razor#layout) Razor directive at the top of the component definition file, `Welcome.razor` for the example in this section. The following example assumes that the app has a layout named `RazorComponentResultLayout` (`Components/Layout/RazorComponentResultLayout.razor`):

```razor
@using BlazorSample.Components.Layout
@layout RazorComponentResultLayout
```

You can avoid placing the `@using` statement for the `Layout` folder in individual components by moving it to the app's `_Imports.razor` file.

For more information, see <xref:blazor/components/layouts>.

## Component namespaces

When using a custom folder to hold the project's Razor components, add the namespace representing the folder to either the page/view or to the `_ViewImports.cshtml` file. In the following example:

* Components are stored in the `Components` folder of the project.
* The `{APP NAMESPACE}` placeholder is the project's namespace. `Components` represents the name of the folder.

```cshtml
@using {APP NAMESPACE}.Components
```

For example:

```cshtml
@using BlazorSample.Components
```

The `_ViewImports.cshtml` file is located in the `Pages` folder of a Razor Pages app or the `Views` folder of an MVC app.

For more information, see <xref:blazor/components/index#class-name-and-namespace>.

## Additional resources

<xref:blazor/components/prerender>
