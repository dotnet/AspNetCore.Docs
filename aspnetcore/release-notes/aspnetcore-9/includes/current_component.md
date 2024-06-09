## Detect the current component's render mode at runtime

We've introduced an API to make easier to query components at runtime:

* Where is the component currently running.
* Is the component running in an interactive environment.
* What is the assigned render-mode for my component.

`ComponentBase` (and per extension your components), offer a new [`Platform`](https://source.dot.net/#Microsoft.AspNetCore.Components/ComponentBase.cs,d694f3b1e643e437) property (soon to be renamed `RendererInfo`) that exposes the [`Name`](https://source.dot.net/#Microsoft.AspNetCore.Components/RenderTree/ComponentPlatform.cs,23), [`IsInteractive`](https://source.dot.net/#Microsoft.AspNetCore.Components/RenderTree/ComponentPlatform.cs,30), and [`AssignedRenderMode`](https://source.dot.net/#Microsoft.AspNetCore.Components/ComponentBase.cs,64912adf8a598ff1) properties:

* `Platform.Name`: Where the component is running: `Static`, `Server`, `WebAssembly`, or `WebView`.
* `Platform.IsInteractive`: indicates whether the platform supports interactivity. This is `true` for all implementations except `Static`.
* `AssignedRenderMode`: Exposes the render mode value defined in the component hierarchy, if any, via the `render-mode` attribute on a root component or the `[RenderMode]` attribute. The values can be `InteractiveServer`, `InteractiveAuto` or `InteractiveWebassembly`.

These values are most useful during prerendering as they show where the component will transition to after prerendering. Knowing where the component will transition to after prerendering is often useful for rendering different content.

For example, consider a create a Form component that is rendered interactively. You might choose to disable the inputs during prerendering. Once the component becomes interactive, the inputs are enabled.

Alternatively, if the component is not going to be rendered in an interactive context, you might render markup to support performing any action through regular web mechanics.
