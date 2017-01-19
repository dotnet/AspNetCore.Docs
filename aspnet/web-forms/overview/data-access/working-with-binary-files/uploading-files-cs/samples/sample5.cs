protected void UploadButton_Click(object sender, EventArgs e)
{
    if (UploadTest.HasFile == false)
    {
        // No file uploaded!
        UploadDetails.Text = "Please first select a file to upload...";            
    }
    else
    {
        // Display the uploaded file's details
        UploadDetails.Text = string.Format(
                @"Uploaded file: {0}<br />
                  File size (in bytes): {1:N0}<br />
                  Content-type: {2}", 
                  UploadTest.FileName, 
                  UploadTest.FileBytes.Length,
                  UploadTest.PostedFile.ContentType);
        // Save the file
        string filePath = 
            Server.MapPath("~/Brochures/" + UploadTest.FileName);
        UploadTest.SaveAs(filePath);
    }
}