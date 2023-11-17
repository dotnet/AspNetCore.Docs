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
Static | Static server rendering |  Server  | <span aria-hidden="true">❌</span><span class="visually-hidden">No</span>
Interactive Server | Interactive server rendering using Blazor Server | Server | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive WebAssembly | Interactive client rendering using Blazor WebAssembly | Client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive Auto | Interactive client rendering using Blazor Server initially and then WebAssembly on subsequent visits after the Blazor bundle is downloaded | Server, then client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>

Prerendering is enabled by default for interactive components. Guidance on controlling prerendering is provided later in this article.

The following examples demonstrate setting the component's render mode with a few basic Razor component features.

To test the render mode behaviors locally, you can place the following components in an app created from the *Blazor Web App* project template. When you create the app, select the checkboxes (Visual Studio) or apply the CLI options (.NET CLI) to enable both server-side and client-side interactivity. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

## Enable support for interactive render modes

A Blazor Web App must be configured to support interactive render modes. The following extensions are automatically applied to apps created from the *Blazor Web App* project template during app creation. Individual components are still required to declare their render mode per the [*Render modes*](#render-modes) section after the component services and endpoints are configured in the app's `Program` file.

Services for Razor components are added by calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>.

Component builder extensions:

* `AddInteractiveServerComponents` adds services to support rendering Interactive Server components.
* `AddInteractiveWebAssemblyComponents` adds services to support rendering Interactive WebAssembly components.

<xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> discovers available components and specifies the root component for the app (the first component loaded), which by default is the `App` component (`App.razor`).

Endpoint convention builder extensions:

* `AddInteractiveServerRenderMode` configures the Server render mode for the app.
* `AddInteractiveWebAssemblyRenderMode` configures the WebAssembly render mode for the app.

> [!NOTE]
> For orientation on the placement of the API in the following examples, inspect the `Program` file of an app generated from the Blazor Web App project template. For guidance on how to create a Blazor Web App, see <xref:blazor/tooling>.

Example 1: The following `Program` file API adds services and configuration for enabling the Server render mode:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

Example 2: The following `Program` file API adds services and configuration for enabling the WebAssembly render mode:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
```

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode();
```

Example 3: The following `Program` file API adds services and configuration for enabling the Interactive Server, WebAssembly, and Auto render modes:

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

Blazor uses the Blazor WebAssembly hosting model to download and execute components that use the WebAssembly render mode. A separate client project is required to set up Blazor WebAssembly hosting for these components. The client project contains the startup code for the Blazor WebAssembly host and sets up the .NET runtime for running in a browser. The Blazor Web App template adds this client project for you when you select the option to enable WebAssembly interactivity. Any components using the WebAssembly render mode should be built from the client project, so they get included in the downloaded app bundle.

## Apply a render mode to a component instance

To apply a render mode to a component instance use the [`@rendermode` Razor directive attribute](xref:mvc/views/razor#rendermode) where the component is used.

In the following example, the Server render mode is applied to the `Dialog` component instance:

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

You can also reference static render mode instances instantiated directly with custom configuration. For more information, see the [Custom shorthand render modes](#custom-shorthand-render-modes) section later in this article.

## Apply a render mode to a component definition

To specify the render mode for a component as part of its definition, use the [`@rendermode` Razor directive](xref:mvc/views/razor#rendermode) and the corresponding render mode attribute.

```razor
@page "..."
@rendermode InteractiveServer
```

Applying a render mode to a component definition is commonly used when applying a render mode to a specific page. Routable pages by default use the same render mode as the router component that rendered the page.

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

The Blazor router propagates its render mode to the pages it routes.

You also typically must set the same interactive render mode on the `HeadOutlet` component, which is also found in the `App` component of a Blazor Web App generated from the project template:

```
<HeadOutlet @rendermode="InteractiveServer" />
```

To enable global interactivity when creating a Blazor Web App:

* Visual Studio: Set the **Interactivity location** dropdown list to **Global**.
* .NET CLI: Use the `-ai|--all-interactive` option.

For more information, see <xref:blazor/tooling>.

## Prerendering

*Prerendering* is the process of initially rendering page content on the server without enabling event handlers for rendered controls. The server outputs the HTML UI of the page as soon as possible in response to the initial request, which makes the app feel more responsive to users. Prerendering can also improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines use to calculate page rank.

Prerendering is enabled by default for interactive components.

<!-- UPDATE 8.0 Are there any simplifications for these at RTM? -->

To disable prerendering for a *component instance*, pass the `prerender` flag with a value of `false` to the render mode:

* `<... @rendermode="new InteractiveServerRenderMode(prerender: false)" />`
* `<... @rendermode="new InteractiveWebAssemblyRenderMode(prerender: false)" />`
* `<... @rendermode="new InteractiveAutoRenderMode(prerender: false)" />`

To disable prerendering in a *component definition*:

* `@rendermode @(new InteractiveServerRenderMode(prerender: false))`
* `@rendermode @(new InteractiveWebAssemblyRenderMode(prerender: false))`
* `@rendermode @(new InteractiveAutoRenderMode(prerender: false))`

To disable prerendering for the entire app, indicate the render mode at the highest-level interactive component in the app's component hierarchy that isn't a root component.

> [!NOTE]
> Making a root component interactive, such as the `App` component, isn't supported. Therefore, prerendering can't be disabled directly by the `App` component.

For apps based on the Blazor Web App project template, a render mode assigned to the entire app is specified where the `Routes` component is used in the `App` component (`Components/App.razor`). The following example sets the app's render mode to Interactive Server with prerendering disabled:

```razor
<Routes @rendermode="new InteractiveServerRenderMode(prerender: false)" />
```

Also, disable prerendering for the `HeadOutlet` component:

```razor
<HeadOutlet @rendermode="new InteractiveServerRenderMode(prerender: false)" />
```

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

If using the preceding component locally in a Blazor Web App, place the component in the server project's `Components/Pages` folder. The server project is the solution's project with a name that doesn't end in `.Client`. When the app is running, navigate to `/render-mode-1` in the browser's address bar.

[Enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) with static rendering requires special attention when loading JavaScript. For more information, see <xref:blazor/js-interop/ssr>.

## Server render mode

The Server render mode renders the component interactively from the server using Blazor Server. User interactions are handled over a real-time connection with the browser. The circuit connection is established when the Server component is rendered.

In the following example, the render mode is set to Server by adding `@rendermode InteractiveServer` to the component definition. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI.

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

## WebAssembly render mode

The WebAssembly render mode renders the component interactively on the client using Blazor WebAssembly. The .NET runtime and app bundle are downloaded and cached when the WebAssembly component is initially rendered. Components using the WebAssembly render mode must be built from a separate client project that sets up the Blazor WebAssembly host.

In the following example, the render mode is set to WebAssembly with `@rendermode InteractiveWebAssembly`. The button calls the `UpdateMessage` method when selected. The value of `message` changes, and the component is rerendered to update the message in the UI.

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

## Auto render mode

The Auto render mode determines how to render the component at runtime. The component is initially rendered server-side with interactivity using the Blazor Server hosting model. The .NET runtime and app bundle are downloaded to the client in the background and cached so that they can be used on future visits. Components using the automatic render mode must be built from a separate client project that sets up the Blazor WebAssembly host.

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

> :::no-loc text="Cannot provide a value for property 'Environment' on type 'BlazorWebAppSample.Client.Pages.Home'. There is no registered service of type 'Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment'.":::

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

* *Recommended*: Create a custom service implementation for the service on the server. Use the service normally in interactive components of the `.Client` project. For a demonstration of this approach, see <xref:blazor/fundamentals/environments#read-the-environment-client-side-in-a-blazor-web-app>.

* Create a service abstraction and create implementations for the service in the `.Client` and server projects. Register the services in each project. Inject the custom service in the component.

* You might be able to add a `.Client` project package reference to a server-side package and fall back to using the server-side API when prerendering on the server.

## Render mode propagation

Render modes propagate down the component hierarchy.

Rules for applying render modes:

* The default render mode is Static. 
* The Interactive Server (`InteractiveServer`), WebAssembly (`InteractiveWebAssembly`), and automatic (`InteractiveAuto`) render modes can be used from a Static component, including using different render modes for sibling components. 
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

* The first `SharedMessage` component with Server rendering is interactive after the SignalR circuit is established.
* The second `SharedMessage` component with WebAssembly rendering is interactive *after* the Blazor app bundle is downloaded and the .NET runtime is active on the client.

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

## Discover components from additional assemblies for Static Server rendering

Configure additional assemblies to discover routable Razor components for Static Server rendering using the `AddAdditionalAssemblies` method chained to <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A>.

The following example includes the assembly of the `DifferentAssemblyCounter` component:

```csharp
app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(DifferentAssemblyCounter).Assembly);
```

## Closure of circuits when there are no remaining Interactive Server components

[!INCLUDE[](~/blazor/includes/closure-of-circuits.md)]

## Custom shorthand render modes

The `@rendermode` directive takes a single parameter that's a static instance of type <xref:Microsoft.AspNetCore.Components.IComponentRenderMode>. The `@rendermode` directive attribute can take any render mode instance, static or not. The Blazor framework provides the <xref:Microsoft.AspNetCore.Components.Web.RenderMode> static class with some predefined render modes for convenience, but you can create your own.

Normally, a component uses the following `@attribute` directive to [disable prerendering](#prerendering):

```razor
@attribute [RenderModeInteractiveServer(prerender: false)]
```

However, consider the following example that creates a shorthand Interactive Server render mode without prerendering via the app's `_Imports` file (`Components/_Imports.razor`):

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

