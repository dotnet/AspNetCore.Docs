if (user == null)
{
    // Insert name into the profile table
    UserProfile newUser = db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
    db.SaveChanges();

    db.ExternalUsers.Add(new ExternalUserInformation 
    { 
        UserId = newUser.UserId, 
        FullName = model.FullName, 
        Link = model.Link 
    });
    db.SaveChanges();

    OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
    OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

    return RedirectToLocal(returnUrl);
}
else
{
    ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
}