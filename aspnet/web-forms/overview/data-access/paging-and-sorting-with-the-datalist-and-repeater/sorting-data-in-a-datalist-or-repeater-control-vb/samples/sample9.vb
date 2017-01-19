Protected Sub SortByProductName_Click(sender As Object, e As EventArgs) _
    Handles SortByProductName.Click
    'Sort by ProductName
    RedirectUser(0, "ProductName")
End Sub
Protected Sub SortByCategoryName_Click(sender As Object, e As EventArgs) _
    Handles SortByCategoryName.Click
    'Sort by CategoryName
    RedirectUser(0, "CategoryName")
End Sub
Protected Sub SortBySupplierName_Click(sender As Object, e As EventArgs) _
    Handles SortBySupplierName.Click
    'Sort by SupplierName
    RedirectUser(0, "SupplierName")
End Sub