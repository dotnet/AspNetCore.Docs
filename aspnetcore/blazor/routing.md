---
title: Blazor routing
author: guardrex
description: Learn how to route requests in apps and about the NavLink component.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/14/2019
uid: blazor/routing
---
# Blazor routing

By [Luke Latham](https://github.com/guardrex)

Learn how to route requests in apps and about the NavLink component.

## ASP.NET Core endpoint routing integration

Blazor server-side is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with `MapBlazorHub` in `Startup.Configure`:

[!code-cshtml[](routing/samples_snapshot/3.x/Startup.cs?highlight=5)]

## Route templates

The `<Router>` component enables routing, and a route template is provided to each accessible component. The `<Router>` component appears in the *App.razor* file:

In a Blazor server-side app:

```cshtml
<Router AppAssembly="typeof(Startup).Assembly" />
```

In a Blazor client-side app:

```cshtml
<Router AppAssembly="typeof(Program).Assembly" />
```

When a *.razor* file with an `@page` directive is compiled, the generated class is provided a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router looks for component classes with a `RouteAttribute` and renders the component with a route template that matches the requested URL.

Multiple route templates can be applied to a component. The following component responds to requests for `/BlazorRoute` and `/DifferentBlazorRoute`:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/BlazorRoute.razor?name=snippet_BlazorRoute)]

`<Router>` supports setting a fallback component to render when a requested route isn't resolved. Enable this opt-in scenario by setting the `FallbackComponent` parameter to the type of the fallback component class.

The following example sets a component defined in *Pages/MyFallbackRazorComponent.razor* as the fallback component for a `<Router>`:

```cshtml
<Router ... FallbackComponent="typeof(Pages.MyFallbackRazorComponent)" />
```

> [!IMPORTANT]
> To generate routes properly, the app must include a `<base>` tag in its *wwwroot/index.html* file with the app base path specified in the `href` attribute (`<base href="/">`). For more information, see <xref:host-and-deploy/blazor/client-side#app-base-path>.

## Route parameters

The router uses route parameters to populate the corresponding component parameters with the same name (case insensitive):

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/RouteParameter.razor?name=snippet_RouteParameter&highlight=2,7-8)]

Optional parameters aren't supported for Blazor apps in ASP.NET Core 3.0 Preview. Two `@page` directives are applied in the previous example. The first permits navigation to the component without a parameter. The second `@page` directive takes the `{text}` route parameter and assigns the value to the `Text` property.

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the Users component only matches if:

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

## NavLink component

Use a NavLink component in place of HTML `<a>` elements when creating navigation links. A NavLink component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed.

The following NavMenu component creates a [Bootstrap](https://getbootstrap.com/docs/) navigation bar that demonstrates how to use NavLink components:

[!code-cshtml[](common/samples/3.x/BlazorSample/Shared/NavMenu.razor?name=snippet_NavLinks&highlight=4-6,9-11)]

There are two `NavLinkMatch` options:

* `NavLinkMatch.All` &ndash; Specifies that the NavLink should be active when it matches the entire current URL.
* `NavLinkMatch.Prefix` &ndash; Specifies that the NavLink should be active when it matches any prefix of the current URL.

In the preceding example, the Home NavLink (`href=""`) matches all URLs and always receives the `active` CSS class. The second NavLink only receives the `active` class when the user visits the Blazor Route component (`href="BlazorRoute"`).

## URI and navigation state helpers

Use `Microsoft.AspNetCore.Components.IUriHelper` to work with URIs and navigation in C# code. `IUriHelper` provides the event and methods shown in the following table.

| Member | Description |
| ------ | ----------- |
| `GetAbsoluteUri` | Gets the current absolute URI. |
| `GetBaseUri` | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, `GetBaseUri` corresponds to the `href` attribute on the document's `<base>` element in *wwwroot/index.html* (Blazor client-side) or *Pages/\_Host.cshtml* (Blazor server-side). |
| `NavigateTo` | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul> |
| `OnLocationChanged` | An event that fires when the navigation location has changed. |
| `ToAbsoluteUri` | Converts a relative URI into an absolute URI. |
| `ToBaseRelativePath` | Given a base URI (for example, a URI previously returned by `GetBaseUri`), converts an absolute URI into a URI relative to the base URI prefix. |

The following component navigates to the app's Counter component when the button is selected:

```cshtml
@page "/navigate"
@using Microsoft.AspNetCore.Components
@inject IUriHelper UriHelper

<h1>Navigate in Code Example</h1>

<button class="btn btn-primary" onclick="@NavigateToCounterComponent">
    Navigate to the Counter component
</button>

@functions {
    private void NavigateToCounterComponent()
    {
        UriHelper.NavigateTo("counter");
    }
}
```
