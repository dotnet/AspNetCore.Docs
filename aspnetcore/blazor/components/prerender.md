---
title: Prerender ASP.NET Core Razor components
author: guardrex
description: Learn about Razor component prerendering in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/05/2025
uid: blazor/components/prerender
---
# Prerender ASP.NET Core Razor components

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

<!--
    NOTE: The console output block quotes in this topic use a double-space 
    at the ends of lines to generate a bare return in block quote output.
-->

This article explains Razor component prerendering scenarios for server-rendered components in Blazor Web Apps and Blazor Server apps.

*Prerendering* is the process of statically rendering page content from the server to deliver HTML to the browser as quickly as possible. After the prerendered content is quickly displayed to the user, interactive content with active event handlers are rendered, replacing any content that was rendered previously. Prerendering can also improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines use to calculate page rank.

:::moniker range=">= aspnetcore-8.0"

Prerendering is enabled by default for interactive components.

Internal navigation with interactive routing doesn't use prerendering because the page is already interactive. For more information, see [Static versus interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing) and [Interactive routing and prerendering](xref:blazor/state-management/prerendered-state-persistence#interactive-routing-and-prerendering).

[`OnAfterRender{Async}` component lifecycle events](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) aren't called when prerendering, only after the component renders interactively.

## Disable prerendering

<!-- UPDATE 11.0 Tracking ...

                 "prerender: false" is ignored in child components
                 https://github.com/dotnet/aspnetcore/issues/55635

                 ... for .NET 11 work in the following area. -->

Prerendering can complicate an app because the app's Razor components must render twice: once for prerendering and once for setting up interactivity. If the components are set up to run on WebAssembly, then you also must design your components so that they can run from both the server and the client.

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

Disabling prerendering using the preceding techniques only takes effect for top-level render modes. If a parent component specifies a render mode, the prerendering settings of its children are ignored.

:::moniker-end

## Persist prerendered state

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is created asynchronously, the UI may flicker as the prerendered UI is replaced when the component is rerendered. For guidance on how to persist state during prerendering, see <xref:blazor/state-management/prerendered-state-persistence>.

:::moniker range=">= aspnetcore-8.0"

## Client-side services fail to resolve during prerendering

Assuming that prerendering isn't disabled for a component or for the app, a component in the `.Client` project is prerendered on the server. Because the server doesn't have access to registered client-side Blazor services, it isn't possible to inject these services into a component without receiving an error that the service can't be found during prerendering.

For example, consider the following `Home` component in the `.Client` project in a Blazor Web App with [global Interactive WebAssembly or Interactive Auto rendering](xref:blazor/components/render-modes#apply-a-render-mode-to-the-entire-app). The component attempts to inject <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> to obtain the environment's name.

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

There are several approaches that you can take to address this scenario:

* If the service supports server execution, register the service on the server in addition to the client so that it's available during prerendering. For an example of this scenario, see the guidance for <xref:System.Net.Http.HttpClient> services in the [Blazor Web App external web APIs](xref:blazor/call-web-api#blazor-web-app-external-web-apis) section of the *Call web API* article.

* Make the service optional if it isn't always needed during prerendering.

* If a different service implementation is needed on the server, create a service abstraction and create implementations for the service in the `.Client` and server projects. Register the services in each project. Inject the custom service abstraction in the component.

* Disable prerendering for the component or for the entire app.

To optionally inject the service into the component, use constructor injection:

```csharp
private string? environmentName;

public Home(IWebAssemblyHostEnvironment? env = null)
{
    environmentName = env?.Environment;
}
```

Alternatively, inject <xref:System.IServiceProvider> to optionally obtain the service if it's available:

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

To obtain the environment whether the code is running on the server or on the client, you could optionally inject <xref:Microsoft.Extensions.Hosting.IHostEnvironment> from the [`Microsoft.Extensions.Hosting.Abstractions` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.Abstractions):

```csharp
private string? environmentName;

public Home(IHostEnvironment? serverEnvironment = null, 
    IWebAssemblyHostEnvironment? wasmEnvironment = null)
{
    environmentName = serverEnvironment?.EnvironmentName;
    environmentName ??= wasmEnvironment?.Environment;
}
```

However, this approach adds an additional dependency to the client project that isn't needed.

A better approach is to create a custom service abstraction and implementations for the server and client. Implement the service interface in the server and client projects and register the implementations in each project. The component then depends solely on the custom service abstraction.

In the case of `IWebAssemblyHostEnvironment`, we can reuse the existing interface instead of creating a new one:

`ServerHostEnvironment.cs`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;

public class ServerHostEnvironment(IWebHostEnvironment env, NavigationManager nav) : 
    IWebAssemblyHostEnvironment
{
    public string Environment => env.EnvironmentName;
    public string BaseAddress => nav.BaseUri;
}
```

In the server project's `Program` file, register the service:

```csharp
builder.Services.TryAddScoped<IWebAssemblyHostEnvironment, ServerHostEnvironment>();
```

At this point, the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> service can be [injected into an interactive WebAssembly or Auto component that is also prerendered from the server](xref:blazor/fundamentals/environments#read-the-environment-in-a-blazor-webassembly-app).

:::moniker-end
