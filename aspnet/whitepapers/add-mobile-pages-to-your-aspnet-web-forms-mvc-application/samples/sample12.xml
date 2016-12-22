public ActionResult LogOn()
{
    string returnUrl = Request.QueryString["ReturnUrl"];
    if ((returnUrl != null) && returnUrl.StartsWith("/Mobile/", 
                               StringComparison.OrdinalIgnoreCase)) 
    {
        return RedirectToAction("LogOn", "Account", 
                                new { Area = "Mobile", ReturnUrl = returnUrl });
    }
    return View();
}