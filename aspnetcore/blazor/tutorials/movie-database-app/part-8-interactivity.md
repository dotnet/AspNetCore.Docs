---
title: Build a Blazor movie database app (Part 8 - Add interactivity)
author: guardrex
description: This part of the Blazor movie database app tutorial explains ...
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/06/2024
uid: blazor/tutorials/movie-database/interactivity
---
# Build a Blazor movie database app (Part 9 - Add interactivity)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the eighth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

Up to this point in the tutorial, the entire app has been enabled for interactivity, but the app hasn't adopted interactivity. This part of the series explains how to adopt interactivity.

*Interactivity* means that a component has the capacity to process .NET events via C# code. The .NET events are either processed on the server by the ASP.NET Core runtime or in the browser on the client by the WebAssembly-based Blazor runtime. This tutorial adopts server-side rendering, known generally as Interactive Server (`InteractiveServer`) rendering or interactive server-side rendering (interactive SSR).

Review the API in the `Program` file (`Program.cs`) that enables interactive SSR.

Razor component services are added to the app to enable Razor components to render statically from the server (<xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>) and execute code with interactive SSR (<xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A>):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

<xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> maps components defined in the root `App` component to the given .NET assembly and renders routable components, and <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> configures the app to support interactive SSR:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

At this point, the app is capable of interactive SSR, but none of the components in the app actually adopt it.

When Blazor sets the type of rendering for a component, the rendering is referred to as the component's *render mode*. The following table shows the available render modes for rendering Razor components in a Blazor Web App.

Name | Description | Render location | Interactive
---- | ----------- | :-------------: | :---------:
Static Server | Static server-side rendering (static SSR) |  Server  | <span aria-hidden="true">❌</span><span class="visually-hidden">No</span>
Interactive Server | Interactive server-side rendering (interactive SSR) using Blazor Server. | Server | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive WebAssembly | Client-side rendering (CSR) using Blazor WebAssembly&dagger;. | Client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive Auto | Interactive SSR using Blazor Server initially and then CSR on subsequent visits after the Blazor bundle is downloaded. | Server, then client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>

To apply a render mode to a component, the developer either uses the `@rendermode` directive or directive attribute on the component instance or on the component definition:

* On a component instance with the `@rendermode` directive attribute. For example, where a hypothetical dialog (`Dialog`) component is used in some other component:

  ```razor
  <Dialog @rendermode="InteractiveServer" />
  ```

* In a component definition with the `@rendermode` directive. For example, at the top of a hypothetical sales forecast (`SalesForecast`) component:

  ```razor
  @page "/sales-forecast"
  @rendermode="InteractiveServer"
  ```

Using the preceding approaches, you can apply a render mode on a per-page/component basis. However, an entire app can adopt a single render mode via a root component that then by inheritance sets the render mode of every other component loaded. This is termed *global interactivity*, as opposed to *per-page/component interactivity*. That's the approach that we'll take for the movie database app.

Based on creating the app from the Blazor Web App project template, the root component of the app is the `App` component (`Components/Pages/App.razor`):

```razor
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="app.css" />
    <link rel="stylesheet" href="BlazorWebAppMovies.styles.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <HeadOutlet />
</head>

<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
</body>

</html>
```

There are two components used by the `App` component:

* <xref:Microsoft.AspNetCore.Components.Web.HeadOutlet> component: Renders content for the `<head>` by other components.
* `Routes` component: Sets up routing for the app. All other app components are loaded via the `Routes` component.

To apply global server-side interactivity to these two components, add `@rendermode="InteractiveServer"` to each component instance:

```diff
- <HeadOutlet />
+ <HeadOutlet @rendermode="InteractiveServer" />

...

- <Routes />
+ <Routes @rendermode="InteractiveServer" />
```

Now, every component in the movie database app inherits interactive SSR via the `Routes` component.

To see how making a component interactive enhances the user experience, let's provide two enhancements to the app in the next couple of sections:

* Make the `QuickGrid` component in the movie `Index` page *sortable*.
* Replace the HTML form for filtering movies by title text with C# code that runs on the server.

## Sortable `QuickGrid`

Open the `Index` component (`Components/Pages/Movies/Index.razor`).

Add `Sortable="true"` (<xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Sortable%2A>) to the title <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602>:

```diff
- <PropertyColumn Property="movie => movie.Title" />
+ <PropertyColumn Property="movie => movie.Title" Sortable="true" />
```

Run the app and navigate to the movies `Index` page.

You can sort the `QuickGrid` by movie title by selecting the **Title** column.

The component is *interactive*. The page doesn't reload for sorting to occur. The sorting is performed live over a SignalR connection between the browser and the server, where the sorting operation is performed on the server with the rendered result sent back to the client for the browser to display.

## Use C# code to search by title

In Part 6 of the tutorial series, the `Index` component was modified to allow the user to filter movies by title. This was accomplished by:

* Adding an HTML form that issues a GET request to the server with the user's title search string as a query string field-value pair (for example, `?titleFilter=road+warrior` if the user searches for "`road warrior`"):

  ```html
  <form action="/movies">
      <input type="text" name="titleFilter" />
      <input type="submit" value="Search" />
  </form>
  ```

* Adding code to the component that obtains the title search string from the query string and uses it to filter the database's records:

  ```csharp
  [SupplyParameterFromQuery]
  public string? TitleFilter { get; set; }

  protected override void OnParametersSet()
  {
      if (!string.IsNullOrEmpty(TitleFilter))
      {
          movies = DB.Movie.Where(
              s => !string.IsNullOrEmpty(s.Title) ? 
                  s.Title.Contains(TitleFilter) : false);
      }
      else
      {
          movies = DB.Movie;
      }
  }
  ```

The preceding approach is effective for a component that adopts static SSR, where the only interaction between the client and server is via HTTP requests. There was no live SignalR connection between the client and the server, and there was no way for the app on the server to process C# code *interactively* based on the user's actions in the component's UI and return content for display transparently without a full page refresh.

Now, the component is interactive, so it can provide a much improved user experience by adopting Blazor features for binding and event handling.

Convert the `TitleFilter` property into a C# field because an interactive component doesn't require a filter string supplied by a user to reach the server via a query string. Blazor can bind an HTML element's value directly to a C# field or property. Change the following code for the filter string, including the casing of the variable to match the convention for fields, which is camel case:

```diff
- [SupplyParameterFromQuery]
- public string? TitleFilter { get; set; }
+ private string? titleFilter;
```

The `OnParametersSet` lifecycle method was used to conditionally filter the database based on `TitleFilter` (the property) having a value. We still want the `QuickGrid` to receive an unfiltered movie list on load, but we want that to happen just once when the component is initialized. Also, we'd like the filtering to occur when the user selects the **Search** button in the UI, which we can set up as a Blazor event.

Remove the overridden `OnParametersSet` Blazor lifecycle method from the `@code` block:

```diff
- protected override void OnParametersSet()
- {
-     if (!string.IsNullOrEmpty(TitleFilter))
-     {
-         movies = DB.Movie.Where(
-             s => !string.IsNullOrEmpty(s.Title) ? 
-                 s.Title.Contains(TitleFilter) : false);
-     }
-     else
-     {
-         movies = DB.Movie;
-     }
- }
```

Add an overridden `OnInitialized` Blazor lifecycle method to provide the initial movie list when the component is rendered for the first time:

```csharp
protected override void OnInitialized()
{
    movies = DB.Movie;
}
```

Add a delegate event handler (method) that the user can trigger to filter the database records. The method uses the value of the `titleFilter` field to perform the operation. If the user has cleared `titleFilter`, the method loads the entire movie list for display. Add the following method to the `@code` block:

```csharp
private void FilterMovies()
{
    if (!string.IsNullOrEmpty(titleFilter))
    {
        movies = DB.Movie.Where(
            s => !string.IsNullOrEmpty(s.Title) ? 
                s.Title.Contains(titleFilter) : false);
    }
    else
    {
        movies = DB.Movie;
    }
}
```

The component won't issue a GET request via an HTML form to trigger the `FilterMovies` method. The component should provide:

* An input element (`<input>`) bound to the `titleFilter` field.
* A button that triggers the `FilterMovies` method.

Binding is achieved in Blazor with the `@bind` directive attribute, which can bind the value of an element to either a C# field or property.

Event handling is achieved in Blazor by specifying a delegate event handler (method) to the `@onclick` directive attribute.

Remove the HTML form from the component:

```diff
- <form action="/movies">
-     <input type="text" name="titleFilter" />
-     <input type="submit" value="Search" />
- </form>
```

In its place, add the following Razor markup:

```razor
<input @bind="titleFilter" />
<button @onclick="FilterMovies">Search</button>
```

The input element *binds* the value of the element to the `titleFilter` field. Selecting the button triggers the `FilterMovies` delegate.

Run the app, type "road warrior" into the search field, and select **Search**:

![Movie list filtered to 'The Road Warrior' movie after searching on the text 'road warrior'.](~/blazor/tutorials/movie-database-app/part-8-interactivity/_static/filtered-to-road-warrior.png)

When the user selects the button, an HTTP request isn't issued. The event is transmitted to the server over the live SignalR connection in the background transparent to the user. The filtering operation is performed on the server, and the server sends back the HTML of the grid over the same SignalR connection transparently. The page doesn't reload.

Instead of an HTML form, submitting a GET request in this scenario could've also used JavaScript to submit the request to the server, either using the [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API)` or [XMLHttpRequest API](https://developer.mozilla.org/docs/Web/API/XMLHttpRequest). In most cases, JavaScript can be replaced by using Blazor and C# in an interactive component.

## Next steps

If you're new to Blazor, we recommend reading the following Blazor articles that cover important general information for Blazor development:

* <xref:blazor/index>
* <xref:blazor/supported-platforms>
* <xref:blazor/tooling>
* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>
* <xref:blazor/fundamentals/index> and the other *Fundamentals* node articles.
* <xref:blazor/components/index> and the other *Components* node articles.
* <xref:blazor/forms/index> if you intend to start using Blazor forms immediately.
* <xref:blazor/js-interop/index> and the other *JavaScript interop* articles if you intend to start using JS interop immediately.
* <xref:blazor/security/index>
* <xref:blazor/host-and-deploy/index>

Articles are laid out in the table of contents (TOC) by subject matter in roughly in a general-to-specific or general-to-complex order, so the best approach to consuming Blazor documentation is to read down the table of contents.

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

> [!div class="step-by-step"]
> [Previous: Add validation](xref:blazor/tutorials/movie-database/validation)
