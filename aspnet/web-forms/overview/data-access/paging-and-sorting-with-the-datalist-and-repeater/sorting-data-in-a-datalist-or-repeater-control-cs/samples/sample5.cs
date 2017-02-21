[System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, false)]
public PagedDataSource GetProductsSortedAsPagedDataSource
    (string sortExpression, int pageIndex, int pageSize)
{
    // Get ALL of the products
    Northwind.ProductsDataTable products = GetProducts();
    // Sort the products
    products.DefaultView.Sort = sortExpression;
    // Limit the results through a PagedDataSource
    PagedDataSource pagedData = new PagedDataSource();
    pagedData.DataSource = products.DefaultView;
    pagedData.AllowPaging = true;
    pagedData.CurrentPageIndex = pageIndex;
    pagedData.PageSize = pageSize;
    return pagedData;
}