return View("ExternalLoginConfirmation", new RegisterExternalLoginModel 
{ 
    UserName = result.UserName, 
    ExternalLoginData = loginData 
});