// Reference the FileUpload control
FileUpload BrochureUpload = 
    (FileUpload)NewCategory.FindControl("BrochureUpload");
if (BrochureUpload.HasFile)
{
    // Make sure that a PDF has been uploaded
    if (string.Compare(System.IO.Path.GetExtension
        (BrochureUpload.FileName), ".pdf", true) != 0)
    {
        UploadWarning.Text = 
            "Only PDF documents may be used for a category's brochure.";
        UploadWarning.Visible = true;
        e.Cancel = true;
        return;
    }
}