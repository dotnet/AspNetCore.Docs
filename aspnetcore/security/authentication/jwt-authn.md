---
title: JWT authentication and 
author: rick-anderson
description: Learn how to set up manage JSON Web Tokens in development with dotnet user-jwts
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.date: 09/22/2018
ms.custom: "mvc, seodec18"
uid: security/authentication/jwt
---

# Manage JSON Web Tokens in development with dotnet user-jwts

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The `dotnet user-jwts` command line tool can create and manage app specific local [JSON Web Tokens](https://jwt.io/introduction) (JWTs).

## Name

`dotnet user-jwts` - Cleans the output of a project.

## Synopsis

```dotnetcli
dotnet user-jwts [<PROJECT>|<SOLUTION>] [command]
dotnet user-jwts [command] -h|--help
```

## Description

Create and manages app specific local JSON Web Tokens.

## Arguments

`PROJECT | SOLUTION`

The MSBuild project or solution to apply a command on. If a project or solution file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* or *sln*, and uses that file.

## Commands

| Command  | Description |
| ------------- | ------------- |
| clear  |  Delete all issued JWTs for a project |
| create | Issue a new JSON Web Token   |
| delete | Delete a given JWT |
| key | Display or reset the signing key used to issue JWTs |
| list | Lists the JWTs issued for the project |
| print | Print the details of a given JWT |

## Examples

Run the following commands to create an empty web project and add the [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) NuGet package:

```dotnetcli
dotnet new web -o MyJWT
cd MyJWT
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --prerelease
```

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="~/security/authentication/jwt-authn/samples/MyJWT/Program.cs" :::

In the preceding code, a GET request to `/secret` returns an `401 Unauthorized` error. A production app might get the JWT from a [Security token service](/azure/active-directory/develop/security-tokens) (STS), perhaps in response to logging in via a set of credentials. Ror the purpose of working with the API during local development, the `dotnet user-jwts` command line tool can be used to create and manage app-specific local JWTs.

The `user-jwts` tool is similar in concept to the  [user-secrets](xref:security/app-secrets) tool, in that it can be used to manage values for the app that are only valid for the developer on the local machine. In fact, the user-jwts tool utilizes the user-secrets infrastructure to manage the key that the JWTs will be signed with, ensuring it’s stored safely in the user profile.

The `user-jwts` tool hides implementation details, such as where and how the values are stored. The tool can be used without knowing the implementation details. The values are stored in a JSON file in the local machine's user profile folder:

# [Windows](#tab/windows)

File system path:

`%APPDATA%\Microsoft\UserSecrets\<secrets_GUID>\secrets.json`

# [Linux / macOS](#tab/linux+macos)

File system path:

`~/.microsoft/usersecrets/<secrets_GUID>/secrets.json`

---

### Create a JWT

The following commands create a local JWT:

```dotnetcli
dotnet user-secrets init
dotnet user-jwts create
```

First, we have to initialize the user secrets system for our project by calling dotnet user-secrets init and dotnet user-secrets list (note this will be done for you automatically by dotnet user-jwts in a future preview release):