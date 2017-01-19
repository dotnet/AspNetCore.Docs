Protected Sub AddProducts_Click(sender As Object, e As EventArgs) _
    Handles AddProducts.Click
    ' Make sure that the UnitPrice CompareValidators report valid data...
    If Not Page.IsValid Then Exit Sub
    ' Add new ProductsRows to a ProductsDataTable...
    Dim products As New Northwind.ProductsDataTable()
    For i As Integer = firstControlID To lastControlID
        ' Read in the values for the product name and unit price
        Dim productName As String = CType(InsertingInterface.FindControl _
            ("ProductName" + i.ToString()), TextBox).Text.Trim()
        Dim unitPrice As String = CType(InsertingInterface.FindControl _
            ("UnitPrice" + i.ToString()), TextBox).Text.Trim()
        ' Ensure that if unitPrice has a value, so does productName
        If unitPrice.Length > 0 AndAlso productName.Length = 0 Then
            ' Display a warning and exit this event handler
            StatusLabel.Text = "If you provide a unit price you must also 
                                include the name of the product."
            StatusLabel.Visible = True
            Exit Sub
        End If
        ' Only add the product if a product name value is provided
        If productName.Length > 0 Then
            ' Add a new ProductsRow to the ProductsDataTable
            Dim newProduct As Northwind.ProductsRow = products.NewProductsRow()
            ' Assign the values from the web page
            newProduct.ProductName = productName
            newProduct.SupplierID = Convert.ToInt32(Suppliers.SelectedValue)
            newProduct.CategoryID = Convert.ToInt32(Categories.SelectedValue)
            If unitPrice.Length > 0 Then
                newProduct.UnitPrice = Convert.ToDecimal(unitPrice)
            End If
            ' Add any "default" values
            newProduct.Discontinued = False
            newProduct.UnitsOnOrder = 0
            products.AddProductsRow(newProduct)
        End If
    Next
    ' If we reach here, see if there were any products added
    If products.Count > 0 Then
        ' Add the new products to the database using a transaction
        Dim productsAPI As New ProductsBLL()
        productsAPI.UpdateWithTransaction(products)
        ' Rebind the data to the grid so that the producst just added are displayed
        ProductsGrid.DataBind()
        ' Display a confirmation (don't use the Warning CSS class, though)
        StatusLabel.CssClass = String.Empty
        StatusLabel.Text = String.Format( _
            "{0} products from supplier {1} have been " & _
            "added and filed under category {2}.", _
            products.Count, Suppliers.SelectedItem.Text, Categories.SelectedItem.Text)
        StatusLabel.Visible = True
        ' Revert to the display interface
        ReturnToDisplayInterface()
    Else
        ' No products supplied!
        StatusLabel.Text = 
            "No products were added. Please enter the " & _
            "product names and unit prices in the textboxes."
        StatusLabel.Visible = True
    End If
End Sub