:::moniker range=">= aspnetcore-8.0"

*This section applies to server-side apps that prerender Razor components. Prerendering is covered in <xref:blazor/components/prerender>.*

> [!NOTE]
> Internal navigation for interactive routing in Blazor Web Apps doesn't involve requesting new page content from the server. Therefore, prerendering doesn't occur for internal page requests. If the app adopts interactive routing, perform a full page reload for component examples that demonstrate prerendering behavior. For more information, see <xref:blazor/components/prerender#interactive-routing-and-prerendering>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to server-side apps and hosted Blazor WebAssembly apps that prerender Razor components. Prerendering is covered in <xref:blazor/components/prerendering-and-integration>.*

:::moniker-end

While an app is prerendering, certain actions, such as calling into JavaScript (JS), aren't possible.

The following example demonstrates how to use JS interop as part of a component's initialization logic in a way that's compatible with prerendering. The component shows that it's possible to trigger a rendering update from inside <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>. The developer must be careful to avoid creating an infinite loop in this scenario.

The following `scrollElementIntoView` function is called by a component with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> and returns a value.

```javascript
window.scrollElementIntoView = (element) => {
  element.scrollIntoView();
  return element.getBoundingClientRect().top;
}
```

Where <xref:Microsoft.JSInterop.JSRuntime.InvokeAsync%2A?displayProperty=nameWithType> is called, the <xref:Microsoft.AspNetCore.Components.ElementReference> is only used in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> and not in any earlier lifecycle method because there's no HTML DOM element until after the component is rendered.

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to rerender the component with the new state obtained from the JS interop call (for more information, see <xref:blazor/components/rendering>). The code doesn't create an infinite loop because `StateHasChanged` is only called when `scrollPosition` is `null`.

`PrerenderedInterop.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/PrerenderedInterop.razor":::

The preceding example pollutes the client with global functions. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).
