---
title: ASP.NET Core Blazor synchronization context
author: guardrex
description: Learn about Blazor's synchronization context, how to avoid thread-blocking calls, and how to invoke component methods externally.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/27/2024
uid: blazor/components/sync-context
---
# ASP.NET Core Blazor synchronization context

[!INCLUDE[](~/includes/not-latest-version.md)]

Blazor uses a synchronization context (<xref:System.Threading.SynchronizationContext>) to enforce a single logical thread of execution. A component's [lifecycle methods](xref:blazor/components/lifecycle) and event callbacks raised by Blazor are executed on the synchronization context.

Blazor's server-side synchronization context attempts to emulate a single-threaded environment so that it closely matches the WebAssembly model in the browser, which is single threaded. This emulation is scoped only to an individual circuit, meaning two different circuits can run in parallel. At any given point in time within a circuit, work is performed on exactly one thread, which yields the impression of a single logical thread. No two operations execute concurrently within the same circuit.

## Avoid thread-blocking calls

Generally, don't call the following methods in components. The following methods block the execution thread and thus block the app from resuming work until the underlying <xref:System.Threading.Tasks.Task> is complete:

* <xref:System.Threading.Tasks.Task%601.Result%2A>
* <xref:System.Threading.Tasks.Task.Wait%2A>
* <xref:System.Threading.Tasks.Task.WaitAny%2A>
* <xref:System.Threading.Tasks.Task.WaitAll%2A>
* <xref:System.Threading.Thread.Sleep%2A>
* <xref:System.Runtime.CompilerServices.TaskAwaiter.GetResult%2A>

> [!NOTE]
> Blazor documentation examples that use the thread-blocking methods mentioned in this section are only using the methods for demonstration purposes, not as recommended coding guidance. For example, a few component code demonstrations simulate a long-running process by calling <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>.

## Invoke component methods externally to update state

In the event a component must be updated based on an external event, such as a timer or other notification, use the `InvokeAsync` method, which dispatches code execution to Blazor's synchronization context. For example, consider the following *notifier service* that can notify any listening component about updated state. The `Update` method can be called from anywhere in the app.

`TimerService.cs`:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/TimerService.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/TimerService.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/TimerService.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/TimerService.cs":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/TimerService.cs":::

:::moniker-end

`NotifierService.cs`:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/NotifierService.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/NotifierService.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/NotifierService.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/NotifierService.cs":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/NotifierService.cs":::

:::moniker-end

Register the services:

* For client-side development, register the services as singletons in the client-side `Program` file:

  ```csharp
  builder.Services.AddSingleton<NotifierService>();
  builder.Services.AddSingleton<TimerService>();
  ```

* For server-side development, register the services as scoped in the server `Program` file:

  ```csharp
  builder.Services.AddScoped<NotifierService>();
  builder.Services.AddScoped<TimerService>();
  ```

Use the `NotifierService` to update a component.

:::moniker range=">= aspnetcore-8.0"

`Notifications.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Notifications.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`ReceiveNotifications.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/synchronization-context/ReceiveNotifications.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`ReceiveNotifications.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/synchronization-context/ReceiveNotifications.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`ReceiveNotifications.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/synchronization-context/ReceiveNotifications.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`ReceiveNotifications.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/synchronization-context/ReceiveNotifications.razor":::

:::moniker-end

In the preceding example:

:::moniker range=">= aspnetcore-6.0"

* The timer is initiated outside of Blazor's synchronization context with `_ = Task.Run(Timer.Start)`.
* `NotifierService` invokes the component's `OnNotify` method. `InvokeAsync` is used to switch to the correct context and queue a render. For more information, see <xref:blazor/components/rendering>.
* The component implements <xref:System.IDisposable>. The `OnNotify` delegate is unsubscribed in the `Dispose` method, which is called by the framework when the component is disposed. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* `NotifierService` invokes the component's `OnNotify` method outside of Blazor's synchronization context. `InvokeAsync` is used to switch to the correct context and queue a render. For more information, see <xref:blazor/components/rendering>.
* The component implements <xref:System.IDisposable>. The `OnNotify` delegate is unsubscribed in the `Dispose` method, which is called by the framework when the component is disposed. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

:::moniker-end

> [!IMPORTANT]
> If a Razor component defines an event that's triggered from a background thread, the component might be required to capture and restore the execution context (<xref:System.Threading.ExecutionContext>) at the time the handler is registered. For more information, see [Calling `InvokeAsync(StateHasChanged)` causes page to fallback to default culture (dotnet/aspnetcore #28521)](https://github.com/dotnet/aspnetcore/issues/28521).

:::moniker range=">= aspnetcore-8.0"

To dispatch caught exceptions from the background `TimerService` to the component to treat the exceptions like normal lifecycle event exceptions, see the [Handle caught exceptions outside of a Razor component's lifecycle](#handle-caught-exceptions-outside-of-a-razor-components-lifecycle) section.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Handle caught exceptions outside of a Razor component's lifecycle

Use <xref:Microsoft.AspNetCore.Components.ComponentBase.DispatchExceptionAsync%2A?displayProperty=nameWithType> in a Razor component to process exceptions thrown outside of the component's lifecycle call stack. This permits the component's code to treat exceptions as though they're lifecycle method exceptions. Thereafter, Blazor's error handling mechanisms, such as [error boundaries](xref:blazor/fundamentals/handle-errors#error-boundaries), can process the exceptions.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Components.ComponentBase.DispatchExceptionAsync%2A?displayProperty=nameWithType> is used in Razor component files (`.razor`) that inherit from <xref:Microsoft.AspNetCore.Components.ComponentBase>. When creating components that [implement <xref:Microsoft.AspNetCore.Components.IComponent> directly](xref:blazor/components/index#component-classes), use <xref:Microsoft.AspNetCore.Components.RenderHandle.DispatchExceptionAsync%2A?displayProperty=nameWithType>.

To handle caught exceptions outside of a Razor component's lifecycle, pass the exception to <xref:Microsoft.AspNetCore.Components.RenderHandle.DispatchExceptionAsync%2A> and await the result:

```csharp
try
{
    ...
}
catch (Exception ex)
{
    await DispatchExceptionAsync(ex);
}
```

A common scenario for the preceding approach is when a component starts an asynchronous operation but doesn't await a <xref:System.Threading.Tasks.Task>, often called the *fire and forget* pattern because the method is *fired* (started) and the result of the method is *forgotten* (thrown away). If the operation fails, you may want the component to treat the failure as a component lifecycle exception for any of the following goals:

* Put the component into a faulted state, for example, to trigger an [error boundary](xref:blazor/fundamentals/handle-errors#error-boundaries).
* Terminate the circuit if there's no error boundary.
* Trigger the same logging that occurs for lifecycle exceptions.

In the following example, the user selects the **Send report** button to trigger a background method, `ReportSender.SendAsync`, that sends a report. In most cases, a component awaits the <xref:System.Threading.Tasks.Task> of an asynchronous call and updates the UI to indicate the operation completed. In the following example, the `SendReport` method doesn't await a <xref:System.Threading.Tasks.Task> and doesn't report the result to the user. Because the component intentionally discards the <xref:System.Threading.Tasks.Task> in `SendReport`, any asynchronous failures occur off of the normal lifecycle call stack, hence aren't seen by Blazor:

```razor
<button @onclick="SendReport">Send report</button>

@code {
    private void SendReport()
    {
        _ = ReportSender.SendAsync();
    }
}
```

To treat failures like lifecycle method exceptions, explicitly dispatch exceptions back to the component with <xref:Microsoft.AspNetCore.Components.ComponentBase.DispatchExceptionAsync%2A>, as the following example demonstrates: 

```razor
<button @onclick="SendReport">Send report</button>

@code {
    private void SendReport()
    {
        _ = SendReportAsync();
    }

    private async Task SendReportAsync()
    {
        try
        {
            await ReportSender.SendAsync();
        }
        catch (Exception ex)
        {
            await DispatchExceptionAsync(ex);
        }
    }
}
```

An alternative approach leverages <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType>:

```csharp
private void SendReport()
{
    _ = Task.Run(async () =>
    {
        try
        {
            await ReportSender.SendAsync();
        }
        catch (Exception ex)
        {
            await DispatchExceptionAsync(ex);
        }
    });
}
```

For a working demonstration, implement the timer notification example in [Invoke component methods externally to update state](xref:blazor/components/sync-context#invoke-component-methods-externally-to-update-state). In a Blazor app, add the following files from the timer notification example and register the services in the `Program` file as the section explains:

* `TimerService.cs`
* `NotifierService.cs`
* `Notifications.razor`

The example uses a timer outside of a Razor component's lifecycle, where an unhandled exception normally isn't processed by Blazor's error handling mechanisms, such as an [error boundary](xref:blazor/fundamentals/handle-errors#error-boundaries).

First, change the code in `TimerService.cs` to create an artificial exception outside of the component's lifecycle. In the `while` loop of `TimerService.cs`, throw an exception when the `elapsedCount` reaches a value of two:

```csharp
if (elapsedCount == 2)
{
    throw new Exception("I threw an exception! Somebody help me!");
}
```

Place an [error boundary](xref:blazor/fundamentals/handle-errors#error-boundaries) in the app's main layout. Replace the `<article>...</article>` markup with the following markup.

In `MainLayout.razor`:

```razor
<article class="content px-4">
    <ErrorBoundary>
        <ChildContent>
            @Body
        </ChildContent>
        <ErrorContent>
            <p class="alert alert-danger" role="alert">
                Oh, dear! Oh, my! - George Takei
            </p>
        </ErrorContent>
    </ErrorBoundary>
</article>
```

In Blazor Web Apps with the error boundary only applied to a static `MainLayout` component, the boundary is only active during the static server-side rendering (static SSR) phase. The boundary doesn't activate just because a component further down the component hierarchy is interactive. To enable interactivity broadly for the `MainLayout` component and the rest of the components further down the component hierarchy, enable interactive rendering for the `HeadOutlet` and `Routes` component instances in the `App` component (`Components/App.razor`). The following example adopts the Interactive Server (`InteractiveServer`) render mode:

```razor
<HeadOutlet @rendermode="InteractiveServer" />

...

<Routes @rendermode="InteractiveServer" />
```

If you run the app at this point, the exception is thrown when the elapsed count reaches a value of two. However, the UI doesn't change. The error boundary doesn't show the error content.

To dispatch exceptions from the timer service back to the `Notifications` component, the following changes are made to the component:

* Start the timer in a [`try-catch` statement](/dotnet/csharp/language-reference/statements/exception-handling-statements#the-try-catch-statement). In the `catch` clause of the `try-catch` block, exceptions are dispatched back to the component by passing the <xref:System.Exception> to <xref:Microsoft.AspNetCore.Components.ComponentBase.DispatchExceptionAsync%2A> and awaiting the result.
* In the `StartTimer` method, start the asynchronous timer service in the <xref:System.Action> delegate of <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> and intentionally discard the returned <xref:System.Threading.Tasks.Task>.

The `StartTimer` method of the `Notifications` component (`Notifications.razor`):

```csharp
private void StartTimer()
{
    _ = Task.Run(async () =>
    {
        try
        {
            await Timer.Start();
        }
        catch (Exception ex)
        {
            await DispatchExceptionAsync(ex);
        }
    });
}
```

When the timer service executes and reaches a count of two, the exception is dispatched to the Razor component, which in turn triggers the error boundary to display the error content of the `<ErrorBoundary>` in the `MainLayout` component:

> :::no-loc text="Oh, dear! Oh, my! - George Takei":::

:::moniker-end
