---
title: ASP.NET Core Blazor render modes
author: guardrex
description: Learn about Blazor render modes and how to apply them in Blazor Web Apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/08/2023
uid: blazor/components/render-modes
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
Auto | Interactive client rendering using Blazor Server initially and then WebAssembly on subsequent visits after the Blazor bundle is downloaded | Server, then client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>

Prerendering is enabled by default for interactive components. Guidance on controlling prerendering is provided later in this article. 

The following examples demonstrate setting the component's render mode with a few basic Razor component features.

To test the render mode behaviors locally, you can place the following components in an app created from the *Blazor Web App* project template. When you create the app, select the checkboxes (Visual Studio) or apply the CLI options (.NET CLI) to enable both server-side and client-side interactivity. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

## Enable support for interactive render modes

A Blazor Web App must be configured to support interactive render modes. The following extensions are automatically applied to apps created from the *Blazor Web App* project template during app creation. Individual components are still required to declare their render mode per the [*Render modes*](#render-modes) section after the component services and endpoints are configured in the app's `Program` file.

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

> [!NOTE]
> For orientation on the placement of the API in the following examples, inspect the `Program` file of an app generated from the Blazor Web App project template. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

Example 1: The following `Program` file API adds services and configuration for enabling the Server render mode:

```csharp
builder.Services.AddRazorComponents()
    .AddServerComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddServerRenderMode();
```

Example 2: The following `Program` file API adds services and configuration for enabling the WebAssembly render mode:

```csharp
builder.Services.AddRazorComponents()
    .AddWebAssemblyComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddWebAssemblyRenderMode();
```

Example 3: The following `Program` file API adds services and configuration for enabling the Server, WebAssembly, and Auto render modes:

```csharp
builder.Services.AddRazorComponents()
    .AddServerComponents()
    .AddWebAssemblyComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddServerRenderMode()
    .AddWebAssemblyRenderMode();
```

Blazor uses the Blazor WebAssembly hosting model to download and execute components that use the WebAssembly render mode. A separate client project is required to set up Blazor WebAssembly hosting for these components. The client project contains the startup code for the Blazor WebAssembly host and sets up the .NET runtime for running in a browser. The Blazor Web App template adds this client project for you when you select the option to enable WebAssembly interactivity. Any components using the WebAssembly render mode should be built from the client project, so they get included in the downloaded app bundle.

## Apply a render mode to a component instance

To apply a render mode to a component instance use the [`@rendermode` Razor directive attribute](xref:mvc/views/razor#attribute) where the component is used.

In the following example, the Server render mode is applied to the `Dialog` component instance:

```razor
<Dialog @rendermode="@RenderMode.Server" />
```

> [!NOTE]
> During .NET 8 *Release Candidate 1*, use the following values:
>
> Render mode | Value
> ----------- | -----
> Server      | `@RenderMode.Server`
> WebAssembly | `@RenderMode.WebAssembly`
> Auto        | `@RenderMode.Auto`
>
> The preceding syntax will be simplified in an upcoming preview release.

## Apply a render mode to a component definition

To specify the render mode for a component as part of its definition, use the [`@attribute` Razor directive](xref:mvc/views/razor#attribute) and the corresponding render mode attribute.

```razor
@page "{ROUTE}"
@attribute [RenderModeServer]
```

In the preceding example, the `{ROUTE}` placeholder is the route template.

Applying a render mode to a component definition is commonly used when applying a render mode to a specific page. Routable pages by default use the same render mode as the router component that rendered the page.

> [!NOTE]
> Component authors should avoid coupling a component's implementation to a specific render mode. Instead, component authors should typically design components to support any render mode or hosting model. A component's implementation should avoid assumptions on where it's running (server or client) and should degrade gracefully when rendered statically. Specifying the render mode in the component definition may be needed if the component isn't instantiated directly (such as with a routable page component) or to specify a render mode for all component instances.

> [!NOTE]
> During .NET 8 *Release Candidate 1*, use the following attributes:
>
> Render mode | Value
> ----------- | -----
> Server      | `[RenderModeServer]`
> WebAssembly | `[RenderModeWebAssembly]`
> Auto        | `[RenderModeAuto]`
>
> The preceding syntax will be simplified in an upcoming preview release.

## Prerendering

Prerendering is enabled by default for interactive components.

To disable prerendering, pass the `prerender` flag with a value of `false`.

For a component instance:

```razor
<Dialog @rendermode="@(new ServerRenderMode(prerender: false))" />
```

From the component definition:

```razor
@page "{ROUTE}"
@attribute [RenderModeServer(prerender: false)]
```

In the preceding example, the `{ROUTE}` placeholder is the route template.

> [!NOTE]
> During .NET 8 *Release Candidate 1*, use the following values:
>
> Render mode | Value
> ----------- | -----
> Server      | `@(new ServerRenderMode(prerender: false))`
> WebAssembly | `@(new WebAssemblyRenderMode(prerender: false))`
> Auto        | `@(new AutoRenderMode(prerender: false))`
>
> The preceding syntax will be simplified in an upcoming preview release.

## Static render mode

By default, components use the Static render mode. The component renders to the response stream and interactivity isn't enabled.

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

If using the preceding component locally in a Blazor Web App, place the component in the server-side project's `Components/Pages` folder. The server-side project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-1` in the browser's address bar.

## Server render mode

The Server render mode renders the component interactively from the server using Blazor Server. User interactions are handled over a real-time connection with the browser. The circuit connection is established when the Server component is rendered.

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

## WebAssembly render mode

The WebAssembly render mode renders the component interactively on the client using Blazor WebAssembly. The .NET runtime and app bundle are downloaded and cached when the WebAssembly component is initially rendered. Components using the WebAssembly render mode must be built from a separate client project that sets up the Blazor WebAssembly host.

In the following example, the render mode is set to WebAssembly with `@attribute [RenderModeWebAssembly]`. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI.

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

## Auto render mode

The Auto render mode determines how to render the component at runtime. The component is initially rendered server-side with interactivity using the Blazor Server hosting model. The .NET runtime and app bundle are downloaded to the client in the background and cached so that they can be used on future visits. Components using the Auto render mode must be built from a separate client project that sets up the Blazor WebAssembly host.

In the following example, the component is interactive throughout the process. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI. Initially, the component is rendered interactively from the server, but on subsequent visits it's rendered from the client after the .NET runtime and app bundle are downloaded and cached.

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

Render modes propagate down the component hierarchy.

Rules for applying render modes:

* The default render mode is Static. 
* The interactive Server, WebAssembly, and Auto render modes can be used from a Static component, including using different render modes for sibling components. 
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
@attribute [RenderModeServer]

<SharedMessage />
```

### Child components with different render modes

In the following example:

* The first `SharedMessage` child component is interactive with Server rendering. The component immediately appears and is interactive when the page is displayed in the browser.
* The second `SharedMessage` child component is interactive with WebAssembly rendering. The component is rendered and interactive *after* the Blazor app bundle is downloaded and the .NET runtime is active on the client.

`RenderMode7.razor`:

```razor
@page "/render-mode-7"

<SharedMessage @rendermode="@RenderMode.Server" />
<SharedMessage @rendermode="@RenderMode.WebAssembly" />
```

### Child component with a serializable parameter

The following example demonstrates an interactive child component that takes a parameter. Parameters must be serializable.

`RenderMode8.razor`:

```razor
@page "/render-mode-8"

<SharedMessage @rendermode="@RenderMode.Server" Greeting="Welcome!" />
```

Non-serializable component parameters, such as child content or a render fragment, are ***not*** supported. In the following example, passing child content to the `SharedMessage` component results in a runtime error.

`RenderMode9.razor`:

```razor
@page "/render-mode-9"

<SharedMessage @rendermode="@RenderMode.Server">
    Child content
</SharedMessage>
```

<span aria-hidden="true">❌</span> **Error**:

:::no-loc text="System.InvalidOperationException: Cannot pass the parameter 'ChildContent' to component 'SharedMessage' with rendermode 'ServerRenderMode'. This is because the parameter is of the delegate type 'Microsoft.AspNetCore.Components.RenderFragment', which is arbitrary code and cannot be serialized.":::

To circumvent the preceding limitation, wrap the child component in another component that doesn't have the parameter. This is the approach taken in the Blazor Web App project template with the `Routes` component (`Components/Routes.razor`) to wrap the Blazor router.

`WrapperComponent.razor`:

```razor
<SharedMessage>
    Child content
</SharedMessage>
```

`RenderMode10.razor`:

```razor
@page "/render-mode-10"

<WrapperComponent @rendermode="@RenderMode.Server" />
```

In the preceding example:

* The child content is passed to the `SharedMessage` component without generating a runtime error.
* The `SharedMessage` component renders interactively on the server.

### Child component with a different render mode than its parent

Don't try to apply a different interactive render mode to a child component than its parent's render mode.

The following component results in a runtime error when the `RenderMode9` component is rendered:

`RenderMode11.razor`:

```razor
@page "/render-mode-11"
@attribute [RenderModeServer]

<SharedMessage @rendermode="@RenderMode.WebAssembly" />
```

<span aria-hidden="true">❌</span> **Error**:

> :::no-loc text="Cannot create a component of type 'BlazorSample.Components.SharedMessage' because its render mode 'Microsoft.AspNetCore.Components.Web.WebAssemblyRenderMode' is not supported by interactive server-side rendering.":::

## Set the render mode for the entire app

To set the render mode for the entire app, indicate the render mode at the highest-level component in the app's component hierarchy that isn't a root component (root components can't be interactive). Typically, this is where the `Routes` component is used in the `App` component (`Components/App.razor`) for apps based on the Blazor Web App project template:

```razor
<Routes @rendermode="@RenderMode.Server" />
```

> [!NOTE]
> The preceding syntax will be simplified in an upcoming preview release.

The Blazor router propagates its render mode to the pages it routes. The pages aren't technically child components of the router, but when the routes are discovered at runtime for the router, they inherit the router's render mode.

You also typically must set the same interactive render mode on the `HeadOutlet` component, which is also found in the `App` component of a Blazor Web App generated from the project template:

```
<HeadOutlet @rendermode="@RenderMode.Server" />
```

> [!NOTE]
> Making a root component interactive, such as the `App` component, isn't supported because the Blazor script may be evaluated multiple times.

> [!NOTE]
> In an upcoming preview release, a template option for the Blazor Web App template to create the app with root-level interactivity.

<!-- UPDATE 8.0 The preceding is tracked by https://github.com/dotnet/aspnetcore/issues/50433 -->
