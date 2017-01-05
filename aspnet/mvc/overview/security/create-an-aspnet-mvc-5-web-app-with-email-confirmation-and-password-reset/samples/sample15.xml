//
// POST: /Account/Register
[HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Register(RegisterViewModel model)
{
   if (ModelState.IsValid)
   {
      var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
      var result = await UserManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
         //  Comment the following line to prevent log in until the user is confirmed.
         //  await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

         string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account");

         ViewBag.Message = "Check your email and confirm your account, you must be confirmed "
                         + "before you can log in.";

         return View("Info");
         //return RedirectToAction("Index", "Home");
      }
      AddErrors(result);
   }

   // If we got this far, something failed, redisplay form
   return View(model);
}