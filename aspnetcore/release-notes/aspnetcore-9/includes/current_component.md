## Detect the current component's render mode at runtime

We've introduced a new api designed to simplify the process of querying component states at runtime. This api provides the following capabilities:

* **Determining the current execution environment of the component**: This feature allows you to identify the environment in which the component is currently running. It can be particularly useful for debugging and optimizing component performance.
* **Checking if the component is running in an interactive environment**: This functionality enables you to verify whether the component is operating in an interactive environment. This can be helpful for components that have different behaviors based on the interactivity of their environment.
* **Retrieving the assigned render-mode for the component**: This feature allows you to obtain the render-mode assigned to the component. Understanding the render-mode can help in optimizing the rendering process and improving the overall performance of the component.

`ComponentBase` (and per extension your components), offer a new [`Platform`](https://source.dot.net/#Microsoft.AspNetCore.Components/ComponentBase.cs,d694f3b1e643e437) property (soon to be renamed `RendererInfo`) that exposes the [`Name`](https://source.dot.net/#Microsoft.AspNetCore.Components/RenderTree/ComponentPlatform.cs,23), [`IsInteractive`](https://source.dot.net/#Microsoft.AspNetCore.Components/RenderTree/ComponentPlatform.cs,30), and [`AssignedRenderMode`](https://source.dot.net/#Microsoft.AspNetCore.Components/ComponentBase.cs,64912adf8a598ff1) properties:

* `Platform.Name`: Where the component is running: `Static`, `Server`, `WebAssembly`, or `WebView`.
* `Platform.IsInteractive`: indicates whether the platform supports interactivity. This is `true` for all implementations except `Static`.
* `AssignedRenderMode`: Exposes the render mode value defined in the component hierarchy, if any, via the `render-mode` attribute on a root component or the `[RenderMode]` attribute. The values can be `InteractiveServer`, `InteractiveAuto` or `InteractiveWebassembly`.

These values are most useful during prerendering as they show where the component will transition to after prerendering. Knowing where the component will transition to after prerendering is often useful for rendering different content. For example, consider a create a Form component that is rendered interactively. You might choose to disable the inputs during prerendering. Once the component becomes interactive, the inputs are enabled.

Alternatively, if the component is not going to be rendered in an interactive context, consider rendering markup to support performing any action through regular web mechanics.
