' A page variable to "remember" the deleted category's BrochurePath value
Private deletedCategorysPdfPath As String = Nothing
Protected Sub Categories_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) _
    Handles Categories.RowDeleting
    
    ' Determine the PDF path for the category being deleted...
    Dim categoryID As Integer = Convert.ToInt32(e.Keys("CategoryID"))
    Dim categoryAPI As New CategoriesBLL()
    Dim categoriesData As Northwind.CategoriesDataTable = _
        categoryAPI.GetCategoryByCategoryID(categoryID)
    Dim category As Northwind.CategoriesRow = categoriesData(0)
    If category.IsBrochurePathNull() Then
        deletedCategorysPdfPath = Nothing
    Else
        deletedCategorysPdfPath = category.BrochurePath
    End If
End Sub
Protected Sub Categories_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) _
    Handles Categories.RowDeleted
    
    ' Delete the brochure file if there were no problems deleting the record
    If e.Exception Is Nothing Then
        DeleteRememberedBrochurePath()
    End If
End Sub