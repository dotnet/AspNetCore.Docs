//
// POST: /Account/Register
[HttpPost]
 public ActionResult Register(RegisterModel model)
 {
    if (ModelState.IsValid)
    {
        // Attempt to register the user
        MembershipCreateStatus createStatus;
        Membership.CreateUser(model.UserName, model.Password, model.Email, 
               "question", "answer", true, null, out
               createStatus);
 
        if (createStatus == MembershipCreateStatus.Success)
        {
            MigrateShoppingCart(model.UserName);
                    
            FormsAuthentication.SetAuthCookie(model.UserName, false /*
                  createPersistentCookie */);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", ErrorCodeToString(createStatus));
        }
    }
    // If we got this far, something failed, redisplay form
    return View(model);
 }