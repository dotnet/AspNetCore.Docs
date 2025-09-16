### New and updated Blazor Web App security samples

We've added and updated the Blazor Web App security samples linked in the following articles:

* <xref:blazor/security/blazor-web-app-oidc?view=aspnetcore-10.0>
* <xref:blazor/security/blazor-web-app-entra?view=aspnetcore-10.0>
* <xref:blazor/security/blazor-web-app-windows-authentication?view=aspnetcore-10.0>

All of our OIDC and Entra sample solutions now include a separate web API project (`MinimalApiJwt`) to demonstrate how to configure and call an external web API securely. Calling web APIs is demonstrated with a token handler and named HTTP client for an OIDC identity provider or Microsoft Identity Web packages/API for Microsoft Entra ID.

The sample solutions are configured in C# code in their `Program` files. To configure the solutions from app settings files (for example, `appsettings.json`) see the ***new*** *Supply configuration with the JSON configuration provider (app settings)* section of the OIDC or Entra articles.

Our Entra article and sample apps also include new guidance on the following approaches:

* How to use an encrypted distributed token cache for web farm hosting scenarios.
* How to use [Azure Key Vault](https://azure.microsoft.com/products/key-vault/) with [Azure Managed Identities](/entra/identity/managed-identities-azure-resources/overview) for data protection.

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

The release of .NET 9 introduced [server-side fingerprinting](https://en.wikipedia.org/wiki/Fingerprint_(computing)) of static assets in Blazor Web Apps with the introduction of [Map Static Assets routing endpoint conventions (`MapStaticAssets`)](xref:fundamentals/static-files), the [`ImportMap` component](xref:blazor/fundamentals/static-files#importmap-component), and the <xref:Microsoft.AspNetCore.Components.ComponentBase.Assets?displayProperty=nameWithType> property (`@Assets["..."]`) to resolve fingerprinted JavaScript modules. For .NET 10, you can opt-into client-side fingerprinting of JavaScript modules for standalone Blazor WebAssembly apps.

In standalone Blazor WebAssembly apps during build/publish, the framework overrides placeholders in `index.html` with values computed during build to fingerprint static assets. A fingerprint is placed into the `blazor.webassembly.js` script file name.

The following markup must be present in the `wwwroot/index.html` file to adopt the fingerprinting feature:

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

You can now declaratively specify state to persist from components and services using the `[PersistentState]` attribute. Properties with this attribute are automatically persisted using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service during prerendering. The state is retrieved when the component renders interactively or the service is instantiated.

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
    [PersistentState]
    public List<Movie>? MoviesList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MoviesList ??= await MovieService.GetMoviesAsync();
    }
}
```

State can be serialized for multiple components of the same type, and you can establish declarative state in a service for use around the app by calling `RegisterPersistentService` on the Razor components builder (<xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>) with a custom service type and render mode. For more information, see <xref:blazor/state-management/prerendered-state-persistence?view=aspnetcore-10.0>.

### New JavaScript interop features

Blazor adds support for the following JS interop features:

* Create an instance of a JS object using a constructor function and get the <xref:Microsoft.JSInterop.IJSObjectReference>/<xref:Microsoft.JSInterop.IJSInProcessObjectReference> .NET handle for referencing the instance.
* Read or modify the value of a JS object property, both data and accessor properties.

The following asynchronous methods are available on <xref:Microsoft.JSInterop.IJSRuntime> and <xref:Microsoft.JSInterop.IJSObjectReference> with the same scoping behavior as the existing <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> method:

* `InvokeConstructorAsync(string identifier, object?[]? args)`: Invokes the specified JS constructor function asynchronously. The function is invoked with the `new` operator. In the following example, `jsInterop.TestClass` is a class with a constructor function, and `classRef` is an <xref:Microsoft.JSInterop.IJSObjectReference>:

  ```csharp
  var classRef = await JSRuntime.InvokeConstructorAsync("jsInterop.TestClass", "Blazor!");
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

* `InvokeConstructor(string identifier, object?[]? args)`: Invokes the specified JS constructor function synchronously. The function is invoked with the `new` operator. In the following example, `jsInterop.TestClass` is a class with a constructor function, and `classRef` is an <xref:Microsoft.JSInterop.IJSInProcessObjectReference>:

  ```csharp
  var inProcRuntime = ((IJSInProcessRuntime)JSRuntime);
  var classRef = inProcRuntime.InvokeConstructor("jsInterop.TestClass", "Blazor!");
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

### Opt-in to avoiding a `NavigationException` during static server-side rendering with `NavigationManager.NavigateTo`

Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> during static server-side rendering (static SSR) throws a <xref:Microsoft.AspNetCore.Components.NavigationException>, interrupting execution before being converted to a redirection response. This can cause confusion during debugging and is inconsistent with interactive rendering behavior, where code after <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> continues to execute normally.

In .NET 10, you can set the `<BlazorDisableThrowNavigationException>` MSBuild property to `true` in the app's project file in order to avoid throwing the exception during static SSR:

```xml
<PropertyGroup>
  <BlazorDisableThrowNavigationException>true</BlazorDisableThrowNavigationException>
</PropertyGroup>
```

With the MSBuild property set, calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> during static SSR no longer throws a <xref:Microsoft.AspNetCore.Components.NavigationException>. Instead, it behaves consistently with interactive rendering by performing the navigation without throwing an exception. Code after <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> executes before the redirection occurs.

The .NET 10 Blazor Web App project template sets the MSBuild property to `true` by default. We recommend that apps updating to .NET 10 use the new MSBuild property and avoid the prior behavior.

If the MSBuild property is used, code that relied on <xref:Microsoft.AspNetCore.Components.NavigationException> being thrown should be updated. In the default Blazor Identity UI of the Blazor Web App project template before the release of .NET 10, the `IdentityRedirectManager` throws an <xref:System.InvalidOperationException> after calling `RedirectTo` to ensure that the method wasn't invoked during interactive rendering. This exception and the [`[DoesNotReturn]` attributes](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute) should now be removed when the MSBuild property is used. For more information, see <xref:migration/90-to-100#when-navigation-errors-are-disabled-in-a-blazor-web-app-with-individual-accounts>.

### Blazor router has a `NotFoundPage` parameter

Blazor now provides an improved way to display a "Not Found" page when navigating to a non-existent page. You can specify a page to render when `NavigationManager.NotFound` (described in the next section) is invoked by passing a page type to the `Router` component using the `NotFoundPage` parameter. The feature supports routing, works across code Status Code Pages Re-execution Middleware, and is compatible even with non-Blazor scenarios.

The [`NotFound` render fragment](xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound%2A) (`<NotFound>...</NotFound>`) isn't supported in .NET 10 or later.

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

* **Streaming rendering**: If [enhanced navigation](xref:blazor/fundamentals/routing?view=aspnetcore-10.0#enhanced-navigation-and-form-handling) is active, [streaming rendering](xref:blazor/components/rendering#streaming-rendering) renders Not Found content without reloading the page. When enhanced navigation is blocked, the framework redirects to Not Found content with a page refresh.

Streaming rendering can only render components that have a route, such as a [`NotFoundPage` assignment](#blazor-router-has-a-notfoundpage-parameter) (`NotFoundPage="..."`) or a [Status Code Pages Re-execution Middleware page assignment](xref:fundamentals/error-handling#usestatuscodepageswithreexecute) (<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A>). `DefaultNotFound` 404 content ("`Not found`" plain text) doesn't have a route, so it can't be used during streaming rendering.

`NavigationManager.NotFound` content rendering uses the following, regardless if the response has started or not (in order):

* If <xref:Microsoft.AspNetCore.Components.Routing.NotFoundEventArgs.Path%2A?displayProperty=nameWithType> is set, render the contents of the assigned page.
* If `Router.NotFoundPage` is set, render the assigned page.
* A Status Code Pages Re-execution Middleware page, if configured.
* No action if none of the preceding approaches are adopted.

[Status Code Pages Re-execution Middleware](xref:fundamentals/error-handling#usestatuscodepageswithreexecute) with <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A> takes precedence for browser-based address routing problems, such as an incorrect URL typed into the browser's address bar or selecting a link that has no endpoint in the app.

You can use the `NavigationManager.OnNotFound` event for notifications when `NotFound` is invoked.

For more information and examples, see <xref:blazor/fundamentals/routing?view=aspnetcore-10.0#not-found-responses>.

### Support for Not Found responses in apps without Blazor's router

Apps that implement a custom router can use `NavigationManager.NotFound`. The custom router can render Not Found content from two sources, depending on the state of the response:

* Regardless of the response state, the re-execution path to the page can used by passing it to <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A>:

  ```csharp
  app.UseStatusCodePagesWithReExecute(
      "/not-found", createScopeForStatusCodePages: true);
  ```

* When the response has started, the <xref:Microsoft.AspNetCore.Components.Routing.NotFoundEventArgs.Path%2A?displayProperty=nameWithType> can be used by subscribing to the `OnNotFoundEvent` in the router:

  ```razor
  @code {
      [CascadingParameter]
      public HttpContext? HttpContext { get; set; }

      private void OnNotFoundEvent(object sender, NotFoundEventArgs e)
      {
          // Only execute the logic if HTTP response has started,
          // because setting NotFoundEventArgs.Path blocks re-execution
          if (HttpContext?.Response.HasStarted == false)
          {
              return;
          }

          var type = typeof(CustomNotFoundPage);
          var routeAttributes = type.GetCustomAttributes<RouteAttribute>(inherit: true);

          if (routeAttributes.Length == 0)
          {
              throw new InvalidOperationException($"The type {type.FullName} " +
                  $"doesn't have a {typeof(RouteAttribute).FullName} applied.");
          }

          var routeAttribute = (RouteAttribute)routeAttributes[0];

          if (routeAttribute.Template != null)
          {
              e.Path = routeAttribute.Template;
          }
      }
  }
  ```

### Metrics and tracing

This release introduces comprehensive metrics and tracing capabilities for Blazor apps, providing detailed observability of the component lifecycle, navigation, event handling, and circuit management.

For more information, see <xref:blazor/performance/index?view=aspnetcore-10.0#metrics-and-tracing>.

### JavaScript bundler support

Blazor's build output isn't compatible with JavaScript bundlers, such as [Gulp](https://gulpjs.com), [Webpack](https://webpack.js.org), and [Rollup](https://rollupjs.org/). Blazor can now produce bundler-friendly output during publish by setting the `WasmBundlerFriendlyBootConfig` MSBuild property to `true`.

For more information, see <xref:blazor/host-and-deploy/index?view=aspnetcore-10.0#javascript-bundler-support>.

### Blazor WebAssembly static asset preloading in Blazor Web Apps

We replaced `<link>` headers with a `ResourcePreloader` component (`<ResourcePreloader />`) for preloading WebAssembly assets in Blazor Web Apps. This permits the app base path configuration (`<base href="..." />`) to correctly identify the app's root.

Removing the component disables the feature if the app is using a [`loadBootResource` callback](xref:blazor/fundamentals/startup?view=aspnetcore-10.0#load-client-side-boot-resources) to modify URLs.

The Blazor Web App template adopts the feature by default in .NET 10, and apps upgrading to .NET 10 can implement the feature by placing the `ResourcePreloader` component after the base URL tag (`<base>`) in the `App` component's head content (`App.razor`):

```diff
<head>
    ...
    <base href="/" />
+   <ResourcePreloader />
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

Validation support now includes:

* Validation of nested complex objects and collections is now supported.
  * This includes validation rules defined by property attributes, class attributes, and the <xref:System.ComponentModel.DataAnnotations.IValidatableObject> implementation.
  * The `[SkipValidation]` attribute can exclude properties or types from validation.
* Validation now uses a source generator-based implementation instead of reflection-based implementation for improved performance and compatibility with ahead-of-time (AOT) compilation.

The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component now has the same validation order and short-circuiting behavior as <xref:System.ComponentModel.DataAnnotations.Validator?displayProperty=nameWithType>. The following rules are applied when validating an instance of type `T`:

1. Member properties of `T` are validated, including recursively validating nested objects.
1. Type-level attributes of `T` are validated.
1. The <xref:System.ComponentModel.DataAnnotations.IValidatableObject.Validate%2A?displayProperty=nameWithType> method is executed, if `T` implements it.

If one of the preceding steps produces a validation error, the remaining steps are skipped.

### Custom Blazor cache and `BlazorCacheBootResources` MSBuild property removed

Now that all Blazor client-side files are fingerprinted and cached by the browser, Blazor's custom caching mechanism and the `BlazorCacheBootResources` MSBuild property have been removed from the framework. If the client-side project's project file contains the MSBuild property, remove the property, as it no longer has any effect:

```diff
- <BlazorCacheBootResources>...</BlazorCacheBootResources>
```

For more information, see <xref:blazor/host-and-deploy/webassembly/bundle-caching-and-integrity-check-failures?view=aspnetcore-10.0>.

### Web Authentication API (passkey) support for ASP.NET Core Identity

[Web Authentication (WebAuthn) API](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API) support, known widely as *passkeys*, is a modern, phishing-resistant authentication method that improves security and user experience by leveraging public key cryptography and device-based authentication. ASP.NET Core Identity now supports passkey authentication based on WebAuthn and FIDO2 standards. This feature allows users to sign in without passwords, using secure, device-based authentication methods, such as biometrics or security keys.

The Blazor Web App project template provides out-of-the-box passkey management and login functionality.

For more information, see the following articles:

* <xref:security/authentication/passkeys/index>
* <xref:security/authentication/passkeys/blazor>

### Circuit state persistence

During server-side rendering, Blazor Web Apps can now persist a user's session (circuit) state when the connection to the server is lost for an extended period of time or proactively paused, as long as a full-page refresh isn't triggered. This allows users to resume their session without losing unsaved work in the following scenarios:

* Browser tab throttling
* Mobile device users switching apps
* Network interruptions
* Proactive resource management (pausing inactive circuits)

*[Enhanced navigation](xref:blazor/fundamentals/routing?view=aspnetcore-10.0#enhanced-navigation-and-form-handling) with circuit state persistence isn't currently supported but planned for a future release.*

For more information, see <xref:blazor/state-management/server?view=aspnetcore-10.0#circuit-state-and-prerendering-state-preservation>.

### Hot Reload for Blazor WebAssembly and .NET on WebAssembly

The SDK migrated to a general purpose [Hot Reload](xref:test/hot-reload) for WebAssembly scenarios. There's a new MSBuild property `WasmEnableHotReload` that's `true` by default for the `Debug` configuration (`Configuration == "Debug"`) that enables Hot Reload.

For other configurations with custom configuration names, set the value to `true` in the app's project file to enable Hot Reload:

```xml
<PropertyGroup>
  <WasmEnableHotReload>true</WasmEnableHotReload>
</PropertyGroup>
```

To disable Hot Reload for the `Debug` configuration, set the value to `false`:

```xml
<PropertyGroup>
  <WasmEnableHotReload>false</WasmEnableHotReload>
</PropertyGroup>
```

### Updated PWA service worker registration to prevent caching issues

The service worker registration in the [Blazor Progressive Web Application (PWA)](xref:blazor/progressive-web-app/index) project template now includes the [`updateViaCache: 'none'` option](https://developer.mozilla.org/docs/Web/API/ServiceWorkerRegistration/updateViaCache), which prevents caching issues during service worker updates.

```diff
- navigator.serviceWorker.register('service-worker.js');
+ navigator.serviceWorker.register('service-worker.js', { updateViaCache: 'none' });
```

The option ensures that:

* The browser doesn't use cached versions of the service worker script.
* Service worker updates are applied reliably without being blocked by HTTP caching.
* PWA applications can update their service workers more predictably.

This addresses caching issues that can prevent service worker updates from being applied correctly, which is particularly important for PWAs that rely on service workers for offline functionality.

We recommend using the option set to `none` in all PWAs, including those that target .NET 9 or earlier.

### Serialization extensibility for persistent component state

Implement a custom serializer with the `IPersistentComponentStateSerializer` interface. Without a registered custom serializer, serialization falls back to the existing JSON serialization.

The custom serializer is registered in the app's `Program` file. In the following example, the `CustomUserSerializer` is registered for the `User` type:

```csharp
builder.Services.AddSingleton<IPersistentComponentStateSerializer<User>, 
    CustomUserSerializer>();
```

The type is automatically persisted and restored with the custom serializer:

```razor
[PersistentState] 
public User? CurrentUser { get; set; } = new();
```

### `OwningComponentBase` now implements `IAsyncDisposable`

[`OwningComponentBase`](xref:fundamentals/dependency-injection#utility-base-component-classes-to-manage-a-di-scope) now includes support for asynchronous disposal, improving resource management. There are new `DisposeAsync` and `DisposeAsyncCore` methods with an updated `Dispose` method to handle both synchronous and asynchronous disposal of the service scope.

### New `InputHidden` component to handle hidden input fields in forms

The new `InputHidden` component provides a hidden input field for storing string values.

In the following example, a hidden input field is created for the form's `Parameter` property. When the form is submitted, the value of the hidden field is displayed:

```razor
<EditForm Model="Parameter" OnValidSubmit="Submit" FormName="InputHidden Example">
    <InputHidden id="hidden" @bind-Value="Parameter" />
    <button type="submit">Submit</button>
</EditForm>

@if (submitted)
{
    <p>Hello @Parameter!</p>
}

@code {
    private bool submitted;

    [SupplyParameterFromForm] 
    public string Parameter { get; set; } = "stranger";

    private void Submit() => submitted = true;
}
```

### Persistent component state support for enhanced navigation

Blazor now supports handling persistent component state during [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling). State persisted during enhanced navigation can be read by interactive components on the page.

By default, persistent component state is only loaded by interactive components when they're initially loaded on the page. This prevents important state, such as data in an edited webform, from being overwritten if additional enhanced navigation events to the same page occur after the component is loaded.

If the data is read-only and doesn't change frequently, opt-in to allow updates during enhanced navigation by setting `AllowUpdates = true` on the [`[PersistentState]` attribute](xref:Microsoft.AspNetCore.Components.PersistentStateAttribute). This is useful for scenarios such as displaying cached data that's expensive to fetch but doesn't change often. The following example demonstrates the use of `AllowUpdates` for weather forecast data:

```csharp
[PersistentState(AllowUpdates = true)]
public WeatherForecast[]? Forecasts { get; set; }

protected override async Task OnInitializedAsync()
{
    Forecasts ??= await ForecastService.GetForecastAsync();
}
```

To skip restoring state during prerendering, set `RestoreBehavior` to `SkipInitialValue`:

```csharp
[PersistentState(RestoreBehavior = RestoreBehavior.SkipInitialValue)]
public string NoPrerenderedData { get; set; }
```

To skip restoring state during reconnection, set `RestoreBehavior` to `SkipLastSnapshot`. This can be useful to ensure fresh data after reconnection:

```csharp
[PersistentState(RestoreBehavior = RestoreBehavior.SkipLastSnapshot)]
public int CounterNotRestoredOnReconnect { get; set; }
```

Call `PersistentComponentState.RegisterOnRestoring` to register a callback for imperatively controlling how state is restored, similar to how <xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting%2A?displayProperty=nameWithType> provides full control of how state is persisted.
