:::moniker range=">= aspnetcore-8.0"

*This section applies to server-side apps that prerender Razor components. Prerendering is covered in <xref:blazor/components/prerender>.*

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to server-side apps and hosted Blazor WebAssembly apps that prerender Razor components. Prerendering is covered in <xref:blazor/components/prerendering-and-integration>.*

:::moniker-end

While an app is prerendering, certain actions, such as calling into JavaScript (JS), aren't possible.

For the following example, the `setElementText1` function is called with <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType> and doesn't return a value.

> [!NOTE]
> For general guidance on JS location and our recommendations for production apps, see <xref:blazor/js-interop/index#javascript-location>.

```html
<script>
  window.setElementText1 = (element, text) => element.innerText = text;
</script>
```

> [!WARNING]
> **The preceding example modifies the DOM directly for demonstration purposes only.** Directly modifying the DOM with JS isn't recommended in most scenarios because JS can interfere with Blazor's change tracking. For more information, see <xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom>.

The [`OnAfterRender{Async}` lifecycle event](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) isn't called during the prerendering process on the server. Override the `OnAfterRender{Async}` method to delay JS interop calls until after the component is rendered and interactive on the client after prerendering.

`PrerenderedInterop1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/prerendering/PrerenderedInterop1.razor" highlight="2-3,10-17":::

> [!NOTE]
> The preceding example pollutes the client with global methods. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).
>
> Example:
>
> ```javascript
> export setElementText1 = (element, text) => element.innerText = text;
> ```

The following component demonstrates how to use JS interop as part of a component's initialization logic in a way that's compatible with prerendering. The component shows that it's possible to trigger a rendering update from inside <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>. The developer must be careful to avoid creating an infinite loop in this scenario.

For the following example, the `setElementText2` function is called with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> and returns a value.

> [!NOTE]
> For general guidance on JS location and our recommendations for production apps, see <xref:blazor/js-interop/index#javascript-location>.

```html
<script>
  window.setElementText2 = (element, text) => {
    element.innerText = text;
    return text;
  };
</script>
```

> [!WARNING]
> **The preceding example modifies the DOM directly for demonstration purposes only.** Directly modifying the DOM with JS isn't recommended in most scenarios because JS can interfere with Blazor's change tracking. For more information, see <xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom>.

Where <xref:Microsoft.JSInterop.JSRuntime.InvokeAsync%2A?displayProperty=nameWithType> is called, the <xref:Microsoft.AspNetCore.Components.ElementReference> is only used in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> and not in any earlier lifecycle method because there's no JS element until after the component is rendered.

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to rerender the component with the new state obtained from the JS interop call (for more information, see <xref:blazor/components/rendering>). The code doesn't create an infinite loop because `StateHasChanged` is only called when `data` is `null`.

`PrerenderedInterop2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/prerendering/PrerenderedInterop2.razor" highlight="3-4,18,23-29":::

> [!NOTE]
> The preceding example pollutes the client with global methods. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).
>
> Example:
>
> ```javascript
> export setElementText2 = (element, text) => {
>   element.innerText = text;
>   return text;
> };
> ```
