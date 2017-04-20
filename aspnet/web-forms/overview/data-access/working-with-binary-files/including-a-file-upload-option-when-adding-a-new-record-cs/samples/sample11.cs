protected void NewCategory_ItemInserting(object sender, DetailsViewInsertEventArgs e)
{
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
    // Set the value of the picture parameter
    e.Values["picture"] = PictureUpload.FileBytes;
    
    
    // Reference the FileUpload controls
    FileUpload BrochureUpload = 
        (FileUpload)NewCategory.FindControl("BrochureUpload");
    if (BrochureUpload.HasFile)
    {
        // Make sure that a PDF has been uploaded
        if (string.Compare(System.IO.Path.GetExtension(BrochureUpload.FileName), 
            ".pdf", true) != 0)
        {
            UploadWarning.Text = 
                "Only PDF documents may be used for a category's brochure.";
            UploadWarning.Visible = true;
            e.Cancel = true;
            return;
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
        e.Values["brochurePath"] = brochurePath;
    }
}