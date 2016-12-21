private async Task SignInAsync(ApplicationUser user, bool isPersistent)
{
    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
    AuthenticationManager.SignIn(new AuthenticationProperties(){
       IsPersistent = isPersistent }, 
       await user.GenerateUserIdentityAsync(UserManager));
}