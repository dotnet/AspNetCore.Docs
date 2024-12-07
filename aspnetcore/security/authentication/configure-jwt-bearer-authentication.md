---
title: Configure JWT bearer authentication in ASP.NET Core
author: damienbod
description: Learn how to set up JWT bearer authentication in an ASP.NET Core app.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/7/2024
uid: security/authentication/configure-jwt-bearer-authentication
---
# Configure JWT bearer authentication in ASP.NET Core

By [Damien Bowden](https://github.com/damienbod)

This article covers the following areas:

* Token types
* Using JWT tokens to secure an APIs
* How OIDC/OAuth fits into this?
* Implementing JWT bearer token authentication
* Recommended approaches to create a JWT
* Downstream APIs
* Advanced features, standards
* Testing APIs

Is this really authentication?

Using Bearer tokens as the authentication method is not really authentication but more authorization. The authentication is implemented when requesting access tokens for the first time in a UI application. This can also be described as delegated authorization. Using bearer tokens, you do not know who or what sent the access token and you do not know how the access token was acquired. The application can only say if the token is valid to use the requested API.

## Token types

There are many different types of tokens and many formats. You should not be creating access tokens or ID tokens yourself unless in testing scenarios. Creating self-made tokens and not following standards usually ends up with security problems and can only be used in closed systems. It is recommended to use OpenID Connect and/or OAuth to create access tokens for API access. 

### Access tokens

An access token is a string used by a client application to make requests to the server implementing an API. Access tokens can vary in format and different APIs may use different formats for their tokens.

An access token can be encrypted. Access tokens should never be read or interpreted by a web client or UI application holding the access token, only an API is the intended audience.

Access tokens are intended solely for making requests to an API. This is normally sent to the API is the **Authorization** request header as a bearer token.

[OAUTH spec](datatracker.ietf.org/doc/html/rfc6749#section-1.4)

#### Application access tokens and delegeted Access tokens

When requesting or creating an access token, an application or an application acting on behalf of a user can request and access token. The tokens are **application access tokens** or **delegated access tokens**. The tokens have different claims and are handled and persisted in different ways. An application is normally persisted once in the application until it expires where the delegated access token is persisted per user, either in a cookie or in a cache on a secure server.

It is recommended to user-delegated user access tokens whenever a user is involved. Downstream APIs can request a delegated user access token on behalf of the authenticated user. 

#### Sender constrained access tokens

There are two types of access tokens: **bearer tokens** and **sender-constrained** tokens. Sender-constrained tokens require the requesting client to prove possession of a private key to use the token, making the token unusable on its own. Sender-constrained tokens can be implemented in two ways:

- Demonstrating Proof-of-Possession (DPoP)
- MTLS

### ID tokens

ID tokens are security tokens that confirm a user’s successful authentication. They allow the client to verify the user’s identity. The authorization server issues ID tokens containing claims with user information. ID tokens are always in JWT (JSON Web Token) format.

ID tokens should never be used to access APIs.

### Other tokens

There are many different types of tokens as well as access tokens and ID tokens. OpenID Connect and OAuth standards specify many different types. Refresh tokens can be used to refresh a UI application without authenticating the user again, OAuth JAR tokens can be used to send authorization requests is a secure way. Verifiable credentials using JWT types in issuing or verifying credentials. It is important to use the tokens following the specifications. Please refer to the Standards provided in the links for more information.

## Using JWT tokens to secure an API

When using JWT access tokens to authorize an API, the request is valid, or not valid. If the request is not valid, a 401 response or a 403 response is returned. The API should never redirect to the identity provider to acquire more permissions or the correct access token. That is the responsibility of the UI requesting the data from the API.

### 401 Unauthorized

A 401 response is returned when the access token has an invalid standard requirement. The OAuth specifications are clear which claims must be valid and how to validate the claims in the access token. This could be the wrong signature, or the token has expired or one of the required claims like the audience or the issuer is incorrect. 

### 403 Forbidden

A 403 forbidden response is normally returned when a business permission is missing. The authorization has nothing to do with the authentication or the standard claims used in the access token. This could be implemented using an ASP.NET requirement with a policy or also a role authorization.

## How OIDC/OAuth fits into this?

When using access tokens, only the access token is validated on the API. The process of acquiring the access token is unspecified.  OpenID Connect and OAuth specify standards on how to acquire access tokens in a safe way. This process is different for every type of application. It is complicated to implement this in a safe way. This is why it is recommended to use one of the standards to create access tokens. OpenID Connect is used to create access tokens for an application and a user. These access tokens are user delegated access tokens. In a web application, a confidential OpenID Connect code flow using PKCE is the recommended way to implement this. If the application has no user, OAuth client credentials can be used to acquire an application access token. 

## Implementing JWT bearer token authentication

The **Microsoft.AspNetCore.Authentication.JwtBearer** Nuget package can be used to validate the JWT bearer tokens.

JWT bearer tokens should be validated in an API

*	The signature should be validated for trust and integrity. The token was created by the defined secure token service and the token was not tampered with.
*	The Issuer should be validated and should have the expected value.
*	The Audience should be validated and should have the expected value.
*	Token expiration claim should be validated.
*	Token type should be validated. (Required in RFC 9068, "at+jwt")

Following claims are required for OAuth 2.0 access tokens: iss, exp, aud, sub, client_id, iat, jti

If any of these claims or values are incorrect, the API should return a 401 response.

### JWT bearer token basic validation

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(jwtOptions =>
{
	jwtOptions.Authority = "https://{--your-authority--}";
	jwtOptions.Audience = "https://{--your-audience--}";
});
```

### JWT bearer token explicit validation

```csharp
builder.Services.AddAuthentication()
.AddJwtBearer("some-scheme", jwtOptions =>
{
	jwtOptions.MetadataAddress = builder.Configuration["Api:MetadataAddress"]!;
	jwtOptions.Authority = builder.Configuration["Api:Authority"];
	jwtOptions.Audience = builder.Configuration["Api:Audience"];
	jwtOptions.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateIssuerSigningKey = true,
		ValidAudiences = builder.Configuration.GetSection("Api:ValidAudiences").Get<string[]>(),
		ValidIssuers = builder.Configuration.GetSection("Api:ValidIssuers").Get<string[]>()
	};

	jwtOptions.MapInboundClaims = false;
	jwtOptions.TokenValidationParameters.ValidTypes = ["at+jwt"];
});
```

### JWT with multiple schemes

```csharp
services.AddAuthentication(options =>
{
	options.DefaultScheme = "UNKNOWN";
	options.DefaultChallengeScheme = "UNKNOWN";

})
.AddJwtBearer(Consts.MY_AUTH0_SCHEME, options =>
{
	options.Authority = "https://dev-damienbod.eu.auth0.com/";
	options.Audience = "https://auth0-api1";
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateIssuerSigningKey = true,
		ValidAudiences = Configuration.GetSection("ValidAudiences").Get<string[]>(),
		ValidIssuers = Configuration.GetSection("ValidIssuers").Get<string[]>()
	};
})
.AddJwtBearer(Consts.MY_AAD_SCHEME, jwtOptions =>
{
	jwtOptions.MetadataAddress = Configuration["AzureAd:MetadataAddress"]; 
	jwtOptions.Authority = Configuration["AzureAd:Authority"];
	jwtOptions.Audience = Configuration["AzureAd:Audience"]; 
	jwtOptions.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateIssuerSigningKey = true,
		ValidAudiences = Configuration.GetSection("ValidAudiences").Get<string[]>(),
		ValidIssuers = Configuration.GetSection("ValidIssuers").Get<string[]>()
	};
})
.AddPolicyScheme("UNKNOWN", "UNKNOWN", options =>
{
	options.ForwardDefaultSelector = context =>
	{
		string authorization = context.Request.Headers[HeaderNames.Authorization];
		if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
		{
			var token = authorization.Substring("Bearer ".Length).Trim();
			var jwtHandler = new JwtSecurityTokenHandler();

			if(jwtHandler.CanReadToken(token)) // it's a self contained access token and not encrypted
			{
				var issuer = jwtHandler.ReadJwtToken(token).Issuer; //.Equals("B2C-Authority"))
				if(issuer == Consts.MY_OPENIDDICT_ISS) // OpenIddict
				{
					return OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
				}

				if (issuer == Consts.MY_AUTH0_ISS) // Auth0
				{
					return Consts.MY_AUTH0_SCHEME;
				}

				if (issuer == Consts.MY_AAD_ISS) // AAD
				{
					return Consts.MY_AAD_SCHEME;
				}
			}
		}

		// We don't know with it is
		return Consts.MY_AAD_SCHEME;
	};
});
```

## Recommended approaches to create a JWT

When using access tokens, many security problems arise because the access tokens are created or stored in an unsecure way. The application did not authenticate the user in a strong way or the access token was persisted directly in the browser using local storage, session storage or web workers. The following section describes some best practices for applications using and creating access tokens.

### Use standards

Standards like OpenID Connect or OAuth should always be used when creating access tokens. Access tokens should not be in your applications without the correct security precautions.  Only in test scenarios, should you be creating access tokens.

### Use asymmetric keys

Asymmetric keys should always be used when creating access tokens. The public key is available in the well known endpoints and the API clients can validate the signature of the access token using the public key.

### Why creating your own access tokens is normally a bad idea

### Should I create an access token from a username/password request?

## Downstream APIs

### OAuth downstream application tokens

### Microsoft OBO downstream access tokens

### How Yarp can help

## Advanced features, standards

### Access token rotation

### Access tokens and cache

### Encypted access tokens

## Testing APIs

[Manage JSON Web Tokens in development with dotnet user-jwts](xref:security/authentication/jwt)

### Testing application access tokens

### Testing delegated access tokens

### Use Swagger, Postman and other API UI tools

## Map claims from OpenID Connect

Refer to the following document:

[Mapping, customizing, and transforming claims in ASP.NET Core](xref:security/authentication/claims)

## Standards

[JSON Web Token (JWT)](https://datatracker.ietf.org/doc/html/rfc7519)

[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749)

[OAuth 2.0 Demonstrating Proof of Possession DPoP](https://datatracker.ietf.org/doc/html/rfc9449)

[OAuth 2.0 JWT-Secured Authorization Request (JAR) RFC 9101](https://datatracker.ietf.org/doc/rfc9101/)

[OAuth 2.0 Mutual-TLS Client Authentication and Certificate-Bound Access Tokens](https://datatracker.ietf.org/doc/html/rfc8705)

[OpenID Connect 1.0](https://openid.net/specs/openid-connect-core-1_0-final.html)

[Microsoft identity platform and OAuth 2.0 On-Behalf-Of flow](https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-on-behalf-of-flow)

[OAuth 2.0 Token Exchange](https://datatracker.ietf.org/doc/html/rfc8693)

[JSON Web Token (JWT) Profile for OAuth 2.0 Access Tokens](https://datatracker.ietf.org/doc/html/rfc9068)
