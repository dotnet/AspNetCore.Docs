---
title: Prerender ASP.NET Core Razor components
author: guardrex
description: Learn about Razor component prerendering in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/components/prerender
---
# Prerender ASP.NET Core Razor components

<!--
[!INCLUDE[](~/includes/not-latest-version.md)]
-->

This article explains Razor component prerendering scenarios for server-rendered components in Blazor Web Apps.
  
Prerendering can improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines can use to calculate page rank.

<!-- UPDATE 8.0 Remove IMPORTANT notice -->

> [!IMPORTANT]
> This article is currently undergoing updates for .NET 8. Please check back periodically for new content or when .NET 8 is released.

## Persist prerendered state

> [!IMPORTANT]
> This section is currently undergoing updates for .NET 8.

<!-- UPDATE 8.0

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is setup asynchronously, the UI may flicker as the prerendered UI is replaced with temporary placeholders and then fully rendered again.

To solve these problems, Blazor supports persisting state in a prerendered page using the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper). Add the Tag Helper's tag, `<persist-component-state />`, inside the closing `</body>` tag.

`Pages/_Host.cshtml`:

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

-->

## Prerendering guidance

Prerendering guidance is organized in the Blazor documentation by subject matter. The following links cover all of the prerendering guidance throughout the documentation set by subject:

* Fundamentals
  * <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice* when prerendering: [Handle asynchronous navigation events with `OnNavigateAsync`](xref:blazor/fundamentals/routing#handle-asynchronous-navigation-events-with-onnavigateasync)
  * [Startup: Control headers in C# code](xref:blazor/fundamentals/startup#control-headers-in-c-code)
  * [Handle Errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
  * [SignalR: Prerendered state size and SignalR message size limit](xref:blazor/fundamentals/signalr#prerendered-state-size-and-signalr-message-size-limit)
* [Render modes: Prerendering](xref:blazor/components/render-modes#prerendering)
* Components
  * [Control `<head>` content during prerendering](xref:blazor/components/control-head-content#control-head-content-during-prerendering)
  * Razor component lifecycle subjects that pertain to prerendering
    * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
    * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
    * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering)
    * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop): This section also appears in the two JS interop articles on calling JavaScript from .NET and calling .NET from JavaScript.
  * [QuickGrid component sample app](xref:blazor/components/quickgrid#sample-app): The [**QuickGrid for Blazor** sample app](https://aspnet.github.io/quickgridsamples/) is hosted on GitHub Pages. The site loads fast thanks to static prerendering using the community-maintained [`BlazorWasmPrerendering.Build` GitHub project](https://github.com/jsakamoto/BlazorWasmPreRendering.Build).
  * [Prerendering when integrating components into Razor Pages and MVC apps](xref:blazor/components/integration)
* Authentication and authorization
  * [Server-side threat mitigation: Cross-site scripting (XSS)](xref:blazor/security/server/threat-mitigation#cross-site-scripting-xss)
  * [Unauthorized content display while prerendering with a custom `AuthenticationStateProvider`](xref:blazor/security/server/index#unauthorized-content-display-while-prerendering-with-a-custom-authenticationstateprovider)
  * [WebAssembly prerendering support](xref:blazor/security/webassembly/index#prerendering-support)
<!-- UPDATE 8.0 HOLD LINK FOR WORK AT DESTINATION * [Blazor WebAssembly rendered component authentication with prerendering](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication) -->
* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering): Besides the *Handle prerendering* section, several of the article's other sections include remarks on prerendering.
