string sessionId = "";
string sessionToken = "";
string theme = "";

CookieHeaderValue cookie = Request.Headers.GetCookies("session").FirstOrDefault();
if (cookie != null)
{
    CookieState cookieState = cookie["session"];

    sessionId = cookieState["sid"];
    sessionToken = cookieState["token"];
    theme = cookieState["theme"];
}