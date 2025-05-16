---
title: Custom authorization policies with `IAuthorizationRequirementData`
author: rick-anderson
description: Learn how to specify requirements associated with the authorization policy in attribute definitions with the IAuthorizationRequirementData interface.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 5/16/2025
uid: security/authorization/iard
---
# Custom authorization policies with `IAuthorizationRequirementData`

Use the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> interface to specify requirements associated with the authorization policy in attribute definitions.

## Sample app

The complete sample described in this article is the [AuthRequirementsData sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData) ([how to download](xref:blazor/fundamentals/index#sample-apps)). The sample app implements a minimum age handler for users, requiring a user to present a birth date claim indicating that they're at least 21 years old.

## Minimum age authorize attribute

The `MinimumAgeAuthorizeAttribute` implementation of <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> sets an authorization age:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizeAttribute.cs":::

## Minimum age authorization handler

The `MinimumAgeAuthorizationHandler` class handles the single <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> provided by `MinimumAgeAuthorizeAttribute`, as specified by the generic parameter `MinimumAgeAuthorizeAttribute`.

The `HandleRequirementAsync` method:

* Gets the user's birth date claim.
* Obtains the user's age from the claim.
* Adjusts age if the user hasn't had a birthday this year.
* Marks the authorization requirement succeeded if the user meets the age requirement.
* Implements logging for demonstration purposes.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizationHandler.cs":::

The `MinimumAgeAuthorizationHandler` is registered as a scoped <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler> service in the app's `Program` file:

```csharp
builder.Services.AddSingleton<IAuthorizationHandler,
    MinimumAgeAuthorizationHandler>();
```

The `GreetingsController` displays the user's name when they satisfy the minimum age policy:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Controllers/GreetingsController.cs":::

JWT bearer authentication services are added in the app's `Program` file:

```csharp
builder.Services.AddAuthentication().AddJwtBearer();
```

The app settings file (`appsettings.json`) configures the audience and issuer for JWT bearer authentication. The localhost audience matches the localhost address specified by `applicationUrl` in the app's launch profile (`Properties/launchSettings.json`):

```json
"Authentication": {
  "Schemes": {
    "Bearer": {
      "ValidAudiences": [
        "https://localhost:51100"
      ],
      "ValidIssuer": "dotnet-user-jwts"
    }
  }
}
```

## Demonstration

The sample can be tested with [`dotnet user-jwts`](xref:security/authentication/jwt) and curl.

From the project's folder in a console, execute the following command to create a JWT bearer token with a birth date claim that makes the user over 21 years old:

```dotnetcli
dotnet user-jwts create --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=1989-01-01
```

The output produces a token after "`Token`" in the console:

```dotnetcli
New JWT saved with ID '{JWT ID}'.
Name: {USER}
Custom Claims: [http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=1989-01-01]

Token: {TOKEN}
```

Set the value of the token (`{TOKEN}` placeholder) aside for use later.

You can decode the token in an online JWT decoder, such as [`jwt.ms`](https://jwt.ms/) to see its contents, revealing that it contains a `birthdate` claim with the user's birth date:

```json
{
  "alg": "HS256",
  "typ": "JWT"
}.{
  "unique_name": "{USER}",
  "sub": "{USER}",
  "jti": "{JWT ID}",
  "birthdate": "1989-01-01",
  "aud": [
    "https://localhost:51100",
    "http://localhost:51101"
  ],
  "nbf": 1747315312,
  "exp": 1755264112,
  "iat": 1747315313,
  "iss": "dotnet-user-jwts"
}.[Signature]
```

Execute the command again with a `dateofbirth` value that makes the user presenting the claim under the age of 21:

```dotnetcli
dotnet user-jwts create --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=2020-01-01
```

Set the value of second token aside.

Start the app in Visual Studio or with the `dotnet watch` command in the .NET CLI.

In the .NET CLI, execute the following `curl.exe` command to request the `api/greetings/hello` endpoint. Replace the `{TOKEN}` placeholder with the first JWT bearer token that you saved earlier:

```dotnetcli
curl.exe -i -H "Authorization: Bearer {TOKEN}" https://localhost:51100/api/greetings/hello
```

The output in the console indicates success because the user's birth date claim indicates that they're at least 21 years old:

```dotnetcli
HTTP/1.1 200 OK
Content-Type: text/plain; charset=utf-8
Date: Thu, 15 May 2025 22:58:10 GMT
Server: Kestrel
Transfer-Encoding: chunked

Hello {USER}!
```

Logging indicates that the age requirement was met:

> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Evaluating authorization requirement for age >= 21":::  
> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Minimum age authorization requirement 21 satisfied":::

Re-execute the `curl` command with the second token, which indicates the user is under 21 years old. The output indicates that the requirement wasn't met. Access to the endpoint is forbidden (status code 403):

```dotnetcli
HTTP/1.1 403 Forbidden
Content-Length: 0
Date: Thu, 15 May 2025 22:58:36 GMT
Server: Kestrel
```

> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Evaluating authorization requirement for age >= 21":::  
> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Current user's DateOfBirth claim (2020-01-01) doesn't satisfy the minimum age authorization requirement 21":::
