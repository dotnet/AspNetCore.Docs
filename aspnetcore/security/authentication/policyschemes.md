---
title: Policy schemes in ASP.NET Core
author: rick-anderson
description: Authentication policy schemes make it easier to have a single logical authentication scheme
ms.author: riande
ms.date: 12/05/2019
uid: security/authentication/policyschemes
---

# Policy schemes in ASP.NET Core

Authentication policy schemes make it easier to have a single logical authentication scheme potentially use multiple approaches. For example, a policy scheme might use Google authentication for challenges, and cookie authentication for everything else. Authentication policy schemes make it:

* Easy to forward any authentication action to another scheme.
* Forward dynamically based on the request.

All authentication schemes that use derived <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions> and the associated <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601>:

* Are automatically policy schemes in ASP.NET Core 2.1 and later.
* Can be enabled via configuring the scheme's options.

[!code-csharp[sample](policyschemes/samples/AuthenticationSchemeOptions.cs?name=snippet)]

## JWT with multiple schemes

The AddPolicyScheme method can define multiple authentication schemes and implement logic to select the appropriate scheme based on token properties (e.g., issuer, claims). This approach allows for greater flexibility within a single API.

```csharp
services.AddAuthentication(options =>
{
	options.DefaultScheme = Consts.MY_POLICY_SCHEME;
	options.DefaultChallengeScheme = Consts.MY_POLICY_SCHEME;

})
.AddJwtBearer(Consts.MY_FIRST_SCHEME, options =>
{
	options.Authority = "https://your-authority";
	options.Audience = "https://your-audience";
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
	jwtOptions.Authority = Configuration["AzureAd:Authority"];
	jwtOptions.Audience = Configuration["AzureAd:Audience"]; 
})
.AddPolicyScheme(Consts.MY_POLICY_SCHEME, displayName: null, options =>
{
	options.ForwardDefaultSelector = context =>
	{
		string authorization = context.Request.Headers[HeaderNames.Authorization];
		if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
		{
			var token = authorization.Substring("Bearer ".Length).Trim();
			var jwtHandler = new JsonWebTokenHandler();

			if(jwtHandler.CanReadToken(token)) // it's a self contained access token and not encrypted
			{
				var issuer = jwtHandler.ReadJsonWebToken(token).Issuer; //.Equals("B2C-Authority"))
				if (issuer == Consts.MY_THIRD_PARTY_ISS) // Third party identity provider
				{
					return Consts.MY_THIRD_PARTY_SCHEME;
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

## Examples

The following example shows a higher level scheme that combines lower level schemes. Google authentication is used for challenges, and cookie authentication is used for everything else:

[!code-csharp[sample](policyschemes/samples/Startup.cs?name=snippet1)]

The following example enables dynamic selection of schemes on a per request basis. That is, how to mix cookies and API authentication:

 <!-- REVIEW, missing If set in public Func<HttpContext, string> ForwardDefaultSelector -->

[!code-csharp[sample](policyschemes/samples/Startup.cs?name=snippet2)]
