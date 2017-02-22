public void ConfigureAuth(IAppBuilder app)
 {
     // Enable the Application Sign In Cookie.
     app.UseCookieAuthentication(new CookieAuthenticationOptions
     {
         AuthenticationType = "Application",
         AuthenticationMode = AuthenticationMode.Passive,
         LoginPath = new PathString(Paths.LoginPath),
         LogoutPath = new PathString(Paths.LogoutPath),
     });

     // Enable the External Sign In Cookie.
     app.SetDefaultSignInAsAuthenticationType("External");
     app.UseCookieAuthentication(new CookieAuthenticationOptions
     {
         AuthenticationType = "External",
         AuthenticationMode = AuthenticationMode.Passive,
         CookieName = CookieAuthenticationDefaults.CookiePrefix + "External",
         ExpireTimeSpan = TimeSpan.FromMinutes(5),
     });

     // Enable Google authentication.
     app.UseGoogleAuthentication();

     // Setup Authorization Server
     app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
     {
         AuthorizeEndpointPath = new PathString(Paths.AuthorizePath),
         TokenEndpointPath = new PathString(Paths.TokenPath),
         ApplicationCanDisplayErrors = true,
#if DEBUG
                AllowInsecureHttp = true,
#endif
     // Authorization server provider which controls the lifecycle of Authorization Server
     Provider = new OAuthAuthorizationServerProvider
     {
         OnValidateClientRedirectUri = ValidateClientRedirectUri,
         OnValidateClientAuthentication = ValidateClientAuthentication,
         OnGrantResourceOwnerCredentials = GrantResourceOwnerCredentials,
         OnGrantClientCredentials = GrantClientCredetails
     },

     // Authorization code provider which creates and receives the authorization code.
     AuthorizationCodeProvider = new AuthenticationTokenProvider
     {
         OnCreate = CreateAuthenticationCode,
         OnReceive = ReceiveAuthenticationCode,
     },

     // Refresh token provider which creates and receives refresh token.
     RefreshTokenProvider = new AuthenticationTokenProvider
     {
         OnCreate = CreateRefreshToken,
         OnReceive = ReceiveRefreshToken,
     }
 });
}