---
title: Integrate ASP.NET Core Razor components into Razor Pages and MVC apps
author: guardrex
description: Learn about data binding scenarios for components and DOM elements in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/12/2020
no-loc: [Blazor, SignalR]
uid: blazor/integrate-components
---
# Integrate ASP.NET Core Razor components into Razor Pages and MVC apps

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

Razor components can be integrated into Razor Pages and MVC apps. When the page or view is rendered, components can be prerendered at the same time.

## Prepare the app to use components in pages and views

An existing Razor Pages or MVC app can integrate Razor components into pages and views:

1. In the app's layout file (*_Layout.cshtml*):

   * Add the following `<base>` tag to the `<head>` element:

     ```html
     <base href="~/" />
     ```

     The `href` value (the *app base path*) in the preceding example assumes that the app resides at the root URL path (`/`). If the app is a sub-application, follow the guidance in the *App base path* section of the <xref:host-and-deploy/blazor/index#app-base-path> article.

     The *_Layout.cshtml* file is located in the *Pages/Shared* folder in a Razor Pages app or *Views/Shared* folder in an MVC app.

   * Add a `<script>` tag for the *blazor.server.js* script immediately before of the closing `</body>` tag:

     ```html
     <script src="_framework/blazor.server.js"></script>
     ```

     The framework adds the *blazor.server.js* script to the app. There's no need to manually add the script to the app.

1. Add an *_Imports.razor* file to the root folder of the project with the following content (change the last namespace, `MyAppNamespace`, to the namespace of the app):

   ```razor
   @using System.Net.Http
   @using Microsoft.AspNetCore.Authorization
   @using Microsoft.AspNetCore.Components.Authorization
   @using Microsoft.AspNetCore.Components.Forms
   @using Microsoft.AspNetCore.Components.Routing
   @using Microsoft.AspNetCore.Components.Web
   @using Microsoft.JSInterop
   @using MyAppNamespace
   ```

1. In `Startup.ConfigureServices`, register the Blazor Server service:

   ```csharp
   services.AddServerSideBlazor();
   ```

1. In `Startup.Configure`, add the Blazor Hub endpoint to `app.UseEndpoints`:

   ```csharp
   endpoints.MapBlazorHub();
   ```

1. Integrate components into any page or view. For more information, see the [Render components from a page or view](#render-components-from-a-page-or-view) section.

## Use routable components in a Razor Pages app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in Razor Pages apps:

1. Follow the guidance in the [Prepare the app to use components in pages and views](#prepare-the-app-to-use-components-in-pages-and-views) section.

1. Add an *App.razor* file to the project root with the following content:

   ```razor
   @using Microsoft.AspNetCore.Components.Routing

   <Router AppAssembly="typeof(Program).Assembly">
       <Found Context="routeData">
           <RouteView RouteData="routeData" />
       </Found>
       <NotFound>
           <h1>Page not found</h1>
           <p>Sorry, but there's nothing here!</p>
       </NotFound>
   </Router>
   ```

1. Add a *_Host.cshtml* file to the *Pages* folder with the following content:

   ```cshtml
   @page "/blazor"
   @{
       Layout = "_Layout";
   }

   <app>
       <component type="typeof(App)" render-mode="ServerPrerendered" />
   </app>
   ```

   Components use the shared *_Layout.cshtml* file for their layout.

1. Add a low-priority route for the *_Host.cshtml* page to endpoint configuration in `Startup.Configure`:

   ```csharp
   app.UseEndpoints(endpoints =>
   {
       ...

       endpoints.MapFallbackToPage("/_Host");
   });
   ```

1. Add routable components to the app. For example:

   ```razor
   @page "/counter"

   <h1>Counter</h1>

   ...
   ```

   For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Use routable components in an MVC app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in MVC apps:

1. Follow the guidance in the [Prepare the app to use components in pages and views](#prepare-the-app-to-use-components-in-pages-and-views) section.

1. Add an *App.razor* file to the root of the project with the following content:

   ```razor
   @using Microsoft.AspNetCore.Components.Routing

   <Router AppAssembly="typeof(Program).Assembly">
       <Found Context="routeData">
           <RouteView RouteData="routeData" />
       </Found>
       <NotFound>
           <h1>Page not found</h1>
           <p>Sorry, but there's nothing here!</p>
       </NotFound>
   </Router>
   ```

1. Add a *_Host.cshtml* file to the *Views/Home* folder with the following content:

   ```cshtml
   @{
       Layout = "_Layout";
   }

   <app>
       <component type="typeof(App)" render-mode="ServerPrerendered" />
   </app>
   ```

   Components use the shared *_Layout.cshtml* file for their layout.

1. Add an action to the Home controller:

   ```csharp
   public IActionResult Blazor()
   {
      return View("_Host");
   }
   ```

1. Add a low-priority route for the controller action that returns the *_Host.cshtml* view to the endpoint configuration in `Startup.Configure`:

   ```csharp
   app.UseEndpoints(endpoints =>
   {
       ...

       endpoints.MapFallbackToController("Blazor", "Home");
   });
   ```

1. Create a *Pages* folder and add routable components to the app. For example:

   ```razor
   @page "/counter"

   <h1>Counter</h1>

   ...
   ```

   For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Component namespaces

When using a custom folder to hold the app's components, add the namespace representing the folder to either the page/view or to the *_ViewImports.cshtml* file. In the following example:

* Change `MyAppNamespace` to the app's namespace.
* If a folder named *Components* isn't used to hold the components, change `Components` to the folder where the components reside.

```cshtml
@using MyAppNamespace.Components
```

The *_ViewImports.cshtml* file is located in the *Pages* folder of a Razor Pages app or the *Views* folder of an MVC app.

For more information, see <xref:blazor/components#import-components>.

## Render components from a page or view

*This section pertains to adding components to pages or views, where the components aren't directly routable from user requests.*

To render a component from a page or view, use the `Component` Tag Helper:

```cshtml
<component type="typeof(Counter)" render-mode="ServerPrerendered" 
    param-IncrementAmount="10" />
```

The parameter type must be JSON serializable, which typically means that the type must have a default constructor and settable properties. For example, you can specify a value for `IncrementAmount` because the type of `IncrementAmount` is an `int`, which is a primitive type supported by the JSON serializer.

`RenderMode` configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

| `RenderMode`        | Description |
| ------------------- | ----------- |
| `ServerPrerendered` | Renders the component into static HTML and includes a marker for a Blazor Server app. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Server`            | Renders a marker for a Blazor Server app. Output from the component isn't included. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Static`            | Renders the component into static HTML. |

While pages and views can use components, the converse isn't true. Components can't use view- and page-specific scenarios, such as partial views and sections. To use logic from partial view in a component, factor out the partial view logic into a component.

Rendering server components from a static HTML page isn't supported.

For more information on how components are rendered, component state, and the `Component` Tag Helper, see the following articles:

* <xref:blazor/hosting-models>
* <xref:blazor/hosting-model-configuration>
