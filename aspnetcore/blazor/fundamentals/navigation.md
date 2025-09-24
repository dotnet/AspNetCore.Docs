---
title: ASP.NET Core Blazor navigation
author: guardrex
description: Learn about navigation in Blazor, including how to use the Navigation Manager and NavLink component for navigation.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 09/24/2025
uid: blazor/fundamentals/navigation
---
# ASP.NET Core Blazor navigation

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use the <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component to create navigation links and how to use the <xref:Microsoft.AspNetCore.Components.NavigationManager> to manage URIs and navigation in C# code.

> [!IMPORTANT]
> Code examples throughout this article show methods called on `Navigation`, which is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager> in classes and components.

## `NavLink` component

Use a <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component in place of HTML hyperlink elements (`<a>`) when creating navigation links. A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. Optionally, assign a CSS class name to <xref:Microsoft.AspNetCore.Components.Routing.NavLink.ActiveClass?displayProperty=nameWithType> to apply a custom CSS class to the rendered link when the current route matches the `href`.

:::moniker range=">= aspnetcore-10.0"

There are two <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch> options that you can assign to the `Match` attribute of the `<NavLink>` element:

* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType>: The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches the current URL, ignoring the query string and fragment. To include matching on the query string/fragment, use the `Microsoft.AspNetCore.Components.Routing.NavLink.EnableMatchAllForQueryStringAndFragment` [`AppContext` switch](/dotnet/fundamentals/runtime-libraries/system-appcontext) set to `true`.
* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.Prefix?displayProperty=nameWithType> (*default*): The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches any prefix of the current URL.

:::moniker-end

:::moniker range="< aspnetcore-10.0"

There are two <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch> options that you can assign to the `Match` attribute of the `<NavLink>` element:

* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType>: The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches the entire current URL, including the query string and fragment.
* <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.Prefix?displayProperty=nameWithType> (*default*): The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> is active when it matches any prefix of the current URL.

:::moniker-end

In the preceding example, the Home <xref:Microsoft.AspNetCore.Components.Routing.NavLink> `href=""` matches the home URL and only receives the `active` CSS class at the app's default base path (`/`). The second <xref:Microsoft.AspNetCore.Components.Routing.NavLink> receives the `active` class when the user visits any URL with a `component` prefix (for example, `/component` and `/component/another-segment`).

:::moniker range=">= aspnetcore-10.0"

<!-- UPDATE 10.0 - API cross-link -->

To adopt custom matching logic, subclass <xref:Microsoft.AspNetCore.Components.Routing.NavLink> and override its `ShouldMatch` method. Return `true` from the method when you want to apply the `active` CSS class:

```csharp
public class CustomNavLink : NavLink
{
    protected override bool ShouldMatch(string currentUriAbsolute)
    {
        // Custom matching logic
    }
}
```

:::moniker-end

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
> @for (int c = 1; c < 4; c++)
> {
>     var ct = c;
>     <li ...>
>         <NavLink ...>
>             <span ...></span> Product #@ct
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
> @foreach (var c in Enumerable.Range(1, 3))
> {
>     <li ...>
>         <NavLink ...>
>             <span ...></span> Product #@c
>         </NavLink>
>     </li>
> }
> ```

## URI and navigation state helpers

Use <xref:Microsoft.AspNetCore.Components.NavigationManager> to manage URIs and navigation in C# code. <xref:Microsoft.AspNetCore.Components.NavigationManager> provides the event and methods shown in the following table.

:::moniker range=">= aspnetcore-10.0"

<!-- UPDATE 10.0 - API doc cross-links -->

Member | Description
--- | ---
<xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)).
<xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `false`:<ul><li>And enhanced navigation is available at the current URL, Blazor's enhanced navigation is activated.</li><li>Otherwise, Blazor performs a full-page reload for the requested URL.</li></ul>If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side interactive router.</li></ul><p>For more information, see the [Enhanced navigation and form handling](#enhanced-navigation-and-form-handling) section.</p><p>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack.</p>
<xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section.
`NotFound` | Called to handle scenarios where a requested resource isn't found. For more information, see the [Not Found responses](#not-found-responses) section.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section.
[`RegisterLocationChangingHandler`](#handleprevent-location-changes) | Registers a handler to process incoming navigation events. Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> always invokes the handler.
<xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section.

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-10.0"

Member | Description
--- | ---
<xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)).
<xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `false`:<ul><li>And enhanced navigation is available at the current URL, Blazor's enhanced navigation is activated.</li><li>Otherwise, Blazor performs a full-page reload for the requested URL.</li></ul>If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side interactive router.</li></ul><p>For more information, see the [Enhanced navigation and form handling](#enhanced-navigation-and-form-handling) section.</p><p>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack.</p>
<xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section.
[`RegisterLocationChangingHandler`](#handleprevent-location-changes) | Registers a handler to process incoming navigation events. Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> always invokes the handler.
<xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Member | Description
--- | ---
<xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)).
<xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack.
<xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section.
[`RegisterLocationChangingHandler`](#handleprevent-location-changes) | Registers a handler to process incoming navigation events. Calling <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> always invokes the handler.
<xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Member | Description
--- | ---
<xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)).
<xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul>If `replace` is `true`, the current URI in the browser history is replaced instead of pushing a new URI onto the history stack.
<xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed. For more information, see the [Location changes](#location-changes) section.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section.
<xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> | Returns a URI constructed by updating <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri?displayProperty=nameWithType> with a single parameter added, updated, or removed. For more information, see the [Query strings](#query-strings) section.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Member | Description
--- | ---
<xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> | Gets the current absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> | Gets the base URI (with a trailing slash) that can be prepended to relative URI paths to produce an absolute URI. Typically, <xref:Microsoft.AspNetCore.Components.NavigationManager.BaseUri> corresponds to the `href` attribute on the document's `<base>` element ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)).
<xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> | Navigates to the specified URI. If `forceLoad` is `true`:<ul><li>Client-side routing is bypassed.</li><li>The browser is forced to load the new page from the server, whether or not the URI is normally handled by the client-side router.</li></ul>
<xref:Microsoft.AspNetCore.Components.NavigationManager.LocationChanged> | An event that fires when the navigation location has changed.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToAbsoluteUri%2A> | Converts a relative URI into an absolute URI.
<xref:Microsoft.AspNetCore.Components.NavigationManager.ToBaseRelativePath%2A> | Based on the app's base URI, converts an absolute URI into a URI relative to the base URI prefix. For an example, see the [Produce a URI relative to the base URI prefix](#produce-a-uri-relative-to-the-base-uri-prefix) section.

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

```razor
@page "/navigate"
@implements IDisposable
@inject ILogger<Navigate> Logger
@inject NavigationManager Navigation

<h1>Navigate Example</h1>

<button class="btn btn-primary" @onclick="NavigateToCounterComponent">
    Navigate to the Counter component
</button>

@code {
    private void NavigateToCounterComponent() => Navigation.NavigateTo("counter");

    protected override void OnInitialized() => 
        Navigation.LocationChanged += HandleLocationChanged;

    private void HandleLocationChanged(object? sender, LocationChangedEventArgs e) => 
        Logger.LogInformation("URL of new location: {Location}", e.Location);

    public void Dispose() => Navigation.LocationChanged -= HandleLocationChanged;
}
```

For more information on component disposal, see <xref:blazor/components/component-disposal>.

:::moniker range=">= aspnetcore-9.0"

## Navigation Manager redirect behavior during static server-side rendering (static SSR)

For a redirect during static server-side rendering (static SSR), <xref:Microsoft.AspNetCore.Components.NavigationManager> relies on throwing a <xref:Microsoft.AspNetCore.Components.NavigationException> that gets captured by the framework, which converts the error into a redirect. Code that exists after the call to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> isn't called. When using Visual Studio, the debugger breaks on the exception, requiring you to deselect the checkbox for **Break when this exception type is user-handled** in the Visual Studio UI to avoid the debugger stopping for future redirects.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

You can use the `<BlazorDisableThrowNavigationException>` MSBuild property set to `true` in the app's project file to opt-in to no longer throwing a <xref:Microsoft.AspNetCore.Components.NavigationException>. Also, code after the call to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> executes when it wouldn't have run before. This behavior is enabled by default in the .NET 10 or later Blazor Web App project template:

```xml
<BlazorDisableThrowNavigationException>true</BlazorDisableThrowNavigationException>
```

:::moniker-end

:::moniker range=">= aspnetcore-9.0 < aspnetcore-10.0"

> [!NOTE]
> In .NET 10 or later, you can opt-in to not throwing a <xref:Microsoft.AspNetCore.Components.NavigationException> by setting the `<BlazorDisableThrowNavigationException>` MSBuild property to `true` in the app's project file. To take advantage of the new MSBuild property and behavior, upgrade the app to .NET 10 or later.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

## Not Found responses

<!-- UPDATE 10.0 - API doc cross-links -->

<xref:Microsoft.AspNetCore.Components.NavigationManager> provides a `NotFound` method to handle scenarios where a requested resource isn't found during static server-side rendering (static SSR) or global interactive rendering:

* **Static SSR**: Calling `NavigationManager.NotFound` sets the HTTP status code to 404.

* **Interactive rendering**: Signals the Blazor router ([`Router` component](xref:blazor/fundamentals/routing#route-templates)) to render Not Found content.

* **Streaming rendering**: If [enhanced navigation](xref:blazor/fundamentals/routing?view=aspnetcore-10.0#enhanced-navigation-and-form-handling) is active, [streaming rendering](xref:blazor/components/rendering#streaming-rendering) renders Not Found content without reloading the page. When enhanced navigation is blocked, the framework redirects to Not Found content with a page refresh.

> [!NOTE]
> The following discussion mentions that a Not Found Razor component can be assigned to the `Router` component's `NotFoundPage` parameter. The parameter works in concert with `NavigationManager.NotFound` and is described in more detail later in this section.

Streaming rendering can only render components that have a route, such as a `NotFoundPage` assignment (`NotFoundPage="..."`) or a [Status Code Pages Re-execution Middleware page assignment](xref:fundamentals/error-handling#usestatuscodepageswithreexecute) (<xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A>). `DefaultNotFound` 404 content ("`Not found`" plain text) doesn't have a route, so it can't be used during streaming rendering.

> [!NOTE]
> The Not Found render fragment (`<NotFound>...</NotFound>`) isn't supported in .NET 10 or later.

`NavigationManager.NotFound` content rendering uses the following, regardless if the response has started or not (in order):

* If <xref:Microsoft.AspNetCore.Components.Routing.NotFoundEventArgs.Path%2A?displayProperty=nameWithType> is set, render the contents of the assigned page.
* If `Router.NotFoundPage` is set, render the assigned page.
* A Status Code Pages Re-execution Middleware page, if configured.
* No action if none of the preceding approaches are adopted.

[Status Code Pages Re-execution Middleware](xref:fundamentals/error-handling#usestatuscodepageswithreexecute) with <xref:Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute%2A> takes precedence for browser-based address routing problems, such as an incorrect URL typed into the browser's address bar or selecting a link that has no endpoint in the app.

When a component is rendered statically (static SSR) and `NavigationManager.NotFound` is called, the 404 status code is set on the response:

```razor
@page "/render-not-found-ssr"
@inject NavigationManager Navigation

@code {
    protected override void OnInitialized()
    {
        Navigation.NotFound();
    }
}
```

To provide Not Found content for global interactive rendering, use a Not Found page (Razor component).

> [!NOTE]
> The Blazor project template includes a `NotFound.razor` page. This page automatically renders whenever `NavigationManager.NotFound` is called, making it possible to handle missing routes with a consistent user experience.

`Pages/NotFound.razor`:

```razor
@page "/not-found"
@layout MainLayout

<h3>Not Found</h3>
<p>Sorry, the content you are looking for does not exist.</p>
```

The `NotFound` component is assigned to the router's `NotFoundPage` parameter. `NotFoundPage` supports routing that can be used across Status Code Pages Re-execution Middleware, including non-Blazor middleware.

In the following example, the preceding `NotFound` component is present in the app's `Pages` folder and passed to the `NotFoundPage` parameter:

```razor
<Router AppAssembly="@typeof(Program).Assembly" NotFoundPage="typeof(Pages.NotFound)">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
</Router>
```

When a component is rendered with a global interactive render mode, calling `NavigationManager.NotFound` signals the Blazor router to render the `NotFound` component:

```razor
@page "/render-not-found-interactive"
@inject NavigationManager Navigation

@if (RendererInfo.IsInteractive)
{
    <button @onclick="TriggerNotFound">Trigger Not Found</button>
}

@code {
    private void TriggerNotFound()
    {
        Navigation.NotFound();
    }
}
```

You can use the `OnNotFound` event for notifications when `NavigationManager.NotFound` is invoked. The event is only fired when `NavigationManager.NotFound` is called, not for any 404 response. For example, setting `HttpContextAccessor.HttpContext.Response.StatusCode` to `404` doesn't trigger `NavigationManager.NotFound`/`OnNotFound`.

Apps that implement a custom router can also use `NavigationManager.NotFound`. The custom router can render Not Found content from two sources, depending on the state of the response:

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
                  $"doesn't have a {nameof(RouteAttribute)} applied.");
          }

          var routeAttribute = (RouteAttribute)routeAttributes[0];

          if (routeAttribute.Template != null)
          {
              e.Path = routeAttribute.Template;
          }
      }
  }
  ```

In the following example for components that adopt [interactive server-side rendering (interactive SSR)](xref:blazor/fundamentals/index#client-and-server-rendering-concepts), custom content is rendered depending on where `OnNotFound` is called. If the event is triggered by the following `Movie` component when a movie isn't found on component initialization, a custom message states that the requested movie isn't found. If the event is triggered by the `User` component in the following example, a different message states that the user isn't found.

The following `NotFoundContext` service manages the context and the message for when content isn't found by components.

`NotFoundContext.cs`:

```csharp
public class NotFoundContext
{
    public string? Heading { get; private set; }
    public string? Message { get; private set; }

    public void UpdateContext(string heading, string message)
    {
        Heading = heading;
        Message = message;
    }
}
```

The service is registered in the server-side `Program` file:

```csharp
builder.Services.AddScoped<NotFoundContext>();
```

The `NotFound` page injects the `NotFoundContext` and displays the heading and message.

`Pages/NotFound.razor`:

```razor
@page "/not-found"
@layout MainLayout
@inject NotFoundContext NotFoundContext

<h3>@NotFoundContext.Heading</h3>
<div>
    <p>@NotFoundContext.Message</p>
</div>
```

The `Routes` component (`Routes.razor`) sets the `NotFound` component as the Not Found page via the `NotFoundPage` parameter:

```razor
<Router AppAssembly="typeof(Program).Assembly" NotFoundPage="typeof(Pages.NotFound)">
    ...
</Router>
```

In the following example components:

* The `NotFoundContext` service is injected, along with the <xref:Microsoft.AspNetCore.Components.NavigationManager>.
* In <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>, `HandleNotFound` is an event handler assigned to the `OnNotFound` event. `HandleNotFound` calls `NotFoundContext.UpdateContext` to set a heading and message for Not Found content in the `NotFound` component.
* The components would normally use an ID from a route parameter to obtain a movie or user from a data store, such as a database. In the following examples, no entity is returned (`null`) to simulate what happens when an entity isn't found.
* When no entity is returned to <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>, `NavigationManager.NotFound` is called, which in turn triggers the `OnNotFound` event and the `HandleNotFound` event handler. Not Found content is displayed by the router.
* The `HandleNotFound` method is unhooked on component disposal in <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>.

`Movie` component (`Movie.razor`):

```razor
@page "/movie/{Id:int}"
@implements IDisposable
@inject NavigationManager NavigationManager
@inject NotFoundContext NotFoundContext

<div>
    No matter what ID is used, no matching movie is returned
    from the call to GetMovie().
</div>

@code {
    [Parameter]
    public int Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.OnNotFound += HandleNotFound;

        var movie = await GetMovie(Id);

        if (movie == null)
        {
            NavigationManager.NotFound();
        }
    }

    private void HandleNotFound(object? sender, NotFoundEventArgs e)
    {
        NotFoundContext.UpdateContext("Movie Not Found",
            "Sorry! The requested movie wasn't found.");
    }

    private async Task<MovieItem[]?> GetMovie(int id)
    {
        // Simulate no movie with matching id found
        return await Task.FromResult<MovieItem[]?>(null);
    }

    void IDisposable.Dispose()
    {
        NavigationManager.OnNotFound -= HandleNotFound;
    }

    public class MovieItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
```

`User` component (`User.razor`):

```razor
@page "/user/{Id:int}"
@implements IDisposable
@inject NavigationManager NavigationManager
@inject NotFoundContext NotFoundContext

<div>
    No matter what ID is used, no matching user is returned
    from the call to GetUser().
</div>

@code {
    [Parameter]
    public int Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.OnNotFound += HandleNotFound;

        var user = await GetUser(Id);

        if (user == null)
        {
            NavigationManager.NotFound();
        }
    }

    private void HandleNotFound(object? sender, NotFoundEventArgs e)
    {
        NotFoundContext.UpdateContext("User Not Found",
            "Sorry! The requested user wasn't found.");
    }

    private async Task<UserItem[]?> GetUser(int id)
    {
        // Simulate no user with matching id found
        return await Task.FromResult<UserItem[]?>(null);
    }

    void IDisposable.Dispose()
    {
        NavigationManager.OnNotFound -= HandleNotFound;
    }

    public class UserItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
```

To reach the preceding components in a local demonstration with a test app, create entries in the `NavMenu` component (`NavMenu.razor`) to reach the `Movie` and `User` components. The entity IDs, passed as route parameters, in the following example are mock values that have no effect because they aren't actually used by the components, which simulate not finding a movie or user.

In `NavMenu.razor`:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="movie/1">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Movie
    </NavLink>
</div>

<div class="nav-item px-3">
    <NavLink class="nav-link" href="user/2">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> User
    </NavLink>
</div>
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Enhanced navigation and form handling

*This section applies to Blazor Web Apps.*

Blazor Web Apps are capable of two types of routing for page navigation and form handling requests:

* Normal navigation (cross-document navigation): a full-page reload is triggered for the request URL.
* Enhanced navigation (same-document navigation): Blazor intercepts the request and performs a `fetch` request instead. Blazor then patches the response content into the page's DOM. Blazor's enhanced navigation and form handling avoid the need for a full-page reload and preserves more of the page state, so pages load faster, usually without losing the user's scroll position on the page.

Enhanced navigation is available when:

* The Blazor Web App script (`blazor.web.js`) is used, not the Blazor Server script (`blazor.server.js`) or Blazor WebAssembly script (`blazor.webassembly.js`).
* The feature isn't [explicitly disabled](xref:blazor/fundamentals/startup#disable-enhanced-navigation-and-form-handling).
* The destination URL is within the internal base URI space (the app's base path) and the link to the page doesn't have the `data-enhance-nav` attribute set to `false`.

If server-side routing and enhanced navigation are enabled, [location changing handlers](#location-changes) are only invoked for programmatic navigation initiated from an interactive runtime. In future releases, additional types of navigation, such as following a link, may also invoke location changing handlers.

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
<EditForm ... Enhance ...>
    ...
</EditForm>
```

```html
<form ... data-enhance ...>
    ...
</form>
```

Enhanced form handling isn't hierarchical and doesn't flow to child forms:

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> You can't set enhanced navigation on a form's ancestor element to enable enhanced navigation for the form.

```html
<div ... data-enhance ...>
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

Unlike component parameter properties (`[Parameter]`), `[SupplyParameterFromQuery]` properties can be marked `private` in addition to `public`.

```csharp
[SupplyParameterFromQuery(Name = "{QUERY PARAMETER NAME}")]
private string? {COMPONENT PARAMETER NAME} { get; set; }
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Just like component parameter properties (`[Parameter]`), `[SupplyParameterFromQuery]` properties are always `public` properties in .NET 6/7. In .NET 8 or later, `[SupplyParameterFromQuery]` properties can be marked `public` or `private`.

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
    private string? Filter { get; set; }

    [SupplyParameterFromQuery]
    private int? Page { get; set; }

    [SupplyParameterFromQuery(Name = "star")]
    private string[]? Stars { get; set; }
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

Use <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameter%2A> to add, change, or remove one or more query parameters on the current URL:

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

Call <xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions.GetUriWithQueryParameters%2A> to create a URI constructed from <xref:Microsoft.AspNetCore.Components.NavigationManager.Uri> with multiple parameters added, updated, or removed. For each value, the framework uses `value?.GetType()` to determine the runtime type for each query parameter and selects the correct culture-invariant formatting. The framework throws an error for unsupported types.

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
* `DateOnly`
* `DateTime`
* `decimal`
* `double`
* `float`
* `Guid`
* `int`
* `long`
* `string`
* `TimeOnly`

Supported types include:

* Nullable variants of the preceding types.
* Arrays of the preceding types, whether they're nullable or not nullable.

[!INCLUDE[](~/blazor/includes/compression-with-untrusted-data.md)]

### Replace a query parameter value when the parameter exists

```csharp
Navigation.GetUriWithQueryParameter("full name", "Morena Baccarin")
```

Current URL | Generated URL
--- | ---
`scheme://host/?full%20name=David%20Krumholtz&age=42` | `scheme://host/?full%20name=Morena%20Baccarin&age=42`
`scheme://host/?fUlL%20nAmE=David%20Krumholtz&AgE=42` | `scheme://host/?full%20name=Morena%20Baccarin&AgE=42`
`scheme://host/?full%20name=Jewel%20Staite&age=42&full%20name=Summer%20Glau` | `scheme://host/?full%20name=Morena%20Baccarin&age=42&full%20name=Morena%20Baccarin`
`scheme://host/?full%20name=&age=42` | `scheme://host/?full%20name=Morena%20Baccarin&age=42`
`scheme://host/?full%20name=` | `scheme://host/?full%20name=Morena%20Baccarin`

### Append a query parameter and value when the parameter doesn't exist

```csharp
Navigation.GetUriWithQueryParameter("name", "Morena Baccarin")
```

Current URL | Generated URL 
--- | --- 
`scheme://host/?age=42` | `scheme://host/?age=42&name=Morena%20Baccarin`
`scheme://host/` | `scheme://host/?name=Morena%20Baccarin`
`scheme://host/?` | `scheme://host/?name=Morena%20Baccarin`

### Remove a query parameter when the parameter value is `null`

```csharp
Navigation.GetUriWithQueryParameter("full name", (string)null)
```

Current URL | Generated URL
--- | ---
`scheme://host/?full%20name=David%20Krumholtz&age=42` | `scheme://host/?age=42`
`scheme://host/?full%20name=Sally%20Smith&age=42&full%20name=Summer%20Glau` | `scheme://host/?age=42`
`scheme://host/?full%20name=Sally%20Smith&age=42&FuLl%20NaMe=Summer%20Glau` | `scheme://host/?age=42`
`scheme://host/?full%20name=&age=42` | `scheme://host/?age=42`
`scheme://host/?full%20name=` | `scheme://host/`

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

Current URL | Generated URL
--- | ---
`scheme://host/?name=David%20Krumholtz&age=42` | `scheme://host/?age=25&eye%20color=green`
`scheme://host/?NaMe=David%20Krumholtz&AgE=42` | `scheme://host/?age=25&eye%20color=green`
`scheme://host/?name=David%20Krumholtz&age=42&keepme=true` | `scheme://host/?age=25&keepme=true&eye%20color=green`
`scheme://host/?age=42&eye%20color=87` | `scheme://host/?age=25&eye%20color=green`
`scheme://host/?` | `scheme://host/?age=25&eye%20color=green`
`scheme://host/` | `scheme://host/?age=25&eye%20color=green`

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

Current URL | Generated URL
--- | ---
`scheme://host/?full%20name=David%20Krumholtz&ping=8&ping=300` | `scheme://host/?full%20name=Morena%20Baccarin&ping=35&ping=16&ping=87&ping=240`
`scheme://host/?ping=8&full%20name=David%20Krumholtz&ping=300` | `scheme://host/?ping=35&full%20name=Morena%20Baccarin&ping=16&ping=87&ping=240`
`scheme://host/?ping=8&ping=300&ping=50&ping=68&ping=42` | `scheme://host/?ping=35&ping=16&ping=87&ping=240&full%20name=Morena%20Baccarin`

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

:::moniker range=">= aspnetcore-7.0"

## Handle/prevent location changes

<xref:Microsoft.AspNetCore.Components.NavigationManager.RegisterLocationChangingHandler%2A> registers a handler to process incoming navigation events. The handler's context provided by <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext> includes the following properties:

* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.TargetLocation>: Gets the target location.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.HistoryEntryState>: Gets the state associated with the target history entry.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.IsNavigationIntercepted>: Gets whether the navigation was intercepted from a link.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.CancellationToken>: Gets a <xref:System.Threading.CancellationToken> to determine if the navigation was canceled, for example, to determine if the user triggered a different navigation.
* <xref:Microsoft.AspNetCore.Components.Routing.LocationChangingContext.PreventNavigation%2A>: Called to prevent the navigation from continuing.

A component can register multiple location changing handlers in the [`OnAfterRender{Async}` lifecycle method](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). Navigation invokes all of the location changing handlers registered across the entire app (across multiple components), and any internal navigation executes them all in parallel. In addition to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A> handlers are invoked:

* When selecting internal links, which are links that point to URLs under the app's base path.
* When navigating using the forward and back buttons in a browser.

Handlers are only executed for internal navigation within the app. If the user selects a link that navigates to a different site or changes the address bar to a different site manually, location changing handlers aren't executed.

Implement <xref:System.IDisposable> and dispose registered handlers to unregister them. For more information, see <xref:blazor/components/component-disposal>.

> [!IMPORTANT]
> Don't attempt to execute DOM cleanup tasks via JavaScript (JS) interop when handling location changes. Use the [`MutationObserver` pattern](https://developer.mozilla.org/docs/Web/API/MutationObserver) in JS on the client. For more information, see <xref:blazor/js-interop/index#dom-cleanup-tasks-during-component-disposal>.

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

* <xref:Microsoft.AspNetCore.Components.Routing.NavigationLock.ConfirmExternalNavigation> sets a browser dialog to prompt the user to either confirm or cancel external navigation. The default value is `false`. Displaying the confirmation dialog requires initial user interaction with the page before triggering external navigation with the URL in the browser's address bar. For more information on the interaction requirement, see [Window: `beforeunload` event](https://developer.mozilla.org/docs/Web/API/Window/beforeunload_event).
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

## Dynamically-generated `NavLink` components via reflection

<xref:Microsoft.AspNetCore.Components.Routing.NavLink> component entries can be dynamically created from the app's components via reflection. The following example demonstrates the general approach for further customization.

For the following demonstration, a consistent, standard naming convention is used for the app's components:

* Routable component file names use Pascal case&dagger;, for example `Pages/ProductDetail.razor`.
* Routable component file paths match their URLs in kebab case&Dagger; with hyphens appearing between words in a component's route template. For example, a `ProductDetail` component with a route template of `/product-detail` (`@page "/product-detail"`) is requested in a browser at the relative URL `/product-detail`.

&dagger;Pascal case (upper camel case) is a naming convention without spaces and punctuation and with the first letter of each word capitalized, including the first word.  
&Dagger;Kebab case is a naming convention without spaces and punctuation that uses lowercase letters and dashes between words.

In the Razor markup of the `NavMenu` component (`NavMenu.razor`) under the default `Home` page, <xref:Microsoft.AspNetCore.Components.Routing.NavLink> components are added from a collection:

```diff
<div class="nav-scrollable" 
    onclick="document.querySelector('.navbar-toggler').click()">
    <nav class="flex-column">
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
                <span class="bi bi-house-door-fill-nav-menu" 
                    aria-hidden="true"></span> Home
            </NavLink>
        </div>

+       @foreach (var name in GetRoutableComponents())
+       {
+           <div class="nav-item px-3">
+               <NavLink class="nav-link" 
+                       href="@Regex.Replace(name, @"(\B[A-Z]|\d+)", "-$1").ToLower()">
+                   @Regex.Replace(name, @"(\B[A-Z]|\d+)", " $1")
+               </NavLink>
+           </div>
+       }

    </nav>
</div>
```

The `GetRoutableComponents` method in the `@code` block:

```csharp
public IEnumerable<string> GetRoutableComponents() => 
    Assembly.GetExecutingAssembly()
        .ExportedTypes
        .Where(t => t.IsSubclassOf(typeof(ComponentBase)))
        .Where(c => c.GetCustomAttributes(inherit: true)
                     .OfType<RouteAttribute>()
                     .Any())
        .Where(c => c.Name != "Home" && c.Name != "Error")
        .OrderBy(o => o.Name)
        .Select(c => c.Name);
```

The preceding example doesn't include the following pages in the rendered list of components:

* `Home` page: The page is listed separately from the automatically generated links because it should appear at the top of the list and set the `Match` parameter.
* `Error` page: The error page is only navigated to by the framework and shouldn't be listed.

:::moniker range=">= aspnetcore-8.0"

For an demonstration of the preceding code in a sample app, obtain the [**Blazor Web App** or **Blazor WebAssembly** sample app](xref:blazor/fundamentals/index#sample-apps).

:::moniker-end
