string sessionId = "";

CookieHeaderValue cookie = Request.Headers.GetCookies("session-id").FirstOrDefault();
if (cookie != null)
{
    sessionId = cookie["session-id"].Value;
}