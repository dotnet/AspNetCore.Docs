// Reference the PictureUpload FileUpload
FileUpload PictureUpload = 
    (FileUpload)Categories.Rows[e.RowIndex].FindControl("PictureUpload");
if (PictureUpload.HasFile)
{
    // Make sure the picture upload is valid
    if (ValidPictureUpload(PictureUpload))
    {
        e.NewValues["picture"] = PictureUpload.FileBytes;
    }
    else
    {
        // Invalid file upload, cancel update and exit event handler
        e.Cancel = true;
        return;
    }
}