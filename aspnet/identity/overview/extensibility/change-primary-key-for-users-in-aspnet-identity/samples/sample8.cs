app.UseCookieAuthentication(new CookieAuthenticationOptions 
    { 
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, 
        LoginPath = new PathString("/Account/Login"), 
        Provider = new CookieAuthenticationProvider 
        { 
            OnValidateIdentity = SecurityStampValidator
                .OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>( 
                    validateInterval: TimeSpan.FromMinutes(30), 
                    regenerateIdentityCallback: (manager, user) => 
                        user.GenerateUserIdentityAsync(manager), 
                    getUserIdCallback:(id)=>(id.GetUserId<int>()))
        } 
    });