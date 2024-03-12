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
