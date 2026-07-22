---
title: Generate tokens with dotnet user-jwts
author: tdykstra
description: Learn how to generate and manage JSON Web Tokens in development with the dotnet user-jwts command.
monikerRange: '>= aspnetcore-7.0'
ms.author: tdykstra
ms.date: 05/11/2026
uid: security/authentication/jwt

# customer intent: As an ASP.NET developer, I want to use the dotnet user-jwts command, so I can generate and manage JSON Web Tokens in development.
---

# Manage JSON Web Tokens in development with dotnet user-jwts

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The `dotnet user-jwts` command line tool can create and manage app specific local [JSON Web Tokens](https://www.jwt.io/introduction#what-is-json-web-token) (JWTs).

This article provides syntax details for the command and examples.

## Synopsis

```dotnetcli
dotnet user-jwts [<PROJECT>] [command]
dotnet user-jwts [command] -h|--help
```

## Description

Creates and manages project specific local JSON Web Tokens.

## Arguments

`PROJECT | SOLUTION`

The MSBuild project to apply a command on. If a project isn't specified, MSBuild searches the current working directory for a file that has a file extension that ends in *proj*. It then uses that file to obtain the project information for the command.

<!-- When solutions are supported, delete the preceding and uncomment this section

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
| -------- | ----------- |
| `clear`  | Delete all issued JWTs for a project. |
| `create` | Issue a new JSON Web Token.   |
| `remove` | Delete a given JWT. |
| `key`    | Display or reset the signing key used to issue JWTs. |
| `list`   | List the JWTs issued for the project. |
| `print`  | Display the details of a given JWT. |

### Options for the create command

Usage: `dotnet user-jwts create [options]`

| Option  | Description |
| ------- | ----------- |
| `-p \| --project` | The path of the project to operate on. Defaults to the project in the current directory. |
| `--scheme`        | The scheme name to use for the generated token. Defaults to `Bearer`. |
| `-n \| --name`    | The name of the user to create the JWT for. Defaults to the current environment user. |
| `--audience`      | The audiences to create the JWT for. Defaults to the URLs configured in the project's _launchSettings.json_ file. |
| `--issuer`        | The issuer of the JWT. Defaults to `dotnet-user-jwts`. |
| `--scope`         | A scope claim to add to the JWT. Specify once for each scope. |
| `--role`          | A role claim to add to the JWT. Specify once for each role. |
| `--claim`         | Claims to add to the JWT. Specify once for each claim in the format `name=value`. |
| `--not-before`    | The UTC date and time at which the JWT becomes valid, in the format `yyyy-MM-dd [[HH:mm[[:ss]]]]`. Defaults to the date and time the JWT is created. |
| `--expires-on`    | The UTC date and time at which the JWT expires, in the format `yyyy-MM-dd [[[ [HH:mm]]:ss]]`. Defaults to six months after the `--not-before` date. Don't use this option with the `--valid-for` option. |
| `--valid-for`     | The amount of time the JWT remains valid. When the time is reached, the JWT expires. Specify a number followed by the duration type (`d` days, `h` hours, `m` minutes, `s` seconds), such as `365d`. Don't use this option with the `--expires-on` option. |
| `-o \| --output`  | The format to use for displaying output from the command: `default`, `token`, or `json`. |
| `-h \| --help`    | Show help information for the command. |

## Examples

Run the following commands to create an empty web project and add the [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) NuGet package:

```dotnetcli
dotnet new web -o MyJWT
cd MyJWT
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

Replace the contents of the _Program.cs_ file with the following code:

:::code language="csharp" source="~/security/authentication/jwt-authn/samples/MyJWT/Program.cs" id="snippet_1":::

In the preceding code, a GET request to the `/secret` endpoint returns a `401 Unauthorized` error. A production app might get the JWT from a [Security token service](/entra/identity-platform/security-tokens), perhaps in response to signing in with credentials. When you use the API during local development, the `dotnet user-jwts` command line tool can be used to create and manage app-specific local JWTs.

The `user-jwts` tool is similar in concept to the [user-secrets](xref:security/app-secrets) tool. It can be used to manage values for the app that are valid only for the developer on the local machine. In fact, the `user-jwts` tool utilizes the `user-secrets` infrastructure to manage the key that the JWTs are signed with. This approach ensures the key is stored safely in the user profile.

The `user-jwts` tool hides implementation details, such as where and how the values are stored. The tool can be used without knowing the implementation details.

The values are stored in a JSON file in the local machine's user profile folder:

- **Windows**: _%APPDATA%\Microsoft\UserSecrets\<secrets_GUID>\user-jwts.json_

- **Linux/macOS**: _~/.microsoft/usersecrets/<secrets_GUID>/user-jwts.json_

### Create a JWT

The following command creates a local JWT:

```dotnetcli
dotnet user-jwts create
```

The preceding command creates a JWT and updates the project `appsettings.Development.json` file with JSON similar to the following example:

:::code language="csharp" source="~/security/authentication/jwt-authn/samples/MyJWT/appsettings.Development.json" highlight="7-19":::

Copy the JWT and the `ID` created in the preceding command. Use a tool like Curl to test the `/secret` endpoint, where `{token}` is the previously generated JWT:

```dotnetcli
curl -i -H "Authorization: Bearer {token}" https://localhost:{port}/secret
```

### Display JWT security information

The following command displays the JWT security information, including expiration, scopes, roles, token header and payload, and the compact token:

```dotnetcli
dotnet user-jwts print {ID} --show-all
```

### Create a token for a specific user and scope

The following command creates a JWT for a user named `MyTestUser`. For the supported `create` options, see the [Options for the create command](#options-for-the-create-command) section.

```dotnetcli
dotnet user-jwts create --name MyTestUser --scope "myapi:secrets"
```

The preceding command has output similar to the following example:

```dotnetcli
New JWT saved with ID '43e0b748'.
Name: MyTestUser
Scopes: myapi:secrets

Token: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.{Remaining token deleted}
```

The preceding token can be used to test the `/secret2` endpoint in the following code:

:::code language="csharp" source="~/security/authentication/jwt-authn/samples/MyJWT/Program.cs" id="snippet_2" highlight="11-12":::

## Related content

- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
- [JSON Web Tokens](https://www.jwt.io/introduction#what-is-json-web-token)
