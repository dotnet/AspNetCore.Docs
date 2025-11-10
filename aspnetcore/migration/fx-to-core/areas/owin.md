---
title: OWIN integration in ASP.NET Core
description: How to use OWIN middleware in ASP.NET Core applications during migration from ASP.NET Framework
ai-usage: ai-assisted
author: twsouthwick
ms.author: tasou
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/10/2025
ms.topic: article
uid: migration/fx-to-core/areas/owin
---

# OWIN integration

The `Microsoft.AspNetCore.SystemWebAdapters.Owin` library enables ASP.NET Core applications to use OWIN middleware during migration from ASP.NET Framework. This integration is valuable when migrating applications that rely on OWIN-based middleware, particularly for authentication, authorization, or custom pipeline components.

> [!WARNING]
> When using OWIN integration, you may need to suppress build warnings for .NET Framework package dependencies. Add the following to your project file:
> ```xml
> <PropertyGroup>
>   <NoWarn>$(NoWarn);NU1701</NoWarn>
> </PropertyGroup>
> ```
> Running .NET Framework code on .NET Core is supported as long as the APIs used exist and have the same behavior. It is recommended to use this as part of the migration process, but to not stay in this state for too long.
>
> Some packages will need to be manually updated to supported version if used. These include:
> * EntityFramework must be >= 6.5.1 for best support on .NET Core

## Why use OWIN integration

OWIN integration provides several benefits during migration:

* **Preserve existing middleware**: Reuse OWIN middleware from your ASP.NET Framework application without immediate rewrites
* **Gradual migration**: Migrate middleware components incrementally while maintaining application functionality
* **Authentication continuity**: Maintain authentication state and share cookies between ASP.NET Framework and ASP.NET Core applications during migration
* **Familiar patterns**: Continue using OWIN APIs and patterns that your team already understands

## Integration patterns

The library provides three distinct integration patterns, each suited for different migration scenarios:

1. **OWIN pipeline as main pipeline middleware**: Add OWIN middleware directly to the ASP.NET Core middleware pipeline
2. **OWIN pipeline as authentication handler**: Use OWIN middleware as an ASP.NET Core authentication handler
3. **OWIN pipeline in emulated HttpApplication events**: Run OWIN middleware within the emulated `HttpApplication` pipeline

## OWIN pipeline as middleware

This pattern incorporates OWIN middleware into the ASP.NET Core middleware pipeline without using emulated `HttpApplication` events.

### When to use this pattern

Use this approach when:

* You want standard middleware pipeline behavior
* Your application doesn't rely on `HttpApplication` events
* You're gradually migrating OWIN middleware to ASP.NET Core patterns

### Setup

Add OWIN middleware to the main pipeline:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseOwin(owinApp =>
{
    owinApp.UseMyOwinMiddleware();
});

app.UseRouting();
app.MapControllers();

app.Run();
```

### Access services

Access services when configuring OWIN middleware:

```csharp
app.UseOwin((owinApp, services) =>
{
    var configuration = services.GetRequiredService<IConfiguration>();
    owinApp.UseMyOwinMiddleware(configuration);
});
```

## OWIN authentication handler

This pattern uses OWIN middleware as an ASP.NET Core authentication handler, integrating with the `AuthenticationBuilder` API.

### When to use this pattern

Use this approach when:

* Migrating authentication logic from ASP.NET Framework
* Sharing authentication cookies between ASP.NET Framework and ASP.NET Core applications
* Using OWIN authentication middleware such as cookie authentication or OAuth providers
* Working with ASP.NET Framework Identity

### Setup

Register OWIN authentication as an ASP.NET Core authentication handler:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSystemWebAdapters()
    .AddAuthentication()
    .AddOwinAuthentication((owinApp, services) =>
    {
        owinApp.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login")
        });
    });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
```

### Custom authentication scheme

Specify a custom authentication scheme name:

```csharp
builder.Services
    .AddAuthentication()
    .AddOwinAuthentication("MyOwinScheme", (owinApp, services) =>
    {
        owinApp.UseMyOwinAuthenticationMiddleware();
    });
```

When no scheme name is provided, the authentication handler uses `OwinAuthenticationDefaults.AuthenticationScheme` as the default scheme. The authentication scheme name determines:

* **Default authentication**: If set as the default scheme, it automatically authenticates requests without requiring an `[Authorize]` attribute
* **Challenge behavior**: Controls which handler responds to authentication challenges (such as redirecting to a login page)
* **Authentication selection**: Allows you to explicitly authenticate against a specific scheme using `HttpContext.AuthenticateAsync("scheme-name")`

For applications with multiple authentication schemes, you can configure the default authentication and challenge schemes:

```csharp
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "MyOwinScheme";
        options.DefaultChallengeScheme = "MyOwinScheme";
    })
    .AddOwinAuthentication("MyOwinScheme", (owinApp, services) =>
    {
        owinApp.UseMyOwinAuthenticationMiddleware();
    });
```

For more information about authentication schemes and how they work in ASP.NET Core, see <xref:security/authentication/index> and <xref:security/authentication/cookie>.

### Access OWIN authentication

Continue using the OWIN `IAuthenticationManager` interface:

```csharp
var owinContext = HttpContext.GetOwinContext();
var authManager = owinContext.Authentication;

authManager.SignIn(identity);
authManager.SignOut();
```

## Migrating ASP.NET Framework Identity

A common migration scenario involves ASP.NET Framework Identity with OWIN cookie authentication. This example shows how to maintain compatibility during migration.

### Configure data protection

Configure data protection to match ASP.NET Framework settings for cookie sharing:

```csharp
var builder = WebApplication.CreateBuilder(args);

var sharedApplicationName = "CommonMvcAppName";
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Path.GetTempPath(), "sharedkeys", sharedApplicationName)))
    .SetApplicationName(sharedApplicationName);
```

### Configure OWIN authentication

Set up OWIN authentication with Identity services:

```csharp
builder.Services
    .AddAuthentication()
    .AddOwinAuthentication("SharedCookie", (app, services) =>
    {
        app.CreatePerOwinContext(ApplicationDbContext.Create);
        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

        var dataProtector = services.GetDataProtector(
            "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
            "SharedCookie",
            "v2");

        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login"),
            Provider = new CookieAuthenticationProvider
            {
                OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                    validateInterval: TimeSpan.FromMinutes(30),
                    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            },
            CookieName = ".AspNet.ApplicationCookie",
            TicketDataFormat = new AspNetTicketDataFormat(new DataProtectorShim(dataProtector))
        });
    });
```

### Use in controllers

Access OWIN-registered services in controllers:

```csharp
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SystemWebAdapters;
using Microsoft.Owin.Security;

[Authorize]
public class AccountController : Controller
{
    public ApplicationSignInManager SignInManager =>
        HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

    public ApplicationUserManager UserManager =>
        HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

    private IAuthenticationManager AuthenticationManager =>
        HttpContext.GetOwinContext().Authentication;

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await SignInManager.PasswordSignInAsync(
            model.Email, 
            model.Password, 
            model.RememberMe, 
            shouldLockout: false);

        if (result == SignInStatus.Success)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid login attempt.");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        return RedirectToAction("Index", "Home");
    }
}
```

### Key configuration points

When migrating ASP.NET Framework Identity:

* **Data protection**: Configure the same `ApplicationName` and key storage location in both ASP.NET Framework and ASP.NET Core
* **Per-request services**: Use `app.CreatePerOwinContext<T>()` to register services created once per request
* **Data protection bridge**: Use `AspNetTicketDataFormat` with `DataProtectorShim` to bridge ASP.NET Core's `IDataProtector` to OWIN
* **Service access**: Access OWIN-registered services through `HttpContext.GetOwinContext()`
* **Cookie names**: Ensure the `CookieName` matches between applications when sharing authentication state

## OWIN pipeline in HttpApplication events

This pattern runs OWIN middleware within the emulated `HttpApplication` event pipeline, similar to how OWIN works in ASP.NET Framework's integrated pipeline mode.

### When to use this pattern

Use this approach when:

* Your application relies on the ASP.NET Framework integrated pipeline
* OWIN middleware needs to execute at specific `HttpApplication` event stages
* You're migrating applications that use both `HttpApplication` events and OWIN together

### Setup

Configure the OWIN pipeline to run within `HttpApplication` events:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSystemWebAdapters()
    .AddOwinApp(app =>
    {
        app.UseMyOwinMiddleware();
        app.UseStageMarker(PipelineStage.Authenticate);
    });

var app = builder.Build();

app.UseSystemWebAdapters();
app.Run();
```

### Access services

Access the `IServiceProvider` when configuring the OWIN pipeline:

```csharp
builder.Services
    .AddSystemWebAdapters()
    .AddOwinApp((app, services) =>
    {
        var configuration = services.GetRequiredService<IConfiguration>();
        app.UseMyOwinMiddleware(configuration);
        app.UseStageMarker(PipelineStage.Authenticate);
    });
```

### HttpApplication event mapping

The OWIN pipeline integrates with these `HttpApplication` events:

* `AuthenticateRequest` / `PostAuthenticateRequest`
* `AuthorizeRequest` / `PostAuthorizeRequest`
* `ResolveRequestCache` / `PostResolveRequestCache`
* `MapRequestHandler` / `PostMapRequestHandler`
* `AcquireRequestState` / `PostAcquireRequestState`
* `PreRequestHandlerExecute`

Use `.UseStageMarker(PipelineStage)` to control when OWIN middleware executes relative to these events.

## Migration strategy

When incorporating OWIN middleware into your ASP.NET Core application:

1. **Identify OWIN dependencies**: Determine which OWIN middleware your application uses
1. **Choose integration pattern**: Select the appropriate pattern based on your application's needs
1. **Configure data protection**: Set up shared data protection for authentication cookie sharing
1. **Test authentication flow**: Verify authentication works correctly in the ASP.NET Core application
1. **Gradual conversion**: Plan to migrate OWIN middleware to native ASP.NET Core middleware over time
1. **Monitor compatibility**: Ensure OWIN middleware behavior matches expectations during migration

## Additional resources

* <xref:migration/fx-to-core/areas/authentication>
* <xref:fundamentals/middleware/index>
* <xref:security/authentication/index>
