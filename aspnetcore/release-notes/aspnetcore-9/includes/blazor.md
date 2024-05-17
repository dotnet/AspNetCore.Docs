<!-- ENABLE at Pre4 release ...

### Add static server-side rendering (SSR) pages to a globally-interactive Blazor Web App

The Blazor Web App template includes an option to enable *global interactivity*, which means that all pages run on Server, WebAssembly, or Auto (Server and WebAssembly) interactivity mode. Until the release of .NET 9, it wasn't possible to add static SSR pages to apps that adopt global interactivity.

Now, you can mark any Razor component page with the new `[ExcludeFromInteractiveRouting]` attribute assigned with the `@attribute` Razor directive:

```razor
@attribute [ExcludeFromInteractiveRouting]
```

Applying the attribute causes navigation to the page to exit from interactive routing. That is, inbound navigation is forced to perform a full-page reload instead resolving the page via SPA-style interactive routing. This means that your top-level root component, typically the `App` component (`App.razor`), re-runs, allowing you to switch to a different top-level render mode.

In your `App` component, you can use the following pattern, where all pages default to the `InteractiveServer` render mode, retaining global interactivity, except for pages annotated with `[ExcludeFromInteractiveRouting]`, which only render with static SSR. Of course, you can replace `InteractiveServer` with `InteractiveWebAssembly` or `InteractiveAuto` to specify a different default global mode.

```razor
<!DOCTYPE html>
<html>
<head>
    ... other head content here ...
    <HeadOutlet @rendermode="@PageRenderMode" />
</head>
<body>
    <Routes @rendermode="@PageRenderMode" />
    <script src="_framework/blazor.web.js"></script>
</body>
</html>

@code {
    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    private IComponentRenderMode? PageRenderMode
        => HttpContext.AcceptsInteractiveRouting() ? InteractiveServer : null;
}
```

The new `HttpContext.AcceptsInteractiveRouting` extension method is a helper that makes it easy to detect whether `[ExcludeFromInteractiveRouting]` is applied to the current page. Alternatively, you can read endpoint metadata manually using `HttpContext.GetEndpoint()?.Metadata`.

This approach is useful only if you have certain pages that can't work with interactive Server or WebAssembly rendering. For example, adopt this approach for pages that include code that depends on reading/writing HTTP cookies and can only work in a request/response cycle. Forcing those pages to use static SSR mode forces them into this traditional request/response cycle instead of interactive SPA-style rendering.

For pages that work with interactive SPA-style rendering, you shouldn't force them to use static SSR rendering, as it's less efficient and less responsive for the end user.

This feature is covered by the reference documentation in <xref:blazor/components/render-modes#static-ssr-pages-in-a-globally-interactive-app>.
-->

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
