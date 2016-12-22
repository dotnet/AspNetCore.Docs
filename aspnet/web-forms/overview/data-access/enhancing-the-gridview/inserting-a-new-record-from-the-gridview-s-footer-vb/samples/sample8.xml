Protected Sub ProductsDataSource_Inserting _
    (sender As Object, e As .ObjectDataSourceMethodEventArgs) _
    Handles ProductsDataSource.Inserting
    
    ' Programmatically reference Web controls in the inserting interface...
    Dim NewProductName As TextBox = _
        Products.FooterRow.FindControl("NewProductName")
    Dim NewCategoryID As DropDownList = _
        Products.FooterRow.FindControl("NewCategoryID")
    Dim NewSupplierID As DropDownList = _
        Products.FooterRow.FindControl("NewSupplierID")
    Dim NewQuantityPerUnit As TextBox = _
        Products.FooterRow.FindControl("NewQuantityPerUnit")
    Dim NewUnitPrice As TextBox = _
        Products.FooterRow.FindControl("NewUnitPrice")
    Dim NewUnitsInStock As TextBox = _
        Products.FooterRow.FindControl("NewUnitsInStock")
    Dim NewUnitsOnOrder As TextBox = _
        Products.FooterRow.FindControl("NewUnitsOnOrder")
    Dim NewReorderLevel As TextBox = _
        Products.FooterRow.FindControl("NewReorderLevel")
    Dim NewDiscontinued As CheckBox = _
        Products.FooterRow.FindControl("NewDiscontinued")
    ' Set the ObjectDataSource's InsertParameters values...
    e.InputParameters("productName") = NewProductName.Text
    e.InputParameters("supplierID") = _
        Convert.ToInt32(NewSupplierID.SelectedValue)
    e.InputParameters("categoryID") = _
        Convert.ToInt32(NewCategoryID.SelectedValue)
    Dim quantityPerUnit As String = Nothing
    If Not String.IsNullOrEmpty(NewQuantityPerUnit.Text) Then
        quantityPerUnit = NewQuantityPerUnit.Text
    End If
    e.InputParameters("quantityPerUnit") = quantityPerUnit
    Dim unitPrice As Nullable(Of Decimal) = Nothing
    If Not String.IsNullOrEmpty(NewUnitPrice.Text) Then
        unitPrice = Convert.ToDecimal(NewUnitPrice.Text)
    End If
    e.InputParameters("unitPrice") = unitPrice
    Dim unitsInStock As Nullable(Of Short) = Nothing
    If Not String.IsNullOrEmpty(NewUnitsInStock.Text) Then
        unitsInStock = Convert.ToInt16(NewUnitsInStock.Text)
    End If
    e.InputParameters("unitsInStock") = unitsInStock
    Dim unitsOnOrder As Nullable(Of Short) = Nothing
    If Not String.IsNullOrEmpty(NewUnitsOnOrder.Text) Then
        unitsOnOrder = Convert.ToInt16(NewUnitsOnOrder.Text)
    End If
    e.InputParameters("unitsOnOrder") = unitsOnOrder
    Dim reorderLevel As Nullable(Of Short) = Nothing
    If Not String.IsNullOrEmpty(NewReorderLevel.Text) Then
        reorderLevel = Convert.ToInt16(NewReorderLevel.Text)
    End If
    e.InputParameters("reorderLevel") = reorderLevel
    e.InputParameters("discontinued") = NewDiscontinued.Checked
End Sub