---
title: ASP.NET Core Blazor component rendering
author: guardrex
description: Learn about Razor component rendering in ASP.NET Core Blazor apps, including when to call StateHasChanged.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/rendering
---
# ASP.NET Core Blazor component rendering

Components *must* render when they're first added to the component hierarchy by their parent component. This is the only time that a component strictly must render.

Components *may* choose to render at any other time according to their own logic and conventions.

## Conventions for `ComponentBase`

By default, Razor components (`.razor`) inherit from the <xref:Microsoft.AspNetCore.Components.ComponentBase> base class, which contains logic to trigger rerendering at the following times:

* After applying an updated set of parameters from a parent component.
* After applying an updated value for a cascading parameter.
* After notification of an event and invoking one of its own event handlers.
* After a call to its own <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> method.

Components inherited from <xref:Microsoft.AspNetCore.Components.ComponentBase> skip rerenders due to parameter updates if either of the following are true:

* All of the parameter values are of known immutable primitive types (for example, `int`, `string`, `DateTime`) and haven't changed since the previous set of parameters were set.
* The component's <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> method returns `false`.

For more information on <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A>, see <xref:blazor/webassembly-performance-best-practices#use-of-shouldrender>.

## Control the rendering flow

In most cases, <xref:Microsoft.AspNetCore.Components.ComponentBase> conventions result in the correct subset of component rerenders after an event occurs. Developers aren't usually required to provide manual logic to tell the framework which components to rerender and when to rerender them. The overall effect of the framework's conventions is that the component receiving an event rerenders itself, which recursively triggers rerendering of descendant components whose parameter values may have changed.

For more information on the performance implications of the framework's conventions and how to optimize an app's component hierarchy, see <xref:blazor/webassembly-performance-best-practices#optimize-rendering-speed>.

## When to call `StateHasChanged`

The <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A?displayProperty=nameWithType> method allows you to trigger a render at any time. However, be careful not to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> unnecessarily, which is a common mistake, because it imposes unnecessary rendering costs.

You should *not* need to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> when:

* Routinely handling events, whether synchronously or asynchronously, since <xref:Microsoft.AspNetCore.Components.ComponentBase> triggers a render for most routine event handlers.
* Implementing typical lifecycle logic, such as [`OnInitialized`](xref:blazor/components/lifecycle#component-initialization-methods) or [`OnParametersSetAsync`](xref:blazor/components/lifecycle#after-parameters-are-set), whether synchonrously or asynchronously, since <xref:Microsoft.AspNetCore.Components.ComponentBase> triggers a render for typical lifecycle events.

However, it might make sense to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in the cases described by the following sections:

* [An asynchronous handler involves multiple asynchronous phases](#an-asynchronous-handler-involves-multiple-asynchronous-phases)
* [Receiving a call from something external to the Blazor rendering and event handling system](#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system)
* [To render component outside the subtree that is rerendered by a particular event](#to-render-a-component-outside-the-subtree-thats-rerendered-by-a-particular-event)

### An asynchronous handler involves multiple asynchronous phases

Consider the following `Counter` component, which updates the count four times on each click.

`Pages/Counter.razor`:

```razor
@page "/counter"

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private async Task IncrementCount()
    {
        currentCount++;
        // Renders here automatically

        await Task.Delay(1000);
        currentCount++;
        StateHasChanged();

        await Task.Delay(1000);
        currentCount++;
        StateHasChanged();

        await Task.Delay(1000);
        currentCount++;
        // Renders here automatically
    }
}
```

Due to the way that tasks are defined in .NET, a receiver of a <xref:System.Threading.Tasks.Task> can only observe its final completion, not intermediate asynchronous states. Therefore, <xref:Microsoft.AspNetCore.Components.ComponentBase> can only trigger rerendering when the <xref:System.Threading.Tasks.Task> is first returned and when the <xref:System.Threading.Tasks.Task> finally completes. It can't know to rerender at other intermediate points. If you want to rerender at intermediate points, use <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>.

### Receiving a call from something external to the Blazor rendering and event handling system

<xref:Microsoft.AspNetCore.Components.ComponentBase> only knows about its own lifecycle methods and Blazor-triggered events. <xref:Microsoft.AspNetCore.Components.ComponentBase> doesn't know about other events that may occur in your code. For example, any C# events raised by a custom data store are unknown to Blazor. In order for such events to trigger rerendering to display updated values in the UI, use <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>.

In another use case, consider the following `Counter` component that uses <xref:System.Timers.Timer?displayProperty=fullName> to update the count at a regular interval and calls <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> to update the UI.

`Pages/CounterWithTimerDisposal.razor`:

```razor
@page "/counter-with-timer-disposal"
@using System.Timers
@implements IDisposable

<h1>Counter with <code>Timer</code> disposal</h1>

<p>Current count: @currentCount</p>

@code {
    private int currentCount = 0;
    private Timer timer = new Timer(1000);

    protected override void OnInitialized()
    {
        timer.Elapsed += (sender, eventArgs) => OnTimerCallback();
        timer.Start();
    }

    private void OnTimerCallback()
    {
        _ = InvokeAsync(() =>
        {
            currentCount++;
            StateHasChanged();
        });
    }

    public void IDisposable.Dispose() => timer.Dispose();
}
```

In the preceding example:

* `OnTimerCallback` must call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> because Blazor isn't aware of the changes to `currentCount` in the callback. `OnTimerCallback` runs outside of any Blazor-managed rendering flow or event notification.
* The component implements <xref:System.IDisposable>, where the <xref:System.Timers.Timer> is disposed when the framework calls the `Dispose` method. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable>.

Similarly, because the callback is invoked outside Blazor's synchronization context, it's necessary to wrap the logic in <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType> to move it onto the renderer's synchronization context. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> can only be called from the renderer's synchronization context and throws an exception otherwise. This is equivalent to marshalling to the UI thread in other UI frameworks.

### To render a component outside the subtree that's rerendered by a particular event

Your UI might involve dispatching an event to one component, changing some state, and needing to rerender a completely different component that isn't a descendant of the one receiving the event.

One way to deal with this scenario is to have a *state management* class, perhaps as a DI service, injected into multiple components. When one component calls a method on the state manager, the state manager can raise a C# event that's then received by an independent component.

Since these C# events are outside the Blazor rendering pipeline, call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> on other components you wish to render in response to the state manager's events.

This is similar to the earlier case with <xref:System.Timers.Timer?displayProperty=fullName> in the [previous section](#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system) section. Since the execution call stack typically remains on the renderer's synchronization context, <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A> isn't normally required. <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A> is only required if the logic escapes the synchronization context, such as calling <xref:System.Threading.Tasks.Task.ContinueWith%2A> on a <xref:System.Threading.Tasks.Task> or awaiting a <xref:System.Threading.Tasks.Task> with [`ConfigureAwait(false)`](xref:System.Threading.Tasks.Task.ConfigureAwait%2A).
