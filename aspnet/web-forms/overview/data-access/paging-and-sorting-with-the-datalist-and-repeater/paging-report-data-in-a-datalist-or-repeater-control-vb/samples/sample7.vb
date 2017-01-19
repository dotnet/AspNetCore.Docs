Protected Sub ProductsDefaultPagingDataSource_Selected(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) _
    Handles ProductsDefaultPagingDataSource.Selected
    ' Reference the PagedDataSource bound to the DataList
    Dim pagedData As PagedDataSource = CType(e.ReturnValue, PagedDataSource)
    ' Remember the total number of records being paged through across postbacks
    TotalRowCount = pagedData.DataSourceCount
End Sub