@using Microsoft.Web.Helpers;
@{
  var message = "";
  if (IsPost) {
      var fileName = "";
      var fileSavePath = "";
      int numFiles = Request.Files.Count;
      int uploadedCount = 0;
      for(int i =0; i < numFiles; i++) {
          var uploadedFile = Request.Files[i];
          if (uploadedFile.ContentLength > 0) {
              fileName = Path.GetFileName(uploadedFile.FileName);
              fileSavePath = Server.MapPath("~/App_Data/UploadedFiles/" +
                fileName);
              uploadedFile.SaveAs(fileSavePath);
              uploadedCount++;
          }
       }
       message = "File upload complete. Total files uploaded: " +
         uploadedCount.ToString();
   }
}
<!DOCTYPE html>
<html>
    <head><title>FileUpload - Multiple File Example</title></head>
<body>
    <form id="myForm" method="post"
       enctype="multipart/form-data"
       action="">
    <div>
    <h1>File Upload - Multiple-File Example</h1>
    @if (!IsPost) {
        @FileUpload.GetHtml(
            initialNumberOfFiles:2,
            allowMoreFilesToBeAdded:true,
            includeFormTag:true,
            addText:"Add another file",
            uploadText:"Upload")
        }
    <span>@message</span>
    </div>
    </form>
</body>
</html>