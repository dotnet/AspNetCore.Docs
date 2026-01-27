---
title: "Breaking change: Security token events return a JsonWebToken"
description: Learn about the breaking change in ASP.NET Core 8.0 where the JwtBearer, WsFederation, and OpenIdConnect events context properties of type 'SecurityToken' now return a 'JsonWebToken' by default.
ms.date: 07/31/2023
ms.custom: https://github.com/aspnet/Announcements/issues/508
---
# Security token events return a JsonWebToken

The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents>, <xref:Microsoft.AspNetCore.Authentication.WsFederation.WsFederationEvents>, and <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents> events are authentication events fired respectively by the [JwtBearer](xref:Microsoft.AspNetCore.Authentication.JwtBearer), [WsFederation](xref:Microsoft.AspNetCore.Authentication.WsFederation), and [OpenIdConnect](xref:Microsoft.AspNetCore.Authentication.OpenIdConnect) authentication handlers. For example, the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnTokenValidated> event is fired when a security token is validated. These events are fired with a context (for example, <xref:Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext>) that exposes a <xref:Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext.SecurityToken?displayProperty=nameWithType> property of abstract type <xref:System.IdentityModel.Tokens.SecurityToken>. The default real implementation of <xref:Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext.SecurityToken?displayProperty=nameWithType> changed from `System.IdentityModel.Tokens.Jwt.JwtSecurityToken` to <xref:Microsoft.IdentityModel.JsonWebTokens.JsonWebToken>.

## Version introduced

ASP.NET Core 8.0 Preview 7

## Previous behavior

Previously, the affected `SecurityToken` properties were implemented by `System.IdentityModel.Tokens.Jwt.JwtSecurityToken`, which derives from <xref:System.IdentityModel.Tokens.SecurityToken>. `JwtSecurityToken` is the previous generation of JSON Web Token (JWT) implementation. The `JwtSecurityToken` tokens were produced by <xref:Microsoft.AspNetCore.Builder.JwtBearerOptions.SecurityTokenValidators>.

In addition, the `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap` field provided the default claim type mapping for inbound claims.

## New behavior

Starting in ASP.NET Core 8.0, the <xref:Microsoft.IdentityModel.JsonWebTokens> class, which also derives from <xref:System.IdentityModel.Tokens.SecurityToken>, implements the `SecurityToken` properties, by default. <xref:Microsoft.IdentityModel.JsonWebTokens> tokens are produced by more optimized `TokenHandler` handlers.

In addition, the <xref:Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler.DefaultInboundClaimTypeMap?displayProperty=nameWithType> field provides the default claim type mapping for inbound claims.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made because <xref:Microsoft.IdentityModel.JsonWebTokens.JsonWebToken> (and its associated <xref:Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler>) bring the following benefits:

- 30% performance improvement.
- Improved reliability by using a "last known good" metadata (such as `OpenIdConnectMetadata`).
- Async processing.

## Recommended action

For most users, this change shouldn't be a problem as the type of the properties (`SecurityToken`) hasn't changed, and you weren't supposed to look at the real type.

However, if you were down-casting one of the affected `SecurityToken` properties to `JwtSecurityToken` (for example, to get the claims), you have two options:

- Down-cast the property to `JsonWebToken`:

  ```csharp
  service.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options => {
      options.Events.OnTokenValidated = (context) => {
          // Replace your cast to JwtSecurityToken.
          JsonWebToken token = context.SecurityToken as JsonWebToken;
          // Do something ...
      };
  });
  ```

- Set one of the `UseSecurityTokenValidators` Boolean properties on the corresponding options (<xref:Microsoft.AspNetCore.Builder.JwtBearerOptions>, <xref:Microsoft.AspNetCore.Authentication.WsFederation.WsFederationOptions>, or <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions>) to `true`. By setting the property to `true`, the authentication handlers will keep using `JwtTokenValidators` and will keep producing `JwtSecurityToken` tokens.

  ```csharp
  service.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme,  options => {
      options.UseSecurityTokenValidators = true;
      options.Events.OnTokenValidated = (context) => {
          // As you were doing before
          JwtSecurityToken token = context.SecurityToken as JwtSecurityToken;
          // Do something ...
      };
  });
  ```

## Affected APIs

- <xref:Microsoft.AspNetCore.Authentication.WsFederation.SecurityTokenValidatedContext.SecurityToken?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext.SecurityToken?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext.SecurityToken?displayProperty=fullName>
- [AuthorizationCodeReceivedContext.SecurityToken](xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext?displayProperty=fullName)
