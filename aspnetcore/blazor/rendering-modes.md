# Component rendering modes

This article explains the multiple ways in which components can be rendered as part of an ASP.NET Core application. There are four ways to render an initial component hierachy into an application:
* Static rendering: Creates a component hierarchy and renders its contents into static HTML. After that, it disposes the component hierarchy.
* Dynamic rendering: Includes a marker element on the page and when the JavaScript blazor server-side library boots up it creates the initial hierarchy and renders the component into the page.
* Attached rendering: Creates a component hierarchy and renders its contents into static HTML. After that, it preserves the rendered components in memory for a while until the JavaScript blazor server-side library boots up and resumes the rendering on the client.
* Detached rendering: It is a combination of static and dynamic rendering. The initial markup is produced by a static renderer, after which the componet hierarchy gets destroyed and a marker element is included on the page so that when the JavaScript blazor server-side (or client-side) library boots up, it recreates the initial component hierarchy and starts rendering the content on the client replacing the statically rendered content.

## Choosing between different rendering modes

Attached rendering is the most powerful way of rendering a component. It enables prerendering a root component passing in an initial set of parameters and maintaining that state until the client reconnects and is able to interact with the application. This additional power comes at the expense of having to keep the component hierarchy in memory whether the client connects to the application or not and requires sticky sessions to work.

Detached rendering is less powerful than attached rendering. It enables prerendering a root component, but while possible, its not recommended to pass in parameters as when the client connects back to the server, the root component will be rendered again from scratch and the initial set of parameters will not be available. This mode is also best suited when you are prerendering a blazor client-side application, where the state can't be transferred from the initial server-side render to the client.

Dynamic rendering is the default form of rendering a component where a marker is defined on the page and when the client bootstraps the application after the initial request, the component gets rendered and the UI updated (client or server-side). It has the disadvantage that there is no meaningful content as part of the first response and that no parameters can be passed in.

Finally, static rendering is suitable for when you don't need interactivity, (for example, printed media or reusing a component as part of an MVC application).

## Special characteristics of different rendering modes

### Static rendering
When a component is rendered statically, the component gets instantiated and passed an inital set of parameters. The static renderer waits for the initial call to `IComponent.SetParametersAsync` to complete and then produces HTML based on the current state of the component. After producing the initial markup the component hierarchy gets disposed. For the most common case (components extending ComponentBase) this means that the render waits after OnInitAsync and OnParametersSetAsync have run before producing the markup representing the component.

It is important to note that other lifecycle methods like `OnAfterRenderAsync` will not run when the component is being rendered statically and that features that require JavaScript interoperability won't be available.


```csharp
await Html.RenderStaticComponentAsync<App>()
```

```csharp
await Html.RenderStaticComponentAsync<App>(new { Title= "My awesome application" });
```

### Attached rendering
When a component is rendered attached, the component gets instantiated and passed an inital set of parameters. The renderer waits for the initial call to `IComponent.SetParametersAsync` to complete and then produces HTML based on the current state of the component. The whole component hierarchy is maintained in memory for a limited ammount of time and a pair of HTML comments are emitted around the produced markup to delimit the area where the component was rendered.

When the browser loads the blazor.server.js script, it scans the page for components that were prerendered and reconnects to them, producing updates to the UI and enabling interactivity.
Lifecycle methods like `OnAfterRenderAsync` will only run when the component has successfully rendered using the client-side renderer and has become interactive. Features that require JavaScript interoperability will be available on OnAfterRenderAsync.

```csharp
await Html.RenderComponentAsync<App>()
```

```csharp
await Html.RenderComponentAsync<App>(new { Title= "My awesome application" });
```

### Dynamic rendering
In this mode, rendering is always started on the client; when the client connects to the server it requests that certain components be rendered. As such, is not possible to pass parameters to the root component and is the client the one that starts the render process.

```
<app></app>
```

### Detached rendering
In this mode, the component gets rendered statically on the server and then, the browser rerenders the entire component again either by connecting to the server and rendering the entire component or by rerendering the component on the client-side. This is the combination that blazor client-side uses for prerendering.
```razor
<app>@(await Html.RenderStaticComponent<App>())</app>
```
