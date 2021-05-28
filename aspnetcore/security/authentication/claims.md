---
title: Mapping claims, customizing claims and transforming claims in ASP.NET Core
author: damienbod
description: Learn how to map claims, do claims transformations, customize claims.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/28/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/claims
---
# Mapping claims, customizing claims and transforming claims in ASP.NET Core

By [Damien Bowden](https://github.com/damienbod)

Claims can be created from user data, identity data which can be issued using a trusted identity provider or ASP.NET Core identity. A claim is a name value pair that represents what the subject is, not what the subject can do.
This article covers the following areas:

* How to configure map claims using an OpenID Connect client
* Set the name claim and the role claim
* Reset the claims namespaces
* Customize, extend the claims with ASP.NET Core Identity

## Mapping claims using Open ID Connect authentication

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
   .AddCookie()
   .AddOpenIdConnect(options =>
   {
       options.SignInScheme = "Cookies";
       options.Authority = "-your-identity-provider-";
       options.RequireHttpsMetadata = true;
       options.ClientId = "-your-clientid-";
       options.ClientSecret = "-your-client-secret-from-user-secrets-or-keyvault";
       options.ResponseType = "code";
       options.UsePkce = true;
       options.Scope.Add("profile");
       options.SaveTokens = true;
   });
```

   
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
   .AddCookie()
   .AddOpenIdConnect(options =>
   {
       options.SignInScheme = "Cookies";
       options.Authority = "-your-identity-provider-";
       options.RequireHttpsMetadata = true;
       options.ClientId = "-your-clientid-";
       options.ClientSecret = "-your-client-secret-from-user-secrets-or-keyvault";
       options.ResponseType = "code";
       options.UsePkce = true;
       options.Scope.Add("profile");
       options.SaveTokens = true;
       options.GetClaimsFromUserInfoEndpoint = true;
       options.ClaimActions.MapUniqueJsonKey("preferred_username", "preferred_username");
       options.ClaimActions.MapUniqueJsonKey("gender", "gender");
   });
   
```

## Name claim and role claim mapping

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
   .AddCookie()
   .AddOpenIdConnect(options =>
   {
       // other options...
       options.TokenValidationParameters = new TokenValidationParameters
       {
         NameClaimType = "email", 
         // RoleClaimType = "role"
       };
   });

```

## Claims namespaces, default namespaces

```csharp
public void Configure(IApplicationBuilder app)
{
	JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
```

## Extending or adding custom claims in ASP.NET Core Identity

## Map claims from external identity providers