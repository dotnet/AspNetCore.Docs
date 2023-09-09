---
title: ASP.NET Core Blazor render modes
author: guardrex
description: Learn about Blazor render modes and how to apply them in Blazor Web Apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/08/2023
uid: blazor/fundamentals/render-modes
---
# ASP.NET Core Blazor render modes

This article explains control of Razor component rendering in Blazor Web Apps, either at compile time or runtime.

## Render modes

Every component in a Blazor Web App adopts a *render mode* to determine the hosting model that it uses, where it's rendered, and whether or not it's interactive.

The following table shows the available render modes for rendering Razor components in a Blazor Web App. To apply a render mode to a component use the `@rendermode` directive on the component instance or use the [`@attribute` Razor directive](xref:mvc/views/razor#attribute) with the corresponding render mode attribute in the component's Razor markup. Later in this article, examples are shown for each render mode scenario.

Name | Description | Render location | Interactive
---- | ----------- | :-------------: | :---------:
Static | Static server rendering |  Server  | <span aria-hidden="true">❌</span><span class="visually-hidden">No</span>
Server | Interactive server rendering using Blazor Server | Server | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
WebAssembly | Interactive client rendering using Blazor WebAssembly | Client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Auto | Interactive client rendering using Blazor Server initially and then WebAssembly on subsequent visits once download | Server, then client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>

The following examples demonstrate setting the component's render mode with a few basic Razor component features.

To test the render mode behaviors locally, you can place the following components in an app created from the *Blazor Web App* project template. When you create the app, select the checkboxes (Visual Studio) or apply the CLI options (.NET CLI) to enable both server-side and client-side interactivity. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

## Enable support for interactive render modes

A Blazor Web App must be configured to support interactive render modes. The following extensions are automatically applied to apps created from the [*Blazor Web App* project template](xref:blazor/tooling) when either or both of server-side component interactivity and client-side component interactivity are enabled during app creation. Individual components are still required to declare their render mode per the [*Render modes*](#render-modes) section after the component services and endpoints are configured in the app's `Program` file.

Services for Razor components are added by calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>.

Component builder extensions:

* <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsBuilderExtensions.AddServerComponents%2A> adds services to support rendering interactive server components.
* `AddWebAssemblyComponents` adds services to support rendering interactive WebAssembly components.

<!-- UPDATE 8.0 HOLD
     <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddWebAssemblyComponents%2A>
-->

<xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> discovers available components and specifies the root component for the app, which by default is the `App` component (`App.razor`).

Endpoint convention builder extensions:

* <xref:Microsoft.AspNetCore.Builder.RazorComponentEndpointConventionBuilder.AddServerRenderMode%2A> configures the Server render mode for the app.
* `AddWebAssemblyRenderMode` configures the WebAssembly render mode for the app.

<!-- UPDATE 8.0 HOLD
    <xref:Microsoft.AspNetCore.Builder.WebAssemblyRazorComponentsEndpointConventionBuilderExtensions.AddWebAssemblyRenderMode%2A>
-->

Example 1: The following `Program` file API adds services and a render mode for Razor components with only server-side rendering support:

```csharp
...

builder.Services.AddRazorComponents()
    .AddServerComponents();
    

...

app.MapRazorComponents<App>()
    .AddServerRenderMode();

...
```

Example 2: The following `Program` file API adds services and a render mode for Razor components with only client-side rendering support:

```csharp
...

builder.Services.AddRazorComponents()
    .AddWebAssemblyComponents();

...

app.MapRazorComponents<App>()
    .AddWebAssemblyRenderMode();

...
```

Example 3: The following `Program` file API adds services and render modes for Razor components with both server-side and client-side rendering support:

```csharp
...

builder.Services.AddRazorComponents()
    .AddServerComponents()
    .AddWebAssemblyComponents();

...

app.MapRazorComponents<App>()
    .AddServerRenderMode()
    .AddWebAssemblyRenderMode();

...
```

## Apply a render mode

### Routable page components

To specify the render mode for an entire page you need to use the @attribute directive and the corresponding render mode attribute. But since pages are typically defined by app developers, not library authors, it's still the app developer that is in control of the render mode.

```razor
@page "{ROUTE}"
@attribute [RenderModeServer]
```

In the preceding example, the `{ROUTE}` placeholder is the route template.

### Non-routable, non-page components

Typically, non-routable, non-page components are created render mode agnostic. The developer usually applies a render mode to a given component using the `@rendermode` directive on the component instance.

In the following example, the `Dialog` component doesn't specify a render mode. The render mode is applied where the `Dialog` component is used:

<!-- UPDATE 8.0 RC2: Remove preview remark update code -->

```razor
<Dialog @rendermode="new ServerRenderMode()" />
```

> [!NOTE]
> The preceding syntax will be simplified in an upcoming preview release.

### Static render mode

By default components use the Static render mode. The component renders to the response stream and interactivity isn't enabled.

In the following example, there's no designation for the component's render mode. Therefore, the component is *statically rendered* on the server. The button isn't interactive and doesn't call the `UpdateMessage` method when selected. The value of `message` doesn't change, and the component isn't rerendered in response to UI events.

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

If using the preceding component locally in a Blazor Web App, place the component in the server-side project's `Components/Pages` folder. The server-side project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-1` in the browser's address bar.

> [!NOTE]
> The anatomy of a basic Razor component is fully explained in the <xref:blazor/fundamentals/index> article. Project structure for apps created by a Blazor template are described in the <xref:blazor/project-structure> article. Detailed components coverage is found in the *Components* articles later in the documentation.

### Server render mode

The Server render mode renders the component interactively from the server using Blazor Server. User interactions are handled over a SignalR connection.

In the following example, the render mode is set to Server by adding `@attribute [RenderModeServer]` to the component definition. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI.

`RenderMode2.razor`:

```razor
@page "/render-mode-2"
@attribute [RenderModeServer]

<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If using the preceding component locally in a Blazor Web App, place the component in the server-side project's `Components/Pages` folder. The server-side project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-2` in the browser's address bar.

### Client render mode

The Client render mode renders the component interactively on the client using Blazor WebAssembly.

In the following example, the render mode is set to use the Blazor WebAssembly hosting model with `@attribute [RenderModeWebAssembly]`. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI.

`RenderMode3.razor`:

```razor
@page "/render-mode-3"
@attribute [RenderModeWebAssembly]

<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If using the preceding component locally in a Blazor Web App, place the component in the client-side project's `Pages` folder. The client-side project is the solution's project with a name that ends in `.Client`. When the app is running, navigate to `/render-mode-3` in the browser's address bar.

### Auto render mode

The Auto render mode determines how to render the component at runtime. The component is initially rendered server-side with interactivity using the Blazor Server hosting model. The Blazor WebAssembly runtime and app bundle are downloaded to the client in the background and cached so that they can be used on future visits.

In the following example, the component is interactive throughout the process. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI. Initially, the component is rendered interactively from the server, but on subsequent visits it's rendered from the client after the Blazor WebAssembly runtime and app bundle are downloaded and cached.

`RenderMode4.razor`:

```razor
@page "/render-mode-4"
@attribute [RenderModeAuto]

<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If using the preceding component locally in a Blazor Web App, place the component in the client-side project's `Pages` folder. The client-side project is the solution's project with a name that ends in `.Client`. When the app is running, navigate to `/render-mode-4` in the browser's address bar.

## Render mode propagation

Render modes propagate down the component hierarchy. Consider the following `SharedMessage` component for use in other components that doesn't indicate a render mode.

`SharedMessage.razor`:

```razor
<button @onclick="UpdateMessage">Click me</button> @message

@code {
    private string message = "Not clicked yet.";

    private void UpdateMessage()
    {
        message = "Somebody clicked me!";
    }
}
```

If the `SharedMessage` component is placed in a statically-rendered parent component, the `SharedMessage` component is also rendered statically and isn't interactive. The button doesn't call `UpdateMessage`, and the message isn't updated.

`PassedRenderMode.razor`:

```razor
@page "/passed-render-mode"

<SharedMessage />
```

If the `SharedMessage` component is placed in a component that defines the render mode, it inherits the applied render mode.

In the following example, the `SharedMessage` component is interactive over a SignalR connection to the client. The button calls `UpdateMessage`, and the message is updated.

`PassedRenderMode2.razor`:

```razor
@page "/passed-render-mode-2"
@attribute [RenderModeServer]

<SharedMessage />
```

Additional rules for applying render modes:

* You can't switch to a different interactive render mode in a child component. For example, a Server component can't be a child of a WebAssembly component.
* Parameters passed to an interactive child component from a Static parent must be JSON serializable. This means that you can't pass render fragments or child content from a Static parent component to an interactive child component.

## Set the render mode for the entire app

<!-- UPDATE 8.0 RC2: Remove preview remark update code -->

To set the render mode for the entire app, indicate the render mode at the highest level component in the app's component hierarchy, typically the `Routes` component (`Components/App.razor`) for apps based on the Blazor Web App project template:

```razor
<Routes @rendermode="new ServerRenderMode()" />
```

> [!NOTE]
> The preceding syntax will be simplified in an upcoming preview release.

The Blazor router propagates its render mode to the pages it routes. The pages aren't technically child components of the router, but when the routes are discovered at runtime for the router, they inherit the router's render mode.

You also typically need to set the same interactive render mode on the `HeadOutlet` component, also in the `App` component:

```
<HeadOutlet @rendermode="new ServerRenderMode()" />
```

> [!NOTE]
> Making a root component interactive, such as the `App` component, isn't supported because the Blazor script might be evaluated multiple times.

> [!NOTE]
> In an upcoming preview release, a template option for the Blazor Web App template to create the app with root-level interactivity.

<!-- UPDATE 8.0 The preceding is tracked by https://github.com/dotnet/aspnetcore/issues/50433 -->
