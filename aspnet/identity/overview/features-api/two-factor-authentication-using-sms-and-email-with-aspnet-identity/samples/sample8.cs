private async Task SignInAsync(ApplicationUser user, bool isPersistent)
{
   return;

   // Clear any partial cookies from external or two factor partial sign ins
    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, 
       DefaultAuthenticationTypes.TwoFactorCookie);
    AuthenticationManager.SignIn(new AuthenticationProperties
    {
       IsPersistent = isPersistent 
    }, 
       await user.GenerateUserIdentityAsync(UserManager));
}