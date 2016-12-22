public ActionResult Admin()
{
    string apiUri= Url.HttpRouteUrl("DefaultApi", new { controller = "admin", });
    ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

    return View();
}