public Task<HttpResponseMessage> PostFormData()
{
    // Check if the request contains multipart/form-data.
    if (!Request.Content.IsMimeMultipartContent())
    {
        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
    }

    string root = HttpContext.Current.Server.MapPath("~/App_Data");
    var provider = new MultipartFormDataStreamProvider(root);

    // Read the form data and return an async task.
    var task = Request.Content.ReadAsMultipartAsync(provider).
        ContinueWith<HttpResponseMessage>(t =>
        {
            if (t.IsFaulted || t.IsCanceled)
            {
                Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
            }

            // This illustrates how to get the file names.
            foreach (MultipartFileData file in provider.FileData)
            {
                Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                Trace.WriteLine("Server file path: " + file.LocalFileName);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        });

    return task;
}