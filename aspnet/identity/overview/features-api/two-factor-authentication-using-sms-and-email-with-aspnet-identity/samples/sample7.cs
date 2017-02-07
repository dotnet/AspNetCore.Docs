private async Task SignInAsync(ApplicationUser user, bool isPersistent)
{
   // Clear the temporary cookies used for external and two factor sign ins
    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, 
       DefaultAuthenticationTypes.TwoFactorCookie);
    AuthenticationManager.SignIn(new AuthenticationProperties
    {
       IsPersistent = isPersistent 
    }, 
       await user.GenerateUserIdentityAsync(UserManager));
}