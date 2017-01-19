public static class AuthConfig
{
    public static void RegisterAuth()
    {
        //OAuthWebSecurity.RegisterMicrosoftClient(
        //    clientId: "",
        //    clientSecret: "");

        //OAuthWebSecurity.RegisterTwitterClient(
        //    consumerKey: "",
        //    consumerSecret: "");

        OAuthWebSecurity.RegisterFacebookClient(
            appId: "",
            appSecret: "");

        //OAuthWebSecurity.RegisterGoogleClient();        
    }
}