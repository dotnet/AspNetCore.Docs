---
title: ASP.NET Core Razor component disposal
author: guardrex
description: Learn about ASP.NET Core Razor component component disposal with IDisposable and IAsyncDisposable.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 03/18/2025
uid: blazor/components/component-disposal
---
# ASP.NET Core Razor component disposal

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains the ASP.NET Core Razor component disposal with with <xref:System.IDisposable> and <xref:System.IAsyncDisposable>.

If a component implements <xref:System.IDisposable> or <xref:System.IAsyncDisposable>, the framework calls for resource disposal when the component is removed from the UI. Don't rely on the exact timing of when these methods are executed. For example, <xref:System.IAsyncDisposable> can be triggered before or after an asynchronous <xref:System.Threading.Tasks.Task> awaited in [`OnInitalizedAsync`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) or [`OnParametersSetAsync`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) is called or completes. Also, object disposal code shouldn't assume that objects created during initialization or other lifecycle methods exist.

Components shouldn't need to implement <xref:System.IDisposable> and <xref:System.IAsyncDisposable> simultaneously. If both are implemented, the framework only executes the asynchronous overload.

Developer code must ensure that <xref:System.IAsyncDisposable> implementations don't take a long time to complete.

For more information, see the introductory remarks of <xref:blazor/components/sync-context>.

## Disposal of JavaScript interop object references

Examples throughout the [JavaScript (JS) interop articles](xref:blazor/js-interop/index) demonstrate typical object disposal patterns:

* When calling JS from .NET, as described in <xref:blazor/js-interop/call-javascript-from-dotnet>, dispose any created <xref:Microsoft.JSInterop.IJSObjectReference>/<xref:Microsoft.JSInterop.IJSInProcessObjectReference>/<xref:Microsoft.JSInterop.Implementation.JSObjectReference> either from .NET or from JS to avoid leaking JS memory.

* When calling .NET from JS, as described in <xref:blazor/js-interop/call-dotnet-from-javascript>, dispose any created <xref:Microsoft.JSInterop.DotNetObjectReference> either from .NET or from JS to avoid leaking .NET memory.

JS interop object references are implemented as a map keyed by an identifier on the side of the JS interop call that creates the reference. When object disposal is initiated from either the .NET or JS side, Blazor removes the entry from the map, and the object can be garbage collected as long as no other strong reference to the object is present.

At a minimum, always dispose objects created on the .NET side to avoid leaking .NET managed memory.

## DOM cleanup tasks during component disposal

For more information, see <xref:blazor/js-interop/index#dom-cleanup-tasks-during-component-disposal>.

For guidance on <xref:Microsoft.JSInterop.JSDisconnectedException> when a circuit is disconnected, see <xref:blazor/js-interop/index#javascript-interop-calls-without-a-circuit>. For general JavaScript interop error handling guidance, see the *JavaScript interop* section in <xref:blazor/fundamentals/handle-errors#javascript-interop>.

## Synchronous `IDisposable`

For synchronous disposal tasks, use <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is a type that implements <xref:System.IDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IDisposable

...

@code {
    ...

    public void Dispose()
    {
        obj?.Dispose();
    }
}
```

If a single object requires disposal, a lambda can be used to dispose of the object when <xref:System.IDisposable.Dispose%2A> is called. The following example appears in the <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system> article and demonstrates the use of a lambda expression for the disposal of a <xref:System.Timers.Timer>.

:::moniker range=">= aspnetcore-9.0"

`TimerDisposal1.razor`:

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/TimerDisposal1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

`TimerDisposal1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/TimerDisposal1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`CounterWithTimerDisposal1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`CounterWithTimerDisposal1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`CounterWithTimerDisposal1.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`CounterWithTimerDisposal1.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal1.razor":::

:::moniker-end

> [!NOTE]
> In the preceding example, the call to <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is wrapped by a call to <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType> because the callback is invoked outside of Blazor's synchronization context. For more information, see <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system>.

If the object is created in a lifecycle method, such as [`OnInitialized{Async}`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), check for `null` before calling `Dispose`.

:::moniker range=">= aspnetcore-9.0"

`TimerDisposal2.razor`:

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/TimerDisposal2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

`TimerDisposal2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/TimerDisposal2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`CounterWithTimerDisposal2.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`CounterWithTimerDisposal2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`CounterWithTimerDisposal2.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`CounterWithTimerDisposal2.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal2.razor":::

:::moniker-end

For more information, see:

* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

## Asynchronous `IAsyncDisposable`

For asynchronous disposal tasks, use <xref:System.IAsyncDisposable.DisposeAsync%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IAsyncDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is an unmanaged type that implements <xref:System.IAsyncDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IAsyncDisposable

...

@code {
    ...

    public async ValueTask DisposeAsync()
    {
        if (obj is not null)
        {
            await obj.DisposeAsync();
        }
    }
}
```

For more information, see:

* <xref:blazor/components/sync-context>
* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

## Assignment of `null` to disposed objects

Usually, there's no need to assign `null` to disposed objects after calling <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>. Rare cases for assigning `null` include the following:

* If the object's type is poorly implemented and doesn't tolerate repeat calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>, assign `null` after disposal to gracefully skip further calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>.
* If a long-lived process continues to hold a reference to a disposed object, assigning `null` allows the [garbage collector](/dotnet/standard/garbage-collection/fundamentals) to free the object in spite of the long-lived process holding a reference to it.

These are unusual scenarios. For objects that are implemented correctly and behave normally, there's no point in assigning `null` to disposed objects. In the rare cases where an object must be assigned `null`, we recommend documenting the reason and seeking a solution that prevents the need to assign `null`.

## `StateHasChanged`

> [!NOTE]
> Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in `Dispose` and `DisposeAsync` isn't supported. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> might be invoked as part of tearing down the renderer, so requesting UI updates at that point isn't supported.

## Event handlers

Always unsubscribe event handlers from .NET events. The following [Blazor form](xref:blazor/forms/index) examples show how to unsubscribe an event handler in the `Dispose` method.

Private field and lambda approach:

```razor
@implements IDisposable

<EditForm ... EditContext="editContext" ...>
    ...
    <button type="submit" disabled="@formInvalid">Submit</button>
</EditForm>

@code {
    ...

    private EventHandler<FieldChangedEventArgs>? fieldChanged;

    protected override void OnInitialized()
    {
        editContext = new(model);

        fieldChanged = (_, __) =>
        {
            ...
        };

        editContext.OnFieldChanged += fieldChanged;
    }

    public void Dispose()
    {
        editContext.OnFieldChanged -= fieldChanged;
    }
}
```

Private method approach:

```razor
@implements IDisposable

<EditForm ... EditContext="editContext" ...>
    ...
    <button type="submit" disabled="@formInvalid">Submit</button>
</EditForm>

@code {
    ...

    protected override void OnInitialized()
    {
        editContext = new(model);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {
        ...
    }

    public void Dispose()
    {
        editContext.OnFieldChanged -= HandleFieldChanged;
    }
}
```

For more information on the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component and forms, see <xref:blazor/forms/index> and the other forms articles in the *Forms* node.

## Anonymous functions, methods, and expressions

When [anonymous functions](/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions), methods, or expressions, are used, it isn't necessary to implement <xref:System.IDisposable> and unsubscribe delegates. However, failing to unsubscribe a delegate is a problem **when the object exposing the event outlives the lifetime of the component registering the delegate**. When this occurs, a memory leak results because the registered delegate keeps the original object alive. Therefore, only use the following approaches when you know that the event delegate disposes quickly. When in doubt about the lifetime of objects that require disposal, subscribe a delegate method and properly dispose the delegate as the earlier examples show.

Anonymous lambda method approach (explicit disposal not required):

```csharp
private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
{
    formInvalid = !editContext.Validate();
    StateHasChanged();
}

protected override void OnInitialized()
{
    editContext = new(starship);
    editContext.OnFieldChanged += (s, e) => HandleFieldChanged((editContext)s, e);
}
```

Anonymous lambda expression approach (explicit disposal not required):

```csharp
private ValidationMessageStore? messageStore;

[CascadingParameter]
private EditContext? CurrentEditContext { get; set; }

protected override void OnInitialized()
{
    ...

    messageStore = new(CurrentEditContext);

    CurrentEditContext.OnValidationRequested += (s, e) => messageStore.Clear();
    CurrentEditContext.OnFieldChanged += (s, e) => 
        messageStore.Clear(e.FieldIdentifier);
}
```

The full example of the preceding code with anonymous lambda expressions appears in the <xref:blazor/forms/validation#validator-components> article.

For more information, see [Cleaning up unmanaged resources](/dotnet/standard/garbage-collection/unmanaged) and the topics that follow it on implementing the `Dispose` and `DisposeAsync` methods.

## Disposal during JS interop

Trap <xref:Microsoft.JSInterop.JSDisconnectedException> in potential cases where loss of Blazor's SignalR circuit prevents JS interop calls and results an unhandled exception.

For more information, see the following resources:

* [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules)
* [JavaScript interop calls without a circuit](xref:blazor/js-interop/index#javascript-interop-calls-without-a-circuit)
