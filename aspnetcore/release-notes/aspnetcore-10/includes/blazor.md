### QuickGrid `RowClass` parameter

Apply a stylesheet class to a row of the grid based on the row item using the new `RowClass` parameter. In the following example, the `ApplyRowStyle` method is called on each row to conditionally apply a stylesheet class based on the row item:

```razor
<QuickGrid ... RowClass="ApplyRowStyle">
    ...
</QuickGrid>

@code {
    private string ApplyRowStyle({TYPE} rowItem) =>
        rowItem.{PROPERTY} == {VALUE} ? "{CSS STYLE CLASS}" : null;
}
```

For more information, see <xref:blazor/components/quickgrid?view=aspnetcore-10.0#style-a-table-row-based-on-the-row-item>.

### Blazor script

In prior releases of .NET, the Blazor script is served from an embedded resource in the ASP.NET Core shared framework. In .NET 10 or later, the Blazor script is served as a static web asset with automatic compression and fingerprinting.

For more information, see the following resources:
  
* <xref:blazor/project-structure?view=aspnetcore-10.0#location-of-the-blazor-script>
* <xref:blazor/fundamentals/static-files?view=aspnetcore-10.0>

### Route template highlights

The [`[Route]` attribute](xref:Microsoft.AspNetCore.Components.RouteAttribute) now supports route syntax highlighting to help visualize the structure of the route template:

![Route template pattern for the Order ID is highlighted in a method that maps endpoints](~/release-notes/aspnetcore-10/_static/route-template-highlighting.png)

<!-- PREVIEW 2

### `NavigateTo` no longer scrolls to the top for same-page navigations

Previously, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> scrolled to the top of the page for same-page navigations. This behavior has been changed in .NET 10 so that the browser no longer scrolls to the top of the page when navigating to the same page. This means the viewport is no longer reset when making updates to the address for the current page, such as changing the query string or fragment.

-->
