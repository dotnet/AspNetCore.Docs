---
title: Build a Blazor movie database app (Part 3 - Learn about Razor components)
author: guardrex
description: This part of the Blazor movie database app tutorial explains the Razor components in the project that were scaffolded into the app. Improvements are made to the display of movie data.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/26/2024
uid: blazor/tutorials/movie-database-app/part-3
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 3 - Learn about Razor components)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the third part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the tutorial series examines the Razor components in the project that were scaffolded into the app. Improvements are made for the display of movie data.

## Razor components

Blazor apps are based on *Razor components*, often referred to as just *components*. A *component* is an element of UI, such as a page, dialog, or data entry form. Components are .NET C# classes built into [.NET assemblies](/dotnet/standard/assembly/).

*Razor* refers to how components are usually written in the form of a [Razor](xref:mvc/views/razor) markup page (`.razor` file extension) for client-side UI logic and composition. Razor is a syntax for combining HTML markup with C# code designed for developer productivity.

Although developers and online resources use the term "Blazor components," the documentation uses the formal name "Razor components" (or just "components").

The anatomy of a Razor component has the following general pattern:

* At the top of the component definition (`.razor` file), various Razor directives specify how the component markup is compiled or functions.
* Next, Razor markup specifies how HTML is rendered, which includes ordinary HTML elements.
* Finally, an `@code` block contains C# code to define members for the component class, including component parameters and event handlers.

Consider the following `Welcome` component (`Welcome.razor`):

```razor
@page "/welcome"

<PageTitle>Welcome!</PageTitle>

<h1>Welcome to Blazor!</h1>

<p>@welcomeMessage</p>

@code {
    private string welcomeMessage = "We ❤️ Blazor!";
}
```

The first line represents an important Razor construct in Razor components, a *Razor directive*. A Razor directive is a reserved keyword prefixed with `@` that appears in Razor markup that changes the way component markup is compiled or functions. The `@page` Razor directive specifies the route template for the component. This component is reached in a browser at the relative URL `/welcome`. By convention, most of a component's directives are placed at the top of the component definition file.

The <xref:Microsoft.AspNetCore.Components.Web.PageTitle> component is a component built into the framework that specifies a page title.

"`Welcome to Blazor!`" is the first rendered body markup of the component per the content of the H1 heading element (`<h1>`).

Next, a welcome message is displayed using Razor syntax by prefixing the at symbol (`@`) to a C# variable (`welcomeMessage`).

The `@code` block contains the C# code of the component. `welcomeMessage` is a private string initialized with a value.

In the following sections of this article:

* Three components for webpage navigation and layout are described, the `NavMenu`, <xref:Microsoft.AspNetCore.Components.Routing.NavLink>, and `MainLayout` components.
* The components created by scaffolding for CRUD operations on movie database entities are discussed.

## `NavMenu` component for navigation

The `NavMenu` component (`Components/Layout/NavMenu.razor`) implements sidebar navigation using <xref:Microsoft.AspNetCore.Components.Routing.NavLink> components, which render navigation links to other Razor components.

A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType> assigned to the <xref:Microsoft.AspNetCore.Components.Routing.NavLink.Match%2A> parameter configures the component to display an active CSS class when it matches the entire current URL.

The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component built into the Blazor framework for any Blazor app to use, while the `NavMenu` component is only part of Blazor project templates.

`Components/Layout/NavMenu.razor`:

```razor
<div class="top-row ps-3 navbar navbar-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="">BlazorWebAppMovies</a>
    </div>
</div>

<input type="checkbox" title="Navigation menu" class="navbar-toggler" />

<div class="nav-scrollable" onclick="document.querySelector('.navbar-toggler').click()">
    <nav class="flex-column">
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
                <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Home
            </NavLink>
        </div>

        <div class="nav-item px-3">
            <NavLink class="nav-link" href="weather">
                <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Weather
            </NavLink>
        </div>
    </nav>
</div>
```

Notice in the `NavMenu` component's first `<div>` element the brand link text (`<a>` element content). Change the brand from `BlazorWebAppMovies` to `Sci-fi Movies`:

```diff
- <a class="navbar-brand" href="">BlazorWebAppMovies</a>
+ <a class="navbar-brand" href="">Sci-fi Movies</a>
```

To allow users to reach the movies `Index` page, add a navigation menu entry to the `NavMenu` component. Immediately after the markup (`<div>`) for the `Weather` component's `NavLink`, add the following markup:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="movies">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Movies
    </NavLink>
</div>
```

The final `NavMenu` component after making the preceding changes:

```razor
<div class="top-row ps-3 navbar navbar-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="">Sci-fi Movies</a>
    </div>
</div>

<input type="checkbox" title="Navigation menu" class="navbar-toggler" />

<div class="nav-scrollable" onclick="document.querySelector('.navbar-toggler').click()">
    <nav class="flex-column">
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
                <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Home
            </NavLink>
        </div>

        <div class="nav-item px-3">
            <NavLink class="nav-link" href="weather">
                <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Weather
            </NavLink>
        </div>

        <div class="nav-item px-3">
            <NavLink class="nav-link" href="movies">
                <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Movies
            </NavLink>
        </div>
    </nav>
</div>
```

Run the app to see the updated brand at the top of the sidebar navigation and a link to reach the movies page (**Movies**):

![App running in a browser showing the brand at the top of the sidebar navigation as 'Sci-fi Movies' and a 'Movie' link in the sidebar](~/blazor/tutorials/movie-database-app/part-3/_static/updated-brand-and-added-link.png)

:::zone pivot="vs"

Stop the app by closing the browser's window.

:::zone-end

:::zone pivot="vsc"

Stop the app by closing the browser's window and pressing <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard in VS Code.

:::zone-end

:::zone pivot="cli"

Stop the app by closing the browser's window and pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS) in the command shell.

:::zone-end

## `MainLayout` component for layout

The `MainLayout` component is the app's default layout. The `MainLayout` component inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>, which is a base class for components that represent a layout. The app's components that use the layout are rendered where the <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body%2A> (`@Body`) appears in the markup.

`Components/Layout/MainLayout.razor`:

```razor
@inherits LayoutComponentBase

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>
```

The `MainLayout` component adopts the following additional specifications:

* The `NavMenu` component is rendered in the sidebar. Notice that you only need to place an HTML tag with the component name to render a component at that location in Razor markup. This allows you to nest components within each other and within any HTML layout that you implement.
* The `<main>` element's content includes:
  * An **:::no-loc text="About":::** link that sends the user to the ASP.NET Core documentation landing page.
  * An `<article>` element with the <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body%2A> (`@Body`) parameter, where components that use the layout are rendered.

The default layout (`MainLayout` component) is specified in the `Routes` component (`Components/Pages/Routes.razor`):

```razor
<RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />
```

Individual components are free to set their own non-default layout, and a layout can be applied to whole folder of components via an `_Imports.razor` file in the same folder. These features are covered in detail in the Blazor documentation.

## Create, Read, Update, Delete (CRUD) components

The following sections explain the composition of the movie CRUD components and how they work.

### `Index` component

Open the `Index` component definition file (`Components/Pages/Movies/Index.razor`) and examine the Razor directives at the top of the file.

The `@page` directive's route template indicates the URL for the page is `/movies`.

`@using` directives appear to access the following API:

* <xref:Microsoft.EntityFrameworkCore?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Components.QuickGrid?displayProperty=fullName>
* `BlazorWebAppMovies.Models`
* `BlazorWebAppMovies.Data`

The database context factory (`IDbContextFactory<BlazorWebAppMoviesContext>`) is injected into the component with the `@inject` directive. The factory approach requires that a database context be disposed, so the component implements the <xref:System.IAsyncDisposable> interface with the `@implements` directive.

The page title is set via the Blazor framework's <xref:Microsoft.AspNetCore.Components.Web.PageTitle> component, and an H1 section heading is the first rendered element:

```razor
<PageTitle>Index</PageTitle>

<h1>Index</h1>
```

A link is rendered to navigate to the `Create` page at `/movies/create`:

```razor
<p>
    <a href="movies/create">Create New</a>
</p>
```

The [`QuickGrid`](xref:Microsoft.AspNetCore.Components.QuickGrid) component displays movie entities. The item provider is a `DbSet<Movie>` obtained from the created database context (<xref:Microsoft.EntityFrameworkCore.IDbContextFactory%601.CreateDbContext%2A>) of the injected database context factory (`DbFactory`). For each movie entity, the component displays the movie's title, release date, genre, and price. A column also holds links to edit, see details, and delete each movie entity.

```razor
<QuickGrid Class="table" Items="context.Movie">
    <PropertyColumn Property="movie => movie.Title" />
    <PropertyColumn Property="movie => movie.ReleaseDate" />
    <PropertyColumn Property="movie => movie.Genre" />
    <PropertyColumn Property="movie => movie.Price" />

    <TemplateColumn Context="movie">
        <a href="@($"movies/edit?id={movie.Id}")">Edit</a> |
        <a href="@($"movies/details?id={movie.Id}")">Details</a> |
        <a href="@($"movies/delete?id={movie.Id}")">Delete</a>
    </TemplateColumn>
</QuickGrid>

@code {
    private BlazorWebAppMoviesContext context = default!;

    protected override void OnInitialized()
    {
        context = DbFactory.CreateDbContext();
    }

    public async ValueTask DisposeAsync() => await context.DisposeAsync();
}
```

In the code block (`@code`):

* The `context` field holds the database context, typed as a `BlazorWebAppMoviesContext`.
* The `OnInitialized` lifecycle method assigns a created database context (<xref:Microsoft.EntityFrameworkCore.IDbContextFactory%601.CreateDbContext%2A>) from the injected factory (`DbFactory`) to the `context` variable.
* The asynchronous `DisposeAsync` method disposes of the database context when the component is disposed.

Notice how the context (`Context`) parameter of the <xref:Microsoft.AspNetCore.Components.QuickGrid.TemplateColumn%601> specifies a parameter name (`movie`) for the context instance of the column. Specifying a name for the context instance makes the markup more readable (the default name for the context is simply `context`). `Movie` class properties are read from the context instance. For example, the movie identifier (`Id`) is available in `movie.Id`.

The at symbol (`@`) with parentheses (`@(...)`), which is called an *explicit Razor expression*, allows the `href` of each link to include the movie entity's `Id` property in the link query string as an *interpolated string* (`$...{...}...`). For a movie identifier (`Id`) of 7, the string value provided to the `href` to edit that movie is `movies/edit?id=7`. When the link is followed, the `id` field is read from the query string by the `Edit` component to load the movie.

For the movie example from the last part of the tutorial series, *The Matrix*&copy;, the [`QuickGrid`](xref:Microsoft.AspNetCore.Components.QuickGrid) component renders the following HTML markup (some elements and attributes aren't present to simplify display). See how the explicit Razor expressions and interpolated strings produced the `href` values for the links to other pages. The movie's identifier in the database happens to be `3` for this example, so the `id` is `3` in the query strings for the `Edit`, `Details`, and `Delete` pages. You may see a different value when you run the app.

```html
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>ReleaseDate</th>
            <th>Genre</th>
            <th>Price</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>The Matrix</td>
            <td>3/29/1999</td>
            <td>Sci-fi (Cyberpunk)</td>
            <td>5.00</td>
            <td>
                <a href="movies/edit?id=3">Edit</a> |
                <a href="movies/details?id=3">Details</a> |
                <a href="movies/delete?id=3">Delete</a>
            </td>
        </tr>
    </tbody>
</table>
```

The column names are taken from the `Movie` model properties, so the release date doesn't have a space between the words. Add a <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Title> to the <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602> with a value that includes a space between the words:

```razor
<PropertyColumn Property="movie => movie.ReleaseDate" Title="Release Date" />
```

Run the app to see that the column displays two words for the release date.

:::zone pivot="vs"

Stop the app by closing the browser's window.

:::zone-end

:::zone pivot="vsc"

Stop the app by closing the browser's window and pressing <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard in VS Code.

:::zone-end

:::zone pivot="cli"

Stop the app by closing the browser's window and pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS) in the command shell.

:::zone-end

### `Details` component

Open the `Details` component definition file (`Components/Pages/Movies/Details.razor`).

The `@page` directive at the top of the file indicates the relative URL for the page is `/movies/details`. As before, the database context is injected, and namespaces are provided to access API (`BlazorWebAppMovies.Models` and `Microsoft.EntityFrameworkCore`). The `Details` component also injects the app's <xref:Microsoft.AspNetCore.Components.NavigationManager>, which is used for a variety of navigation-related operations in components.

```razor
@page "/movies/details"
@using Microsoft.EntityFrameworkCore
@using BlazorWebAppMovies.Models
@inject IDbContextFactory<BlazorWebAppMovies.Data.BlazorWebAppMoviesContext> DbFactory
@inject NavigationManager NavigationManager
```

Details for a movie entity are only shown if the movie, located by its identifier (`Id`) from the query string, has been loaded for display. The presence of the movie in `movie` is checked with an `@if` Razor statement:

```razor
@if (movie is null)
{
    <p><em>Loading...</em></p>
}
```

When the movie is loaded, it's displayed as a [description list (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Element/dl) along with two links:

* The first link provides the user an opportunity to edit the entity.
* The second link allows the user to return to the movies `Index` page.

CSS classes aren't shown in the following example to simplify the Razor markup for display:

```razor
<dl>
    <dt>Title</dt>
    <dd>@movie.Title</dd>
    <dt>ReleaseDate</dt>
    <dd>@movie.ReleaseDate</dd>
    <dt>Genre</dt>
    <dd>@movie.Genre</dd>
    <dt>Price</dt>
    <dd>@movie.Price</dd>
</dl>
<div>
    <a href="@($"/movies/edit?id={movie.Id}")">Edit</a> |
    <a href="@($"/movies")">Back to List</a>
</div>
</div>
```

Add a space to the content of the description term element (`<dt>`) for the movie's release date to separate the words:

```diff
- <dt class="col-sm-2">ReleaseDate</dt>
+ <dt class="col-sm-2">Release Date</dt>
```

Examine the C# of the component's `@code` block:

```csharp
private Movie? movie;

[SupplyParameterFromQuery]
private int Id { get; set; }

protected override async Task OnInitializedAsync()
{
    using var context = DbFactory.CreateDbContext();
    movie = await context.Movie.FirstOrDefaultAsync(m => m.Id == Id);

    if (movie is null)
    {
        NavigationManager.NavigateTo("notfound");
    }
}
```

The `movie` variable is a private field of type `Movie`, which is a null-reference type (`?`), meaning that `movie` might be set to `null`.

The `Id` is a *component parameter* supplied from the component's query string due to the presence of the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute). If the identifier is missing, `Id` defaults to zero (`0`).

`OnInitializedAsync` is the first component lifecycle method that we've seen. This method is executed when the component loads. <xref:Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync%2A> is called on the database set (`DbSet<Movie>`) to retrieve the movie entity with and `Id` equal to the `Id` parameter that was set by the query string. If `movie` is `null`, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> is used to navigate to a `notfound` endpoint.

<!-- UPDATE 10.0 - See https://github.com/dotnet/aspnetcore/issues/45654 
                   for .NET 10 work on handling a 404 with static SSR without \
                   having to navigate to a non-existent endpoint. -->

There isn't an actual `notfound` endpoint (Razor component) in the app. When adopting server-side rendering (SSR), Blazor doesn't have a mechanism to return a 404 (Not Found) status code. As a temporary workaround, a 404 is generated by navigating to a non-existent endpoint. This scaffolded code is for your further implementation of a suitable result when not finding an entity. For example, you could have the component direct the user to a page where they can file an inquiry with your support team, or you could remove the injected <xref:Microsoft.AspNetCore.Components.NavigationManager> and <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> code and replace it with Razor markup and code that displays a message to the user that the entity wasn't found.

### `Create` component

Open the `Create` component definition file (`Components/Pages/Movies/Create.razor`).

The component uses a built-in component called an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, which renders a form for user input and includes validation features.

CSS classes aren't present in the following example to simplify the display:

```razor
<EditForm method="post" Model="Movie" OnValidSubmit="AddMovie" FormName="create" Enhance>
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div>
        <label for="title">Title:</label> 
        <InputText id="title" @bind-Value="Movie.Title" /> 
        <ValidationMessage For="() => Movie.Title" /> 
    </div>
    <div>
        <label for="releasedate">ReleaseDate:</label> 
        <InputDate id="releasedate" @bind-Value="Movie.ReleaseDate" /> 
        <ValidationMessage For="() => Movie.ReleaseDate" /> 
    </div>
    <div>
        <label for="genre">Genre:</label> 
        <InputText id="genre" @bind-Value="Movie.Genre" /> 
        <ValidationMessage For="() => Movie.Genre" /> 
    </div>
    <div>
        <label for="price">Price:</label> 
        <InputNumber id="price" @bind-Value="Movie.Price" /> 
        <ValidationMessage For="() => Movie.Price" /> 
    </div>
    <button type="submit">Create</button>
</EditForm>
```

Add a space to the content of the label element (`<label>`) for the movie's release date to separate the words:

```diff
- <label for="releasedate" class="form-label">ReleaseDate:</label>
+ <label for="releasedate" class="form-label">Release Date:</label>
```

The <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model%2A> parameter is assigned the model, in this case `Movie`. <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit%2A> specifies a method to invoke (`AddMovie`) when the form is submitted and the data is valid. By convention, every form should assign a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.FormName%2A> to prevent form collisions when multiple forms are present on a page. The <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Enhance%2A> flag activates a Blazor feature for server-side rendering (SSR) that submits the form without performing a full-page reload.

For validation:

* The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> adds data annotations validation support, which is covered later in this tutorial series.
* The <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component displays a list of validation messages.
* The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> components hold validation messages for the form's fields.

Blazor includes several form element components to assist you with creating forms, including <xref:Microsoft.AspNetCore.Components.Forms.EditForm> and various input components, such as <xref:Microsoft.AspNetCore.Components.Forms.InputText>, <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>, and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601>. Each input component is bound to a model property with `@bind-Value` Razor syntax, where `Value` is a property in each input component.

In the component's `@code` block, C# code includes a `Movie` component parameter tied to the form via the [`[SupplyParameterFromForm]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute).

The `AddMovie` method:

* Is called when the form is submitted.
* Adds the movie data bound to the form's model (`Movie`) if form validation passes.
* <xref:Microsoft.EntityFrameworkCore.DbContext.SaveChangesAsync%2A> is called on the database context to save the movie.
* <xref:Microsoft.AspNetCore.Components.NavigationManager> is used to return the user to the movies `Index` page.

```csharp
@code {
    [SupplyParameterFromForm]
    private Movie Movie { get; set; } = new();

    private async Task AddMovie()
    {
        using var context = DbFactory.CreateDbContext();
        context.Movie.Add(Movie);
        await context.SaveChangesAsync();
        NavigationManager.NavigateTo("/movies");
    }
}
```

> [!WARNING]
> Although it isn't a concern for the app in this tutorial, binding form data to entity data models can be susceptible to overposting attacks. Additional information on this subject appears later in this article.

### `Delete` component

Open the `Delete` component definition file (`Components/Pages/Movies/Delete.razor`).

Add a space to the content of the description term element (`<dt>`) for the movie's release date to separate the words:

```diff
- <dt class="col-sm-2">ReleaseDate</dt>
+ <dt class="col-sm-2">Release Date</dt>
```

Examine the Razor markup for the submit button of the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> (CSS class removed for simplicity):

```razor
<button type="submit" disabled="@(movie is null)">Delete</button>
```

The **:::no-loc text="Delete":::** button sets its [`disabled` HTML attribute (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Attributes/disabled) based on the presence of the movie (not `null`) using an explicit Razor expression (`@(...)`).

In the C# code of the `@code` block, the `DeleteMovie` method removes the movie, saves the changes to the database, and navigates the user to the movies `Index` page. The exclamation point on the movie field (`movie!`) is the [null-forgiving operator (C# Language Reference)](/dotnet/csharp/language-reference/operators/null-forgiving), which suppresses nullable warnings for `movie`.

```csharp
private async Task DeleteMovie()
{
    using var context = DbFactory.CreateDbContext();
    context.Movie.Remove(movie!);
    await context.SaveChangesAsync();
    NavigationManager.NavigateTo("/movies");
}
```

### `Edit` component

Open the `Edit` component definition file (`Components/Pages/Movies/Edit.razor`).

Add a space to the content of the label element (`<label>`) for the movie's release date to separate the words:

```diff
- <label for="releasedate" class="form-label">ReleaseDate:</label>
+ <label for="releasedate" class="form-label">Release Date:</label>
```

The component uses an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> similar to the `Create` component.

The movie entity's identifier `Id` is stored in a hidden field of the form:

```razor
<input type="hidden" name="Movie.Id" value="@Movie.Id" />
```

Examine the C# code of the `@code` block:

```csharp
private async Task UpdateMovie()
{
    using var context = DbFactory.CreateDbContext();
    context.Attach(Movie!).State = EntityState.Modified;

    try
    {
        await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!MovieExists(Movie!.Id))
        {
            NavigationManager.NavigateTo("notfound");
        }
        else
        {
            throw;
        }
    }

    NavigationManager.NavigateTo("/movies");
}

private bool MovieExists(int id)
{
    using var context = DbFactory.CreateDbContext();
    return context.Movie.Any(e => e.Id == id);
}
```

The movie entity's <xref:Microsoft.EntityFrameworkCore.EntityState> is set to <xref:Microsoft.EntityFrameworkCore.EntityState.Modified>, which signifies that the entity is tracked by the context, exists in the database, and that some or all of its property values are modified.

If there's a concurrency exception and the movie entity no longer exists at the time that changes are saved, the component redirects to the non-existent endpoint (`notfound`), which results in returning a 404 (Not Found) status code. You could change this code to notify the user that the movie no longer exists in the database or create a dedicated *Not Found* component and navigate the user to that endpoint. If the movie exists and a concurrency exception is thrown, for example when another user has already modified the entity, the exception is rethrown by the component with the [`throw` statement (C# Language Reference)](/dotnet/csharp/language-reference/statements/exception-handling-statements#the-throw-statement). Additional guidance on handling concurrency with EF Core in Blazor apps is provided by the Blazor documentation.

> [!WARNING]
> Although it isn't a concern for the app in this tutorial, binding form data to entity data models can be susceptible to overposting attacks. Additional information on this subject appears in the next section.

## Mitigate overposting attacks

Statically-rendered server-side forms, such as those in the `Create` and `Edit` components, can be vulnerable to an *overposting* attack, also known as a *mass assignment* attack. An overposting attack occurs when a malicious user issues an HTML form POST to the server that processes data for properties that aren't part of the rendered form and that the developer doesn't wish to allow users to modify. The term "overposting" literally means that the malicious user has *over*-POSTed with the form.

In the example `Create` and `Edit` components of this tutorial, the `Movie` model doesn't include restricted properties for create and update operations, so overposting isn't a concern. However, it's important to keep overposting in mind when working with static SSR-based Blazor forms that you create and modify in the future.

To mitigate overposting, we recommend using a separate view model/data transfer object (DTO) for the form and database with create (insert) and update operations. When the form is submitted, only properties of the view model/DTO are used by the component and C# code to modify the database. Any extra data included by a malicious user is discarded, so the malicious user is prevented from conducting an overposting attack.

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* [`NavLink` component](xref:blazor/fundamentals/routing#navlink-component)
* <xref:blazor/components/layouts>
* [Razor directives](xref:mvc/views/razor#directives) (Razor syntax article) / [Razor directives](xref:blazor/components/index#razor-syntax) (Blazor documentation)
* <xref:blazor/components/quickgrid>
* <xref:blazor/forms/index>
* [Concurrency with EF Core in Blazor apps](xref:blazor/blazor-ef-core)
* <xref:blazor/globalization-localization>: Explains how to render globalized and localized content to users in different cultures and languages, including how to accept comma number separators.

## Next steps

> [!div class="step-by-step"]
> [Previous: Add and scaffold a model](xref:blazor/tutorials/movie-database-app/part-2)
> [Next: Work with a database](xref:blazor/tutorials/movie-database-app/part-4)
