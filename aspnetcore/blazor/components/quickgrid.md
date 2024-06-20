---
title: ASP.NET Core Blazor QuickGrid component
author: guardrex
description: The QuickGrid component is a Razor component for quickly and efficiently displaying data in tabular form.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/components/quickgrid
---
# ASP.NET Core Blazor `QuickGrid` component

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

The [`QuickGrid`](xref:Microsoft.AspNetCore.Components.QuickGrid) component is a Razor component for quickly and efficiently displaying data in tabular form. `QuickGrid` provides a simple and convenient data grid component for common grid rendering scenarios and serves as a reference architecture and performance baseline for building data grid components. `QuickGrid` is highly optimized and uses advanced techniques to achieve optimal rendering performance.

## Package

Add a package reference for the [`Microsoft.AspNetCore.Components.QuickGrid`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.QuickGrid) package.

[!INCLUDE[](~/includes/package-reference.md)]

## Sample app

For various `QuickGrid` demonstrations, see the [**QuickGrid for Blazor** sample app](https://aspnet.github.io/quickgridsamples/). The demo site is hosted on GitHub Pages. The site loads fast thanks to static prerendering using the community-maintained [`BlazorWasmPrerendering.Build` GitHub project](https://github.com/jsakamoto/BlazorWasmPreRendering.Build).

## `QuickGrid` implementation

To implement a `QuickGrid` component:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

* Specify tags for the `QuickGrid` component in Razor markup (`<QuickGrid>...</QuickGrid>`).
* Name a queryable source of data for the grid. Use ***either*** of the following data sources:
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A>: A nullable `IQueryable<TGridItem>`, where `TGridItem` is the type of data represented by each row in the grid.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemsProvider%2A>: A callback that supplies data for the grid.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Class%2A>: An optional CSS class name. If provided, the class name is included in the `class` attribute of the rendered table.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Theme%2A>: A theme name (default value: `default`). This affects which styling rules match the table.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A>: If true, the grid is rendered with virtualization. This is normally used in conjunction with scrolling and causes the grid to fetch and render only the data around the current scroll viewport. This can greatly improve the performance when scrolling through large data sets. If you use <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A>, you should supply a value for <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemSize%2A> and must ensure that every row renders with a constant height. Generally, it's preferable not to use <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A> if the amount of data rendered is small or if you're using pagination.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemSize%2A>: Only applicable when using <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A>. <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemSize%2A> defines an expected height in pixels for each row, allowing the virtualization mechanism to fetch the correct number of items to match the display size and to ensure accurate scrolling.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemKey%2A>: Optionally defines a value for `@key` on each rendered row. Typically, this is used to specify a unique identifier, such as a primary key value, for each data item. This allows the grid to preserve the association between row elements and data items based on their unique identifiers, even when the `TGridItem` instances are replaced by new copies (for example, after a new query against the underlying data store). If not set, the `@key` is the `TGridItem` instance.
* `OverscanCount`: Defines how many additional items to render before and after the visible region to reduce rendering frequency during scrolling. While higher values can improve scroll smoothness by rendering more items off-screen, a higher value can also result in an increase in initial load times. Finding a balance based on your data set size and user experience requirements is recommended. The default value is 3. Only available when using <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A>. 
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Pagination%2A>: Optionally links this `TGridItem` instance with a <xref:Microsoft.AspNetCore.Components.QuickGrid.PaginationState> model, causing the grid to fetch and render only the current page of data. This is normally used in conjunction with a <xref:Microsoft.AspNetCore.Components.QuickGrid.Paginator> component or some other UI logic that displays and updates the supplied <xref:Microsoft.AspNetCore.Components.QuickGrid.PaginationState> instance.
* In the `QuickGrid` child content (<xref:Microsoft.AspNetCore.Components.RenderFragment>), specify <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn`2>s, which represent `TGridItem` columns whose cells display values:
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602.Property%2A>: Defines the value to be displayed in this column's cells.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602.Format%2A>: Optionally specifies a format string for the value. Using <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602.Format%2A> requires the `TProp` type to implement <xref:System.IFormattable>.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Sortable%2A>: Indicates whether the data should be sortable by this column. The default value may vary according to the column type. For example, a <xref:Microsoft.AspNetCore.Components.QuickGrid.TemplateColumn%601> is sortable by default if any <xref:Microsoft.AspNetCore.Components.QuickGrid.TemplateColumn%601.SortBy%2A> parameter is specified.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.InitialSortDirection%2A>: Indicates the sort direction if <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.IsDefaultSortColumn%2A> is `true`.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.IsDefaultSortColumn%2A>: Indicates whether this column should be sorted by default.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.PlaceholderTemplate%2A>: If specified, virtualized grids use this template to render cells whose data hasn't been loaded.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.HeaderTemplate>: An optional template for this column's header cell. If not specified, the default header template includes the <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Title>, along with any applicable sort indicators and options buttons.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Title>: Title text for the column. The title is rendered automatically if <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.HeaderTemplate> isn't used.

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

* Specify tags for the `QuickGrid` component in Razor markup (`<QuickGrid>...</QuickGrid>`).
* Name a queryable source of data for the grid. Use ***either*** of the following data sources:
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A>: A nullable `IQueryable<TGridItem>`, where `TGridItem` is the type of data represented by each row in the grid.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemsProvider%2A>: A callback that supplies data for the grid.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Class%2A>: An optional CSS class name. If provided, the class name is included in the `class` attribute of the rendered table.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Theme%2A>: A theme name (default value: `default`). This affects which styling rules match the table.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A>: If true, the grid is rendered with virtualization. This is normally used in conjunction with scrolling and causes the grid to fetch and render only the data around the current scroll viewport. This can greatly improve the performance when scrolling through large data sets. If you use <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A>, you should supply a value for <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemSize%2A> and must ensure that every row renders with a constant height. Generally, it's preferable not to use <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A> if the amount of data rendered is small or if you're using pagination.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemSize%2A>: Only applicable when using <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Virtualize%2A>. <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemSize%2A> defines an expected height in pixels for each row, allowing the virtualization mechanism to fetch the correct number of items to match the display size and to ensure accurate scrolling.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemKey%2A>: Optionally defines a value for `@key` on each rendered row. Typically, this is used to specify a unique identifier, such as a primary key value, for each data item. This allows the grid to preserve the association between row elements and data items based on their unique identifiers, even when the `TGridItem` instances are replaced by new copies (for example, after a new query against the underlying data store). If not set, the `@key` is the `TGridItem` instance.
* <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Pagination%2A>: Optionally links this `TGridItem` instance with a <xref:Microsoft.AspNetCore.Components.QuickGrid.PaginationState> model, causing the grid to fetch and render only the current page of data. This is normally used in conjunction with a <xref:Microsoft.AspNetCore.Components.QuickGrid.Paginator> component or some other UI logic that displays and updates the supplied <xref:Microsoft.AspNetCore.Components.QuickGrid.PaginationState> instance.
* In the `QuickGrid` child content (<xref:Microsoft.AspNetCore.Components.RenderFragment>), specify <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn`2>s, which represent `TGridItem` columns whose cells display values:
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602.Property%2A>: Defines the value to be displayed in this column's cells.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602.Format%2A>: Optionally specifies a format string for the value. Using <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn%602.Format%2A> requires the `TProp` type to implement <xref:System.IFormattable>.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Sortable%2A>: Indicates whether the data should be sortable by this column. The default value may vary according to the column type. For example, a <xref:Microsoft.AspNetCore.Components.QuickGrid.TemplateColumn%601> is sortable by default if any <xref:Microsoft.AspNetCore.Components.QuickGrid.TemplateColumn%601.SortBy%2A> parameter is specified.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.InitialSortDirection%2A>: Indicates the sort direction if <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.IsDefaultSortColumn%2A> is `true`.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.IsDefaultSortColumn%2A>: Indicates whether this column should be sorted by default.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.PlaceholderTemplate%2A>: If specified, virtualized grids use this template to render cells whose data hasn't been loaded.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.HeaderTemplate>: An optional template for this column's header cell. If not specified, the default header template includes the <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Title>, along with any applicable sort indicators and options buttons.
  * <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Title>: Title text for the column. The title is rendered automatically if <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.HeaderTemplate> isn't used.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

For example, add the following component to render a grid.

The component assumes that the Interactive Server render mode (`InteractiveServer`) is inherited from a parent component or applied globally to the app, which enables interactive features. For the following example, the only interactive feature is sortable columns.

`PromotionGrid.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/PromotionGrid.razor":::

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The `QuickGrid` component is an experimental Razor component for quickly and efficiently displaying data in tabular form. `QuickGrid` provides a simple and convenient data grid component for common grid rendering scenarios and serves as a reference architecture and performance baseline for building data grid components. `QuickGrid` is highly optimized and uses advanced techniques to achieve optimal rendering performance.

To get started with `QuickGrid`:

Add a ***prerelease*** package reference for the [`Microsoft.AspNetCore.Components.QuickGrid`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.QuickGrid) package. If using the .NET CLI to add the package reference, include the `--prerelease` option when you execute the [`dotnet add package` command](/dotnet/core/tools/dotnet-add-package).

[!INCLUDE[](~/includes/package-reference.md)]

> [!NOTE]
> Because the `Microsoft.AspNetCore.Components.QuickGrid` package is an experimental package for .NET 7, the package remains in *prerelease* status forever for .NET 7 Blazor apps. The package reached production status for .NET 8 or later. For more information, see an 8.0 or later version of this article.

Add the following component to render a grid.

`PromotionGrid.razor`:

```razor
@page "/promotion-grid"
@using Microsoft.AspNetCore.Components.QuickGrid

<QuickGrid Items="people">
    <PropertyColumn Property="@(p => p.PersonId)" Sortable="true" />
    <PropertyColumn Property="@(p => p.Name)" Sortable="true" />
    <PropertyColumn Property="@(p => p.PromotionDate)" Format="yyyy-MM-dd" Sortable="true" />
</QuickGrid>

@code {
    private record Person(int PersonId, string Name, DateOnly PromotionDate);

    private IQueryable<Person> people = new[]
    {
        new Person(10895, "Jean Martin", new DateOnly(1985, 3, 16)),
        new Person(10944, "António Langa", new DateOnly(1991, 12, 1)),
        new Person(11203, "Julie Smith", new DateOnly(1958, 10, 10)),
        new Person(11205, "Nur Sari", new DateOnly(1922, 4, 27)),
        new Person(11898, "Jose Hernandez", new DateOnly(2011, 5, 3)),
        new Person(12130, "Kenji Sato", new DateOnly(2004, 1, 9)),
    }.AsQueryable();
}
```

:::moniker-end

Access the component in a browser at the relative path `/promotion-grid`.

There aren't current plans to extend `QuickGrid` with features that full-blown commercial grids tend to offer, for example, hierarchical rows, drag-to-reorder columns, or Excel-like range selections. If you require advanced features that you don't wish to develop on your own, continue using third-party grids.

## Custom attributes and styles

QuickGrid also supports passing custom attributes and style classes to the rendered table element:

```razor
<QuickGrid Items="..." custom-attribute="value" class="custom-class">
```

:::moniker range=">= aspnetcore-8.0"

## Entity Framework Core (EF Core) data source

EF Core's <xref:Microsoft.EntityFrameworkCore.DbContext> provides a <xref:Microsoft.EntityFrameworkCore.DbSet%601> property for each table in the database. Supply the property to the <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter.

The following example uses the `People` <xref:Microsoft.EntityFrameworkCore.DbSet%601> (table) as the data source:

```razor
@inject ApplicationDbContext AppDbContext

<QuickGrid Items="@AppDbContext.People">
    ...
</QuickGrid>
```

You may also use any EF-supported LINQ operator to filter the data before passing it to the <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.Items%2A> parameter.

The following example filters documents by a category ID:

```razor
<QuickGrid Items="@AppDbContext.Documents.Where(d => d.CategoryId == categoryId)">
    ...
</QuickGrid>
```

QuickGrid recognizes EF-supplied <xref:System.Linq.IQueryable> instances and knows how to resolve queries asynchronously for efficiency.

Start by adding a package reference for the [`Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter` NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter).

[!INCLUDE[](~/includes/package-reference.md)]

Call <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkAdapterServiceCollectionExtensions.AddQuickGridEntityFrameworkAdapter%2A> on the service collection in the `Program` file to register an EF-aware <xref:Microsoft.AspNetCore.Components.QuickGrid.IAsyncQueryExecutor> implementation:

```csharp
builder.Services.AddQuickGridEntityFrameworkAdapter();
```

:::moniker-end

## Display name support

A column title can be assigned using <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Title?displayProperty=nameWithType> in the <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn`2>'s tag. In the following example, the column is given the name "`Release Date`" for the column's movie release date data:

```razor
<PropertyColumn Property="movie => movie.ReleaseDate" Title="Release Date" />
```

However, managing column titles (names) from bound model properties is usually a better choice for maintaining an app. A model can control the display name of a property with the [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute). In the following example, the model specifies a movie release date display name of "`Release Date`" for its `ReleaseDate` property:

```csharp
[Display(Name = "Release Date")]
public DateTime ReleaseDate { get; set; }
```

To enable the `QuickGrid` component to use the <xref:System.ComponentModel.DataAnnotations.DisplayAttribute.Name?displayProperty=nameWithType>, subclass <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn`2> either in the component or in a separate class:

```csharp
public class DisplayNameColumn<TGridItem, TProp> : PropertyColumn<TGridItem, TProp>
{
    protected override void OnParametersSet()
    {
        if (Title is null && Property.Body is MemberExpression memberExpression)
        {
            var memberInfo = memberExpression.Member;
            Title = 
                memberInfo.GetCustomAttribute<DisplayNameAttribute>().DisplayName ??
                memberInfo.GetCustomAttribute<DisplayAttribute>().Name ??
                memberInfo.Name;
        }

        base.OnParametersSet();
    }
}
```

Use the subclass in the `QuickGrid` component. In the following example, the preceding `DisplayNameColumn` is used. The name "`Release Date`" is provided by the [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute) in the model, so there's no need to specify a <xref:Microsoft.AspNetCore.Components.QuickGrid.ColumnBase%601.Title>:

```razor
<DisplayNameColumn Property="movie => movie.ReleaseDate" />
```

The [`[DisplayName]` attribute](xref:System.ComponentModel.DisplayNameAttribute) is also supported:

```csharp
[DisplayName("Release Date")]
public DateTime ReleaseDate { get; set; }
```

However, the `[Display]` attribute is recommended because it makes additional properties available. For example, the `[Display]` attribute offers the ability to assign a resource type for localization.

## Remote data

In Blazor WebAssembly apps, fetching data from a JSON-based web API on a server is a common requirement. To fetch only the data that's required for the current page/viewport of data and apply sorting or filtering rules on the server, use the <xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemsProvider%2A> parameter.

<xref:Microsoft.AspNetCore.Components.QuickGrid.QuickGrid%601.ItemsProvider%2A> can also be used in a server-side Blazor app if the app is required to query an external endpoint or in other cases where the requirements aren't covered by an <xref:System.Linq.IQueryable>.

Supply a callback matching the <xref:Microsoft.AspNetCore.Components.QuickGrid.GridItemsProvider%601> delegate type, where `TGridItem` is the type of data displayed in the grid. The callback is given a parameter of type <xref:Microsoft.AspNetCore.Components.QuickGrid.GridItemsProviderRequest%601>, which specifies the start index, maximum row count, and sort order of data to return. In addition to returning the matching items, a total item count (`totalItemCount`) is also required for paging and virtualization to function correctly.

The following example obtains data from the public [OpenFDA Food Enforcement database](https://open.fda.gov/apis/food/enforcement/).

The <xref:Microsoft.AspNetCore.Components.QuickGrid.GridItemsProvider%601> converts the <xref:Microsoft.AspNetCore.Components.QuickGrid.GridItemsProviderRequest%601> into a query against the OpenFDA database. Query parameters are translated into the particular URL format supported by the external JSON API. It's only possible to perform sorting and filtering via sorting and filtering that's supported by the external API. The OpenFDA endpoint doesn't support sorting, so none of the columns are marked as sortable. However, it does support skipping records (`skip` parameter) and limiting the return of records (`limit` parameter), so the component can enable virtualization and scroll quickly through tens of thousands of records.

`FoodRecalls.razor`:

```razor
@page "/food-recalls"
@inject HttpClient Http
@inject NavigationManager NavManager

<PageTitle>Food Recalls</PageTitle>

<h1>OpenFDA Food Recalls</h1>

<div class="grid" tabindex="-1">
    <QuickGrid ItemsProvider="@foodRecallProvider" Virtualize="true">
        <PropertyColumn Title="ID" Property="@(c => c.Event_Id)" />
        <PropertyColumn Property="@(c => c.State)" />
        <PropertyColumn Property="@(c => c.City)" />
        <PropertyColumn Title="Company" Property="@(c => c.Recalling_Firm)" />
        <PropertyColumn Property="@(c => c.Status)" />
    </QuickGrid>
</div>

<p>Total: <strong>@numResults results found</strong></p>

@code {
    GridItemsProvider<FoodRecall>? foodRecallProvider;
    int numResults;

    protected override async Task OnInitializedAsync()
    {
        foodRecallProvider = async req =>
        {
            var url = NavManager.GetUriWithQueryParameters(
                "https://api.fda.gov/food/enforcement.json", 
                new Dictionary<string, object?>
            {
                { "skip", req.StartIndex },
                { "limit", req.Count },
            });

            var response = await Http.GetFromJsonAsync<FoodRecallQueryResult>(
                url, req.CancellationToken);

            return GridItemsProviderResult.From(
                items: response!.Results,
                totalItemCount: response!.Meta.Results.Total);
        };

        numResults = (await Http.GetFromJsonAsync<FoodRecallQueryResult>(
            "https://api.fda.gov/food/enforcement.json"))!.Meta.Results.Total;
    }
}
```

For more information on calling web APIs, see <xref:blazor/call-web-api>.

## `QuickGrid` scaffolder

The `QuickGrid` scaffolder scaffolds Razor components with `QuickGrid` to display data from a database.

The scaffolder generates basic Create, Read, Update, and Delete (CRUD) pages based on an Entity Framework Core data model. You can scaffold individual pages or all of the CRUD pages. You select the model class and the `DbContext`, optionally creating a new `DbContext` if needed.

The scaffolded Razor components are added to the project's `Pages` folder in a generated folder named after the model class. The generated `Index` component uses `QuickGrid` to display the data. Customize the generated components as needed and enable interactivity to take advantage of interactive features, such as sorting and filtering.

The components produced by the scaffolder require server-side rendering (SSR), so they aren't supported when running on WebAssembly.

To use the scaffolder in Visual Studio, right-click the project in **Solution Explorer** and select **Add** > **New Scaffolded Item**. Open **Installed** > **Common** > **Razor Component**. Select **Razor Components using Entity Framework (CRUD)**. To use the scaffolder with the .NET CLI, see <xref:fundamentals/tools/dotnet-aspnet-codegenerator>.

<!-- UPDATE 8.0 Uncomment link after
                https://github.com/dotnet/AspNetCore.Docs/pull/32747
                merges.

For an example use case, see <xref:blazor/tutorials/movie-database-app/index>.
-->
