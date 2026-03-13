---
title: Custom authorization policies with `IAuthorizationRequirementData` in ASP.NET Core MVC
ai-usage: ai-assisted
author: tdykstra
description: Learn how to specify requirements associated with the authorization policy in attribute definitions with the IAuthorizationRequirementData interface in ASP.NET Core MVC.
monikerRange: '>= aspnetcore-8.0'
ms.author: tdykstra
ms.date: 03/11/2026
uid: mvc/security/authorization/iard
---
# Custom authorization policies with `IAuthorizationRequirementData` in ASP.NET Core MVC

This article provides a demonstration on how to use <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> to define custom authorization policies in ASP.NET Core MVC. For general guidance on this subject, see <xref:security/authorization/iard>.

## Sample app

The MVC sample for this article is the [`AuthRequirementsData` sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData) ([how to download](xref:index#how-to-download-a-sample)). The sample app implements a minimum age handler for users, requiring a user to present a birth date claim indicating that they're at least 21 years old.

## Demonstration

Test the sample with [`dotnet user-jwts`](xref:security/authentication/jwt) and curl.

From the project's folder in a command shell, execute the following command to create a JWT bearer token with a birth date claim that makes the user over 21 years old:

```dotnetcli
dotnet user-jwts create --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=1989-01-01
```

The output produces a token after "`Token:`" in the command shell:

```dotnetcli
New JWT saved with ID '{JWT ID}'.
Name: {USER}
Custom Claims: [http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=1989-01-01]

Token: {TOKEN}
```

Set the value of the token (where the `{TOKEN}` placeholder appears in the preceding output) aside for use later.

You can decode the token in an online JWT decoder, such as [`jwt.ms`](https://jwt.ms/) to see its contents, revealing that it contains a `birthdate` claim with the user's birth date:

```json
{
  "alg": "HS256",
  "typ": "JWT"
}.{
  "unique_name": "guard",
  "sub": "guard",
  "jti": "5316e1b4",
  "birthdate": "1989-01-01",
  "aud": "https://localhost:51100",
  "nbf": 1773320013,
  "exp": 1781268813,
  "iat": 1773320014,
  "iss": "dotnet-user-jwts"
}.[Signature]
```

Execute the command again with a `dateofbirth` value that makes the user under the age of 21:

```dotnetcli
dotnet user-jwts create --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=2020-01-01
```

Set the value of second token aside.

Start the app in Visual Studio or with the `dotnet watch` command in the .NET CLI.

In a command shell, use the .NET CLI to execute the following `curl.exe` command to request the `api/greetings/hello` endpoint. Replace the `{TOKEN}` placeholder with the first JWT bearer token that you saved earlier:

```dotnetcli
curl.exe -i -H "Authorization: Bearer {TOKEN}" https://localhost:51100/api/greetings/hello
```

The output indicates success because the user's birth date claim indicates that they're at least 21 years old:

```dotnetcli
HTTP/1.1 200 OK
Content-Type: text/plain; charset=utf-8
Date: Thu, 15 May 2025 22:58:10 GMT
Server: Kestrel
Transfer-Encoding: chunked

Hello {USER}!
```

Logging indicates that the age requirement was met:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Evaluating authorization requirement for age >= 21":::  
> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Minimum age authorization requirement 21 satisfied":::

Re-execute the `curl.exe` command with the second token, which indicates the user is under 21 years old. The output indicates that the requirement isn't met. Access to the endpoint is forbidden (status code 403):

```dotnetcli
HTTP/1.1 403 Forbidden
Content-Length: 0
Date: Thu, 15 May 2025 22:58:36 GMT
Server: Kestrel
```

Logging indicates that the age requirement wasn't met:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Evaluating authorization requirement for age >= 21":::  
> :::no-loc text="MinimumAgeAuthorizationHandler: Information: Current user's DateOfBirth claim (2020-01-01) doesn't satisfy the minimum age authorization requirement 21":::
