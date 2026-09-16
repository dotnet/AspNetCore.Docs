### Experimental Device Bound Session Credentials support

> [!IMPORTANT]
> The `Microsoft.AspNetCore.Authentication.DeviceBoundSessions` package is experimental and remains prerelease throughout .NET 11 and until the specification stabilizes.

The [Device Bound Session Credentials (DBSC) specification](https://w3c.github.io/webappsec-dbsc/) defines a protocol that binds session refresh to a private key held by the browser. The app issues a short-lived session cookie, and the browser must provide a signed proof of possession to refresh it. A copied session cookie might remain usable until it expires, but an attacker without the device key can't use it to extend the session.

ASP.NET Core adds an experimental server-side DBSC implementation in the `Microsoft.AspNetCore.Authentication.DeviceBoundSessions` package. The authentication component layers over an existing cookie authentication scheme and manages the registration and refresh endpoints, a path-scoped refresh cookie, and the short-lived session cookie.

After adding the `Microsoft.AspNetCore.Authentication.DeviceBoundSessions` package, configure DBSC over an existing cookie authentication scheme:

```csharp
builder.Services
    .AddAuthentication("Application")
    .AddCookie("Application")
    .AddDeviceBoundSession("Application", options =>
    {
        options.ShortLivedCookieExpiration = TimeSpan.FromMinutes(10);
    });
```

Browser support currently requires an experimental DBSC implementation. For more information, see [Chrome's DBSC documentation](https://developer.chrome.com/docs/web-platform/device-bound-session-credentials).
