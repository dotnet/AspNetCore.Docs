public async Task<HttpResponseMessage> PostFormData()
{
    if (!Request.Content.IsMimeMultipartContent())
    {
        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
    }

    string root = HttpContext.Current.Server.MapPath("~/App_Data");
    var provider = new MultipartFormDataStreamProvider(root);

    try
    {
        await Request.Content.ReadAsMultipartAsync(provider);

        // Show all the key-value pairs.
        foreach (var key in provider.FormData.AllKeys)
        {
            foreach (var val in provider.FormData.GetValues(key))
            {
                Trace.WriteLine(string.Format("{0}: {1}", key, val));
            }
        }

        return Request.CreateResponse(HttpStatusCode.OK);
    }
    catch (System.Exception e)
    {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
    }
}