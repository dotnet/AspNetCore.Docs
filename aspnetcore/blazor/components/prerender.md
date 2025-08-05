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

Interactive render modes prerender by default, but you can [disable prerendering](xref:blazor/components/render-modes#prerendering) if needed.

:::moniker-end

[`OnAfterRender{Async}` component lifecycle events](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) aren't called when prerendering, only after the component renders interactively.

## Persist prerendered state

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is created asynchronously, the UI may flicker as the prerendered UI is replaced when the component is rerendered. For guidance on how to persist state during prerendering, see <xref:blazor/state-management/prerendered-state-persistence>.

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
    * [Prerendering](xref:blazor/components/render-modes#prerendering)
    * [Detect rendering location, interactivity, and assigned render mode at runtime](xref:blazor/components/render-modes#detect-rendering-location-interactivity-and-assigned-render-mode-at-runtime)
    * [Client-side services fail to resolve during prerendering](xref:blazor/components/render-modes#client-side-services-fail-to-resolve-during-prerendering)
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
