public void ConfigureAuth(IAppBuilder app)
 {
    // Code removed for clarity     

     // Refresh token provider which creates and receives refresh token.
     RefreshTokenProvider = new AuthenticationTokenProvider
     {
         OnCreate = CreateRefreshToken,
         OnReceive = ReceiveRefreshToken,
     }
 });
}