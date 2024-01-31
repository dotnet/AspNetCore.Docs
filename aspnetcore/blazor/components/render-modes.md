---
title: ASP.NET Core Blazor render modes
author: guardrex
description: Learn about Blazor render modes and how to apply them in Blazor Web Apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/render-modes
---
# ASP.NET Core Blazor render modes

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains control of Razor component rendering in Blazor Web Apps, either at compile time or runtime.

> [!NOTE]
> This guidance doesn't apply to standalone Blazor WebAssembly apps.

## Render modes

Every component in a Blazor Web App adopts a *render mode* to determine the hosting model that it uses, where it's rendered, and whether or not it's interactive.

The following table shows the available render modes for rendering Razor components in a Blazor Web App. To apply a render mode to a component use the `@rendermode` directive on the component instance or on the component definition. Later in this article, examples are shown for each render mode scenario.

Name | Description | Render location | Interactive
---- | ----------- | :-------------: | :---------:
Static Server | Static server-side rendering (static SSR) |  Server  | <span aria-hidden="true">❌</span><span class="visually-hidden">No</span>
Interactive Server | Interactive server-side rendering (interactive SSR) using Blazor Server. | Server | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive WebAssembly | Client-side rendering (CSR) using Blazor WebAssembly&dagger;. | Client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive Auto | Interactive SSR using Blazor Server initially and then CSR on subsequent visits after the Blazor bundle is downloaded. | Server, then client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>

&dagger;Client-side rendering (CSR) is assumed to be interactive. "*Interactive* client-side rendering" and "*interactive* CSR" aren't used by the industry or in the Blazor documentation.

Prerendering is enabled by default for interactive components. Guidance on controlling prerendering is provided later in this article. For general industry terminology on client and server rendering concepts, see <xref:blazor/fundamentals/index#client-and-server-rendering-concepts>.

The following examples demonstrate setting the component's render mode with a few basic Razor component features.

To test the render mode behaviors locally, you can place the following components in an app created from the *Blazor Web App* project template. When you create the app, select the checkboxes (Visual Studio) or apply the CLI options (.NET CLI) to enable both server-side and client-side interactivity. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

## Enable support for interactive render modes

A Blazor Web App must be configured to support interactive render modes. The following extensions are automatically applied to apps created from the *Blazor Web App* project template during app creation. Individual components are still required to declare their render mode per the [*Render modes*](#render-modes) section after the component services and endpoints are configured in the app's `Program` file.

Services for Razor components are added by calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>.

Component builder extensions:

* <xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A> adds services to support rendering Interactive Server components.
* <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddInteractiveWebAssemblyComponents%2A> adds services to support rendering Interactive WebAssembly components.

<xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> discovers available components and specifies the root component for the app (the first component loaded), which by default is the `App` component (`App.razor`).

Endpoint convention builder extensions:

* <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> configures interactive server-side rendering (interactive SSR) for the app.
* <xref:Microsoft.AspNetCore.Builder.WebAssemblyRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveWebAssemblyRenderMode%2A> configures the Interactive WebAssembly render mode for the app.

> [!NOTE]
> For orientation on the placement of the API in the following examples, inspect the `Program` file of an app generated from the Blazor Web App project template. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

Example 1: The following `Program` file API adds services and configuration for enabling interactive SSR:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

Example 2: The following `Program` file API adds services and configuration for enabling the Interactive WebAssembly render mode:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode();
```

Example 3: The following `Program` file API adds services and configuration for enabling the Interactive Server, Interactive WebAssembly, and Interactive Auto render modes:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();
```

Blazor uses the Blazor WebAssembly hosting model to download and execute components that use the Interactive WebAssembly render mode. A separate client project is required to set up Blazor WebAssembly hosting for these components. The client project contains the startup code for the Blazor WebAssembly host and sets up the .NET runtime for running in a browser. The Blazor Web App template adds this client project for you when you select the option to enable WebAssembly interactivity. Any components using the Interactive WebAssembly render mode should be built from the client project, so they get included in the downloaded app bundle.

## Apply a render mode to a component instance

To apply a render mode to a component instance use the [`@rendermode` Razor directive attribute](xref:mvc/views/razor#rendermode) where the component is used.

In the following example, interactive server-side rendering (interactive SSR) is applied to the `Dialog` component instance:

```razor
<Dialog @rendermode="InteractiveServer" />
```

> [!NOTE]
> Blazor templates include a static `using` directive for <xref:Microsoft.AspNetCore.Components.Web.RenderMode> in the app's `_Imports` file (`Components/_Imports.razor`) for shorter `@rendermode` syntax:
>
> ```razor
> @using static Microsoft.AspNetCore.Components.Web.RenderMode
> ```
>
> Without the preceding directive, components must specify the static <xref:Microsoft.AspNetCore.Components.Web.RenderMode> class in `@rendermode` syntax:
>
> ```razor
> <Dialog @rendermode="RenderMode.InteractiveServer" />
> ```

You can also reference custom render mode instances instantiated directly with custom configuration. For more information, see the [Custom shorthand render modes](#custom-shorthand-render-modes) section later in this article.

## Apply a render mode to a component definition

To specify the render mode for a component as part of its definition, use the [`@rendermode` Razor directive](xref:mvc/views/razor#rendermode) and the corresponding render mode attribute.

```razor
@page "..."
@rendermode InteractiveServer
```

Applying a render mode to a component definition is commonly used when applying a render mode to a specific page. Routable pages by default use the same render mode as the <xref:Microsoft.AspNetCore.Components.Routing.Router> component that rendered the page.

Technically, `@rendermode` is both a Razor *directive* and a Razor *directive attribute*. The semantics are similar, but there are differences. The `@rendermode` directive is on the component definition, so the referenced render mode instance must be static. The `@rendermode` directive attribute can take any render mode instance.

> [!NOTE]
> Component authors should avoid coupling a component's implementation to a specific render mode. Instead, component authors should typically design components to support any render mode or hosting model. A component's implementation should avoid assumptions on where it's running (server or client) and should degrade gracefully when rendered statically. Specifying the render mode in the component definition may be needed if the component isn't instantiated directly (such as with a routable page component) or to specify a render mode for all component instances.

## Apply a render mode to the entire app

To set the render mode for the entire app, indicate the render mode at the highest-level interactive component in the app's component hierarchy that isn't a root component.

> [!NOTE]
> Making a root component interactive, such as the `App` component, isn't supported. Therefore, the render mode for the entire app can't be set directly by the `App` component.

For apps based on the Blazor Web App project template, a render mode assigned to the entire app is typically specified where the `Routes` component is used in the `App` component (`Components/App.razor`):

```razor
<Routes @rendermode="InteractiveServer" />
```

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component propagates its render mode to the pages it routes.

You also typically must set the same interactive render mode on the [`HeadOutlet` component](xref:blazor/components/control-head-content#headoutlet-component), which is also found in the `App` component of a Blazor Web App generated from the project template:

```
<HeadOutlet @rendermode="InteractiveServer" />
```

For apps that adopt an interactive client-side (WebAssembly or Auto) rendering mode and enable the render mode for the entire app via the `Routes` component:

* Place or move the layout and navigation files of the server app's `Components/Layout` folder into the `.Client` project's `Layout` folder. Create a `Layout` folder in the `.Client` project if it doesn't exist.
* Place or move the components of the server app's `Components/Pages` folder into the `.Client` project's `Pages` folder. Create a `Pages` folder in the `.Client` project if it doesn't exist.
* Place or move the `Routes` component of the server app's `Components` folder into the `.Client` project's root folder.

To enable global interactivity when creating a Blazor Web App:

* Visual Studio: Set the **Interactivity location** dropdown list to **Global**.
* .NET CLI: Use the `-ai|--all-interactive` option.

For more information, see <xref:blazor/tooling>.

## Apply a render mode programatically

Properties and fields can assign a render mode.

The second approach described in this section, setting the render mode by component instance, is especially useful when your app specification calls for either of the following scenarios:

* You have an area (folder) of the app with components that must adopt static server-side rendering (static SSR) and only run on the server. The app controls the render mode globally by setting the render mode on the `Routes` component in the `App` component based on the path to the folder.
* You have components around the app in various locations (not in a single folder) that must adopt static SSR and only run on the server. The app controls the render mode on a per-component basis by setting the render mode with the `@rendermode` directive in component instances. Reflection is used in the `App` component to set the render mode on the `Routes` component.

In both cases, the component that must adopt static SSR must also force a full-page reload.

The preceding two scenarios are covered with examples in the [Fine control of render modes](#fine-control-of-render-modes) section later in this article. The following two subsections focus on basic approaches for setting the render mode.

### Set the render mode by component definition

A component definition can define a render mode via a private field:

```razor
@rendermode renderModeForPage

...

@code {
    private static IComponentRenderMode renderModeForPage = InteractiveServer;
}
```

### Set the render mode by component instance

The following example applies interactive server-side rendering (interactive SSR) to any request.

```razor
<Routes @rendermode="RenderModeForPage" />

...

@code {
    private IComponentRenderMode? RenderModeForPage => InteractiveServer;
}
```

Additional information on render mode propagation is provided in the [Render mode propagation](#render-mode-propagation) section later in this article. The [Fine control of render modes](#fine-control-of-render-modes) section shows how to use the preceding approach to adopt static SSR in either specific areas of the app (folders) or for specific components spread around the app with per-component render mode assignments.

## Prerendering

*Prerendering* is the process of initially rendering page content on the server without enabling event handlers for rendered controls. The server outputs the HTML UI of the page as soon as possible in response to the initial request, which makes the app feel more responsive to users. Prerendering can also improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines use to calculate page rank.

Prerendering is enabled by default for interactive components.

To disable prerendering for a *component instance*, pass the `prerender` flag with a value of `false` to the render mode:

* `<... @rendermode="new InteractiveServerRenderMode(prerender: false)" />`
* `<... @rendermode="new InteractiveWebAssemblyRenderMode(prerender: false)" />`
* `<... @rendermode="new InteractiveAutoRenderMode(prerender: false)" />`

To disable prerendering in a *component definition*:

* `@rendermode @(new InteractiveServerRenderMode(prerender: false))`
* `@rendermode @(new InteractiveWebAssemblyRenderMode(prerender: false))`
* `@rendermode @(new InteractiveAutoRenderMode(prerender: false))`

To disable prerendering for the entire app, indicate the render mode at the highest-level interactive component in the app's component hierarchy that isn't a root component.

For apps based on the Blazor Web App project template, a render mode assigned to the entire app is specified where the `Routes` component is used in the `App` component (`Components/App.razor`). The following example sets the app's render mode to Interactive Server with prerendering disabled:

```razor
<Routes @rendermode="new InteractiveServerRenderMode(prerender: false)" />
```

Also, disable prerendering for the [`HeadOutlet` component](xref:blazor/components/control-head-content#headoutlet-component) in the `App` component:

```razor
<HeadOutlet @rendermode="new InteractiveServerRenderMode(prerender: false)" />
```

Making a root component, such as the `App` component, interactive with the `@rendermode` directive at the top of the root component's definition file (`.razor`) isn't supported. Therefore, prerendering can't be disabled directly by the `App` component.

## Static server-side rendering (static SSR)

By default, components use the static server-side rendering (static SSR). The component renders to the response stream and interactivity isn't enabled.

In the following example, there's no designation for the component's render mode, and the component inherits the default render mode from its parent. Therefore, the component is *statically rendered* on the server. The button isn't interactive and doesn't call the `UpdateMessage` method when selected. The value of `message` doesn't change, and the component isn't rerendered in response to UI events.

`RenderMode1.razor`:

```razor
@page "/render-mode-1"

<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If using the preceding component locally in a Blazor Web App, place the component in the server project's `Components/Pages` folder. The server project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-1` in the browser's address bar.

[Enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) with static SSR requires special attention when loading JavaScript. For more information, see <xref:blazor/js-interop/ssr>.

## Interactive server-side rendering (interactive SSR)

Interactive server-side rendering (interactive SSR) renders the component interactively from the server using Blazor Server. User interactions are handled over a real-time connection with the browser. The circuit connection is established when the Server component is rendered.

In the following example, the render mode is set interactive SSR by adding `@rendermode InteractiveServer` to the component definition. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI.

`RenderMode2.razor`:

```razor
@page "/render-mode-2"
@rendermode InteractiveServer

<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If using the preceding component locally in a Blazor Web App, place the component in the server project's `Components/Pages` folder. The server project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-2` in the browser's address bar.

## Client-side rendering (CSR)

Client-side rendering (CSR) renders the component interactively on the client using Blazor WebAssembly. The .NET runtime and app bundle are downloaded and cached when the WebAssembly component is initially rendered. Components using CSR must be built from a separate client project that sets up the Blazor WebAssembly host.

In the following example, the render mode is set to CSR with `@rendermode InteractiveWebAssembly`. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI.

`RenderMode3.razor`:

```razor
@page "/render-mode-3"
@rendermode InteractiveWebAssembly

<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If using the preceding component locally in a Blazor Web App, place the component in the client project's `Pages` folder. The client project is the solution's project with a name that ends in `.Client`. When the app is running, navigate to `/render-mode-3` in the browser's address bar.

## Automatic (Auto) rendering

Automatic (Auto) rendering determines how to render the component at runtime. The component is initially rendered with interactive server-side rendering (interactive SSR) using the Blazor Server hosting model. The .NET runtime and app bundle are downloaded to the client in the background and cached so that they can be used on future visits.

The Auto render mode never dynamically changes the render mode of a component already on the page. The Auto render mode makes an initial decision about which type of interactivity to use for a component, then the component keeps that type of interactivity for as long as it's on the page. One factor in this initial decision is considering whether components already exist on the page with WebAssembly/Server interactivity. Auto mode prefers to select a render mode that matches the render mode of existing interactive components. The reason that the Auto mode prefers to use an existing interactivity mode is to avoid introducing a new interactive runtime that doesn't share state with the existing runtime.

Components using the Auto render mode must be built from a separate client project that sets up the Blazor WebAssembly host.

In the following example, the component is interactive throughout the process. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI. Initially, the component is rendered interactively from the server, but on subsequent visits it's rendered from the client after the .NET runtime and app bundle are downloaded and cached.

`RenderMode4.razor`:

```razor
@page "/render-mode-4"
@rendermode InteractiveAuto

<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If using the preceding component locally in a Blazor Web App, place the component in the client project's `Pages` folder. The client project is the solution's project with a name that ends in `.Client`. When the app is running, navigate to `/render-mode-4` in the browser's address bar.

## Render mode propagation

Render modes propagate down the component hierarchy.

Rules for applying render modes:

* The default render mode is Static. 
* The Interactive Server (<xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveServer>), Interactive WebAssembly (<xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveWebAssembly>), and Interactive Auto (<xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveAuto>) render modes can be used from a component, including using different render modes for sibling components. 
* You can't switch to a different interactive render mode in a child component. For example, a Server component can't be a child of a WebAssembly component.
* Parameters passed to an interactive child component from a Static parent must be JSON serializable. This means that you can't pass render fragments or child content from a Static parent component to an interactive child component.

The following examples use a non-routable, non-page `SharedMessage` component. The render mode agnostic `SharedMessage` component doesn't apply a render mode with an [`@attribute` directive](xref:mvc/views/razor#attribute). If you're testing these scenarios with a Blazor Web App, place the following component in the app's `Components` folder.

`SharedMessage.razor`:

```razor
<p>@Greeting</p>

<button @onclick="UpdateMessage">Click me</button> @message

<p>@ChildContent</p>

@code {
    private string message = "Not clicked yet.";

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string Greeting { get; set; } = "Hello!";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

### Render mode inheritance

If the `SharedMessage` component is placed in a statically-rendered parent component, the `SharedMessage` component is also rendered statically and isn't interactive. The button doesn't call `UpdateMessage`, and the message isn't updated.

`RenderMode5.razor`:

```razor
@page "/render-mode-5"

<SharedMessage />
```

If the `SharedMessage` component is placed in a component that defines the render mode, it inherits the applied render mode.

In the following example, the `SharedMessage` component is interactive over a SignalR connection to the client. The button calls `UpdateMessage`, and the message is updated.

`RenderMode6.razor`:

```razor
@page "/render-mode-6"
@rendermode InteractiveServer

<SharedMessage />
```

### Child components with different render modes

In the following example, both `SharedMessage` components are prerendered (by default) and appear when the page is displayed in the browser.

* The first `SharedMessage` component with interactive server-side rendering (interactive SSR) is interactive after the SignalR circuit is established.
* The second `SharedMessage` component with client-side rendering (CSR) is interactive *after* the Blazor app bundle is downloaded and the .NET runtime is active on the client.

`RenderMode7.razor`:

```razor
@page "/render-mode-7"

<SharedMessage @rendermode="InteractiveServer" />
<SharedMessage @rendermode="InteractiveWebAssembly" />
```

### Child component with a serializable parameter

The following example demonstrates an interactive child component that takes a parameter. Parameters must be serializable.

`RenderMode8.razor`:

```razor
@page "/render-mode-8"

<SharedMessage @rendermode="InteractiveServer" Greeting="Welcome!" />
```

Non-serializable component parameters, such as child content or a render fragment, are ***not*** supported. In the following example, passing child content to the `SharedMessage` component results in a runtime error.

`RenderMode9.razor`:

```razor
@page "/render-mode-9"

<SharedMessage @rendermode="InteractiveServer">
    Child content
</SharedMessage>
```

<span aria-hidden="true">❌</span> **Error**:

> :::no-loc text="System.InvalidOperationException: Cannot pass the parameter 'ChildContent' to component 'SharedMessage' with rendermode 'InteractiveServerRenderMode'. This is because the parameter is of the delegate type 'Microsoft.AspNetCore.Components.RenderFragment', which is arbitrary code and cannot be serialized.":::

To circumvent the preceding limitation, wrap the child component in another component that doesn't have the parameter. This is the approach taken in the Blazor Web App project template with the `Routes` component (`Components/Routes.razor`) to wrap the <xref:Microsoft.AspNetCore.Components.Routing.Router> component.

`WrapperComponent.razor`:

```razor
<SharedMessage>
    Child content
</SharedMessage>
```

`RenderMode10.razor`:

```razor
@page "/render-mode-10"

<WrapperComponent @rendermode="InteractiveServer" />
```

In the preceding example:

* The child content is passed to the `SharedMessage` component without generating a runtime error.
* The `SharedMessage` component renders interactively on the server.

### Child component with a different render mode than its parent

Don't try to apply a different interactive render mode to a child component than its parent's render mode.

The following component results in a runtime error when the component is rendered:

`RenderMode11.razor`:

```razor
@page "/render-mode-11"
@rendermode InteractiveServer

<SharedMessage @rendermode="InteractiveWebAssembly" />
```

<span aria-hidden="true">❌</span> **Error**:

> :::no-loc text="Cannot create a component of type 'BlazorSample.Components.SharedMessage' because its render mode 'Microsoft.AspNetCore.Components.Web.InteractiveWebAssemblyRenderMode' is not supported by Interactive Server rendering.":::

## Fine control of render modes

There are cases where the app's specification calls for components to adopt static server-side rendering (static SSR) and only run on the server, while the rest of the app uses an interactive render mode.

There are two approaches that can be taken for fine control of render modes, each of which is described in the following subsections:

* [Area (folder) of static SSR components](#area-folder-of-static-ssr-components): You have an area (folder) of the app with components that must adopt static SSR and share the same route path prefix. The app controls the render mode globally by setting the render mode on the `Routes` component in the `App` component based on the path to the folder.

* [Static SSR components spread out across the app](#static-ssr-components-spread-out-across-the-app): You have components spread around the app in various locations that must adopt static SSR and only run on the server. The static SSR-only components aren't in a single folder and don't share a common route path prefix. The app controls the render mode on a per-component basis by setting the render mode with the `@rendermode` directive in component instances. Reflection is used in the `App` component to set the render mode on the `Routes` component.

In both cases, the component that must adopt static SSR must also force a full-page reload.

The following examples use the <xref:Microsoft.AspNetCore.Http.HttpContext> cascading parameter to determine if the page is statically-rendered. A `null` <xref:Microsoft.AspNetCore.Http.HttpContext> indicates that the component is rendering interactively, which is useful as a signal in app code to trigger a full-page reload.

### Area (folder) of static SSR components

The approach described in this subsection is used by the Blazor Web App project template with individual authentication and global interactivity.

An area (folder) of the app contains the components that must adopt static SSR and only run on the server. The components in the folder share the same route path prefix. For example, the Identity Razor components of the Blazor Web App project template are in the `Components/Account/Pages` folder and share the root path prefix `/Account`.

The folder also contains an `_Imports.razor` file, which applies a custom account layout to the components in the folder:

```razor
@using BlazorSample.Components.Account.Shared
@layout AccountLayout
```

The `Shared` folder maintains the `AccountLayout` layout component. The component makes use of <xref:Microsoft.AspNetCore.Http.HttpContext> to determine if the component is rendering on the server. Identity components must render on the server with static SSR because they set Identity cookies. If the value of <xref:Microsoft.AspNetCore.Http.HttpContext> is `null`, the component is rendering interactively, and a full-page reload is performed by calling <xref:Microsoft.AspNetCore.Components.NavigationManager.Refresh%2A?displayProperty=nameWithType> with `forceLoad` set to `true`. This forces a full rerender of the page using static SSR.

`Components/Account/Shared/AccountLayout.razor`:

```razor
@inherits LayoutComponentBase
@layout BlazorSample.Components.Layout.MainLayout
@inject NavigationManager NavigationManager

@if (HttpContext is null)
{
    <p>Loading...</p>
}
else
{
    @Body
}

@code {
    [CascadingParameter]
    private HttpContext? HttpContext { get; set; }

    protected override void OnParametersSet()
    {
        if (HttpContext is null)
        {
            NavigationManager.Refresh(forceReload: true);
        }
    }
}
```

> [!NOTE]
> In the Blazor Web App project template, there's a second layout file (`ManageLayout.razor` in the `Components/Account/Shared` folder) for Identity components in the `Components/Account/Pages/Manage` folder. The `Manage` folder has its own `_Imports.razor` file to apply to the `ManageLayout` to components in the folder. In your own apps, using nested `_Imports.razor` files is a useful approach for applying custom layouts to groups of pages.

In the `App` component, any request for a component in the `Account` folder applies a `null` render mode, which enforces static SSR. Other component requests receive a global application of the interactive SSR render mode (`InteractiveServer`).

> [!IMPORTANT]
> Applying a `null` render mode doesn't always enforce static SSR. It just happens to behave that way using the approach shown in this section.
>
> A `null` render mode is effectively the same as not specifying a render mode, which results in the component inheriting its parent's render mode. In this case, the `App` component is rendered using static SSR, so a `null` render mode results in the `Routes` component inheriting static SSR from the `App` component. If a null render mode is specified for a child component whose parent uses an interactive render mode, the child inherits the same interactive render mode.

`Components/App.razor`:

```razor
<Routes @rendermode="RenderModeForPage" />

...

@code {
    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    private IComponentRenderMode? RenderModeForPage => 
        HttpContext.Request.Path.StartsWithSegments("/Account")
            ? null
            : {INTERACTIVE RENDER MODE};
}
```

In the preceding code, change the `{INTERACTIVE RENDER MODE}` placeholder to the appropriate value, depending on if the rest of the application should adopt global <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveServer>, <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveWebAssembly>, or <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveAuto> rendering.

The components that must adopt static SSR in the `Account` folder aren't required to set the layout because it's applied via the `_Imports.razor` file, and the components do ***not*** set a render mode because they should render with static SSR. Nothing further must be done for the components in the `Account` folder to enforce static SSR.

### Static SSR components spread out across the app

In the [preceding subsection](#area-folder-of-static-ssr-components), the app controls the render mode of the components by setting the render mode globally in the `App` component. Alternatively, the `App` component can also adopt ***per-component*** render modes for setting the render mode, which permits components spread around the app to enforce adoption of static SSR. This subsection describes the approach.

The app has a custom layout that can be applied to components around the app. Usually, a shared component for the app is placed in the `Components/Layout` folder. The component makes use of <xref:Microsoft.AspNetCore.Http.HttpContext> to determine if the component is rendering on the server. If the value of <xref:Microsoft.AspNetCore.Http.HttpContext> is `null`, the component is rendering interactively, and a full-page reload is performed by calling <xref:Microsoft.AspNetCore.Components.NavigationManager.Refresh%2A?displayProperty=nameWithType> with `forceLoad` set to `true`. This triggers a request to the server for the component.

`Components/Layout/StaticSsrLayout.razor`:

```razor
@inherits LayoutComponentBase
@layout MainLayout
@inject NavigationManager NavigationManager

@if (HttpContext is null)
{
    <p>Loading...</p>
}
else
{
    @Body
}

@code {
    [CascadingParameter]
    private HttpContext? HttpContext { get; set; }

    protected override void OnParametersSet()
    {
        if (HttpContext is null)
        {
            NavigationManager.Refresh(forceReload: true);
        }
    }
}
```

In the `App` component, reflection is used to set the render mode. Whatever render mode is assigned to the individual component definition file is applied to the `Routes` component.

`Components/App.razor`:

```razor
<Routes @rendermode="RenderModeForPage" />

...

@code {
    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    private IComponentRenderMode? RenderModeForPage =>
        HttpContext.GetEndpoint()?.Metadata.GetMetadata<RenderModeAttribute>()?
            .Mode;
}
```

Each component that must adopt static SSR sets the custom layout and does ***not*** specify a render mode. Not specifying a render mode results in a `null` value of <xref:Microsoft.AspNetCore.Components.RenderModeAttribute.Mode?displayProperty=nameWithType> in the `App` component, which results in no render mode assigned to the `Routes` component instance and enforcement of static SSR.

> [!IMPORTANT]
> Applying a `null` render mode doesn't always enforce static SSR. It just happens to behave that way using the approach shown in this section.
>
> A `null` render mode is effectively the same as not specifying a render mode, which results in the component inheriting its parent's render mode. In this case, the `App` component is rendered using static SSR, so a `null` render mode results in the `Routes` component inheriting static SSR from the `App` component. If a null render mode is specified for a child component whose parent uses an interactive render mode, the child inherits the same interactive render mode.

Nothing further must be done for the components to enforce static SSR than applying the custom layout:

```razor
@layout BlazorSample.Components.Layout.StaticSsrLayout
```

Other components around the app set an appropriate interactive render mode, which upon reflection in the `App` component is applied to the `Routes` component. Interactive components ***avoid*** applying the custom static SSR layout:

```razor
@rendermode {INTERACTIVE RENDER MODE}
```

In the preceding code, change the `{INTERACTIVE RENDER MODE}` placeholder to the appropriate value, depending on if the component should adopt <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveServer>, <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveWebAssembly>, or <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveAuto> rendering.

## Client-side services fail to resolve during prerendering

Assuming that prerendering isn't disabled for a component or for the app, a component in the `.Client` project is prerendered on the server. Because the server doesn't have access to registered client-side Blazor services, it isn't possible to inject these services into a component without receiving an error that the service can't be found during prerendering.

For example, consider the following `Home` component in the `.Client` project in a Blazor Web App with [global Interactive WebAssembly or Interactive Auto rendering](#apply-a-render-mode-to-the-entire-app). The component attempts to inject <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> to obtain the environment's name.

```razor
@page "/"
@inject IWebAssemblyHostEnvironment Environment

<PageTitle>Home</PageTitle>

<h1>Home</h1>

<p>
    Environment: @Environment.Environment
</p>
```

No compile time error occurs, but a runtime error occurs during prerendering:

> :::no-loc text="Cannot provide a value for property 'Environment' on type 'BlazorSample.Client.Pages.Home'. There is no registered service of type 'Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment'.":::

This error occurs because the component must compile and execute on the server during prerendering, but <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> isn't a registered service on the server.

If the app doesn't require the value during prerendering, this problem can be solved by injecting <xref:System.IServiceProvider> to obtain the service instead of the service type itself:

```razor
@page "/"
@using Microsoft.AspNetCore.Components.WebAssembly.Hosting
@inject IServiceProvider Services

<PageTitle>Home</PageTitle>

<h1>Home</h1>

<p>
    <b>Environment:</b> @environmentName
</p>

@code {
    private string? environmentName;

    protected override void OnInitialized()
    {
        if (Services.GetService<IWebAssemblyHostEnvironment>() is { } env)
        {
            environmentName = env.Environment;
        }
    }
}
```

However, the preceding approach isn't useful if your logic requires a value during prerendering.

You can also avoid the problem if you [disable prerendering](#prerendering) for the component, but that's an extreme measure to take in many cases that may not meet your component's specifications.

There are a three approaches that you can take to address this scenario. The following are listed from most recommended to least recommended:

* *Recommended* for shared framework services: For shared framework services that merely aren't registered server-side in the main project, register the services in the main project, which makes them available during prerendering. For an example of this scenario, see the guidance for <xref:System.Net.Http.HttpClient> services in <xref:blazor/call-web-api?pivots=webassembly#client-side-services-for-httpclient-fail-during-prerendering>.

* *Recommended* for services outside of the shared framework: Create a custom service implementation for the service on the server. Use the service normally in interactive components of the `.Client` project. For a demonstration of this approach, see <xref:blazor/fundamentals/environments#read-the-environment-client-side-in-a-blazor-web-app>.

* Create a service abstraction and create implementations for the service in the `.Client` and server projects. Register the services in each project. Inject the custom service in the component.

* You might be able to add a `.Client` project package reference to a server-side package and fall back to using the server-side API when prerendering on the server.

## Discover components from additional assemblies

Additional assemblies must be disclosed to the Blazor framework to discover routable Razor components in referenced projects. For more information, see <xref:blazor/fundamentals/routing#route-to-components-from-multiple-assemblies>.

## Closure of circuits when there are no remaining Interactive Server components

[!INCLUDE[](~/blazor/includes/closure-of-circuits.md)]

## Custom shorthand render modes

The `@rendermode` directive takes a single parameter that's a static instance of type <xref:Microsoft.AspNetCore.Components.IComponentRenderMode>. The `@rendermode` directive attribute can take any render mode instance, static or not. The Blazor framework provides the <xref:Microsoft.AspNetCore.Components.Web.RenderMode> static class with some predefined render modes for convenience, but you can create your own.

Normally, a component uses the following `@rendermode` directive to [disable prerendering](#prerendering):

```razor
@rendermode @(new InteractiveServerRenderMode(prerender: false))
```

However, consider the following example that creates a shorthand interactive server-side render mode without prerendering via the app's `_Imports` file (`Components/_Imports.razor`):

```csharp
public static IComponentRenderMode InteractiveServerWithoutPrerendering { get; } = 
    new InteractiveServerRenderMode(prerender: false);
```

Use the shorthand render mode in components throughout the `Components` folder:

```razor
@rendermode InteractiveServerWithoutPrerendering
```

Alternatively, a single component instance can define a custom render mode via a private field:

```razor
@rendermode interactiveServerWithoutPrerendering

...

@code {
    private static IComponentRenderMode interactiveServerWithoutPrerendering = 
        new InteractiveServerRenderMode(prerender: false);
}
```

At the moment, the shorthand render mode approach is probably only useful for reducing the verbosity of specifying the `prerender` flag. The shorthand approach might be more useful in the future if additional flags become available for interactive rendering and you would like to create shorthand render modes with different combinations of flags.

## Additional resources

* <xref:blazor/js-interop/ssr>
* [Cascading values/parameters and render mode boundaries](xref:blazor/components/cascading-values-and-parameters#cascading-valuesparameters-and-render-mode-boundaries): Also see the [Root-level cascading parameters](xref:blazor/components/cascading-values-and-parameters#root-level-cascading-parameters) section earlier in the article.
* <xref:blazor/components/class-libraries-with-static-ssr>
