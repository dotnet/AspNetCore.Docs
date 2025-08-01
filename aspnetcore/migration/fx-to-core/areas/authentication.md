---
title: ASP.NET Framework to Core Authentication Migration
description: ASP.NET Framework to Core Authentication Migration
author: wadepickett
ms.author: wpickett
monikerRange: '>= aspnetcore-6.0'
ms.date: 07/17/2025
ms.topic: article
uid: migration/fx-to-core/areas/authentication
zone_pivot_groups: migration-remote-app-setup
---

# Migrate ASP.NET Framework Authentication to ASP.NET Core

Authentication is a critical component of web applications, handling user identity verification across HTTP requests. When migrating from ASP.NET Framework to ASP.NET Core, authentication presents unique challenges because the two frameworks handle authentication very differently.

For general information about authentication in ASP.NET Core, see <xref:security/authentication/index>. For information about authorization, see <xref:security/authorization/introduction>.

## Why authentication migration is complex

ASP.NET Framework and ASP.NET Core have fundamentally different approaches to authentication:

* **ASP.NET Framework** provides built-in authentication modules with automatic configuration and tight integration with System.Web
* **ASP.NET Core** uses a middleware-based approach with explicit configuration and dependency injection

These differences mean you can't simply move your authentication code from Framework to Core without changes.

## Authentication types and migration challenges

Different authentication types present varying levels of migration complexity:

### Cookie-based authentication

* **ASP.NET Framework**: Uses `Microsoft.Owin` cookie authentication middleware
* **ASP.NET Core**: Uses `CookieAuthentication` middleware with different configuration
* **Migration challenge**: Cookie format, encryption keys, and configuration differences

### JWT Bearer tokens

* **ASP.NET Framework**: Often handled through custom modules or OWIN middleware
* **ASP.NET Core**: Native support through `Microsoft.AspNetCore.Authentication.JwtBearer`
* **Migration challenge**: Token validation parameter differences and middleware registration

### Windows authentication

* **ASP.NET Framework**: Built-in IIS integration
* **ASP.NET Core**: Requires explicit configuration and may need hosting model changes
* **Migration challenge**: Server configuration and authentication flow differences

### Forms authentication

* **ASP.NET Framework**: Built-in `System.Web.Security.FormsAuthentication`
* **ASP.NET Core**: No direct equivalent, requires migration to cookie authentication
* **Migration challenge**: Complete authentication system rewrite needed

### Custom authentication

* **ASP.NET Framework**: Custom modules implementing `IHttpModule`
* **ASP.NET Core**: Custom middleware or authentication handlers
* **Migration challenge**: Complete architecture change from modules to middleware

## Migration strategies overview

You have three main approaches for handling authentication during migration:

1. **Complete rewrite** - Rewrite all authentication code to use ASP.NET Core's native authentication
2. **Remote authentication** - Use System.Web adapters to delegate authentication to the ASP.NET Framework app
3. **Shared cookie authentication** - Share authentication cookies between Framework and Core applications (for OWIN-based scenarios)

For most applications, migrating to native ASP.NET Core authentication provides the best performance and maintainability. However, larger applications or those with complex authentication requirements may benefit from an incremental approach using the System.Web adapters.

## Choose your migration approach

You have three main options for migrating authentication from ASP.NET Framework to ASP.NET Core. Your choice depends on your authentication type, migration timeline, whether you need to run both applications simultaneously, and how much code you're willing to rewrite.

### Quick decision guide

**Answer these questions to choose your approach:**

1. **Are you doing a complete rewrite or incremental migration?**
   * Complete rewrite → [Complete rewrite to ASP.NET Core authentication](#complete-rewrite-to-aspnet-core-authentication)
   * Incremental migration → Continue to question 2

2. **What type of authentication does your ASP.NET Framework app use?**
   * OWIN cookie authentication → Continue to question 3
   * Forms authentication, JWT Bearer tokens, Windows auth, or Custom authentication → [Remote authentication](#remote-authentication)

3. **Do both your ASP.NET Framework and ASP.NET Core apps need to access the same authentication state?**
   * Yes, shared authentication needed → Continue to question 4
   * No, separate authentication is fine → [Complete rewrite to ASP.NET Core authentication](#complete-rewrite-to-aspnet-core-authentication)

4. **Can you configure matching data protection settings between both apps?**
   * Yes → [Shared cookie authentication](#shared-cookie-authentication) (see Alternatives section, best performance)
   * No or unsure → [Remote authentication](#remote-authentication)

### Migration approaches comparison

| Approach | Code Changes | Performance | Auth Sharing | When to Use |
|----------|-------------|-------------|--------------|-------------|
| **[Complete rewrite](#complete-rewrite-to-aspnet-core-authentication)** | High - Rewrite all auth code | Best | None | Complete rewrites, performance-critical apps, non-OWIN auth |
| **[Remote authentication](#remote-authentication)** | Low - Keep existing patterns | Fair | Full | Incremental migrations, complex auth, Windows auth |
| **[Shared cookies](#shared-cookie-authentication)** | Medium - Update configuration | Good | Full | OWIN cookie auth, performance-critical shared auth (see Alternatives) |

## Complete rewrite to ASP.NET Core authentication

Choose this approach when you're performing a complete migration, have non-OWIN authentication, or want the best performance and maintainability.

ASP.NET Core provides comprehensive authentication support with high performance and extensive customization options. This approach requires rewriting authentication code but offers the most benefits in the long term.

### Complete rewrite pros and cons

| Pros | Cons |
|------|------|
| Best performance and security | Requires rewriting all authentication code |
| Native ASP.NET Core implementation | No automatic migration path |
| Full control over authentication flow | Learning curve for new authentication patterns |
| No additional dependencies | Breaking change from Framework patterns |
| Access to latest ASP.NET Core auth features | Potential downtime during migration |

### Migration considerations

When migrating to native ASP.NET Core authentication:

**Choose based on your Framework authentication type:**
* **Forms authentication** → Migrate to [Cookie authentication](xref:security/authentication/cookie)
* **JWT Bearer tokens** → Migrate to [JWT Bearer authentication](xref:security/authentication/configure-jwt-bearer-authentication)
* **Windows authentication** → Use [Windows authentication](xref:security/authentication/windowsauth)
* **OWIN OAuth providers** → Use corresponding ASP.NET Core OAuth providers
* **Custom authentication** → Implement [custom authentication handlers](xref:security/authentication/index#authentication-handler)

**Code changes required:**
* Replace `HttpContext.User` access patterns (mostly compatible)
* Update authentication middleware registration in `Program.cs`
* Migrate custom authentication logic to ASP.NET Core patterns
* Update authorization attributes and policies

**When to choose this approach:**
* You can afford to rewrite authentication-related code
* Performance is a top priority
* You're not sharing authentication state with legacy applications
* You want to eliminate System.Web dependencies completely
* Your Framework app uses Forms authentication, custom modules, or JWT tokens

## Remote authentication

[!INCLUDE[](~/migration/fx-to-core/includes/uses-systemweb-adapters.md)]

Choose this approach when you need to share authentication between your ASP.NET Framework and ASP.NET Core applications during incremental migration, or when you have complex authentication that's difficult to migrate.

The System.Web adapters' remote authentication feature allows an ASP.NET Core app to determine a user's identity by deferring to an ASP.NET app. This enables gradual migration while maintaining a single authentication system.

### How remote authentication works

1. When requests are processed by the ASP.NET Core app, if remote app authentication is the default scheme or specified by the request's endpoint, the `RemoteAuthenticationAuthHandler` will attempt to authenticate the user.
2. The handler makes an HTTP request to the ASP.NET app's authenticate endpoint, forwarding configured headers from the current request (by default, `Authorization` and `Cookie` headers).
3. The ASP.NET app processes the authentication and returns either a serialized `ClaimsPrincipal` or an HTTP status code indicating failure.
4. The ASP.NET Core app uses the result to establish the user's identity or handle authentication challenges.

### Remote authentication pros and cons

| Pros | Cons |
|------|------|
| Minimal code changes required | Additional HTTP request overhead |
| Works with any Framework auth type | Network dependency between apps |
| Gradual migration capability | More complex debugging |
| Preserves existing auth logic | Requires both apps to be running |
| Handles complex auth scenarios | Limited Windows auth support |

### When to choose remote authentication

**Choose Remote Authentication when:**
* Your ASP.NET app doesn't use `Microsoft.Owin` cookie authentication
* You want a flexible solution that works with various authentication mechanisms  
* You need to gradually migrate authentication logic to ASP.NET Core
* You have complex custom authentication that's difficult to rewrite
* You're doing an incremental migration and need shared authentication state

### Remote authentication configuration

There are just a few small code changes needed to enable remote authentication in a solution that's already set up according to the [Getting Started](xref:migration/fx-to-core/start).

First, follow the [remote app setup](xref:migration/fx-to-core/inc/remote-app-setup) instructions to connect the ASP.NET Core and ASP.NET apps. Then, there are just a couple extra extension methods to call to enable remote app authentication.

:::zone pivot="manual"

#### ASP.NET app configuration

The ASP.NET app needs to be configured to add the authentication endpoint. Adding the authentication endpoint is done by calling the `AddAuthenticationServer` extension method to set up the HTTP module that watches for requests to the authentication endpoint. Note that remote authentication scenarios typically want to add proxy support as well, so that any authentication related redirects correctly route to the ASP.NET Core app rather than the ASP.NET one.

:::code language="csharp" source="~/migration/fx-to-core/areas/authentication/samples/AspNetApp.cs" id="snippet_SystemWebAdapterConfiguration" :::

#### ASP.NET Core app configuration

Next, the ASP.NET Core app needs to be configured to enable the authentication handler that will authenticate users by making an HTTP request to the ASP.NET app. Again, this is done by calling `AddAuthenticationClient` when registering System.Web adapters services:

:::code language="csharp" source="~/migration/fx-to-core/areas/authentication/samples/AspNetCore.cs" id="snippet_AddSystemWebAdapters" highlight="8" :::

The boolean that is passed to the `AddAuthenticationClient` call specifies whether remote app authentication should be the default authentication scheme. Passing `true` will cause the user to be authenticated via remote app authentication for all requests, whereas passing `false` means that the user will only be authenticated with remote app authentication if the remote app scheme is specifically requested (with `[Authorize(AuthenticationSchemes = RemoteAppAuthenticationDefaults.AuthenticationScheme)]` on a controller or action method, for example). Passing false for this parameter has the advantage of only making HTTP requests to the original ASP.NET app for authentication for endpoints that require remote app authentication but has the disadvantage of requiring annotating all such endpoints to indicate that they will use remote app auth.

:::zone-end

:::zone pivot="aspire"
When using Aspire, the configuration will be done via environment variables and are set by the AppHost. To enable remote session, the option must be enabled:

```csharp
...

var coreApp = builder.AddProject<Projects.AuthRemoteIdentityCore>("core")
    .WithHttpHealthCheck()
    .WaitFor(frameworkApp)
    .WithIncrementalMigrationFallback(frameworkApp, options => options.RemoteAuthentication = RemoteAuthentication.DefaultScheme);

...
```

Once this is done, it will be automatically hooked up in both the framework and core applications.
:::zone-end

#### Using Remote Authentication with Specific Endpoints

When you set the default scheme to `false`, you can specify remote authentication for specific controllers or actions:

```csharp
[Authorize(AuthenticationSchemes = RemoteAppAuthenticationDefaults.AuthenticationScheme)]
public class SecureController : Controller
{
    // This controller uses remote authentication
    public IActionResult Index()
    {
        return View();
    }
}

// Or on specific actions
public class HomeController : Controller
{
    [Authorize(AuthenticationSchemes = RemoteAppAuthenticationDefaults.AuthenticationScheme)]
    public IActionResult SecureAction()
    {
        return View();
    }
}
```

#### Implementing Custom Authentication Result Processors

You can implement custom processors to modify authentication results before they are used:

```csharp
public class CustomAuthResultProcessor : IRemoteAuthenticationResultProcessor
{
    public Task ProcessAsync(RemoteAuthenticationResult result, HttpContext context)
    {
        // Custom logic to process authentication results
        if (result.Headers.ContainsKey("Location"))
        {
            // Modify redirect URLs or other logic
        }
        
        return Task.CompletedTask;
    }
}

// Register the custom processor
builder.Services.AddScoped<IRemoteAuthenticationResultProcessor, CustomAuthResultProcessor>();
```

Finally, if the ASP.NET Core app didn't previously include authentication middleware, that will need to be enabled (after routing middleware, but before authorization middleware). For more information about middleware ordering, see <xref:fundamentals/middleware/index#middleware-order>:

:::code language="csharp" source="~/migration/fx-to-core/areas/authentication/samples/AspNetCore.cs" id="snippet_UseAuthentication" :::

#### Security Considerations

When implementing remote authentication, consider the following security aspects:

* **API Key Security**: The API key used for communication between the ASP.NET Core and ASP.NET apps should be stored securely using [configuration providers](xref:fundamentals/configuration/index) and not hardcoded.
* **Network Security**: Communication between the apps should occur over secure channels (HTTPS) in production environments.
* **Header Forwarding**: Be cautious about which headers you forward to avoid exposing sensitive information. Only forward headers that are necessary for authentication.
* **Endpoint Protection**: The authentication endpoint on the ASP.NET app should only be accessible to the ASP.NET Core app, not external clients.

#### Troubleshooting

Common issues when configuring remote authentication:

* **Authentication failures**: Verify that the API keys match between both applications and that the authentication endpoint path is correctly configured.
* **Redirect loops**: Ensure that the `RedirectUrlProcessor` is properly configured to redirect to the ASP.NET Core app rather than the ASP.NET app.
* **Missing claims**: Verify that the ASP.NET app is properly serializing the `ClaimsPrincipal` and that all required claims are included.

#### Design

1. When requests are processed by the ASP.NET Core app, if remote app authentication is the default scheme or specified by the request's endpoint, the `RemoteAuthenticationAuthHandler` will attempt to authenticate the user.
    1. The handler will make an HTTP request to the ASP.NET app's authenticate endpoint. It will copy configured headers from the current request onto this new one in order to forward auth-relevant data. As mentioned above, default behavior is to copy the `Authorization` and `Cookie` headers. The API key header is also added for security purposes.
1. The ASP.NET app will serve requests sent to the authenticate endpoint. As long as the API keys match, the ASP.NET app will return either the current user's <xref:System.Security.Claims.ClaimsPrincipal> serialized into the response body or it will return an HTTP status code (like 401 or 302) and response headers indicating failure.
1. When the ASP.NET Core app's `RemoteAuthenticationAuthHandler` receives the response from the ASP.NET app:
    1. If a ClaimsPrincipal was successfully returned, the auth handler will deserialize it and use it as the current user's identity.
    1. If a ClaimsPrincipal was not successfully returned, the handler will store the result and if authentication is challenged (because the user is accessing a protected resource, for example), the request's response will be updated with the status code and selected response headers from the response from the authenticate endpoint. This enables challenge responses (like redirects to a login page) to be propagated to end users.
        1. Because results from the ASP.NET app's authenticate endpoint may include data specific to that endpoint, users can register `IRemoteAuthenticationResultProcessor` implementations with the ASP.NET Core app which will run on any authentication results before they are used. As an example, the one built-in `IRemoteAuthenticationResultProcessor` is `RedirectUrlProcessor` which looks for `Location` response headers returned from the authenticate endpoint and ensures that they redirect back to the host of the ASP.NET Core app and not the ASP.NET app directly.

#### Known limitations

This remote authentication approach has a couple known limitations:

1. **Windows Authentication**: Because Windows authentication depends on a handle to a Windows identity, Windows authentication is not supported by this feature. Future work is planned to explore how shared Windows authentication might work. See [dotnet/systemweb-adapters#246](https://github.com/dotnet/systemweb-adapters/issues/246) for more information. For Windows authentication scenarios, consider using <xref:security/authentication/windowsauth> in your ASP.NET Core application instead.
1. **User Management Actions**: This feature allows the ASP.NET Core app to make use of an identity authenticated by the ASP.NET app, but all actions related to users (logging on, logging off, etc.) still need to be routed through the ASP.NET app.
1. **Performance Considerations**: Each authentication request requires an HTTP call to the ASP.NET app, which may impact performance. Consider using shared cookie authentication (described in the Alternatives section) if performance is critical.

## Shared cookie authentication

If authentication in the ASP.NET app is done using `Microsoft.Owin` Cookie Authentication Middleware, an alternative solution to remote authentication is to configure the ASP.NET and ASP.NET Core apps so that they are able to share an authentication cookie. 

### How shared cookies work

Sharing an authentication cookie enables:

* Both apps to determine the user identity from the same cookie.
* Signing in or out of one app signs the user in or out of the other app.

Both applications are configured to:
* Use the same cookie name and domain settings
* Share data protection keys for cookie encryption/decryption  
* Use compatible cookie authentication middleware

This allows users authenticated in one app to be automatically authenticated in the other app when they make requests.

### Shared cookie authentication pros and cons

| Pros | Cons |
|------|------|
| Best performance for shared auth | Only works with OWIN cookie auth |
| No additional HTTP requests | Requires matching data protection setup |
| Both apps can handle sign-in/sign-out | More complex initial configuration |
| Seamless user experience | Limited to cookie-based authentication |
| Lower network overhead | Requires coordination of deployments |

### Authentication limitations with shared cookies

Note that because signing in typically depends on a specific database, not all authentication functionality will work in both apps:

* Users should sign in through only one of the apps, either the ASP.NET or ASP.NET Core app, whichever the database is setup to work with.
* Both apps are able to see the users' identity and claims.
* Both apps are able to sign the user out.

Details on how to configure sharing auth cookies between ASP.NET and ASP.NET Core apps are available in [cookie sharing documentation](xref:security/cookie-sharing). For more information about cookie authentication in ASP.NET Core, see <xref:security/authentication/cookie>.

The following samples in the [System.Web adapters](https://github.com/dotnet/systemweb-adapters) GitHub repo demonstrates remote app authentication with shared cookie configuration enabling both apps to sign users in and out:

* [ASP.NET app](https://github.com/dotnet/systemweb-adapters/tree/main/samples/RemoteAuth/Identity/MvcApp)
* [ASP.NET Core app](https://github.com/dotnet/systemweb-adapters/tree/main/samples/RemoteAuth/Identity/MvcCoreApp)

### When to choose shared cookie authentication

**Choose Shared Cookie Authentication when:**
* Your ASP.NET app already uses `Microsoft.Owin` cookie authentication
* You can configure matching data protection settings between both apps  
* Performance is critical and you want to minimize HTTP requests
* You want both apps to handle user sign-in/sign-out operations
* You're comfortable managing shared encryption keys

Sharing authentication is a good option if both the following are true:

* The ASP.NET app is already using `Microsoft.Owin` cookie authentication.
* It's possible to update the ASP.NET app and ASP.NET Core apps to use matching data protection settings. Matching shared data protection settings includes a shared file path, Redis cache, or Azure Blob Storage for storing data protection keys. For more information, see <xref:security/data-protection/introduction>.

For other scenarios, the remote authentication approach described previously in this doc is more flexible and is probably a better fit.

## See also

* <xref:security/authentication/index>
* <xref:security/authorization/introduction>
* <xref:security/cookie-sharing>
* <xref:security/authentication/cookie>
* <xref:fundamentals/middleware/index>
* <xref:migration/fx-to-core/index>
* <xref:migration/fx-to-core/inc/remote-app-setup>
