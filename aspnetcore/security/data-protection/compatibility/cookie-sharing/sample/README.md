# Cookie Sharing Sample App

The sample illustrates cookie sharing across three apps that use cookie authentication:

| Project                             | Description |
| ----------------------------------- | ----------- |
| CookieAuth.Core                     | ASP.NET Core 2.0 Razor Pages app without using ASP.NET Core Identity |
| CookieAuthWithIdentity.Core         | ASP.NET Core 2.0 MVC app with ASP.NET Core Identity |
| CookieAuthWithIdentity.NETFramework | ASP.NET Framework 4.6.1 MVC app with ASP.NET Identity |

Instructions:

1. Run the CookieAuth.Core app. Register a user. The app authenticates the user when the user is registered. Sign the user out.
1. In the same browser session, run the CookieAuthWithIdentity.Core app. Register the same user as used with the Core app. The app authenticates the user when the user is registered. Sign the user out.
1. In the same browser session, run the CookieAuthWithIdentity.NETFramework app. Register the same user as used with the other apps. The app authenticates the user when the user is registered. Sign the user out.
1. Sign in the user to any of the three apps. The authentication cookie is shared among the apps. Note that the user is automatically signed into the other two apps.
1. Sign out the user from any of the apps. Note that the user is automatically signed out of the other two apps.

This sample demonstrates the features described in the [Sharing cookies among apps](https://docs.microsoft.com/aspnet/core/security/data-protection/compatibility/cookie-sharing) topic.
