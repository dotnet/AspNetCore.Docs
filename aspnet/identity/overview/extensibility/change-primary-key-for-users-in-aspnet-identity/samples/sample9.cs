public async Task<ActionResult> ConfirmEmail(int userId, string code) 
{ 
    if (userId == default(int) || code == null)  
    { 
        return View("Error"); 
    } 

    IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code); 
    if (result.Succeeded) 
    { 
        return View("ConfirmEmail"); 
    } 
    else 
    { 
        AddErrors(result); 
        return View(); 
    } 
}