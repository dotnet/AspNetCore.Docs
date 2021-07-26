---
title: ASP.NET Core Blazor routing
author: guardrex
description: Learn how to manage request routing in apps and how to use the NavLink component in Blazor apps for navigation.
monikerRange: '>= aspnetcore-3.1 < aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/09/2020
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/routing
---
# ASP.NET Core Blazor routing

In this article, learn how to manage request routing and how to use the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component to create a navigation links in Blazor apps.

## Route templates

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component enables routing to Razor components in a Blazor app. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component is used in the `App` component of Blazor apps.

`App.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/routing/App1.razor)]

When a Razor component (`.razor`) with an [`@page` directive](xref:mvc/views/razor#page) is compiled, the generated component class is provided a <xref:Microsoft.AspNetCore.Components.RouteAttribute> specifying the component's route template.

When the app starts, the assembly specified as the Router's `AppAssembly` is scanned to gather route information for the app's components that have a <xref:Microsoft.AspNetCore.Components.RouteAttribute>.

At runtime, the <xref:Microsoft.AspNetCore.Components.RouteView> component:

* Receives the <xref:Microsoft.AspNetCore.Components.RouteData> from the <xref:Microsoft.AspNetCore.Components.Routing.Router> along with any route parameters.
* Renders the specified component with its [layout](xref:blazor/components/layouts), including any further nested layouts.

Optionally specify a <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout> parameter with a layout class for components that don't specify a layout with the [`@layout` directive](xref:blazor/components/layouts#apply-a-layout-to-a-component). The framework's [Blazor project templates](xref:blazor/project-structure) specify the `MainLayout` component (`Shared/MainLayout.razor`) as the app's default layout. For more information on layouts, see <xref:blazor/components/layouts>.

Components support multiple route templates using multiple [`@page` directives](xref:mvc/views/razor#page). The following example component loads on requests for `/BlazorRoute` and `/DifferentBlazorRoute`.

`Pages/BlazorRoute.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor?highlight=1-2)]

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag in its `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server) with the app base path specified in the `href` attribute. For more information, see <xref:blazor/host-and-deploy/index#app-base-path>.

> [!NOTE]
> The <xref:Microsoft.AspNetCore.Components.Routing.Router> doesn't interact with query string values. To work with query strings, see the [Query string and parse parameters](#query-string-and-parse-parameters) section.

## Provide custom content when content isn't found

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component allows the app to specify custom content if content isn't found for the requested route.

In the `App` component, set custom content in the <xref:Microsoft.AspNetCore.Components.Routing.Router> component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template.

`App.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/routing/App2.razor?highlight=5-8)]

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

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor?highlight=1)]

Optional parameters aren't supported. In the following example, two [`@page` directives](xref:mvc/views/razor#page) are applied. The first directive permits navigation to the component without a parameter. The second directive assigns the `{text}` route parameter value to the component's `Text` property.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor?highlight=2)]


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

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/routing/User.razor?highlight=1)]

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

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/routing/Example.razor?highlight=2)]

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
| <span style="word-break:normal;word-wrap:normal"><xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A></span> | Given a base URI (for example, a URI previously returned by <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri>), converts an absolute URI into a URI relative to the base URI prefix. |

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

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/routing/Navigate.razor)]

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

The following `NavMenu` component creates a [`Bootstrap`](https://getbootstrap.com/docs/) navigation bar that demonstrates how to use <xref:Microsoft.AspNetCore.Components.Routing.NavLink> components:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/routing/NavMenu.razor?highlight=4,9)]

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
> @foreach(var c in Enumerable.Range(0,10))
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

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_Server/routing/Startup.cs?highlight=11)]

The typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named `_Host.cshtml` in the `Pages` folder of the app.

The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is used when other routes don't match. This allows the app to use other controllers and pages without interfering with component routing in the Blazor Server app.

For information on configuring <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for non-root URL server hosting, see <xref:blazor/host-and-deploy/index#app-base-path>.
