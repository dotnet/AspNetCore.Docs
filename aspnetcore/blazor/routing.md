---
title: ASP.NET Core Blazor routing
author: guardrex
description: Learn how to route requests in apps and about the NavLink component.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/15/2019
uid: blazor/routing
---
# ASP.NET Core Blazor routing

By [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

Learn how to route requests and how to use the `NavLink` component to create navigation links in Blazor apps.

## ASP.NET Core endpoint routing integration

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with `MapBlazorHub` in `Startup.Configure`:

[!code-csharp[](routing/samples_snapshot/3.x/Startup.cs?highlight=5)]

The most typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named *_Host.cshtml*. The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is considered when other routes don't match. This allows the app to use others controllers and pages without interfering with the Blazor Server app.

## Route templates

The `Router` component enables routing to each component with a specified route. The `Router` component appears in the *App.razor* file:

```cshtml
<Router AppAssembly="typeof(Startup).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <p>Sorry, there's nothing at this address.</p>
    </NotFound>
</Router>
```

When a *.razor* file with an `@page` directive is compiled, the generated class is provided a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template.

At runtime, the `RouteView` component:

* Receives the `RouteData` from the `Router` along with any desired parameters.
* Renders the specified component with its layout (or an optional default layout) using the specified parameters.

You can optionally specify a `DefaultLayout` parameter with a layout class to use for components that don't specify a layout. The default Blazor templates specify the `MainLayout` component. *MainLayout.razor* is in the template project's *Shared* folder. For more information on layouts, see <xref:blazor/layouts>.

Multiple route templates can be applied to a component. The following component responds to requests for `/BlazorRoute` and `/DifferentBlazorRoute`:

[!code-cshtml[](common/samples/3.x/BlazorWebAssemblySample/Pages/BlazorRoute.razor?name=snippet_BlazorRoute)]

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag in its *wwwroot/index.html* file (Blazor WebAssembly) or *Pages/_Host.cshtml* file (Blazor Server) with the app base path specified in the `href` attribute (`<base href="/">`). For more information, see <xref:host-and-deploy/blazor/index#app-base-path>.

## Provide custom content when content isn't found

The `Router` component allows the app to specify custom content if content isn't found for the requested route.

In the *App.razor* file, set custom content in the `NotFound` template parameter of the `Router` component:

```cshtml
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

The content of `<NotFound>` tags can include arbitrary items, such as other interactive components. To apply a default layout to `NotFound` content, see <xref:blazor/layouts>.

## Route to components from multiple assemblies

Use the `AdditionalAssemblies` parameter to specify additional assemblies for the `Router` component to consider when searching for routable components. Specified assemblies are considered in addition to the `AppAssembly`-specified assembly. In the following example, `Component1` is a routable component defined in a referenced class library. The following `AdditionalAssemblies` example results in routing support for `Component1`:

```cshtml
<Router
    AppAssembly="typeof(Program).Assembly"
    AdditionalAssemblies="new[] { typeof(Component1).Assembly }">
    ...
</Router>
```

## Route parameters

The router uses route parameters to populate the corresponding component parameters with the same name (case insensitive):

[!code-cshtml[](common/samples/3.x/BlazorWebAssemblySample/Pages/RouteParameter.razor?name=snippet_RouteParameter&highlight=2,7-8)]

Optional parameters aren't supported for Blazor apps in ASP.NET Core 3.0. Two `@page` directives are applied in the previous example. The first permits navigation to the component without a parameter. The second `@page` directive takes the `{text}` route parameter and assigns the value to the `Text` property.

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the `Users` component only matches if:

* An `Id` route segment is present on the request URL.
* The `Id` segment is an integer (`int`).

[!code-cshtml[](routing/samples_snapshot/3.x/Constraint.razor?highlight=1)]

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
> Route constraints that verify the URL and are converted to a CLR type (such as `int` or `DateTime`) always use the invariant culture. These constraints assume that the URL is non-localizable.

### Routing with URLs that contain dots

In Blazor Server apps, the default route in *_Host.cshtml* is `/` (`@page "/"`). A request URL that contains a dot (`.`) isn't matched by the default route because the URL appears to request a file. A Blazor app returns a *404 - Not Found* response for a static file that doesn't exist. To use routes that contain a dot, configure *_Host.cshtml* with the following route template:

```cshtml
@page "/{**path}"
```

The `"/{**path}"` template includes:

* Double-asterisk *catch-all* syntax (`**`) to capture the path across multiple folder boundaries without encoding forward slashes (`/`).
* A `path` route parameter name.

For more information, see <xref:fundamentals/routing>.

## NavLink component

Use a `NavLink` component in place of HTML hyperlink elements (`<a>`) when creating navigation links. A `NavLink` component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed.

The following `NavMenu` component creates a [Bootstrap](https://getbootstrap.com/docs/) navigation bar that demonstrates how to use `NavLink` components:

[!code-cshtml[](routing/samples_snapshot/3.x/NavMenu.razor?highlight=4,9)]

There are two `NavLinkMatch` options that you can assign to the `Match` attribute of the `<NavLink>` element:

* `NavLinkMatch.All` &ndash; The `NavLink` is active when it matches the entire current URL.
* `NavLinkMatch.Prefix` (*default*) &ndash; The `NavLink` is active when it matches any prefix of the current URL.

In the preceding example, the Home `NavLink` `href=""` matches the home URL and only receives the `active` CSS class at the app's default base path URL (for example, `https://localhost:5001/`). The second `NavLink` receives the `active` class when the user visits any URL with a `MyComponent` prefix (for example, `https://localhost:5001/MyComponent` and `https://localhost:5001/MyComponent/AnotherSegment`).

Additional `NavLink` component attributes are passed through to the rendered anchor tag. In the following example, the `NavLink` component includes the `target` attribute:

```cshtml
<NavLink href="my-page" target="_blank">My page</NavLink>
```

The following HTML markup is rendered:

```html
<a href="my-page" target="_blank" rel="noopener noreferrer">My page</a>
```

## URI and navigation state helpers

Use `Microsoft.AspNetCore.Components.NavigationManager` to work with URIs and navigation in C# code. `NavigationManager` provides the event and methods shown in the following table.

| Member | Description |
| ------ | ----------- |
| `Uri` | Gets the current absolute URI. |
| `BaseUri` | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, `BaseUri` corresponds to the `href` attribute on the document's `<base>` element in *wwwroot/index.html* (Blazor WebAssembly) or *Pages/_Host.cshtml* (Blazor Server). |
| `NavigateTo` | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul> |
| `LocationChanged` | An event that fires when the navigation location has changed. |
| `ToAbsoluteUri` | Converts a relative URI into an absolute URI. |
| `ToBaseRelativePath` | Given a base URI (for example, a URI previously returned by `GetBaseUri`), converts an absolute URI into a URI relative to the base URI prefix. |

The following component navigates to the app's `Counter` component when the button is selected:

```cshtml
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
