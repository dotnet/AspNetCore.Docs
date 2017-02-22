Private Sub BatchUpdateAlternate()
    ' Enumerate the GridView's Rows collection and create a ProductRow
    Dim productsAPI As New ProductsBLL()
    Dim products As New Northwind.ProductsDataTable()
    For Each gvRow As GridViewRow In ProductsGrid.Rows
        ' Create a new ProductRow instance
        Dim productID As Integer = _
            Convert.ToInt32(ProductsGrid.DataKeys(gvRow.RowIndex).Value)
        Dim currentProductDataTable As Northwind.ProductsDataTable = _
            productsAPI.GetProductByProductID(productID)
        If currentProductDataTable.Rows.Count > 0 Then
            Dim product As Northwind.ProductsRow = currentProductDataTable(0)
            Dim productName As TextBox = _
                CType(gvRow.FindControl("ProductName"), TextBox)
            Dim categories As DropDownList = _
                CType(gvRow.FindControl("Categories"), DropDownList)
            Dim unitPrice As TextBox = _
                CType(gvRow.FindControl("UnitPrice"), TextBox)
            Dim discontinued As CheckBox = _
                CType(gvRow.FindControl("Discontinued"), CheckBox)
            ' Assign the user-entered values to the current ProductRow
            product.ProductName = productName.Text.Trim()
            If categories.SelectedIndex = 0 Then 
                product.SetCategoryIDNull() 
            Else 
                product.CategoryID = Convert.ToInt32(categories.SelectedValue)
            End If
            If unitPrice.Text.Trim().Length = 0 Then 
                product.SetUnitPriceNull() 
            Else 
                product.UnitPrice = Convert.ToDecimal(unitPrice.Text)
            End If
            product.Discontinued = discontinued.Checked
            ' Import the ProductRow into the products DataTable
            products.ImportRow(product)
        End If
    Next
    ' Now have the BLL update the products data using a transaction
    productsAPI.UpdateProductsWithTransaction(products)
End Sub