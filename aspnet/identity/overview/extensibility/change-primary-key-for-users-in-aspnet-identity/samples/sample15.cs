public async Task<ActionResult> ConfirmEmail(int userId, string code) 
{ 
    if (userId == default(int) || code == null)  
    { 
        return View("Error"); 
    } 

    IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code); 
    return View(result.Succeeded ? "ConfirmEmail" : "Error");
}