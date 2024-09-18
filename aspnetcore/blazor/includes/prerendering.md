:::moniker range=">= aspnetcore-8.0"

*This section applies to server-side apps that prerender Razor components. Prerendering is covered in <xref:blazor/components/prerender>.*

> [!NOTE]
> Internal navigation for [interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing) in Blazor Web Apps doesn't involve requesting new page content from the server. Therefore, prerendering doesn't occur for internal page requests. If the app adopts interactive routing, perform a full page reload for component examples that demonstrate prerendering behavior. For more information, see <xref:blazor/components/prerender#interactive-routing-and-prerendering>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to server-side apps and hosted Blazor WebAssembly apps that prerender Razor components. Prerendering is covered in <xref:blazor/components/prerendering-and-integration>.*

:::moniker-end

During prerendering, calling into JavaScript (JS) isn't possible. The following example demonstrates how to use JS interop as part of a component's initialization logic in a way that's compatible with prerendering.

The following `scrollElementIntoView` function:

* Scrolls to the passed element with [`scrollIntoView`](https://developer.mozilla.org/docs/Web/API/Element/scrollIntoView).
* Returns the element's `top` property value from the [`getBoundingClientRect`](https://developer.mozilla.org/docs/Web/API/Element/getBoundingClientRect) method.

```javascript
window.scrollElementIntoView = (element) => {
  element.scrollIntoView();
  return element.getBoundingClientRect().top;
}
```

Where <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> calls the JS function in component code, the <xref:Microsoft.AspNetCore.Components.ElementReference> is only used in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> and not in any earlier lifecycle method because there's no HTML DOM element until after the component is rendered.

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) ([reference source](xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A)) is called to enqueue rerendering of the component with the new state obtained from the JS interop call (for more information, see <xref:blazor/components/rendering>). An infinite loop isn't created because <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is only called when `scrollPosition` is `null`.

`PrerenderedInterop.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/PrerenderedInterop.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/prerendering/PrerenderedInterop.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/prerendering/PrerenderedInterop.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_Server/Pages/prerendering/PrerenderedInterop.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_Server/Pages/prerendering/PrerenderedInterop.razor":::

:::moniker-end

The preceding example pollutes the client with a global function. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).
