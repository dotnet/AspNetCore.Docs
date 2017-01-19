<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Select, False)> _
Public Function GetProductsAsPagedDataSource(ByVal pageIndex As Integer, _
    ByVal pageSize As Integer) As PagedDataSource
    ' Get ALL of the products
    Dim products As Northwind.ProductsDataTable = GetProducts()
    ' Limit the results through a PagedDataSource
    Dim pagedData As New PagedDataSource()
    pagedData.DataSource = products.Rows
    pagedData.AllowPaging = True
    pagedData.CurrentPageIndex = pageIndex
    pagedData.PageSize = pageSize
    Return pagedData
End Function