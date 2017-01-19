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
            appId: "111111111111111",
            appSecret: "a1a1aa111111111a111a111aaa111111");

        //OAuthWebSecurity.RegisterGoogleClient();
    }
}