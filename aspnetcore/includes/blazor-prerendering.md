While a Blazor server-side app is prerendering, certain actions, such as calling into JavaScript, aren't possible because a connection with the browser hasn't been established. Components may need to render differently when prerendered.

To delay JavaScript interop calls until after the connection with the browser is established, you can use the `OnAfterRenderAsync` component lifecycle event. This event is only called after the app is fully rendered and the client connection is established.

```cshtml
@using Microsoft.JSInterop
@inject IJSRuntime JSRuntime

<input ref="myInput" value="Value set during render" />

@functions {
    ElementRef myInput;

    protected override void OnAfterRender()
    {
        JSRuntime.InvokeAsync<object>(
            "setElementValue", myInput, "Value set after render");
    }
}
```

This following component demonstrates how to use JavaScript interop as part of a component's initialization logic in a way that's compatible with prerendering.

The component shows that it's possible to trigger a rendering update from inside `OnAfterRenderAsync`. For this scenario. the developer must avoid creating an infinite loop.

Where `JSRuntime.InvokeAsync` is called, `ElementRef` is only used in `OnAfterRenderAsync` and not any earlier lifecycle method because there's no JavaScript element until after the component is rendered.

`StateHasChanged` is called to rerender the component with the new state obtained from the JavaScript interop call. The code doesn't create an infinite loop because `StateHasChanged` is only called when `infoFromJs` is `null`.

```cshtml
@page "/prerendered-interop"
@using Microsoft.AspNetCore.Components
@using Microsoft.JSInterop
@inject IComponentContext ComponentContext
@inject IJSRuntime JSRuntime

<p>
    Get value via JS interop call:
    <strong id="val-get-by-interop">@(infoFromJs ?? "No value yet")</strong>
</p>

<p>
    Set value via JS interop call:
    <input id="val-set-by-interop" ref="@myElem" />
</p>

@functions {
    string infoFromJs;
    ElementRef myElem;

    protected override async Task OnAfterRenderAsync()
    {
        // TEMPORARY: Currently we need this guard to avoid making the interop
        // call during prerendering. Soon this will be unnecessary because we
        // will change OnAfterRenderAsync so that it won't run during the
        // prerendering phase.
        if (!ComponentContext.IsConnected)
        {
            return;
        }

        if (infoFromJs == null)
        {
            infoFromJs = await JSRuntime.InvokeAsync<string>(
                "setElementValue", myElem, "Hello from interop call");

            StateHasChanged();
        }
    }
}
```

To conditionally render different content based on whether the app is currently prerendering content, use the `IsConnected` property on the `IComponentContext` service. When running server-side, `IsConnected` only returns `true` if there's an active connection to the client. It always returns `true` when running client-side.

```cshtml
@page "/isconnected-example"
@using Microsoft.AspNetCore.Components.Services
@inject IComponentContext ComponentContext

<h1>IsConnected Example</h1>

<p>
    Current state:
    <strong id="connected-state">
        @(ComponentContext.IsConnected ? "connected" : "not connected")
    </strong>
</p>

<p>
    Clicks:
    <strong id="count">@count</strong>
    <button id="increment-count" onclick="@(() => count++)">Click me</button>
</p>

@functions {
    private int count;
}
```
