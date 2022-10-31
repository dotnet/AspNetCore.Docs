*This section only applies to Blazor Server apps.*

In server-side component and object disposal scenarios, JavaScript (JS) interop calls can't be issued after the SignalR circuit is disconnected during component disposal. The following method calls fail and log a message that the circuit is disconnected:

* JS interop method calls
  * <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType>
  * <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A?displayProperty=nameWithType>
  * <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType>)
* `Dispose`/`DisposeAsync` calls on any <xref:Microsoft.JSInterop.IJSObjectReference> or `Dispose` calls on any <xref:Microsoft.JSInterop.DotNetObjectReference>.

The error message logged by the framework is of type <xref:Microsoft.JSInterop.JSDisconnectedException>. In order to avoid logging the exception, catch it in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.

For the following example with an <xref:Microsoft.JSInterop.IJSObjectReference> object used to call JS from .NET:

* The component implements <xref:System.IAsyncDisposable>.
* `objInstance` is an <xref:Microsoft.JSInterop.IJSObjectReference>.
* Optionally, you can log a message that the circuit was disconnected in the `catch` statement at whatever log level you prefer. The following example doesn't log a custom message because it assumes the developer doesn't care about when or where circuits are disconnected.
* <xref:Microsoft.JSInterop.JSDisconnectedException> is caught and not logged.

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

> [!NOTE]
> The pattern for <xref:Microsoft.JSInterop.DotNetObjectReference> disposal is the same in scenarios where .NET is called from JS.
>
> When a circuit fails and developer disposal code fails with a caught or uncaught <xref:Microsoft.JSInterop.JSDisconnectedException>, automatic garbage collection eventually disposes of any objects created by the developer in the component.

If you must clean up your own JS objects or execute other JS code on the client during circuit disconnection or you prefer to dispose one or more <xref:Microsoft.JSInterop.IJSObjectReference>s or <xref:Microsoft.JSInterop.DotNetObjectReference>s on the client, use the [`MutationObserver` (MDN documentation)](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JS on the client and avoid calling a `Dispose`/`DisposeAsync` method in the component.

For more information, see the following articles:

* <xref:fundamentals/handle-errors>: The *JavaScript interop* section discusses error handling in JS interop scenarios. <!-- AUTHOR NOTE: The JavaScript interop section isn't linked because the section title changed across versions of the doc. Prior to 6.0, the section appears twice, once for Blazor Server and once for Blazor WebAssembly, each with the hosting model name in the section name. -->
* <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>: The *Component disposal with `IDisposable` and `IAsyncDisposable`* section describes how to implement disposal patterns in Razor components.
