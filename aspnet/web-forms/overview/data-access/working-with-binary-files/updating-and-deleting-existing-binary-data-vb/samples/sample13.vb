Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim categoryID As Integer = _
        Convert.ToInt32(Request.QueryString("CategoryID"))
    ' Get information about the specified category
    Dim categoryAPI As New CategoriesBLL()
    Dim categories As Northwind.CategoriesDataTable = _
        categoryAPI.GetCategoryWithBinaryDataByCategoryID(categoryID)
    Dim category As Northwind.CategoriesRow = categories(0)
    ' For new categories, images are JPGs...
    ' Output HTTP headers providing information about the binary data
    Response.ContentType = "image/jpeg"
    ' Output the binary data
    Response.BinaryWrite(category.Picture)
End Sub