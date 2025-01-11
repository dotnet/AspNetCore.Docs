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

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authentication/configure-jwt-bearer-authentication/sample/JwtBearer)

This article covers the following areas:

* Token types
* Using JWT tokens to secure an APIs
* How OIDC/OAuth fits into this?
* Implementing JWT bearer token authentication
* Recommended approaches to create a JWT
* Downstream APIs
* Handling access tokens
* YARP
* Testing APIs

## Authentication v Authorization

Bearer tokens are often treated as an authentication mechanism, but in practice, the tokens are used primarily for authorization. Authentication occurs when a user first requests an access token in the UI layer. When the token is presented to an API, the process is more accurately described as *delegated authorization*. Because the token itself doesn't reveal who or what obtained it or how it was issued, the API can only confirm whether the token is valid for calling the requested resource.

## Token types

There are numerous types of tokens and formats. Generating your own access tokens or ID tokens is discouraged, except for testing purposes. Self-created tokens that do not adhere to established standards:

* Can lead to security vulnerabilities.
* Are only suitable for closed systems.

We recommend using [OpenID Connect 1.0](https://openid.net/specs/openid-connect-core-1_0-final.html) or an OAuth standard for creating access tokens intended for API access. 

### Access tokens

Access tokens:
* Are strings used by a client app to make requests to the server implementing an API.
* Can vary in format. Different APIs may use different formats for the tokens.
* Can be encrypted.
* Should never be read or interpreted by a web client or UI app holding the access token.
* Are intended solely for making requests to an API.
* Are typically sent to the API in the **Authorization** request header as a bearer token.

See [The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749#section-1.4)

#### Application access tokens and delegated access tokens

When requesting or creating an access token, an app, or an app acting on behalf of a user, can request an access token. These tokens can be either *application access tokens* or *delegated access tokens*. The tokens have different claims and are managed and stored differently. An *application access token* is typically stored once in the app until it expires, while a *delegated access token* is stored per user, either in a cookie or in a secure server cache.

We recommend using delegated user access tokens whenever a user is involved. Downstream APIs can request a delegated user access token on behalf of the authenticated user. 

#### Sender constrained access tokens

There are two types of access tokens: [bearer tokens](https://cloud.google.com/docs/authentication/token-types#bearer) and [sender-constrained tokens](https://docs.verify.ibm.com/ibm-security-verify-access/docs/tasks-certboundaccesstoken). Sender-constrained tokens require the requesting client to prove possession of a private key to use the token. Proving possession of a private key guarantees the token can't be used independently. Sender-constrained tokens can be implemented in two ways:

- [Demonstrating Proof of Possession (DPoP)](https://datatracker.ietf.org/doc/html/rfc9449)
- [Mutual-TLS (MTLS)](https://datatracker.ietf.org/doc/html/rfc8705)

### ID tokens

ID tokens are security tokens that confirm a user’s successful authentication. The tokens allow the client to verify the user’s identity. The JWT token server issues ID tokens containing claims with user information. ID tokens are always in [JWT](https://jwt.io/introduction) format.

ID tokens ***should never*** be used to access APIs.

### Other tokens

There are many types of tokens, including access and ID tokens, as specified by OpenID Connect and OAuth standards. Refresh tokens can be used to refresh a UI app without re-authenticating the user. [OAuth JAR tokens](https://datatracker.ietf.org/doc/rfc9101/) can securely send authorization requests. Verifiable credentials flows utilize JWT types for issuing or verifying credentials. It is crucial to use tokens according to the specifications. See the standards links provided later in this article for more information.

## Using JWT tokens to secure an API

When using JWT access tokens for API authorization, the API grants or denies access based on the provided token. If the request is not authorized, a 401 or 403 response is returned. The API shouldn't redirect the user to the identity provider to obtain a new token or request additional permissions. The app consuming the API is responsible for acquiring an appropriate token. This ensures a clear separation of concerns between the API (authorization) and the consuming client app (authentication).

### 401 Unauthorized

A 401 Unauthorized response indicates that the provided access token doesn't meet the required standards. This could be due to several reasons, including:

* **Invalid signature**: The token's signature doesn't match, suggesting potential tampering.
* **Expiration**: The token has expired and is no longer valid.
* **Incorrect claims**: Critical claims within the token, such as the audience (`aud`) or issuer (`iss`), are missing or invalid.

The [OAuth specifications](https://learn.microsoft.com/entra/identity-platform/access-token-claims-reference) provide detailed guidelines on the required claims and their validation. 

### 403 Forbidden

A [403 Forbidden](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/403) response typically indicates that the authenticated user lacks the necessary permissions to access the requested resource. This is distinct from authentication issues, e.g. an invalid token, and is unrelated to the standard claims within the access token.

In ASP.NET Core, you can enforce authorization using:

[Requirements and policies](/aspnet/core/security/authorization/policies?view=aspnetcore-9.0): Define custom requirements, e.g., "Must be an administrator" and associate them with policies.
[Role-based authorization](/aspnet/core/security/authorization/roles*): Assign users to roles e.g., "Admin," "Editor", and restrict access based on those roles.

## What role has OIDC and/or OAuth when using bearer tokens?

When an API uses JWT access tokens for authorization, the API only validates the access token, not on how the token was obtained.

OpenID Connect (OIDC) and OAuth 2.0 provide standardized, secure frameworks for token acquisition. Token acquisition varies depending on the type of app. Due to the complexity of secure token acquisition, it's highly recommended to rely on these standards:

* For apps acting on behalf of a user and an application: OIDC is the preferred choice, enabling delegated user access. In web apps, the confidential code flow with [Proof Key for Code Exchange](https://oauth.net/2/pkce/) (PKCE) is recommended for enhanced security.
* If the app has no user: The OAuth 2.0 client credentials flow is suitable for obtaining application access tokens.

## Implementing JWT bearer token authentication

The [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) Nuget package can be used to validate the JWT bearer tokens.

JWT bearer tokens should be fully validated in an API. The following should be validated:

*  Signature, for trust and integrity. This ensures the token was created by the designated secure token service and has not been tampered with.
*  Issuer claim with the expected value.
*  Audience claim with the expected value.
*  Token expiration.
*  Token type. Required in [RFC 9068](https://datatracker.ietf.org/doc/rfc9068/) (`"application/at+jwt"`)

The following claims are required for OAuth 2.0 access tokens: `iss`, `exp`, `aud`, `sub`, `client_id`, `iat, and`jti`.

If any of these claims or values are incorrect, the API should return a 401 response.

### JWT bearer token basic validation

A basic implementation of the [AddJwtBearer](/dotnet/api/microsoft.extensions.dependencyinjection.jwtbearerextensions.addjwtbearer) can validate just the audience and the issuer. The signature must be validated so that the token can be trusted and that it hasn't been tampered with.

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(jwtOptions =>
{
	jwtOptions.Authority = "https://{--your-authority--}";
	jwtOptions.Audience = "https://{--your-audience--}";
});
```

### JWT bearer token explicit validation

The [AddJwtBearer](/dotnet/api/microsoft.extensions.dependencyinjection.jwtbearerextensions.addjwtbearer) method provides multiple configurations. Some secure token providers use a non-standard metadata address and the parameter can be setup explicitly. The API can accept multiple issuers or audiences. The [ValidTypes](/dotnet/api/microsoft.identitymodel.tokens.tokenvalidationparameters.validtypes) types can be used to validate the "at+jwt" header if the value is supported.

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

APIs often need to accommodate access tokens from various issuers. Supporting multiple token issuers in an API can be accomplished by:

* **Separate APIs**: Create distinct APIs with dedicated authentication schemes for each issuer.
* [AddPolicyScheme](/dotnet/api/microsoft.aspnetcore.authentication.authenticationbuilder.addpolicyscheme): This method can define multiple authentication schemes and implement logic to select the appropriate scheme based on token properties (e.g., issuer, claims). This approach allows for greater flexibility within a single API.

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
### Forcing the bearer authentication

[SetFallbackPolicy](/dotnet/api/microsoft.aspnetcore.authorization.authorizationoptions.fallbackpolicy) can be used to require authentication if no policy is defined. 

```csharp
var requireAuthPolicy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();

builder.Services.AddAuthorizationBuilder()
	.SetFallbackPolicy(requireAuthPolicy);
```

The [Authorize](/dotnet/api/microsoft.aspnetcore.authorization.authorizeattribute) attribute can also be used to force the authentication. If multiple schemes are used, the bearer scheme needs to be set.

```csharp
[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
```

## Recommended approaches to create a JWT

Insecure handling of access tokens, such as weak authentication or storing tokens in vulnerable client-side storage, can lead to significant security vulnerabilities. For example, storing access tokens directly in the browser using local storage, session storage, or web workers. The following section contains best practices for apps using and creating access tokens.

### Use standards

Standards like OpenID Connect or OAuth should **always**** be used when creating access tokens. Access tokens should **not**** be created in production apps without adhering to the security precautions outlined in this article. Creating access tokens should be limited to test scenarios.

### Use asymmetric keys

Asymmetric keys should **always** be used when creating access tokens. The public key is available in the well known endpoints and the API clients can validate the signature of the access token using the public key.

### Never create an access token from a username/password request

You should **NOT** create an access token from a username/password request. Username/password requests aren't authenticated and are vunerable to impersonation and phishing attacks. Access tokens should only be created using an OpenID Connect flow or an OAuth standard flow. Deviating from these standards can result in an insecure app.

### Use cookies

For secure web apps, a backend is required to store access tokens on a trusted server.  Only a secure HTTP only cookie is shared on the client browser. See the [OIDC authentication documentation](/aspnet/core/security/authentication/configure-oidc-web-authentication) for how to do this in an ASP.NET Core web app.

## Downstream APIs

APIs occasionally need to access user data from downstream APIs on behalf of the authenticated user in the calling app. While implementing an OAuth client credentials flow is an option, it necessitates full trust between the two API apps. A more secure approach involves using a zero-trust strategy with a delegated user access token. This approach:

* Enhances security by granting the API only the necessary permissions for that specific user.
* Requires the API to create the new access token for the user calling the app and the API.

There are several ways to implement a zero-trust strategy with a delegated user access token:

### Use OAuth 2.0 Token Exchange to request a new delegated access token

This is a good way to implement this requirement but it's complicated if you must implement the OAuth flow. 

See [OAuth 2.0 Token Exchange](https://datatracker.ietf.org/doc/html/rfc8693)

### Use Microsoft on behalf of flow to request a new delegated access token

Using the [Microsoft Identity Web authentication library](/entra/msal/dotnet/microsoft-identity-web/) is the easiest and a secure approach. It only works with Microsoft Entra ID, Microsoft Entra External ID.

### Use the same delegated access token sent to the API

This is easy to implement but the access token has access to both APIs. Yarp reverse proxy can be used to implement this. This is easy to implement.

### Use OAuth client credentials flow and use an application access token
This is easy to implement but the client application has full application access and not a delegated access token. The token should be cached in the client API application.

> Note
> Any app-to-app security would also work. Certificate authentication can be used or in Azure a managed identity can be used. 

## Handling access tokens

When using access tokens in a client application, the access tokens need to be rotated, persisted and stored somewhere on the server. In a web application, cookies are used to secure the session. The cookies should not contain the access tokens as the size of the cookie would become too large.

Duende.AccessTokenManagement.OpenIdConnect is a great Nuget package for handling and managing access tokens in the client application. 

> Note
> If deploying the production, the cache should work in a mutli-instance deployment and a persistent cache is normally required.

Some secure token servers encrypt the access tokens. Access tokens do not require any format. When using OAuth introspection, a reference token is used instead of an access token. A client (UI) application should never open an access token as the access token is not intended for this. Only an API for which the access token was created for should open the access token. 

* Do not open access tokens in a UI application
* Do not send the ID token to the APIs
* Access tokens can have any format
* Access tokens can be encrypted
* Access tokens expire and need to be rotated
* Access tokens are persisted on a secure backend server

## YARP

YARP (Yet Another Reverse Proxy) is a great tool for handling http requests and forwarding the requests to other APIs. YARP can implement security logic for acquiring new access credentials. YARP is used a lot in the backend for frontend (BFF) security architecture.

## Testing APIs

Testing secure APIs can be implemented in different ways. Integration tests and containers with access tokens can be used to test the APIs. You can also create the access tokens using the dotnet user-jwts tool.

[Manage JSON Web Tokens in development with dotnet user-jwts](xref:security/authentication/jwt)

Ensure that security problems are **not** introduced into the API for testing purposes. Testing becomes more challenging when delegated access tokens are used, as these tokens can only be created through a UI and an OpenID Connect flow. If a test tool is used to create delegated access tokens, security features must be disabled for testing. It's essential that these features are only disabled in the test environment.

Create dedicated and isolated test environments where security features can safely be disable or modified. Ensure these changes are strictly limited to the test environment.

### Use Swagger, Curl and other API UI tools

Swagger and Curl are great UI tools for testing APIs. For the tools to work, the API can produce an Open API document and this can be loaded into the client testing tool. A security flow to acquire a new access token can be added to the API Open API file. 

> Warning
> Do not deploy insecure security test flows to production.

When implementing a Swagger UI for an API, you should normally not deploy the UI to production as the security must be weakened to allow this to work. 

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

[Microsoft identity platform and OAuth 2.0 On-Behalf-Of flow](/azure/active-directory/develop/v2-oauth2-on-behalf-of-flow)

[OAuth 2.0 Token Exchange](https://datatracker.ietf.org/doc/html/rfc8693)

[JSON Web Token (JWT) Profile for OAuth 2.0 Access Tokens](https://datatracker.ietf.org/doc/html/rfc9068)
