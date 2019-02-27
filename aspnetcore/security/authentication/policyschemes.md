# Policy schemes

Authentication policy schemes were introduced to make it easier to have a single logical authentication scheme potentially use multiple approaches. For example, a policy scheme might use Google for challenges, and Cookie for everything else. Authentication policy schemes make it:
* Easy to forward any authentication action to another scheme.
* Forward dynamically based on the request.

All authentication schemes that use derived <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions?displayProperty=fullName> and the associated <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>:

* Are automatically policy schemes in ASP.NET Core 2.1 and later.
* The authentication policy schemes can be enabled via configuring the scheme's options.

```C#
    public class AuthenticationSchemeOptions
    {
        /// <summary>
        /// If set, this specifies a default scheme that authentication handlers should forward all authentication operations to
        /// by default. The default forwarding logic will check the most specific ForwardAuthenticate/Challenge/Forbid/SignIn/SignOut 
        /// setting first, followed by checking the ForwardDefaultSelector, followed by ForwardDefault. The first non null result
        /// will be used as the target scheme to forward to.
        /// </summary>
        public string ForwardDefault { get; set; }

        /// <summary>
        /// If set, this specifies the target scheme that this scheme should forward AuthenticateAsync calls to.
        /// For example Context.AuthenticateAsync("ThisScheme") => Context.AuthenticateAsync("ForwardAuthenticateValue");
        /// Set the target to the current scheme to disable forwarding and allow normal processing.
        /// </summary>
        public string ForwardAuthenticate { get; set; }

        /// <summary>
        /// If set, this specifies the target scheme that this scheme should forward ChallengeAsync calls to.
        /// For example Context.ChallengeAsync("ThisScheme") => Context.ChallengeAsync("ForwardChallengeValue");
        /// Set the target to the current scheme to disable forwarding and allow normal processing.
        /// </summary>
        public string ForwardChallenge { get; set; }

        /// <summary>
        /// If set, this specifies the target scheme that this scheme should forward ForbidAsync calls to.
        /// For example Context.ForbidAsync("ThisScheme") => Context.ForbidAsync("ForwardForbidValue");
        /// Set the target to the current scheme to disable forwarding and allow normal processing.
        /// </summary>
        public string ForwardForbid { get; set; }

        /// <summary>
        /// If set, this specifies the target scheme that this scheme should forward SignInAsync calls to.
        /// For example Context.SignInAsync("ThisScheme") => Context.SignInAsync("ForwardSignInValue");
        /// Set the target to the current scheme to disable forwarding and allow normal processing.
        /// </summary>
        public string ForwardSignIn { get; set; }

        /// <summary>
        /// If set, this specifies the target scheme that this scheme should forward SignOutAsync calls to.
        /// For example Context.SignOutAsync("ThisScheme") => Context.SignInAsync("ForwardSignOutValue");
        /// Set the target to the current scheme to disable forwarding and allow normal processing.
        /// </summary>
        public string ForwardSignOut { get; set; }

        /// <summary>
        /// Used to select a default scheme for the current request that authentication handlers should forward all authentication operations to
        /// by default. The default forwarding logic will check the most specific ForwardAuthenticate/Challenge/Forbid/SignIn/SignOut 
        /// setting first, followed by checking the ForwardDefaultSelector, followed by ForwardDefault. The first non null result
        /// will be used as the target scheme to forward to.
        /// </summary>
        public Func<HttpContext, string> ForwardDefaultSelector { get; set; }
    }
```



## Examples
* A higher level scheme that combines lower level schemes, where Google is used for challenges, and Cookie is used for everything else.

```C#
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.ForwardChallenge = "Google")
                .AddGoogle(options => { });
        }
```

* Enables dynamic selection of schemes on a per request basis (i.e. how to mix cookies and api authentication)

```C#
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    // For example, can foward any requests that start with /api to the api scheme
                    options.ForwardDefaultSelector = ctx => ctx.Request.Path.StartsWithSegments("/api") ? "Api" : null;
                })
                .AddYourApiAuth("Api");
        }
```
