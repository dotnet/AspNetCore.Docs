### New `DisplayName` component and support for `[Display]` and `[DisplayName]` attributes

The <xref:Microsoft.AspNetCore.Components.Forms.DisplayName`1> component can be used to display property names from metadata attributes.

Use the [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute) on the model class property:

```csharp
[Required, Display(Name = "Production Date")]
public DateTime ProductionDate { get; set; }
```

The [`[DisplayName]` attribute](xref:System.ComponentModel.DisplayNameAttribute) is also supported:

```csharp
[Required, DisplayName("Production Date")]
public DateTime ProductionDate { get; set; }
```

The `[Display]` attribute is recommended, which makes additional properties available. The `[Display]` attribute also enables assigning a resource type for localization. When both attributes are present, `[Display]` takes precedence over the `[DisplayName]` attribute. If neither attribute is present, the component falls back to the property name.

Use the <xref:Microsoft.AspNetCore.Components.Forms.DisplayName`1> component in labels or table headers:

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

For more information, see [ASP.NET Core Blazor startup](../../../blazor/fundamentals/startup.md?view=aspnetcore-11.0&preserve-view=true#startup-process-and-configuration).

### New `BasePath` component

Blazor Web Apps can use the new `BasePath` component (`<BasePath />`) to render the app's app base path (`<base href>`) HTML tag automatically. For more information, see [ASP.NET Core Blazor app base path](../../../blazor/host-and-deploy/app-base-path.md?view=aspnetcore-11.0&preserve-view=true).

### Inline JS event handler removed from the `NavMenu` component

The inline JS event handler that toggles the display of navigation links is no longer present in the `NavMenu` component of the Blazor Web App project template. Apps generated from the project template now use a [collocated JS module](../../../blazor/javascript-interoperability/location-of-javascript.md?view=aspnetcore-11.0&preserve-view=true#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) approach to show or hide the navigation bar on the rendered page. The new approach improves [Content Security Policy (CSP) compliance](../../../blazor/security/content-security-policy.md?view=aspnetcore-11.0&preserve-view=true) because it doesn't require the CSP to include an unsafe hash for the inline JS.

To migrate an existing app to .NET 11, including adopting the new JS module approach for the navigation bar toggler, see [Migrate from ASP.NET Core in .NET 10 to ASP.NET Core in .NET 11](../../../migration/100-to-110.md).

### `NavigateTo` and `NavLink` support for relative navigation

The new `RelativeToCurrentUri` parameter (default: `false`) for <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo*?displayProperty=nameWithType> and the [`NavLink` component](../../../blazor/fundamentals/navigation.md?view=aspnetcore-11.0&preserve-view=true#navlink-component) allows you to navigate to URIs relative to the current page path rather than the app's base URI.

Consider the following nested endpoints:

* `/docs`
  * `/getting-started`
    * `/installation`
    * `/configuration`

When the browser's URI is `/docs/getting-started/installation` and you want to navigate the user to `/docs/getting-started/configuration`, `NavigateTo("/configuration")` redirects to `/configuration` at the app's root instead of the relative path at `/docs/getting-started/configuration`. Set the `RelativeToCurrentUri` with <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo*> or the [`NavLink` component](../../../blazor/fundamentals/navigation.md?view=aspnetcore-11.0&preserve-view=true#navlink-component) for the desired navigation:

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

TempData is available when <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents*> is called in the app's `Program` file and is provided as a cascading value with the [`[CascadingParameter]` attribute](../../../blazor/components/cascading-values-and-parameters.md#cascadingparameter-attribute).

```csharp
[CascadingParameter]
public ITempData? TempData { get; set; }
```

When supplied to a parameter for simple read/write of a single value, use the `[SupplyParameterFromTempData]` attribute:

```csharp
[SupplyParameterFromTempData]
public string? Message { get; set; }
```

For more information, see [ASP.NET Core Blazor server-side state management](../../../blazor/state-management/server.md?view=aspnetcore-11.0&preserve-view=true#temporary-data-persistence).

### New Blazor Web Worker template (`blazorwebworker`)

The .NET Web Worker project template, which contains a Web Worker client for offloading long-running work to a background thread, has been renamed to the **Blazor Web Worker** project template (`blazorwebworker`). The name change makes it clearer that the template is part of the Blazor stack for use in Blazor WebAssembly and Blazor Web apps (for client-side rendering, CSR).

Two often-requested capabilities have been added to the generated `WebWorkerClient`:

* `InvokeVoidAsync` for fire-and-forget worker calls that don't return a value, mirroring the shape on `IJSRuntime`.
* Cancellation and timeout support on both worker creation and worker invocations, so callers can pass a `CancellationToken` and tear down a stuck worker cleanly.

Existing projects created with the old template continue to work. The rename only affects the template name shown in `dotnet new list` and in Visual Studio's list of **Create a new project** templates.

For more information, see the following resources:

* [ASP.NET Core Blazor with .NET on Web Workers](../../../blazor/blazor-with-dotnet-on-web-workers.md?view=aspnetcore-11.0&preserve-view=true)
* [.NET Web Worker template update to Blazor Web Worker template (`dotnet/aspnetcore` #66070)](https://github.com/dotnet/aspnetcore/pull/66070) (Please don't comment on closed issues and PRs.)

### Virtualization enhancements

* The <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize`1> component no longer assumes every item has the same height. Previously, the component disabled the browser's native scroll anchoring (to avoid an infinite rendering loop), which meant any height change above the viewport&mdash;item expansion, data updates, lazy-loaded content&mdash;caused visible items to jump on screen. The `Virtualize` component now adapts to measured item sizes at runtime, which reduces incorrect spacing and scrolling when item heights vary.

  The updates use a hybrid approach: native CSS scroll anchoring on browsers that support it for non-`<table>` layouts with a manual `ResizeObserver`-based scroll-compensation fallback for `<table>` layouts and Safari, where native anchoring miscalculates positions on `<tr>` elements.

  Apps using the `Virtualize` component receive the benefits of these updates automatically. No developer API changes are required.

  These updates include an update to the default value of <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize`1.OverscanCount?displayProperty=nameWithType>, which was `3` in .NET 10 or earlier and now changes to `15` in .NET 11 or later. The change in default value increases the precision of average item height calculations.

  For more information, see the following resources:

  * [*Item size* section](../../../blazor/components/virtualization.md?view=aspnetcore-11.0&preserve-view=true#item-size) and [*Overscan count* section](../../../blazor/components/virtualization.md?view=aspnetcore-11.0&preserve-view=true#overscan-count) of the *Virtualization* article.
  * [[Virtualization] Visible content does not shift when in-DOM items above the viewport change height (`dotnet/aspnetcore` #65951)](https://github.com/dotnet/aspnetcore/pull/65951) (Please don't comment on closed issues and PRs).

* Use the new `AnchorMode` parameter to control how the viewport behaves at list edges when items are dynamically added:

  * `None`: No edge pinning. The viewport stays at the current scroll position regardless of item changes.
  * `Start` (default): Pins the viewport to the beginning of the list. For example, this pinning behavior is useful for a news feed user experience.
  * `End`: Pins the viewport to the end of the list. For example, this pinning behavior is useful for a chat or logging user experience.

  In the following example, the virtualized content is pinned to the beginning of the list:

  ```razor
  <Virtualize AnchorMode="Start" ...>
      ...
  </Virtualize>
  ```

  For more information, see the following resources:

  * [ASP.NET Core Razor component virtualization](../../../blazor/components/virtualization.md?view=aspnetcore-11.0&preserve-view=true#control-viewport-scroll-position-behavior-when-items-are-dynamically-added)
  * [[release/11.0-preview4] Virtualization AnchorMode with variable-height support (`dotnet/aspnetcore` #66521)](https://github.com/dotnet/aspnetcore/pull/66521) (Please don't comment on closed issues and PRs.)

* Content Security Policy (CSP) compliance

  The `Virtualize` component renders dynamic inline `style` attributes on its spacer and placeholder elements (for example, `style="height: 478896px; flex-shrink: 0;"`) because spacer heights are calculated at runtime based on scroll position, item count, and average item size, which change on every scroll interaction. These are blocked by a Content Security Policy (CSP) when `style-src 'self'` is set, breaking virtualization entirely for apps with strict CSP policies.

  Now, CSP violations are avoided because `Virtualize` components:

  * Render calculated spacer and placeholder heights as numeric values in `data-blazor-virtualize-reserved-height` attributes.
  * When required, render the trailing spacer's vertical offset as a numeric value in a `data-blazor-virtualize-loop-breaker-transform` attribute to hide the spacer.

### New service defaults library project template for Blazor WebAssembly apps

The `blazor-wasm-servicedefaults` project template creates a service defaults library for Blazor WebAssembly apps with [Aspire](/dotnet/aspire/get-started/aspire-overview) integration. For more information, see [Tooling for ASP.NET Core Blazor](../../../blazor/tooling.md?view=aspnetcore-11.0&preserve-view=true#service-defaults-library-for-blazor-webassembly-apps).

### New development server for Blazor WebAssembly apps

[`Microsoft.AspNetCore.Components.Gateway`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Gateway) is a lightweight ASP.NET Core host that replaces [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer) for serving standalone Blazor WebAssembly apps during development and production.

To adopt the Gateway in an existing standalone Blazor WebAssembly app, reference the `Microsoft.AspNetCore.Components.Gateway` package in the app's project file.

[!INCLUDE[](~/includes/package-reference.md)]

Custom routing code and middleware aren't required by the app. Fallback endpoints come from the static web assets manifest the SDK emits when the `StaticWebAssetSpaFallbackEnabled` property is set in the app's project file, which is present by default in standalone Blazor WebAssembly apps created from the project template:

```xml
<StaticWebAssetSpaFallbackEnabled>true</StaticWebAssetSpaFallbackEnabled>
```

Prior to the release of .NET 11, the `inspectUri` property of the `Properties/launchSettings.json` file:

* Enables the IDE to detect that the app is a Blazor app.
* Instructs the script debugging infrastructure to connect to the browser through Blazor's debugging proxy.

The property is no longer required when using the new development server.

Open the `Properties/launchSettings.json` file of the startup project. Remove the `inspectUri` property in each launch profile of the file's `profiles` node:

```diff
- "inspectUri": "..."
```

For more information, see [[Blazor] Replace DevServer with BlazorGateway for standalone WASM apps (`dotnet/aspnetcore` #65982)](https://github.com/dotnet/aspnetcore/pull/65982) (Please don't comment on closed issues and PRs).

### Server-triggered circuit pause

*This feature applies to server-side Blazor apps.*

Blazor already supports graceful circuit pause and resume with [`Blazor.pauseCircuit()` and `Blazor.resumeCircuit()`](../../../blazor/state-management/server.md#pause-and-resume-circuits). .NET 11 introduces a symmetric server-side pause and resume capability, where the server can request that connected clients begin the graceful circuit-pause flow.

`Circuit.RequestCircuitPauseAsync(CancellationToken)` is used to request that the connected client begin the graceful circuit-pause flow. The `CancellationToken` cancels the request before it is accepted by the framework. The method returns `true` if the request was accepted and the client was asked to begin pausing.

This feature is useful in the following scenarios:

* Planned shutdowns and deployments.
* Instance draining.
* App maintenance windows.

For more information and an implementation example for server restarts, see [ASP.NET Core Blazor server-side state management](../../../blazor/state-management/server.md?view=aspnetcore-11.0&preserve-view=true#server-triggered-circuit-pause).

### Smaller Blazor WebAssembly publish output

Two trimming changes shrink published Blazor WebAssembly apps that don't use [OpenTelemetry (OTEL)](https://opentelemetry.io/) or Hot Reload:

* The `ComponentsMetrics` and `ComponentsActivitySource` types are now gated behind a `[FeatureSwitchDefinition]` attribute, so the trimmer can drop the metrics and tracing call paths from `Renderer` and friends when `System.Diagnostics.Metrics.Meter.IsSupported` is `false` (the default for trimmed apps) [[browser][wasm] Implement IL trimming for OTEL (`dotnet/aspnetcore` #65901)](https://github.com/dotnet/aspnetcore/pull/65901) (Please don't comment on closed issues and PRs).
* `HotReloadManager` now exposes a feature-switched `IsSupported` property tied to `System.Reflection.Metadata.MetadataUpdater.IsSupported`, so the trimmer can eliminate hot-reload caches and metadata-update handler registrations across the renderer when published [[blazor][wasm] Fix hot reload IL trimming (`dotnet/aspnetcore` #65903)](https://github.com/dotnet/aspnetcore/pull/65903) (Please don't comment on closed issues and PRs).

Apps that use OTEL or Hot Reload aren't affected by the preceding updates.

### `QuickGrid` improvements

The [`QuickGrid` component](xref:Microsoft.AspNetCore.Components.QuickGrid) receives several new features in .NET 11.

For more information on the following features, see [ASP.NET Core Blazor \`QuickGrid\` component](../../../blazor/components/quickgrid.md?view=aspnetcore-11.0&preserve-view=true).

#### Pagination modes

Prior to the release of .NET 11, pagination and sort state is managed in memory inside the `QuickGrid` component without changing the URL, called *inner-state navigation*. An interactive render mode is required.

With the release of .NET 11, `QuickGrid` supports *URL-based navigation*.

Pagination and sort state is persisted in the URL query string. When users paginate or sort, the URL updates (example: `?page=2&sort=Name&direction=asc`). This enables link sharing, browser back/forward, and static SSR without interactivity.

Sortable column headers and paginator controls render as `<a>` elements with `href` attributes. The `StaticHtmlRenderer` renders these anchors. On each request, the server reads the query string to determine current page and sort state&mdash;no JavaScript runtime required.

Query string parameters:

* `page`: One-based page number. The first page omits the parameter for clean URLs.
* `sort`: Column title for sorting the grid.
* `direction`: Ascending (`asc`) or descending (`desc`).

The `sort` column is identified by the column's `Title` property. Columns without a `Title` render a non-clickable `<div>` header.

`QuickGrid` reads the URL on initialization and subscribes to `NavigationManager.LocationChanged`, so browser back/forward and direct URL entry work. When sort parameters are removed from the URL, it falls back to the default sort column/direction.

Disabled paginator links use `aria-disabled="true"` and `pointer-events: none` instead of the HTML `disabled` attribute, which doesn't exist on `<a>` elements.

#### Query parameter names

The new `QueryParameterNameOptions` parameter of the `QuickGrid` component controls the names of the query string parameters that persist grid state in the URL. The `QueryParameterNameOptions` class has three settable properties:

* `Sort`: Name of the query string parameter that holds the sort column. The default value is `sort`.
* `Direction`: Name of the query string parameter that holds the sort direction. The default value is `direction`.
* `Page`: Name of the query string parameter that holds the page number. The default value is `page`.

The constructor takes an optional prefix argument that's prepended to all three default names. The prefix must include any separator character that you want to appear between the prefix and the name. In the following example, the query string parameters are named `products_sort`, `products_direction`, and `products_page`:

```razor
@using Microsoft.AspNetCore.Components.QuickGrid

<QuickGrid ...
    QueryParameterNameOptions="@(new QueryParameterNameOptions("products_"))">
    ...
</QuickGrid>
```

To control the names individually, set the properties of the class. Properties set explicitly take precedence over a prefix passed to the constructor, so the two approaches can be combined:

```razor
@using Microsoft.AspNetCore.Components.QuickGrid

<QuickGrid ... QueryParameterNameOptions="@queryParameterNames">
    ...
</QuickGrid>

@code {
    private QueryParameterNameOptions queryParameterNames = new()
    {
        Sort = "orderBy",
        Direction = "orderDir",
        Page = "p"
    };
}
```

#### Multiple grids on the same page

Multiple `QuickGrid` components on the same page require unique query parameter names to avoid query string conflicts. Assign a `QueryParameterNameOptions` parameter to all but one of the grids.

Each `QuickGrid` must have its own `PaginationState` instance. Multiple grids must not share a `PaginationState` if they use different query parameter names&mdash;the last grid to render overwrites the query parameter name on the shared state, causing the `Paginator` to read from the wrong parameter.

In releases prior to .NET 11, the following `QuickGrid` components worked implicitly:

```razor
<QuickGrid ... Pagination="@pagination1">
    ...
</QuickGrid>

<QuickGrid ... Pagination="@pagination2">
    ...
</QuickGrid>
```

With the release of .NET 11, the following `QuickGrid` components require unique query parameter names. The first `QuickGrid` uses the default names, while the second one uses a `cities_` prefix:

```razor
<QuickGrid ... Pagination="@pagination1">
    ...
</QuickGrid>

<QuickGrid ... Pagination="@pagination2"
    QueryParameterNameOptions="@(new QueryParameterNameOptions("cities_"))">
    ...
</QuickGrid>
```

Example query string for the preceding `QuickGrid` components:

```
?page=2&sort=Name&direction=asc&cities_page=3&cities_sort=Population&cities_direction=desc
```

#### Sort by column

Add `Sortable="true"` to a `PropertyColumn`. With URL-based navigation, selecting a header navigates to a URL with updated `sort` and `direction` parameters. With inner-state navigation, selecting a header triggers `@onclick`, which calls `SortByColumnAsync`. In both cases, `SortByColumnAsync` navigates via `NavigationManager.NavigateTo(GetSortQueryStringUrl(...))`, so the URL always reflects the sort state.

#### Title-based sort identification

Sort state in the URL uses the column's `Title` property as the identifier. The `sort` query parameter is set to `column.Title` (example for column title `Name`: `?sort=Name&direction=asc`). On a URL change, `QuickGrid` matches the `sort` value back to a column by executing `_columns.FirstOrDefault(c => c.Title == sort.ColumnTitle)`. If no column title matches, the sort is ignored and the grid falls back to its default sort.

Renaming a column's `Title` is a URL-breaking change. Any bookmarked or shared URLs containing the old title in the `sort` parameter stop matching, and the grid silently falls back to the default sort instead of sorting by the intended column. For `PropertyColumn`, the `Title` defaults to the property name (example: `Property="@(p => p.FirstName)"` produces `Title="First Name"`), so renaming the property or explicitly changing the `Title` parameter both break existing URLs.

#### Paginator

`Paginator` injects `NavigationManager`, subscribes to `LocationChanged`, and reads the page index from the query string on every location change. `GoToPageAsync` navigates to the target URL rather than directly mutating `PaginationState`. State is updated through the `LocationChanged` callback flow.

`GetPageUrl` returns a URL with the one-based page number. Page index 0 (page 1) omits the query parameter entirely.

<!-- UPDATE 11.0 - Hold for December servicing release

The `Paginator` component now supports passing custom attributes to its rendered navigation element (`<nav>`). In the following example, the [`aria-label` attribute](https://developer.mozilla.org/docs/Web/Accessibility/ARIA/Reference/Attributes/aria-label) and value are passed:

```razor
<Paginator State="@pagination" aria-label="Orders page" />
```

-->

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

The `QuickGrid` component now supports row click events through the new <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid`1.OnRowClick> parameter. When set, the grid automatically applies appropriate styling (cursor pointer) and invokes the callback with the clicked item:

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

For more information, see [ASP.NET Core Blazor server-side state management](../../../blazor/state-management/server.md?view=aspnetcore-11.0&preserve-view=true#session-data-persistence).

### `GetUriWithFragment` extension method

A new `GetUriWithFragment` extension method permits `NavigationManager` to easily construct URIs with hash fragments. This helper method provides an efficient, zero-allocation way to append hash fragments to the current URI. The following example demonstrates two use cases:

* Inline call that jumps to Section 1 (`id="section-1"`) of the rendered page.
* Method call that receives a section Id (`sectionId`) and navigates to the section of the page.

```razor
@inject NavigationManager Navigation

<a href="@Navigation.GetUriWithFragment("section-1")">
    Jump to Section 1
</a>

@code {
    private void NavigateToSection(string sectionId)
    {
        var uri = Navigation.GetUriWithFragment(sectionId);
        Navigation.NavigateTo(uri);
    }
}
```

The method uses `string.Create` for optimal performance and works correctly with non-root base URIs (for example, when using `<base href="/app/">`).

### `EnvironmentView` component

Blazor now includes a built-in `EnvironmentView` component for conditional rendering based on the hosting environment. This component provides a consistent way to render content based on the current environment across both server-side and client-side hosting models.

The `EnvironmentView` component accepts `Include` and `Exclude` parameters for specifying environment names. The component performs case-insensitive matching and follows the same semantics as MVC's `EnvironmentTagHelper`.

```razor
@using Microsoft.AspNetCore.Components.Web

<EnvironmentView Include="Development">
    <div class="alert alert-warning">
        Debug mode enabled
    </div>
</EnvironmentView>

<EnvironmentView Include="Development,Staging">
    <p>Pre-production environment</p>
</EnvironmentView>

<EnvironmentView Exclude="Production">
    <p>@DateTime.Now</p>
</EnvironmentView>
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

### Configure Blazor client behavior from the server

<!-- UPDATE 11.0 - We need reference article coverage for this, but we'll wait
                   for the API to completely stabilize at RC2 and possibly
                   for content from the PU to arrive. -->

Blazor apps can now configure client-side startup behavior from the server in C# when mapping Razor components instead of hand-writing `Blazor.start` JavaScript. `WithBrowserOptions` sets options that the server serializes into the rendered page and the Blazor script applies in the browser, across the Server, WebAssembly, and Auto render modes. The options cover the client log level, interactive Server reconnection, whether enhanced navigation preserves the DOM, and a WebAssembly runtime's environment name, culture, and environment variables:

```csharp
app.MapRazorComponents<App>()
    .WithBrowserOptions(options =>
    {
        options.InteractiveServer.ReconnectionDialogId = "reconnect-dialog";
        options.InteractiveServer.ReconnectionMaxRetries = 10;
        options.InteractiveServer.ReconnectionRetryInterval = TimeSpan.FromSeconds(1.5);
        options.InteractiveWebAssembly.EnvironmentVariables["OTEL_EXPORTER_OTLP_ENDPOINT"] =
            "https://localhost:4318";
        options.StaticServer.CircuitInactivityTimeout = TimeSpan.FromSeconds(1.5);
        options.StaticServer.PreserveDom = true;
        options.InteractiveWebAssembly.ApplicationCulture = "en-ca";
        options.InteractiveWebAssembly.EnvironmentName = "Staging";
        options.LogLevel = LogLevel.Warning;
    });
```

You can also set the options in a Razor component with the `ConfigureBrowser` component:

```razor
<ConfigureBrowser Options="RequestBrowserOptions" />

...

@code {
    private BrowserOptions RequestBrowserOptions => new()
    {
        LogLevel = LogLevel.Trace,
        StaticServer = { PreserveDom = true }
    };
}
```

Read the resolved options from `HttpContext` with `GetBrowserOptions()`:

```razor
@BrowserOptions.GetBrowserOptions(HttpContext).LogLevel
```

For more information, see the following resources:

* [API Proposal: BrowserOptions for server-to-client configuration (`dotnet/aspnetcore` #66393)](https://github.com/dotnet/aspnetcore/issues/66393)
* [Reshape BrowserConfiguration API per review (BrowserOptions) while preserving the JS wire format (`dotnet/aspnetcore` #67337)](https://github.com/dotnet/aspnetcore/pull/67337)
* [Reshape BrowserOptions server-to-client configuration API per review (`dotnet/aspnetcore` #67918)](https://github.com/dotnet/aspnetcore/pull/67918)

Please don't comment on closed issues and PRs. Open a new issue to provide feedback on this API.

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

Complete feature coverage is available in [ASP.NET Core Blazor client-side form validation in static SSR](../../../blazor/forms/validation-client-side.md?view=aspnetcore-11.0&preserve-view=true).

For more information, see the following resources:

* [Add .NET support for client-side validation in Blazor SSR (`dotnet/aspnetcore` #66441)](https://github.com/dotnet/aspnetcore/pull/66441)
* [Add JS library for client-side validation in Blazor SSR (`dotnet/aspnetcore` #66420)](https://github.com/dotnet/aspnetcore/pull/66420)

Please don't comment on closed issues and PRs. If you have feedback on this feature, please open a new issue on the `dotnet/aspnetcore` GitHub repository.

### Asynchronous form validation support

Blazor forms receive support for async validation rules, such as database lookups or remote API calls. In any rendering mode, `EditForm` submit validation awaits async validators end-to-end.

The built-in `DataAnnotationsValidator` component runs the asynchronous `DataAnnotations` APIs (`AsyncValidationAttribute` and `IAsyncValidatableObject`), so asynchronous rules declared on the model work without additional configuration.

Validator components register asynchronous work with `ValidationRequestedEventArgs.AddAsyncValidator` for the whole form and `EditContext.RegisterAsyncFieldValidator` for a single field. The framework owns the cancellation token source, cancels superseded validations, and exposes progress with `IsValidationPending(field)` and `IsValidationFaulted(field)`.

```razor
<EditForm EditContext="editContext" OnValidSubmit="HandleSubmit">
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
                editContext.RegisterAsyncFieldValidator(e.FieldIdentifier,
                    token => CheckAsync(e.FieldIdentifier, model.Username, token));
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

    private Task HandleSubmit() => RegisterAsync();
}
```

Complete feature coverage is available in [ASP.NET Core Blazor advanced form validation](../../../blazor/forms/validation-advanced.md?view=aspnetcore-11.0&preserve-view=true#asynchronous-validation).

For more information, see [Add built-in support for async form validation in Blazor (`dotnet/aspnetcore` #66526)](https://github.com/dotnet/aspnetcore/pull/66526).

Please don't comment on closed issues and PRs. If you have feedback on this feature, please open a new issue on the `dotnet/aspnetcore` GitHub repository.

### Fixes to TempData and `[SupplyParameterFromSession]` persistence for streaming SSR

When a page uses session-backed features, where a component has a `[SupplyParameterFromSession]` parameter (which creates a subscription) or the session-storage TempData provider is active, the session cookie (`.AspNetCore.Session`) is now issued before streaming begins, even if no value is ultimately written. Pages that don't use session-backed features are unaffected.

For more information, see [Fix TempData and SupplyParameterFromSession persistence for streaming SSR case (`dotnet/aspnetcore` #66832)](https://github.com/dotnet/aspnetcore/pull/66832). (Please don't comment on closed issues and PRs.)

### Antiforgery middleware (`app.UseAntiforgery()`) optional in Blazor Web Apps

[CSRF protection](../../../security/anti-request-forgery.md#automatic-csrf-protection-in-aspnet-core) is enabled by default via the auto-injected CSRF protection middleware, so an explicit `app.UseAntiforgery()` call in a Blazor Web App is usually unnecessary and should only be added for specific use cases. The call no longer appears in apps created from the Blazor Web App project template.

For more information, see the following resources:

* [Migrate from ASP.NET Core in .NET 10 to ASP.NET Core in .NET 11](../../../migration/100-to-110.md)
* [Blazor server-side rendering defers antiforgery validation to middleware (breaking change announcement)](../../../breaking-changes/11/blazor-server-side-rendering-deferred-cross-site-request-forgery-protection.md)

General coverage for the new automatic CSRF protection in ASP.NET Core:

* [Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core](../../../security/anti-request-forgery.md?view=aspnetcore-11.0&preserve-view=true)
* [ASP.NET Core Blazor forms overview](../../../blazor/forms/index.md?view=aspnetcore-11.0&preserve-view=true#antiforgery-support)
* [ASP.NET Core Blazor authentication and authorization](../../../blazor/security/index.md?view=aspnetcore-11.0&preserve-view=true#antiforgery-support)

### Blazor Virtualize can scroll to an item

The `Virtualize<TItem>` component can now open at a specific item and scroll to any item on demand. Two new public APIs make this possible:

* `InitialItemIndex` positions the list at a given item on the first interactive render, so the list opens at that item without a flash of the first item.
* `ScrollToItemAsync(int itemIndex, CancellationToken cancellationToken = default)` scrolls to an item at any time after the first render and returns a `Task` that completes when the target is aligned to the top of the viewport.

```razor
<Virtualize TItem="Product" Items="products" InitialItemIndex="500" @ref="list">
    <div class="product">@context.Name</div>
</Virtualize>

<button @onclick="GoToTop">Back to top</button>

@code {
    private Virtualize<Product> list = default!;
    private List<Product> products = ProductCatalog.All;

    private async Task GoToTop() => await list.ScrollToItemAsync(0);
}
```

Out-of-range indexes are clamped to the valid range. If a second `ScrollToItemAsync` call starts while one is still in flight, the last call wins. Calling `ScrollToItemAsync` before the first interactive render throws `InvalidOperationException`; use `InitialItemIndex` to set the starting position instead.

For more information, see the following resources:

* [ASP.NET Core Razor component virtualization](../../../blazor/components/virtualization.md#scroll-to-a-specific-item)
* [Add `InitialIndex` (sic&dagger;) parameter and `ScrollToIndexAsync` (sic&dagger;) API to `Virtualize<TItem>` (`dotnet/aspnetcore` #66753)](https://github.com/dotnet/aspnetcore/pull/66753). (Please don't comment on closed issues and PRs. *sic*&dagger;: API naming was changed without updating the title of the PR.)

### Automatic circuit pause on tab inactivity

Auto-pause can pause a circuit when the browser tab becomes hidden, freeing server memory and SignalR connections held by inactive users. It's an opt-in feature provided by the `Microsoft.AspNetCore.Components.Server.AutoPause` package. After adding a package reference, enable the feature by calling `AddAutoPause` when the app's root component is mapped:

```csharp
app.MapRazorComponents<App>()
    .WithBrowserOptions(options => options.AddAutoPause(p => p.HiddenDelay = TimeSpan.FromSeconds(30)));
```

After the tab is hidden for a configurable delay period (default: 2 minutes), the circuit pauses. If the user returns before the delay elapses, the pause doesn't occur.

For more information, see [ASP.NET Core Blazor server-side state management](../../../blazor/state-management/server.md?view=aspnetcore-11.0&preserve-view=true#automatic-circuit-pause-on-tab-inactivity).

### Wider support for `AuthorizationPolicy` and `IAuthorizationRequirementData`

Starting in .NET 11, you can apply <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> attributes to SignalR hubs and hub methods, MVC controllers and actions, and Blazor's [`AuthorizeView`](../../../blazor/security/index.md#authorizeview-component) and [`AuthorizeRouteView`](../../../blazor/security/authentication-state.md?pivots=server#implement-a-custom-authenticationstateprovider) components, not just to endpoints. For apps that target releases earlier than .NET 11, these attributes are only enforced on Minimal API and routed endpoints.

For more information, see [Custom authorization policies with \`IAuthorizationRequirementData\`](../../../security/authorization/custom-authorization-policies-with-iauthorizationrequirementdata.md?view=aspnetcore-11.0&preserve-view=true).

### QuickGrid APIs from Virtualize are exposed

The following new [`QuickGrid` component](xref:Microsoft.AspNetCore.Components.QuickGrid) APIs are exposed when a grid is virtualized (<xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid`1.Virtualize> set to `true`):

* `InitialItemIndex`: Scrolls the grid to the given zero-based row index on the first interactive render. The value is applied once and clamped to the valid range. This forwards to the inner `Virtualize` component. For more information, see [ASP.NET Core Razor component virtualization](../../../blazor/components/virtualization.md?view=aspnetcore-11.0&preserve-view=true#scroll-to-a-specific-item).
* `ScrollToItemAsync`: Programmatically scrolls the grid to the given zero-based row index, aligning it to the top. The last call wins, and the method throws an <xref:System.InvalidOperationException> when virtualization is disabled or the grid isn't rendered yet. This forwards to the inner `Virtualize` component. For more information, see [ASP.NET Core Razor component virtualization](../../../blazor/components/virtualization.md?view=aspnetcore-11.0&preserve-view=true#scroll-to-a-specific-item).
* `AnchorMode`: Controls how the viewport behaves at list edges when items are dynamically added (default: `Start`). This is an experimental API that requires opting in to the `ASP0030` diagnostic, and it forwards to the inner `Virtualize` component. For more information, see [ASP.NET Core Razor component virtualization](../../../blazor/components/virtualization.md?view=aspnetcore-11.0&preserve-view=true#control-viewport-scroll-position-behavior-when-items-are-dynamically-added).
* `ItemComparer`: A comparer used to detect whether items were prepended or appended between data loads, which is useful for class-typed items supplied by an <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid`1.ItemsProvider>. This is an experimental API that requires opting in to the `ASP0030` diagnostic, and it forwards to the inner `Virtualize` component. For more information, see [ASP.NET Core Razor component virtualization](../../../blazor/components/virtualization.md?view=aspnetcore-11.0&preserve-view=true#control-viewport-scroll-position-behavior-when-items-are-dynamically-added).

For more information, see [ASP.NET Core Blazor \`QuickGrid\` component](../../../blazor/components/quickgrid.md?view=aspnetcore-11.0&preserve-view=true#quickgrid-implementation).

### Cache rendered output of a component subtree during static SSR

The new `CacheView` component caches the rendered output of a Razor component subtree during static server-side rendering (static SSR). On a cache hit, cached markup is replayed without instantiating or running the lifecycle of the child components that were included in the cached output.

`CacheView` is useful for expensive, mostly static sections of a page that don't require the entire response to be cached:

```razor
<CacheView VaryByQuery="category" ExpiresAfter="TimeSpan.FromMinutes(5)">
    <ProductList Category="@Category" />
</CacheView>
```

For more information, see [ASP.NET Core Blazor CacheView component](../../../blazor/state-management/cacheview-component.md?view=aspnetcore-11.0&preserve-view=true).

### Blazor Server circuits update after authentication refresh

Interactive Server components can now receive the refreshed `ClaimsPrincipal` without reconnecting the circuit. The Blazor component hub and client enable authentication refresh automatically, so no additional configuration is required.

After the connection refreshes its authentication, Blazor updates the authentication state and raises `AuthenticationStateChanged`. Components that consume `AuthenticationStateProvider`, including `AuthorizeView`, rerender using the refreshed identity and claims. This behavior is useful when a user's roles or permissions change during an active circuit or when a component should reload user-specific content after claims are refreshed. The UI can reflect the new authentication state without forcing the user to reconnect or reload the page.

For more information, see the following resources:

* [[Blazor] Propagate SignalR authentication refresh to server circuits (`dotnet/aspnetcore` #68221)](https://github.com/dotnet/aspnetcore/pull/68221)
* [[release/11.0-rc1] Harden SignalR authentication refresh (`dotnet/aspnetcore` #68593)](https://github.com/dotnet/aspnetcore/pull/68593)

Please don't comment on closed issues and PRs. If you have feedback on this feature, please open a new issue on the `dotnet/aspnetcore` GitHub repository.

### Experimental Blazor AI components for agentic user interfaces

Modern AI apps increasingly provide rich interactions with agents. A complete agentic user interface may need to stream ongoing work, visualize agent reasoning and progress, request approval before tools act, accept multimodal input, and synchronize state between the app and the agent. The Blazor AI components are designed to provide building blocks for creating these experiences using Blazor's component model.

The new [`Microsoft.AspNetCore.Components.AI` NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.AI) includes an initial set of Blazor AI components for streaming chat, rich-text and tool rendering, human approval flows, and typed, shared, and predictive UI state.

Blazor AI chat interface showing a conversation with a travel planning agent:

![Conversation with a travel planning agent](~/release-notes/aspnetcore-11/static/blazor-ai-chat.png)

For more information, see [ASP.NET Core Blazor AI components for agentic user interfaces](../../../blazor/components/ai-components.md).

#### Render content blocks

An `IChatClient` streams model-facing content, such as `TextContent`, `RichTextContent`, and `FunctionCallContent`, in `ChatResponseUpdate` values. `UIAgent` maps this response content into UI-facing `ContentBlock` objects that retain rendering state and can update in place while the response streams. For example, both plain-text fragments and structured rich-text snapshots map to a `RichContentBlock`.

The built-in block types include:

* `RichContentBlock` for streamed text and structured rich content.
* `FunctionInvocationContentBlock` for a server function call and its eventual result.
* `UIActionBlock` for a function that runs in the Blazor app.
* `FunctionApprovalBlock` for a function call that is waiting for user approval.
* `ActivityContentBlock` for application-defined progress that updates in place.

`ChatPage` and `MessageList` include default rendering for `RichContentBlock` and `FunctionApprovalBlock`. Add a `BlockRenderer<TBlock>` to `ChatPage.MessageListContent` to replace this default rendering or render another block type. Its child content receives the matching block as `context`, including its current properties as they change during streaming.

The following example replaces the default rendering for conversational content:

```razor
<ChatPage Agent="agent">
    <MessageListContent>
        <BlockRenderer TBlock="RichContentBlock" Context="block">
            <div class="agent-response">@block.RawText</div>
        </BlockRenderer>
    </MessageListContent>
</ChatPage>
```

Use the renderer's `When` predicate to only handle selected blocks of a type. If multiple renderers match, the most recently registered renderer takes precedence. Apps can also define custom `ContentBlock` types and map response content to them with a `ContentBlockHandler<TState>`.







### Validation attributes are no longer experimental

<xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> and <xref:Microsoft.Extensions.Validation.SkipValidationAttribute> from the [`Microsoft.Extensions.Validation` package](https://www.nuget.org/packages/Microsoft.Extensions.Validation) are no longer marked experimental. If you suppressed `ASP0029` to use either attribute, remove the suppression.

For more information, see the following resources:

* [Upgrade from the experimental `ValidatableTypeAttribute` and `SkipValidationAttribute` in .NET 10](../../../migration/100-to-110.md#upgrade-from-the-experimental-validatabletypeattribute-and-skipvalidationattribute-in-net-10)
* [Validation in ASP.NET Core](../../../fundamentals/validation.md?view=aspnetcore-11.0&preserve-view=true#nested-objects-and-collections)
* [Validation in ASP.NET Core](../../../fundamentals/validation.md?view=aspnetcore-11.0&preserve-view=true#force-generate-validatable-type-information)
