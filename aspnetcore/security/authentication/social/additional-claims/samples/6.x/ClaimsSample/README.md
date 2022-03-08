# Additional Claims Sample App

The sample app demonstrates how to:

* Obtain the user's given name and surname from Google and store the name claims with the values provided by Google.
* Store the Google access token in the user's `AuthenticationProperties`.

To use the sample app:

1. Register the app and obtain a valid client ID and client secret for Google authentication. For more information, see [Google external login setup](https://docs.microsoft.com/aspnet/core/security/authentication/social/google-logins).
1. Provide the client ID and client secret to the app in the [GoogleOptions](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.google.googleoptions) of `Startup.ConfigureServices`.
1. Run the app and request the My Claims page. When the user isn't signed in, the app redirects to Google. Sign in with Google. Google redirects the user back to the app (`/MyClaims`). The user is authenticated, and the My Claims page is loaded. The given name and surname claims are present under **User Claims** with the values provided by Google. The access token is displayed under **Authentication Properties**.
