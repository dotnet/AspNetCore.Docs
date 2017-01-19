public async Task<ActionResult> Disassociate(string loginProvider, string providerKey) 
{ 
    ManageMessageId? message = null; 
    IdentityResult result = await UserManager.RemoveLoginAsync(
        User.Identity.GetUserId<int>(), 
        new UserLoginInfo(loginProvider, providerKey)); 
    if (result.Succeeded) 
    { 
        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>()); 
        await SignInAsync(user, isPersistent: false); 
        message = ManageMessageId.RemoveLoginSuccess; 
    } 
    else 
    { 
        message = ManageMessageId.Error; 
    } 
    return RedirectToAction("Manage", new { Message = message }); 
}