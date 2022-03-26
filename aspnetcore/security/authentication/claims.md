---
title: Mapping, customizing, and transforming claims in ASP.NET Core
author: damienbod
description: Learn how to map claims, do claims transformations, customize claims.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 2/16/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/claims
---
# Mapping, customizing, and transforming claims in ASP.NET Core

By [Damien Bowden](https://github.com/damienbod)

:::moniker range=">= aspnetcore-6.0"

Claims can be created from any user or identity data which can be issued using a trusted identity provider or ASP.NET Core identity. A claim is a name value pair that represents what the subject is, not what the subject can do.
This article covers the following areas:

* How to configure and map claims using an [OpenID Connect](https://openid.net/connect/) client
* Set the name and role claim
* Reset the claims namespaces
* Customize, extend the claims using <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation.TransformAsync%2A>

## Mapping claims using OpenID Connect authentication

The profile claims can be returned in the `id_token`, which is returned after a successful authentication. The ASP.NET Core client app only requires the profile scope. When using the `id_token` for claims, no extra claims mapping is required.

[!code-csharp[](~/security/authentication/claims/sample6/WebRPmapClaims/Program.cs?name=snippet1&highlight=8-26)]

The preceding code requires the [Microsoft.AspNetCore.Authentication.OpenIdConnect](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.OpenIdConnect) NuGet package .

Another way to get the user claims is to use the OpenID Connect User Info API. The ASP.NET Core client app uses the `GetClaimsFromUserInfoEndpoint` property to configure this. One important difference from the first settings, is that you must specify the claims you require using the `MapUniqueJsonKey` method, otherwise only the `name`, `given_name` and `email` standard claims will be available in the client app. The claims included in the `id_token` are mapped per default. This is the major difference to the first option. You must explicitly define some of the claims you require.

[!code-csharp[](~/security/authentication/claims/sample6/WebRPmapClaims/Program.cs?name=snippet2&highlight=26-29)]

## Name claim and role claim mapping

The **Name** claim and the **Role** claim are mapped to default properties in the ASP.NET Core HTTP context. Sometimes it is required to use different claims for the default properties, or the name claim and the role claim do not match the default values. The claims can be mapped using the **TokenValidationParameters** property and set to any claim as required. The values from the claims can be used directly in the HttpContext **User.Identity.Name** property and the roles.

If the `User.Identity.Name` has no value or the roles are missing, please check the values in the returned claims and set the `NameClaimType` and the `RoleClaimType` values. The returned claims from the client authentication can be viewed in the HTTP context.

[!code-csharp[](~/security/authentication/claims/sample6/WebRPmapClaims/Program.cs?name=snippet_name&highlight=10-14)]

## Claims namespaces, default namespaces

ASP.NET Core adds default namespaces to some known claims, which might not be required in the app. Optionally, disable these added namespaces and use the exact claims that the OpenID Connect server created.

[!code-csharp[](~/security/authentication/claims/sample6/WebRPmapClaims/Program.cs?name=snippet_NS&highlight=5)]

## Extend or add custom claims using `IClaimsTransformation`

The <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation> interface can be used to add extra claims to the <xref:System.Security.Claims.ClaimsPrincipal> class. The interface requires a single method <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation.TransformAsync%2A>. This method might get called multiple times. Only add a new claim if it does not already exist in the `ClaimsPrincipal`. A `ClaimsIdentity` is created to add the new claims and this can be added to the `ClaimsPrincipal`.

[!code-csharp[](~/security/authentication/claims/sample6/WebRPmapClaims/MyClaimsTransformation.cs)]

The <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation> interface and the `MyClaimsTransformation` class can be registered as a service:

```csharp
builder.Services.AddTransient<IClaimsTransformation, MyClaimsTransformation>();
```

## Extend or add custom claims in ASP.NET Core Identity

Refer to the following document:

[Add claims to Identity using IUserClaimsPrincipalFactory](xref:security/authentication/add-user-data#add-claims-to-identity-using-iuserclaimsprincipalfactoryapplicationuser)

## Map claims from external identity providers

Refer to the following document:

[Persist additional claims and tokens from external providers in ASP.NET Core](xref:security/authentication/social/additional-claims)

:::moniker-end


:::moniker range="< aspnetcore-6.0"

Claims can be created from any user or identity data which can be issued using a trusted identity provider or ASP.NET Core identity. A claim is a name value pair that represents what the subject is, not what the subject can do.
This article covers the following areas:

* How to configure and map claims using an [OpenID Connect](https://openid.net/connect/) client
* Set the name and role claim
* Reset the claims namespaces
* Customize, extend the claims using <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation.TransformAsync%2A>

## Mapping claims using OpenID Connect authentication

The profile claims can be returned in the `id_token`, which is returned after a successful authentication. The ASP.NET Core client app only requires the profile scope. When using the `id_token` for claims, no extra claims mapping is required.

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

Another way to get the user claims is to use the OpenID Connect User Info API. The ASP.NET Core client application uses the `GetClaimsFromUserInfoEndpoint` property to configure this. One important difference from the first settings, is that you must specify the claims you require using the `MapUniqueJsonKey` method, otherwise only the `name`, `given_name` and `email` standard claims will be available in the client application. The claims included in the `id_token` are mapped per default. This is the major difference to the first option. You must explicitly define some of the claims you require.

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

If the `User.Identity.Name` has no value or the roles are missing, please check the values in the returned claims and set the `NameClaimType` and the `RoleClaimType` values. The returned claims from the client authentication can be viewed in the HTTP context.

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

ASP.NET Core adds default namespaces to some known claims, which might not be required in the app. Optionally, disable these added namespaces and use the exact claims that the OpenID Connect server created.

```csharp
public void Configure(IApplicationBuilder app)
{
    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
```

## Extend or add custom claims using `IClaimsTransformation`

The `IClaimsTransformation` interface can be used to add extra claims to the `ClaimsPrincipal` class. The interface requires a single method `TransformAsync`. This method might get called multiple times. Only add a new claim if it does not already exist in the `ClaimsPrincipal`. A `ClaimsIdentity` is created to add the new claims and this can be added to the `ClaimsPrincipal`.

```csharp
public class MyClaimsTransformation : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
       ClaimsIdentity claimsIdentity = new ClaimsIdentity();
       var claimType = "myNewClaim";
       if (!principal.HasClaim(claim => claim.Type == claimType))
       {		   
          claimsIdentity.AddClaim(new Claim(claimType, "myClaimValue"));
       }

       principal.AddIdentity(claimsIdentity);
       return Task.FromResult(principal);
    }
}
```

The `IClaimsTransformation` interface and the `MyClaimsTransformation` class can be added in the ConfigureServices method as a service.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IClaimsTransformation, MyClaimsTransformation>();
```

## Extend or add custom claims in ASP.NET Core Identity

Refer to the following document:

[Add claims to Identity using IUserClaimsPrincipalFactory](xref:security/authentication/add-user-data#add-claims-to-identity-using-iuserclaimsprincipalfactoryapplicationuser)

## Map claims from external identity providers

Refer to the following document:

[Persist additional claims and tokens from external providers in ASP.NET Core](xref:security/authentication/social/additional-claims)

:::moniker-end