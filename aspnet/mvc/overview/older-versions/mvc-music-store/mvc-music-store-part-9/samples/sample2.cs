//
// POST: /Account/LogOn
[HttpPost]
 public ActionResult LogOn(LogOnModel model, string returnUrl)
 {
    if (ModelState.IsValid)
    {
        if (Membership.ValidateUser(model.UserName, model.Password))
        {
            MigrateShoppingCart(model.UserName);
                    
            FormsAuthentication.SetAuthCookie(model.UserName,
                model.RememberMe);
            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1
                && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") &&
                !returnUrl.StartsWith("/\\"))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
        }
    }
    // If we got this far, something failed, redisplay form
    return View(model);
 }