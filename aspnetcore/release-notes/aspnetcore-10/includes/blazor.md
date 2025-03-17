### QuickGrid `RowClass` parameter

Apply a stylesheet class to a row of the grid based on the row item using the new `RowClass` parameter. In the following example, the `GetRowCssClass` method is called on each row to conditionally apply a stylesheet class based on the row item:

```razor
<QuickGrid ... RowClass="GetRowCssClass">
    ...
</QuickGrid>

@code {
    private string GetRowCssClass(MyGridItem item) =>
        item.IsArchived ? "row-archived" : null;
}
```

For more information, see <xref:blazor/components/quickgrid?view=aspnetcore-10.0#style-a-table-row-based-on-the-row-item>.

### Blazor script as static web asset

In prior releases of .NET, the Blazor script is served from an embedded resource in the ASP.NET Core shared framework. In .NET 10 or later, the Blazor script is served as a static web asset with automatic compression and fingerprinting.

For more information, see the following resources:
  
* <xref:blazor/project-structure?view=aspnetcore-10.0#location-of-the-blazor-script>
* <xref:blazor/fundamentals/static-files?view=aspnetcore-10.0>

### Route template highlights

The [`[Route]` attribute](xref:Microsoft.AspNetCore.Components.RouteAttribute) now supports route syntax highlighting to help visualize the structure of the route template:

![Route template pattern of a route attribute for the counter value shows syntax highlighting](~/release-notes/aspnetcore-10/_static/route-template-highlighting.png)

<!-- PREVIEW 2

### `NavigateTo` no longer scrolls to the top for same-page navigations

Previously, <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> scrolled to the top of the page for same-page navigations. This behavior has been changed in .NET 10 so that the browser no longer scrolls to the top of the page when navigating to the same page. This means the viewport is no longer reset when making updates to the address for the current page, such as changing the query string or fragment.

### Reconnection UI component added to the Blazor Web App project template

The Blazor Web App project template now includes a `ReconnectModal` component, including collocated stylesheet and JavaScript files, for improved developer control over the reconnection UI when the client loses the WebSocket connection to the server. The component doesn't insert styles programmatically, ensuring compliance with stricter Content Security Policy (CSP) settings for the `style-src` policy. In prior releases, the default reconnection UI was created by the framework in a way that could cause CSP violations. Note that the default reconnection UI is still used as fallback when the app doesn't define the reconnection UI, such as by using the project template's `ReconnectModal` component or a similar custom component.

New reconnection UI features:

* Apart from indicating the reconnection state by setting a specific CSS class on the reconnection UI element, the new `components-reconnect-state-changed` event is dispatched for reconnection state changes.
* Code can better differentiate the stages of the reconnection process with the new reconnection state "`retrying`," indicated by both the CSS class and the new event.

For more information, see <xref:blazor/fundamentals/signalr?view=aspnetcore-10.0#reflect-the-server-side-connection-state-in-the-ui>.

### Ignore the query string and fragment when using `NavLinkMatch.All`

The `NavLink` component now ignores the query string and fragment when using the `NavLinkMatch.All` value for the `Match` parameter. This means that the link retains the `active` class if the URL path matches but the query string or fragment change. To revert to the original behavior, use the `Microsoft.AspNetCore.Components.Routing.NavLink.DisableMatchAllIgnoresLeftUriPart` [`AppContext` switch](/dotnet/fundamentals/runtime-libraries/system-appcontext).

You can also override the `ShouldMatch` method on `NavLink` to customize the matching behavior:

```csharp
public class CustomNavLink : NavLink
{
    protected override bool ShouldMatch(string currentUriAbsolute)
    {
        // Custom matching logic
    }
}
```

For more information, see <xref:blazor/fundamentals/routing#navlink-component>.

### Close `QuickGrid` column options

You can now close the `QuickGrid` column options UI using the new `CloseColumnOptionsAsync` method.

The following example uses the `CloseColumnOptionsAsync` method to close the column options UI as soon as the title filter is applied:

```razor
<QuickGrid @ref="movieGrid" Items="movies">
    <PropertyColumn Property="@(m => m.Title)" Title="Title">
        <ColumnOptions>
            <input type="search" @bind="titleFilter" placeholder="Filter by title" 
                @bind:after="@(() => movieGrid.CloseColumnOptionsAsync())" />
        </ColumnOptions>
    </PropertyColumn>
    <PropertyColumn Property="@(m => m.Genre)" Title="Genre" />
    <PropertyColumn Property="@(m => m.ReleaseYear)" Title="Release Year" />
</QuickGrid>

@code {
    private QuickGrid<Movie>? movieGrid;
    private string titleFilter = string.Empty;
    private IQueryable<Movie> movies = new List<Movie> { ... }.AsQueryable();
    private IQueryable<Movie> filteredMovies => 
        movies.Where(m => m.Title!.Contains(titleFilter));
}
```

-->
