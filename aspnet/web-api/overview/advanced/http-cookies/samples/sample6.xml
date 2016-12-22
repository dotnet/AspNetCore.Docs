public HttpResponseMessage Get()
{
    var resp = new HttpResponseMessage();

    var cookie = new CookieHeaderValue("session-id", "12345");
    cookie.Expires = DateTimeOffset.Now.AddDays(1);
    cookie.Domain = Request.RequestUri.Host;
    cookie.Path = "/";

    resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
    return resp;
}