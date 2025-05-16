---
title: Custom authorization policies with `IAuthorizationRequirementData`
author: rick-anderson
description: Learn how to add  custom authorization policies with IAuthorizationRequirementData.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 5/15/2025
uid: security/authorization/iard
---
# Custom authorization policies with `IAuthorizationRequirementData`

XXXXXXXXXX

## Sample app

The complete sample can be found in the [AuthRequirementsData](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData) folder of the [AspNetCore.Docs.Samples](https://github.com/dotnet/AspNetCore.Docs.Samples) repository.

## Minimum age authorization handler

Consider the following sample that implements a custom `MinimumAgeAuthorizationHandler`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Program.cs" highlight="9":::

The `MinimumAgeAuthorizationHandler` class handles the single <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> provided by the `MinimumAgeAuthorizeAttribute` implementation of <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData>, as specified by the generic parameter `MinimumAgeAuthorizeAttribute`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="7,19":::

The `GreetingsController` displays the user's name when they satisfy the minimum age policy:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Controllers/GreetingsController.cs" highlight="10":::

## Demonstration

The sample can be tested with [`dotnet user-jwts`](xref:security/authentication/jwt) and curl.

From the project's folder in a console, execute the following command to create a JWT bearer token with a birth date claim that makes the user over 16 years old:

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

Execute the command again with a `dateofbirth` value that makes the user presenting the claim under the age of 16:

```dotnetcli
dotnet user-jwts create --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=2020-01-01
```

Set the value of second token aside.

Start the app in Visual Studio or with the `dotnet watch` command in the .NET CLI.

In the .NET CLI, execute the following `curl.exe` command to request the `api/greetings/hello` endpoint. Replace the `{TOKEN}` placeholder with the first JWT bearer token that you saved earlier:

```dotnetcli
curl.exe -i -H "Authorization: Bearer {TOKEN}" https://localhost:51100/api/greetings/hello
```

The output in the console indicates success because the user's birth date claim indicates that they're at least 16 years old:

```dotnetcli
HTTP/1.1 200 OK
Content-Type: text/plain; charset=utf-8
Date: Thu, 15 May 2025 22:58:10 GMT
Server: Kestrel
Transfer-Encoding: chunked

Hello {USER}!
```

Logging indicates that the age requirement was met:

> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Evaluating authorization requirement for age >= 16":::  
> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Minimum age authorization requirement 16 satisfied":::

Re-execute the `curl` command with the second token, which indicates the user is under 16 years old. The output indicates that the requirement wasn't met. Access to the endpoint is forbidden (status code 403):

```dotnetcli
HTTP/1.1 403 Forbidden
Content-Length: 0
Date: Thu, 15 May 2025 22:58:36 GMT
Server: Kestrel
```

> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Evaluating authorization requirement for age >= 16":::  
> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Current user's DateOfBirth claim (2020-01-01) doesn't satisfy the minimum age authorization requirement 16":::
