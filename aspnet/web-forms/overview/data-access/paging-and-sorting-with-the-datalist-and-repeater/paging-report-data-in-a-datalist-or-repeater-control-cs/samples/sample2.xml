[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, false)]
public PagedDataSource GetProductsAsPagedDataSource(int pageIndex, int pageSize)
{
    // Get ALL of the products
    Northwind.ProductsDataTable products = GetProducts();
    // Limit the results through a PagedDataSource
    PagedDataSource pagedData = new PagedDataSource();
    pagedData.DataSource = products.Rows;
    pagedData.AllowPaging = true;
    pagedData.CurrentPageIndex = pageIndex;
    pagedData.PageSize = pageSize;
    return pagedData;
}