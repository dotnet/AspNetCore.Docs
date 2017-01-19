// Reference the FileUpload controls
FileUpload PictureUpload = (FileUpload)NewCategory.FindControl("PictureUpload");
if (PictureUpload.HasFile)
{
    // Make sure that a JPG has been uploaded
    if (string.Compare(System.IO.Path.GetExtension(PictureUpload.FileName), 
            ".jpg", true) != 0 &&
        string.Compare(System.IO.Path.GetExtension(PictureUpload.FileName), 
            ".jpeg", true) != 0)
    {
        UploadWarning.Text = 
            "Only JPG documents may be used for a category's picture.";
        UploadWarning.Visible = true;
        e.Cancel = true;
        return;
    }
}
else
{
    // No picture uploaded!
    UploadWarning.Text = 
        "You must provide a picture for the new category.";
    UploadWarning.Visible = true;
    e.Cancel = true;
    return;
}