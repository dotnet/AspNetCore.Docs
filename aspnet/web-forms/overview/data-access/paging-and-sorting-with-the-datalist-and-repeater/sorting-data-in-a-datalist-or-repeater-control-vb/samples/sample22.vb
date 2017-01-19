Protected Sub SortByProductName_Click(sender As Object, e As EventArgs) _
    Handles SortByProductName.Click
    StartRowIndex = 0
    SortExpression = "ProductName"
    Products.DataBind()
End Sub
Protected Sub SortByCategoryName_Click(sender As Object, e As EventArgs) _
    Handles SortByCategoryName.Click
    StartRowIndex = 0
    SortExpression = "CategoryName"
    Products.DataBind()
End Sub
Protected Sub SortBySupplierName_Click(sender As Object, e As EventArgs) _
    Handles SortBySupplierName.Click
    StartRowIndex = 0
    SortExpression = "CompanyName"
    Products.DataBind()
End Sub