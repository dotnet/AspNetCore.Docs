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

The .NET Web Worker project template, which contains a Web Worker client for offloading long-running work to a background thread, has been renamed to the **Blazor Web Worker** project template (`blazorwebworker`). The name change makes it clearer that the template is part of the Blazor stack for use in Blazor WebAssembly and Blazor Web apps (for client-side rendering, CSR).

Two often-requested capabilities have been added to the generated `WebWorkerClient`:

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
  * [[release/11.0-preview4] Virtualization AnchorMode with variable-height support (`dotnet/aspnetcore` #66521)](https://github.com/dotnet/aspnetcore/pull/66521) (Please don't comment on closed issues and PRs.)

### New service defaults library project template for Blazor WebAssembly apps

The `blazor-wasm-servicedefaults` project template creates a service defaults library for Blazor WebAssembly apps with [Aspire](/dotnet/aspire/get-started/aspire-overview) integration. For more information, see <xref:blazor/tooling?view=aspnetcore-11.0#service-defaults-library-for-blazor-webassembly-apps>.

### New development server for Blazor WebAssembly apps

[`Microsoft.AspNetCore.Components.Gateway`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Gateway) is a lightweight ASP.NET Core host that replaces [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer) for serving standalone Blazor WebAssembly apps during development and production.

<!-- UPDATE 11.0 - Update the word "preview" in the following remark at RC
                   to "release candidate." Remove entirely at GA. -->

To adopt the Gateway in an existing standalone Blazor WebAssembly app, reference the preview `Microsoft.AspNetCore.Components.Gateway` package in the app's project file.

[!INCLUDE[](~/includes/package-reference.md)]

Custom routing code and middleware aren't required by the app. Fallback endpoints come from the static web assets manifest the SDK emits when the `StaticWebAssetSpaFallbackEnabled` property is set in the app's project file, which is present by default in standalone Blazor WebAssembly apps created from the project template:

```xml
<StaticWebAssetSpaFallbackEnabled>true</StaticWebAssetSpaFallbackEnabled>
```

Prior to the release of .NET 11, the `inspectUri` property of the `Properties/launchSettings.json` file:

* Enables the IDE to detect that the app is a Blazor app.
* Instructs the script debugging infrastructure to connect to the browser through Blazor's debugging proxy.

The property is longer required when using the new development server.

Open the `Properties/launchSettings.json` file of the startup project. Remove the `inspectUri` property in each launch profile of the file's `profiles` node:

```diff
- "inspectUri": "..."
```

For more information, see [[Blazor] Replace DevServer with BlazorGateway for standalone WASM apps (`dotnet/aspnetcore` #65982)](https://github.com/dotnet/aspnetcore/pull/65982) (Please don't comment on closed issues and PRs).

### Server-triggered circuit pause

*This feature applies to server-side Blazor apps.*

Blazor already supports graceful circuit pause and resume with [`Blazor.pauseCircuit()` and `Blazor.resumeCircuit()`](xref:blazor/state-management/server#pause-and-resume-circuits). .NET 11 introduces a symmetric server-side pause and resume capability, where the server can request that connected clients begin the graceful circuit-pause flow.

`Circuit.RequestCircuitPauseAsync(CancellationToken)` is used to request that the connected client begin the graceful circuit-pause flow. The `CancellationToken` cancels the request before it is accepted by the framework. The method returns `true` if the request was accepted and the client was asked to begin pausing.

This feature is useful in the following scenarios:

* Planned shutdowns and deployments.
* Instance draining.
* App maintenance windows.

For more information and an implementation example for server restarts, see <xref:blazor/state-management/server?view=aspnetcore-11.0#server-triggered-circuit-pause>.

### Smaller Blazor WebAssembly publish output

Two trimming changes shrink published Blazor WebAssembly apps that don't use [OpenTelemetry (OTEL)](https://opentelemetry.io/) or Hot Reload:

* The `ComponentsMetrics` and `ComponentsActivitySource` types are now gated behind a `[FeatureSwitchDefinition]` attribute, so the trimmer can drop the metrics and tracing call paths from `Renderer` and friends when `System.Diagnostics.Metrics.Meter.IsSupported` is `false` (the default for trimmed apps) [[browser][wasm] Implement IL trimming for OTEL (`dotnet/aspnetcore` #65901)](https://github.com/dotnet/aspnetcore/pull/65901) (Please don't comment on closed issues and PRs).
* `HotReloadManager` now exposes a feature-switched `IsSupported` property tied to `System.Reflection.Metadata.MetadataUpdater.IsSupported`, so the trimmer can eliminate hot-reload caches and metadata-update handler registrations across the renderer when published [[blazor][wasm] Fix hot reload IL trimming (`dotnet/aspnetcore` #65903)](https://github.com/dotnet/aspnetcore/pull/65903) (Please don't comment on closed issues and PRs).

Apps that use OTEL or Hot Reload aren't affected by the preceding updates.

### `QuickGrid` improvements

The [`QuickGrid` component](xref:Microsoft.AspNetCore.Components.QuickGrid) receives several new features in .NET 11.

For more information on the following features, see <xref:blazor/components/quickgrid?view=aspnetcore-11.0>.

#### Pagination modes

Prior to the release of .NET 11, pagination and sort state is managed in memory inside the `QuickGrid` component without changing the URL, called *inner-state navigation*. An interactive render mode is required.

With the release of .NET 11, `QuickGrid` supports *URL-based navigation*.

Pagination and sort state is persisted in the URL query string. When users paginate or sort, the URL updates (example: `?page=2&sort=Name&order=asc`). This enables link sharing, browser back/forward, and static SSR without interactivity.

Sortable column headers and paginator controls render as `<a>` elements with `href` attributes. The `StaticHtmlRenderer` renders these anchors. On each request, the server reads the query string to determine current page and sort state&mdash;no JavaScript runtime required.

Query string parameters:

* `page`: One-based page number. The first page omits the parameter for clean URLs.
* `sort`: Column title for sorting the grid.
* `order`: Ascending (`asc`) or descending (`desc`).

The `sort` column is identified by the column's `Title` property. Columns without a `Title` render a non-clickable `<div>` header.

`QuickGrid` reads the URL on initialization and subscribes to `NavigationManager.LocationChanged`, so browser back/forward and direct URL entry work. When sort parameters are removed from the URL, it falls back to the default sort column/direction.

Disabled paginator links use `aria-disabled="true"` and `pointer-events: none` instead of the HTML `disabled` attribute, which doesn't exist on `<a>` elements.

#### Multiple grids on the same page

Multiple `QuickGrid` components on the same page require unique `QueryParameterNamePrefix` values to avoid query string conflicts. The default prefix is an empty string, producing parameters named `page`, `sort`, `order`. For example, setting the prefix to "`cities`" produces `cities_page`, `cities_sort`, and `cities_order`.

Each `QuickGrid` must have its own `PaginationState` instance. Multiple grids must not share a `PaginationState` if they have different prefixes&mdash;the last grid to render overwrites the query parameter name on the shared state, causing the `Paginator` to read from the wrong parameter.

In releases prior to .NET 11, the following `QuickGrid` components worked implicitly:

```razor
<QuickGrid ... Pagination="@pagination1">
    ...
</QuickGrid>

<QuickGrid ... Pagination="@pagination2">
    ...
</QuickGrid>
```

With the release of .NET 11, the following `QuickGrid` components require a unique `QueryParameterNamePrefix`. The first `QuickGrid` uses the default empty string prefix, while the second one sets `cities` as the prefix:

```razor
<QuickGrid ... Pagination="@pagination1">
    ...
</QuickGrid>

<QuickGrid ... Pagination="@pagination2" QueryParameterNamePrefix="cities">
    ...
</QuickGrid>
```

Example query string for the preceding `QuickGrid` components:

```
?page=2&sort=Name&order=asc&cities_page=3&cities_sort=Country&cities_order=desc
```

#### Sort by column

Add `Sortable="true"` to a `PropertyColumn`. With URL-based navigation, selecting a header navigates to a URL with updated `sort` and `order` parameters. With inner-state navigation, selecting a header triggers `@onclick`, which calls `SortByColumnAsync`. In both cases, `SortByColumnAsync` navigates via `NavigationManager.NavigateTo(GetSortQueryStringUrl(...))`, so the URL always reflects the sort state.

#### Title-based sort identification

Sort state in the URL uses the column's `Title` property as the identifier. The `sort` query parameter is set to `column.Title` (example for column title `Name`: `?sort=Name&order=asc`). On a URL change, `QuickGrid` matches the `sort` value back to a column by executing `_columns.FirstOrDefault(c => c.Title == sort.ColumnTitle)`. If no column title matches, the sort is ignored and the grid falls back to its default sort.

Renaming a column's `Title` is a URL-breaking change. Any bookmarked or shared URLs containing the old title in the `sort` parameter stop matching, and the grid silently falls back to the default sort instead of sorting by the intended column. For `PropertyColumn`, the `Title` defaults to the property name (example: `Property="@(p => p.FirstName)"` produces `Title="First Name"`), so renaming the property or explicitly changing the `Title` parameter both break existing URLs.

#### Paginator

`Paginator` injects `NavigationManager`, subscribes to `LocationChanged`, and reads the page index from the query string on every location change. `GoToPageAsync` navigates to the target URL rather than directly mutating `PaginationState`. State is updated through the `LocationChanged` callback flow.

`GetPageUrl` returns a URL with the one-based page number. Page index 0 (page 1) omits the query parameter entirely.

#### CSS breaking change

When URL-based navigation is enabled, selectors targeting `button.col-title` must also target `a.col-title`, and `nav button`/`nav button:disabled` require `nav a`/`nav a[aria-disabled="true"]`. The built-in QuickGrid stylesheet provides both by default.

#### How to disable URL-based navigation

To disable URL-based navigation, set the `AppContext` switch for the feature to `false`:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Components.QuickGrid.EnableUrlBasedQuickGridNavigationAndSorting",
    false);
```

This restores `<button>` elements with `@onclick` handlers. An interactive render mode is required.

The switch only controls the rendered HTML element (`<a>` versus `<button>`). Even when disabled, `QuickGrid` still reads and writes state to the URL query string internally. `SortByColumnAsync` and `Paginator.GoToPageAsync` navigate via `NavigationManager.NavigateTo` regardless of the flag.

#### Row click event (`OnRowClick`)

The `QuickGrid` component now supports row click events through the new <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.OnRowClick%2A> parameter. When set, the grid automatically applies appropriate styling (cursor pointer) and invokes the callback with the clicked item:

```razor
@using Microsoft.AspNetCore.Components.QuickGrid
@inject NavigationManager NavigationManager

<QuickGrid Items="@people.AsQueryable()" 
    OnRowClick="@((Person args) => HandleRowClick(args))">
    <PropertyColumn Property="@(p => p.Name)" />
    <PropertyColumn Property="@(p => p.Email)" />
</QuickGrid>

@code {
    private List<Person> people = new()
    {
        new(1, "Alice Smith", "alice@example.com", "Engineering"),
        new(2, "Bob Johnson", "bob@example.com", "Marketing"),
        new(3, "Carol Williams", "carol@example.com", "Engineering"),
    };

    private void HandleRowClick(Person person)
    {
        NavigationManager.NavigateTo($"/person/{person.Id}");
    }

    private record Person(int Id, string Name, string Email, string Department);
}
```

The feature includes built-in CSS styling that applies a pointer cursor to clickable rows through the row-clickable CSS class, providing clear visual feedback to users.

### Client-side prerendering in a Blazor Web App preserves the server's culture

By default, client-side prerendering on the server (`.Client` project in a Blazor Web App) persists the server's <xref:System.Globalization.CultureInfo.CurrentCulture> and <xref:System.Globalization.CultureInfo.CurrentUICulture> into component state and applies them on the client before satellite assemblies load.

Apps that require the client to choose a culture independently of the server can opt out with `WebAssemblyComponentsOptions.UseCultureFromServer` in the Blazor Web App's `Program` file:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents(options =>
    {
        options.UseCultureFromServer = false;
    });
```

### Persist session data between HTTP requests during static server-side rendering (static SSR)

Session data persistence reads and writes cookie-based HTTP session values during static server-side rendering (static SSR), which is useful for scenarios such as shopping cart IDs or multi-step form progress. Unlike [temporary data persistence (`ITempData`)](#persist-temporary-data-between-http-requests-during-static-server-side-rendering-static-ssr), session values aren't cleared after reading. Values persist across multiple requests for the session lifetime.

Session storage configuration requires adding services by calling `AddSession` and request pipeline configuration with `UseSession`:

```csharp
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddRazorComponents();

var app = builder.Build();

app.UseSession();
```

When supplied to a parameter, use the `[SupplyParameterFromSession]` attribute without or with a key (string):

```csharp
[SupplyParameterFromSession]
public string? Message { get; set; }

[SupplyParameterFromSession(Name = "flash_message")]
public string? FlashMessage { get; set; }
```

For more information, see <xref:blazor/state-management/server?view=aspnetcore-11.0#session-data-persistence>.

### `GetUriWithHash` extension method

A new `GetUriWithHash` extension method permits `NavigationManager` to easily construct URIs with hash fragments. This helper method provides an efficient, zero-allocation way to append hash fragments to the current URI. The following example demonstrates two use cases:

* Inline call that jumps to Section 1 (`id="section-1"`) of the rendered page.
* Method call that receives a section Id (`sectionId`) and navigates to the section of the page.

```razor
@inject NavigationManager Navigation

<a href="@Navigation.GetUriWithHash("section-1")">
    Jump to Section 1
</a>

@code {
    private void NavigateToSection(string sectionId)
    {
        var uri = Navigation.GetUriWithHash(sectionId);
        Navigation.NavigateTo(uri);
    }
}
```

The method uses `string.Create` for optimal performance and works correctly with non-root base URIs (for example, when using `<base href="/app/">`).

### `EnvironmentBoundary` component

Blazor now includes a built-in `EnvironmentBoundary` component for conditional rendering based on the hosting environment. This component provides a consistent way to render content based on the current environment across both server-side and client-side hosting models.

The `EnvironmentBoundary` component accepts `Include` and `Exclude` parameters for specifying environment names. The component performs case-insensitive matching and follows the same semantics as MVC's `EnvironmentTagHelper`.

```razor
@using Microsoft.AspNetCore.Components.Web

<EnvironmentBoundary Include="Development">
    <div class="alert alert-warning">
        Debug mode enabled
    </div>
</EnvironmentBoundary>

<EnvironmentBoundary Include="Development,Staging">
    <p>Pre-production environment</p>
</EnvironmentBoundary>

<EnvironmentBoundary Exclude="Production">
    <p>@DateTime.Now</p>
</EnvironmentBoundary>
```

### MathML namespace support

Blazor now supports MathML elements in interactive rendering. MathML elements, such as `<math>`, `<mrow>`, `<mi>`, and `<mn>`, are created with the correct namespace (http://www.w3.org/1998/Math/MathML) using `document.createElementNS()`, similar to how SVG elements are handled:

```html
<math>
    <mrow>
        <mi>x</mi>
        <mo>=</mo>
        <mfrac>
            <mrow>
                <mo>−</mo>
                <mi>b</mi>
                <mo>±</mo>
                <msqrt>
                    <mrow>
                        <msup><mi>b</mi><mn>2</mn></msup>
                        <mo>−</mo>
                        <mn>4</mn>
                        <mi>a</mi>
                        <mi>c</mi>
                    </mrow>
                </msqrt>
            </mrow>
            <mrow>
                <mn>2</mn>
                <mi>a</mi>
            </mrow>
        </mfrac>
    </mrow>
</math>
```

This fix ensures that MathML content renders correctly in browsers when added dynamically through Blazor's renderer, resolving issues where MathML elements were previously created as regular HTML elements without the proper namespace.

### `InvokeVoidAsync()` analyzer

A new Blazor analyzer (BL0010) has been added that recommends using `InvokeVoidAsync` instead of `InvokeAsync<object>` when calling JavaScript functions that don't return values. This analyzer helps developers write more efficient JSInterop code.

**Problematic code:**

```csharp
// ⚠️ BL0010: Use InvokeVoidAsync for JavaScript functions that don't return a value
await JSRuntime.InvokeAsync<object>("console.log", "Hello");
```

**Recommended code:**

```csharp
// ✅ Correct: Use InvokeVoidAsync
await JSRuntime.InvokeVoidAsync("console.log", "Hello");
```

The analyzer helps catch performance issues where `InvokeAsync` is unnecessarily used with `object` or ignored return values, guiding developers toward the more appropriate `InvokeVoidAsync` method.

### `IComponentPropertyActivator`

Blazor now provides `IComponentPropertyActivator` for customizing how `[Inject]` properties are populated on components. This enables advanced scenarios such as:

* Providing additional context for property resolution.
* Support for custom DI containers that need to intercept property injection.
* Advanced scenarios requiring property injection customization.

```csharp
public interface IComponentPropertyActivator
{
    Action<IServiceProvider, IComponent> GetActivator(
        [DynamicallyAccessedMembers(Component)] Type componentType);
}
```

The default implementation caches activators per component type, supports keyed services via `[Inject(Key = "...")]`, integrates with Hot Reload for cache invalidation, and includes proper trimming annotations for AOT compatibility.

### SignalR `ConfigureConnection` for Interactive Server components

Blazor now provides access to configure the underlying SignalR connection options when using Interactive Server components through the new `ConfigureConnection` property on `ServerComponentsEndpointOptions`. This enables configuration of `HttpConnectionDispatcherOptions` properties that were previously only accessible through workarounds.

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(options =>
    {
        options.ConfigureConnection = dispatcherOptions =>
        {
            dispatcherOptions.CloseOnAuthenticationExpiration = true;
            dispatcherOptions.AllowStatefulReconnects = true;
            dispatcherOptions.ApplicationMaxBufferSize = 1024 * 1024;
        };
    });
```

This provides a clean, type-safe API for configuring SignalR connection settings without needing to inspect endpoint metadata.

### `IHostedService` support in Blazor WebAssembly

Blazor WebAssembly now supports `IHostedService` for running background services in the browser. This brings feature parity with Blazor Server and enables scenarios like periodic data refresh, real-time updates, and background processing.

```csharp
public class DataRefreshService : IHostedService
{
    private Timer? _timer;
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(RefreshData, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        return Task.CompletedTask;
    }

    private void RefreshData(object? state)
    {
        // Refresh data periodically
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Dispose();
        return Task.CompletedTask;
    }
}

// Registration
builder.Services.AddHostedService<DataRefreshService>();
```

Hosted services are started when the app starts and stopped when it shuts down, providing a clean lifecycle for background operations in Blazor WebAssembly apps.

### Environment variables in Blazor WebAssembly configuration

Blazor WebAssembly applications can now access environment variables through `IConfiguration`. This enables runtime configuration without rebuilding the application, making it easier to deploy the same build to different environments.

In the following example, the `API_ENDPOINT` and `ENABLE_FEATURE_X` environment variables are automatically included in configuration:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

var apiEndpoint = builder.Configuration["API_ENDPOINT"];
var featureFlag = builder.Configuration["ENABLE_FEATURE_X"];
```

Environment variables are loaded into the configuration system alongside other configuration sources, such as app settings (`appsettings.json`), providing a unified way to access configuration values regardless of their source.

### Blazor WebAssembly component metrics and tracing

Blazor WebAssembly apps now provide component specific metrics and tracing when support for metrics has been enabled in the runtime.

### Enable container support in Blazor Web App template

The Blazor Web App project template now supports the **Enable container support** option in Visual Studio. This makes it easier to containerize Blazor Web Apps and deploy them to container orchestration platforms, such as Kubernetes or Azure Container Apps.

### Static SSR supports client-side validation

Blazor static server-side rendering (static SSR) forms now get instant, in-browser validation feedback without a server round-trip, matching the experience provided by interactive Blazor apps and MVC apps with unobtrusive validation. The .NET model remains the single source of truth for validation rules. The server renders metadata for the validation rules which are then enforced by the Blazor JS code on the client-side.

The feature is enabled by default for all static SSR forms that include the `DataAnnotationsValidator` component. Both enhanced and non-enhanced forms are supported.

Complete feature coverage is available in <xref:blazor/forms/validation?view=aspnetcore-11.0#client-side-validation-in-static-ssr-forms>.

For more information, see the following resources:

* [Add .NET support for client-side validation in Blazor SSR (`dotnet/aspnetcore` #66441)](https://github.com/dotnet/aspnetcore/pull/66441)
* [Add JS library for client-side validation in Blazor SSR (`dotnet/aspnetcore` #66420)](https://github.com/dotnet/aspnetcore/pull/66420)

Please don't comment on closed issues and PRs. If you have feedback on this feature, please open a new issue on the `dotnet/aspnetcore` GitHub repository.

### Asynchronous form validation support

Blazor forms receive support for async validation rules, such as database lookups or remote API calls. In any rendering mode, `EditForm` submit validation now properly awaits async validators end-to-end. In interactive modes, validator components can register per-field async tasks via `EditContext.AddValidationTask`. The framework tracks them, cancels superseded tasks, and exposes progress status via `IsValidationPending(field)` and `IsValidationFaulted(field)`.

<!-- UPDATE 11.0 - We'll adjust the following remark for future
                   preview releases. -->

While Preview 5 ships the building blocks for Blazor forms, the full built-in async validation experience will be enabled when the new asynchronous `DataAnnotations` APIs are released in a later .NET preview. These APIs will be fully supported by the existing `DataAnnotationsValidator` component.

```razor
<EditForm EditContext="editContext" OnSubmit="HandleSubmit">
    <InputText @bind-Value="model.Username" />
    @if (editContext.IsValidationPending(() => model.Username))
    {
        <span>Checking availability...</span>
    }
    <ValidationMessage For="() => model.Username" />
    <button type="submit">Register</button>
</EditForm>

@code {
    [Inject] public UserService Users { get; set; } = default!;

    private readonly RegistrationModel model = new();
    private EditContext editContext = default!;
    private ValidationMessageStore messages = default!;

    protected override void OnInitialized()
    {
        editContext = new EditContext(model);
        messages = new ValidationMessageStore(editContext);
        editContext.OnFieldChanged += (_, e) =>
        {
            if (e.FieldIdentifier.FieldName == nameof(model.Username))
            {
                var cts = new CancellationTokenSource();
                editContext.AddValidationTask(e.FieldIdentifier,
                    CheckAsync(e.FieldIdentifier, model.Username, cts.Token), cts);
            }
        };
    }

    private async Task CheckAsync(FieldIdentifier field, string value, CancellationToken ct)
    {
        messages.Clear(field);
        if (await Users.IsUsernameTakenAsync(value, ct))
        {
            messages.Add(field, "Username is taken.");
        }
        editContext.NotifyValidationStateChanged();
    }

    private async Task HandleSubmit() => await editContext.ValidateAsync();
}
```

Complete feature coverage is available in <xref:blazor/forms/validation?view=aspnetcore-11.0#asynchronous-validation>.

For more information, see [Add built-in support for async form validation in Blazor (`dotnet/aspnetcore` #66526)](https://github.com/dotnet/aspnetcore/pull/66526).

Please don't comment on closed issues and PRs. If you have feedback on this feature, please open a new issue on the `dotnet/aspnetcore` GitHub repository.

## Blazor and Minimal APIs support error localization

Validation of Blazor forms and Minimal API endpoints receives first-class support for localization of error messages and property names. By default, localization uses language-specific RESX files deployed as part of the assembly.

```csharp
builder.Services.AddValidation()
    .AddValidationLocalization<ValidationMessages>();
    // Resolves to ValidationMessages.en.resx, ValidationMessages.es.resx, ...
```

```csharp
[ValidatableType]
public class ContactModel
{
    // Values of ErrorMessage are used as localization keys.
    [Required(ErrorMessage = "RequiredError")]
    [EmailAddress(ErrorMessage = "EmailError")]
    [Display(Name = "ContactEmail")]
    public string? Email { get; set; }
}
```

Apps can also register custom `IStringLocalizerFactory` implementations to read the localized strings from other sources, such as databases or JSON files. A user registered type takes precedence over the default RESX localization.

```csharp
builder.Services.AddValidation()
    .AddValidationLocalization();
builder.Services.AddSingleton<IStringLocalizerFactory, DbStringLocalizerFactory>();
```

Apps can also configure a programmatic strategy for localization, removing the need to specify localization keys on every validation attribute:

```csharp
builder.Services.AddValidation()
    .AddValidationLocalization<ValidationMessages>(options =>
    {
        options.ErrorMessageKeyProvider = ctx =>
            ctx.Attribute.ErrorMessage ?? $"{ctx.Attribute.GetType().Name}_Error";
    });
```

```csharp
[ValidatableType]
public class ContactModel
{
    // Looks-up localized string for 'RequiredAttribute_Error' automatically.
    [Required]
    public string? Username { get; set; }
}
```

Complete feature coverage is available in the following articles:

* <xref:fundamentals/localization/make-content-localizable?view=aspnetcore-11.0#dataannotations-localization-in-minimal-apis-and-blazor>
* <xref:fundamentals/minimal-apis?view=aspnetcore-11.0#localizing-validation-messages>

For more information, see [Add localization support to Microsoft.Extensions.Validation (`dotnet/aspnetcore` #66646)](https://github.com/dotnet/aspnetcore/pull/66646).

Please don't comment on closed issues and PRs. If you have feedback on this feature, please open a new issue on the `dotnet/aspnetcore` GitHub repository.
