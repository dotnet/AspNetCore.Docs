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

Internal navigation for interactive routing doesn't involve requesting new page content from the server. Therefore, prerendering doesn't occur for internal page requests, including for [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling). For more information, see [Static versus interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing), [Interactive routing and prerendering](xref:blazor/state-management/prerendered-state-persistence#interactive-routing-and-prerendering), and [Enhanced navigation and form handling](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling).

## Disable prerendering

<!-- UPDATE 11.0 Tracking ...

                 "prerender: false" is ignored in child components
                 https://github.com/dotnet/aspnetcore/issues/55635

                 ... for .NET 11 work in the following area. -->

Disabling prerendering using the following techniques only takes effect for top-level render modes. If a parent component specifies a render mode, the prerendering settings of its children are ignored.

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

:::moniker-end

[`OnAfterRender{Async}` component lifecycle events](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) aren't called when prerendering, only after the component renders interactively.

## Persist prerendered state

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is created asynchronously, the UI may flicker as the prerendered UI is replaced when the component is rerendered. For guidance on how to persist state during prerendering, see <xref:blazor/state-management/prerendered-state-persistence>.

:::moniker range=">= aspnetcore-8.0"

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

You can also avoid the problem if you [disable prerendering](#disable-prerendering) for the component, but that's an extreme measure to take in many cases that may not meet your component's specifications.

There are a three approaches that you can take to address this scenario. The following are listed from most recommended to least recommended:

* *Recommended* for shared framework services: For shared framework services that merely aren't registered server-side in the main project, register the services in the main project, which makes them available during prerendering. For an example of this scenario, see the guidance for <xref:System.Net.Http.HttpClient> services in <xref:blazor/call-web-api?pivots=webassembly#client-side-services-for-httpclient-fail-during-prerendering>.

* *Recommended* for services outside of the shared framework: Create a custom service implementation for the service on the server. Use the service normally in interactive components of the `.Client` project. For a demonstration of this approach, see <xref:blazor/fundamentals/environments#read-the-environment-client-side-in-a-blazor-web-app>.

* Create a service abstraction and create implementations for the service in the `.Client` and server projects. Register the services in each project. Inject the custom service in the component.

* You might be able to add a `.Client` project package reference to a server-side package and fall back to using the server-side API when prerendering on the server.

:::moniker-end

## Prerendering guidance

Prerendering guidance is organized in the Blazor documentation by subject matter. The following links cover all of the prerendering guidance throughout the documentation set by subject:

* Fundamentals
  * [Overview: Client and server rendering concepts](xref:blazor/fundamentals/index#client-and-server-rendering-concepts)
  * Routing
    * [Static versus interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing)
    * [Route to components from multiple assemblies: Interactive routing](xref:blazor/fundamentals/routing#interactive-routing)
    * <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice* when prerendering: [Handle asynchronous navigation events with `OnNavigateAsync`](xref:blazor/fundamentals/routing#handle-asynchronous-navigation-events-with-onnavigateasync)
  * Startup
    * [Control headers in C# code](xref:blazor/fundamentals/startup#control-headers-in-c-code)
    * [Client-side loading indicators](xref:blazor/fundamentals/startup#client-side-loading-indicators)
  * [Environments: Read the environment client-side in a Blazor Web App](xref:blazor/fundamentals/environments#read-the-environment-client-side-in-a-blazor-web-app)
  * [Handle Errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
  * SignalR
    * [Client-side rendering](xref:blazor/fundamentals/signalr#client-side-rendering)
    * [Prerendered state size and SignalR message size limit](xref:blazor/fundamentals/signalr#prerendered-state-size-and-signalr-message-size-limit)

* Components
  * [Control `<head>` content during prerendering](xref:blazor/components/control-head-content#control-head-content-during-prerendering)
  * Render modes
    * [Detect rendering location, interactivity, and assigned render mode at runtime](xref:blazor/components/render-modes#detect-rendering-location-interactivity-and-assigned-render-mode-at-runtime)
    * [Client-side services fail to resolve during prerendering](xref:blazor/components/prerender#client-side-services-fail-to-resolve-during-prerendering)
    * [Custom shorthand render modes](xref:blazor/components/render-modes#custom-shorthand-render-modes)
  * Razor component lifecycle subjects that pertain to prerendering
    * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
    * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
    * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering)
    * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop): This section also appears in the two JS interop articles on calling JavaScript from .NET and calling .NET from JavaScript.
    * [Handle incomplete asynchronous actions at render](xref:blazor/components/lifecycle#handle-incomplete-asynchronous-actions-at-render): Guidance for delayed rendering due to long-running lifecycle tasks during prerendering on the server.
  * [`QuickGrid` component sample app](xref:blazor/components/quickgrid#sample-app): The [**QuickGrid for Blazor** sample app](https://aspnet.github.io/quickgridsamples/) is hosted on GitHub Pages. The site loads fast thanks to static prerendering using the community-maintained [`BlazorWasmPrerendering.Build` GitHub project](https://github.com/jsakamoto/BlazorWasmPreRendering.Build).
  * [Prerendering when integrating components into Razor Pages and MVC apps](xref:blazor/components/integration)

* [Call a web API: Prerendered data](xref:blazor/call-web-api#prerendered-data)

* [File uploads: Upload files to a server with client-side rendering (CSR)](xref:blazor/file-uploads#upload-files-to-a-server-with-client-side-rendering-csr)

* [Globalization and localization: Location override using "Sensors" pane in developer tools](xref:blazor/globalization-localization#location-override-using-sensors-pane-in-developer-tools)

* Authentication and authorization
  * [Server-side threat mitigation: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)
  * Blazor server-side security overview
    * [Manage authentication state in Blazor Web Apps](xref:blazor/security/index#manage-authentication-state-in-blazor-web-apps)
    * [Unauthorized content display while prerendering with a custom `AuthenticationStateProvider`](xref:blazor/security/index#unauthorized-content-display-while-prerendering-with-a-custom-authenticationstateprovider)
  * [Blazor server-side additional scenarios: Reading tokens from `HttpContext`](xref:blazor/security/additional-scenarios#reading-tokens-from-httpcontext)
  * [Blazor WebAssembly overview: Prerendering support](xref:blazor/security/webassembly/index#prerendering-support)
  * Blazor WebAssembly additional scenarios
    * [Rendered component authentication with prerendering](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication)
    * [Secure a SignalR hub](xref:blazor/security/webassembly/additional-scenarios#secure-a-signalr-hub)
  * [Interactive server-side rendering: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)

* [State management: Protected browser storage: Handle prerendering](xref:blazor/state-management/protected-browser-storage#handle-prerendering): Besides the *Handle prerendering* section, several article sections in the [State management node](xref:blazor/state-management/index) include remarks on prerendering.

For .NET 7 or earlier, see [Blazor WebAssembly security additional scenarios: Prerendering with authentication](xref:blazor/security/webassembly/additional-scenarios?view=aspnetcore-7.0&preserve-view=true#prerendering-with-authentication). After viewing the content in this section, reset the documentation article version selector dropdown to the latest .NET release version to ensure that documentation pages load for the latest release on subsequent visits.
