[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult LogOff()
{
    WebSecurity.Logout();
    if (Session["facebooktoken"] != null)
    {
        var fb = new Facebook.FacebookClient();
        string accessToken = Session["facebooktoken"] as string;
        var logoutUrl = fb.GetLogoutUrl(new { access_token = accessToken, next = "http://localhost:39852/" });

        Session.RemoveAll();
        return Redirect(logoutUrl.AbsoluteUri);
    }

    return RedirectToAction("Index", "Home");
}