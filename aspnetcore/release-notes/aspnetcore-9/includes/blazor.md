### .NET MAUI Blazor Hybrid and Web App solution template

A new solution template makes it easier to create .NET MAUI native and Blazor web client apps that share the same UI. This template shows how to create client apps that maximize code reuse and target Android, iOS, Mac, Windows, and Web. 

Key features of this template include:

* The ability to choose a Blazor interactive render mode for the web app.
* Automatic creation of the appropriate projects, including a Blazor Web App (global Interactive Auto rendering) and a .NET MAUI Blazor Hybrid app.
* The created projects use a shared Razor class library (RCL) to maintain the UI's Razor components.
* Sample code is included that demonstrates how to use dependency injection to provide different interface implementations for the Blazor Hybrid app and the Blazor Web App.

To get started, install the [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) and install the .NET MAUI workload, which contains the template:

```dotnetcli
dotnet workload install maui
```

Create a solution from the project template in a command shell using the following command:

```dotnetcli
dotnet new maui-blazor-web
```

The template is also available in Visual Studio.

> [!NOTE]
> Currently, an exception occurs if Blazor rendering modes are defined at the per-page/component level. For more information, see [BlazorWebView needs a way to enable overriding ResolveComponentForRenderMode (`dotnet/aspnetcore` #51235)](https://github.com/dotnet/aspnetcore/issues/51235).

For more information, see <xref:blazor/hybrid/tutorials/maui-blazor-web-app?view=aspnetcore-9.0>.

### Static asset delivery optimization

`MapStaticAssets` is a new middleware that helps optimize the delivery of static assets in any ASP.NET Core app, including Blazor apps.

For more information, see either of the following resources:

* The [Optimizing static web asset delivery](#optimizing-static-web-asset-delivery) section of this article.
* <xref:blazor/fundamentals/static-files?view=aspnetcore-9.0#static-asset-middleware>.

### Detect rendering location, interactivity, and assigned render mode at runtime

We've introduced a new API designed to simplify the process of querying component states at runtime. This API provides the following capabilities:

* **Determine the current execution location of the component**: This can be particularly useful for debugging and optimizing component performance.
* **Check if the component is running in an interactive environment**: This can be helpful for components that have different behaviors based on the interactivity of their environment.
* **Retrieve the assigned render mode for the component**: Understanding the render mode can help in optimizing the rendering process and improving the overall performance of a component.

For more information, see <xref:blazor/components/render-modes?view=aspnetcore-9.0#detect-rendering-location-interactivity-and-assigned-render-mode-at-runtime>.

### Improved server-side reconnection experience:

The following enhancements have been made to the default server-side reconnection experience:

* When the user navigates back to an app with a disconnected circuit, reconnection is attempted immediately rather than waiting for the duration of the next reconnect interval. This improves the user experience when navigating to an app in a browser tab that has gone to sleep.

* When a reconnection attempt reaches the server but the server has already released the circuit, a page refresh occurs automatically. This prevents the user from having to manually refresh the page if it's likely going to result in a successful reconnection.

* Reconnect timing uses a computed backoff strategy. By default, the first several reconnection attempts occur in rapid succession without a retry interval before computed delays are introduced between attempts. You can customize the retry interval behavior by specifying a function to compute the retry interval, as the following exponential backoff example demonstrates:

  ```javascript
  Blazor.start({
    circuit: {
      reconnectionOptions: {
        retryIntervalMilliseconds: (previousAttempts, maxRetries) => 
          previousAttempts >= maxRetries ? null : previousAttempts * 1000
      },
    },
  });
  ```

* The styling of the default reconnect UI has been modernized.

For more information, see <xref:blazor/fundamentals/signalr?view=aspnetcore-9.0#adjust-the-server-side-reconnection-retry-count-and-interval>.

### Simplified authentication state serialization for Blazor Web Apps

New APIs make it easier to add authentication to an existing Blazor Web App. When you create a new Blazor Web App with authentication using **Individual Accounts** and you enable WebAssembly-based interactivity, the project includes a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> in both the server and client projects. 

These providers flow the user's authentication state to the browser. Authenticating on the server rather than the client allows the app to access authentication state during prerendering and before the Blazor WebAssembly runtime is initialized.

The custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> implementations use the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) (<xref:Microsoft.AspNetCore.Components.PersistentComponentState>) to serialize the authentication state into HTML comments and read it back from WebAssembly to create a new <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> instance. 

This works well if you've started from the Blazor Web App project template and selected the **Individual Accounts** option, but it's a lot of code to implement yourself or copy if you're trying to add authentication to an existing project. There are now APIs, which are now part of the Blazor Web App project template, that can be called in the server and client projects to add this functionality:

* `AddAuthenticationStateSerialization`: Adds the necessary services to serialize the authentication state on the server.
* `AddAuthenticationStateDeserialization`: Adds the necessary services to deserialize the authentication state in the browser.

By default, the API only serializes the server-side name and role claims for access in the browser. An option can be passed to `AddAuthenticationStateSerialization` to include all claims.

For more information, see the following sections of the ** article:

* [Blazor Identity UI (Individual Accounts)](xref:blazor/security/server/index?view=aspnetcore-9.0#blazor-identity-ui-individual-accounts)
* [Manage authentication state in Blazor Web Apps](xref:blazor/security/server/index?view=aspnetcore-9.0#manage-authentication-state-in-blazor-web-apps)

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

This feature is covered by the reference documentation in <xref:blazor/components/render-modes?view=aspnetcore-9.0#static-ssr-pages-in-a-globally-interactive-app>.

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
