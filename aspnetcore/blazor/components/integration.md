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

* [Add static server Razor component rendering](#add-static-server-razor-component-rendering)
* [Enable interactive server rendering](#enable-interactive-server-rendering)
<!-- * [Enable interactive Auto or WebAssembly rendering](#enable-interactive-auto-or-webassembly-rendering) -->

> [!NOTE]
> For the examples in this section, the example app's name and namespace is `AspNetCoreApp`.

### Add static server Razor component rendering

Add the following assets to the app, updating the `{APP NAMESPACE}` to the app's namespace as each file is added.

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

`Components/App.razor`:

```razor
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="{APP NAMESPACE}.styles.css" />
    <HeadOutlet />
</head>

<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
</body>

</html>
```

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

In the ASP.NET Core project's `Program` file, add a `using` statement to the top of the file for the project's components:

```csharp
using {APP NAMESPACE}.Components;
```

Add Razor component services (`AddRazorComponents`) before the app is built (the line that calls `builder.Build()`):

```csharp
builder.Services.AddRazorComponents();
```

Add [Antiforgery Middleware](xref:blazor/security/index#antiforgery-support) to the request processing pipeline after the call to `app.UseRouting`. If there are calls to `app.UseRouting` and `app.UseEndpoints`, the call to `app.UseAntiforgery` must go between them. A call to `app.UseAntiforgery` must be placed after calls to `app.UseAuthentication` and `app.UseAuthorization`.

```csharp
app.UseAntiforgery();
```

Add `MapRazorComponents` to the app's request processing pipeline with the `App` component (`App.razor`) specified as the default root component. Place the following code before the app is run (the line that calls `app.Run`):

```csharp
app.MapRazorComponents<App>();
```

When the app is run, the `Welcome` component is accessed at the `/welcome` endpoint.

### Enable interactive server rendering

Follow the guidance in the [Add static server Razor component rendering](#add-static-server-razor-component-rendering) section.

Make the following changes in the app's `Program` file.

Add a call to `AddInteractiveServerComponents` where Razor component services are added with `AddRazorComponents`:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

Add a call to `AddInteractiveServerRenderMode` where Razor components are mapped with `MapRazorComponents`:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

Add a `Counter` component to the app with the interactive server render mode.

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

When the app is run, the `Counter` component is accessed at the `/counter` endpoint.



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

Where services are registered, add services for Razor components and services to support rendering interactive server components.

In the `Program` file before the line that builds the app (`builder.Build()`):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

For more information on adding support for server and WebAssembly components, see <xref:blazor/components/render-modes>.

<!-- UPDATE 8.0 Update API cross-link -->

In the `Program` file immediately after the call to map Razor Pages (<xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>), call <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> to discover available components and specify the app's root component. By default, the app's root component is the `App` component (`App.razor`). Chain a call to `AddInteractiveInteractiveServerRenderMode` <!-- <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointConventionBuilder.AddInteractiveInteractiveServerRenderMode%2A> --> to configure the Server render mode for the app:

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

Where services are registered, add services for Razor components and services to support rendering interactive server components.

In the `Program` file before the line that builds the app (`builder.Build()`):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

For more information on adding support for server and WebAssembly components, see <xref:blazor/components/render-modes>.

<!-- UPDATE 8.0 Update API cross-link -->

In the `Program` file immediately after the call to map Razor Pages (<xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>), call <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> to discover available components and specify the app's root component. By default, the app's root component is the `App` component (`App.razor`). Chain a call to `AddInteractiveInteractiveServerRenderMode` <!-- <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointConventionBuilder.AddInteractiveInteractiveServerRenderMode%2A> --> to configure the Server render mode for the app:

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

