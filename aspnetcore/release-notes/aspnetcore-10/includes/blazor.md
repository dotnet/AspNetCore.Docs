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
