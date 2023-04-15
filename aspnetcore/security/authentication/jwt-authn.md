---
title: Generate tokens with dotnet user-jwts
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

## Synopsis

```dotnetcli
dotnet user-jwts [<PROJECT>] [command]
dotnet user-jwts [command] -h|--help
```

## Description

Creates and manages project specific local JSON Web Tokens.

## Arguments

`PROJECT | SOLUTION`

The MSBuild project to apply a command on. If a project is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* and uses that file.

<!-- Once solutions are supported delete the preceding and uncomment this section 

```dotnetcli
dotnet user-jwts [<PROJECT>|<SOLUTION>] [command]
dotnet user-jwts [command] -h|--help
```

## Description

Creates and manages project specific local JSON Web Tokens.

## Arguments

`PROJECT | SOLUTION`

The MSBuild project or solution to apply a command on. If a project or solution file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj* or *sln*, and uses that file.

-->

## Commands

| Command  | Description |
| ------------- | ------------- |
| clear  |  Delete all issued JWTs for a project. |
| create | Issue a new JSON Web Token.   |
| remove | Delete a given JWT. |
| key | Display or reset the signing key used to issue JWTs. |
| list | Lists the JWTs issued for the project. |
| print | Display the details of a given JWT. |

### Create

Usage: `dotnet user-jwts create [options]`

| Option  | Description |
| ------------- | ------------- |
|  -p \| --project | The path of the project to operate on. Defaults to the project in the current directory. |
| --scheme | The scheme name to use for the generated token. Defaults to 'Bearer'. |
| -n \| --name | The name of the user to create the JWT for. Defaults to the current environment user. |
| --audience | The audiences to create the JWT for. Defaults to the URLs configured in the project's launchSettings.json. |
| --issuer | The issuer of the JWT. Defaults to 'dotnet-user-jwts'. |
| --scope | A scope claim to add to the JWT. Specify once for each scope. |
| --role | A role claim to add to the JWT. Specify once for each role. |
| --claim | Claims to add to the JWT. Specify once for each claim in the format "name=value". |
| --not-before | The UTC date & time the JWT should not be valid before in the format 'yyyy-MM-dd [[HH:mm[[:ss]]]]'. Defaults to the date & time the JWT is created. |
| --expires-on | The UTC date & time the JWT should expire in the format 'yyyy-MM-dd [[[ [HH:mm]]:ss]]'. Defaults to 6 months after the --not-before date. Do not use this option in conjunction with the --valid-for option. |
| --valid-for | The period the JWT should expire after. Specify using a number followed by duration type like 'd' for days, 'h' for hours, 'm' for minutes, and 's' for seconds, e.g. 365d'. Do not use this option in conjunction with the --expires-on option. |
| -o \| --output | The format to use for displaying output from the command. Can be one of 'default', 'token', or 'json'. |
| -h \| --help | Show help information |

## Examples

Run the following commands to create an empty web project and add the [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) NuGet package:

```dotnetcli
dotnet new web -o MyJWT
cd MyJWT
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="~/security/authentication/jwt-authn/samples/MyJWT/Program.cs" id="snippet_1":::

In the preceding code, a GET request to `/secret` returns an `401 Unauthorized` error. A production app might get the JWT from a [Security token service](/azure/active-directory/develop/security-tokens) (STS), perhaps in response to logging in via a set of credentials. For the purpose of working with the API during local development, the `dotnet user-jwts` command line tool can be used to create and manage app-specific local JWTs.

The `user-jwts` tool is similar in concept to the  [user-secrets](xref:security/app-secrets) tool, it can be used to manage values for the app that are only valid for the developer on the local machine. In fact, the user-jwts tool utilizes the `user-secrets` infrastructure to manage the key that the JWTs are signed with, ensuring it’s stored safely in the user profile.

The `user-jwts` tool hides implementation details, such as where and how the values are stored. The tool can be used without knowing the implementation details. The values are stored in a JSON file in the local machine's user profile folder:

# [Windows](#tab/windows)

File system path:

`%APPDATA%\Microsoft\UserSecrets\<secrets_GUID>\user-jwts.json`

# [Linux / macOS](#tab/linux+macos)

File system path:

`~/.microsoft/usersecrets/<secrets_GUID>/user-jwts.json`

---

### Create a JWT

The following command creates a local JWT:

```dotnetcli
dotnet user-jwts create
```

The preceding command creates a JWT and updates the project’s `appsettings.Development.json` file with JSON similar to the following:

:::code language="csharp" source="~/security/authentication/jwt-authn/samples/MyJWT/appsettings.Development.json" highlight="7-19":::

Copy the JWT and the `ID` created in the preceding command. Use a tool like Curl to test `/secret`:

```dotnetcli
curl -i -H "Authorization: Bearer {token}" https://localhost:{port}/secret
```

Where `{token}` is the previously generated JWT.

### Display JWT security information

The following command displays the JWT security information, including expiration, scopes, roles, token header and payload, and the compact token:

```dotnetcli
dotnet user-jwts print {ID} --show-all
```

### Create a token for a specific user and scope

See [Create](#create) in this topic for supported create options.

The following command creates a JWT for a user named `MyTestUser`:

```dotnetcli
dotnet user-jwts create --name MyTestUser --scope "myapi:secrets"
```

The preceding command has output similar to the following:

```dotnetcli
New JWT saved with ID '43e0b748'.
Name: MyTestUser
Scopes: myapi:secrets

Token: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.{Remaining token deleted}
```

The preceding token can be used to test the `/secret2` endpoint in the following code:

:::code language="csharp" source="~/security/authentication/jwt-authn/samples/MyJWT/Program.cs" id="snippet_2" highlight="11-12":::
