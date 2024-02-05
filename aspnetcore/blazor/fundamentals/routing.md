---
title: ASP.NET Core Blazor routing and navigation
author: guardrex
description: Learn how to manage Blazor app request routing and how to use the Navigation Manager and NavLink component for navigation.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/fundamentals/routing
---
# ASP.NET Core Blazor routing and navigation

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to manage Blazor app request routing and how to use the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component to create navigation links.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

> [!IMPORTANT]
> Code examples throughout this article show methods called on `Navigation`, which is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager> in classes and components.

:::moniker range=">= aspnetcore-8.0"

## Static versus interactive routing

*This section applies to Blazor Web Apps.*

If [prerendering isn't disabled](xref:blazor/components/render-modes#prerendering), the Blazor router (`Router` component, `<Router>` in `Routes.razor`) performs static routing to components during static server-side rendering (static SSR). This type of routing is called *static routing*.

When an interactive render mode is assigned to the `Routes` component, the Blazor router becomes interactive after static SSR with static routing on the server. This type of routing is called *interactive routing*.

Static routers use endpoint routing and the HTTP request path to determine which component to render. When the router becomes interactive, it uses the document's URL (the URL in the browser's address bar) to determine which component to render. This means that the interactive router can dynamically change which component is rendered if the document's URL dynamically changes to another valid internal URL, and it can do so without performing an HTTP request to fetch new page content.

Interactive routing also prevents prerendering because new page content isn't requested from the server with a normal page request. For more information, see <xref:blazor/components/prerender#interactive-routing-and-prerendering>.

:::moniker-end

## Route templates

:::moniker range=">= aspnetcore-8.0"

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component enables routing to Razor components and is located in the app's `Routes` component (`Components/Routes.razor`).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component enables routing to Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component is used in the `App` component (`App.razor`).

:::moniker-end

When a Razor component (`.razor`) with an [`@page` directive](xref:mvc/views/razor#page) is compiled, the generated component class is provided a <xref:Microsoft.AspNetCore.Components.RouteAttribute> specifying the component's route template.

When the app starts, the assembly specified as the Router's `AppAssembly` is scanned to gather route information for the app's components that have a <xref:Microsoft.AspNetCore.Components.RouteAttribute>.

At runtime, the <xref:Microsoft.AspNetCore.Components.RouteView> component:

* Receives the <xref:Microsoft.AspNetCore.Components.RouteData> from the <xref:Microsoft.AspNetCore.Components.Routing.Router> along with any route parameters.
* Renders the specified component with its [layout](xref:blazor/components/layouts), including any further nested layouts.

Optionally specify a <xref:Microsoft.AspNetCore.Components.RouteView.DefaultLayout> parameter with a layout class for components that don't specify a layout with the [`@layout` directive](xref:blazor/components/layouts#apply-a-layout-to-a-component). The framework's [Blazor project templates](xref:blazor/project-structure) specify the `MainLayout` component (`MainLayout.razor`) as the app's default layout. For more information on layouts, see <xref:blazor/components/layouts>.

Components support multiple route templates using multiple [`@page` directives](xref:mvc/views/razor#page). The following example component loads on requests for `/blazor-route` and `/different-blazor-route`.

`BlazorRoute.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/BlazorRoute.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor" highlight="1-2":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor" highlight="1-2":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor" highlight="1-2":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/routing/BlazorRoute.razor" highlight="1-2":::

:::moniker-end

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)) with the app base path specified in the `href` attribute. For more information, see <xref:blazor/host-and-deploy/index#app-base-path>.

:::moniker range="< aspnetcore-6.0"

The <xref:Microsoft.AspNetCore.Components.Routing.Router> doesn't interact with query string values. To work with query strings, see the [Query strings](#query-strings) section.

:::moniker-end

As an alternative to specifying the route template as a string literal with the `@page` directive, constant-based route templates can be specified with the [`@attribute` directive](xref:mvc/views/razor#attribute).

In the following example, the `@page` directive in a component is replaced with the `@attribute` directive and the constant-based route template in `Constants.CounterRoute`, which is set elsewhere in the app to "`/counter`":

```diff
- @page "/counter"
+ @attribute [Route(Constants.CounterRoute)]
```

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Focus an element on navigation

The <xref:Microsoft.AspNetCore.Components.Routing.FocusOnNavigate> component sets the UI focus to an element based on a CSS selector after navigating from one page to another.

```razor
<FocusOnNavigate RouteData="@routeData" Selector="h1" />
```

When the <xref:Microsoft.AspNetCore.Components.Routing.Router> component navigates to a new page, the <xref:Microsoft.AspNetCore.Components.Routing.FocusOnNavigate> component sets the focus to the page's top-level header (`<h1>`). This is a common strategy for ensuring that a page navigation is announced when using a screen reader.

:::moniker-end

## Provide custom content when content isn't found

:::moniker range=">= aspnetcore-8.0"

*This section only applies to Blazor WebAssembly apps.* Blazor Web Apps don't use the <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> parameter (`<NotFound>...</NotFound>` markup), but the parameter is supported for backward compatibility to avoid a breaking change in the framework. Blazor Web Apps typically process bad URL requests by either displaying the browser's built-in 404 UI or returning a custom 404 page from the ASP.NET Core server via ASP.NET Core middleware (for example, [`UseStatusCodePagesWithRedirects`](xref:fundamentals/error-handling#usestatuscodepageswithredirects) / [API documentation](xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithRedirects%2A)).

:::moniker-end

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component allows the app to specify custom content if content isn't found for the requested route.

Set custom content for the <xref:Microsoft.AspNetCore.Components.Routing.Router> component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> parameter:

```razor
<Router ...>
    ...
    <NotFound>
        ...
    </NotFound>
</Router>
```

Arbitrary items are supported as content of the <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> parameter, such as other interactive components. To apply a default layout to <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content, see <xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component>.

## Route to components from multiple assemblies

:::moniker range=">= aspnetcore-8.0"

*This section applies to Blazor Web Apps.*

Use the <xref:Microsoft.AspNetCore.Components.Routing.Router> component's <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter and the endpoint convention builder <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointConventionBuilderExtensions.AddAdditionalAssemblies%2A> to discover routable components in additional assemblies. The following subsections explain when and how to use each API.

### Static routing

To discover routable components from additional assemblies for static server-side rendering (static SSR), even if the router later becomes interactive for interactive rendering, the assemblies must be disclosed to the Blazor framework. Call the <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointConventionBuilderExtensions.AddAdditionalAssemblies%2A> method with the additional assemblies chained to <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> in the server project's `Program` file.

The following example includes the routable components in the `BlazorSample.Client` project's assembly using the project's `_Imports.razor` file:

```csharp
app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(BlazorSample.Client._Imports).Assembly);
```

> [!NOTE]
> The preceding guidance also applies in [component class library](xref:blazor/components/class-libraries) scenarios. Additional important guidance for class libraries and static SSR is found in <xref:blazor/components/class-libraries-with-static-ssr>.

### Interactive routing

An interactive render mode can be assigned to the `Routes` component (`Routes.razor`) that makes the Blazor router become interactive after static SSR and static routing on the server. For example, `<Routes @rendermode="InteractiveServer" />` assigns interactive server-side rendering (interactive SSR) to the `Routes` component. The `Router` component inherits interactive server-side rendering (interactive SSR) from the `Routes` component. The router becomes interactive after static routing on the server.

Internal navigation for interactive routing doesn't involve requesting new page content from the server. Therefore, prerendering doesn't occur for internal page requests. For more information, see <xref:blazor/components/prerender#interactive-routing-and-prerendering>.

If the `Routes` component is defined in the server project, the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter of the `Router` component should include the `.Client` project's assembly. This allows the router to work correctly when rendered interactively.

In the following example, the `Routes` component is in the server project, and the `_Imports.razor` file of the `BlazorSample.Client` project indicates the assembly to search for routable components:

```razor
<Router
    AppAssembly="..."
    AdditionalAssemblies="new[] { typeof(BlazorSample.Client._Imports).Assembly }">
    ...
</Router>
```

Additional assemblies are scanned in addition to the assembly specified to <xref:Microsoft.AspNetCore.Components.Routing.Router.AppAssembly%2A>.

> [!NOTE]
> The preceding guidance also applies in [component class library](xref:blazor/components/class-libraries) scenarios.

Alternatively, routable components only exist in the `.Client` project with global Interactive WebAssembly or Auto rendering applied, and the `Routes` component is defined in the `.Client` project, not the server project. In this case, there aren't external assemblies with routable components, so it isn't necessary to specify a value for <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to Blazor Server apps.*

Use the <xref:Microsoft.AspNetCore.Components.Routing.Router> component's <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter and the endpoint convention builder <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointConventionBuilderExtensions.AddAdditionalAssemblies%2A> to discover routable components in additional assemblies.

In the following example, `Component1` is a routable component defined in a referenced [component class library](xref:blazor/components/class-libraries) named `ComponentLibrary`:

```razor
<Router
    AppAssembly="..."
    AdditionalAssemblies="new[] { typeof(ComponentLibrary.Component1).Assembly }">
    ...
</Router>
```

Additional assemblies are scanned in addition to the assembly specified to <xref:Microsoft.AspNetCore.Components.Routing.Router.AppAssembly%2A>.

:::moniker-end

## Route parameters

The router uses route parameters to populate the corresponding [component parameters](xref:blazor/components/index#component-parameters) with the same name. Route parameter names are case insensitive. In the following example, the `text` parameter assigns the value of the route segment to the component's `Text` property. When a request is made for `/route-parameter-1/amazing`, the content is rendered as `Blazor is amazing!`.

`RouteParameter1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/RouteParameter1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor" highlight="1":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor" highlight="1":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor" highlight="1":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/routing/RouteParameter1.razor" highlight="1":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

Optional parameters are supported. In the following example, the `text` optional parameter assigns the value of the route segment to the component's `Text` property. If the segment isn't present, the value of `Text` is set to `fantastic`.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Optional parameters aren't supported. In the following example, two [`@page` directives](xref:mvc/views/razor#page) are applied. The first directive permits navigation to the component without a parameter. The second directive assigns the `{text}` route parameter value to the component's `Text` property.

:::moniker-end

`RouteParameter2.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/RouteParameter2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor" highlight="1":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor" highlight="1":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor" highlight="1":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/routing/RouteParameter2.razor" highlight="1":::

:::moniker-end

Use [`OnParametersSet`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) instead of [`OnInitialized{Async}`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) to permit app navigation to the same component with a different optional parameter value. Based on the preceding example, use `OnParametersSet` when the user should be able to navigate from `/route-parameter-2` to `/route-parameter-2/amazing` or from `/route-parameter-2/amazing` to `/route-parameter-2`:

```csharp
protected override void OnParametersSet()
{
    Text = Text ?? "fantastic";
}
```

:::moniker range="< aspnetcore-6.0"

> [!NOTE]
> Route parameters don't work with query string values. To work with query strings, see the [Query strings](#query-strings) section.

:::moniker-end

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the `User` component only matches if:

* An `Id` route segment is present in the request URL.
* The `Id` segment is an integer (`int`) type.

`User.razor`:

```razor
@page "/user/{Id:int}"

<PageTitle>User</PageTitle>

<h1>User Example</h1>

<p>User Id: @Id</p>

@code {
    [Parameter]
    public int Id { get; set; }
}
```

:::moniker range="< aspnetcore-5.0"

> [!NOTE]
> Route constraints don't work with query string values. To work with query strings, see the [Query strings](#query-strings) section.

:::moniker-end

The route constraints shown in the following table are available. For the route constraints that match the invariant culture, see the warning below the table for more information.

Constraint | Example | Example Matches | Invariant<br>culture<br>matching
--- | --- | --- | :---:
`bool` | `{active:bool}` | `true`, `FALSE` | No
`datetime` | `{dob:datetime}` | `2016-12-31`, `2016-12-31 7:32pm` | Yes
`decimal` | `{price:decimal}` | `49.99`, `-1,000.01` | Yes
`double` | `{weight:double}` | `1.234`, `-1,001.01e8` | Yes
`float` | `{weight:float}` | `1.234`, `-1,001.01e8` | Yes
`guid` | `{id:guid}` | `CD2C1638-1638-72D5-1638-DEADBEEF1638`, `{CD2C1638-1638-72D5-1638-DEADBEEF1638}` | No
`int` | `{id:int}` | `123456789`, `-123456789` | Yes
`long` | `{ticks:long}` | `123456789`, `-123456789` | Yes

> [!WARNING]
> Route constraints that verify the URL and are converted to a CLR type (such as `int` or <xref:System.DateTime>) always use the invariant culture. These constraints assume that the URL is non-localizable.

:::moniker range=">= aspnetcore-6.0"

Route constraints also work with [optional parameters](#route-parameters). In the following example, `Id` is required, but `Option` is an optional boolean route parameter.

`User.razor`:

```razor
@page "/user/{id:int}/{option:bool?}"

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

:::moniker-end

:::moniker range="< aspnetcore-8.0"

<!--
    NOTE: Section removed at 8.0 when routing with dots became supported.
-->

## Routing with URLs that contain dots

A ***server-side*** default route template assumes that if the last segment of a request URL contains a dot (`.`) that a file is requested. For example, the relative URL `/example/some.thing` is interpreted by the router as a request for a file named `some.thing`. Without additional configuration, an app returns a *404 - Not Found* response if `some.thing` was meant to route to a component with an [`@page`](xref:mvc/views/razor#page) directive and `some.thing` is a route parameter value. To use a route with one or more parameters that contain a dot, the app must configure the route with a custom template.

Consider the following `Example` component that can receive a route parameter from the last segment of the URL.

`Example.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/routing/Example.razor" highlight="1":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/routing/Example.razor" highlight="1":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_Server/Pages/routing/Example.razor" highlight="1":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_Server/Pages/routing/Example.razor" highlight="2":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

To permit the **:::no-loc text="Server":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) to route the request with a dot in the `param` route parameter, add a fallback file route template with the optional parameter in the `Program` file:

```csharp
app.MapFallbackToFile("/example/{param?}", "index.html");
```

To configure a Blazor Server app to route the request with a dot in the `param` route parameter, add a fallback page route template with the optional parameter in the `Program` file:

```csharp
app.MapFallbackToPage("/example/{param?}", "/_Host");
```

For more information, see <xref:fundamentals/routing>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

To permit the **:::no-loc text="Server":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) to route the request with a dot in the `param` route parameter, add a fallback file route template with the optional parameter in `Startup.Configure`.

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

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## Catch-all route parameters

Catch-all route parameters, which capture paths across multiple folder boundaries, are supported in components.

Catch-all route parameters are:

* Named to match the route segment name. Naming isn't case-sensitive.
* A `string` type. The framework doesn't provide automatic casting.
* At the end of the URL.

`CatchAll.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Catchall.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/routing/CatchAll.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/routing/CatchAll.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/routing/CatchAll.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

For the URL `/catch-all/this/is/a/test` with a route template of `/catch-all/{*pageRoute}`, the value of `PageRoute` is set to `this/is/a/test`.

Slashes and segments of the captured path are decoded. For a route template of `/catch-all/{*pageRoute}`, the URL `/catch-all/this/is/a%2Ftest%2A` yields `this/is/a/test*`.

:::moniker-end

## URI and navigation state helpers

Use <xref:Microsoft.AspNetCore.Components.NavigationManager> to manage URIs and navigation in C# code. <xref:Microsoft.AspNetCore.Components.NavigationManager> provides the event and methods shown in the following table.

:::moniker range=">= aspnetcore-8.0"

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `false`:<ul><li>And enhanced navigation is available at the current URL, Blazor's enhanced navigation is activated.</li><li>Otherwise, Blazor performs a full-page reload for the requested URL.</li></ul>If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side interactive router.</li></ul><p>For more information, see the [Enhanced navigation and form handling](#enhanced-navigation-and-form-handling) section.</p><p>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack.</p> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section. |
| [`RegisterLocationChangingHandler`](#handleprevent-location-changes) | Registers a handler to process incoming navigation events. Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> always invokes the handler. |
| <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section. |

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section. |
| [`RegisterLocationChangingHandler`](#handleprevent-location-changes) | Registers a handler to process incoming navigation events. Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> always invokes the handler. |
| <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section. |

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section. |
| <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section. |

:::moniker-end

:::moniker range="< aspnetcore-6.0"

| Member | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)). |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section. |

:::moniker-end

## Location changes

For the <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> event, <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs> provides the following information about navigation events:

* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.Location>: The URL of the new location.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs.IsNavigationIntercepted>: If `true`, Blazor intercepted the navigation from the browser. If `false`, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> caused the navigation to occur.

The following component:

* Navigates to the app's `Counter` component (`Counter.razor`) when the button is selected using <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A>.
* Handles the location changed event by subscribing to <xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged?displayProperty=nameWithType>.
  * The `HandleLocationChanged` method is unhooked when `Dispose` is called by the framework. Unhooking the method permits garbage collection of the component.
  * The logger implementation logs the following information when the button is selected:

    > :::no-loc text="BlazorSample.Pages.Navigate: Information: URL of new location: https://localhost:{PORT}/counter":::

`Navigate.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Navigate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/routing/Navigate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/routing/Navigate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/routing/Navigate.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/routing/Navigate.razor":::

:::moniker-end

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

:::moniker range=">= aspnetcore-8.0"

## Enhanced navigation and form handling

*This section applies to Blazor Web Apps.*

Blazor Web Apps are capable of two types of routing for page navigation and form handling requests:

* Normal navigation (cross-document navigation): a full-page reload is triggered for the request URL.
* Enhanced navigation (same-document navigation)&dagger;: Blazor intercepts the request and performs a `fetch` request instead. Blazor then patches the response content into the page's DOM. Blazor's enhanced navigation and form handling avoid the need for a full-page reload and preserves more of the page state, so pages load faster, usually without losing the user's scroll position on the page.

&dagger;Enhanced navigation is available when:

* The Blazor Web App script (`blazor.web.js`) is used, not the Blazor Server script (`blazor.server.js`) or Blazor WebAssembly script (`blazor.webassembly.js`).
* The feature isn't [explicitly disabled](xref:blazor/fundamentals/startup#disable-enhanced-navigation-and-form-handling).
* The destination URL is within the internal base URI space (the app's base path).

If server-side routing and enhanced navigation are enabled, [location changing handlers](#location-changes) are only invoked for programmatic navigation initiated from an interactive runtime. In future releases, additional types of navigation, such as link clicks, may also invoke location changing handlers.

When an enhanced navigation occurs, [`LocationChanged` event handlers](#location-changes) registered with Interactive Server and WebAssembly runtimes are typically invoked. There are cases when location changing handlers might not intercept an enhanced navigation. For example, the user might switch to another page before an interactive runtime becomes available. Therefore, it's important that app logic not rely on invoking a location changing handler, as there's no guarantee of the handler executing.

When calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A>:

* If `forceLoad` is `false`, which is the default:
  * And enhanced navigation is available at the current URL, Blazor's enhanced navigation is activated.
  * Otherwise, Blazor performs a full-page reload for the requested URL.
* If `forceLoad` is `true`: Blazor performs a full-page reload for the requested URL, whether enhanced navigation is available or not.

You can refresh the current page by calling `NavigationManager.Refresh(bool forceLoad = false)`, which always performs an enhanced navigation, if available. If enhanced navigation isn't available, Blazor performs a full-page reload.

```csharp
Navigation.Refresh();
```

Pass `true` to the `forceLoad` parameter to ensure a full-page reload is always performed, even if enhanced navigation is available:

```csharp
Navigation.Refresh(true);
```

Enhanced navigation is enabled by default, but it can be controlled hierarchically and on a per-link basis using the `data-enhance-nav` HTML attribute.

The following examples disable enhanced navigation:

```html
<a href="redirect" data-enhance-nav="false">
    GET without enhanced navigation
</a>
```

```razor
<ul data-enhance-nav="false">
    <li>
        <a href="redirect">GET without enhanced navigation</a>
    </li>
    <li>
        <a href="redirect-2">GET without enhanced navigation</a>
    </li>
</ul>
```

If the destination is a non-Blazor endpoint, enhanced navigation doesn't apply, and the client-side JavaScript retries as a full page load. This ensures no confusion to the framework about external pages that shouldn't be patched into an existing page.

To enable enhanced form handling, add the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Enhance%2A> parameter to <xref:Microsoft.AspNetCore.Components.Forms.EditForm> forms or the `data-enhance` attribute to HTML forms (`<form>`):

```razor
<EditForm Enhance ...>
    ...
</EditForm>
```

```html
<form ... data-enhance>
    ...
</form>
```

Enhanced form handling isn't hierarchical and doesn't flow to child forms:

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> You can't set enhanced navigation on a form's ancestor element to enable enhanced navigation for the form.

```html
<div data-enhance>
    <form ...>
        <!-- NOT enhanced -->
    </form>
</div>
```

Enhanced form posts only work with Blazor endpoints. Posting an enhanced form to non-Blazor endpoint results in an error.

To disable enhanced navigation:

* For an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, remove the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Enhance%2A> parameter from the form element (or set it to `false`: `Enhance="false"`).
* For an HTML `<form>`, remove the `data-enhance` attribute from form element (or set it to `false`: `data-enhance="false"`).

Blazor's enhanced navigation and form handing may undo dynamic changes to the DOM if the updated content isn't part of the server rendering. To preserve the content of an element, use the `data-permanent` attribute.

In the following example, the content of the `<div>` element is updated dynamically by a script when the page loads:

```html
<div data-permanent>
    ...
</div>
```

Once Blazor has started on the client, you can use the `enhancedload` event to listen for enhanced page updates. This allows for re-applying changes to the DOM that may have been undone by an enhanced page update.

```javascript
Blazor.addEventListener('enhancedload', () => console.log('Enhanced update!'));
```

To disable enhanced navigation and form handling globally, see <xref:blazor/fundamentals/startup#disable-enhanced-navigation-and-form-handling>.

Enhanced navigation with [static server-side rendering (static SSR)](xref:blazor/components/render-modes#static-server-side-rendering-static-ssr) requires special attention when loading JavaScript. For more information, see <xref:blazor/js-interop/ssr>.

:::moniker-end

## Produce a URI relative to the base URI prefix

Based on the app's base URI, <xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> converts an absolute URI into a URI relative to the base URI prefix.

Consider the following example:

```csharp
try
{
    baseRelativePath = Navigation.ToBaseRelativePath(inputURI);
}
catch (ArgumentException ex)
{
    ...
}
```

If the base URI of the app is `https://localhost:8000`, the following results are obtained:

* Passing `https://localhost:8000/segment` in `inputURI` results in a `baseRelativePath` of `segment`.
* Passing `https://localhost:8000/segment1/segment2` in `inputURI` results in a `baseRelativePath` of `segment1/segment2`.

If the base URI of the app doesn't match the base URI of `inputURI`, an <xref:System.ArgumentException> is thrown.

Passing `https://localhost:8001/segment` in `inputURI` results in the following exception:

> :::no-loc text="System.ArgumentException: 'The URI 'https://localhost:8001/segment' is not contained by the base URI 'https://localhost:8000/'.'":::

:::moniker range=">= aspnetcore-7.0"

## Navigation history state

The <xref:Microsoft.AspNetCore.Components.NavigationManager> uses the browser's [History API](https://developer.mozilla.org/docs/Web/API/History_API) to maintain navigation history state associated with each location change made by the app. Maintaining history state is particularly useful in external redirect scenarios, such as when [authenticating users with external identity providers](xref:blazor/security/webassembly/index#customize-authorization). For more information, see the [Navigation options](#navigation-options) section.

## Navigation options

Pass <xref:Microsoft.AspNetCore.Components.NavigationOptions> to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> to control the following behaviors:

* <xref:Microsoft.AspNetCore.Components.NavigationOptions.ForceLoad>: Bypass client-side routing and force the browser to load the new page from the server, whether or not the URI is handled by the client-side router. The default value is `false`.
* <xref:Microsoft.AspNetCore.Components.NavigationOptions.ReplaceHistoryEntry>: Replace the current entry in the history stack. If `false`, append the new entry to the history stack. The default value is `false`.
* <xref:Microsoft.AspNetCore.Components.NavigationOptions.HistoryEntryState>: Gets or sets the state to append to the history entry.

```csharp
Navigation.NavigateTo("/path", new NavigationOptions
{
    HistoryEntryState = "Navigation state"
});
```

For more information on obtaining the state associated with the target history entry while handling location changes, see the [Handle/prevent location changes](#handleprevent-location-changes) section.

:::moniker-end

## Query strings

:::moniker range=">= aspnetcore-8.0"

Use the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute) to specify that a component parameter comes from the query string.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Use the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute) with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute) to specify that a component parameter of a *routable* component comes from the query string.

> [!NOTE]
> Component parameters can only receive query parameter values in routable components with an [`@page`](xref:mvc/views/razor#page) directive.
>
> Only routable components directly receive query parameters in order to avoid subverting top-down information flow and to make parameter processing order clear, both by the framework and by the app. This design avoids subtle bugs in app code that was written assuming a specific parameter processing order. You're free to define custom cascading parameters or directly assign to regular component parameters in order to pass query parameter values to non-routable components.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Component parameters supplied from the query string support the following types:

* `bool`, `DateTime`, `decimal`, `double`, `float`, `Guid`, `int`, `long`, `string`.
* Nullable variants of the preceding types.
* Arrays of the preceding types, whether they're nullable or not nullable.

The correct culture-invariant formatting is applied for the given type (<xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType>).

Specify the `[SupplyParameterFromQuery]` attribute's <xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute.Name> property to use a query parameter name different from the component parameter name. In the following example, the C# name of the component parameter is `{COMPONENT PARAMETER NAME}`. A different query parameter name is specified for the `{QUERY PARAMETER NAME}` placeholder:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
[SupplyParameterFromQuery(Name = "{QUERY PARAMETER NAME}")]
public string? {COMPONENT PARAMETER NAME} { get; set; }
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```csharp
[Parameter]
[SupplyParameterFromQuery(Name = "{QUERY PARAMETER NAME}")]
public string? {COMPONENT PARAMETER NAME} { get; set; }
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

In the following example with a URL of `/search?filter=scifi%20stars&page=3&star=LeVar%20Burton&star=Gary%20Oldman`:

* The `Filter` property resolves to `scifi stars`.
* The `Page` property resolves to `3`.
* The `Stars` array is filled from query parameters named `star` (`Name = "star"`) and resolves to `LeVar Burton` and `Gary Oldman`.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

> [!NOTE]
> The query string parameters in the following routable page component also work in a *non-routable* component without an `@page` directive (for example, `Search.razor` for a shared `Search` component used in other components).

`Search.razor`:

```razor
@page "/search"

<h1>Search Example</h1>

<p>Filter: @Filter</p>

<p>Page: @Page</p>

@if (Stars is not null)
{
    <p>Stars:</p>

    <ul>
        @foreach (var name in Stars)
        {
            <li>@name</li>
        }
    </ul>
}

@code {
    [SupplyParameterFromQuery]
    public string? Filter { get; set; }

    [SupplyParameterFromQuery]
    public int? Page { get; set; }

    [SupplyParameterFromQuery(Name = "star")]
    public string[]? Stars { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

`Search.razor`:

```razor
@page "/search"

<h1>Search Example</h1>

<p>Filter: @Filter</p>

<p>Page: @Page</p>

@if (Stars is not null)
{
    <p>Stars:</p>

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

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Use [`NavigationManager.GetUriWithQueryParameter`](xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A) to add, change, or remove one or more query parameters on the current URL:

```razor
@inject NavigationManager Navigation

...

Navigation.GetUriWithQueryParameter("{NAME}", {VALUE})
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
@inject NavigationManager Navigation

...

Navigation.GetUriWithQueryParameters({PARAMETERS})
```

The `{PARAMETERS}` placeholder is an `IReadOnlyDictionary<string, object>`.

Pass a URI string to <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameters%2A> to generate a new URI from a provided URI with multiple parameters added, updated, or removed. For each value, the framework uses `value?.GetType()` to determine the runtime type for each query parameter and selects the correct culture-invariant formatting. The framework throws an error for unsupported types. Supported types are listed later in this section.

```razor
@inject NavigationManager Navigation

...

Navigation.GetUriWithQueryParameters("{URI}", {PARAMETERS})
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
Navigation.GetUriWithQueryParameter("full name", "Morena Baccarin")
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
Navigation.GetUriWithQueryParameter("name", "Morena Baccarin")
```

| Current URL | Generated URL |
| --- | --- |
| `scheme://host/?age=42` | `scheme://host/?age=42&name=Morena%20Baccarin` |
| `scheme://host/` | `scheme://host/?name=Morena%20Baccarin` |
| `scheme://host/?` | `scheme://host/?name=Morena%20Baccarin` |

### Remove a query parameter when the parameter value is `null`

```csharp
Navigation.GetUriWithQueryParameter("full name", (string)null)
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
Navigation.GetUriWithQueryParameters(
    new Dictionary<string, object?>
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
Navigation.GetUriWithQueryParameters(
    new Dictionary<string, object?>
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
Navigation.NavigateTo(
    Navigation.GetUriWithQueryParameter("name", "Morena Baccarin"));
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The query string of a request is obtained from the <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> property:

```razor
@inject NavigationManager Navigation

...

var query = new Uri(Navigation.Uri).Query;
```

To parse a query string's parameters, one approach is to use [`URLSearchParams`](https://developer.mozilla.org/docs/Web/API/URLSearchParams) with [JavaScript (JS) interop](xref:blazor/js-interop/call-javascript-from-dotnet):

```javascript
export createQueryString = (string queryString) => new URLSearchParams(queryString);
```

For more information on JavaScript isolation with JavaScript modules, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Hashed routing to named elements

Navigate to a named element using the following approaches with a hashed (`#`) reference to the element. Routes to elements within the component and routes to elements in external components use root-relative paths. A leading forward slash (`/`) is optional.

Examples for each of the following approaches demonstrate navigation to an element with an `id` of `targetElement` in the `Counter` component:

* Anchor element (`<a>`) with an `href`:

  ```razor
  <a href="/counter#targetElement">
  ```

* <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component with an `href`:

  ```razor
  <NavLink href="/counter#targetElement">
  ```

* <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> passing the relative URL:

  ```csharp
  Navigation.NavigateTo("/counter#targetElement");
  ```

The following example demonstrates hashed routing to named H2 headings within a component and to external components.

In the `Home` (`Home.razor`) and `Counter` (`Counter.razor`) components, place the following markup at the bottoms of the existing component markup to serve as navigation targets. The `<div>` creates artificial vertical space to demonstrate browser scrolling behavior:

```razor
<div class="border border-info rounded bg-info" style="height:500px"></div>

<h2 id="targetElement">Target H2 heading</h2>
<p>Content!</p>
```

Add the following `HashedRouting` component to the app.

`HashedRouting.razor`:

```razor
@page "/hashed-routing"
@inject NavigationManager Navigation

<PageTitle>Hashed routing</PageTitle>

<h1>Hashed routing to named elements</h1>

<ul>
    <li>
        <a href="/hashed-routing#targetElement">
            Anchor in this component
        </a>
    </li>
    <li>
        <a href="/#targetElement">
            Anchor to the <code>Home</code> component
        </a>
    </li>
    <li>
        <a href="/counter#targetElement">
            Anchor to the <code>Counter</code> component
        </a>
    </li>
    <li>
        <NavLink href="/hashed-routing#targetElement">
            Use a `NavLink` component in this component
        </NavLink>
    </li>
    <li>
        <button @onclick="NavigateToElement">
            Navigate with <code>NavigationManager</code> to the 
            <code>Counter</code> component
        </button>
    </li>
</ul>

<div class="border border-info rounded bg-info" style="height:500px"></div>

<h2 id="targetElement">Target H2 heading</h2>
<p>Content!</p>

@code {
    private void NavigateToElement()
    {
        Navigation.NavigateTo("/counter#targetElement");
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## User interaction with `<Navigating>` content

If there's a significant delay during navigation, such as while [lazy-loading assemblies in a Blazor WebAssembly app](xref:blazor/webassembly-lazy-load-assemblies) or for a slow network connection to a Blazor server-side app, the <xref:Microsoft.AspNetCore.Components.Routing.Router> component can indicate to the user that a page transition is occurring.

At the top of the component that specifies the <xref:Microsoft.AspNetCore.Components.Routing.Router> component, add an [`@using`](xref:mvc/views/razor#using) directive for the <xref:Microsoft.AspNetCore.Components.Routing?displayProperty=fullName> namespace:

```razor
@using Microsoft.AspNetCore.Components.Routing
```

Provide content to the <xref:Microsoft.AspNetCore.Components.Routing.Router.Navigating> parameter for display during page transition events.

In the router element (`<Router>...</Router>`) content:

```razor
<Navigating>
    <p>Loading the requested page&hellip;</p>
</Navigating>
```

For an example that uses the <xref:Microsoft.AspNetCore.Components.Routing.Router.Navigating> property, see <xref:blazor/webassembly-lazy-load-assemblies#user-interaction-with-navigating-content>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## Handle asynchronous navigation events with `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component supports an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> feature. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> handler is invoked when the user:

* Visits a route for the first time by navigating to it directly in their browser.
* Navigates to a new route using a link or a <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> invocation.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```razor
<Router AppAssembly="@typeof(App).Assembly" 
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

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

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

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

For an example that uses <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync>, see <xref:blazor/webassembly-lazy-load-assemblies>.

When prerendering on the server, <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice*:

* Once when the requested endpoint component is initially rendered statically.
* A second time when the browser renders the endpoint component.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

To prevent developer code in <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> from executing twice, the `Routes` component can store the <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> for use in [`OnAfterRender{Async}`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync), where `firstRender` can be checked. For more information, see [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop) in the *Blazor Lifecycle* article.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

To prevent developer code in <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> from executing twice, the `App` component can store the <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> for use in [`OnAfterRender{Async}`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync), where `firstRender` can be checked. For more information, see [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop) in the *Blazor Lifecycle* article.

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## Handle cancellations in `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> object passed to the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback contains a <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken> that's set when a new navigation event occurs. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback must throw when this cancellation token is set to avoid continuing to run the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback on an outdated navigation.

If a user navigates to an endpoint but then immediately navigates to a new endpoint, the app shouldn't continue running the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback for the first endpoint.

In the following example:

* The cancellation token is passed in the call to `PostAsJsonAsync`, which can cancel the POST if the user navigates away from the `/about` endpoint.
* The cancellation token is set during a product prefetch operation if the user navigates away from the `/store` endpoint.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```razor
@inject HttpClient Http
@inject ProductCatalog Products

<Router AppAssembly="@typeof(App).Assembly" 
    OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private async Task OnNavigateAsync(NavigationContext context)
    {
        if (context.Path == "/about") 
        {
            var stats = new Stats { Page = "/about" };
            await Http.PostAsJsonAsync("api/visited", stats, 
                context.CancellationToken);
        }
        else if (context.Path == "/store")
        {
            var productIds = new[] { 345, 789, 135, 689 };

            foreach (var productId in productIds) 
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                Products.Prefetch(productId);
            }
        }
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

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
            var stats = new Stats { Page = "/about" };
            await Http.PostAsJsonAsync("api/visited", stats, 
                context.CancellationToken);
        }
        else if (context.Path == "/store")
        {
            var productIds = new[] { 345, 789, 135, 689 };

            foreach (var productId in productIds) 
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                Products.Prefetch(productId);
            }
        }
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

> [!NOTE]
> Not throwing if the cancellation token in <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> is canceled can result in unintended behavior, such as rendering a component from a previous navigation.

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Handle/prevent location changes

<xref:Microsoft.AspNetCore.Components.NavigationManager.RegisterLocationChangingHandler%2A> registers a handler to process incoming navigation events. The handler's context provided by <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext> includes the following properties:

* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.TargetLocation>: Gets the target location.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.HistoryEntryState>: Gets the state associated with the target history entry.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.IsNavigationIntercepted>: Gets whether the navigation was intercepted from a link.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.CancellationToken>: Gets a <xref:System.Threading.CancellationToken> to determine if the navigation was canceled, for example, to determine if the user triggered a different navigation.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.PreventNavigation%2A>: Called to prevent the navigation from continuing.

A component can register multiple location changing handlers in its [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). Navigation invokes all of the location changing handlers registered across the entire app (across multiple components), and any internal navigation executes them all in parallel. In addition to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> handlers are invoked:

* When selecting internal links, which are links that point to URLs under the app's base path.
* When navigating using the forward and back buttons in a browser.

Handlers are only executed for internal navigation within the app. If the user selects a link that navigates to a different site or changes the address bar to a different site manually, location changing handlers aren't executed.

Implement <xref:System.IDisposable> and dispose registered handlers to unregister them. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

> [!IMPORTANT]
> Don't attempt to execute DOM cleanup tasks via JavaScript (JS) interop when handling location changes. Use the [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JS on the client. For more information, see <xref:blazor/js-interop/index#dom-cleanup-tasks-during-component-disposal>.

In the following example, a location changing handler is registered for navigation events.

`NavHandler.razor`:

```razor
@page "/nav-handler"
@implements IDisposable
@inject NavigationManager Navigation

<p>
    <button @onclick="@(() => Navigation.NavigateTo("/"))">
        Home (Allowed)
    </button>
    <button @onclick="@(() => Navigation.NavigateTo("/counter"))">
        Counter (Prevented)
    </button>
</p>

@code {
    private IDisposable? registration;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            registration = 
                Navigation.RegisterLocationChangingHandler(OnLocationChanging);
        }
    }

    private ValueTask OnLocationChanging(LocationChangingContext context)
    {
        if (context.TargetLocation == "/counter")
        {
            context.PreventNavigation();
        }

        return ValueTask.CompletedTask;
    }

    public void Dispose() => registration?.Dispose();
}
```

Since internal navigation can be canceled asynchronously, multiple overlapping calls to registered handlers may occur. For example, multiple handler calls may occur when the user rapidly selects the back button on a page or selects multiple links before a navigation is executed. The following is a summary of the asynchronous navigation logic:

* If any location changing handlers are registered, all navigation is initially reverted, then replayed if the navigation isn't canceled.
* If overlapping navigation requests are made, the latest request always cancels earlier requests, which means the following:
  * The app may treat multiple back and forward button selections as a single selection.
  * If the user selects multiple links before the navigation completes, the last link selected determines the navigation.

For more information on passing <xref:Microsoft.AspNetCore.Components.NavigationOptions> to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> to control entries and state of the navigation history stack, see the [Navigation options](#navigation-options) section.

For additional example code, see the [`NavigationManagerComponent` in the `BasicTestApp` (`dotnet/aspnetcore` reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/RouterTest/NavigationManagerComponent.razor).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

The [`NavigationLock` component](xref:Microsoft.AspNetCore.Components.Routing.NavigationLock) intercepts navigation events as long as it is rendered, effectively "locking" any given navigation until a decision is made to either proceed or cancel. Use `NavigationLock` when navigation interception can be scoped to the lifetime of a component.

<xref:Microsoft.AspNetCore.Components.Routing.NavigationLock> parameters:

* <xref:Microsoft.AspNetCore.Components.Routing.NavigationLock.ConfirmExternalNavigation> sets a browser dialog to prompt the user to either confirm or cancel external navigation. The default value is `false`. Displaying the confirmation dialog requires initial user interaction with the page before triggering external navigation with the URL in the browser's address bar. For more information on the interaction requirement, see [Window: `beforeunload` event (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Window/beforeunload_event).
* <xref:Microsoft.AspNetCore.Components.Routing.NavigationLock.OnBeforeInternalNavigation> sets a callback for internal navigation events.

In the following `NavLock` component:

* An attempt to follow the link to Microsoft's website must be confirmed by the user before the navigation to `https://www.microsoft.com` succeeds.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.PreventNavigation%2A> is called to prevent navigation from occurring if the user declines to confirm the navigation via a [JavaScript (JS) interop call](xref:blazor/js-interop/call-javascript-from-dotnet) that spawns the [JS `confirm` dialog](https://developer.mozilla.org/docs/Web/API/Window/confirm).

`NavLock.razor`:

```razor
@page "/nav-lock"
@inject IJSRuntime JSRuntime
@inject NavigationManager Navigation

<NavigationLock ConfirmExternalNavigation="true" 
    OnBeforeInternalNavigation="OnBeforeInternalNavigation" />

<p>
    <button @onclick="Navigate">Navigate</button>
</p>

<p>
    <a href="https://www.microsoft.com">Microsoft homepage</a>
</p>

@code {
    private void Navigate()
    {
        Navigation.NavigateTo("/");
    }

    private async Task OnBeforeInternalNavigation(LocationChangingContext context)
    {
        var isConfirmed = await JSRuntime.InvokeAsync<bool>("confirm", 
            "Are you sure you want to navigate to the root page?");

        if (!isConfirmed)
        {
            context.PreventNavigation();
        }
    }
}
```

For additional example code, see the [`ConfigurableNavigationLock` component in the `BasicTestApp` (`dotnet/aspnetcore` reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/RouterTest/ConfigurableNavigationLock.razor).

:::moniker-end

## `NavLink` component

Use a <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component in place of HTML hyperlink elements (`<a>`) when creating navigation links. A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. Optionally, assign a CSS class name to <xref:Microsoft.AspNetCore.Components.Routing.NavLink.ActiveClass?displayProperty=nameWithType> to apply a custom CSS class to the rendered link when the current route matches the `href`.

There are two <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch> options that you can assign to the `Match` attribute of the `<NavLink>` element:

* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType>: The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches the entire current URL.
* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.Prefix?displayProperty=nameWithType> (*default*): The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches any prefix of the current URL.

In the preceding example, the Home <xref:Microsoft.AspNetCore.Components.Routing.NavLink> `href=""` matches the home URL and only receives the `active` CSS class at the app's default base path (`/`). The second <xref:Microsoft.AspNetCore.Components.Routing.NavLink> receives the `active` class when the user visits any URL with a `component` prefix (for example, `/component` and `/component/another-segment`).

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
>         <NavLink ... href="product-number/@c">
>             <span ...></span> Product #@current
>         </NavLink>
>     </li>
> }
> ```
>
> Using an index variable in this scenario is a requirement for **any** child component that uses a loop variable in its [child content](xref:blazor/components/index#child-content-render-fragments), not just the `NavLink` component.
>
> Alternatively, use a `foreach` loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType>:
>
> ```razor
> @foreach (var c in Enumerable.Range(0,10))
> {
>     <li ...>
>         <NavLink ... href="product-number/@c">
>             <span ...></span> Product #@c
>         </NavLink>
>     </li>
> }
> ```

## ASP.NET Core endpoint routing integration

:::moniker range=">= aspnetcore-8.0"

*This section applies to Blazor Web Apps operating over a circuit.*

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to Blazor Server apps.*

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

A Blazor Web App is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> in the `Program` file.  The default root component (first component loaded) is the `App` component (`App.razor`):

```csharp
app.MapRazorComponents<App>();
```

<!-- UPDATE 8.0 Any additional remarks for BWAs? -->

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in the `Program` file:

```csharp
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in `Startup.Configure`.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named `_Host.cshtml` in the `Pages` folder of the app.

The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is used when other routes don't match. This allows the app to use other controllers and pages without interfering with component routing in the Blazor Server app.

For information on configuring <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for non-root URL server hosting, see <xref:blazor/host-and-deploy/index#app-base-path>.

:::moniker-end
