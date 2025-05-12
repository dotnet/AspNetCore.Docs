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

For more information, see <xref:blazor/fundamentals/routing#navlink-component>.

### Close `QuickGrid` column options

You can now close the `QuickGrid` column options UI using the new `CloseColumnOptionsAsync` method.

The following example uses the `CloseColumnOptionsAsync` method to close the column options UI as soon as the title filter is applied:

```razor
<QuickGrid @ref="movieGrid" Items="movies">
    <PropertyColumn Property="@(m => m.Title)" Title="Title">
        <ColumnOptions>
            <input type="search" @bind="titleFilter" placeholder="Filter by title" 
                @bind:after="@(() => movieGrid.CloseColumnOptionsAsync())" />
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

<!-- UNCOMMENT FOR PREVIEW 4? ...
     Waiting on https://github.com/dotnet/runtime/issues/97449
     ... and update the Call web API article Line 983

To opt-out of response streaming globally, use either of the following approaches:

* Add the `<WasmEnableStreamingResponse>` property to the project file with a value of `false`:
  
  ```xml
  <WasmEnableStreamingResponse>false</WasmEnableStreamingResponse>
  ```

* Set the `DOTNET_WASM_ENABLE_STREAMING_RESPONSE` environment variable to `false` or `0`.

............. AND REMOVE THE NEXT LINE .............

-->

To opt-out of response streaming globally, set the `DOTNET_WASM_ENABLE_STREAMING_RESPONSE` environment variable to `false` or `0`.

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

In the project file (`.csproj`), add the `<WriteImportMapToHtml>` property set to `true`:

```diff
<Project Sdk="Microsoft.NET.Sdk.BlazorWebAssembly">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
+   <WriteImportMapToHtml>true</WriteImportMapToHtml>
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

<!-- PREVIEW 4

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
  var text = await classRef.GetValueAsync<string>("text");
  var textLength = await classRef.InvokeAsync<int>("getTextLength");
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

## Preloaded Blazor framework static assets

In Blazor Web Apps, framework static assets are automatically preloaded using [`Link` headers](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Link), which allows the browser to preload resources before the initial page is fetched and rendered. In standalone Blazor WebAssembly apps, framework assets are scheduled for high priority downloading and caching early in browser `index.html` page processing.

For more information, see <xref:blazor/fundamentals/static-files?view=aspnetcore-10.0#preloaded-blazor-framework-static-assets>.

## `NavigationManager.NavigateTo` no longer throws a `NavigationException`

Previously, calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> during static server-side rendering (SSR) would throw a <xref:Microsoft.AspNetCore.Components.NavigationException>, interrupting execution before being converted to a redirection response. This caused confusion during debugging and was inconsistent with interactive rendering, where code after <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> continues to execute normally.

Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> during static SSR no longer throws a <xref:Microsoft.AspNetCore.Components.NavigationException>. Instead, it behaves consistently with interactive rendering by performing the navigation without throwing an exception.

Code that relied on <xref:Microsoft.AspNetCore.Components.NavigationException> being thrown should be updated. For example, in the default Blazor Identity UI, the `IdentityRedirectManager` previously threw an <xref:System.InvalidOperationException> after calling `RedirectTo` to ensure it wasn't invoked during interactive rendering. This exception and the [`[DoesNotReturn]` attributes](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute) should now be removed.

!!!!!!!!! HOLD THE NEXT BIT FOR PREVIEW 5 !!!!!!!!!
To revert to the previous behavior of throwing a <xref:Microsoft.AspNetCore.Components.NavigationException>, set the following <xref:System.AppContext> switch:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Components.Endpoints.NavigationManager.EnableThrowNavigationException", 
    isEnabled: true);
```
!!!!!!!!! HOLD END !!!!!!!!!

-->
