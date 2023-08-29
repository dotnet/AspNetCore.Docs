*This section only applies to server-side components.*

JavaScript (JS) interop calls can't be issued after a SignalR circuit is disconnected. Without a circuit during component disposal or at any other time that a circuit doesn't exist, the following method calls fail and log a message that the circuit is disconnected as a <xref:Microsoft.JSInterop.JSDisconnectedException>:

* JS interop method calls
  * <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType>
  * <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A?displayProperty=nameWithType>
  * <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType>)
* `Dispose`/`DisposeAsync` calls on any <xref:Microsoft.JSInterop.IJSObjectReference>.

In order to avoid logging <xref:Microsoft.JSInterop.JSDisconnectedException> or to log custom information, catch the exception in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.

For the following component disposal example:

* The component implements <xref:System.IAsyncDisposable>.
* `objInstance` is an <xref:Microsoft.JSInterop.IJSObjectReference>.
* <xref:Microsoft.JSInterop.JSDisconnectedException> is caught and not logged.
* Optionally, you can log custom information in the `catch` statement at whatever log level you prefer. The following example doesn't log custom information because it assumes the developer doesn't care about when or where circuits are disconnected during component disposal.

```csharp
async ValueTask IAsyncDisposable.DisposeAsync()
{
    try
    {
        if (objInstance is not null)
        {
            await objInstance.DisposeAsync();
        }
    }
    catch (JSDisconnectedException)
    {
    }
}
```

If you must clean up your own JS objects or execute other JS code on the client after a circuit is lost, use the [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JS on the client. The `MutationObserver` pattern allows you to execute JS code when an element is removed from the DOM.

For more information, see the following articles:

* <xref:blazor/js-interop/index#dom-cleanup-tasks-during-component-disposal>: Includes a code example of the `MutationObserver` pattern.
* <xref:blazor/fundamentals/handle-errors#javascript-interop>: The *JavaScript interop* section discusses error handling in JS interop scenarios.
* <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>: The *Component disposal with `IDisposable` and `IAsyncDisposable`* section describes how to implement disposal patterns in Razor components.
