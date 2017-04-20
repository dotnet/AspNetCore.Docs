[HttpPost] 
public ActionResult LogOn(LogOnModel model, string returnUrl) 
{ 
    if (ModelState.IsValid) 
    { 
        if (MembershipService.ValidateUser(model.UserName, model.Password)) 
        { 
            FormsService.SignIn(model.UserName, model.RememberMe); 
            if (IsLocalUrl(returnUrl)) 
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
            ModelState.AddModelError("", 
		    "The user name or password provided is incorrect."); 
        } 
    }
}