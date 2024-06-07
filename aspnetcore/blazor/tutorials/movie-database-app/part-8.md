---
title: Build a Blazor movie database app (Part 8 - Add interactivity)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how to adopt interactive SSR rendering in the app.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/06/2024
uid: blazor/tutorials/movie-database-app/part-8
---
# Build a Blazor movie database app (Part 8 - Add interactivity)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the eighth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

Up to this point in the tutorial, the entire app has been *enabled* for interactivity, but the app hasn't *adopted* interactivity. This part of the series explains how to adopt interactivity.

> [!IMPORTANT]
> Confirm that the app isn't running for the next steps.

## Adopt interactivity

*Interactivity* means that a component has the capacity to process .NET events via C# code. The .NET events are either processed on the server by the ASP.NET Core runtime or in the browser on the client by the WebAssembly-based Blazor runtime. This tutorial adopts interactive server-side rendering, known generally as Interactive Server (`InteractiveServer`) rendering or interactive server-side rendering (interactive SSR). Client-side rendering (CSR), which is inherently interactive by default, is covered in the Blazor reference documentation.

UI interactions are handled from the server over a real-time SignalR connection with the browser. Interactive SSR enables a rich user experience like one would expect from a client app but without the need to create API endpoints to access server resources. Page content for interactive pages is prerendered, where content on the server is initially generated and sent to the client without enabling event handlers for rendered controls. The server outputs the HTML UI of the page as soon as possible in response to the initial request, which makes the app feel more responsive to users.

Review the API in the `Program` file (`Program.cs`) that enables interactive SSR. Razor component services are added to the app to enable Razor components to render statically from the server (<xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>) and execute code with interactive SSR (<xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A>):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

<xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> maps components defined in the root `App` component to the given .NET assembly and renders routable components, and <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> configures the app's SignalR hub to support interactive SSR:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

Up to this point in the tutorial series, the calls to <xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A> and <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> weren't required because the app only adopted static SSR. Because we'll adopt interactive SSR in this article, the app is now required to call these extension methods.

When Blazor sets the type of rendering for a component, the rendering is referred to as the component's *render mode*. The following table shows the available render modes for rendering Razor components in a Blazor Web App.

Name | Description | Render location | Interactive
---- | ----------- | :-------------: | :---------:
Static Server | Static server-side rendering (static SSR) |  Server  | <span aria-hidden="true">❌</span><span class="visually-hidden">No</span>
Interactive Server | Interactive server-side rendering (interactive SSR) using Blazor Server. | Server | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive WebAssembly | Client-side rendering (CSR) using Blazor WebAssembly. | Client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>
Interactive Auto | Interactive SSR using Blazor Server initially and then CSR on subsequent visits after the Blazor bundle is downloaded. | Server, then client | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span>

To apply a render mode to a component, the developer either uses the `@rendermode` directive or directive attribute on the component instance or on the component definition:

* The following example shows how to set the render mode on a component instance with the `@rendermode` directive attribute. For example, where a hypothetical dialog (`Dialog`) component is used in some other component:

  ```razor
  <Dialog @rendermode="InteractiveServer" />
  ```

* The following example shows how to set the render mode on a component definition with the `@rendermode` directive. For example, at the top of a hypothetical sales forecast (`SalesForecast`) component:

  ```razor
  @page "/sales-forecast"
  @rendermode="InteractiveServer"
  ```

Using the preceding approaches, you can apply a render mode on a per-page/component basis. However, an entire app can adopt a single render mode via a root component that then by inheritance sets the render mode of every other component loaded. This is termed *global interactivity*, as opposed to *per-page/component interactivity*. Global interactivity is the approach that we'll take for the movie database app.

> [!NOTE]
> More information on render modes is provided by Blazor's reference documentation. For the purposes of this tutorial, we'll only adopt interactive SSR. After the tutorial, you're free to use this app to study the other component render modes.

Based on creating the app from the Blazor Web App project template, the root component of the app is the `App` component.

`Components/Pages/App.razor`:

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

Now, every component in the movie database app inherits interactive SSR via the `Routes` component. It's not necessary for each component to specify the Interactive Server (`InteractiveServer`) render mode.

To see how making a component interactive enhances the user experience, let's provide two enhancements to the app in the next couple of sections:

* Make the `QuickGrid` component in the movie `Index` page *sortable*.
* Replace the HTML form for filtering movies by title with C# code that:
  * Runs on the server.
  * Renders content transparently over the underlying SignalR connection.

## Sortable `QuickGrid`

Open the `Index` component (`Components/Pages/Movies/Index.razor`).

Add `Sortable="true"` (<xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Sortable%2A>) to the title <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602>:

```diff
- <PropertyColumn Property="movie => movie.Title" />
+ <PropertyColumn Property="movie => movie.Title" Sortable="true" />
```

Run the app and navigate to the movies `Index` page.

You can sort the `QuickGrid` by movie title by selecting the **Title** column.

The component is *interactive*. The page doesn't reload for sorting to occur. The sorting is performed live over the SignalR connection between the browser and the server, where the sorting operation is performed on the server with the rendered result sent back to the client for the browser to display.

## Use C# code and interactivity to search by title

In an earlier part of the tutorial series, the `Index` component was modified to allow the user to filter movies by title. This was accomplished by:

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

The preceding approach is effective for a component that adopts static SSR, where the only interaction between the client and server is via HTTP requests. There was no live SignalR connection between the client and the server, and there was no way for the app on the server to process C# code *interactively* based on the user's actions in the component's UI and return content without a full-page reload.

Now that the component is interactive, it can provide an improved user experience with Blazor features for binding and event handling, where full-page reloads aren't required to run C# on the server that interacts with the page's elements.

Convert the `TitleFilter` property into a C# field because an interactive component doesn't require a filter string supplied by a user to reach the server via a query string and a GET request. Blazor can bind an HTML element's value to a C# field or property transparently over the underlying SignalR connection. Change the following code for the filter string, including the casing of the variable to match the convention for fields, which is camel case (`TitleFilter` to `titleFilter`):

```diff
- [SupplyParameterFromQuery]
- public string? TitleFilter { get; set; }
+ private string? titleFilter;
```

The `OnParametersSet` lifecycle method was used to conditionally filter the database based on `TitleFilter` (the property) having a value. We still want the `QuickGrid` to receive an unfiltered movie list on load, but we want that to happen just once when the component is initialized. Also, we'd like the filtering to occur when the user selects the **Search** button in the UI, which we can set up with a Blazor event handler delegate.

Remove the overridden `OnParametersSet` Blazor lifecycle method from the `@code` block:

```diff
- protected override void OnParametersSet()
- {
-     ...
- }
```

Add an overridden `OnInitialized` Blazor lifecycle method to provide the initial movie list when the component is rendered for the first time:

```csharp
protected override void OnInitialized()
{
    movies = DB.Movie;
}
```

Add a delegate event handler that the user can trigger to filter the database's movie records. The method uses the value of the `titleFilter` field to perform the operation. If the user clears `titleFilter` and searches, the method loads the entire movie list for display.

Add the following method to the `@code` block:

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

* An input element (`<input>`) bound to the `titleFilter` field. Binding is achieved in Blazor with the `@bind` directive attribute, which can bind the value of an element to either a C# field or property.
* A button that triggers the `FilterMovies` method. Event handling is achieved in Blazor by specifying a delegate event handler (method) to the `@onclick` directive attribute.

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

The `<input>` element *binds* the value of the element to the `titleFilter` field. Selecting the button triggers the `FilterMovies` delegate via the `@onclick` directive attribute of the `<button>` element.

Run the app, type "`road warrior`" into the search field, and select the **Search** button:

![Movie list filtered to 'The Road Warrior' movie after searching on the text 'road warrior'.](~/blazor/tutorials/movie-database-app/part-8/_static/filtered-to-road-warrior.png)

When the user selects the button, an HTTP request isn't issued. The event is transparently transmitted to the server over the SignalR connection in the background. The filtering operation is performed on the server, and the server transparently sends back the HTML to display over the same SignalR connection. The page doesn't reload. The user feels like their interactions with the page are running code on the client. Actually, the code is running the server.

Instead of an HTML form, submitting a GET request in this scenario could've also used JavaScript to submit the request to the server, either using the [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API)` or [XMLHttpRequest API](https://developer.mozilla.org/docs/Web/API/XMLHttpRequest). In most cases, JavaScript can be replaced by using Blazor and C# in an interactive component.

## Congratulations!

Congratulations on completing the tutorial series! We hope you enjoyed this tutorial on Blazor. Blazor offers many more features than we were able to cover in this series, and we invite you to explore the Blazor documentation, examples, and sample apps to learn more. *Happy coding with Blazor!*

## Next steps

If you're new to Blazor, we recommend reading the following Blazor articles that cover important general information for Blazor development:

* <xref:blazor/index>
* <xref:blazor/supported-platforms>
* <xref:blazor/tooling>
* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>
* <xref:blazor/fundamentals/index> and the other *Fundamentals* node articles.
* <xref:blazor/components/index> and the other *Components* node articles.
* <xref:blazor/forms/index>
* <xref:blazor/js-interop/index> and the other *JavaScript interop* articles.
* <xref:blazor/security/index>
* <xref:blazor/host-and-deploy/index>
* <xref:blazor/blazor-ef-core> covers concurrency with EF Core in Blazor apps.

In the documentation website's sidebar navigation, articles are organized by subject matter and laid out in roughly in a general-to-specific or general-to-complex order. The best approach when starting to learn about Blazor is to read down the table of contents from top to bottom.

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

> [!div class="step-by-step"]
> [Previous: Add validation](xref:blazor/tutorials/movie-database-app/part-7)
