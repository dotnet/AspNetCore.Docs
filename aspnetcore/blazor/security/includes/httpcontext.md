:::moniker range=">= aspnetcore-8.0"

<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> must be avoided with interactive rendering because there isn't a valid `HttpContext` available.

<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> can be used for components that are statically rendered on the server. **However, we recommend avoiding it if possible.**

<xref:Microsoft.AspNetCore.Http.HttpContext> can be used as a [cascading parameter](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) only in *statically-rendered root components* for general tasks, such as inspecting and modifying headers or other properties in the `App` component (`Components/App.razor`). The value is always `null` for interactive rendering.

```csharp
[CascadingParameter]
public HttpContext? HttpContext { get; set; }
```

For scenarios where the <xref:Microsoft.AspNetCore.Http.HttpContext> is required in interactive components, we recommend flowing the data via persistent component state from the server. For more information, see <xref:blazor/security/server/additional-scenarios#pass-tokens-to-a-server-side-blazor-app>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

**Don't use <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>/<xref:Microsoft.AspNetCore.Http.HttpContext> directly or indirectly in the Razor components of server-side Blazor apps.** Blazor apps run outside of the ASP.NET Core pipeline context. The <xref:Microsoft.AspNetCore.Http.HttpContext> isn't guaranteed to be available within the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>, and <xref:Microsoft.AspNetCore.Http.HttpContext> isn't guaranteed to hold the context that started the Blazor app.

The recommended approach for passing request state to the Blazor app is through root component parameters during the app's initial rendering. Alternatively, the app can copy the data into a scoped service in the root component's initialization lifecycle event for use across the app. For more information, see <xref:blazor/security/server/additional-scenarios#pass-tokens-to-a-server-side-blazor-app>.

A critical aspect of server-side Blazor security is that the user attached to a given circuit might become updated at some point after the Blazor circuit is established but the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> ***isn't updated***. For more information on addressing this situation with custom services, see <xref:blazor/security/server/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

:::moniker-end
