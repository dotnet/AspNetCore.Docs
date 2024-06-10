### .NET MAUI Blazor Hybrid and Web App solution template

A new solution template makes it easier to create .NET MAUI native and Blazor web client apps that share the same UI. This template shows how to create client apps that maximize code reuse and target Android, iOS, Mac, Windows, and Web. 

Key features of this template include:

* The ability to choose a Blazor interactive render mode for the web app.
* Automatic creation of the appropriate projects, including a Blazor Web App and a .NET MAUI Blazor Hybrid app.
* The created projects use a shared Razor class library (RCL) to maintain the UI's Razor components.
* Sample code is included that demonstrates how to use dependency injection to provide different interface implementations for the Blazor Hybrid and Blazor Web App. In .NET 8, this is a manual process documented in [Build a .NET MAUI Blazor Hybrid app with a Blazor Web App](https://aka.ms/maui-blazor-web).

To get started, install the [.NET 9 SDK](https://get.dot.net/9) and install the .NET MAUI workload, which contains the template.

```dotnetcli
dotnet workload install maui
```

Then create the template from the command line like this:

```dotnetcli
dotnet new maui-blazor-web
```

The template is also available in Visual Studio.
> [!NOTE]
> Currently Blazor hybrid apps throw an exception if the Blazor rendering modes are defined at the page/component level. For more information, see [#51235](https://github.com/dotnet/aspnetcore/issues/51235).

### Static asset deliver optimization

For more information, see the [Optimizing static web asset delivery](#optimizing-static-web-asset-delivery) section.

### Detect the current component's render mode at runtime

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

### Improved Blazor Server reconnection experience:

The following enhancements have been made to the default Blazor Server reconnection experience:

* Reconnect timing now uses an exponential backoff strategy. The first several reconnection attempts happen in rapid succession, and then a delay gradually gets introduced between attempts.

  This behavior can be customized by specifying a function to compute the retry interval. For example:

  ```js
  Blazor.start({
    circuit: {
      reconnectionOptions: {
        retryIntervalMilliseconds: (previousAttempts, maxRetries) => previousAttempts >= maxRetries ? null : previousAttempts * 1000,
      },
    },
  });
  ```

* A reconnect attempt is immediate when the user navigates back to an app with a disconnected circuit. In this case, the automatic retry interval is ignored. This behavior especially improves the user experience when navigating to an app in a browser tab that has gone to sleep.

* If a reconnection attempt reaches the server, but reconnection fails because the server had already released the circuit, a refresh occurs automatically. A manual refresh isn't needed if successful reconnection is likely.

* The styling of the default reconnect UI has been modernized.

### Simplified authentication state serialization for Blazor Web Apps

New APIs make it easier to add authentication to an existing Blazor web app. When you create a new Blazor web app project with authentication using **Individual Accounts** and you enable WebAssembly-based interactivity, the project includes a custom `AuthenticationStateProvider` in both the server and client projects. 

These providers flow the user's authentication state to the browser. Authenticating on the server rather than the client allows the app to access authentication state during prerendering and before the WebAssembly runtime is initialized.

The custom `AuthenticationStateProvider` implementations use the `PersistentComponentState` service to serialize the authentication state into HTML comments and then read it back from WebAssembly to create a new `AuthenticationState` instance. 

This works well if you've started from the Blazor web app project template and selected the **Individual Accounts** option, but it's a lot of code to implement yourself or copy if you're trying to add authentication to an existing project.

There are now APIs that can be called in the server and client projects to add this functionality:

* In the server project, use [`AddAuthenticationStateSerialization`](https://source.dot.net/#Microsoft.AspNetCore.Components.WebAssembly.Server/WebAssemblyRazorComponentsBuilderExtensions.cs,5557151694ca7c07) in `Program.cs` to add the necessary services to serialize the authentication state on the server.

  ```csharp
  builder.Services.AddRazorComponents()
      .AddInteractiveWebAssemblyComponents()
      .AddAuthenticationStateSerialization();
  ```

* In the client project, use [`AddAuthenticationStateDeserialization`](https://apisof.net/catalog/4a296157ae3e0f6f0c352bfb4a0c5d5a?) in `Program.cs` to add the necessary services to deserialize the authentication state in the browser.

  ```csharp
  builder.Services.AddAuthorizationCore();
  builder.Services.AddCascadingAuthenticationState();
  builder.Services.AddAuthenticationStateDeserialization();
  ```

By default, these APIs will only serialize the server-side name and role claims for access in the browser. To include all claims, use [AuthenticationStateSerializationOptions](https://source.dot.net/#Microsoft.AspNetCore.Components.WebAssembly.Server/AuthenticationStateSerializationOptions.cs,f2703f443f0954f5) on the server:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization(options => options.SerializeAllClaims = true);
```

The Blazor Web App project template has been updated to use these APIs.

### Add static server-side rendering (SSR) pages to a globally-interactive Blazor Web App

With the release of .NET 9, it's now simpler to add static SSR pages to apps that adopt global interactivity.

This approach is only useful when the app has specific pages that can't work with interactive Server or WebAssembly rendering. For example, adopt this approach for pages that depend on reading/writing HTTP cookies and can only work in a request/response cycle instead of interactive rendering. For pages that work with interactive rendering, you shouldn't force them to use static SSR rendering, as it's less efficient and less responsive for the end user.

Mark any Razor component page with the new `[ExcludeFromInteractiveRouting]` attribute assigned with the `@attribute` Razor directive:

```razor
@attribute [ExcludeFromInteractiveRouting]
```

Applying the attribute causes navigation to the page to exit from interactive routing. Inbound navigation is forced to perform a full-page reload instead resolving the page via interactive routing. The full-page reload forces the top-level root component, typically the `App` component (`App.razor`), to rerender from the server, allowing the app to switch to a different top-level render mode.

The `HttpContext.AcceptsInteractiveRouting` extension method allows the component to detect whether `[ExcludeFromInteractiveRouting]` is applied to the current page.

In the `App` component, use the pattern in the following example:

* Pages that aren't annotated with `[ExcludeFromInteractiveRouting]` default to the `InteractiveServer` render mode with global interactivity. You can replace `InteractiveServer` with `InteractiveWebAssembly` or `InteractiveAuto` to specify a different default global render mode.
* Pages annotated with `[ExcludeFromInteractiveRouting]` adopt static SSR (`PageRenderMode` is assigned `null`).

```razor
<!DOCTYPE html>
<html>
<head>
    ...
    <HeadOutlet @rendermode="@PageRenderMode" />
</head>
<body>
    <Routes @rendermode="@PageRenderMode" />
    ...
</body>
</html>

@code {
    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    private IComponentRenderMode? PageRenderMode
        => HttpContext.AcceptsInteractiveRouting() ? InteractiveServer : null;
}
```

An alternative to using the `HttpContext.AcceptsInteractiveRouting` extension method is to read endpoint metadata manually using `HttpContext.GetEndpoint()?.Metadata`.

This feature is covered by the reference documentation in <xref:blazor/components/render-modes#static-ssr-pages-in-a-globally-interactive-app>.

### Constructor injection

Razor components support constructor injection.

In the following example, the partial (code-behind) class injects the `NavigationManager` service using a [primary constructor](/dotnet/csharp/whats-new/tutorials/primary-constructors):

```csharp
public partial class ConstructorInjection(NavigationManager navigation)
{
    protected NavigationManager Navigation { get; } = navigation;
}
```

For more information, see <xref:blazor/fundamentals/dependency-injection?view=aspnetcore-9.0#request-a-service-in-a-component>.

### Websocket compression for Interactive Server components

By default, Interactive Server components enable compression for [WebSocket connections](xref:fundamentals/websockets) and set a `frame-ancestors` [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP) directive set to `'self'`, which only permits embedding the app in an `<iframe>` of the origin from which the app is served when compression is enabled or when a configuration for the WebSocket context is provided.

Compression can be disabled by setting `ConfigureWebSocketOptions` to `null`, which reduces the [vulnerability of the app to attack](xref:blazor/security/server/interactive-server-side-rendering#interactive-server-components-with-websocket-compression-enabled) but may result in reduced performance:

```csharp
.AddInteractiveServerRenderMode(o => o.ConfigureWebSocketOptions = null)
```

Configure a stricter `frame-ancestors` CSP with a value of `'none'` (single quotes required), which allows WebSocket compression but prevents browsers from embedding the app into any `<iframe>`:

```csharp
.AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = "'none'")
```

For more information, see the following resources:

* <xref:blazor/fundamentals/signalr?view=aspnetcore-9.0#websocket-compression-for-interactive-server-components>
* <xref:blazor/security/server/interactive-server-side-rendering?view=aspnetcore-9.0#interactive-server-components-with-websocket-compression-enabled>

### Handle keyboard composition events in Blazor

The new `KeyboardEventArgs.IsComposing` property indicates if the keyboard event [is part of a composition session](https://w3c.github.io/uievents/#dom-keyboardevent-iscomposing). Tracking the composition state of keyboard events is crucial for handling international character input methods.

### Added `OverscanCount` parameter to `QuickGrid`

The [`QuickGrid`](xref:Microsoft.AspNetCore.Components.QuickGrid) component now exposes an `OverscanCount` property that specifies how many additional rows are rendered before and after the visible region when virtualization is enabled.

The default `OverscanCount` is 3. The following example increases the `OverscanCount` to 4:

```razor
<QuickGrid ItemsProvider="itemsProvider" Virtualize="true" OverscanCount="4">
    ...
</QuickGrid>
```
