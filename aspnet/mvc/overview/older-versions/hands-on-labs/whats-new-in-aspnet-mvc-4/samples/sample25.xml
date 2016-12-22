public async Task<ActionResult> Index(CancellationToken cancellationToken)
{
    var client = new HttpClient();
    var response = await client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme), cancellationToken);
    var value = await response.Content.ReadAsStringAsync();
    var result = await JsonConvert.DeserializeObjectAsync<List<Photo>>(value);

    return View(result);
}