Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim categoryID As Integer = _
        Convert.ToInt32(Request.QueryString("CategoryID"))
    ' Get information about the specified category
    Dim categoryAPI As New CategoriesBLL()
    Dim categories As Northwind.CategoriesDataTable = _
        categoryAPI.GetCategoryWithBinaryDataByCategoryID(categoryID)
    Dim category As Northwind.CategoriesRow = categories(0)
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
End Sub