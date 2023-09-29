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

<!--
[!INCLUDE[](~/includes/not-latest-version.md)]
-->

> [!WARNING]
> Guidance in this document pertains to the ***Release Candidate 2*** of .NET 8, which is targeted for release on October 10.

This article explains Razor component integration scenarios for ASP.NET Core apps, including prerendering of Razor components on the server.

Razor components can be integrated into Razor Pages and MVC apps. When the page or view is rendered, components can be prerendered at the same time. Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

Use the guidance in the following sections depending on the project's requirements:

* For interactive components that aren't directly routable from user requests, see the [Use non-routable components in pages or views](#use-non-routable-components-in-pages-or-views) section. Follow this guidance when the app embeds components into existing pages and views with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).
* For interactive components that are directly routable from user requests, see the [Use routable components](#use-routable-components) section. Follow this guidance when visitors should be able to make an HTTP request in their browser for a component with an [`@page`](xref:mvc/views/razor#page) directive.

## Use non-routable components in pages or views

Use the following guidance to integrate Razor components into pages and views of an existing Razor Pages or MVC app.

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

* Add the following `<base>` tag and <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component via a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to the `<head>` element:

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

  The framework adds the `blazor.web.js` script to the app. There's no need to manually add a `blazor.web.js` script file to the app.

> [!NOTE]
> Typically, the layout loads via a `_ViewStart.cshtml` file.

In the `Program` file where services are registered before the line that builds the app (`builder.Build()`), add services for Razor components and services to support rendering interactive server components:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

<!-- UPDATE 8.0 Update API cross-link -->

In the `Program` file immediately after the call to map Razor Pages (<xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>), call <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> in the middleware processing pipeline to discover available components and specify the root component for the app, which by default is the `App` component (`App.razor`). Chain a call to `AddInteractiveServerRenderMode` <!-- <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointConventionBuilder.AddInteractiveServerRenderMode%2A> --> to configure the Server render mode for the app:

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

To support routable Razor components:

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

Add a `Layout` folder to the `Components` folder.

Add a footer component and stylesheet.

`Components/Layout/Footer.razor`:

```razor
<footer class="border-top footer text-muted">
    <div class="container">
        &copy; 2023 - {APP TITLE} - <a href="/privacy">Privacy</a>
    </div>
</footer>
```

In the preceding markup, set the `{APP TITLE}` placeholder to the title of the app.

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

Add a navigation menu component.

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

In the preceding markup, set the `{APP TITLE}` placeholder to the title of the app.

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

Add a main layout component and stylesheet.

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

> [!IMPORTANT]
> The page title and stylesheet of routable components doesn't currently flow from the app and must be set manually:
>
> * For the `{APP TITLE}` placeholder in the `<title>` element, set the app title.
> * For the `{APP NAMESPACE}` placeholder in the stylesheet `<link>` element, set the app's namespace.

In the `Program` file where services are registered before the line that builds the app (`builder.Build()`), add services for Razor components and services to support rendering interactive server components:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

<!-- UPDATE 8.0 Update API cross-link -->

In the `Program` file immediately after the call to map Razor Pages (<xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>) or map controller routes (<xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>), call <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> in the middleware processing pipeline to discover available components and specify the root component for the app, which by default is the `App` component (`App.razor`). Chain a call to `AddInteractiveServerRenderMode` <!-- <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointConventionBuilder.AddInteractiveServerRenderMode%2A> --> to configure the Server render mode for the app:

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

Create a `Pages` folder in the `Components` folder for routable components. The following example is a `RoutableCounter` component based on the `Counter` component in the Blazor project templates.

`Components/Pages/Counter.razor`:

```razor
@page "/counter"
@attribute [RenderModeInteractiveServer]

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

### Render stateful interactive components

Stateful interactive components can be added to a Razor page or view.

When the page or view renders:

* The component is prerendered with the page or view.
* The initial component state used for prerendering is lost.
* New component state is created when the SignalR connection is established.

The following Razor page renders a `Counter` component:

```cshtml
<h1>Razor Page</h1>

<component type="typeof(Counter)" render-mode="ServerPrerendered" 
    param-InitialValue="InitialValue" />

@functions {
    [BindProperty(SupportsGet=true)]
    public int InitialValue { get; set; }
}
```

For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

### Render noninteractive components

In the following Razor page, the `Counter` component is statically rendered with an initial value that's specified using a form. Since the component is statically rendered, the component isn't interactive:

```cshtml
<h1>Razor Page</h1>

<form>
    <input type="number" asp-for="InitialValue" />
    <button type="submit">Set initial value</button>
</form>

<component type="typeof(Counter)" render-mode="Static" 
    param-InitialValue="InitialValue" />

@functions {
    [BindProperty(SupportsGet=true)]
    public int InitialValue { get; set; }
}
```

For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

## Component namespaces

When using a custom folder to hold the project's Razor components, add the namespace representing the folder to either the page/view or to the `_ViewImports.cshtml` file. In the following example:

* Components are stored in the `Components` folder of the project.
* The `{APP NAMESPACE}` placeholder is the project's namespace. `Components` represents the name of the folder.

```cshtml
@using {APP NAMESPACE}.Components
```

The `_ViewImports.cshtml` file is located in the `Pages` folder of a Razor Pages app or the `Views` folder of an MVC app.

For more information, see <xref:blazor/components/index#class-name-and-namespace>.

<!-- UPDATE 8.0 This content will cross-link the section 
                of the same name in the Prerendering article. 

## Persist prerendered state

-->

## Additional resources

<xref:blazor/components/prerender>

