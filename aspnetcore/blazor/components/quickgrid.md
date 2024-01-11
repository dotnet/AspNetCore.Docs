---
title: ASP.NET Core Blazor QuickGrid component
author: guardrex
description: The QuickGrid component is a Razor component for quickly and efficiently displaying data in tabular form.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/quickgrid
---
# ASP.NET Core Blazor `QuickGrid` component

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 No API doc for Quickgrid and Microsoft.AspNetCore.Components.QuickGrid -->

The `QuickGrid` component is a Razor component for quickly and efficiently displaying data in tabular form. `QuickGrid` provides a simple and convenient data grid component for common grid rendering scenarios and serves as a reference architecture and performance baseline for building data grid components. `QuickGrid` is highly optimized and uses advanced techniques to achieve optimal rendering performance.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

## Package

Add a package reference for the [`Microsoft.AspNetCore.Components.QuickGrid`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.QuickGrid) package.

[!INCLUDE[](~/includes/package-reference.md)]

## Sample app

For various `QuickGrid` demonstrations, see the [**QuickGrid for Blazor** sample app](https://aspnet.github.io/quickgridsamples/). The demo site is hosted on GitHub Pages. The site loads fast thanks to static prerendering using the community-maintained [`BlazorWasmPrerendering.Build` GitHub project](https://github.com/jsakamoto/BlazorWasmPreRendering.Build).

## `QuickGrid` implementation

To implement a `QuickGrid` component:

* Specify tags for the `QuickGrid` component in Razor markup (`<QuickGrid>...</QuickGrid>`).
* Name a queryable source of data for the grid. Use ***either*** of the following data sources:
  * `Items`: A nullable `IQueryable<TGridItem>`, where `TGridItem` is the type of data represented by each row in the grid.
  * `ItemsProvider`: A callback that supplies data for the grid.
* `Class`: An optional CSS class name. If provided, the class name is included in the `class` attribute of the rendered table.
* `Theme`: A theme name (default value: `default`). This affects which styling rules match the table.
* `Virtualize`: If true, the grid is rendered with virtualization. This is normally used in conjunction with scrolling and causes the grid to fetch and render only the data around the current scroll viewport. This can greatly improve the performance when scrolling through large data sets. If you use `Virtualize`, you should supply a value for `ItemSize` and must ensure that every row renders with a constant height. Generally, it's preferable not to use `Virtualize` if the amount of data rendered is small or if you're using pagination.
* `ItemSize`: Only applicable when using `Virtualize`. `ItemSize` defines an expected height in pixels for each row, allowing the virtualization mechanism to fetch the correct number of items to match the display size and to ensure accurate scrolling.
* `ItemKey`: Optionally defines a value for `@key` on each rendered row. Typically, this is used to specify a unique identifier, such as a primary key value, for each data item. This allows the grid to preserve the association between row elements and data items based on their unique identifiers, even when the `TGridItem` instances are replaced by new copies (for example, after a new query against the underlying data store). If not set, the `@key` is the `TGridItem` instance.
* `Pagination`: Optionally links this `TGridItem` instance with a `PaginationState` model, causing the grid to fetch and render only the current page of data. This is normally used in conjunction with a `Paginator` component or some other UI logic that displays and updates the supplied `PaginationState` instance.
* In the `QuickGrid` child content (<xref:Microsoft.AspNetCore.Components.RenderFragment>), specify `PropertyColumn`s, which represent `TGridItem` columns whose cells display values:
  * `Property`: Defines the value to be displayed in this column's cells.
  * `Format`: Optionally specifies a format string for the value. Using `Format` requires the `TProp` type to implement `IFormattable`.
  * `Sortable`: Indicates whether the data should be sortable by this column. The default value may vary according to the column type. For example, a `TemplateColumn<TGridItem>` is sortable by default if any `TemplateColumn<TGridItem>.SortBy` parameter is specified.
  * `InitialSortDirection`: Indicates the sort direction if `IsDefaultSortColumn` is `true`.
  * `IsDefaultSortColumn`: Indicates whether this column should be sorted by default.
  * `PlaceholderTemplate`: If specified, virtualized grids use this template to render cells whose data hasn't been loaded.

For example, add the following component to render a grid.

The component assumes that the Interactive Server render mode (`InteractiveServer`) is inherited from a parent component or applied globally to the app, which enables interactive features. For the following example, the only interactive feature is sortable columns.

`PromotionGrid.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/PromotionGrid.razor":::

For an example that uses an <xref:System.Linq.IQueryable> with Entity Framework Core as the queryable data source, see the [`SampleQuickGridComponent` component in the ASP.NET Core Basic Test App (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/QuickGridTest/SampleQuickGridComponent.razor).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

To use Entity Framework (EF) Core as the data source:

* Add a ***prerelease*** package reference for the [`Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter) package. If using the .NET CLI to add the package reference, include the `--prerelease` option when you execute the [`dotnet add package` command](/dotnet/core/tools/dotnet-add-package).

  [!INCLUDE[](~/includes/package-reference.md)]

* Call `AddQuickGridEntityFrameworkAdapter` on the service collection in the `Program` file to register an EF-aware implementation of `IAsyncQueryExecutor`:

  ```csharp
  builder.Services.AddQuickGridEntityFrameworkAdapter();
  ```

QuickGrid supports passing custom attributes to the rendered table element:

```razor
<QuickGrid Items="..." custom-attribute="somevalue" class="custom-class">
```

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

<QuickGrid Items="@people">
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

## `QuickGrid` scaffolder (Preview)

<!-- UPDATE 9.0 Remove when out of preview -->

> [!IMPORTANT]
> The `QuickGrid` scaffolder is in ***preview***. The scaffolder is unsupported for use in production apps. Features of the scaffolder are subject to change without notice.

The preview `QuickGrid` scaffolder offered in [Visual Studio Preview](https://visualstudio.microsoft.com/vs/preview/) scaffolds Razor components with `QuickGrid` to display data from a database.

To use the scaffolder, right-click the project in **Solution Explorer** and select **Add** > **New Scaffolded Item**. Open **Installed** > **Common** > **Razor Component**. Select **Razor Components using Entity Framework (CRUD)**.

The scaffolder generates basic Create, Read, Update, and Delete (CRUD) pages based on an Entity Framework Core data model. You can scaffold individual pages or all of the CRUD pages. You select the model class and the `DbContext`, optionally creating a new `DbContext` if needed.

The scaffolded Razor components are added to the project's `Pages` folder in a generated folder named after the model class. The generated `Index` component uses `QuickGrid` to display the data. Customize the generated components as needed and enable interactivity to take advantage of interactive features, such as sorting and filtering.

The components produced by the scaffolder require server-side rendering (SSR), so they aren't supported when running on WebAssembly.
