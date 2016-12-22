Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim categoryID As Integer = Convert.ToInt32(Request.QueryString("CategoryID"))
    ' Get information about the specified category
    Dim categoryAPI As New CategoriesBLL()
    Dim categories As Northwind.CategoriesDataTable = _
        categoryAPI.GetCategoryWithBinaryDataByCategoryID(categoryID)
    Dim category As Northwind.CategoriesRow = categories(0)
    If categoryID <= 8 Then
        ' Output HTTP headers providing information about the binary data
        Response.ContentType = "image/bmp"
        ' Output the binary data
        ' But first we need to strip out the OLE header
        Const OleHeaderLength As Integer = 78
        Dim strippedImageLength As Integer = _
            category.Picture.Length - OleHeaderLength
        Dim strippedImageData(strippedImageLength) As Byte
        Array.Copy(category.Picture, OleHeaderLength, _
            strippedImageData, 0, strippedImageLength)
        Response.BinaryWrite(strippedImageData)
    Else
        ' For new categories, images are JPGs...
        ' Output HTTP headers providing information about the binary data
        Response.ContentType = "image/jpeg"
        ' Output the binary data
        Response.BinaryWrite(category.Picture)
    End If
End Sub