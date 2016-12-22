<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Select, False)> _
Public Function GetProductsSortedAsPagedDataSource _
    (sortExpression As String, pageIndex As Integer, pageSize As Integer) _
    As PagedDataSource
    ' Get ALL of the products
    Dim products As Northwind.ProductsDataTable = GetProducts()
    'Sort the products
    products.DefaultView.Sort = sortExpression
    ' Limit the results through a PagedDataSource
    Dim pagedData As New PagedDataSource()
    pagedData.DataSource = products.DefaultView
    pagedData.AllowPaging = True
    pagedData.CurrentPageIndex = pageIndex
    pagedData.PageSize = pageSize
    Return pagedData
End Function