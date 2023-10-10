---
title: ASP.NET Core Razor component virtualization
author: guardrex
description: Learn how to use component virtualization in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/components/virtualization
---
# ASP.NET Core Razor component virtualization

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use component virtualization in ASP.NET Core Blazor apps.

Improve the perceived performance of component rendering using the Blazor framework's built-in virtualization support with the [`Virtualize` component](xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601). Virtualization is a technique for limiting UI rendering to just the parts that are currently visible. For example, virtualization is helpful when the app must render a long list of items and only a subset of items is required to be visible at any given time.

Use the `Virtualize` component ([reference source](xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601)) when:

* Rendering a set of data items in a loop.
* Most of the items aren't visible due to scrolling.
* The rendered items are the same size.

When the user scrolls to an arbitrary point in the `Virtualize` component's list of items, the component calculates the visible items to show. Unseen items aren't rendered.

Without virtualization, a typical list might use a C# [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) loop to render each item in a list. In the following example:

* `allFlights` is a collection of airplane flights.
* The `FlightSummary` component displays details about each flight.
* The [`@key` directive attribute](xref:blazor/components/key) preserves the relationship of each `FlightSummary` component to its rendered flight by the flight's `FlightId`.

```razor
<div style="height:500px;overflow-y:scroll">
    @foreach (var flight in allFlights)
    {
        <FlightSummary @key="flight.FlightId" Details="@flight.Summary" />
    }
</div>
```

If the collection contains thousands of flights, rendering the flights takes a long time and users experience a noticeable UI lag. Most of the flights aren't seen because they fall outside of the height of the `<div>` element.

Instead of rendering the entire list of flights at once, replace the [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) loop in the preceding example with the `Virtualize` component:

* Specify `allFlights` as a fixed item source to <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.Items%2A?displayProperty=nameWithType>. Only the currently visible flights are rendered by the `Virtualize` component.
* Specify a context for each flight with the `Context` parameter. In the following example, `flight` is used as the context, which provides access to each flight's members.

```razor
<div style="height:500px;overflow-y:scroll">
    <Virtualize Items="@allFlights" Context="flight">
        <FlightSummary @key="flight.FlightId" Details="@flight.Summary" />
    </Virtualize>
</div>
```

If a context isn't specified with the `Context` parameter, use the value of `context` in the item content template to access each flight's members:

```razor
<div style="height:500px;overflow-y:scroll">
    <Virtualize Items="@allFlights">
        <FlightSummary @key="context.FlightId" Details="@context.Summary" />
    </Virtualize>
</div>
```

The `Virtualize` component:

* Calculates the number of items to render based on the height of the container and the size of the rendered items.
* Recalculates and rerenders the items as the user scrolls.
* Only fetches the slice of records from an external API that correspond to the current visible region, instead of downloading all of the data from the collection.
* Receives a generic <xref:System.Collections.Generic.ICollection%601> for <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.Items?displayProperty=nameWithType>. If a non-generic collection supplies the items (for example, a collection of <xref:System.Data.DataRow>), follow the guidance in the [Item provider delegate](#item-provider-delegate) section to supply the items.

The item content for the `Virtualize` component can include:

* Plain HTML and Razor code, as the preceding example shows.
* One or more Razor components.
* A mix of HTML/Razor and Razor components.

## Item provider delegate

If you don't want to load all of the items into memory or the collection isn't a generic <xref:System.Collections.Generic.ICollection%601>, you can specify an items provider delegate method to the component's <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.ItemsProvider%2A?displayProperty=nameWithType> parameter that asynchronously retrieves the requested items on demand. In the following example, the `LoadEmployees` method provides the items to the `Virtualize` component:

```razor
<Virtualize Context="employee" ItemsProvider="@LoadEmployees">
    <p>
        @employee.FirstName @employee.LastName has the 
        job title of @employee.JobTitle.
    </p>
</Virtualize>
```

The items provider receives an <xref:Microsoft.AspNetCore.Components.Web.Virtualization.ItemsProviderRequest>, which specifies the required number of items starting at a specific start index. The items provider then retrieves the requested items from a database or other service and returns them as an <xref:Microsoft.AspNetCore.Components.Web.Virtualization.ItemsProviderResult%601> along with a count of the total items. The items provider can choose to retrieve the items with each request or cache them so that they're readily available.

A `Virtualize` component can only accept **one item source** from its parameters, so don't attempt to simultaneously use an items provider and assign a collection to `Items`. If both are assigned, an <xref:System.InvalidOperationException> is thrown when the component's parameters are set at runtime.

The following example loads employees from an `EmployeeService` (not shown):

```csharp
private async ValueTask<ItemsProviderResult<Employee>> LoadEmployees(
    ItemsProviderRequest request)
{
    var numEmployees = Math.Min(request.Count, totalEmployees - request.StartIndex);
    var employees = await EmployeesService.GetEmployeesAsync(request.StartIndex, 
        numEmployees, request.CancellationToken);

    return new ItemsProviderResult<Employee>(employees, totalEmployees);
}
```

In the following example, a collection of <xref:System.Data.DataRow> is a non-generic collection, so an items provider delegate is used for virtualization:

```razor
<Virtualize Context="row" ItemsProvider="@GetRows">
    ...
</Virtualize>

@code{
    ...

    private ValueTask<ItemsProviderResult<DataRow>> GetRows(ItemsProviderRequest request)
    {
        return new(new ItemsProviderResult<DataRow>(
            dataTable.Rows.OfType<DataRow>().Skip(request.StartIndex).Take(request.Count),
            dataTable.Rows.Count));
    }
}
```

<xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.RefreshDataAsync%2A?displayProperty=nameWithType> instructs the component to rerequest data from its <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.ItemsProvider%2A>. This is useful when external data changes. There's usually no need to call <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.RefreshDataAsync%2A> when using <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.Items%2A>. 

:::moniker range=">= aspnetcore-6.0"

<xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.RefreshDataAsync%2A> updates a `Virtualize` component's data without causing a rerender. If <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.RefreshDataAsync%2A> is invoked from a Blazor event handler or component lifecycle method, triggering a render isn't required because a render is automatically triggered at the end of the event handler or lifecycle method. If <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.RefreshDataAsync%2A> is triggered separately from a background task or event, such as in the following `ForecastUpdated` delegate, call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> to update the UI at the end of the background task or event:

```csharp
<Virtualize ... @ref="virtualizeComponent">
    ...
</Virtualize>

...

private Virtualize<FetchData>? virtualizeComponent;

protected override void OnInitialized()
{
    WeatherForecastSource.ForecastUpdated += async () => 
    {
        await InvokeAsync(async () =>
        {
            await virtualizeComponent?.RefreshDataAsync();
            StateHasChanged();
        });
    });
}
```

In the preceding example:

* <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.RefreshDataAsync%2A> is called first to obtain new data for the `Virtualize` component.
* `StateHasChanged` is called to rerender the component.

:::moniker-end

## Placeholder

Because requesting items from a remote data source might take some time, you have the option to render a placeholder with item content:

* Use a <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.Placeholder%2A> (`<Placeholder>...</Placeholder>`) to display content until the item data is available.
* Use <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.ItemContent%2A?displayProperty=nameWithType> to set the item template for the list.

```razor
<Virtualize Context="employee" ItemsProvider="@LoadEmployees">
    <ItemContent>
        <p>
            @employee.FirstName @employee.LastName has the 
            job title of @employee.JobTitle.
        </p>
    </ItemContent>
    <Placeholder>
        <p>
            Loading&hellip;
        </p>
    </Placeholder>
</Virtualize>
```

:::moniker range=">= aspnetcore-8.0"

## Empty content

Use the `EmptyContent` parameter to supply content when the component has loaded and either `Items` is empty or `ItemsProviderResult<T>.TotalItemCount` is zero.

EmptyContent.razor:

```razor
@page "/empty-content"
@rendermode RenderMode.InteractiveServer

<h1>Empty Content Example</h1>

<Virtualize Items="@stringList">
    <ItemContent>
        <p>
            @context
        </p>
    </ItemContent>
    <EmptyContent>
        <p>
            There are no strings to display.
        </p>
    </EmptyContent>
</Virtualize>

@code {
    private List<string>? stringList;

    protected override void OnInitialized() => stringList ??= new();
}
```

Change the `OnInitialized` method lambda to see the component display strings:

```csharp
protected override void OnInitialized() =>
    stringList ??= new() { "Here's a string!", "Here's another string!" };
```

:::moniker-end

## Item size

The height of each item in pixels can be set with <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.ItemSize%2A?displayProperty=nameWithType> (default: 50). The following example changes the height of each item from the default of 50 pixels to 25 pixels:

```razor
<Virtualize Context="employee" Items="@employees" ItemSize="25">
    ...
</Virtualize>
```

By default, the `Virtualize` component measures the rendering size (height) of individual items *after* the initial render occurs. Use <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.ItemSize%2A> to provide an exact item size in advance to assist with accurate initial render performance and to ensure the correct scroll position for page reloads. If the default <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.ItemSize%2A> causes some items to render outside of the currently visible view, a second re-render is triggered. To correctly maintain the browser's scroll position in a virtualized list, the initial render must be correct. If not, users might view the wrong items.

## Overscan count

<xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.OverscanCount%2A?displayProperty=nameWithType> determines how many additional items are rendered before and after the visible region. This setting helps to reduce the frequency of rendering during scrolling. However, higher values result in more elements rendered in the page (default: 3). The following example changes the overscan count from the default of three items to four items:

```razor
<Virtualize Context="employee" Items="@employees" OverscanCount="4">
    ...
</Virtualize>
```

## State changes

When making changes to items rendered by the `Virtualize` component, call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> to force re-evaluation and rerendering of the component. For more information, see <xref:blazor/components/rendering>.

:::moniker range=">= aspnetcore-6.0"

## Keyboard scroll support

To allow users to scroll virtualized content using their keyboard, ensure that the virtualized elements or scroll container itself is focusable. If you fail to take this step, keyboard scrolling doesn't work in Chromium-based browsers.

For example, you can use a `tabindex` attribute on the scroll container:

```razor
<div style="height:500px; overflow-y:scroll" tabindex="-1">
    <Virtualize Items="@allFlights">
        <div class="flight-info">...</div>
    </Virtualize>
</div>
```

To learn more about the meaning of `tabindex` value `-1`, `0`, or other values, see [`tabindex` (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Global_attributes/tabindex).

## Advanced styles and scroll detection

The `Virtualize` component is only designed to support specific element layout mechanisms. To understand which element layouts work correctly, the following explains how `Virtualize` detects which elements should be visible for display in the correct place.

If your source code looks like the following:

```razor
<div style="height:500px; overflow-y:scroll" tabindex="-1">
    <Virtualize Items="@allFlights" ItemSize="100">
        <div class="flight-info">Flight @context.Id</div>
    </Virtualize>
</div>
```

At runtime, the `Virtualize` component renders a DOM structure similar to the following:

```html
<div style="height:500px; overflow-y:scroll" tabindex="-1">
    <div style="height:1100px"></div>
    <div class="flight-info">Flight 12</div>
    <div class="flight-info">Flight 13</div>
    <div class="flight-info">Flight 14</div>
    <div class="flight-info">Flight 15</div>
    <div class="flight-info">Flight 16</div>
    <div style="height:3400px"></div>
</div>
```

The actual number of rows rendered and the size of the spacers vary according to your styling and `Items` collection size. However, notice that there are spacer `div` elements injected before and after your content. These serve two purposes:

* To provide an offset before and after your content, causing currently-visible items to appear at the correct location in the scroll range and the scroll range itself to represent the total size of all content.
* To detect when the user is scrolling beyond the current visible range, meaning that different content must be rendered.

> [!NOTE]
> To learn how to control the spacer HTML element tag, see the [Control the spacer element tag name](#control-the-spacer-element-tag-name) section later in this article.

The spacer elements internally use an [Intersection Observer](https://developer.mozilla.org/docs/Web/API/Intersection_Observer_API) to receive notification when they're becoming visible. `Virtualize` depends on receiving these events. `Virtualize` works under the following conditions:

* **All content items are of identical height.** This makes it possible to calculate which content corresponds to a given scroll position without first fetching every data item and rendering the data into a DOM element.

* **Both the spacers and the content rows are rendered in a single vertical stack with every item filling the whole horizontal width.** This is generally the default. In typical cases with `div` elements, `Virtualize` works by default. If you're using CSS to create a more advanced layout, bear in mind the following requirements:

  * Scroll container styling requires a `display` with any of the following values:
    * `block` (the default for a `div`).
    * `table-row-group` (the default for a `tbody`).
    * `flex` with `flex-direction` set to `column`. Ensure that immediate children of the `Virtualize` component don't shrink under flex rules. For example, add `.mycontainer > div { flex-shrink: 0 }`.
  * Content row styling requires a `display` with either of the following values:
    * `block` (the default for a `div`).
    * `table-row` (the default for a `tr`).
  * Don't use CSS to interfere with the layout for the spacer elements. By default, the spacer elements have a `display` value of `block`, except if the parent is a table row group, in which case they default to `table-row`. Don't try to influence spacer element width or height, including by causing them to have a border or `content` pseudo-elements.

Any approach that stops the spacers and content elements from rendering as a single vertical stack, or causes the content items to vary in height, prevents correct functioning of the `Virtualize` component.

:::moniker-end

## Root-level virtualization

:::moniker range=">= aspnetcore-7.0"

The `Virtualize` component supports using the document itself as the scroll root, as an alternative to having some other element with `overflow-y: scroll`. In the following example, the `<html>` or `<body>` elements are styled in a component with `overflow-y: scroll`:

```razor
<HeadContent>
    <style>
        html, body { overflow-y: scroll }
    </style>
</HeadContent>
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

The `Virtualize` component supports using the document itself as the scroll root, as an alternative to having some other element with `overflow-y: scroll`. When using the document as the scroll root, avoid styling the `<html>` or `<body>` elements with `overflow-y: scroll` because it causes the [intersection observer](#advanced-styles-and-scroll-detection) to treat the full scrollable height of the page as the visible region, instead of just the window viewport.

You can reproduce this problem by creating a large virtualized list (for example, 100,000 items) and attempt to use the document as the scroll root with `html { overflow-y: scroll }` in the page CSS styles. Although it may work correctly at times, the browser attempts to render all 100,000 items at least once at the start of rendering, which may cause a browser tab lockup.

To work around this problem prior to the release of .NET 7, either avoid styling `<html>`/`<body>` elements with `overflow-y: scroll` or adopt an alternative approach. In the following example, the height of the `<html>` element is set to just over 100% of the viewport height:

```razor
<HeadContent>
    <style>
        html { min-height: calc(100vh + 0.3px) }
    </style>
</HeadContent>
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The `Virtualize` component supports using the document itself as the scroll root, as an alternative to having some other element with `overflow-y: scroll`. When using the document as the scroll root, avoid styling the `<html>` or `<body>` elements with `overflow-y: scroll` because it cause the full scrollable height of the page to be treated as the visible region, instead of just the window viewport.

You can reproduce this problem by creating a large virtualized list (for example, 100,000 items) and attempt to use the document as the scroll root with `html { overflow-y: scroll }` in the page CSS styles. Although it may work correctly at times, the browser attempts to render all 100,000 items at least once at the start of rendering, which may cause a browser tab lockup.

To work around this problem prior to the release of .NET 7, either avoid styling `<html>`/`<body>` elements with `overflow-y: scroll` or adopt an alternative approach. In the following example, the height of the `<html>` element is set to just over 100% of the viewport height:

```razor
<style>
    html { min-height: calc(100vh + 0.3px) }
</style>
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Control the spacer element tag name

If the `Virtualize` component is placed inside an element that requires a specific child tag name, <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601.SpacerElement> allows you to obtain or set the virtualization spacer tag name. The default value is `div`. For the following example, the `Virtualize` component renders inside a table body element ([`tbody`](https://developer.mozilla.org/docs/Web/HTML/Element/tbody)), so the appropriate child element for a table row ([`tr`](https://developer.mozilla.org/docs/Web/HTML/Element/tr)) is set as the spacer.

`VirtualizedTable.razor`:

```razor
@page "/virtualized-table"

<HeadContent>
    <style>
        html, body { overflow-y: scroll }
    </style>
</HeadContent>

<h1>Virtualized Table Example</h1>

<table id="virtualized-table">
    <thead style="position: sticky; top: 0; background-color: silver">
        <tr>
            <th>Item</th>
            <th>Another column</th>
        </tr>
    </thead>
    <tbody>
        <Virtualize Items="@fixedItems" ItemSize="30" SpacerElement="tr">
            <tr @key="context" style="height: 30px;" id="row-@context">
                <td>Item @context</td>
                <td>Another value</td>
            </tr>
        </Virtualize>
    </tbody>
</table>

@code {
    private List<int> fixedItems = Enumerable.Range(0, 1000).ToList();
}
```

In the preceding example, the document root is used as the scroll container, so the `html` and `body` elements are styled with `overflow-y: scroll`. For more information, see the following resources:

* [Root-level virtualization](#root-level-virtualization) section
* <xref:blazor/components/control-head-content>

:::moniker-end
