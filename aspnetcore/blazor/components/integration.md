---
title: Integrate ASP.NET Core Razor components with MVC or Razor Pages
author: guardrex
description: Learn about Razor component integration scenarios for MVC or Razor Pages, including prerendering of Razor components on the server.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/components/integration
---
# Integrate ASP.NET Core Razor components with MVC or Razor Pages

[!INCLUDE[](~/includes/not-latest-version.md)]

Razor components can be integrated into Razor Pages or MVC apps. When the page or view is rendered, components can be prerendered at the same time.

> [!IMPORTANT]
> Framework changes across ASP.NET Core releases led to different sets of instructions in this article. Before using this article's guidance, confirm that the document version selector at the top of this article matches the version of ASP.NET Core that you intend to use for your app.

:::moniker range=">= aspnetcore-7.0"

Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

After [configuring the project](#configuration), use the guidance in the following sections depending on the project's requirements:

* For components that are directly routable from user requests. Follow this guidance when visitors should be able to make an HTTP request in their browser for a component with an [`@page`](xref:mvc/views/razor#page) directive.
  * [Use routable components in a Razor Pages app](#use-routable-components-in-a-razor-pages-app)
  * [Use routable components in an MVC app](#use-routable-components-in-an-mvc-app)
* For components that aren't directly routable from user requests, see the [Render components from a page or view](#render-components-from-a-page-or-view) section. Follow this guidance when the app embeds components into existing pages or views with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

## Configuration

Use the following guidance to integrate Razor components into pages or views of an existing Razor Pages or MVC app.

1. Add an imports file to the root folder of the project with the following content. Change the `{APP NAMESPACE}` placeholder to the namespace of the project.

   `_Imports.razor`:

   ```razor
   @using System.Net.Http
   @using Microsoft.AspNetCore.Authorization
   @using Microsoft.AspNetCore.Components.Authorization
   @using Microsoft.AspNetCore.Components.Forms
   @using Microsoft.AspNetCore.Components.Routing
   @using Microsoft.AspNetCore.Components.Web
   @using Microsoft.AspNetCore.Components.Web.Virtualization
   @using Microsoft.JSInterop
   @using {APP NAMESPACE}
   ```

1. In the project's layout file (`Pages/Shared/_Layout.cshtml` in Razor Pages apps or `Views/Shared/_Layout.cshtml` in MVC apps):

   * Add the following `<base>` tag and <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component Tag Helper to the `<head>` element:

     ```cshtml
     <base href="~/" />
     <component type="typeof(Microsoft.AspNetCore.Components.Web.HeadOutlet)" 
         render-mode="ServerPrerendered" />
     ```

     The `href` value (the *app base path*) in the preceding example assumes that the app resides at the root URL path (`/`). If the app is a sub-application, follow the guidance in the *App base path* section of the <xref:blazor/host-and-deploy/index#app-base-path> article.

     The <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is used to render head (`<head>`) content for page titles (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component) set by Razor components. For more information, see <xref:blazor/components/control-head-content>.

   * Add a `<script>` tag for the `blazor.server.js` script immediately before the `Scripts` render section (`@await RenderSectionAsync(...)`):

     ```html
     <script src="_framework/blazor.server.js"></script>
     ```

     The framework adds the `blazor.server.js` script to the app. There's no need to manually add a `blazor.server.js` script file to the app.

   > [!NOTE]
   > Typically, the layout loads via a `_ViewStart.cshtml` file.

1. Register the Blazor Server services in `Program.cs` where services are registered:

   ```csharp
   builder.Services.AddServerSideBlazor();
   ```

1. Add the Blazor Hub endpoint to the endpoints of `Program.cs` where routes are mapped. Place the following line after the call to `MapRazorPages` (Razor Pages) or `MapControllerRoute` (MVC):

   ```csharp
   app.MapBlazorHub();
   ```

1. Integrate components into any page or view. For example, add a `Counter` component to the project's `Shared` folder.

   `Pages/Shared/Counter.razor` (Razor Pages) or `Views/Shared/Counter.razor` (MVC):

   ```razor
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

   **Razor Pages**:

   In the project's `Index` page of a Razor Pages app, add the `Counter` component's namespace and embed the component into the page. When the `Index` page loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Pages/Index.cshtml`:

   ```cshtml
   @page
   @using {APP NAMESPACE}.Pages.Shared
   @model IndexModel
   @{
       ViewData["Title"] = "Home page";
   }

   <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   ```

   **MVC**:

   In the project's `Index` view of an MVC app, add the `Counter` component's namespace and embed the component into the view. When the `Index` view loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Views/Home/Index.cshtml`:

   ```cshtml
   @using {APP NAMESPACE}.Views.Shared
   @{
       ViewData["Title"] = "Home Page";
   }

   <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   ```

For more information, see the [Render components from a page or view](#render-components-from-a-page-or-view) section.

## Use routable components in a Razor Pages app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in Razor Pages apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

   ```razor
   @using Microsoft.AspNetCore.Components.Routing

   <Router AppAssembly="typeof(App).Assembly">
       <Found Context="routeData">
           <RouteView RouteData="routeData" />
       </Found>
       <NotFound>
           <PageTitle>Not found</PageTitle>
           <p role="alert">Sorry, there's nothing at this address.</p>
       </NotFound>
   </Router>
   ```

1. Add a `_Host` page to the project with the following content. Replace the `{APP NAMESPACE}` placeholder with the app's namespace.

   `Pages/_Host.cshtml`:

   ```cshtml
   @page
   @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

   <component type="typeof(App)" render-mode="ServerPrerendered" />
   ```

   > [!NOTE]
   > The preceding example assumes that the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component and Blazor script (`_framework/blazor.server.js`) are rendered by the app's layout. For more information, see the [Configuration](#configuration) section.
  
   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. In the `Program.cs` endpoints, add a low-priority route for the `_Host` page as the last endpoint:

   ```csharp
   app.MapFallbackToPage("/_Host");
   ```

1. Add routable components to the project. The following example is a `RoutableCounter` component based on the `Counter` component in the Blazor project templates.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <PageTitle>Routable Counter</PageTitle>

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Use routable components in an MVC app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in MVC apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

   ```razor
   @using Microsoft.AspNetCore.Components.Routing

   <Router AppAssembly="typeof(App).Assembly">
       <Found Context="routeData">
           <RouteView RouteData="routeData" />
       </Found>
       <NotFound>
           <PageTitle>Not found</PageTitle>
           <p role="alert">Sorry, there's nothing at this address.</p>
       </NotFound>
   </Router>
   ```

1. Add a `_Host` view to the project with the following content. Replace the `{APP NAMESPACE}` placeholder with the app's namespace.

   `Views/Home/_Host.cshtml`:

   ```cshtml
   @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

   <component type="typeof(App)" render-mode="ServerPrerendered" />
   ```

   > [!NOTE]
   > The preceding example assumes that the <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component and Blazor script (`_framework/blazor.server.js`) are rendered by the app's layout. For more information, see the [Configuration](#configuration) section.

   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. Add an action to the Home controller.

   `Controllers/HomeController.cs`:

   ```csharp
   public IActionResult Blazor()
   {
      return View("_Host");
   }
   ```

1. In the `Program.cs` endpoints, add a low-priority route for the controller action that returns the `_Host` view:

   ```csharp
   app.MapFallbackToController("Blazor", "Home");
   ```

1. Create a `Pages` folder in the MVC app and add routable components. The following example is a `RoutableCounter` component based on the `Counter` component in the Blazor project templates.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <PageTitle>Routable Counter</PageTitle>

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Render components from a page or view

*This section pertains to adding components to pages or views, where the components aren't directly routable from user requests.*

To render a component from a page or view, use the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

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

## Persist prerendered state

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is setup asynchronously, the UI may flicker as the prerendered UI is replaced with temporary placeholders and then fully rendered again.

To persist state for prerendered components, use the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.TagHelpers/src/PersistComponentStateTagHelper.cs)). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag of the `_Host` page in an app that prerenders components.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

In `Pages/_Host.cshtml` of Blazor apps that are `ServerPrerendered` in a Blazor Server app:

```cshtml
<body>
    ...

    <persist-component-state />
</body>
```

Decide what state to persist using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. [`PersistentComponentState.RegisterOnPersisting`](xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting%2A) registers a callback to persist the component state before the app is paused. The state is retrieved when the application resumes.

In the following example:

* The `{TYPE}` placeholder represents the type of data to persist (for example, `WeatherForecast[]`).
* The `{TOKEN}` placeholder is a state identifier string (for example, `fetchdata`).

```razor
@implements IDisposable
@inject PersistentComponentState ApplicationState

...

@code {
    private {TYPE} data;
    private PersistingComponentStateSubscription persistingSubscription;

    protected override async Task OnInitializedAsync()
    {
        persistingSubscription = 
            ApplicationState.RegisterOnPersisting(PersistData);

        if (!ApplicationState.TryTakeFromJson<{TYPE}>(
            "{TOKEN}", out var restored))
        {
            data = await ...;
        }
        else
        {
            data = restored!;
        }
    }

    private Task PersistData()
    {
        ApplicationState.PersistAsJson("{TOKEN}", data);

        return Task.CompletedTask;
    }

    void IDisposable.Dispose()
    {
        persistingSubscription.Dispose();
    }
}
```

The following example is an updated version of the `FetchData` component based on the Blazor project template. The `WeatherForecastPreserveState` component persists weather forecast state during prerendering and then retrieves the state to initialize the component. The [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) persists the component state after all component invocations.

`Pages/WeatherForecastPreserveState.razor`:

```razor
@page "/weather-forecast-preserve-state"
@using BlazorSample.Shared
@implements IDisposable
@inject IWeatherForecastService WeatherForecastService
@inject PersistentComponentState ApplicationState

<PageTitle>Weather Forecast</PageTitle>

<h1>Weather forecast</h1>

<p>This component demonstrates fetching data from the server.</p>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var forecast in forecasts)
            {
                <tr>
                    <td>@forecast.Date.ToShortDateString()</td>
                    <td>@forecast.TemperatureC</td>
                    <td>@forecast.TemperatureF</td>
                    <td>@forecast.Summary</td>
                </tr>
            }
        </tbody>
    </table>
}

@code {
    private WeatherForecast[] forecasts = Array.Empty<WeatherForecast>();
    private PersistingComponentStateSubscription persistingSubscription;

    protected override async Task OnInitializedAsync()
    {
        persistingSubscription = 
            ApplicationState.RegisterOnPersisting(PersistForecasts);

        if (!ApplicationState.TryTakeFromJson<WeatherForecast[]>(
            "fetchdata", out var restored))
        {
            forecasts = 
                await WeatherForecastService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
        }
        else
        {
            forecasts = restored!;
        }
    }

    private Task PersistForecasts()
    {
        ApplicationState.PersistAsJson("fetchdata", forecasts);

        return Task.CompletedTask;
    }

    void IDisposable.Dispose()
    {
        persistingSubscription.Dispose();
    }
}
```

By initializing components with the same state used during prerendering, any expensive initialization steps are only executed once. The rendered UI also matches the prerendered UI, so no flicker occurs in the browser.

The persisted prerendered state is transferred to the client, where it's used to restore the component state. [ASP.NET Core Data Protection](xref:security/data-protection/introduction) ensures that the data is transferred securely in Blazor Server apps.

## Prerendered state size and SignalR message size limit

A large prerendered state size may exceed Blazor's SignalR circuit message size limit, which results in the following:

* The SignalR circuit fails to initialize with an error on the client: :::no-loc text="Circuit host not initialized.":::
* The reconnection UI on the client appears when the circuit fails. Recovery isn't possible.

To resolve the problem, use ***either*** of the following approaches:

* Reduce the amount of data that you are putting into the prerendered state.
* Increase the [SignalR message size limit](xref:blazor/fundamentals/signalr#server-side-circuit-handler-options). ***WARNING***: Increasing the limit may increase the risk of Denial of Service (DoS) attacks.

## Additional Blazor Server resources

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering)
* Razor component lifecycle subjects that pertain to prerendering
  * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
  * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
  * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering)
  * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop)
* [Authentication and authorization: General aspects](xref:blazor/security/index#aspnet-core-blazor-authentication-and-authorization)
* [Handle Errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
* [Host and deploy: Blazor Server](xref:blazor/host-and-deploy/server)
* [Threat mitigation: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)
* <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice* when prerendering: [Handle asynchronous navigation events with `OnNavigateAsync`](xref:blazor/fundamentals/routing#handle-asynchronous-navigation-events-with-onnavigateasync)

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

After [configuring the project](#configuration), use the guidance in the following sections depending on the project's requirements:

* Routable components: For components that are directly routable from user requests. Follow this guidance when visitors should be able to make an HTTP request in their browser for a component with an [`@page`](xref:mvc/views/razor#page) directive.
  * [Use routable components in a Razor Pages app](#use-routable-components-in-a-razor-pages-app)
  * [Use routable components in an MVC app](#use-routable-components-in-an-mvc-app)
* [Render components from a page or view](#render-components-from-a-page-or-view): For components that aren't directly routable from user requests. Follow this guidance when the app embeds components into existing pages or views with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

## Configuration

Use the following guidance to integrate Razor components into pages or views of an existing Razor Pages or MVC app.

> [!IMPORTANT]
> The use of a layout page (`_Layout.cshtml`) with a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is required to control `<head>` content, such as the page's title (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component). For more information, see <xref:blazor/components/control-head-content#control-head-content-during-prerendering>.

1. In the project's layout file:

   * Add the following `<base>` tag and <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component Tag Helper to the `<head>` element in `Pages/Shared/_Layout.cshtml` (Razor Pages) or `Views/Shared/_Layout.cshtml` (MVC):

     ```cshtml
     <base href="~/" />
     <component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />
     ```

     The `href` value (the *app base path*) in the preceding example assumes that the app resides at the root URL path (`/`). If the app is a sub-application, follow the guidance in the *App base path* section of the <xref:blazor/host-and-deploy/index#app-base-path> article.
  
     The <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is used to render head (`<head>`) content for page titles (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component) set by Razor components. For more information, see <xref:blazor/components/control-head-content>.

   * Add a `<script>` tag for the `blazor.server.js` script immediately before the `Scripts` render section (`@await RenderSectionAsync(...)`) in the app's layout.

     `Pages/Shared/_Layout.cshtml` (Razor Pages) or `Views/Shared/_Layout.cshtml` (MVC):

     ```html
     <script src="_framework/blazor.server.js"></script>
     ```

     The framework adds the `blazor.server.js` script to the app. There's no need to manually add a `blazor.server.js` script file to the app.

1. Add an imports file to the root folder of the project with the following content. Change the `{APP NAMESPACE}` placeholder to the namespace of the project.

   `_Imports.razor`:

   ```razor
   @using System.Net.Http
   @using Microsoft.AspNetCore.Authorization
   @using Microsoft.AspNetCore.Components.Authorization
   @using Microsoft.AspNetCore.Components.Forms
   @using Microsoft.AspNetCore.Components.Routing
   @using Microsoft.AspNetCore.Components.Web
   @using Microsoft.AspNetCore.Components.Web.Virtualization
   @using Microsoft.JSInterop
   @using {APP NAMESPACE}
   ```

1. Register the Blazor Server services in `Program.cs` where services are registered:

   ```csharp
   builder.Services.AddServerSideBlazor();
   ```

1. Add the Blazor Hub endpoint to the endpoints of `Program.cs` where routes are mapped.

   Place the following line after the call to `MapRazorPages` (Razor Pages) or `MapControllerRoute` (MVC):

   ```csharp
   app.MapBlazorHub();
   ```

1. Integrate components into any page or view. For example, add a `Counter` component to the project's `Shared` folder.

   `Pages/Shared/Counter.razor` (Razor Pages) or `Views/Shared/Counter.razor` (MVC):

   ```razor
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

   **Razor Pages**:

   In the project's `Index` page of a Razor Pages app, add the `Counter` component's namespace and embed the component into the page. When the `Index` page loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Pages/Index.cshtml`:

   ```cshtml
   @page
   @using {APP NAMESPACE}.Pages.Shared
   @model IndexModel
   @{
       ViewData["Title"] = "Home page";
   }

   <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   ```

   **MVC**:

   In the project's `Index` view of an MVC app, add the `Counter` component's namespace and embed the component into the view. When the `Index` view loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Views/Home/Index.cshtml`:

   ```cshtml
   @using {APP NAMESPACE}.Views.Shared
   @{
       ViewData["Title"] = "Home Page";
   }

   <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   ```

For more information, see the [Render components from a page or view](#render-components-from-a-page-or-view) section.

## Use routable components in a Razor Pages app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in Razor Pages apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

   ```razor
   @using Microsoft.AspNetCore.Components.Routing

   <Router AppAssembly="typeof(App).Assembly">
       <Found Context="routeData">
           <RouteView RouteData="routeData" />
       </Found>
       <NotFound>
           <PageTitle>Not found</PageTitle>
           <p role="alert">Sorry, there's nothing at this address.</p>
       </NotFound>
   </Router>
   ```

1. Add a `_Host` page to the project with the following content.

   `Pages/_Host.cshtml`:

   ```cshtml
   @page "/blazor"
   @namespace {APP NAMESPACE}.Pages.Shared
   @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
   @{
       Layout = "_Layout";
   }

   <component type="typeof(App)" render-mode="ServerPrerendered" />
   ```

   In this scenario, components use the shared `_Layout.cshtml` file for their layout.
  
   > [!IMPORTANT]
   > The use of a layout page (`_Layout.cshtml`) with a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is required to control `<head>` content, such as the page's title (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component). For more information, see <xref:blazor/components/control-head-content#control-head-content-during-prerendering>.
  
   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. In the `Program.cs` endpoints, add a low-priority route for the `_Host` page as the last endpoint:

   ```csharp
   app.MapFallbackToPage("/_Host");
   ```

1. Add routable components to the project. The following example is a `RoutableCounter` component based on the `Counter` component in the Blazor project templates.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <PageTitle>Routable Counter</PageTitle>

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Use routable components in an MVC app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in MVC apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

   ```razor
   @using Microsoft.AspNetCore.Components.Routing

   <Router AppAssembly="typeof(App).Assembly">
       <Found Context="routeData">
           <RouteView RouteData="routeData" />
       </Found>
       <NotFound>
           <PageTitle>Not found</PageTitle>
           <p role="alert">Sorry, there's nothing at this address.</p>
       </NotFound>
   </Router>
   ```

1. Add a `_Host` view to the project with the following content.

   `Views/Home/_Host.cshtml`:

   ```cshtml
   @namespace {APP NAMESPACE}.Views.Shared
   @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
   @{
       Layout = "_Layout";
   }

   <component type="typeof(App)" render-mode="ServerPrerendered" />
   ```

   Components use the shared `_Layout.cshtml` file for their layout.
     
   > [!IMPORTANT]
   > The use of a layout page (`_Layout.cshtml`) with a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is required to control `<head>` content, such as the page's title (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component). For more information, see <xref:blazor/components/control-head-content#control-head-content-during-prerendering>.

   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. Add an action to the Home controller.

   `Controllers/HomeController.cs`:

   ```csharp
   public IActionResult Blazor()
   {
      return View("_Host");
   }
   ```

1. In the `Program.cs` endpoints, add a low-priority route for the controller action that returns the `_Host` view:

   ```csharp
   app.MapFallbackToController("Blazor", "Home");
   ```

1. Create a `Pages` folder in the MVC app and add routable components. The following example is a `RoutableCounter` component based on the `Counter` component in the Blazor project templates.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <PageTitle>Routable Counter</PageTitle>

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Render components from a page or view

*This section pertains to adding components to pages or views, where the components aren't directly routable from user requests.*

To render a component from a page or view, use the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

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
     
> [!IMPORTANT]
> The use of a layout page (`_Layout.cshtml`) with a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is required to control `<head>` content, such as the page's title (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component). For more information, see <xref:blazor/components/control-head-content#control-head-content-during-prerendering>.

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
     
> [!IMPORTANT]
> The use of a layout page (`_Layout.cshtml`) with a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is required to control `<head>` content, such as the page's title (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component). For more information, see <xref:blazor/components/control-head-content#control-head-content-during-prerendering>.

## Component namespaces

When using a custom folder to hold the project's Razor components, add the namespace representing the folder to either the page/view or to the `_ViewImports.cshtml` file. In the following example:

* Components are stored in the `Components` folder of the project.
* The `{APP NAMESPACE}` placeholder is the project's namespace. `Components` represents the name of the folder.

```cshtml
@using {APP NAMESPACE}.Components
```

The `_ViewImports.cshtml` file is located in the `Pages` folder of a Razor Pages app or the `Views` folder of an MVC app.

For more information, see <xref:blazor/components/index#class-name-and-namespace>.

## Persist prerendered state

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is setup asynchronously, the UI may flicker as the prerendered UI is replaced with temporary placeholders and then fully rendered again.

To solve these problems, Blazor supports persisting state in a prerendered page using the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag.

`Pages/_Layout.cshtml`:

```cshtml
<body>
    ...

    <persist-component-state />
</body>
```

Decide what state to persist using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. [`PersistentComponentState.RegisterOnPersisting`](xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting%2A) registers a callback to persist the component state before the app is paused. The state is retrieved when the application resumes.

The following example is an updated version of the `FetchData` component based on the Blazor project template. The `WeatherForecastPreserveState` component persists weather forecast state during prerendering and then retrieves the state to initialize the component. The [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) persists the component state after all component invocations.

`Pages/WeatherForecastPreserveState.razor`:

```razor
@page "/weather-forecast-preserve-state"
@implements IDisposable
@using BlazorSample.Shared
@inject IWeatherForecastService WeatherForecastService
@inject PersistentComponentState ApplicationState

<PageTitle>Weather Forecast</PageTitle>

<h1>Weather forecast</h1>

<p>This component demonstrates fetching data from the server.</p>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var forecast in forecasts)
            {
                <tr>
                    <td>@forecast.Date.ToShortDateString()</td>
                    <td>@forecast.TemperatureC</td>
                    <td>@forecast.TemperatureF</td>
                    <td>@forecast.Summary</td>
                </tr>
            }
        </tbody>
    </table>
}

@code {
    private WeatherForecast[] forecasts = Array.Empty<WeatherForecast>();
    private PersistingComponentStateSubscription persistingSubscription;

    protected override async Task OnInitializedAsync()
    {
        persistingSubscription = 
            ApplicationState.RegisterOnPersisting(PersistForecasts);

        if (!ApplicationState.TryTakeFromJson<WeatherForecast[]>(
            "fetchdata", out var restored))
        {
            forecasts = 
                await WeatherForecastService.GetForecastAsync(DateTime.Now);
        }
        else
        {
            forecasts = restored!;
        }
    }

    private Task PersistForecasts()
    {
        ApplicationState.PersistAsJson("fetchdata", forecasts);

        return Task.CompletedTask;
    }

    void IDisposable.Dispose()
    {
        persistingSubscription.Dispose();
    }
}
```

By initializing components with the same state used during prerendering, any expensive initialization steps are only executed once. The rendered UI also matches the prerendered UI, so no flicker occurs in the browser.

The persisted prerendered state is transferred to the client, where it's used to restore the component state. [ASP.NET Core Data Protection](xref:security/data-protection/introduction) ensures that the data is transferred securely in Blazor Server apps.

## Prerendered state size and SignalR message size limit

A large prerendered state size may exceed Blazor's SignalR circuit message size limit, which results in the following:

* The SignalR circuit fails to initialize with an error on the client: :::no-loc text="Circuit host not initialized.":::
* The reconnection UI on the client appears when the circuit fails. Recovery isn't possible.

To resolve the problem, use ***either*** of the following approaches:

* Reduce the amount of data that you are putting into the prerendered state.
* Increase the [SignalR message size limit](xref:blazor/fundamentals/signalr#server-side-circuit-handler-options). ***WARNING***: Increasing the limit may increase the risk of Denial of Service (DoS) attacks.

## Additional Blazor Server resources

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering)
* Razor component lifecycle subjects that pertain to prerendering
  * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
  * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
  * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering)
  * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop)
* [Authentication and authorization: General aspects](xref:blazor/security/index#aspnet-core-blazor-authentication-and-authorization)
* [Handle Errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
* [Host and deploy: Blazor Server](xref:blazor/host-and-deploy/server)
* [Threat mitigation: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

After [configuring the project](#configuration), use the guidance in the following sections depending on the project's requirements:

* Routable components: For components that are directly routable from user requests. Follow this guidance when visitors should be able to make an HTTP request in their browser for a component with an [`@page`](xref:mvc/views/razor#page) directive.
  * [Use routable components in a Razor Pages app](#use-routable-components-in-a-razor-pages-app)
  * [Use routable components in an MVC app](#use-routable-components-in-an-mvc-app)
* [Render components from a page or view](#render-components-from-a-page-or-view): For components that aren't directly routable from user requests. Follow this guidance when the app embeds components into existing pages or views with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

## Configuration

An existing Razor Pages or MVC app can integrate Razor components into pages or views:

1. In the project's layout file:

   * Add the following `<base>` tag to the `<head>` element in `Pages/Shared/_Layout.cshtml` (Razor Pages) or `Views/Shared/_Layout.cshtml` (MVC):

     ```html
     <base href="~/" />
     ```

     The `href` value (the *app base path*) in the preceding example assumes that the app resides at the root URL path (`/`). If the app is a sub-application, follow the guidance in the *App base path* section of the <xref:blazor/host-and-deploy/index#app-base-path> article.

   * Add a `<script>` tag for the `blazor.server.js` script immediately before the `Scripts` render section.

     `Pages/Shared/_Layout.cshtml` (Razor Pages) or `Views/Shared/_Layout.cshtml` (MVC):

     ```cshtml
         ...
         <script src="_framework/blazor.server.js"></script>

         @await RenderSectionAsync("Scripts", required: false)
     </body>
     ```

     The framework adds the `blazor.server.js` script to the app. There's no need to manually add a `blazor.server.js` script file to the app.

1. Add an imports file to the root folder of the project with the following content. Change the `{APP NAMESPACE}` placeholder to the namespace of the project.

   `_Imports.razor`:

   ```razor
   @using System.Net.Http
   @using Microsoft.AspNetCore.Authorization
   @using Microsoft.AspNetCore.Components.Authorization
   @using Microsoft.AspNetCore.Components.Forms
   @using Microsoft.AspNetCore.Components.Routing
   @using Microsoft.AspNetCore.Components.Web
   @using Microsoft.JSInterop
   @using {APP NAMESPACE}
   ```

1. Register the Blazor Server service in `Startup.ConfigureServices`.

   In `Startup.cs`:

   ```csharp
   services.AddServerSideBlazor();
   ```

1. Add the Blazor Hub endpoint to the endpoints (`app.UseEndpoints`) of `Startup.Configure`.

   `Startup.cs`:

   ```csharp
   endpoints.MapBlazorHub();
   ```

1. Integrate components into any page or view. For example, add a `Counter` component to the project's `Shared` folder.

   `Pages/Shared/Counter.razor` (Razor Pages) or `Views/Shared/Counter.razor` (MVC):

   ```razor
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

   **Razor Pages**:

   In the project's `Index` page of a Razor Pages app, add the `Counter` component's namespace and embed the component into the page. When the `Index` page loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Pages/Index.cshtml`:

   ```cshtml
   @page
   @using {APP NAMESPACE}.Pages.Shared
   @model IndexModel
   @{
       ViewData["Title"] = "Home page";
   }

   <div>
       <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   </div>
   ```

   In the preceding example, replace the `{APP NAMESPACE}` placeholder with the app's namespace.

   **MVC**:

   In the project's `Index` view of an MVC app, add the `Counter` component's namespace and embed the component into the view. When the `Index` view loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Views/Home/Index.cshtml`:

   ```cshtml
   @using {APP NAMESPACE}.Views.Shared
   @{
       ViewData["Title"] = "Home Page";
   }

   <div>
       <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   </div>
   ```

For more information, see the [Render components from a page or view](#render-components-from-a-page-or-view) section.

## Use routable components in a Razor Pages app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in Razor Pages apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

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

   [!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

1. Add a `_Host` page to the project with the following content.

   `Pages/_Host.cshtml`:

   ```cshtml
   @page "/blazor"
   @{
       Layout = "_Layout";
   }

   <app>
       <component type="typeof(App)" render-mode="ServerPrerendered" />
   </app>
   ```

   Components use the shared `_Layout.cshtml` file for their layout.

   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. In the `Startup.Configure` endpoints of `Startup.cs`, add a low-priority route for the `_Host` page as the last endpoint:

   ```csharp
   endpoints.MapFallbackToPage("/_Host");
   ```

   The following example shows the added line in a typical app's endpoint configuration:

   ```csharp
   app.UseEndpoints(endpoints =>
   {
       endpoints.MapRazorPages();
       endpoints.MapBlazorHub();
       endpoints.MapFallbackToPage("/_Host");
   });
   ```

1. Add routable components to the project.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Use routable components in an MVC app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in MVC apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

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

   [!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

1. Add a `_Host` view to the project with the following content.

   `Views/Home/_Host.cshtml`:

   ```cshtml
   @{
       Layout = "_Layout";
   }

   <app>
       <component type="typeof(App)" render-mode="ServerPrerendered" />
   </app>
   ```

   Components use the shared `_Layout.cshtml` file for their layout.

   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. Add an action to the Home controller.

   `Controllers/HomeController.cs`:

   ```csharp
   public IActionResult Blazor()
   {
      return View("_Host");
   }
   ```

1. In the `Startup.Configure` endpoints of `Startup.cs`, add a low-priority route for the controller action that returns the `_Host` view:

   ```csharp
   endpoints.MapFallbackToController("Blazor", "Home");
   ```
   
   The following example shows the added line in a typical app's endpoint configuration:

   ```csharp
   app.UseEndpoints(endpoints =>
   {
       endpoints.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");
       endpoints.MapBlazorHub();
       endpoints.MapFallbackToController("Blazor", "Home");
   });
   ```

1. Add routable components to the project.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Render components from a page or view

*This section pertains to adding components to pages or views, where the components aren't directly routable from user requests.*

To render a component from a page or view, use the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

### Render stateful interactive components

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

@functions {
    [BindProperty(SupportsGet=true)]
    public int InitialValue { get; set; }
}
```

For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

### Render noninteractive components

In the following Razor page, the `Counter` component is statically rendered with an initial value that's specified using a form. Since the component is statically rendered, the component isn't interactive:

```cshtml
<h1>My Razor Page</h1>

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

## Prerendered state size and SignalR message size limit

A large prerendered state size may exceed Blazor's SignalR circuit message size limit, which results in the following:

* The SignalR circuit fails to initialize with an error on the client: :::no-loc text="Circuit host not initialized.":::
* The reconnection UI on the client appears when the circuit fails. Recovery isn't possible.

To resolve the problem, use ***either*** of the following approaches:

* Reduce the amount of data that you are putting into the prerendered state.
* Increase the [SignalR message size limit](xref:blazor/fundamentals/signalr#server-side-circuit-handler-options). ***WARNING***: Increasing the limit may increase the risk of Denial of Service (DoS) attacks.

## Additional Blazor Server resources

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering)
* Razor component lifecycle subjects that pertain to prerendering
  * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
  * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
  * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering)
  * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop)
* [Authentication and authorization: General aspects](xref:blazor/security/index#aspnet-core-blazor-authentication-and-authorization)
* [Handle Errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
* [Host and deploy: Blazor Server](xref:blazor/host-and-deploy/server)
* [Threat mitigation: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Razor components can be integrated into Razor Pages or MVC apps. When the page or view is rendered, components can be prerendered at the same time.

Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

After [configuring the project](#configuration), use the guidance in the following sections depending on the project's requirements:

* Routable components: For components that are directly routable from user requests. Follow this guidance when visitors should be able to make an HTTP request in their browser for a component with an [`@page`](xref:mvc/views/razor#page) directive.
  * [Use routable components in a Razor Pages app](#use-routable-components-in-a-razor-pages-app)
  * [Use routable components in an MVC app](#use-routable-components-in-an-mvc-app)
* [Render components from a page or view](#render-components-from-a-page-or-view): For components that aren't directly routable from user requests. Follow this guidance when the app embeds components into existing pages or views with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

## Configuration

An existing Razor Pages or MVC app can integrate Razor components into pages or views:

1. In the project's layout file:

   * Add the following `<base>` tag to the `<head>` element in `Pages/Shared/_Layout.cshtml` (Razor Pages) or `Views/Shared/_Layout.cshtml` (MVC):

     ```diff
     + <base href="~/" />
     ```

     The `href` value (the *app base path*) in the preceding example assumes that the app resides at the root URL path (`/`). If the app is a sub-application, follow the guidance in the *App base path* section of the <xref:blazor/host-and-deploy/index#app-base-path> article.

   * Add a `<script>` tag for the `blazor.server.js` script immediately before the `Scripts` render section.

     `Pages/Shared/_Layout.cshtml` (Razor Pages) or `Views/Shared/_Layout.cshtml` (MVC):

     ```cshtml
         ...
         <script src="_framework/blazor.server.js"></script>

         @await RenderSectionAsync("Scripts", required: false)
     </body>
     ```

     The framework adds the `blazor.server.js` script to the app. There's no need to manually add a `blazor.server.js` script file to the app.

1. Add an imports file to the root folder of the project with the following content. Change the `{APP NAMESPACE}` placeholder to the namespace of the project.

   `_Imports.razor`:

   ```razor
   @using System.Net.Http
   @using Microsoft.AspNetCore.Authorization
   @using Microsoft.AspNetCore.Components.Authorization
   @using Microsoft.AspNetCore.Components.Forms
   @using Microsoft.AspNetCore.Components.Routing
   @using Microsoft.AspNetCore.Components.Web
   @using Microsoft.JSInterop
   @using {APP NAMESPACE}
   ```

1. Register the Blazor Server service in `Startup.ConfigureServices`.

   `Startup.cs`:

   ```csharp
   services.AddServerSideBlazor();
   ```

1. Add the Blazor Hub endpoint to the endpoints (`app.UseEndpoints`) of `Startup.Configure`.

   `Startup.cs`:

   ```csharp
   endpoints.MapBlazorHub();
   ```

1. Integrate components into any page or view. For example, add a `Counter` component to the project's `Shared` folder.

   `Pages/Shared/Counter.razor` (Razor Pages) or `Views/Shared/Counter.razor` (MVC):

   ```razor
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

   **Razor Pages**:

   In the project's `Index` page of a Razor Pages app, add the `Counter` component's namespace and embed the component into the page. When the `Index` page loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Pages/Index.cshtml`:

   ```cshtml
   @page
   @using {APP NAMESPACE}.Pages.Shared
   @model IndexModel
   @{
       ViewData["Title"] = "Home page";
   }

   <div>
       <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   </div>
   ```

   In the preceding example, replace the `{APP NAMESPACE}` placeholder with the app's namespace.

   **MVC**:

   In the project's `Index` view of an MVC app, add the `Counter` component's namespace and embed the component into the view. When the `Index` view loads, the `Counter` component is prerendered in the page. In the following example, replace the `{APP NAMESPACE}` placeholder with the project's namespace.

   `Views/Home/Index.cshtml`:

   ```cshtml
   @using {APP NAMESPACE}.Views.Shared
   @{
       ViewData["Title"] = "Home Page";
   }

   <div>
       <component type="typeof(Counter)" render-mode="ServerPrerendered" />
   </div>
   ```

For more information, see the [Render components from a page or view](#render-components-from-a-page-or-view) section.

## Use routable components in a Razor Pages app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in Razor Pages apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

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

1. Add a `_Host` page to the project with the following content.

   `Pages/_Host.cshtml`:

   ```cshtml
   @page "/blazor"
   @{
       Layout = "_Layout";
   }

   <app>
       <component type="typeof(App)" render-mode="ServerPrerendered" />
   </app>
   ```

   Components use the shared `_Layout.cshtml` file for their layout.

   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. In the `Startup.Configure` endpoints of `Startup.cs`, add a low-priority route for the `_Host` page as the last endpoint:

   ```csharp
   endpoints.MapFallbackToPage("/_Host");
   ```

   The following example shows the added line in a typical app's endpoint configuration:

   ```csharp
   app.UseEndpoints(endpoints =>
   {
       endpoints.MapRazorPages();
       endpoints.MapBlazorHub();
       endpoints.MapFallbackToPage("/_Host");
   });
   ```

1. Add routable components to the project.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Use routable components in an MVC app

*This section pertains to adding components that are directly routable from user requests.*

To support routable Razor components in MVC apps:

1. Follow the guidance in the [Configuration](#configuration) section.

1. Add an `App` component to the project root with the following content.

   `App.razor`:

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

1. Add a `_Host` view to the project with the following content.

   `Views/Home/_Host.cshtml`:

   ```cshtml
   @{
       Layout = "_Layout";
   }

   <app>
       <component type="typeof(App)" render-mode="ServerPrerendered" />
   </app>
   ```

   Components use the shared `_Layout.cshtml` file for their layout.

   <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the `App` component:

   * Is prerendered into the page.
   * Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

   For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

1. Add an action to the Home controller.

   `Controllers/HomeController.cs`:

   ```csharp
   public IActionResult Blazor()
   {
      return View("_Host");
   }
   ```

1. In the `Startup.Configure` endpoints of `Startup.cs`, add a low-priority route for the controller action that returns the `_Host` view:

   ```csharp
   endpoints.MapFallbackToController("Blazor", "Home");
   ```

   The following example shows the added line in a typical app's endpoint configuration:

   ```csharp
   app.UseEndpoints(endpoints =>
   {
       endpoints.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");
       endpoints.MapBlazorHub();
       endpoints.MapFallbackToController("Blazor", "Home");
   });
   ```

1. Add routable components to the project.

   `Pages/RoutableCounter.razor`:

   ```razor
   @page "/routable-counter"

   <h1>Routable Counter</h1>

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

1. Run the project and navigate to the routable `RoutableCounter` component at `/routable-counter`.

For more information on namespaces, see the [Component namespaces](#component-namespaces) section.

## Render components from a page or view

*This section pertains to adding components to pages or views, where the components aren't directly routable from user requests.*

To render a component from a page or view, use the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

### Render stateful interactive components

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

@functions {
    [BindProperty(SupportsGet=true)]
    public int InitialValue { get; set; }
}
```

For more information, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

### Render noninteractive components

In the following Razor page, the `Counter` component is statically rendered with an initial value that's specified using a form. Since the component is statically rendered, the component isn't interactive:

```cshtml
<h1>My Razor Page</h1>

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

## Prerendered state size and SignalR message size limit

A large prerendered state size may exceed Blazor's SignalR circuit message size limit, which results in the following:

* The SignalR circuit fails to initialize with an error on the client: :::no-loc text="Circuit host not initialized.":::
* The reconnection UI on the client appears when the circuit fails. Recovery isn't possible.

To resolve the problem, use ***either*** of the following approaches:

* Reduce the amount of data that you are putting into the prerendered state.
* Increase the [SignalR message size limit](xref:blazor/fundamentals/signalr#server-side-circuit-handler-options). ***WARNING***: Increasing the limit may increase the risk of Denial of Service (DoS) attacks.

## Additional Blazor Server resources

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering)
* Razor component lifecycle subjects that pertain to prerendering
  * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
  * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
  * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering)
  * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop)
* [Authentication and authorization: General aspects](xref:blazor/security/index#aspnet-core-blazor-authentication-and-authorization)
* [Handle Errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
* [Host and deploy: Blazor Server](xref:blazor/host-and-deploy/server)
* [Threat mitigation: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)

:::moniker-end
