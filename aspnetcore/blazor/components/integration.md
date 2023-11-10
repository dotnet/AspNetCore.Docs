---
title: Integrate ASP.NET Core Razor components into ASP.NET Core apps
author: guardrex
description: Learn about Razor component integration scenarios ASP.NET Core apps, Razor Pages and MVC.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/components/integration
---
# Integrate ASP.NET Core Razor components into ASP.NET Core apps

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains Razor component integration scenarios for ASP.NET Core apps.

Razor components can be integrated into Razor Pages, MVC, and other types of ASP.NET Core apps. Razor components can also be integrated into any web app, including apps not based on ASP.NET Core, as [custom HTML elements](xref:blazor/components/js-spa-frameworks#blazor-custom-elements).

Use the guidance in the following sections depending on the project's requirements:

* Blazor support can be [added to an ASP.NET Core app](#add-blazor-support-to-an-aspnet-core-app).
* For interactive components that aren't directly routable from user requests, see the [Use non-routable components in pages or views](#use-non-routable-components-in-pages-or-views) section. Follow this guidance when the app embeds components into existing pages and views with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).
* For interactive components that are directly routable from user requests, see the [Use routable components](#use-routable-components) section. Follow this guidance when visitors should be able to make an HTTP request in their browser for a component with an [`@page`](xref:mvc/views/razor#page) directive.

## Add Blazor support to an ASP.NET Core app

This section covers adding Blazor support to an ASP.NET Core app:

* [Add Static Server Razor component rendering](#add-static-server-razor-component-rendering)
* [Enable Interactive Server rendering](#enable-interactive-server-rendering)
* [Enable interactive Auto or WebAssembly rendering](#enable-interactive-auto-and-webassembly-rendering)

> [!NOTE]
> For the examples in this section, the example app's name and namespace is `AspNetCoreApp`.

### Add Static Server Razor component rendering

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
@using AspNetCoreApp
@using AspNetCoreApp.Components
```

Change the namespace `AspNetCoreApp` in the preceding example to match the app.

Add the Blazor router (`<Router>`) to the app in a `Routes` component, which is placed in the app's `Components` folder.

`Components/Routes.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
</Router>
```

You can supply a default layout with the <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout?displayProperty=nameWithType> parameter of the `RouteView` component:

```razor
<RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
```

For more information, see <xref:blazor/components/layouts#apply-a-default-layout-to-an-app>.

Add an `App` component to the app, which serves as the root component for other components.

`Components/App.razor`:

```razor
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="AspNetCoreApp.styles.css" />
    <HeadOutlet />
</head>

<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
</body>

</html>
```

For the `<link>` element in the preceding example, change `AspNetCoreApp` in the stylesheet's file name to match the app's project name. For example, a project named `ContosoApp` uses the `ContosoApp.styles.css` stylesheet file name:

```html
<link rel="stylesheet" href="ContosoApp.styles.css" />
```

Add a `Pages` folder to the `Components` folder to hold routable Razor components.

Add the following `Welcome` component to demonstrate Static Server rendering.

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
  using AspNetCoreApp.Components;
  ```

  In the preceding example, change `AspNetCoreApp` in the namespace to match the app.

* Add Razor component services (`AddRazorComponents`). Add the following line before the line that calls `builder.Build()`):

  ```csharp
  builder.Services.AddRazorComponents();
  ```

* Add [Antiforgery Middleware](xref:blazor/security/index#antiforgery-support) to the request processing pipeline after the call to `UseRouting`. If there are calls to `UseRouting` and `UseEndpoints`, the call to `UseAntiforgery` must go between them. A call to `UseAntiforgery` must be placed after calls to `UseAuthentication` and `UseAuthorization`.

  ```csharp
  app.UseAntiforgery();
  ```

* Add `MapRazorComponents` to the app's request processing pipeline with the `App` component (`App.razor`) specified as the default root component. Place the following code before the the line that calls `app.Run`:

  ```csharp
  app.MapRazorComponents<App>();
  ```

When the app is run, the `Welcome` component is accessed at the `/welcome` endpoint.

### Enable Interactive Server rendering

Follow the guidance in the [Add Static Server Razor component rendering](#add-static-server-razor-component-rendering) section.

Make the following changes in the app's `Program` file:

* Add a call to `AddInteractiveServerComponents` where Razor component services are added with `AddRazorComponents`:

  ```csharp
  builder.Services.AddRazorComponents()
      .AddInteractiveServerComponents();
  ```

* Add a call to `AddInteractiveServerRenderMode` where Razor components are mapped with `MapRazorComponents`:

  ```csharp
  app.MapRazorComponents<App>()
      .AddInteractiveServerRenderMode();
  ```

Add the following `Counter` component to the app that adopts the Interactive Server render mode.

`Components/Pages/Counter.razor`:

```razor
@page "/counter"
@rendermode RenderMode.InteractiveServer

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

### Enable interactive Auto and WebAssembly rendering

Follow the guidance in the [Add Static Server Razor component rendering](#add-static-server-razor-component-rendering) section.

Components using the Auto render mode initially use Interactive Server rendering, but then switch to render on the client after the Blazor bundle has been downloaded and the Blazor runtime activates. Components using the WebAssembly render mode only render interactively on the client after the Blazor bundle is downloaded and the Blazor runtime activates. Keep in mind that when using the Auto or WebAssembly render modes, component code downloaded to the client is ***not*** private. For more information, see <xref:blazor/components/render-modes>.

After deciding which render mode to adopt:

* If you plan to adopt the Auto render mode, follow the guidance in the [Enable Interactive Server rendering](#enable-interactive-server-rendering) section. 
* If you plan to only adopt Interactive WebAssembly rendering, continue without adding Interactive Server rendering.

Add a package reference for the [`Microsoft.AspNetCore.Components.WebAssembly.Server`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server) NuGet package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

<!-- UPDATE 8.0 'Interactivity type' will change to 'Interactive render mode' at RTM -->

Create a donor Blazor Web App to provide assets to the app. Follow the guidance in the <xref:blazor/tooling> article, selecting support for the following template features when generating the Blazor Web App.

For the app's name, use the same name as the ASP.NET Core app, which results in matching app name markup in components and matching namespaces in code. Using the same name/namespace isn't strictly required, as namespaces can be adjusted after assets are moved from the donor app to the ASP.NET Core app. However, time is saved by matching the namespaces at the outset.

Visual Studio:

* For **Interactivity type**, select **Auto (Server and WebAssembly)**.
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
> * `AspNetCoreAppSolution` (top-level solution folder)
>   * `AspNetCoreApp` (original ASP.NET Core project)
>   * `AspNetCoreApp.Client` (`.Client` project folder from the donor Blazor Web App)
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
  dotnet add reference ../AspNetCoreApp.Client/AspNetCoreApp.Client.csproj
  ```

  The preceding command assumes the following:
  
  * The project file name is `AspNetCoreApp.Client.csproj`.
  * The `.Client` project is in a `AspNetCoreApp.Client` folder inside the solution folder. The `.Client` folder is side-by-side with the ASP.NET Core project's folder.
  
  For more information on the `dotnet add reference` command, see [`dotnet add reference` (.NET documentation)](/dotnet/core/tools/dotnet-add-reference).

Make the following changes to the ASP.NET Core app's `Program` file:

* Add Interactive WebAssembly component services with `AddInteractiveWebAssemblyComponents` where Razor component services are added with `AddRazorComponents`.

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

* Add the Interactive WebAssembly render mode (`AddInteractiveWebAssemblyRenderMode`) and additional assemblies for the `.Client` project where Razor components are mapped with `MapRazorComponents`.

  For interactive Auto rendering:

  ```csharp
  app.MapRazorComponents<App>()
      .AddInteractiveServerRenderMode()
      .AddInteractiveWebAssemblyRenderMode()
      .AddAdditionalAssemblies(typeof(AspNetCoreApp.Client._Imports).Assembly);
  ```

  For only Interactive WebAssembly rendering:

  ```csharp
  app.MapRazorComponents<App>()
      .AddInteractiveWebAssemblyRenderMode()
      .AddAdditionalAssemblies(typeof(AspNetCoreApp.Client._Imports).Assembly);
  ```

  In the preceding examples, change `AspNetCoreApp.Client` to match the `.Client` project's namespace.

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

## Use non-routable components in pages or views

Use the following guidance to integrate Razor components into pages and views of an existing Razor Pages or MVC app with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

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

Where services are registered, add services for Razor components and services to support rendering Interactive Server components.

In the `Program` file before the line that builds the app (`builder.Build()`):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

For more information on adding support for Interactive Server and WebAssembly components, see <xref:blazor/components/render-modes>.

In the `Program` file immediately after the call to map Razor Pages (<xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>), call <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> to discover available components and specify the app's root component. By default, the app's root component is the `App` component (`App.razor`). Chain a call to `AddInteractiveInteractiveServerRenderMode` to configure the Server render mode for the app:

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

## Use routable components

Use the following guidance to integrate routable Razor components into an existing Razor Pages or MVC app.

The guidance in this section assumes:

* The title of the app is `Blazor Sample`.
* The namespace of the app is `BlazorSample`.

To support routable Razor components:

Add a `Components` folder to the root folder of the project.

Add an imports file to the `Components` folder with the following content.

`Components/_Imports.razor`:

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using {APP NAMESPACE}
@using {APP NAMESPACE}.Components
```

Change the `{APP NAMESPACE}` placeholder to the namespace of the project. For example:

```razor
@using BlazorSample
@using BlazorSample.Components
```

Add a `Layout` folder to the `Components` folder.

Add a footer component and stylesheet to the `Layout` folder.

`Components/Layout/Footer.razor`:

```razor
<footer class="border-top footer text-muted">
    <div class="container">
        &copy; 2023 - {APP TITLE} - <a href="/privacy">Privacy</a>
    </div>
</footer>
```

In the preceding markup, set the `{APP TITLE}` placeholder to the title of the app. For example:

```html
&copy; 2023 - Blazor Sample - <a href="/privacy">Privacy</a>
```

`Components/Layout/Footer.razor.css`:

```css
.footer {
position: absolute;
bottom: 0;
width: 100%;
white-space: nowrap;
line-height: 60px;
}
```

Add a navigation menu component to the `Layout` folder.

`Components/Layout/NavMenu.razor`:

```razor
<nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
<div class="container">
    <a class="navbar-brand" href="/">{APP TITLE}</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
        <ul class="navbar-nav flex-grow-1">
            <li class="nav-item">
                <a class="nav-link text-dark" href="/">Home</a>
            </li>
            <li class="nav-item">
                <a class="nav-link text-dark" href="/privacy">Privacy</a>
            </li>
            <li class="nav-item">
                <a class="nav-link text-dark" href="/counter">Counter</a>
            </li>
        </ul>
    </div>
</div>
</nav>
```

In the preceding markup, set the `{APP TITLE}` placeholder to the title of the app. For example:

```html
<a class="navbar-brand" href="/">Blazor Sample</a>
```

`Components/Layout/NavMenu.razor.css`:

```css
a.navbar-brand {
    white-space: normal;
    text-align: center;
    word-break: break-all;
}

a {
    color: #0077cc;
}

.btn-primary {
    color: #fff;
    background-color: #1b6ec2;
    border-color: #1861ac;
}

.nav-pills .nav-link.active, .nav-pills .show > .nav-link {
    color: #fff;
    background-color: #1b6ec2;
    border-color: #1861ac;
}

.border-top {
    border-top: 1px solid #e5e5e5;
}

.border-bottom {
    border-bottom: 1px solid #e5e5e5;
}

.box-shadow {
    box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
}

button.accept-policy {
    font-size: 1rem;
    line-height: inherit;
}
   ```

Add a main layout component and stylesheet to the `Layout` folder.

`Components/Layout/MainLayout.razor`:

```razor
@inherits LayoutComponentBase

<header>
    <NavMenu />
</header>

<div class="container">
    <main role="main" class="pb-3">
        @Body
    </main>
</div>

<Footer />

<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

`Components/Layout/MainLayout.razor.css`:

```css
#blazor-error-ui {
    background: lightyellow;
    bottom: 0;
    box-shadow: 0 -1px 2px rgba(0, 0, 0, 0.2);
    display: none;
    left: 0;
    padding: 0.6rem 1.25rem 0.7rem 1.25rem;
    position: fixed;
    width: 100%;
    z-index: 1000;
}

    #blazor-error-ui .dismiss {
        cursor: pointer;
        position: absolute;
        right: 0.75rem;
        top: 0.5rem;
    }
```

Add a `Routes` component to the `Components` folder with the following content.

`Components/Routes.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(Layout.MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
</Router>
```

Add an `App` component to the `Components` folder with the following content.

`Components/App.razor`:

```razor
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>{APP TITLE}</title>
    <link rel="stylesheet" href="/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/css/site.css" />
    <link rel="stylesheet" href="/{APP NAMESPACE}.styles.css" />
    <HeadOutlet />
</head>
<body>
    <Routes />
    <script src="/lib/jquery/dist/jquery.min.js"></script>
    <script src="/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="/js/site.js"></script>
    <script src="_framework/blazor.web.js"></script>
</body>
</html>
```

In the preceding code update the app title and stylesheet file name:

* For the `{APP TITLE}` placeholder in the `<title>` element, set the app's title. For example:

  ```html
  <title>Blazor Sample</title>
  ```

* For the `{APP NAMESPACE}` placeholder in the stylesheet `<link>` element, set the app's namespace. For example:

  ```html
  <link rel="stylesheet" href="/BlazorSample.styles.css" />
  ```

Where services are registered, add services for Razor components and services to support rendering Interactive Server components.

In the `Program` file before the line that builds the app (`builder.Build()`):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

For more information on adding support for Interactive Server and WebAssembly components, see <xref:blazor/components/render-modes>.

In the `Program` file immediately after the call to map Razor Pages (<xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>), call <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> to discover available components and specify the app's root component. By default, the app's root component is the `App` component (`App.razor`). Chain a call to `AddInteractiveInteractiveServerRenderMode` to configure the Server render mode for the app:

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

Create a `Pages` folder in the `Components` folder for routable components. The following example is a `Counter` component based on the `Counter` component in the Blazor project templates.

`Components/Pages/Counter.razor`:

```razor
@page "/counter"
@rendermode RenderMode.InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

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

Run the project and navigate to the routable `Counter` component at `/counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Return a `RazorComponentResult` from an MVC controller action

An MVC controller action can return a component with `RazorComponentResult`.

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

