---
title: ASP.NET Core Blazor hosting model configuration
author: guardrex
description: Learn about Blazor hosting model configuration, including how to integrate Razor components into Razor Pages and MVC apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/04/2020
no-loc: [Blazor, SignalR]
uid: blazor/hosting-model-configuration
---
# ASP.NET Core Blazor hosting model configuration

By [Daniel Roth](https://github.com/danroth27)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

This article covers hosting model configuration.

<!-- For future use:

## Blazor WebAssembly

-->

## Blazor Server

### Integrate Razor components into Razor Pages and MVC apps

#### Use components in pages and views

An existing Razor Pages or MVC app can integrate Razor components into pages and views:

1. In the app's layout file (*_Layout.cshtml*):

   * Add the following `<base>` tag to the `<head>` element:

     ```html
     <base href="~/" />
     ```

     The `href` value (the *app base path*) in the preceding example assumes that the app resides at the root URL path (`/`). If the app is a sub-application, follow the guidance in the *App base path* section of the <xref:host-and-deploy/blazor/index#app-base-path> article.

     The *_Layout.cshtml* file is located in the *Pages/Shared* folder in a Razor Pages app or *Views/Shared* folder in an MVC app.

   * Add a `<script>` tag for the *blazor.server.js* script inside of the closing `</body>` tag:

     ```html
     <script src="_framework/blazor.server.js"></script>
     ```

     The framework adds the *blazor.server.js* script to the app. There's no need to manually add the script to the app.

1. Add an *_Imports.razor* file to the root folder of the project with the following content (change the last namespace, `MyAppNamespace`, to the namespace of the app):

   ```csharp
   @using System.Net.Http
   @using Microsoft.AspNetCore.Authorization
   @using Microsoft.AspNetCore.Components.Authorization
   @using Microsoft.AspNetCore.Components.Forms
   @using Microsoft.AspNetCore.Components.Routing
   @using Microsoft.AspNetCore.Components.Web
   @using Microsoft.JSInterop
   @using MyAppNamespace
   ```

1. In `Startup.ConfigureServices`, add the Blazor Server service:

   ```csharp
   services.AddServerSideBlazor();
   ```

1. In `Startup.Configure`, add the Blazor Hub endpoint to `app.UseEndpoints`:

   ```csharp
   endpoints.MapBlazorHub();
   ```

1. Integrate components into any page or view. For more information, see the *Integrate components into Razor Pages and MVC apps* section of the <xref:blazor/components#integrate-components-into-razor-pages-and-mvc-apps> article.

#### Use routable components in a Razor Pages app

To support routable Razor components in Razor Pages apps:

1. Follow the guidance in the [Use components in pages and views](#use-components-in-pages-and-views) section.

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

   When using a custom folder to hold the app's components, add the namespace representing the folder to the *Pages/_ViewImports.cshtml* file. For more information, see <xref:blazor/components#integrate-components-into-razor-pages-and-mvc-apps>.

#### Use routable components in an MVC app

To support routable Razor components in MVC apps:

1. Follow the guidance in the [Use components in pages and views](#use-components-in-pages-and-views) section.

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

   When using a custom folder to hold the app's components, add the namespace representing the folder to the *Views/_ViewImports.cshtml* file. For more information, see <xref:blazor/components#integrate-components-into-razor-pages-and-mvc-apps>.

### Reflect the connection state in the UI

When the client detects that the connection has been lost, a default UI is displayed to the user while the client attempts to reconnect. If reconnection fails, the user is provided the option to retry.

To customize the UI, define an element with an `id` of `components-reconnect-modal` in the `<body>` of the *_Host.cshtml* Razor page:

```cshtml
<div id="components-reconnect-modal">
    ...
</div>
```

The following table describes the CSS classes applied to the `components-reconnect-modal` element.

| CSS class                       | Indicates&hellip; |
| ------------------------------- | ----------------- |
| `components-reconnect-show`     | A lost connection. The client is attempting to reconnect. Show the modal. |
| `components-reconnect-hide`     | An active connection is re-established to the server. Hide the modal. |
| `components-reconnect-failed`   | Reconnection failed, probably due to a network failure. To attempt reconnection, call `window.Blazor.reconnect()`. |
| `components-reconnect-rejected` | Reconnection rejected. The server was reached but refused the connection, and the user's state on the server is lost. To reload the app, call `location.reload()`. This connection state may result when:<ul><li>A crash in the server-side circuit occurs.</li><li>The client is disconnected long enough for the server to drop the user's state. Instances of the components that the user is interacting with are disposed.</li><li>The server is restarted, or the app's worker process is recycled.</li></ul> |

### Render mode

Blazor Server apps are set up by default to prerender the UI on the server before the client connection to the server is established. This is set up in the *_Host.cshtml* Razor page:

```cshtml
<body>
    <app>
      <component type="typeof(App)" render-mode="ServerPrerendered" />
    </app>

    <script src="_framework/blazor.server.js"></script>
</body>
```

`RenderMode` configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

| `RenderMode`        | Description |
| ------------------- | ----------- |
| `ServerPrerendered` | Renders the component into static HTML and includes a marker for a Blazor Server app. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Server`            | Renders a marker for a Blazor Server app. Output from the component isn't included. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Static`            | Renders the component into static HTML. |

Rendering server components from a static HTML page isn't supported.

### Render stateful interactive components from Razor pages and views

Stateful interactive components can be added to a Razor page or view.

When the page or view renders:

* The component is prerendered with the page or view.
* The initial component state used for prerendering is lost.
* New component state is created when the SignalR connection is established.

The following Razor page renders a `Counter` component:

```cshtml
<h1>My Razor Page</h1>

<component type="typeof(Counter)" render-mode="ServerPrerendered" 
    param-InitialValue="InitialValue" />

@code {
    [BindProperty(SupportsGet=true)]
    public int InitialValue { get; set; }
}
```

### Render noninteractive components from Razor pages and views

In the following Razor page, the `Counter` component is statically rendered with an initial value that's specified using a form:

```cshtml
<h1>My Razor Page</h1>

<form>
    <input type="number" asp-for="InitialValue" />
    <button type="submit">Set initial value</button>
</form>

<component type="typeof(Counter)" render-mode="Static" 
    param-InitialValue="InitialValue" />

@code {
    [BindProperty(SupportsGet=true)]
    public int InitialValue { get; set; }
}
```

Since `MyComponent` is statically rendered, the component can't be interactive.

### Configure the SignalR client for Blazor Server apps

Sometimes, you need to configure the SignalR client used by Blazor Server apps. For example, you might want to configure logging on the SignalR client to diagnose a connection issue.

To configure the SignalR client in the *Pages/_Host.cshtml* file:

* Add an `autostart="false"` attribute to the `<script>` tag for the `blazor.server.js` script.
* Call `Blazor.start` and pass in a configuration object that specifies the SignalR builder.

```html
<script src="_framework/blazor.server.js" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      builder.configureLogging("information"); // LogLevel.Information
    }
  });
</script>
```
