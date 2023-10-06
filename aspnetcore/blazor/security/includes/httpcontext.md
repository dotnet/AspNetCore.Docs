:::moniker range=">= aspnetcore-8.0"

<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> must be avoided when interactive rendering for the following reasons:

* The interface isn't implemented for interactive WebAssembly rendering.
* For interactive server rendering, the implementation isn't guaranteed to exist.

<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> can be used for components that are statically rendered on the server. **However, we recommend avoid using it if possible.**

<xref:Microsoft.AspNetCore.Http.HttpContext> can be used as a [cascading parameter](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) only in *statically-rendered root components* for general tasks, such as inspecting and modifying headers or other properties. The value is always `null` for interactive rendering. It's permissable to use it in the `App` component (`Components/App.razor`).

```csharp
[CascadingParameter]
public HttpContext? HttpContext { get; set; }
```

One caveat for using <xref:Microsoft.AspNetCore.Http.HttpContext> is that it won't compile in the `.Client` project of a Blazor Web App for WebAssembly rendering because the `.Client` project doesn't reference the [HTTP Abstractions package](https://www.nuget.org/packages/Microsoft.AspNetCore.Http.Abstractions). Even if the package reference is added to the `.Client` project, <xref:Microsoft.AspNetCore.Http.HttpContext> still isn't supported by the Blazor framework on WebAssembly, so there's no point in adding the package just to permit the `.Client` project to compile.

<!-- UPDATE 8.0 Holding to hear back from Javier if he
                was refering to passing tokens coverage
                in the security docs for the pattern to
                cross-link

For scenarios where the <xref:Microsoft.AspNetCore.Http.HttpContext> is required, we recommend flowing the data via persistent component state from the server. For more information, see <xref:>.

-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

**Don't use <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>/<xref:Microsoft.AspNetCore.Http.HttpContext> directly or indirectly in the Razor components of server-side Blazor apps.** Blazor apps run outside of the ASP.NET Core pipeline context. The <xref:Microsoft.AspNetCore.Http.HttpContext> isn't guaranteed to be available within the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>, and <xref:Microsoft.AspNetCore.Http.HttpContext> isn't guaranteed to hold the context that started the Blazor app.

The recommended approach for passing request state to the Blazor app is through root component parameters during the app's initial rendering. Alternatively, the app can copy the data into a scoped service in the root component's initialization lifecycle event for use across the app. For more information, see <xref:blazor/security/server/additional-scenarios#pass-tokens-to-a-server-side-blazor-app>.

A critical aspect of server-side Blazor security is that the user attached to a given circuit might become updated at some point after the Blazor circuit is established but the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> ***isn't updated***. For more information on addressing this situation with custom services, see <xref:blazor/security/server/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

:::moniker-end
