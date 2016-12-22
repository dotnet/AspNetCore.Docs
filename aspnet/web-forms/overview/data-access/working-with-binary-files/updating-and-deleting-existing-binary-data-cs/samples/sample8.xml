private string ProcessBrochureUpload
    (FileUpload BrochureUpload, out bool CancelOperation)
{
    CancelOperation = false;    // by default, do not cancel operation
    if (BrochureUpload.HasFile)
    {
        // Make sure that a PDF has been uploaded
        if (string.Compare(System.IO.Path.GetExtension(BrochureUpload.FileName), 
            ".pdf", true) != 0)
        {
            UploadWarning.Text = 
                "Only PDF documents may be used for a category's brochure.";
            UploadWarning.Visible = true;
            CancelOperation = true;
            return null;
        }
        const string BrochureDirectory = "~/Brochures/";
        string brochurePath = BrochureDirectory + BrochureUpload.FileName;
        string fileNameWithoutExtension = 
            System.IO.Path.GetFileNameWithoutExtension(BrochureUpload.FileName);
        int iteration = 1;
        while (System.IO.File.Exists(Server.MapPath(brochurePath)))
        {
            brochurePath = string.Concat(BrochureDirectory, fileNameWithoutExtension, 
                "-", iteration, ".pdf");
            iteration++;
        }
        // Save the file to disk and set the value of the brochurePath parameter
        BrochureUpload.SaveAs(Server.MapPath(brochurePath));
        return brochurePath;
    }
    else
    {
        // No file uploaded
        return null;
    }
}
private void DeleteRememberedBrochurePath()
{
    // Is there a file to delete?
    if (deletedCategorysPdfPath != null)
    {
        System.IO.File.Delete(Server.MapPath(deletedCategorysPdfPath));
    }
}