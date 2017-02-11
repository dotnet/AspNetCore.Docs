// Uncomment the following lines to enable logging in with third party login providers
//app.UseMicrosoftAccountAuthentication(
//    clientId: "",
//    clientSecret: "");

app.UseTwitterAuthentication(
   consumerKey: "426f62526f636b73",
   consumerSecret: "57686f6120447564652c2049495320526f636b73");

//app.UseFacebookAuthentication(
//   appId: "",
//   appSecret: "");

//app.UseGoogleAuthentication();