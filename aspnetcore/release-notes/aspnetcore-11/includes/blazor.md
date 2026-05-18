### New `DisplayName` component and support for `[Display]` and `[DisplayName]` attributes

<!-- UPDATE 11.0 - API cross-link 

<xref:Microsoft.AspNetCore.Components.Forms.DisplayName%601>
-->
The `DisplayName` component can be used to display property names from metadata attributes:

```csharp
[Required, DisplayName("Production Date")]
public DateTime ProductionDate { get; set; }
```

The [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute) on the model class property is supported:

```csharp
[Required, Display(Name = "Production Date")]
public DateTime ProductionDate { get; set; }
```

Of the two approaches, the `[Display]` attribute is recommended, which makes additional properties available. The `[Display]` attribute also enables assigning a resource type for localization. When both attributes are present, `[Display]` takes precedence over `[DisplayName]`. If neither attribute is present, the component falls back to the property name.

Use the `DisplayName` component in labels or table headers:

```razor
<label>
    <DisplayName For="@(() => Model!.ProductionDate)" />
    <InputDate @bind-Value="Model!.ProductionDate" />
</label>
```

### Blazor Web script startup options format now supported for Blazor Server and Blazor WebAssembly scripts

The Blazor Web App script (`blazor.web.js`) options object passed to `Blazor.start()` uses the following format since the release of .NET 8:

```javascript
Blazor.start({
  ssr: { ... },
  circuit: { ... },
  webAssembly: { ... },
});
```

Now, Blazor Server (`blazor.server.js`) and Blazor WebAssembly (`blazor.webassembly.js`) scripts can use the same options format.

The following example shows the prior options format, which remains supported:

```javascript
Blazor.start({
  loadBootResource: function (...) {
      ...
    },
  });
```

The newly supported options format for the preceding example:

```javascript
Blazor.start({
  webAssembly: {
    loadBootResource: function (...) {
      ...
    },
  },
});
```

For more information, see <xref:blazor/fundamentals/startup?view=aspnetcore-11.0#startup-process-and-configuration>.

### New `BasePath` component

Blazor Web Apps can use the new `BasePath` component (`<BasePath />`) to render the app's app base path (`<base href>`) HTML tag automatically. For more information, see <xref:blazor/host-and-deploy/app-base-path?view=aspnetcore-11.0>.

### Inline JS event handler removed from the `NavMenu` component

The inline JS event handler that toggles the display of navigation links is no longer present in the `NavMenu` component of the Blazor Web App project template. Apps generated from the project template now use a [collocated JS module](xref:blazor/js-interop/javascript-location?view=aspnetcore-11.0#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) approach to show or hide the navigation bar on the rendered page. The new approach improves [Content Security Policy (CSP) compliance](xref:blazor/security/content-security-policy?view=aspnetcore-11.0) because it doesn't require the CSP to include an unsafe hash for the inline JS.

To migrate an existing app to .NET 11, including adopting the new JS module approach for the navigation bar toggler, see <xref:migration/100-to-110>.

### `NavigateTo` and `NavLink` support for relative navigation

The new `RelativeToCurrentUri` parameter (default: `false`) for <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> and the [`NavLink` component](xref:blazor/fundamentals/routing?view=aspnetcore-11.0#navlink-component) allows you to navigate to URIs relative to the current page path rather than the app's base URI.

Consider the following nested endpoints:

* `/docs`
  * `/getting-started`
    * `/installation`
    * `/configuration`

When the browser's URI is `/docs/getting-started/installation` and you want to navigate the user to `/docs/getting-started/configuration`, `NavigateTo("/configuration")` redirects to `/configuration` at the app's root instead of the relative path at `/docs/getting-started/configuration`. Set the `RelativeToCurrentUri` with <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> or the [`NavLink` component](xref:blazor/fundamentals/routing?view=aspnetcore-11.0#navlink-component) for the desired navigation:

```csharp
Navigation.NavigateTo("/configuration", new NavigationOptions
{
    RelativeToCurrentUri = true
});
```

```razor
<NavLink href="configuration" RelativeToCurrentUri="true">Configuration</NavLink>
```

### Persist temporary data between HTTP requests during static server-side rendering (static SSR)

To persist temporary data between HTTP requests during static server-side rendering (static SSR), Blazor supports TempData. TempData is ideal for scenarios such as flash messages after form submissions, passing data during redirects (POST-Redirect-GET pattern), and one-time notifications.

TempData is available when <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> is called in the app's `Program` file and is provided as a cascading value with the [`[CascadingParameter]` attribute](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

```csharp
[CascadingParameter]
public ITempData? TempData { get; set; }
```

When supplied to a parameter for simple read/write of a single value, use the `[SupplyParameterFromTempData]` attribute:

```csharp
[SupplyParameterFromTempData]
public string? Message { get; set; }
```

For more information, see <xref:blazor/state-management/server?view=aspnetcore-11.0#temporary-data-persistence>.

### New Blazor Web Worker template (`blazorwebworker`)

The standalone .NET Web Worker project template, which scaffolds a Web Worker client for offloading long-running work to a background thread in Blazor WebAssembly and Blazor Web apps (for client-side rendering, CSR), was renamed to the Blazor Web Worker project template (`blazorwebworker`) to make it clearer that it's part of the Blazor stack. Two often-requested capabilities have been added to the generated `WebWorkerClient`:

* `InvokeVoidAsync` for fire-and-forget worker calls that don't return a value, mirroring the shape on `IJSRuntime`.
* Cancellation and timeout support on both worker creation and worker invocations, so callers can pass a `CancellationToken` and tear down a stuck worker cleanly.

Existing projects created with the old template continue to work. The rename only affects the template name shown in `dotnet new list` and in Visual Studio's list of **Create a new project** templates.

For more information, see the following resources:

* <xref:blazor/blazor-web-workers?view=aspnetcore-11.0>
* [.NET Web Worker template update to Blazor Web Worker template (`dotnet/aspnetcore` #66070)](https://github.com/dotnet/aspnetcore/pull/66070) (Please don't comment on closed issues and PRs.)

### Virtualization enhancements

* The <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601> component no longer assumes every item has the same height. Previously, the component disabled the browser's native scroll anchoring (to avoid an infinite rendering loop), which meant any height change above the viewport&mdash;item expansion, data updates, lazy-loaded content&mdash;caused visible items to jump on screen. The `Virtualize` component now adapts to measured item sizes at runtime, which reduces incorrect spacing and scrolling when item heights vary.

  The updates use a hybrid approach: native CSS scroll anchoring on browsers that support it for non-`<table>` layouts with a manual `ResizeObserver`-based scroll-compensation fallback for `<table>` layouts and Safari, where native anchoring miscalculates positions on `<tr>` elements.
  
  Apps using the `Virtualize` component receive the benefits of these updates automatically. No developer API changes are required.

  These updates include an update to the default value of <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.OverscanCount%2A?displayProperty=nameWithType>, which was `3` in .NET 10 or earlier and now changes to `15` in .NET 11 or later. The change in default value increases the precision of average item height calculations.

  For more information, see the following resources:
  
  * [*Item size* section](xref:blazor/components/virtualization?view=aspnetcore-11.0#item-size) and [*Overscan count* section](xref:blazor/components/virtualization?view=aspnetcore-11.0#overscan-count) of the *Virtualization* article.
  * [[Virtualization] Visible content does not shift when in-DOM items above the viewport change height (`dotnet/aspnetcore` #65951)](https://github.com/dotnet/aspnetcore/pull/65951) (Please don't comment on closed issues and PRs).

* Use the new `AnchorMode` parameter to control how the viewport behaves at list edges when items are dynamically added:

  * `None`: No edge pinning. The viewport stays at the current scroll position regardless of item changes.
  * `Beginning`: Pins the viewport to the beginning of the list. For example, this pinning behavior is useful for a news feed user experience.
  * `End`: Pins the viewport to the end of the list. For example, this pinning behavior is useful for a chat or logging user experience.

  In the following example, the virtualized content is pinned to the beginning of the list:

  ```razor
  <Virtualize AnchorMode="Beginning" ...>
      ...
  </Virtualize>
  ```

  For more information, see the following resources:
  
  * <xref:blazor/components/virtualization?view=aspnetcore-11.0#control-viewport-scroll-position-behavior-when-items-are-dynamically-added>
  * [[release/11.0-preview4] Virtualization AnchorMode with for variable-height support (`dotnet/aspnetcore` #66521)](https://github.com/dotnet/aspnetcore/pull/66521) (Please don't comment on closed issues and PRs.)

### New service defaults library project template for Blazor WebAssembly apps

The `blazor-wasm-servicedefaults` project template creates a service defaults library for Blazor WebAssembly apps with [Aspire](/dotnet/aspire/get-started/aspire-overview) integration. For more information, see <xref:blazor/tooling?view=aspnetcore-11.0#service-defaults-library-for-blazor-webassembly-apps>.

### New development server for Blazor WebAssembly apps

<!-- UPDATE 11.0 - Link to package when it's out.

     [`Microsoft.AspNetCore.Components.Gateway`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Gateway)
-->

`Microsoft.AspNetCore.Components.Gateway` is a lightweight ASP.NET Core host that replaces [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer) for serving standalone Blazor WebAssembly applications during development and production.

For more information, see [[Blazor] Replace DevServer with BlazorGateway for standalone WASM apps (`dotnet/aspnetcore` #65982)](https://github.com/dotnet/aspnetcore/pull/65982) (Please don't comment on closed issues and PRs).

### Server-triggered circuit pause

*This feature applies to server-side Blazor apps.*

Blazor already supports graceful circuit pause and resume with [`Blazor.pauseCircuit()` and `Blazor.resumeCircuit()`](xref:blazor/state-management/server#pause-and-resume-circuits). .NET 11 introduces a symmetric server-side pause and resume capability, where the server can request that connected clients begin the graceful circuit-pause flow.

`Circuit.RequestCircuitPauseAsync(CancellationToken)` is used to request that the connected client begin the graceful circuit-pause flow. The `CancellationToken` cancels the request before it is accepted by the framework. The method returns `true` if the request was accepted and the client was asked to begin pausing.

This feature is useful in the following scenarios:

* Planned shutdowns and deployments.
* Instance draining.
* App maintenance windows.

For more information and an implementation example for server restarts, see <xref:blazor/state-management/server#server-triggered-circuit-pause>.

### Smaller Blazor WebAssembly publish output

Two trimming changes shrink published Blazor WebAssembly apps that don't use [OpenTelemetry (OTEL)](https://opentelemetry.io/) or Hot Reload:

* The `ComponentsMetrics` and `ComponentsActivitySource` types are now gated behind a `[FeatureSwitchDefinition]` attribute, so the trimmer can drop the metrics and tracing call paths from `Renderer` and friends when `System.Diagnostics.Metrics.Meter.IsSupported` is `false` (the default for trimmed apps) [[browser][wasm] Implement IL trimming for OTEL (`dotnet/aspnetcore` #65901)](https://github.com/dotnet/aspnetcore/pull/65901) (Please don't comment on closed issues and PRs).
* `HotReloadManager` now exposes a feature-switched `IsSupported` property tied to `System.Reflection.Metadata.MetadataUpdater.IsSupported`, so the trimmer can eliminate hot-reload caches and metadata-update handler registrations across the renderer when published [[blazor][wasm] Fix hot reload IL trimming (`dotnet/aspnetcore` #65903)](https://github.com/dotnet/aspnetcore/pull/65903) (Please don't comment on closed issues and PRs).

Apps that use OTEL or Hot Reload aren't affected by the preceding updates.
