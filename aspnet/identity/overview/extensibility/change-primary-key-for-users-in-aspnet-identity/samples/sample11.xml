public async Task<ActionResult> Manage(ManageUserViewModel model) 
{ 
    bool hasPassword = HasPassword(); 
    ViewBag.HasLocalPassword = hasPassword; 
    ViewBag.ReturnUrl = Url.Action("Manage"); 
    if (hasPassword) 
    { 
        if (ModelState.IsValid) 
        { 
            IdentityResult result = await UserManager.ChangePasswordAsync(
                User.Identity.GetUserId<int>(),
                model.OldPassword, 
                model.NewPassword); 
            if (result.Succeeded) 
            { 
                var user = await UserManager.FindByIdAsync(
                  User.Identity.GetUserId<int>()); 
                await SignInAsync(user, isPersistent: false); 
                return RedirectToAction("Manage", new { 
                    Message = ManageMessageId.ChangePasswordSuccess }); 
            } 
            else 
            { 
                AddErrors(result); 
            } 
        } 
    } 
    else 
    { 
        // User does not have a password so remove any validation errors caused 
        // by a missing OldPassword field 
        ModelState state = ModelState["OldPassword"]; 
        if (state != null) 
        { 
            state.Errors.Clear(); 
        } 

        if (ModelState.IsValid) 
        { 
            IdentityResult result = await UserManager.AddPasswordAsync(
                User.Identity.GetUserId<int>(), model.NewPassword); 
            if (result.Succeeded) 
            { 
                return RedirectToAction("Manage", new { 
                    Message = ManageMessageId.SetPasswordSuccess }); 
            } 
            else 
            { 
                AddErrors(result); 
            } 
        } 
    } 

    // If we got this far, something failed, redisplay form 
    return View(model); 
}