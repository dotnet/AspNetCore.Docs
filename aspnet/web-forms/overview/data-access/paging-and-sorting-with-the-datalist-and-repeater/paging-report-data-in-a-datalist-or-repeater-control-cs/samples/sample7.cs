protected void ProductsDefaultPagingDataSource_Selected
    (object sender, ObjectDataSourceStatusEventArgs e)
{
    // Reference the PagedDataSource bound to the DataList
    PagedDataSource pagedData = (PagedDataSource)e.ReturnValue;
    // Remember the total number of records being paged through
    // across postbacks
    TotalRowCount = pagedData.DataSourceCount;
}