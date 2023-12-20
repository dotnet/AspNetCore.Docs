---
title: ASP.NET Core Blazor synchronization context
author: guardrex
description: Learn about Blazor's synchronization context, how to avoid thread-blocking calls, and how to invoke component methods externally.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/sync-context
---
# ASP.NET Core Blazor synchronization context

Blazor uses a synchronization context (<xref:System.Threading.SynchronizationContext>) to enforce a single logical thread of execution. A component's [lifecycle methods](xref:blazor/components/lifecycle) and event callbacks raised by Blazor are executed on the synchronization context.

Blazor's server-side synchronization context attempts to emulate a single-threaded environment so that it closely matches the WebAssembly model in the browser, which is single threaded. At any given point in time, work is performed on exactly one thread, which yields the impression of a single logical thread. No two operations execute concurrently.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

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

* `NotifierService` invokes the component's `OnNotify` method outside of Blazor's synchronization context. `InvokeAsync` is used to switch to the correct context and queue a render. For more information, see <xref:blazor/components/rendering>.
* The component implements <xref:System.IDisposable>. The `OnNotify` delegate is unsubscribed in the `Dispose` method, which is called by the framework when the component is disposed. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

> [!IMPORTANT]
> If a Razor component defines an event that's triggered from a background thread, the component might be required to capture and restore the execution context (<xref:System.Threading.ExecutionContext>) at the time the handler is registered. For more information, see [Calling `InvokeAsync(StateHasChanged)` causes page to fallback to default culture (dotnet/aspnetcore #28521)](https://github.com/dotnet/aspnetcore/issues/28521).

:::moniker range=">= aspnetcore-8.0"

To dispatch caught exceptions from the background `TimerService` to the component to treat the exceptions like normal lifecycle event exceptions, see [Handle caught exceptions outside of a Razor component's lifecycle](xref:blazor/fundamentals/handle-errors#handle-caught-exceptions-outside-of-a-razor-components-lifecycle) in the *Handle errors* article.

:::moniker-end
