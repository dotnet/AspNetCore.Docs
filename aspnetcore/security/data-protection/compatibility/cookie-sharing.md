---
title: Sharing cookies between applications
author: rick-anderson
description: Learn how to share authentication cookies among ASP.NET 4.x and ASP.NET Core apps.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 12/15/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/data-protection/compatibility/cookie-sharing
---
# Sharing cookies between applications

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Luke Latham](https://github.com/guardrex)

Websites often consist of individual web apps, working together to meet the needs of visitors. To provide a single sign-on (SSO) experience, the web apps within the site must share authentication tickets. To support this scenario, the data protection stack allows sharing Katana cookie authentication and ASP.NET Core cookie authentication tickets.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/data-protection/compatibility/cookie-sharing/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample illustrates cookie sharing across three apps that use cookie authentication:

* ASP.NET Core 2.0 Razor Pages app without using ASP.NET Core Identity
* ASP.NET Core 2.0 MVC app with ASP.NET Core Identity
* ASP.NET Framework 4.6.1 MVC app with ASP.NET Identity

## Sharing authentication cookies between apps

To share authentication cookies between two ASP.NET Core apps, configure each app that should share cookies as follows.

If you're using identity:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

In the `ConfigureServices` method, use the [ConfigureApplicationCookie](/dotnet/api/microsoft.extensions.dependencyinjection.identityservicecollectionextensions.configureapplicationcookie) extension method to set up the data protection service for cookies.

[!code-csharp[Main](cookie-sharing/sample/CookieAuthWithIdentity.Core/Startup.cs?name=snippet1)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

In the `Configure` method, use the [CookieAuthenticationOptions](/dotnet/api/microsoft.aspnetcore.builder.cookieauthenticationoptions) to set up:

* The data protection service for cookies
* The `AuthenticationScheme` to match ASP.NET 4.x.

```csharp
app.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Cookies.ApplicationCookie.AuthenticationScheme = 
        "ApplicationCookie";

    var protectionProvider = 
        DataProtectionProvider.Create(
            new DirectoryInfo(@"PATH_TO_KEY_RING_FOLDER"));

    options.Cookies.ApplicationCookie.DataProtectionProvider = 
        protectionProvider;

    options.Cookies.ApplicationCookie.TicketDataFormat = 
        new TicketDataFormat(protectionProvider.CreateProtector(
            "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", 
            "Cookies", 
            "v2"));
});
```

---

If you're using cookies directly:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](cookie-sharing/sample/CookieAuth.Core/Startup.cs?name=snippet1)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
app.UseCookieAuthentication(new CookieAuthenticationOptions
{
    DataProtectionProvider = 
        DataProtectionProvider.Create(
            new DirectoryInfo(@"PATH_TO_KEY_RING_FOLDER"))
});
```

---

[DataProtectionProvider](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionprovider) requires the [Microsoft.AspNetCore.DataProtection.Extensions](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.Extensions/) NuGet package.

[DirectoryInfo](/dotnet/api/system.io.directoryinfo) is provided a key storage location set aside for use with authentication cookies. The cookie authentication middleware uses the provided implementation of `DataProtectionProvider`. The `DataProtectionProvider` instance is isolated from the data protection system used by other parts of the app.

## Encrypting data protection keys at rest

For production deployments, configure the `DataProtectionProvider` to encrypt keys at rest with DPAPI or an X509Certificate. See [Key Encryption At Rest](xref:security/data-protection/implementation/key-encryption-at-rest) for more information.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
services.AddDataProtection()
    .ProtectKeysWithCertificate("thumbprint");
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
app.UseCookieAuthentication(new CookieAuthenticationOptions
{
    DataProtectionProvider = DataProtectionProvider.Create(
        new DirectoryInfo(@"PATH_TO_KEY_RING"),
        configure =>
        {
            configure.ProtectKeysWithCertificate("thumbprint");
        })
});
```

---

## Sharing authentication cookies between ASP.NET 4.x and ASP.NET Core apps

ASP.NET 4.x apps which use Katana cookie authentication middleware can be configured to generate authentication cookies that are compatible with the ASP.NET Core cookie authentication middleware. This allows upgrading a large site's individual apps piecemeal while providing a smooth SSO experience across the site.

> [!TIP]
> You can tell if your existing app uses Katana cookie authentication middleware by the existence of a call to `UseCookieAuthentication` in your project's *Startup.Auth.cs* file. ASP.NET 4.x web app projects created with Visual Studio 2013 and later use the Katana cookie authentication middleware by default.

> [!NOTE]
> Your ASP.NET 4.x app must target .NET Framework 4.5.1 or higher. Otherwise, the necessary NuGet packages fail to install.

To share authentication cookies among your ASP.NET 4.x apps and your ASP.NET Core apps, configure the ASP.NET Core app as stated above, then configure your ASP.NET 4.x apps by following the steps below.

1. Install the package [Microsoft.Owin.Security.Interop](https://www.nuget.org/packages/Microsoft.Owin.Security.Interop/) into each ASP.NET 4.x app.

2. In *Startup.Auth.cs*, locate the call to `UseCookieAuthentication` and modify it as follows. Change the cookie name to match the name used by the ASP.NET Core cookie authentication middleware. Provide an instance of a `DataProtectionProvider` that has been initialized to a key storage location.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](cookie-sharing/sample/CookieAuthWithIdentity.NETFramework/CookieAuthWithIdentity.NETFramework/App_Start/Startup.Auth.cs?name=snippet1)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Set the `CookieManager` to interop `ChunkingCookieManager` so the chunking format is compatible.

```csharp
app.UseCookieAuthentication(new CookieAuthenticationOptions
{
    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    CookieName = ".AspNetCore.Cookies",
    // CookieName = ".AspNetCore.ApplicationCookie", (if using ASP.NET Identity)
    // CookiePath = "...", (if necessary)
    // ...
    TicketDataFormat = new AspNetTicketDataFormat(
        new DataProtectorShim(
            DataProtectionProvider.Create(
                new DirectoryInfo(@"PATH_TO_KEY_RING_FOLDER"))
            .CreateProtector(
                "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
                "Cookies", 
                "v2"))),
    CookieManager = new ChunkingCookieManager()
});
```

---

> [!NOTE]
> Confirm that the identity system for each app is pointed at the same user database. Otherwise, the identity system produces failures at runtime when it tries to match the information in the authentication cookie against the information in its database.
