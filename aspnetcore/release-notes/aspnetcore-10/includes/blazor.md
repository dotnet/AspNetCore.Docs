### New and updated Blazor Web App security samples

We've added and updated the Blazor Web App security samples linked in the following articles:

* <xref:blazor/security/blazor-web-app-oidc?view=aspnetcore-10.0>
* <xref:blazor/security/blazor-web-app-entra?view=aspnetcore-10.0>
* <xref:blazor/security/blazor-web-app-windows-authentication?view=aspnetcore-10.0>

All of our OIDC and Entra sample solutions now include a separate web API project (`MinimalApiJwt`) to demonstrate how to configure and call an external web API securely. Calling web APIs is demonstrated with a token handler and named HTTP client for an OIDC identity provider or Microsoft Identity Web packages/API for Microsoft Entra ID.

The sample solutions are configured in C# code in their `Program` files. To configure the solutions from app settings files (for example, `appsettings.json`) see the ***new*** *Supply configuration with the JSON configuration provider (app settings)* section of the OIDC or Entra articles.

Our Entra samples also include new guidance on using an encrypted distributed token cache for web farm hosting scenarios.

### QuickGrid `RowClass` parameter

Apply a stylesheet class to a row of the grid based on the row item using the new `RowClass` parameter. In the following example, the `GetRowCssClass` method is called on each row to conditionally apply a stylesheet class based on the row item:

```razor
<QuickGrid ... RowClass="GetRowCssClass">
    ...
</QuickGrid>

@code {
    private string GetRowCssClass(MyGridItem item) =>
        item.IsArchived ? "row-archived" : null;
}
```

For more information, see <xref:blazor/components/quickgrid?view=aspnetcore-10.0#style-a-table-row-based-on-the-row-item>.

### Blazor script as static web asset

In prior releases of .NET, the Blazor script is served from an embedded resource in the ASP.NET Core shared framework. In .NET 10 or later, the Blazor script is served as a static web asset with automatic compression and fingerprinting.

For more information, see the following resources:
  
* <xref:blazor/project-structure?view=aspnetcore-10.0#location-of-the-blazor-script>
* <xref:blazor/fundamentals/static-files?view=aspnetcore-10.0>

### Route template highlights

The [`[Route]` attribute](xref:Microsoft.AspNetCore.Components.RouteAttribute) now supports route syntax highlighting to help visualize the structure of the route template:

![Route template pattern of a route attribute for the counter value shows syntax highlighting](~/release-notes/aspnetcore-10/_static/route-template-highlighting.png)

### `NavigateTo` no longer scrolls to the top for same-page navigations

Previously, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> scrolled to the top of the page for same-page navigations. This behavior has been changed in .NET 10 so that the browser no longer scrolls to the top of the page when navigating to the same page. This means the viewport is no longer reset when making updates to the address for the current page, such as changing the query string or fragment.

### Reconnection UI component added to the Blazor Web App project template

The Blazor Web App project template now includes a `ReconnectModal` component, including collocated stylesheet and JavaScript files, for improved developer control over the reconnection UI when the client loses the WebSocket connection to the server. The component doesn't insert styles programmatically, ensuring compliance with stricter Content Security Policy (CSP) settings for the `style-src` policy. In prior releases, the default reconnection UI was created by the framework in a way that could cause CSP violations. Note that the default reconnection UI is still used as fallback when the app doesn't define the reconnection UI, such as by using the project template's `ReconnectModal` component or a similar custom component.

New reconnection UI features:

* Apart from indicating the reconnection state by setting a specific CSS class on the reconnection UI element, the new `components-reconnect-state-changed` event is dispatched for reconnection state changes.
* Code can better differentiate the stages of the reconnection process with the new reconnection state "`retrying`," indicated by both the CSS class and the new event.

For more information, see <xref:blazor/fundamentals/signalr?view=aspnetcore-10.0#reflect-the-server-side-connection-state-in-the-ui>.

### Ignore the query string and fragment when using `NavLinkMatch.All`

The `NavLink` component now ignores the query string and fragment when using the `NavLinkMatch.All` value for the `Match` parameter. This means that the link retains the `active` class if the URL path matches but the query string or fragment change. To revert to the original behavior, use the `Microsoft.AspNetCore.Components.Routing.NavLink.EnableMatchAllForQueryStringAndFragment` [`AppContext` switch](/dotnet/fundamentals/runtime-libraries/system-appcontext) set to `true`.

You can also override the `ShouldMatch` method on `NavLink` to customize the matching behavior:

```csharp
public class CustomNavLink : NavLink
{
    protected override bool ShouldMatch(string currentUriAbsolute)
    {
        // Custom matching logic
    }
}
```

For more information, see <xref:blazor/fundamentals/routing?view=aspnetcore-10.0#navlink-component>.

### Close `QuickGrid` column options

You can now close the `QuickGrid` column options UI using the new `HideColumnOptionsAsync` method.

The following example uses the `HideColumnOptionsAsync` method to close the column options UI as soon as the title filter is applied:

```razor
<QuickGrid @ref="movieGrid" Items="movies">
    <PropertyColumn Property="@(m => m.Title)" Title="Title">
        <ColumnOptions>
            <input type="search" @bind="titleFilter" placeholder="Filter by title" 
                @bind:after="@(() => movieGrid.HideColumnOptionsAsync())" />
        </ColumnOptions>
    </PropertyColumn>
    <PropertyColumn Property="@(m => m.Genre)" Title="Genre" />
    <PropertyColumn Property="@(m => m.ReleaseYear)" Title="Release Year" />
</QuickGrid>

@code {
    private QuickGrid<Movie>? movieGrid;
    private string titleFilter = string.Empty;
    private IQueryable<Movie> movies = new List<Movie> { ... }.AsQueryable();
    private IQueryable<Movie> filteredMovies => 
        movies.Where(m => m.Title!.Contains(titleFilter));
}
```

### Response streaming is opt-in and how to opt-out

In prior Blazor releases, response streaming for <xref:System.Net.Http.HttpClient> requests was opt-in. Now, response streaming is enabled by default.

This is a breaking change because calling <xref:System.Net.Http.HttpContent.ReadAsStreamAsync%2A?displayProperty=nameWithType> for an <xref:System.Net.Http.HttpResponseMessage.Content%2A?displayProperty=nameWithType> (`response.Content.ReadAsStreamAsync()`) returns a `BrowserHttpReadStream` and no longer a <xref:System.IO.MemoryStream>. `BrowserHttpReadStream` doesn't support synchronous operations, such as `Stream.Read(Span<Byte>)`. If your code uses synchronous operations, you can opt-out of response streaming or copy the <xref:System.IO.Stream> into a <xref:System.IO.MemoryStream> yourself.

To opt-out of response streaming globally, use either of the following approaches:

* Add the `<WasmEnableStreamingResponse>` property to the project file with a value of `false`:
  
  ```xml
  <WasmEnableStreamingResponse>false</WasmEnableStreamingResponse>
  ```

* Set the `DOTNET_WASM_ENABLE_STREAMING_RESPONSE` environment variable to `false` or `0`.

To opt-out of response streaming for an individual request, set <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserResponseStreamingEnabled%2A> to `false` on the <xref:System.Net.Http.HttpRequestMessage> (`requestMessage` in the following example):

```csharp
requestMessage.SetBrowserResponseStreamingEnabled(false);
```

For more information, see [`HttpClient` and `HttpRequestMessage` with Fetch API request options (*Call web API* article)](xref:blazor/call-web-api?view=aspnetcore-10.0#httpclient-and-httprequestmessage-with-fetch-api-request-options).

### Client-side fingerprinting

Last year, the release of .NET 9 introduced [server-side fingerprinting](https://en.wikipedia.org/wiki/Fingerprint_(computing)) of static assets in Blazor Web Apps with the introduction of [Map Static Assets routing endpoint conventions (`MapStaticAssets`)](xref:fundamentals/map-static-files), the [`ImportMap` component](xref:blazor/fundamentals/static-files#importmap-component), and the <xref:Microsoft.AspNetCore.Components.ComponentBase.Assets?displayProperty=nameWithType> property (`@Assets["..."]`) to resolve fingerprinted JavaScript modules. For .NET 10, you can opt-into client-side fingerprinting of JavaScript modules for standalone Blazor WebAssembly apps.

In standalone Blazor WebAssembly apps during build/publish, the framework overrides placeholders in `index.html` with values computed during build to fingerprint static assets. A fingerprint is placed into the `blazor.webassembly.js` script file name.

The following markup must be present in the `wwwwoot/index.html` file to adopt the fingerprinting feature:

```diff
<head>
    ...
+   <script type="importmap"></script>
</head>

<body>
    ...
-   <script src="_framework/blazor.webassembly.js"></script>
+   <script src="_framework/blazor.webassembly#[.{fingerprint}].js"></script>
</body>

</html>
```

In the project file (`.csproj`), add the `<OverrideHtmlAssetPlaceholders>` property set to `true`:

```diff
<Project Sdk="Microsoft.NET.Sdk.BlazorWebAssembly">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
+   <OverrideHtmlAssetPlaceholders>true</OverrideHtmlAssetPlaceholders>
  </PropertyGroup>
</Project>
```

Any script in `index.html` with the fingerprint marker is fingerprinted by the framework. For example, a script file named `scripts.js` in the app's `wwwroot/js` folder is fingerprinted by adding `#[.{fingerprint}]` before the file extension (`.js`):

```html
<script src="js/scripts#[.{fingerprint}].js"></script>
```

To fingerprint additional JS modules in standalone Blazor WebAssembly apps, use the `<StaticWebAssetFingerprintPattern>` property in the app's project file (`.csproj`).

In the following example, a fingerprint is added for all developer-supplied `.mjs` files in the app:

```xml
<StaticWebAssetFingerprintPattern Include="JSModule" Pattern="*.mjs" 
  Expression="#[.{fingerprint}]!" />
```

The files are automatically placed into the import map:

* Automatically for Blazor Web App CSR.
* When opting-into module fingerprinting in standalone Blazor WebAssembly apps per the preceding instructions.

When resolving the import for JavaScript interop, the import map is used by the browser resolve fingerprinted files.

### Set the environment in standalone Blazor WebAssembly apps

The `Properties/launchSettings.json` file is no longer used to control the environment in standalone Blazor WebAssembly apps.

Starting in .NET 10, set the environment with the `<WasmApplicationEnvironmentName>` property in the app's project file (`.csproj`).

The following example sets the app's environment to `Staging`:

```xml
<WasmApplicationEnvironmentName>Staging</WasmApplicationEnvironmentName>
```

The default environments are:

* `Development` for build.
* `Production` for publish.

### Boot configuration file inlined

Blazor's boot configuration, which prior to the release of .NET 10 existed in a file named `blazor.boot.json`, has been inlined into the `dotnet.js` script. This only affects developers who are interacting directly with the `blazor.boot.json` file, such as when developers are:

* Checking file integrity for published assets with the troubleshoot integrity PowerShell script per the guidance in <xref:blazor/host-and-deploy/webassembly/bundle-caching-and-integrity-check-failures?view=aspnetcore-9.0#troubleshoot-integrity-powershell-script>.
* Changing the file name extension of DLL files when not using the default Webcil file format per the guidance in <xref:blazor/host-and-deploy/webassembly/index?view=aspnetcore-9.0#customize-how-boot-resources-are-loaded>.

Currently, there's no documented replacement strategy for the preceding approaches. If you require either of the preceding strategies, open a new documentation issue describing your scenario using the **Open a documentation issue** link at the bottom of either article.

### Declarative model for persisting state from components and services

You can now declaratively specify state to persist from components and services using the `[SupplyParameterFromPersistentComponentState]` attribute. Properties with this attribute are automatically persisted using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service during prerendering. The state is retrieved when the component renders interactively or the service is instantiated.

In previous Blazor releases, persisting component state during prerendering using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service involved a significant amount of code, as the following example demonstrates:

```razor
@page "/movies"
@implements IDisposable
@inject IMovieService MovieService
@inject PersistentComponentState ApplicationState

@if (MoviesList == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <QuickGrid Items="MoviesList.AsQueryable()">
        ...
    </QuickGrid>
}

@code {
    public List<Movie>? MoviesList { get; set; }
    private PersistingComponentStateSubscription? persistingSubscription;

    protected override async Task OnInitializedAsync()
    {
        if (!ApplicationState.TryTakeFromJson<List<Movie>>(nameof(MoviesList), 
            out var movies))
        {
            MoviesList = await MovieService.GetMoviesAsync();
        }
        else
        {
            MoviesList = movies;
        }

        persistingSubscription = ApplicationState.RegisterOnPersisting(() =>
        {
            ApplicationState.PersistAsJson(nameof(MoviesList), MoviesList);
            return Task.CompletedTask;
        });
    }

    public void Dispose() => persistingSubscription?.Dispose();
}
```

This code can now be simplified using the new declarative model:

```razor
@page "/movies"
@inject IMovieService MovieService

@if (MoviesList == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <QuickGrid Items="MoviesList.AsQueryable()">
        ...
    </QuickGrid>
}

@code {
    [SupplyParameterFromPersistentComponentState]
    public List<Movie>? MoviesList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MoviesList ??= await MovieService.GetMoviesAsync();
    }
}
```

State can be serialized for multiple components of the same type, and you can establish declarative state in a service for use around the app by calling `RegisterPersistentService` on the Razor components builder (<xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>) with a custom service type and render mode. For more information, see <xref:blazor/components/prerender?view=aspnetcore-10.0#persist-prerendered-state>.

### New JavaScript interop features

Blazor adds support for the following JS interop features:

* Create an instance of a JS object using a constructor function and get the <xref:Microsoft.JSInterop.IJSObjectReference>/<xref:Microsoft.JSInterop.IJSInProcessObjectReference> .NET handle for referencing the instance.
* Read or modify the value of a JS object property, both data and accessor properties.

The following asynchronous methods are available on <xref:Microsoft.JSInterop.IJSRuntime> and <xref:Microsoft.JSInterop.IJSObjectReference> with the same scoping behavior as the existing <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> method:

* `InvokeNewAsync(string identifier, object?[]? args)`: Invokes the specified JS constructor function asynchronously. The function is invoked with the `new` operator. In the following example, `jsInterop.TestClass` is a class with a constructor function, and `classRef` is an <xref:Microsoft.JSInterop.IJSObjectReference>:

  ```csharp
  var classRef = await JSRuntime.InvokeNewAsync("jsInterop.TestClass", "Blazor!");
  var text = await classRef.GetValueAsync<string>("text");
  var textLength = await classRef.InvokeAsync<int>("getTextLength");
  ```

* `GetValueAsync<TValue>(string identifier)`: Reads the value of the specified JS property asynchronously. The property can't be a `set`-only property. A <xref:Microsoft.JSInterop.JSException> is thrown if the property doesn't exist. The following example returns a value from a data property:

  ```csharp
  var valueFromDataPropertyAsync = await JSRuntime.GetValueAsync<int>(
    "jsInterop.testObject.num");
  ```

* `SetValueAsync<TValue>(string identifier, TValue value)`: Updates the value of the specified JS property asynchronously. The property can't be a `get`-only property. If the property isn't defined on the target object, the property is created. A <xref:Microsoft.JSInterop.JSException> is thrown if the property exists but isn't writable or when a new property can't be added to the object. In the following example, `num` is created on `testObject` with a value of 30 if it doesn't exist:

  ```csharp
  await JSRuntime.SetValueAsync("jsInterop.testObject.num", 30);
  ```

Overloads are available for each of the preceding methods that take a <xref:System.Threading.CancellationToken> argument or <xref:System.TimeSpan> timeout argument.

The following synchronous methods are available on <xref:Microsoft.JSInterop.IJSInProcessRuntime> and <xref:Microsoft.JSInterop.IJSInProcessObjectReference> with the same scoping behavior as the existing <xref:Microsoft.JSInterop.IJSInProcessObjectReference.Invoke%2A?displayProperty=nameWithType> method:

* `InvokeNew(string identifier, object?[]? args)`: Invokes the specified JS constructor function synchronously. The function is invoked with the `new` operator. In the following example, `jsInterop.TestClass` is a class with a constructor function, and `classRef` is an <xref:Microsoft.JSInterop.IJSInProcessObjectReference>:

  ```csharp
  var inProcRuntime = ((IJSInProcessRuntime)JSRuntime);
  var classRef = inProcRuntime.InvokeNew("jsInterop.TestClass", "Blazor!");
  var text = classRef.GetValue<string>("text");
  var textLength = classRef.Invoke<int>("getTextLength");
  ```

* `GetValue<TValue>(string identifier)`: Reads the value of the specified JS property synchronously. The property can't be a `set`-only property. A <xref:Microsoft.JSInterop.JSException> is thrown if the property doesn't exist. The following example returns a value from a data property:

  ```csharp
  var inProcRuntime = ((IJSInProcessRuntime)JSRuntime);
  var valueFromDataProperty = inProcRuntime.GetValue<int>(
    "jsInterop.testObject.num");
  ```

* `SetValue<TValue>(string identifier, TValue value)`: Updates the value of the specified JS property synchronously. The property can't be a `get`-only property. If the property isn't defined on the target object, the property is created. A <xref:Microsoft.JSInterop.JSException> is thrown if the property exists but isn't writable or when a new property can't be added to the object. In the following example, `num` is created on `testObject` with a value of 20 if it doesn't exist:

  ```csharp
  var inProcRuntime = ((IJSInProcessRuntime)JSRuntime);
  inProcRuntime.SetValue("jsInterop.testObject.num", 20);
  ```

For more information, see the following sections of the *Call JavaScript functions from .NET methods* article:

* [Create an instance of a JS object using a constructor function](xref:blazor/js-interop/call-javascript-from-dotnet?view=aspnetcore-10.0#create-an-instance-of-a-js-object-using-a-constructor-function)
* [Read or modify the value of a JS object property](xref:blazor/js-interop/call-javascript-from-dotnet?view=aspnetcore-10.0#read-or-modify-the-value-of-a-js-object-property)

### Blazor WebAssembly performance profiling and diagnostic counters

New performance profiling and diagnostic counters are available for Blazor WebAssembly apps. For more information, see the following articles:

* <xref:blazor/performance/webassembly-browser-developer-tools?view=aspnetcore-10.0>
* <xref:blazor/performance/webassembly-event-pipe?view=aspnetcore-10.0>

### Preloaded Blazor framework static assets

In Blazor Web Apps, framework static assets are automatically preloaded using [`Link` headers](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Link), which allows the browser to preload resources before the initial page is fetched and rendered. In standalone Blazor WebAssembly apps, framework assets are scheduled for high priority downloading and caching early in browser `index.html` page processing.

For more information, see <xref:blazor/fundamentals/static-files?view=aspnetcore-10.0#preloaded-blazor-framework-static-assets>.

### `NavigationManager.NavigateTo` no longer throws a `NavigationException`

Previously, calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> during static server-side rendering (SSR) would throw a <xref:Microsoft.AspNetCore.Components.NavigationException>, interrupting execution before being converted to a redirection response. This caused confusion during debugging and was inconsistent with interactive rendering, where code after <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> continues to execute normally.

Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> during static SSR no longer throws a <xref:Microsoft.AspNetCore.Components.NavigationException>. Instead, it behaves consistently with interactive rendering by performing the navigation without throwing an exception.

Code that relied on <xref:Microsoft.AspNetCore.Components.NavigationException> being thrown should be updated. For example, in the default Blazor Identity UI, the `IdentityRedirectManager` previously threw an <xref:System.InvalidOperationException> after calling `RedirectTo` to ensure it wasn't invoked during interactive rendering. This exception and the [`[DoesNotReturn]` attributes](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute) should now be removed.

To revert to the previous behavior of throwing a <xref:Microsoft.AspNetCore.Components.NavigationException>, set the following <xref:System.AppContext> switch:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Components.Endpoints.NavigationManager.DisableThrowNavigationException", 
    isEnabled: false);
```

### Blazor router has a `NotFoundPage` parameter

Blazor now provides an improved way to display a "Not Found" page when navigating to a non-existent page. You can specify a page to render when `NavigationManager.NotFound` (described in the next section) is invoked by passing a page type to the `Router` component using the `NotFoundPage` parameter. This approach is recommended over using the [`NotFound` render fragment](xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound%2A) (`<NotFound>...</NotFound>`), as it supports routing, works across code Status Code Pages Re-execution Middleware, and is compatible even with non-Blazor scenarios. If both a `NotFound` render fragment and `NotFoundPage` are defined, the page specified by `NotFoundPage` takes priority.

```razor
<Router AppAssembly="@typeof(Program).Assembly" NotFoundPage="typeof(Pages.NotFound)">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
    <NotFound>This content is ignored because NotFoundPage is defined.</NotFound>
</Router>
```

The Blazor project template now includes a `NotFound.razor` page by default. This page automatically renders whenever `NavigationManager.NotFound` is called in your app, making it easier to handle missing routes with a consistent user experience.

For more information, see <xref:blazor/fundamentals/routing?view=aspnetcore-10.0#not-found-responses>.

### Not Found responses using `NavigationManager` for static SSR and global interactive rendering

The <xref:Microsoft.AspNetCore.Components.NavigationManager> now includes a `NotFound` method to handle scenarios where a requested resource isn't found during static server-side rendering (static SSR) or global interactive rendering:

* **Static server-side rendering (static SSR)**: Calling `NotFound` sets the HTTP status code to 404.

* **Interactive rendering**: Signals the Blazor router ([`Router` component](xref:blazor/fundamentals/routing?view=aspnetcore-10.0#route-templates)) to render Not Found content.

* **Streaming rendering**: If [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) is active, [streaming rendering](xref:blazor/components/rendering#streaming-rendering) renders Not Found content without reloading the page. When enhanced navigation is blocked, the framework redirects to Not Found content with a page refresh.

Streaming rendering can only render components that have a route, such as a [`NotFoundPage` assignment](#blazor-router-has-a-notfoundpage-parameter) (`NotFoundPage="..."`) or a [Status Code Pages Re-execution Middleware page assignment](xref:fundamentals/error-handling#usestatuscodepageswithreexecute) (<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A>). The Not Found render fragment (`<NotFound>...</NotFound>`) and the `DefaultNotFound` 404 content ("`Not found`" plain text) don't have routes, so they can't be used during streaming rendering.

Streaming `NavigationManager.NotFound` content rendering uses (in order):

* A `NotFoundPage` passed to the `Router` component, if present.
* A Status Code Pages Re-execution Middleware page, if configured.
* No action if neither of the preceding approaches is adopted.

Non-streaming `NavigationManager.NotFound` content rendering uses (in order):

* A `NotFoundPage` passed to the `Router` component, if present.
* Not Found render fragment content, if present. *Not recommended in .NET 10 or later.*
* `DefaultNotFound` 404 content ("`Not found`" plain text).

[Status Code Pages Re-execution Middleware](xref:fundamentals/error-handling#usestatuscodepageswithreexecute) with <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A> takes precedence for browser-based address routing problems, such as an incorrect URL typed into the browser's address bar or selecting a link that has no endpoint in the app.

You can use the `NavigationManager.OnNotFound` event for notifications when `NotFound` is invoked.

For more information and examples, see <xref:blazor/fundamentals/routing?view=aspnetcore-10.0#not-found-responses>.

### Metrics and tracing

This release introduces comprehensive metrics and tracing capabilities for Blazor apps, providing detailed observability of the component lifecycle, navigation, event handling, and circuit management.

For more information, see <xref:blazor/performance/index?view=aspnetcore-10.0#metrics-and-tracing>.

### JavaScript bundler support

Blazor's build output isn't compatible with JavaScript bundlers, such as [Gulp](https://gulpjs.com), [Webpack](https://webpack.js.org), and [Rollup](https://rollupjs.org/). Blazor can now produce bundler-friendly output during publish by setting the `WasmBundlerFriendlyBootConfig` MSBuild property to `true`.

For more information, see <xref:blazor/host-and-deploy/index?view=aspnetcore-10.0#javascript-bundler-support>.

### Blazor WebAssembly static asset preloading in Blazor Web Apps

We replaced `<link>` headers with a `LinkPreload` component (`<LinkPreload />`) for preloading WebAssembly assets in Blazor Web Apps. This permits the app base path configuration (`<base href="..." />`) to correctly identify the app's root.

Removing the component disables the feature if the app is using a [`loadBootResource` callback](xref:blazor/fundamentals/startup#load-client-side-boot-resources) to modify URLs.

The Blazor Web App template adopts the feature by default in .NET 10, and apps upgrading to .NET 10 can implement the feature by placing the `LinkPreload` component after the base URL tag (`<base>`) in the `App` component's head content (`App.razor`):

```diff
<head>
    ...
    <base href="/" />
+   <LinkPreload />
    ...
</head>
```

For more information, see <xref:blazor/host-and-deploy/server/index?view=aspnetcore-10.0#static-asset-preloading>.

### Improved form validation

Blazor now has improved form validation capabilities, including support for validating properties of nested objects and collection items.

To create a validated form, use a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component inside an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component, just as before.

To opt into the new validation feature:

1. Call the `AddValidation` extension method in the `Program` file where services are registered.
2. Declare the form model types in a C# class file, not in a Razor component (`.razor`).
3. Annotate the root form model type with the `[ValidatableType]` attribute.

Without following the preceding steps, the validation behavior remains the same as in previous .NET releases.

The following example demonstrates customer orders with the improved form validation (details omitted for brevity):

In `Program.cs`, call `AddValidation` on the service collection to enable the new validation behavior:

```csharp
builder.Services.AddValidation();
```

In the following `Order` class, the `[ValidatableType]` attribute is required on the top-level model type. The other types are discovered automatically. `OrderItem` and `ShippingAddress` aren't shown for brevity, but nested and collection validation works the same way in those types if they were shown.

`Order.cs`:

```csharp
[ValidatableType]
public class Order
{
    public Customer Customer { get; set; } = new();
    public List<OrderItem> OrderItems { get; set; } = [];
}

public class Customer
{
    [Required(ErrorMessage = "Name is required.")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }

    public ShippingAddress ShippingAddress { get; set; } = new();
}
```

In the following `OrderPage` component, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component is present in the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component.

`OrderPage.razor`:

```razor
<EditForm Model="Model">
    <DataAnnotationsValidator />

    <h3>Customer Details</h3>
    <div class="mb-3">
        <label>
            Full Name
            <InputText @bind-Value="Model!.Customer.FullName" />
        </label>
        <ValidationMessage For="@(() => Model!.Customer.FullName)" />
    </div>

    @* ... form continues ... *@
</EditForm>

@code {
    public Order? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    // ... code continues ...
}
```

The requirement to declare the model types outside of Razor components (`.razor` files) is due to the fact that both the new validation feature and the Razor compiler itself are using a source generator. Currently, output of one source generator can't be used as an input for another source generator.

### Custom Blazor cache and `BlazorCacheBootResources` MSBuild property removed

Now that all Blazor client-side files are fingerprinted and cached by the browser, Blazor's custom caching mechanism and the `BlazorCacheBootResources` MSBuild property have been removed from the framework. If the client-side project's project file contains the MSBuild property, remove the property, as it no longer has any effect:

```diff
- <BlazorCacheBootResources>...</BlazorCacheBootResources>
```

For more information, see <xref:blazor/host-and-deploy/webassembly/bundle-caching-and-integrity-check-failures?view=aspnetcore-10.0>.

## Web Authentication API (passkey) support for ASP.NET Core Identity

[Web Authentication (WebAuthn) API](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API) support, known widely as *passkeys*, is a modern, phishing-resistant authentication method that improves security and user experience by leveraging public key cryptography and device-based authentication. ASP.NET Core Identity now supports passkey authentication based on WebAuthn and FIDO2 standards. This feature allows users to sign in without passwords, using secure, device-based authentication methods, such as biometrics or security keys.

The Preview 6 Blazor Web App project template provides out-of-the-box passkey management and login functionality.

Migration guidance for existing apps will be published for the upcoming release of Preview 7, which is scheduled for mid-August.
