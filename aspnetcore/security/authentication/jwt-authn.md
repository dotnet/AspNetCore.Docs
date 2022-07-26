---
title: JWT authentication and 
author: rick-anderson
description: Learn how to set up two-factor authentication (2FA) with an ASP.NET Core app.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.date: 09/22/2018
ms.custom: "mvc, seodec18"
uid: security/authentication/2fa
---

By [Rick Anderson](https://twitter.com/RickAndMSFT)

# Manage JSON Web Tokens in development with dotnet user-jwts

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
