// GET: /Account/ConfirmEmail
[AllowAnonymous]
public async Task<ActionResult> ConfirmEmail(string userId, string code)
{
   if (userId == null || code == null)
   {
      return View("Error");
   }
   IdentityResult result;
   try
   {
      result = await UserManager.ConfirmEmailAsync(userId, code);
   }
   catch (InvalidOperationException ioe)
   {
      // ConfirmEmailAsync throws when the userId is not found.
      ViewBag.errorMessage = ioe.Message;
      return View("Error");
   }

   if (result.Succeeded)
   {
      return View();
   }

   // If we got this far, something failed.
   AddErrors(result);
   ViewBag.errorMessage = "ConfirmEmail failed";
   return View("Error");
}