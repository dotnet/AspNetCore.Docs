public async Task<ActionResult> Index()
{
    var client = new HttpClient();
    var response = await client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme));
    ...