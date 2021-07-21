---
title: ASP.NET Core Blazor component rendering
author: guardrex
description: Learn about Razor component rendering in ASP.NET Core Blazor apps, including when to call StateHasChanged.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/16/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/rendering
---
# ASP.NET Core Blazor component rendering

Components *must* render when they're first added to the component hierarchy by a parent component. This is the only time that a component must render. Components *may* render at other times according to their own logic and conventions.

## Rendering conventions for `ComponentBase`

By default, Razor components inherit from the <xref:Microsoft.AspNetCore.Components.ComponentBase> base class, which contains logic to trigger rerendering at the following times:

* After applying an updated set of [parameters](xref:blazor/components/data-binding#binding-with-component-parameters) from a parent component.
* After applying an updated value for a [cascading parameter](xref:blazor/components/cascading-values-and-parameters).
* After notification of an event and invoking one of its own [event handlers](xref:blazor/components/event-handling).
* After a call to its own <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> method (see <xref:blazor/components/lifecycle#state-changes-statehaschanged>).

Components inherited from <xref:Microsoft.AspNetCore.Components.ComponentBase> skip rerenders due to parameter updates if either of the following are true:

* All of the parameter values are of known immutable primitive types, such as `int`, `string`, `DateTime`, and haven't changed since the previous set of parameters were set.
* The component's [`ShouldRender` method](#suppress-ui-refreshing-shouldrender) returns `false`.

## Control the rendering flow

In most cases, <xref:Microsoft.AspNetCore.Components.ComponentBase> conventions result in the correct subset of component rerenders after an event occurs. Developers aren't usually required to provide manual logic to tell the framework which components to rerender and when to rerender them. The overall effect of the framework's conventions is that the component receiving an event rerenders itself, which recursively triggers rerendering of descendant components whose parameter values may have changed.

For more information on the performance implications of the framework's conventions and how to optimize an app's component hierarchy for rendering, see <xref:blazor/webassembly-performance-best-practices#optimize-rendering-speed>.

## Suppress UI refreshing (`ShouldRender`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> is called each time a component is rendered. Override <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> to manage UI refreshing. If the implementation returns `true`, the UI is refreshed.

Even if <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> is overridden, the component is always initially rendered.

`Pages/ControlRender.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/rendering/ControlRender.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/rendering/ControlRender.razor)]

::: moniker-end

For more information on performance best practices pertaining to <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A>, see <xref:blazor/webassembly-performance-best-practices#avoid-unnecessary-rendering-of-component-subtrees>.

## When to call `StateHasChanged`

Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> allows you to trigger a render at any time. However, be careful not to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> unnecessarily, which is a common mistake that imposes unnecessary rendering costs.

Code shouldn't need to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> when:

* Routinely handling events, whether synchronously or asynchronously, since <xref:Microsoft.AspNetCore.Components.ComponentBase> triggers a render for most routine event handlers.
* Implementing typical lifecycle logic, such as [`OnInitialized`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) or [`OnParametersSetAsync`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync), whether synchonrously or asynchronously, since <xref:Microsoft.AspNetCore.Components.ComponentBase> triggers a render for typical lifecycle events.

However, it might make sense to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in the cases described in the following sections of this article:

* [An asynchronous handler involves multiple asynchronous phases](#an-asynchronous-handler-involves-multiple-asynchronous-phases)
* [Receiving a call from something external to the Blazor rendering and event handling system](#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system)
* [To render component outside the subtree that is rerendered by a particular event](#to-render-a-component-outside-the-subtree-thats-rerendered-by-a-particular-event)

### An asynchronous handler involves multiple asynchronous phases

Due to the way that tasks are defined in .NET, a receiver of a <xref:System.Threading.Tasks.Task> can only observe its final completion, not intermediate asynchronous states. Therefore, <xref:Microsoft.AspNetCore.Components.ComponentBase> can only trigger rerendering when the <xref:System.Threading.Tasks.Task> is first returned and when the <xref:System.Threading.Tasks.Task> finally completes. The framework can't know to rerender a component at other intermediate points. If you want to rerender at intermediate points, call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> at those points.

Consider the following `CounterState1` component, which updates the count four times on each click:

* Automatic renders occur after the first and last increments of `currentCount`.
* Manual renders are triggered by calls to <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> when the framework doesn't automatically trigger rerenders at intermediate processing points where `currentCount` is incremented.

`Pages/CounterState1.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/rendering/CounterState1.razor?highlight=17,21,25,29)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/rendering/CounterState1.razor?highlight=17,21,25,29)]

::: moniker-end

### Receiving a call from something external to the Blazor rendering and event handling system

<xref:Microsoft.AspNetCore.Components.ComponentBase> only knows about its own lifecycle methods and Blazor-triggered events. <xref:Microsoft.AspNetCore.Components.ComponentBase> doesn't know about other events that may occur in code. For example, any C# events raised by a custom data store are unknown to Blazor. In order for such events to trigger rerendering to display updated values in the UI, call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>.

Consider the following `CounterState2` component that uses <xref:System.Timers.Timer?displayProperty=fullName> to update a count at a regular interval and calls <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> to update the UI:

* `OnTimerCallback` runs outside of any Blazor-managed rendering flow or event notification. Therefore, `OnTimerCallback` must call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> because Blazor isn't aware of the changes to `currentCount` in the callback.
* The component implements <xref:System.IDisposable>, where the <xref:System.Timers.Timer> is disposed when the framework calls the `Dispose` method. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

Because the callback is invoked outside of Blazor's synchronization context, the component must wrap the logic of `OnTimerCallback` in <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType> to move it onto the renderer's synchronization context. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> can only be called from the renderer's synchronization context and throws an exception otherwise. This is equivalent to marshalling to the UI thread in other UI frameworks.

`Pages/CounterState2.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/rendering/CounterState2.razor?highlight=26)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/rendering/CounterState2.razor?highlight=26)]

::: moniker-end

### To render a component outside the subtree that's rerendered by a particular event

The UI might involve:

1. Dispatching an event to one component.
1. Changing some state.
1. Rerendering a completely different component that isn't a descendant of the component receiving the event.

One way to deal with this scenario is to provide a *state management* class, often as a dependency injection (DI) service, injected into multiple components. When one component calls a method on the state manager, the state manager raises a C# event that's then received by an independent component.

Since these C# events are outside the Blazor rendering pipeline, call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> on other components you wish to render in response to the state manager's events.

This is similar to the earlier case with <xref:System.Timers.Timer?displayProperty=fullName> in the [previous section](#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system). Since the execution call stack typically remains on the renderer's synchronization context, calling <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A> isn't normally required. Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A> is only required if the logic escapes the synchronization context, such as calling <xref:System.Threading.Tasks.Task.ContinueWith%2A> on a <xref:System.Threading.Tasks.Task> or awaiting a <xref:System.Threading.Tasks.Task> with [`ConfigureAwait(false)`](xref:System.Threading.Tasks.Task.ConfigureAwait%2A).
