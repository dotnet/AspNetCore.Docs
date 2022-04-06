---
title: ASP.NET Core Blazor routing and navigation
author: guardrex
description: Learn how to manage request routing in Blazor apps and how to use the Navigation Manager and NavLink component for navigation.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/routing
---
# ASP.NET Core Blazor routing and navigation

This article explains how to manage request routing and how to use the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component to create a navigation links in Blazor apps.

:::moniker range=">= aspnetcore-6.0"

## Route templates

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component enables routing to Razor components in a Blazor app. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component is used in the `App` component of Blazor apps.

`App.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/routing/App1.razor)]

When a Razor component (`.razor`) with an [`@page` directive](xref:mvc/views/razor#page) is compiled, the generated component class is provided a <xref:Microsoft.AspNetCore.Components.RouteAttribute> specifying the component's route template.

When the app starts, the assembly specified as the Router's `AppAssembly` is scanned to gather route information for the app's components that have a <xref:Microsoft.AspNetCore.Components.RouteAttribute>.

At runtime, the <xref:Microsoft.AspNetCore.Components.RouteView> component:

* Receives the <xref:Microsoft.AspNetCore.Components.RouteData> from the <xref:Microsoft.AspNetCore.Components.Routing.Router> along with any route parameters.
* Renders the specified component with its [layout](xref:blazor/components/layouts), including any further nested layouts.

Optionally specify a <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout> parameter with a layout class for components that don't specify a layout with the [`@layout` directive](xref:blazor/components/layouts#apply-a-layout-to-a-component). The framework's [Blazor project templates](xref:blazor/project-structure) specify the `MainLayout` component (`Shared/MainLayout.razor`) as the app's default layout. For more information on layouts, see <xref:blazor/components/layouts>.

Components support multiple route templates using multiple [`@page` directives](xref:mvc/views/razor#page). The following example component loads on requests for `/BlazorRoute` and `/DifferentBlazorRoute`.

`Pages/BlazorRoute.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor?highlight=1-2)]

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag in its `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Layout.cshtml` file (Blazor Server) with the app base path specified in the `href` attribute. For more information, see <xref:blazor/host-and-deploy/index#app-base-path>.

## Focus an element on navigation

Use the <xref:Microsoft.AspNetCore.Components.Routing.FocusOnNavigate> component to set the UI focus to an element based on a CSS selector after navigating from one page to another. You can see the <xref:Microsoft.AspNetCore.Components.Routing.FocusOnNavigate> component in use by the `App` component of an app generated from a Blazor project template.

`App.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <p role="alert">Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

When the preceding <xref:Microsoft.AspNetCore.Components.Routing.Router> component navigates to a new page, the <xref:Microsoft.AspNetCore.Components.Routing.FocusOnNavigate> component sets the focus to the page's top-level header (`<h1>`). This is a common strategy for ensuring that page navigations are announced when using a screen reader.

## Provide custom content when content isn't found

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component allows the app to specify custom content if content isn't found for the requested route.

In the `App` component, set custom content in the <xref:Microsoft.AspNetCore.Components.Routing.Router> component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template.

`App.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/routing/App2.razor?highlight=5-8)]

Arbitrary items are supported as content of the `<NotFound>` tags, such as other interactive components. To apply a default layout to <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content, see <xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component>.

## Route to components from multiple assemblies

Use the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter to specify additional assemblies for the <xref:Microsoft.AspNetCore.Components.Routing.Router> component to consider when searching for routable components. Additional assemblies are scanned in addition to the assembly specified to `AppAssembly`. In the following example, `Component1` is a routable component defined in a referenced [component class library](xref:blazor/components/class-libraries). The following <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> example results in routing support for `Component1`.

`App.razor`:

```razor
<Router
    AppAssembly="@typeof(Program).Assembly"
    AdditionalAssemblies="new[] { typeof(Component1).Assembly }">
    @* ... Router component elements ... *@
</Router>
```

## Route parameters

The router uses route parameters to populate the corresponding [component parameters](xref:blazor/components/index#component-parameters) with the same name. Route parameter names are case insensitive. In the following example, the `text` parameter assigns the value of the route segment to the component's `Text` property. When a request is made for `/RouteParameter/amazing`, the `<h1>` tag content is rendered as `Blazor is amazing!`.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor?highlight=1)]

Optional parameters are supported. In the following example, the `text` optional parameter assigns the value of the route segment to the component's `Text` property. If the segment isn't present, the value of `Text` is set to `fantastic`.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor?highlight=1)]

Use [`OnParametersSet`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) instead of [`OnInitialized{Async}`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) to permit app navigation to the same component with a different optional parameter value. Based on the preceding example, use `OnParametersSet` when the user should be able to navigate from `/RouteParameter` to `/RouteParameter/amazing` or from `/RouteParameter/amazing` to `/RouteParameter`:

```csharp
protected override void OnParametersSet()
{
    Text = Text ?? "fantastic";
}
```

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the `User` component only matches if:

* An `Id` route segment is present in the request URL.
* The `Id` segment is an integer (`int`) type.

`Pages/User.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/routing/User.razor?highlight=1)]

The route constraints shown in the following table are available. For the route constraints that match the invariant culture, see the warning below the table for more information.

| Constraint | Example           | Example Matches                                                                  | Invariant<br>culture<br>matching |
| ---------- | ----------------- | -------------------------------------------------------------------------------- | :------------------------------: |
| `bool`     | `{active:bool}`   | `true`, `FALSE`                                                                  | No                               |
| `datetime` | `{dob:datetime}`  | `2016-12-31`, `2016-12-31 7:32pm`                                                | Yes                              |
| `decimal`  | `{price:decimal}` | `49.99`, `-1,000.01`                                                             | Yes                              |
| `double`   | `{weight:double}` | `1.234`, `-1,001.01e8`                                                           | Yes                              |
| `float`    | `{weight:float}`  | `1.234`, `-1,001.01e8`                                                           | Yes                              |
| `guid`     | `{id:guid}`       | `CD2C1638-1638-72D5-1638-DEADBEEF1638`, `{CD2C1638-1638-72D5-1638-DEADBEEF1638}` | No                               |
| `int`      | `{id:int}`        | `123456789`, `-123456789`                                                        | Yes                              |
| `long`     | `{ticks:long}`    | `123456789`, `-123456789`                                                        | Yes                              |

> [!WARNING]
> Route constraints that verify the URL and are converted to a CLR type (such as `int` or <xref:System.DateTime>) always use the invariant culture. These constraints assume that the URL is non-localizable.

Route constraints also work with [optional parameters](#route-parameters). In the following example, `Id` is required, but `Option` is an optional boolean route parameter.

`Pages/User.razor`:

```razor
@page "/user/{Id:int}/{Option:bool?}"

<p>
    Id: @Id
</p>

<p>
    Option: @Option
</p>

@code {
    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public bool Option { get; set; }
}
```

## Routing with URLs that contain dots

For hosted Blazor WebAssembly and Blazor Server apps, the server-side default route template assumes that if the last segment of a request URL contains a dot (`.`) that a file is requested. For example, the URL `https://localhost.com:5001/example/some.thing` is interpreted by the router as a request for a file named `some.thing`. Without additional configuration, an app returns a *404 - Not Found* response if `some.thing` was meant to route to a component with an [`@page`](xref:mvc/views/razor#page) directive and `some.thing` is a route parameter value. To use a route with one or more parameters that contain a dot, the app must configure the route with a custom template.

Consider the following `Example` component that can receive a route parameter from the last segment of the URL.

`Pages/Example.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/routing/Example.razor?highlight=1)]

To permit the **`Server`** app of a hosted Blazor WebAssembly solution to route the request with a dot in the `param` route parameter, add a fallback file route template with the optional parameter in `Program.cs`:

```csharp
app.MapFallbackToFile("/example/{param?}", "index.html");
```

To configure a Blazor Server app to route the request with a dot in the `param` route parameter, add a fallback page route template with the optional parameter in `Program.cs`:

```csharp
app.MapFallbackToPage("/example/{param?}", "/_Host");
```

For more information, see <xref:fundamentals/routing>.

## Catch-all route parameters

Catch-all route parameters, which capture paths across multiple folder boundaries, are supported in components.

Catch-all route parameters are:

* Named to match the route segment name. Naming isn't case sensitive.
* A `string` type. The framework doesn't provide automatic casting.
* At the end of the URL.

`Pages/CatchAll.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/routing/CatchAll.razor)]

For the URL `/catch-all/this/is/a/test` with a route template of `/catch-all/{*pageRoute}`, the value of `PageRoute` is set to `this/is/a/test`.

Slashes and segments of the captured path are decoded. For a route template of `/catch-all/{*pageRoute}`, the URL `/catch-all/this/is/a%2Ftest%2A` yields `this/is/a/test*`.

## URI and navigation state helpers

Use <xref:Microsoft.AspNetCore.Components.NavigationManager> to manage URIs and navigation in C# code. <xref:Microsoft.AspNetCore.Components.NavigationManager> provides the event and methods shown in the following table.

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element in `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Given a base URI (for example, a URI previously returned by <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri>), converts an absolute URI into a URI relative to the base URI prefix. |
| <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section. |

## Location changes

For the <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> event, <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs> provides the following information about navigation events:

* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.Location>: The URL of the new location.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.IsNavigationIntercepted>: If `true`, Blazor intercepted the navigation from the browser. If `false`, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> caused the navigation to occur.

The following component:

* Navigates to the app's `Counter` component (`Pages/Counter.razor`) when the button is selected using <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A>.
* Handles the location changed event by subscribing to <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged?displayProperty=nameWithType>.
  * The `HandleLocationChanged` method is unhooked when `Dispose` is called by the framework. Unhooking the method permits garbage collection of the component.
  * The logger implementation logs the following information when the button is selected:

    > `BlazorSample.Pages.Navigate: Information: URL of new location: https://localhost:5001/counter`

`Pages/Navigate.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/routing/Navigate.razor)]

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

## Query strings

Use the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute) with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute) to specify that a component parameter of a routable component can come from the query string.

> [!NOTE]
> Component parameters can only receive query parameter values in routable components with an [`@page`](xref:mvc/views/razor#page) directive.

Component parameters supplied from the query string support the following types:

* `bool`, `DateTime`, `decimal`, `double`, `float`, `Guid`, `int`, `long`, `string`.
* Nullable variants of the preceding types.
* Arrays of the preceding types, whether they're nullable or not nullable.

The correct culture-invariant formatting is applied for the given type (<xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType>).

Specify the `[SupplyParameterFromQuery]` attribute's <xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute.Name> property to use a query parameter name different from the component parameter name. In the following example, the C# name of the component parameter is `{COMPONENT PARAMETER NAME}`. A different query parameter name is specified for the `{QUERY PARAMETER NAME}` placeholder:

```csharp
[Parameter]
[SupplyParameterFromQuery(Name = "{QUERY PARAMETER NAME}")]
public string? {COMPONENT PARAMETER NAME} { get; set; }
```

In the following example with a URL of `/search?filter=scifi%20stars&page=3&star=LeVar%20Burton&star=Gary%20Oldman`:

* The `Filter` property resolves to `scifi stars`.
* The `Page` property resolves to `3`.
* The `Stars` array is filled from query parameters named `star` (`Name = "star"`) and resolves to `LeVar Burton` and `Gary Oldman`.

`Pages/Search.razor`:

```razor
@page "/search"

<h1>Search Example</h1>

<p>Filter: @Filter</p>

<p>Page: @Page</p>

@if (Stars is not null)
{
    <p>Assignees:</p>

    <ul>
        @foreach (var name in Stars)
        {
            <li>@name</li>
        }
    </ul>
}

@code {
    [Parameter]
    [SupplyParameterFromQuery]
    public string? Filter { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public int? Page { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "star")]
    public string[]? Stars { get; set; }
}
```

Use [`NavigationManager.GetUriWithQueryParameter`](xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A) to add, change, or remove one or more query parameters on the current URL:

```razor
@inject NavigationManager NavigationManager

...

NavigationManager.GetUriWithQueryParameter("{NAME}", {VALUE})
```

For the preceding example:

* The `{NAME}` placeholder specifies the query parameter name. The `{VALUE}` placeholder specifies the value as a supported type. Supported types are listed later in this section.
* A string is returned equal to the current URL with a single parameter:
  * Added if the query parameter name doesn't exist in the current URL.
  * Updated to the value provided if the query parameter exists in the current URL.
  * Removed if the type of the provided value is nullable and the value is `null`.
* The correct culture-invariant formatting is applied for the given type (<xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType>).
* The query parameter name and value are URL-encoded.
* All of the values with the matching query parameter name are replaced if there are multiple instances of the type.

Call [`NavigationManager.GetUriWithQueryParameters`](xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameters%2A) to create a URI constructed from <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> with multiple parameters added, updated, or removed. For each value, the framework uses `value?.GetType()` to determine the runtime type for each query parameter and selects the correct culture-invariant formatting. The framework throws an error for unsupported types.

```razor
@inject NavigationManager NavigationManager

...

NavigationManager.GetUriWithQueryParameters({PARAMETERS})
```

The `{PARAMETERS}` placeholder is an `IReadOnlyDictionary<string, object>`.

Pass a URI string to <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameters%2A> to generate a new URI from a provided URI with multiple parameters added, updated, or removed. For each value, the framework uses `value?.GetType()` to determine the runtime type for each query parameter and selects the correct culture-invariant formatting. The framework throws an error for unsupported types. Supported types are listed later in this section.

```razor
@inject NavigationManager NavigationManager

...

NavigationManager.GetUriWithQueryParameters("{URI}", {PARAMETERS})
```

* The `{URI}` placeholder is the URI with or without a query string.
* The `{PARAMETERS}` placeholder is an `IReadOnlyDictionary<string, object>`.

Supported types are identical to supported types for route constraints:

* `bool`
* `DateTime`
* `decimal`
* `double`
* `float`
* `Guid`
* `int`
* `long`
* `string`

Supported types include:

* Nullable variants of the preceding types.
* Arrays of the preceding types, whether they're nullable or not nullable.

### Replace a query parameter value when the parameter exists

```csharp
NavigationManager.GetUriWithQueryParameter("full name", "Morena Baccarin")
```

| Current URL | Generated URL |
| --- | --- |
| `scheme://host/?full%20name=David%20Krumholtz&age=42` | `scheme://host/?full%20name=Morena%20Baccarin&age=42` |
| `scheme://host/?fUlL%20nAmE=David%20Krumholtz&AgE=42` | `scheme://host/?full%20name=Morena%20Baccarin&AgE=42` |
| `scheme://host/?full%20name=Jewel%20Staite&age=42&full%20name=Summer%20Glau` | `scheme://host/?full%20name=Morena%20Baccarin&age=42&full%20name=Morena%20Baccarin` |
| `scheme://host/?full%20name=&age=42` | `scheme://host/?full%20name=Morena%20Baccarin&age=42` |
| `scheme://host/?full%20name=` | `scheme://host/?full%20name=Morena%20Baccarin` |

### Append a query parameter and value when the parameter doesn't exist

```csharp
NavigationManager.GetUriWithQueryParameter("name", "Morena Baccarin")
```

| Current URL | Generated URL |
| --- | --- |
| `scheme://host/?age=42` | `scheme://host/?age=42&name=Morena%20Baccarin` |
| `scheme://host/` | `scheme://host/?name=Morena%20Baccarin` |
| `scheme://host/?` | `scheme://host/?name=Morena%20Baccarin` |

### Remove a query parameter when the parameter value is `null`

```csharp
NavigationManager.GetUriWithQueryParameter("full name", (string)null)
```

| Current URL | Generated URL |
| --- | --- |
| `scheme://host/?full%20name=David%20Krumholtz&age=42` | `scheme://host/?age=42` |
| `scheme://host/?full%20name=Sally%20Smith&age=42&full%20name=Summer%20Glau` | `scheme://host/?age=42` |
| `scheme://host/?full%20name=Sally%20Smith&age=42&FuLl%20NaMe=Summer%20Glau` | `scheme://host/?age=42` |
| `scheme://host/?full%20name=&age=42` | `scheme://host/?age=42` |
| `scheme://host/?full%20name=` | `scheme://host/` |

### Add, update, and remove query parameters

In the following example:

* `name` is removed, if present.
* `age` is added with a value of `25` (`int`), if not present. If present, `age` is updated to a value of `25`.
* `eye color` is added or updated to a value of `green`.

```csharp
NavigationManager.GetUriWithQueryParameters(
    new Dictionary<string, object>
    {
        ["name"] = null,
        ["age"] = (int?)25,
        ["eye color"] = "green"
    })
```

| Current URL | Generated URL |
| --- | --- |
| `scheme://host/?name=David%20Krumholtz&age=42` | `scheme://host/?age=25&eye%20color=green` |
| `scheme://host/?NaMe=David%20Krumholtz&AgE=42` | `scheme://host/?age=25&eye%20color=green` |
| `scheme://host/?name=David%20Krumholtz&age=42&keepme=true` | `scheme://host/?age=25&keepme=true&eye%20color=green` |
| `scheme://host/?age=42&eye%20color=87` | `scheme://host/?age=25&eye%20color=green` |
| `scheme://host/?` | `scheme://host/?age=25&eye%20color=green` |
| `scheme://host/` | `scheme://host/?age=25&eye%20color=green` |

### Support for enumerable values

In the following example:

* `full name` is added or updated to `Morena Baccarin`, a single value.
* `ping` parameters are added or replaced with `35`, `16`, `87` and `240`.

```csharp
NavigationManager.GetUriWithQueryParameters(
    new Dictionary<string, object>
    {
        ["full name"] = "Morena Baccarin",
        ["ping"] = new int?[] { 35, 16, null, 87, 240 }
    })
```

| Current URL | Generated URL |
| --- | --- |
| `scheme://host/?full%20name=David%20Krumholtz&ping=8&ping=300` | `scheme://host/?full%20name=Morena%20Baccarin&ping=35&ping=16&ping=87&ping=240` |
| `scheme://host/?ping=8&full%20name=David%20Krumholtz&ping=300` | `scheme://host/?ping=35&full%20name=Morena%20Baccarin&ping=16&ping=87&ping=240` |
| `scheme://host/?ping=8&ping=300&ping=50&ping=68&ping=42` | `scheme://host/?ping=35&ping=16&ping=87&ping=240&full%20name=Morena%20Baccarin` |

### Navigate with an added or modified query string

To navigate with an added or modified query string, pass a generated URL to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A>.

The following example calls:

* <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> to add or replace the `name` query parameter using a value of `Morena Baccarin`.
* Calls <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> to trigger navigation to the new URL.

```csharp
NavigationManager.NavigateTo(
    NavigationManager.GetUriWithQueryParameter("name", "Morena Baccarin"));
```

## User interaction with `<Navigating>` content

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component can indicate to the user that a page transition is occurring.

At the top of the `App` component (`App.razor`), add an [`@using`](xref:mvc/views/razor#using) directive for the <xref:Microsoft.AspNetCore.Components.Routing?displayProperty=fullName> namespace:

```razor
@using Microsoft.AspNetCore.Components.Routing
```

Add a `<Navigating>` tag to the component with markup to display during page transition events. For more information, see <xref:Microsoft.AspNetCore.Components.Routing.Router.Navigating> (API documentation).

In the router element content (`<Router>...</Router>`) of the `App` component (`App.razor`):

```razor
<Navigating>
    <p>Loading the requested page&hellip;</p>
</Navigating>
```

For an example that uses the <xref:Microsoft.AspNetCore.Components.Routing.Router.Navigating> property, see <xref:blazor/webassembly-lazy-load-assemblies#user-interaction-with-navigating-content>.

## Handle asynchronous navigation events with `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component supports an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> feature. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> handler is invoked when the user:

* Visits a route for the first time by navigating to it directly in their browser.
* Navigates to a new route using a link or a <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> invocation.

In the `App` component (`App.razor`):

```razor
<Router AppAssembly="@typeof(Program).Assembly" 
    OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private async Task OnNavigateAsync(NavigationContext args)
    {
        ...
    }
}
```

For an example that uses <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync>, see <xref:blazor/webassembly-lazy-load-assemblies>.

When prerendering on the server in a Blazor Server app or hosted Blazor WebAssembly app, <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice*:

* Once when the requested endpoint component is initially rendered statically.
* A second time when the browser renders the endpoint component.

To prevent developer code in <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> from executing twice, the `App` component can store the <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> for use in [`OnAfterRender`/`OnAfterRenderAsync`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync), where `firstRender` can be checked. For more information, see [Detect when the app is prerendering](xref:blazor/components/lifecycle#detect-when-the-app-is-prerendering) in the *Blazor Lifecycle* article.

## Handle cancellations in `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> object passed to the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback contains a <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken> that's set when a new navigation event occurs. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback must throw when this cancellation token is set to avoid continuing to run the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback on a outdated navigation.

If a user navigates to an endpoint but then immediately navigates to a new endpoint, the app shouldn't continue running the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback for the first endpoint.

In the following `App` component example:

* The cancellation token is passed in the call to `PostAsJsonAsync`, which can cancel the POST if the user navigates away from the `/about` endpoint.
* The cancellation token is set during a product prefetch operation if the user navigates away from the `/store` endpoint.

`App.razor`:

```razor
@inject HttpClient Http
@inject ProductCatalog Products

<Router AppAssembly="@typeof(Program).Assembly" 
    OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private async Task OnNavigateAsync(NavigationContext context)
    {
        if (context.Path == "/about") 
        {
            var stats = new Stats = { Page = "/about" };
            await Http.PostAsJsonAsync("api/visited", stats, 
                context.CancellationToken);
        }
        else if (context.Path == "/store")
        {
            var productIds = [345, 789, 135, 689];

            foreach (var productId in productIds) 
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                Products.Prefetch(productId);
            }
        }
    }
}
```

> [!NOTE]
> Not throwing if the cancellation token in <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> is canceled can result in unintended behavior, such as rendering a component from a previous navigation.

## `NavLink` and `NavMenu` components

Use a <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component in place of HTML hyperlink elements (`<a>`) when creating navigation links. A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. Optionally, assign a CSS class name to <xref:Microsoft.AspNetCore.Components.Routing.NavLink.ActiveClass?displayProperty=nameWithType> to apply a custom CSS class to the rendered link when the current route matches the `href`.

> [!NOTE]
> The `NavMenu` component (`NavMenu.razor`) is provided in the `Shared` folder of an app generated from the [Blazor project templates](xref:blazor/project-structure).

There are two <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch> options that you can assign to the `Match` attribute of the `<NavLink>` element:

* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType>: The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches the entire current URL.
* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.Prefix?displayProperty=nameWithType> (*default*): The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches any prefix of the current URL.

In the preceding example, the Home <xref:Microsoft.AspNetCore.Components.Routing.NavLink> `href=""` matches the home URL and only receives the `active` CSS class at the app's default base path URL (for example, `https://localhost:5001/`). The second <xref:Microsoft.AspNetCore.Components.Routing.NavLink> receives the `active` class when the user visits any URL with a `component` prefix (for example, `https://localhost:5001/component` and `https://localhost:5001/component/another-segment`).

Additional <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component attributes are passed through to the rendered anchor tag. In the following example, the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component includes the `target` attribute:

```razor
<NavLink href="example-page" target="_blank">Example page</NavLink>
```

The following HTML markup is rendered:

```html
<a href="example-page" target="_blank">Example page</a>
```

> [!WARNING]
> Due to the way that Blazor renders child content, rendering `NavLink` components inside a `for` loop requires a local index variable if the incrementing loop variable is used in the `NavLink` (child) component's content:
>
> ```razor
> @for (int c = 0; c < 10; c++)
> {
>     var current = c;
>     <li ...>
>         <NavLink ... href="@c">
>             <span ...></span> @current
>         </NavLink>
>     </li>
> }
> ```
>
> Using an index variable in this scenario is a requirement for **any** child component that uses a loop variable in its [child content](xref:blazor/components/index#child-content), not just the `NavLink` component.
>
> Alternatively, use a `foreach` loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType>:
>
> ```razor
> @foreach (var c in Enumerable.Range(0,10))
> {
>     <li ...>
>         <NavLink ... href="@c">
>             <span ...></span> @c
>         </NavLink>
>     </li>
> }
> ```

## ASP.NET Core endpoint routing integration

*This section only applies to Blazor Server apps.*

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in `Program.cs`:

```csharp
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
```

The typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named `_Host.cshtml` in the `Pages` folder of the app.

The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is used when other routes don't match. This allows the app to use other controllers and pages without interfering with component routing in the Blazor Server app.

<!-- HOLD
For information on configuring <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for non-root URL server hosting, see <xref:blazor/host-and-deploy/index#app-base-path>.
-->

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

This article explains how to manage request routing and how to use the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component to create a navigation links in Blazor apps.

## Route templates

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component enables routing to Razor components in a Blazor app. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component is used in the `App` component of Blazor apps.

`App.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/routing/App1.razor)]

When a Razor component (`.razor`) with an [`@page` directive](xref:mvc/views/razor#page) is compiled, the generated component class is provided a <xref:Microsoft.AspNetCore.Components.RouteAttribute> specifying the component's route template.

When the app starts, the assembly specified as the Router's `AppAssembly` is scanned to gather route information for the app's components that have a <xref:Microsoft.AspNetCore.Components.RouteAttribute>.

At runtime, the <xref:Microsoft.AspNetCore.Components.RouteView> component:

* Receives the <xref:Microsoft.AspNetCore.Components.RouteData> from the <xref:Microsoft.AspNetCore.Components.Routing.Router> along with any route parameters.
* Renders the specified component with its [layout](xref:blazor/components/layouts), including any further nested layouts.

Optionally specify a <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout> parameter with a layout class for components that don't specify a layout with the [`@layout` directive](xref:blazor/components/layouts#apply-a-layout-to-a-component). The framework's [Blazor project templates](xref:blazor/project-structure) specify the `MainLayout` component (`Shared/MainLayout.razor`) as the app's default layout. For more information on layouts, see <xref:blazor/components/layouts>.

Components support multiple route templates using multiple [`@page` directives](xref:mvc/views/razor#page). The following example component loads on requests for `/BlazorRoute` and `/DifferentBlazorRoute`.

`Pages/BlazorRoute.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor?highlight=1-2)]

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag in its `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server) with the app base path specified in the `href` attribute. For more information, see <xref:blazor/host-and-deploy/index#app-base-path>.

The <xref:Microsoft.AspNetCore.Components.Routing.Router> doesn't interact with query string values. To work with query strings, see the [Query string and parse parameters](#query-string-and-parse-parameters) section.

## Provide custom content when content isn't found

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component allows the app to specify custom content if content isn't found for the requested route.

In the `App` component, set custom content in the <xref:Microsoft.AspNetCore.Components.Routing.Router> component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template.

`App.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/routing/App2.razor?highlight=5-8)]

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

Arbitrary items are supported as content of the `<NotFound>` tags, such as other interactive components. To apply a default layout to <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content, see <xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component>.

## Route to components from multiple assemblies

Use the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter to specify additional assemblies for the <xref:Microsoft.AspNetCore.Components.Routing.Router> component to consider when searching for routable components. Additional assemblies are scanned in addition to the assembly specified to `AppAssembly`. In the following example, `Component1` is a routable component defined in a referenced [component class library](xref:blazor/components/class-libraries). The following <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> example results in routing support for `Component1`.

`App.razor`:

```razor
<Router
    AppAssembly="@typeof(Program).Assembly"
    AdditionalAssemblies="new[] { typeof(Component1).Assembly }">
    @* ... Router component elements ... *@
</Router>
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

## Route parameters

The router uses route parameters to populate the corresponding [component parameters](xref:blazor/components/index#component-parameters) with the same name. Route parameter names are case insensitive. In the following example, the `text` parameter assigns the value of the route segment to the component's `Text` property. When a request is made for `/RouteParameter/amazing`, the `<h1>` tag content is rendered as `Blazor is amazing!`.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor?highlight=1)]

Optional parameters are supported. In the following example, the `text` optional parameter assigns the value of the route segment to the component's `Text` property. If the segment isn't present, the value of `Text` is set to `fantastic`.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor?highlight=1)]

Use [`OnParametersSet`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) instead of [`OnInitialized{Async}`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) to permit app navigation to the same component with a different optional parameter value. Based on the preceding example, use `OnParametersSet` when the user should be able to navigate from `/RouteParameter` to `/RouteParameter/amazing` or from `/RouteParameter/amazing` to `/RouteParameter`:

```csharp
protected override void OnParametersSet()
{
    Text = Text ?? "fantastic";
}
```

> [!NOTE]
> Route parameters don't work with query string values. To work with query strings, see the [Query string and parse parameters](#query-string-and-parse-parameters) section.

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the `User` component only matches if:

* An `Id` route segment is present in the request URL.
* The `Id` segment is an integer (`int`) type.

`Pages/User.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/routing/User.razor?highlight=1)]

> [!NOTE]
> Route constraints don't work with query string values. To work with query strings, see the [Query string and parse parameters](#query-string-and-parse-parameters) section.

The route constraints shown in the following table are available. For the route constraints that match the invariant culture, see the warning below the table for more information.

| Constraint | Example           | Example Matches                                                                  | Invariant<br>culture<br>matching |
| ---------- | ----------------- | -------------------------------------------------------------------------------- | :------------------------------: |
| `bool`     | `{active:bool}`   | `true`, `FALSE`                                                                  | No                               |
| `datetime` | `{dob:datetime}`  | `2016-12-31`, `2016-12-31 7:32pm`                                                | Yes                              |
| `decimal`  | `{price:decimal}` | `49.99`, `-1,000.01`                                                             | Yes                              |
| `double`   | `{weight:double}` | `1.234`, `-1,001.01e8`                                                           | Yes                              |
| `float`    | `{weight:float}`  | `1.234`, `-1,001.01e8`                                                           | Yes                              |
| `guid`     | `{id:guid}`       | `CD2C1638-1638-72D5-1638-DEADBEEF1638`, `{CD2C1638-1638-72D5-1638-DEADBEEF1638}` | No                               |
| `int`      | `{id:int}`        | `123456789`, `-123456789`                                                        | Yes                              |
| `long`     | `{ticks:long}`    | `123456789`, `-123456789`                                                        | Yes                              |

> [!WARNING]
> Route constraints that verify the URL and are converted to a CLR type (such as `int` or <xref:System.DateTime>) always use the invariant culture. These constraints assume that the URL is non-localizable.

Route constraints also work with [optional parameters](#route-parameters). In the following example, `Id` is required, but `Option` is an optional boolean route parameter.

`Pages/User.razor`:

```razor
@page "/user/{Id:int}/{Option:bool?}"

<p>
    Id: @Id
</p>

<p>
    Option: @Option
</p>

@code {
    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public bool Option { get; set; }
}
```

## Routing with URLs that contain dots

For hosted Blazor WebAssembly and Blazor Server apps, the server-side default route template assumes that if the last segment of a request URL contains a dot (`.`) that a file is requested. For example, the URL `https://localhost.com:5001/example/some.thing` is interpreted by the router as a request for a file named `some.thing`. Without additional configuration, an app returns a *404 - Not Found* response if `some.thing` was meant to route to a component with an [`@page` directive](xref:mvc/views/razor#page) and `some.thing` is a route parameter value. To use a route with one or more parameters that contain a dot, the app must configure the route with a custom template.

Consider the following `Example` component that can receive a route parameter from the last segment of the URL.

`Pages/Example.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/routing/Example.razor?highlight=1)]

To permit the **`Server`** app of a hosted Blazor WebAssembly solution to route the request with a dot in the `param` route parameter, add a fallback file route template with the optional parameter in `Startup.Configure`.

`Startup.cs`:

```csharp
endpoints.MapFallbackToFile("/example/{param?}", "index.html");
```

To configure a Blazor Server app to route the request with a dot in the `param` route parameter, add a fallback page route template with the optional parameter in `Startup.Configure`.

`Startup.cs`:

```csharp
endpoints.MapFallbackToPage("/example/{param?}", "/_Host");
```

For more information, see <xref:fundamentals/routing>.

## Catch-all route parameters

Catch-all route parameters, which capture paths across multiple folder boundaries, are supported in components.

Catch-all route parameters are:

* Named to match the route segment name. Naming isn't case sensitive.
* A `string` type. The framework doesn't provide automatic casting.
* At the end of the URL.

`Pages/CatchAll.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/routing/CatchAll.razor)]

For the URL `/catch-all/this/is/a/test` with a route template of `/catch-all/{*pageRoute}`, the value of `PageRoute` is set to `this/is/a/test`.

Slashes and segments of the captured path are decoded. For a route template of `/catch-all/{*pageRoute}`, the URL `/catch-all/this/is/a%2Ftest%2A` yields `this/is/a/test*`.

## URI and navigation state helpers

Use <xref:Microsoft.AspNetCore.Components.NavigationManager> to manage URIs and navigation in C# code. <xref:Microsoft.AspNetCore.Components.NavigationManager> provides the event and methods shown in the following table.

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element in `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Given a base URI (for example, a URI previously returned by <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri>), converts an absolute URI into a URI relative to the base URI prefix. |

For the <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> event, <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs> provides the following information about navigation events:

* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.Location>: The URL of the new location.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.IsNavigationIntercepted>: If `true`, Blazor intercepted the navigation from the browser. If `false`, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> caused the navigation to occur.

The following component:

* Navigates to the app's `Counter` component (`Pages/Counter.razor`) when the button is selected using <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A>.
* Handles the location changed event by subscribing to <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged?displayProperty=nameWithType>.
  * The `HandleLocationChanged` method is unhooked when `Dispose` is called by the framework. Unhooking the method permits garbage collection of the component.
  * The logger implementation logs the following information when the button is selected:

    > `BlazorSample.Pages.Navigate: Information: URL of new location: https://localhost:5001/counter`

`Pages/Navigate.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/routing/Navigate.razor)]

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

## Query string and parse parameters

The query string of a request is obtained from the <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> property:

```razor
@inject NavigationManager NavigationManager

...

var query = new Uri(NavigationManager.Uri).Query;
```

To parse a query string's parameters, one approach is to use [`URLSearchParams`](https://developer.mozilla.org/docs/Web/API/URLSearchParams) with [JavaScript (JS) interop](xref:blazor/js-interop/call-javascript-from-dotnet):

```javascript
export createQueryString = (string queryString) => new URLSearchParams(queryString);
```

For more information on JavaScript isolation with JavaScript modules, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

## User interaction with `<Navigating>` content

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component can indicate to the user that a page transition is occurring.

At the top of the `App` component (`App.razor`), add an [`@using`](xref:mvc/views/razor#using) directive for the <xref:Microsoft.AspNetCore.Components.Routing?displayProperty=fullName> namespace:

```razor
@using Microsoft.AspNetCore.Components.Routing
```

Add a `<Navigating>` tag to the component with markup to display during page transition events. For more information, see <xref:Microsoft.AspNetCore.Components.Routing.Router.Navigating> (API documentation).

In the router element content (`<Router>...</Router>`) of the `App` component (`App.razor`):

```razor
<Navigating>
    <p>Loading the requested page&hellip;</p>
</Navigating>
```

For an example that uses the <xref:Microsoft.AspNetCore.Components.Routing.Router.Navigating> property, see <xref:blazor/webassembly-lazy-load-assemblies#user-interaction-with-navigating-content>.

## Handle asynchronous navigation events with `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component supports an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> feature. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> handler is invoked when the user:

* Visits a route for the first time by navigating to it directly in their browser.
* Navigates to a new route using a link or a <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> invocation.

In the `App` component (`App.razor`):

```razor
<Router AppAssembly="@typeof(Program).Assembly" 
    OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private async Task OnNavigateAsync(NavigationContext args)
    {
        ...
    }
}
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

For an example that uses <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync>, see <xref:blazor/webassembly-lazy-load-assemblies>.

When prerendering on the server in a Blazor Server app or hosted Blazor WebAssembly app, <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice*:

* Once when the requested endpoint component is initially rendered statically.
* A second time when the browser renders the endpoint component.

To prevent developer code in <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> from executing twice, the `App` component can store the <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> for use in [`OnAfterRender`/`OnAfterRenderAsync`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync), where `firstRender` can be checked. For more information, see [Detect when the app is prerendering](xref:blazor/components/lifecycle#detect-when-the-app-is-prerendering) in the *Blazor Lifecycle* article.

## Handle cancellations in `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> object passed to the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback contains a <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken> that's set when a new navigation event occurs. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback must throw when this cancellation token is set to avoid continuing to run the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback on a outdated navigation.

If a user navigates to an endpoint but then immediately navigates to a new endpoint, the app shouldn't continue running the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback for the first endpoint.

In the following `App` component example:

* The cancellation token is passed in the call to `PostAsJsonAsync`, which can cancel the POST if the user navigates away from the `/about` endpoint.
* The cancellation token is set during a product prefetch operation if the user navigates away from the `/store` endpoint.

`App.razor`:

```razor
@inject HttpClient Http
@inject ProductCatalog Products

<Router AppAssembly="@typeof(Program).Assembly" 
    OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private async Task OnNavigateAsync(NavigationContext context)
    {
        if (context.Path == "/about") 
        {
            var stats = new Stats = { Page = "/about" };
            await Http.PostAsJsonAsync("api/visited", stats, 
                context.CancellationToken);
        }
        else if (context.Path == "/store")
        {
            var productIds = [345, 789, 135, 689];

            foreach (var productId in productIds) 
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                Products.Prefetch(productId);
            }
        }
    }
}
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

> [!NOTE]
> Not throwing if the cancellation token in <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> is canceled can result in unintended behavior, such as rendering a component from a previous navigation.

## `NavLink` and `NavMenu` components

Use a <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component in place of HTML hyperlink elements (`<a>`) when creating navigation links. A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. Optionally, assign a CSS class name to <xref:Microsoft.AspNetCore.Components.Routing.NavLink.ActiveClass?displayProperty=nameWithType> to apply a custom CSS class to the rendered link when the current route matches the `href`.

> [!NOTE]
> The `NavMenu` component (`NavMenu.razor`) is provided in the `Shared` folder of an app generated from the [Blazor project templates](xref:blazor/project-structure).

There are two <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch> options that you can assign to the `Match` attribute of the `<NavLink>` element:

* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType>: The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches the entire current URL.
* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.Prefix?displayProperty=nameWithType> (*default*): The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches any prefix of the current URL.

In the preceding example, the Home <xref:Microsoft.AspNetCore.Components.Routing.NavLink> `href=""` matches the home URL and only receives the `active` CSS class at the app's default base path URL (for example, `https://localhost:5001/`). The second <xref:Microsoft.AspNetCore.Components.Routing.NavLink> receives the `active` class when the user visits any URL with a `component` prefix (for example, `https://localhost:5001/component` and `https://localhost:5001/component/another-segment`).

Additional <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component attributes are passed through to the rendered anchor tag. In the following example, the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component includes the `target` attribute:

```razor
<NavLink href="example-page" target="_blank">Example page</NavLink>
```

The following HTML markup is rendered:

```html
<a href="example-page" target="_blank">Example page</a>
```

> [!WARNING]
> Due to the way that Blazor renders child content, rendering `NavLink` components inside a `for` loop requires a local index variable if the incrementing loop variable is used in the `NavLink` (child) component's content:
>
> ```razor
> @for (int c = 0; c < 10; c++)
> {
>     var current = c;
>     <li ...>
>         <NavLink ... href="@c">
>             <span ...></span> @current
>         </NavLink>
>     </li>
> }
> ```
>
> Using an index variable in this scenario is a requirement for **any** child component that uses a loop variable in its [child content](xref:blazor/components/index#child-content), not just the `NavLink` component.
>
> Alternatively, use a `foreach` loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType>:
>
> ```razor
> @foreach (var c in Enumerable.Range(0,10))
> {
>     <li ...>
>         <NavLink ... href="@c">
>             <span ...></span> @c
>         </NavLink>
>     </li>
> }
> ```

## ASP.NET Core endpoint routing integration

*This section only applies to Blazor Server apps.*

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in `Startup.Configure`.

`Startup.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_Server/routing/Startup.cs?highlight=11)]

The typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named `_Host.cshtml` in the `Pages` folder of the app.

The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is used when other routes don't match. This allows the app to use other controllers and pages without interfering with component routing in the Blazor Server app.

<!-- HOLD
For information on configuring <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for non-root URL server hosting, see <xref:blazor/host-and-deploy/index#app-base-path>.
-->

:::moniker-end

:::moniker range="< aspnetcore-5.0"

This article explains how to manage request routing and how to use the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component to create a navigation links in Blazor apps.

## Route templates

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component enables routing to Razor components in a Blazor app. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component is used in the `App` component of Blazor apps.

`App.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/routing/App1.razor)]

When a Razor component (`.razor`) with an [`@page` directive](xref:mvc/views/razor#page) is compiled, the generated component class is provided a <xref:Microsoft.AspNetCore.Components.RouteAttribute> specifying the component's route template.

When the app starts, the assembly specified as the Router's `AppAssembly` is scanned to gather route information for the app's components that have a <xref:Microsoft.AspNetCore.Components.RouteAttribute>.

At runtime, the <xref:Microsoft.AspNetCore.Components.RouteView> component:

* Receives the <xref:Microsoft.AspNetCore.Components.RouteData> from the <xref:Microsoft.AspNetCore.Components.Routing.Router> along with any route parameters.
* Renders the specified component with its [layout](xref:blazor/components/layouts), including any further nested layouts.

Optionally specify a <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout> parameter with a layout class for components that don't specify a layout with the [`@layout` directive](xref:blazor/components/layouts#apply-a-layout-to-a-component). The framework's [Blazor project templates](xref:blazor/project-structure) specify the `MainLayout` component (`Shared/MainLayout.razor`) as the app's default layout. For more information on layouts, see <xref:blazor/components/layouts>.

Components support multiple route templates using multiple [`@page` directives](xref:mvc/views/razor#page). The following example component loads on requests for `/BlazorRoute` and `/DifferentBlazorRoute`.

`Pages/BlazorRoute.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor?highlight=1-2)]

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag in its `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server) with the app base path specified in the `href` attribute. For more information, see <xref:blazor/host-and-deploy/index#app-base-path>.

The <xref:Microsoft.AspNetCore.Components.Routing.Router> doesn't interact with query string values. To work with query strings, see the [Query string and parse parameters](#query-string-and-parse-parameters) section.

## Provide custom content when content isn't found

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component allows the app to specify custom content if content isn't found for the requested route.

In the `App` component, set custom content in the <xref:Microsoft.AspNetCore.Components.Routing.Router> component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template.

`App.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/routing/App2.razor?highlight=5-8)]

Arbitrary items are supported as content of the `<NotFound>` tags, such as other interactive components. To apply a default layout to <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content, see <xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component>.

## Route to components from multiple assemblies

Use the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter to specify additional assemblies for the <xref:Microsoft.AspNetCore.Components.Routing.Router> component to consider when searching for routable components. Additional assemblies are scanned in addition to the assembly specified to `AppAssembly`. In the following example, `Component1` is a routable component defined in a referenced [component class library](xref:blazor/components/class-libraries). The following <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> example results in routing support for `Component1`.

`App.razor`:

```razor
<Router
    AppAssembly="@typeof(Program).Assembly"
    AdditionalAssemblies="new[] { typeof(Component1).Assembly }">
    @* ... Router component elements ... *@
</Router>
```

## Route parameters

The router uses route parameters to populate the corresponding [component parameters](xref:blazor/components/index#component-parameters) with the same name. Route parameter names are case insensitive. In the following example, the `text` parameter assigns the value of the route segment to the component's `Text` property. When a request is made for `/RouteParameter/amazing`, the `<h1>` tag content is rendered as `Blazor is amazing!`.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor?highlight=1)]

Optional parameters aren't supported. In the following example, two [`@page` directives](xref:mvc/views/razor#page) are applied. The first directive permits navigation to the component without a parameter. The second directive assigns the `{text}` route parameter value to the component's `Text` property.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor?highlight=2)]


Use [`OnParametersSet`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) instead of [`OnInitialized{Async}`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) to permit app navigation to the same component with a different optional parameter value. Based on the preceding example, use `OnParametersSet` when the user should be able to navigate from `/RouteParameter` to `/RouteParameter/amazing` or from `/RouteParameter/amazing` to `/RouteParameter`:

```csharp
protected override void OnParametersSet()
{
    Text = Text ?? "fantastic";
}
```

> [!NOTE]
> Route parameters don't work with query string values. To work with query strings, see the [Query string and parse parameters](#query-string-and-parse-parameters) section.

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the `User` component only matches if:

* An `Id` route segment is present in the request URL.
* The `Id` segment is an integer (`int`) type.

`Pages/User.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/routing/User.razor?highlight=1)]

> [!NOTE]
> Route constraints don't work with query string values. To work with query strings, see the [Query string and parse parameters](#query-string-and-parse-parameters) section.

The route constraints shown in the following table are available. For the route constraints that match the invariant culture, see the warning below the table for more information.

| Constraint | Example           | Example Matches                                                                  | Invariant<br>culture<br>matching |
| ---------- | ----------------- | -------------------------------------------------------------------------------- | :------------------------------: |
| `bool`     | `{active:bool}`   | `true`, `FALSE`                                                                  | No                               |
| `datetime` | `{dob:datetime}`  | `2016-12-31`, `2016-12-31 7:32pm`                                                | Yes                              |
| `decimal`  | `{price:decimal}` | `49.99`, `-1,000.01`                                                             | Yes                              |
| `double`   | `{weight:double}` | `1.234`, `-1,001.01e8`                                                           | Yes                              |
| `float`    | `{weight:float}`  | `1.234`, `-1,001.01e8`                                                           | Yes                              |
| `guid`     | `{id:guid}`       | `CD2C1638-1638-72D5-1638-DEADBEEF1638`, `{CD2C1638-1638-72D5-1638-DEADBEEF1638}` | No                               |
| `int`      | `{id:int}`        | `123456789`, `-123456789`                                                        | Yes                              |
| `long`     | `{ticks:long}`    | `123456789`, `-123456789`                                                        | Yes                              |

> [!WARNING]
> Route constraints that verify the URL and are converted to a CLR type (such as `int` or <xref:System.DateTime>) always use the invariant culture. These constraints assume that the URL is non-localizable.

## Routing with URLs that contain dots

For hosted Blazor WebAssembly and Blazor Server apps, the server-side default route template assumes that if the last segment of a request URL contains a dot (`.`) that a file is requested. For example, the URL `https://localhost.com:5001/example/some.thing` is interpreted by the router as a request for a file named `some.thing`. Without additional configuration, an app returns a *404 - Not Found* response if `some.thing` was meant to route to a component with an [`@page` directive](xref:mvc/views/razor#page) and `some.thing` is a route parameter value. To use a route with one or more parameters that contain a dot, the app must configure the route with a custom template.

Consider the following `Example` component that can receive a route parameter from the last segment of the URL.

`Pages/Example.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/routing/Example.razor?highlight=2)]

To permit the **`Server`** app of a hosted Blazor WebAssembly solution to route the request with a dot in the `param` route parameter, add a fallback file route template with the optional parameter in `Startup.Configure`.

`Startup.cs`:

```csharp
endpoints.MapFallbackToFile("/example/{param?}", "index.html");
```

To configure a Blazor Server app to route the request with a dot in the `param` route parameter, add a fallback page route template with the optional parameter in `Startup.Configure`.

`Startup.cs`:

```csharp
endpoints.MapFallbackToPage("/example/{param?}", "/_Host");
```

For more information, see <xref:fundamentals/routing>.

## Catch-all route parameters

Catch-all route parameters are supported in ASP.NET Core 5.0 or later. For more information, select the 5.0 version of this article.

## URI and navigation state helpers

Use <xref:Microsoft.AspNetCore.Components.NavigationManager> to manage URIs and navigation in C# code. <xref:Microsoft.AspNetCore.Components.NavigationManager> provides the event and methods shown in the following table.

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element in `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Given a base URI (for example, a URI previously returned by <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri>), converts an absolute URI into a URI relative to the base URI prefix. |

For the <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> event, <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs> provides the following information about navigation events:

* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.Location>: The URL of the new location.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.IsNavigationIntercepted>: If `true`, Blazor intercepted the navigation from the browser. If `false`, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> caused the navigation to occur.

The following component:

* Navigates to the app's `Counter` component (`Pages/Counter.razor`) when the button is selected using <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A>.
* Handles the location changed event by subscribing to <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged?displayProperty=nameWithType>.
  * The `HandleLocationChanged` method is unhooked when `Dispose` is called by the framework. Unhooking the method permits garbage collection of the component.
  * The logger implementation logs the following information when the button is selected:

    > `BlazorSample.Pages.Navigate: Information: URL of new location: https://localhost:5001/counter`

`Pages/Navigate.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/routing/Navigate.razor)]

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

## Query string and parse parameters

The query string of a request is obtained from the <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> property:

```razor
@inject NavigationManager NavigationManager

...

var query = new Uri(NavigationManager.Uri).Query;
```

To parse a query string's parameters, one approach is to use [`URLSearchParams`](https://developer.mozilla.org/docs/Web/API/URLSearchParams) with [JavaScript (JS) interop](xref:blazor/js-interop/call-javascript-from-dotnet):

## `NavLink` and `NavMenu` components

Use a <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component in place of HTML hyperlink elements (`<a>`) when creating navigation links. A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. Optionally, assign a CSS class name to <xref:Microsoft.AspNetCore.Components.Routing.NavLink.ActiveClass?displayProperty=nameWithType> to apply a custom CSS class to the rendered link when the current route matches the `href`.

> [!NOTE]
> The `NavMenu` component (`NavMenu.razor`) is provided in the `Shared` folder of an app generated from the [Blazor project templates](xref:blazor/project-structure).

There are two <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch> options that you can assign to the `Match` attribute of the `<NavLink>` element:

* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType>: The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches the entire current URL.
* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.Prefix?displayProperty=nameWithType> (*default*): The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches any prefix of the current URL.

In the preceding example, the Home <xref:Microsoft.AspNetCore.Components.Routing.NavLink> `href=""` matches the home URL and only receives the `active` CSS class at the app's default base path URL (for example, `https://localhost:5001/`). The second <xref:Microsoft.AspNetCore.Components.Routing.NavLink> receives the `active` class when the user visits any URL with a `component` prefix (for example, `https://localhost:5001/component` and `https://localhost:5001/component/another-segment`).

Additional <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component attributes are passed through to the rendered anchor tag. In the following example, the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component includes the `target` attribute:

```razor
<NavLink href="example-page" target="_blank">Example page</NavLink>
```

The following HTML markup is rendered:

```html
<a href="example-page" target="_blank">Example page</a>
```

> [!WARNING]
> Due to the way that Blazor renders child content, rendering `NavLink` components inside a `for` loop requires a local index variable if the incrementing loop variable is used in the `NavLink` (child) component's content:
>
> ```razor
> @for (int c = 0; c < 10; c++)
> {
>     var current = c;
>     <li ...>
>         <NavLink ... href="@c">
>             <span ...></span> @current
>         </NavLink>
>     </li>
> }
> ```
>
> Using an index variable in this scenario is a requirement for **any** child component that uses a loop variable in its [child content](xref:blazor/components/index#child-content), not just the `NavLink` component.
>
> Alternatively, use a `foreach` loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType>:
>
> ```razor
> @foreach (var c in Enumerable.Range(0,10))
> {
>     <li ...>
>         <NavLink ... href="@c">
>             <span ...></span> @c
>         </NavLink>
>     </li>
> }
> ```

## ASP.NET Core endpoint routing integration

*This section only applies to Blazor Server apps.*

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in `Startup.Configure`.

`Startup.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_Server/routing/Startup.cs?highlight=11)]

The typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named `_Host.cshtml` in the `Pages` folder of the app.

The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is used when other routes don't match. This allows the app to use other controllers and pages without interfering with component routing in the Blazor Server app.

<!-- HOLD
For information on configuring <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for non-root URL server hosting, see <xref:blazor/host-and-deploy/index#app-base-path>.
-->

:::moniker-end
