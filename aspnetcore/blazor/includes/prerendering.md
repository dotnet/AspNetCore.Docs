---
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
While a Blazor Server app is prerendering, certain actions, such as calling into JavaScript, aren't possible because a connection with the browser hasn't been established. Components may need to render differently when prerendered.

To delay JavaScript interop calls until after the connection with the browser is established, you can override the [`OnAfterRenderAsync` lifecycle event](xref:blazor/components/lifecycle#after-component-render). This event is only called after the app is fully rendered and the client connection is established.

`Pages/PrerenderedInterop1.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/prerendering/PrerenderedInterop1.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/prerendering/PrerenderedInterop1.razor)]

::: moniker-end

For the preceding example code, provide a `setElementText1` JavaScript function inside the `<head>` element of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server). The function is called with <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType> and doesn't return a value:

```html
<script>
  window.setElementText1 = (element, text) => element.innerText = text;
</script>
```

> [!WARNING]
> **The preceding example modifies the Document Object Model (DOM) directly for demonstration purposes only.** Directly modifying the DOM with JavaScript isn't recommended in most scenarios because JavaScript can interfere with Blazor's change tracking.

The following component demonstrates how to use JavaScript interop as part of a component's initialization logic in a way that's compatible with prerendering. The component shows that it's possible to trigger a rendering update from inside <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>. The developer must be careful to avoid creating an infinite loop in this scenario.

Where <xref:Microsoft.JSInterop.JSRuntime.InvokeAsync%2A?displayProperty=nameWithType> is called, `ElementRef` is only used in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> and not in any earlier lifecycle method because there's no JavaScript element until after the component is rendered.

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes) is called to rerender the component with the new state obtained from the JavaScript interop call (for more information, see <xref:blazor/components/rendering>). The code doesn't create an infinite loop because `StateHasChanged` is only called when `infoFromJs` is `null`.

`Pages/PrerenderedInterop2.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/prerendering/PrerenderedInterop2.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/prerendering/PrerenderedInterop2.razor)]

::: moniker-end

For the preceding example code, provide a `setElementText2` JavaScript function inside the `<head>` element of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server). The function is called with<xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> and returns a value:

```html
<script>
  window.setElementText2 = (element, text) => {
    element.innerText = text;
    return text;
  };
</script>
```

> [!WARNING]
> **The preceding example modifies the Document Object Model (DOM) directly for demonstration purposes only.** Directly modifying the DOM with JavaScript isn't recommended in most scenarios because JavaScript can interfere with Blazor's change tracking.
