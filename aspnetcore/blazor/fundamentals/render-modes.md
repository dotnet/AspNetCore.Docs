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

The following table shows the four potential render mode scenarios for rendering Razor components in a Blazor Web App. The render mode attributes in the *Render mode attribute* column are applied to components with the [`@attribute` Razor directive](xref:mvc/views/razor#attribute). Later in this article, examples are shown for each render mode scenario.

Scenario              | Render mode attribute     | Hosting model                             | Render location     | Interactive
--------------------- | :-----------------------: | :---------------------------------------: | :-----------------: | :---------:
Statically-rendered   | None                      | None                                      | Server              | ❌
Server render mode    | `[RenderModeServer]`      | Blazor Server                             | Server              | ✔️
Client render mode    | `[RenderModeWebAssembly]` | Blazor WebAssembly                        | Client              | ✔️
Determined at runtime | `[RenderModeAuto]`        | Blazor Server,<br>then Blazor WebAssembly | Server, then client | ✔️

<!-- HOLD for final commit - We'll use accessible markup for the ❌ and ✔️:
<span aria-hidden="true">❌</span><span class="visually-hidden">No</span>
<span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
-->

The following examples demonstrate setting the component's render mode with a few basic Razor component features.

To test the render mode behaviors locally, you can place the following components in an app created from the *Blazor Web App* project template. When you create the app, select the checkboxes (Visual Studio) or apply the CLI options (.NET CLI) to enable both server-side and client-side interactivity. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

### Statically-rendered on the server without user interactivity

In the following example, there's no designation for the component's render mode. Therefore, the component is *statically rendered* on the server. The button isn't interactive and doesn't call the `UpdateMessage` method when selected. The value of `message` doesn't change, and the component isn't re-rendered.

If using the following component locally in a Blazor Web App, place the component in the server-side project's `Components/Pages` folder. The server-side project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-1` in the browser's address bar.

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

> [!NOTE]
> The anatomy of a basic Razor component is fully explained in the <xref:blazor/fundamentals/index> article. Project structure for apps created by a Blazor template are described in the <xref:blazor/project-structure> article. Detailed components coverage is found in the *Components* articles later in the documentation.

### Server render mode

Server render mode results in rendering a component on the server with user interactivity.

In the following example, the render mode is set to use the Blazor Server hosting model with `@attribute [RenderModeServer]`. Therefore, the component is rendered server-side with server-side interactivity over a SignalR connection. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is re-rendered to update the message in the UI.

If using the following component locally in a Blazor Web App, place the component in the server-side project's `Components/Pages` folder. The server-side project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-2` in the browser's address bar.

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

### Client render mode

Client render mode results in rendering a component on the client with user interactivity.

In the following example, the render mode is set to use the Blazor WebAssembly hosting model with `@attribute [RenderModeWebAssembly]`. Therefore, the component is rendered client-side with interactivity. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is re-rendered to update the message in the UI.

If using the following component locally in a Blazor Web App, place the component in the client-side project's `Pages` folder. The client-side project is the solution's project with a name that ends in `.Client`. When the app is running, navigate to `/render-mode-3` in the browser's address bar.

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

### Render mode determined at runtime

The render mode can be determined at runtime. The component is initially rendered server-side with interactivity using the Blazor Server hosting model. After the Blazor bundle is downloaded to the client and the .NET client-side runtime activates, the component adopts the Blazor WebAssembly hosting model for client-side rendering and interactivity.

In the following example, the component is interactive throughout the process. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is re-rendered, either server-side or client-side, to update the message in the UI.

If using the following component locally in a Blazor Web App, place the component in the client-side project's `Pages` folder. The client-side project is the solution's project with a name that ends in `.Client`. When the app is running, navigate to `/render-mode-4` in the browser's address bar.

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

`PassedRenderMode1.razor`:

```razor
@page "/passed-render-mode-1"

<SharedMessage />
```

If the `SharedMessage` component is placed in a server-rendered component, it adopts server-side rendering. The `SharedMessage` component is interactive over a SignalR connection to the client. The button calls `UpdateMessage`, and the message is updated.

`PassedRenderMode2.razor`:

```razor
@page "/passed-render-mode-2"
@attribute [RenderModeServer]

<SharedMessage />
```

If the `SharedMessage` component is placed in a client-rendered component, it adopts client-side rendering. The `SharedMessage` component is interactive on the client with the .NET WebAssembly-based runtime. The button calls `UpdateMessage`, and the message is updated.

`PassedRenderMode3.razor`:

```razor
@page "/passed-render-mode-3"
@attribute [RenderModeWebAssembly]

<SharedMessage />
```

If the `SharedMessage` component is placed in a dynamically-rendered component, where the render mode is determined at runtime, it adopts server-side rendering initially, then client-side rendering after the component and Blazor bundle are downloaded and the .NET runtime activates on the client. The component is interactive. The button calls `UpdateMessage`, and the message is updated.

`PassedRenderMode4.razor`:

```razor
@page "/passed-render-mode-4"
@attribute [RenderModeAuto]

<SharedMessage />
```

## Set the render mode for the entire app

To set the render mode for the entire app, indicate the render mode at the highest level component in the app's component hierarchy, typically the `Routes` component (`Components/Routes.razor`) for apps based on the Blazor Web App project template:

```razor
@attribute {RENDER MODE}

<Router AppAssembly="@typeof(App).Assembly" ...>
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(Layout.MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
</Router>
```

In the preceding example, the `{RENDER MODE}` placeholder is the render mode (`[RenderModeServer]`, `[RenderModeWebAssembly]`, or `[RenderModeAuto]`). The render mode propagates down the component hierarchy to all of the components in the app.

## API extensions that support components in Blazor Web Apps

The following extensions are automatically applied to apps created from the [*Blazor Web App* project template](xref:blazor/tooling) when either or both of server-side component interactivity and client-side component interactivity are enabled during app creation. Individual components are still required to declare their render mode per the [*Render modes*](#render-modes) section after the component services and endpoints are configured in the app's `Program` file.

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
