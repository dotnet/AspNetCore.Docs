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

The profile claims can be returned in the **id_token** which is returned after a successful authentication. The ASP.NET Core client application just needs to request the profile scope. When using the id_token for claims, no extra claims mapping is required.

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

A second way to get the user claims is to use the OpenID Connect User Info API. The ASP.NET Core client application uses the **GetClaimsFromUserInfoEndpoint** property to configure this. One important difference from the first settings, is that you must specify the claims you require using the **MapUniqueJsonKey** method, otherwise only the **name**, **given_name** and **email** standard claims will be available in the client application. The claims included in the id_token are mapped per default. This is the major difference to the first option. You must explicit define some of the standard claims you require.

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

The **Name** claim and the **Role** claim are mapped to default properties in the ASP.NET Core HTTP context. Sometimes it is required to use different claims for the default properties, or the name claim and the role claim do not match the default values. The claims can be mapped using the **TokenValidationParameters** property and set to any claim as required. The values from the claims can be used directly in the HttpContext **User.Identity.Name** property and the roles.

If the **User.Identity.Name** has no value or the roles are missing, please check the values in the returned claims and set the **NameClaimType** and the **RoleClaimType** values. The returned claims from the client authentication can be viewed in the HTTP context.

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

ASP.NET Core adds default namespaces to some known claims which might not be required in your application. You can disable this namespace adding, if you would like to use the claims exactly like the Open ID Connect server created. 

```csharp
public void Configure(IApplicationBuilder app)
{
	JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
```

## Extending or adding custom claims in ASP.NET Core Identity

## Map claims from external identity providers

Please refer to this doc:

[Persist additional claims and tokens from external providers in ASP.NET Core](xref:security/authentication/social/additional-claims)
