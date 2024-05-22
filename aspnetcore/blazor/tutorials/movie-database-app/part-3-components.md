---
title: Build a Blazor movie database app (Part 3 - Learn about Razor components)
author: guardrex
description: This part of the Blazor movie database app tutorial explains ...
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/06/2024
uid: blazor/tutorials/movie-database/components
---
# Build a Blazor movie database app (Part 3 - Learn about Razor components)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the third part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the series examines the Razor components in the project. 

Blazor apps are based on *Razor components*, often referred to as just *components*. A *component* is an element of UI, such as a page, dialog, or data entry form. Components are .NET C# classes built into [.NET assemblies](/dotnet/standard/assembly/).

*Razor* refers to how components are usually written in the form of a [Razor](xref:mvc/views/razor) markup page (`.razor` file extension) for client-side UI logic and composition. Razor is a syntax for combining HTML markup with C# code designed for developer productivity. Razor files use the `.razor` file extension.

Although developers and online resources use the term "Blazor components," the documentation avoids that term and universally adopts the formal name "Razor components" (or just "components").

The anatomy of a Razor component follows the following general pattern:

* At the top of the component definition (`.razor` file), razor markup specifies the way that component markup is parsed or functions.
* Next, Razor markup specifies how HTML is rendered, which includes ordinary HTML elements.
* Finally, an `@code` block contains C# code to execute during component lifecycle stages and when various events occur, such as when a user selects a rendered button on the page.

Consider the following `Counter` component example (`Counter.razor`), which is a basic component example that appears in Blazor project templates:

```razor
@page "/counter"

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

The first line represents an important Razor construct in Razor components, the *Razor directive*. A Razor directive is a reserved keyword prefixed with `@` that appears in Razor markup that changes the way component markup is parsed or functions. In the preceding example, the Razor directive (`@page`) specifies the route template for the component. This component is reached in a browser at the relative URL `/counter`. By convention, a component's directives are placed at the top of the component definition file and are placed in a consistent order (component ordering is covered in the reference documentation on components).

The <xref:Microsoft.AspNetCore.Components.Web.PageTitle> component is a component built into the framework that specifies a page title. In this case, the page title is `Counter`.

`Counter` is also the first rendered markup of the component per the content of the H1 heading element (`<h1>`).

A current count is displayed using Razor syntax by prefixing the at symbol (`@`) to a C# variable (`currentCount`).

Next, the button element appears. Note the *Razor directive attribute*, `@onclick`, specifies an event handler that executes when the button is selected. The event handler is an ordinary C# method.

The `@code` block contains the C# code of the component. `currentCount` is a private integer type variable initialized to a value of zero (0). The `IncrementCount` method is an ordinary C# method that increments `currentCount` by one each time the method executes.

In the following sections of this article:

* Three components for webpage navigation and layout are described, the `NavMenu`, <xref:Microsoft.AspNetCore.Components.Routing.NavLink>, and `MainLayout` components.
* The components created by scaffolding for CRUD operations on movie database entities are discussed.

## `NavMenu` component for navigation

The `NavMenu` component implements sidebar navigation using <xref:Microsoft.AspNetCore.Components.Routing.NavLink> components, which render navigation links to other Razor components.

A <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component behaves like an `<a>` element, except it toggles an `active` CSS class based on whether its `href` matches the current URL. The `active` class helps a user understand which page is the active page among the navigation links displayed. <xref:Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All?displayProperty=nameWithType> assigned to the <xref:Microsoft.AspNetCore.Components.Routing.NavLink.Match%2A> parameter configures the component to display an active CSS class when it matches the entire current URL.

The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component is built-into the Blazor framework and available for all Blazor apps to use. The `NavMenu` component is only part of Blazor project templates.

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

The final `NavMenu` component:

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

Run the app and note that the brand is displayed at the top of the sidebar navigation and a link to reach the movies page (**`Movies`**) appears in the sidebar navigation.

## `MainLayout` component for layout

The `MainLayout` component is the app's default layout. The `MainLayout` component inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>, which is a base class for components that represent a layout. The app's components that use the layout are rendered where the <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body%2A> (`@Body`) appears in the markup.

The `MainLayout` component is only part of Blazor project templates.

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

The first line of the `MainLayout` component is the `@inherits` Razor directive that specifies this component inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>.

The `MainLayout` component adopts the following additional specifications:

* The `NavMenu` component is rendered in the sidebar. Notice that you only need to place an HTML tag with the component name to render a component at that location in Razor markup. This allows you to nest components within each other and within whatever HTML layout you implement.
* The main content includes:
  * An `About` link that sends the user to the ASP.NET Core documentation landing page.
  * An `<article>` element with the <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body%2A> (`@Body`) parameter, where components that use the layout are rendered.

The default layout (`MainLayout` component) is specified in the `Routes` component (`Components/Pages/Routes.razor`):

```razor
<RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />
```

Individual components are free to set their own non-default layout, and a layout can be applied to whole folder of components via an `_Imports.razor` file. These features are covered in detail in the Blazor documentation.

## Create, Read, Update, Delete (CRUD) components

The following sections explain the composition of the movie CRUD components and how they work.

### `Index` component

Open the `Index` component file (`Components/Pages/Movies/Index.razor`) definition file.

The Razor directives at the top of the file indicate the relative URL for the page is `/movies`. An `@using` directive makes the <xref:Microsoft.AspNetCore.Components.QuickGrid?displayProperty=fullName> API available to the component. A `QuickGrid` component is used to display movie entities from the database. The database context (`BlazorWebAppMoviesContext`) is injected into the component with the `@inject` directive. Finally, an `@using` directive makes the project's models available (`BlazorWebAppMovies.Models`).

```razor
@page "/movies"
@using Microsoft.AspNetCore.Components.QuickGrid
@inject BlazorWebAppMovies.Data.BlazorWebAppMoviesContext DB
@using BlazorWebAppMovies.Models
```

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

The <xref:Microsoft.AspNetCore.Components.QuickGrid> component displays movie entities. `Movie` from the injected database context (`DB`) is the item provider. For each movie entity, the component displays the movie's title, release date, genre, and price. A column also holds links to edit, see details, and delete each movie entity. Notice how the context (`Context`) parameter specifies a parameter name (`movie`) for each content expression of the <xref:Microsoft.AspNetCore.Components.QuickGrid.TemplateColumn%601>. `Movie` class properties are read from the parameter. For example, the movie identifier (`Id`) is available in `movie.Id`. The at symbol (`@`) with parentheses (`@(...)`), which is called an *explicit Razor expression*, allows the `href` of each link to include the movie entity's `Id` property in the link query string as an *interpolated string* (`$...{...}...`).

```razor
<QuickGrid Class="table" Items="DB.Movie">
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
```

For the movie example from the last part of the tutorial series, *The Matrix*&copy;, the <xref:Microsoft.AspNetCore.Components.QuickGrid> component renders the following HTML markup (some elements and attributes aren't present to simplify display). See how the explicit Razor expressions and interpolated strings produced the `href` values for the links to other pages. The movie entity's `Id` is `3`, which is composed in the query strings.

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
            <td>3/29/1999 12:00:00 AM</td>
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

Run the app to see that the column now displays two words for the release date.

### `Details` component

Open the `Details` component file (`Components/Pages/Movies/Details.razor`) definition file.

The Razor directives at the top of the file indicate the relative URL for the page is `/movies/details`. As before, the database context is injected, and namespaces are provided to access API (`BlazorWebAppMovies.Models` and `Microsoft.EntityFrameworkCore`). The `Details` component also injects the app's <xref:Microsoft.AspNetCore.Components.NavigationManager>, which is used for a variety of navigation-related features in components.

```razor
@page "/movies/details"
@inject BlazorWebAppMovies.Data.BlazorWebAppMoviesContext DB
@using BlazorWebAppMovies.Models
@inject NavigationManager NavigationManager
@using Microsoft.EntityFrameworkCore
```

Details for a movie entity are only shown if the movie, located by its identifier (`Id`) from the query string, has been loaded for display. If there's a short delay while the component retrieves the entity, a loading message (*`Loading...`*) is displayed. The presence of the movie in `movie` is checked with an `@if` Razor statement:

```razor
@if (movie is null)
{
    <p><em>Loading...</em></p>
}
```

When the movie is loaded, it's displayed as a [description list (MDN documenation)](https://developer.mozilla.org/docs/Web/HTML/Element/dl) along with two links:

* The first link provides the user an opportunity to edit the entity.
* The second link allows the user to return to the movies `Index` page.

CSS classes aren't present to simplify display in the following example:

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

Examine the C# of the component's `@code` block:

```csharp
Movie? movie;

[SupplyParameterFromQuery]
public int Id { get; set; }

protected override async Task OnInitializedAsync()
{
    movie = await DB.Movie.FirstOrDefaultAsync(m => m.Id == Id);

    if (movie is null)
    {
        NavigationManager.NavigateTo("notfound");
    }
}
```

The `movie` variable is a private field of type `Movie`, which is a null-reference type (`?`), meaning that `movie` might be set to `null`.

The `Id` is a *component parameter* supplied from the component's query string due to the presence of the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute). If the identifier is missing, `Id` is set to zero (`0`).

`OnInitializedAsync` is the first component lifecycle method that we've seen. This method is executed when the component loads. <xref:Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync%2A> is called on the database set (`DbSet<Movie>`) to retrieve the movie entity with and `Id` equal to the `Id` parameter that was set by the query string. If `movie` is `null`, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> is used to navigate to a `notfound` endpoint.

<!-- UPDATE 10.0 - See https://github.com/dotnet/aspnetcore/issues/45654 
                   for .NET 10 work on handling a 404 with static SSR without \
                   having to navigate to a non-existent endpoint. -->

There isn't an actual `notfound` endpoint (component) in the app. When adopting server-side rendering (SSR), Blazor doesn't have a mechanism to return a 404 (Not Found) status code. As a temporary workaround, a 404 is generated by navigating to a non-existent endpoint. This scaffolded code is for your further implementation of a suitable result when not finding an entity. For example, you could have the component direct the user to a page where they can file an inquiry with your support team, or you could remove the injected <xref:Microsoft.AspNetCore.Components.NavigationManager> and <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> code and replace it with Razor markup and code that displays a message to the user that the entity wasn't found.

### `Create` component

Open the `Create` component file (`Components/Pages/Movies/Create.razor`) definition file.

The component uses a built-in component called an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, which renders a form for user input and includes validation features. <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model%2A> parameter is assigned the model, in this case `Movie`. <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit%2A> specifies a method to invoke (`AddMovie`) when the form is submitted and the form contains valid field entries. By convention, every form should assign a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.FormName%2A> to prevent form collisions when multiple forms are present on a page. The <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Enhance%2A> flag activates a Blazor feature for server-side rendering (SSR) that submits the form without performing a full-page reload.

For validation:

* <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> adds data annotations validation support, which is covered in part 5 of this tutorial series.
* The <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component displays a list of validation messages.
* <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> components holds validation messages for the form's fields.

Blazor includes several form element components to assist you in creating forms. The following form uses <xref:Microsoft.AspNetCore.Components.Forms.InputText>, <xref:Microsoft.AspNetCore.Components.Forms.InputDate>, and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber> components. Each of these is bound to a model property with `@bind-Value` Razor syntax, where `Value` is a property in each input component.

CSS classes aren't present to simplify display in the following example:

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

In the component's `@code` block, C# code includes a `Movie` component parameter tied to the form via the [`[SupplyParameterFromForm]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute).

The `AddMovie` method:

* Is called when the form is submitted with valid form field entries (`OnValidSubmit="AddMovie"`).
* Adds the movie data bound to the form's model (`Movie`).
* <xref:Microsoft.EntityFrameworkCore.DbContext.SaveChangesAsync%2A> is called on the database context to save the movie.
* <xref:Microsoft.AspNetCore.Components.NavigationManager> is used to return the user to the movies `Index` page.

```csharp
    [SupplyParameterFromForm]
    public Movie Movie { get; set; } = new();

    public async Task AddMovie()
    {
        DB.Movie.Add(Movie);
        await DB.SaveChangesAsync();
        NavigationManager.NavigateTo("/movies");
    }
}
```

> [!WARNING]
> The preceding code is susceptible to overposting attacks. Guidance on how to address this is covered in the [Mitigate overposting attacks](#mitigate-overposting-attacks) section.

### `Delete` component

Open the `Delete` component file (`Components/Pages/Movies/Delete.razor`) definition file.

Examine the Razor markup for the submit button of the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> (CSS class removed for simplicity):

```razor
<button type="submit" disabled="@(movie is null)">Delete</button>
```

The `**Delete**` button sets its [`disabled` HTML attribute (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Attributes/disabled) based on the presence of the movie (not `null`) using an explicit Razor expression (`@(...)`).

In the C# code of the `@code` block, the `DeleteMovie` method removes the movie, saves the changes to the data database, and navigates the user to the movies `Index` page. The exclamation point on the movie field (`movie!`) is the [null-forgiving operator (C# Language Reference)](/dotnet/csharp/language-reference/operators/null-forgiving), which suppresses all nullable warnings for `movie`.

```csharp
public async Task DeleteMovie()
{
    DB.Movie.Remove(movie!);
    await DB.SaveChangesAsync();
    NavigationManager.NavigateTo("/movies");
}
```

### `Edit` component

Open the `Edit` component file (`Components/Pages/Movies/Edit.razor`) definition file.

The component uses an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> similar to the `Create` component.

The movie entity's identifier `Id` is stored in a hidden field of the form:

```razor
<input type="hidden" name="Movie.Id" value="@Movie.Id" />
```

Examine the C# code of the `@code` block:

```csharp
public async Task UpdateMovie()
{
    DB.Attach(Movie!).State = EntityState.Modified;

    try
    {
        await DB.SaveChangesAsync();
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

bool MovieExists(int id)
{
    return DB.Movie.Any(e => e.Id == id);
}
```

The movie entity's <xref:Microsoft.EntityFrameworkCore.EntityState> is set to <xref:Microsoft.EntityFrameworkCore.EntityState.Modified>, which signifies that the entity is tracked by the context, exists in the database, and that some or all of its property values are modified.

If there's a concurrency exception and the movie entity no longer exists at the time that changes are saved, the component redirects to the non-existant endpoint (`notfound`), which results in returning a 404 (Not Found) status code. You could change this code for a production app to notify the user that the movie no longer exists in the database or create a dedicated Not Found component and navigate the user to that endpoint. If the movie exists and a concurrency exception is thrown, for example when another user has already modified the entity, the exception is rethrown by the component with the [`throw` statement (C# Language Reference)](/dotnet/csharp/language-reference/statements/exception-handling-statements#the-throw-statement).

> [!WARNING]
> The preceding code is susceptible to overposting attacks. Guidance on how to address this is covered in the [Mitigate overposting attacks](#mitigate-overposting-attacks) section.

<!-- DO WE WANT TO COVER ROUTE TEMPLATES?

     e.g. ... @page "/movies/edit/{id:int?}"

## Use a route template instead of a query string

-->

## Mitigate overposting attacks

Statically-rendered server-side forms, such as those in the `Create` and `Edit` components, can be vulnerable to an *overposting* attack, also known as a *mass assignment* attack. An overposting attack occurs when a malicious user issues an HTML form POST to the server that processes data for properties that aren't part of the rendered form and that the developer doesn't wish to allow users to modify. The term "overposting" literally means that the malicious user has *over*-POSTed with the form.

In the example `Create` and `Edit` components of this tutorial, overposting isn't a concern because the `Movie` model doesn't include restricted properties for create and update operations. However, it's important to keep overposting in mind when working with static SSR-based Blazor forms that you create and modify in the future in other apps.

To mitigate overposting, we recommend using a separate view model/data transfer object (DTO) for the form and database with create (insert) and update operations. When the form is submitted, only properties of the view model/DTO are used by the component. Any extra data included by a malicious user is discarded, so the malicious user is prevented from conducting an overposting attack.

## Globalization

To support [jQuery validation](https://jqueryvalidation.org/) for non-English locales that use a comma (`,`) for a decimal point and non-US English date formats, you must take steps to globalize the app. For instructions on adding comma number separator, see [Show support jQuery validation for non-English locales that use a comma (",") for a decimal point (`dotnet/AspNetCore.Docs` #4076)](https://github.com/dotnet/AspNetCore.Docs/issues/4076#issuecomment-326590420).

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* [`NavLink` component](xref:blazor/fundamentals/routing#navlink-component)
* <xref:blazor/components/layouts>
* [Razor directives](xref:mvc/views/razor#directives) (Razor syntax article) / [Razor directives](xref:blazor/components/index#razor-syntax) (Blazor documentation)
* <xref:blazor/components/quickgrid>
* <xref:blazor/forms/index>

## Next steps

> [!div class="step-by-step"]
> [Previous: Add a model](xref:blazor/tutorials/movie-database/model)
> [Next: Work with a database](xref:blazor/tutorials/movie-database/database)
