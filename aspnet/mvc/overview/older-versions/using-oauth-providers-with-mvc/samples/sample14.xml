if (user == null)
{
    // Insert name into the profile table
    UserProfile newUser = db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
    db.SaveChanges();

    bool facebookVerified;

    var client = new Facebook.FacebookClient(Session["facebooktoken"].ToString());
    dynamic response = client.Get("me", new { fields = "verified" });
    if (response.ContainsKey("verified"))
    {
        facebookVerified = response["verified"];
    }
    else
    {
        facebookVerified = false;
    }

    db.ExternalUsers.Add(new ExternalUserInformation 
    { 
        UserId = newUser.UserId, 
        FullName = model.FullName, 
        Link = model.Link, 
        Verified = facebookVerified 
    });
    db.SaveChanges();

    OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
    OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

    return RedirectToLocal(returnUrl);
}