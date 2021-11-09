---
title: Persist Component State Tag Helper in ASP.NET Core
author: guardrex
ms.author: riande
description: Learn how to use the ASP.NET Core Persist Component State Tag Helper to persist state when prerendering components.
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 07/16/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper
zone_pivot_groups: blazor-hosting-models
---
# Persist Component State Tag Helper in ASP.NET Core

## Prerequisites

Follow the guidance in the *Configuration* section for either:

* [Blazor WebAssembly](xref:blazor/components/prerendering-and-integration?pivots=webassembly)
* [Blazor Server](xref:blazor/components/prerendering-and-integration?pivots=server)

## Persist Component State Tag Helper

To persist state for prerendered components, use the Persist Component State Tag Helper (`<persist-component-state />`). Add the `<persist-component-state />` tag inside the closing `</body>` tag of the `_Host` page in an app that prerenders components:

::: zone pivot="webassembly"

`Pages/_Host.cshtml`:

```cshtml
<body>
    <component type="typeof(App)" render-mode="WebAssemblyPrerendered" />

    ...

    <persist-component-state />
</body>
```

::: zone-end

::: zone pivot="server"

`Pages/_Host.cshtml`:

```cshtml
<body>
    <component type="typeof(App)" render-mode="ServerPrerendered" />

    ...

    <persist-component-state />
</body>
```

::: zone-end

Decide what state to persist using the `ComponentApplicationState` service. The `ComponentApplicationState.OnPersisting` event is fired just before the state is persisted into the prerendered page, which allows you to retrieve any persisted state when initializing a component.

In the following example:

* The `{TYPE}` placeholder represents the type of data to persist (for example, `WeatherForecast[]`).
* The `{TOKEN}` placeholder is a state identifier string (for example, `fetchdata`).

```razor
@implements IDisposable
@inject ComponentApplicationState ApplicationState

...

@code {
    protected override async Task OnInitializedAsync()
    {
        ApplicationState.OnPersisting += PersistData;

        if (!ApplicationState
            .TryTakeAsJson<{TYPE}>("{TOKEN}", out var data))
        {
            data = ...;
        }
    }

    private Task PersistData()
    {
        ApplicationState.PersistAsJson("{TOKEN}", data);

        return Task.CompletedTask;
    }

    void IDisposable.Dispose()
    {
        ApplicationState.OnPersisting -= PersistData;
    }
}
```

For more information and a complete example, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

## Additional resources

* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components/index>
