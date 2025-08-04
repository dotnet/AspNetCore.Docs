---
title: ASP.NET Core Blazor state management overview
author: guardrex
description: Learn how to persist user data (state) in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/01/2025
uid: blazor/state-management/index
---
# ASP.NET Core Blazor state management overview

This article and the other articles in this node describe common approaches for maintaining a user's data (state) while they use an app and across browser sessions, including during server prerendering.

Guidance on using browser storage is provided in <xref:blazor/state-management/browser-storage>.

For guidance specific to server-side Blazor apps, see <xref:blazor/state-management/server>. For Blazor WebAssembly apps, see <xref:blazor/state-management/webassembly>.

The remainder of this article discusses general state management strategies for any type of Blazor app.

## In-memory state container service

Nested components typically bind data using *chained bind* as described in <xref:blazor/components/data-binding>. Nested and unnested components can share access to data using a registered in-memory state container. A custom state container class can use an assignable <xref:System.Action> to notify components in different parts of the app of state changes. In the following example:

* A pair of components uses a state container to track a property.
* One component in the following example is nested in the other component, but nesting isn't required for this approach to work.

> [!IMPORTANT]
> The example in this section demonstrates how to create an in-memory state container service, register the service, and use the service in components. The example doesn't persist data without further development. For persistent storage of data, the state container must adopt an underlying storage mechanism that survives when browser memory is cleared. This can be accomplished with `localStorage`/`sessionStorage` or some other technology.

`StateContainer.cs`:

```csharp
public class StateContainer
{
    private string? savedString;

    public string Property
    {
        get => savedString ?? string.Empty;
        set
        {
            savedString = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
```

Client-side apps (`Program` file):

```csharp
builder.Services.AddSingleton<StateContainer>();
```

Server-side apps (`Program` file, ASP.NET Core in .NET 6 or later):

```csharp
builder.Services.AddScoped<StateContainer>();
```

Server-side apps (`Startup.ConfigureServices` of `Startup.cs`, typically in .NET 6 or earlier):

```csharp
services.AddScoped<StateContainer>();
```

`Shared/Nested.razor`:

```razor
@implements IDisposable
@inject StateContainer StateContainer

<h2>Nested component</h2>

<p>Nested component Property: <b>@StateContainer.Property</b></p>

<p>
    <button @onclick="ChangePropertyValue">
        Change the Property from the Nested component
    </button>
</p>

@code {
    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }

    private void ChangePropertyValue()
    {
        StateContainer.Property = 
            $"New value set in the Nested component: {DateTime.Now}";
    }

    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }
}
```

`StateContainerExample.razor`:

```razor
@page "/state-container-example"
@implements IDisposable
@inject StateContainer StateContainer

<h1>State Container Example component</h1>

<p>State Container component Property: <b>@StateContainer.Property</b></p>

<p>
    <button @onclick="ChangePropertyValue">
        Change the Property from the State Container Example component
    </button>
</p>

<Nested />

@code {
    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }

    private void ChangePropertyValue()
    {
        StateContainer.Property = "New value set in the State " +
            $"Container Example component: {DateTime.Now}";
    }

    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }
}
```

The preceding components implement <xref:System.IDisposable>, and the `OnChange` delegates are unsubscribed in the `Dispose` methods, which are called by the framework when the components are disposed. For more information, see <xref:blazor/components/component-disposal>.

## Cascading values and parameters

Use [cascading values and parameters](xref:blazor/components/cascading-values-and-parameters) to manage state by flowing data from an ancestor Razor component to descendent components:

* To consume state across many components.
* If there's just one top-level state object to persist.

:::moniker range=">= aspnetcore-8.0"

Root-level cascading values with a <xref:Microsoft.AspNetCore.Components.CascadingValueSource%601> permit Razor component subscriber notifications of changed cascading values. For more information and a working example, see the `NotifyingDalek` example in <xref:blazor/components/cascading-values-and-parameters#root-level-cascading-values-with-notifications>.

:::moniker-end

## Support state modifications from outside Blazor's synchronization context

When using a custom state management service where you want to support state modifications from outside Blazor's synchronization context (for example from a timer or a background service), all consuming components must wrap the <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> call in <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType>. This ensures the change notification is handled on the renderer's synchronization context.

When the state management service doesn't call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> on Blazor's synchronization context, the following error is thrown:

> :::no-loc text="System.InvalidOperationException: 'The current thread is not associated with the Dispatcher. Use InvokeAsync() to switch execution to the Dispatcher when triggering rendering or component state.'":::

For more information and an example of how to address this error, see <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system>.
