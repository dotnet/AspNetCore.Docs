---
title: Integrate ASP.NET Core Razor components with MVC or Razor Pages in hosted Blazor WebAssembly solutions
author: guardrex
description: Learn about Razor component integration scenarios for hosted Blazor WebAssembly apps with MVC or Razor Pages, including prerendering of Razor components on the server.
monikerRange: '>= aspnetcore-3.1 < aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/components/integration-hosted-webassembly
---
# Integrate ASP.NET Core Razor components with MVC or Razor Pages in hosted Blazor WebAssembly solutions

> [!NOTE]
> Hosted Blazor WebAssembly solutions remain supported, but the project template was removed and is no longer supported in .NET 8 or later. This article appears in the table of contents up to .NET 7 for reference, but note that .NET 7 is a [Standard Support Term](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) release that's no longer supported.

:::moniker range="= aspnetcore-7.0 || = aspnetcore-5.0 || = aspnetcore-3.0 || = aspnetcore-3.1 || = aspnetcore-2.0"

> [!WARNING]
> This version of ASP.NET Core is no longer supported. For more information, see the [.NET and .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core). 

:::moniker-end

This article explains Razor component integration scenarios for hosted Blazor WebAssembly apps, including prerendering of Razor components on the server.

> [!IMPORTANT]
> Framework changes across ASP.NET Core releases led to different sets of instructions in this article. Before using this article's guidance, confirm that the document version selector at the top of this article matches the version of ASP.NET Core that you intend to use for your app.

:::moniker range=">= aspnetcore-7.0"

Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

## Solution configuration

### Prerendering configuration

To set up prerendering for a hosted Blazor WebAssembly app:

1. Host the Blazor WebAssembly app in an ASP.NET Core app. A standalone Blazor WebAssembly app can be added to an ASP.NET Core solution, or you can use a hosted Blazor WebAssembly app created from the [Blazor WebAssembly project template](xref:blazor/tooling) with the hosted option:

   * Visual Studio: In the **Additional information** dialog, select the **ASP.NET Core Hosted** checkbox when creating the Blazor WebAssembly app. In this article's examples, the solution is named `BlazorHosted`.
   * Visual Studio Code/.NET CLI command shell: `dotnet new blazorwasm -ho` (use the `-ho|--hosted` option). Use the `-o|--output {LOCATION}` option to create a folder for the solution and set the solution's project namespaces. In this article's examples, the solution is named `BlazorHosted` (`dotnet new blazorwasm -ho -o BlazorHosted`).

   For the examples in this article, the hosted solution's name (assembly name) is `BlazorHosted`. The client project's namespace is `BlazorHosted.Client`, and the server project's namespace is `BlazorHosted.Server`.

1. **Delete** the `wwwroot/index.html` file from the Blazor WebAssembly **:::no-loc text="Client":::** project.

1. In the **:::no-loc text="Client":::** project, **delete** the following lines in `Program.cs`:

   ```diff
   - builder.RootComponents.Add<App>("#app");
   - builder.RootComponents.Add<HeadOutlet>("head::after");
   ```

1. Add `_Host.cshtml` file to the **:::no-loc text="Server":::** project's `Pages` folder. You can obtain the files from a project created from the Blazor Server template using Visual Studio or using the .NET CLI with the `dotnet new blazorserver -o BlazorServer` command in a command shell (the `-o BlazorServer` option creates a folder for the project). After placing the files into the **:::no-loc text="Server":::** project's `Pages` folder, make the following changes to the files.

   Make the following changes to the `_Host.cshtml` file:

   * Update the `Pages` namespace at the top of the file to match the namespace of the **:::no-loc text="Server":::** app's pages. The `{APP NAMESPACE}` placeholder in the following example represents the namespace of the donor app's pages that provided the `_Host.cshtml` file:

     Delete:

     ```diff
     - @namespace {APP NAMESPACE}.Pages
     ```

     Add:

     ```razor
     @namespace BlazorHosted.Server.Pages
     ```

   * Add an [`@using`](xref:mvc/views/razor#using) directive for the **:::no-loc text="Client":::** project at the top of the file:

     ```razor
     @using BlazorHosted.Client
     ```

   * Update the stylesheet links to point to the WebAssembly project's stylesheets. In the following example, the client project's namespace is `BlazorHosted.Client`. The `{APP NAMESPACE}` placeholder represents the namespace of the donor app that provided the `_Host.cshtml` file. Update the Component Tag Helper (`<component>` tag) for the `HeadOutlet` component to prerender the component.

     Delete:

     ```diff
     - <link href="css/site.css" rel="stylesheet" />
     - <link href="{APP NAMESPACE}.styles.css" rel="stylesheet" />
     - <component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />
     ```

     Add:

     ```cshtml
     <link href="css/app.css" rel="stylesheet" />
     <link href="BlazorHosted.Client.styles.css" rel="stylesheet" />
     <component type="typeof(HeadOutlet)" render-mode="WebAssemblyPrerendered" />
     ```

     > [!NOTE]
     > Leave the `<link>` element that requests the Bootstrap stylesheet (`css/bootstrap/bootstrap.min.css`) in place.

   * Update the Blazor script source to use the client-side Blazor WebAssembly script:

     Delete:

     ```diff
     - <script src="_framework/blazor.server.js"></script>
     ```

     Add:

     ```html
     <script src="_framework/blazor.webassembly.js"></script>
     ```

   * Update the `render-mode` of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to prerender the root `App` component with <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>:

     Delete:

     ```diff
     - <component type="typeof(App)" render-mode="ServerPrerendered" />
     ```

     Add:

     ```cshtml
     <component type="typeof(App)" render-mode="WebAssemblyPrerendered" />
     ```

     > [!IMPORTANT]
     > Prerendering isn't supported for authentication endpoints (`/authentication/` path segment). For more information, see <xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication>.

1. In the `Program.cs` file of the **:::no-loc text="Server":::** project, change the fallback endpoint from the `index.html` file to the `_Host.cshtml` page:

   Delete:

   ```diff
   - app.MapFallbackToFile("index.html");
   ```

   Add:

   ```csharp
   app.MapFallbackToPage("/_Host");
   ```

1. If the **:::no-loc text="Client":::** and **:::no-loc text="Server":::** projects use one or more common services during prerendering, factor the service registrations into a method that can be called from both projects. For more information, see <xref:blazor/fundamentals/dependency-injection#register-common-services>.

1. Run the **:::no-loc text="Server":::** project. The hosted Blazor WebAssembly app is prerendered by the **:::no-loc text="Server":::** project for clients.

### Configuration for embedding Razor components into pages or views

The following sections and examples for embedding Razor components from the **:::no-loc text="Client":::** Blazor WebAssembly app into pages or views of the server app require additional configuration.

The **:::no-loc text="Server":::** project must have the following files and folders.

Razor Pages:

* `Pages/Shared/_Layout.cshtml`
* `Pages/Shared/_Layout.cshtml.css`
* `Pages/_ViewImports.cshtml`
* `Pages/_ViewStart.cshtml`

MVC:

* `Views/Shared/_Layout.cshtml`
* `Views/Shared/_Layout.cshtml.css`
* `Views/_ViewImports.cshtml`
* `Views/_ViewStart.cshtml`

The preceding files can be obtained by generating an app from the ASP.NET Core project templates using:

* Visual Studio's new project creation tools.
* Opening a command shell and executing `dotnet new webapp -o {PROJECT NAME}` (Razor Pages) or `dotnet new mvc -o {PROJECT NAME}` (MVC). The option `-o|--output` with a value for the `{PROJECT NAME}` placeholder provides a name for the app and creates a folder for the app.

Update the namespaces in the imported `_ViewImports.cshtml` file to match those in use by the **:::no-loc text="Server":::** project receiving the files.

`Pages/_ViewImports.cshtml` (Razor Pages):

```razor
@using BlazorHosted.Server
@namespace BlazorHosted.Server.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

`Views/_ViewImports.cshtml` (MVC):

```razor
@using BlazorHosted.Server
@using BlazorHosted.Server.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

Update the imported layout file, which is `Pages/Shared/_Layout.cshtml` for Razor Pages or `Views/Shared/_Layout.cshtml` for MVC.

First, delete the title and the stylesheet from the donor project, which is `RPDonor.styles.css` in the following example. The `{PROJECT NAME}` placeholder represents the donor project's app name.

```diff
- <title>@ViewData["Title"] - {PROJECT NAME}</title>
- <link rel="stylesheet" href="~/RPDonor.styles.css" asp-append-version="true" />
```

Include the **:::no-loc text="Client":::** project's styles in the layout file. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`. The `<title>` element can be updated at the same time.

Place the following lines in the `<head>` content of the layout file:

```cshtml
<title>@ViewData["Title"] - BlazorHosted</title>
<link href="css/app.css" rel="stylesheet" />
<link rel="stylesheet" href="BlazorHosted.Client.styles.css" asp-append-version="true" />
<component type="typeof(HeadOutlet)" render-mode="WebAssemblyPrerendered" />
```

The imported layout contains two `Home` (`Index` page) and `Privacy` navigation links. To make the `Home` links point to the hosted Blazor WebAssembly app, change the hyperlinks:

```diff
- <a class="navbar-brand" asp-area="" asp-page="/Index">{PROJECT NAME}</a>
+ <a class="navbar-brand" href="/">BlazorHosted</a>
```

```diff
- <a class="nav-link text-dark" asp-area="" asp-page="/Index">Home</a>
+ <a class="nav-link text-dark" href="/">Home</a>
```

In an MVC layout file:

```diff
- <a class="navbar-brand" asp-area="" asp-controller="Home" 
-     asp-action="Index">{PROJECT NAME}</a>
+ <a class="navbar-brand" href="/">BlazorHosted</a>
```

```diff
- <a class="nav-link text-dark" asp-area="" asp-controller="Home" 
-     asp-action="Index">Home</a>
+ <a class="nav-link text-dark" href="/">Home</a>
```

Update the `<footer>` element's app name. The following example uses the app name `BlazorHosted`:

```diff
- &copy; {DATE} - {DONOR NAME} - <a asp-area="" asp-page="/Privacy">Privacy</a>
+ &copy; {DATE} - BlazorHosted - <a asp-area="" asp-page="/Privacy">Privacy</a>
```

In the preceding example, the `{DATE}` placeholder represents the copyright date in an app generated from the Razor Pages or MVC project template.

To make the `Privacy` link lead to a privacy page (Razor Pages), add a privacy page to the **:::no-loc text="Server":::** project.

`Pages/Privacy.cshtml` in the **:::no-loc text="Server":::** project:

```cshtml
@page
@model PrivacyModel
@{
    ViewData["Title"] = "Privacy Policy";
}
<h1>@ViewData["Title"]</h1>

<p>Use this page to detail your site's privacy policy.</p>
```

For an MVC-based privacy view, create a privacy view in the **:::no-loc text="Server":::** project.

`View/Home/Privacy.cshtml` in the **:::no-loc text="Server":::** project:

```cshtml
@{
    ViewData["Title"] = "Privacy Policy";
}
<h1>@ViewData["Title"]</h1>

<p>Use this page to detail your site's privacy policy.</p>
```

In the `Home` controller of the MVC app, return the view.

Add the following code to `Controllers/HomeController.cs`:

```csharp
public IActionResult Privacy()
{
    return View();
}
```

If you import files from a donor app, be sure to update any namespaces in the files to match that of the **:::no-loc text="Server":::** project (for example, `BlazorHosted.Server`).

Import static assets to the **:::no-loc text="Server":::** project from the donor project's `wwwroot` folder:

* `wwwroot/css` folder and contents
* `wwwroot/js` folder and contents
* `wwwroot/lib` folder and contents

If the donor project is created from an ASP.NET Core project template and the files aren't modified, you can copy the entire `wwwroot` folder from the donor project into the **:::no-loc text="Server":::** project and remove the :::no-loc text="favicon"::: icon file.

> [!WARNING]
> Avoid placing the static asset into both the **:::no-loc text="Client":::** and **:::no-loc text="Server":::** `wwwroot` folders. If the same file is present in both folders, an exception is thrown because the static assets share the same web root path. Therefore, host a static asset in either of the `wwwroot` folders, not both.

After adopting the preceding configuration, embed Razor components into pages or views of the **:::no-loc text="Server":::** project. Use the guidance in the following sections of this article:

* *Render components in a page or view with the Component Tag Helper*
* *Render components in a page or view with a CSS selector*

## Render components in a page or view with the Component Tag Helper

After [configuring the solution](#solution-configuration), including the [additional configuration](#configuration-for-embedding-razor-components-into-pages-or-views), the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) supports two render modes for rendering a component from a Blazor WebAssembly app in a page or view:

* <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssembly>
* <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>

In the following Razor Pages example, the `Counter` component is rendered in a page. To make the component interactive, the Blazor WebAssembly script is included in the page's [render section](xref:mvc/views/layout#sections). To avoid using the full namespace for the `Counter` component with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) (`{ASSEMBLY NAME}.Pages.Counter`), add an [`@using`](xref:mvc/views/razor#using) directive for the client project's `Pages` namespace. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`.

In the **:::no-loc text="Server":::** project, `Pages/RazorPagesCounter1.cshtml`:

```cshtml
@page
@using BlazorHosted.Client.Pages

<component type="typeof(Counter)" render-mode="WebAssemblyPrerendered" />

@section Scripts {
    <script src="_framework/blazor.webassembly.js"></script>
}
```

Run the **:::no-loc text="Server":::** project. Navigate to the Razor page at `/razorpagescounter1`. The prerendered `Counter` component is embedded in the page.

<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

Additional work might be required depending on the static resources that components use and how layout pages are organized in an app. Typically, scripts are added to a page or view's `Scripts` render section and stylesheets are added to the layout's `<head>` element content.

### Set child content through a render fragment

The [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) doesn't support receiving a [`RenderFragment` delegate for child content](xref:blazor/components/index#child-content-render-fragments) (for example, `param-ChildContent="..."`). We recommend creating a Razor component (`.razor`) that references the component you want to render with the child content you want to pass and then invoke the Razor component from the page or view.

### Ensure that top-level prerendered components aren't trimmed out on publish

If a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) directly references a component from a library that's subject to trimming on publish, the component might be trimmed out during publish because there are no references to it from client-side app code. As a result, the component isn't prerendered, leaving a blank spot in the output. If this occurs, instruct the trimmer to preserve the library component by adding a [`DynamicDependency` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute) to any class in the client-side app. To preserve a component called `SomeLibraryComponentToBePreserved`, add the following to any component:

```razor
@using System.Diagnostics.CodeAnalysis
@attribute [DynamicDependency(DynamicallyAccessedMemberTypes.All, 
    typeof(SomeLibraryComponentToBePreserved))]
```

The preceding approach usually isn't required because the app usually prerenders its components (which are not trimmed), which in turn references components from libraries (causing them also not to be trimmed). Only use `DynamicDependency` explicitly for prerendering a library component directly when the library is subject to trimming.

## Render components in a page or view with a CSS selector

After [configuring the solution](#solution-configuration), including the [additional configuration](#configuration-for-embedding-razor-components-into-pages-or-views), add root components to the **:::no-loc text="Client":::** project of a hosted Blazor WebAssembly solution in the `Program.cs` file. In the following example, the `Counter` component is declared as a root component with a CSS selector that selects the element with the `id` that matches `counter-component`. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`.

In `Program.cs` file of the **:::no-loc text="Client":::** project, add the namespace for the project's Razor components to the top of the file:

```csharp
using BlazorHosted.Client.Pages;
```

After the `builder` is established in `Program.cs`, add the `Counter` component as a root component:

```csharp
builder.RootComponents.Add<Counter>("#counter-component");
```

In the following Razor Pages example, the `Counter` component is rendered in a page. To make the component interactive, the Blazor WebAssembly script is included in the page's [render section](xref:mvc/views/layout#sections).

In the **:::no-loc text="Server":::** project, `Pages/RazorPagesCounter2.cshtml`:

```cshtml
@page

<div id="counter-component">Loading...</div>

@section Scripts {
    <script src="_framework/blazor.webassembly.js"></script>
}
```

Run the **:::no-loc text="Server":::** project. Navigate to the Razor page at `/razorpagescounter2`. The prerendered `Counter` component is embedded in the page.

Additional work might be required depending on the static resources that components use and how layout pages are organized in an app. Typically, scripts are added to a page or view's `Scripts` render section and stylesheets are added to the layout's `<head>` element content.

> [!NOTE]
> The preceding example throws a <xref:Microsoft.JSInterop.JSException> if a Blazor WebAssembly app is prerendered and integrated into a Razor Pages or MVC app **simultaneously** with the use of a CSS selector. Navigating to one of the **:::no-loc text="Client":::** project's Razor components or navigating to a page or view of the **:::no-loc text="Server":::** with an embedded component throws one or more <xref:Microsoft.JSInterop.JSException>.
>
> This is normal behavior because prerendering and integrating a Blazor WebAssembly app with routable Razor components is incompatible with the use of CSS selectors.
>
> If you've been working with the examples in the preceding sections and just wish to see the CSS selector work in your sample app, comment out the specification of the `App` root component of the **:::no-loc text="Client":::** project's `Program.cs` file:
>
> ```diff
> - builder.RootComponents.Add<App>("#app");
> + //builder.RootComponents.Add<App>("#app");
> ```
>
> Navigate to the page or view with the embedded Razor component that uses a CSS selector (for example, `/razorpagescounter2` of the preceding example). The page or view loads with the embedded component, and the embedded component functions as expected.

## Persist prerendered state

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is setup asynchronously, the UI may flicker as the prerendered UI is replaced with temporary placeholders and then fully rendered again.

To persist state for prerendered components, use the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.TagHelpers/src/PersistComponentStateTagHelper.cs)). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag of the `_Host` page in an app that prerenders components.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

In `Pages/_Host.cshtml` of Blazor apps that are WebAssembly prerendered (`WebAssemblyPrerendered`) in a hosted Blazor WebAssembly app:

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

The following example is an updated version of the `FetchData` component in a hosted Blazor WebAssembly app based on the Blazor project template. The `WeatherForecastPreserveState` component persists weather forecast state during prerendering and then retrieves the state to initialize the component. The [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) persists the component state after all component invocations.

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

The persisted prerendered state is transferred to the client, where it's used to restore the component state. For prerendering in a hosted Blazor WebAssembly app, the data is exposed to the browser and must not contain sensitive, private information.

## Additional Blazor WebAssembly resources

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering)
* [Prerendering support with assembly lazy loading](xref:blazor/webassembly-lazy-load-assemblies#lazy-load-assemblies-in-a-hosted-blazor-webassembly-solution)
* Razor component lifecycle subjects that pertain to prerendering
  * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
  * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
  * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering): Although the content in the section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see *Persist prerendered state* section of this article.
  * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop)
* Authentication and authorization subjects that pertain to prerendering
  * [General aspects](xref:blazor/security/index)
  * [Prerendering with authentication in hosted Blazor WebAssembly apps](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication)
* [Host and deploy: Blazor WebAssembly](xref:blazor/host-and-deploy/webassembly)
* [Handle errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
* <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice* when prerendering: [Handle asynchronous navigation events with `OnNavigateAsync`](xref:blazor/fundamentals/routing#handle-asynchronous-navigation-events-with-onnavigateasync)

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

## Solution configuration

### Prerendering configuration

To set up prerendering for a hosted Blazor WebAssembly app:

1. Host the Blazor WebAssembly app in an ASP.NET Core app. A standalone Blazor WebAssembly app can be added to an ASP.NET Core solution, or you can use a hosted Blazor WebAssembly app created from the [Blazor WebAssembly project template](xref:blazor/tooling) with the hosted option:

   * Visual Studio: In the **Additional information** dialog, select the **ASP.NET Core Hosted** checkbox when creating the Blazor WebAssembly app. In this article's examples, the solution is named `BlazorHosted`.
   * Visual Studio Code/.NET CLI command shell: `dotnet new blazorwasm -ho` (use the `-ho|--hosted` option). Use the `-o|--output {LOCATION}` option to create a folder for the solution and set the solution's project namespaces. In this article's examples, the solution is named `BlazorHosted` (`dotnet new blazorwasm -ho -o BlazorHosted`).

   For the examples in this article, the client project's namespace is `BlazorHosted.Client`, and the server project's namespace is `BlazorHosted.Server`.

1. **Delete** the `wwwroot/index.html` file from the Blazor WebAssembly **:::no-loc text="Client":::** project.

1. In the **:::no-loc text="Client":::** project, **delete** the following lines in `Program.cs`:

   ```diff
   - builder.RootComponents.Add<App>("#app");
   - builder.RootComponents.Add<HeadOutlet>("head::after");
   ```

1. Add `_Host.cshtml` and `_Layout.cshtml` files to the **:::no-loc text="Server":::** project's `Pages` folder. You can obtain the files from a project created from the Blazor Server template using Visual Studio or using the .NET CLI with the `dotnet new blazorserver -o BlazorServer` command in a command shell (the `-o BlazorServer` option creates a folder for the project). After placing the files into the **:::no-loc text="Server":::** project's `Pages` folder, make the following changes to the files.

   > [!IMPORTANT]
   > The use of a layout page (`_Layout.cshtml`) with a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is required to control `<head>` content, such as the page's title (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component). For more information, see <xref:blazor/components/control-head-content#control-head-content-during-prerendering>.

   Make the following changes to the `_Layout.cshtml` file:

   * Update the `Pages` namespace at the top of the file to match the namespace of the **:::no-loc text="Server":::** app's pages. The `{APP NAMESPACE}` placeholder in the following example represents the namespace of the donor app's pages that provided the `_Layout.cshtml` file:

     Delete:

     ```diff
     - @namespace {APP NAMESPACE}.Pages
     ```

     Add:

     ```razor
     @namespace BlazorHosted.Server.Pages
     ```

   * Add an [`@using`](xref:mvc/views/razor#using) directive for the **:::no-loc text="Client":::** project at the top of the file:

     ```razor
     @using BlazorHosted.Client
     ```

   * Update the stylesheet links to point to the WebAssembly project's stylesheets. In the following example, the client project's namespace is `BlazorHosted.Client`. The `{APP NAMESPACE}` placeholder represents the namespace of the donor app that provided the `_Layout.cshtml` file. Update the Component Tag Helper (`<component>` tag) for the `HeadOutlet` component to prerender the component.

     Delete:

     ```diff
     - <link href="css/site.css" rel="stylesheet" />
     - <link href="{APP NAMESPACE}.styles.css" rel="stylesheet" />
     - <component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />
     ```

     Add:

     ```cshtml
     <link href="css/app.css" rel="stylesheet" />
     <link href="BlazorHosted.Client.styles.css" rel="stylesheet" />
     <component type="typeof(HeadOutlet)" render-mode="WebAssemblyPrerendered" />
     ```

     > [!NOTE]
     > Leave the `<link>` element that requests the Bootstrap stylesheet (`css/bootstrap/bootstrap.min.css`) in place.

   * Update the Blazor script source to use the client-side Blazor WebAssembly script:

     Delete:

     ```diff
     - <script src="_framework/blazor.server.js"></script>
     ```

     Add:

     ```html
     <script src="_framework/blazor.webassembly.js"></script>
     ```

   In the `_Host.cshtml` file:

   * Change the `Pages` namespace to that of the **:::no-loc text="Client":::** project. The `{APP NAMESPACE}` placeholder represents the namespace of the donor app's pages that provided the `_Host.cshtml` file:

     Delete:

     ```diff
     - @namespace {APP NAMESPACE}.Pages
     ```

     Add:

     ```razor
     @namespace BlazorHosted.Client
     ```

   * Update the `render-mode` of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to prerender the root `App` component with <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>:

     Delete:

     ```diff
     - <component type="typeof(App)" render-mode="ServerPrerendered" />
     ```

     Add:

     ```cshtml
     <component type="typeof(App)" render-mode="WebAssemblyPrerendered" />
     ```

     > [!IMPORTANT]
     > Prerendering isn't supported for authentication endpoints (`/authentication/` path segment). For more information, see <xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication>.

1. In endpoint mapping of the **:::no-loc text="Server":::** project in `Program.cs`, change the fallback from the `index.html` file to the `_Host.cshtml` page:

   Delete:

   ```diff
   - app.MapFallbackToFile("index.html");
   ```

   Add:

   ```csharp
   app.MapFallbackToPage("/_Host");
   ```

1. If the **:::no-loc text="Client":::** and **:::no-loc text="Server":::** projects use one or more common services during prerendering, factor the service registrations into a method that can be called from both projects. For more information, see <xref:blazor/fundamentals/dependency-injection#register-common-services>.

1. Run the **:::no-loc text="Server":::** project. The hosted Blazor WebAssembly app is prerendered by the **:::no-loc text="Server":::** project for clients.

### Configuration for embedding Razor components into pages or views

The following sections and examples for embedding Razor components from the **:::no-loc text="Client":::** Blazor WebAssembly app into pages or views of the server app require additional configuration.

The **:::no-loc text="Server":::** project must have the following files and folders.

Razor Pages:

* `Pages/Shared/_Layout.cshtml`
* `Pages/Shared/_Layout.cshtml.css`
* `Pages/_ViewImports.cshtml`
* `Pages/_ViewStart.cshtml`

MVC:

* `Views/Shared/_Layout.cshtml`
* `Views/Shared/_Layout.cshtml.css`
* `Views/_ViewImports.cshtml`
* `Views/_ViewStart.cshtml`

> [!IMPORTANT]
> The use of a layout page (`_Layout.cshtml`) with a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) for a <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component is required to control `<head>` content, such as the page's title (<xref:Microsoft.AspNetCore.Components.Web.PageTitle> component) and other head elements (<xref:Microsoft.AspNetCore.Components.Web.HeadContent> component). For more information, see <xref:blazor/components/control-head-content#control-head-content-during-prerendering>.

The preceding files can be obtained by generating an app from the ASP.NET Core project templates using:

* Visual Studio's new project creation tools.
* Opening a command shell and executing `dotnet new webapp -o {PROJECT NAME}` (Razor Pages) or `dotnet new mvc -o {PROJECT NAME}` (MVC). The option `-o|--output` with a value for the `{PROJECT NAME}` placeholder provides a name for the app and creates a folder for the app.

Update the namespaces in the imported `_ViewImports.cshtml` file to match those in use by the **:::no-loc text="Server":::** project receiving the files.

`Pages/_ViewImports.cshtml` (Razor Pages):

```razor
@using BlazorHosted.Server
@namespace BlazorHosted.Server.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

`Views/_ViewImports.cshtml` (MVC):

```razor
@using BlazorHosted.Server
@using BlazorHosted.Server.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

Update the imported layout file, which is `Pages/Shared/_Layout.cshtml` for Razor Pages or `Views/Shared/_Layout.cshtml` for MVC.

First, delete the title and the stylesheet from the donor project, which is `RPDonor.styles.css` in the following example. The `{PROJECT NAME}` placeholder represents the donor project's app name.

```diff
- <title>@ViewData["Title"] - {PROJECT NAME}</title>
- <link rel="stylesheet" href="~/RPDonor.styles.css" asp-append-version="true" />
```

Include the **:::no-loc text="Client":::** project's styles in the layout file. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`. The `<title>` element can be updated at the same time.

Place the following lines in the `<head>` content of the layout file:

```cshtml
<title>@ViewData["Title"] - BlazorHosted</title>
<link href="css/app.css" rel="stylesheet" />
<link rel="stylesheet" href="BlazorHosted.Client.styles.css" asp-append-version="true" />
<component type="typeof(HeadOutlet)" render-mode="WebAssemblyPrerendered" />
```

The imported layout contains two `Home` (`Index` page) and `Privacy` navigation links. To make the `Home` links point to the hosted Blazor WebAssembly app, change the hyperlinks:

```diff
- <a class="navbar-brand" asp-area="" asp-page="/Index">{PROJECT NAME}</a>
+ <a class="navbar-brand" href="/">BlazorHosted</a>
```

```diff
- <a class="nav-link text-dark" asp-area="" asp-page="/Index">Home</a>
+ <a class="nav-link text-dark" href="/">Home</a>
```

In an MVC layout file:

```diff
- <a class="navbar-brand" asp-area="" asp-controller="Home" 
-     asp-action="Index">{PROJECT NAME}</a>
+ <a class="navbar-brand" href="/">BlazorHosted</a>
```

```diff
- <a class="nav-link text-dark" asp-area="" asp-controller="Home" 
-     asp-action="Index">Home</a>
+ <a class="nav-link text-dark" href="/">Home</a>
```

Update the `<footer>` element's app name. The following example uses the app name `BlazorHosted`:

```diff
- &copy; {DATE} - {DONOR NAME} - <a asp-area="" asp-page="/Privacy">Privacy</a>
+ &copy; {DATE} - BlazorHosted - <a asp-area="" asp-page="/Privacy">Privacy</a>
```

In the preceding example, the `{DATE}` placeholder represents the copyright date in an app generated from the Razor Pages or MVC project template.

To make the `Privacy` link lead to a privacy page (Razor Pages), add a privacy page to the **:::no-loc text="Server":::** project.

`Pages/Privacy.cshtml` in the **:::no-loc text="Server":::** project:

```cshtml
@page
@model PrivacyModel
@{
    ViewData["Title"] = "Privacy Policy";
}
<h1>@ViewData["Title"]</h1>

<p>Use this page to detail your site's privacy policy.</p>
```

For an MVC-based privacy view, create a privacy view in the **:::no-loc text="Server":::** project.

`View/Home/Privacy.cshtml` in the **:::no-loc text="Server":::** project:

```cshtml
@{
    ViewData["Title"] = "Privacy Policy";
}
<h1>@ViewData["Title"]</h1>

<p>Use this page to detail your site's privacy policy.</p>
```

In the `Home` controller of the MVC app, return the view.

Add the following code to `Controllers/HomeController.cs`:

```csharp
public IActionResult Privacy()
{
    return View();
}
```

If you import files from a donor app, be sure to update any namespaces in the files to match that of the **:::no-loc text="Server":::** project (for example, `BlazorHosted.Server`).

Import static assets to the **:::no-loc text="Server":::** project from the donor project's `wwwroot` folder:

* `wwwroot/css` folder and contents
* `wwwroot/js` folder and contents
* `wwwroot/lib` folder and contents

If the donor project is created from an ASP.NET Core project template and the files aren't modified, you can copy the entire `wwwroot` folder from the donor project into the **:::no-loc text="Server":::** project and remove the :::no-loc text="favicon"::: icon file.

> [!WARNING]
> Avoid placing the static asset into both the **:::no-loc text="Client":::** and **:::no-loc text="Server":::** `wwwroot` folders. If the same file is present in both folders, an exception is thrown because the static asset in each folder shares the same web root path. Therefore, host a static asset in either `wwwroot` folder, not both.

After adopting the preceding configuration, embed Razor components into pages or views of the **:::no-loc text="Server":::** project. Use the guidance in the following sections of this article:

* *Render components in a page or view with the Component Tag Helper*
* *Render components in a page or view with a CSS selector*

## Render components in a page or view with the Component Tag Helper

After [configuring the solution](#solution-configuration), including the [additional configuration](#configuration-for-embedding-razor-components-into-pages-or-views), the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) supports two render modes for rendering a component from a Blazor WebAssembly app in a page or view:

* <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssembly>
* <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>

In the following Razor Pages example, the `Counter` component is rendered in a page. To make the component interactive, the Blazor WebAssembly script is included in the page's [render section](xref:mvc/views/layout#sections). To avoid using the full namespace for the `Counter` component with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) (`{ASSEMBLY NAME}.Pages.Counter`), add an [`@using`](xref:mvc/views/razor#using) directive for the client project's `Pages` namespace. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`.

In the **:::no-loc text="Server":::** project, `Pages/RazorPagesCounter1.cshtml`:

```cshtml
@page
@using BlazorHosted.Client.Pages

<component type="typeof(Counter)" render-mode="WebAssemblyPrerendered" />

@section Scripts {
    <script src="_framework/blazor.webassembly.js"></script>
}
```

Run the **:::no-loc text="Server":::** project. Navigate to the Razor page at `/razorpagescounter1`. The prerendered `Counter` component is embedded in the page.

<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

Additional work might be required depending on the static resources that components use and how layout pages are organized in an app. Typically, scripts are added to a page or view's `Scripts` render section and stylesheets are added to the layout's `<head>` element content.

### Set child content through a render fragment

The [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) doesn't support receiving a [`RenderFragment` delegate for child content](xref:blazor/components/index#child-content-render-fragments) (for example, `param-ChildContent="..."`). We recommend creating a Razor component (`.razor`) that references the component you want to render with the child content you want to pass and then invoke the Razor component from the page or view.

### Ensure that top-level prerendered components aren't trimmed out on publish

If a [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) directly references a component from a library that's subject to trimming on publish, the component might be trimmed out during publish because there are no references to it from client-side app code. As a result, the component isn't prerendered, leaving a blank spot in the output. If this occurs, instruct the trimmer to preserve the library component by adding a [`DynamicDependency` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute) to any class in the client-side app. To preserve a component called `SomeLibraryComponentToBePreserved`, add the following to any component:

```razor
@using System.Diagnostics.CodeAnalysis
@attribute [DynamicDependency(DynamicallyAccessedMemberTypes.All, 
    typeof(SomeLibraryComponentToBePreserved))]
```

The preceding approach usually isn't required because the app usually prerenders its components (which are not trimmed), which in turn references components from libraries (causing them also not to be trimmed). Only use `DynamicDependency` explicitly for prerendering a library component directly when the library is subject to trimming.

## Render components in a page or view with a CSS selector

After [configuring the solution](#solution-configuration), including the [additional configuration](#configuration-for-embedding-razor-components-into-pages-or-views), add root components to the **:::no-loc text="Client":::** project of a hosted Blazor WebAssembly solution in the `Program.cs` file. In the following example, the `Counter` component is declared as a root component with a CSS selector that selects the element with the `id` that matches `counter-component`. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`.

In `Program.cs` file of the **:::no-loc text="Client":::** project, add the namespace for the project's Razor components to the top of the file:

```csharp
using BlazorHosted.Client.Pages;
```

After the `builder` is established in `Program.cs`, add the `Counter` component as a root component:

```csharp
builder.RootComponents.Add<Counter>("#counter-component");
```

In the following Razor Pages example, the `Counter` component is rendered in a page. To make the component interactive, the Blazor WebAssembly script is included in the page's [render section](xref:mvc/views/layout#sections).

In the **:::no-loc text="Server":::** project, `Pages/RazorPagesCounter2.cshtml`:

```cshtml
@page

<div id="counter-component">Loading...</div>

@section Scripts {
    <script src="_framework/blazor.webassembly.js"></script>
}
```

Run the **:::no-loc text="Server":::** project. Navigate to the Razor page at `/razorpagescounter2`. The prerendered `Counter` component is embedded in the page.

Additional work might be required depending on the static resources that components use and how layout pages are organized in an app. Typically, scripts are added to a page or view's `Scripts` render section and stylesheets are added to the layout's `<head>` element content.

> [!NOTE]
> The preceding example throws a <xref:Microsoft.JSInterop.JSException> if a Blazor WebAssembly app is prerendered and integrated into a Razor Pages or MVC app **simultaneously** with the use of a CSS selector. Navigating to one of the **:::no-loc text="Client":::** project's Razor components or navigating to a page or view of the **:::no-loc text="Server":::** with an embedded component throws one or more <xref:Microsoft.JSInterop.JSException>.
>
> This is normal behavior because prerendering and integrating a Blazor WebAssembly app with routable Razor components is incompatible with the use of CSS selectors.
>
> If you've been working with the examples in the preceding sections and just wish to see the CSS selector work in your sample app, comment out the specification of the `App` root component of the **:::no-loc text="Client":::** project's `Program.cs` file:
>
> ```diff
> - builder.RootComponents.Add<App>("#app");
> + //builder.RootComponents.Add<App>("#app");
> ```
>
> Navigate to the page or view with the embedded Razor component that uses a CSS selector (for example, `/razorpagescounter2` of the preceding example). The page or view loads with the embedded component, and the embedded component functions as expected.

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

The following example is an updated version of the `FetchData` component in a hosted Blazor WebAssembly app based on the Blazor project template. The `WeatherForecastPreserveState` component persists weather forecast state during prerendering and then retrieves the state to initialize the component. The [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) persists the component state after all component invocations.

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

The persisted prerendered state is transferred to the client, where it's used to restore the component state. For prerendering in a hosted Blazor WebAssembly app, the data is exposed to the browser and must not contain sensitive, private information.

## Additional Blazor WebAssembly resources

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering)
* [Prerendering support with assembly lazy loading](xref:blazor/webassembly-lazy-load-assemblies#lazy-load-assemblies-in-a-hosted-blazor-webassembly-solution)
* Razor component lifecycle subjects that pertain to prerendering
  * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
  * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
  * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering): Although the content in the section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see *Persist prerendered state* section of this article.
  * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop)
* Authentication and authorization subjects that pertain to prerendering
  * [General aspects](xref:blazor/security/index#aspnet-core-blazor-authentication-and-authorization)
  * [Prerendering with authentication](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication)
* [Host and deploy: Blazor WebAssembly](xref:blazor/host-and-deploy/webassembly)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

## Solution configuration

### Prerendering configuration

To set up prerendering for a hosted Blazor WebAssembly app:

1. Host the Blazor WebAssembly app in an ASP.NET Core app. A standalone Blazor WebAssembly app can be added to an ASP.NET Core solution, or you can use a hosted Blazor WebAssembly app created from the [Blazor WebAssembly project template](xref:blazor/tooling) with the hosted option:

   * Visual Studio: In the **Additional information** dialog, select the **ASP.NET Core Hosted** checkbox when creating the Blazor WebAssembly app. In this article's examples, the solution is named `BlazorHosted`.
   * Visual Studio Code/.NET CLI command shell: `dotnet new blazorwasm -ho` (use the `-ho|--hosted` option). Use the `-o|--output {LOCATION}` option to create a folder for the solution and set the solution's project namespaces. In this article's examples, the solution is named `BlazorHosted` (`dotnet new blazorwasm -ho -o BlazorHosted`).

   For the examples in this article, the client project's namespace is `BlazorHosted.Client`, and the server project's namespace is `BlazorHosted.Server`.

1. **Delete** the `wwwroot/index.html` file from the Blazor WebAssembly **:::no-loc text="Client":::** project.

1. In the **:::no-loc text="Client":::** project, **delete** the following line in `Program.cs`:

   ```diff
   - builder.RootComponents.Add<App>("#app");
   ```

1. Add a `Pages/_Host.cshtml` file to the **:::no-loc text="Server":::** project's `Pages` folder. You can obtain a `_Host.cshtml` file from a project created from the Blazor Server template with the `dotnet new blazorserver -o BlazorServer` command in a command shell (the `-o BlazorServer` option creates a folder for the project). After placing the `Pages/_Host.cshtml` file into the **:::no-loc text="Server":::** project of the hosted Blazor WebAssembly solution, make the following changes to the file:

   * Provide an [`@using`](xref:mvc/views/razor#using) directive for the **:::no-loc text="Client":::** project (for example, `@using BlazorHosted.Client`).
   * Update the stylesheet links to point to the WebAssembly project's stylesheets. In the following example, the client project's namespace is `BlazorHosted.Client`:

     ```diff
     - <link href="css/site.css" rel="stylesheet" />
     - <link href="_content/BlazorServer/_framework/scoped.styles.css" rel="stylesheet" />
     + <link href="css/app.css" rel="stylesheet" />
     + <link href="BlazorHosted.Client.styles.css" rel="stylesheet" />
     ```

     > [!NOTE]
     > Leave the `<link>` element that requests the Bootstrap stylesheet (`css/bootstrap/bootstrap.min.css`) in place.

   * Update the `render-mode` of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to prerender the root `App` component with <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>:

     ```diff
     - <component type="typeof(App)" render-mode="ServerPrerendered" />
     + <component type="typeof(App)" render-mode="WebAssemblyPrerendered" />
     ```

   * Update the Blazor script source to use the client-side Blazor WebAssembly script:

     ```diff
     - <script src="_framework/blazor.server.js"></script>
     + <script src="_framework/blazor.webassembly.js"></script>
     ```

1. In `Startup.Configure` of the **:::no-loc text="Server":::** project, change the fallback from the `index.html` file to the `_Host.cshtml` page.

   `Startup.cs`:

   ```diff
   - endpoints.MapFallbackToFile("index.html");
   + endpoints.MapFallbackToPage("/_Host");
   ```

1. If the **:::no-loc text="Client":::** and **:::no-loc text="Server":::** projects use one or more common services during prerendering, factor the service registrations into a method that can be called from both projects. For more information, see <xref:blazor/fundamentals/dependency-injection#register-common-services>.

1. Run the **:::no-loc text="Server":::** project. The hosted Blazor WebAssembly app is prerendered by the **:::no-loc text="Server":::** project for clients.

### Configuration for embedding Razor components into pages or views

The following sections and examples in this article for embedding Razor components of the client Blazor WebAssembly app into pages or views of the server app require additional configuration.

Use a default Razor Pages or MVC layout file in the **:::no-loc text="Server":::** project. The **:::no-loc text="Server":::** project must have the following files and folders.

Razor Pages:

* `Pages/Shared/_Layout.cshtml`
* `Pages/_ViewImports.cshtml`
* `Pages/_ViewStart.cshtml`

MVC:

* `Views/Shared/_Layout.cshtml`
* `Views/_ViewImports.cshtml`
* `Views/_ViewStart.cshtml`

Obtain the preceding files from an app created from the Razor Pages or MVC project template. For more information, see <xref:tutorials/razor-pages/razor-pages-start> or <xref:tutorials/first-mvc-app/start-mvc>.

Update the namespaces in the imported `_ViewImports.cshtml` file to match those in use by the **:::no-loc text="Server":::** project receiving the files.

Update the imported layout file (`_Layout.cshtml`) to include the **:::no-loc text="Client":::** project's styles. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`. The `<title>` element can be updated at the same time.

`Pages/Shared/_Layout.cshtml` (Razor Pages) or `Views/Shared/_Layout.cshtml` (MVC):

```diff
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
-   <title>@ViewData["Title"] - DonorProject</title>
+   <title>@ViewData["Title"] - BlazorHosted</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" />
+   <link href="css/app.css" rel="stylesheet" />
+   <link href="BlazorHosted.Client.styles.css" rel="stylesheet" />
</head>
```

The imported layout contains `Home` and `Privacy` navigation links. To make the `Home` link point to the hosted Blazor WebAssembly app, change the hyperlink:

```diff
- <a class="nav-link text-dark" asp-area="" asp-page="/Index">Home</a>
+ <a class="nav-link text-dark" href="/">Home</a>
```

In an MVC layout file:

```diff
- <a class="nav-link text-dark" asp-area="" asp-controller="Home" 
-     asp-action="Index">Home</a>
+ <a class="nav-link text-dark" href="/">Home</a>
```

To make the `Privacy` link lead to a privacy page, add a privacy page to the **:::no-loc text="Server":::** project.

`Pages/Privacy.cshtml` in the **:::no-loc text="Server":::** project:

```cshtml
@page
@model BlazorHosted.Server.Pages.PrivacyModel
@{
}

<h1>Privacy Policy</h1>
```

If an MVC-based privacy view is preferred, create a privacy view in the **:::no-loc text="Server":::** project.

`View/Home/Privacy.cshtml`:

```cshtml
@{
    ViewData["Title"] = "Privacy Policy";
}

<h1>@ViewData["Title"]</h1>
```

In the `Home` controller, return the view.

`Controllers/HomeController.cs`:

```csharp
public IActionResult Privacy()
{
    return View();
}
```

Import static assets to the **:::no-loc text="Server":::** project from the donor project's `wwwroot` folder:

* `wwwroot/css` folder and contents
* `wwwroot/js` folder and contents
* `wwwroot/lib` folder and contents

If the donor project is created from an ASP.NET Core project template and the files aren't modified, you can copy the entire `wwwroot` folder from the donor project into the **:::no-loc text="Server":::** project and remove the :::no-loc text="favicon"::: icon file.

> [!WARNING]
> Avoid placing the static asset into both the **:::no-loc text="Client":::** and **:::no-loc text="Server":::** `wwwroot` folders. If the same file is present in both folders, an exception is thrown because the static asset in each folder shares the same web root path. Therefore, host a static asset in either `wwwroot` folder, not both.

## Render components in a page or view with the Component Tag Helper

After [configuring the solution](#solution-configuration), including the [additional configuration](#configuration-for-embedding-razor-components-into-pages-or-views), the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) supports two render modes for rendering a component from a Blazor WebAssembly app in a page or view:

* <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssembly>
* <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>

In the following Razor Pages example, the `Counter` component is rendered in a page. To make the component interactive, the Blazor WebAssembly script is included in the page's [render section](xref:mvc/views/layout#sections). To avoid using the full namespace for the `Counter` component with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) (`{ASSEMBLY NAME}.Pages.Counter`), add an [`@using`](xref:mvc/views/razor#using) directive for the client project's `Pages` namespace. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`.

In the **:::no-loc text="Server":::** project, `Pages/RazorPagesCounter1.cshtml`:

```cshtml
@page
@using BlazorHosted.Client.Pages

<component type="typeof(Counter)" render-mode="WebAssemblyPrerendered" />

@section Scripts {
    <script src="_framework/blazor.webassembly.js"></script>
}
```

Run the **:::no-loc text="Server":::** project. Navigate to the Razor page at `/razorpagescounter1`. The prerendered `Counter` component is embedded in the page.

<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

For more information on the Component Tag Helper, including passing parameters and <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configuration, see <xref:mvc/views/tag-helpers/builtin-th/component-tag-helper>.

Additional work might be required depending on the static resources that components use and how layout pages are organized in an app. Typically, scripts are added to a page or view's `Scripts` render section and stylesheets are added to the layout's `<head>` element content.

## Render components in a page or view with a CSS selector

After [configuring the solution](#solution-configuration), including the [additional configuration](#configuration-for-embedding-razor-components-into-pages-or-views), add root components to the **:::no-loc text="Client":::** project of a hosted Blazor WebAssembly solution in `Program.cs`. In the following example, the `Counter` component is declared as a root component with a CSS selector that selects the element with the `id` that matches `counter-component`. In the following example, the **:::no-loc text="Client":::** project's namespace is `BlazorHosted.Client`.

In `Program.cs` of the **:::no-loc text="Client":::** project, add the namespace for the project's Razor components to the top of the file:

```csharp
using BlazorHosted.Client.Pages;
```

After the `builder` is established in `Program.cs`, add the `Counter` component as a root component:

```csharp
builder.RootComponents.Add<Counter>("#counter-component");
```

In the following Razor Pages example, the `Counter` component is rendered in a page. To make the component interactive, the Blazor WebAssembly script is included in the page's [render section](xref:mvc/views/layout#sections).

In the **:::no-loc text="Server":::** project, `Pages/RazorPagesCounter2.cshtml`:

```cshtml
@page

<div id="counter-component">Loading...</div>

@section Scripts {
    <script src="_framework/blazor.webassembly.js"></script>
}
```

Run the **:::no-loc text="Server":::** project. Navigate to the Razor page at `/razorpagescounter2`. The prerendered `Counter` component is embedded in the page.

Additional work might be required depending on the static resources that components use and how layout pages are organized in an app. Typically, scripts are added to a page or view's `Scripts` render section and stylesheets are added to the layout's `<head>` element content.

> [!NOTE]
> The preceding example throws a <xref:Microsoft.JSInterop.JSException> if a Blazor WebAssembly app is prerendered and integrated into a Razor Pages or MVC app **simultaneously** with a CSS selector. Navigating to one of the **:::no-loc text="Client":::** project's Razor components throws the following exception:
>
> > Microsoft.JSInterop.JSException: Could not find any element matching selector '#counter-component'.
>
> This is normal behavior because prerendering and integrating a Blazor WebAssembly app with routable Razor components is incompatible with the use of CSS selectors.

## Additional Blazor WebAssembly resources

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering)
* [Prerendering support with assembly lazy loading](xref:blazor/webassembly-lazy-load-assemblies#lazy-load-assemblies-in-a-hosted-blazor-webassembly-solution)
* Razor component lifecycle subjects that pertain to prerendering
  * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
  * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
  * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering): Although the content in the section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see *Persist prerendered state* section of this article.
  * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop)
* Authentication and authorization subjects that pertain to prerendering
  * [General aspects](xref:blazor/security/index#aspnet-core-blazor-authentication-and-authorization)
  * [Prerendering with authentication](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication)
* [Host and deploy: Blazor WebAssembly](xref:blazor/host-and-deploy/webassembly)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Integrating Razor components into Razor Pages or MVC apps in a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) is supported in ASP.NET Core in .NET 5 or later. Select a .NET 5 or later version of this article.

:::moniker-end
