public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
    UserManager<ApplicationUser, int> manager) 
{ 
    // Note the authenticationType must match the one defined in
    // CookieAuthenticationOptions.AuthenticationType 
    var userIdentity = await manager.CreateIdentityAsync(
        this, DefaultAuthenticationTypes.ApplicationCookie); 
    // Add custom user claims here 
    return userIdentity; 
}