---
title: ASP.NET Core Blazor routing
author: guardrex
description: Learn how to route requests in apps and about the NavLink component.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 09/02/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/routing
---
# ASP.NET Core Blazor routing

By [Luke Latham](https://github.com/guardrex)

Learn how to route requests and how to use the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component to create navigation links in Blazor apps.

## ASP.NET Core endpoint routing integration

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in `Startup.Configure`:

[!code-csharp[](routing/samples_snapshot/3.x/Startup.cs?highlight=5)]

The most typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named `_Host.cshtml`. The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is considered when other routes don't match. This allows the app to use others controllers and pages without interfering with the Blazor Server app.

For information on configuring <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for non-root URL server hosting, see <xref:blazor/host-and-deploy/index#app-base-path>.

## Route templates

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component enables routing to each component with a specified route. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component appears in the `App.razor` file:

```razor
<Router AppAssembly="@typeof(Startup).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <p>Sorry, there's nothing at this address.</p>
    </NotFound>
</Router>
```

When a `.razor` file with an `@page` directive is compiled, the generated class is provided a <xref:Microsoft.AspNetCore.Components.RouteAttribute> specifying the route template.

At runtime, the <xref:Microsoft.AspNetCore.Components.RouteView> component:

* Receives the <xref:Microsoft.AspNetCore.Components.RouteData> from the <xref:Microsoft.AspNetCore.Components.Routing.Router> along with any desired parameters.
* Renders the specified component with its layout (or an optional default layout) using the specified parameters.

You can optionally specify a <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout> parameter with a layout class to use for components that don't specify a layout. The default Blazor templates specify the `MainLayout` component. `MainLayout.razor` is in the template project's `Shared` folder. For more information on layouts, see <xref:blazor/layouts>.

Multiple route templates can be applied to a component. The following component responds to requests for `/BlazorRoute` and `/DifferentBlazorRoute`:

```razor
@page "/BlazorRoute"
@page "/DifferentBlazorRoute"

<h1>Blazor routing</h1>
```

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag in its `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server) with the app base path specified in the `href` attribute (`<base href="/">`). For more information, see <xref:blazor/host-and-deploy/index#app-base-path>.

## Provide custom content when content isn't found

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component allows the app to specify custom content if content isn't found for the requested route.

In the `App.razor` file, set custom content in the <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template parameter of the <xref:Microsoft.AspNetCore.Components.Routing.Router> component:

```razor
<Router AppAssembly="typeof(Startup).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <h1>Sorry</h1>
        <p>Sorry, there's nothing at this address.</p> b
    </NotFound>
</Router>
```

The content of `<NotFound>` tags can include arbitrary items, such as other interactive components. To apply a default layout to <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content, see <xref:blazor/layouts>.

## Route to components from multiple assemblies

Use the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter to specify additional assemblies for the <xref:Microsoft.AspNetCore.Components.Routing.Router> component to consider when searching for routable components. Specified assemblies are considered in addition to the `AppAssembly`-specified assembly. In the following example, `Component1` is a routable component defined in a referenced class library. The following <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> example results in routing support for `Component1`:

```razor
<Router
    AppAssembly="@typeof(Program).Assembly"
    AdditionalAssemblies="new[] { typeof(Component1).Assembly }">
    ...
</Router>
```

## Route parameters

The router uses route parameters to populate the corresponding component parameters with the same name (case insensitive):

```razor
@page "/RouteParameter"
@page "/RouteParameter/{text}"

<h1>Blazor is @Text!</h1>

@code {
    [Parameter]
    public string Text { get; set; }

    protected override void OnInitialized()
    {
        Text = Text ?? "fantastic";
    }
}
```

Optional parameters aren't supported. Two `@page` directives are applied in the previous example. The first permits navigation to the component without a parameter. The second `@page` directive takes the `{text}` route parameter and assigns the value to the `Text` property.

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the `Users` component only matches if:

* An `Id` route segment is present on the request URL.
* The `Id` segment is an integer (`int`).

[!code-razor[](routing/samples_snapshot/3.x/Constraint.razor?highlight=1)]

The route constraints shown in the following table are available. For the route constraints that match with the invariant culture, see the warning below the table for more information.

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

### Routing with URLs that contain dots

For hosted Blazor WebAssembly and Blazor Server apps, the server-side default route template assumes that if the last segment of a request URL contains a dot (`.`) that a file is requested (for example, `https://localhost.com:5001/example/some.thing`). Without additional configuration, an app returns a *404 - Not Found* response if this was meant to route to a component. To use a route with one or more parameters that contains a dot, the app must configure the route with a custom template.

Consider the following `Example` component that can receive a route parameter from the last segment of the URL:

```razor
@page "/example"
@page "/example/{param}"

<p>
    Param: @Param
</p>

@code {
    [Parameter]
    public string Param { get; set; }
}
```

To permit the *Server* app of a hosted Blazor WebAssembly solution to route the request with a dot in the `param` parameter, add a fallback file route template with the optional parameter in `Startup.Configure` (`Startup.cs`):

```csharp
endpoints.MapFallbackToFile("/example/{param?}", "index.html");
```

To configure a Blazor Server app to route the request with a dot in the `param` parameter, add a fallback page route template with the optional parameter in `Startup.Configure` (`Startup.cs`):

```csharp
endpoints.MapFallbackToPage("/example/{param?}", "/_Host");
```

For more information, see <xref:fundamentals/routing>.

## Catch-all route parameters

::: moniker range=">= aspnetcore-5.0"

*This section applies to ASP.NET Core in .NET 5 Release Candidate 1 (RC1) or later.*

Catch-all route parameters, which capture paths across multiple folder boundaries, are supported in components. The catch-all route parameter must be:

* Named to match the route segment name. Naming isn't case sensitive.
* A `string` type. The framework doesn't provide automatic casting.
* At the end of the URL.

```razor
@page "/page/{*pageRoute}"

@code {
    [Parameter]
    public string PageRoute { get; set; }
}
```

For the URL `/page/this/is/a/test` with a route template of `/page/{*pageRoute}`, the value of `PageRoute` is set to `this/is/a/test`.

Slashes and segments of the captured path are decoded. For a route template of `/page/{*pageRoute}`, the URL `/page/this/is/a%2Ftest%2A` yields `this/is/a/test*`.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

Catch-all route parameters are supported in ASP.NET Core in .NET 5 Release Candidate 1 (RC1) or later.*

::: moniker-end

## NavLink component

Use a <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component in place of HTML hyperlink elements (`<a>`) when creating navigation links. A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. Optionally, assign a CSS class name to <xref:Microsoft.AspNetCore.Components.Routing.NavLink.ActiveClass?displayProperty=nameWithType> to apply a custom CSS class to the rendered link when the current route matches the `href`.

The following `NavMenu` component creates a [`Bootstrap`](https://getbootstrap.com/docs/) navigation bar that demonstrates how to use <xref:Microsoft.AspNetCore.Components.Routing.NavLink> components:

[!code-razor[](routing/samples_snapshot/3.x/NavMenu.razor?highlight=4,9)]

There are two <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch> options that you can assign to the `Match` attribute of the `<NavLink>` element:

* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType>: The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches the entire current URL.
* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.Prefix?displayProperty=nameWithType> (*default*): The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches any prefix of the current URL.

In the preceding example, the Home <xref:Microsoft.AspNetCore.Components.Routing.NavLink> `href=""` matches the home URL and only receives the `active` CSS class at the app's default base path URL (for example, `https://localhost:5001/`). The second <xref:Microsoft.AspNetCore.Components.Routing.NavLink> receives the `active` class when the user visits any URL with a `MyComponent` prefix (for example, `https://localhost:5001/MyComponent` and `https://localhost:5001/MyComponent/AnotherSegment`).

Additional <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component attributes are passed through to the rendered anchor tag. In the following example, the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component includes the `target` attribute:

```razor
<NavLink href="my-page" target="_blank">My page</NavLink>
```

The following HTML markup is rendered:

```html
<a href="my-page" target="_blank">My page</a>
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
> @foreach(var c in Enumerable.Range(0,10))
> {
>     <li ...>
>         <NavLink ... href="@c">
>             <span ...></span> @c
>         </NavLink>
>     </li>
> }
> ```

## URI and navigation state helpers

Use <xref:Microsoft.AspNetCore.Components.NavigationManager> to work with URIs and navigation in C# code. <xref:Microsoft.AspNetCore.Components.NavigationManager> provides the event and methods shown in the following table.

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element in `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <span style="word-break:normal;word-wrap:normal"><xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A></span> | Given a base URI (for example, a URI previously returned by <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri>), converts an absolute URI into a URI relative to the base URI prefix. |

The following component navigates to the app's `Counter` component when the button is selected:

```razor
@page "/navigate"
@inject NavigationManager NavigationManager

<h1>Navigate in Code Example</h1>

<button class="btn btn-primary" @onclick="NavigateToCounterComponent">
    Navigate to the Counter component
</button>

@code {
    private void NavigateToCounterComponent()
    {
        NavigationManager.NavigateTo("counter");
    }
}
```

The following component handles a location changed event by subscribing to <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged?displayProperty=nameWithType>. The `HandleLocationChanged` method is unhooked when `Dispose` is called by the framework. Unhooking the method permits garbage collection of the component.

```razor
@implements IDisposable
@inject NavigationManager NavigationManager

...

protected override void OnInitialized()
{
    NavigationManager.LocationChanged += HandleLocationChanged;
}

private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
{
    ...
}

public void Dispose()
{
    NavigationManager.LocationChanged -= HandleLocationChanged;
}
```

<xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs> provides the following information about the event:

* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.Location>: The URL of the new location.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.IsNavigationIntercepted>: If `true`, Blazor intercepted the navigation from the browser. If `false`, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> caused the navigation to occur.

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable>.

## Query string and parse parameters

The query string of a request can be obtained from the <xref:Microsoft.AspNetCore.Components.NavigationManager>'s <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> property:

```razor
@inject NavigationManager Navigation

...

var query = new Uri(Navigation.Uri).Query;
```

To parse a query string's parameters:

* Add a package reference for [Microsoft.AspNetCore.WebUtilities](https://www.nuget.org/packages/Microsoft.AspNetCore.WebUtilities).
* Obtain the value after parsing the query string with <xref:Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery%2A?displayProperty=nameWithType>.

```razor
@page "/"
@using Microsoft.AspNetCore.WebUtilities
@inject NavigationManager NavigationManager

<h1>Query string parse example</h1>

<p>Value: @queryValue</p>

@code {
    private string queryValue = "Not set";

    protected override void OnInitialized()
    {
        var query = new Uri(NavigationManager.Uri).Query;

        if (QueryHelpers.ParseQuery(query).TryGetValue("{KEY}", out var value))
        {
            queryValue = value;
        }
    }
}
```

The placeholder `{KEY}` in the preceding example is the query string parameter key. For example, the URL key-value pair `?ship=Tardis` uses a key of `ship`.
