*This section only applies to client-side components.*

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across server-side and client-side render modes. On the server, all JS interop calls must be asynchronous because they're sent over a network connection.

If you know for certain that your component only runs on WebAssembly, you can choose to make synchronous JS interop calls. This has slightly less overhead than making asynchronous calls and can result in fewer render cycles because there's no intermediate state while awaiting results.

To make a synchronous call from .NET to JavaScript in a client-side component, cast <xref:Microsoft.JSInterop.IJSRuntime> to <xref:Microsoft.JSInterop.IJSInProcessRuntime> to make the JS interop call:

```razor
@inject IJSRuntime JS

...

@code {
    protected override void HandleSomeEvent()
    {
        var jsInProcess = (IJSInProcessRuntime)JS;
        var value = jsInProcess.Invoke<string>("javascriptFunctionIdentifier");
    }
}
```

When working with <xref:Microsoft.JSInterop.IJSObjectReference> in ASP.NET Core 5.0 or later client-side components, you can use <xref:Microsoft.JSInterop.IJSInProcessObjectReference> synchronously instead. <xref:Microsoft.JSInterop.IJSInProcessObjectReference> implements <xref:System.IAsyncDisposable>/<xref:System.IDisposable> and should be disposed for garbage collection to prevent a memory leak, as the following example demonstrates:

```razor
@inject IJSRuntime JS
@implements IAsyncDisposable

...

@code {
    ...
    private IJSInProcessObjectReference? module;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSInProcessObjectReference>("import", 
            "./scripts.js");
        }
    }

    ...

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
```
