Protected Sub Categories_RowUpdating _
    (sender As Object, e As GridViewUpdateEventArgs) _
    Handles Categories.RowUpdating
    
    ' Reference the RadioButtonList
    Dim BrochureOptions As RadioButtonList = _
        CType(Categories.Rows(e.RowIndex).FindControl("BrochureOptions"), _
            RadioButtonList)
    ' Get BrochurePath information about the record being updated
    Dim categoryID As Integer = Convert.ToInt32(e.Keys("CategoryID"))
    Dim categoryAPI As New CategoriesBLL()
    Dim categoriesData As Northwind.CategoriesDataTable = _
        categoryAPI.GetCategoryByCategoryID(categoryID)
    Dim category As Northwind.CategoriesRow = categoriesData(0)
    If BrochureOptions.SelectedValue = "1" Then
        ' Use current value for BrochurePath
        If category.IsBrochurePathNull() Then
            e.NewValues("brochurePath") = Nothing
        Else
            e.NewValues("brochurePath") = category.BrochurePath
        End If
    ElseIf BrochureOptions.SelectedValue = "2" Then
        ' Remove the current brochure (set it to NULL in the database)
        e.NewValues("brochurePath") = Nothing
    ElseIf BrochureOptions.SelectedValue = "3" Then
        ' Reference the BrochurePath FileUpload control
        Dim BrochureUpload As FileUpload = _
            CType(categories.Rows(e.RowIndex).FindControl("BrochureUpload"), _
                FileUpload)
        ' Process the BrochureUpload
        Dim cancelOperation As Boolean = False
        e.NewValues("brochurePath") = _
            ProcessBrochureUpload(BrochureUpload, cancelOperation)
        e.Cancel = cancelOperation
    Else
        ' Unknown value!
        Throw New ApplicationException( _
            String.Format("Invalid BrochureOptions value, {0}", _
                BrochureOptions.SelectedValue))
    End If
    If BrochureOptions.SelectedValue = "2" OrElse _
        BrochureOptions.SelectedValue = "3" Then
        
        ' "Remember" that we need to delete the old PDF file
        If (category.IsBrochurePathNull()) Then
            deletedCategorysPdfPath = Nothing
        Else
            deletedCategorysPdfPath = category.BrochurePath
        End If
    End If
End Sub
Protected Sub Categories_RowUpdated _
    (sender As Object, e As GridViewUpdatedEventArgs) _
    Handles Categories.RowUpdated
    
    ' If there were no problems and we updated the PDF file, 
    ' then delete the existing one
    If e.Exception Is Nothing Then
        DeleteRememberedBrochurePath()
    End If
End Sub