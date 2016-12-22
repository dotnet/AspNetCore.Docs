var resp = new HttpResponseMessage();

var nv = new NameValueCollection();
nv["sid"] = "12345";
nv["token"] = "abcdef";
nv["theme"] = "dark blue";
var cookie = new CookieHeaderValue("session", nv); 

resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });