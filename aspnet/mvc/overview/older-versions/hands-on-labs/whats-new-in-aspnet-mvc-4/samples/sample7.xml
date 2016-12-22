public ActionResult Index()
{
    var client = new HttpClient();
    var response = client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme)).Result;
    var value = response.Content.ReadAsStringAsync().Result;

    var result = JsonConvert.DeserializeObject<List<Photo>>(value);

    return View(result);
}