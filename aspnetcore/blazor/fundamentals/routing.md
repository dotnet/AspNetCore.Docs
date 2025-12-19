---
title: ASP.NET Core Blazor routing
author: guardrex
description: Learn about Blazor app request routing with guidance on static versus interactive routing, endpoint routing integration, navigation events, and route templates and constraints for Razor components.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 12/09/2025
uid: blazor/fundamentals/routing
---
# ASP.NET Core Blazor routing

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains Blazor app request routing with guidance on static versus interactive routing, ASP.NET Core endpoint routing integration, navigation events, and route templates and constraints for Razor components.

Routing in Blazor is achieved by providing a route template to each accessible component in the app with an [`@page`](xref:mvc/views/razor#page) directive. When a Razor file with an `@page` directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Components.RouteAttribute> specifying the route template. At runtime, the router searches for component classes with a <xref:Microsoft.AspNetCore.Components.RouteAttribute> and renders whichever component has a route template that matches the requested URL.

The following `HelloWorld` component uses a route template of `/hello-world`, and the rendered webpage for the component is reached at the relative URL `/hello-world`.

`HelloWorld.razor`:

```razor
@page "/hello-world"

<h1>Hello World!</h1>
```

The preceding component loads in the browser at `/hello-world` regardless of whether or not you add the component to the app's UI navigation as a link.

:::moniker range=">= aspnetcore-8.0"

## Static versus interactive routing

*This section applies to Blazor Web Apps.*

If [prerendering is enabled](xref:blazor/components/prerender), the Blazor router (`Router` component, `<Router>` in `Routes.razor`) performs static routing to components during static server-side rendering (static SSR). This type of routing is called *static routing*.

When an interactive render mode is assigned to the `Routes` component, the Blazor router becomes interactive after static SSR with static routing on the server. This type of routing is called *interactive routing*.

Static routers use endpoint routing and the HTTP request path to determine which component to render. When the router becomes interactive, it uses the document's URL (the URL in the browser's address bar) to determine which component to render. This means that the interactive router can dynamically change which component is rendered if the document's URL dynamically changes to another valid internal URL, and it can do so without performing an HTTP request to fetch new page content.

Interactive routing also prevents prerendering because new page content isn't requested from the server with a normal page request. For more information, see <xref:blazor/state-management/prerendered-state-persistence#interactive-routing-and-prerendering>.

:::moniker-end

## ASP.NET Core endpoint routing integration

:::moniker range=">= aspnetcore-8.0"

*This section applies to Blazor Web Apps operating over a circuit.*

A Blazor Web App is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured with endpoints for routable components and the root component to render for those endpoints with <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> in the `Program` file.  The default root component (first component loaded) is the `App` component (`App.razor`):

```csharp
app.MapRazorComponents<App>();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

*This section applies to Blazor Server apps operating over a circuit.*

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in the `Program` file:

```csharp
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

*This section applies to Blazor Server apps operating over a circuit.*

Blazor Server is integrated into [ASP.NET Core Endpoint Routing](xref:fundamentals/routing). An ASP.NET Core app is configured to accept incoming connections for interactive components with <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> in `Startup.Configure`.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The typical configuration is to route all requests to a Razor page, which acts as the host for the server-side part of the Blazor Server app. By convention, the *host* page is usually named `_Host.cshtml` in the `Pages` folder of the app.

The route specified in the host file is called a *fallback route* because it operates with a low priority in route matching. The fallback route is used when other routes don't match. This allows the app to use other controllers and pages without interfering with component routing in the Blazor Server app.

For information on configuring <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> for non-root URL server hosting, see <xref:blazor/host-and-deploy/app-base-path>.

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

```razor
@page "/blazor-route"
@page "/different-blazor-route"

<h1>Routing Example</h1>

<p>
    This page is reached at either <code>/blazor-route</code> or 
    <code>/different-blazor-route</code>.
</p>
```

> [!IMPORTANT]
> For URLs to resolve correctly, the app must include a `<base>` tag ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)) with the app base path specified in the `href` attribute. For more information, see <xref:blazor/host-and-deploy/app-base-path>.

:::moniker range="< aspnetcore-6.0"

The <xref:Microsoft.AspNetCore.Components.Routing.Router> doesn't interact with query string values. To work with query strings, see [Query strings](xref:blazor/fundamentals/navigation#query-strings).

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
<FocusOnNavigate RouteData="routeData" Selector="h1" />
```

When the <xref:Microsoft.AspNetCore.Components.Routing.Router> component navigates to a new page, the <xref:Microsoft.AspNetCore.Components.Routing.FocusOnNavigate> component sets the focus to the page's top-level header (`<h1>`). This is a common strategy for ensuring that a page navigation is announced when using a screen reader.

:::moniker-end

## Provide custom content when content isn't found

:::moniker range=">= aspnetcore-10.0"

For requests where content isn't found, a Razor component can be assigned to <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFoundPage%2A?displayProperty=nameWithType>. The parameter works in concert with [`NavigationManager.NotFound`](xref:blazor/fundamentals/navigation#not-found-responses), a method called in developer code that triggers a Not Found response.

The Blazor project template includes a `NotFound.razor` page. This page automatically renders whenever <xref:Microsoft.AspNetCore.Components.NavigationManager.NotFound%2A> is called, making it possible to handle missing routes with a consistent user experience.

`NotFound.razor`:

```razor
@page "/not-found"
@layout MainLayout

<h3>Not Found</h3>
<p>Sorry, the content you are looking for does not exist.</p>
```

The `NotFound` component is assigned to the router's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFoundPage%2A?displayProperty=nameWithType> parameter, which supports routing that can be used across Status Code Pages Re-execution Middleware, including non-Blazor middleware.

In the following example, the preceding `NotFound` component is present in the app's `Pages` folder and passed to the <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFoundPage%2A?displayProperty=nameWithType> parameter:

```razor
<Router AppAssembly="@typeof(Program).Assembly" NotFoundPage="typeof(Pages.NotFound)">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
</Router>
```

For more information, see the next article on <xref:blazor/fundamentals/navigation#not-found-responses>.

:::moniker-end

:::moniker range="< aspnetcore-10.0"

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

Blazor Web Apps don't use the <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> parameter (`<NotFound>...</NotFound>` markup), but the parameter is supported&dagger; for backward compatibility in .NET 8/9 to avoid a breaking change in the framework. The server-side ASP.NET Core middleware pipeline processes requests on the server. Use server-side techniques to handle bad requests.

&dagger;*Supported* in this context means that placing `<NotFound>...</NotFound>` markup doesn't result in an exception, but using the markup isn't effective either.

For more information, see the following resources:

* <xref:blazor/components/render-modes#static-server-side-rendering-static-ssr>
* [Blazor navigation: Not Found responses](xref:blazor/fundamentals/navigation#not-found-responses)

:::moniker-end

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

Internal navigation for interactive routing doesn't involve requesting new page content from the server. Therefore, prerendering doesn't occur for internal page requests. For more information, see <xref:blazor/state-management/prerendered-state-persistence#interactive-routing-and-prerendering>.

If the `Routes` component is defined in the server project, the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> parameter of the `Router` component should include the `.Client` project's assembly. This allows the router to work correctly when rendered interactively.

In the following example, the `Routes` component is in the server project, and the `_Imports.razor` file of the `BlazorSample.Client` project indicates the assembly to search for routable components:

```razor
<Router
    AppAssembly="..."
    AdditionalAssemblies="[ typeof(BlazorSample.Client._Imports).Assembly ]">
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

```razor
@page "/route-parameter-1/{text}"

<h1>Route Parameter Example 1</h1>

<p>Blazor is @Text!</p>

@code {
    [Parameter]
    public string? Text { get; set; }
}
```

:::moniker range=">= aspnetcore-5.0"

Optional parameters are supported. In the following example, the `text` optional parameter assigns the value of the route segment to the component's `Text` property. If the segment isn't present, the value of `Text` is set to `fantastic`.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Optional parameters aren't supported. In the following example, two [`@page` directives](xref:mvc/views/razor#page) are applied. The first directive permits navigation to the component without a parameter. The second directive assigns the `{text}` route parameter value to the component's `Text` property.

:::moniker-end

`RouteParameter2.razor`:

```razor
@page "/route-parameter-2/{text?}"

<h1>Route Parameter Example 2</h1>

<p>Blazor is @Text!</p>

@code {
    [Parameter]
    public string? Text { get; set; }

    protected override void OnParametersSet() => Text = Text ?? "fantastic";
}
```

When the [`OnInitialized{Async}` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) is used instead of the [`OnParametersSet{Async}` lifecycle method](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync), the default assignment of the `Text` property to `fantastic` doesn't occur if the user navigates within the same component. For example, this situation arises when the user navigates from `/route-parameter-2/amazing` to `/route-parameter-2`. As the component instance persists and accepts new parameters, the `OnInitialized` method isn't invoked again.

:::moniker range="< aspnetcore-6.0"

> [!NOTE]
> Route parameters don't work with query string values. To work with query strings, see [Query strings](xref:blazor/fundamentals/navigation#query-strings).

:::moniker-end

## Route constraints

A route constraint enforces type matching on a route segment to a component.

In the following example, the route to the `User` component only matches if:

* An `Id` route segment is present in the request URL.
* The `Id` segment is an integer (`int`) type.

`User.razor`:

```razor
@page "/user/{Id:int}"

<h1>User Example</h1>

<p>User Id: @Id</p>

@code {
    [Parameter]
    public int Id { get; set; }
}
```

:::moniker range="< aspnetcore-5.0"

> [!NOTE]
> Route constraints don't work with query string values. To work with query strings, see [Query strings](xref:blazor/fundamentals/navigation#query-strings).

:::moniker-end

The route constraints shown in the following table are available. For the route constraints that match the invariant culture, see the warning below the table for more information.

Constraint | Example | Example Matches | Invariant<br>culture<br>matching
--- | --- | --- | :---:
`bool` | `{active:bool}` | `true`, `FALSE` | No
`datetime` | `{dob:datetime}` | `2016-12-31`, `2016-12-31 7:32pm` | Yes
`decimal` | `{price:decimal}` | `49.99`, `-1,000.01` | Yes
`double` | `{weight:double}` | `1.234`, `-1,001.01e8` | Yes
`float` | `{weight:float}` | `1.234`, `-1,001.01e8` | Yes
`guid` | `{id:guid}` | `00001111-aaaa-2222-bbbb-3333cccc4444`, `{00001111-aaaa-2222-bbbb-3333cccc4444}` | No
`int` | `{id:int}` | `123456789`, `-123456789` | Yes
`long` | `{ticks:long}` | `123456789`, `-123456789` | Yes
`nonfile` | `{parameter:nonfile}` | Not `BlazorSample.styles.css`, not `favicon.ico` | Yes

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

## Avoid file capture in a route parameter

The following route template inadvertently captures static asset paths in its optional route parameter (`Optional`). For example, the app's stylesheet (`.styles.css`) is captured, which breaks the app's styles:

```razor
@page "/{optional?}"

...

@code {
    [Parameter]
    public string? Optional { get; set; }
}
```

To restrict a route parameter to capturing non-file paths, use the [`:nonfile` constraint](#route-constraints) in the route template:

```razor
@page "/{optional:nonfile?}"
```

:::moniker range="< aspnetcore-8.0"

<!--
    NOTE: Section removed at 8.0 when routing with dots became supported.
-->

## Routing with URLs that contain dots

A ***server-side*** default route template assumes that if the last segment of a request URL contains a dot (`.`) that a file is requested. For example, the relative URL `/example/some.thing` is interpreted by the router as a request for a file named `some.thing`. Without additional configuration, an app returns a *404 - Not Found* response if `some.thing` was meant to route to a component with an [`@page`](xref:mvc/views/razor#page) directive and `some.thing` is a route parameter value. To use a route with one or more parameters that contain a dot, the app must configure the route with a custom template.

Consider the following `Example` component that can receive a route parameter from the last segment of the URL.

`Example.razor`:

```razor
@page "/example/{param?}"

<p>
    Param: @Param
</p>

@code {
    [Parameter]
    public string? Param { get; set; }
}
```

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

```razor
@page "/catch-all/{*pageRoute}"

<h1>Catch All Parameters Example</h1>

<p>Add some URI segments to the route and request the page again.</p>

<p>
    PageRoute: @PageRoute
</p>

@code {
    [Parameter]
    public string? PageRoute { get; set; }
}
```

For the URL `/catch-all/this/is/a/test` with a route template of `/catch-all/{*pageRoute}`, the value of `PageRoute` is set to `this/is/a/test`.

Slashes and segments of the captured path are decoded. For a route template of `/catch-all/{*pageRoute}`, the URL `/catch-all/this/is/a%2Ftest%2A` yields `this/is/a/test*`.

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## Handle asynchronous navigation events with `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component supports an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> feature. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> handler is invoked when the user:

* Visits a route for the first time by navigating to it directly in their browser.
* Navigates to a new route using a link or a <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> invocation, which is called in developer code to navigates to a URI. [<xref:Microsoft.AspNetCore.Components.NavigationManager> API is described in the next article, <xref:blazor/fundamentals/navigation>.]

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```razor
<Router AppAssembly="typeof(App).Assembly" 
    OnNavigateAsync="OnNavigateAsync">
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
<Router AppAssembly="typeof(Program).Assembly" 
    OnNavigateAsync="OnNavigateAsync">
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

To prevent developer code in <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> from executing twice, the `Routes` component can store the <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> for use in the [`OnAfterRender{Async}` lifecycle method](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync), where `firstRender` can be checked. For more information, see [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop).

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

To prevent developer code in <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> from executing twice, the `App` component can store the <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> for use in [`OnAfterRender{Async}`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync), where `firstRender` can be checked. For more information, see [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop).

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

<Router AppAssembly="typeof(App).Assembly" 
    OnNavigateAsync="OnNavigateAsync">
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

<Router AppAssembly="typeof(Program).Assembly" 
    OnNavigateAsync="OnNavigateAsync">
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
