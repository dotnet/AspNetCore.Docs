[HttpPost]
[ActionName("Simple")]
public HttpResponseMessage PostSimple([FromBody] string value)
{
    if (value != null)
    {
        Update update = new Update()
        {
            Status = HttpUtility.HtmlEncode(value),
            Date = DateTime.UtcNow
        };

        var id = Guid.NewGuid();
        updates[id] = update;

        var response = new HttpResponseMessage(HttpStatusCode.Created)
        {
            Content = new StringContent(update.Status)
        };
        response.Headers.Location = 
            new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
        return response;
    }
    else
    {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
    }